using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;

namespace Digital_Medical_Treatment
{
    public partial class frmPatientProgress : DevComponents.DotNetBar.Office2007Form
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

        }

        private void frmPatientProgress_Load(object sender, EventArgs e)
        {
            tChart1.Header.Text = "���������Ʒ���ͼ";
            tChart1.Axes.Left.Title.Text = "���ֵ";
            //tChart1.Axes.Left.SetMinMax(0, 1000);
            tChart1.Axes.Bottom.Title.Text = "ʱ������";
            tChart1.Panel.Color = Color.White;
            App.FormStytleSet(this, false);
            this.GetHistoryCheckItems(this.inPateintInfo);
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Sql = "select t.xmdm,t.xmmc,t.xmjg,t.cssj from t_lis_result t inner join t_Lis_Sample a on a.bblsh=t.bblsh where  t.cssj is not null and to_date(t.cssj,'YYYY-MM-DD HH24:MI:SS') between to_date('" + dateTimePicker1.Value.ToString() + "','yyyy-MM-dd HH24:MI:SS') and to_date('" + dateTimePicker2.Value.ToString() + "','yyyy-MM-dd HH24:MI:SS') and a.mzh='" + inPateintInfo.PId + "' order by t.cssj asc";
            dsItes = App.GetDataSet(Sql);//��������ִ��ʱ�䳤
            chkItemList.Items.Clear();
            if (dsItes != null)
            {

                /*
                 * ˢ����Ŀ
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
        /// �ж��Ƿ��Ѿ�������Ŀ
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
        /// ���Ʒ���
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
                ChkItem tempitem = (ChkItem)chkItemList.CheckedItems[i];
                templ.Title = tempitem.Mc;
                DataRow[] temprows = dsItes.Tables[0].Select("xmdm='" + tempitem.Dm + "'");
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
        #region ����������ʾ��չʾ�ļ�����Ŀ
        /// <summary>
        /// ��ȡ��ʷ���湴ѡ�ļ�����Ŀ
        /// </summary>
        /// <param name="inpatientInfo"></param>
        private void GetHistoryCheckItems(InPatientInfo inpatientInfo)
        {
            string sql = string.Empty;
            sql = "select * from t_patient_disscuss  d where  d.patient_id ='" + inpatientInfo.Id + "'";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                //�ϴ�ѡ�еļ�����Ŀ�Ĵ��룬�Զ��Ÿ���
                string checkedItems = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime begindate=DateTime.MaxValue;
                        DateTime enddate = DateTime.MinValue;
                        if (DateTime.TryParse(dt.Rows[i]["begin_check_date"].ToString(),out begindate))
                        {
                            this.dateTimePicker1.Value = begindate;
                        }
                        if (DateTime.TryParse(dt.Rows[i]["end_check_date"].ToString(), out enddate))
                        {
                            this.dateTimePicker2.Value = enddate;
                        }
                       
                        checkedItems = dt.Rows[i]["check_item_list"].ToString();
                        if (!string.IsNullOrEmpty(checkedItems))
                        {
                            this.btnSearch_Click(this, null);
                        }
                    }
                    //�ϴ�ѡ�еļ�����Ŀ�Ĵ���
                    string[] checkItems=new string[100];
                    checkItems = checkedItems.Split(',');

                    foreach (string item in checkItems)
                    {
                        for (int i = 0; i < chkItemList.Items.Count; i++)
                        {
                            ChkItem chkItem = (ChkItem)chkItemList.Items[i];
                            if(item.Equals(chkItem.Dm.ToString()))
                            {
                                chkItemList.SetItemChecked(i,true);
                            }
                        }
                    }
                    this.btnFenxi_Click(this, null);
                }
                else
                {
                    App.Msg("��ǰ�����޸û���");
                }
            }
        }
        /// <summary>
        /// ����ѡ�еļ�����Ŀ����
        /// </summary>
        private void SaveCheckItems(string savaItems)
        {
            string Sql = "update t_patient_disscuss set CHECK_ITEM_LIST ='" + savaItems + "',BEGIN_CHECK_DATE=to_timestamp('" + this.dateTimePicker1.Value.ToString() + "','yyyy-MM-dd HH24:mi:ss'),END_CHECK_DATE=to_timestamp('" + this.dateTimePicker2.Value.ToString() + "','yyyy-MM-dd HH24:mi:ss') " +
                             "where patient_id = '" + this.inPateintInfo.Id.ToString() + "' ";
            int count = App.ExecuteSQL(Sql);
            if (count > 0)
            {
                App.Msg("����ɹ���");
            }
        }
        /// <summary>
        /// ɾ����ʷ����ļ�����Ŀ
        /// </summary>
        /// <param name="inpatientInfo"></param>
        private void DeleteHistoryCheckedItem()
        {
            string Sql = "update t_patient_disscuss set CHECK_ITEM_LIST ='" + string.Empty + "',BEGIN_CHECK_DATE=to_timestamp('" +string.Empty + "','yyyy-MM-dd HH24:mi:ss'),END_CHECK_DATE=to_timestamp('" + string.Empty + "','yyyy-MM-dd HH24:mi:ss') " +
                                "where patient_id = '" + this.inPateintInfo.Id.ToString() + "' ";
            int count = App.ExecuteSQL(Sql);
            if (count > 0)
            {
                App.Msg("ɾ���ɹ���");
            }
        }
        /// <summary>
        /// ������Ҫչʾ�ļ�����Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveItems = string.Empty;
            for (int i = 0; i < chkItemList.CheckedItems.Count; i++)
            {
                ChkItem tempitem = (ChkItem)chkItemList.CheckedItems[i];
                saveItems += tempitem.Dm.ToString() + ",";
            }
            if (saveItems.Substring(saveItems.Length-1,1)==",")
            {
                saveItems=saveItems.Substring(0, saveItems.Length - 1);
                this.SaveCheckItems(saveItems);
            }
        }
        /// <summary>
        /// ���֮ǰչʾ�ļ�����Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkItemList.Items.Count; i++)
            {
                chkItemList.SetItemChecked(i, false);
            }
            this.btnFenxi_Click(this, null);
            this.DeleteHistoryCheckedItem();
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetCheckItems_Click(object sender, EventArgs e)
        {
            this.groupPanel1.Visible = true;
            this.groupPanel2.Visible = true;
        }
        #endregion

       

      
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