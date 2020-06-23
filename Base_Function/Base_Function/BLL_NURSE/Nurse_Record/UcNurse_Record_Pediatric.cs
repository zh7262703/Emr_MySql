using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using Base_Function.BLL_NURSE.Nereuse_record;
using System.Collections.Specialized;
using Base_Function.MODEL;
using System.Collections;
using Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls;
using System.Threading;

namespace Base_Function.BLL_NURSE.Nurse_Record
{
    public partial class UcNurse_Record_Pediatric : UserControl
    {
        /// <summary>
        /// �������ֵ�
        /// ��:������
        /// ֵ:��Ŀ����
        /// </summary>
        Dictionary<int, string> dictColumnName = new Dictionary<int, string>();
        ColumnInfo[] cols = new ColumnInfo[28];
        /// <summary>
        /// �����¼���ж���ļ���
        /// </summary>
        ArrayList nurses = new ArrayList();
        ArrayList SumNusers = new ArrayList();
        ArrayList SumNusersRecords = new ArrayList();
        
        #region �ֵ�
        ListDictionary ldSickLevel = new ListDictionary();//����̶�
        ListDictionary ldConsciousness = new ListDictionary();//��ʶ�ֵ�
        ListDictionary ldDuct_name = new ListDictionary();//���ֹܵ������ֵ�
        ListDictionary ldDuct_values = new ListDictionary();//���ֹܵ�����ֵ� 
        ListDictionary ldSafenurse = new ListDictionary();//��ȫ����
        ListDictionary ldSkin = new ListDictionary();//Ƥ��
        ListDictionary ldXY = new ListDictionary();//����
        ListDictionary ldNurseLevel = new ListDictionary();//������
        #endregion

        #region �Զ���ֵ
        //�����Զ���ֵ
        public string pipe1 = "";
        //�����Զ���ֵ
        public string pipe2 = "";
        #endregion
        /// <summary>
        /// ���
        /// </summary>
        public string diagnose = "";
        /// <summary>
        /// ��������
        /// </summary>
        private string oldInputName = "";

        /// <summary>
        /// ��ǰ����
        /// </summary>
        InPatientInfo currentPatient = null;

        /// <summary>
        /// �����¼������
        /// </summary>
        private string strType;

        Class_Take_over_SEQ[] Take_over_seq;

        public UcNurse_Record_Pediatric()
        {
            InitializeComponent();
        }

        public UcNurse_Record_Pediatric(InPatientInfo patient)
        {
            InitializeComponent();
            strType = "C";
            currentPatient = patient;
            Take_over_SEQ();//�󶨰��
            SetCellData();//�󶨵�Ԫ������
            LoadDiagnose();
        }

        private void UcNurse_Record_Pediatric_Load(object sender, EventArgs e)
        {
            lblDatePriview.Text = App.GetSystemTime().AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + App.GetSystemTime().AddDays(1).ToShortDateString();
            bindColData();
            SetDictionaryForItem();
            cboTiming_SelectedIndexChanged(sender, e);//����ͳ����ʱ��
            btnSearch_Click(sender, e);
            ShowMsg();
        }

        /// <summary>
        /// �󶨰�α�
        /// </summary>
        private void Take_over_SEQ()
        {
            //DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ where id<7 or id=11 order by ID asc");
            DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ order by SEQ asc");
            Take_over_seq = new Class_Take_over_SEQ[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Take_over_seq[i] = new Class_Take_over_SEQ();
                Take_over_seq[i].Id = ds.Tables[0].Rows[i]["id"].ToString();
                Take_over_seq[i].Seq = ds.Tables[0].Rows[i]["SEQ"].ToString();
                Take_over_seq[i].Begin_time = ds.Tables[0].Rows[i]["BEGIN_TIME"].ToString();
                Take_over_seq[i].End_time = ds.Tables[0].Rows[i]["END_TIME"].ToString();
                Take_over_seq[i].Begin_logic = ds.Tables[0].Rows[i]["BEGIN_LOGIC"].ToString();
                Take_over_seq[i].End_logic = ds.Tables[0].Rows[i]["END_LOGIC"].ToString();
                cboTiming.Items.Add(Take_over_seq[i]);
                cboTiming.DisplayMember = "SEQ";
            }
            if (cboTiming.Items.Count > 0)
            {
                cboTiming.SelectedIndex = 0;
            }
            //cboTiming.Text = "24Сʱ������";
        }

        /// <summary>
        /// ������Ŀ�ֵ�
        /// </summary>
        public void SetDictionaryForItem()
        {
            dictColumnName.Add(0, "����ʱ��");
            dictColumnName.Add(1, "����̶�");
            dictColumnName.Add(2, "������");
            dictColumnName.Add(3, "��ʶ");
            dictColumnName.Add(4, "��");
            dictColumnName.Add(5, "��");
            dictColumnName.Add(6, "T");
            dictColumnName.Add(7, "P");
            dictColumnName.Add(8, "HR");
            dictColumnName.Add(9, "R");
            dictColumnName.Add(10, "BP");
            dictColumnName.Add(11, "Ѫ�����Ͷ�");
            dictColumnName.Add(12, "��������");
            dictColumnName.Add(13, "������");
            dictColumnName.Add(14, "�����Զ���ֵ");
            dictColumnName.Add(15, "���");
            dictColumnName.Add(16, "С��");
            dictColumnName.Add(17, "��������");
            dictColumnName.Add(18, "�����Զ���ֵ");
            dictColumnName.Add(19, "�ܵ�����");
            dictColumnName.Add(20, "�ܵ����");
            dictColumnName.Add(21, "Ƥ��");
            dictColumnName.Add(22, "������ʽ");
            dictColumnName.Add(23, "��������");
            dictColumnName.Add(24, "��ȫ����");
            dictColumnName.Add(25, "��ע");
            dictColumnName.Add(26, "ǩ��");
        }

