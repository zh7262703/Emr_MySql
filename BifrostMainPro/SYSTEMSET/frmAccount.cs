using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LeadronTest.SYSTEMSET
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 进行保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {

        }
    }
}