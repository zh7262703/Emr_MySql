using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using Base_Function.BLL_NURSE.Nereuse_record;
using Base_Function.MODEL;
using Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls;
using System.Threading;
using Base_Function.BASE_COMMON;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_NURSE.Nurse_Record
{
    public partial class UcNurse_Record_NewBorn : UserControl
    {
        public UcNurse_Record_NewBorn()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �������ֵ�
        /// ��:������
        /// ֵ:��Ŀ����
        /// </summary>
        Dictionary<int, string> dictColumnName = new Dictionary<int, string>();
        ColumnInfo[] cols = new ColumnInfo[35];
        /// <summary>
        /// �����¼���ж���ļ���
        /// </summary>
        ArrayList nurses = new ArrayList();
        ArrayList SumNusers = new ArrayList();
        ArrayList SumNusersRecords = new ArrayList();

        #region �ֵ�
        ListDictionary ldDuckItem = new ListDictionary();//�ܵ���Ŀ
        ListDictionary ldEye = new ListDictionary();//��
        ListDictionary ldMouth = new ListDictionary();//��
        ListDictionary ldNavel = new ListDictionary();//��
        ListDictionary ldButtocks = new ListDictionary();//��
        ListDictionary ldShower = new ListDictionary();//��ԡ
        ListDictionary ldSpongeBath = new ListDictionary();//��ԡ
        ListDictionary ldPosition = new ListDictionary();//��λ
        ListDictionary ldSkin = new ListDictionary();//Ƥ��
        ListDictionary ldSuck = new ListDictionary();//��˱
        ListDictionary ldAutoActive = new ListDictionary();//�����
        ListDictionary ldAcra = new ListDictionary();//֫��
        ListDictionary ldCry = new ListDictionary();
        #endregion
        /// <summary>
        /// ���
        /// </summary>
        public string diagnose = "";

        /// <summary>
        /// ���ǰ��ҩ������
        /// </summary>
        string oldInAmountName = "";

        /// <summary>
        /// ��ǰ����
        /// </summary>
        InPatientInfo currentPatient = null;
        /// <summary>
        /// ��¼���� B����������
        /// </summary>
        string strType="";

        Class_Take_over_SEQ[] Take_over_seq;

        public UcNurse_Record_NewBorn(InPatientInfo patient)
        {
            InitializeComponent();
            currentPatient = patient;
            strType = "B";
            Take_over_SEQ();//�󶨰��
            SetCellData();
            LoadDiagnose();
        }

        /// <summary>
        /// �󶨰�α�
        /// </summary>
        private void Take_over_SEQ()
        {
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
            dictColumnName.Add(1, "����");
            dictColumnName.Add(2, "ʪ��");
            dictColumnName.Add(3, "����");
            dictColumnName.Add(4, "����");
            dictColumnName.Add(5, "����");
            dictColumnName.Add(6, "Ѫѹ");
            dictColumnName.Add(7, "Ѫ�����Ͷ�");
            dictColumnName.Add(8, "ҩ������");
            dictColumnName.Add(9, "ҩ����");
            dictColumnName.Add(10, "�ٶ�");
            dictColumnName.Add(11, "ĸ��");
            dictColumnName.Add(12, "ˮ");
            dictColumnName.Add(13, "�䷽��");
            dictColumnName.Add(14, "С��");
            dictColumnName.Add(15, "��ɫ");
            dictColumnName.Add(16, "���");
            dictColumnName.Add(17, "��״");
            dictColumnName.Add(18, "Ż����");
            dictColumnName.Add(19, "�ܵ�");
            dictColumnName.Add(20, "��");
            dictColumnName.Add(21, "��");
            dictColumnName.Add(22, "��");
            dictColumnName.Add(23, "��");
            dictColumnName.Add(24, "��ԡ");
            dictColumnName.Add(25, "��ԡ");
            dictColumnName.Add(26, "��λ");
            dictColumnName.Add(27, "Ƥ��");
            dictColumnName.Add(28, "����");
            dictColumnName.Add(29, "��˱");
            dictColumnName.Add(30, "�����");
            dictColumnName.Add(31, "֫��");
            dictColumnName.Add(32, "�����ʩ");
            dictColumnName.Add(33, "ǩ��");
        }

        #region �������
        /// <summary>
        /// ������
        /// </summary>
        public void ShowData()
        {
            SetTable();
            GetDatas(false);
            try
            {
            //������ͬ��ʱ��
                string tempDateTime = null;
                Class_Nurse_Record_NewBorn[] nurse = new Class_Nurse_Record_NewBorn[nurses.Count];
                for (int i = 0; i < nurses.Count; i++)
                {
                    nurse[i] = new Class_Nurse_Record_NewBorn();
                    nurse[i] = nurses[i] as Class_Nurse_Record_NewBorn;

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
                //SetTable();
                flgView.Rows.Count = 4 + nurses.Count;
                try
                {
                    if (nurse.Length != 0)
                    {
                        //nurse[nurse.Length - 1] = new Class_Nurse_Record();
                        App.ArrayToGrid(flgView, nurse, cols, 3);
                    }
                    else
                    {
                        flgView.Rows.Count = 3;
                    }
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("���ݼ��ش���!����:" + ex.Message);
            }
            CellUnit();
            //flgView.Refresh();
            flgView.AutoSizeCols();
            flgView.AutoSizeRows();
        }

        /// <summary>
        /// ��ͷ����
        /// </summary>
        private void SetTable()
        {
            flgView.Cols.Count = 35;
            flgView.Rows.Count = 4 + nurses.Count;
            flgView.Rows.Fixed = 3;
            //��ͷ����
            cols[0].Name = "����ʱ��";
            cols[0].Field = "dateTime";
            cols[0].Index = 1;
            cols[0].visible = true;

            //����̶�
            cols[1].Name = "����";
            cols[1].Field = "boxT";
            cols[1].Index = 2;
            cols[1].visible = true;

            //������
            cols[2].Name = "ʪ��";
            cols[2].Field = "humidity";
            cols[2].Index = 3;
            cols[2].visible = true;

            //����
            cols[3].Name = "����";
            cols[3].Field = "t";
            cols[3].Index = 4;
            cols[3].visible = true;

            //����
            cols[4].Name = "����";
            cols[4].Field = "hr";
            cols[4].Index = 5;
            cols[4].visible = true;

            //����
            cols[5].Name = "����";
            cols[5].Field = "r";
            cols[5].Index = 6;
            cols[5].visible = true;

            //Ѫѹ
            cols[6].Name = "Ѫѹ";
            cols[6].Field = "bp";
            cols[6].Index = 7;
            cols[6].visible = true;

            //Ѫ�����Ͷ�
            cols[7].Name = "Ѫ�����Ͷ�";
            cols[7].Field = "oxygen_saturation";
            cols[7].Index = 8;
            cols[7].visible = true;

            //ҩ������
            cols[8].Name = "ҩ������";
            cols[8].Field = "medicineName";
            cols[8].Index = 9;
            cols[8].visible = true;

            //ҩ����
            cols[9].Name = "ҩ����";
            cols[9].Field = "medicineValue";
            cols[9].Index = 10;
            cols[9].visible = true;

            //�ٶ�
            cols[10].Name = "�ٶ�";
            cols[10].Field = "v";
            cols[10].Index = 11;
            cols[10].visible = true;

            //ĸ��
            cols[11].Name = "ĸ��";
            cols[11].Field = "breastMilk";
            cols[11].Index = 12;
            cols[11].visible = true;

            //ˮ
            cols[12].Name = "ˮ";
            cols[12].Field = "water";
            cols[12].Index = 13;
            cols[12].visible = true;

            //�䷽��
            cols[13].Name = "�䷽��";
            cols[13].Field = "formula";
            cols[13].Index = 14;
            cols[13].visible = true;

            //С��
            cols[14].Name = "С��";
            cols[14].Field = "urine";
            cols[14].Index = 15;
            cols[14].visible = true;

            //��ɫ
            cols[15].Name = "��ɫ";
            cols[15].Field = "uColor";
            cols[15].Index = 16;
            cols[15].visible = true;

            //���
            cols[16].Name = "���";
            cols[16].Field = "shit";
            cols[16].Index = 17;
            cols[16].visible = true;

            //��״
            cols[17].Name = "��״";
            cols[17].Field = "characteristics";
            cols[17].Index = 18;
            cols[17].visible = true;

            //Ż����
            cols[18].Name = "Ż����";
            cols[18].Field = "puke";
            cols[18].Index = 19;
            cols[18].visible = true;

            //�ܵ�
            cols[19].Name = "�ܵ�";
            cols[19].Field = "ductItem";
            cols[19].Index = 20;
            cols[19].visible = true;

            //��
            cols[20].Name = "��";
            cols[20].Field = "eye";
            cols[20].Index = 21;
            cols[20].visible = true;

            //��
            cols[21].Name = "��";
            cols[21].Field = "mouth";
            cols[21].Index = 22;
            cols[21].visible = true;

            //��
            cols[22].Name = "��";
            cols[22].Field = "navel";
            cols[22].Index = 23;
            cols[22].visible = true;

            //��
            cols[23].Name = "��";
            cols[23].Field = "buttocks";
            cols[23].Index = 24;
            cols[23].visible = true;

            //��ԡ
            cols[24].Name = "��ԡ";
            cols[24].Field = "shower";
            cols[24].Index = 25;
            cols[24].visible = true;

            //��ԡ
            cols[25].Name = "��ԡ";
            cols[25].Field = "spongeBath";
            cols[25].Index = 26;
            cols[25].visible = true;

            //��λ
            cols[26].Name = "��λ";
            cols[26].Field = "position";
            cols[26].Index = 27;
            cols[26].visible = true;

            //Ƥ��
            cols[27].Name = "Ƥ��";
            cols[27].Field = "skin";
            cols[27].Index = 28;
            cols[27].visible = true;

            //����
            cols[28].Name = "����";
            cols[28].Field = "cry";
            cols[28].Index = 29;
            cols[28].visible = true;

            //��˱
            cols[29].Name = "��˱";
            cols[29].Field = "suck";
            cols[29].Index = 30;
            cols[29].visible = true;

            //�����
            cols[30].Name = "�����";
            cols[30].Field = "autoactive";
            cols[30].Index = 31;
            cols[30].visible = true;

            //֫��
            cols[31].Name = "֫��";
            cols[31].Field = "acra";
            cols[31].Index = 32;
            cols[31].visible = true;

            //�����ʩ
            cols[32].Name = "�����ʩ";
            cols[32].Field = "nurseResult";
            cols[32].Index = 33;
            cols[32].visible = true;

            //ǩ��
            cols[33].Name = "ǩ��";
            cols[33].Field = "signature";
            cols[33].Index = 34;
            cols[33].visible = true;

            cols[34].Name = "SumID";
            cols[34].Field = "Number";
            cols[34].Index = 35;
            cols[34].visible = false;
        }

        /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        private void CellUnit()
        {
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 2, 0);
            cr.Data = "����\r\n/\r\nʱ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 2, 1);
            cr.Data = "��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 2, 2);
            cr.Data = "ʪ\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 7);
            cr.Data = "�����Ŀ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 3, 2, 3);
            cr.Data = "��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 4, 2, 4);
            cr.Data = "��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 5, 2, 5);
            cr.Data = "��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 6, 2, 6);
            cr.Data = "Ѫѹ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 7, 2, 7);
            cr.Data = "Ѫ��\n���Ͷ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 8, 0, 13);
            cr.Data = "����(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 8, 1, 10);
            cr.Data = "ҩ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 8, 2, 8);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 9, 2, 9);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 10, 2, 10);
            cr.Data = "�ٶ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 11, 2, 11);
            cr.Data = "ĸ\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 12, 2, 12);
            cr.Data = "ˮ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 13, 2, 13);
            cr.Data = "��\n��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 14, 0, 18);
            cr.Data = "����(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 14, 1, 15);
            cr.Data = "С��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 14, 2, 14);
            cr.Data = "��\n��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 15, 2, 15);
            cr.Data = "ɫ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 16, 1, 17);
            cr.Data = "���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(2, 16, 2, 16);
            cr.Data = "��\n��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 17, 2, 17);
            cr.Data = "��\n״";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 18, 2, 18);
            cr.Data = "Ż\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 19, 2, 19);
            cr.Data = "��\n��\n��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 20, 0, 26);
            cr.Data = "��   ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 20, 2, 20);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 21, 2, 21);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 22, 2, 22);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 23, 2, 23);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 24, 2, 24);
            cr.Data = "��\nԡ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 25, 2, 25);
            cr.Data = "��\nԡ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 26, 2, 26);
            cr.Data = "��\nλ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 27, 0, 31);
            cr.Data = "����۲�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 27, 2, 27);
            cr.Data = "Ƥ\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 28, 2, 28);
            cr.Data = "��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 29, 2, 29);
            cr.Data = "��\n˱";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 30, 2, 30);
            cr.Data = "��\n��\n��\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 31, 2, 31);
            cr.Data = "֫\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 32, 2, 32);
            cr.Data = "����\n��ʩ��Ч��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 33, 2, 33);
            cr.Data = "ǩ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //flgView.AutoSizeCols();
            flgView.Cols[27].Width = 35;
            flgView.Cols[28].Width = 35;
            flgView.Cols[32].Width = 100;
            flgView.AutoSizeRows();
        }

        private void SetCellData()
        {
            //�ܵ�
            ldDuckItem.Add("0", "-");
            ldDuckItem.Add("1", "+");
            ldDuckItem.Add("nul", " ");

            //��
            ldEye.Add("0", "��");
            ldEye.Add("1", " ");

            //��
            ldMouth.Add("0", "��");
            ldMouth.Add("1", " ");

            //��
            ldNavel.Add("0", "��");
            ldNavel.Add("1", " ");

            //��
            ldShower.Add("0", "��");
            ldShower.Add("1", " ");

            //��ԡ
            ldSpongeBath.Add("0", "��");
            ldSpongeBath.Add("1", " ");

            //��ԡ
            ldButtocks.Add("0", "��");
            ldButtocks.Add("1", " ");

            //��λ
            ldPosition.Add("0", "��");
            ldPosition.Add("1", "��");
            ldPosition.Add("2", "ƽ");
            ldPosition.Add("3", "��");
            ldPosition.Add("4", " ");

            //Ƥ��
            ldSkin.Add("0", "����");
            ldSkin.Add("1", "����");
            ldSkin.Add("3", "����");
            ldSkin.Add("4", "�Ի�");
            ldSkin.Add("5", "��Ⱦ");
            ldSkin.Add("6", "����");
            ldSkin.Add("7", "�԰�");
            ldSkin.Add("2", " ");

            //��˱
            ldSuck.Add("0", "Э��");
            ldSuck.Add("1", "��Э��");
            ldSuck.Add("2", "����");
            ldSuck.Add("3", "��");

            //֫��
            ldAcra.Add("0", "��");
            ldAcra.Add("1", "��");
            ldAcra.Add("2", " ");

            //�����
            ldAutoActive.Add("0", "��");
            ldAutoActive.Add("1", "��");
            ldAutoActive.Add("2", " ");

            //����
            ldCry.Add("0", "����");
            ldCry.Add("1", "����");
            ldCry.Add("2", "˻��");
            ldCry.Add("4", "��");
            ldCry.Add("3", " ");
        }

        /// <summary>
        /// �󶨱������
        /// </summary>
        private void bindColData()
        {
            try
            {
                flgView.Cols[19].DataMap = ldDuckItem;//�ܵ�
                flgView.Cols[20].DataMap = ldEye;//��
                flgView.Cols[21].DataMap = ldMouth;//��
                flgView.Cols[22].DataMap = ldNavel;//��
                flgView.Cols[23].DataMap = ldButtocks;//��
                flgView.Cols[24].DataMap = ldShower;//��ԡ
                flgView.Cols[25].DataMap = ldSpongeBath;//��ԡ
                flgView.Cols[26].DataMap = ldPosition;//��λ
                flgView.Cols[27].DataMap = ldSkin;//Ƥ��
                flgView.Cols[28].DataMap = ldCry;//����
                flgView.Cols[29].DataMap = ldSuck;//��˱
                flgView.Cols[30].DataMap = ldAutoActive;//�����
                flgView.Cols[31].DataMap = ldAcra;//֫��
            }
            catch
            { }
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
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where RECORD_TYPE='B' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//�Լ��޸ĵĻ���
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
            frmNursePrint_Records ff = new frmNursePrint_Records(ReSetPrintDataSet(ds),diagnose, currentPatient, strType);
            ff.Show();
        }

        public DataSet GetNusersRecords()
        {
            DataSet ds = null;
            GetDatas(true);
            SumInOrOutRecordSets();
            Class_Nurse_Record_NewBorn[] cNurse = new Class_Nurse_Record_NewBorn[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                cNurse[i] = new Class_Nurse_Record_NewBorn();
                cNurse[i] = nurses[i] as Class_Nurse_Record_NewBorn;
                //    //if (cNurse[i].In_item_name == null)
                //    //{
                //    //    cNurse[i].In_item_name = "";
                //    //}
                //    //����ת������������
                //    //if (cNurse[i].Consciousness != null)
                //    //    cNurse[i].Consciousness = ldConsciousness[cNurse[i].Consciousness].ToString();

            }
            ds = App.ObjectArrayToDataSet(cNurse);
            return ds;
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
            if (flgView[rowSel, 0] != null && flgView[rowSel, 0].ToString() != "")
            {
                dateTime = flgView[rowSel, 0].ToString();
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
            flgView.AutoSizeCol(e.Col);
        }
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            //ǩ���в�����༭
            if (e.Col == 33)
            {
                e.Cancel = true;
                return;
            }
            if (flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "")
            {
                if (e.Col == 8)
                {
                    string measureTime = GetTime(e.Row);
                    //��֤Ȩ��
                    DateTime objDataTime;
                    if (measureTime != "" && DateTime.TryParse(measureTime, out objDataTime))//ʱ��Ϊ��˵����������ݣ�������֤Ȩ��
                    {
                        string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                        if (!ValidateUser(operateId))//App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                        {
                            App.Msg("Ȩ�޲��㣡");
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(),"B");
                        fsd.ShowDialog();
                        if (fsd.flag)
                            flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                        //flgView.Col = 1;
                        e.Cancel = true;
                        return;
                    }
                }
                else if (e.Col == 9 || e.Col == 10)
                {
                    if (flgView[e.Row, 8] == null || flgView[e.Row, 8].ToString() == "")
                    {
                        App.Msg("��������ҩ�����ƣ�");
                        flgView.Col = 8;
                        return;
                    }
                }
                else
                {
                    if (flgView[e.Row, 8] != null && flgView[e.Row, 8].ToString().Length > 0)
                    {
                        e.Cancel = true;
                        return;
                    }
                    //App.Msg("��ѡ�����ʱ�䣡");
                    FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), "B");
                    fsd.ShowDialog();
                    if (fsd.flag)
                        flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                    //flgView.Col = 1;
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                //if (flgView.Col == 32)
                //{
                //    //this.��ȡ��עģ��ToolStripMenuItem_Click(sender, e);
                //    //return;
                //}
                if (flgView[e.Row, 8] != null && (flgView[e.Row, 8].ToString().Contains("�ܽ�") || flgView[e.Row, 8].ToString().Contains("С��")))
                {
                    int id = 0;
                    if (flgView[e.Row, 34] != null && flgView[e.Row, 34].ToString().Length > 0)
                    {
                        try
                        {
                            id = int.Parse(flgView[e.Row, 34].ToString());
                        }
                        catch { }
                    }
                    if (id == 0)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(flgView[e.Row, 0].ToString());
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and  patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (ValidateUser(operateId) || operateId == null)//operateId == null || App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                    {
                        if (e.Col == 0)
                        {
                            FrmSetDatetime fsd = new FrmSetDatetime(dt, currentPatient.Id.ToString(), "B");
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
                                    dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id.ToString() + "";

                                if (App.ExecuteSQL(sql) == 0 && operateId != null)
                                {
                                    App.MsgErr("�޸�ʱ��û���޸ĳɹ���");
                                }
                            }
                        }
                        if (e.Col == 9 || e.Col == 10)
                        {
                            if (flgView[e.Row, 8] == null || flgView[e.Row, 8].ToString() == "")
                            {
                                App.Msg("��������ҩ�����ƣ�");
                                flgView.Col = 8;
                                return;
                            }
                        }
                    }
                    else
                    {
                        App.Msg("�޸�Ȩ�޲��㣡");
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        #endregion

        private void flgView_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            try
            {
                if (e.Col == 0 )//|| e.Col == 32)//ʱ������,��ע��ֹ�ֶ�����
                {
                    e.Handled = true;
                }
                if (e.Col == 1|| e.Col == 9 || e.Col == 11 || e.Col == 12 || e.Col == 13)
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    {
                        if (e.Col == 9 && e.KeyChar == '-')
                        {
                            e.Handled = false;
                        }
                        else
                            e.Handled = true;
                    }
                }
                if (e.Col == 2 || e.Col == 4 || e.Col == 5 || e.Col == 7)
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                //if (e.Col == 14 || e.Col == 16)//��С����������g���Ρ���ֵ
                //{

                //}
                if (e.Col == 6)//Ѫѹ
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '/')
                    {
                        e.Handled = true;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// ���ñ༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_SetupEditor(object sender, RowColEventArgs e)
        {
            oldInAmountName = "";
            try
            {
                if ((e.Col == 8||e.Col==9||e.Col==10) && flgView[e.Row, 8] != null && flgView[e.Row, 8].ToString() != "")//ҩ��������
                {
                    //�����޸�ǰ��ҩ������
                    if (flgView[e.Row, 8] != null)
                    {
                        oldInAmountName = flgView[e.Row, 8].ToString();
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //oldDuct_name = "";
            ShowData();
            SumInOrOutRecordSet(true);
            ShowSumDataGrid();
            flgView.Cols[2].Width = 30;
            flgView.Cols[32].Width = 100;
            flgView.Cols[27].Width = 35;
            flgView.Cols[28].Width = 35;
            //flgView.AutoSizeCols();
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
            if (flgView[e.Row, e.Col] != null && flgView[e.Row, e.Col].ToString() != "")
            {
                string measureTime = GetTime(e.Row);
                string itemCode = "";
                string itemValue = "";
                string itemName = "";
                string otherName = "";
                int id = 0;
                if (e.Col > 18 && e.Col < 32)
                {
                    ListDictionary ldCommon = GetDictionaryByColIndex(e.Col);
                    itemValue = ldCommon[flgView[e.Row, e.Col].ToString()].ToString();
                    itemCode = flgView[e.Row, e.Col].ToString();
                    itemName = dictColumnName[e.Col];
                }
                else if (e.Col > 7 && e.Col < 11)//ҩ��
                {
                    //ҩ������
                    otherName = flgView[e.Row, 8] == null ? "" : flgView[e.Row, 8].ToString();
                    //ҩ����
                    itemValue = flgView[e.Row, 9] == null ? "" : flgView[e.Row, 9].ToString();
                    //ҩ���ٶ�
                    itemCode = flgView[e.Row, 10] == null ? "" : flgView[e.Row, 10].ToString();
                    itemName = "ҩ��";
                    if (flgView[e.Row, 34] != null&&flgView[e.Row,34].ToString().Length>0)
                    {
                        try
                        {
                            id = int.Parse(flgView[e.Row, 34].ToString());
                        }
                        catch { }
                    }
                    //if (e.Col == 8)
                    //{
                    //    string s = App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "' and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)");
                    //    if (s != "0" && oldInAmountName != otherName)
                    //    {
                    //        App.Msg("ҩ�������ظ�!");
                    //        this.flgView[e.Row, e.Col] = oldInAmountName;
                    //        this.flgView.Col = e.Col;
                    //        return;
                    //    }
                    //}
                }
                else if (e.Col == 14 || e.Col == 15)//С��
                {
                    //�����
                    itemValue = flgView[e.Row, 14] == null ? "" : flgView[e.Row, 14].ToString();
                    //ɫ
                    itemCode = flgView[e.Row, 15] == null ? "" : flgView[e.Row, 15].ToString();
                    itemName = "С��";
                }
                else if (e.Col == 16 || e.Col == 17)//���
                {
                    //�����
                    itemValue = flgView[e.Row, 16] == null ? "" : flgView[e.Row, 16].ToString();
                    //��״
                    itemCode = flgView[e.Row, 17] == null ? "" : flgView[e.Row, 17].ToString();
                    itemName = "���";
                }

                else
                {
                    itemValue = flgView[e.Row, e.Col].ToString();
                    if (e.Col == 33)//��ע����֤�ַ�����
                    {
                        int length = getStringLength(itemValue);
                        if (length > 1000)
                        {
                            App.Msg("����������ݳ���1000�ֽ���!");
                            return;
                        }
                    }
                    itemName = dictColumnName[e.Col];
                    itemCode = App.ReadSqlVal("select id from t_nurse_record_dict where item_name='" + itemName + "'", 0, "id");

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
                if (e.Col < 8 || e.Col > 10)
                {
                    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                }
                else //������֤��������othername
                {
                    if (id == 0)
                    {
                        itemCount = 0;
                    }
                    else
                    {
                        itemCount = 1;
                    }
                    //string strName = string.IsNullOrEmpty(oldInAmountName) ? otherName : oldInAmountName;
                    //itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + strName + "'  and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                }
                string sql = "";
                if (itemCount == 0)
                {
                    if (otherName == "")
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + strType + "')";
                    }
                    else
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + otherName + "','" + strType + "')";
                    }
                }
                else
                {

                    //string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    //if (App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                    //{
                    //    App.Msg("�޸�Ȩ�޲���!");
                    //    btnSearch_Click(sender, e);
                    //    return;
                    //}
                    if (!ValidateUser(userId))
                    {
                        App.Msg("�޸�Ȩ�޲���!");
                        btnSearch_Click(sender, e);
                        return;
                    }
                    if (otherName == "")
                    {
                        sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                        sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                    }
                    else
                    {
                        sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                        //sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "'";
                        //if (string.IsNullOrEmpty(oldInAmountName))
                        //{
                        //    sql += " and other_name='" + otherName + "'";
                        //}
                        //else
                        //{
                        //    sql += " and other_name='" + oldInAmountName + "'";
                        //}
                        //sql += " and record_type='" + strType + "' and patient_id=" + currentPatient.Id;

                        //int id = int.Parse(flgView[e.Row, 35].ToString());
                        sql += " where id=" + id;
                    }

                }
                int num = App.ExecuteSQL(sql);
                if (num > 0)
                {
                    timer1.Start();
                    operateFlag = true;
                    //����ǩ��
                    if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "" && flgView[e.Row, 34] == null && sql.Contains("insert"))
                    {
                        flgView[e.Row, 33] = App.UserAccount.UserInfo.User_name;
                    }
                    if (otherName.Length > 0 && id == 0&&sql.ToLower().Contains("insert"))
                    {
                        btnSearch_Click(sender, e);
                    }
                    //App.Msg("�����ɹ���");
                    //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "',create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                    //
                }
            }
            #endregion
        }

        /// <summary>
        /// �����е�������ö�Ӧ���ֵ伯��
        /// </summary>
        /// <returns>�����ֵ�</returns>
        private ListDictionary GetDictionaryByColIndex(int col)
        {
            switch (col)
            {
                case 19:
                    return ldDuckItem;
                case 20:
                    return ldEye;
                case 21:
                    return ldMouth;
                case 22:
                    return ldNavel;
                case 23:
                    return ldButtocks;
                case 24:
                    return ldShower;
                case 25:
                    return ldSpongeBath;
                case 26:
                    return ldPosition;
                case 27:
                    return ldSkin;
                case 28:
                    return ldCry;
                case 29:
                    return ldSuck;
                case 30:
                    return ldAutoActive;
                case 31:
                    return ldAcra;
                default:
                    return null;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            //lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            //lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            
            cboTiming_SelectedIndexChanged(sender, e);
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
                //tHour = sp.TotalHours;
                //lblTatolTime.Text = tHour.ToString().Split('.')[0];
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
                    //tHour = sp.TotalHours;
                    //lblTatolTime.Text = tHour.ToString().Split('.')[0];
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
                FrmSumItem sum_item = new FrmSumItem(sum_id, "B");
                sum_item.ShowDialog();
                if (!sum_item.successflag)
                {//û�в����ɹ�,�������ͳ�Ƽ�¼
                    string del = "delete from t_nurse_dangery_inout_sum_h where id=" + sum_id + " and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
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
            Class_Nurse_Record_NewBorn[] Nusers_objs = new Class_Nurse_Record_NewBorn[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                Nusers_objs[i] = new Class_Nurse_Record_NewBorn();
                Nusers_objs[i] = (Class_Nurse_Record_NewBorn)nurses[i];
            }
            //SetTable();//��ͷ����
            flgView.Rows.Count = 4 + nurses.Count;
            if (Nusers_objs.Length != 0)
            {
                //Nusers_objs[Nusers_objs.Length - 1] = new Class_Nurse_Record();
                App.ArrayToGrid(flgView, Nusers_objs, cols, 3);
            }


            //�����ܼ�����в���ID
            for (int i = 0; i < Nusers_objs.Length; i++)
            {
                if (Nusers_objs[i].Number != null)
                {
                    flgView[i + 3, 34] = Nusers_objs[i].Number;
                }
            }
            //��Ԫ��ϲ�������
            CellUnit();
            this.flgView.AutoSizeCols();
            this.flgView.AutoSizeRows();
            //for (int i = 0; i < flgView.Rows.Count; i++)
            //{
            //    if (flgView[i, 12] != null)
            //    {
            //        if (flgView[i, 12].ToString().Contains("С��") || flgView[i, 12].ToString().Contains("������"))
            //        {
            //            flgView.Rows[i].AllowEditing = false;
            //        }
            //        else
            //        {
            //            flgView.Rows[i].AllowEditing = true;
            //        }
            //    }
            //}
        }
        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            //tHour = sp.TotalHours;
            //lblTatolTime.Text = tHour.ToString().Split('.')[0];
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "��";
            lblTatolTime.Text = tHour;
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            //tHour = sp.TotalHours;
            //lblTatolTime.Text = tHour.ToString().Split('.')[0];
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "��";
            lblTatolTime.Text = tHour;
        }
        private void dtpDateSelect_ValueChanged(object sender, EventArgs e)
        {
            cboTiming_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// ���ü������������
        /// </summary>
        private void SumInOrOutRecordSet(bool IsToDay)
        {
            SumNusersRecords.Clear();
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id;
            if(IsToDay)
            {
                sql_date+= " and  to_char(end_time,'yyyy-MM-dd')='" + date + "'";
            }
            sql_date += " and record_type='" + strType + "'";
            sql_date += " order by end_time";
            DataSet ds_sum_oper = App.GetDataSet(sql_date);

            for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            {
                //SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);

                SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            }

            for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            {
                string BeginTime, EndTime, Item_name;
                string Number = "";//����
                string seq_id = "";//ͳ������ID
                string singsure = ""; //ǩ��
                double dinsum = 0;//����
                double dmedicine = 0;//ҩ��
                double dbreastmilk = 0;//ĸ��
                double dwater = 0;//ˮ
                double dformula = 0;//�䷽��
                double doutsum = 0;//����
                double durine = 0;//С��
                double dshit = 0;//���
                double dpuke = 0;//Ż��

                BeginTime = SumNusersRecords[i1].ToString().Split(',')[0];
                EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
                Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
                Number = SumNusersRecords[i1].ToString().Split(',')[3];
                seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
                //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
                singsure = SumNusersRecords[i1].ToString().Split(',')[5];
                string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');
                SumNusers.Clear();

                Class_Nurse_Record_NewBorn sumtemp = new Class_Nurse_Record_NewBorn ();

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

                StringBuilder sbSum = new StringBuilder("select item_show_name as ItemName,a.item_value as ItemValue,a.other_name as ItemCode from t_nurse_record a");
                sbSum.Append(" where 1=1");
                sbSum.Append(" and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME");
                sbSum.Append(" " + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name in('ҩ��','ĸ��','ˮ','�䷽��','С��','���','Ż����')");
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
                        string strTempValue = drSum["ItemValue"].ToString();
                        string strTempCode = drSum["ItemCode"].ToString();
                        if (Double.TryParse(strTempValue, out dtmp))
                        {
                            switch (strTempName)
                            {
                                case "ҩ��":
                                    if (strTempCode.Contains("��Һ"))
                                    {
                                        dtmp = -Math.Abs(dtmp);
                                    }
                                    else if (strTempCode.Equals("��Һ"))
                                    {
                                        dtmp = 0;
                                    }
                                    else if (strTempCode.Equals("��Һ+"))
                                    {
                                        dtmp = Math.Abs(dtmp);
                                    }
                                    else if (strTempCode.Equals("��Һ-"))
                                    {
                                        dtmp = -Math.Abs(dtmp);
                                    }
                                    dmedicine += dtmp;
                                    break;
                                case "ĸ��":
                                    dbreastmilk += dtmp;
                                    break;
                                case "ˮ":
                                    dwater += dtmp;
                                    break;
                                case "�䷽��":
                                    dformula += dtmp;
                                    break;
                                case "���":
                                    dshit += dtmp;
                                    break;
                                case "С��":
                                    durine += dtmp;
                                    break;
                                case "Ż����":
                                    dpuke += dtmp;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                dinsum = dmedicine + dbreastmilk + dwater + dformula;
                doutsum = durine + dshit + dpuke;
                sumtemp.DateTime = Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm");
                sumtemp.MedicineName = Item_name;
                sumtemp.Number = Number;
                //ͳ��ֵΪ0�ľ�����ʾ
                if (Item_name.Contains("�ܽ�"))
                {
                    if (dinsum > 0)
                    {
                        sumtemp.MedicineValue = dinsum.ToString();
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
                            case "ҩ��":
                                if (dmedicine > 0)
                                {
                                    sumtemp.MedicineValue = dmedicine.ToString();
                                }
                                break;
                            case "ĸ��":
                                if (dbreastmilk > 0)
                                {
                                    sumtemp.BreastMilk = dbreastmilk.ToString();
                                }
                                break;
                            case "ˮ":
                                if (dwater > 0)
                                {
                                    sumtemp.Water = dwater.ToString();
                                }
                                break;
                            case "�䷽��":
                                if (dformula > 0)
                                {
                                    sumtemp.Formula = dformula.ToString();
                                }
                                break;
                            case "���":
                                if (dshit > 0)
                                {
                                    sumtemp.Shit = dshit.ToString();
                                }
                                break;
                            case "С��":
                                if (durine > 0)
                                {
                                    sumtemp.Urine = durine.ToString();
                                }
                                break;
                            case "Ż��":
                                if (dpuke > 0)
                                {
                                    sumtemp.Puke = dpuke.ToString();
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
                    SumNusers.Add(nurses[i]);
                }

                for (int i = 0; i < nurses.Count; i++)
                {
                    Class_Nurse_Record_NewBorn temp_nuser = (Class_Nurse_Record_NewBorn)SumNusers[i];
                    if (temp_nuser.DateTime != null)
                    {
                        TempDate = Convert.ToDateTime(temp_nuser.DateTime);

                        if (TempDate == Convert.ToDateTime(EndTime))
                        {
                            if (tempSeq != null && tempSeq.End_logic == "0")//�������Ϊ��0�������ܲ嵽��ͬʱ������Ŀ֮ǰ
                            {
                                SumNusers.Insert(i, sumtemp);
                                break;
                            }
                        }
                        else if (TempDate > Convert.ToDateTime(EndTime))//����ʱ��С�ڵ�ǰ¼��ʱ�䣬�嵽������Ŀ֮ǰ
                        {
                            SumNusers.Insert(i, sumtemp);
                            break;
                        }
                    }
                    if (i == SumNusers.Count - 1)
                    {
                        SumNusers.Add(sumtemp);
                        break;
                    }
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
            flgView.Rows.Insert(flgView.RowSel);
        }  

        /// <summary>
        /// ɾ���л���ɾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            int rowindex = flgView.Row;
            int colindex = flgView.Col;
            string measureTime = GetTime(rowindex);
            object obj = flgView[rowindex, colindex];
            object obj2 = flgView[rowindex, 8];
            if (obj != null && obj.ToString().Trim().Length > 0)
            {
                string sql = "";
                int id = 0;
                if (flgView[rowindex, 34] != null && flgView[rowindex, 34].ToString().Length > 0)
                {
                    try
                    {
                        id = int.Parse(flgView[rowindex, 34].ToString());
                    }
                    catch { }
                }
                if (colindex == 0&&(obj2==null||(obj2!=null&&!obj2.ToString().Contains("С��")&&!obj2.ToString().Contains("�ܽ�"))))
                {
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    //ֻ�д����߱��˻��߻�ʿ��Ȩ�޵Ĳ���ɾ����¼
                    if (App.UserAccount.UserInfo.User_id == operateId || operateId == null || operateId == ""||App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                    {
                        sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                    }
                    else
                    {
                        App.Msg("Ȩ�޲��㣡");
                        return;
                    }
                }
                else if (id == 0 && obj2 != null && (flgView[rowindex, 8].ToString().Contains("С��") || flgView[rowindex, 8].ToString().Contains("�ܽ�")))
                {
                    string signature = App.ReadSqlVal("select signature from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 8].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "signature");
                    if (App.UserAccount.UserInfo.User_name == signature || signature == null || signature == "" || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                    {
                        sql = "delete from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 8].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
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
                    string itemName = dictColumnName[flgView.Col];
                    if (itemName.Contains("ҩ��"))
                    {
                        if (flgView[flgView.Row, 34] != null && flgView[flgView.Row, 34].ToString().Length > 0)
                        {
                            try
                            {
                                id = int.Parse(flgView[flgView.Row, 34].ToString());
                            }
                            catch { }
                        }
                    }
                    if (id == 0)
                    {
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                        //ֻ�д����߱��˻��߻�ʿ��Ȩ�޵Ĳ���ɾ����¼
                        if (App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                        {
                            App.Msg("Ȩ�޲��㣡");
                            return;
                        }
                    }
                    else
                    {
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id + " order by id", 0, "creat_id"));
                        //ֻ�д����߱��˻��߻�ʿ��Ȩ�޵Ĳ���ɾ����¼
                        if (App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                        {
                            App.Msg("Ȩ�޲��㣡");
                            return;
                        }
                    }
                    if (colindex == 8)//ɾ��ҩ������
                    {
                        if (id > 0)
                        {
                            sql = "delete from t_nurse_record where id=" + id;
                        }
                        else
                        {
                            sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                            sql += " and item_show_name='ҩ��' and other_name='" + obj.ToString() + "'";
                        }
                    }
                    else if (colindex == 9 || colindex == 10)//ɾ��ҩ�������ٶ�
                    {
                        sql = "update t_nurse_record set ";
                        if (colindex == 9)
                        {
                            sql += " item_value=null ";
                        }
                        else
                        {
                            sql += " item_code=null ";
                        }
                        if (id > 0)
                        {
                            sql += " where id=" + id;
                        }
                        else
                        {
                            sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                            sql += " and item_show_name='ҩ��' and other_name='" + obj2.ToString() + "'";
                        }
                    }
                    else//ɾ��������
                    {
                        sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                        sql += " and item_show_name='" + dictColumnName[colindex] + "'";
                    }
                }
                int num = 0;
                try
                {
                    num = App.ExecuteSQL(sql);
                }
                catch
                {

                }
                if (num > 0)
                {
                    btnSearch_Click(this, new EventArgs());
                }
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

        #region ��ӡ�Ű�����
        /// <summary>
        /// ���ݴ�ӡʱ��Ҫ����Ԫ���Ȼ���
        /// </summary>
        /// <param name="ds"></param>
        public DataSet ReSetPrintDataSet(DataSet ds)
        {
            ArrayList DataRows = new ArrayList();
            int maxcount = 0;
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and record_type='" + strType + "' order by DATETIMEVAL asc";
            DataSet ds_Time = App.GetDataSet(sql_time);
            if (ds_Time != null)
            {
                for (int i = 0; i < ds_Time.Tables[0].Rows.Count; i++)
                {
                    ArrayList drDatarows = new ArrayList();
                    for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
                    {
                        if (!ds.Tables[0].Rows[i1]["medicineName"].ToString().Contains("С��") &&
                           !ds.Tables[0].Rows[i1]["medicineName"].ToString().Contains("������") &&
                           !ds.Tables[0].Rows[i1]["medicineName"].ToString().Contains("�ܽ�"))
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
                        int rownurseresult = 32;//��ӡʱ��ע��ʾ���ַ�����
                        List<string> nurseresultlist = new List<string>();

                        string signature = "";
                        maxcount = drArray.Length;
                        if (drArray[0]["nurseResult"] != null && drArray[0]["nurseResult"].ToString().Length > 0)
                        {
                            GetRowNurseResult(drArray[0]["nurseResult"].ToString(), rownurseresult, ref nurseresultlist);
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
                                    drArray[j]["nurseResult"] = nurseresultlist[j];
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
                                        dr["nurseResult"] = nurseresultlist[j];
                                    }
                                    DataRows.Add(dr);
                                }
                                else
                                {
                                    DataRow dr = ds.Tables[0].NewRow();
                                    dr["Signature"] = "";
                                    if (j <= nurseresultlist.Count - 1)
                                    {
                                        dr["nurseResult"] = nurseresultlist[j];
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

            DataRow[] drSum = ds.Tables[0].Select("medicineName like '%������%' or medicineName like '%С��%' or medicineName like '%�ܽ�%'");
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
            //ÿһҳ��ʾ����������
            int pageRows = 25;
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
                if (!dd.Rows[i]["medicineName"].ToString().Contains("С��") &&
                    !dd.Rows[i]["medicineName"].ToString().Contains("�ܽ�") &&
                    !dd.Rows[i]["medicineName"].ToString().Contains("������"))
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
                            //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
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
                        dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
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
                GetRowNurseResult(strNurseResult, rowlenth, ref list);
            }
        }

        /// <summary>
        /// ���ݱ�ע�ĳ��ȷ���string��������
        /// </summary>
        /// <param name="remark">��ע����</param>
        /// <returns></returns>
        private string[] RemarkArray(string remark)
        {

            Graphics graphics = CreateGraphics();
            //SizeF sizeF = graphics.MeasureString(remark, new Font("����", 8));
            int strlength = System.Text.Encoding.Default.GetBytes(remark).Length;
            //��ע��ռ����
            int remarkRowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(strlength) / 61));//Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            string[] strArr = new string[remarkRowCount];
            string tempperval = "";
            int index = 0;//�����������
            for (int j = 0; j < remark.Length; j++)
            {
                strlength = System.Text.Encoding.Default.GetBytes(tempperval).Length;
                if (strlength < 61 || (strlength == 61 && System.Text.Encoding.Default.GetBytes(remark[j].ToString()).Length != 2))
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
                    if (temprow.Table.Columns[i].ColumnName.ToLower() != "number")//number
                    {
                        string tempperval = "";

                        tempperval = perval + olddatarow[i].ToString()[j];


                        SizeF sizeF = graphics.MeasureString(tempperval, new Font("����", 8));
                        if (sizeF.Width <= widthindex * 28.3465)
                        {
                            perval = tempperval;
                            if (j == olddatarow[i].ToString().Length - 1)
                            {
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

        private void flgView_ChangeEdit(object sender, EventArgs e)
        {
            using (Graphics g = flgView.CreateGraphics())
            {
                if (flgView.Col == 32)
                {
                    // measure text height
                    StringFormat sf = new StringFormat();
                    int wid = flgView.Cols[32].WidthDisplay;
                    string text = flgView.Editor.Text;
                    SizeF sz = g.MeasureString(text, flgView.Font, wid, sf);
                    // adjust row height if necessary
                    C1.Win.C1FlexGrid.Row row = flgView.Rows[flgView.Row];
                    if (sz.Height + 4 > row.HeightDisplay)
                        row.HeightDisplay = (int)sz.Height + 4;
                }
            }
        }

        private void UcNurse_Record_NewBorn_Load(object sender, EventArgs e)
        {
            lblDatePriview.Text = App.GetSystemTime().AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + App.GetSystemTime().AddDays(1).ToShortDateString();
            SetDictionaryForItem();
            cboTiming_SelectedIndexChanged(sender, e);
            btnSearch_Click(sender, e);
            bindColData();
            ShowMsg();
            //flgView.Cols.Count = 34;
            //CellUnit();
            //flgView.AutoSizeCols();
            //flgView.AutoSizeRows();
            //flgView.Rows.Fixed = 3;
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="IsAllData"></param>
        private void GetDatas(bool IsAllData)
        {
            nurses.Clear();
            try
            {
                #region ���ݼ���
                string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

                string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where record_type='" + strType + "' and t.patient_Id=" + currentPatient.Id;
                if (!IsAllData)
                {
                    sql_time = sql_time + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                sql_time += " order by DATETIMEVAL asc";
                string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                                " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                                " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where  patient_Id=" + currentPatient.Id + " and record_type='" + strType + "' order by t.create_time asc ";
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

                        //ҩ��
                        DataRow[] dr_InAmount = dt_sets.Select("item_show_name='ҩ��' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                        int index = dr_InAmount.Length;
                        if (index == 0)
                            index = 1;
                        for (int j = 0; j < index; j++)
                        {
                            Class_Nurse_Record_NewBorn temp = new Class_Nurse_Record_NewBorn();
                            temp.DateTime = dateTimeValue;
                            //ҩ��
                            if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                            {
                                temp.MedicineName = dr_InAmount[j]["other_name"].ToString();
                                temp.MedicineValue = dr_InAmount[j]["item_value"].ToString();
                                temp.V = dr_InAmount[j]["item_code"].ToString();
                                temp.Number = dr_InAmount[j]["id"].ToString();
                            }
                            for (int k = 0; k < dr_Values.Length; k++)
                            {
                                if (j == 0)//��������ҩ����Ŀֻ�ڵ�ǰʱ��εĵ�һ����ʾ
                                {
                                    if (dr_Values[k]["item_show_name"].ToString() == "����")
                                    {
                                        temp.BoxT = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "ʪ��")
                                    {
                                        temp.Humidity = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                    {
                                        temp.T = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                    {
                                        temp.HR = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                    {
                                        temp.R = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "Ѫѹ")
                                    {
                                        temp.Bp = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "Ѫ�����Ͷ�")
                                    {
                                        temp.Oxygen_saturation = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "ĸ��")
                                    {
                                        temp.BreastMilk = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "ˮ")
                                    {
                                        temp.Water = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "�䷽��")
                                    {
                                        temp.Formula = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "С��")
                                    {
                                        temp.Urine = dr_Values[k]["item_value"].ToString();
                                        temp.UColor = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "���")
                                    {
                                        temp.Shit = dr_Values[k]["item_value"].ToString();
                                        temp.Characteristics = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "Ż����")
                                    {
                                        temp.Puke = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "�ܵ�")
                                    {
                                        temp.DuctItem = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                    {
                                        temp.Eye = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                    {
                                        temp.Mouth = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                    {
                                        temp.Navel = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��")
                                    {
                                        temp.Buttocks = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��ԡ")
                                    {
                                        temp.Shower = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��ԡ")
                                    {
                                        temp.SpongeBath = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��λ")
                                    {
                                        temp.Position = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "Ƥ��")
                                    {
                                        temp.Skin = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                    {
                                        temp.Cry = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "��˱")
                                    {
                                        temp.Suck = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "�����")
                                    {
                                        temp.Autoactive = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "֫��")
                                    {
                                        temp.Acra = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "�����ʩ")
                                    {
                                        temp.NurseResult = dr_Values[k]["item_value"].ToString();
                                    }
                                }
                                if (j == index - 1)
                                {
                                    temp.Signature = dr_Values[0]["user_name"].ToString();
                                }
                            }
                            nurses.Add(temp);
                        }
                    }

                }
                #endregion
            }
            catch (Exception ex)
            {
                App.MsgErr("���ݼ��ش���!����:" + ex.Message);
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (flgView.Col == 32)
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

        private int PageRowCount = 25;
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
                    lmsg2.Text = "��ҳ��¼ʱ��Ϊ��" + dtime.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    lmsg2.Text = "����ҳ��Ϣ";
                }

            }
            #endregion

            #region ��Σ������ʾ
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

        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            
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
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where Patient_Id =" + currentPatient.Id + " and record_type='" + strType + "'", 0, "diagnose_name");//�Լ��޸ĵĻ���
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

        private void txtDiagnose_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
    }
}
