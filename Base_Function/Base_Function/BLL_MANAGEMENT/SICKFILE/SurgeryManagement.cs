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
    public partial class SurgeryManagement : UserControl
    {
        public SurgeryManagement()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("通用手术名称", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("通用手术拼音码", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("标准手术名称", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("标准ICD9编码", Type.GetType("System.String"));
            dt.Columns.Add(dc3);



            DataRow dr = dt.NewRow();
            dr[0] = "阑尾切除术";
            dr[1] = "lwqcs";
            dr[2] = "阑尾切除术";
            dr[3] = "47.0 01";



            DataRow dr1 = dt.NewRow();
            dr1[0] = "b";
            dr1[1] = "b";
            dr1[2] = "髌骨脱位复位术";
            dr1[3] = "81.4401";

            DataRow dr2 = dt.NewRow();
            dr2[0] = "a";
            dr2[1] = "a";
            dr2[2] = "手部肌腱探查术";
            dr2[3] = "82.0102";





            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["通用手术名称"].Width = 250;
            ucC1FlexGrid1.fg.Cols["通用手术拼音码"].Width = 250;
            ucC1FlexGrid1.fg.Cols["标准手术名称"].Width = 250;
            ucC1FlexGrid1.fg.Cols["标准ICD9编码"].Width = 250;
        }
    }
}
