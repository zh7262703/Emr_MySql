using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BASE_DATA.KBS
{
    public partial class ucKBS : UserControl
    {
        public ucKBS()
        {
            InitializeComponent();

            frmKBSCommonSection frmKBSSEC = new frmKBSCommonSection();
            this.tabControlPanel1.Controls.Add(frmKBSSEC);
            frmKBSSEC.Dock = DockStyle.Fill;

            frmKBSCommon frmKBS = new frmKBSCommon();
            this.tabControlPanel2.Controls.Add(frmKBS);
            frmKBS.Dock = DockStyle.Fill;
        }
    }
}
