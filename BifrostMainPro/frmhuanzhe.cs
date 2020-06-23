using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UNITDATASET
{
    public partial class frmhuanzhe : Form
    {
        public frmhuanzhe()
        {
            InitializeComponent();
        }

        private void frmhuanzhe_Load(object sender, EventArgs e)
        {
           // WebReference.Service f = new UNITDATASET.WebReference.Service();
           // f.ExecuteSQL("select *from kjdfjksdh");            
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void treeView3_MouseDown(object sender, MouseEventArgs e)
        {
            treeView3.SelectedNode = treeView3.GetNodeAt(e.X, e.Y);
        }

   
    }
}