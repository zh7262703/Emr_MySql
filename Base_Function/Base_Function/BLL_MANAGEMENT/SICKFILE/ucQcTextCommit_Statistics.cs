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
    public partial class ucQcTextCommit_Statistics : UserControl
    {
        public ucQcTextCommit_Statistics()
        {
            InitializeComponent();
        }
        //�еļ���
        ColumnInfo[] cols = new ColumnInfo[5];
        /// <summary>
        /// ���ݼ�
        /// </summary>
        DataSet ds = null;

        /// <summary>
        /// ȫ�ֱ�������¼��ѯ��Χ��ֻ���ٴβ�ѯʱ��״̬�Ÿı�
        /// </summary>
        string searchName = "";

        private void ucTime_Statistics_Load(object sender, EventArgs e)
        {
            try
            {
                flgview.MouseHoverCell += new EventHandler(fg_MouseHover);
                flgview.AllowEditing = false;
                TimeUnit();
                setTableHeader();
                CellMerge();
            }
            catch
            { }
        }

        int oldRow = 0;
        /// <summary>
        /// ���ͣ�����е�ɫ�ı� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_MouseHover(object sender, EventArgs e)
        {
            int Row = flgview.MouseRow;

            if (Row > 0)
            {
                if (Row != oldRow && oldRow <= flgview.Rows.Count)
                {
                    flgview.Rows[Row].StyleNew.BackColor = ColorTranslator.FromHtml("#e9f7f6");
                    flgview.Rows[Row].StyleNew.ForeColor = ColorTranslator.FromHtml("#00619d");
                    flgview.Cursor = Cursors.Hand;
                    flgview.Cols[2].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
                    if (oldRow > 0)
                    {
                        if (oldRow < flgview.Rows.Count && oldRow > 0)
                        {
                            flgview.Rows[oldRow].StyleNew.BackColor = flgview.BackColor;
                            flgview.Rows[oldRow].StyleNew.ForeColor = flgview.ForeColor;
                        }
                    }
                }
                oldRow = Row;
            }
        }
 
        //��ʱ��ͳ�Ʒ�Χ
        private void TimeUnit()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='39'");
            cboTimeUnit.DataSource = ds.Tables[0].DefaultView;
            cboTimeUnit.ValueMember = "ID";
            cboTimeUnit.DisplayMember = "NAME";
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            searchName = cboTimeUnit.Text;
            DataSet ds = Get_Search_Data();

            Get_Fill_Grid(ds);
        }

        /// <summary>
        /// ��ȡ��ѯ�����ݽ��
        /// </summary>
        /// <returns></returns>
        private DataSet Get_Search_Data()
        {
            string dataStart = dtpStart.Value.ToString("yyyy-MM-dd ");
            string dataend = dtpEnd.Value.ToString("yyyy-MM-dd ");
            try
            {
                Class_Table[] temtables = new Class_Table[7];


                //��ǰ���ۼ�¼
                string sql_into_area = "select b.section_name ����,\n" +
                "       b.pid סԺ��,\n" +
                "       b.patient_name ��������,\n" +
                "       b.section_id,\n" +
                "       b.SICK_AREA_ID,\n" +
                "       b.SICK_AREA_name,\n" +
                "       null ��Ժ���,\n" +
                "       b.id ����ID\n" +
                "from t_patients_doc t\n" +
                "left join t_text s on t.textkind_id = s.id\n" +
                "left join t_in_patient b on t.patient_id = b.id\n" +
                "where s.textname = '��ǰ���ۼ�¼' and  t.submitted = 'Y'\n" +
                "and to_char(b.in_time, 'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'\n" +
                "order by b.section_name, b.sick_area_name,b.patient_name";


                //���ѡ�Σ�ز������ۼ�¼
                string sql_out_area = "select b.section_name ����,\n" +
                "       b.pid סԺ��,\n" +
                "       b.patient_name ��������,\n" +
                "       b.section_id,\n" +
                "       b.SICK_AREA_ID,\n" +
                "       b.SICK_AREA_name,\n" +
                "       null ��Ժ���,\n" +
                "       b.id ����ID\n" +
                "from t_patients_doc t\n" +
                "left join t_text s on t.textkind_id = s.id\n" +
                "left join t_in_patient b on t.patient_id = b.id\n" +
                "where s.textname = '���ѡ�Σ�ز������ۼ�¼' and  t.submitted = 'Y'\n" +
                "and to_char(b.in_time, 'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'\n" +
                "order by b.section_name, b.sick_area_name,b.patient_name";


                //�������ۼ�¼
                string sql_turn_out = "select b.section_name ����,\n" +
                "       b.pid סԺ��,\n" +
                "       b.patient_name ��������,\n" +
                "       b.section_id,\n" +
                "       b.SICK_AREA_ID,\n" +
                "       b.SICK_AREA_name,\n" +
                "       null ��Ժ���,\n" +
                "       b.id ����ID\n" +
                "from t_patients_doc t\n" +
                "left join t_text s on t.textkind_id = s.id\n" +
                "left join t_in_patient b on t.patient_id = b.id\n" +
                "where s.textname = '�������ۼ�¼' and  t.submitted = 'Y'\n" +
                "and to_char(b.in_time, 'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'\n" +
                "order by b.section_name, b.sick_area_name,b.patient_name";


                //�����¼
                string sqlString = "select b.section_name ����,\n" +
                "       b.pid סԺ��,\n" +
                "       b.patient_name ��������,\n" +
                "       b.section_id,\n" +
                "       b.SICK_AREA_ID,\n" +
                "       b.SICK_AREA_name,\n" +
                "       null ��Ժ���,\n" +
                "       b.id ����ID\n" +
                "from t_patients_doc t\n" +
                "left join t_text s on t.textkind_id = s.id\n" +
                "left join t_in_patient b on t.patient_id = b.id\n" +
                "where s.textname = '�����¼' and  t.submitted = 'Y'\n" +
                "and to_char(b.in_time, 'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'\n" +
                "order by b.section_name, b.sick_area_name,b.patient_name";


                //���в���
                string sql_allSickArea = "select said,sick_area_name from t_sickareainfo";
                //���п���
                string sql_allSection = "select sid,section_name from t_sectioninfo where enable_flag='Y'";

                //������Ժ���
                string sql_allin_diag = "select d.patient_id,d.diagnose_name,d.create_time,d.diagnose_sort\n" +
                "from t_diagnose_item d\n" +
                "left join t_in_patient t on d.patient_id = t.id\n" +
                "where diagnose_type=408 and diagnose_sort = 1\n" +
                "and to_char(t.in_time, 'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                
                temtables[0] = new Class_Table();
                temtables[0].Sql = sql_into_area;
                temtables[0].Tablename = "into_area";

                temtables[1] = new Class_Table();
                temtables[1].Sql = sql_out_area;
                temtables[1].Tablename = "out_area";

                temtables[2] = new Class_Table();
                temtables[2].Sql = sql_turn_out;
                temtables[2].Tablename = "turn_out";

                temtables[3] = new Class_Table();
                temtables[3].Sql = sqlString;
                temtables[3].Tablename = "turn_in";

                temtables[4] = new Class_Table();
                temtables[4].Sql = sql_allSickArea;
                temtables[4].Tablename = "allSickArea";

                temtables[5] = new Class_Table();
                temtables[5].Sql = sql_allSection;
                temtables[5].Tablename = "allSection";

                temtables[6] = new Class_Table();
                temtables[6].Sql = sql_allin_diag;
                temtables[6].Tablename = "allin_diag";

                ds = App.GetDataSet(temtables);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private void Get_Fill_Grid(DataSet ds)
        {
            flgview.Rows.Count = 1;
            if (ds != null)
            {
                //178��ȫԺ��ѯ
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 178)
                {
                    flgview.Rows.Add();
                    //�������
                    flgview[1, 0] = "ȫԺ";

                    int val = 0;
                    val = ds.Tables["into_area"].Rows.Count;
                    flgview[1, 1] = val;

                    val = ds.Tables["out_area"].Rows.Count;
                    flgview[1, 2] = val;

                    val = ds.Tables["turn_out"].Rows.Count;
                    flgview[1, 3] = val;

                    val = ds.Tables["turn_in"].Rows.Count;
                    flgview[1, 4] = val;

                }
                //179����������ѯ
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 179)
                {
                    //����
                    int count = ds.Tables["allSickArea"].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        flgview.Rows.Add();
                        DataRow dr = ds.Tables["allSickArea"].Rows[i];
                        string sickId = dr["said"].ToString();
                        string sickName = dr["sick_area_name"].ToString();
                        flgview[i + 1, 0] = sickName;
                        int val = 0;
                        val = ds.Tables["into_area"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                        flgview[i + 1, 1] = val;

                        val = ds.Tables["out_area"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                        flgview[i + 1, 2] = val;

                        val = ds.Tables["turn_out"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                        flgview[i + 1, 3] = val;

                        val = ds.Tables["turn_in"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                        flgview[i + 1, 4] = val;
                    }
                }
                //�����Ҳ�ѯ
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 180)
                {
                    //����
                    int count = ds.Tables["allSection"].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        flgview.Rows.Add();
                        DataRow dr = ds.Tables["allSection"].Rows[i];
                        string sectionId = dr["sid"].ToString();
                        string sectionName = dr["section_name"].ToString();
                        flgview[i + 1, 0] = sectionName;
                        int val = 0;
                        val = ds.Tables["into_area"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 1] = val;

                        val = ds.Tables["out_area"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 2] = val;

                        val = ds.Tables["turn_out"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 3] = val;

                        val = ds.Tables["turn_in"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 4] = val;
                    }
                }

                setTableHeader();
                CellMerge();
            }
        }

       

        /// <summary>
        /// ���ñ�ͷ
        /// </summary>
        public void setTableHeader()
        {

            try
            {
                flgview.Cols.Count = 5;
                //flgview.Rows.Count = 2;
                flgview.Rows.Fixed = 1;
                //��ͷ����
                //�ܼ�
                cols[0].Name = "���������ң�";
                cols[0].Field = "Sick_Section";
                cols[0].Index = 1;
                cols[0].visible = true;

                cols[1].Name = "��ǰ���ۼ�¼";
                cols[1].Field = "into_area";
                cols[1].Index = 2;
                cols[1].visible = true;

                cols[2].Name = "���ѡ�Σ�ز������ۼ�¼";
                cols[2].Field = "out_area";
                cols[2].Index = 3;
                cols[2].visible = true;

                cols[3].Name = "�������ۼ�¼";
                cols[3].Field = "turn_out";
                cols[3].Index = 4;
                cols[3].visible = true;

                cols[4].Name = "�����¼";
                cols[4].Field = "turn_in";
                cols[4].Index = 5;
                cols[4].visible = true;

                flgview.Cols[0].Width = 150;
                flgview.Cols[1].Width = 80;
                flgview.Cols[2].Width = 150;
                flgview.Cols[3].Width = 80;
                flgview.Cols[4].Width = 80;


                for (int i = 0; i < flgview.Cols.Count; i++)
                {
                    flgview.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// ��Ԫ��ϲ�
        /// </summary>
        public void CellMerge()
        {
            //��Ԫ������           
            flgview[0, 0] = "���������ң�";
            flgview[0, 1] = "��ǰ���ۼ�¼";
            flgview[0, 2] = "���ѡ�Σ�ز������ۼ�¼";
            flgview[0, 3] = "�������ۼ�¼";
            flgview[0, 4] = "�����¼";
            flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgview.Cols.Fixed = 0;
        }

        /// <summary>
        /// ˫�����֣���ʾ��Ӧ�Ĳ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgview_DoubleClick(object sender, EventArgs e)
        {

            if (flgview[flgview.RowSel, flgview.ColSel] != null && App.IsNumeric(flgview[flgview.RowSel, flgview.ColSel].ToString()))
            {
                //��Ժ���
                DataTable dt_inDiag = ds.Tables["allin_diag"];
                //flgview[flgview.RowSel, "��Ժ����"];
                DataTable dt = new DataTable();
                //��һ����ͷ
                //ѡ������ͷ
                string rowname = flgview[flgview.RowSel, 0].ToString();
                //�ڶ�����ͷ
                string colname = flgview[0, flgview.ColSel].ToString();
                switch (colname)
                {
                    case "��ǰ���ۼ�¼":
                        dt = ds.Tables["into_area"];
                        break;
                    case "���ѡ�Σ�ز������ۼ�¼":
                        dt = ds.Tables["out_area"];
                        break;
                    case "�������ۼ�¼":
                        dt = ds.Tables["turn_out"];
                        break;
                    case "�����¼":
                        dt = ds.Tables["turn_in"];
                        break;
                }

                if (rowname == "ȫԺ")
                {
                    if (colname == "��ǰ���ۼ�¼" || colname == "���ѡ�Σ�ز������ۼ�¼" || colname == "�������ۼ�¼" || colname == "�����¼")
                    {
                        frmQCTextCommit_PatientInfo patientInfo = new frmQCTextCommit_PatientInfo(dt, dt_inDiag);
                        patientInfo.ShowDialog();
                    }
                }
                if (searchName == "������")//������
                {
                    DataTable dt_sick_area = new DataTable();
                    DataRow[] dr = dt.Select("sick_area_name='" + rowname + "'");
                    dt_sick_area = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_sick_area.Rows.Add(dr[i].ItemArray);
                    }

                    if (colname == "��ǰ���ۼ�¼" || colname == "���ѡ�Σ�ز������ۼ�¼" || colname == "�������ۼ�¼" || colname == "�����¼")
                    {
                        frmQCTextCommit_PatientInfo patientInfo = new frmQCTextCommit_PatientInfo(dt_sick_area, dt_inDiag);
                        patientInfo.ShowDialog();
                    }
                }
                if (searchName == "������")//������
                {
                    DataTable dt_section = new DataTable();

                    DataRow[] dr = dt.Select("����='" + rowname + "'");
                    dt_section = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_section.Rows.Add(dr[i].ItemArray);
                    }
                    if (colname == "��ǰ���ۼ�¼" || colname == "���ѡ�Σ�ز������ۼ�¼" || colname == "�������ۼ�¼" || colname == "�����¼")
                    {
                        frmQCTextCommit_PatientInfo patientInfo = new frmQCTextCommit_PatientInfo(dt_section, dt_inDiag);
                        patientInfo.ShowDialog();
                    }
                }
            }

        }

        private void dtpStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnStatistics.PerformClick();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            flgview.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "�ʿذ��������ͳ��.xls";
            saveFileDialog1.Filter = "Excel������(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

    }
}
