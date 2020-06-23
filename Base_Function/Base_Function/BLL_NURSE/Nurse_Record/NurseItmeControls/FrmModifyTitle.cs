using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class FrmModifyTitle : DevComponents.DotNetBar.Office2007Form
    {
        public string tName = "";
        public bool flag = false;
        public FrmModifyTitle()
        {
            InitializeComponent();
        }

        public FrmModifyTitle(string titleName)
        {
            InitializeComponent();
            tName = titleName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmModifyTitle_Load(object sender, EventArgs e)
        {
            txtTitleName.Focus();
            txtTitleName.Text = tName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tName = txtTitleName.Text;
            flag = true;
            this.Close();
        }

        private void txtTitleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}