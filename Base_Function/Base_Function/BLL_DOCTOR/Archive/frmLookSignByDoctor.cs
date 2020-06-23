using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR.Archive
{
    public partial class frmLookSignByDoctor : DevComponents.DotNetBar.Office2007Form
    {
        public frmLookSignByDoctor()
        {
            InitializeComponent();
        }
        public frmLookSignByDoctor(string Patient_Name)
        {
            InitializeComponent();
           
            ucLookSign uclook = new ucLookSign( false, Patient_Name);
            this.Controls.Add(uclook);
            uclook.Dock = DockStyle.Fill;
        }
    }
}