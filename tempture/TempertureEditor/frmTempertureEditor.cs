using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using TempertureEditor.Controls;
using System.IO;
using TempertureEditor.Element;
using Bifrost;

namespace TempertureEditor
{
    public partial class frmTempertureEditor : Form
    {
        private ucTempertureEditor tempertureEditor;
        public frmTempertureEditor()
        {
            InitializeComponent();

            tempertureEditor = new ucTempertureEditor();
            tempertureEditor.Dock = DockStyle.Fill;
            this.Controls.Add(tempertureEditor);
        }
    }
}
