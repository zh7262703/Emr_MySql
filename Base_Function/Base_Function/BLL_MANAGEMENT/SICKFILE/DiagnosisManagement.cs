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
            DataColumn dc = new DataColumn("ͨ���������", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("ͨ�����ƴ����", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("��׼�������", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("��׼ICD10����", Type.GetType("System.String"));
            dt.Columns.Add(dc3);

           

            DataRow dr = dt.NewRow();
            dr[0] = "����ֹǹ���";
            dr[1] = "zcjggz";
            dr[2] = "���軵��";
            dr[3] = "D75.801";
           


            DataRow dr1 = dt.NewRow();
            dr1[0] = "����";
            dr1[1] = "gz";
            dr1[2] = "���۲�����";
            dr1[3] = "M84.191";
            

           

            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["ͨ���������"].Width = 250;
            ucC1FlexGrid1.fg.Cols["ͨ�����ƴ����"].Width = 250;
            ucC1FlexGrid1.fg.Cols["��׼�������"].Width = 250;
            ucC1FlexGrid1.fg.Cols["��׼ICD10����"].Width = 250;
           
        }
    }
}
