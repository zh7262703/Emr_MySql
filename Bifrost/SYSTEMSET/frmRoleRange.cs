using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Bifrost.SYSTEMSET;

namespace Bifrost
{
    /// <summary>
    /// 设置角色帐号的使用范围
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public partial class frmRoleRange : DevComponents.DotNetBar.Office2007Form
    {
        string Acc_Role_Id = "0";
        string Account_Type = "D";

        ArrayList CurrentRanges = new ArrayList();

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRoleRange()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        /// <param name="acc_role_id"></param>
        /// <param name="account_type"></param>
        public frmRoleRange(string acc_role_id, string account_type, ArrayList currentranges)
        {
            InitializeComponent();
            Acc_Role_Id = acc_role_id;
            Account_Type = account_type;
            CurrentRanges = currentranges;
        }

        /// <summary>
        /// 刷新范围树
        /// </summary>
        public void RefleshTrv()
        {
            try
            {
                //小科室
                string Sql_Section = "select a.*,b.sub_hospital_name from t_sectioninfo a inner join T_SUB_HOSPITALINFO b on a.shid=b.shid  where ISBELONGTOBIGSECTION='N' and ENABLE_FLAG='Y' and a.sid in (select sid from T_SECTION_AREA)";

                //小病区
                string Sql_SickArea = "select a.*,b.sub_hospital_name from t_sickareainfo a inner join T_SUB_HOSPITALINFO b on a.shid=b.shid where ISBELONGTOSECTION='N' and ENABLE_FLAG='Y'";

                //大科室
                string Sql_Big_Section = "select a.*,b.sub_hospital_name from t_sectioninfo a inner join T_SUB_HOSPITALINFO b on a.shid=b.shid where ISBELONGTOBIGSECTION='Y' and ENABLE_FLAG='Y' and a.sid in (select sid from T_SECTION_AREA)";

                //大病区
                string Sql_Big_SickArea = "select a.*,b.sub_hospital_name from t_sickareainfo a inner join T_SUB_HOSPITALINFO b on a.shid=b.shid where ISBELONGTOSECTION='Y' and ENABLE_FLAG='Y'";

                chkListRanges.Items.Clear();
                if (rdbArea.Checked)
                {
                    if (cboSubHospital.Text != "全部科室/病区")
                    {
                        Sql_SickArea = Sql_SickArea + " and a.SHID=" + cboSubHospital.SelectedValue.ToString() + "";
                    }
                    else
                    {
                        Sql_SickArea = Sql_SickArea + " order by a.sick_area_name,a.said";
                    }
                    DataSet ds = App.GetDataSet(Sql_SickArea);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Class_Rnage temprage = new Class_Rnage();
                        temprage.Acc_role_id = Acc_Role_Id;
                        temprage.Rnagename =ds.Tables[0].Rows[i]["sick_area_name"].ToString();
                        temprage.Sickarea_id = ds.Tables[0].Rows[i]["said"].ToString();
                        temprage.Section_id = "0";
                        temprage.Isbelonge = "1";
                        chkListRanges.Items.Add(temprage);
                        chkListRanges.DisplayMember = "Rnagename";

                    }
                }
                else if (rdbBigArea.Checked)
                {
                    if (cboSubHospital.Text != "全部科室/病区")
                    {
                        Sql_Big_SickArea = Sql_Big_SickArea + " and a.SHID=" + cboSubHospital.SelectedValue.ToString() + "";
                    }
                    else
                    {
                        Sql_Big_SickArea = Sql_Big_SickArea + " order by a.sick_area_name,a.said";
                    }
                    DataSet ds = App.GetDataSet(Sql_Big_SickArea);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Class_Rnage temprage = new Class_Rnage();
                        temprage.Acc_role_id = Acc_Role_Id;
                        temprage.Rnagename = ds.Tables[0].Rows[i]["sick_area_name"].ToString();
                        temprage.Sickarea_id = ds.Tables[0].Rows[i]["said"].ToString();
                        temprage.Section_id = "0";
                        temprage.Isbelonge = "1";
                        chkListRanges.Items.Add(temprage);
                        chkListRanges.DisplayMember = "Rnagename";

                    }
                }
                else if (rdbBigSection.Checked)
                {
                    if (cboSubHospital.Text != "全部科室/病区")
                    {
                        Sql_Big_Section = Sql_Big_Section + " and a.SHID=" + cboSubHospital.SelectedValue.ToString() + "";
                    }
                    else
                    {
                        Sql_Big_Section = Sql_Big_Section + " order by a.section_name,a.sid";
                    }
                    DataSet ds = App.GetDataSet(Sql_Big_Section);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Class_Rnage temprage = new Class_Rnage();
                        temprage.Acc_role_id = "0";
                        temprage.Rnagename = ds.Tables[0].Rows[i]["section_name"].ToString();
                        temprage.Sickarea_id = "0";
                        temprage.Section_id = ds.Tables[0].Rows[i]["sid"].ToString();
                        temprage.Isbelonge = "0";
                        chkListRanges.Items.Add(temprage);
                        chkListRanges.DisplayMember = "Rnagename";
                    }
                }
                else
                {
                    if (cboSubHospital.Text == "全部科室/病区")
                    {
                        if (App.UserAccount.UserInfo.User_name == "管理员")
                            Sql_Section = Sql_Section + " order by a.section_name,a.sid";
                        else
                        {
                            string sectionIds = "";
                            for (int i = 0; i < App.UserAccount.Roles.Length; i++)
                            {
                                if (App.UserAccount.Roles[i].Role_name == "科主任")
                                {
                                    for (int j = 0; j < App.UserAccount.Roles[i].Rnages.Length; j++)
                                    {
                                        if (sectionIds == "")
                                        {
                                            sectionIds = App.UserAccount.Roles[i].Rnages[j].Section_id;
                                        }
                                        else
                                        {
                                            sectionIds += "," + App.UserAccount.Roles[i].Rnages[j].Section_id;
                                        }
                                    }
                                }
                            }
                            Sql_Section = Sql_Section + " and sid in(" + sectionIds + ") order by a.section_name,a.sid";
                        }
                    }
                    else
                    {
                        Sql_Section = Sql_Section + " and a.SHID=" + cboSubHospital.SelectedValue.ToString() + "";
                    }
                    DataSet ds = App.GetDataSet(Sql_Section);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Class_Rnage temprage = new Class_Rnage();
                        temprage.Acc_role_id = "0";
                        temprage.Rnagename =ds.Tables[0].Rows[i]["section_name"].ToString();
                        temprage.Sickarea_id = "0";
                        temprage.Section_id = ds.Tables[0].Rows[i]["sid"].ToString();
                        temprage.Isbelonge = "0";
                        chkListRanges.Items.Add(temprage);
                        chkListRanges.DisplayMember = "Rnagename";
                    }
                }


                for (int i = 0; i < chkListRanges.Items.Count; i++)
                {
                    for (int j = 0; j < CurrentRanges.Count; j++)
                    {
                        Class_Rnage temprage = (Class_Rnage)chkListRanges.Items[i];
                        if (temprage.Rnagename == CurrentRanges[j].ToString())
                        {
                            chkListRanges.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch
            { }
        }

        private void frmRoleRange_Load(object sender, EventArgs e)
        {
            DataSet ds_sub_Hospital = App.GetDataSet("select * from t_sub_hospitalinfo");
            DataRow allrow = ds_sub_Hospital.Tables[0].NewRow();
            allrow["SUB_HOSPITAL_NAME"] = "全部科室/病区";
            allrow["SHID"] = "0";
            ds_sub_Hospital.Tables[0].Rows.Add(allrow);



            cboSubHospital.DataSource = ds_sub_Hospital.Tables[0].DefaultView;
            cboSubHospital.ValueMember = "SHID";
            cboSubHospital.DisplayMember = "SUB_HOSPITAL_NAME";

            //cboSubHospital.Items.Add("全部科室/病区");

            if (cboSubHospital.Items.Count > 0)
            {
                cboSubHospital.SelectedIndex = 0;
            }

            if (Account_Type == "D")
            {
                rdbSection.Checked = true;
                rdbSection.Enabled = true;
                rdbBigSection.Enabled = true;

                rdbArea.Enabled = false;
                rdbBigArea.Enabled = false;
            }
            else if (Account_Type == "N")
            {
                rdbArea.Checked = true;
                rdbArea.Enabled = true;

                rdbSection.Enabled = false;
                rdbBigSection.Enabled = false;

                rdbBigArea.Enabled = true;
            }
            else if (Account_Type == "O")
            {
                rdbArea.Enabled = false;
                rdbSection.Enabled = false;
                groupPanel1.Enabled = false;
                rdbBigArea.Enabled = false;
                rdbBigSection.Enabled = false;
            }
            else
            {
                rdbArea.Enabled = false;
                rdbSection.Enabled = false;
                groupPanel1.Enabled = false;
                rdbBigArea.Enabled = false;
                rdbBigSection.Enabled = false;
            }
            //if (App.UserAccount.UserInfo.User_name != "管理员")
            //{
            //    rdbSection.Checked = true;
            //    rdbSection.Enabled = true;
            //    rdbBigSection.Enabled = false;
            //    rdbArea.Enabled = false;
            //    rdbBigArea.Enabled = false;
            //    cboSubHospital.Enabled = false;
            //}
            cboSubHospital.Text = "全部科室/病区";
            //RefleshTrv();
                
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.UserInfo.User_name != "管理员")
                ucSectionkeep.trvTempRoleRange = new TreeView();
            else
                frmAccount.trvTempRoleRange = new TreeView();
            for (int i = 0; i < chkListRanges.CheckedItems.Count; i++)
            {
                TreeNode tn = new TreeNode();
                Class_Rnage temprage = (Class_Rnage)chkListRanges.CheckedItems[i];

                if (rdbBigSection.Checked)            //判断是大科室，还是小科室
                {
                    //获得大科室下的所有小科室
                    string sql = "select * from t_sectioninfo where ISBELONGTOBIGSECTION='N' and BELONGTO_BIGSECTION_ID='" + temprage.Section_id + "'";
                    DataSet ds = App.GetDataSet(sql);
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        TreeNode tnSmall = new TreeNode();
                        Class_Rnage smallSection = new Class_Rnage();
                        smallSection.Acc_role_id = "0";
                        smallSection.Rnagename = ds.Tables[0].Rows[j]["section_name"].ToString();
                        smallSection.Sickarea_id = "0";
                        smallSection.Section_id = ds.Tables[0].Rows[j]["sid"].ToString();
                        smallSection.Isbelonge = "0";

                        tnSmall.Tag = smallSection;
                        tnSmall.Text = smallSection.Rnagename;
                        if (App.UserAccount.UserInfo.User_name != "管理员")
                            ucSectionkeep.trvTempRoleRange.Nodes.Add(tnSmall);
                        else
                            frmAccount.trvTempRoleRange.Nodes.Add(tnSmall);
                    }
                }
                else if (rdbBigArea.Checked)       //判断是大病区，还是小病区
                {
                    //获得大病区下的所有小病区
                    string sql = "select * from t_sickareainfo where ISBELONGTOSECTION='N' and BELONGTOSECTION='" + temprage.Sickarea_id + "'";
                    DataSet ds = App.GetDataSet(sql);
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        TreeNode tnSmall = new TreeNode();
                        Class_Rnage smallArea = new Class_Rnage();
                        smallArea.Acc_role_id = Acc_Role_Id;
                        smallArea.Rnagename = ds.Tables[0].Rows[j]["sick_area_name"].ToString();
                        smallArea.Sickarea_id = ds.Tables[0].Rows[j]["said"].ToString();
                        smallArea.Section_id = "0";
                        smallArea.Isbelonge = "1";
                        tnSmall.Tag = smallArea;
                        tnSmall.Text = smallArea.Rnagename;
                        if (App.UserAccount.UserInfo.User_name != "管理员")
                            ucSectionkeep.trvTempRoleRange.Nodes.Add(tnSmall);
                        else
                            frmAccount.trvTempRoleRange.Nodes.Add(tnSmall);
                    }
                }
                else
                {
                    tn.Tag = temprage;
                    tn.Text = temprage.Rnagename;
                    if (App.UserAccount.UserInfo.User_name != "管理员")
                        ucSectionkeep.trvTempRoleRange.Nodes.Add(tn);
                    else
                        frmAccount.trvTempRoleRange.Nodes.Add(tn);
                }

            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (App.UserAccount.UserInfo.User_name != "管理员")
                ucSectionkeep.trvTempRoleRange = null;
            else
                frmAccount.trvTempRoleRange = null;
        }

        private void rdbArea_CheckedChanged(object sender, EventArgs e)
        {
            RefleshTrv();

        }

        private void rdbSection_CheckedChanged(object sender, EventArgs e)
        {
            RefleshTrv();
        }

        private void trvSectionOrSiceArea_AfterCheck(object sender, TreeViewEventArgs e)
        {
        }

        private void rdbBigArea_CheckedChanged(object sender, EventArgs e)
        {
            //RefleshTrv();
        }

        private void rdbBigSection_CheckedChanged(object sender, EventArgs e)
        {
            // RefleshTrv();
        }

        private void cboSubHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefleshTrv();
        }

        private void chkListRanges_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}