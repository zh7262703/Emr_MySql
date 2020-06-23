using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmPatientInfo : Office2007Form
    {
        public frmPatientInfo()
        {
            InitializeComponent(); 
        }
        public frmPatientInfo(InPatientInfo inpatient)
        {
            InitializeComponent();
            UcPatientInfo ucPatientInfo = new UcPatientInfo(inpatient);
            this.Controls.Add(ucPatientInfo);
            ucPatientInfo.Dock = DockStyle.Fill;

        }
    }
}