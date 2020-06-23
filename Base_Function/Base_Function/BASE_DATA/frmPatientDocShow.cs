using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BASE_DATA
{
    /// <summary>
    /// 病情借阅
    /// </summary>
    public partial class frmPatientDocShow : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo PatientInfo;

        /// <summary>
        /// 病人基本信息
        /// </summary>
        /// <param name="pifo"></param>
        public frmPatientDocShow(InPatientInfo pifo)
        {
            InitializeComponent();
            PatientInfo = pifo;
        }

        private void frmPatientDocShow_Load(object sender, EventArgs e)
        {
            if (PatientInfo != null)
            {
                ucDoctorOperater fq = new ucDoctorOperater(PatientInfo);
                fq.Dock = DockStyle.Fill;
                this.Controls.Add(fq);
                App.FormStytleSet(this, false);
            }
        }
    }
}