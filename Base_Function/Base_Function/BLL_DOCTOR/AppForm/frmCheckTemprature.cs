using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using Bifrost;
using Base_Function.BASE_COMMON;
using Base_Function.TEMPERATURES;

namespace Base_Function.BLL_DOCTOR.AppForm
{
    public partial class frmCheckTemprature : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo currentPatient = null;
        public frmCheckTemprature()
        {
            InitializeComponent();
        }

        private void frmCheckTemprature_Load(object sender, EventArgs e)
        {
            try
            {
                //绑定病人列表
                string sql_PatientList = "";
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")     //医生站
                {
                    sql_PatientList = "select distinct a.sick_bed_id,a.id,a.sick_bed_no||'床:'||a.patient_name as name from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_Id and b.next_id=0 where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and b.action_state=4 ";// order by cast(a.sick_bed_id as number)";
                }
                else
                {
                    sql_PatientList = "select distinct a.sick_bed_id,a.id,a.sick_bed_no||'床:'||a.patient_name as name from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_Id and b.next_id=0 where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and b.action_state=4 ";// order by cast(a.sick_bed_id as number)";
                }

                DataSet ds = App.GetDataSet(sql_PatientList);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    dt.DefaultView.Sort = "sick_bed_id";
                    cboPatientName.DisplayMember = "name";
                    cboPatientName.ValueMember = "id";
                    cboPatientName.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cboPatientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlTemprature.Controls.Clear();
            currentPatient = DataInit.GetInpatientInfoByPid(cboPatientName.SelectedValue.ToString());

            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {//护士
                //ucTempraute temper = new ucTempraute(currentPatient);//.PId, currentPatient.Medicare_no, currentPatient.Id.ToString(), currentPatient.Sick_Bed_Name, currentPatient.Patient_Name, currentPatient.Gender_Code, currentPatient.Age + currentPatient.Age_unit, currentPatient.Section_Name, currentPatient.Sick_Area_Name, currentPatient.In_Time.ToString());
                TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
                temper.Dock = DockStyle.Fill;
                pnlTemprature.Controls.Add(temper);
            }
            else
            {//医生
                TempertureEditor.ucTempraute tprint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, false);
                tprint.Dock = DockStyle.Fill;
                pnlTemprature.Controls.Add(tprint);
            }

        }
    }
}