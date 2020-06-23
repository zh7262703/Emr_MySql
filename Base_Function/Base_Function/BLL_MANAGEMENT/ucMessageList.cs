using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucMessageList : UserControl
    {


        public ucMessageList()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string Sql = "select t.add_time as 发布时间," +
                           "t.receive_user_name  as 接收人," +
                           "t.patient_name  as 患者姓名," +
                           "t.pid           as 患者ID," +
                           "t.in_time       as 入院时间," +
                           "t.title         as 标题," +
                           "t.content       as 内容," +
                           "t.operator_user as 发布人," +
                           "t.id,t.receive_user " +
                           "from t_msg_info t ";

                string conditions = " where t.add_time between to_timestamp('" + dtStart.Value.ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9') and to_timestamp('" + dtEnd.Value.ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9') and t.operator_user like '" + txtCreator.Text + "%'";
                Sql = Sql + conditions;
                DataSet ds = App.GetDataSet(Sql);
                dgvxMessage.DataSource = ds.Tables[0].DefaultView;

                dgvxMessage.Columns["id"].Visible = false;
                dgvxMessage.Columns["receive_user"].Visible = false;
                dgvxMessage.AutoResizeColumns();
            }
            catch(Exception ex)
            {
                App.Msg("查询失败！原因："+ex.Message);
            }
        }
    }
}
