using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.AdvTree;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class UcMedicalRightRun : UserControl
    {
        public UcMedicalRightRun()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }
        Class_User user = new Class_User();
        private void UcMedicalRightRun_Load(object sender, EventArgs e)
        {
            this.lveSection1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.lveSection2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            cboSearchType.SelectedIndex = 0;
            //GetUsers();
            GetSection();
        }

        private void GetSection()
        {
            // 查询科室信息
            string sql_sectionInfo = "select a.sid,a.section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid";
            try
            {
                DataSet ds = App.GetDataSet(sql_sectionInfo);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Class_Sections section = new Class_Sections();
                        section.Sid = Convert.ToInt32(dt.Rows[i]["sid"]);
                        section.Section_Name = dt.Rows[i]["section_name"].ToString();
                        ListViewItem listItem = new ListViewItem();
                        listItem.Tag = section;
                        listItem.Text = section.Section_Name;
                        lveSection1.Items.Add(listItem);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void trvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (trvAccount.SelectedNode != null)
                {
                    
                    GetUserInfo(user);
                    
                    lblName.Text = user.User_name;
                    lblSex.Text = user.U_gender_code.Contains("1") ? "女" : "男";
                    lblId.Text = App.ReadSqlVal("select c.account_name from t_userinfo a inner join t_account_user b on a.user_id=b.user_id inner join t_account c on b.account_id=c.account_id where a.user_id=" + user.User_id, 0, "account_name");
                    lblPosition.Text = user.U_position_name;
                    lblSection.Text = user.Section.Section_Name;
                    lblSick_area.Text = user.Sickarea_id;
                    lblTech_Post.Text = user.U_tech_post_name;
                    lblInTime.Text = user.In_time.ToString();
                    //清空科室ListView的选中项
                    for (int i = 0; i < lveSection1.Items.Count; i++)
                    {
                        lveSection1.Items[i].Checked = false;
                    }
                    lveSection2.Items.Clear();
                    //设置已分配的科室为选中
                    string sql_sections = "select section_id from t_user_section_right where user_id=" + user.User_id;

                    DataSet ds = App.GetDataSet(sql_sections);
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            foreach (ListViewItem lstItem in lveSection1.Items)
                            {
                                Class_Sections section = lstItem.Tag as Class_Sections;
                                if (section.Sid == Convert.ToInt32(dt.Rows[i]["section_id"]))
                                {
                                    lstItem.Checked = true;
                                    break;
                                }
                            }
                        }
                        btnAdd_Click(sender, e);
                    }

                }
            }
            catch (Exception ex)
            {

            }


        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="user"></param>
        private void GetUserInfo(Class_User user)
        {
            Class_Account account = trvAccount.SelectedNode.Tag as Class_Account;
            // 查询用户信息
            string sql_userInfo = "select c.account_name,a.user_id,a.user_name," +
                                "a.gender_code,(select name from t_data_code bb where a.U_Position=bb.id) 职务," +
                                "(select name from t_data_code cc where a.u_tech_post=cc.id) 职称," +
                                "(select section_name from t_sectioninfo dd where a.section_id=dd.sid) 科室," +
                                "(select sick_area_name from t_sickareainfo ee where a.sickarea_id=ee.said) 病区," +
                                "to_char(a.in_time,'yyyy-MM-dd HH24:mi:ss') 入职时间 from t_userinfo a inner join " +
                                "t_account_user b on a.user_id=b.user_id " +
                                "inner join t_account c on b.account_id=c.account_id where c.account_id='" + account.Account_id + "'";
            DataSet ds_userInfo = App.GetDataSet(sql_userInfo);

            if (ds_userInfo != null)
            {
                DataTable dt = ds_userInfo.Tables[0];
                user.User_id = dt.Rows[0]["user_id"].ToString();
                user.User_name = dt.Rows[0]["user_name"].ToString();
                user.U_gender_code = dt.Rows[0]["gender_code"].ToString();
                user.U_tech_post_name = dt.Rows[0]["职称"].ToString();
                user.U_position_name = dt.Rows[0]["职务"].ToString();
                user.Section = new Class_Sections();
                user.Section.Section_Name = dt.Rows[0]["科室"].ToString();
                user.Sickarea_id = dt.Rows[0]["病区"].ToString();
                user.In_time = Convert.ToDateTime(dt.Rows[0]["入职时间"]);
            }
        }

        /// <summary>
        /// 添加科室到“已选科室”列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //循环遍历“可选科室”列表的每一项，把勾选的科室添加到“已选科室”中
            foreach (ListViewItem lstItem in lveSection1.Items)
            {
                if (lstItem.Checked)
                {
                    bool flag = false;//验证是否有相同科室的标识
                    //先验证“已选科室”中是否存在相同科室
                    foreach (ListViewItem lstItem2 in lveSection2.Items)
                    {
                        if (lstItem2.Text == lstItem.Text)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        lveSection2.Items.Add(lstItem.Clone() as ListViewItem);
                    }
                }
            }
        }

        /// <summary>
        /// 移除“已选科室”的选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lveSection2.SelectedItems.Count > 0)
            {

                foreach (ListViewItem lstItem in lveSection1.Items)
                {
                    if (lstItem.Text == lveSection2.SelectedItems[0].Text)
                    {
                        lstItem.Checked = false;
                    }
                }
                lveSection2.SelectedItems[0].Remove();
            }
        }

        /// <summary>
        /// 授权
        /// 1:删除以前的授权科室
        /// 2:重新插入新的授权科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                if (lveSection2.Items.Count > 0)
                {
                    string strsInsert = "delete from T_USER_SECTION_RIGHT where user_id=" + user.User_id;
                    for (int i = 0; i < lveSection2.Items.Count; i++)
                    {
                        Class_Sections section = lveSection2.Items[i].Tag as Class_Sections;
                        string sql_insert = "insert into T_USER_SECTION_RIGHT(user_id,section_id) values(" + Convert.ToInt32(user.User_id) + "," + section.Sid + ")";
                        strsInsert += "&" + sql_insert;
                    }
                    //转换成string类型的数组，批处理Sql
                    string[] strArray = strsInsert.Split('&');
                    int num = App.ExecuteBatch(strArray);
                    if (num > 0)
                    {
                        App.Msg("授权成功！");
                    }
                }
                else
                {
                    App.Msg("请选择至少一个科室！");
                }
            }
            else
            {
                App.Msg("请选择一个用户作为授权对象！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                string sql_del = "delete from T_USER_SECTION_RIGHT where user_id=" + user.User_id;
                int num = App.ExecuteSQL(sql_del);
                if (num > 0)
                {
                    App.Msg("授权已取消！");
                    //清空科室ListView的选中项
                    for (int i = 0; i < lveSection1.Items.Count; i++)
                    {
                        lveSection1.Items[i].Checked = false;
                    }
                    lveSection2.Items.Clear();
                }
            }
            else
            {
                App.Msg("请选择一个用户对象！");
            }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lveSection1.Items.Count; i++)
            {
                if (checkBoxX1.Checked)
                {
                    lveSection1.Items[i].Checked = true;
                }
                else
                {
                    lveSection1.Items[i].Checked = false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IniTrvAccount(txtName.Text);
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
                Sql = "select * from t_account a inner join t_account_user b on a.account_id=b.account_id inner join t_userinfo c on b.user_id = c.user_id where 1=1";
            }
            else
            {
                Sql = "select * from t_account a inner join t_account_user b on a.account_id=b.account_id inner join t_userinfo c on b.user_id = c.user_id where rownum <30";
            }
            if (cboSearchType.Text == "按姓名")
            {
                Sql += " and c.user_name like '%" + Accountname + "%'";
            }
            else if (cboSearchType.Text == "按工号")
            {
                Sql += " and a.account_name like '%" + Accountname + "%'";
            }
            Sql += " order by a.account_id";
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
                    account.Kind = Convert.ToInt32(ds.Tables["account"].Rows[i]["KIND"].ToString());
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
    }
}
