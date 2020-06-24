using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DataOperater.Model;

namespace Bifrost
{ 
    /// <summary>
    /// 帐号维护的功能模块 
    /// 创建者：张华
    /// 创建时间：2009-12-15
    /// </summary>
    public partial class frmSectionAccount : DevComponents.DotNetBar.Office2007Form
    {
        private bool IsSave = false;          //用于存放当前的操作状态 true为添加操作 false为修改操作

        private Class_Account CurrentAccount; //用于存放当前正在操作的帐户

        private Class_Role[] AllRoles;        //获取所有权限

        private string ID;                    //用户ID

        private string accounttype;           //帐号性质
                      

        /// <summary>
        /// 角色使用范围树
        /// </summary>
        public static TreeView trvTempRoleRange; 

        //string Role_Type = "";    //帐号类型
      

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmSectionAccount()
        {
            InitializeComponent();
              professional();

           
      
        //绑定职务
        position();
        
        //绑定处方权
        Prescription();
        
        //绑定所属科室
        Bangding();
        
        //绑定所属病区
        Sick();
        
        }

        /// <summary>
        /// 界面的刷新
        /// </summary>
        private void frmReflesh()
        {
            txtAccount.Text = "";                     
            lvOwernRoles.Items.Clear();            
            IniTrvRoles(null);
        }

