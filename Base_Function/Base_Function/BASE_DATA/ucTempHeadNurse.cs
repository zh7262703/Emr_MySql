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

    public partial class ucTempHeadNurse : UserControl
    {   
        bool saveflag = false;          //添加修改标示 true 添加 false 修改
        string sick_area_id = "";       //病区ID  
        string acc_role_range_id = "";  //账号和角色关系范围ID
        string headNuser_id = "";       //临时护士长权限ID
        string acc_role_id = "";        //账号和角色关系ID

        public ucTempHeadNurse()
        {
            InitializeComponent();
        }

        private void InitSickArea()
        {
//            string Sql_SickArea = string.Format(@"select a.said,a.sick_area_name,a.sick_area_code,b.sub_hospital_name 
//from t_sickareainfo a 
//inner join T_SUB_HOSPITALINFO b on a.shid=b.shid 
//where ISBELONGTOSECTION='N' and ENABLE_FLAG='Y'
//and a.said in 
//(
//select t.sickarea_id from T_ACC_ROLE_RANGE t
//inner join t_acc_role r on r.id = t.acc_role_id
//where r.account_id = {0} and r.role_id = {1}
//)", App.UserAccount.Account_id, App.UserAccount.CurrentSelectRole.Role_id);


            string Sql_SickArea =  @"select a.said,a.sick_area_name,a.sick_area_code,b.sub_hospital_name 
                                    from t_sickareainfo a 
                                    inner join T_SUB_HOSPITALINFO b on a.shid=b.shid 
                                    where ISBELONGTOSECTION='N' and ENABLE_FLAG='Y'
                                    and a.said in 
                                    (select t.sickarea_id from T_ACC_ROLE_RANGE t
                                    inner join t_acc_role r on r.id = t.acc_role_id                                 
                                    )";

            DataSet ds = App.GetDataSet(Sql_SickArea);
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["said"] = 0;
                dr["sick_area_name"] = "请选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboAreaSelect.DataSource = ds.Tables[0];
                cboAreaSelect.DisplayMember = "sick_area_name";
                cboAreaSelect.ValueMember = "said";
            }
        }

        private void InitUser(string sickArea_id)
        {
            string sql = "select distinct a.user_id,a.user_name,a.user_num,a.gender_code,a.birthday,dc2.name as 职称,dc1.name as 职务,s.section_name,sa.sick_area_name,c.account_id from t_userinfo a " +
                            "inner join t_account_user b on a.user_id=b.user_id " +
                            "inner join t_account c on c.account_id=b.account_id " +
                            "inner join t_acc_role d on c.account_id=d.account_id " +
                            "left join t_data_code dc1 on dc1.id = a.u_position " +
                            "left join t_data_code dc2 on dc2.id = a.u_tech_post " +
                            "left join t_sectioninfo s on s.sid = a.section_id " +
                            "left join t_sickareainfo sa on sa.said = a.sickarea_id " +
                            "inner join t_acc_role_range d1 on d.id=d1.acc_role_id where d1.sickarea_id = " + sickArea_id + " and d.role_id = 225";
            DataSet ds = App.GetDataSet(sql);

            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["user_id"] = 0;
                dr["user_name"] = "请选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboNurseName.DataSource = ds.Tables[0].DefaultView;
                cboNurseName.DisplayMember = "user_name";
                cboNurseName.ValueMember = "user_id";
            }
            
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void refleshData()
        {
            string sql = "select sc.sick_area_name as 病区范围,sc.said as 病区ID,a.user_id as 用户ID,a.user_name as 姓名,a.user_num as 工号, " +
                "(case when a.gender_code = 0 then '男' else '女' end) as 性别,a.birthday as 出生日期,dc2.name as 职称,dc1.name as 职务, " +
                "t.enable,t.enable_start_time as 授权时间,t.enable_end_time as 结束时间,us.user_name as 授权人,ar.id as acc_role_id,t.id as headNuser_id,g.id as 账户角色范围ID from t_tempHeadNuser t " +
                "inner join t_userinfo a on a.user_id = t.user_id " +
                "inner join t_account_user b on a.user_id = b.user_id " +
                "inner join t_account c on c.account_id = b.account_id " +
                "inner join t_acc_role ar on c.account_id = ar.account_id " +
                "inner join t_acc_role_range g on g.acc_role_id = ar.id and g.sickarea_id = t.said " +
                "left join t_sickareainfo sc on sc.said = g.sickarea_id " +
                "left join t_data_code dc1 on dc1.id = a.u_position " +
                "left join t_data_code dc2 on dc2.id = a.u_tech_post " +
                "left join t_userinfo us on us.user_id = t.head_nurse_id " +
                "where t.head_nurse_id = " + App.UserAccount.UserInfo.User_id + " and ar.role_id = 10938189";
                
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
                dataGridViewX1.Columns["病区ID"].Visible = false;
                dataGridViewX1.Columns["用户ID"].Visible = false;
                dataGridViewX1.Columns["enable"].Visible = false;
                dataGridViewX1.Columns["acc_role_id"].Visible = false;
                dataGridViewX1.Columns["headNuser_id"].Visible = false;
                dataGridViewX1.Columns["账户角色范围ID"].Visible = false;
            }

            dataGridViewX1.ReadOnly = true;
        }

        /// <summary>
        /// 数据清空
        /// </summary>
        private void ClearData()
        {
            cboAreaSelect.SelectedIndex = 0;
            try
            {
                cboNurseName.SelectedIndex = 0;
            }
            catch { }
            cboGender.SelectedIndex = 0;

            txtNumber.Text = "";
            rbtnUserful.Checked = true;
            txtZhiCheng.Text = "";
            txtZhiWu.Text = "";
            txtSectionName.Text = "";
            txtAreaName.Text = "";

            dtpValidBegin.Value = DateTime.Now;
            dtpValidEnd.Value = DateTime.Now;
            dtpBirthday.Value = DateTime.Now;
        }

        /// <summary>
        /// 选中行记录
        /// </summary>
        /// <param name="rowindex"></param>
        private void ShowSelectData(int rowindex)
        {
            try
            {
                if (rowindex < 0) return;

                cboAreaSelect.SelectedValue = dataGridViewX1["病区ID", rowindex].Value.ToString();
                cboNurseName.SelectedValue = dataGridViewX1["用户ID", rowindex].Value.ToString();
                sick_area_id = dataGridViewX1["病区ID", rowindex].Value.ToString();
                acc_role_range_id = dataGridViewX1["账户角色范围ID", rowindex].Value.ToString();
                headNuser_id = dataGridViewX1["headNuser_id", rowindex].Value.ToString();

                if (!string.IsNullOrEmpty(dataGridViewX1["授权时间", rowindex].Value.ToString()))
                {
                    dtpValidBegin.Value = Convert.ToDateTime(dataGridViewX1["授权时间", rowindex].Value.ToString());
                }
                else
                {
                    dtpValidBegin.Value = DateTime.Now;
                }

                if (!string.IsNullOrEmpty(dataGridViewX1["结束时间", rowindex].Value.ToString()))
                {
                    dtpValidEnd.Value = Convert.ToDateTime(dataGridViewX1["结束时间", rowindex].Value.ToString());
                }
                else
                {
                    dtpValidEnd.Value = DateTime.Now;
                }

                string Enable = dataGridViewX1["enable", rowindex].Value.ToString();
                if (Enable == "Y")
                {
                    rbtnUserful.Checked = true;
                }
                else
                {
                    rdtnUnUserful.Checked = true;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("信息读取错误!原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 控件状态设置
        /// </summary>
        /// <param name="flag"></param>
        private void EnableSet(bool flag)
        {
            cboAreaSelect.Enabled = flag;
            cboNurseName.Enabled = flag;
            panel4.Enabled = flag;

            btnSave.Enabled = flag;
            btnCancel.Enabled = flag;
            dtpValidBegin.Enabled = flag;
            dtpValidEnd.Enabled = flag;
            dataGridViewX1.Enabled = !flag;

            if (flag)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void frmTempAccout_Load(object sender, EventArgs e)
        {
            InitSickArea();
            //InitUser();

            refleshData();
            ClearData();

            EnableSet(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            saveflag = true;
            EnableSet(true);
            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.cboAreaSelect.SelectedIndex == 0)
            {
                App.Msg("请先选中要修改的数据！");
                return;
            }
            saveflag = false;
            EnableSet(true);
            cboNurseName.Enabled = false;
            cboAreaSelect.Enabled = false;
        }

        /// <summary>
        /// 添加保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();

            string Account_Enable = "Y"; //帐号状态
            //帐号状态
            if (!rbtnUserful.Checked)
            {
                Account_Enable = "N";
            }

            if (this.dtpValidBegin.Value > this.dtpValidEnd.Value)
            {
                App.Msg("授权时间不能大于结束时间");
                return;
            }

            if (saveflag)
            {
                #region 添加操作

                //判断是否已经存在相同账号
                DataSet ds = App.GetDataSet("select * from t_tempheadnuser t where t.user_id = " + this.cboNurseName.SelectedValue + " and t.said = " + this.cboAreaSelect.SelectedValue + " and t.enable = 'Y'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    App.MsgWaring("此账号已有临时护士长权限！");
                    return;
                }

                string arid = App.GenId().ToString();
                string headNuser_id = App.GenId().ToString();

                string tempid = App.ReadSqlVal("select t.id from t_acc_role t where t.account_id = "+txtAcountID.Text+" and t.role_id = 10938189",0,"id");
                if (!string.IsNullOrEmpty(tempid))
                {
                    arid = tempid;
                }
                else
                {
                    string sql_role = "insert into t_acc_role(id,account_id,role_id)values(" +
                                  arid + "," + txtAcountID.Text + ",10938189)"; //临时护士长
                    sqls.Add(sql_role);
                }

                string rang_id = App.ReadSqlVal("select t.id from t_acc_role_range t where t.acc_role_id = "+arid+" and t.sickarea_id = "+cboAreaSelect.SelectedValue+"",0,"id");
                if (string.IsNullOrEmpty(rang_id))
                {
                    string sql_role_range = "insert into t_acc_role_range(acc_role_id,section_id,sickarea_id,isbelongto)values(" +
                                            arid + ",0," + cboAreaSelect.SelectedValue + ",1)";
                    sqls.Add(sql_role_range);
                }
                string sql_head_nurse = "insert into t_tempHeadNuser(id,user_id,head_nurse_id,said,enable,enable_start_time,enable_end_time)values(" + headNuser_id + "," + cboNurseName.SelectedValue + "," + App.UserAccount.UserInfo.User_id + "," + cboAreaSelect.SelectedValue + ",'" + Account_Enable + "',to_timestamp('" + dtpValidBegin.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('" + dtpValidEnd.Value.Date.AddDays(1).AddMilliseconds(-1) + "','syyyy-mm-dd hh24:mi:ss.ff9'))";

                
                sqls.Add(sql_head_nurse);

                #endregion
            }
            else
            {
                #region 修改操作

                string sql_headNurse = "update t_tempheadnuser set enable_start_time = to_timestamp('" + dtpValidBegin.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),enable_end_time = to_timestamp('" + dtpValidEnd.Value.Date.AddDays(1).AddMilliseconds(-1) + "','syyyy-mm-dd hh24:mi:ss.ff9'), enable='" + Account_Enable + "' " +
                                       "where id =" + headNuser_id + "";
                sqls.Add(sql_headNurse);

                #endregion

            }

            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                App.Msg("操作成功！");
                refleshData();

                EnableSet(false);
            }
            else
            {
                App.MsgWaring("操作失败！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            EnableSet(false);
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowSelectData(e.RowIndex);
        }

        /// <summary>
        /// 删除选中的记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            try
            {

                #region 删除账号相关信息
                
                string sql_del_headnuser = "delete from t_tempheadnuser t where t.id = " + headNuser_id + "";

                sqls.Add(sql_del_headnuser);
                #endregion

                if (App.Ask("确定要删除账号：“" + dataGridViewX1["工号", dataGridViewX1.CurrentRow.Index].Value.ToString() +"”的临时护士长记录？"))
                {
                    if (App.ExecuteBatch(sqls.ToArray()) > 0)
                    {
                        App.Msg("操作成功！");
                        refleshData();
                        ClearData();
                    }
                    else
                    {
                        App.MsgWaring("操作未成功！");
                    }
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败！原因：" + ex.Message);
            }

        }

        private void dataGridViewX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewX1.ClearSelection();
                    dataGridViewX1.Rows[e.RowIndex].Selected = true;
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    ShowSelectData(e.RowIndex);
                    //contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void cboNurseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNurseName.SelectedIndex > 0)
            {
                try
                {
                    DataRowView drv = (DataRowView)cboNurseName.SelectedItem; //a.user_id,a.user_name,a.user_num,a.gender_code,a.birthday,dc2.name as 职称,dc1.name as 职务,s.section_name,sa.sick_area_name

                    txtNumber.Text = drv.Row.ItemArray[2].ToString();
                    txtZhiCheng.Text = drv.Row.ItemArray[5].ToString();
                    txtZhiWu.Text = drv.Row.ItemArray[6].ToString();
                    txtSectionName.Text = drv.Row.ItemArray[7].ToString();
                    txtAreaName.Text = drv.Row.ItemArray[8].ToString();
                    txtAcountID.Text = drv.Row.ItemArray[9].ToString();

                    if (drv.Row.ItemArray[3].ToString().Trim() == "0")
                    {
                        cboGender.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;
                    }
                    if (!string.IsNullOrEmpty(drv.Row.ItemArray[4].ToString()))
                    {
                        dtpBirthday.Value = Convert.ToDateTime(drv.Row.ItemArray[4].ToString());
                    }
                }
                catch { }
            }
            else
            {
                cboGender.SelectedIndex = 0;

                txtNumber.Text = "";
                rbtnUserful.Checked = true;
                txtZhiCheng.Text = "";
                txtZhiWu.Text = "";
                txtSectionName.Text = "";
                txtAreaName.Text = "";

                dtpValidBegin.Value = DateTime.Now;
                dtpValidEnd.Value = DateTime.Now;
                dtpBirthday.Value = DateTime.Now;
            }
        }

        private void cboAreaSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAreaSelect.SelectedIndex != -1 && cboAreaSelect.SelectedIndex != 0)
            {
                InitUser(cboAreaSelect.SelectedValue.ToString());
            }
        }

    }
}
