using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_NURSE.First_cases;

namespace Base_Function.BLL_DOCTOR
{
    public partial class ucDIAGNOSIS_CERTIFICATE : UserControl
    {
        private InPatientInfo patient;
        private string AdciceId = "";

        public static string CaseListValue = ""; //诊断值

        public ucDIAGNOSIS_CERTIFICATE()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 诊断证明书
        /// </summary>
        /// <param name="patient">病人</param>
        public ucDIAGNOSIS_CERTIFICATE(InPatientInfo Patient)
        {
            InitializeComponent();
            patient = Patient;
            lblName.Text = patient.Patient_Name;
            if (patient.Gender_Code=="0")
              lblSex.Text = "男";
            else
              lblSex.Text = "女";
            lblAge.Text = patient.Age.ToString() + patient.Age_unit;
            lblSection.Text = patient.Section_Name;
            lblPid.Text = patient.PId;

            DataSet ds = App.GetDataSet("select * from T_DIAGNOSIS_CERTIFICATE where PATIENT_ID=" + patient.Id+ "");                      
            if (ds.Tables[0].Rows.Count > 0)
            {
                AdciceId = ds.Tables[0].Rows[0]["id"].ToString();
                txtAdvice.Text = ds.Tables[0].Rows[0]["ADVICE"].ToString();
                dptCreateTime.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DISPLAY_TIME"].ToString());
            }
            cbxPrientNum.SelectedIndex = 0;
        }

        /// <summary>
        /// 保存诊断说明书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            string Sql = "";
            string Id="";
            string diagnosisCount = "";
            string diagCount = App.ReadSqlVal("select count(*) num from T_DIAGNOSIS_CERTIFICATE where PATIENT_ID=" + patient.Id, 0, "num");
            if (Convert.ToInt32(diagCount) == 0)
            {
                Id = App.GenId("t_diagnosis_certificate", "id").ToString();
                //添加操作
                Sql = "insert into t_diagnosis_certificate(ID,ADVICE,CREATE_ID,PATIENT_ID,CREATE_TIME,DISPLAY_TIME)values(" + Id + ",'" + txtAdvice.Text + "'," + App.UserAccount.UserInfo.User_id + "," + patient.Id + ",sysdate,to_timestamp('" + dptCreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9'))";
            }
            else
            {
                //修改操作
                Sql = "update t_diagnosis_certificate set ADVICE='" + txtAdvice.Text + "',DISPLAY_TIME=to_timestamp('" + dptCreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') where id="+AdciceId+"";
            }

            if (App.ExecuteSQL(Sql) > 0)
            {
                App.Msg("操作已成功！");
                //AdciceId = Id;
            }
            else
            {
                App.MsgErr("操作失败！");                
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint_t_diagnosis_certificate fc = new frmPrint_t_diagnosis_certificate(patient,cbxPrientNum.SelectedIndex+1);
            App.ButtonStytle(fc, false);
            fc.Show();
        }

        private void 插入诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCaselist_P ff = new FrmCaselist_P(patient.Id.ToString());
            App.ButtonStytle(ff, false);
            ff.ShowDialog();
            int startindex = 0;
            if (CaseListValue != "")
            {
                if (txtAdvice.Text.Trim() == "")
                {
                    txtAdvice.Text = txtAdvice.Text + CaseListValue;
                    startindex = txtAdvice.Text.Length-1;
                }
                else
                {
                    string s = txtAdvice.Text.Substring(0, txtAdvice.SelectionStart);
                    string s2 = txtAdvice.Text.Substring(txtAdvice.SelectionStart, txtAdvice.Text.Length - txtAdvice.SelectionStart);
                    
                    txtAdvice.Text = s + CaseListValue;
                    startindex = txtAdvice.Text.Length - 1;
                    txtAdvice.Text=txtAdvice.Text + s2;

                }
                txtAdvice.SelectionStart = startindex;
            }
           
          
        }
    }
}
