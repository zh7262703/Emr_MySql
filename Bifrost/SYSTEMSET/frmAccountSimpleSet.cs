using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost.SYSTEMSET;

namespace Bifrost
{
    /// <summary>
    /// ����û�����
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2009-12-15
    /// </summary>
    public partial class frmAccountSimpleSet : DevComponents.DotNetBar.Office2007Form
    {

        /*
         * ˵����
         * ��ģ��Ĺ��ܺͣ����ʺŹ�������һ�µģ�ֻ�����ڷ��������
         * �������û���Ϣ��ʱ��ֱ�Ӹ��û������ʺš�
         */

        private Class_User User;

        private int tagindex = 0; //0 tab1 1 tb2

        string Account_Type = "";    //�ʺ�����

        /// <summary>
        /// ��ɫʹ�÷�Χ��
        /// </summary>
        public static TreeView trvTempRoleRange;


        /// <summary>
        /// ���캯��
        /// </summary>
        public frmAccountSimpleSet(Class_User user)
        {
            InitializeComponent();            
            User = user;
            
            if (User == null)
            {
                App.MsgErr("����ѡ���û���");
                this.Close();
                return;
            }

            //txtAccount.Text = User.User_num;
            //txtAccount.ReadOnly = true;
        }

        private void frmAccountSimpleSet_Load(object sender, EventArgs e)
        {
           
            string sql = "select * from t_data_code where type=5";
            //if (User.Accounttype == "1")
            //{
            //    sql = sql + " and id not in (70,52)";
            //}
            //else
            //{
            //    sql = sql + " and id in (70,52)";
            //}
            cboAccountType.SelectedIndex = 0;
            cboAccountKind.DataSource = App.GetDataSet(sql).Tables[0].DefaultView;
            cboAccountKind.DisplayMember = "NAME";
            cboAccountKind.ValueMember = "ID";
            cboAccountKind.SelectedIndex = 1;   
            IniTrvAccount();
            IniRoles();
            IniTrvRoles(null);
            EditState(false);
            //tabControl1.Tabs.Clear();
            //tabControl1.Tabs.Add(tabItem1);
            tabItem1.Visible = true;
            tabItem2.Visible = false;
            this.Text = this.Text + "(��ǰ�û���" + User.User_name + ")";

                   
        }

        private bool IsSave = false;          //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���

        private Class_Account CurrentAccount; //���ڴ�ŵ�ǰ���ڲ������ʻ�

        private Class_Role[] AllRoles;        //��ȡ����Ȩ��

        /// <summary>
        /// �����ˢ��
        /// </summary>
        private void frmReflesh()
        {
            //txtAccount.Text = "";
            txtPassword.Text = "";
            txtPasswordAgin.Text = "";
            rbtnUserful.Checked = true;
            trvRoleRange.Nodes.Clear();
            lvOwernRoles.Items.Clear();
            IniTrvRoles(null);
        }

