using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Digital_Medical_Treatment
{
    public partial class UcMark :DevComponents.DotNetBar.Office2007Form
    {
        public UcMark()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            foreach (Control con in tableLayoutPanel1.Controls)
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (checkBox1.Checked)
                    {
                        chk.Checked = true;
                    }
                    else
                    {
                        chk.Checked = false;
                    }
                }
            }
        }


    }
}
