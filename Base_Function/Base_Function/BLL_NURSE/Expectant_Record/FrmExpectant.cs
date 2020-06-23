using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Expectant_Record
{
    public partial class FrmExpectant : DevComponents.DotNetBar.Office2007Form
    {
        private string Pidname = "";
        private string Sickname = "";
        private string Bed = "";
        private string Pid = "";
        public FrmExpectant()
        {
            InitializeComponent();
        }
        DataSet dsp = new DataSet();
        public FrmExpectant(DataSet disp,string pidname,string sickname,string bed,string pid)
        {
            InitializeComponent();
            dsp = disp;
            Pidname = pidname;
            Sickname = sickname;
            Bed = bed;
            Pid = pid;
        }

        private void FrmExpectant_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            if (dsp != null)
            {
                if (dsp.Tables[0].Rows.Count < 1)
                {
                    App.Msg("没有可以打印的信息！");
                    return;
                }
                else
                {
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\Report_Expectant.rdlc";
                    ReportParameter[] pams = new ReportParameter[4];
                    pams[0] = new ReportParameter("Pidname", Pidname);
                    pams[1] = new ReportParameter("Sickname", Sickname);
                    pams[2] = new ReportParameter("Bed", Bed);
                    pams[3] = new ReportParameter("Pid", Pid);
                    reportViewer1.LocalReport.SetParameters(pams);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Expectant_DataTable_Expectant", dsp.Tables[0]));
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.Percent;
                    this.reportViewer1.ZoomPercent = 100;
                }
            }
        }
    }
}