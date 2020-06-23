using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    public partial class frmHelp:DevComponents.DotNetBar.Office2007Form 
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            try
            {
                string url = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite1/XTBZ/standardmain.html";
                Uri ur = new Uri(url);
                webBrowser1.Url = ur;
            }
            catch
            {

            }
        }
    }
}