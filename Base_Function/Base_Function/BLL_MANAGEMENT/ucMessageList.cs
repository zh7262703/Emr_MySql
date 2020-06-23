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
                string Sql = "select t.add_time as ����ʱ��," +
                           "t.receive_user_name  as ������," +
                           "t.patient_name  as ��������," +
                           "t.pid           as ����ID," +
                           "t.in_time       as ��Ժʱ��," +
                           "t.title         as ����," +
                           "t.content       as ����," +
                           "t.operator_user as ������," +
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
                App.Msg("��ѯʧ�ܣ�ԭ��"+ex.Message);
            }
        }
    }
}
