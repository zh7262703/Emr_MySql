using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Bifrost;


namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    public partial class frmPrintByInout_Amount : DevComponents.DotNetBar.Office2007Form
    {
        private DataSet ds_Datesource=new DataSet();
        private InPatientInfo inPatient;
        public frmPrintByInout_Amount()
        {
            InitializeComponent();
        }
        public frmPrintByInout_Amount(DataSet ds, InPatientInfo inpatient)
        {
            InitializeComponent();
            this.ds_Datesource = ds;
            this.inPatient = inpatient;
        }
        private void frmPrintByInout_Amount_Load(object sender, EventArgs e)
        {
            if (ds_Datesource != null)
            {
                if (ds_Datesource.Tables[0].Rows.Count>0)
                {
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_InOutMount.rdlc";
                    ReportParameter[] parameter = new ReportParameter[4];
                    parameter[0] = new ReportParameter("BedRoom", inPatient.Section_Name);
                    parameter[1] = new ReportParameter("BedNumber", inPatient.Sick_Bed_Name);
                    parameter[2] = new ReportParameter("UserName", inPatient.Patient_Name);
                    parameter[3] = new ReportParameter("InPid", inPatient.PId);
                    reportViewer1.LocalReport.SetParameters(parameter);

                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Inhospital_Info_Model_NuserInout_show", ds_Datesource.Tables[0]));
                        this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                        this.reportViewer1.ZoomMode = ZoomMode.Percent;
                        this.reportViewer1.ZoomPercent = 100;
                        //this.reportViewer1.RefreshReport();
                }
                else
                {
                    App.Msg("没有数据可以打印");
                }
            }
        }
    }
}