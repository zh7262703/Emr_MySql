using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Bifrost;
namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class frmFirstCases_Print : DevComponents.DotNetBar.Office2007Form
    {
        public DataSet DsSource;

        public frmFirstCases_Print()
        {
            InitializeComponent();
        }

        public frmFirstCases_Print(DataSet ds)
        {
            InitializeComponent();
            this.DsSource = ds;
        }

        private void frmFirstCases_Print_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\First_Cases.rdlc";
            
            // 清空数据源
            reportViewer1.LocalReport.DataSources.Clear();
            // 呈现当前报表
            this.reportViewer1.RefreshReport();

            this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\First_Cases.rdlc";
            
            // 添加数据源
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Info", DsSource.Tables[0]));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Diagnose", DsSource.Tables[1]));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Operation", DsSource.Tables[2]));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Quality", DsSource.Tables[3]));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Temp", DsSource.Tables[4]));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_cover_patient_cost", DsSource.Tables[5]));
         
            // 设置控件的显示模式为打印布局模式(避免多页打印需先点击一下布局,否则会丢失后几页)
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;         
        }
    }

}
