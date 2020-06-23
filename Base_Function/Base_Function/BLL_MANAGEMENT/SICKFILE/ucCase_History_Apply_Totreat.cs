using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucCase_History_Apply_Totreat : UserControl
    {
        public ucCase_History_Apply_Totreat()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void ucC1FlexGrid1_Load(object sender, EventArgs e)
        {
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            try
            {
                DataSet ds = new DataSet();
                string sql = "select sID,Section_Name from t_sectioninfo";
                ds = App.GetDataSet(sql);
                this.cboFrequencyItem.DataSource = ds.Tables[0].DefaultView;
                cboFrequencyItem.DisplayMember = "Section_Name";
                cboFrequencyItem.ValueMember = "sID";
            }
            catch { }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            #region ����
            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn("����ʱ��", Type.GetType("System.String"));
            //dt.Columns.Add(dc);

            //DataColumn dc1 = new DataColumn("�������", Type.GetType("System.String"));
            //dt.Columns.Add(dc1);

            //DataColumn dc2 = new DataColumn("��������", Type.GetType("System.String"));
            //dt.Columns.Add(dc2);

            //DataColumn dc3 = new DataColumn("������", Type.GetType("System.String"));
            //dt.Columns.Add(dc3);

            //DataColumn dc4 = new DataColumn("������", Type.GetType("System.String"));
            //dt.Columns.Add(dc4);

            //DataColumn dc5 = new DataColumn("סԺ����", Type.GetType("System.String"));
            //dt.Columns.Add(dc5);

            //DataColumn dc6 = new DataColumn("��������", Type.GetType("System.String"));
            //dt.Columns.Add(dc6);

            //DataRow dr = dt.NewRow();
            //dr[0] = "2009-03-15";
            //dr[1] = "�����";
            //dr[2] = "";
            //dr[3] = "�ź���";
            //dr[4] = "";
            //dr[5] = "1";
            //dr[6] = "���ڶ�";


            //DataRow dr1 = dt.NewRow();
            //dr1[0] = "2009-03-19";
            //dr1[1] = "������Ʋ���";
            //dr1[2] = "";
            //dr1[3] = "ϵͳ����";
            //dr1[4] = "PD0900000012";
            //dr1[5] = "1";
            //dr1[6] = "�����";

            //DataRow dr2 = dt.NewRow();
            //dr2[0] = "2009-03-19";
            //dr2[1] = "���ڿ�";
            //dr2[2] = "";
            //dr2[3] = "ϵͳ����";
            //dr2[4] = "PD0900000016";
            //dr2[5] = "1";
            //dr2[6] = "������";

            //DataRow dr3 = dt.NewRow();
            //dr3[0] = "2009-07-31";
            //dr3[1] = "�����";
            //dr3[2] = "";
            //dr3[3] = "ϵͳ����";
            //dr3[4] = "";
            //dr3[5] = "1";
            //dr3[6] = "���ڶ�";

            //DataRow dr4 = dt.NewRow();
            //dr4[0] = "2010-02-23";
            //dr4[1] = "������";
            //dr4[2] = "";
            //dr4[3] = "������";
            //dr4[4] = "";
            //dr4[5] = "1";
            //dr4[6] = "�޽�Ԫ";

            //DataRow dr5 = dt.NewRow();
            //dr5[0] = "2010-04-15";
            //dr5[1] = "�����";
            //dr5[2] = "";
            //dr5[3] = "ϵͳ����";
            //dr5[4] = "";
            //dr5[5] = "1";
            //dr5[6] = "���ڶ�";

            //dt.Rows.Add(dr);
            //dt.Rows.Add(dr1);
            //dt.Rows.Add(dr2);
            //dt.Rows.Add(dr3);
            //dt.Rows.Add(dr4);
            //dt.Rows.Add(dr5);
            //ucC1FlexGrid1.fg.DataSource = dt;

            //ucC1FlexGrid1.fg.Cols["����ʱ��"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["�������"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["��������"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["������"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["������"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["סԺ����"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["��������"].Width = 170;
            #endregion
            GetCoseData();
        }
        DataSet ds = null;
        string querySQLS = ""; 
        public void GetCoseData()
        {
            querySQLS = "select doc.id as ID, REQ_BY_TIME as ����ʱ��,sick.sick_area_name as �������, REQ_REMARK as ��������,REQ_BY_NAME as ����������, " +
                              "RECORD_BY_NAME as �˻ز���������,IN_HOSPITAL_ID as ���벡����,IN_COUNT as ���벡��סԺ����,patient_name as �������� " +
                              "from T_DOC_REQ_RECORD doc " +
                              "join t_Sickareainfo sick on sickorsection_id=sick.said " +
                              "join t_in_patient pati on in_patient_id=pati.pid";
            if (this.cboFrequencyItem.Text != "")
            {
                querySQLS += " and sick.sick_area_name='" + this.cboFrequencyItem.Text + "'";
            }

            if (this.txtShenqing.Text != "")
            {
                querySQLS += " and REQ_BY_NAME like '%" + this.txtShenqing.Text + "%'";
            }
            if (this.dtpStartYear.Text != "")
            {
                querySQLS += " and to_char(REQ_BY_TIME,'yyyy-MM-dd') like '" + this.dtpStartYear.Text + "'";
            }
             ds = App.GetDataSet(querySQLS);
            this.ucC1FlexGrid1.fg.DataSource = ds.Tables[0];
            for (int i = 1; i < this.ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                this.ucC1FlexGrid1.fg.Cols[i].Width = 158;
                ucC1FlexGrid1.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
            }
            this.ucC1FlexGrid1.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

        }
        //string querySQLS = "";
        private void ucCase_History_Apply_Totreat_Load(object sender, EventArgs e)
        {

            //GetCoseData();
            try
            {
                string querySQLS = "select doc.id as ID, REQ_BY_TIME as ����ʱ��,sick.sick_area_name as �������, REQ_REMARK as ��������,REQ_BY_NAME as ����������, " +
                                     "RECORD_BY_NAME as �˻ز���������,IN_HOSPITAL_ID as ���벡����,IN_COUNT as ���벡��סԺ����,patient_name as �������� " +
                                     "from T_DOC_REQ_RECORD doc " +
                                     "join t_Sickareainfo sick on sickorsection_id=sick.said " +
                                     "join t_in_patient pati on in_patient_id=pati.pid where 1=1";
                DataSet ds = App.GetDataSet(querySQLS);
                this.ucC1FlexGrid1.fg.DataSource = ds.Tables[0];
                for (int i = 1; i < this.ucC1FlexGrid1.fg.Cols.Count; i++)
                {
                    this.ucC1FlexGrid1.fg.Cols[i].Width = 158;
                    ucC1FlexGrid1.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }
                this.ucC1FlexGrid1.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }
            catch (Exception ee)
            {
            }

        }
        string ID = "";
        int oldRow = 0;//���ԭ������
        int selRow = 0;//�µ���
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.Rows.Count > 1)
            {
                ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
            }

            selRow = 1;
            ucC1FlexGrid1.fg.AllowEditing = false;


            int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к� 
            if (rows > 0)
            {
                if (oldRow == rows)
                {
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //�������ͷ��
                    if (rows > 0)
                    {
                        //�͸ı䱳��ɫ
                        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow)
                    {
                        //������һ�ε�������л�ԭ
                        this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
            }
            //����һ�ε��кŸ�ֵ
            oldRow = rows;

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string updateSQL = "update T_DOC_REQ_RECORD set STATE='1' where id='" + ID + "'";
            int go = App.ExecuteSQL(updateSQL);
            if (go > 0)
            {
                App.Msg("ͬ������ɹ�");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string updateSQL = "update T_DOC_REQ_RECORD set REQ_STATE='1' where id='" + ID + "'";
            int go = App.ExecuteSQL(updateSQL);
            if (go > 0)
            {
                App.Msg("�Ѿܾ�");
            }
        }

        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//����ID����
                ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }
    }
}
