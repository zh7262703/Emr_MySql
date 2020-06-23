using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.HisInStance
{
    public partial class frmPicShow : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">链接</param>
        public frmPicShow(string url)
        {
            InitializeComponent();
            webBrowser1.Url = new Uri(url);            
        }

        private void frmPicShow_Load(object sender, EventArgs e)
        {

        }
    }
}