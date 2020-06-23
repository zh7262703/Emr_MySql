using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;


namespace Base_Function.BASE_DATA
{
    public partial class ucDiagnosis_Account : UserControl
    {
        Class_Account currAccount;//当前选中帐户的对象
        Class_DiagnosisTreat currDiagnosisTreat;//当前选中诊疗护理组的对象
 
        public ucDiagnosis_Account()
        {
            InitializeComponent();
        }

        private void frmDiagnosis_Account_Activated(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
            btnSelect_B_Click(sender, e);
        }
        
        /// <summary>
        /// 判断关系是否重复设置
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExist(int id)
        {           
            bool flag = false;
            for (int i = 0; i < lvRelation.Items.Count; i++)
            {
                if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Account"))
                {
                    Class_Account temp = (Class_Account)lvRelation.Items[i].Tag;
                    if (temp.Account_id== id.ToString())
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 实例化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_TngAccount[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_TngAccount[] Directionary = new Class_TngAccount[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_TngAccount();
                        Directionary[i].Id =Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        Directionary[i].Tng_id =Convert.ToInt32(tempds.Tables[0].Rows[i]["TNG_ID"].ToString());
                        Directionary[i].Account_id =Convert.ToInt32(tempds.Tables[0].Rows[i]["ACCOUNT_ID"].ToString());

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
        /// 实例化查询帐户结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Account[] GetDirectionary(DataSet tempds)
        {  
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Account[] Directionary = new Class_Account[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Account();
                        Directionary[i].Account_id =Convert.ToInt32(tempds.Tables[0].Rows[i]["ACCOUNT_ID"]).ToString();
                        Directionary[i].Account_type = tempds.Tables[0].Rows[i]["ACCOUNT_TYPE"].ToString();
                        Directionary[i].Account_name = tempds.Tables[0].Rows[i]["ACCOUNT_NAME"].ToString();
                        Directionary[i].Password = tempds.Tables[0].Rows[i]["PASSWORD"].ToString();
                        Directionary[i].Enable = tempds.Tables[0].Rows[i]["ENABLE"].ToString();
                        if (tempds.Tables[0].Rows[i]["ENABLE_START_TIME"].ToString().Trim() != "")
                        {
                            Directionary[i].Enable_start_time = DateTime.Parse(tempds.Tables[0].Rows[i]["ENABLE_START_TIME"].ToString());
                        }
                        
                        if (tempds.Tables[0].Rows[i]["ENABLE_END_TIME"].ToString().Trim()!= "")
                        {
                            Directionary[i].Enable_end_time = DateTime.Parse(tempds.Tables[0].Rows[i]["ENABLE_END_TIME"].ToString());
                        }
                        if (tempds.Tables[0].Rows[i]["ENABLE_END_TIME"].ToString().Trim()!="")
                        {
                             Directionary[i].Enable_end_time =DateTime.Parse(tempds.Tables[0].Rows[i]["ENABLE_END_TIME"].ToString());
                        }
                        
                        Directionary[i].Last_login_ip =tempds.Tables[0].Rows[i]["LAST_LOGIN_IP"].ToString();
                        if(tempds.Tables[0].Rows[i]["LAST_LOGIN_TIME"].ToString().Trim()!="")
                        {
                             Directionary[i].Last_login_time =DateTime.Parse(tempds.Tables[0].Rows[i]["LAST_LOGIN_TIME"].ToString());
                        }
                        if (tempds.Tables[0].Rows[i]["LAST_EXIT_TIME"].ToString().Trim() != "")
                        {
                            Directionary[i].Last_exit_time = DateTime.Parse(tempds.Tables[0].Rows[i]["LAST_EXIT_TIME"].ToString());
                        }
                        if (App.IsNumeric(tempds.Tables[0].Rows[i]["KIND"].ToString()))
                            Directionary[i].Kind =Convert.ToInt32(tempds.Tables[0].Rows[i]["KIND"].ToString());

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
        /// 实例化查询诊疗护理组结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_DiagnosisTreat[] GetTreatDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_DiagnosisTreat[] Directionary = new Class_DiagnosisTreat[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_DiagnosisTreat();
                        Directionary[i].Tng_id= Convert.ToInt32(tempds.Tables[0].Rows[i]["TNG_ID"].ToString());
                        Directionary[i].Tng_code= tempds.Tables[0].Rows[i]["TNG_CODE"].ToString();
                        Directionary[i].Tng_name= tempds.Tables[0].Rows[i]["TNG_NAME"].ToString();
                        Directionary[i].Director_id = tempds.Tables[0].Rows[i]["DIRECTOR_ID"].ToString();
                        Directionary[i].Tng_type= tempds.Tables[0].Rows[i]["TNG_TYPE"].ToString();
                        Directionary[i].Enable_flag = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        Directionary[i].Belongto_id = tempds.Tables[0].Rows[i]["BELONGTO_ID"].ToString();
                        Directionary[i].Specialties_flag = tempds.Tables[0].Rows[i]["SPECIALTIES_FLAG"].ToString();
                      
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
        /// 诊疗护理组查询
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (txtConditions.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险!");
                    txtConditions.Focus();
                    return;
                }
                lvDiagnosisTreat.Items.Clear();
                string Sql = "select * from T_TREATORNURSE_GROUP ";

                if (txtConditions.Text.Trim() != "")
                {
                    Sql = "select * from T_TREATORNURSE_GROUP where TNG_NAME like '%" + txtConditions.Text.Trim() + "%'";
                }
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_DiagnosisTreat[] Directionarys = GetTreatDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        /**/
                        ListViewItem tempitem = new ListViewItem();
                        tempitem.Tag = Directionarys[i];
                        tempitem.Text = Directionarys[i].Tng_name;
                        tempitem.ImageIndex = 0;
                        lvDiagnosisTreat.Items.Add(tempitem);
                        
                    }
                }
                //else
                //{
                //    App.Msg("没有找到查询结果！");
                //}
            }
            catch
            { }
            finally
            {
                btnSelect.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// 帐户查询
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_B_Click(object sender, EventArgs e)
        {
         
            try
            {
                btnSelect_B.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (txtConditions_B.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险!");
                    txtConditions.Focus();
                    return;
                }
                lvAccount.Items.Clear();
                
                string Sql = "select * from T_ACCOUNT ";

                if (txtConditions_B.Text.Trim() != "")
                {
                    Sql = "select * from T_ACCOUNT where ACCOUNT_NAME like '%" + txtConditions_B.Text.Trim() + "%'";
                }
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Account[] Directionarys = GetDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                      
                        ListViewItem tempitem = new ListViewItem();
                        tempitem.Tag = Directionarys[i];
                        tempitem.Text = Directionarys[i].Account_name;
                        tempitem.ImageIndex = 1;
                        lvAccount.Items.Add(tempitem);

                       

                    }
                }
                //else
                //{
                //    App.Msg("没有找到查询结果！");
                //}
            }
            catch
            { }
            finally
            {
                btnSelect_B.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// 清空关系
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (currDiagnosisTreat != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("确定要删除所有关系？"))
                    {
                        string sql = "delete from T_TNG_ACCOUNT where TNG_ID=" + currDiagnosisTreat.Tng_id + "";
                        App.ExecuteSQL(sql);
                        lvRelation.Items.Clear();
                    }
                }
            }
        }
        /// <summary>
        /// 移除诊疗护理组与账户之间的关系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currDiagnosisTreat != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("你是否要删除？"))
                    {

                        Class_Account temp = (Class_Account)lvRelation.SelectedItems[0].Tag;
                        App.ExecuteSQL("delete from T_TNG_ACCOUNT where ACCOUNT_ID=" + temp.Account_id.ToString() + " and TNG_ID=" + currDiagnosisTreat.Tng_id + "");
                        lvRelation.Items.Remove(lvRelation.SelectedItems[0]);

                    }
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currDiagnosisTreat != null)
                {

                    //清空原有关系 
                    if (currDiagnosisTreat != null)
                    {

                        App.ExecuteSQL("delete from T_TNG_ACCOUNT  where   TNG_ID=" + currDiagnosisTreat.Tng_id + "");

                    }
                    //设置现有关系
                    for (int i = 0; i < lvRelation.Items.Count; i++)
                    {
                        if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Account"))
                        {
                            Class_Account temp = (Class_Account)lvRelation.Items[i].Tag;
                            int id = App.GenId("T_TNG_ACCOUNT", "ID");
                            App.ExecuteSQL("insert into T_TNG_ACCOUNT(ID,TNG_ID,ACCOUNT_ID) values(" + id + "," + currDiagnosisTreat.Tng_id.ToString() + "," + temp.Account_id.ToString() + ")");

                        }

                    }
                    App.Msg("操作成功！");

                }
                else
                {
                    App.Msg("请先选择病区！");
                }
            }
            catch (Exception ex)
            {
                App.Msg("操作失败，原因:" + ex.ToString() + "");
            }
        }
 
