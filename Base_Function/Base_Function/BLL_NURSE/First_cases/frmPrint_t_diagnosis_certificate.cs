using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Bifrost;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class frmPrint_t_diagnosis_certificate : Form
    {
        private InPatientInfo patient;
        //打印数量
        private int count=1;

        public frmPrint_t_diagnosis_certificate()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  病人对象
        /// </summary>
        /// <param name="pt">病人对象</param>
        /// <param name="num">打印数量</param>
        public frmPrint_t_diagnosis_certificate(InPatientInfo pt,int num)
        {
            InitializeComponent();
            patient = pt;
            count = num;
        }

        private void frmPrint_t_diagnosis_certificate_Load(object sender, EventArgs e)
        {
            try
            {
                if (count != 2)
                {
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\Report_t_diagnosis_certificate.rdlc";
                }
                else
                {
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\Report_t_diagnosis_certificate2.rdlc";
                }
                this.reportViewer1.LocalReport.DataSources.Clear();
                DataSet ds = App.GetDataSet("select ID,ADVICE,DISPLAY_TIME,a.user_name as Create_name from t_diagnosis_certificate t inner join T_USERINFO a on t.create_id=a.user_id  where t.patient_id=" + patient.Id.ToString() + "");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    App.MsgWaring("请先保存诊断证明书！");
                }

                ReportParameter[] pams = new ReportParameter[5];
                pams[0] = new ReportParameter("Parameter_UserName", patient.Patient_Name);
                if (patient.Gender_Code == "0")
                {
                    pams[1] = new ReportParameter("Parameter_Sex", "男");
                }
                else
                {
                    pams[1] = new ReportParameter("Parameter_Sex", "女");
                }
                pams[2] = new ReportParameter("Parameter_Age", patient.Age.ToString());
                pams[3] = new ReportParameter("Parameter_Section", patient.Section_Name);
                pams[4] = new ReportParameter("Parameter_PID", patient.PId);
                this.reportViewer1.LocalReport.SetParameters(pams);
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_diagnosis_certificate_DataTable1", ds.Tables["table"]));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }
    }
}