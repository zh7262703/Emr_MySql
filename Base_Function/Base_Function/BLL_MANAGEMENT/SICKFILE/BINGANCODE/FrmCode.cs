using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE.BINGANCODE
{
    public partial class FrmCode : DevComponents.DotNetBar.Office2007Form
    {
        public FrmCode()
        {
            InitializeComponent();
        }
        public FrmCode(string text)
        {
            InitializeComponent();
            this.Text = text;
            this.label1.Text = text + ":";
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.Text.Trim().Length == 0)
            {
                Bifrost.App.Msg("原因不能为空！");
                return;
            }
            this.Reason = this.richTextBox1.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        public string Reason { get; set; }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}