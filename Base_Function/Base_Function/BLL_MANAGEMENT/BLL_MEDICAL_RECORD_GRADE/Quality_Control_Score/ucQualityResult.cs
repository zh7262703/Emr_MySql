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
    public partial class ucQualityResult : UserControl
    {
        public ucQualityResult()
        {
            InitializeComponent();
        }

        private void ucQualityResult_Load(object sender, EventArgs e)
        {
            cmbGrade.SelectedIndex = 0;            
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            dgvPatient.DataSource = null;
            string strSql = "select a.id,a.pid 住院号,a.inhospital_count 住院次数,a.patient_name 患者姓名, a.section_name 科室,a.sick_bed_no 床号,to_char(a.in_time, 'yyyy-mm-dd') 入院时间,"+
                            "to_char(a.die_time, 'yyyy-mm-dd') 出院时间,b.OPERATOR_USER_NAME 评分人,b.score 病历得分," +
                            "Case WHEN b.doc_level=0 THEN '甲' WHEN b.doc_level=1 THEN '乙' else  '丙' END 病历级别,b.content from t_in_patient a inner join T_DEDUCT_SUMMARY b "+
                            "on a.id=b.patient_id where b.STATE='M' and a.SICK_DOCTOR_ID='"+App.UserAccount.UserInfo.User_id.ToString()+"' and ";

            //选中住院号查询则只有住院号一个查询条件
            if (chkPid.Checked)
            {
                strSql += " a.pid='" + txtPid.Text.Trim() + "'";
            }
            else
            {
                //入院时间           
                strSql += " to_char(a.in_time,'yyyy-MM-DD')>='" + dtpInTime1.Value.ToString("yyyy-MM-dd") + "' and to_char(a.in_time,'yyyy-MM-DD')<='" +
                            dtpIntime2.Value.ToString("yyyy-MM-dd") + "'";

                //评分等级
                if (cmbGrade.SelectedIndex.ToString() == "1")//甲
                {
                    strSql += "and b.doc_level='0'";
                }
                else if (cmbGrade.SelectedIndex.ToString() == "2")//乙
                {
                    strSql += " and b.doc_level='1'";
                }
                else if (cmbGrade.SelectedIndex.ToString() == "3")//丙
                {
                    strSql += " and b.doc_level='2'";
                }
            }

            DataSet ds = App.GetDataSet(strSql);
            if (ds != null)
            {
                dgvPatient.DataSource = ds.Tables[0].DefaultView;
                dgvPatient.Columns["content"].Visible = false;
                dgvPatient.Columns["id"].Visible = false;
                dgvPatient.DataSource = ds.Tables[0].DefaultView;
            }
        }

        /// <summary>
        /// 双击数据显示评分结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >-1&&e.ColumnIndex>-1)
            //{
            //    frmScoreResults frm = new frmScoreResults(dgvPatient.Rows[e.RowIndex].Cells["id"].Value.ToString(), dgvPatient.Rows[e.RowIndex].Cells["住院号"].Value.ToString(), 
            //                dgvPatient.Rows[e.RowIndex].Cells["患者姓名"].Value.ToString(),dgvPatient.Rows[e.RowIndex].Cells["评分人"].Value.ToString(), 
            //                dgvPatient.Rows[e.RowIndex].Cells["病历得分"].Value.ToString(), dgvPatient.Rows[e.RowIndex].Cells["病历级别"].Value.ToString(),
            //                dgvPatient.Rows[e.RowIndex].Cells["content"].Value.ToString());
            //    frm.ShowDialog();
            //}
        }

        private void chkPid_Click(object sender, EventArgs e)
        {
            if (chkPid.Checked)
                txtPid.Enabled = true;
            else
                txtPid.Enabled = false;
        }


    }
}
