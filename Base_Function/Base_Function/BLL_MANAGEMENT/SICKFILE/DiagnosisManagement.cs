using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class DiagnosisManagement : UserControl
    {
        public DiagnosisManagement()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("通用诊断名称", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("通用诊断拼音码", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("标准诊断名称", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("标准ICD10编码", Type.GetType("System.String"));
            dt.Columns.Add(dc3);

           

            DataRow dr = dt.NewRow();
            dr[0] = "左侧胫骨骨折";
            dr[1] = "zcjggz";
            dr[2] = "骨髓坏死";
            dr[3] = "D75.801";
           


            DataRow dr1 = dt.NewRow();
            dr1[0] = "骨折";
            dr1[1] = "gz";
            dr1[2] = "骨折不愈合";
            dr1[3] = "M84.191";
            

           

            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["通用诊断名称"].Width = 250;
            ucC1FlexGrid1.fg.Cols["通用诊断拼音码"].Width = 250;
            ucC1FlexGrid1.fg.Cols["标准诊断名称"].Width = 250;
            ucC1FlexGrid1.fg.Cols["标准ICD10编码"].Width = 250;
           
        }
    }
}
