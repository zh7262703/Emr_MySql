using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Remoting服务端
{
    public partial class frmMessageShow : Form
    {
        public frmMessageShow()
        {
            InitializeComponent();
        }

        public void ini(string errmsg)
        {
            this.lblMessage.Text = errmsg;
            this.Refresh();
        }

        private void frmMessageShow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
