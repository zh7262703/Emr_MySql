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
    public partial class CardManagement : UserControl
    {
        public CardManagement()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("����", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("Ժ�б���", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("��Ⱦ������", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("��������", Type.GetType("System.String"));
            dt.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn("�в�����������", Type.GetType("System.String"));
            dt.Columns.Add(dc4);

            DataColumn dc5 = new DataColumn("Χ������������", Type.GetType("System.String"));
            dt.Columns.Add(dc5);

            DataColumn dc6 = new DataColumn("��ͯ��������", Type.GetType("System.String"));
            dt.Columns.Add(dc6);

            DataColumn dc7 = new DataColumn("����ȱ�ݶ�����", Type.GetType("System.String"));
            dt.Columns.Add(dc7);

            DataRow dr = dt.NewRow();
            dr[0] = "�ڿ�";
            dr[1] = "0";
            dr[2] = "0";
            dr[3] = "0";
            dr[4] = "0";
            dr[5] = "0";
            dr[6] = "0";
            dr[7] = "0";


            DataRow dr1 = dt.NewRow();
            dr1[0] = "�����ڿ�";
            dr1[1] = "2";
            dr1[2] = "1";
            dr1[3] = "1";
            dr1[4] = "1";
            dr1[5] = "0";
            dr1[6] = "1";
            dr1[7] = "2";

            DataRow dr2 = dt.NewRow();
            dr2[0] = "�ڷ��ڿ�";
            dr2[1] = "1";
            dr2[2] = "0";
            dr2[3] = "0";
            dr2[4] = "0";
            dr2[5] = "1";
            dr2[6] = "0";
            dr2[7] = "0";

            DataRow dr3 = dt.NewRow();
            dr3[0] = "��Ѫ���ڿ�";
            dr3[1] = "1";
            dr3[2] = "0";
            dr3[3] = "0";
            dr3[4] = "0";
            dr3[5] = "0";
            dr3[6] = "0";
            dr3[7] = "0";

            DataRow dr4 = dt.NewRow();
            dr4[0] = "���ڿ�";
            dr4[1] = "0";
            dr4[2] = "0";
            dr4[3] = "0";
            dr4[4] = "0";
            dr4[5] = "0";
            dr4[6] = "0";
            dr4[7] = "0";

            DataRow dr5 = dt.NewRow();
            dr5[0] = "�����ڿ�";
            dr5[1] = "0";
            dr5[2] = "0";
            dr5[3] = "0";
            dr5[4] = "0";
            dr5[5] = "0";
            dr5[6] = "0";
            dr5[7] = "0";

            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);
            dt.Rows.Add(dr5);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["����"].Width = 150;
            ucC1FlexGrid1.fg.Cols["Ժ�б���"].Width = 150;
            ucC1FlexGrid1.fg.Cols["��Ⱦ������"].Width = 150;
            ucC1FlexGrid1.fg.Cols["��������"].Width = 150;
            ucC1FlexGrid1.fg.Cols["�в�����������"].Width = 150;
            ucC1FlexGrid1.fg.Cols["Χ������������"].Width = 150;
            ucC1FlexGrid1.fg.Cols["��ͯ��������"].Width = 150;
            ucC1FlexGrid1.fg.Cols["����ȱ�ݶ�����"].Width = 150;
        }
    }
}
