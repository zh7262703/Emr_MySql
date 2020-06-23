using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    public partial class FrmSearchQuality : DevComponents.DotNetBar.Office2007Form
    {
        public FrmSearchQuality()
        {
            InitializeComponent();
        }
        private string id = "";
        public FrmSearchQuality(string patient_id, string name, string inTime, string pid, string sectionName)
        {
            InitializeComponent();
            this.id = patient_id;
            this.lblName.Text = name;
            this.lblInTime.Text = inTime;
            this.lblPid.Text = pid;
            this.lblSection.Text = sectionName;
        }

        private void FrmSearchQuality_Load(object sender, EventArgs e)
        {
            string sql = "select note from t_quality_record where patient_id=" + id;
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    dgvDoc.DataSource = dt;
                    dgvDoc.Columns["note"].HeaderText = "Ã·–—–≈œ¢";
                }
            }

        }
    }
}