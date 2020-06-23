using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using Bifrost;
namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    public partial class frmHeart_PIC_Print : DevComponents.DotNetBar.Office2007Form
    {
        private DataSet ds = new DataSet();
        private string section = "";//科别
        private string pid = "";//住院号
        private string bed_no = "";//床号
        private string name = "";//住院号
        private string diagnose = "";//诊断

        public frmHeart_PIC_Print()
        {
            InitializeComponent();
        }
        public frmHeart_PIC_Print(DataSet ds,string p_name,string p_section,string p_bed_id,string pid,string p_diagnose)
        {
            InitializeComponent();
            this.ds = ds;
            this.section = p_section;
            this.name = p_name;
            this.pid = pid;
            this.bed_no = p_bed_id;
            this.diagnose = p_diagnose;
        }
        private void frmHeart_PIC_Print_Load(object sender, EventArgs e)
        {
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    App.Msg("没有可以打印的信息！");
                    return;
                }
                else
                {
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\Report_HeartPIC.rdlc";

                    //参数
                    ReportParameter[] pams = new ReportParameter[5];
                    pams[0] = new ReportParameter("bed_no", bed_no);
                    pams[1] = new ReportParameter("name", name);
                    pams[2] = new ReportParameter("pid", pid);
                    pams[3] = new ReportParameter("diagnose", diagnose);
                    pams[4] = new ReportParameter("section", section);
                    reportViewer1.LocalReport.SetParameters(pams);

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Bgrecord_DataHeart_PIC", ds.Tables[0]));

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.Percent;
                    this.reportViewer1.ZoomPercent = 100;
                    this.reportViewer1.RefreshReport();
                }
            }
        }
    }
}