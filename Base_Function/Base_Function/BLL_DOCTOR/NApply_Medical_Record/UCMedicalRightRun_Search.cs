using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Bifrost.HisInstance;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    /// <summary>
    /// ���в�������
    /// </summary>
    public partial class UCMedicalRightRun_Search : UserControl
    {
        public delegate void RefEventHandler(object sender, Child_EventArgs e);
        /// <summary>
        /// �������
        /// </summary>
        public event RefEventHandler browse_Book;
        public UCMedicalRightRun_Search()
        {
            InitializeComponent();
            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("EMR��������"))
            {//���������pacsӰ�����ʱ����ʾ��ѯģ��
                groupPanel1.Visible = false;
            }
        }

        private void UCMedicalRightRun_Search_Load(object sender, EventArgs e)
        {
            if (App.OtherSystemHisId != "")
            {
                groupPanel1.Visible = false;//����his_id��ֵʱ,����ʾ��ѯ 
                
                string sql_patientInfo = "select a.id ���,a.pid סԺ��,a.patient_name ����,concat(a.age,a.age_unit) ����,(case when a.gender_code=0 then '��' else 'Ů' end) �Ա�," +
                                    "a.section_id,a.section_name as ����,a.sick_area_id,a.sick_area_name as ���� from t_in_patient a where his_id='"+App.OtherSystemHisId+"'";
                try
                {
                    DataSet ds = App.GetDataSet(sql_patientInfo);

                    if (ds != null)
                    {
                        dgvPatientInfo.DataSource = ds.Tables[0].DefaultView;
                        dgvPatientInfo.Columns["section_id"].Visible = false;
                        dgvPatientInfo.Columns["sick_area_id"].Visible = false;
                        dgvPatientInfo.Columns["sick_doctor_id"].Visible = false;
                    }
                    else
                    {
                        App.Msg("��ʾ:û���ڵ��Ӳ����в�ѯ��HIS_ID:" + App.OtherSystemHisId + "����Ϣ!");
                    }
                }
                catch
                {

                }
            }
        }

        private void GetPatientInfo()
        {
            //string sql_patientInfo = "select a.id ���,a.pid סԺ��,a.patient_name ����,concat(a.age,a.age_unit) ����,(case when a.gender_code=0 then '��' else 'Ů' end) �Ա�,a.insection_id,a.insection_name ��Ժ����," +
            //    "(select d.diagnose_name from T_Diagnose_Item d where d.diagnose_type=403 and d.patient_id=a.id and d.id=" +
            //    "(select min(e.id) from T_Diagnose_Item e where e.patient_id=a.id and e.diagnose_type=403)" +
            //    ") as �����,a.sick_doctor_id,a.sick_doctor_name �ܴ�ҽ�� " +
            //    "from t_in_patient a " +
            //    "inner join t_user_section_right b on a.section_id=b.section_id " +
            //    "inner join t_inhospital_action c on a.id=c.pid " +
            //    "where b.user_id=" + App.UserAccount.UserInfo.User_id + " and c.action_type<>'����' and c.next_id=0 ";

            string sql_patientInfo = "select a.id ���,a.pid סԺ��,a.patient_name ����,concat(a.age,a.age_unit) ����,(case when a.gender_code=0 then '��' else 'Ů' end) �Ա�," +
                       "a.section_id,a.section_name as ����,a.sick_area_id,a.sick_area_name as ���� from t_in_patient a where a.id>0 ";

            if (txtPid.Text != "")
            {
                sql_patientInfo += " and a.pid like '%" + txtPid.Text + "%'";
            }
            if (txtName.Text != "")
            {
                sql_patientInfo += " and patient_name like '%" + txtName.Text + "%'";
            }


            sql_patientInfo += " and rownum<300";

            try
            {
                DataSet ds = App.GetDataSet(sql_patientInfo);

                if (ds != null)
                {                   
                    dgvPatientInfo.DataSource = ds.Tables[0].DefaultView;
                    dgvPatientInfo.Columns["section_id"].Visible = false;
                    dgvPatientInfo.Columns["sick_area_id"].Visible = false;
                    dgvPatientInfo.Columns["sick_doctor_id"].Visible = false;                    
                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetPatientInfo();
        }

        private void ҽ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = dgvPatientInfo.CurrentRow.Cells["���"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                frmYZ fc = new frmYZ(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void lisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = dgvPatientInfo.CurrentRow.Cells["סԺ��"].Value.ToString();
                FrmLis fc = new FrmLis(pid);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void pACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                
                string patient_id = dgvPatientInfo.CurrentRow.Cells["���"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string patient_id = dgvPatientInfo.CurrentRow.Cells["���"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);

                inPatient.PatientState = "����";//����״̬
                string pageText = "����" + " " + inPatient.Patient_Name;

                DataInit.boolAgree = true;
                DataInit.isRightRun = true;
                ucDoctorOperater fq = new ucDoctorOperater(inPatient);
                App.UsControlStyle(fq);
                App.AddNewBusUcControl(fq, pageText);
                //((Form)this.ParentForm).Close();
            }
            catch (Exception ex)
            {
 
            }
        }

        private void txtPid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
