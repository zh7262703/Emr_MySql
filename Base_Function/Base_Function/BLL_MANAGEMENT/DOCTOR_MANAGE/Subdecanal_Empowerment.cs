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
    public partial class Subdecanal_Empowerment : UserControl
    {
        private Class_User[] Cuser;
        private Class_User[] Cusername;
        private string Subd_sql = "";
       
        public Subdecanal_Empowerment()
        {
            try
            {
                InitializeComponent();
                Subd_sql = @"select distinct u.user_id,u.user_name,f.section_id,r.role_id,r.role_name from t_userinfo u " +
                        @"inner join t_account_user a on a.user_id=u.user_id " +
                        @"inner join t_account tot on tot.account_id=a.account_id " +
                       @"  inner join t_acc_role tac on tac.account_id=tot.account_id " +
                       @" inner join t_role r on r.role_id=tac.role_id " +
                        @"inner join t_acc_role_range f on tac.id= f.acc_role_id " +
                        @"where r.role_type='O'";
            }
            catch
            {
            }

        }

        private void Subdecanal_Empowerment_Load(object sender, EventArgs e)
        {
            try
            {
                Section_username();
                User_chaxun();
                cboSubdcanal.SelectedIndex = 0;
            }
            catch
            {

            }


        }
        //根据职务（副院长）得到属于副院长的名字
        private void Section_username()
        {
            cboSubdcanal.Items.Clear();
            string sql = Subd_sql;
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                Cuser = new Class_User[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Cuser[i] = new Class_User();
                    Cuser[i].User_id = ds.Tables[0].Rows[i]["USER_ID"].ToString();
                    Cuser[i].User_name = ds.Tables[0].Rows[i]["USER_NAME"].ToString();
                    cboSubdcanal.Items.Add(Cuser[i]);

                }

                cboSubdcanal.ValueMember = "USER_ID";
                cboSubdcanal.DisplayMember = "USER_NAME";

            }

        }
        //根据副院长人名进行查询
        private void SectionChanged()
        {
            cboSubdcanal.Items.Clear();
            string sql1 = "";
            if (txtBox.Text.Trim() != "")
            {
                sql1 =Subd_sql +" and u.user_name like '%" + txtBox.Text.Trim() + "%'";

            }
            DataSet ds = new DataSet();
            ds = App.GetDataSet(sql1);
            if (ds != null)
            {
                Cusername = new Class_User[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Cusername[i] = new Class_User();
                    Cusername[i].User_id = ds.Tables[0].Rows[i]["USER_ID"].ToString();
                    Cusername[i].User_name = ds.Tables[0].Rows[i]["USER_NAME"].ToString();
                    cboSubdcanal.Items.Add(Cusername[i]);
                }
                cboSubdcanal.ValueMember = "USER_ID";
                cboSubdcanal.DisplayMember = "USER_NAME";
            }
        }
        private void User_chaxun()
        {
            lstSetionName.Items.Clear();
            string sename = "业务副院长授权管理";
            //sectionId = GetSelectItemId(name);
            string t_user = "";

            t_user = "select * from T_APPROVE_ACCREDIT tap inner join t_userinfo us on  tap.userid=us.user_id where t.type='" + sename + "'";

            DataSet dt = App.GetDataSet(t_user);
            Class_User[] Directionarys = GetDirectionary(dt);

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
        /// 实例化查询用户结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_User[] GetDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {

                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_User[] Directionary = new Class_User[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_User();
                        Directionary[i].User_id = Convert.ToInt32(tempds.Tables[0].Rows[i]["USER_ID"]).ToString();
                        Directionary[i].User_name = tempds.Tables[0].Rows[i]["USER_NAME"].ToString();
                        Directionary[i].U_gender_code = tempds.Tables[0].Rows[i]["GENDER_CODE"].ToString();
                        Directionary[i].Birth_date = DateTime.Parse(tempds.Tables[0].Rows[i]["BIRTHDAY"].ToString());
                        Directionary[i].U_tech_post = tempds.Tables[0].Rows[i]["U_TECH_POST"].ToString();
                        Directionary[i].U_seniority = tempds.Tables[0].Rows[i]["U_SENIORITY"].ToString();
                        Directionary[i].In_time = DateTime.Parse(tempds.Tables[0].Rows[i]["IN_TIME"].ToString());
                        if (tempds.Tables[0].Rows[i]["U_POSITION"].ToString().Trim() != "")
                        {
                            Directionary[i].U_position = tempds.Tables[0].Rows[i]["U_POSITION"].ToString();
                        }
                        Directionary[i].U_recipe_power = tempds.Tables[0].Rows[i]["U_RECIPE_POWER"].ToString();
                        Directionary[i].Section_id = tempds.Tables[0].Rows[i]["SECTION_ID"].ToString();
                        Directionary[i].Sickarea_id = tempds.Tables[0].Rows[i]["SICKAREA_ID"].ToString();
                        if (tempds.Tables[0].Rows[i]["PHONE"].ToString().Trim() != "")
                        {
                            Directionary[i].Phone = tempds.Tables[0].Rows[i]["PHONE"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["EMAIL"].ToString().Trim() != "")
                        {
                            Directionary[i].Email = tempds.Tables[0].Rows[i]["EMAIL"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["MOBILE_PHONE"].ToString().Trim() != "")
                        {
                            Directionary[i].Mobile_phone = tempds.Tables[0].Rows[i]["MOBILE_PHONE"].ToString();
                        }
                        Directionary[i].Enable_flag = tempds.Tables[0].Rows[i]["ENABLE"].ToString();
                        if (tempds.Tables[0].Rows[i]["PROFESSION_CARD"].ToString().Trim() != "")
                        {
                            Directionary[i].Profession_card = tempds.Tables[0].Rows[i]["PROFESSION_CARD"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["PROF_CARD_NAME"].ToString().Trim() != "")
                        {
                            Directionary[i].Prof_card_name = tempds.Tables[0].Rows[i]["PROF_CARD_NAME"].ToString();
                        }
                        Directionary[i].Pass_time = DateTime.Parse(tempds.Tables[0].Rows[i]["PASS_TIME"].ToString());
                        Directionary[i].Receive_time = DateTime.Parse(tempds.Tables[0].Rows[i]["RECEIVE_TIME"].ToString());
                        Directionary[i].Register_time = DateTime.Parse(tempds.Tables[0].Rows[i]["REGISTER_TIME"].ToString());


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
        /// 判断关系是否重复设置
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExist(string  name)
        {
            bool flag = false;
            for (int i = 0; i < lstSetionName.Items.Count; i++)
            {
                if (!(lstSetionName.Items[i].Text.GetType().ToString().Contains("Class_User")))
                {
                    //Class_User temp = (Class_User)lstSetionName.Items[i].Tag;
                    if (lstSetionName.Items[i].Text.ToString() == name.ToString())
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
            if (cboSubdcanal.SelectedItem.ToString() != "")
            {
                string bid;
                string name;
                ListViewItem lst = new ListViewItem();
                Class_User temp = (Class_User)cboSubdcanal.SelectedItem;
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
        }
        /// <summary>
        /// 收回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTakeback_Click(object sender, EventArgs e)
        {
            if (lstSetionName.SelectedItems.ToString() != "")
            {
                if (lstSetionName.SelectedItems.Count == 0)
                {
                    App.Msg("请选择你要收回的人");
                    return;
                }
                string temp = (lstSetionName.SelectedItems[0] as ListViewItem).Tag.ToString();
                string ESQ = "delete  from T_APPROVE_ACCREDIT   where USERID='" + temp + "'";
                App.ExecuteSQL(ESQ);
                lstSetionName.Items.Remove(lstSetionName.SelectedItems[0]);
                //cboSetionName.Items.Add(lstSetionName.SelectedItems[0]);

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
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {

            DataSet ds = App.GetDataSet("select * from t_approve_accredit where  USERID='" + id + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string type = "业务副院长授权管理";
            string SQL = "";

            //设置关系
            for (int i = 0; i < lstSetionName.Items.Count; i++)
            {
                string sectionId = "";
               

                string ids = lstSetionName.Items[i].Tag.ToString();//获取用户编号
                sectionId = GetSelectItemId(ids);
                // SID='" + sectionId + "' and and  AID='" + App.UserAccount.Account_id + "'
                string ss = "select *  from T_APPROVE_ACCREDIT where  USERID='" + ids + "' and TYPE='" + type + "' ";
                DataSet dst = App.GetDataSet(ss);
                int count1 = dst.Tables[0].Select("USERID='" + ids + "' and TYPE='" + type + "'").Length;
                if (count1 == 0)
                {
                    SQL = "insert into T_APPROVE_ACCREDIT(SID,USERID,TYPE,AID) values(" + sectionId + "," + ids + ",'" + type + "'," + App.UserAccount.Account_id + ")";
                }
                else
                {
                    SQL = "update T_APPROVE_ACCREDIT set USERID='" + ids + "'  where  TYPE='" + type + "'";
                }
                //SQL = "insert into T_APPROVE_ACCREDIT(SID,USERID,TYPE,AID) values(" + sectionId + "," + ids + ",'" + type + "'," + App.UserAccount.Account_id + ")";
                if (SQL != null)
                {
                    App.ExecuteSQL(SQL);
                }
                //if (isExisitName(App.ToDBC(ids)))
                //{
                //    App.Msg("已经存在相同的授权的名字了！");
                //    return;
                //}
                //SQL = "insert into T_APPROVE_ACCREDIT(SID,USERID,TYPE,AID) values(" + sectionId + "," + ids + ",'" + type + "'," + App.UserAccount.Account_id + ")";
                //App.ExecuteSQL(SQL);
            }
            App.Msg("操作成功！");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

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
                cboSubdcanal.SelectedIndex = 0;
            }
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBox_TextChanged(sender, e);
                cboSubdcanal.SelectedIndex = 0;
            }
        }



    }
}
