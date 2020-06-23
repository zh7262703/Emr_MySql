using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.Element;
using System.IO;

namespace Base_Function.BLL_FOLLOW.DispalayList
{
    public partial class ucFollowCancel : UserControl
    {
        private string selectedId = "";  //选中的病人
        private string selectedSid = "";    //选中的方案
        public ucFollowCancel()
        {
            InitializeComponent();
            IniState();
            DispalayTable();
        }
        /// <summary>
        /// 
        /// </summary>
        public void IniState()
        {
            string temp = "select * from T_FOLLOW_CANCEL_REASON";
            DataSet dsTemp = App.GetDataSet(temp);
            if(dsTemp!=null)
                if (dsTemp.Tables[0].Rows.Count != 0)
                {
                    try
                    {
                        DataRow Row = dsTemp.Tables[0].NewRow();
                        Row[0] = 0;
                        Row[1] = "";
                        dsTemp.Tables[0].Rows.InsertAt(Row, 0);
                        cmbCancelReason.DataSource = dsTemp.Tables[0].DefaultView;
                        cmbCancelReason.DisplayMember = "des";
                        cmbCancelReason.ValueMember = "id";
                    }
                    catch (Exception ex)
                    {
                        App.MsgErr(ex.Message);
                    }
                }
        }
        /// <summary>
        /// 获取相关IDS
        /// </summary>
        /// <returns></returns>
        public string GetRelatedIds()
        {
            string ReturnStr = "";
            DataSet desDs=null;
            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                string User_SickArea_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                string qurySickArea = "select * from t_follow_info where exec_sickarea='" + User_SickArea_Id + "' or exec_sickarea like '%," + User_SickArea_Id + ",%' or exec_sickarea like '," + User_SickArea_Id + "%' or exec_sickarea like '" + User_SickArea_Id + ",%' or exec_sickarea='0'";
                desDs = App.GetDataSet(qurySickArea);
            }
            if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                string User_Section_Id = App.UserAccount.CurrentSelectRole.Section_Id;
                string qurySection = "select * from t_follow_info where exec_sections='" + User_Section_Id + "' or exec_sections like '%," + User_Section_Id + ",%' or exec_sections like '," + User_Section_Id + "%' or exec_sections like '" + User_Section_Id + ",%' or exec_sections='0'";
                desDs = App.GetDataSet(qurySection);
            }
            if(desDs!=null)
                if (desDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < desDs.Tables[0].Rows.Count; i++)
                    {
                        if (ReturnStr == "")
                            ReturnStr = desDs.Tables[0].Rows[i]["id"].ToString();
                        else
                            ReturnStr += "," + desDs.Tables[0].Rows[i]["id"].ToString();
                    }
                    return ReturnStr;
                }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        public void DispalayTable()
        {
            string ids = GetRelatedIds();
            string temp = "";
            if (ids != "")
                temp = "select a.patient_id ID,a.solution_id 方案号,c.pid 住院号,c.sick_bed_no 床号,c.patient_name 病人姓名,(case when c.gender_code='1' then '女' else '男' end) 性别,c.age||c.age_unit 年龄,"
            + "c.sick_doctor_name 管床医生,c.leave_time 出院时间,c.section_name 出院科室,(select name from COVER_DIAGNOSE where a.patient_id=patient_id and rownum=1) 诊断,(select t.actual_time from " 
            + "T_FOLLOW_RECORD t where t.patient_id=a.patient_id and t.solution_id =a.solution_id and isfinished=1 and not exists( select 1 from T_FOLLOW_RECORD where t.patient_id=patient_id and solution_id=t.solution_id" 
            + " and isfinished=1 and requested_time>t.requested_time)) 末次随访,b.des 不随访原因,c.now_addres_phone 联系电话,c.now_address 地址 from T_FOLLOW_MANUALPATIENT a JOIN t_follow_cancel_reason b on a.cancel_id=b.id join t_in_patient c on a.patient_id=c.id and a.solution_id in (" + ids + ")";
            else
                temp = "select a.patient_id ID,a.solution_id 方案号,c.pid 住院号,c.sick_bed_no 床号,c.patient_name 病人姓名,(case when c.gender_code='1' then '女' else '男' end) 性别,c.age||c.age_unit 年龄,"
            + "c.sick_doctor_name 管床医生,c.leave_time 出院时间,c.section_name 出院科室,(select name from COVER_DIAGNOSE where a.patient_id=patient_id and rownum=1) 诊断,(select t.actual_time from "
            + "T_FOLLOW_RECORD t where t.patient_id=a.patient_id and t.solution_id =a.solution_id and isfinished=1 and not exists( select 1 from T_FOLLOW_RECORD where t.patient_id=patient_id and solution_id=t.solution_id"
            + " and isfinished=1 and requested_time>t.requested_time)) 末次随访,b.des 不随访原因,c.now_addres_phone 联系电话,c.now_address 地址 from T_FOLLOW_MANUALPATIENT a JOIN t_follow_cancel_reason b on a.cancel_id=b.id join t_in_patient c on a.patient_id=c.id";
            temp = FilterStr(temp);
            DataSet dsTemp = App.GetDataSet(temp);
            if (dsTemp != null)
                if (dsTemp.Tables[0].Rows.Count != 0)
                {
                    dgvPatients.DataSource = dsTemp.Tables[0].DefaultView;
                    dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                    dgvPatients.DataSource = null;
            
        }
        public string FilterStr(string temp)
        {
            if (txtPatientName.Text != "")
                temp += " and c.patient_name ='" + txtPatientName.Text + "'";
            if (cmbCancelReason.Text != "")
                temp += " and a.cancel_id=" + cmbCancelReason.SelectedValue.ToString() + "";
            return temp;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DispalayTable();
        }

        private void 病人基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                frmFollowPatientBaseInfo info = new frmFollowPatientBaseInfo(selectedId);
                info.ShowDialog();
            }
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedId = dgvPatients.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                selectedSid = dgvPatients.Rows[e.RowIndex].Cells["方案号"].Value.ToString();
            }
            else
            {
                selectedId = "";
                selectedSid = "";
            }
        }

        private void dgvPatients_DoubleClick(object sender, EventArgs e)
        {
            if (selectedId != "" && selectedSid != "")
            {
                frmFollowRecord rd = new frmFollowRecord(selectedId, selectedSid, 1);
                rd.ShowDialog();

            }
        }

        private void 诊断信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                frmPatientDiagnose diag = new frmPatientDiagnose(selectedId);
                diag.ShowDialog();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataToExcel(dgvPatients);
        }
        public void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXCEL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName + ".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 恢复随访ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "" && selectedSid != "")
            {
                frmFollowDieCancel frm = new frmFollowDieCancel(selectedId, selectedSid);
                frm.ShowDialog();
            }
        }

    }
}
