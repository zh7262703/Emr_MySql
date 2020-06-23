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
namespace Base_Function.BLL_MANAGEMENT.ServerLink
{
    public partial class ucShowServerLinks : UserControl
    {
        public ucShowServerLinks()
        {
            InitializeComponent();
        }

        private void frmShowServerLinks_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedTabIndex = 0;
        }
       
    }
}