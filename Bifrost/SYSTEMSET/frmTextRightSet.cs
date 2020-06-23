using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Bifrost.SYSTEMSET
{
    public partial class frmTextRightSet : DevComponents.DotNetBar.Office2007Form
    {
        public static bool flagte = false;
        public frmTextRightSet(string patientId)
        {
            InitializeComponent();
            ucSetTextRight uctextright = new ucSetTextRight(patientId,this);    
            this.Controls.Add(uctextright);
            uctextright.Dock = DockStyle.Fill;
            
        }

        private void frmTextRightSet_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (frmTextRightSet.flagte)
            {
                this.Close();
            }
        }

        //public static void temp(object sender, FormClosingEventArgs e) 
        //{
        //    this.
        //}

    }
}