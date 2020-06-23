using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    public partial class Section_HeadEmpowerment : UserControl
    {
        private Class_User[] Cuser;
        private Class_User[] Cusername;
        private string id;//科室id
        private string sectid;
        private DataSet dsdata;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string ItemName
        {
            get { return this.lblSetionName.Text; }
            set { this.lblSetionName.Text = value; }
        }

        public DataSet DsData
        {
            get{return dsdata;}
            set{dsdata=value;}
        }

        public Section_HeadEmpowerment()
        {
            try
            {
                InitializeComponent();

            }
            catch
            {
            }
        }

        public Section_HeadEmpowerment(string id, string itemName,DataSet ds)
        {
            InitializeComponent();
            this.Id = id;
            this.lblSetionName.Text = itemName;
            DsData = ds;

        }

        private void Section_HeadEmpowerment_Load(object sender, EventArgs e)
        {
            try
            {
                Section_username();
                User_chaxun();
                cboSetionName.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        /// <summary>
        /// 实例化查询用户结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_User[] GetDirectionary(DataRow[] Rows)
        {
            if (Rows != null)
            {

                if (Rows.Length > 0)
                {
                    Class_User[] Directionary = new Class_User[Rows.Length];
                    for (int i = 0; i <Rows.Length; i++)
                    {
                        Directionary[i] = new Class_User();
                        Directionary[i].User_id = Convert.ToInt32(Rows[i]["USER_ID"]).ToString();
                        Directionary[i].User_name = Rows[i]["USER_NAME"].ToString();
                        Directionary[i].U_gender_code = Rows[i]["GENDER_CODE"].ToString();
                        Directionary[i].Birth_date = DateTime.Parse(Rows[i]["BIRTHDAY"].ToString());
                        Directionary[i].U_tech_post = Rows[i]["U_TECH_POST"].ToString();
                        Directionary[i].U_seniority = Rows[i]["U_SENIORITY"].ToString();
                        Directionary[i].In_time = DateTime.Parse(Rows[i]["IN_TIME"].ToString());
                        if (Rows[i]["U_POSITION"].ToString().Trim() != "")
                        {
                            Directionary[i].U_position = Rows[i]["U_POSITION"].ToString();
                        }
                        Directionary[i].U_recipe_power = Rows[i]["U_RECIPE_POWER"].ToString();
                        Directionary[i].Section_id = Rows[i]["SECTION_ID"].ToString();
                        Directionary[i].Sickarea_id = Rows[i]["SICKAREA_ID"].ToString();
                        if (Rows[i]["PHONE"].ToString().Trim() != "")
                        {
                            Directionary[i].Phone = Rows[i]["PHONE"].ToString();
                        }
                        if (Rows[i]["EMAIL"].ToString().Trim() != "")
                        {
                            Directionary[i].Email = Rows[i]["EMAIL"].ToString();
                        }
                        if (Rows[i]["MOBILE_PHONE"].ToString().Trim() != "")
                        {
                            Directionary[i].Mobile_phone = Rows[i]["MOBILE_PHONE"].ToString();
                        }
                        Directionary[i].Enable_flag = Rows[i]["ENABLE"].ToString();
                        if (Rows[i]["PROFESSION_CARD"].ToString().Trim() != "")
                        {
                            Directionary[i].Profession_card = Rows[i]["PROFESSION_CARD"].ToString();
                        }
                        if (Rows[i]["PROF_CARD_NAME"].ToString().Trim() != "")
                        {
                            Directionary[i].Prof_card_name = Rows[i]["PROF_CARD_NAME"].ToString();
                        }
                        Directionary[i].Pass_time = DateTime.Parse(Rows[i]["PASS_TIME"].ToString());
                        Directionary[i].Receive_time = DateTime.Parse(Rows[i]["RECEIVE_TIME"].ToString());
                        Directionary[i].Register_time = DateTime.Parse(Rows[i]["REGISTER_TIME"].ToString());


                    }
                    return Directionary;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据科室得到属于这个科室医生
        /// </summary>
        private void Section_username()
        {

            cboSetionName.Items.Clear();
            //string sql = "select u.user_id,u.user_name,u.section_id,t.section_name from t_userinfo u  " +
            //               @" inner join t_sectioninfo t on t.sid=u.section_id where t.ISBELONGTOBIGSECTION='N' and t.section_name='" + lblSetionName.Text + "'";
            //section_name='" + lblSetionName.Text + "'
            //DataSet ds = App.GetDataSet(sql);
            DataRow[] Rows = DsData.Tables["Sections_Peoples"].Select(" section_id='" + Id + "' and  ISBELONGTOBIGSECTION='N' and role_type='D' ");
            if (Rows != null)
            {
                Cuser = new Class_User[Rows.Length];
                for (int i = 0; i < Rows.Length; i++)
                {
                    Cuser[i] = new Class_User();
                    Cuser[i].User_id = Rows[i]["USER_ID"].ToString();
                    Cuser[i].User_name = Rows[i]["USER_NAME"].ToString();
                    cboSetionName.Items.Add(Cuser[i]);

                }
                //cboSetionName.DataSource = ds.Tables[0].DefaultView;
                cboSetionName.ValueMember = "USER_ID";
                cboSetionName.DisplayMember = "USER_NAME";
                //cboSetionName.SelectedIndex = 0;
            }
            //cboSetionName.SelectedIndex = 0;
        }



        //
        /// <summary>
        /// 根据科室和科室人名进行查询
        /// </summary>
        private void SectionChanged()
        {
            cboSetionName.Items.Clear();
            //string sql1 = "";
            DataRow[] Rows;
            if (txtBox.Text.Trim() != "")
            {
                //sql1 = "select u.user_id,u.user_name,u.section_id,t.section_name from t_userinfo u  " +
                //           @" inner join t_sectioninfo t on t.sid=u.section_id where t.ISBELONGTOBIGSECTION='N' and t.section_name='" + lblSetionName.Text + "' and u.user_name like '%" + txtBox.Text.Trim() + "%'";
                Rows = DsData.Tables["Sections_Peoples"].Select("ISBELONGTOBIGSECTION='N' and role_type='D' and  section_id='" + Id + "' and  user_name like '%" + txtBox.Text.Trim() + "%'");
            }
            else
            {
                Rows = null;
            }
            if (Rows != null)
            {
                Cusername = new Class_User[Rows.Length];
                for (int i = 0; i < Rows.Length; i++)
                {
                    Cusername[i] = new Class_User();
                    Cusername[i].User_id = Rows[i]["USER_ID"].ToString();
                    Cusername[i].User_name = Rows[i]["USER_NAME"].ToString();
                    cboSetionName.Items.Add(Cusername[i]);

                }
                //cboSetionName.DataSource = ds.Tables[0].DefaultView;
                cboSetionName.ValueMember = "USER_ID";
                cboSetionName.DisplayMember = "USER_NAME";
                

            }
            

        }

        /// <summary>
        /// 根据科室显示已经授权的人
        /// </summary>
        private void User_chaxun()
        {
            //lstSetionName.Items.Clear();
            string uid = Id;
            DataRow[] Rows = DsData.Tables["Sections_Exist_peoples"].Select("SID='" + uid + "'");
            Class_User[] Directionarys = GetDirectionary(Rows);

            if (Directionarys != null)
            {

                for (int i = 0; i < Directionarys.Length; i++)
                {

                    ListViewItem tm = new ListViewItem();
                    tm.Tag = Directionarys[i].User_id;
                    tm.Text = Directionarys[i].User_name;

                    lstSetionName.Items.Add(tm);
                }
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (txtBox.Text.Trim() != "")
            {
                SectionChanged();
            }
            else
            {
                Section_username();
                User_chaxun();
                cboSetionName.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 回车查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBox_TextChanged(sender, e);
                cboSetionName.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 判断关系是否重复设置
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExist(string name)
        {
            bool flag = false;
            for (int i = 0; i < lstSetionName.Items.Count; i++)
            {
                if (!(lstSetionName.Items[i].Text.GetType().ToString().Contains("Class_User")))
                {
                   
                    if (lstSetionName.Items[i].Text.ToString() ==name.ToString())
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }


        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImpower_Click(object sender, EventArgs e)
        {
            if (cboSetionName.SelectedItem != null)
            {
                string bid;
                string name;
                ListViewItem lst = new ListViewItem();
                Class_User temp = (Class_User)cboSetionName.SelectedItem;
                bid = temp.User_id.ToString();
                name = temp.User_name.ToString();
                lst.Tag = bid;
                lst.Text = name;
                if (!isExist(name))
                {

                    lstSetionName.Items.Add(lst);
                }
                else
                {
                    App.Msg("你已经给这个人授权了!");
                }

            }
            else
            {
                App.Msg("选中您要授权的人");
            }
        }
        /// <summary>
        /// 收回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntakeBack_Click(object sender, EventArgs e)
        {

            if (Id != null)
            {
                if (lstSetionName.SelectedItems.ToString() != "")
                {
                    if (this.lstSetionName.SelectedItems.Count == 0)
                    {
                        App.Msg("您还没有选择要收回的人呢。");
                        return;
                    }
                    string temp = (lstSetionName.SelectedItems[0] as ListViewItem).Tag.ToString();
                    string ESQ = "delete  from T_APPROVE_ACCREDIT   where USERID='" + temp + "' and  sid='" + Id + "'";
                    App.ExecuteSQL(ESQ);
                    lstSetionName.Items.Remove(lstSetionName.SelectedItems[0]);
                }
            }

        }
        /// <summary>
        /// 根据项目科室名称获取相关记录的ID
        /// </summary>
        /// <param Name="ItemName">科室名称</param>
        /// <returns></returns>
        private string GetSelectItemId(string ItemName)
        {
            string Sql = "select section_id from t_userinfo  where user_id='" + ItemName + "'";
            string ID = App.ReadSqlVal(Sql, 0, "section_id");
            return ID;
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //lstSetionName.Items.Clear();
            string type = "科主任授权管理";
            string SQL = "";
            if (Id != null)
            {
                //设置关系
                for (int i = 0; i < lstSetionName.Items.Count; i++)
                {


                    string ids = lstSetionName.Items[i].Tag.ToString();//获取用户编号
                   //string  sectionId = GetSelectItemId(ids);
                   //sectid = sectionId;
                   string ss = "select *  from T_APPROVE_ACCREDIT where  USERID='" + ids + "' and  SID='" + Id + "' and TYPE='" + type + "' ";

                   DataSet dst = App.GetDataSet(ss);
                   int count1 = dst.Tables[0].Select("USERID='" + ids + "' and  SID='" + Id + "' and TYPE='" + type + "'").Length;
                   if (count1 == 0)
                   {
                       SQL = "insert into T_APPROVE_ACCREDIT(SID,USERID,TYPE,AID) values(" + Id + "," + ids + ",'" + type + "'," + App.UserAccount.Account_id + ")";
                   }
                   else
                   {
                       SQL = "update T_APPROVE_ACCREDIT set USERID='" + ids + "',and  SID='" + Id + "'  where  TYPE='" + type + "' and  AID=" + App.UserAccount.Account_id + "";
                   }
                   if (SQL != null)
                   {
                       App.ExecuteSQL(SQL);
                   }
                    ////Class_User temp = (Class_User)lstSetionName.SelectedItems[0].Tag;
                    //SQL = "insert into T_APPROVE_ACCREDIT(SID,USERID,TYPE,AID) values(" + Id + "," + ids + ",'" + type + "'," + App.UserAccount.Account_id + ")";
                    //App.ExecuteSQL(SQL);


                }
                App.Msg("操作成功！");
                Show_chaxun();
                

            }


        }
        /// <summary>
        /// 根据科室显示已经授权的人
        /// </summary>
        private void Show_chaxun()
        {
            lstSetionName.Items.Clear();
            Bifrost.WebReference.Class_Table[] NTables1 = new Bifrost.WebReference.Class_Table[1];
            NTables1[0] = new Bifrost.WebReference.Class_Table();
            NTables1[0].Tablename = "Sections_peoples";
            NTables1[0].Sql = "select * from T_APPROVE_ACCREDIT tap inner join t_userinfo us on  tap.userid=us.user_id ";
            DataSet ds = App.GetDataSet(NTables1);
            DataRow[] Rows = ds.Tables["Sections_peoples"].Select("SID='" + Id + "'");
            Class_User[] Directionarys = GetDirectionary(Rows);

            if (Directionarys != null)
            {

                for (int i = 0; i < Directionarys.Length; i++)
                {

                    ListViewItem tm = new ListViewItem();
                    tm.Tag = Directionarys[i].User_id;
                    tm.Text = Directionarys[i].User_name;

                    lstSetionName.Items.Add(tm);
                }
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }












    }
}