        /// <summary>
        /// �����û���Ϣˢ��ӵ�е��ʺ��б�
        /// </summary>
        private void IniTrvAccount()
        {           
            trvAccount.Nodes.Clear();           
            Bifrost.WebReference.Class_Table[] tabSqls = new Bifrost.WebReference.Class_Table[3];

            tabSqls[0] = new Bifrost.WebReference.Class_Table();
            tabSqls[0].Sql = "select * from T_ACCOUNT where ACCOUNT_ID in (Select ACCOUNT_ID from T_ACCOUNT_USER where USER_ID=" + User.User_id + ")";
            tabSqls[0].Tablename = "account";

            tabSqls[1] = new Bifrost.WebReference.Class_Table();
            tabSqls[1].Sql = "select a.role_id,a.role_name,a.enable_flag,b.account_id,a.role_type from T_ROLE a inner join T_ACC_ROLE b on a.role_id=b.role_id";
            tabSqls[1].Tablename = "acc_role";

            tabSqls[2] = new Bifrost.WebReference.Class_Table();
            tabSqls[2].Sql = "select a.id,b.account_id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said";
            tabSqls[2].Tablename = "range";

            DataSet ds = App.GetDataSet(tabSqls);
            if (ds == null)
                return;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Class_Account account = new Class_Account();
                account.Account_id = ds.Tables["account"].Rows[i]["ACCOUNT_ID"].ToString();
                account.Account_type = ds.Tables["account"].Rows[i]["ACCOUNT_TYPE"].ToString();
                //cboAccountType.SelectedValue = ds.Tables["account"].Rows[i]["ACCOUNT_TYPE"].ToString();
                account.Account_name = ds.Tables["account"].Rows[i]["ACCOUNT_NAME"].ToString();
                //txtAccount.Text = ds.Tables["account"].Rows[i]["ACCOUNT_NAME"].ToString();

                account.Password = ds.Tables["account"].Rows[i]["PASSWORD"].ToString();
                account.Enable = ds.Tables["account"].Rows[i]["ENABLE"].ToString();
                if (App.isNumval(ds.Tables["account"].Rows[i]["KIND"].ToString()))
                    account.Kind = Convert.ToInt16(ds.Tables["account"].Rows[i]["KIND"].ToString());
                //cboAccountKind.SelectedValue= ds.Tables["account"].Rows[i]["KIND"].ToString();
                //��ȡ������ص�Ȩ��
                //DataSet dsroles = App.GetDataSet("select * from T_ROLE where ROLE_ID in (select ROLE_ID from T_ACC_ROLE where ACCOUNT_ID=" + account.Account_id + ")");

                //��ȡȨ�޵����÷�Χ
                //string Sql_range = "select a.id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said";

                //DataSet dsranges = App.GetDataSet(Sql_range + " where b.account_id=" + account.Account_id + "");

                //account.Roles = new Class_Role[ds.Tables["acc_role"].Rows.Count];

                DataRow[] rolerows = ds.Tables["acc_role"].Select("ACCOUNT_ID='" + account.Account_id + "'");
                account.Roles = new Class_Role[rolerows.Length];
                for (int j = 0; j < rolerows.Length; j++)
                {
                    account.Roles[j] = new Class_Role();
                    account.Roles[j].Role_id = rolerows[j]["ROLE_ID"].ToString();
                    account.Roles[j].Role_name = rolerows[j]["ROLE_NAME"].ToString();                   
                    account.Roles[j].Enable = rolerows[j]["ENABLE_FLAG"].ToString();
                    account.Roles[j].Role_type = rolerows[j]["ROLE_TYPE"].ToString();
                    DataRow[] rows = ds.Tables["range"].Select("account_id='" + account.Account_id + "' and role_id='" + account.Roles[j].Role_id + "'");
                    account.Roles[j].Rnages = new Class_Rnage[rows.Length];
                    for (int j1 = 0; j1 < rows.Length; j1++)
                    {
                        account.Roles[j].Rnages[j1] = new Class_Rnage();
                        account.Roles[j].Rnages[j1].Id = rows[j1]["id"].ToString();
                        account.Roles[j].Rnages[j1].Section_id = rows[j1]["section_id"].ToString();
                        account.Roles[j].Rnages[j1].Sickarea_id = rows[j1]["sickarea_id"].ToString();
                        account.Roles[j].Rnages[j1].Acc_role_id = rows[j1]["acc_role_id"].ToString();
                        account.Roles[j].Rnages[j1].Isbelonge = rows[j1]["isbelongto"].ToString();
                        //0���� 1���� --sub_hospital_name
                        if (account.Roles[j].Rnages[j1].Isbelonge == "0")
                        {
                            string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                            account.Roles[j].Rnages[j1].Rnagename = rows[j1]["section_name"].ToString();
                        }
                        else
                        {
                            string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said='" + rows[j1]["sickarea_id"].ToString() + "'", 0, "sub_hospital_name");
                            account.Roles[j].Rnages[j1].Rnagename =rows[j1]["sick_area_name"].ToString();
                        }
                    }
                }
                TreeNode tn = new TreeNode();
                tn.Tag = account;
                tn.Text = account.Account_name;
                trvAccount.Nodes.Add(tn);
            }
            trvAccount.Refresh();
        }

