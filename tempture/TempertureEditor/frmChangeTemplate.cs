using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor
{
    public partial class frmChangeTemplate : Form
    {
        private string _selectedTemplatePath;

        public string SelectedTemplatePath
        {
            get
            {
                return _selectedTemplatePath;
            }

            set
            {
                _selectedTemplatePath = value;
            }
        }

        public frmChangeTemplate()
        {
            InitializeComponent();
        }

        private void frmChangeTemplate_Load(object sender, EventArgs e)
        {
            txtTemplatePath.Text = _selectedTemplatePath;
        }

        private void btnTemplateChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Xml Files|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTemplatePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            _selectedTemplatePath = txtTemplatePath.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
    }
}
