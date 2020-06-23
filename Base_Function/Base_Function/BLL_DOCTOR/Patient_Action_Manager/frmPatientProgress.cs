using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;
using System.IO;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmPatientProgress :DevComponents.DotNetBar.Office2007Form
    {

        DataSet dsItes;
        private InPatientInfo inPateintInfo;
        public frmPatientProgress()
        {
            InitializeComponent();
           
        }
        public frmPatientProgress(InPatientInfo inpateint)
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
            this.inPateintInfo = inpateint;
            App.GetListDatas(inpateint.PId);

        }

        private void frmPatientProgress_Load(object sender, EventArgs e)
        {
            tChart1.Header.Text = "检验检查趋势分析图";
            tChart1.Axes.Left.Title.Text = "检测值";
            //tChart1.Axes.Left.SetMinMax(0, 1000);
            tChart1.Axes.Bottom.Title.Text = "时间日期";
            tChart1.Panel.Color = Color.White;
            App.FormStytleSet(this, false);

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                string MZH = ""; 
                string zycs = "1";

                System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
                if (reg1.IsMatch(this.txtzycs.Text.Trim()))
                {
                    zycs = this.txtzycs.Text.Trim();
                }

              
                //1.自己数据库表时读取
                string Sql = "select distinct t.xmdm,t.xmmc,t.xmjg,t.cssj  from t_lis_result t ,t_in_patient p  , t_Lis_Sample a  where  a.bblsh=t.bblsh and p.pid= a.mzh "
                              + "  and  to_date(t.cssj,'YYYY-MM-DD HH24:MI:SS') between to_date('" + 
                             dateTimePicker1.Value.ToString() + "','yyyy-MM-dd HH24:MI:SS') and to_date('" +
                             dateTimePicker2.Value.ToString() + "','yyyy-MM-dd HH24:MI:SS') and a.mzh='" + inPateintInfo.PId + "'  order by t.cssj asc";

                //string Sql = "select t.xmdm,t.xmmc,t.xmjg,t.cssj  from t_lis_result t ,t_in_patient p  , t_Lis_Sample a  where a.bblsh=t.bblsh and p.pid= a.mzh "
                //             + " and t.cssj>='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and  t.cssj<='" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "'"
                //             + " and a.mzh='" + inPateintInfo.PId.Trim() + "'  order by t.cssj asc";


                //instr(a.mzh,'" + inPateintInfo.PId + "',1)>0
                //2.采用视图读取
                //string Sql = "select t.xmdm,t.xmmc,t.xmjg,to_date(t.cssj,'YYYY-MM-DD HH24:MI:SS') cssj from hnyz_zxyy.View_LIS_Result@DBHISLINK t inner join hnyz_zxyy.View_LIS_SampleInfo@DBHISLINK a on a.bblsh=t.bblsh where  t.cssj is not null and a.mzh='" + inPateintInfo.PId + "' and  (CASE WHEN translate(t.cssj, 'x1234567890', 'x') is null  THEN TO_NUMBER (t.cssj)  ELSE  null  END) between  " + dateTimePicker1.Value.ToString("yyyyMMdd") + " and " + dateTimePicker2.Value.ToString("yyyyMMdd") + " order by t.cssj asc";
                dsItes = App.GetDataSet(Sql);//数据量大，执行时间长
            }
            catch (System.Exception ex)
            {

            }
            chkItemList.Items.Clear();
            if (dsItes != null)
            {

                /*
                 * 刷新项目
                 */

                for (int i = 0; i < dsItes.Tables[0].Rows.Count; i++)
                {
                    ChkItem item = new ChkItem();
                    item.Dm = dsItes.Tables[0].Rows[i]["xmdm"].ToString();
                    item.Mc = dsItes.Tables[0].Rows[i]["xmmc"].ToString();
                    item.Jcjg = dsItes.Tables[0].Rows[i]["xmjg"].ToString();
                    item.Dtime = Convert.ToDateTime(dsItes.Tables[0].Rows[i]["cssj"].ToString());

                    if (!isHaveItem(item))
                        chkItemList.Items.Add(item);
                    chkItemList.DisplayMember = "Mc";
                    chkItemList.ValueMember = "Dm";

                }
            }
        }


        /// <summary>
        /// 判断是否已经存在项目
        /// </summary>
        /// <returns></returns>
        private bool isHaveItem(ChkItem item)
        {           
            for (int i = 0; i < chkItemList.Items.Count; i++)
            {
                ChkItem tempitem = (ChkItem)chkItemList.Items[i];
                if (item.Mc == tempitem.Mc)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 趋势分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFenxi_Click(object sender, EventArgs e)
        {
            tChart1.Series.Clear();
            for (int i = 0; i < chkItemList.CheckedItems.Count; i++)
            {

                Steema.TeeChart.Styles.Bezier templ = new Steema.TeeChart.Styles.Bezier();
                templ.Marks.Visible = true;
                templ.Marks.Style = 0;
                tChart1.Series.Add(templ);
                ChkItem tempitem=(ChkItem)chkItemList.CheckedItems[i];
                templ.Title = tempitem.Mc;
                DataRow[] temprows = dsItes.Tables[0].Select("xmdm='" + tempitem.Dm+ "'");
                for (int j = 0; j < temprows.Length; j++)
                {
                    if (App.IsNumeric(temprows[j]["xmjg"].ToString()))
                    {
                        tChart1.Series[tChart1.Series.Count - 1].Add(Convert.ToSingle(temprows[j]["xmjg"]), temprows[j]["cssj"].ToString());
                        //tChart1.Series[tChart1.Series.Count - 1].Marks = temprows[j]["xmjg"].ToString();
                    }
                }
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            string ImgBase64 = GetBase64FromImage(tChart1.Bitmap);
            string xmlstr = "<img operatercreater=\"0\" saveinfile=\"1\" height=\"244\" width=\"667\" type=\"\" src=\"\">" + ImgBase64 +
             "</img>";
            //TXTEDIT.MyDoc.InsertByXML(xmlstr);
            App.LisResault = xmlstr;
            this.Close();
        }

        public string GetBase64FromImage(Bitmap bmp)
        {
            string strbaser64 = "";
            try
            {
                //Bitmap bmp = new Bitmap(imagefile);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }
    }

    class ChkItem
    {
        private string dm;
        public string Dm
        {
            get { return dm; }
            set { dm = value; }
        }

        private string mc;
        public string Mc
        {
            get { return mc; }
            set { mc = value; }
        }

        private string jcjg;
        public string Jcjg
        {
            get { return jcjg; }
            set { jcjg = value; }
        }

        private DateTime dtime;
        public DateTime Dtime
        {
            get { return dtime; }
            set { dtime = value; }
        }
    }
}