        /// <summary>
        /// �����û���Ϣˢ��δӵ�е��ʺ��б�
        /// </summary>
        private void IniTrvUnUseAccount()
        {

            trvUnUsedAccount.Nodes.Clear();
            DataSet ds = App.GetDataSet("select * from T_ACCOUNT where ACCOUNT_ID not in (Select ACCOUNT_ID from T_ACCOUNT_USER)");// where USER_ID=" + User.User_id + "
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Account account = new Class_Account();
                    account.Account_id = ds.Tables[0].Rows[i]["ACCOUNT_ID"].ToString();
                    account.Account_type = ds.Tables[0].Rows[i]["ACCOUNT_TYPE"].ToString();
                    account.Account_name = ds.Tables[0].Rows[i]["ACCOUNT_NAME"].ToString();
                    account.Password = ds.Tables[0].Rows[i]["PASSWORD"].ToString();
                    account.Enable = ds.Tables[0].Rows[i]["ENABLE"].ToString();
                    DataSet dsroles = App.GetDataSet("select * from T_ROLE where ROLE_ID in (select ROLE_ID from T_ACC_ROLE where ACCOUNT_ID=" + account.Account_id + ")");

                    //��ȡȨ�޵����÷�Χ
                    string Sql_range = "select a.id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said";

                    DataSet dsranges = App.GetDataSet(Sql_range + " where b.account_id=" + account.Account_id + "");

                    account.Roles = new Class_Role[dsroles.Tables[0].Rows.Count];
                    if (App.isNumval(ds.Tables[0].Rows[i]["KIND"].ToString()))
                        account.Kind = Convert.ToInt16(ds.Tables[0].Rows[i]["KIND"].ToString());
                    for (int j = 0; j < dsroles.Tables[0].Rows.Count; j++)
                    {
                        account.Roles[j] = new Class_Role();
                        account.Roles[j].Role_id = dsroles.Tables[0].Rows[j]["ROLE_ID"].ToString();
                        account.Roles[j].Role_name = dsroles.Tables[0].Rows[j]["ROLE_NAME"].ToString();
                        account.Roles[j].Enable = dsroles.Tables[0].Rows[j]["ENABLE_FLAG"].ToString();
                        account.Roles[j].Role_type = dsroles.Tables[0].Rows[j]["ROLE_TYPE"].ToString();
                        DataRow[] rows = dsranges.Tables[0].Select("role_id=" + account.Roles[j].Role_id + "");
                        account.Roles[j].Rnages = new Class_Rnage[rows.Length];
                        for (int j1 = 0; j1 < rows.Length; j1++)
                        {
                            account.Roles[j].Rnages[j1] = new Class_Rnage();
                            account.Roles[j].Rnages[j1].Id = rows[j1]["id"].ToString();
                            account.Roles[j].Rnages[j1].Section_id = rows[j1]["section_id"].ToString();
                            account.Roles[j].Rnages[j1].Sickarea_id = rows[j1]["sickarea_id"].ToString();
                            account.Roles[j].Rnages[j1].Acc_role_id = rows[j1]["acc_role_id"].ToString();
                            account.Roles[j].Rnages[j1].Isbelonge = rows[j1]["isbelongto"].ToString();
                            //0���� 1���� --sub_hospital_name
                            if (account.Roles[j].Rnages[j1].Isbelonge == "0")
                            {
                                string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                                account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["section_name"].ToString();
                            }
                            else
                            {
                                string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said='" + rows[j1]["sickarea_id"].ToString() + "'", 0, "sub_hospital_name");
                                account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["sick_area_name"].ToString();
                            }
                        }
                    }
                    TreeNode tn = new TreeNode();
                    tn.Tag = account;
                    tn.Text = account.Account_name;
                    trvUnUsedAccount.Nodes.Add(tn);
                }
            }
        }

        /// <summary>
        /// �����û���Ϣˢ��δӵ�е��ʺ��б�
        /// </summary>
        /// <param name="usercaount"></param>
        private void IniTrvUnUseAccount(string usercaount)
        {

            trvUnUsedAccount.Nodes.Clear();
            DataSet ds = App.GetDataSet("select * from T_ACCOUNT where ACCOUNT_ID not in (Select ACCOUNT_ID from T_ACCOUNT_USER) and ACCOUNT_NAME like '" + usercaount.ToUpper() + "%'");// where USER_ID=" + User.User_id + "
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Account account = new Class_Account();
                    account.Account_id = ds.Tables[0].Rows[i]["ACCOUNT_ID"].ToString();
                    account.Account_type = ds.Tables[0].Rows[i]["ACCOUNT_TYPE"].ToString();
                    account.Account_name = ds.Tables[0].Rows[i]["ACCOUNT_NAME"].ToString();
                    account.Password = ds.Tables[0].Rows[i]["PASSWORD"].ToString();
                    account.Enable = ds.Tables[0].Rows[i]["ENABLE"].ToString();
                    DataSet dsroles = App.GetDataSet("select * from T_ROLE where ROLE_ID in (select ROLE_ID from T_ACC_ROLE where ACCOUNT_ID=" + account.Account_id + ")");

                    //��ȡȨ�޵����÷�Χ
                    string Sql_range = "select a.id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said";

                    DataSet dsranges = App.GetDataSet(Sql_range + " where b.account_id=" + account.Account_id + "");

                    account.Roles = new Class_Role[dsroles.Tables[0].Rows.Count];
                    if (App.isNumval(ds.Tables[0].Rows[i]["KIND"].ToString()))
                        account.Kind = Convert.ToInt16(ds.Tables[0].Rows[i]["KIND"].ToString());
                    for (int j = 0; j < dsroles.Tables[0].Rows.Count; j++)
                    {
                        account.Roles[j] = new Class_Role();
                        account.Roles[j].Role_id = dsroles.Tables[0].Rows[j]["ROLE_ID"].ToString();
                        account.Roles[j].Role_name = dsroles.Tables[0].Rows[j]["ROLE_NAME"].ToString();
                        account.Roles[j].Enable = dsroles.Tables[0].Rows[j]["ENABLE_FLAG"].ToString();
                        account.Roles[j].Role_type = dsroles.Tables[0].Rows[j]["ROLE_TYPE"].ToString();
                        DataRow[] rows = dsranges.Tables[0].Select("role_id=" + account.Roles[j].Role_id + "");
                        account.Roles[j].Rnages = new Class_Rnage[rows.Length];
                        for (int j1 = 0; j1 < rows.Length; j1++)
                        {
                            account.Roles[j].Rnages[j1] = new Class_Rnage();
                            account.Roles[j].Rnages[j1].Id = rows[j1]["id"].ToString();
                            account.Roles[j].Rnages[j1].Section_id = rows[j1]["section_id"].ToString();
                            account.Roles[j].Rnages[j1].Sickarea_id = rows[j1]["sickarea_id"].ToString();
                            account.Roles[j].Rnages[j1].Acc_role_id = rows[j1]["acc_role_id"].ToString();
                            account.Roles[j].Rnages[j1].Isbelonge = rows[j1]["isbelongto"].ToString();
                            //0���� 1���� --sub_hospital_name
                            if (account.Roles[j].Rnages[j1].Isbelonge == "0")
                            {
                                string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                                account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["section_name"].ToString();
                            }
                            else
                            {
                                string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said='" + rows[j1]["sickarea_id"].ToString() + "'", 0, "sub_hospital_name");
                                account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["sick_area_name"].ToString();
                            }
                        }
                    }
                    TreeNode tn = new TreeNode();
                    tn.Tag = account;
                    tn.Text = account.Account_name;
                    trvUnUsedAccount.Nodes.Add(tn);
                }
            }
        }


        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private void IniRoles()
        {
            DataSet ds = App.GetDataSet("select * from T_ROLE");
            AllRoles=new Class_Role[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AllRoles[i] = new Class_Role();
                AllRoles[i].Role_id = ds.Tables[0].Rows[i]["ROLE_ID"].ToString();
                AllRoles[i].Role_name = ds.Tables[0].Rows[i]["ROLE_NAME"].ToString();
                AllRoles[i].Enable = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                AllRoles[i].Role_type = ds.Tables[0].Rows[i]["ROLE_TYPE"].ToString();
            }
        }

        /// <summary>
        /// ��ʼ������ѡ���Ȩ����
        /// </summary>
        /// <param name="Account">��ǰ�ʺ�</param>
        private void IniTrvRoles(Class_Account Account)
        {
            lvRoles.Items.Clear();
            if (AllRoles != null)
            {
                if (Account != null)
                {
                    for (int i = 0; i < AllRoles.Length; i++)
                    {
                        bool flag = false;
                        if (Account.Roles != null)
                        {
                            for (int j = 0; j < Account.Roles.Length; j++)
                            {
                                if (Account.Roles[j].Role_id == AllRoles[i].Role_id)
                                {
                                    flag = true;
                                }
                            }
                        }
                        if (!flag)
                        {
                            ListViewItem tempitem = new ListViewItem();
                            tempitem.Tag = AllRoles[i];
                            tempitem.Text = AllRoles[i].Role_name;
                            tempitem.ImageIndex = 1;
                            tempitem.IndentCount = 0;
                            lvRoles.Items.Add(tempitem);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < AllRoles.Length; i++)
                    {
                        ListViewItem tempitem = new ListViewItem();
                        tempitem.Tag = AllRoles[i];
                        tempitem.Text = AllRoles[i].Role_name;
                        tempitem.ImageIndex = 1;
                        tempitem.IndentCount = 0;
                        lvRoles.Items.Add(tempitem);
                    }
                }
            }
            lvRoles.Refresh();
        }

        /// <summary>
        /// ��ʼ���Ѿ�ӵ�е�Ȩ����
        /// </summary>
        /// <param name="Account">��ǰ�ʺ�</param>
        private void IniTrvOwner(Class_Account Account)
        {
            lvOwernRoles.Items.Clear();
            if (Account != null)
            {
                if (Account.Roles != null)
                {
                    for (int i = 0; i < Account.Roles.Length; i++)
                    {
                        Class_Role temp = (Class_Role)Account.Roles[i];
                        ListViewItem tempitem = new ListViewItem();
                        tempitem.Tag = temp;
                        tempitem.Text = temp.Role_name;
                        tempitem.ImageIndex = 1;
                        lvOwernRoles.Items.Add(tempitem);
                    }
                }
            }
        }

        /// <summary>
        ///�༭״̬���� 
        /// </summary>
        /// <param name="flag"></param>
        private void EditState(bool flag)
        {
            cboAccountType.Enabled = flag;
            txtAccount.Enabled = flag;
            txtPassword.Enabled = flag;
            txtPasswordAgin.Enabled = flag;
            panel4.Enabled = flag;
            groupBox4.Enabled = flag;
            cboAccountKind.Enabled = flag;
            if(tagindex==0)
               btnSure.Enabled = flag;
            //btnCancel.Enabled = flag;            
            if (flag)
            {
                groupPanel1.Enabled = false;
            }
            else
            {
                groupPanel1.Enabled = true;
            }
        }

        /// <summary>
        /// �ж��Ƿ��ʺ��Ѿ�����
        /// </summary>
        /// <param name="account">�ʺ�</param>
        /// <returns></returns>
        private string IsExitAccount(string account)
        {
            DataSet ds = App.GetDataSet("select ACCOUNT_ID from T_ACCOUNT where ACCOUNT_NAME='" + account + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string msg = "���˺��Ѿ����ڣ�����ʱ��δʹ�ã�";
                    DataSet ds_user = App.GetDataSet("select a.user_name from t_userinfo a inner join t_account_user b on a.user_id=b.user_id where b.account_id=" + ds.Tables[0].Rows[0][0].ToString() + "");
                    if (ds_user != null)
                    {
                        if (ds_user.Tables[0].Rows.Count > 0)
                        {
                            msg = "���˺��Ѿ����ڣ������Ѿ�����Ϊ��" + ds_user.Tables[0].Rows[0][0].ToString() + "����ҽ��/��ʿʹ���ˣ�";
                        }
                    }
                    return msg;
                }                
            }
           return "";
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EditState(false);
            frmReflesh();
            trvAccount.SelectedNode = null;
            trvAccount.Refresh();
        }

        /// <summary>
        /// ���б���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            ArrayList SqlStrs = new ArrayList();
            string TbSql ="";//ͬ������SQL

            //�ʺ��춯��Ϣ
            string accountAccountType = "";//��������
            string accountInfo = "";//������Ϣ
            if (IsSave)//����
            {
                accountAccountType = "�½�";
            }
            else
            {
                accountAccountType = "�޸�";
            }
            int Account_Id = 0;          //�ʺű������
            if ( tagindex == 0)
            {
                string Sql = "";           //���в�����SQL���
               
               
                string Account_Enable = "Y"; //�ʺ�״̬
                string Account_Password = "";//�ʺ�����

                //if (cboAccountType.Text == "ҽ��")
                //{
                //    Account_Type = "D";
                //}
                //else if (cboAccountType.Text == "��ʿ")
                //{
                //    Account_Type = "N";
                //}
                //else if (cboAccountType.Text == "����Ա")
                //{
                //    Account_Type = "M";
                //}
                //else if (cboAccountType.Text == "����")
                //{
                //    Account_Type = "O";
                //}
                //else
                //{

                //}


                if (cboAccountKind.Text.Trim() == "")
                {
                    App.MsgErr("��ѡ���˻�����.");
                    return;
                }


                //�鿴�Ƿ��Ѿ����������н�ɫ��ʹ�÷�Χ
                for (int i = 0; i < lvOwernRoles.Items.Count; i++)
                {
                    Class_Role temprole = (Class_Role)lvOwernRoles.Items[i].Tag;
                    if (temprole.Role_type == "N" || temprole.Role_type == "D")
                    {
                        if (temprole.Rnages == null)
                        {
                            App.MsgErr("���ʺŵ�ĳ������ѡ�еĽ�ɫû������ʹ�÷�Χ.");
                            return;
                        }
                    }
                }

                //�ʺ�״̬
                if (!rbtnUserful.Checked)
                {
                    Account_Enable = "N";
                }

                if (IsSave)
                {
                    /*
                     * ������Ӳ���
                     */
                    if (txtPassword.Text.Trim() == "")
                    {
                        App.MsgErr("���벻��Ϊ�գ�");
                        return;
                    }
                    else
                    {
                        if (txtPassword.Text != txtPasswordAgin.Text)
                        {
                            App.MsgErr("�����������ò�һ�£�");
                            return;
                        }
                    }
                    if (txtAccount.Text != "")
                    {
                        string Msg = IsExitAccount(txtAccount.Text.ToUpper());
                        if (Msg != "")
                        {
                            App.MsgWaring(Msg);
                            return;
                        }
                    }
                    else
                    {
                        App.MsgErr("�ʺŲ���Ϊ�գ�");
                        return;
                    }                    

                    

                    Account_Password = txtPassword.Text;
                    //Account_Id = App.GenId("T_ACCOUNT", "ACCOUNT_ID");
                    Account_Id = App.GenAccountId(App.CurrentHospitalId.ToString());
                    if (Account_Enable == "Y")
                        Sql = "insert into T_ACCOUNT(ACCOUNT_ID,ACCOUNT_TYPE,ACCOUNT_NAME,PASSWORD,ENABLE,ENABLE_START_TIME,KIND,HSID)values(" + Account_Id.ToString() + ",'" + Account_Type + "','" + txtAccount.Text.ToUpper() + "','" + Encrypt.EncryptStr(Account_Password) + "','" + Account_Enable + "',to_timestamp('" + DateTime.Now.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9')," + cboAccountKind.SelectedValue.ToString() + ","+App.CurrentHospitalId.ToString()+")";
                    else
                        Sql = "insert into T_ACCOUNT(ACCOUNT_ID,ACCOUNT_TYPE,ACCOUNT_NAME,PASSWORD,ENABLE,ENABLE_END_TIME,KIND,HSID)values(" + Account_Id.ToString() + ",'" + Account_Type + "','" + txtAccount.Text.ToUpper() + "','" + Encrypt.EncryptStr(Account_Password) + "','" + Account_Enable + "',to_timestamp('" + DateTime.Now.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9')," + cboAccountKind.SelectedValue.ToString() + "," + App.CurrentHospitalId.ToString() + ")";

                }
                else
                {
                    /*
                  * �����޸Ĳ���
                  */
                    Account_Id = Convert.ToInt32(CurrentAccount.Account_id);
                    if (txtPassword.Text.Trim() != "")
                    {
                        if (txtPassword.Text != txtPasswordAgin.Text)
                        {
                            App.MsgErr("�����������ò�һ�£�");
                            return;
                        }
                        else
                        {

                            Account_Password = txtPassword.Text;
                            if (CurrentAccount.Enable == "Y")
                            {
                                if (Account_Enable == "Y")
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                                else
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',ENABLE_END_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                            }
                            else
                            {
                                if (Account_Enable == "Y")
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',ENABLE_START_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                                else
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                            }
                        }
                    }
                    else
                    {

                        Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";

                        if (CurrentAccount.Enable == "Y")
                        {
                            if (Account_Enable == "Y")
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                            else
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',ENABLE='" + Account_Enable + "',ENABLE_END_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                        }
                        else
                        {
                            if (Account_Enable == "Y")
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',ENABLE='" + Account_Enable + "',ENABLE_START_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                            else
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                        }
                    }
                }
                //�����ʺŻ�����Ϣ
                //App.ExecuteSQL(Sql);
                SqlStrs.Add(Sql);
                TbSql = Sql;
                if (IsSave)
                {
                    string id = App.GenId("T_ACCOUNT_USER", "ID").ToString();
                     //App.ExecuteSQL("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + Account_Id + "," + User.User_id + ")");                   
                    SqlStrs.Add("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + Account_Id + "," + User.User_id + ")");
                }

                //�����ʺŵ�Ȩ��
                SqlStrs.Add("delete from T_ACC_ROLE where ACCOUNT_ID=" + Account_Id.ToString() + "");
                SqlStrs.Add("delete from T_ACC_ROLE_RANGE where ACC_ROLE_ID in (select ID from T_ACC_ROLE where ACCOUNT_ID=" + Account_Id.ToString() + ")");

                int ACC_ROLE_ID = 0;

                for (int i = 0; i < lvOwernRoles.Items.Count; i++)
                {
                    if (ACC_ROLE_ID >= App.GenId("T_ACC_ROLE", "ID"))
                    {
                        ACC_ROLE_ID = ACC_ROLE_ID + 1;
                    }
                    else
                    {                        
                        ACC_ROLE_ID = App.GenId("T_ACC_ROLE", "ID");
                    }
                    Class_Role temp = (Class_Role)lvOwernRoles.Items[i].Tag;
                    //App.ExecuteSQL("insert into T_ACC_ROLE(ID,ACCOUNT_ID,ROLE_ID)values(" + ACC_ROLE_ID.ToString() + "," + Account_Id + "," + temp.Role_id + ")");
                    SqlStrs.Add("insert into T_ACC_ROLE(ID,ACCOUNT_ID,ROLE_ID)values(" + ACC_ROLE_ID.ToString() + "," + Account_Id + "," + temp.Role_id + ")");
                    //������ʺ�Ȩ�޵�ʹ���÷�Χ
                    if (temp.Rnages != null)
                    {
                        for (int i1 = 0; i1 < temp.Rnages.Length; i1++)
                        {

                            string Section_id = "0";
                            string Area_id = "0";
                            if (temp.Rnages[i1].Isbelonge == "0")
                            {
                                Section_id = temp.Rnages[i1].Section_id;
                            }
                            else
                            {
                                Area_id = temp.Rnages[i1].Sickarea_id;
                            }
                            //�ʺ�ʹ�÷�Χ�춯��Ϣ
                            if (accountInfo == "")
                            {
                                accountInfo = temp.Rnages[i1].Rnagename;
                            }
                            else
                            {
                                if (!accountInfo.Contains(temp.Rnages[i1].Rnagename))
                                {
                                    accountInfo += "," + temp.Rnages[i1].Rnagename;
                                }

                            }
                            //App.ExecuteSQL("insert into T_ACC_ROLE_RANGE(ACC_ROLE_ID,SICKAREA_ID,SECTION_ID,ISBELONGTO)values(" + ACC_ROLE_ID + "," + Area_id + "," + Section_id + ",'" + temp.Rnages[i1].Isbelonge + "')");
                            SqlStrs.Add("insert into T_ACC_ROLE_RANGE(ACC_ROLE_ID,SICKAREA_ID,SECTION_ID,ISBELONGTO)values(" + ACC_ROLE_ID + ",'" + Area_id + "','" + Section_id + "','" + temp.Rnages[i1].Isbelonge + "')");
                        }
                    }
                }
                
                
            }
            else
            {
                int id=0;
                for (int i = 0; i < trvUnUsedAccount.Nodes.Count; i++)
                {
                    if (trvUnUsedAccount.Nodes[i].Checked)
                    {
                        //string id = App.GenId("T_ACCOUNT_USER", "ID").ToString();
                        if(id>=App.GenId("T_ACCOUNT_USER", "ID"))
                        {
                            id=id+1;
                        }
                        else
                        {
                            id=App.GenId("T_ACCOUNT_USER", "ID");
                        }
                        Class_Account temp = (Class_Account)trvUnUsedAccount.Nodes[i].Tag;
                        //App.ExecuteSQL("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + temp.Account_id + "," + User.User_id + ")");
                        SqlStrs.Add("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + temp.Account_id + "," + User.User_id + ")");
                    }
                }
                //IniTrvUnUseAccount();
            }
            string[] ESQlS = new string[SqlStrs.Count];
            for (int i = 0; i < ESQlS.Length; i++)
            {
                ESQlS[i] = SqlStrs[i].ToString();
            }
            if (App.ExecuteBatch(ESQlS) > 0)
            {
                App.Msg("�����ѳɹ�");
                if (IsSave)
                {
                    App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), TbSql, Account_Id.ToString(), User.User_id.ToString(), txtAccount.Text.ToUpper());
                }
                else
                {
                    App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), TbSql);
                }
                //��¼�ʺ��춯��־
                if (accountInfo == "" && IsSave == false)
                {
                    accountAccountType = "ע��";
                }
                LogHelper.Account_SystemLog(Account_Id.ToString(), accountAccountType, accountInfo);
            }
            //App.Msg("�����ѳɹ�");
            IniTrvAccount();
            
        }

        /// <summary>
        /// ����ʺŵĲ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            tabItem1.Visible = true;
            tabItem2.Visible = false;
            IsSave = true;
            EditState(true);
            frmReflesh();
        }

        /// <summary>
        /// ���²���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tabItem1.Visible = true;
            tabItem2.Visible = false;
            IsSave = false;
            EditState(true);            
        }


        private void frmAccount_Load(object sender, EventArgs e)
        {
           
        }

        private void trvAccount_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        /// <summary>
        /// ����ѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoseone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvRoles.Items.Count; i++)
            {
                if (lvRoles.Items[i].Checked)
                {
                    bool flag = false;
                    for (int j = 0; j < lvOwernRoles.Items.Count; j++)
                    {
                        Class_Role temp1 = (Class_Role)lvRoles.Items[i].Tag;
                        Class_Role temp2 = (Class_Role)lvOwernRoles.Items[j].Tag;
                        if (temp1.Role_id == temp2.Role_id)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        lvOwernRoles.Items.Add((ListViewItem)lvRoles.Items[i].Clone());
                    }
                }
            }

            App.RemoveSelectNodes(lvRoles);
        }

        /// <summary>
        /// �Ƴ�ѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoseOut_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvOwernRoles.Items.Count; i++)
            {
                if (lvOwernRoles.Items[i].Checked)
                {
                    bool flag = false;
                    for (int j = 0; j < lvRoles.Items.Count; j++)
                    {
                        Class_Role temp1 = (Class_Role)lvRoles.Items[j].Tag;
                        Class_Role temp2 = (Class_Role)lvOwernRoles.Items[i].Tag;
                        if (temp1.Role_id == temp2.Role_id)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        lvRoles.Items.Add((ListViewItem)lvOwernRoles.Items[i].Clone());
                    }
                }
            }
            App.RemoveSelectNodes(lvOwernRoles);
        }

        /// <summary>
        /// ɾ���ʺŲ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDetelet_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                if (App.Ask("ȷ��ɾ���ʺ���"))
                {
                    string[] Sqls = new string[4];
                    Sqls[0] = "delete from T_ACCOUNT where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                    Sqls[1] = "delete from T_ACCOUNT_USER where ACCOUNT_ID=" + CurrentAccount.Account_id + " and USER_ID=" + User.User_id + "";
                    Sqls[2] = "delete from t_acc_role_range where ACC_ROLE_ID in (select id from T_ACC_ROLE where ACCOUNT_ID='" + CurrentAccount.Account_id + "')";
                    Sqls[3] = "delete from T_ACC_ROLE where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";

                    if (App.ExecuteBatch(Sqls) > 0)
                    {

                        App.Msg("�����Ѿ��ɹ���");
                        trvAccount.Nodes.Remove(trvAccount.SelectedNode);
                        //IniTrvUnUseAccount();
                    }

                }
            }
            else
            {
                App.Msg("��ѡ��Ҫ�޸ĵ��ʺţ�");
            }
        }

        private void trvAccount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tagindex = 0;
            btnUpdate_Click(sender, e);
        }

        private void tMenuAddByHand_Click(object sender, EventArgs e)
        {
            tagindex = 0;
            btnAdd_Click(sender, e);
        }

        private void tMenuUpdate_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                tagindex = 0;
                tabItem1.Visible = true;
                tabItem2.Visible = false;
                btnUpdate_Click(sender, e);
            }
            else
            {
                App.Msg("��ѡ��Ҫ�޸ĵ��ʺţ�");
            }
        }

        private void tMenuAddBySelect_Click(object sender, EventArgs e)
        {
            
                tagindex = 1;
                tabItem1.Visible = false;
                tabItem2.Visible = true;
                //IniTrvUnUseAccount();
                btnSure.Enabled = true;
                btnCancel.Enabled = true;
           
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedIndex == 0)
            //{
                
            //}
            //else
            //{               
            //     IniTrvUnUseAccount();                
            //}
        }

        private void trvAccount_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void trvAccount_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                CurrentAccount = (Class_Account)trvAccount.SelectedNode.Tag;

                /*
                 * ���ؽ���ؼ���ֵ
                 */
                if (CurrentAccount.Account_type == "D")
                {
                    cboAccountType.Text = "ҽ��";
                }
                else if (CurrentAccount.Account_type == "N")
                {
                    cboAccountType.Text = "��ʿ";
                }
                else if (CurrentAccount.Account_type == "M")
                {
                    cboAccountType.Text = "����Ա";
                }
                else if (CurrentAccount.Account_type == "O")
                {
                    cboAccountType.Text = "����";
                }
                else
                {

                }

                txtAccount.Text = CurrentAccount.Account_name;

                if (CurrentAccount.Enable == "Y")
                {
                    rbtnUserful.Checked = true;
                }
                else
                {
                    rdtnUnUserful.Checked = true;
                }

                cboAccountKind.SelectedValue = CurrentAccount.Kind;

                IniTrvRoles(CurrentAccount);
                IniTrvOwner(CurrentAccount);
                //IniUserInfor(CurrentAccount.Account_id);
                if (tabControl1.SelectedTabIndex == 1)
                {
                    //IniTrvUnUseAccount();
                }
            }
        }

        private void trvOwernRoles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {            
        }

        private void trvOwernRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void trvAccount_MouseDown(object sender, MouseEventArgs e)
        {
            trvAccount.SelectedNode = trvAccount.GetNodeAt(e.X, e.Y);
        }

        private void lvOwernRoles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Class_Role temp = (Class_Role)lvOwernRoles.SelectedItems[0].Tag;
                //if (cboAccountType.Text == "ҽ��")
                //{
                //    Account_Type = "D";
                //}
                //else if (cboAccountType.Text == "��ʿ")
                //{
                //    Account_Type = "N";
                //}
                //else if (cboAccountType.Text == "����Ա")
                //{
                //    Account_Type = "M";
                //}
                //else if (cboAccountType.Text == "����")
                //{
                //    Account_Type = "O";
                //}
                //else
                //{
                //    Account_Type = "";
                //}

                /*
                 * ��ȡ�Ѿ��еķ�Χ����
                 */
                ArrayList currentRanges = new ArrayList();
                for (int i = 0; i < trvRoleRange.Nodes.Count; i++)
                {
                    currentRanges.Add(trvRoleRange.Nodes[i].Text);
                }

                frmRoleRange fm = new frmRoleRange("0", temp.Role_type, currentRanges);
                App.FormStytleSet(fm, false);
                fm.ShowDialog();
                if (frmAccount.trvTempRoleRange != null)
                {
                    temp = (Class_Role)lvOwernRoles.SelectedItems[0].Tag;
                    temp.Rnages = new Class_Rnage[frmAccount.trvTempRoleRange.Nodes.Count];
                    trvRoleRange.Nodes.Clear();
                    for (int i = 0; i < temp.Rnages.Length; i++)
                    {
                        temp.Rnages[i] = new Class_Rnage();
                        temp.Rnages[i] = (Class_Rnage)frmAccount.trvTempRoleRange.Nodes[i].Tag;
                        TreeNode tn = new TreeNode();
                        tn.Tag = temp.Rnages[i];
                        tn.Text = temp.Rnages[i].Rnagename;
                        trvRoleRange.Nodes.Add(tn);
                    }
                    lvOwernRoles.SelectedItems[0].Tag = temp;
                }
                if (ucSectionkeep.trvTempRoleRange != null)
                {
                    temp = (Class_Role)lvOwernRoles.SelectedItems[0].Tag;
                    temp.Rnages = new Class_Rnage[ucSectionkeep.trvTempRoleRange.Nodes.Count];
                    trvRoleRange.Nodes.Clear();
                    for (int i = 0; i < temp.Rnages.Length; i++)
                    {
                        temp.Rnages[i] = new Class_Rnage();
                        temp.Rnages[i] = (Class_Rnage)ucSectionkeep.trvTempRoleRange.Nodes[i].Tag;
                        TreeNode tn = new TreeNode();
                        tn.Tag = temp.Rnages[i];
                        tn.Text = temp.Rnages[i].Rnagename;
                        trvRoleRange.Nodes.Add(tn);
                    }
                    lvOwernRoles.SelectedItems[0].Tag = temp;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("������Ϣ��" + ex.Message);
            }
        }

        private void lvOwernRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                trvRoleRange.Nodes.Clear();
                Class_Role temp = (Class_Role)lvOwernRoles.SelectedItems[0].Tag;
                if (temp.Rnages != null)
                {
                    trvRoleRange.Nodes.Clear();
                    for (int i = 0; i < temp.Rnages.Length; i++)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Tag = temp.Rnages[i];
                        tn.Text = temp.Rnages[i].Rnagename;
                        trvRoleRange.Nodes.Add(tn);
                    }
                }
            }
            catch
            { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (trvAccount.Nodes.Count > 0)
            {
                tMenuAddByHand.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ucPasswordStrongCheck1.RefleshState(txtPassword.Text);
        }

        /// <summary>
        /// �����˺�����        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            IniTrvUnUseAccount(txtAccountHname.Text);
        }           
    }
}