using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Windows.Forms.VisualStyles;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class ucReceiveNotice : UserControl
    {
        private string whereSql = "";
        //医生查看“整改通知”界面
        public ucReceiveNotice()
        {
            InitializeComponent();
        }

        public ucReceiveNotice(string patientid)
        {
            InitializeComponent();
            whereSql = " and b.id=" + patientid;
        }

        private void ucReceiveNotice_Load(object sender, EventArgs e)
        {
            dgvNoticeShow();
            this.Refresh();
        }

        public void dgvNoticeShow()
        {
            string strSql = "select a.id,a.PATIENT_ID,a.PID 住院号,a.PATIENT_NAME 患者姓名,b.sick_bed_no 床号,CONTENT 通知内容,OPERATOR_USER_NAME 发送人,SEND_TIME 发送时间,type," +
                               "''质控状态,b.document_state from T_AMENDMENTS_INFO a inner join t_in_patient b on a.patient_id=b.id where RECEIVE_USER_ID='" +
                               App.UserAccount.UserInfo.User_id.ToString() + "' and STATE_FLAG=1 " + whereSql; //
            DataSet ds = App.GetDataSet(strSql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //质控状态S：科室自评；H：院级；E：终末；
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["type"].ToString() == "S")
                            ds.Tables[0].Rows[i]["质控状态"] = "科室自评";
                        else if (ds.Tables[0].Rows[i]["type"].ToString() == "H")
                            ds.Tables[0].Rows[i]["质控状态"] = "院级评分";
                        else if (ds.Tables[0].Rows[i]["type"].ToString() == "E")
                            ds.Tables[0].Rows[i]["质控状态"] = "终末评分";
                    }
                }
               
                dgvNotice.Columns.Clear();
                dgvNotice.DataSource = ds.Tables[0].DefaultView;

                dgvNotice.Columns["id"].Visible = false;
                dgvNotice.Columns["type"].Visible = false;
                dgvNotice.Columns["PATIENT_ID"].Visible = false;
                dgvNotice.Columns["document_state"].Visible = false;

                DataGridViewButtonColumn btn_1 = new DataGridViewButtonColumn();
                btn_1.Name = "colBtn_1";
                btn_1.HeaderText = "详情";
                btn_1.DefaultCellStyle.NullValue = "查看";
                dgvNotice.Columns.Add(btn_1);

                frmDocView.DataGridViewDisableButtonColumn btn_2 = new frmDocView.DataGridViewDisableButtonColumn();
                btn_2.Name = "colBtn_2";
                btn_2.HeaderText = "退回申请";
                btn_2.UseColumnTextForButtonValue = true;
                btn_2.Text = "申请";
                dgvNotice.Columns.Add(btn_2);

                //未归档患者不显示退回按钮                
                for (int i = 0; i < dgvNotice.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvNotice.Rows[i].Cells["document_state"].Value.ToString()))
                    {
                        frmDocView.DataGridViewDisableButtonCell buttonCell1 = (frmDocView.DataGridViewDisableButtonCell)dgvNotice.Rows[i].Cells["colBtn_2"];
                        buttonCell1.Enabled = false;
                    }
                }
                for (int i = 0; i < dgvNotice.Columns.Count; i++) { dgvNotice.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; }
            }
           
        }

        /// <summary>
        /// 点击表格按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNotice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //查看按钮
                if (dgvNotice.Columns[e.ColumnIndex].Name == "colBtn_1")
                {
                    //终末质控的都是已归档病人，需归档退回
                    if (!string.IsNullOrEmpty(dgvNotice.Rows[e.RowIndex].Cells["document_state"].Value.ToString()))
                    {
                        App.Msg("该患者已经归档，请点击申请按钮退回！",this.ParentForm);
                        return;
                    }
                    else
                    {
                        frmDocView frm = new frmDocView(dgvNotice.Rows[e.RowIndex].Cells["PATIENT_ID"].Value.ToString(), "D", dgvNotice.Rows[e.RowIndex].Cells["id"].Value.ToString());
                        frm.Refresh += new frmDocView.RefEventHandler(dgvNoticeShow);
                        frm.ShowDialog();                  
                    }
                }
                //退回申请按钮
                if (dgvNotice.Columns[e.ColumnIndex].Name == "colBtn_2")
                {
                    if (!string.IsNullOrEmpty(dgvNotice.Rows[e.RowIndex].Cells["document_state"].Value.ToString()))
                    {
                        Base_Function.BLL_DOCTOR.Doc_Return.FrmApply_DocReturn_Record frm = new Base_Function.BLL_DOCTOR.Doc_Return.FrmApply_DocReturn_Record(dgvNotice.Rows[e.RowIndex].Cells["住院号"].Value.ToString());
                        frm.ShowDialog();
                    }
                    //else
                    //{
                    //    App.Msg("该患者未归档，不需申请！");
                    //}
                }
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvNoticeShow();
        }

     
    
    }
}
