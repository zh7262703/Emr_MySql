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

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmUpdate_InArea_Time : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatientInfo;
        public frmUpdate_InArea_Time()
        {
            InitializeComponent();
        }
        public frmUpdate_InArea_Time(InPatientInfo inPatient)
        {
            InitializeComponent();
            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdate_InArea_Time_Load(object sender, EventArgs e)
        {
            this.lblPid.Text = inPatientInfo.PId;
            this.lblUserName.Text = inPatientInfo.Patient_Name;
            this.lblAge.Text = inPatientInfo.Age.ToString() + inPatientInfo.Age_unit;
            string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
            this.lblSex.Text = sex;
            this.lblSectionName.Text = inPatientInfo.Section_Name;
            this.lblCurentArea.Text = inPatientInfo.Sick_Area_Name;
            this.lblInHospital_Time.Text =string.Format("{0:g}",inPatientInfo.In_Time);
            this.lblBed_Id.Text = inPatientInfo.Sick_Bed_Name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ddtpUptArea_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") != string.Empty)
            {
                if (ddtpUptArea_Time.Value.Date >Convert.ToDateTime(inPatientInfo.Birthday))
                {
                    string sql_UptInArea_Time = " update t_in_patient set in_time=to_timestamp('" + ddtpUptArea_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                                                "'yyyy-mm-dd hh24:mi:ss') where id =" + inPatientInfo.Id + " ";                    
                    int count = App.ExecuteSQL(sql_UptInArea_Time);
                    if (count > 0)
                    {
                        //删除体温单的入院事件
                        App.ExecuteSQL("delete from T_VITAL_SIGNS t where t.describe like '%入院%' and t.patient_id=" + inPatientInfo.Id + "");
                        

                        DataInit.isInAreaSucceed = true;
                        inPatientInfo.In_Time = ddtpUptArea_Time.Value;
                        this.Close();
                    }
                }
                else
                {
                    App.Msg("入区时间必须大于病人的出生时间！！！");
                }
            }

        }

    }
}