using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class ucQualityFedback : UserControl
    {
        string type = "";
        public ucQualityFedback()
        {
            InitializeComponent();
        }

        public ucQualityFedback(string strType)
        {
            InitializeComponent();
            type = strType;
        }

        private void ucQualityFedback_Load(object sender, EventArgs e)
        {
            DataShow();
        }


        private void DataShow()
        {
            //查出医生反馈信息
            string strSql = "select a.id,a.PATIENT_ID,a.PID 住院号,a.PATIENT_NAME 患者姓名,b.sick_bed_no 床号,CONTENT 通知内容,RECEIVE_USER_ID 接收人,RECEIVE_USER_NAME 发送人," +
                            " SEND_TIME 通知发送时间,FEEDBACK_TIME 医生反馈时间" +
                            " from T_AMENDMENTS_INFO a inner join t_in_patient b on a.patient_id=b.id where STATE_FLAG=2 and a.type='" + type + "'";  //反馈到权限，不反馈到某一人
            DataSet ds = App.GetDataSet(strSql);
            if (ds != null)
            {                
                dgvNotice.Columns.Clear();
                dgvNotice.DataSource = ds.Tables[0].DefaultView;

                dgvNotice.Columns["id"].Visible = false;
                dgvNotice.Columns["PATIENT_ID"].Visible = false;

                DataGridViewButtonColumn btn_1 = new DataGridViewButtonColumn();
                btn_1.Name = "colBtn_1";
                btn_1.HeaderText = "详情";
                btn_1.DefaultCellStyle.NullValue = "查看";
                dgvNotice.Columns.Add(btn_1);

            }   
        }

        private void dgvNotice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //查看按钮
                if (dgvNotice.Columns[e.ColumnIndex].Name == "colBtn_1")
                {
                    frmDocView frm = new frmDocView(dgvNotice.Rows[e.RowIndex].Cells["PATIENT_ID"].Value.ToString(), type, dgvNotice.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    frm.Refresh += new frmDocView.RefEventHandler(DataShow);
                    frm.ShowDialog();                    
                }
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DataShow();
        }
    }
}