        private void frmDiagnosis_Account_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("诊疗护理组与帐户关系设置");
            this.panel5.Left = (418 - 216) / 2;
        }

        private void frmDiagnosis_Account_Resize(object sender, EventArgs e)
        {
            this.panel5.Left = (this.panel2.Width - this.panel5.Width) / 2;
        }

        private void lvDiagnosisTreat_Click(object sender, EventArgs e)
        {

            if (lvDiagnosisTreat.SelectedItems != null)
            {
                lvRelation.Items.Clear();
                currDiagnosisTreat = (Class_DiagnosisTreat)lvDiagnosisTreat.SelectedItems[0].Tag;
                lblSelectValue.Text = currDiagnosisTreat.Tng_name;

                DataSet ds = App.GetDataSet("select * from　T_ACCOUNT a inner join T_TNG_ACCOUNT b on a.account_id=b.account_id  where b.TNG_ID='" + currDiagnosisTreat.Tng_id.ToString() + "'");

                Class_Account[] Directionarys = GetDirectionary(ds);

                if (Directionarys != null)
                {

                    for (int i = 0; i < Directionarys.Length; i++)
                    {

                        ListViewItem tm = new ListViewItem();
                        tm.Tag = Directionarys[i];
                        tm.Text = Directionarys[i].Account_name;
                        tm.ImageIndex = 1;
                        lvRelation.Items.Add(tm);
                    }
                }
            }
            btnSelect_B_Click(sender, e);
        }

        private void lvAccount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvAccount.SelectedItems != null)
            {
                if (lvAccount.SelectedItems[0].Tag.GetType().ToString().Contains("Class_Account"))
                {
                    Class_Account temp = (Class_Account)lvAccount.SelectedItems[0].Tag;
                    if (!isExist(Convert.ToInt32(temp.Account_id)))
                    {
                    
                        ListViewItem tem = new ListViewItem();
                        tem.Tag = temp;
                        tem.Text = temp.Account_name;
                        tem.ImageIndex = 1;
                        lvRelation.Items.Add(tem);

                    }
                    else
                    {
                        App.Msg("当前诊疗护理组已经存在相同的账户了!");
                    }
                }
            }
        }

        private void lvAccount_RightToLeftLayoutChanged(object sender, EventArgs e)
        {
             if (lvAccount.SelectedItems != null)
            {
                currAccount = (Class_Account)lvAccount.SelectedItems[0].Tag;
            }
        }







  


    }
}