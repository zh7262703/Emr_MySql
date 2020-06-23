using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.Element;

namespace Base_Function.BLL_FOLLOW.DispalayList
{
    public partial class ucTodayFollowList : UserControl
    {
        private string PName = "";
        private string HospitalId = "";
        private string DoctorId = "";
        private string SectionId = "";
        private string Sid = "";
        Class_FollowInfo[] myInfo;
        public ucTodayFollowList()
        {
            InitializeComponent();
            IniSection();
            IniFollowInfo();
        }

        /// <summary>
        /// ��ʼ������
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
        /// ��ʼ����÷���
        /// </summary>
        public void IniFollowInfo()
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
            myInfo = GetInfo(desDs);
            if (myInfo != null&&myInfo.Length!=0)
            {
                for (int i = 0; i < myInfo.Length; i++)
                    cmbFollowInfo.Items.Add(myInfo[i]);
                cmbFollowInfo.DisplayMember = "Follow_Name";
                cmbFollowInfo.ValueMember = "id";
                cmbFollowInfo.SelectedIndex = 0;
            }
            else
                cmbFollowInfo.DataSource = null;
        }

        /// <summary>
        /// ʵ��������
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public Class_FollowInfo[] GetInfo(DataSet temp)
        {
            if (temp != null)
                if (temp.Tables[0].Rows.Count != 0)
                {

                    DataTable dt = temp.Tables[0];
                    Class_FollowInfo[] info = new Class_FollowInfo[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        info[i] = new Class_FollowInfo();
                        info[i].Id = dt.Rows[i]["id"].ToString();
                        info[i].Follow_name = dt.Rows[i]["follow_name"].ToString();                        
                        info[i].Section_ids = dt.Rows[i]["section_ids"].ToString();
                        info[i].Icd9codes = dt.Rows[i]["icd9codes"].ToString();
                        info[i].Icd10codes = dt.Rows[i]["icd10codes"].ToString();
                        info[i].Ismaindiag = dt.Rows[i]["ismaindiag"].ToString();
                        info[i].Startingtime = dt.Rows[i]["startingtime"].ToString();
                        info[i].Defaultdays = dt.Rows[i]["defaultdays"].ToString();
                        info[i].Followtype = dt.Rows[i]["followtype"].ToString();
                        info[i].Definefollows = dt.Rows[i]["definefollows"].ToString();
                        info[i].Followtextid = dt.Rows[i]["followtextid"].ToString();
                        info[i].Createtime = dt.Rows[i]["createtime"].ToString();
                        info[i].Isenable = dt.Rows[i]["isenable"].ToString();
                        info[i].Maintain_section = dt.Rows[i]["maintain_section"].ToString();
                        info[i].FinishType = dt.Rows[i]["finishType"].ToString();
                    }
                    return info;
                }
            return null;
        }
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime myTime = App.GetSystemTime();
            string stateTime = myTime.ToShortDateString();
            myTime = myTime.AddDays(1);
            string endTime = myTime.ToShortDateString() ;
            string temp = "select '' ���,c.follow_name ��÷���,a.pid סԺ��,a.id ���˺�,a.patient_name ��������,a.age||a.age_unit ����,a.sick_doctor_id �ܴ�ҽ����,a.sick_doctor_name �ܴ�ҽ��,section_id ���Һ�,section_name ����,(select name from COVER_DIAGNOSE c where c.patient_id=a.id and rownum=1 and c.type='M') ���,(select count(*) from T_FOLLOW_RECORD where patient_id=b.patient_id and solution_id=b.solution_id and isfinished=1) ��ô��� ,d.des ���״̬,a.now_addres_phone �绰,a.now_address ��ַ ,c.id ������ from T_FOLLOW_RECORD b join T_IN_PATIENT a on a.id=b.patient_id join T_FOLLOW_INFO c on b.solution_id=c.id join T_FOLLOW_STATE d on b.state_id=d.id join T_FOLLOW_DOC_ATTACH da on b.id=da.record_id where da.finish_time  between to_date('" + stateTime + "','yyyy-MM-dd') and to_date('" + endTime + "','yyyy-MM-dd') ";
            if (cmbFollowInfo.Text != "")
            {
                Class_FollowInfo info = cmbFollowInfo.SelectedItem as Class_FollowInfo;
                temp += " and b.solution_id=" + info.Id + "";
            }
            if (txtPatientName.Text.Trim() != "")
                temp += " and a.patient_name='"+txtPatientName.Text.Trim()+"'";
            if (txtHospital.Text.Trim() != "")
                temp += " and a.pid like '%" + txtHospital.Text.Trim() + "%'";
            if (DoctorId != "")
                temp += " and a.sick_doctor_id=" + DoctorId + "";
            if (cmbSection.Text != "")
                temp += " and a.section_id =" + cmbSection.SelectedValue.ToString() + "";
            DataSet dsTemp = App.GetDataSet(temp);
            if (dsTemp != null)
                if (dsTemp.Tables[0].Rows.Count != 0)
                {
                    dgvPatients.DataSource = dsTemp.Tables[0].DefaultView;
                    dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPatients.Columns["�ܴ�ҽ����"].Visible = false;
                    dgvPatients.Columns["���Һ�"].Visible = false;
                    dgvPatients.Columns["������"].Visible = false;
                    for (int i = 0; i < dgvPatients.Rows.Count; i++)
                    {
                        dgvPatients.Rows[i].Cells["���"].Value = i + 1;
                    }
                    dgvPatients.ReadOnly = true;
                }
                else
                {
                    dgvPatients.DataSource = null;
                }
            else
                dgvPatients.DataSource = null;

        }
        private string pid="";
        private DataGridViewRow selectrow;
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                pid = dgvPatients.Rows[e.RowIndex].Cells["���˺�"].Value.ToString();
                selectrow = dgvPatients.Rows[e.RowIndex];
            }
            else
            {
                pid = "";
                selectrow = null;
            }
        }

        private void dgvPatients_DoubleClick(object sender, EventArgs e)
        {
            if (pid != "")
            {
                frmFollowRecord frm = new frmFollowRecord(pid,selectrow.Cells["������"].Value.ToString(),1);
                frm.ShowDialog();
            }
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

        private void ������ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pid != "")
            {
                frmFollowPatientBaseInfo frm = new frmFollowPatientBaseInfo(pid);
                frm.ShowDialog();

            }
            
        }

        private void �����ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pid!="")
            {
                frmPatientDiagnose diag = new frmPatientDiagnose(pid);
                diag.ShowDialog();
            }
        }
    }
}
