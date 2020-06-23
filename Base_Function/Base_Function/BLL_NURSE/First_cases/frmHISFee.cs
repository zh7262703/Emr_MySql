using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class frmHISFee : DevComponents.DotNetBar.Office2007Form
    {
        private DataSet dsHisFee = null;
        public frmHISFee(DataSet ds)
        {
            InitializeComponent();
            dsHisFee = ds;
        }

        private void frmHISFee_Load(object sender, EventArgs e)
        {
            this.dataGridViewX1.DataSource = dsHisFee.Tables[0].DefaultView;
        }
    }
}