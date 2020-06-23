using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net; 
namespace Bifrost.SYSTEMSET
{
    public partial class frmShowServerLinks : UserControl
    {
        public frmShowServerLinks()
        {
            InitializeComponent();
        }

        private void frmShowServerLinks_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedTabIndex = 0;
        }
       
    }
}