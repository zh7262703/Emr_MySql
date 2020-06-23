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
    public partial class ArchiveStatistics : UserControl
    {
        public ArchiveStatistics()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }
        public void GetAllSection_Name() {
            try
            {
                DataSet ds = new DataSet();
                string sql = "select sID,Section_Name from t_sectioninfo";
                ds = App.GetDataSet(sql);
                this.cmbSectionOffice.DataSource = ds.Tables[0].DefaultView;
                cmbSectionOffice.DisplayMember = "Section_Name";
                cmbSectionOffice.ValueMember = "sID";
            }
            catch
            { }
        }

        private void ucC1FlexGrid1_Load(object sender, EventArgs e)
        {
            GetAllSection_Name();
        }
        
        private void btnSum_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("����", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("δ�鵵������", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("��������", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("Ӧ�ù鵵����", Type.GetType("System.String"));
            dt.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn("�ܴ�ҽʦ", Type.GetType("System.String"));
            dt.Columns.Add(dc4);
            
            DataRow dr = dt.NewRow();
            dr[0] = "������";
            dr[1] = "371838";
            dr[2] = "������";
            dr[3] = "2009-02-16 08:37:00";
            dr[4] = " ";

            DataRow dr1 = dt.NewRow();
            dr1[0] = "ICU����";
            dr1[1] = "372425";
            dr1[2] = "�ﰮ��";
            dr1[3] = "2008-12-18 08:59:46";
            dr1[4] = " ";

            DataRow dr2 = dt.NewRow();
            dr2[0] = "������";
            dr2[1] = "375584";
            dr2[2] = "�����";
            dr2[3] = "2009-01-26 15:40:00";
            dr2[4] = " ";

            DataRow dr3 = dt.NewRow();
            dr3[0] = "ICU����";
            dr3[1] = "375618";
            dr3[2] = "��̫��";
            dr3[3] = "2009-02-17 14:34:00";
            dr3[4] = " ";

            DataRow dr4 = dt.NewRow();
            dr4[0] = "������";
            dr4[1] = "376019";
            dr4[2] = "������";
            dr4[3] = "2009-02-11 17:03:00";
            dr4[4] = " ";

            DataRow dr5 = dt.NewRow();
            dr5[0] = "�����";
            dr5[1] = "378466";
            dr5[2] = "���ٷ�";
            dr5[3] = "2009-02-13 08:57:00";
            dr5[4] = " ";

            DataRow dr6 = dt.NewRow();
            dr6[0] = "�����ڿ�";
            dr6[1] = "378568";
            dr6[2] = "��Ի��";
            dr6[3] = "2009-02-18 05:40:00";
            dr6[4] = "��ΰ";

            DataRow dr7 = dt.NewRow();
            dr7[0] = "�����ڿ�";
            dr7[1] = "378905";
            dr7[2] = "������";
            dr7[3] = "2009-02-17 14:07:00";
            dr7[4] = " ";

            DataRow dr8 = dt.NewRow();
            dr8[0] = "����ƶ�����";
            dr8[1] = "379369";
            dr8[2] = "������";
            dr8[3] = "2009-03-01 10:10:00";
            dr8[4] = "����Ұ";

            DataRow dr9 = dt.NewRow();
            dr9[0] = "�ε����";
            dr9[1] = "378698";
            dr9[2] = "�߽���";
            dr9[3] = "2009-03-02 14:37:00";
            dr9[4] = "�ų�ϰ";

            DataRow dr10 = dt.NewRow();
            dr10[0] = "�����";
            dr10[1] = "380008";
            dr10[2] = "����ѧ";
            dr10[3] = "2010-03-19 06:59:00";
            dr10[4] = "���";

            DataRow dr11 = dt.NewRow();
            dr11[0] = "�����";
            dr11[1] = "380066";
            dr11[2] = "���Ӹ�";
            dr11[3] = "2009-03-04 11:40:00";
            dr11[4] = " ";

           
            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);
            dt.Rows.Add(dr5);
            dt.Rows.Add(dr6);
            dt.Rows.Add(dr7);
            dt.Rows.Add(dr8);
            dt.Rows.Add(dr9);
            dt.Rows.Add(dr10);
            dt.Rows.Add(dr11);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["����"].Width = 200;
            ucC1FlexGrid1.fg.Cols["δ�鵵������"].Width = 200;
            ucC1FlexGrid1.fg.Cols["��������"].Width = 200;
            ucC1FlexGrid1.fg.Cols["Ӧ�ù鵵����"].Width = 200;
            ucC1FlexGrid1.fg.Cols["�ܴ�ҽʦ"].Width = 200;
        }
    }
}
