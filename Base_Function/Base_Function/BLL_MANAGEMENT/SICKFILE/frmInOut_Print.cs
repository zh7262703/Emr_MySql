using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Microsoft.Reporting.WinForms;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmInOut_Print : DevComponents.DotNetBar.Office2007Form
    {
        DataSet ds = new DataSet();
        string sectionName="";
        string beginTime="";
        string endTime = "";
        string titleName = "";
        public frmInOut_Print()
        {
            InitializeComponent();
        }

        public frmInOut_Print(DataSet ds,string sectionName,string beginTime,string endTime,string titleName)
        {
            InitializeComponent();
            this.sectionName = sectionName;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.titleName = titleName;
            this.ds = ds;
        }

        private void frmInOut_Print_Load(object sender, EventArgs e)
        {
            if (ds == null)
            {
                App.Msg("没有可以打印的信息!");
                return;
            }
            else
            {
                this.reportViewer1.LocalReport.ReportPath = App.SysPath + @"\Report_InOut.rdlc";
                
                ReportParameter[] pams = new ReportParameter[4];
                pams[0] = new ReportParameter("TitleName", titleName);
                pams[1] = new ReportParameter("sectionName", sectionName);
                pams[2] = new ReportParameter("BeginTime", beginTime);
                pams[3] = new ReportParameter("EndTime", endTime);
                
                reportViewer1.LocalReport.SetParameters(pams);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsStatistics_DtInOut", ds.Tables[0]));
                reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

            }
        }
    }
}