using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class UcAccountAction : UserControl
    {
        public UcAccountAction()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select b.account_name 异动帐号,a.action_type 异动类型,a.action_time 异动时间,a.action_info 异动信息,c.account_name 操作帐号,d.user_name 操作人 " +
                        "from t_account_action a " +
                        "inner join t_account b on a.account_id=b.account_id " +
                        "inner join t_account c on a.operater_account_id=c.account_id " +
                        "inner join t_userinfo d on a.operater_id = d.user_id " +
                        "where 1=1 ";

            if (txtAccount.Text != "")//异动帐号
            {
                sql += " and b.account_name like '%" + txtAccount.Text + "%'";
            }
            if (txtOperAccount.Text != "")//操作帐号
            {
                sql += " and c.account_name like '%" + txtOperAccount.Text + "%'";
            }
            if (txtOperUser.Text != "")//操作人
            {
                sql += " and d.user_name like '%" + txtOperUser.Text + "%'";
            }
            if (cbxTime.Checked)//按时间查询
            {
                sql += " and to_char(a.action_time,'yyyy-MM-dd') between '" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "' and '" + dtpEndTime.Value.ToString("yyyy-MM-dd") + "'";
            }

            sql += " order by b.account_name,a.action_time desc";

            ucGridviewX1.DataBd(sql, "异动帐号", "", "");
        }

        private void cbxTime_CheckedChanged(object sender, EventArgs e)
        {

            if (cbxTime.Checked)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }

        private void UcAccountAction_Load(object sender, EventArgs e)
        {
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.ReadOnly = true;
        }

    }
}
