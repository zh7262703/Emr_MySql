using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    public partial class frmZLGF : DevComponents.DotNetBar.Office2007Form
    {
        public frmZLGF()
        {
            InitializeComponent();
        }

        private void frmZLGF_Load(object sender, EventArgs e)
        {
            try
            {
                string url = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite1/ZLGF/standardmain.html";
                Uri ur = new Uri(url);
                webBrowser1.Url = ur;
            }
            catch
            {
 
            }
        }
    }
}