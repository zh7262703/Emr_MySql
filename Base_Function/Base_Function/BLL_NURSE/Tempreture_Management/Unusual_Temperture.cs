using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using Microsoft.Reporting.WinForms;

namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    public partial class Unusual_Temperture : Office2007Form
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
        public Unusual_Temperture()
        {
            InitializeComponent();
        }
        DataSet dsItemsstr = new DataSet();
        public Unusual_Temperture(DataSet dsitems, string sickareas, string datetimes)
        {
            InitializeComponent();
            dsItemsstr = dsitems;
            Sickareas = sickareas;
            Datetimes = datetimes;
        }
        private void Unusual_Temperture_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            if (dsItemsstr != null)
            {
                if (dsItemsstr.Tables[0].Rows.Count < 1)
                {
                    App.Msg("没有可以打印的信息！");
                    return;
                }
                else
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Temperture1.rdlc";
                   
                    ReportParameter[] pams = new ReportParameter[2];
                    pams[0] = new ReportParameter("SickArea", Sickareas);
                    pams[1] = new ReportParameter("Date_Time", Datetimes);
                    reportViewer1.LocalReport.SetParameters(pams);
                    //reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Temperature1_DataTable_Tempertures1", dsItemsstr.Tables[0]));
                    //this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.Percent;
                    this.reportViewer1.ZoomPercent = 100;
                }
            }
        }
    }
}