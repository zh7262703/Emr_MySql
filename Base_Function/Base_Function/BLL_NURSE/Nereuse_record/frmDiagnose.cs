using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nereuse_record
{
    public partial class frmDiagnose : DevComponents.DotNetBar.Office2007Form
    {
        private int Patient_Id;
        private string Diagnose = "";
        public frmDiagnose()
        {
            InitializeComponent();
        }
        public frmDiagnose(int patient_Id,string diagnose)
        {
            InitializeComponent();
            Patient_Id = patient_Id;
            if (diagnose != "")
            {
                Diagnose = diagnose;
                txtDiagnose.Text = Diagnose;
            }
            else
            {
                string select_Diagnose = "select diagnose_name from t_nurse_record  where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + patient_Id + "";
                txtDiagnose.Text = App.ReadSqlVal(select_Diagnose, 0, "diagnose_name");
            }
        }


        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            //诊断名称
            string diagnose = txtDiagnose.Text.Trim();
            string update_Sql = "update t_nurse_record set diagnose_name='" + diagnose + "' where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + Patient_Id + "";
            int count = 0;
            try
            {
                count = App.ExecuteSQL(update_Sql);
            }
            catch (Exception)
            {
                
               //throw;
            }
            if (count > 0)
            {
                App.Msg("保存成功！");
                this.Close();
            }
        }
    }
}