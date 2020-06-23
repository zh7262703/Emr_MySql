using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LeadronTest
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            Leadron.App.Ini();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Leadron.SYSTEMSET.frmTextRightSet f = new Leadron.SYSTEMSET.frmTextRightSet("177044");           
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if (Leadron.App.UpLoadFtp(openFileDialog1.FileName, "test", "D","123456"))
            //    {
            //        Leadron.App.Msg("操作已经成功！");
            //    }
            //}
            //Leadron.App.isHaveFtpDir(@"ftp://192.168.200.44/住院", "newdoc", "newdoc");
            //string sss = "";
            //string pth = Leadron.App.SysPath;
            //DirectoryInfo Dir = new DirectoryInfo(pth);
            //foreach (FileInfo tfile in Dir.GetFiles())
            //{
            //    sss = tfile.ToString();
            //}
            Leadron.HisInstance.frmYZ ff = new Leadron.HisInstance.frmYZ();
            Leadron.App.FormStytleSet(ff, false);
            ff.ShowDialog();
        }
    }
}