using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.EMERGENCY
{
    public partial class frmJZ : DevComponents.DotNetBar.Office2007Form
    {
        public string outTime = ""    ;
        public bool flag = false;
        public frmJZ()
        {
            InitializeComponent();
        }

        private void frmJZ_Load(object sender, EventArgs e)
        {
            dtiOut.Value = App.GetSystemTime();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            outTime = dtiOut.Value.ToString("yyyy-MM-dd HH:mm:ss");
            flag = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            outTime = "";
            flag = false;
            this.Close();
        }
    }
}