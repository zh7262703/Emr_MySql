using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;


namespace Bifrost.SYSTEMSET
{
    public partial class ucSectionkeep : UserControl
    {
        /// <summary>
        /// 保存当前用户信息
        /// </summary>
        public Class_User user = new Class_User();
        private int tagindex = 0; //0 tab1 1 tb2
        string Account_Type = "";    //帐号类型
        private string ID;                    //用户ID
        /// <summary>
        /// 角色使用范围树
        /// </summary>
        public static TreeView trvTempRoleRange;

        private bool IsSave = false;          //用于存放当前的操作状态 true为添加操作 false为修改操作

        private Class_Account CurrentAccount; //用于存放当前正在操作的帐户

        private Class_Role[] AllRoles;        //获取所有权限

        private string sectionIds = "";       //当前登录的科主任的使用范围ID字符串

        public Class_User User
        {
            get { return user; }
            set { user = value; }
        }


        public ucSectionkeep()
        {

            try
            {
                InitializeComponent();
            }
            catch
            {
            }
        }
        public ucSectionkeep(Class_User user)
        {
            #region
            try
            {
                this.User = user;
                this.user = user;
                InitializeComponent();
            }
            catch
            {
            }
            #endregion
        }

        private void ucSectionkeep_Load(object sender, EventArgs e)
        {
            try
            {
                GetSectionIds();
                txtAccountCheck.Text = "";
                txttracan.Text = "";
                string sql = "select * from t_data_code where type=5";
                if (User.Accounttype == "1")
                {
                    sql = sql + " and id not in (70,52)";
                }
                else
                {
                    sql = sql + " and id in (70,52)";
                }
                cboAccountType.SelectedIndex = 0;
                cboAccountKind.DataSource = App.GetDataSet(sql).Tables[0].DefaultView;
                cboAccountKind.DisplayMember = "NAME";
                cboAccountKind.ValueMember = "ID";
                string userKind = "";
                //string password = "";
                //cboAccountKind.SelectedIndex = 1;
                #region  账户性质
                try
                {
                    userKind = App.ReadSqlVal("select * from  T_ACCOUNT a where a.account_name='" + user.User_num + "'", 0, "kind").ToString();
                    //password = App.ReadSqlVal("select * from  T_ACCOUNT a where a.account_name='" + user.User_num + "'", 0, "password").ToString();
                    //txtPassword.Text = password;
                    //txtPasswordAgin.Text = password;
                    if (userKind == "70")
                    {
                        cboAccountKind.Text = "轮转医师";
                    }
                    else if (userKind == "53")
                    {
                        cboAccountKind.Text = "实习";
                    }
                    else if (userKind == "52")
                    {
                        cboAccountKind.Text = "正式";
                    }
                    else if (userKind == "54")
                    {
                        cboAccountKind.Text = "进修";
                    }
                    else if (userKind == "55")
                    {
                        cboAccountKind.Text = "院外会诊";
                    }
                    else
                    {
                        cboAccountKind.Text = "研究生";
                    }
                }
                catch
                {
                    //
                }
                #endregion 
                //if (App.UserAccount.UserInfo.User_name == "9999")
                //{
                //    transfer.Checked = true;
                //}
                //注销转调至干保病房按钮不可用
                transfer.Checked = true;//默认查询条件为简历权限
                btnSure.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = false;
                btnupdate.Enabled = false;
                groupPanel2.Enabled = true;
                lvOwernRoles.Enabled = false;
                lvRoles.Enabled = false;
                trvRoleRange.Enabled = false;
                //tabControl2.Tabs.Add(tabItem1);
                tabControl2.Visible = true;
                tabItem1.Visible = true;
                tabItem2.Visible = true;
                trvAccount.Enabled = true;

                IniTrvAccount();//根据用户信息刷新所拥有的账号列表
                IniRoles();//初始化角色
                //SeckionChion();
                this.Text = this.Text + "(当前用户：" + App.UserAccount.UserInfo.User_name + ")";
                if (user.User_id != "" && user.User_id != null)
                {
                    txtAccount.Text = user.User_num;
                }
                EditState(false);
                string sql_user = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id where  a.account_name='" + user.User_num + "' order by a.ACCOUNT_ID desc";
                if (App.GetDataSet(sql_user).Tables[0].Rows.Count == 0)
                {
                    btnAdd.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //
            }

        }
        /// <summary>
        /// 根据用户是否是干保科主任来判断是否显示
        /// </summary>
        private void SeckionChion()
        {
            //if (App.UserAccount.UserInfo.User_name == "9999")
            //{
            //    transfer.Enabled = true;
            //    txtAccountCheck.Enabled = true;
            //    Cantrans.Enabled = true;
            //    //txttracan.Enabled = true;
            //    //btnZCan.Enabled = true;

            //}
            //else
            //{
            //    transfer.Enabled = false;
            //    txtAccountCheck.Enabled = false;
            //    Cantrans.Enabled = false;
            //    txttracan.Enabled = false;
            //    //btnZCan.Enabled = false;

            //}
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            EditState(false);
            IniTrvAccountByCon();
        }
        /// <summary>
        /// 根据条件查询帐号信息
        /// </summary>
        private void IniTrvAccountByCon()
        {
            string Sql = "";
            string section_id = App.UserAccount.CurrentSelectRole.Section_Id;
            string account_id = App.UserAccount.Account_id;
            trvAccount.Nodes.Clear();
            ////显示所有
            //if (chkAll.Checked)
            //{
            //    if (txtAllcheck.Text.ToString() != "")
            //    {
            //        Sql = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id where a.account_id in(select account_id from t_acc_role b where id in(select acc_role_id from t_acc_role_range c where c.section_id in(" + sectionIds + "))) and u.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.account_name like'%" + txtAllcheck.Text.ToString() + "%' order by a.ACCOUNT_ID desc";
            //    }
            //    else
            //    {
            //        Sql = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id where a.account_id in(select account_id from t_acc_role b where id in(select acc_role_id from t_acc_role_range c where c.section_id in(" + sectionIds + "))) and u.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id;
            //    }
            //}
            ////已注销账号
            //else if (cance.Checked)
            //{
            //    if (txtcan.Text.ToString() != "")
            //    {
            //        Sql = "select * from t_account a inner join t_account_user b on a.account_id=b.account_id inner join t_userinfo c on b.user_id=c.user_id where a.account_id not in(select account_id from t_acc_role b) and a.account_name like'%" + txtcan.Text.ToString() + "%'";
            //    }
            //    else
            //    {
            //        Sql = "select * from t_account a inner join t_account_user b on a.account_id=b.account_id inner join t_userinfo c on b.user_id=c.user_id where a.account_id not in(select account_id from t_acc_role b)";
            //    }
            //}
            //建立权限
            if (transfer.Checked)
            {
                if (txtAccountCheck.Text.ToString() != "")
                {
                    Sql = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id where  a.account_name like '%" + txtAccountCheck.Text.ToString() + "%' order by a.ACCOUNT_ID desc ";

                }
                else
                {
                    Sql = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id order by a.ACCOUNT_ID desc";

                }
            }

            //注销权限
            else if (Cantrans.Checked)
            {
                if (txttracan.Text.ToString() != "")
                {
                    Sql = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id where a.account_id in(select account_id from t_acc_role b where id in(select acc_role_id from t_acc_role_range c where c.section_id in(" + sectionIds + ")))  and a.account_name like'%" + txttracan.Text.ToString() + "%' order by a.ACCOUNT_ID desc";//and u.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "
                }
                else
                {
                    Sql = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id where a.account_id in(select account_id from t_acc_role b where id in(select acc_role_id from t_acc_role_range c where c.section_id in(" + sectionIds + "))) order by a.ACCOUNT_ID desc";// and u.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id;
                }
            }
            Bifrost.WebReference.Class_Table[] tabSqls = new Bifrost.WebReference.Class_Table[3];

            tabSqls[0] = new Bifrost.WebReference.Class_Table();
            tabSqls[0].Sql = Sql;
            tabSqls[0].Tablename = "account";

            tabSqls[1] = new Bifrost.WebReference.Class_Table();
            tabSqls[1].Sql = "select a.role_id,a.role_name,a.enable_flag,b.account_id,a.role_type from T_ROLE a inner join T_ACC_ROLE b on a.role_id=b.role_id";
            tabSqls[1].Tablename = "acc_role";

            tabSqls[2] = new Bifrost.WebReference.Class_Table();
            tabSqls[2].Sql = "select a.id,b.account_id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said"; //inner join T_SUB_HOSPITALINFO e on c.shid=e.shid";           
            tabSqls[2].Tablename = "range";
            DataSet ds = App.GetDataSet(tabSqls);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Class_Account account = new Class_Account();
                account.Account_id = ds.Tables["account"].Rows[i]["ACCOUNT_ID"].ToString();
                account.Account_type = ds.Tables["account"].Rows[i]["ACCOUNT_TYPE"].ToString();
                account.Account_name = ds.Tables["account"].Rows[i]["ACCOUNT_NAME"].ToString();
                account.Password = ds.Tables["account"].Rows[i]["PASSWORD"].ToString();
                account.Enable = ds.Tables["account"].Rows[i]["ENABLE"].ToString();
                if (App.isNumval(ds.Tables["account"].Rows[i]["KIND"].ToString()))
                    account.Kind = Convert.ToInt16(ds.Tables["account"].Rows[i]["KIND"].ToString());
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
                        //0科室 1病区 --sub_hospital_name
                        if (account.Roles[j].Rnages[j1].Isbelonge == "0")
                        {
                            string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                            account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["section_name"].ToString();
                        }
                        else
                        {
                            string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said=" + rows[j1]["sickarea_id"].ToString() + "", 0, "sub_hospital_name");
                            account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["sick_area_name"].ToString();
                        }
                    }
                }
                Node tn = new Node();
                tn.Tag = account;
                tn.Text = account.Account_name;
                tn.ImageIndex = 0;
                trvAccount.Nodes.Add(tn);
            }
            trvAccount.Refresh();

        }



        /// <summary>
        /// 根据用户信息刷新拥有的帐号列表
        /// </summary>
        private void IniTrvAccount()
        {
            trvAccount.Nodes.Clear();
            Bifrost.WebReference.Class_Table[] tabSqls = new Bifrost.WebReference.Class_Table[3];

            tabSqls[0] = new Bifrost.WebReference.Class_Table();
            if (User.User_id == null)
            {
                tabSqls[0].Sql = "select * from T_ACCOUNT where ACCOUNT_ID in (Select ACCOUNT_ID from T_ACCOUNT_USER where USER_ID=" + App.UserAccount.UserInfo.User_id + ")";
            }
            else
            {
                tabSqls[0].Sql = "select * from T_ACCOUNT where ACCOUNT_ID in (Select ACCOUNT_ID from T_ACCOUNT_USER where USER_ID=" + User.User_id + ")";
            }
            tabSqls[0].Tablename = "account";

            tabSqls[1] = new Bifrost.WebReference.Class_Table();
            tabSqls[1].Sql = "select a.role_id,a.role_name,a.enable_flag,b.account_id,a.role_type from T_ROLE a inner join T_ACC_ROLE b on a.role_id=b.role_id";
            tabSqls[1].Tablename = "acc_role";

            tabSqls[2] = new Bifrost.WebReference.Class_Table();
            tabSqls[2].Sql = "select a.id,b.account_id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said";
            tabSqls[2].Tablename = "range";

            DataSet ds = App.GetDataSet(tabSqls);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Class_Account account = new Class_Account();
                account.Account_id = ds.Tables["account"].Rows[i]["ACCOUNT_ID"].ToString();
                account.Account_type = ds.Tables["account"].Rows[i]["ACCOUNT_TYPE"].ToString();
                //cboAccountType.SelectedValue = ds.Tables["account"].Rows[i]["ACCOUNT_TYPE"].ToString();
                account.Account_name = ds.Tables["account"].Rows[i]["ACCOUNT_NAME"].ToString();

                account.Password = ds.Tables["account"].Rows[i]["PASSWORD"].ToString();
                account.Enable = ds.Tables["account"].Rows[i]["ENABLE"].ToString();
                if (App.isNumval(ds.Tables["account"].Rows[i]["KIND"].ToString()))
                    account.Kind = Convert.ToInt16(ds.Tables["account"].Rows[i]["KIND"].ToString());
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
                        //0科室 1病区 --sub_hospital_name
                        if (account.Roles[j].Rnages[j1].Isbelonge == "0")
                        {
                            string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                            account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["section_name"].ToString();
                        }
                        else
                        {
                            string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said=" + rows[j1]["sickarea_id"].ToString() + "", 0, "sub_hospital_name");
                            account.Roles[j].Rnages[j1].Rnagename = HospitalName + "-" + rows[j1]["sick_area_name"].ToString();
                        }
                    }
                }
                Node tn = new Node();
                tn.Tag = account;
                tn.Text = account.Account_name;
                tn.ImageIndex = 0;
                trvAccount.Nodes.Add(tn);
            }
            if (ds.Tables[0].Rows.Count == 0)//0行表示还没有创建帐号
            {
                btnAdd.Enabled = true;
            }
            trvAccount.Refresh();
        }

        /// <summary>
        /// 初始化角色
        /// </summary>
        private void IniRoles()
        {
            DataSet ds = App.GetDataSet("select * from T_ROLE where role_id in(226,235,232,233)");
            AllRoles = new Class_Role[ds.Tables[0].Rows.Count];
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
        /// 初始化可以选择的权限树
        /// </summary>
        /// <param name="Account">当前帐号</param>
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
        /// 初始化已经拥有的权限树
        /// </summary>
        /// <param name="Account">当前帐号</param>
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
        /// 界面的刷新
        /// </summary>
        private void frmReflesh()
        {
            trvRoleRange.Nodes.Clear();
            lvOwernRoles.Items.Clear();
            trvAccount.Nodes.Clear();
            lvRoles.Items.Clear();
            IniRoles();
            //IniTrvRoles(null);
        }

        /// <summary>
        /// 进行保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            ArrayList SqlStrs = new ArrayList();
            if (tagindex == 0)
            {
                string Sql = "";           //进行操作的SQL语句
                int Account_Id = 0;          //帐号表的主键
                //查看是否已经设置了所有角色的使用范围
                for (int i = 0; i < lvOwernRoles.Items.Count; i++)
                {
                    Class_Role temprole = (Class_Role)lvOwernRoles.Items[i].Tag;
                    if (temprole.Role_type == "N" || temprole.Role_type == "D")
                    {
                        if (temprole.Rnages == null)
                        {
                            App.MsgErr("该帐号的某个或多个选中的角色没有设置使用范围.");
                            return;
                        }
                    }
                }
                //保存帐号基本信息
                //App.ExecuteSQL(Sql);
                SqlStrs.Add(Sql);
                if (IsSave)
                {
                    string id = App.GenId("T_ACCOUNT_USER", "ID").ToString();
                    //App.ExecuteSQL("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + Account_Id + "," + User.User_id + ")");
                    SqlStrs.Add("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + Account_Id + "," + User.User_id + ")");
                }

                //保存帐号的权限
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
                    //保存该帐号权限的使用用范围
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
                            //App.ExecuteSQL("insert into T_ACC_ROLE_RANGE(ACC_ROLE_ID,SICKAREA_ID,SECTION_ID,ISBELONGTO)values(" + ACC_ROLE_ID + "," + Area_id + "," + Section_id + ",'" + temp.Rnages[i1].Isbelonge + "')");
                            SqlStrs.Add("insert into T_ACC_ROLE_RANGE(ACC_ROLE_ID,SICKAREA_ID,SECTION_ID,ISBELONGTO)values(" + ACC_ROLE_ID + "," + Area_id + "," + Section_id + ",'" + temp.Rnages[i1].Isbelonge + "')");
                        }
                    }
                }


            }

            string[] ESQlS = new string[SqlStrs.Count];
            for (int i = 0; i < ESQlS.Length; i++)
            {
                ESQlS[i] = SqlStrs[i].ToString();
            }
            if (App.ExecuteBatch(ESQlS) > 0)
                App.Msg("操作已成功");
            //App.Msg("操作已成功");
            IniTrvAccount();
        }

        /// <summary>
        /// 添加角色
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
        /// 删除角色
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
                        #region 拥有非干保使用范围的角色，不允许移除
                        if (temp2.Rnages != null)
                        {
                            for (int k = 0; k < temp2.Rnages.Length; k++)
                            {
                                if(sectionIds.Contains(temp2.Rnages[k].Section_id)==false)
                                {
                                    App.Msg("该角色拥有你使用范围以外的角色，不能移除！");
                                    return;
                                }
                            }
                        }
                        #endregion
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
        /// 清空用户信息
        /// </summary>
        private void UserInfoClear()
        {
            ID = "";
            txtName.Text = "";
            cboCreer.Text = "";
            txtPhone.Text = "";
            txtTelphone.Text = "";
            txtEmail.Text = "";
            txtCertificatename.Text = "";
            lblName.Text = "";
            lblPrice.Text = "";
            lblSiceArea.Text = "";
            lblBirthday.Text = "";
            lblCreers.Text = "";
            lblTelphone.Text = "";
            lblValidmark.Text = "";
            lblCertificatename.Text = "";
            lblLeadcard.Text = "";
            lblPrescription.Text = "";
            lblGender.Text = "";
            lblAppointment.Text = "";
            lblPhone.Text = "";
            lblCreer.Text = "";
            lblOffice.Text = "";
            lblEmail.Text = "";
            lblSelected.Text = "";
            lblPassingtime.Text = "";
            lblRegdate.Text = "";

        }
        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private void IniUserInfor(string AccoutId)
        {
            /*
             * 根据帐号的ID获取，该帐号所对应的所有相关信息。
             */
            try
            {
                UserInfoClear();
                DataSet dsUser = App.GetDataSet("select * from t_userinfo a inner join t_account_user b on a.User_Id=b.user_id where b.account_id=" + AccoutId + "");
                if (dsUser != null)
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        txtAccount.Text = dsUser.Tables[0].Rows[0]["user_num"].ToString();//account_name
                        ID = dsUser.Tables[0].Rows[0]["USER_ID"].ToString();

                        txtName.Text = dsUser.Tables[0].Rows[0]["USER_NAME"].ToString();
                        lblName.Text = txtName.Text;

                        cboGender.SelectedIndex = Convert.ToUInt16(dsUser.Tables[0].Rows[0]["GENDER_CODE"].ToString());
                        lblGender.Text = cboGender.Text;

                        dtpBirthday.Value = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["BIRTHDAY"].ToString());
                        lblBirthday.Text = lblBirthday.Text + dtpBirthday.Value.ToShortDateString();

                        cboCreer.SelectedValue = dsUser.Tables[0].Rows[0]["U_TECH_POST"].ToString();
                        lblCreer.Text = cboCreer.Text;

                        if (dsUser.Tables[0].Rows[0]["U_SENIORITY"].ToString() == "1")
                        {
                            //rbtnPriceHigh.Checked = true;
                            lblPrice.Text = lblPrice.Text + "高";
                        }
                        else
                        {
                            //rbtnPriceLow.Checked = true;
                            lblPrice.Text = lblPrice.Text + "低";
                        }

                        dtpAppointment.Value = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["IN_TIME"].ToString());
                        lblAppointment.Text = dtpAppointment.Value.ToShortDateString();

                        cboCreers.SelectedValue = dsUser.Tables[0].Rows[0]["U_POSITION"].ToString();
                        lblCreers.Text = cboCreers.Text;

                        cboPrescription.SelectedValue = Convert.ToInt16(dsUser.Tables[0].Rows[0]["U_RECIPE_POWER"].ToString()) - 1;
                        lblPrescription.Text = cboPrescription.Text;

                        cboOffice.SelectedValue = Convert.ToInt32(dsUser.Tables[0].Rows[0]["SECTION_ID"].ToString());
                        lblOffice.Text = cboOffice.Text;

                        cboSick.SelectedValue = dsUser.Tables[0].Rows[0]["SICKAREA_ID"].ToString();
                        lblSiceArea.Text = cboSick.Text;

                        txtPhone.Text = dsUser.Tables[0].Rows[0]["PHONE"].ToString();
                        lblPhone.Text = txtPhone.Text;

                        txtTelphone.Text = dsUser.Tables[0].Rows[0]["MOBILE_PHONE"].ToString();
                        lblPhone.Text = txtTelphone.Text;

                        txtEmail.Text = dsUser.Tables[0].Rows[0]["EMAIL"].ToString();
                        lblEmail.Text = txtEmail.Text;

                        if (dsUser.Tables[0].Rows[0]["ENABLE"].ToString() == "Y")
                        {
                            //rbtnValidmark.Checked = true;
                            lblValidmark.Text = "有效";
                        }
                        else
                        {
                            //rbtnVainmark.Checked = true;
                            lblValidmark.Text = "无效";
                        }

                        if (dsUser.Tables[0].Rows[0]["PROFESSION_CARD"].ToString() == "true")
                        {
                            //rbtnSelected.Checked = true;
                            lblSelected.Text = "有";
                        }
                        else
                        {
                            //rbtnNoselected.Checked = true;
                            lblSelected.Text = "无";
                        }
                        txtCertificatename.Text = dsUser.Tables[0].Rows[0]["PROF_CARD_NAME"].ToString();
                        lblCertificatename.Text = txtCertificatename.Text;

                        dtpPassingtime.Value = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["PASS_TIME"].ToString());
                        lblPassingtime.Text = dtpPassingtime.Value.ToShortDateString();

                        dtpLeadcard.Value = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["RECEIVE_TIME"].ToString());
                        lblLeadcard.Text = dtpLeadcard.Value.ToShortDateString();


                        dtpRegdate.Value = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["REGISTER_TIME"].ToString());
                        lblRegdate.Text = dtpRegdate.Value.ToShortDateString();

                    }
                }

            }
            catch
            { }
        }

        /// <summary>
        ///   当帐号列表选择以后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvAccount_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                CurrentAccount = (Class_Account)trvAccount.SelectedNode.Tag;

                IniTrvRoles(CurrentAccount);//初始化可以选择的权限树
                IniTrvOwner(CurrentAccount);//初始化拥有的权限树
                IniUserInfor(CurrentAccount.Account_id);//初始化用户信息
            }
            btnupdate.Enabled = true;
            if (Cantrans.Checked)
            {
                btnZCan.Enabled = true;
            }
        }
        /// <summary>
        /// 帐号注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZCan_Click(object sender, EventArgs e)
        {
            #region 帐号注销

            if (App.Ask("注销帐号之后，当前帐号就无法登录当前系统，确定要注销吗？"))
            {
                string result = "";
                //if (App.UserAccount.Kind == 53 || App.UserAccount.Kind == 54 || App.UserAccount.Kind == 7921)
                if (CurrentAccount.Kind == 53 || CurrentAccount.Kind == 54 || CurrentAccount.Kind == 7921)
                {
                    //实习生、研究生、进修生
                    result = "";
                }
                else if (CurrentAccount.Kind == 52)
                {

                    //正式
                    DataSet ds_docs = App.GetDataSet("select t.tid,t3.patient_name,t3.pid,t2.textname,t.doc_name,t.havedoctorsign from t_patients_doc t inner join t_text t2 on t.textkind_id=t2.id inner join t_in_patient t3 on t.patient_id=t3.id where t.createid=(select user_id from t_account_user a where a.account_id=" + CurrentAccount.Account_id + ") ");
                    if (ds_docs != null)
                    {
                        if (ds_docs.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds_docs.Tables[0].Rows.Count; i++)
                            {
                                if (ds_docs.Tables[0].Rows[i]["havedoctorsign"].ToString() != "Y")
                                {

                                    string strtemp = "病人姓名：" + ds_docs.Tables[0].Rows[i]["patient_name"].ToString() + ",住院号：" + ds_docs.Tables[0].Rows[i]["pid"].ToString() + ",文书类型：" + ds_docs.Tables[0].Rows[i]["textname"].ToString() + ",文书名称：" + ds_docs.Tables[0].Rows[i]["doc_name"].ToString();
                                    if (result == "")
                                    {
                                        result = "你还有一些文书没有签名：\n";
                                        result = result + strtemp;

                                    }
                                    else
                                    {
                                        result = result + "\n" + strtemp;
                                    }
                                }
                            }
                        }
                    }
                }

                if (result == "")
                {
                    //注销操作
                    string[] sqls = new string[1];
                    sqls[0] = "delete from t_acc_role_range a where a.acc_role_id in (select b.id from t_acc_role b where b.account_id=" + CurrentAccount.Account_id + ") and a.section_id in(24,25,26,51)";
                    //sqls[1] = "delete from t_acc_role c where c.account_id=" + CurrentAccount.Account_id + "";

                    if (App.ExecuteBatch(sqls) > 0)
                    {
                        App.Msg("帐号注销成功！");
                        //isReset = true;
                        //Application.Restart();
                    }
                }
                else
                {
                    App.MsgWaring(result);
                }
            }
            #endregion

        }
        /// <summary>
        /// 取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            frmReflesh();
            trvAccount.SelectedNode = null;
            btnZCan.Enabled = false;
            btnCancel.Enabled = false;
            btnSure.Enabled = false;
            btnupdate.Enabled = false;
            lvRoles.Enabled = false;
            lvOwernRoles.Enabled = false;
            trvRoleRange.Enabled = false;
            trvAccount.Enabled = true;
            groupPanel2.Enabled = true;
            trvAccount.Refresh();
            EditState(false);
            txtPassword.Text = "";
            txtPasswordAgin.Text = "";//密码和确认密码都要为空
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            btnupdate.Enabled = false;
            btnZCan.Enabled = false;
            trvAccount.Enabled = false;
            btnCancel.Enabled = true;
            btnSure.Enabled = true;
            IsSave = false;
            groupPanel2.Enabled = false;

            lvRoles.Enabled = true;
            lvOwernRoles.Enabled = true;
            trvRoleRange.Enabled = true;
            EditState(true);
            if (Cantrans.Checked == true)
            {
                txtPassword.Enabled = false;
                txtPasswordAgin.Enabled = false;
                cboAccountKind.Enabled = false;
                cboAccountType.Enabled = false;
                rbtnUserful.Enabled = false;
                rdtnUnUserful.Enabled = false;
            }
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click_1(object sender, EventArgs e)
        {
            try
            {

                ArrayList SqlStrs = new ArrayList();
                int Account_Id = 0;          //帐号表的主键
                string Sql = "";           //进行操作的SQL语句
                string Account_Enable = "Y"; //帐号状态
                string Account_Password = "";//帐号密码
                string TbSql = "";           //同步用的SQL
                //帐号异动信息
                string accountAccountType = "";//操作类型
                string accountInfo = "";//操作信息
                if (IsSave)//新增
                {
                    accountAccountType = "新建";
                }
                else
                {
                    accountAccountType = "修改";
                }
                if (cboAccountKind.Text.Trim() == "")
                {
                    App.MsgErr("请选择账户性质.");
                    return;
                }

                //查看是否已经设置了所有角色的使用范围
                for (int i = 0; i < lvOwernRoles.Items.Count; i++)
                {
                    Class_Role temprole = (Class_Role)lvOwernRoles.Items[i].Tag;
                    if (temprole.Role_type == "N" || temprole.Role_type == "D")
                    {
                        if (temprole.Rnages == null)
                        {
                            App.MsgErr("该帐号的某个或多个选中的角色没有设置使用范围.");
                            return;
                        }
                    }
                }

                //帐号状态
                if (!rbtnUserful.Checked)
                {
                    Account_Enable = "N";
                }

                if (IsSave)
                {
                    /*
                     * 进行添加操作
                     */
                    if (txtPassword.Text.Trim() == "")
                    {
                        App.MsgErr("密码不能为空！");
                        return;
                    }
                    else
                    {
                        if (txtPassword.Text != txtPasswordAgin.Text)
                        {
                            App.MsgErr("两次密码设置不一致！");
                            return;
                        }
                    }
                    if (txtAccount.Text != "")
                    {
                        if (IsExitAccount(txtAccount.Text))
                        {
                            App.MsgErr("帐号已经存在！");
                            return;
                        }
                    }
                    else
                    {
                        App.MsgErr("帐号不能为空！");
                        return;
                    }

                    Account_Password = txtPassword.Text;
                    //Account_Id = App.GenId("T_ACCOUNT", "ACCOUNT_ID");
                    Account_Id = App.GenAccountId(App.CurrentHospitalId.ToString());
                    if (Account_Enable == "Y")
                        Sql = "insert into T_ACCOUNT(ACCOUNT_ID,ACCOUNT_TYPE,ACCOUNT_NAME,PASSWORD,ENABLE,ENABLE_START_TIME,KIND,HSID)values(" + Account_Id.ToString() + ",'" + Account_Type + "','" + txtAccount.Text + "','" + Encrypt.EncryptStr(Account_Password) + "','" + Account_Enable + "',to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9')," + cboAccountKind.SelectedValue.ToString() + "," + App.CurrentHospitalId.ToString() + ")";
                    else
                        Sql = "insert into T_ACCOUNT(ACCOUNT_ID,ACCOUNT_TYPE,ACCOUNT_NAME,PASSWORD,ENABLE,ENABLE_END_TIME,KIND,HSID)values(" + Account_Id.ToString() + ",'" + Account_Type + "','" + txtAccount.Text + "','" + Encrypt.EncryptStr(Account_Password) + "','" + Account_Enable + "',to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9')," + cboAccountKind.SelectedValue.ToString() + "," + App.CurrentHospitalId.ToString() + ")";

                }
                else
                {
                    /*
                  * 进行修改操作 有密码的时候 需要改密码，密码为空的时候，密码是不修改的
                  */
                    Account_Id = Convert.ToInt32(CurrentAccount.Account_id);
                    if (txtPassword.Text.Trim() != "")
                    {
                        if (txtPassword.Text != txtPasswordAgin.Text)
                        {
                            App.MsgErr("两次密码设置不一致！");
                            return;
                        }
                        else
                        {

                            Account_Password = txtPassword.Text;
                            if (CurrentAccount.Enable == "Y")
                            {
                                if (Account_Enable == "Y")
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                                else
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',ENABLE_END_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                            }
                            else
                            {
                                if (Account_Enable == "Y")
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',ENABLE_START_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                                else
                                {
                                    Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',PASSWORD='" + Encrypt.EncryptStr(Account_Password) + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                                }
                            }
                        }
                    }
                    else
                    {

                        Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";

                        if (CurrentAccount.Enable == "Y")
                        {
                            if (Account_Enable == "Y")
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                            else
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',ENABLE='" + Account_Enable + "',ENABLE_END_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                        }
                        else
                        {
                            if (Account_Enable == "Y")
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',ENABLE='" + Account_Enable + "',ENABLE_START_TIME=to_timestamp('" + DateTime.Now.ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                            else
                            {
                                Sql = "update T_ACCOUNT set ACCOUNT_TYPE='" + Account_Type + "',ACCOUNT_NAME='" + txtAccount.Text + "',ENABLE='" + Account_Enable + "',KIND=" + cboAccountKind.SelectedValue.ToString() + " where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                            }
                        }
                    }
                }
                //保存帐号基本信息
                //App.ExecuteSQL(Sql);
                SqlStrs.Add(Sql);
                TbSql = Sql;
                if (IsSave)
                {
                    string id = App.GenId("T_ACCOUNT_USER", "ID").ToString();
                    //App.ExecuteSQL("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + Account_Id + "," + User.User_id + ")");
                    SqlStrs.Add("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + Account_Id + "," + User.User_id + ")");
                }

                //MessageBox.Show(Account_Id.ToString());

                //保存帐号的权限            
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
                    SqlStrs.Add("insert into T_ACC_ROLE(ID,ACCOUNT_ID,ROLE_ID)values(" + ACC_ROLE_ID.ToString() + "," + Account_Id + "," + temp.Role_id + ")");
                    //保存该帐号权限的使用用范围
                    if (temp.Rnages != null)
                    {
                        for (int i1 = 0; i1 < temp.Rnages.Length; i1++)
                        {

                            string Section_id = "0";
                            string Area_id = "0";
                            if (temp.Rnages[i1] == null)
                            {
                                continue;
                            }
                            if (temp.Rnages[i1].Isbelonge == "0")
                            {
                                Section_id = temp.Rnages[i1].Section_id;
                            }
                            else
                            {
                                Area_id = temp.Rnages[i1].Sickarea_id;
                            }
                            //帐号使用范围异动信息
                            if (accountInfo == "")
                            {
                                accountInfo = temp.Rnages[i1].Rnagename;
                            }
                            else
                            {
                                if (temp.Rnages[i1].Rnagename.Trim() == "")
                                {
                                    continue;
                                }
                                if (!accountInfo.Contains(temp.Rnages[i1].Rnagename))
                                {
                                    accountInfo += "," + temp.Rnages[i1].Rnagename;
                                }
                                
                            }
                            SqlStrs.Add("insert into T_ACC_ROLE_RANGE(ACC_ROLE_ID,SICKAREA_ID,SECTION_ID,ISBELONGTO)values(" + ACC_ROLE_ID + "," + Area_id + "," + Section_id + ",'" + temp.Rnages[i1].Isbelonge + "')");
                        }
                    }
                }
                string[] ESQlS = new string[SqlStrs.Count];
                for (int i = 0; i < ESQlS.Length; i++)
                {
                    ESQlS[i] = SqlStrs[i].ToString();
                }
                if (App.ExecuteBatch(ESQlS) > 0)
                {
                    App.Msg("操作已成功");
                   // App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), TbSql);
                    if (IsSave)
                    {
                        App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), TbSql, Account_Id.ToString(), User.User_id.ToString(), txtAccount.Text);
                    }
                    else
                    {
                        App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), TbSql);
                    }
                    //记录帐号异动日志
                    if (accountInfo=="" && IsSave==false)
                    {
                        accountAccountType = "注销";
                    }
                    LogHelper.Account_SystemLog(Account_Id.ToString(), accountAccountType, accountInfo);
                }
                //IniTrvAccount(txtAccountCheck.Text);
                btnCancel_Click_1(sender, e);
            }

            catch
            {

            }
        }

        /// <summary>
        /// 为选择的角色配置实用范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        Node tn = new Node();
                        tn.Tag = temp.Rnages[i];
                        tn.Text = temp.Rnages[i].Rnagename;
                        tn.ImageIndex = 2;
                        trvRoleRange.Nodes.Add(tn);
                    }
                }
            }
            catch
            { }
        }
        /// /// <summary>
        /// 添加多个角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
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
        // <summary>
        /// 删除多个角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX4_Click(object sender, EventArgs e)
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
                        #region 拥有非干保使用范围的角色，不允许移除
                        //拥有不再你使用范围的角色，不允许移除
                        if (temp2.Rnages != null)
                        {
                            for (int k = 0; k < temp2.Rnages.Length; k++)
                            {
                                //if (temp2.Rnages[k].Section_id != "24" && temp2.Rnages[k].Section_id != "25" && temp2.Rnages[k].Section_id != "26" && temp2.Rnages[k].Section_id != "51")
                                if(sectionIds.Contains(temp2.Rnages[k].Section_id)==false)
                                {
                                    App.Msg("该角色拥有你使用范围以外的角色，不能移除！");
                                    return;
                                }
                            }
                        }
                        #endregion
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void txtAllcheck_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtAllcheck.Text.Trim() == "")
        //    {
        //        txtcan.Enabled = true;
        //        txtAccountCheck.Enabled = true;
        //        txttracan.Enabled = true;
        //    }
        //    else
        //    {
        //        txtcan.Enabled = false;
        //        txtAccountCheck.Enabled = false;
        //        txttracan.Enabled = false;
        //    }
        //    if (App.UserAccount.UserInfo.User_name != "9999")
        //    {
        //        SeckionChion();
        //    }
        //}

        //private void txtcan_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtcan.Text.Trim() == "")
        //    {
        //        txtAllcheck.Enabled = true;
        //        txtAccountCheck.Enabled = true;
        //        txttracan.Enabled = true;
        //    }
        //    else
        //    {
        //        txtAllcheck.Enabled = false;
        //        txtAccountCheck.Enabled = false;
        //        txttracan.Enabled = false;
        //    }
        //    if (App.UserAccount.UserInfo.User_name != "9999")
        //    {
        //        SeckionChion();
        //    }
        //}

        //private void txtAccountCheck_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtAccountCheck.Text.Trim() == "")
        //    {
        //        //txtAllcheck.Enabled = true;
        //        //txtcan.Enabled = true;
        //        txttracan.Enabled = true;
        //    }
        //    else
        //    {
        //        //txtAllcheck.Enabled = false;
        //        //txtcan.Enabled = false;
        //        txttracan.Enabled = false;
        //    }
        //}

        //private void txttracan_TextChanged(object sender, EventArgs e)
        //{
        //    if (txttracan.Text.Trim() == "")
        //    {
        //        //txtAllcheck.Enabled = true;
        //        //txtcan.Enabled = true;
        //        txtAccountCheck.Enabled = true;
        //    }
        //    else
        //    {
        //        //txtAllcheck.Enabled = false;
        //        //txtcan.Enabled = false;
        //        txtAccountCheck.Enabled = false;
        //    }
        //}

        private void chkAll_TextChanged(object sender, EventArgs e)
        {
            //if (chkAll.Checked == false)
            //{
            //    txtAllcheck.Enabled = false;
            //}
            //else
            //{
                trvAccount.Nodes.Clear();
                //txtcan.Enabled = false;
                txtAccountCheck.Enabled = false;
                txttracan.Enabled = false;
                btnZCan.Enabled = false;
                btnupdate.Enabled = false;
                //txtAllcheck.Enabled = true;
                txtAccount.Text = "";
                //txtcan.Text = "";
                txtAccountCheck.Text = "";
                txttracan.Text = "";
            //}
            //if (App.UserAccount.UserInfo.User_name != "9999")
            //{
            //    SeckionChion();
            //}
        }

        //private void cance_TextChanged(object sender, EventArgs e)
        //{
        //    if (cance.Checked == false)
        //    {
        //        txtcan.Enabled = false;
        //    }
        //    else
        //    {
        //        trvAccount.Nodes.Clear();
        //        txtAllcheck.Enabled = false;
        //        txtAccountCheck.Enabled = false;
        //        txttracan.Enabled = false;
        //        btnZCan.Enabled = false;
        //        btnupdate.Enabled = false;
        //        txtcan.Enabled = true;
        //        txtAccount.Text = "";
        //        txtcan.Text = "";
        //        txtAccountCheck.Text = "";
        //        txttracan.Text = "";
        //    }
        //    if (App.UserAccount.UserInfo.User_name != "9999")
        //    {
        //        SeckionChion();
        //    }
        //}

        private void transfer_CheckedChanged(object sender, EventArgs e)
        {
            if (transfer.Checked == false)
            {
                txtAccountCheck.Enabled = false;
            }
            else
            {
                trvAccount.Nodes.Clear();
                //txtAllcheck.Enabled = false;
                //txtcan.Enabled = false;
                txttracan.Enabled = false;
                txtAccountCheck.Enabled = true;
                btnZCan.Enabled = false;
                btnupdate.Enabled = false;
                txtAccount.Text = "";
                //txtcan.Text = "";
                txtAccountCheck.Text = "";
                txttracan.Text = "";
            }
        }

        /// <summary>
        /// 根据用户对象，设置用户信息
        /// </summary>
        /// <param name="user"></param>
        public void SetUserInfo(Class_User user)
        {
            this.User = user;
            this.txtAccount.Text = user.User_num;
            this.lvRoles.Clear();
            this.lvOwernRoles.Clear();
            this.trvRoleRange.Nodes.Clear();
            ucSectionkeep_Load(null, null);
        }

        private void lvOwernRoles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
             *说明：
             *角色的使用范围一般是只有，护士帐号和医生帐号才有，其他帐号暂无。
             */

            try
            {
                /*
                 * 获取已经有的范围配置
                 */
                trvTempRoleRange = null;//清空TreeView
                ArrayList currentRanges = new ArrayList();
                for (int i = 0; i < trvRoleRange.Nodes.Count; i++)
                {
                    currentRanges.Add(trvRoleRange.Nodes[i].Text);
                }

                Class_Role temp = (Class_Role)lvOwernRoles.SelectedItems[0].Tag;
                frmRoleRange fm = new frmRoleRange("0", temp.Role_type, currentRanges);
                App.FormStytleSet(fm, false);
                fm.ShowDialog();
                if (trvTempRoleRange != null)
                {
                    ArrayList currentTempRanges = GetSectionIds(sectionIds);
                    //for (int i = 0; i < trvTempRoleRange.Nodes.Count; i++)
                    //{
                    //    currentTempRanges.Add(trvTempRoleRange.Nodes[i].Text);
                    //}
                    //trvRoleRange.Nodes.Clear();
                    
                    //列表中有在当前角色范围内的都删除,只能删除使用人有权限的范围，不再此范围的不能删除
                    for (int i = trvRoleRange.Nodes.Count; i>0; i--)
                    {
                        if (currentTempRanges.Contains(trvRoleRange.Nodes[i - 1].Text) == true)
                        {
                            trvRoleRange.Nodes[i-1].Remove();
                        }
                    }
                    temp.Rnages = new Class_Rnage[trvTempRoleRange.Nodes.Count + trvRoleRange.Nodes.Count];
                    for (int i = 0; i < trvRoleRange.Nodes.Count; i++)
                    {
                        temp.Rnages[i] = new Class_Rnage();
                        temp.Rnages[i] = (Class_Rnage)trvRoleRange.Nodes[i].Tag;
                    }
                    int trvRoleRangecount = trvRoleRange.Nodes.Count;
                    for (int j = 0; j < trvTempRoleRange.Nodes.Count; j++)
                    {
                        temp.Rnages[trvRoleRangecount + j] = new Class_Rnage();
                        temp.Rnages[trvRoleRangecount + j] = (Class_Rnage)trvTempRoleRange.Nodes[j].Tag;
                        Node tn = new Node();
                        if (temp.Rnages[trvRoleRangecount + j] == null)
                        {
                            continue;
                        }
                        tn.Tag = temp.Rnages[trvRoleRangecount + j];
                        tn.Text = temp.Rnages[trvRoleRangecount + j].Rnagename;
                        tn.ImageIndex = 2;
                        //if (currentRanges.Contains(tn.Text) == false)
                        //{
                        //   trvRoleRange.Nodes.Add(tn);
                        //}
                        trvRoleRange.Nodes.Add(tn);
                    }
                    lvOwernRoles.SelectedItems[0].Tag = temp;
                }
                //    //trvRoleRange已经拥有的角色  + 选中的角色=之后的角色
                //    temp.Rnages = new Class_Rnage[trvTempRoleRange.Nodes.Count + trvRoleRange.Nodes.Count];//权限数组长度等于原有非干保权限个数+新选择的干保权限个数
                //    //int ganBaoRoleCount = trvRoleRange.Nodes.Count;
                //    //trvRoleRange.Nodes.Clear();
                //    //for (int i = 0; i < trvRoleRange.Nodes.Count; i++)
                //    //{
                //    //    temp.Rnages[i] = new Class_Rnage();
                //    //    temp.Rnages[i] = (Class_Rnage)trvRoleRange.Nodes[i].Tag;
                //    //}
                    
                //    int j = 0;
                //    for (int i = ganBaoRoleCount; i < temp.Rnages.Length; i++)
                //    {
                //        temp.Rnages[i] = new Class_Rnage();

                //        temp.Rnages[i] = (Class_Rnage)trvTempRoleRange.Nodes[j].Tag;
                //        j++;
                //        Node tn = new Node();
                //        tn.Tag = temp.Rnages[i];
                //        tn.Text = temp.Rnages[i].Rnagename;
                //        tn.ImageIndex = 2;
                //        trvRoleRange.Nodes.Add(tn);
                //    }
                //    lvOwernRoles.SelectedItems[0].Tag = temp;
                //}
                ////if (trvTempRoleRange != null)
                ////{
                ////    temp = (Class_Role)lvOwernRoles.SelectedItems[0].Tag;
                ////    temp.Rnages = new Class_Rnage[frmAccount.trvTempRoleRange.Nodes.Count];
                ////    trvRoleRange.Nodes.Clear();
                ////    for (int i = 0; i < temp.Rnages.Length; i++)
                ////    {
                ////        temp.Rnages[i] = new Class_Rnage();
                ////        temp.Rnages[i] = (Class_Rnage)frmAccount.trvTempRoleRange.Nodes[i].Tag;
                ////        Node tn = new Node();
                ////        tn.Tag = temp.Rnages[i];
                ////        tn.Text = temp.Rnages[i].Rnagename;
                ////        trvRoleRange.Nodes.Add(tn);
                ////    }
                ////    lvOwernRoles.SelectedItems[0].Tag = temp;
                ////}
            }
            catch (Exception ex)
            {
                App.MsgErr("错误信息：" + ex.Message);
            }
        }

        private void Cantrans_CheckedChanged(object sender, EventArgs e)
        {
            if (Cantrans.Checked == false)
            {
                txttracan.Enabled = false;
            }
            else
            {
                trvAccount.Nodes.Clear();
                txttracan.Enabled = true;
                btnZCan.Enabled = false;
                btnupdate.Enabled = false;
                txtAccount.Text = "";
                //txtcan.Text = "";
                txtAccountCheck.Text = "";
                txttracan.Text = "";
            }
        }

        /// <summary>
        /// 判断是否帐号已经存在
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        private bool IsExitAccount(string account)
        {
            DataSet ds = App.GetDataSet("select count(ACCOUNT_ID) from T_ACCOUNT where ACCOUNT_NAME='" + account + "'");
            if (ds != null)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///编辑状态设置 
        /// </summary>
        /// <param name="flag"></param>
        private void EditState(bool flag)
        {
            cboAccountType.Enabled = flag;
            txtPassword.Enabled = flag;
            txtPasswordAgin.Enabled = flag;
            cboAccountKind.Enabled = flag;
            panel4.Enabled = flag;
            //txtPassword.Enabled = !flag;
            //txtPasswordAgin.Enabled = !flag;
            //cboAccountKind.Enabled = !flag;
            //cboAccountType.Enabled = !flag;
            //rbtnUserful.Enabled = !flag;
            //rdtnUnUserful.Enabled = !flag;

        }

        /// <summary>
        /// 添加帐号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            IsSave = true;
            btnSure.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            trvAccount.Enabled = false;
            groupPanel2.Enabled = false;

            lvRoles.Enabled = true;
            lvOwernRoles.Enabled = true;
            trvRoleRange.Enabled = true;
            EditState(true);
            IniTrvRoles(null);
            txtPassword.Text = "111111";
            txtPasswordAgin.Text = "111111";//新添加帐号初始密码为111111
        }
        /// <summary>
        /// 根据科室ID字符串得到所属院区-科室
        /// </summary>
        /// <param name="sectionIds"></param>
        /// <returns></returns>
        private ArrayList GetSectionIds(string sectionIds)
        {
            ArrayList sectionName = new ArrayList();
            string[] hsid = sectionIds.Split(',');
            for (int i = 0; i < hsid.Length;i++ )
            {
                string sql = "select a.section_name,b.sub_hospital_name from t_sectioninfo a inner join  T_Sub_HospitalInfo  b on a.shid=b.shid where a.sid='"+Convert.ToInt32(hsid[i].Trim())+"'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    string yuanqubingqu = ds.Tables[0].Rows[0]["sub_hospital_name"].ToString() + "-" + ds.Tables[0].Rows[0]["section_name"].ToString();
                    sectionName.Add(yuanqubingqu);
                }
            }

            return sectionName;
        }
        /// <summary>
        /// 获取用户是否还有文书没有写完
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        private string IsHaveDoc(int user_kind,string user_id)
        {
            string result = "";
            if (user_kind == 52 || user_kind == 70)
            {               
                //正式,轮转医生
                DataSet ds_docs = App.GetDataSet("select t.tid,t3.patient_name,t3.pid,t2.textname,t.doc_name,t.havedoctorsign from t_patients_doc t inner join t_text t2 on t.textkind_id=t2.id inner join t_in_patient t3 on t.patient_id=t3.id where t.createid=" + user_id + "");
                if (ds_docs != null)
                {
                    if (ds_docs.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_docs.Tables[0].Rows.Count; i++)
                        {
                            if (ds_docs.Tables[0].Rows[i]["havedoctorsign"].ToString() != "Y")
                            {

                                string strtemp = "病人姓名：" + ds_docs.Tables[0].Rows[i]["patient_name"].ToString() + ",住院号：" + ds_docs.Tables[0].Rows[i]["pid"].ToString() + ",文书类型：" + ds_docs.Tables[0].Rows[i]["textname"].ToString() + ",文书名称：" + ds_docs.Tables[0].Rows[i]["doc_name"].ToString();
                                if (result == "")
                                {
                                    result = "该用户还有一些文书没有签名：\n";
                                    result = result + strtemp;

                                }
                                else
                                {
                                    result = result + "\n" + strtemp;
                                }
                            }
                        }
                    }
                }
            }
            return result;

        }
        /// <summary>
        /// 获取科室ID字符串，作为SQL查询范围
        /// </summary>
        private void GetSectionIds()
        {

            for (int i = 0; i < App.UserAccount.Roles.Length; i++)
            {
                if (App.UserAccount.Roles[i].Role_name.Contains("主任")==true)
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
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            string sql_user = "select * from t_account a inner join t_account_user au on a.account_id=au.account_id inner join t_userinfo u on au.user_id=u.user_id where  a.account_name='" + txtAccount.Text.Trim() + "' order by a.ACCOUNT_ID desc";
            if (App.GetDataSet(sql_user).Tables[0].Rows.Count > 0)
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }
    }
}
