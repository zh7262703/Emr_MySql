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
    public partial class ucCase_History : UserControl
    {
        public ucCase_History()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }


        private void ucCase_History_Load(object sender, EventArgs e)
        {
            try
            {
                chkSection_CheckedChanged(sender, e);
                chkTime_CheckedChanged(sender, e);
            }
            catch { }
        }
        private void Sections()
        {
            DataSet dt = App.GetDataSet("select * from T_SECTIONINFO");
            cboFrequencyItem.DataSource = dt.Tables[0].DefaultView;
            cboFrequencyItem.ValueMember = "SID";
            cboFrequencyItem.DisplayMember = "SECTION_NAME";
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("����", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("סԺ��", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("��������", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("�ܴ�ҽʦ", Type.GetType("System.String"));
            dt.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn("���˻ش���", Type.GetType("System.String"));
            dt.Columns.Add(dc4);

            DataRow dr = dt.NewRow();
            dr[0] = "���ڿ�";
            dr[1] = "363669";
            dr[2] = "����ƽ";
            dr[3] = "";
            dr[4] = "0";

            DataRow dr1 = dt.NewRow();
            dr1[0] = "ICU����";
            dr1[1] = "372425";
            dr1[2] = "�ﰮ��";
            dr1[3] = "";
            dr1[4] = "0";

            DataRow dr2 = dt.NewRow();
            dr2[0] = "������";
            dr2[1] = "375584";
            dr2[2] = "�����";
            dr2[3] = "";
            dr2[4] = "0";

            DataRow dr3 = dt.NewRow();
            dr3[0] = "ICU����";
            dr3[1] = "375618";
            dr3[2] = "��̫��";
            dr3[3] = "";
            dr3[4] = "0";

            DataRow dr4 = dt.NewRow();
            dr4[0] = "������";
            dr4[1] = "376019";
            dr4[2] = "������";
            dr4[3] = "";
            dr4[4] = "0";

            DataRow dr5 = dt.NewRow();
            dr5[0] = "�����";
            dr5[1] = "378466";
            dr5[2] = "���ٷ�";
            dr5[3] = "";
            dr5[4] = "0";

            DataRow dr6 = dt.NewRow();
            dr6[0] = "�����ڿ�";
            dr6[1] = "378568";
            dr6[2] = "��Ի��";
            dr6[3] = "�벨";
            dr6[4] = "0";

            DataRow dr7 = dt.NewRow();
            dr7[0] = "�����ڿ�";
            dr7[1] = "378905";
            dr7[2] = "������";
            dr7[3] = "";
            dr7[4] = "0";

            DataRow dr8 = dt.NewRow();
            dr8[0] = "����ƶ�����";
            dr8[1] = "379369";
            dr8[2] = "������";
            dr8[3] = "";
            dr8[4] = "0";


            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);
            dt.Rows.Add(dr5);
            dt.Rows.Add(dr6);
            dt.Rows.Add(dr7);
            dt.Rows.Add(dr8);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["����"].Width = 200;
            ucC1FlexGrid1.fg.Cols["סԺ��"].Width = 200;
            ucC1FlexGrid1.fg.Cols["��������"].Width = 200;
            ucC1FlexGrid1.fg.Cols["�ܴ�ҽʦ"].Width = 200;
            ucC1FlexGrid1.fg.Cols["���˻ش���"].Width = 200;
        }
        /// <summary>
        /// ���ҿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSection.Checked == true)
                {
                    cboFrequencyItem.Enabled = true;
                    DataSet ds = new DataSet();
                    string sql = "select sID,Section_Name from t_sectioninfo";
                    ds = App.GetDataSet(sql);
                    this.cboFrequencyItem.DataSource = ds.Tables[0].DefaultView;
                    cboFrequencyItem.DisplayMember = "Section_Name";
                    cboFrequencyItem.ValueMember = "sID";
                }
                else
                {
                    cboFrequencyItem.Enabled = false;
                    DataSet ds = new DataSet();
                    string sql = "select sID,Section_Name from t_sectioninfo";
                    ds = App.GetDataSet(sql);
                    this.cboFrequencyItem.DataSource = ds.Tables[0].DefaultView;
                    cboFrequencyItem.DisplayMember = "Section_Name";
                    cboFrequencyItem.ValueMember = "sID";
                }
            }
            catch
            {
            }

        }
        /// <summary>
        /// �鵵ʱ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked == true)
            {
                dtpStartYear.Enabled = true;

            }
            else
            {
                dtpStartYear.Enabled = false;
            }
        }

        private void ucC1FlexGrid1_Load(object sender, EventArgs e)
        {

        }

    }
}