        /// <summary>
        /// 清空用户信息
        /// </summary>
        private void UserInfoClear()
        {
            ID = "";
            //txtName.Text ="";          
            //cboCreer.Text = "";                     
            //txtPhone.Text ="";
            //txtTelphone.Text = "";
            //txtEmail.Text = "";            
            //txtCertificatename.Text = "";           

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
            accounttype = "";

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

                        accounttype = dsUser.Tables[0].Rows[0]["ACCOUNT_TYPE"].ToString();
                      
                    }
                }
               
            }
            catch
            { }
        }
      

        /// <summary>
        /// 刷新帐号列表，所有的用户信息刷新到树状控件。
        /// </summary>
        private void IniTrvAccount(string Accountname)
        {
            /*
             * 说明
             * 将T_ACCOUNT表的中的所有信息检索出来，然后再根据这些
             * 信息检索每个帐号所对应的角色，以及角色所对应的使用范围。
             */

            string Sql = "";
            trvAccount.Nodes.Clear();
            
            if (chkAll.Checked)
            {
                //select a.* from T_ACCOUNT a where a.account_id not in (select c.account_id from t_acc_role c)
                Sql = "select a.* from T_ACCOUNT a where a.ACCOUNT_NAME like '%" + Accountname + "%' and a.account_id not in (select c.account_id from t_acc_role c) order by a.ACCOUNT_ID desc";
            }
            else
            {
                Sql = "select a.* from T_ACCOUNT a where ACCOUNT_NAME like '%" + Accountname + "%' and  a.account_id not in (select c.account_id from t_acc_role c) and rownum<30 order by a.ACCOUNT_ID desc";
            }
            Class_Table[] tabSqls = new Class_Table[3];
            
            tabSqls[0] = new Class_Table();
            tabSqls[0].Sql = Sql;
            tabSqls[0].Tablename = "account";

            tabSqls[1] = new Class_Table();
            tabSqls[1].Sql = "select a.role_id,a.role_name,a.enable_flag,b.account_id,a.role_type from T_ROLE a inner join T_ACC_ROLE b on a.role_id=b.role_id";
            tabSqls[1].Tablename = "acc_role";
            
            tabSqls[2] = new Class_Table();          
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
        /// 初始化角色
        /// </summary>
        private void IniRoles()
        {
            DataSet ds = App.GetDataSet("select * from t_role g where g.role_name='普通医师' or  g.role_name='内科值班医生' or  g.role_name='外科值班医生'");
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
        ///编辑状态设置 
        /// </summary>
        /// <param name="flag"></param>
        private void EditState(bool flag)
        {           
            txtAccount.Enabled = flag;           
            this.panel6.Enabled = flag;
            btnSure.Enabled = flag;
            btnCancel.Enabled = flag;           
            if (flag)
            {
               
                btnUpdate.Enabled = false;
                groupPanel1.Enabled = false;             
            }
            else
            {
                
                btnUpdate.Enabled = true;
                groupPanel1.Enabled = true;               
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
        /// 取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EditState(false);
            frmReflesh();
        }
     


        /// <summary>
        /// 进行添加或修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {

            /*
             * 说明：
             * 1、添加操作：
             *    手动生成一个帐号的ID,然后再插入帐号，已经相关的角色和以及角色所对应使用范围。
             * 2、修改操作：
             *    对帐号表信息进行修改，然后再对“帐号角色关系表”，“角色和使用范围表”进行删除
             * 操作，然后再添加新的角色和相关使用范围。
             */
            try
            {
              
                int Account_Id = 0;          //帐号表的主键
                Account_Id = Convert.ToInt32(CurrentAccount.Account_id);
                ArrayList SqlStrs = new ArrayList();
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
                    if (App.UserAccount.CurrentSelectRole.Rnages!= null)
                    {
                        for (int i1 = 0; i1 < App.UserAccount.CurrentSelectRole.Rnages.Length; i1++)
                        {

                            string Section_id = "0";
                            string Area_id = "0";
                            if (App.UserAccount.CurrentSelectRole.Rnages[i1].Isbelonge == "0")
                            {
                                Section_id = App.UserAccount.CurrentSelectRole.Rnages[i1].Section_id;
                            }
                            else
                            {
                                Area_id = App.UserAccount.CurrentSelectRole.Rnages[i1].Sickarea_id;
                            }
                            SqlStrs.Add("insert into T_ACC_ROLE_RANGE(ACC_ROLE_ID,SICKAREA_ID,SECTION_ID,ISBELONGTO)values(" + ACC_ROLE_ID + "," + Area_id + "," + Section_id + ",'" + App.UserAccount.CurrentSelectRole.Rnages[i1].Isbelonge + "')");
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
                IniTrvAccount(txtAccountCheck.Text);
                btnCancel_Click(sender, e);
            }
            catch(Exception ex)
            {
                App.MsgErr("操作失败！原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 添加帐号的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            EditState(true);
            frmReflesh();
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            EditState(true);            
        }


        private void frmAccount_Load(object sender, EventArgs e)
        {        
            IniTrvAccount(txtAccountCheck.Text);
            IniRoles();
            IniTrvRoles(null);
            EditState(false);                                            
        }

        

        /// <summary>
        /// 加载选择项
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
        /// 移除选择项
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
        /// 删除帐号操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDetelet_Click(object sender, EventArgs e)
        {
            /*
             * 说明：
             * 在删除帐号的同时，必须将相关的信息(帐号用户关系，帐号角色关系，帐号角色使用范围)也删除。
             */
            if (trvAccount.SelectedNode != null)
            {
                if (App.Ask("确定删除帐号吗？"))
                {
                    string[] Sqls = new string[4];
                    Sqls[0] = "delete from T_ACCOUNT where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                    Sqls[1] = "delete from T_ACCOUNT_USER where ACCOUNT_ID=" + CurrentAccount.Account_id + "";
                    Sqls[2] = "delete from t_acc_role_range where ACC_ROLE_ID in (select id from T_ACC_ROLE where ACCOUNT_ID='" + CurrentAccount.Account_id + "')";
                    Sqls[3] = "delete from T_ACC_ROLE where ACCOUNT_ID='" + CurrentAccount.Account_id + "'";
                    if (App.ExecuteBatch(Sqls) > 0)
                    {
                        App.Msg("操作已经成功！");
                        trvAccount.Nodes.Remove(trvAccount.SelectedNode);
                    }
                }                
            }
        }      
     
       
        private void trvAccount_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        #region combobox 绑定
        //绑定职称
        private void professional()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE  where Type='1'");
            cboCreer.DataSource = ds.Tables[0].DefaultView;
            cboCreer.ValueMember = "ID";
            cboCreer.DisplayMember = "NAME";
        }
        //绑定职务
        private void position()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='2'");
            cboCreers.DataSource = ds.Tables[0].DefaultView;
            cboCreers.ValueMember = "ID";
            cboCreers.DisplayMember = "NAME";
        }
        ////绑定年资
        //private void Price()
        //{

        //    DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='6'");
        //    cboPrice.DataSource = ds.Tables[0].DefaultView;
        //    cboPrice.ValueMember = "ID";
        //    cboPrice.DisplayMember = "NAME";
        //}
        //绑定处方权
        private void Prescription()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='7'");
            cboPrescription.DataSource = ds.Tables[0].DefaultView;
            cboPrescription.ValueMember = "ID";
            cboPrescription.DisplayMember = "NAME";
        }
        //绑定所属科室
        private void Bangding()
        {
            DataSet dt = App.GetDataSet("select * from T_SECTIONINFO");
            cboOffice.DataSource = dt.Tables[0].DefaultView;
            cboOffice.ValueMember = "SID";
            cboOffice.DisplayMember = "SECTION_NAME";
        }
        //绑定所属病区
        private void Sick()
        {
            DataSet dt = App.GetDataSet("select * from T_SICKAREAINFO");
            cboSick.DataSource = dt.Tables[0].DefaultView;
            cboSick.ValueMember = "SAID";
            cboSick.DisplayMember = "SICK_AREA_NAME";
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {           
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            IniTrvAccount(txtAccountCheck.Text);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            IniTrvAccount(txtAccountCheck.Text);
        }

        private void txtAccountCheck_TextChanged(object sender, EventArgs e)
        {
           
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

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            tabControl2.Refresh();
        }

        private void cboAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

              

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }
       

        /// <summary>
        /// 帐号的选择操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvAccount_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                CurrentAccount = (Class_Account)trvAccount.SelectedNode.Tag;

                txtAccount.Text = CurrentAccount.Account_name;
                IniTrvRoles(CurrentAccount);//初始化可以选择的权限数
                IniTrvOwner(CurrentAccount);//初始化已经拥有的权限树
                IniUserInfor(CurrentAccount.Account_id);//初始化用户信息
            }
        }
    }
}