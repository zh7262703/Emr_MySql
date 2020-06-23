using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor
{
    public partial class frmPrint : Form
    {
        private Comm cm;
        public frmPrint(Comm cm)
        {
            this.cm = cm;
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {           
        }

        private void ucTemperturePrint1_Load(object sender, EventArgs e)
        {

        }
    }
}
