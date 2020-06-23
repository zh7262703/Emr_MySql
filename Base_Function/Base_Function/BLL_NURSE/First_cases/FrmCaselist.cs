using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class FrmCaselist : DevComponents.DotNetBar.Office2007Form
    {

        // ================================ Xiao Jun =========================================
        /// <summary>
        /// ����ʵ��
        /// </summary>
        private InPatientInfo inPatient;

        /// <summary>
        /// ������ҳ��������
        /// </summary>
        frmCases_First frmCaseFirst;
        ColumnInfo[] cols = new ColumnInfo[6];
        /// <summary>
        /// ������İ�ť
        /// </summary>
        DevComponents.DotNetBar.ButtonX btn;

        public FrmCaselist()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="inPatient">����ʵ��</param>
        /// <param name="frmCaseFirst">������ҳ��������</param>
        /// <param name="btn">������İ�ť</param>
        public FrmCaselist(InPatientInfo inPatient, frmCases_First frmCaseFirst, DevComponents.DotNetBar.ButtonX btn,bool _isFree)
        {
            try
            {
                InitializeComponent();
                this.inPatient = inPatient;
                this.frmCaseFirst = frmCaseFirst;
                this.btn = btn;
                this.isFree = _isFree;
            }
            catch
            {
            }
        }
        private string Type;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPatient"></param>
        /// <param name="frmCaseFirst"></param>
        /// <param name="btn"></param>
        /// <param name="_isFree">�Ƿ�����ѡ����ֵ��е����</param>
        /// <param name="_Type">0 ������� 1��ҽ��� 2��ҽ���</param>
        public FrmCaselist(InPatientInfo inPatient, frmCases_First frmCaseFirst, DevComponents.DotNetBar.ButtonX btn,bool _isFree,string _Type)
        {
            try
            {
                InitializeComponent();
                this.inPatient = inPatient;
                this.frmCaseFirst = frmCaseFirst;
                this.btn = btn;
                this.isFree = _isFree;
                this.Type = _Type;
            }
            catch
            {
            }
        }

        private void FrmCaselist_Load(object sender, EventArgs e)
        {
            try
            {
              
            ShowData();

            c1FlexGrid1.SelectionMode = SelectionModeEnum.Row;
              }
            catch
            {
            }
        }

        /// <summary>
        /// ���ݰ�ť���͵Ĳ�ͬ��ʾ����������б�
        /// </summary>
        private void ShowData()
        {
            #region �������
            //            string sql = @"select t2.name,t1.diagnose_name,t1.diagnose_icd10,case t1.primary_order when 'Y' then 'Y' 
//                        else '' end,case t1.in_condition when '1054' then '��' when '1055' then '�ٴ�δȷ��' 
//                        when '1056' then '�������' when '1057' then '��' else '' end,t1.turn_to,t1.id from t_diagnose_item t1 
//                        inner join t_data_code t2 on t1.diagnose_type = t2.id where t1.patient_id = '" + this.inPatient.Id + "'";//t2.name = '��Ժ���' and 

#endregion
//            string sql = @"select t1.id,t1.diagnose_name,t1.diagnose_icd10,case t1.primary_order when 'Y' then 'Y' 
//                                    else '' end,t1.turn_to,t1.id from t_simple_diagnose t1 
//                                     where t1.patient_id ='" + this.inPatient.Id + "'"+
//                                     " order by is_chinese,diagnose_sort";//t2.name = '��Ժ���' and 

            string sql = "select a.id,a.diagnose_icd10,a.diagnose_name,a.diagnose_sort,a.symptoms_name,a.is_chinese from t_simple_diagnose a";
            sql+=" where 1=1";
            if (Type == "1")
            {
                sql += " and (a.is_chinese is null or a.is_chinese!='Y')";
            }
            else if (Type == "2")
            {
                sql += "and a.is_chinese='Y'";
            }
            sql += " and a.patient_id=" + inPatient.Id;
            sql += " order by a.is_chinese,a.diagnose_sort";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("�ò���û�������Ϣ�ɹ�ѡ��!");
                this.Close();
                //return;
            }

            //// ��ѯ�Ƿ��и������,�������ƴ�������,��"|"���
            //foreach (DataRow row in dt.Rows)
            //{
            //    string id = row["id"].ToString();
            //    string sqlTemp = "select trend_diagnose_name from t_trend_diagnose t where t.diagnoseitem_id=" + id;
            //    DataTable dt1 = App.GetDataSet(sqlTemp).Tables[0];
            //    if (dt1.Rows.Count != 0)
            //    {
            //        string temp = string.Empty;
            //        foreach (DataRow row1 in dt1.Rows)
            //        {
            //            temp +="|"+ row1["trend_diagnose_name"].ToString();
            //        }
            //        row["diagnose_name"] = row["diagnose_name"].ToString() + temp;
            //    }

            //}
           //������ҽ��ϸ������
            DataRow []drows = dt.Select("is_chinese is null or is_chinese<>'Y'");
            if (drows.Length > 0)
            {
                foreach (DataRow dr in drows)
                {
                    string id = dr["id"].ToString();
                    string sqlTemp = "select trend_diagnose_name from t_trend_diagnose t where t.diagnoseitem_id=" + id;
                    DataTable dt1 = App.GetDataSet(sqlTemp).Tables[0];
                    if (dt1.Rows.Count != 0)
                    {
                        dr["symptoms_name"] = dt1.Rows[0]["t_trend_diagnose"].ToString();
                    }
                }
            }
            SetTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = c1FlexGrid1.Rows.Add();
                row[1] = dt.Rows[i][0].ToString();
                row[2] = dt.Rows[i][1].ToString();
                row[3] = dt.Rows[i][2].ToString();
                row[4] = dt.Rows[i][3].ToString();
                row[5] = dt.Rows[i][4].ToString();
                row[6] = dt.Rows[i][5].ToString();
            }

            CellUnit();
        }

        private void CellUnit()
        {
            c1FlexGrid1[0, 0] = "��ѡ��";
            c1FlexGrid1[0, 1] = "���ID";
            c1FlexGrid1[0, 2] = "��ϱ���";
            c1FlexGrid1[0, 3] = "�������";
            c1FlexGrid1[0, 4] = "������";
            c1FlexGrid1[0, 5] = "�������";
            c1FlexGrid1[0, 6] = "�Ƿ���ҽ���";
            //c1FlexGrid1[0, 4] = "�Ƿ���Ҫ���";
            //c1FlexGrid1[0, 4] = "��Ժ����";
            //c1FlexGrid1[0, 6] = "�趨����˳��";
            // c1FlexGrid1[0, 4] = "ת�����";
            //c1FlexGrid1[0, 5] = "���";
            c1FlexGrid1.Cols[0].Width = 50;
            c1FlexGrid1.Cols[1].Width = 80;
            c1FlexGrid1.Cols[2].Width = 80;
            c1FlexGrid1.Cols[3].Width = 150;
            c1FlexGrid1.Cols[4].Width = 50;
            c1FlexGrid1.Cols[5].Width = 150;
            c1FlexGrid1.Cols[6].Width = 100;
            //c1FlexGrid1.Cols[5].Width = 80;
            c1FlexGrid1.Cols[5].AllowEditing = false;
            c1FlexGrid1.Cols[4].Visible = false;
            c1FlexGrid1.Cols[1].Visible = false;
            c1FlexGrid1.Cols[5].Visible = false;
            //c1FlexGrid1.Cols[6].Width = 100;
            //c1FlexGrid1.Cols[7].Width = 70;

            for (int i = 0; i < c1FlexGrid1.Rows.Count; i++)
            {
                for (int j = 0; j < c1FlexGrid1.Cols.Count; j++)
                {
                    CellRange cr = c1FlexGrid1.GetCellRange(i, j);
                    if (i != 0 && j == 0)
                    {
                        cr.StyleNew.DataType = typeof(bool);
                        c1FlexGrid1[i, j] = false;
                    }
                    cr.StyleNew.TextAlign = TextAlignEnum.CenterCenter;
                    c1FlexGrid1.MergedRanges.Add(cr);
                }
            }
            c1FlexGrid1.Cols[0].ImageAlign = ImageAlignEnum.CenterCenter;
        }

        /// <summary>
        /// ���ñ��ı�ͷ�м��̶�����
        /// </summary>
        private void SetTable()
        {
            c1FlexGrid1.Cols.Count = 7;
            c1FlexGrid1.Rows.Count = 1;
            c1FlexGrid1.Rows.Fixed = 1;
            c1FlexGrid1.Cols.Fixed = 0;
            c1FlexGrid1.MergedRanges.Clear(); // ��Ҫ,��ʽ�����,��ҳ������ʾ��ʽ���쳣
        }

        /// <summary>
        /// ���ݱ�����İ�ť��ͬ��ȷ��Ҫ�޸Ĳ�����ҳ��Щ�ı���
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<Row> rows = GetMuchRows();

            switch (this.btn.Tag.ToString())
            {
                case "�ţ����������":
                    if (rows.Count != 1)
                    {
                        MessageBox.Show("ѡ�����,����ѡ��һ�������ֻ��ѡ��һ�����!");
                        return;
                    }
                    frmCaseFirst.txtEmergencyDiagnose.Text = rows[0][3].ToString();
                    frmCaseFirst.txtEmergencyCode.Text = rows[0][2].ToString();
                    if (rows[0][6].ToString() == "Y")
                    {
                        //if (rows[0][5].ToString().Length > 0)
                        //{
                        //    frmCaseFirst.txtEmergencyDiagnose.Text += "��" + rows[0][5].ToString();
                        //}
                        frmCaseFirst.InitMZValidation();
                        frmCaseFirst.cboxMZ.Checked = true;
                    }
                    else
                    {
                        frmCaseFirst.InitMZValidation();
                        frmCaseFirst.cboxMZ.Checked = false;
                    }
                    break;
                case "�������":
                    if (rows.Count != 1)
                    {
                        MessageBox.Show("ѡ�����,����ѡ��һ�������ֻ��ѡ��һ�����!");
                        return;
                    }
                    frmCaseFirst.txtPathology.Text = rows[0][3].ToString();
                    frmCaseFirst.txtPathologyCode.Text = rows[0][2].ToString();
                    break;
                case "��Ҫ���":
                    if (rows.Count > 0)
                    {
                        frmCaseFirst.txtMajorDiagnose.Text = rows[0][3].ToString();
                        frmCaseFirst.txtMajorDiagnoseCode.Text = rows[0][2].ToString();
                        if (rows[0][6].ToString() == "Y")
                        {
                            //if (rows[0][5].ToString().Length > 0)
                            //{
                            //    frmCaseFirst.txtMajorDiagnose.Text += "��" + rows[0][5].ToString();
                            //}
                            frmCaseFirst.InitZYValidation();
                            frmCaseFirst.cboxZY.Checked = true;
                        }
                        else
                        {
                            frmCaseFirst.InitZYValidation();
                            frmCaseFirst.cboxZY.Checked = false;
                        }
                        //string sTemp="";//= rows[0][4].ToString();
                        //if (sTemp.Length == 0)
                        //{
                        //    frmCaseFirst.cboMajorPatientCondition.SelectedIndex = -1;
                        //}
                        //else
                        //{
                        //    frmCaseFirst.cboMajorPatientCondition.Text = sTemp;
                        //}

                        //sTemp = rows[0][4].ToString();
                        //if (sTemp == "����" || sTemp == "��ת" || sTemp == "δ��")
                        //{
                        //    frmCaseFirst.cboTurnTo.Text = sTemp;
                        //}
                        //else
                        //{
                        //    frmCaseFirst.cboTurnTo.SelectedIndex = -1;
                        //}

                    }
                    else
                    {
                        frmCaseFirst.txtMajorDiagnose.Text = "";
                        frmCaseFirst.txtMajorDiagnoseCode.Text = "";
                        frmCaseFirst.cboMajorPatientCondition.SelectedIndex = -1;
                        frmCaseFirst.cboTurnTo.SelectedIndex = -1;
                    }
                    break;
                case "�������":
                    // ����֧��18���������
                    if (rows.Count > 18)
                    {
                        MessageBox.Show("ѡ�����Ϲ���,Ŀǰ���ɹ�ѡ��18���������!");
                        return;
                    }

                    // ��������пؼ���ֵ
                    ClearGroup(this.frmCaseFirst.grpOtherDiagnose);

                    // ���趨������˳���������
                    //rows.Sort(CompareRow);

                    // �������е�ѡ����,��������Ϸ����е��û��ؼ���ֵ
                    int j=0;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        ucOtherDiagnose uc = frmCaseFirst.grpOtherDiagnose.Controls[j] as ucOtherDiagnose;
                        j++;
                        if (uc == null)
                        {
                            i--;
                            continue;
                        }
                        uc.OtherDiagnose = rows[i][3].ToString();
                        uc.ICD10 = rows[i][2].ToString();
                        if (rows[i][6].ToString() == "Y")
                        {
                            //if (rows[i][5].ToString().Length > 0)
                            //{
                            //    uc.OtherDiagnose += "��" + rows[i][5].ToString();
                            //}
                            uc.SetCheckBox(true);
                        }
                        else
                        {
                            uc.SetCheckBox(false);
                        }
                        //uc.InCondition = true;// = rows[i][4].ToString();
                    }
                    break;
            }
            this.Close();
        }

        /// <summary>
        /// ��������пؼ���ֵ
        /// </summary>
        /// <param name="groupPanel"></param>
        private void ClearGroup(DevComponents.DotNetBar.Controls.GroupPanel groupPanel)
        {
            foreach (Control ctr in groupPanel.Controls)
            {
                ucOtherDiagnose uc = ctr as ucOtherDiagnose;
                if (uc != null)
                {
                    uc.OtherDiagnose = "";
                    uc.ICD10 = "";
                    uc.InCondition = "";
                }
            }
        }

        /// <summary>
        /// ���ض��ѡ����
        /// </summary>
        /// <returns></returns>
        private List<Row> GetMuchRows()
        {
            List<Row> rows = new List<Row>();
            foreach (Row row in c1FlexGrid1.Rows)
            {
                if (row[0].ToString() == "True")
                {
                    rows.Add(row);
                }
            }
            return rows;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Row����ıȽ���
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private int CompareRow(Row row1, Row row2)
        {
            if (row1 == null)
            {
                if (row2 == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (row2 == null)
                {
                    return 1;
                }
                else
                {
                    string sTemp1 = row1[6] == null ? "" : row1[6].ToString();
                    string sTemp2 = row2[6] == null ? "" : row2[6].ToString();
                    if (sTemp1.Length == 0)
                    {
                        return 1;
                    }
                    if (sTemp2.Length == 0)
                    {
                        return -1;
                    }
                    int retval = String.Compare(sTemp1, sTemp2);
                    return retval;
                }
            }
        }

        private bool isFree = false;
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (isFree)
                return;
            if (c1FlexGrid1.Col == 0)
            {
                Row dr = c1FlexGrid1.Rows[c1FlexGrid1.Row];
                if (dr[0].ToString() == bool.TrueString)
                {
                    string sql = "";
                    if (dr[6].ToString() == "Y")
                    {
                        sql = "select count(*) from t_bm where bm_name='" + dr[3].ToString() + "'";
                        string sbm = "";
                        sbm = App.ReadSqlVal(sql, 0, "count(*)");
                        if (sbm == "0")
                        {
                            App.Msg("��ҽ����ֵ���û�д˲���,����д����ҳ�����,����ϵ�����������ϣ�");
                            dr[0] = bool.FalseString;
                        }
                    }
                    else
                    {
                        sql = "select count(*) from diag_def_icd10 where name='" + dr[3].ToString() + "'";
                        if (App.ReadSqlVal(sql, 0, "count(*)") == "0")
                        {
                            App.Msg("����ֵ���û�д����,����д����ҳ�����,����ϵ������������!");
                            dr[0] = bool.FalseString;
                        }
                    }
                }
            }
        }
    }
}