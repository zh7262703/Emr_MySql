using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Bifrost.HisInstance
{
    /// <summary>
    /// ������
    /// </summary>
    public partial class FrmLis : DevComponents.DotNetBar.Office2007Form
    {
       // WebReference2.Service WebService;
        //WebReference_Lis.Service WebService = new WebReference_Lis.Service();
        RichTextBox rtxtBx = new RichTextBox();

        //private delegate void  GetListValue(string s);
        //public GetListValue OnGetLisValue = 

        /// <summary>
        /// ��ȡLIS�����İ�
        /// </summary>
        public EventHandler GetListValue;

        string SqlConditions = "";

        


        /// <summary>
        /// ���캯��
        /// </summary>
        public FrmLis()
        {
            InitializeComponent();
            lisoutres = new List<LisOutPutResult>();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="Pid">��������</param>
        public FrmLis(string Pid)
        {           
            InitializeComponent();
            try
            {

                //string medicare_no = App.ReadSqlVal("select medicare_no from t_in_patient t where t.Pid='" + Pid + "'", 0, "medicare_no");
                //if (!string.IsNullOrEmpty(medicare_no))
                //{
                //    if (medicare_no.Length > Pid.Length)
                //    {
                //        txtPid.Text = medicare_no;
                //    }
                //    else
                //    {
                //        txtPid.Text = Pid;
                //    }
                //}
                //else
                //{
                    txtPid.Text = Pid;
                //}
            }
            catch
            {
                txtPid.Text = Pid;
            }
            
            //txtPid.Text = Pid;
            App.FormStytleSet(this, false);
            lisoutres = new List<LisOutPutResult>();
            //App.GetListDatas(txtPid.Text);
        }
        
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="Pid">��������</param>
        public FrmLis(string Pid,string sqlconditions)
        {
            InitializeComponent();
            try
            {
                //string medicare_no = App.ReadSqlVal("select medicare_no from t_in_patient t where t.Pid='" + Pid + "'", 0, "medicare_no");
                //if (!string.IsNullOrEmpty(medicare_no))
                //{
                //    txtPid.Text = medicare_no;
                //}
                //else
                //{
                //    if (medicare_no.Length > Pid.Length)
                //    {
                //        txtPid.Text = medicare_no;
                //    }
                //    else
                //    {
                        txtPid.Text = Pid;
                //    }
                //}
            }
            catch
            {
                txtPid.Text = Pid;
            }
            //txtPid.Text = Pid;
            App.FormStytleSet(this, false);
            SqlConditions = sqlconditions;
            lisoutres = new List<LisOutPutResult>();
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patient">����ʵ����</param>
        public FrmLis(InPatientInfo patient)
        {
            InitializeComponent();
            txtPid.Text = patient.Patient_Id;
            //txtPid.Text = patient.Medicare_no;
            lisoutres = new List<LisOutPutResult>();                        
        }


        private void FrmLis_Load(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                btnSure.Visible = false;
            }            
            //UpdatePatientLis(txtPid.Text);
            btnOk_Click(sender, e);
        }


        /// <summary>
        /// ��ǰ����סԺ��
        /// </summary>
        /// <param name="pid"></param>
        private void UpdatePatientLis(string pid)
        {
           // WebReference_List.LISService Ser = new Bifrost.WebReference_List.LISService();          
            //Ser.GetReport

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //distinct
                //string Sql = "select distinct a.mzh as סԺ��,xm as ����,nl as ����,jyrq as ��������,c.yzmc as ������Ŀ,sfzh as ���֤��,bbdm as �걾����,bbmc as �걾����,jyrmc as ������,b.yzxmdm as ������Ŀ����,a.bblsh as �걾��ˮ�� from hnyz_zxyy.View_LIS_SampleInfo@DBHISLINK a inner join hnyz_zxyy.View_LIS_Result@DBHISLINK b on a.bblsh=b.bblsh inner join hnyz_zxyy.intf_emr_undruginfo@dbhislink c on b.yzxmdm=c.yzdm where mzh='" + txtPid.Text.Trim() + "'" + SqlConditions + " order by jyrq desc";
                // inner join hnyz_zxyy.intf_emr_undruginfo c on b.yzxmdm=c.yzdm  c.yzmc as ������Ŀ
                string Sql = "select distinct a.mzh as סԺ��,xm as ����,nl as ����,jyrq as ��������,b.YZXMMC as ������Ŀ,sfzh as ���֤��,bbdm as �걾����,bbmc as �걾����,jyrmc as ������,b.yzxmdm as ������Ŀ����,a.bblsh as �걾��ˮ�� from t_Lis_Sample a inner join t_lis_result b  on a.bblsh=b.bblsh where mzh='" + txtPid.Text.Trim() + "'" + SqlConditions + " order by jyrq desc";
                flgview_Patient.DataSource = App.GetDataSet(Sql).Tables[0].DefaultView;
                flgview_Patient.Refresh();

                flgview_Patient.Cols["������Ŀ����"].Visible = false;

                flgview_Patient.Cols["�걾��ˮ��"].Visible = false;

                for (int i = 1; i < flgview_Patient.Rows.Count; i++)
                {
                    flgview_Patient.Rows[i]["����"] = flgview_Patient.Rows[i]["����"].ToString().Trim();
                }  

            }
            catch(Exception ex)
            {
                App.MsgErr("LIS���ݿ�����ʧ�ܣ�����ԭ��" + ex.Message);
            }
        }

        private void flgview_Patient_Click(object sender, EventArgs e)
        {
           
        }
        private string mzh;
        private string yblsh;
        private string jyxmdm;
        private void flgview_Patient_SelChange(object sender, EventArgs e)
        {
            try
            {
                flgView_Yb.Clear();
                flgView_Gm.Clear();
                mzh = flgview_Patient[flgview_Patient.RowSel, "סԺ��"].ToString();
                yblsh = flgview_Patient[flgview_Patient.RowSel, "�걾��ˮ��"].ToString();
                jyxmdm=flgview_Patient[flgview_Patient.RowSel, "������Ŀ����"].ToString();
                string Sql = "";
                if (jyxmdm == "")
                {
                    Sql = "select xmdm as ��Ŀ����,xmmc as ��Ŀ����,xmywmc as ��ĿӢ������,xmjg as ��Ŀ���,jgdw as ��λ,ckz as �ο�ֵ��Χ,cssj as ����ʱ��,jgbz as ��־ from t_lis_result where bblsh='" + yblsh + "' and yzxmdm is null";
                }
                else
                {
                    Sql = "select xmdm as ��Ŀ����,xmmc as ��Ŀ����,xmywmc as ��ĿӢ������,xmjg as ��Ŀ���,jgdw as ��λ,ckz as �ο�ֵ��Χ,cssj as ����ʱ��,jgbz as ��־ from t_lis_result where bblsh='" + yblsh + "' and yzxmdm='" + jyxmdm + "'";
                }
                DataTable dt = App.GetDataSet(Sql).Tables[0];
                DataColumn dc = new DataColumn("dcSectFlag",typeof(bool));
                dc.Caption = "ѡ����";
                dc.DefaultValue = false;
                dt.Columns.Add(dc);
                SetTableSelFlag(dt, yblsh, jyxmdm);
                flgView_Yb.DataSource = dt;                
                flgView_Yb.Select(0, 0);
                flgView_Yb.Refresh();
                flgView_Yb.Cols["��Ŀ����"].Visible = false;
                flgView_Yb.Cols["��ĿӢ������"].Visible = false;

                //CellRange rg = flgView.GetCellRange(RowSel, colSel);
                //rg.StyleNew.ForeColor = Color.Red;

                for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                {
                    if (flgView_Yb.Rows[i]["��־"].ToString().ToUpper() == "L")
                    {
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;
                    }
                    else if (flgView_Yb.Rows[i]["��־"].ToString().ToUpper() == "H")
                    {
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.Red;
                    }


                    if (flgView_Yb.Rows[i]["��־"].ToString().ToLower() == "��")
                    {
                        flgView_Yb.Rows[i]["��Ŀ���"] = flgView_Yb.Rows[i]["��Ŀ���"] + "��";
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["��־"].Index);
                        //rg.StyleNew.BackColor = Color.Blue;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;

                    }
                    else if (flgView_Yb.Rows[i]["��־"].ToString().ToLower() == "��")
                    {
                        flgView_Yb.Rows[i]["��Ŀ���"] = flgView_Yb.Rows[i]["��Ŀ���"] + "��";
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["��־"].Index);
                        //rg.StyleNew.BackColor = Color.Red;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.Red;
                    }

                    if (flgView_Yb.Rows[i]["��Ŀ���"].ToString().ToLower() == "����")
                    {
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["��Ŀ���"].Index);
                        //rg.StyleNew.BackColor = Color.SkyBlue;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;
                    }
                    else if (flgView_Yb.Rows[i]["��Ŀ���"].ToString().ToLower() == "����")
                    {
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["��Ŀ���"].Index);
                        //rg.StyleNew.BackColor = Color.OrangeRed;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.OrangeRed;
                    }

                }

                //string Sql2 = "select xmdm as ΢�������,xmmc as ΢��������,xmywmc as ΢����Ӣ������,Kssdm as �����ش���,Kssmc as ����������,csff as ���Է���,Jyjg as ������,mgdjg as ���жȽ�� from T_LIS_RESULTMED where bblsh=" + yblsh + "";
                //string Sql2 = "select  germname ϸ������, anti_name ������,result ���,(case opertype when '0' then '�ֹ�KB��' when '1' then '����MiC��' when '2' then '�����ˣ·�' end) ʵ�鷽��,'' �ο���Χ," +
                //              " flag  ���ж�  from hnyz_zxyy.view_result_germ_yz where  bblsh = '" + yblsh + "' and patientno='" + mzh + "'";

                //flgView_Gm.DataSource = WebService.GetDataSet(Sql2).Tables[0].DefaultView;
                //flgView_Gm.Refresh();
            }
            catch
            {
                //App.MsgErr(ex.ToString());
            }
        }

        private void SetTableSelFlag(DataTable dt, string str1, string str2)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string s3 = dr["��Ŀ����"].ToString();
                bool iexists = false;
                try
                {
                    iexists = lisoutres.Exists(delegate(LisOutPutResult l) { return l.Xmdm == s3 && l.Bblsh == str1 && l.Yzxmdm == str2; });
                }
                catch (Exception ex)
                {
                    string sss = ex.ToString();
                }
                if (iexists)
                {
                    dr["dcSectFlag"] = true;
                }
                else
                {
                    dr["dcSectFlag"] = false;
                }
            }
        }

        bool flag = false;
        private void flgView_Yb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                flag = true;
            }
        }

        private void flgView_Yb_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void flgView_Yb_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                if (flgView_Yb.Rows.Count > 0)
                {
                    flgView_Yb.Rows[flgView_Yb.RowSel].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                {
                    flgView_Yb.Rows[i].Selected = false;
                }
                flgView_Yb.Rows[flgView_Yb.RowSel].Selected = true;
            }
        }

        private void flgView_Yb_Click(object sender, EventArgs e)
        {

        }

        private void flgView_Yb_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.ControlKey)
               flag = false;
        }

        private void ����CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string ChangeChar(string val)
        {           
            if (val.Contains("��"))
            {
                return val.Replace("��", "");
            }
            else if (val.Contains("��"))
            {
                return val.Replace("��", "");
            }
            return val;
        }
        /// <summary>
        /// ��ѡ�еļ����
        /// </summary>
        private List<LisOutPutResult> lisoutres = null;
        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            string strtext = "";
            for (int i = 0; i < lisoutres.Count; i++)
            {
                LisOutPutResult lop = lisoutres[i];

                string jg = "";
                if (lop.Jgdw.Contains("E"))
                {
                    jg = ChangeChar(lop.Xmjg) + "*" + lop.Jgdw;
                }
                else
                {
                    jg = ChangeChar(lop.Xmjg) + " " + lop.Jgdw;
                }
                if (strtext == "")
                {
                    strtext = lop.Xmmc + " " + jg;
                }
                else
                {
                    strtext = strtext + "," + lop.Xmmc + " " + jg;
                }
            }
            //for (int i = 0; i < flgView_Yb.Rows.Count; i++)
            //{
            //    if (flgView_Yb.Rows[i]["dcSectFlag"].ToString()== "True")
            //    {                                    
            //        if (strtext == "")
            //        {
            //            string jg = "";
            //            if (flgView_Yb.Rows[i]["��λ"].ToString().Contains("E"))
            //            {//��λ
            //                jg = ChangeChar(flgView_Yb.Rows[i]["��Ŀ���"].ToString()) + "*" + flgView_Yb.Rows[i]["��λ"].ToString();
            //            }
            //            else
            //            {
            //                jg = ChangeChar(flgView_Yb.Rows[i]["��Ŀ���"].ToString()) + " " + flgView_Yb.Rows[i]["��λ"].ToString();
            //            }
            //            strtext = flgView_Yb.Rows[i]["��Ŀ����"].ToString() + " " + jg;
            //        }
            //        else
            //        {
            //            string jg = "";
            //            if (flgView_Yb.Rows[i]["��λ"].ToString().Contains("E"))
            //            {//��λ
            //                jg = ChangeChar(flgView_Yb.Rows[i]["��Ŀ���"].ToString()) + "*" + flgView_Yb.Rows[i]["��λ"].ToString();
            //            }
            //            else
            //            {
            //                jg = ChangeChar(flgView_Yb.Rows[i]["��Ŀ���"].ToString()) + " " + flgView_Yb.Rows[i]["��λ"].ToString();
            //            }
            //            strtext = strtext + ", " + flgView_Yb.Rows[i]["��Ŀ����"].ToString() + " " + jg;
            //        }
            //    }
            //}      
            App.LisResault = strtext;
            if (GetListValue!=null)
                GetListValue(sender, e);
            this.Close();
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.LisResault = "";
            this.Close();
        }

        private void flgView_Yb_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (flgView_Yb.Cols[e.Col].Name == "dcSectFlag")
            {
                string s = flgView_Yb[e.Row, "��Ŀ����"].ToString();
                if (flgView_Yb[e.Row, e.Col].ToString() == Boolean.TrueString)
                {
                    LisOutPutResult l = new LisOutPutResult();
                    l.Bblsh = yblsh;
                    l.Yzxmdm = jyxmdm;
                    l.Xmdm = s;
                    l.Xmmc = flgView_Yb[e.Row, "��Ŀ����"].ToString();
                    l.Xmywmc = flgView_Yb[e.Row, "��ĿӢ������"].ToString();
                    l.Xmjg = flgView_Yb[e.Row, "��Ŀ���"].ToString();
                    l.Jgdw = flgView_Yb[e.Row, "��λ"].ToString();
                    l.Ckz = flgView_Yb[e.Row, "�ο�ֵ��Χ"].ToString();
                    l.Cssj = flgView_Yb[e.Row, "����ʱ��"].ToString();
                    l.Jgbz = flgView_Yb[e.Row, "��־"].ToString();
                    lisoutres.Add(l);
                }
                else
                {
                    LisOutPutResult l = lisoutres.Find(delegate(LisOutPutResult lop) { return lop.Bblsh == yblsh && lop.Yzxmdm == jyxmdm && lop.Xmdm == s; });
                    lisoutres.Remove(l);
                }
            }
        }

    }

    public class LisOutPutResult
    {
        public LisOutPutResult()
        {

        }
        private string bblsh;

        public string Bblsh
        {
            get { return bblsh; }
            set { bblsh = value; }
        }
        private string yzxmdm;

        public string Yzxmdm
        {
            get { return yzxmdm; }
            set { yzxmdm = value; }
        }
        private string xmdm; //��Ŀ����

        public string Xmdm
        {
            get { return xmdm; }
            set { xmdm = value; }
        }
        private string xmmc; //��Ŀ����

        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }
        private string xmywmc; //��ĿӢ������

        public string Xmywmc
        {
            get { return xmywmc; }
            set { xmywmc = value; }
        }
        private string xmjg; //��Ŀ���

        public string Xmjg
        {
            get { return xmjg; }
            set { xmjg = value; }
        }
        private string jgdw; //��λ

        public string Jgdw
        {
            get { return jgdw; }
            set { jgdw = value; }
        }
        private string ckz;  //�ο�ֵ��Χ

        public string Ckz
        {
            get { return ckz; }
            set { ckz = value; }
        }
        private string cssj; //����ʱ��

        public string Cssj
        {
            get { return cssj; }
            set { cssj = value; }
        }
        private string jgbz; //��־

        public string Jgbz
        {
            get { return jgbz; }
            set { jgbz = value; }
        }
    }
}