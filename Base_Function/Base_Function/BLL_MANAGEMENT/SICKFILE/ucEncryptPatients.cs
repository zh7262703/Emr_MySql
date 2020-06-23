using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucEncryptPatients : UserControl
    {
        public ucEncryptPatients()
        {
            InitializeComponent();
        }

        private List<string> sqls = new List<string>();

        private void ucEncryptPatients_Load(object sender, EventArgs e)
        {
            this.dtpInStart.Enabled = false;
            this.dtpInEnd.Enabled = false;

            this.cboEntryptLevel.SelectedIndex = 0;
            this.cboEntryPtlevSet.SelectedIndex = 0;

            InitDept();
        }

        /// <summary>
        /// 初始化科室下拉列表
        /// </summary>
        private void InitDept()
        {
            try
            {
                string sql_Section = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
                                        inner join t_section_area b on a.sid=b.sid
                                        group  by a.shid,a.sid,a.section_code,a.section_name
                                        order by a.shid,to_number(a.section_code)";//查询科室

                DataSet ds_InSection = new DataSet();

                ds_InSection = App.GetDataSet(sql_Section);
                //插入默认选项（请选择）
                if (ds_InSection != null)
                {
                    DataRow dr = ds_InSection.Tables[0].NewRow();
                    dr["sid"] = 0;
                    dr["section_name"] = "-请选择-";
                    ds_InSection.Tables[0].Rows.InsertAt(dr, 0);

                    //DataRow dr1 = ds_InSection.Tables[0].NewRow();
                    //dr1["sid"] = 1;
                    //dr1["section_name"] = "全院";
                    //ds_InSection.Tables[0].Rows.InsertAt(dr1, 1);
                }
                cboDept.DataSource = ds_InSection.Tables[0];
                cboDept.DisplayMember = "section_name";
                cboDept.ValueMember = "sid";
            }
            catch { }
        }



        private void txtSEC_DIRE_NAME_KeyUp(object sender, KeyEventArgs e)
        {
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            //txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            // string order = " order by case when substr(shortcut_code,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select distinct a.user_num 工号,a.user_name||','||a.user_id 用户信息 from t_userinfo a"
                                                + " inner join t_account_user b on a.user_id=b.user_id"
                                                + " inner join t_account c on b.account_id=c.account_id"
                                                + " inner join t_acc_role d on d.account_id=c.account_id"
                                                + " inner join t_role e on e.role_id=d.role_id"
                                                + " where shortcut_code like '%" + text
                                                + "%' AND substr(shortcut_code,0," + length + ")='" + text + "'";
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "工号", "用户信息");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void txtSEC_DIRE_NAME_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["工号"].ToString();
                            this.labUserName.Text = row["用户信息"].ToString().Split(',')[0];
                            this.labID.Text = row["用户信息"].ToString().Split(',')[1];
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Class_User user = new Class_User();
            user.User_num = this.txtSEC_DIRE_NAME.Text;
            user.User_name = this.labUserName.Text;
            user.User_id = this.labID.Text;

            if (!string.IsNullOrEmpty(user.User_num) && !string.IsNullOrEmpty(user.User_name))
            {

                Class_User temp = new Class_User();
                for (int i = 0; i < lvOwernRoles.Items.Count; i++)
                {
                    temp = (Class_User)lvOwernRoles.Items[i].Tag;

                    if (temp.User_id == user.User_id)
                    {
                        App.Msg("此用户已经存在！");
                        return;
                    }
                }

                ListViewItem tempitem = new ListViewItem();
                tempitem.Tag = user;
                tempitem.Text = user.User_num;
                tempitem.ImageIndex = 0;
                tempitem.IndentCount = 0;
                lvOwernRoles.Items.Add(tempitem);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            App.RemoveSelectNodes(lvOwernRoles);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgvDateList.Columns.Clear();

            try
            {
                string sql = @"select t.id,t.pid as 住院号,t.patient_name as 姓名,t.section_name as 科室,t.in_time as 入院日期,t.encryptlevel as 加密等级, 
(select wmsys.wm_concat(u.user_num) from T_SUPER_USER s
inner join t_userinfo u on u.user_id = s.user_id
where s.patient_id = t.id) as 特别用户  
from t_in_patient t
where 1=1";
                string datatimeStart = dtpInStart.Value.ToString("yyyy-MM-dd");
                string datatimeEnd = dtpInEnd.Value.ToString("yyyy-MM-dd");

                if (txtCode.Text.Trim() != "")
                {
                    sql += " and t.pid like '%" + txtCode.Text + "%' ";
                }
                if (cboDept.Text.Trim() != "-请选择-" && cboDept.Text.Trim() != "全院" && cboDept.SelectedIndex != -1)
                {
                    sql += " and t.section_id = '" + cboDept.SelectedValue.ToString() + "'";
                }

                if (chbEnable.Checked)//按时间查询
                {
                    if (datatimeStart != "" && datatimeEnd != "")
                    {
                        sql += " and (to_char(t.in_time,'yyyy-MM-dd') between '" + datatimeStart + "' and '" + datatimeEnd + "')";
                    }
                }

                if (rtnYes.Checked)
                {
                    if (!cboEntryptLevel.Text.Contains("请选择"))
                    {
                        sql += " and t.encryptlevel = " + this.cboEntryptLevel.Text + "";
                    }
                    else
                    {
                        sql += " and t.encryptlevel > 0 ";
                    }
                }
                if (rbnNo.Checked)
                {
                    sql += " and t.encryptlevel = 0";
                }



                DataSet ds = App.GetDataSet(sql);

                this.dgvDateList.DataSource = ds.Tables[0].DefaultView;
                this.dgvDateList.Columns["id"].Visible = false;
                this.dgvDateList.Columns["特别用户"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
                newColumn.HeaderText = "选择";
                dgvDateList.Columns.Insert(0, newColumn);
                dgvDateList.ReadOnly = false;
                for (int i = 0; i < dgvDateList.Columns.Count; i++)
                {
                    if (i == 0)
                        dgvDateList.Columns[i].ReadOnly = false;
                    else
                        dgvDateList.Columns[i].ReadOnly = true;
                }
                //dgvDateList.AutoResizeColumns();
            }
            catch { }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            sqls.Clear();

            string sqlUpdate = "";
            string sqlDelete = "";
            string sqlInsert = "";
            int superId = 0; 
            string pat_id = "";
            Class_User temp;


            for (int i = 0; i < dgvDateList.RowCount; i++)
            {
                if (dgvDateList[0, i].Value != null)
                {
                    if (dgvDateList[0, i].Value.ToString() == "True")
                    {
                        pat_id = dgvDateList["id", i].Value.ToString();

                        sqlUpdate = string.Format("update t_in_patient set encryptlevel = {1} where id = {0}", pat_id, this.cboEntryPtlevSet.Text);
                        sqls.Add(sqlUpdate);
                        sqlDelete = string.Format("delete from t_super_user where patient_id = {0}", pat_id);
                        sqls.Add(sqlDelete);

                        if (this.cboEntryPtlevSet.Text != "0")
                        {
                            for (int j = 0; j < lvOwernRoles.Items.Count; j++)
                            {
                                if (superId >= App.GenId("t_super_user", "id"))
                                {
                                    superId = superId + 1;
                                }
                                else
                                {
                                    superId = App.GenId("t_super_user", "id");
                                }
                                temp = (Class_User)lvOwernRoles.Items[j].Tag;

                                sqlInsert = string.Format("insert into t_super_user(id,patient_id,user_id) values ({0},{1},{2})", superId, pat_id, temp.User_id);
                                sqls.Add(sqlInsert);
                            }
                        }
                        
                    }
                }
            }

            if (sqls.Count == 0)
            {
                App.Msg("请勾选患者后再执行此操作！");
                return;
            }

            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                App.Msg("操作已成功");
                btnQuery_Click(sender, e);
            }
            else
            {
                App.Msg("操作失败！"); 
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void dgvDateList_Click(object sender, EventArgs e)
        {
            try
            {
                lvOwernRoles.Items.Clear();
                if (this.dgvDateList.Rows.Count >= 0)
                {
                    int level = Convert.ToInt32(this.dgvDateList["加密等级", this.dgvDateList.CurrentRow.Index].Value);
                    string pat_id = this.dgvDateList["id", this.dgvDateList.CurrentRow.Index].Value.ToString();
                    this.cboEntryPtlevSet.SelectedIndex = level;
                    this.txtSEC_DIRE_NAME.Text = "";
                    this.labUserName.Text = "";

                    Class_User[] users = GetDirectionary(pat_id);

                    for (int i = 0; i < users.Length; i++)
                    {
                        ListViewItem tempitem = new ListViewItem();
                        tempitem.Tag = users[i];
                        tempitem.Text = users[i].User_num;
                        tempitem.ImageIndex = 0;
                        tempitem.IndentCount = 0;
                        lvOwernRoles.Items.Add(tempitem);
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 实例化查询用户信息
        /// </summary>
        /// <returns></returns>
        private Class_User[] GetDirectionary(string pat_id)
        {
            string sql = string.Format(@"select u.user_id,u.user_num,u.user_name from t_super_user s
inner join t_userinfo u on u.user_id = s.user_id
where patient_id = {0}", pat_id);
            DataSet tempds = App.GetDataSet(sql);

            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_User[] Directionary = new Class_User[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_User();
                        Directionary[i].User_id = tempds.Tables[0].Rows[i]["user_id"].ToString();
                        Directionary[i].User_num = tempds.Tables[0].Rows[i]["user_num"].ToString();
                        Directionary[i].User_name = tempds.Tables[0].Rows[i]["user_name"].ToString();
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

        private void chbEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnable.Checked)
            {
                this.dtpInStart.Enabled = true;
                this.dtpInEnd.Enabled = true;
            }
            else
            {
                this.dtpInStart.Enabled = false;
                this.dtpInEnd.Enabled = false;
            }
        }


    }
}