        #region �������
        /// <summary>
        /// ������
        /// </summary>
        public void ShowData()
        {
            //SetTable();
            nurses.Clear();
            pipe1 = "";
            pipe2 = "";

            #region ���ݼ���
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");
            //or to_char(a.id)=t.item_code
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where RECORD_TYPE='"+strType+"' and t.patient_Id=" + currentPatient.Id + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "' order by DATETIMEVAL asc";
            string sql_set = "select t.id,to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on  a.item_code=t.item_code  left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where RECORD_TYPE='"+strType+"' and patient_Id=" + currentPatient.Id + " order by t.create_time asc ";
            //ʱ�伯��
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            //��Ŀ����
            DataSet ds_values_sets = App.GetDataSet(sql_set);

            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                    //������Ŀ����
                    DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                    //����
                    DataRow[] drinput = dt_sets.Select("item_show_name='����' and DATETIMEVAL='" + dateTimeValue + "'");
                    int index = drinput.Length;
                    if (index == 0)
                    {
                        index = 1;
                    }
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Pediatric temp = new Class_Nurse_Record_Pediatric();
                        temp.DateTime = dateTimeValue;
                        if (drinput.Length > 0)
                        {
                            temp.Inputname = drinput[j]["item_code"].ToString();
                            temp.Inputvalue = drinput[j]["item_value"].ToString();
                            temp.Number = drinput[j]["id"].ToString();
                        }

                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//��������Ŀֻ�ڵ�һ����ʾ
                            {
                                if (dr_Values[k]["item_show_name"].ToString() == "����̶�")
                                {
                                    temp.Sick_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "������")
                                {
                                    temp.Nurse_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��ʶ")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                {
                                    temp.Left = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                {
                                    temp.Right = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "T")
                                {
                                    temp.T = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "P")
                                {
                                    temp.P = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "HR")
                                {
                                    temp.HR = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "R")
                                {
                                    temp.R = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "BP")
                                {
                                    temp.Bp = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "Ѫ�����Ͷ�")
                                {
                                    temp.Oxygen_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                //{
                                //    temp.Inputname = dr_Values[k]["item_code"].ToString();
                                //    temp.Inputvalue = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "�����Զ���ֵ")
                                {
                                    temp.Inputother = dr_Values[k]["item_value"].ToString();
                                    pipe1 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���")
                                {
                                    temp.Shit = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "С��")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��������")
                                {
                                    temp.Outother = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "�����Զ���ֵ")
                                {
                                    temp.Out_item_name = dr_Values[k]["item_value"].ToString();
                                    pipe2 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "�ܵ�")
                                {
                                    temp.Duct_item_name = dr_Values[k]["item_code"].ToString();
                                    temp.Duct_item_values = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "Ƥ��")
                                {
                                    temp.Skin = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��ȫ����")
                                {
                                    temp.Safenurse = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Oxygen = dr_Values[k]["item_code"].ToString();
                                    temp.Oxygen_value = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��ע")
                                {
                                    temp.Nurse_result = dr_Values[k]["item_value"].ToString();
                                }
                                
                            }
                            if (j == index - 1)
                            {
                                temp.Signature = dr_Values[k]["user_name"].ToString();
                            }
                        }
                        nurses.Add(temp);
                    }
                }

                //������ͬ��ʱ��
                string tempDateTime = null;
                Class_Nurse_Record_Pediatric[] nurse = new Class_Nurse_Record_Pediatric[nurses.Count];
                for (int i = 0; i < nurses.Count; i++)
                {
                    nurse[i] = new Class_Nurse_Record_Pediatric();
                    nurse[i] = nurses[i] as Class_Nurse_Record_Pediatric;

                    if (tempDateTime == null)
                    {
                        tempDateTime = nurse[i].DateTime;
                    }
                    else if (tempDateTime != null)
                    {
                        if (nurse[i].DateTime == tempDateTime)//��ͬ��ʱ�䲻��ʾ
                        {
                            nurse[i].DateTime = null;
                        }
                        else
                        {
                            tempDateTime = nurse[i].DateTime;
                        }

                    }
                }
                SetTable();
                try
                {
                    if (nurse.Length != 0)
                    {
                        //nurse[nurse.Length - 1] = new Class_Nurse_Record_Pediatric();
                        App.ArrayToGrid(this.flgView, nurse, cols, 3);
                    }
                    else
                    {
                        this.flgView.Rows.Count = 3;
                    }
                }
                catch
                {
                }
                CellUnit(pipe1, pipe2);
                //this.flgView.Refresh();
                this.flgView.AutoSizeCols();
                this.flgView.AutoSizeRows();
            }

            #endregion

        }

        /// <summary>
        /// ��ͷ����
        /// </summary>
        private void SetTable()
        {
            
            this.flgView.Cols.Count = 28;
            this.flgView.Rows.Count = 4 + nurses.Count;
            this.flgView.Rows.Fixed = 3;
            //��ͷ����
            cols[0].Name = "����ʱ��";
            cols[0].Field = "dateTime";
            cols[0].Index = 1;
            cols[0].visible = true;

            //����̶�
            cols[1].Name = "����̶�";
            cols[1].Field = "sick_level";
            cols[1].Index = 2;
            cols[1].visible = true;

            //������
            cols[2].Name = "������";
            cols[2].Field = "nurse_level";
            cols[2].Index = 3;
            cols[2].visible = true;

            //��ʶ
            cols[3].Name = "��ʶ";
            cols[3].Field = "consciousness";
            cols[3].Index = 4;
            cols[3].visible = true;

            //ͫ����
            cols[4].Name = "��";
            cols[4].Field = "left";
            cols[4].Index = 5;
            cols[4].visible = true;

            //ͫ����
            cols[5].Name = "��";
            cols[5].Field = "right";
            cols[5].Index = 6;
            cols[5].visible = true;

            //����
            cols[6].Name = "T";
            cols[6].Field = "t";
            cols[6].Index = 7;
            cols[6].visible = true;

            //����
            cols[7].Name = "P";
            cols[7].Field = "p";
            cols[7].Index = 8;
            cols[7].visible = true;

            //����
            cols[8].Name = "HR";
            cols[8].Field = "hr";
            cols[8].Index = 9;
            cols[8].visible = true;

            //����
            cols[9].Name = "R";
            cols[9].Field = "r";
            cols[9].Index = 10;
            cols[9].visible = true;

            //Ѫѹ
            cols[10].Name = "BP";
            cols[10].Field = "bp";
            cols[10].Index = 11;
            cols[10].visible = true;

            //Ѫ�����Ͷ�
            cols[11].Name = "Ѫ�����Ͷ�";
            cols[11].Field = "oxygen_saturation";
            cols[11].Index = 12;
            cols[11].visible = true;

            //��������
            cols[12].Name = "��������";
            cols[12].Field = "inputname";
            cols[12].Index = 13;
            cols[12].visible = true;

            //������
            cols[13].Name = "������";
            cols[13].Field = "inputvalue";
            cols[13].Index = 14;
            cols[13].visible = true;

            //�����Զ�����
            cols[14].Name = "�����Զ���ֵ";
            cols[14].Field = "inputother";
            cols[14].Index = 15;
            cols[14].visible = true;

            //���
            cols[15].Name = "���";
            cols[15].Field = "shit";
            cols[15].Index = 16;
            cols[15].visible = true;

            //С��
            cols[16].Name = "С��";
            cols[16].Field = "urine";
            cols[16].Index = 17;
            cols[16].visible = true;

            //��������
            cols[17].Name = "��������";
            cols[17].Field = "outother";
            cols[17].Index = 18;
            cols[17].visible = true;

            //�����Զ���ֵ
            cols[18].Name = "�����Զ���ֵ";
            cols[18].Field = "out_item_name";
            cols[18].Index = 19;
            cols[18].visible = true;

            //�ܵ�����
            cols[19].Name = "�ܵ�����";
            cols[19].Field = "duct_item_name";
            cols[19].Index = 20;
            cols[19].visible = true;

            //�ܵ����
            cols[20].Name = "�ܵ����";
            cols[20].Field = "duct_item_values";
            cols[20].Index = 21;
            cols[20].visible = true;

            //Ƥ��
            cols[21].Name = "Ƥ��";
            cols[21].Field = "skin";
            cols[21].Index = 22;
            cols[21].visible = true;

            //����
            cols[22].Name = "������ʽ";
            cols[22].Field = "oxygen";
            cols[22].Index = 23;
            cols[22].visible = true;

            //����
            cols[23].Name = "��������";
            cols[23].Field = "oxygen_value";
            cols[23].Index = 24;
            cols[23].visible = true;

            //��ȫ����
            cols[24].Name = "��ȫ����";
            cols[24].Field = "safenurse";
            cols[24].Index = 25;
            cols[24].visible = true;
            
            //��ע
            cols[25].Name = "��ע";
            cols[25].Field = "nurse_result";
            cols[25].Index = 26;
            cols[25].visible = true;

            //ǩ��
            cols[26].Name = "ǩ��";
            cols[26].Field = "signature";
            cols[26].Index = 27;
            cols[26].visible = true;

            cols[27].Name = "SumID";
            cols[27].Field = "Number";
            cols[27].Index = 28;
            cols[27].visible = false;
        }

        /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        /// <param name="pipe1">xx�����Զ���1</param>
        /// <param name="pipe2">xx�����Զ���2</param>
        private void CellUnit(string pipe1, string pipe2)
        {
            this.flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            this.flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = this.flgView.GetCellRange(0, 0, 2, 0);
            cr.Data = "�� ʱ\r\n/\r\n�� ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 1, 2, 1);
            cr.Data = "��\r\n��\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 2, 2, 2);
            cr.Data = "��\r\n��\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 3, 2, 3);
            cr.Data = "��\r\nʶ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 4, 0, 5);
            cr.Data = "ͫ  ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 4, 2, 4);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 5, 2, 5);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            //��������
            cr = this.flgView.GetCellRange(0, 6, 0, 10);
            cr.Data = "��������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 6, 2, 6);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 7, 2, 7);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 8, 2, 8);
            cr.Data = "HR";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 9, 2, 9);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 10, 2, 10);
            cr.Data = "BP";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 11, 2, 11);
            cr.Data = "Ѫ��\r\n����\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            //����
            cr = this.flgView.GetCellRange(0,12, 0, 14);
            cr.Data = "����(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 12, 2, 12);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 13, 2, 13);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 14, 2, 14);
            cr.Data = pipe1;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);


            //����
            cr = this.flgView.GetCellRange(0, 15, 0, 18);
            cr.Data = "����(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 15, 2, 15);
            cr.Data = "���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 16, 2, 16);
            cr.Data = "С��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 17, 2, 17);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 18, 2, 18);
            cr.Data = pipe2;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            //���ֹܵ�
            cr = this.flgView.GetCellRange(0, 19, 0, 20);
            cr.Data = "�ܵ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 19, 2, 19);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 20, 2, 20);
            cr.Data = "���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 21, 2, 21);
            cr.Data = "Ƥ\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 22, 2, 22);
            cr.Data = "��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 23, 2, 23);
            cr.Data = "��\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 24, 2, 24);
            cr.Data = "��\r\nȫ\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 25, 2, 25);
            cr.Data = "��ע";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 26, 2, 26);
            cr.Data = "ǩ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            flgView.Cols[1].Width = 35;
            flgView.Cols[22].Width = 35;
            flgView.Cols[25].Width = 100;

        }

        private void SetCellData()
        {
            //�����ֵ䣺927������ʽ
            string sql_Nurse = "select item_code,item_name,item_type,item_unit from t_nurse_record_dict where item_type=927";
            DataSet ds_Nurse = App.GetDataSet(sql_Nurse);
            //�����ֵ䣺��ͯ��ʶ 205       ����ܵ����� 203   ����ܵ���� 204 ������ʽ927
            string sql_Data = "select code,name,type from t_data_code where type in(196,197,203,204,927) order by id asc";
            try
            {
                DataSet ds_Data = App.GetDataSet(sql_Data);

                if (ds_Data != null&&ds_Nurse!=null)
                {
                    //��ʶ
                    DataRow[] dr = ds_Data.Tables[0].Select("type='196'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        ldConsciousness.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                    }
                    ldConsciousness.Add("nul", " ");
                    //������ʽ
                    dr = ds_Nurse.Tables[0].Select("item_type='927'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        ldXY.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                    }
                    ldXY.Add("nul", " ");
                    //����̶�
                    ldSickLevel.Add("0", "��Σ");
                    ldSickLevel.Add("1", "����");
                    ldSickLevel.Add("2", "һ��");
                    ldSickLevel.Add("nul", " ");
                    //������
                    //ldNurseLevel.Add("0", "I");
                    //ldNurseLevel.Add("1", "II");
                    //ldNurseLevel.Add("2", "III");
                    //ldNurseLevel.Add("3", "��");
                    //ldNurseLevel.Add("nul", " ");
                    //������
                    dr = ds_Data.Tables[0].Select("type='197'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        ldNurseLevel.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                    }
                    ldNurseLevel.Add("nul", " ");
                    //��ȫ����
                    ldSafenurse.Add("0", "��");;
                    ldSafenurse.Add("nul", " ");
                    //Ƥ��
                    ldSkin.Add("0", "��");
                    ldSkin.Add("1", "��");
                    ldSkin.Add("nul", " ");
                }

            }
            catch (Exception ex)
            {
                App.Msg("ע��:���ƻ����¼�������ֵ����ʧ��!");
            }
        }

        /// <summary>
        /// �󶨱������
        /// </summary>
        private void bindColData()
        {
            try
            {
                //����̶�
                this.flgView.Cols[1].DataMap = ldSickLevel;
                //������
                this.flgView.Cols[2].DataMap = ldNurseLevel;
                //��ʶ
                this.flgView.Cols[3].DataMap = ldConsciousness;

                //������ʽ
                this.flgView.Cols[22].DataMap = ldXY;

                //Ƥ��
                this.flgView.Cols[21].DataMap = ldSkin;

                //��ȫ����
                this.flgView.Cols[24].DataMap = ldSafenurse;


            }
            catch
            { }
        }
        #endregion

        #region ��ӡ�Ű�����
        /// <summary>
        /// ���ݴ�ӡʱ��Ҫ����Ԫ���Ȼ���
        /// </summary>
        /// <param name="ds"></param>
        public DataSet ReSetPrintDataSet(DataSet ds)
        {
            ArrayList DataRows = new ArrayList();          
            int maxcount = 0;
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and RECORD_TYPE='" + strType + "' order by DATETIMEVAL asc";
            DataSet ds_Time = App.GetDataSet(sql_time);
            if (ds_Time != null)
            {
                for (int i = 0; i < ds_Time.Tables[0].Rows.Count; i++)
                {
                    ArrayList drDatarows = new ArrayList();
                    for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
                    {
                        if (!ds.Tables[0].Rows[i1]["inputname"].ToString().Contains("С��") &&
                           !ds.Tables[0].Rows[i1]["inputname"].ToString().Contains("������") &&
                           !ds.Tables[0].Rows[i1]["inputname"].ToString().Contains("�ܽ�"))
                        {

                            if (ds.Tables[0].Rows[i1]["datetime"].ToString() == ds_Time.Tables[0].Rows[i]["datetimeval"].ToString())
                            {
                                drDatarows.Add(ds.Tables[0].Rows[i1]);
                            }
                        }
                    }

                    DataRow[] drArray = new DataRow[drDatarows.Count];
                    for (int i1 = 0; i1 < drDatarows.Count; i1++)
                    {
                        drArray[i1] = (DataRow)drDatarows[i1];
                    }
                    if (drArray.Length != 0)
                    {
                        //���㱸ע����
                        int rownurseresult = 33;//��ӡʱ��ע��ʾ���ַ�����
                        List<string> nurseresultlist = new List<string>();
                        
                        string signature = "";
                        maxcount = drArray.Length;
                        if (drArray[0]["nurse_result"] != null && drArray[0]["nurse_result"].ToString().Length>0)
                        {
                            GetRowNurseResult(drArray[0]["nurse_result"].ToString(), rownurseresult, ref nurseresultlist);
                            maxcount = (maxcount > nurseresultlist.Count ? maxcount : nurseresultlist.Count);
                        }
                        for (int j = 0; j < maxcount; j++)
                        {
                            //��ע�Զ�����
                            if (j <= drArray.Length - 1)
                            {
                                //���ǩ��
                                if (drArray[j]["Signature"].ToString() != "")
                                {
                                    signature = drArray[j]["Signature"].ToString();
                                    drArray[j]["Signature"] = "";
                                }
                                if (j <= nurseresultlist.Count - 1)
                                    drArray[j]["nurse_result"] = nurseresultlist[j];
                                if (j == maxcount - 1)
                                    drArray[j]["Signature"] = signature;
                                DataRows.Add(drArray[j]);
                            }
                            else
                            {
                                if (j == maxcount - 1)
                                {
                                    DataRow dr = ds.Tables[0].NewRow();
                                    dr["Signature"] = signature;
                                    if (j <= nurseresultlist.Count - 1)
                                    {
                                        dr["nurse_result"] = nurseresultlist[j];
                                    }
                                    DataRows.Add(dr);
                                }
                                else
                                {
                                    DataRow dr = ds.Tables[0].NewRow();
                                    dr["Signature"] = "";
                                    if (j <= nurseresultlist.Count - 1)
                                    {
                                        dr["nurse_result"] = nurseresultlist[j];
                                    }
                                    DataRows.Add(dr);
                                }
                            }
                        }
                    }

                }
            }
            

            /*
             * �������ݼ���
             */
            DataTable dd = new DataTable();
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                dd.Columns.Add(ds.Tables[0].Columns[i].ColumnName);
            }

            for (int i = 0; i < DataRows.Count; i++)
            {
                DataRow temprow1 = dd.NewRow();
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {

                    DataRow norow = (DataRow)DataRows[i];
                    string t = norow[ds.Tables[0].Columns[j].ColumnName].ToString();


                    if (norow[ds.Tables[0].Columns[j].ColumnName].ToString().IndexOf('@') > -1)
                    {

                        temprow1[ds.Tables[0].Columns[j].ColumnName] = norow[ds.Tables[0].Columns[j].ColumnName].ToString().Split('@')[0].ToString();
                    }
                    else
                    {
                        temprow1[ds.Tables[0].Columns[j].ColumnName] = norow[ds.Tables[0].Columns[j].ColumnName].ToString();
                    }
                }
                dd.Rows.Add(temprow1);
            }


            #region �������
            string currentTime = "";
            for (int i = 0; i < dd.Rows.Count; i++)
            {
                if (dd.Rows[i]["datetime"].ToString() != "")
                {
                    currentTime = dd.Rows[i]["datetime"].ToString();
                }
                else
                {
                    dd.Rows[i]["datetime"] = currentTime;
                }
            }

            DataRow[] drSum = ds.Tables[0].Select("inputname like '%������%' or inputname like '%С��%' or inputname like '%�ܽ�%'");
            for (int i = 0; i < drSum.Length; i++)
            {
                string endLogic = App.ReadSqlVal("select end_logic from T_TAKE_OVER_SEQ a inner join t_nurse_dangery_inout_sum_h b on a.id=b.seq_id where b.id=" + drSum[i]["number"].ToString(), 0, "end_logic");
                //dd.ImportRow(drSum[i]);
                DateTime sumTime = Convert.ToDateTime(drSum[i]["datetime"]);
                for (int j = 0; j < dd.Rows.Count; j++)
                {
                    DateTime itemTime = Convert.ToDateTime(dd.Rows[j]["datetime"]);
                    if (itemTime == sumTime)
                    {
                        if (endLogic == "0")
                        {
                            DataRow dr = dd.NewRow();
                            dr.ItemArray = drSum[i].ItemArray;
                            dd.Rows.InsertAt(dr, j);
                            break;
                        }
                        else
                        {
                            if (j < dd.Rows.Count - 1)
                            {
                                DateTime nextTime = Convert.ToDateTime(dd.Rows[j + 1]["datetime"]);
                                if (nextTime != itemTime)
                                {
                                    DataRow dr = dd.NewRow();
                                    dr.ItemArray = drSum[i].ItemArray;
                                    dd.Rows.InsertAt(dr, j + 1);
                                    break;
                                }
                            }
                        }
                    }
                    else if (itemTime > sumTime)
                    {
                        DataRow dr = dd.NewRow();
                        dr.ItemArray = drSum[i].ItemArray;
                        dd.Rows.InsertAt(dr, j);
                        break;
                    }
                    if (j == dd.Rows.Count - 1)
                    {
                        DataRow dr = dd.NewRow();
                        dr.ItemArray = drSum[i].ItemArray;
                        dd.Rows.InsertAt(dr, j + 1);
                        break;
                    }
                }
            }
            //dd.DefaultView.Sort = "datetime asc";
            //dd = dd.DefaultView.ToTable();
            #endregion
            #region ����ʱ���ʽ

            string tempDate = "";//����
            string tempTime = "";//ʱ��
            int pageRows=21;
            DataColumn dc = new DataColumn("Date");
            dd.Columns.Add(dc);
            dc = new DataColumn("Time");
            dd.Columns.Add(dc);
            //����ʱ����ʾ��ʽ,������ֻͬ��ʾ��һ�����ڣ�����ֻͬ��ʾ��һ�з�
            for (int i = 0; i < dd.Rows.Count; i++)
            {
                if (i % pageRows == 0)
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                        dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                        dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                        tempDate = currDate.ToString("yyyy-MM-dd");
                        tempTime = currDate.ToString("HH:mm");
                    }
                    continue;
                }
                if (!dd.Rows[i]["inputname"].ToString().Contains("С��") &&
                    !dd.Rows[i]["inputname"].ToString().Contains("�ܽ�") &&
                    !dd.Rows[i]["inputname"].ToString().Contains("������"))
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        if (tempDate == "")
                        {
                            //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                            dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                            dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                            continue;
                        }
                        if (tempDate == currDate.ToString("yyyy-MM-dd") && tempTime == currDate.ToString("HH:mm"))//������ʱ�䶼��ͬ������ʵ
                        {
                            //dd.Rows[i]["datetime"] = "";
                            dd.Rows[i]["Date"] = "";
                            dd.Rows[i]["Time"] = "";
                        }
                        else if (tempDate == currDate.ToString("yyyy-MM-dd"))//������ͬ����ʾСʱ�ͷ�
                        {
                            //dd.Rows[i]["datetime"] = currDate.ToString("HH:mm");
                            dd.Rows[i]["Date"] = "";
                            dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                            tempTime = currDate.ToString("HH:mm");
                        }
                        else//��ͬ������ʾ���� Сʱ ��
                        {
                            //dd.Rows[i]["datetime"] = currDate.ToString("MM-dd HH:mm");
                            dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                            dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                        }
                    }
                }
                else
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                        dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                        dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                        tempDate = currDate.ToString("yyyy-MM-dd");
                        tempTime = currDate.ToString("HH:mm");
                    }
                    continue;
                }
            }
            #endregion
            DataSet ds2 = new DataSet();
            ds2.Tables.Add(dd);
            return ds2;
        }

        /// <summary>
        /// ���ݱ�ע�ĳ��ȷ���string��������
        /// </summary>
        /// <param name="remark">��ע����</param>
        /// <returns></returns>
        private string[] RemarkArray(string remark)
        {

            Graphics graphics = CreateGraphics();
            SizeF sizeF = graphics.MeasureString(remark, new Font("����", 8));
            //��ע��ռ����
            int remarkRowCount = Convert.ToInt32(Math.Ceiling(sizeF.Width / (45 * 8)));//Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            string[] strArr = new string[remarkRowCount];
            string tempperval = "";
            int index = 0;//�����������
            for (int j = 0; j < remark.Length; j++)
            {
                sizeF = graphics.MeasureString(tempperval, new Font("����", 8));
                if (sizeF.Width <= 45 * 8)
                {
                    if (tempperval == "")
                    {
                        tempperval = remark[j].ToString();
                    }
                    else
                    {
                        tempperval += remark[j];
                    }

                    if (j == remark.Length - 1)
                    {
                        strArr[index] = tempperval;
                        index++;
                        tempperval = "";
                        //j--;
                    }
                }
                else
                {
                    strArr[index] = tempperval;
                    index++;
                    tempperval = "";
                    j--;
                }
            }

            return strArr;
        }
        /// <summary>
        /// ��������ֵ����������
        /// </summary>
        /// <param name="temprow"></param>
        /// <returns></returns>
        private int MaxRowsCount(DataRow temprow)
        {
            Graphics graphics = CreateGraphics();
            int count = 0;
            double widthindex = 10;
            int MaxRowCount = 0;
            for (int i = 0; i < temprow.Table.Columns.Count; i++)
            {

                string perval = "";
                if (temprow.Table.Columns[i].ColumnName.ToLower() == "date" && temprow[i].ToString() != "")
                {

                    temprow[i] = DateTime.Parse(temprow[i].ToString()).ToString("yy/MM/dd");
                }
                for (int j = 0; j < temprow[i].ToString().Length; j++)
                {
                    if (temprow.Table.Columns[i].ColumnName.ToLower() == "remark")
                    {
                        widthindex = 9.1;
                    }


                    //if (temprow.Table.Columns[i].ColumnName.ToLower() == "temperature")
                    //{
                    //    widthindex = 1.5;
                    //}

                    //if (temprow.Table.Columns[i].ColumnName.ToLower() == "date")
                    //{

                    //    widthindex = 2;
                    //}
                    //if (temprow.Table.Columns[i].ColumnName.ToLower() == "pathograhy")
                    //{
                    //    widthindex = 6.7;
                    //}
                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "signature")
                    //{
                    //    widthindex = 6.7;
                    //}
                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "blood_pressure"
                    //    // || temprow.Table.Columns[i].ColumnName.ToLower() == "r_eat_item_name"
                    //    //|| temprow.Table.Columns[i].ColumnName.ToLower() == "c_item_name"
                    //    )
                    //{
                    //    widthindex = 1.5;
                    //}

                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "r_medicine_item_name")
                    //{
                    //    widthindex = 2.6;
                    //    //continue;
                    //}
                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "r_eat_item_name")
                    //{
                    //    widthindex = 2;
                    //}
                    string tempperval = "";

                    tempperval = perval + temprow[i].ToString()[j];

                    SizeF sizeF = graphics.MeasureString(tempperval, new Font("����", 8));

                    if (sizeF.Width <= widthindex * 28.3465)
                    {
                        perval = tempperval;
                        if (j == temprow[i].ToString().Length - 1)
                        {
                            if (perval.Trim() != "")
                            {
                                perval = "";
                                count++;
                            }
                        }

                    }
                    else
                    {
                        perval = "";
                        count++;
                        j = j - 1;
                    }


                }
                if (MaxRowCount < count)
                {
                    MaxRowCount = count;
                }
                count = 0;
            }
            return MaxRowCount;
        }

        string toDay = string.Empty;
        int totalIndex = 0;
        /// <summary>
        /// ��ֵ
        /// </summary>
        /// <param name="temprow">��Ҫ�󶨵���</param>
        /// <param name="index">����</param>
        /// <param name="olddatarow">ԭʼ������</param>
        /// <returns></returns>
        private void BindVal(ref DataRow temprow, int index, DataRow olddatarow)
        {
            Graphics graphics = CreateGraphics();
            int count = 0;
            double widthindex = 10;

            for (int i = 0; i < temprow.Table.Columns.Count; i++)
            {
                string perval = "";
                for (int j = 0; j < olddatarow[i].ToString().Length; j++)
                {
                    if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "remark")
                    {
                        widthindex = 9.1;
                    }

                    //if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "pathograhy")
                    //{
                    //    widthindex = 6.7;
                    //}
                    ////else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "signature")
                    ////{
                    ////    widthindex = 6.7;
                    ////}
                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "blood_pressure"
                    //    )
                    //{
                    //    widthindex = 1.5;
                    //}
                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "r_medicine_item_name")
                    //{
                    //    widthindex = 2.4;
                    //    //continue;
                    //}

                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "date")
                    //{
                    //    widthindex = 2;
                    //}
                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "r_eat_item_name")
                    //{
                    //    widthindex = 2;
                    //}
                    if (temprow.Table.Columns[i].ColumnName.ToLower() != "number")//number
                    {
                        string tempperval = "";
                        //if (i == 20)
                        //{
                        //    tempperval = perval + olddatarow[i].ToString()[j];
                        //}
                        //else
                        //{
                        tempperval = perval + olddatarow[i].ToString()[j];
                        //}

                        SizeF sizeF = graphics.MeasureString(tempperval, new Font("����", 8));
                        if (sizeF.Width <= widthindex * 28.3465)
                        {
                            perval = tempperval;
                            if (j == olddatarow[i].ToString().Length - 1)
                            {
                                //if (i == 20)
                                //{

                                //}
                                if (perval.Trim() != "")
                                {
                                    if (count == index)
                                    {

                                        temprow[i] = perval;
                                        totalIndex++;
                                    }
                                    perval = "";
                                }
                            }
                        }
                        else
                        {
                            if (count == index)
                            {
                                if (perval.EndsWith("@"))
                                {
                                    perval = perval.Substring(0, perval.Length - 1);
                                    j = j - 1;
                                    //count--;
                                }
                                //if (i == 21)
                                //{
                                //    temprow[i] = olddatarow[i].ToString();
                                //}
                                temprow[i] = perval;
                                totalIndex++;
                            }
                            perval = "";
                            count++;
                            j = j - 1;
                        }
                    }
                }
                count = 0;
            }
        }

        /// <summary>
        /// �ѱ�ע��¼����ָ�����Ƚ�ȡ
        /// </summary>
        /// <param name="strNurseResult"></param>
        /// <param name="rowlenth"></param>
        /// <returns></returns>
        private void GetRowNurseResult(string strNurseResult, int rowlenth, ref List<string> list)
        {

            int lenth = Encoding.Default.GetByteCount(strNurseResult);
            if (lenth <= rowlenth)
            {
                list.Add(strNurseResult);
            }
            else
            {
                int i = ((rowlenth > strNurseResult.Length) ? strNurseResult.Length : rowlenth);                
                while (Encoding.Default.GetByteCount(strNurseResult.Substring(0, i)) > rowlenth)
                {
                    i--;
                }
                list.Add(strNurseResult.Substring(0, i));
                strNurseResult = strNurseResult.Remove(0, i);
                GetRowNurseResult(strNurseResult, rowlenth,ref list);
            }
        }

        private static void FormatDisplay(ArrayList DataRows)
        {
            string topTime = string.Empty;
            string date = string.Empty;
            string topDate = string.Empty;
            int year = 0;
            string time = string.Empty;
            string sign = string.Empty;
            string formTime = string.Empty;

            for (int i = 0; i < DataRows.Count; i++)
            {
                DataRow drTemp = DataRows[i] as DataRow;

                string souDate = drTemp[0].ToString();
                if (!string.IsNullOrEmpty(souDate))
                {
                    topDate = souDate;
                    year = Convert.ToInt32(souDate.Substring(0, 2));
                }
                if ((i) % 30 != 0 || i == 1 || i == 0)
                {
                    //û�л�ҳ
                    formTime = string.IsNullOrEmpty(drTemp[1].ToString()) ? formTime : drTemp[1].ToString();
                    if (string.IsNullOrEmpty(topTime))
                    {
                        topTime = formTime;
                    }
                    if (i == 0)
                    {
                        (DataRows[i] as DataRow)[0] = topDate;
                    }
                    if (date == souDate)
                    {
                        (DataRows[i] as DataRow)[0] = "";
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(souDate))
                        {
                            if (!string.IsNullOrEmpty(date))
                            {
                                if (year == Convert.ToInt32(date.Substring(0, 2)))
                                {
                                    (DataRows[i] as DataRow)[0] = souDate.Substring(3, souDate.Length - 3);
                                }
                                else
                                {
                                    (DataRows[i] as DataRow)[0] = souDate;
                                }
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    (DataRows[i] as DataRow)[0] = souDate.Substring(3, souDate.Length - 3);
                                }
                            }
                        }

                    }
                    if (!string.IsNullOrEmpty(souDate))
                    {
                        if (string.IsNullOrEmpty(date))
                        {
                            date = souDate;
                        }
                        else
                        {
                            int dYear = Convert.ToInt32(date.Substring(0, 2));
                            if (year > dYear)
                            {
                                date = year + souDate.Substring(2, souDate.Length - 2);
                            }
                            else
                            {

                                date = souDate;
                            }
                        }
                    }
                }
                else
                {


                    topDate = topDate.Substring(3, topDate.Length - 3);

                    (DataRows[i] as DataRow)[0] = topDate;

                    (DataRows[i] as DataRow)[1] = string.IsNullOrEmpty((DataRows[i] as DataRow)[1].ToString()) ? formTime : (DataRows[i] as DataRow)[1];
                }

                int index = i;
                if (i + 1 == DataRows.Count)
                {
                    continue;
                }
                string currentTime = drTemp[1].ToString();
                string nextTime = string.Empty;
                string nextDate = string.Empty;
                DataRow nextRow = DataRows[index + 1] as DataRow;
                nextTime = nextRow[1].ToString();
                nextDate = nextRow[0].ToString();
                if (string.IsNullOrEmpty(nextTime))
                {
                    time = currentTime;
                    string drugName = string.Empty;
                    drugName = nextRow[11].ToString();
                    if (!string.IsNullOrEmpty(drugName))
                    {
                        sign = (DataRows[index] as DataRow)[17].ToString();
                        (DataRows[index] as DataRow)[17] = string.Empty;
                        (DataRows[index + 1] as DataRow)[17] = sign;
                    }
                }
                else
                {

                    if (nextTime == currentTime)
                    {
                        sign = (DataRows[index] as DataRow)[17].ToString();
                        (DataRows[index] as DataRow)[17] = string.Empty;
                        (DataRows[index + 1] as DataRow)[17] = sign;

                    }
                    if (nextTime == time)
                    {
                        string drugName = drTemp[11].ToString();
                        string undersign = drTemp[17].ToString();
                        if (!string.IsNullOrEmpty(drugName) && !string.IsNullOrEmpty(undersign))
                        {
                            sign = (DataRows[index] as DataRow)[17].ToString();
                            (DataRows[index] as DataRow)[17] = string.Empty;
                            (DataRows[index + 1] as DataRow)[17] = sign;
                        }
                    }

                }

                if (topTime == nextTime)
                {
                    if (topDate == nextDate)
                    {
                        (DataRows[index + 1] as DataRow)[1] = string.Empty;
                    }
                }
                else
                {
                    topTime = string.IsNullOrEmpty(nextTime) ? topTime : nextTime;
                }

            }
        }
        #endregion

        #region ��ӡ
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = GetNusersRecords();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    App.MsgWaring("��ǰ����û�л����¼���ݣ�");
                    return;
                }
            }
            else
            {
                App.MsgWaring("��ǰ����û�л����¼���ݣ�");
                return;
            }
            //��ȡ���
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where RECORD_TYPE='C' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//�Լ��޸ĵĻ���
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='403' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//�������
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='408' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//�������
            }
            if (diagnose == null)
            {
                diagnose = "";
            }
            frmNursePrint_Records ff = new frmNursePrint_Records(ReSetPrintDataSet(ds), currentPatient,diagnose,strType, pipe1, pipe2);
            ff.Show();
        }

        public DataSet GetNusersRecords()
        {
            DataSet ds = null;
            ShowDatas();
            SumInOrOutRecordSets();
            Class_Nurse_Record_Pediatric[] cNurse = new Class_Nurse_Record_Pediatric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                cNurse[i] = new Class_Nurse_Record_Pediatric();
                cNurse[i] = nurses[i] as Class_Nurse_Record_Pediatric;
                //����ת������������
                if (cNurse[i].Consciousness != null)
                    cNurse[i].Consciousness = ldConsciousness[cNurse[i].Consciousness].ToString();
                if (cNurse[i].Skin != null && ldSkin[cNurse[i].Skin]!=null)
                    cNurse[i].Skin = ldSkin[cNurse[i].Skin].ToString();
                if (cNurse[i].Oxygen != null && ldXY[cNurse[i].Oxygen] != null)
                    cNurse[i].Oxygen = ldXY[cNurse[i].Oxygen].ToString();
                if (cNurse[i].Safenurse != null && ldSafenurse[cNurse[i].Safenurse] != null)
                    cNurse[i].Safenurse = ldSafenurse[cNurse[i].Safenurse].ToString();
                
            }
            //string tempDate = "";//����
            //string tempTime = "";//ʱ��
            ////����ʱ����ʾ��ʽ,������ֻͬ��ʾ��һ�����ڣ�����ֻͬ��ʾ��һ�з�
            //for (int i = 0; i < cNurse.Length; i++)
            //{
            //    DateTime currDate = Convert.ToDateTime(cNurse[i].DateTime);
            //    if (tempDate == "")
            //    {
            //        cNurse[i].DateTime = currDate.ToString("MM-dd HH:mm");
            //        tempDate = currDate.ToString("MM-dd");
            //        tempTime = currDate.ToString("HH:mm");
            //        continue;
            //    }
            //    if (tempDate == currDate.ToString("MM-dd") && tempTime == currDate.ToString("HH:mm"))//������ʱ�䶼��ͬ������ʵ
            //    {
            //        cNurse[i].DateTime = "";
            //    }
            //    else if (tempDate == currDate.ToString("MM-dd"))//������ͬ����ʾСʱ�ͷ�
            //    {
            //        cNurse[i].DateTime = currDate.ToString("HH:mm");
            //        tempTime = currDate.ToString("HH:mm");
            //    }
            //    else//��ͬ������ʾ���� Сʱ ��
            //    {
            //        cNurse[i].DateTime = currDate.ToString("MM-dd HH:mm");
            //        tempDate = currDate.ToString("MM-dd");
            //    }

            //}
            ds = App.ObjectArrayToDataSet(cNurse);
            return ds;
        }

        /// <summary>
        /// �󶨴�ӡ����
        /// </summary>
        public void ShowDatas()
        {
            nurses.Clear();
            pipe1 = "";
            pipe2 = "";
            //SetTable();
            #region ���ݼ���
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where RECORD_TYPE='C' and  t.patient_Id=" + currentPatient.Id + " order by DATETIMEVAL asc";
            string sql_set = "select t.id,to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on a.item_code=t.item_code  left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where RECORD_TYPE='C' and patient_Id=" + currentPatient.Id + " order by t.create_time asc ";
            //ʱ�伯��
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            //��Ŀ����
            DataSet ds_values_sets = App.GetDataSet(sql_set);

            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                    //������Ŀ����
                    DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                    //����
                    DataRow[] drinput = dt_sets.Select("item_show_name='����' and DATETIMEVAL='" + dateTimeValue + "'");
                    int index = drinput.Length;
                    if (index == 0)
                    {
                        index = 1;
                    }
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Pediatric temp = new Class_Nurse_Record_Pediatric();
                        temp.DateTime = dateTimeValue;
                        if (drinput.Length > 0)
                        {
                            temp.Inputname = drinput[j]["item_code"].ToString();
                            temp.Inputvalue = drinput[j]["item_value"].ToString();
                            temp.Number = drinput[j]["id"].ToString();
                        }

                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//��������Ŀֻ�ڵ�һ����ʾ
                            {
                                if (dr_Values[k]["item_show_name"].ToString() == "����̶�")
                                {
                                    temp.Sick_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "������")
                                {
                                    temp.Nurse_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��ʶ")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                {
                                    temp.Left = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                {
                                    temp.Right = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "T")
                                {
                                    temp.T = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "P")
                                {
                                    temp.P = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "HR")
                                {
                                    temp.HR = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "R")
                                {
                                    temp.R = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "BP")
                                {
                                    temp.Bp = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "Ѫ�����Ͷ�")
                                {
                                    temp.Oxygen_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                //{
                                //    temp.Inputname = dr_Values[k]["item_code"].ToString();
                                //    temp.Inputvalue = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "�����Զ���ֵ")
                                {
                                    temp.Inputother = dr_Values[k]["item_value"].ToString();
                                    pipe1 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���")
                                {
                                    temp.Shit = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "С��")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��������")
                                {
                                    temp.Outother = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "�����Զ���ֵ")
                                {
                                    temp.Out_item_name = dr_Values[k]["item_value"].ToString();
                                    pipe2 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "�ܵ�")
                                {
                                    temp.Duct_item_name = dr_Values[k]["item_code"].ToString();
                                    temp.Duct_item_values = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "Ƥ��")
                                {
                                    temp.Skin = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��ȫ����")
                                {
                                    temp.Safenurse = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Oxygen = dr_Values[k]["item_code"].ToString();
                                    temp.Oxygen_value = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��ע")
                                {
                                    temp.Nurse_result = dr_Values[k]["item_value"].ToString();
                                }

                            }
                            if (j == index - 1)
                            {
                                temp.Signature = dr_Values[k]["user_name"].ToString();
                            }
                        }
                        nurses.Add(temp);
                    }
                }


            }

            #endregion

        }
        /// <summary>
        /// ���ü������������
        /// </summary>
        private void SumInOrOutRecordSets()
        {
            SumInOrOutRecordSet(false);
        }
        #endregion

        
        /// <summary>
        /// ��ȡ��Ŀ�Ĵ���ʱ��
        /// </summary>
        /// <param name="rowSel">��Ŀ��������</param>
        /// <returns></returns>
        private string GetTime(int rowSel)
        {
            string dateTime = "";
            if (this.flgView[rowSel, 0] != null && this.flgView[rowSel, 0].ToString() != "")
            {
                dateTime = this.flgView[rowSel, 0].ToString();
            }
            else
            {
                dateTime = GetTime(rowSel - 1);
            }

            return dateTime;
        }
        
        #region �����ز���
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            if (e.Col != 1 || e.Col != 22)
            {
                this.flgView.AutoSizeCol(e.Col);
            }

        }
        //ComboBox cb = null;
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            int id = 0;
            if (flgView[e.Row, 27] != null && flgView[e.Row, 27].ToString().Length > 0)
            {
                try
                {
                    id = int.Parse(flgView[e.Row, 27].ToString());
                }
                catch { }
            }
            if (this.flgView[e.Row, 12] != null && (this.flgView[e.Row, 12].ToString().Contains("С��")
                || this.flgView[e.Row, 12].ToString().Contains("�ܽ�")))
            {
                if (id == 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (this.flgView[e.Row, 0] == null && e.Col == 12)
            {
                string measureTime = GetTime(e.Row);
                //��֤Ȩ��
                DateTime objdt;
                if (measureTime != "")//ʱ��Ϊ��˵����������ݣ�������֤Ȩ��
                {
                    if(!DateTime.TryParse(measureTime,out objdt))
                    {
                        FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), strType);
                        fsd.ShowDialog();
                        if (fsd.flag)
                            this.flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                        this.flgView.Col = 0;
                        //e.Cancel = true;
                        return;
                    }
                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                    if (!ValidateUser(operateId))
                    {
                        App.Msg("Ȩ�޲��㣡");
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if ((this.flgView[e.Row, 0] != null && this.flgView[e.Row, 0].ToString() != ""))
            {
                string measureTime = GetTime(e.Row);
                int num = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                if (num > 0)
                {
                    //��֤Ȩ��
                    DateTime objdt;
                    if (measureTime != ""&&DateTime.TryParse(measureTime,out objdt))//ʱ��Ϊ��˵����������ݣ�������֤Ȩ��
                    {
                        string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                        if (!ValidateUser(operateId))
                        {
                            App.Msg("Ȩ�޲��㣡");
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            //if (((this.flgView[e.Row, 0] == null && e.Col != 12) || (this.flgView[e.Row, 0] == null && e.Col != 13)) || e.Row != this.flgView.Rows.Count - 2)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            if ((this.flgView[e.Row, 0] == null || this.flgView[e.Row, 0].ToString() == "") &&
                e.Col != 12 && e.Col != 13 && e.Row != this.flgView.Rows.Count - 1 && this.flgView[e.Row, 12] != null)
            {
                e.Cancel = true;
                return;
            }

            //3���µ�Ԫ���е�ֵ������ֵ���ͣ�������ǻ������ݣ�ȡ���༭
            //if (this.flgView[e.Row, 3] != null && !App.IsNumeric(this.flgView[e.Row, 3].ToString()))
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //ǩ����ֹ�༭
            if (e.Col == 26)
            {
                e.Cancel = true;
                return;
            }
            if ((e.Col != 12 && e.Col != 13) || e.Col == 0)
            {
                //if (this.flgView[e.Row, 0] == null || this.flgView[e.Row, 0].ToString() == "")
                //{
                if (this.flgView[e.Row, 0] == null || this.flgView[e.Row, 0].ToString() == "")
                {
                    //App.Msg("��ѡ�����ʱ�䣡");
                    FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), strType);
                    fsd.ShowDialog();
                    if (fsd.flag)
                        this.flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                    this.flgView.Col = 0;
                    e.Cancel = true;
                    return;
                    //}
                }
                else
                {
                    if (e.Col == 0)
                    {
                        DateTime dt = Convert.ToDateTime(flgView[e.Row, 0].ToString());
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));

                        if (ValidateUser(operateId) || operateId == null)
                        {
                            FrmSetDatetime fsd = new FrmSetDatetime(dt, currentPatient.Id.ToString(),"C");
                            fsd.ShowDialog();
                            if (fsd.flag)
                            {
                                flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                                //flgView.Col = 1;

                                /*
                                 *�޸����ڵ�ʱ�����ж�Ӧ�Ļ����¼��Ҫ�޸�ʱ��
                                 */
                                string sql = "update t_nurse_record t set  t.measure_time=to_timestamp('" +
                                    fsd.Date.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') where measure_time=to_timestamp('" +
                                    dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='C' and patient_id=" + currentPatient.Id.ToString() + "";

                                if (App.ExecuteSQL(sql) == 0 && operateId != null)
                                {
                                    App.MsgErr("�޸�ʱ��û���޸ĳɹ���");
                                }
                            }
                        }
                        else
                        {
                            App.Msg("�޸�Ȩ�޲��㣡");
                        }

                        e.Cancel = true;
                        return;
                    }

                }

            }
            //��֤�������ı����Ƿ�����
            if (e.Col == 14 || e.Col == 18)
            {
                if (this.flgView[1, e.Col] == null || this.flgView[1, e.Col].ToString() == "")
                {
                    �޸ı���ToolStripMenuItem_Click(sender, e);
                }
            }

            //if (flgView.Col == 25)
            //{
            //    this.��ȡ��עģ��ToolStripMenuItem_Click(sender, e);
            //    return;
            //}

            //����������֤���������������ͣ���������ֵ
            if (e.Col == 13)
            {
                if (this.flgView[e.Row, e.Col - 1] == null || this.flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("�������������ƣ�");
                    this.flgView.Col = 12;
                    return;
                }
            }
            if (e.Col == 23)
            {
                if (this.flgView[e.Row, e.Col - 1] == null || this.flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("����ѡ��������ʽ��");
                    this.flgView.Col = 22;
                    return;
                }
            }
            if (e.Col == 20)
            {
                if (this.flgView[e.Row, e.Col - 1] == null || this.flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("����ѡ��ܵ����ƣ�");
                    this.flgView.Col = 19;
                    return;
                }
            }

            //�༭ͫ��
            if (e.Col == 4 || e.Col == 5)
            {
                if (flgView[e.Row, e.Col] == null || flgView[e.Row, e.Col].ToString() == "")
                {
                    FrmPupilSet frm = new FrmPupilSet();
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        flgView[e.Row, e.Col] = frm.returnValue;
                        //flgView.Editor = null;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    FrmPupilSet frm = new FrmPupilSet(flgView[e.Row, e.Col].ToString());
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        flgView[e.Row, e.Col] = frm.returnValue;
                        //flgView.Editor = null;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }

        }
        #endregion

        private void flgView_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            if (e.Col == 0 )//|| e.Col == 25)//ʱ������,��ע��ֹ�ֶ�����
            {
                e.Handled = true;
            }
            //����ֵ
            if (e.Col == 13)
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.'&&e.KeyChar!='-')
                {
                    e.Handled = true;
                }
                if (e.KeyChar=='-'&&flgView.Editor.Text.Contains("-"))
                {
                    e.Handled = true;
                }
            }
            if ((e.Col > 6 && e.Col < 12&&e.Col!=10) || e.Col == 16 || e.Col == 23)//��������,Ѫ�����Ͷȣ�������С�㣬��������
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            if (e.Col == 15)//��������g ,Ĭ��ml
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && Char.ToLower(e.KeyChar) != 'g')
                {
                    e.Handled = true;
                }
                else if (Char.ToLower(e.KeyChar) == 'g')
                {
                    //�ж��Ƿ��Ѿ��������λ:g
                    if (flgView.Editor.Text.ToLower().Contains("g") || flgView.Editor.Text == "")
                    {
                        e.Handled = true;
                    }
                }
            }
            if (e.Col == 10)//Ѫѹ
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '/' && flgView.Editor.Text.ToLower().Contains("/"))
                {
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// ���ñ༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_SetupEditor(object sender, RowColEventArgs e)
        {
            if (e.Col == 12 && this.flgView[e.Row, e.Col] != null && this.flgView[e.Row, e.Col].ToString() != "")//����������
            {
                //�����޸�ǰ����������
                oldInputName = this.flgView[e.Row, e.Col].ToString();
                //oldDuct_values = this.flgView[e.Row, e.Col].ToString();
            }
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            oldInputName= "";
            ShowData();
            SumInOrOutRecordSet(true);
            ShowSumDataGrid();
            //flgView.AutoSizeCols();
            flgView.Cols[25].Width = 100;
            flgView.Cols[1].Width = 35;
            flgView.Cols[22].Width = 35;
            flgView.AutoSizeRows();
        }
        /// <summary>
        /// �����༭�󣬱��浥Ԫ������ݵ����ݿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_AfterEdit(object sender, RowColEventArgs e)
        {

            #region ��֤
            if (this.flgView[e.Row, 0] != null && this.flgView[e.Row, 0].ToString() != "")
            {
                string currentRowTime = this.flgView[e.Row, 0].ToString();
                //��֤�ظ�ʱ��
                for (int i = 3; i < this.flgView.Rows.Count; i++)
                {
                    if (i != e.Row)
                    {
                        if (this.flgView[i, 0] != null && this.flgView[i, 0].ToString() == currentRowTime)
                        {
                            this.flgView[e.Row, 0] = null;
                            App.Msg("����¼����ͬ��ʱ�䣡");
                            return;
                        }
                    }
                }

                //��֤ʱ�䷶Χ�Ƿ�Ͳ�ѯ����������ͬ
                if (dtpDate.Value.ToString("yyyy-MM-dd") != Convert.ToDateTime(currentRowTime).ToString("yyyy-MM-dd"))
                {
                    this.flgView[e.Row, 0] = null;
                    App.Msg("��ѡ���ʱ�䳬���˲�ѯ���ڣ�");
                    return;
                }
            }
            #endregion

            #region ��������
            if (this.flgView[e.Row, e.Col] != null && this.flgView[e.Row, e.Col].ToString() != "")
            {
                string measureTime = GetTime(e.Row);
                string itemCode = "";
                string itemValue = "";
                string itemName = "";
                string otherName = "";
                int id = 0;
                if (e.Col==1||e.Col==2||e.Col == 3 ||e.Col==21|| e.Col == 24)
                {
                    ListDictionary ldCommon = GetDictionaryByColIndex(e.Col);
                    itemValue = ldCommon[this.flgView[e.Row, e.Col].ToString()].ToString();
                    itemCode = this.flgView[e.Row, e.Col].ToString();
                    itemName = dictColumnName[e.Col];
                }
                else if (e.Col == 13||e.Col==12)//����
                {
                    itemCode = flgView[e.Row, 12] == null ? "" : flgView[e.Row, 12].ToString();
                    itemValue = flgView[e.Row, 13] == null ? "" : flgView[e.Row, 13].ToString();
                    itemName = "����";
                    //if (e.Col == 12)
                    //{
                    //    string s = App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and item_code='" + itemCode + "' and patient_id=" + currentPatient.Id, 0, "count(*)");
                    //    if (s != "0")
                    //    {
                    //        App.Msg("������Ŀ�ظ�!");
                    //        this.flgView[e.Row, e.Col] = oldInputName;
                    //        this.flgView.Col = e.Col;
                    //        return;
                    //    }
                    //}
                    if(flgView[e.Row,27]!=null&&flgView[e.Row,27].ToString().Length>0)
                    {
                        try
                        {
                            id = int.Parse(flgView[e.Row, 27].ToString());
                        }
                        catch{}
                    }
                }
                else if (e.Col == 19||e.Col==20)//�ܵ�
                {
                    itemValue = flgView[e.Row, 20] == null ? "" : flgView[e.Row, 20].ToString();
                    itemCode = flgView[e.Row, 19] == null ? "" : flgView[e.Row, 19].ToString();
                    itemName = "�ܵ�";
                }
                else if (e.Col == 14 || e.Col == 18)//�ֹ��������,������������
                {
                    switch (e.Col)
                    {
                        case 14:
                            itemName = "�����Զ���ֵ";
                            break;
                        case 18:
                            itemName = "�����Զ���ֵ";
                            break;
                    }
                    itemValue = this.flgView[e.Row, e.Col].ToString();
                    otherName = this.flgView[1, e.Col].ToString();
                    //itemCode = e.Col.ToString();
                }
                else if (e.Col == 23||e.Col==22)//����
                {
                    //ListDictionary ldCommon = GetDictionaryByColIndex(22);
                    //otherName = ldCommon[flgView[e.Row, 22].ToString()].ToString();
                    itemValue = flgView[e.Row, 23] == null ? "" : flgView[e.Row, 23].ToString();
                    itemCode = flgView[e.Row, 22] == null ? "" : flgView[e.Row, 22].ToString();
                    itemName = "����";
                }
                else
                {
                    itemValue = this.flgView[e.Row, e.Col].ToString();
                    if (e.Col == 25)//��ע����֤�ַ�����
                    {
                        int length = getStringLength(itemValue);
                        if (length > 600)
                        {
                            App.Msg("����������ݳ���600�ֽ���!");
                            return;
                        }
                    }
                    itemName = dictColumnName[e.Col];
                    itemCode = App.ReadSqlVal("select item_code from t_nurse_record_dict where item_type in(19802,19804,19805,19807,19808,19809,19810) and  item_name='" + itemName + "'", 0, "item_code");

                }
                //ȡ��ǰ����ʱ������Ĵ�����id
                string userId = "";
                try
                {
                    userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (userId == null || userId == "")
                    {
                        userId = App.UserAccount.UserInfo.User_id;
                    }
                }
                catch (System.Exception ex)
                {
                    userId = App.UserAccount.UserInfo.User_id;
                }
                //�ж������������޸�:����ֵ����0���޸ģ�����0������
                int itemCount = 0;
                if (e.Col != 13 && e.Col != 12)
                {
                    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                }
                else //������֤��������othername
                {
                    if (itemName == "����")
                    {
                        if (id > 0)
                        {
                            itemCount = 1;
                        }
                    }
                    else
                    {
                        itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and item_code='" + itemCode + "'  and patient_id=" + currentPatient.Id, 0, "count(*)"));
                    }
                }
                string sql = "";
                if (itemCount == 0)
                {
                    if (otherName == "")
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','"+strType+"')";
                    }
                    else
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + otherName + "','"+strType+"')";
                    }
                }
                else
                {
                    sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                    if (itemName == "����" && id > 0)
                    {
                        sql += " where id=" + id;
                    }
                    else
                    {
                        sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id;
                        ////}
                        //if (!string.IsNullOrEmpty(itemCode))
                        //{
                        //    if (itemName.Equals("����"))
                        //    {
                        //        sql = sql + " and item_code='" + (oldInputName == "" ? itemCode : oldInputName) + "'";
                        //    }
                        //}
                    }
                }
                int num = App.ExecuteSQL(sql);
                if (num > 0)
                {
                    timer1.Start();
                    operateFlag = true;
                    if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "" && flgView[e.Row, 20] == null && sql.Contains("insert"))
                        flgView[e.Row, 26] = App.UserAccount.UserInfo.User_name;
                    if (id == 0 && itemName == "����" && sql.ToLower().Contains("insert"))
                    {
                        btnSearch_Click(sender, e);
                    }
                    //App.Msg("�����ɹ���");
                    //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "',create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                    //btnSearch_Click(sender, e);
                }
                //}
                //else if (e.Col == 12) //���¸��ֹܵ�����
                //{

                //    //��֤�Ƿ��ظ�

                //    itemName = ldDuct_name[this.flgView[e.Row, 12]].ToString();
                //    int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='���ֹܵ�' and other_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                //    if (itemCount > 0 && itemName != oldDuct_name)
                //    {
                //        App.Msg("�ܵ������ظ���");
                //        this.flgView[e.Row, e.Col] = oldDuct_values;
                //        //btnSearch_Click(sender, e);
                //        return;
                //    }

                //    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='���ֹܵ�' and other_name='" + oldDuct_name + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));

                //    //�����ǰ��Ŀ�Ѵ������޸ĵ�ǰֵ����������
                //    if (oldDuct_name != "")
                //    {
                //        if (itemCount > 0 && this.flgView[e.Row, 13] != null)
                //        {
                //            otherName = ldDuct_name[this.flgView[e.Row, 12].ToString()].ToString();
                //            itemCode = this.flgView[e.Row, 12].ToString();
                //            string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='���ֹܵ�' and other_name='" + oldDuct_name + "' and patient_id=" + currentPatient.Id;
                //            int num = App.ExecuteSQL(sql);
                //            if (num > 0)
                //            {
                //                timer1.Start();
                //                //App.Msg("�����ɹ���");
                //                operateFlag = true;
                //                //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'��create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                //                //btnSearch_Click(sender, e);
                //            }
                //        }

                //    }

                //}
            }
            #endregion


        }

        /// <summary>
        /// �����е�������ö�Ӧ���ֵ伯��
        /// </summary>
        /// <returns>�����ֵ�</returns>
        private ListDictionary GetDictionaryByColIndex(int col)
        {
            if (col == 2)
            {
                return ldNurseLevel;
            }
            else if (col == 3)//��ʶ
            {
                return ldConsciousness;
            }
            else if (col == 1)
            {
                return ldSickLevel;
            }
            else if (col == 21)//Ƥ��
            {
                return ldSkin;
            }
            else if (col == 24)//��ȫ����
            {
                return ldSafenurse;
            }
            else if (col == 22)//����
            {
                return ldXY;
            }
            return null;
        }

        private void �޸ı���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string titleName = "";
            titleName = this.flgView[1, this.flgView.Col].ToString();
            FrmModifyTitle frm = new FrmModifyTitle(titleName);
            frm.ShowDialog();

            string pipeIndex = "";//��ǰѡ�б���λ��
            //���ñ�ͷ����,�������Զ�������
            if (this.flgView.Col == 14)
            {
                this.flgView[1, 14] = frm.tName;
                pipeIndex = "�����Զ���ֵ";
            }
            else if (this.flgView.Col == 18 )
            {
                this.flgView[1, 18] = frm.tName;
                pipeIndex = "�����Զ���ֵ";
            }
            //��������,�������Զ�������
            string sql = "update t_nurse_record set other_name='" + frm.tName + "' where patient_id=" + currentPatient.Id + " and record_type='" + strType + "' and item_show_name like '%" + pipeIndex + "%'";
            try
            {
                App.ExecuteSQL(sql);
            }
            catch
            {

            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.flgView.Col == 14 || this.flgView.Col == 18)
            {
                �޸ı���ToolStripMenuItem.Visible = true;
            }
            else
            {
                �޸ı���ToolStripMenuItem.Visible = false;
            }
            if (flgView.Col == 25)
            {
                ��ȡ��עģ��ToolStripMenuItem.Visible = true;
                if (flgView[flgView.Row, flgView.Col] != null)
                {
                    ��ӱ�עģ��ToolStripMenuItem.Visible = true;
                }
                else
                {
                    ��ӱ�עģ��ToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                ��ӱ�עģ��ToolStripMenuItem.Visible = false;
                ��ȡ��עģ��ToolStripMenuItem.Visible = false;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        #region ����
        private void cboTiming_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpBeginTime.Enabled = false;
            dtpEndTime.Enabled = false;
            dtpDateSelect.Enabled = true;
            Class_Take_over_SEQ tempSeq = null;
            if (cboTiming.SelectedItem != null)
            {
                tempSeq = (Class_Take_over_SEQ)cboTiming.SelectedItem;
            }
            if (cboTiming.Text.Contains("�׶���"))
            {
                string tHour;
                TimeSpan sp = new TimeSpan();
                sp = dtpEndTime.Value - dtpBeginTime.Value;
                tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
                tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "��";
                lblTatolTime.Text = tHour;
                dtpBeginTime.Enabled = true;
                dtpEndTime.Enabled = true;
                dtpDateSelect.Enabled = false;
            }
            else
            {
                if (tempSeq != null)
                {
                    dtpBeginTime.Value = Convert.ToDateTime(dtpDateSelect.Value.ToShortDateString() + " " + tempSeq.Begin_time);
                    dtpEndTime.Value = Convert.ToDateTime(dtpDateSelect.Value.ToShortDateString() + " " + tempSeq.End_time);
                    if (Convert.ToDateTime(App.GetSystemTime().ToShortDateString() + " " + tempSeq.Begin_time) >= Convert.ToDateTime(App.GetSystemTime().ToShortDateString() + " " + tempSeq.End_time))
                        dtpBeginTime.Value = dtpBeginTime.Value.AddDays(-1);
                    string tHour;
                    TimeSpan sp = new TimeSpan();
                    sp = dtpEndTime.Value - dtpBeginTime.Value;
                    tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
                    tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "��";
                    lblTatolTime.Text = tHour;
                }
            }
        }

        /// <summary>
        /// ȷ�ϼ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHus_sum_Click(object sender, EventArgs e)
        {
            string sum_id = SumInOrOut();
            if (cboTiming.Text.Contains("С��"))
            {
                FrmSumItem sum_item = new FrmSumItem(sum_id,strType);
                sum_item.ShowDialog();
                if (!sum_item.successflag)
                {//û�в����ɹ�,�������ͳ�Ƽ�¼
                    string del = "delete from t_nurse_dangery_inout_sum_h where id=" + sum_id + " and record_type='"+strType+"' and patient_id=" + currentPatient.Id;
                    if (App.ExecuteSQL(del) > 0)
                    {//������ˢ�²�����
                        return;
                    }
                }
            }
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// �������������
        /// </summary>
        private string SumInOrOut()
        {
            string sum_id = null;
            string sum_Name;
            if (cboTiming.Text == "�׶����ܽ�")
            {
                sum_Name = lblTatolTime.Text + "�ܽ�";
            }
            else if (cboTiming.Text == "�׶���С��")
            {
                sum_Name = lblTatolTime.Text + "С��";
            }
            else
            {
                sum_Name = cboTiming.Text;
            }

            int id = App.GenId("t_nurse_dangery_inout_sum_h", "ID");//��ȡid
            Class_Take_over_SEQ take_Seq = cboTiming.SelectedItem as Class_Take_over_SEQ;

            if (take_Seq != null)
            {
                string inserSumSql = "insert into t_nurse_dangery_inout_sum_h(ID,PID,CALC_DATE,START_TIME,END_TIME,OPER_METHOD,patient_Id,seq_id,SIGNATURE,RECORD_TYPE)values(" +
                id.ToString() + ",'" + currentPatient.PId + "',sysdate,to_timestamp('" +
                dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),to_timestamp('" +
                dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),'" + sum_Name + "'," + currentPatient.Id + "," + take_Seq.Id + ",'" + App.UserAccount.UserInfo.User_name + "','"+strType+"')";

                if (App.ExecuteSQL(inserSumSql) > 0)
                {
                    sum_id = id.ToString();
                }
            }
            return sum_id;          
        }

        /// <summary>
        /// ���Ļ��ܼ���ˢ��
        /// </summary>
        private void ShowSumDataGrid()
        {
            string TempDateTime = null;
            Class_Nurse_Record_Pediatric[] Nusers_objs = new Class_Nurse_Record_Pediatric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {

                Nusers_objs[i] = new Class_Nurse_Record_Pediatric();
                Nusers_objs[i] = (Class_Nurse_Record_Pediatric)nurses[i];
                
            }
            SetTable();//��ͷ����
            if (Nusers_objs.Length != 0)
            {
                //Nusers_objs[Nusers_objs.Length - 1] = new Class_Nurse_Record_Pediatric();
                App.ArrayToGrid(this.flgView, Nusers_objs, cols, 3);
            }


            //�����ܼ�����в���ID
            for (int i = 0; i < Nusers_objs.Length; i++)
            {
                if (Nusers_objs[i].Number != null)
                {
                    this.flgView[i + 3, 27] = Nusers_objs[i].Number;
                }
            }

            //��Ԫ��ϲ�������
            CellUnit(pipe1, pipe2);
            this.flgView.AutoSizeCols();
            this.flgView.AutoSizeRows();
            for (int i = 3; i < this.flgView.Rows.Count; i++)
            {
                if (this.flgView[i, 6] != null)
                {
                    bool isC = false;
                    for (int j = 0; j < Take_over_seq.Length; j++)
                    {
                        int id = 0;
                        if (flgView[flgView.Row, 27] != null && flgView[flgView.Row, 27].ToString().Length > 0)
                        {
                            try
                            {
                                id = int.Parse(flgView[flgView.Row, 27].ToString());
                            }
                            catch { }
                        }
                        if (this.flgView[i, 6].ToString().Contains(Take_over_seq[j].Seq) || this.flgView[i, 6].ToString().Contains("������"))
                        {//�ԱȻ��ܵİ��
                            if (id == 0)
                            {
                                this.flgView.Rows[i].AllowEditing = false;
                                isC = true;
                                break;
                            }
                        }
                    }
                    if (!isC)
                    {
                        this.flgView.Rows[i].AllowEditing = true;
                    }
                }
            }
            
        }

        
        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "��";
            lblTatolTime.Text = tHour;
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "��";
            lblTatolTime.Text = tHour;
        }
        
        private void dtpDateSelect_ValueChanged(object sender, EventArgs e)
        {
            cboTiming_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="IsToDay">true ���㵱ǰ�죬false ����ȫ��</param>
        private void SumInOrOutRecordSet(bool IsToDay)
        {
            string BeginTime, EndTime, Item_name;
            string Number = "";//����
            string seq_id = "";//ͳ������ID
            string singsure = ""; //ǩ��

            SumNusersRecords.Clear();  
            string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id ;
            if(IsToDay)
            {
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                sql_date+=" and  to_char(end_time,'yyyy-MM-dd')='" + date + "'"; 
            }
            sql_date+=" and record_type='"+strType+"'";
            sql_date += " order by end_time";
            DataSet ds_sum_oper = App.GetDataSet(sql_date);

            for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            {
                //SumNusersRecords.Add(ds_sum_oper.Tables[0].Rows[i]["start_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["end_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
                SumNusersRecords.Add(ds_sum_oper.Tables[0].Rows[i]["start_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["end_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            }

            for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            {
                double din = 0;//������
                double dinother = 0;//�����Զ���ֵ��
                double dinsum = 0;//�����ܺ�
                double dshit = 0;//����
                double durine = 0;//С���
                double doutother = 0;//����������
                double doutother2 = 0;//�����Զ���ֵ��
                double doutsum = 0;//�����ܺ�
                             
                BeginTime = SumNusersRecords[i1].ToString().Split(',')[0];
                EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
                Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
                Number = SumNusersRecords[i1].ToString().Split(',')[3];
                seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
                //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
                singsure = SumNusersRecords[i1].ToString().Split(',')[5];
                string [] sum_item=SumNusersRecords[i1].ToString().Split(',')[6].Split('|');
                SumNusers.Clear();
                Class_Nurse_Record_Pediatric sumtemp = new Class_Nurse_Record_Pediatric();

                string beginSgin = ">=";

                string endSgin = "<=";

                Class_Take_over_SEQ tempSeq = null;
                for (int i = 0; i < cboTiming.Items.Count; i++)
                {
                    tempSeq = cboTiming.Items[i] as Class_Take_over_SEQ;
                    if (tempSeq != null && tempSeq.Id == seq_id)
                    {
                        if (tempSeq.Begin_logic == "0")
                        {
                            beginSgin = ">";
                        }
                        if (tempSeq.End_logic == "0")
                        {
                            endSgin = "<";
                        }
                        break;
                    }
                } 

                StringBuilder sbSum = new StringBuilder("select item_show_name as ItemName,a.item_value as ItemValue,a.item_code as ItemCode from t_nurse_record a");
                sbSum.Append(" where 1=1");
                sbSum.Append(" and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME");
                sbSum.Append(" " + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id);
                sbSum.Append(" and a.record_type='" + strType + "'");
                sbSum.Append(" and item_show_name in('����','�����Զ���ֵ','���','С��','��������','�����Զ���ֵ')");

                //����ʼʱ������Һ
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'��Һ+' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(BeginTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='ҩ��'");
                sbSum.Append(" and other_name='��Һ'");

                //�������ʱ������Һ
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'��Һ-' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='ҩ��'");
                sbSum.Append(" and other_name='��Һ'");

                DataSet dsSum = App.GetDataSet(sbSum.ToString());
                if (dsSum.Tables.Count > 0 && dsSum.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drSum in dsSum.Tables[0].Rows)
                    {
                        double dtmp = 0;
                        string strTempName = drSum["ItemName"].ToString();
                        string strTempValue=drSum["ItemValue"].ToString();
                        string strTempCode = drSum["ItemCode"].ToString();
                        if (Double.TryParse(strTempValue, out dtmp))
                        {
                            switch (strTempName)
                            {
                                case "����":
                                    if (strTempCode.Contains("��Һ"))
                                    {
                                        dtmp = -Math.Abs(dtmp);
                                    }
                                    else if (strTempCode.Equals("��Һ"))
                                    {
                                        dtmp = 0;
                                    }
                                    else if(strTempCode.Equals("��Һ+"))
                                    {
                                        dtmp = Math.Abs(dtmp);
                                    }
                                    else if (strTempCode.Equals("��Һ-"))
                                    {
                                        dtmp = -Math.Abs(dtmp);
                                    }
                                    din+=dtmp;
                                    break;
                                case "�����Զ���ֵ":
                                    dinother+=dtmp;
                                    break;
                                case "���":
                                    dshit += dtmp;
                                    break;
                                case "С��":
                                    durine += dtmp;
                                    break;
                                case "��������":
                                    doutother += dtmp;
                                    break;
                                case "�����Զ���ֵ":
                                    doutother2 += dtmp;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                #region �����������
                dinsum = din + dinother;
                doutsum = dshit + durine + doutother + doutother2;
                #endregion
                sumtemp.DateTime = Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm");
                sumtemp.Inputname = Item_name;
                sumtemp.Number = Number;
                //ͳ��ֵΪ0�ľ�����ʾ
                if (Item_name.Contains("�ܽ�"))
                {
                    if (dinsum > 0)
                    {
                        sumtemp.Inputvalue = dinsum.ToString();
                    }
                    if (doutsum > 0)
                    {
                        sumtemp.Urine = doutsum.ToString();
                    }
                }
                else
                {
                    for (int isum = 0; isum < sum_item.Length; isum++)
                    {
                        switch (sum_item[isum].Trim())
                        {
                            case"����":
                                if (din > 0)
                                {
                                    sumtemp.Inputvalue = din.ToString();
                                }
                                break;
                            case"�����Զ�����":
                                if (dinother > 0)
                                {
                                    sumtemp.Inputother = dinother.ToString();
                                }
                                break;
                            case"���":
                                if (dshit > 0)
                                {
                                    sumtemp.Shit = dshit.ToString();
                                }
                                break;
                            case"С��":
                                if (durine > 0)
                                {
                                    sumtemp.Urine = durine.ToString();
                                }
                                break;
                            case"��������":
                                if (doutother > 0)
                                {
                                    sumtemp.Outother = doutother.ToString();
                                }
                                break;
                            case"�����Զ�����":
                                if (doutother2 > 0)
                                {
                                    sumtemp.Out_item_name = doutother2.ToString();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (singsure == "")
                {
                    if (App.UserAccount.UserInfo != null)
                        sumtemp.Signature = App.UserAccount.UserInfo.User_name;//ǩ��
                }
                else
                {
                    sumtemp.Signature = singsure;//ǩ��
                }
                DateTime TempDate = new DateTime();
                bool flag = false;//���ܶ����Ƿ�����ӱ�־

                if (nurses.Count == 0)
                {
                    SumNusers.Add(sumtemp);
                }
                //�����ܼ�¼�嵽���󼯺���ȥ
                for (int i = 0; i < nurses.Count; i++)
                {
                    Class_Nurse_Record_Pediatric temp_nuser = (Class_Nurse_Record_Pediatric)nurses[i];
                    if (temp_nuser.DateTime != null)
                    {
                        TempDate = Convert.ToDateTime(temp_nuser.DateTime);
                    }
                    else
                    {
                        SumNusers.Add(temp_nuser);
                        continue;
                    }

                    if (TempDate >= Convert.ToDateTime(EndTime) && !flag)//���ܽ���ʱ��С�ڲ���ʱ��ʱ������ӻ��ܶ���
                    {
                        SumNusers.Add(sumtemp);
                        SumNusers.Add(temp_nuser);
                        flag = true;
                    }
                    else
                    {
                        SumNusers.Add(temp_nuser);
                    }
                }

                if (SumNusers.Count == nurses.Count)
                {
                    SumNusers.Add(sumtemp);
                }

                nurses.Clear();
                for (int i = 0; i < SumNusers.Count; i++)
                {
                    nurses.Add(SumNusers[i]);
                }


            }
            //ShowSumDataGrid();
        }
        #endregion

        private void ��ӿ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.flgView.Rows.Insert(this.flgView.RowSel);
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.flgView[this.flgView.Row, this.flgView.Col] != null && this.flgView[this.flgView.Row, this.flgView.Col].ToString() != "")
                {
                    string measureTime = GetTime(this.flgView.Row);
                    string itemName = dictColumnName[this.flgView.Col];
                    string otherName = "";
                    string sql = "";//ɾ�����
                    int id = 0;
                    bool isC = false;
                    if (flgView[flgView.Row, 27] != null && flgView[flgView.Row, 27].ToString().Length > 0)
                    {
                        try
                        {
                            id = int.Parse(flgView[flgView.Row, 27].ToString());
                        }
                        catch { }
                    }
                    if (id==0&&this.flgView[this.flgView.Row, 12] != null && (this.flgView[this.flgView.Row, 12].ToString().Contains("С��") || this.flgView[this.flgView.Row, 12].ToString().Contains("�ܽ�")))//ɾ������
                    {
                        //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                        string signature = App.ReadSqlVal("select signature from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 12].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "signature");
                        if (App.UserAccount.UserInfo.User_name == signature || signature == null || signature == ""||App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                        {
                            sql = "delete from t_nurse_dangery_inout_sum_h where oper_method='" + this.flgView[this.flgView.Row, 12].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='"+strType+"' and patient_id=" + currentPatient.Id;
                        }
                        else
                        {
                            App.Msg("Ȩ�޲��㣡");
                            return;
                        }
                    }
                    else
                    {
                        id = 0;
                        bool isdel = true;//ɾ�����Ǹ���
                        string stritemcode = "";
                        if (itemName.Contains("�ܵ�"))
                        {
                            if (itemName.Contains("���"))
                            {
                                isdel = false;
                                stritemcode = flgView[flgView.Row, flgView.Col - 1].ToString();
                            }
                            itemName = "�ܵ�";
                        }
                        if (itemName.Contains("����")&&itemName!="�����Զ���ֵ")
                        {
                            if (itemName.Contains("������"))
                            {
                                isdel = false;
                                stritemcode = flgView[flgView.Row, flgView.Col - 1].ToString();
                            }
                            else
                            {
                                stritemcode = flgView[flgView.Row, flgView.Col].ToString();
                            }
                            if (flgView[flgView.Row, 27] != null && flgView[flgView.Row, 27].ToString().Length > 0)
                            {
                                try
                                {
                                    id = int.Parse(flgView[flgView.Row, 27].ToString());
                                }
                                catch { }
                            }
                            itemName = "����";
                        }
                        if (itemName.Contains("����"))
                        {
                            if (itemName.Contains("����"))
                            {
                                isdel = false;
                                stritemcode = flgView[flgView.Row, flgView.Col - 1].ToString();
                            }
                            itemName = "����";
                        }
                        if (this.flgView.Col != 0)//ɾ��������
                        {
                            if (otherName == "")
                            {
                                string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                if (id > 0)
                                {
                                    operateId = App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id, 0, "creat_id");
                                }
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                                {
                                    if (isdel)
                                    {
                                        if (id > 0)
                                        {
                                            sql = "delete from t_nurse_record where id=" + id;
                                        }
                                        else
                                        {
                                            sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id;
                                            if (stritemcode.Trim().Length > 0)
                                            {
                                                sql = sql + " and item_code='" + stritemcode + "'";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (id > 0)
                                        {
                                            sql = "update t_nurse_record set item_value=null where id=" + id;
                                        }
                                        else
                                        {
                                            sql = "update t_nurse_record set item_value=null where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and item_code='" + stritemcode + "' and patient_id=" + currentPatient.Id;
                                        }
                                    }
                                }
                                else
                                {
                                    App.Msg("Ȩ�޲��㣡");
                                    return;
                                }
                            }
                            else
                            {
                                string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                if (id > 0)
                                {
                                    operateId = App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id, 0, "creat_id");
                                }
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                                {
                                    if (id > 0)
                                    {
                                        sql = "delete from t_nurse_record where id=" + id;
                                    }
                                    else
                                    {
                                        sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id;
                                    }
                                }
                                else
                                {
                                    App.Msg("Ȩ�޲��㣡");
                                    return;
                                }
                            }
                        }
                        else//ɾ����ǰ�е�������Ŀ
                        {
                            string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                            if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                            {
                                sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                            }
                            else
                            {
                                App.Msg("Ȩ�޲��㣡");
                                return;
                            }
                        }
                    }


                    int num = App.ExecuteSQL(sql);
                    if (num > 0)
                    {
                        operateFlag = true;
                        timer1.Start();
                        //App.Msg("ɾ���ɹ���");
                        //���´�����
                        //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'��create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        btnSearch_Click(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
        }




        private bool ValidateUser(string operateId)
        {
            try
            {

                //��ǰ��½�ߵ���Ϣ
                string strUpdateName = App.UserAccount.UserInfo.User_name.ToString();//��¼��ǰ��½�û�����
                string strUpdateUserId = App.UserAccount.UserInfo.User_id.ToString();//��¼��ǰ��½�û�id
                string strUpdateZC = "";//��¼��ǰ��½�û�ְ��
                string strUpdateZCcode = App.UserAccount.UserInfo.U_tech_post.ToString();//��¼��ǰ��½�û�ְ�Ƶ�code
                if (strUpdateZCcode != "")
                {
                    strUpdateZC = App.ReadSqlVal("select name from t_data_code t where t.id='" + strUpdateZCcode + "'", 0, "name");//ͨ���û�ְ�Ƶ�codeȡ��ְ��
                }
                string strUpdateRole = App.UserAccount.CurrentSelectRole.Role_name.ToString();//��¼��ǰ��½�û���ɫ
                string strUpdatedDQZC = "";//��½�ߵĵ�ǰְ��
                if (strUpdateZC == "ʵϰ��ʿ" || strUpdateRole == "ʵϰ��ʿ")
                {
                    strUpdatedDQZC = "1";
                }
                if (strUpdateZC == "��ʿ" || strUpdateRole == "��ʿ")
                {
                    strUpdatedDQZC = "2";
                }
                if (strUpdateZC == "��ʦ" || strUpdateRole == "��ʦ")
                {
                    strUpdatedDQZC = "3";
                }
                if (strUpdateZC == "���ܻ�ʦ" || strUpdateRole == "���ܻ�ʦ")
                {
                    strUpdatedDQZC = "4";
                }
                if (strUpdateZC == "�����λ�ʦ" || strUpdateRole == "�����λ�ʦ")
                {
                    strUpdatedDQZC = "5";
                }
                if (strUpdateZC == "���λ�ʦ" || strUpdateRole == "���λ�ʦ")
                {
                    strUpdatedDQZC = "6";
                }
                if (strUpdateZC == "��ʿ��" || strUpdateRole == "��ʿ��")
                {
                    strUpdatedDQZC = "7";
                }
                //���ݴ����ߵ���Ϣ
                string strCreateName = App.ReadSqlVal("select user_name  from t_Userinfo t  where t.user_id='" + operateId + "'", 0, "user_name");//ȡ�������ߵ�����
                string strCreateCode = App.ReadSqlVal("select u_tech_post  from t_Userinfo t  where t.user_id='" + operateId + "'", 0, "u_tech_post");//ȡ�������ߵ�code
                string strCreateZC = "";//������¼�����ߵ�ְ��
                if (strCreateCode != "")
                {
                    strCreateZC = App.ReadSqlVal("select name from t_data_code t where t.id='" + strCreateCode + "'", 0, "name");//ȡ�������ߵ�ְ��
                }
                string strCreateRole = "";//�������մ����ߵĽ�ɫ
                DataSet ds = new DataSet();
                ds = App.GetDataSet("select t4.role_name from t_userinfo t1, t_account_user t2, t_acc_role t3,t_role t4" +
                           @" where t1.user_id = t2.user_id  and t2.account_id = t3.account_id and t3.role_id = t4.role_id and t1.user_id='" + operateId + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strCreateRole = ds.Tables[0].Rows[0]["role_name"].ToString();//ȡ�������ߵĽ�ɫ
                }
                string strCreateDQZC = "";
                if (strCreateZC == "ʵϰ��ʿ" || strCreateRole == "ʵϰ��ʿ")
                {
                    strCreateDQZC = "1";
                }
                if (strCreateZC == "��ʿ" || strCreateRole == "��ʿ")
                {
                    strCreateDQZC = "2";
                }
                if (strCreateZC == "��ʦ" || strCreateRole == "��ʦ")
                {
                    strCreateDQZC = "3";
                }
                if (strCreateZC == "���ܻ�ʦ" || strCreateRole == "���ܻ�ʦ")
                {
                    strCreateDQZC = "4";
                }
                if (strCreateZC == "�����λ�ʦ" || strCreateRole == "�����λ�ʦ")
                {
                    strCreateDQZC = "5";
                }
                if (strCreateZC == "���λ�ʦ" || strCreateRole == "���λ�ʦ")
                {
                    strCreateDQZC = "6";
                }
                if (strCreateZC == "��ʿ��" || strCreateRole == "��ʿ��")
                {
                    strCreateDQZC = "7";
                }
                //��ǰ��½�ߺʹ�����Ȩ�޵ıȽ�
                if (Convert.ToInt32(strUpdatedDQZC) > Convert.ToInt32(strCreateDQZC))//��ǰ��½�ߵ�Ȩ�޸��ڴ����ߣ�����trueֵ
                {
                    return true;
                }
                else if (strUpdatedDQZC == strCreateDQZC)//��½�ߵĵ�ǰְ�ƺʹ����ߵĵ�ǰְ����ȣ��̶��ж������Ƿ���ͬ
                {
                    if (strUpdateName == strCreateName)//������ͬ���̶��ж�user_id�Ƿ���ͬ
                    {
                        if (strUpdateUserId == operateId)//user_id��ͬ������trueֵ
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void lblDatePriview_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(-1));
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
        }

        private void lblDateNext_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(1));
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            //btnSelect_Click(sender, e);
        }

        /// <summary>
        /// ��ȡ��Ӣ�Ļ����ַ�����ʵ�ʳ���(�ֽ���)
        /// </summary>
        /// <param name="str">Ҫ��ȡ���ȵ��ַ���</param>
        /// <returns>�ַ�����ʵ�ʳ���ֵ���ֽ�����</returns>
        public int getStringLength(string str)
        {
            if (str.Equals(string.Empty))
                return 0;
            int strlen = 0;
            ASCIIEncoding strData = new ASCIIEncoding();
            //���ַ���ת��ΪASCII������ֽ�����
            byte[] strBytes = strData.GetBytes(str);
            for (int i = 0; i <= strBytes.Length - 1; i++)
            {
                if (strBytes[i] == 63)  //���Ķ�������ΪASCII����63,��"?"��
                    strlen++;
                strlen++;
            }
            return strlen;
        }

        bool operateFlag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (operateFlag)
            {
                lblOperate.Visible = true;
                operateFlag = false;
                timer1.Interval = 1500;
            }
            else
            {
                lblOperate.Visible = false;
                timer1.Interval = 1;
                timer1.Stop();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //�������
            diagnose = txtDiagnose.Text.Trim();
            string update_Sql = @"update t_nurse_record set diagnose_name='" + diagnose + "' where patient_id='" + this.currentPatient.Id + "' and record_type='" + strType + "'";
            int count = 0;
            try
            {
                count = App.ExecuteSQL(update_Sql);
            }
            catch (Exception)
            {

                //throw;
            }
            if (count > 0)
            {
                App.Msg("����ɹ���");
                //this.Close();
            }
        }

        /// <summary>
        ///�������
        /// </summary>
        private void LoadDiagnose()
        {
            //��ȡ���
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where Patient_Id =" + currentPatient.Id+" and record_type='"+strType+"'", 0, "diagnose_name");//�Լ��޸ĵĻ���
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='403' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//�������
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='408' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//�������
            }
            if (diagnose == null)
            {
                diagnose = "";
            }
            txtDiagnose.Text = diagnose;
        }

        private void flgView_ChangeEdit(object sender, EventArgs e)
        {
            using (Graphics g = flgView.CreateGraphics())
            {
                if (flgView.Col == 25)
                {
                    // measure text height
                    StringFormat sf = new StringFormat();
                    int wid = flgView.Cols[25].WidthDisplay;
                    string text = flgView.Editor.Text;
                    SizeF sz = g.MeasureString(text, flgView.Font, wid, sf);
                    // adjust row height if necessary
                    C1.Win.C1FlexGrid.Row row = flgView.Rows[flgView.Row];
                    if (sz.Height + 4 > row.HeightDisplay)
                        row.HeightDisplay = (int)sz.Height + 4;
                }
            }
        }

        private void ��ȡ��עģ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateList fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateList();
                fc.ShowDialog();
                //��ֵ
                if (fc.nursecomplate != null && fc.nursecomplate != "")
                {
                    this.flgView[flgView.Row, flgView.Col] = fc.nursecomplate;
                    RowColEventArgs ea = new RowColEventArgs(flgView.Row, flgView.Col);
                    this.flgView_AfterEdit(flgView, ea);
                    this.flgView.Select(flgView.Row, flgView.Col);
                }
            }
            catch (Exception)
            {
            }
        }

        private void ��ӱ�עģ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flgView[flgView.Row, flgView.Col] != null)
            {
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd(flgView[flgView.Row, flgView.Col].ToString());
                fc.ShowDialog();
            }
        }

        private int PageRowCount = 21;
        private void ShowMsg()
        {
            #region �����¼����ҳ����
            //DataSet ds = GetNusersRecords() == null ? null : ReSetPrintDataSet(GetNusersRecords());
            DataSet ds = GetNusersRecords();
            if (ds != null)
            {
                ds = ReSetPrintDataSet(ds);
            }
            int PageCount = 0;
            int FullLastPage = 0;
            if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
            {
                lmsg1.Text = "�˻���û�л����¼��Ϣ";
                lmsg2.Text = "";
            }
            else
            {
                int nrow = ds.Tables[0].Rows.Count;
                if (nrow % PageRowCount == 0)
                {
                    PageCount = nrow / PageRowCount;
                    FullLastPage = PageCount;
                }
                else
                {
                    PageCount = nrow / PageRowCount + 1;
                    FullLastPage = PageCount - 1;
                }
                lmsg1.Text = "��" + PageCount.ToString() + "ҳ,";
                if (FullLastPage > 0)
                {
                    int fullpagerowindex = FullLastPage * PageRowCount - 1;
                    DateTime dtime = new DateTime();
                    string stime = ds.Tables[0].Rows[fullpagerowindex]["DateTime"].ToString();
                    while (!DateTime.TryParse(stime, out dtime))
                    {
                        fullpagerowindex--;
                        stime = ds.Tables[0].Rows[fullpagerowindex]["DateTime"].ToString();
                    }
                    lmsg1.Text += "��" + FullLastPage.ToString() + "ҳ����ҳ";
                    //while (stime.Length < 10)
                    //{
                    //    fullpagerowindex--;
                    //    stime = ds.Tables[0].Rows[fullpagerowindex]["DateTime"].ToString();
                    //}
                    lmsg2.Text = "��ҳ��¼ʱ��Ϊ��" + dtime.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    lmsg2.Text = "����ҳ��Ϣ";
                }

            }
            #endregion

            #region ��Σ��ʾ
            if (!string.IsNullOrEmpty(currentPatient.Die_flag.ToString()))
            {
                if (currentPatient.Sick_Degree == "3")
                {
                    lmsg3.Visible = true;
                }
                else if (currentPatient.Sick_Degree == "2")
                {
                    lmsg3.Text = "���ػ��߻����¼ÿ������һ��";
                    lmsg3.Visible = true;
                }
                else
                {
                    lmsg3.Visible = false;
                }
            }


            #endregion
        }
    }
}
