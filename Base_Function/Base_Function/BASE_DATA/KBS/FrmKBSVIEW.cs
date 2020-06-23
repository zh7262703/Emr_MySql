using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TextEditor;

namespace Base_Function.BASE_DATA.KBS
{
    public partial class FrmKBSVIEW : Office2007Form
    {

        public FrmKBSVIEW()
        {
            InitializeComponent();
        }

        public FrmKBSVIEW(frmText ucText)
        {
            InitializeComponent();

            frmKBSCommonSectionVIEW frmKBSSEC = new frmKBSCommonSectionVIEW(ucText);
            this.Controls.Add(frmKBSSEC);
            frmKBSSEC.Dock = DockStyle.Fill;
        }

        public FrmKBSVIEW(ZYTextInput inputText)
        {
            InitializeComponent();

            frmKBSCommonSectionVIEW frmKBSSEC = new frmKBSCommonSectionVIEW(inputText);
            this.Controls.Add(frmKBSSEC);
            frmKBSSEC.Dock = DockStyle.Fill;
        }


    }
}
