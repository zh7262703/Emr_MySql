using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmHangBed : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatientInfo;
        public frmHangBed()
        {
            InitializeComponent();
        }
        public frmHangBed(InPatientInfo inPatient)
        {
            InitializeComponent();
            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
            cbxHang_Bed.SelectedIndex = 0;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
              {
	              if (cbxHang_Bed.SelectedIndex != 0)
                    {
                        string Bed_State = this.cbxHang_Bed.Text;
                        string UpdateBed_State = string.Empty;
                        if (Bed_State != string.Empty)
                        {
                            string state = string.Empty;
                            if (Bed_State.Equals("挂床"))
                            {
                                state = "1";
                                //UpdateBed_State = "update t_sickbedinfo set state=74 where bed_id=" + inPatientInfo.Sick_Bed_Id + "";
                            }
                            else
                            {
                                state = "0";
                                //UpdateBed_State = "update t_sickbedinfo set state=75 where bed_id=" + inPatientInfo.Sick_Bed_Id + "";
                            }
                            string Sql_Update_State = " update t_in_patient set state='" + state + "' " +
                                                      " where id =" + inPatientInfo.Id + "";
                            //if (state == "1")
                            //{
                            //    string[] arr = new string[2];
                            //    arr[0] = Sql_Update_State;
                            //    arr[1] = UpdateBed_State;
                            //    App.ExecuteBatch(arr);
                            //}
                            //else
                            //{
                            int count = 0;
                            count = App.ExecuteSQL(Sql_Update_State);
                            //}
                            if (count > 0)
                            {
                                DataInit.isInAreaSucceed = true;
                                inPatientInfo.State = state;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        App.Msg("请您选择病人的状态！");
                    }
              }
              catch (System.Exception ex)
              {
              	
              }
        }

        private void frmHangBed_Load(object sender, EventArgs e)
        {
            if (inPatientInfo!=null)
            {
                this.lblPid.Text = inPatientInfo.PId;
                this.lblUserName.Text = inPatientInfo.Patient_Name;
                this.lblAge.Text = inPatientInfo.Age.ToString() + inPatientInfo.Age_unit;
                string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
                this.lblSex.Text = sex;
                this.lblCurentArea.Text = inPatientInfo.Sick_Area_Name;
                this.lblBed_Id.Text = inPatientInfo.Sick_Bed_Name;
                this.lblSectionName.Text = inPatientInfo.Section_Name;
                this.lblInHospital_Time.Text =string.Format("{0:g}",inPatientInfo.In_Time);
             }
        }

    }
}