using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmOpration_Print : DevComponents.DotNetBar.Office2007Form
    {
        private string sectionName = "";//统计科室
        private string beginTime = "";//统计开始时间
        private string endTime = "";//统计结束时间
        private DataSet ds = new DataSet();//数据表
        public frmOpration_Print()
        {
            InitializeComponent();
        }

        public frmOpration_Print(DataSet ds, string section, string beginTime, string endTime)
        {
            InitializeComponent();
            this.sectionName = section;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.ds = ds;
        }

        private void frmOpration_Print_Load(object sender, EventArgs e)
        {
            if (ds == null)
            {
                App.Msg("没有可以打印的信息!");
                return;
            }
            else
            {
                this.reportViewer1.LocalReport.ReportPath = App.SysPath + @"\Report_Opration.rdlc";
                ReportParameter[] pams = new ReportParameter[3];
                pams[0] = new ReportParameter("sectionName", sectionName);
                pams[1] = new ReportParameter("BeginTime", beginTime);
                pams[2] = new ReportParameter("EndTime", endTime);
                reportViewer1.LocalReport.SetParameters(pams);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsStatistics_DtOpration", ds.Tables[0]));
                reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

            }
        }

    }
}