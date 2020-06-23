using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using Bifrost;
using System.Windows.Forms;
using Base_Function.BLL_FOLLOW.Element;

namespace Base_Function.BLL_FOLLOW.DispalayList
{
    public partial class ucFollowDieList : UserControl
    {
        private string DoctorId = "";        
        private string Diag = "";
        private string selectedId = "";
        private string selectedSid = "";
        public ucFollowDieList()
        {
            InitializeComponent();
            InicmbFollowInfo();
            IniSection();
        }
        /// <summary>
        /// ��ʼ�����¼����ط���
        /// </summary>
        public void InicmbFollowInfo()
        {
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
            if (desDs != null&&desDs.Tables[0].Rows.Count!=0)
            {
                cmbFollowInfo.DataSource = desDs.Tables[0].DefaultView;
                cmbFollowInfo.DisplayMember = "Follow_Name";
                cmbFollowInfo.ValueMember = "id";
                cmbFollowInfo.SelectedIndex = 0;
            }
            else
                cmbFollowInfo.DataSource = null;
        }
        /// <summary>
        /// �󶨿���
        /// </summary>
        public void IniSection()
        {
            string secSql = "select a.sid,a.section_name from T_SECTIONINFO a  where a.is_follow_visit='Y'";
            DataSet secTemp = App.GetDataSet(secSql);
            DataRow newRow = secTemp.Tables[0].NewRow();
            newRow[0] = "0";
            newRow[1] = "";
            secTemp.Tables[0].Rows.InsertAt(newRow, 0);
            cmbSection.DataSource = secTemp.Tables[0].DefaultView;
            cmbSection.DisplayMember = "section_name";
            cmbSection.ValueMember = "sid";
            cmbSection.SelectedIndex = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DataBindDieList()
        {
            string temp = "select '' ���,c.id ���˺�,c.pid סԺ��,c.patient_name ��������,c.age||c.age_unit ����,c.sick_doctor_name �ܴ�ҽ��,c.section_name ����,(select name from COVER_DIAGNOSE"
            +" where patient_id=c.id and rownum=1) ��� ,a.update_time ����ʱ��,c.now_addres_phone �绰,c.now_address ��ַ,a.solution_id ������ "
            +" from T_FOLLOW_MANUALPATIENT a  join T_IN_PATIENT c on a.patient_id=c.id where a.cancel_id=(select id from T_FOLLOW_CANCEL_REASON WHERE DES='����')";
            if (txtPatient.Text.Trim()!="")
                temp += " and c.patient_name ='" + txtPatient.Text.Trim() + "'";
            if (txtHospital.Text.Trim()!="")
                temp += " and c.pid like '%" + txtHospital.Text.Trim() + "%'";
            if (DoctorId != "")
                temp += " and c.sick_doctor_id=" + DoctorId + "";
            if (cmbFollowInfo.Text != "")
                temp += " and a.solution_id =" + cmbFollowInfo.SelectedValue.ToString() + "";
            if (cmbSection.Text != "")
                temp += " and c.section_id=" + cmbSection.SelectedValue.ToString() + "";
            if (ckbFollowTime.Checked)
            {
                string starteTime = dtStartTime.Value.ToString("yyyy-MM-dd");
                string endTime = dtEndTime.Value.ToString("yyyy-MM-dd");
                temp += " and a.update_time between to_date('" + starteTime + "','yyyy-MM-dd') and to_date('" + endTime + "','yyyy-MM-dd')";

            }
            if (Diag != "")
            {
                string paId = "";
                string tempSql = "select patient_id from COVER_DIAGNOSE where icd10code is not null and icd10code ='" + Diag + "'";
                DataSet dsTemp = App.GetDataSet(tempSql);
                if (dsTemp != null)
                    if (dsTemp.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
                        {
                            if (paId == "")
                                paId = dsTemp.Tables[0].Rows[i]["patient_id"].ToString();
                            else
                                paId += "," + dsTemp.Tables[0].Rows[i]["patient_id"].ToString();
                        }
                    }
                temp += " and a.patient_id in (" + paId + ")";
            }
            DataSet ds = App.GetDataSet(temp);
            dgvPatients.DataSource = ds.Tables[0].DefaultView;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvPatients.Rows[i].Cells["���"].Value = i + 1;

            }
            dgvPatients.Columns["���˺�"].Visible = false;
            dgvPatients.Columns["������"].Visible = false;

            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataBindDieList();
        }

        private void txtDoctor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDoctor.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDoctor.Text = row["ҽ��"].ToString(); //textName;
                            DoctorId = row["ҽ����"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    DoctorId = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtDoctor_KeyUp(object sender, KeyEventArgs e)
        {
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
                        if (txtDoctor.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select user_id ҽ����,user_name ҽ�� from T_USERINFO"
                                                + " where shortcut_code like '%" + txtDoctor.Text.Trim().ToUpper() + "%' or user_name like '%"+txtDoctor.Text.Trim()+"%'";
                            App.FastCodeCheck(sql_select, txtDoctor, "ҽ��", "ҽ��");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void ȡ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != ""&selectedSid!="")
            {

                frmFollowDieCancel can = new frmFollowDieCancel(selectedId,selectedSid);
                can.ShowDialog();
                
            }
        }
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedId = dgvPatients.Rows[e.RowIndex].Cells["���˺�"].Value.ToString();
                selectedSid = dgvPatients.Rows[e.RowIndex].Cells["������"].Value.ToString();
            }
            else
            {
                selectedId = "";
                selectedSid = "";
            }
        }

        private void ���߻�����ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                frmFollowPatientBaseInfo frm = new frmFollowPatientBaseInfo(selectedId);
                frm.ShowDialog();
            }
        }

        private void dgvPatients_DoubleClick(object sender, EventArgs e)
        {
            if (selectedId != ""&&selectedSid!="")
            {
                frmFollowRecord frm = new frmFollowRecord(selectedId, selectedSid, 1);
                frm.ShowDialog();
            }
        }

        private void �����ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                frmPatientDiagnose diag = new frmPatientDiagnose(selectedId);
                diag.ShowDialog();
            }
        }
    }
}
