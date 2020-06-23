using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE
{
    public partial class ucMedicalMarkControl : UserControl
    {
        public ucMedicalMarkControl()
        {
            InitializeComponent();
            

            this.Load += new EventHandler(ucMedicalMarkControl_Load);
        }

        void ucMedicalMarkControl_Load(object sender, EventArgs e)
        {
            //文书排列
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMark_NEW uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMark_NEW();
            uc.Dock = DockStyle.Fill;
            App.UsControlStyle(uc);
            tabControlPanel1.Controls.Add(uc);

            //规则排列
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMark_NEW_Blues uc1 = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMark_NEW_Blues();
            uc1.Dock = DockStyle.Fill;
            App.UsControlStyle(uc1);
            tabControlPanel2.Controls.Add(uc1);

        }
    }
}
