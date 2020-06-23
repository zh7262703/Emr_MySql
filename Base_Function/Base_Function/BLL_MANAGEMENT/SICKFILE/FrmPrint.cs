using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class FrmPrint : DevComponents.DotNetBar.Office2007Form
    {
        private DataTable dt;
        public FrmPrint(DataTable _dt)
        {
            InitializeComponent();
            this.dt = _dt;
        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“DataAggregate.T_CASE_COPY_RECORD”中。您可以根据需要移动或移除它。
            //this.T_CASE_COPY_RECORDTableAdapter.Fill(this.DataAggregate.T_CASE_COPY_RECORD);

            //localReport.ReportPath = "Bifrost_Hospital_Management\\ReportFrom.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1_DataTable1", dt));
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}