using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Microsoft.Reporting.WinForms;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    public partial class Temperature : Office2007Form
    {
        private string sickareas;//病区

        private string datetimes;//日期

        public string Sickareas
        {
            get { return sickareas; }
            set { sickareas = value; }
        }
        public string Datetimes
        {
            get { return datetimes; }
            set { datetimes = value; }
        }
        public Temperature()
        {
            InitializeComponent();
        }
        DataSet dsItems = new DataSet();
        public Temperature(DataSet dsitems,string sickareas, string datetimes)
        {
            InitializeComponent();
            dsItems = dsitems;
            Sickareas = sickareas;
            Datetimes = datetimes;
        }
        private void Temperature_Load(object sender, EventArgs e)
        {
            if (dsItems != null)
            {
                if (dsItems.Tables[0].Rows.Count < 1)
                {
                    App.Msg("没有可以打印的信息！");
                    return;
                }
                else
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Temperature.rdlc";
                    ReportParameter[] pams = new ReportParameter[2];
                    pams[0] = new ReportParameter("SickArea", Sickareas);
                    pams[1] = new ReportParameter("Date_Time", Datetimes);
                    reportViewer1.LocalReport.SetParameters(pams);
                    //reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_temparature_DatasetTemperature", dsItems.Tables[0]));
                    //this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.Percent;
                    this.reportViewer1.ZoomPercent = 100;
                }
            }
            //this.reportViewer2.RefreshReport();
        }
    }
}