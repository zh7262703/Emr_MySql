using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE.BINGANCODE
{
    public partial class FrmHours : DevComponents.DotNetBar.Office2007Form
    {
        public FrmHours()
        {
            InitializeComponent();
            this.Hours = 24;
            this.numericUpDown1.DataBindings.Add(new Binding("Value", this, "Hours"));
        }

        public int Hours { get; set; }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.Hours <= 0)
            {
                Bifrost.App.Msg("请填写有效小时数！");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
