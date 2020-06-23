using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Base_Function.BLL_NURSE.SickInformational
{
    public partial class SickReportPrint : DevComponents.DotNetBar.Office2007Form
    {
        public SickReportPrint()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataSet ds1;
        public SickReportPrint(DataSet _ds,DataSet _ds1)
        {
            InitializeComponent();
            this.ds = _ds;
            this.ds1 = _ds1;
            DataColumn dc3 = new DataColumn("ACTIONTYPE1", typeof(string));
            //ds1.DefaultValue = false;
            ds1.Tables[0].Columns.Add(dc3);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "240")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "出院";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "241")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "转出";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "242")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "死亡";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "243")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "入院";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "244")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "转入";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "245")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "病重";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "246")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "病危";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "247")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "手术";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "248")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "分娩";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "249")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "新生儿";
                if (ds1.Tables[0].Rows[i]["ACTIONTYPE"].ToString() == "250")
                    ds1.Tables[0].Rows[i]["ACTIONTYPE1"] = "明手术";
            }
        }
        private void SickReportPrint_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0 && ds1.Tables[0].Rows[0]["sick_area_name"].ToString() != "")
            {
                ReportParameter[] report = new ReportParameter[] { new ReportParameter("Report_sick_name", "" + ds1.Tables[0].Rows[0]["sick_area_name"]) };
                this.reportViewer1.LocalReport.SetParameters(report);
            }
            else
            {
                ReportParameter[] report = new ReportParameter[] { new ReportParameter("inpatient_id", "不详") };
                this.reportViewer1.LocalReport.SetParameters(report);
            }
            if (ds != null && ds1!=null)
            {
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("SickReport_Data_DataTable_sickReport", ds.Tables["table"]));
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("SickReport_Data_DataTable_handovers", ds1.Tables["table"]));
                this.reportViewer1.LocalReport.Refresh();
            }
            this.reportViewer1.RefreshReport();
        }
    }
}