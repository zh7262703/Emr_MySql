using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR
{
    public partial class Frm30Day : DevComponents.DotNetBar.Office2007Form
    {
        private DataSet ds;
        public Frm30Day()
        {
            InitializeComponent();
        }

        public Frm30Day(DataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        private void Frm30Day_Load(object sender, EventArgs e)
        {
            try
            {
                if (ds != null)
                {
                    dgvInfo.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Frm30Day_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}