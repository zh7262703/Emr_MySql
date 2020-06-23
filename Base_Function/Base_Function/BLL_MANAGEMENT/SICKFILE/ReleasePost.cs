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
    public partial class ReleasePost : UserControl
    {
        public ReleasePost()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("����ʱ��", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("����", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("����", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("����", Type.GetType("System.String"));
            dt.Columns.Add(dc3);



            DataRow dr = dt.NewRow();
            dr[0] = "2009-02-16 08:37:00";
            dr[1] = "����";
            dr[2] = "��������";
            dr[3] = "D75";



            DataRow dr1 = dt.NewRow();
            dr1[0] = "2008-12-18 08:59:46";
            dr1[1] = "��ͨ";
            dr1[2] = "���۲�����";
            dr1[3] = "M84";




            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["����ʱ��"].Width = 250;
            ucC1FlexGrid1.fg.Cols["����"].Width = 250;
            ucC1FlexGrid1.fg.Cols["����"].Width = 250;
            ucC1FlexGrid1.fg.Cols["����"].Width = 250;
        }
    }
}
