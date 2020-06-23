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
    /// 运行病例查阅
    /// </summary>
    public partial class UCMedicalRightRun_Search : UserControl
    {
        public delegate void RefEventHandler(object sender, Child_EventArgs e);
        /// <summary>
        /// 浏览文书
        /// </summary>
        public event RefEventHandler browse_Book;
        public UCMedicalRightRun_Search()
        {
            InitializeComponent();
            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("EMR病历查阅"))
            {//手术麻醉和pacs影像调用时不显示查询模块
                groupPanel1.Visible = false;
            }
        }

        private void UCMedicalRightRun_Search_Load(object sender, EventArgs e)
        {
            if (App.OtherSystemHisId != "")
            {
                groupPanel1.Visible = false;//参数his_id有值时,不显示查询 
                
                string sql_patientInfo = "select a.id 编号,a.pid 住院号,a.patient_name 姓名,concat(a.age,a.age_unit) 年龄,(case when a.gender_code=0 then '男' else '女' end) 性别," +
                                    "a.section_id,a.section_name as 科室,a.sick_area_id,a.sick_area_name as 病区 from t_in_patient a where his_id='"+App.OtherSystemHisId+"'";
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
                        App.Msg("提示:没有在电子病历中查询到HIS_ID:" + App.OtherSystemHisId + "的信息!");
                    }
                }
                catch
                {

                }
            }
        }

        private void GetPatientInfo()
        {
            //string sql_patientInfo = "select a.id 编号,a.pid 住院号,a.patient_name 姓名,concat(a.age,a.age_unit) 年龄,(case when a.gender_code=0 then '男' else '女' end) 性别,a.insection_id,a.insection_name 入院科室," +
            //    "(select d.diagnose_name from T_Diagnose_Item d where d.diagnose_type=403 and d.patient_id=a.id and d.id=" +
            //    "(select min(e.id) from T_Diagnose_Item e where e.patient_id=a.id and e.diagnose_type=403)" +
            //    ") as 主诊断,a.sick_doctor_id,a.sick_doctor_name 管床医生 " +
            //    "from t_in_patient a " +
            //    "inner join t_user_section_right b on a.section_id=b.section_id " +
            //    "inner join t_inhospital_action c on a.id=c.pid " +
            //    "where b.user_id=" + App.UserAccount.UserInfo.User_id + " and c.action_type<>'出区' and c.next_id=0 ";

            string sql_patientInfo = "select a.id 编号,a.pid 住院号,a.patient_name 姓名,concat(a.age,a.age_unit) 年龄,(case when a.gender_code=0 then '男' else '女' end) 性别," +
                       "a.section_id,a.section_name as 科室,a.sick_area_id,a.sick_area_name as 病区 from t_in_patient a where a.id>0 ";

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

        private void 医嘱单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = dgvPatientInfo.CurrentRow.Cells["编号"].Value.ToString();
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
                string pid = dgvPatientInfo.CurrentRow.Cells["住院号"].Value.ToString();
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
                string patient_id = dgvPatientInfo.CurrentRow.Cells["编号"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void 病案查阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string patient_id = dgvPatientInfo.CurrentRow.Cells["编号"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);

                inPatient.PatientState = "借阅";//病人状态
                string pageText = "借阅" + " " + inPatient.Patient_Name;

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
