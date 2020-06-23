using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Base_Function.BASE_DATA
{
    public partial class FrmPOPForm : Office2007Form
    {
        public FrmPOPForm()
        {
            InitializeComponent();
        }

        public FrmPOPForm(Control uc)
        {
            InitializeComponent();

            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }
    }
}
