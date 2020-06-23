using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    public partial class frmUserInfoAccountSet1 :DevComponents.DotNetBar.Office2007Form
    {
        public frmUserInfoAccountSet1()
        {
            InitializeComponent();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmUserInfoAccountSet1_Load(object sender, EventArgs e)
        {
            ucUserInfo1.setParentTabControl(tabControl1);
            
        }

        private void ucUserInfo1_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemDetelet_Click(object sender, EventArgs e)
        {

        }
    }
}