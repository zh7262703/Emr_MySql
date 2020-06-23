using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class ucQuality : UserControl
    {
        string type = "";
        public ucQuality()
        {
            InitializeComponent();
        }

        public ucQuality(string strType)
        {
            InitializeComponent();
            type = strType;
        }

        private void ucQuality_Load(object sender, EventArgs e)
        {
            //评分界面
            ucQualityTest ucQ = new ucQualityTest(type);
            tabControlPanel1.Controls.Add(ucQ);
            App.UsControlStyle(ucQ);
            ucQ.Dock = DockStyle.Fill;
            //医生查看整改通知
            if (type == "D")
            {
                ucReceiveNotice ucR = new ucReceiveNotice();                
                tabControlPanel2.Controls.Add(ucR);
                ucR.Dock = DockStyle.Fill;                
                tabItem2.Text = "整改通知信息";
                ucQualityResult ucQR = new ucQualityResult();
                tabControlPanel3.Controls.Add(ucQR);
                ucQR.Dock = DockStyle.Fill;
                tabItem3.Visible = true;
            }//评分人查看医生反馈界面
            else
            {
                ucQualityFedback ucF = new ucQualityFedback(type);
                tabControlPanel2.Controls.Add(ucF);
                ucF.Dock = DockStyle.Fill;
            }
        }
    }
}
