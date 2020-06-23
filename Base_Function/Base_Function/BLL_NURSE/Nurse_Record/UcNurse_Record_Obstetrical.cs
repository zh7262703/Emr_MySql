using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections;
using Bifrost;
using Base_Function.MODEL;
using C1.Win.C1FlexGrid;
using Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls;
using Base_Function.BLL_NURSE.Nereuse_record;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Base_Function.BASE_COMMON;


namespace Base_Function.BLL_NURSE.Nurse_Record
{
    /// <summary>
    /// ����ģ��
    /// </summary>
    public partial class UcNurse_Record_Obstetrical : UserControl
    {
        /// <summary>
        /// �������ֵ�
        /// ��:������
        /// ֵ:��Ŀ����
        /// </summary>
        Dictionary<int, string> dictColumnName = new Dictionary<int, string>();
        ColumnInfo[] cols = new ColumnInfo[34];
        /// <summary>
        /// �����¼���ж���ļ���
        /// </summary>
        ArrayList nurses = new ArrayList();
        ArrayList SumNusers = new ArrayList();
        ArrayList SumNusersRecords = new ArrayList();
        /// <summary>
        /// ���
        /// </summary>
        public string diagnose = "";
        #region �ֵ�
     
   
        ListDictionary ldConsciousness = new ListDictionary();//��ʶ�ֵ�
       // ListDictionary ldInAmount = new ListDictionary();//�����ֵ�

        ListDictionary ldLinenames = new ListDictionary();//�ܵ�����
        ListDictionary ldLinecase = new ListDictionary(); //�ܵ����

        ListDictionary ldTpl = new ListDictionary(); //̥Ĥ����
        ListDictionary ldSX = new ListDictionary();  //��Ѫ
        ListDictionary ldHz = new ListDictionary();  //����

        ListDictionary ldGas = new ListDictionary();       //��������
        ListDictionary ldfeedskill = new ListDictionary(); //ι��ָ������
  
        #endregion

        #region ��·����
        string pipe1 = "";
        string pipe2 = "";
        string pipe3 = "";
        string pipe4 = "";
        #endregion

        /// <summary>
        /// ���ǰ����������
        /// </summary>
        string oldInAmountName = "";

        /// <summary>
        /// ���ǰ����������
        /// </summary>
        string oldInAmountCode = "";

        /// <summary>
        /// ��ǰ����
        /// </summary>
        InPatientInfo currentPatient = null;

        Class_Take_over_SEQ[] Take_over_seq;

        public UcNurse_Record_Obstetrical()
        {
            InitializeComponent();
        }

        private string strType = "O";
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patient"></param>
        public UcNurse_Record_Obstetrical(InPatientInfo patient)
        {
            InitializeComponent();
            currentPatient = patient;
            Take_over_SEQ();//�󶨰��
            SetCellData();//�󶨵�Ԫ������
            LoadDiagnose();
        }

        private void UcNurse_Record_Obstetrical_Load(object sender, EventArgs e)
        {
            bindColData();
            SetDictionaryForItem();
            flgView.Styles.Normal.WordWrap = true;
            cboTiming_SelectedIndexChanged(sender, e);//����ͳ����ʱ��
            flgView.Cols[14].AllowEditing = false;
            ShowMsg();
        }

        
        /// <summary>
        /// ��ͼ���⹫ʽ
        /// </summary>
        /// <param name="val">��ʽģʽ�����ϣ����ϣ����£����� �����磺123,33,25,167����һ��ģʽ�����磺123</param>
        /// <returns></returns>
        public Image DrawValueImage(string val)
        {
            Pen blackPen = new Pen(Color.Black, 1f);
            if (val.Contains(","))
            {
                string[] strs = val.Split(',');

                string UpL = "";    //����
                string UpR = "";   //����
                string DownL = ""; //����
                string DownR = ""; //����
                Font df = new Font("����", 9f); 
                StringFormat sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.FitBlackBox;
                SizeF UpLSize = new SizeF();
                SizeF UpRSize = new SizeF();
                SizeF DownLSize = new SizeF();
                SizeF DownRSize = new SizeF();
                UpL = strs[0];
                UpR = strs[1];
                DownL = strs[2];
                DownR = strs[3];
                Bitmap bt = new Bitmap(52, 28);
                Graphics g = Graphics.FromImage(bt);
                UpLSize = g.MeasureString(UpL, df);
                UpRSize = g.MeasureString(UpR, df);
                DownLSize = g.MeasureString(DownL, df);
                DownRSize = g.MeasureString(DownR, df);
                //ʮ�ּ�
                g.DrawLine(blackPen, 0, bt.Height / 2, bt.Width, bt.Height / 2);
                g.DrawLine(blackPen, bt.Width / 2, 0, bt.Width / 2, bt.Height);
                //����
                g.DrawString(UpL, df, Brushes.Black, 0, 1);
                //����
                g.DrawString(UpR, df, Brushes.Black, bt.Width / 2 + 1, 1);
                //����
                g.DrawString(DownL, df, Brushes.Black, 0, bt.Height / 2 + 1);
                //����
                g.DrawString(DownR, df, Brushes.Black, bt.Width / 2 + 1, bt.Height / 2 + 1);
                Image myImage = bt;
                return myImage;
            }
            else
            {
                if (val != "")
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    Font df = new Font("����", 9f);
                    Image imgTest = new Bitmap(35, 25);
                    Graphics grp = Graphics.FromImage(imgTest);
                    SizeF sz = grp.MeasureString(val, df);
                    Bitmap bt = new Bitmap((int)sz.Width, (int)sz.Height);
                    Graphics g = Graphics.FromImage(bt);
                    g.DrawString(val, df, Brushes.Black, 0,1);
                    Image myImage = bt;
                    return myImage;
                }
               
            }
            Bitmap bt1 = new Bitmap(35, 25);
            Image myImage1 = bt1;
            return myImage1;
        }


        private void SetCellData()
        {            

            //�����ֵ䣺96����
            string sql_Nurse = "select item_code,item_name,item_type from t_nurse_record_dict where item_type=96";
            DataSet ds_Nurse = App.GetDataSet(sql_Nurse);

            //�����ֵ䣺��ʶ196
            /*
              199  ����ܵ�-����(�����¼��)  GLGD001
              200  ����ܵ�-���(�����¼��)  GLGD002
              201  ̥Ĥ����(�����¼��)  TMPL001
              202  ι������(�����¼��)  WBJQ001
             * 196,199,200,201,202
             */
            string sql_Data = "select code,name,type from t_data_code where type in (199,200,201,202,207,208) order by code";
            DataSet ds_Data = App.GetDataSet(sql_Data);
            //ʱ������
            //flgView.Cols[0].DataType = Type.GetType("System.DateTime");
            //flgView.Cols[0].Format = "yyyy-MM-dd HH:mm";

                

            if (sql_Nurse != null && ds_Data != null)
            {
                ////����
                //DataRow[] dr = ds_Nurse.Tables[0].Select("item_type=96");
                //for (int i = 0; i < dr.Length; i++)
                //{
                //    ldInAmount.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                //}
                //flgView.Cols[7].DataMap = ldInAmount;

                //��ʶ
                DataRow[] dr = ds_Data.Tables[0].Select("type='208'");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldConsciousness.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                

                //����ܵ�-����(�����¼��) 
                dr = ds_Data.Tables[0].Select("type=199");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldLinenames.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }

                //����ܵ�-���(�����¼��)
                //dr = ds_Nurse.Tables[0].Select("type=200");
                //for (int i = 0; i < dr.Length; i++)
                //{
                //    ldLinecase.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                //}

                ldLinecase.Add("-", "-");
                ldLinecase.Add("+", "+");
                ldLinecase.Add("��", "��");

                //̥Ĥ����(�����¼��) 
                dr = ds_Data.Tables[0].Select("type=201");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldTpl.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }

                //ι������(�����¼��) 
                dr = ds_Data.Tables[0].Select("type=202");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldfeedskill.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                
                //��Ѫ
                ldSX.Add("0","��");
                ldSX.Add("1", "��");

                //����
                dr = ds_Data.Tables[0].Select("type=207");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldHz.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                //ldHz.Add("0","��");
                //ldHz.Add("1", "��");

                //��������
                ldGas.Add("0", "��");
                ldGas.Add("1", "��");             
            }
        }

        /// <summary>
        /// �󶨱������
        /// </summary>
        private void bindColData()
        {
            try
            {
                flgView.Cols[1].DataMap = ldConsciousness;
                //����ܵ�-����(�����¼��)
                flgView.Cols[12].DataMap = ldLinenames;

                //����ܵ�-���(�����¼��)
                flgView.Cols[13].DataMap = ldLinecase;

                //̥Ĥ����(�����¼��) 
                flgView.Cols[15].DataMap = ldTpl;

                //ι������(�����¼��) 
                flgView.Cols[22].DataMap = ldfeedskill;

                //��Ѫ
                flgView.Cols[19].DataMap = ldSX;

                //����
                flgView.Cols[20].DataMap = ldHz;

                //��������
                flgView.Cols[21].DataMap = ldGas; 
            }
            catch
            { }
        }

        /// <summary>
        /// ������Ŀ�ֵ�
        /// </summary>
        public void SetDictionaryForItem()
        {
            dictColumnName.Add(0, "ʱ������");
            dictColumnName.Add(1, "��ʶ");         
            dictColumnName.Add(2, "����");
            dictColumnName.Add(3, "����");   
            dictColumnName.Add(4, "����");
            dictColumnName.Add(5, "Ѫѹ");
            dictColumnName.Add(6, "SPO2");
            dictColumnName.Add(7, "��Ŀ");
            dictColumnName.Add(8, "��");           
            dictColumnName.Add(9, "������Ѫ");
            dictColumnName.Add(10, "��Һ");
            dictColumnName.Add(11, "����");
            dictColumnName.Add(12, "����");
            dictColumnName.Add(13, "���");
            dictColumnName.Add(14, "̥����");
            dictColumnName.Add(15, "̥Ĥ����");
            dictColumnName.Add(16, "���ڿ���");
            dictColumnName.Add(17, "����״��");
            dictColumnName.Add(18, "���׸߶�����");
            dictColumnName.Add(19, "��Ѫ");
            dictColumnName.Add(20, "����");
            dictColumnName.Add(21, "��������");
            dictColumnName.Add(22, "ι������ָ��");
            dictColumnName.Add(23, "���黤���ʩ��Ч��");           
            dictColumnName.Add(24, "ǩ��");
        }

        /// <summary>
        /// �󶨰�α�
        /// </summary>
        private void Take_over_SEQ()
        {
            DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ  order by seq,ID asc");
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
        /// ��ͷ����
        /// </summary>
        private void SetTable()
        {            

            flgView.Cols.Count = 26;
            flgView.Rows.Count = 4 + nurses.Count;
            flgView.Rows.Fixed = 3;
            //��ͷ����
            cols[0].Name = "����/ʱ��";
            cols[0].Field = "dateTime";
            cols[0].Index = 1;
            cols[0].visible = true;

            //��ʶ
            cols[1].Name = "��ʶ";
            cols[1].Field = "consciousness";
            cols[1].Index = 2;
            cols[1].visible = true;

            //����
            cols[2].Name = "����";
            cols[2].Field = "temperature";
            cols[2].Index = 3;
            cols[2].visible = true;

            //����
            cols[3].Name = "����";
            cols[3].Field = "pulse";
            cols[3].Index = 4;
            cols[3].visible = true;

            //����
            cols[4].Name = "����";
            cols[4].Field = "breathe";
            cols[4].Index = 5;
            cols[4].visible = true;

            //Ѫѹ
            cols[5].Name = "Ѫѹ";
            cols[5].Field = "blood_pressure";
            cols[5].Index = 6;
            cols[5].visible = true;

            //�����Ͷ�
            cols[6].Name = "Ѫ�����Ͷ�";
            cols[6].Field = "bp_saturation";
            cols[6].Index = 7;
            cols[6].visible = true;

            //��������
            cols[7].Name = "����";
            cols[7].Field = "in_item_name";
            cols[7].Index = 8;
            cols[7].visible = true;

            //������ֵ
            cols[8].Name = "��";
            cols[8].Field = "in_item_value";
            cols[8].Index = 9;
            cols[8].visible = true;

            //������Ѫ
            cols[9].Name = "������Ѫ";
            cols[9].Field = "in_item_value";
            cols[9].Index = 10;
            cols[9].visible = true;

            //��Һ
            cols[10].Name = "��Һ";
            cols[10].Field = "in_item_value";
            cols[10].Index = 11;
            cols[10].visible = true;

            //����
            cols[11].Name = "����";
            cols[11].Field = "in_item_value";
            cols[11].Index = 12;
            cols[11].visible = true;

            //���ർ��--����
            cols[12].Name = "����";
            cols[12].Field = "in_item_name";
            cols[12].Index = 13;
            cols[12].visible = true;

            //���ർ��--���
            cols[13].Name = "����";
            cols[13].Field = "in_item_name";
            cols[13].Index = 14;
            cols[13].visible = true;


            //̥����
            cols[14].Name = "̥����";
            cols[14].Field = "in_item_name";
            cols[14].Index = 15;
            cols[14].visible = true;

            //̥Ĥ����
            cols[15].Name = "̥Ĥ����";
            cols[15].Field = "in_item_name";
            cols[15].Index = 16;
            cols[15].visible = true;


            //���ڴ�
            cols[16].Name = "���ڿ���";
            cols[16].Field = "in_item_name";
            cols[16].Index = 17;
            cols[16].visible = true;


            //����״��
            cols[17].Name = "����״̬";
            cols[17].Field = "in_item_name";
            cols[17].Index = 18;
            cols[17].visible = true;

            //���׸߶�����
            cols[18].Name = "���׸߶�����";
            cols[18].Field = "in_item_name";
            cols[18].Index = 19;
            cols[18].visible = true;

            //��Ѫ
            cols[19].Name = "��Ѫ";
            cols[19].Field = "in_item_name";
            cols[19].Index = 20;
            cols[19].visible = true;

            //����
            cols[20].Name = "����";
            cols[20].Field = "in_item_name";
            cols[20].Index = 21;
            cols[20].visible = true;

            //��������
            cols[21].Name = "��������";
            cols[21].Field = "in_item_name";
            cols[21].Index = 22;
            cols[21].visible = true;

            //ι������ָ��
            cols[22].Name = "ι������ָ��";
            cols[22].Field = "in_item_name";
            cols[22].Index = 23;
            cols[22].visible = true;

            //�����¼
            cols[23].Name = "�����¼";
            cols[23].Field = "in_item_name";
            cols[23].Index = 24;
            cols[23].visible = true;

            //ǩ��
            cols[24].Name = "ǩ��";
            cols[24].Field = "signature";
            cols[24].Index = 25;
            cols[24].visible = true;

            cols[25].Name = "SumID";
            cols[25].Field = "Number";
            cols[25].Index = 26;
            cols[25].visible = false;
        }

        /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        /// <param name="pipe1">xx����</param>
        /// <param name="pipe2">xx����</param>
        /// <param name="pipe3">xx����</param>
        /// <param name="pipe4">xx����</param>
        private void CellUnit(string pipe1, string pipe2, string pipe3, string pipe4)
        {
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 2, 0);
            cr.Data = "����\r\n/\r\nʱ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 2, 1);
            cr.Data = "��\r\nʶ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 5);
            cr.Data = "��������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 2, 2, 2);
            cr.Data = "��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 3, 2, 3);
            cr.Data = "��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 4, 2, 4);
            cr.Data = "��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 5, 2, 5);
            cr.Data = "Ѫ\r\nѹ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 6, 0, 6);
            cr.Data = "SP\r\nO2";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(1, 6, 2, 6);
            cr.Data = "(%)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 7, 0, 8);
            cr.Data = "����(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 7, 2, 7);
            cr.Data = "��\r\nĿ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 8, 2, 8);
            cr.Data = "��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);



            cr = flgView.GetCellRange(0, 9, 0, 11);
            cr.Data = "����(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(1, 9, 2, 9);
            cr.Data = "����\r\n��Ѫ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 10, 2, 10);
            cr.Data = "��\r\nҺ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 11, 2, 11);
            cr.Data = "��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);



            cr = flgView.GetCellRange(0, 12, 0, 13);
            cr.Data = "����ܵ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 12, 2, 12);
            cr.Data = "��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 13, 2, 13);
            cr.Data = "��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 14, 2, 14);
            cr.Data = "̥\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 15, 2, 15);
            cr.Data = "̥\r\nĤ\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 16, 2, 16);
            cr.Data = "��\r\n��\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 17, 2, 17);
            cr.Data = "��  ��\r\n״  ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 18, 2, 18);
            cr.Data = "����\r\n�߶�\r\n����\r\n(ָ)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 19, 0, 20);
            cr.Data = "�˿�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 19, 2, 19);
            cr.Data = "��Ѫ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 20, 2, 20);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 21, 2, 21);
            cr.Data = "��\r\n��\r\n��\r\n��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 22, 2, 22);
            cr.Data = "ι��\r\n����\r\nָ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 23, 2, 23);
            cr.Data = "���顢�����ʩ��Ч��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 24, 2, 24);
            cr.Data = "ǩ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            flgView.AutoSizeCols();
            flgView.AutoSizeRows();
        }

        /// <summary>
        /// ��ȡ��Ҫ��ӡ������
        /// </summary>
        /// <returns></returns>
        public DataSet GetNusersRecords()
        {
            DataSet ds = null;
            ShowDatas();
            SumInOrOutRecordSets();
            Class_Nurse_Record_Obstetric[] cNurse = new Class_Nurse_Record_Obstetric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                cNurse[i] = new Class_Nurse_Record_Obstetric();
                cNurse[i] = nurses[i] as Class_Nurse_Record_Obstetric;
                if (cNurse[i].In_item_name == null)
                {
                    cNurse[i].In_item_name = "";
                }
                //����ת������������
                try
                {
                    if (cNurse[i].Consciousness != null)
                        cNurse[i].Consciousness = ldConsciousness[cNurse[i].Consciousness].ToString();
                }
                catch (Exception ex)
                { }
                if (cNurse[i].In_item_name != null && App.IsNumeric(cNurse[i].In_item_name))
                {
                    if (cNurse[i].In_item_name != null)
                    {
                        cNurse[i].In_item_name = cNurse[i].In_item_name;
                    }
                    else
                    {
                        cNurse[i].In_item_name = cNurse[i].In_item_name.ToString();
                    }
                }            
            }           
            ds = App.ObjectArrayToDataSet(cNurse);
            return ds;
        }


        /// <summary>
        /// ������
        /// </summary>
        public void ShowData()
        {
            //SetTable();
            nurses.Clear();           

            #region ���ݼ���
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "' and RECORD_TYPE='O' order by DATETIMEVAL asc";
            string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by t.create_time asc ";
            //ʱ�伯��
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            //��Ŀ����
            DataSet ds_values_sets = App.GetDataSet(sql_set);

            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_sets.Rows.Count > 0)
            {
                if (dt_sets.Rows[0]["diagnose_name"] != null)
                {
                    diagnose = dt_sets.Rows[0]["diagnose_name"].ToString();
                }
            }
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                    //������Ŀ����
                    DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                    //����
                    DataRow[] dr_InAmount = dt_sets.Select("item_show_name='����' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    DataRow[] dr_dgmc = dt_sets.Select("item_show_name='����' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    DataRow[] dr_dgqk = dt_sets.Select("item_show_name='���' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    int index = dr_InAmount.Length;
                    if (dr_dgmc.Length > index)
                    {
                        index = dr_dgmc.Length;
                    }
                    if (dr_dgqk.Length > index)
                    {
                        index = dr_dgqk.Length;
                    }
                    if (index == 0)
                        index = 1;
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Obstetric temp = new Class_Nurse_Record_Obstetric();
                        temp.DateTime = dateTimeValue;
                        //����
                        if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                        {
                            temp.In_item_name = dr_InAmount[j]["item_code"].ToString();
                            temp.In_item_value = dr_InAmount[j]["item_value"].ToString();
                            temp.Number = dr_InAmount[j]["id"].ToString();
                        }
                        if (dr_dgmc.Length > 0 && j < dr_dgmc.Length)
                        {
                            temp.Pipeline_name = dr_dgmc[j]["item_value"].ToString();
                        }
                        if (dr_dgqk.Length > 0 && j < dr_dgqk.Length)
                        {
                            temp.Pipeline_value = dr_dgqk[j]["item_value"].ToString();
                        }
                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//����������Ŀֻ�ڵ�ǰʱ��εĵ�һ����ʾ
                            {


                                if (dr_Values[k]["item_show_name"].ToString() == "��ʶ")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Temperature = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Pulse = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Breathe = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "Ѫѹ")
                                {
                                    temp.Blood_pressure = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "SPO2")
                                {
                                    temp.Bp_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "��������")
                                //{
                                //    temp.In_item_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                //{
                                //    temp.In_item_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "������Ѫ")
                                {
                                    temp.Abnormalvaginalbleeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��Һ")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Out_otheritem_value = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                //{
                                //    temp.Pipeline_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "���")
                                //{
                                //    temp.Pipeline_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "̥����")
                                {
                                    temp.Fetal_heart_sound = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "̥Ĥ����")
                                {
                                    temp.Rupture_membranes = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���ڿ���")
                                {
                                    temp.Miyaguchi_kaio = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����״��")
                                {
                                    temp.Uterine_contraction = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���׸߶�����")
                                {
                                    temp.Fundus_height = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��Ѫ")
                                {
                                    temp.Blood_oozing = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Redandswollen = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��������")
                                {
                                    temp.Anus_gas = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "ι������ָ��")
                                {
                                    temp.Breast_feeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���黤���ʩ��Ч��")
                                {
                                    temp.Remark = dr_Values[k]["item_value"].ToString();
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
                Class_Nurse_Record_Obstetric[] nurse = new Class_Nurse_Record_Obstetric[nurses.Count];
                for (int i = 0; i < nurses.Count; i++)
                {
                    nurse[i] = new Class_Nurse_Record_Obstetric();
                    nurse[i] = nurses[i] as Class_Nurse_Record_Obstetric;

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
                //CellUnit(pipe1, pipe2, pipe3, pipe4);
                //flgView.Refresh();
                //flgView.AutoSizeCols();
                //flgView.AutoSizeRows();
            }

            #endregion

        }


        /// <summary>
        /// ������
        /// </summary>
        public void ShowDatas()
        {
            //SetTable();
            nurses.Clear();

            #region ���ݼ���
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by DATETIMEVAL asc";
            string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by t.create_time asc ";
            //ʱ�伯��
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            //��Ŀ����
            DataSet ds_values_sets = App.GetDataSet(sql_set);

            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_sets.Rows.Count > 0)
            {
                if (dt_sets.Rows[0]["diagnose_name"] != null)
                {
                    diagnose = dt_sets.Rows[0]["diagnose_name"].ToString();
                }
            }
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                    //������Ŀ����
                    DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                    //����
                    DataRow[] dr_InAmount = dt_sets.Select("item_show_name='����' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    DataRow[] dr_dgmc = dt_sets.Select("item_show_name='����' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    DataRow[] dr_dgqk = dt_sets.Select("item_show_name='���' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    int index = dr_InAmount.Length;
                    if (dr_dgmc.Length > index)
                    {
                        index = dr_dgmc.Length;
                    }
                    if (dr_dgqk.Length > index)
                    {
                        index = dr_dgqk.Length;
                    }
                    if (index == 0)
                        index = 1;
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Obstetric temp = new Class_Nurse_Record_Obstetric();
                        temp.DateTime = dateTimeValue;
                        //����
                        if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                        {
                            temp.In_item_name = dr_InAmount[j]["item_code"].ToString();
                            temp.In_item_value = dr_InAmount[j]["item_value"].ToString();
                            temp.Number = dr_InAmount[j]["id"].ToString();
                        }
                        if (dr_dgmc.Length > 0 && j < dr_dgmc.Length)
                        {
                            temp.Pipeline_name = dr_dgmc[j]["item_value"].ToString();
                        }
                        if (dr_dgqk.Length > 0 && j < dr_dgqk.Length)
                        {
                            temp.Pipeline_value = dr_dgqk[j]["item_value"].ToString();
                        }
                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//����������Ŀֻ�ڵ�ǰʱ��εĵ�һ����ʾ
                            {
                                if (dr_Values[k]["item_show_name"].ToString() == "��ʶ")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Temperature = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Pulse = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Breathe = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "Ѫѹ")
                                {
                                    temp.Blood_pressure = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "SPO2")
                                {
                                    temp.Bp_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "��������")
                                //{
                                //    temp.In_item_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                //{
                                //    temp.In_item_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "������Ѫ")
                                {
                                    temp.Abnormalvaginalbleeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��Һ")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Out_otheritem_value = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                //{
                                //    temp.Pipeline_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "���")
                                //{
                                //    temp.Pipeline_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "̥����")
                                {
                                    temp.Fetal_heart_sound = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "̥Ĥ����")
                                {
                                    temp.Rupture_membranes = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���ڿ���")
                                {
                                    temp.Miyaguchi_kaio = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����״��")
                                {
                                    temp.Uterine_contraction = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���׸߶�����")
                                {
                                    temp.Fundus_height = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��Ѫ")
                                {
                                    temp.Blood_oozing = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "����")
                                {
                                    temp.Redandswollen = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "��������")
                                {
                                    temp.Anus_gas = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "ι������ָ��")
                                {
                                    temp.Breast_feeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "���黤���ʩ��Ч��")
                                {
                                    temp.Remark = dr_Values[k]["item_value"].ToString();
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

        private int  GetOtherName(int rowSel,ref int ireturn)
        {
            if (flgView[rowSel, 0] != null && flgView[rowSel, 0].ToString() != "")
            {
                return ireturn + 1;
            }
            else
            {
                ireturn++;
                return GetOtherName(rowSel - 1, ref ireturn);
            }
        }

        private bool GetOtherNameExists(int rowSel,int rows,int istart, int colIndex, string itemname)
        {
            if (istart == rows)
            {
                if (rows == 1)
                    return false;
                if (flgView[rowSel, colIndex] != null && flgView[rowSel, colIndex].ToString() != "" && flgView[rowSel, colIndex].Equals(itemname))
                    return true;
                else
                    return false;
            }
            if (flgView[rowSel, colIndex] != null && flgView[rowSel, colIndex].ToString() != "" && flgView[rowSel, colIndex].Equals(itemname))
            {
                return true;
            }
            else
            {
                return GetOtherNameExists(rowSel - 1, rows, istart + 1, colIndex, itemname);
            }
        }

        #region �����ز���
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            flgView.AutoSizeCol(e.Col);
           

        }
        //ComboBox cb = null;
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            if (flgView[e.Row, 0] == null && e.Col == 7)
            {
                string measureTime = GetTime(e.Row);
                //��֤Ȩ��
                if (measureTime != "")//ʱ��Ϊ��˵����������ݣ�������֤Ȩ��
                {
                    //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "creat_id");
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id + " and RECORD_TYPE='O' and rownum=1 order by id", 0, "creat_id"));
                    if (!ValidateUser(operateId))
                    {
                        App.Msg("Ȩ�޲��㣡");
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if ((flgView[e.Row, 0] == null||flgView[e.Row,0].ToString()=="") && (e.Col == 12||e.Col==13))
            {
                string measureTime = GetTime(e.Row);
                //��֤Ȩ��
                if (measureTime != "")//ʱ��Ϊ��˵����������ݣ�������֤Ȩ��
                {
                    //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "creat_id");
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id + " and RECORD_TYPE='O' and rownum=1 order by id", 0, "creat_id"));
                    if (!ValidateUser(operateId))
                    {
                        App.Msg("Ȩ�޲��㣡");
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if ((flgView[e.Row, 0] != null && flgView[e.Row, 7] != null && (flgView[e.Row, 7].ToString().Contains("С��") || flgView[e.Row, 7].ToString().Contains("�ܽ�"))))
            {
                int id = 0;
                if (flgView[e.Row, 25] != null && flgView[e.Row, 25].ToString().Length > 0)
                {
                    try
                    {
                        id = int.Parse(flgView[e.Row, 25].ToString());
                    }
                    catch { }
                }
                if (id == 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if ((flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != ""))
            {
                string measureTime = GetTime(e.Row);
                int num = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                if (num > 0)
                {
                    //��֤Ȩ��
                    if (measureTime != "")//ʱ��Ϊ��˵����������ݣ�������֤Ȩ��
                    {
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                        if (!ValidateUser(operateId))
                        {
                            App.Msg("Ȩ�޲��㣡");
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            //if (((flgView[e.Row, 0] == null && e.Col != 12) || (flgView[e.Row, 0] == null && e.Col != 13)) || e.Row != flgView.Rows.Count - 2)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            if ((flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "") && e.Col != 7 && e.Col != 8 && e.Row != flgView.Rows.Count - 1 && flgView[e.Row, 7] != null)
            {
                e.Cancel = true;
                return;
            }

            //3���µ�Ԫ���е�ֵ������ֵ���ͣ�������ǻ������ݣ�ȡ���༭
            //if (flgView[e.Row, 3] != null && !App.IsNumeric(flgView[e.Row, 3].ToString()))
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //ǩ����ֹ�༭
            if (e.Col == 24)
            {
                e.Cancel = true;
                return;
            }
            if ((e.Col != 7 && e.Col != 8 && e.Col != 12 && e.Col != 13) || e.Col == 0)
            {
                //if (flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "")
                //{
                if (flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "")
                {
                    //App.Msg("��ѡ�����ʱ�䣡");
                    FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), "O");
                    fsd.ShowDialog();
                    if (fsd.flag)
                        flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (e.Col == 0)
                    {
                        DateTime dt = Convert.ToDateTime(flgView[e.Row, 0].ToString());
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));

                        if (ValidateUser(operateId) || operateId == null)
                        {
                            FrmSetDatetime fsd = new FrmSetDatetime(dt, currentPatient.Id.ToString(), "O");
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
                                    dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id.ToString() + "";

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
            ////��֤xx�ܵı����Ƿ�����
            //if (e.Col >= 16 && e.Col <= 23)
            //{
            //    if (flgView[1, e.Col] == null || flgView[1, e.Col].ToString() == "")
            //    {
            //        �޸ı���ToolStripMenuItem_Click(sender, e);
            //    }
            //}

            //����������֤����ѡ���������ͣ���������ֵ
            if (e.Col == 8)
            {
                if (flgView[e.Row, e.Col - 1] == null || flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("��ʾ:���������������ƣ�");
                    flgView.Col = 7;
                    return;
                }
            }
            if (e.Col == 13)
            {
                if (flgView[e.Row, e.Col - 1] == null || flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("��ʾ:����ѡ��ܵ����ƣ�");
                    flgView.Col = 12;
                    return;
                }
            }
            //if (flgView.Col == 23 && flgView[flgView.Row, 0] != null)
            //{
            //    this.��ȡ��עģ��ToolStripMenuItem_Click(sender, e);
            //    return;
            //}
            ////�޸������Զ�������
            //if (e.Col == 7 && flgView[e.Row, 7] != null && flgView[e.Row, 7].ToString() != "" && ldInAmount[flgView[e.Row, 7].ToString()] == null)
            //{
            //    string measureTime = GetTime(e.Row);
            //    oldInAmountName = flgView[e.Row, 7].ToString();
            //    FrmModifyTitle frm = new FrmModifyTitle(flgView[e.Row, 7].ToString());
            //    frm.ShowDialog();
            //    flgView[e.Row, e.Col] = frm.tName;
            //    //��֤���������Ƿ��ظ�
            //    string itemName = flgView[e.Row, 7].ToString();
            //    int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='����' and other_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
            //    if (itemCount > 0 && itemName != oldInAmountName)
            //    {
            //        App.Msg("������Ŀ�ظ���");
            //        flgView[e.Row, e.Col] = oldInAmountName;
            //        e.Cancel = true;
            //        return;
            //    }
            //    else if (itemName == oldInAmountName)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }

            //    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='����' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));

            //    //�����ǰ��Ŀ�Ѵ������޸ĵ�ǰֵ����������
            //    if (oldInAmountName != "")
            //    {
            //        if (itemCount > 0 && flgView[e.Row, 13] != null)
            //        {
            //            string sql = "update t_nurse_record set item_code='" + itemName + "', other_name='" + itemName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='����' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id;
            //            int num = App.ExecuteSQL(sql);
            //            if (num > 0)
            //            {
            //                timer1.Start();
            //                operateFlag = true;
            //                //����ǩ��
            //                flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
            //                App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'��create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
            //            }
            //        }

            //    }
            //    e.Cancel = true;
            //}
        }


        private void flgView_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            //if (e.Col == 23)//��ע
            //{
            //    e.Handled = true;
            //}
            if (e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 6 || e.Col == 10 || e.Col == 11 )
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            //if (e.Col == 9)
            //{
            //    if (!Char.IsNumber(e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }
            //}
            if (e.Col == 8)//������������-
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && Char.ToLower(e.KeyChar) != '-')
                {
                    e.Handled = true;
                }
                else if (Char.ToLower(e.KeyChar) == '-')
                {
                    //�ж��Ƿ��Ѿ��������λ:-
                    if (flgView.Editor.Text.ToLower().Contains("-") || flgView.Editor.Text != "")
                    {
                        e.Handled = true;
                    }
                }
            }
            if (e.Col == 14)
            {
                string measureTime = GetTime(e.Row);
                frmFormula fc = new frmFormula(currentPatient, measureTime, dictColumnName[14]);
                fc.ShowDialog();
                if (fc.successflag)
                {
                    SetTable();
                    oldInAmountName = "";
                    ShowData();
                    SumInOrOutRecordSet(true);
                    ShowSumDataGrid();
                    CellUnit(pipe1, pipe2, pipe3, pipe4);
                }
            }

            if (e.Col == 5)//Ѫѹ
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// �����༭�󣬱��浥Ԫ������ݵ����ݿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_AfterEdit(object sender, RowColEventArgs e)
        {

            #region ��֤
            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
            //{
            //string currentRowTime = flgView[e.Row, 0].ToString();
            ////��֤�ظ�ʱ��
            //for (int i = 3; i < flgView.Rows.Count; i++)
            //{
            //    if (i != e.Row)
            //    {
            //        if (flgView[i, 0] != null && flgView[i, 0].ToString() == currentRowTime)
            //        {
            //            flgView[e.Row, 0] = null;
            //            App.Msg("����¼����ͬ��ʱ�䣡");
            //            return;
            //        }
            //    }
            //}

            ////��֤ʱ�䷶Χ�Ƿ�Ͳ�ѯ����������ͬ
            //if (dtpDate.Value.ToString("yyyy-MM-dd") != Convert.ToDateTime(currentRowTime).ToString("yyyy-MM-dd"))
            //{
            //    flgView[e.Row, 0] = null;
            //    App.Msg("��ѡ���ʱ�䳬���˲�ѯ���ڣ�");
            //    return;
            //}
            //}
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
                //string state = "";
                if (e.Col != 0)//12��������
                {
                    if (e.Col == 1 || e.Col == 12 || e.Col == 13 || e.Col == 15 || 
                        e.Col == 19 || e.Col == 20 || e.Col == 21 || e.Col == 22)
                    {
                        ListDictionary ldCommon = GetDictionaryByColIndex(e.Col);
                        itemValue = ldCommon[flgView[e.Row, e.Col].ToString()].ToString();
                        itemCode = flgView[e.Row, e.Col].ToString();
                        itemName = dictColumnName[e.Col];
                        if (e.Col == 12 || e.Col == 13)
                        {
                            int ireturn = 0;
                            otherName = GetOtherName(flgView.Row, ref ireturn).ToString();
                        }
                    }
                    else if (e.Col == 8||e.Col==7)//������ֵ
                    {
                        if (flgView[e.Row, 7].ToString() != null)
                        {
                            otherName = flgView[e.Row, 7].ToString();
                        }
                        else
                        {
                            otherName = flgView[e.Row, 7].ToString();
                        }
                        if (flgView[e.Row, 8] != null)
                        {
                            itemValue = flgView[e.Row, 8].ToString();
                        }
                        itemCode = flgView[e.Row, 7].ToString();
                        itemName = "����";
                        if (flgView[e.Row, 25] != null && flgView[e.Row, 25].ToString().Length > 0)
                        {
                            try
                            {
                                id = int.Parse(flgView[e.Row, 25].ToString());
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        itemValue = flgView[e.Row, e.Col].ToString();
                        if (e.Col == 23)//��ע����֤�ַ�����
                        {
                            int length = getStringLength(itemValue);
                            if (length > 1000)
                            {
                                App.Msg("����������ݳ���1000�ֽ���!");
                                return;
                            }
                        }
                        if (e.Col == 9)
                        {
                            if (!App.IsNumeric(itemValue))
                            {
                                otherName = "������";
                            }
                        }
                        itemName = dictColumnName[e.Col];
                        itemCode = App.ReadSqlVal("select id from t_nurse_record_dict where item_name='" + itemName + "'", 0, "id");
                    }
                    //ȡ��ǰ����ʱ������Ĵ�����id
                    string userId = "";
                    try
                    {
                        userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
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
                    if (e.Col != 8&&e.Col!=7)
                    {
                        itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                        if (e.Col == 12 || e.Col == 13)
                        {
                            if (otherName != "1")
                            {
                                itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and patient_id=" + currentPatient.Id, 0, "count(*)"));
                            }
                        }
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
                            itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and patient_id=" + currentPatient.Id, 0, "count(*)"));
                        }
                    }
                    string sql = "";
                    if (itemCount == 0)
                    {
                        //if (e.Col==9)
                        //{
                        //    sql = "insert into t_nurse_record" +
                        //                 "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE,C_STATE)values" +
                        //                 "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                        //                 itemCode + "', '" + itemValue + "', '" + App.UserAccount.UserInfo.User_id + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','O','" + state + "')";
                        //}
                        //else 
                        if (otherName == "")
                        {
                            sql = "insert into t_nurse_record" +
                                         "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                                         "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                         itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','O')";
                        }
                        else
                        {
                            sql = "insert into t_nurse_record" +
                                         "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                         "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                         itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + otherName + "','O')";
                        }
                    }
                    else
                    {
                        if (!ValidateUser(userId))
                        {
                            App.Msg("�޸�Ȩ�޲���!");
                            btnSearch_Click(sender, e);
                            return;
                        }
                        if (e.Col == 9)
                        {//������Ѫ:��Ϊ���ֵı�ʶ����other_name�ֶ�,���Եĸ��ű�
                            sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate" +
                                " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "'  and patient_id=" + currentPatient.Id;
                        }
                        else if (otherName == "")
                        {
                            sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate" +
                                " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "'  and patient_id=" + currentPatient.Id;
                        }
                        else
                        {   
                            sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                            if (id > 0)
                            {
                                sql += " where id=" + id;
                            }
                            else
                            {
                                sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and patient_id=" + currentPatient.Id;
                            }
                            if (e.Col == 12 || e.Col == 13)
                            {
                                if (otherName == "1")
                                {
                                    sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                                    sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and (other_name='" + otherName + "' or other_name is null)  and patient_id=" + currentPatient.Id;
                                }
                            }
                        }
                    }
                    int num = App.ExecuteSQL(sql);
                    if (num > 0)
                    {
                        timer1.Start();
                        operateFlag = true;
                        //����ǩ��
                        if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "" && flgView[e.Row, 24] == null && sql.Contains("insert"))
                        {
                            flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
                        }
                        if (id == 0 && itemName == "����"&&sql.ToLower().Contains("insert"))
                        {
                            btnSearch_Click(sender, e);
                        }
                        //App.Msg("�����ɹ���");
                        //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "',create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        //btnSearch_Click(sender, e);
                    }
                }
                //else if (e.Col == 7)//&& flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")//������������
                //{
                //    //�½��Զ�����������
                //    //if (flgView[e.Row, e.Col].ToString() == "80")
                //    //{
                //    //    if (App.Ask("�Ƿ���Ҫ�Զ����������ƣ�"))
                //    //    {
                //    //        FrmModifyTitle frm = new FrmModifyTitle();
                //    //        frm.Text = "��������";
                //    //        frm.ShowDialog();
                //    //        flgView[e.Row, e.Col] = frm.tName;
                //    //        return;
                //    //    }
                //    //}

                //    //��֤���������Ƿ��ظ�
                //    itemName = flgView[e.Row, 7].ToString();
                //    int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='����' and other_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                //    //if (itemCount > 0 && itemName != oldInAmountName)
                //    //{
                //    //    App.Msg("������Ŀ�ظ���");
                //    //    flgView[e.Row, e.Col] = oldInAmountCode;
                //    //    //btnSearch_Click(sender, e);
                //    //    return;
                //    //}

                //    //itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='����' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                //    if (flgView[e.Row, flgView.Cols.Count - 1] != null && flgView[e.Row, flgView.Cols.Count - 1].ToString().Length > 0)
                //    {
                //        try
                //        {
                //            id = int.Parse(flgView[e.Row, flgView.Cols.Count - 1].ToString());
                //        }
                //        catch { }
                //    }
                //    if (id > 0)
                //    {
                //        otherName = flgView[e.Row, 7].ToString();
                //        itemCode = flgView[e.Row, 7].ToString();
                //        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                //        if (!ValidateUser(operateId))
                //        {
                //            App.Msg("�޸�Ȩ�޲���!");
                //            btnSearch_Click(sender, e);
                //            return;
                //        }
                //        string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate ";
                //        sql += " where id=" + id;
                //        //sql+=" where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='����' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id;
                //        int num = App.ExecuteSQL(sql);
                //        if (num > 0)
                //        {
                //            timer1.Start();
                //            //App.Msg("�����ɹ���");
                //            operateFlag = true;
                //            //����ǩ��
                //            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
                //            //    flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
                //            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'��create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                //            //btnSearch_Click(sender, e);
                //        }
                //    }
                    //�����ǰ��Ŀ�Ѵ������޸ĵ�ǰֵ����������
                    //if (oldInAmountName != flgView[e.Row, 7].ToString())
                    //{
                    //    if (flgView[e.Row, 8] != null)
                    //    {
                    //        otherName = flgView[e.Row, 7].ToString();
                    //        itemCode = flgView[e.Row, 7].ToString();
                    //        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    //        if (!ValidateUser(operateId))
                    //        {
                    //            App.Msg("�޸�Ȩ�޲���!");
                    //            btnSearch_Click(sender, e);
                    //            return;
                    //        }
                    //        string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='����' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id;
                    //        int num = App.ExecuteSQL(sql);
                    //        if (num > 0)
                    //        {
                    //            timer1.Start();
                    //            //App.Msg("�����ɹ���");
                    //            operateFlag = true;
                    //            //����ǩ��
                    //            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
                    //            //    flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
                    //            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'��create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                    //            //btnSearch_Click(sender, e);
                    //        }
                    //    }
                    //}
                //}              
            }
            #endregion
        }

        /// <summary>
        /// ���ñ༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_SetupEditor(object sender, RowColEventArgs e)
        {
            if (e.Col == 7 && flgView[e.Row, e.Col] != null && flgView[e.Row, e.Col].ToString() != "")//����������
            {
                //�����޸�ǰ����������
                if (flgView[e.Row, e.Col] != null)
                {
                    oldInAmountName = flgView[e.Row, e.Col].ToString();
                    oldInAmountCode = flgView[e.Row, e.Col].ToString();
                }
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetTable();
            oldInAmountName = "";
            ShowData();
            SumInOrOutRecordSet(true);
            ShowSumDataGrid();
            CellUnit(pipe1, pipe2, pipe3, pipe4);
        }


        /// <summary>
        /// �����е�������ö�Ӧ���ֵ伯��
        /// </summary>
        /// <returns>�����ֵ�</returns>
        private ListDictionary GetDictionaryByColIndex(int col)
        {          
            //��ʶ
            if (col == 1)
            {
                return ldConsciousness;
            }
            //else if (col == 7)//��Ŀ
            //{
            //    return ldInAmount;
            //}           
            else if (col == 12)//����ܵ�����
            {
                return ldLinenames;
            }
            else if (col == 13)//����ܵ����
            {
                return ldLinecase;
            } 
            else if (col == 15)//̥Ĥ����
            {
                return ldTpl;
            }
            else if (col == 19)//��Ѫ
            {
                return ldSX;
            }
            else if (col == 20)//����
            {
                return ldHz;
            }
            else if (col == 21)//��������
            {
                return ldGas;
            }
            else if (col == 22)//ι����ָ��
            {
                return ldfeedskill;
            }
            return null;
        }

        private void �޸ı���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C1.Win.C1FlexGrid.RowColEventArgs c1e = e as C1.Win.C1FlexGrid.RowColEventArgs;
            string measureTime = GetTime(flgView.Row);
            string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
            if (!ValidateUser(operateId))
            {
                App.Msg("�޸�Ȩ�޲���!");
                btnSearch_Click(sender, e);
                return;
            }
            string titleName = "";
            titleName = flgView[1, flgView.Col].ToString();
            FrmModifyTitle frm = new FrmModifyTitle(titleName);
            frm.ShowDialog();

            if (frm.flag)
            {
                string pipeIndex = "";//��ǰѡ�йܵ�λ��
                //���ñ�ͷxx�ܵ�����
                if (flgView.Col == 16 || flgView.Col == 17)
                {
                    flgView[1, 16] = frm.tName;
                    flgView[1, 17] = frm.tName;
                    pipeIndex = "1";
                }
                else if (flgView.Col == 18 || flgView.Col == 19)
                {
                    flgView[1, 18] = frm.tName;
                    flgView[1, 19] = frm.tName;
                    pipeIndex = "2";
                }
                else if (flgView.Col == 20 || flgView.Col == 21)
                {
                    flgView[1, 20] = frm.tName;
                    flgView[1, 21] = frm.tName;
                    pipeIndex = "3";
                }
                else if (flgView.Col == 22 || flgView.Col == 23)
                {
                    flgView[1, 22] = frm.tName;
                    flgView[1, 23] = frm.tName;
                    pipeIndex = "4";
                }
                //����xx�ܵ�����
                string sql = "update t_nurse_record set other_name='" + frm.tName + "' where patient_id=" + currentPatient.Id + " and RECORD_TYPE='O' and item_show_name like '%" + pipeIndex + "%'";
                try
                {
                    App.ExecuteSQL(sql);
                }
                catch
                {
                }
            }
            else
            {
                c1e.Cancel = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (flgView.Col == 7)
            {
                �޸���Ŀ��toolStripMenuItem.Visible = true;
            }
            else
            {
                �޸���Ŀ��toolStripMenuItem.Visible = false;
            }

            if (flgView.Col == 23 && flgView[flgView.Row, 0] != null)
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
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
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
                FrmSumItem sum_item = new FrmSumItem(sum_id,"O");
                sum_item.ShowDialog();
                if (!sum_item.successflag)
                {//û�в����ɹ�,�������ͳ�Ƽ�¼
                    string del = "delete from t_nurse_dangery_inout_sum_h where id=" + sum_id + " and patient_id=" + currentPatient.Id;
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



            int id = App.GenId("t_nurse_dangery_inout_sum_h", "ID");//,CREAT_ID  ,'" + App.UserAccount.Account_id+ "'
            Class_Take_over_SEQ take_Seq = cboTiming.SelectedItem as Class_Take_over_SEQ;

            if (take_Seq != null)
            {
                //���� �գ����� D�� ����    C ��ͯ  O ����  B������
                string inserSumSql = "insert into t_nurse_dangery_inout_sum_h(ID,PID,CALC_DATE,START_TIME,END_TIME,OPER_METHOD,patient_Id,seq_id,SIGNATURE,RECORD_TYPE)values(" +
                id.ToString() + ",'" + currentPatient.PId + "',sysdate,to_timestamp('" +
                dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),to_timestamp('" +
                dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),'" + sum_Name + "'," + currentPatient.Id + "," + take_Seq.Id + ",'" + App.UserAccount.UserInfo.User_name + "','O')";
                if (App.ExecuteSQL(inserSumSql)>0)
                {
                    sum_id = id.ToString();
                } 
            }
            return sum_id;
#region ע
            //SumNusers.Clear();
            //string Eat = "";//ʳ��
            //string abnormalvaginalbleeding = "";//������Ѫ
            //string Urine = "";//��Һ
            //string OtherOut = "";//��������
            //string LetFlow = "";//��Һ
            //int inAmount = 0;//�����ܺ�
            //int outAmount = 0;//�����ܺ�

            
            //Class_Nurse_Record_Obstetric sumtemp = new Class_Nurse_Record_Obstetric();

            //string beginSgin = ">=";

            //string endSgin = "<=";

            //if (cboTiming.SelectedItem != null)
            //{
            //    Class_Take_over_SEQ tempSeq = (Class_Take_over_SEQ)cboTiming.SelectedItem;
            //    if (tempSeq.Begin_logic == "0")
            //    {
            //        beginSgin = ">";
            //    }
            //    if (tempSeq.End_logic == "0")
            //    {
            //        endSgin = "<";
            //    }
            //}          

            ////�����ܺ�
            //string SqlIn_1 = "select '�����ܺ�' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //       " where item_show_name='����'  and other_name not like '%��Һ%' " +
            //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            ////��Һ�ܺ�
            //string SqlIn_2 = "select '������Һ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //       " where item_show_name='����' and other_name like '%��Һ%' " +
            //       " and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            ////������Ѫ:�ַ���ͳ��
            //string SqlOut_1 = "select '������Ѫ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a  where item_show_name like '%������Ѫ%' and other_name is null and MEASURE_TIME" +
            //    beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            ////��Һ
            //string SqlOut_2 = "select '��Һ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%��Һ%' and MEASURE_TIME" +
            //beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
         
            ////����
            //string SqlOut_3 = "select '����' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%����%' and MEASURE_TIME" +
            //beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //string Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;

            //DataSet ds = App.GetDataSet(Sql);

            //sumtemp.DateTime = dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm");
            //if (cboTiming.Text == "�׶��Գ�����")
            //{
            //    sumtemp.Temperature = lblTatolTime.Text + "h�ܽ�";
            //}
            //else
            //{
            //    sumtemp.Temperature = cboTiming.Text;
            //}

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{

            //    if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("�����ܺ�"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            Eat = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            Eat = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Һ"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            LetFlow = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            LetFlow = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Ѫ"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            abnormalvaginalbleeding = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            abnormalvaginalbleeding = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("��Һ"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            Urine = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            Urine = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("����"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            OtherOut = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            OtherOut = "0";
            //        }
            //    }   
            //}
            ////���������ܺ�
            //try
            //{
            //    inAmount = Convert.ToInt32(Eat) - Convert.ToInt32(LetFlow);
            //}
            //catch (Exception)
            //{

            //    inAmount = 0;
            //}
            ////��������ܺ�
            //try
            //{
            //    outAmount = Convert.ToInt32(abnormalvaginalbleeding) + Convert.ToInt32(Urine) + Convert.ToInt32(OtherOut);
            //}
            //catch (Exception)
            //{

            //    outAmount = 0;
            //}

            //sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//ʳ����
            ////sumtemp.Shit = Excrement;//�����
            //sumtemp.Out_otheritem_value = outAmount == 0 ? "" : outAmount.ToString();//�����ܺ� 
            //if (App.UserAccount.UserInfo != null)
            //    sumtemp.Signature = App.UserAccount.UserInfo.User_name;//ǩ��

            //DateTime TempDate = new DateTime();
            //bool flag = false;

            ////�����ܼ�¼�嵽���󼯺���ȥ
            //for (int i = 0; i < nurses.Count; i++)
            //{
            //    Class_Nurse_Record_Obstetric temp_nuser = (Class_Nurse_Record_Obstetric)nurses[i];
            //    if (temp_nuser.DateTime != null)
            //    {
            //        TempDate = Convert.ToDateTime(temp_nuser.DateTime);
            //    }
            //    else
            //    {
            //        SumNusers.Add(temp_nuser);
            //        continue;
            //    }

            //    if (TempDate >= dtpEndTime.Value && !flag)//���ܽ���ʱ��С�ڲ���ʱ��ʱ������ӻ��ܶ���
            //    {
            //        SumNusers.Add(sumtemp);
            //        SumNusers.Add(temp_nuser);
            //        flag = true;
            //    }              
            //    else
            //    {
            //        SumNusers.Add(temp_nuser);
            //    }
            //}

            //nurses.Clear();
            //for (int i = 0; i < SumNusers.Count; i++)
            //{
            //    nurses.Add(SumNusers[i]);
            //}

            //string NusersRecord = dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + sumtemp.Temperature;



            ////��¼���㲽��
            //SumNusersRecords.Add(NusersRecord);


            //int id = App.GenId("t_nurse_dangery_inout_sum_h", "ID");//,CREAT_ID  ,'" + App.UserAccount.Account_id+ "'
            //Class_Take_over_SEQ take_Seq = cboTiming.SelectedItem as Class_Take_over_SEQ;

            //if (take_Seq != null)
            //{
            //    string inserSumSql = "insert into t_nurse_dangery_inout_sum_h(ID,PID,CALC_DATE,START_TIME,END_TIME,OPER_METHOD,patient_Id,seq_id,SIGNATURE)values(" +
            //    id.ToString() + ",'" + currentPatient.PId + "',sysdate,to_timestamp('" +
            //    dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),to_timestamp('" +
            //    dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),'" + sumtemp.Temperature + "'," + currentPatient.Id + "," + take_Seq.Id + ",'" + App.UserAccount.UserInfo.User_name + "')";
            //    int count = App.ExecuteSQL(inserSumSql); 
            //}
#endregion
        }

        /// <summary>
        /// ���Ļ��ܼ���ˢ��
        /// </summary>
        private void ShowSumDataGrid()
        {
            string TempDateTime = null;
            Class_Nurse_Record_Obstetric[] Nusers_objs = new Class_Nurse_Record_Obstetric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {

                Nusers_objs[i] = new Class_Nurse_Record_Obstetric();
                Nusers_objs[i] = (Class_Nurse_Record_Obstetric)nurses[i];
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
                    flgView[i + 3, 25] = Nusers_objs[i].Number;
                }
            }
            //for (int i = 0; i < flgView.Rows.Count; i++)
            //{
            //    if (flgView[i, 7] != null)
            //    {
            //        if (flgView[i, 7].ToString().Contains("С��") || flgView[i, 7].ToString().Contains("������"))
            //        {
            //            flgView.Rows[i].AllowEditing = false;
            //        }
            //        else
            //        {
            //            flgView.Rows[i].AllowEditing = true;
            //        }
            //    }
            //}


            //̥����ͼƬ����         
            for (int i = 3; i < flgView.Rows.Count; i++)
            {
                if (flgView[i, 14] != null)
                {
                    if (flgView[i, 14].ToString() != "")
                    {                       
                        flgView.SetCellImage(i, 14, DrawValueImage(flgView[i, 14].ToString()));
                        flgView[i, 14] = "";
                    }
                    else
                    {
                        flgView.SetCellImage(i, 14, null);
                        flgView[i, 14] = "";
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
        /// ���ü������������
        /// </summary>
        private void SumInOrOutRecordSet(bool IsToDay)
        {
            
            SumNusersRecords.Clear();
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id + " and  to_char(end_time,'yyyy-MM-dd')='" + date + "' and RECORD_TYPE='O' order by end_time";
            if (!IsToDay)
            {
                sql_date="select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by end_time";
            }
            DataSet ds_sum_oper = App.GetDataSet(sql_date);

            for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            {
                //SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
                SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            }

            for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            {
                string BeginTime, EndTime, Item_name;
                string BeginedTiem, EndedTime;
                string Remaining = "0";//��Һ-
                string Remained = "0";//��Һ+
                double Eat = 0;//ʳ��
                double abnormalvaginalbleeding = 0;//������Ѫ
                double Urine = 0;//��Һ
                double OtherOut = 0;//��������
                string Number = "";//����
                string seq_id = "";//ͳ������ID
                string LetFlow = "";//��Һ
                double inAmount = 0;//�����ܺ�
                double outAmount = 0;//�����ܺ�
                string singsure = ""; //ǩ��

                BeginTime = SumNusersRecords[i1].ToString().Split(',')[0];
                EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
                Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
                Number = SumNusersRecords[i1].ToString().Split(',')[3];
                seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
                singsure = SumNusersRecords[i1].ToString().Split(',')[5];
                string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');//ͳ����Ŀ
                //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
                SumNusers.Clear();
                //�ռ�,ҹ�����һ���ʱ��
                //BeginedTiem = Convert.ToDateTime(EndTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm");
                //EndedTime = BeginTiem;

                Class_Nurse_Record_Obstetric sumtemp = new Class_Nurse_Record_Obstetric();

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

                #region old
                ////�����ܺ�
                //string SqlIn_1 = "select '�����ܺ�' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
                //       " where item_show_name='����'  and other_name not like '%��Һ%'  and other_name not like '%��Һ%' " +
                //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////��Һ�ܺ�
                //string SqlIn_2 = "select '������Һ' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                //       " where item_show_name='����' and other_name like '%��Һ%' " +
                //       " and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////��ǰͳ��ʱ����Һ�ܺ�
                //string SqlIn_3 = "select '������Һ-' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                //       " where item_show_name='����'  and other_name like '%��Һ%' " +
                //       @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
                //         endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////�ϴ�ͳ��ʱ����Һ�ܺ�
                //string SqlIn_4 = "select '������Һ+' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                //       " where item_show_name='����'  and other_name like '%��Һ%' " +
                //       @"and MEASURE_TIME>to_timestamp('" + BeginedTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME<=to_timestamp('" + EndedTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

                ////������Ѫ:�����ֲ�ͳ��!
                //string SqlOut_1 = "select '������Ѫ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%������Ѫ%' and other_name is null and MEASURE_TIME" +
                //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////��Һ
                //string SqlOut_2 = "select '��Һ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%��Һ%' and MEASURE_TIME" +
                //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////����
                //string SqlOut_3 = "select '����' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%����%' and MEASURE_TIME" +
                //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

                //string SqlOut = "";

                //foreach (string i in sum_item)
                //{
                //    if (i != null && i != "")
                //    {
                //        if (i == "������Ѫ")
                //            SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and other_name is null and MEASURE_TIME" +
                //                beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                //        else
                //            SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and MEASURE_TIME" +
                //                beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                //    }
                //    else
                //    {
                //        SqlOut = " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
                //    }
                //}

                //string Sql ="";
                //if (Item_name.Contains("�ռ�") || Item_name.Contains("ҹ��"))
                //{
                //    Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlIn_3 + " union " + SqlIn_4 + SqlOut;//" union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
                //}
                //else
                //{
                //    Sql = SqlIn_1 + " union " + SqlIn_2 + SqlOut;// " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
                //}

                //DataSet ds = App.GetDataSet(Sql);
                #endregion

                StringBuilder sbSum = new StringBuilder("select item_show_name as ItemName,a.item_value as ItemValue,a.item_code as ItemCode from t_nurse_record a");
                sbSum.Append(" where 1=1");
                sbSum.Append(" and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME");
                sbSum.Append(" " + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name in('����','������Ѫ','��Һ','����')");
                //����ʼʱ������Һ
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'��Һ+' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(BeginTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='����'");
                sbSum.Append(" and item_code='��Һ'");
                //�������ʱ������Һ
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'��Һ-' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='����'");
                sbSum.Append(" and item_code='��Һ'");
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
                                case "����":
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
                                    Eat += dtmp;
                                    break;
                                case "������Ѫ":
                                    abnormalvaginalbleeding += dtmp;
                                    break;
                                case "��Һ":
                                    Urine += dtmp;
                                    break;
                                case "����":
                                    OtherOut += dtmp;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                sumtemp.DateTime = EndTime;
                sumtemp.In_item_name = Item_name;
                sumtemp.Number = Number;
                #region oldͳ�Ƹ�ֵ
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("�����ܺ�"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            Eat = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            Eat = "0";
                //        }
                //    }
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Һ"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            LetFlow = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            LetFlow = "0";
                //        }
                //    }
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Һ-"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            Remaining = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            Remaining = "0";
                //        }
                //    }
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Һ+"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            Remained = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            Remained = "0";
                //        }
                //    }
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Ѫ"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            abnormalvaginalbleeding = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            abnormalvaginalbleeding = "0";
                //        }
                //    }
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("��Һ"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            Urine = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            Urine = "0";
                //        }
                //    }
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("����"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            OtherOut = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            OtherOut = "0";
                //        }
                //    }
                //}
                #endregion
                //���������ܺ�
                //try
                //{
                //    inAmount = Convert.ToDouble(Eat) - Math.Abs(Convert.ToDouble(LetFlow)) - Math.Abs(Convert.ToDouble(Remaining)) + Math.Abs(Convert.ToDouble(Remained));
                //}
                //catch (Exception) { inAmount = 0; }
                inAmount = Eat;
                //��������ܺ�
                //try
                //{
                //    outAmount = Convert.ToDouble(abnormalvaginalbleeding) + Convert.ToDouble(Urine) + Convert.ToDouble(OtherOut);
                //}
                //catch (Exception) { outAmount = 0; }
                outAmount = abnormalvaginalbleeding + Urine + OtherOut;
                //sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//ʳ����
                //sumtemp.Out_otheritem_value = outAmount == 0 ? "" : outAmount.ToString();//�����ܺ� 
                //if (Item_name.Contains("С��"))
                //{
                //    sumtemp.Abnormalvaginalbleeding = abnormalvaginalbleeding ==0 ? "" : abnormalvaginalbleeding.ToString();//������Ѫ
                //    sumtemp.Urine = Urine == 0 ? "" : Urine.ToString();//��Һ
                //    sumtemp.Out_otheritem_value = OtherOut == 0 ? "" : OtherOut.ToString();//����
                //}
                //ͳ��ֵΪ0�ľ�����ʾ
                if (Item_name.Contains("�ܽ�"))
                {
                    if (inAmount > 0)
                    {
                        sumtemp.In_item_value = inAmount.ToString();
                    }
                    if (outAmount > 0)
                    {
                        sumtemp.Out_otheritem_value = outAmount.ToString();
                    }
                }
                else
                {
                    for (int isum = 0; isum < sum_item.Length; isum++)
                    {
                        switch (sum_item[isum].Trim())
                        {
                            case "����":
                                if (Eat > 0)
                                {
                                    sumtemp.In_item_value = Eat.ToString();
                                }
                                break;
                            case "������Ѫ":
                                if (abnormalvaginalbleeding > 0)
                                {
                                    sumtemp.Abnormalvaginalbleeding = abnormalvaginalbleeding.ToString();
                                }
                                break;
                            case "��Һ":
                                if (Urine > 0)
                                {
                                    sumtemp.Urine = Urine.ToString();
                                }
                                break;
                            case "����":
                                if (OtherOut > 0)
                                {
                                    sumtemp.Out_otheritem_value = OtherOut.ToString();
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
                    Class_Nurse_Record_Obstetric temp_nuser = (Class_Nurse_Record_Obstetric)SumNusers[i];
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


        /// <summary>
        /// ���ü������������
        /// </summary>
        private void SumInOrOutRecordSets()
        {

            #region old
            //SumNusersRecords.Clear();
            //string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by end_time";
            //DataSet ds_sum_oper = App.GetDataSet(sql_date);

            //for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            //{
            //    //SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            //    SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("Сʱ������", "h�ܽ�") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            //}

            //for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            //{
            //    string BeginTiem, EndTime, Item_name;
            //    string BeginedTiem, EndedTime;
            //    string Remaining = "0";//��Һ-
            //    string Remained = "0";//��Һ+
            //    string Eat = "";//ʳ��
            //    string abnormalvaginalbleeding = "";//������Ѫ
            //    string Urine = "";//��Һ
            //    string OtherOut = "";//��������
            //    string Number = "";//����
            //    string seq_id = "";//ͳ������ID
            //    string LetFlow = "";//��Һ
            //    double inAmount = 0;//�����ܺ�
            //    double outAmount = 0;//�����ܺ�
            //    string SIGNATURE = ""; //ǩ��

            //    BeginTiem = SumNusersRecords[i1].ToString().Split(',')[0];
            //    EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
            //    Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
            //    Number = SumNusersRecords[i1].ToString().Split(',')[3];
            //    seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
            //    SIGNATURE = SumNusersRecords[i1].ToString().Split(',')[5];
            //    string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');//ͳ����Ŀ
            //    //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
            //    SumNusers.Clear();
            //    //�ռ�,ҹ�����һ���ʱ��
            //    BeginedTiem = Convert.ToDateTime(EndTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            //    EndedTime = BeginTiem;

            //    Class_Nurse_Record_Obstetric sumtemp = new Class_Nurse_Record_Obstetric();

            //    string beginSgin = ">=";

            //    string endSgin = "<=";

            //    Class_Take_over_SEQ tempSeq = null;
            //    for (int i = 0; i < cboTiming.Items.Count; i++)
            //    {
            //        tempSeq = cboTiming.Items[i] as Class_Take_over_SEQ;
            //        if (tempSeq != null && tempSeq.Id == seq_id)
            //        {
            //            if (tempSeq.Begin_logic == "0")
            //            {
            //                beginSgin = ">";
            //            }
            //            if (tempSeq.End_logic == "0")
            //            {
            //                endSgin = "<";
            //            }
            //            break;
            //        }
            //    }


            //    ////�����ܺ�
            //    //string SqlIn_1 = "select '�����ܺ�' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //    //       " where item_show_name='����'  and other_name not like '%��Һ%' " +
            //    //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    ////��Һ�ܺ�
            //    //string SqlIn_2 = "select '������Һ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //    //       " where item_show_name='����' and other_name like '%��Һ%' " +
            //    //       " and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    ////������Ѫ:�����ֲ�ͳ��
            //    //string SqlOut_1 = "select '������Ѫ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%����%Ѫ%' and other_name is null and MEASURE_TIME" +
            //    //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    ////��Һ
            //    //string SqlOut_2 = "select '��Һ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%��Һ%' and MEASURE_TIME" +
            //    //beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    ////����
            //    //string SqlOut_3 = "select '����' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%����%' and MEASURE_TIME" +
            //    //beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //string Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;

            //    //�����ܺ�
            //    string SqlIn_1 = "select '�����ܺ�' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //           " where item_show_name='����'  and other_name not like '%��Һ%'  and other_name not like '%��Һ%' " +
            //           "and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //��Һ�ܺ�
            //    string SqlIn_2 = "select '������Һ' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //           " where item_show_name='����' and other_name like '%��Һ%' " +
            //           " and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //��ǰͳ��ʱ����Һ�ܺ�
            //    string SqlIn_3 = "select '������Һ-' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //           " where item_show_name='����'  and other_name like '%��Һ%' " +
            //           @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
            //             endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //�ϴ�ͳ��ʱ����Һ�ܺ�
            //    string SqlIn_4 = "select '������Һ+' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //           " where item_show_name='����'  and other_name like '%��Һ%' " +
            //           @"and MEASURE_TIME>to_timestamp('" + BeginedTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME<=to_timestamp('" + EndedTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    //������Ѫ:�����ֲ�ͳ��!
            //    string SqlOut_1 = "select '������Ѫ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%������Ѫ%' and other_name is null and MEASURE_TIME" +
            //        beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //��Һ
            //    string SqlOut_2 = "select '��Һ' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%��Һ%' and MEASURE_TIME" +
            //        beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //����
            //    string SqlOut_3 = "select '����' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%����%' and MEASURE_TIME" +
            //        beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    string SqlOut = "";

            //    foreach (string i in sum_item)
            //    {
            //        if (i != null && i != "")
            //        {
            //            if (i == "������Ѫ")
            //                SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and other_name is null and MEASURE_TIME" +
            //                    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //            else
            //                SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and MEASURE_TIME" +
            //                    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //        }
            //        else
            //        {
            //            SqlOut = " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
            //        }
            //    }

            //    string Sql = "";
            //    if (Item_name.Contains("�ռ�") || Item_name.Contains("ҹ��"))
            //    {
            //        Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlIn_3 + " union " + SqlIn_4 + SqlOut;//" union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
            //    }
            //    else
            //    {
            //        Sql = SqlIn_1 + " union " + SqlIn_2 + SqlOut;// " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
            //    }
            //    DataSet ds = App.GetDataSet(Sql);

            //    sumtemp.DateTime = EndTime;
            //    sumtemp.In_item_name = Item_name;
            //    sumtemp.Number = Number;
            //    #region ͳ�Ƹ�ֵ
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("�����ܺ�"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Eat = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Eat = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Һ"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                LetFlow = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                LetFlow = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Һ-"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Remaining = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Remaining = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Һ+"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Remained = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Remained = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("������Ѫ"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                abnormalvaginalbleeding = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                abnormalvaginalbleeding = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("��Һ"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Urine = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Urine = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("����"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                OtherOut = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                OtherOut = "0";
            //            }
            //        }
            //    }
            //    #endregion
            //    //���������ܺ�
            //    try
            //    {
            //        inAmount = Convert.ToDouble(Eat) - Math.Abs(Convert.ToDouble(LetFlow)) - Math.Abs(Convert.ToDouble(Remaining)) + Math.Abs(Convert.ToDouble(Remained));
            //    }
            //    catch (Exception) { inAmount = 0; }
            //    //��������ܺ�
            //    try
            //    {
            //        outAmount = Convert.ToDouble(abnormalvaginalbleeding) + Convert.ToDouble(Urine) + Convert.ToDouble(OtherOut);
            //    }
            //    catch (Exception) { outAmount = 0; }

            //    sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//ʳ����
            //    sumtemp.Out_otheritem_value = outAmount == 0 ? "" : outAmount.ToString();//�����ܺ� 
            //    if (Item_name.Contains("С��"))
            //    {
            //        sumtemp.Abnormalvaginalbleeding = abnormalvaginalbleeding == "0" ? "" : abnormalvaginalbleeding;//������Ѫ
            //        sumtemp.Urine = Urine == "0" ? "" : Urine;//��Һ
            //        sumtemp.Out_otheritem_value = OtherOut == "0" ? "" : OtherOut;//����
            //    }
            //    if (SIGNATURE == "")
            //    {
            //        if (App.UserAccount.UserInfo != null)
            //            sumtemp.Signature = App.UserAccount.UserInfo.User_name;//ǩ��
            //    }
            //    else
            //    {
            //        sumtemp.Signature = SIGNATURE;//ǩ��
            //    }
            //    DateTime TempDate = new DateTime();
            //    bool flag = false;//���ܶ����Ƿ�����ӱ�־

            //    if (nurses.Count == 0)
            //    {
            //        SumNusers.Add(sumtemp);
            //    }
            //    //�����ܼ�¼�嵽���󼯺���ȥ
            //    for (int i = 0; i < nurses.Count; i++)
            //    {
            //        SumNusers.Add(nurses[i]);
            //    }

            //    for (int i = 0; i < nurses.Count; i++)
            //    {
            //        Class_Nurse_Record_Obstetric temp_nuser = (Class_Nurse_Record_Obstetric)SumNusers[i];
            //        if (temp_nuser.DateTime != null)
            //        {
            //            TempDate = Convert.ToDateTime(temp_nuser.DateTime);

            //            if (TempDate == Convert.ToDateTime(EndTime))
            //            {
            //                if (tempSeq != null && tempSeq.End_logic == "0")//�������Ϊ��0�������ܲ嵽��ͬʱ������Ŀ֮ǰ
            //                {
            //                    SumNusers.Insert(i, sumtemp);
            //                    break;
            //                }
            //            }
            //            else if (TempDate > Convert.ToDateTime(EndTime))//����ʱ��С�ڵ�ǰ¼��ʱ�䣬�嵽������Ŀ֮ǰ
            //            {
            //                SumNusers.Insert(i, sumtemp);
            //                break;
            //            }
            //        }
            //        if (i == SumNusers.Count - 1)
            //        {
            //            SumNusers.Add(sumtemp);
            //            break;
            //        }
            //    }

            //    nurses.Clear();
            //    for (int i = 0; i < SumNusers.Count; i++)
            //    {
            //        nurses.Add(SumNusers[i]);
            //    }


            //}
            #endregion

            SumInOrOutRecordSet(false);
        }

        #endregion

        private void ��ӿ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flgView.Rows.Insert(flgView.RowSel);
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (flgView[flgView.Row, flgView.Col] != null && flgView[flgView.Row, flgView.Col].ToString() != "")
                {
                    string measureTime = GetTime(flgView.Row);
                    string itemName = dictColumnName[flgView.Col];
                    string otherName = "";
                    string del = "";//ɾ�����


                    if (flgView.Col == 7)
                    {
                        itemName = "����";
                    }
                    //int isIN = 0;
                    int id = 0;
                    if (itemName == "����")
                    {
                        otherName = flgView[flgView.Row, 7].ToString();
                        if (flgView[flgView.Row, 25] != null && flgView[flgView.Row, 25].ToString().Length>0)
                        {
                            try
                            {
                                id = int.Parse(flgView[flgView.Row, 25].ToString());
                            }
                            catch{}
                        }
                        //if (id == 0)
                        //{
                        //    isIN = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "' and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                        //}
                    }

                    if (id == 0 && flgView[flgView.Row, 7] != null && (flgView[flgView.Row, 7].ToString().Contains("С��") || flgView[flgView.Row, 7].ToString().Contains("�ܽ�") || flgView[flgView.Row, 7].ToString().Contains("������")))//ɾ������
                    {
                        string signature = App.ReadSqlVal("select signature from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 12].ToString() + "' and RECORD_TYPE='O' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id, 0, "signature");
                        if (App.UserAccount.UserInfo.User_name == signature || signature == null || signature == "" || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                        {
                            del = "delete from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 7].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id;
                        }
                        else
                        {
                            App.Msg("Ȩ�޲��㣡");
                            return;
                        }
                        
                    }
                    else
                    {
                        if (itemName == "����")
                        {
                            if (flgView[flgView.Row, 7] != null)
                            {
                                otherName = flgView[flgView.Row, 7].ToString();
                            }
                            else
                            {
                                otherName = flgView[flgView.Row, 7].ToString();
                            }

                        }
                        if (itemName == "����" || itemName == "���")
                        {
                            int ireturn=0;
                            otherName = GetOtherName(flgView.Row, ref ireturn).ToString();
                        }
                        //else if (itemName == "����")
                        //{
                        //    otherName = ldXY[flgView[flgView.Row, 26]].ToString();
                        //}
                        if (flgView.Col != 0)//ɾ��������
                        {
                            if (otherName == "")
                            {
                                string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                                {
                                    del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id;
                                }
                                else
                                {
                                    App.Msg("Ȩ�޲��㣡");
                                    return;
                                }
                            }
                            else
                            {
                                if (id > 0)
                                {
                                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where id="+id, 0, "creat_id");
                                    if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                                    {
                                        del = "delete from t_nurse_record where id=" + id;
                                    }
                                    else
                                    {
                                        App.Msg("Ȩ�޲��㣡");
                                        return;
                                    }
                                }
                                else
                                {
                                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                    if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                                    {
                                        del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id;
                                        if (otherName == "1")
                                        {
                                            del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and (other_name='" + otherName + "' or other_name is null) and patient_id=" + currentPatient.Id;
                                        }
                                    }
                                    else
                                    {
                                        App.Msg("Ȩ�޲��㣡");
                                        return;
                                    }
                                }
                            }
                        }
                        else//ɾ����ǰ�е�������Ŀ
                        {
                            //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "creat_id");
                            if (id > 0)
                            {
                                string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id + " order by id", 0, "creat_id"));
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                                {
                                    del = "delete from t_nurse_record where id=" + id;
                                }
                                else
                                {
                                    App.Msg("Ȩ�޲��㣡");
                                    return;
                                }
                            }
                            else
                            {
                                string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("��ʿ��"))
                                {
                                    del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id;
                                }
                                else
                                {
                                    App.Msg("Ȩ�޲��㣡");
                                    return;
                                }
                            }
                        }
                    }


                    int num = App.ExecuteSQL(del);
                    if (num > 0)
                    {
                        operateFlag = true;
                        timer1.Start();
                        //App.Msg("ɾ���ɹ���");
                        //���´�����
                        //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'��create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        //App.ExecuteSQL("update t_nurse_record set  update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        btnSearch_Click(sender, e);
                    }
                }
                else
                {
                    if (flgView[flgView.Row, 0] == null)
                        flgView.Rows.Remove(flgView.Row);
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


            //
            /*
             * 28.3465����/1����
             * 9pt ������ ��Լ 0.3175cm         
             *
             * ��λ��������
             */
            //double datewidth = 1;
            //double timewidth = 1;
            //double tempraturewidth = 1;
            //double pulswidth = 1;
            //double breathwidth = 1;
            //double bloodpruswidth = 1;
            //double spo2width = 1;
            //double medicalwidth = 1;
            //double medicalvalwidth = 1;
            //double foodwidth = 1;
            //double foodvalwidth = 1;
            //double sickinfowidth = 3;
            //double signwidth = 1.25;
            ArrayList DataRows = new ArrayList();

            //ArrayList currRowList = new ArrayList();
            //string currTime = "";
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["in_item_name"].ToString().Contains("С��") || ds.Tables[0].Rows[i]["in_item_name"].ToString().Contains("������"))
            //    {
            //        DataRows.Add(ds.Tables[0].Rows[i]);
            //    }
            //    else
            //    {
            //        if (currTime == "")
            //        {
            //            currTime = ds.Tables[0].Rows[i]["in_item_name"].ToString();
            //            currRowList.Clear();
            //        }

            //        if (currTime != ds.Tables[0].Rows[i]["in_item_name"].ToString())
            //        {
            //            currTime = ds.Tables[0].Rows[i]["in_item_name"].ToString();
            //            currRowList.Clear();
            //        }
            //        currRowList.Add(ds.Tables[0].Rows[i]);
            //    }
            //}


            int maxcount = 0;
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by DATETIMEVAL asc";
            DataSet ds_Time = App.GetDataSet(sql_time);
            if (ds_Time != null)
            {
                for (int i = 0; i < ds_Time.Tables[0].Rows.Count; i++)
                {                   
                    ArrayList drDatarows = new ArrayList();
                    for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
                    {
                        if (!ds.Tables[0].Rows[i1]["in_item_name"].ToString().Contains("С��") &&
                           !ds.Tables[0].Rows[i1]["in_item_name"].ToString().Contains("������") &&
                           !ds.Tables[0].Rows[i1]["in_item_name"].ToString().Contains("�ܽ�"))
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
                        if (drArray[0]["remark"] == null || drArray[0]["remark"].ToString() == "")
                        {
                            for (int j = 0; j < drArray.Length; j++)
                            {
                                DataRows.Add(drArray[j]);
                            }
                        }
                        else
                        {
                            //���㱸ע����
                            string[] remarkArray = RemarkArray(DataInit.ReplaceZYChar(drArray[0]["remark"].ToString()));
                            maxcount = remarkArray.Length > drArray.Length ? remarkArray.Length : drArray.Length;
                            string signature = "";
                            for (int j = 0; j < maxcount; j++)
                            {
                                //��ע�Զ�����
                                if (j <= drArray.Length - 1)
                                {
                                    //���ǩ��
                                    if (drArray[j]["Signature"].ToString() != "" && j < maxcount - 1)
                                    {
                                        signature = drArray[j]["Signature"].ToString();
                                        drArray[j]["Signature"] = "";
                                    }
                                    if (j <= remarkArray.Length - 1)
                                        drArray[j]["remark"] = remarkArray[j];
                                    DataRows.Add(drArray[j]);
                                }
                                else
                                {

                                    DataRow dr = ds.Tables[0].NewRow();
                                    //ǩ���嵽���һ��
                                    if (j == maxcount - 1)
                                    {
                                        dr["Signature"] = signature;
                                    }
                                    dr["remark"] = remarkArray[j];
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
                        //FormatConditionSign(norow[ds.Tables[0].Columns[j].ColumnName].ToString().Split('@')[0].ToString());//,norow[ds.Tables[0].Columns[j].ColumnName].ToString().Split('@')[1].ToString()
                    }
                    else
                    {
                        //if (ds.Tables[0].Columns[j].ColumnName != "Pathograhy")
                        //{
                        temprow1[ds.Tables[0].Columns[j].ColumnName] = norow[ds.Tables[0].Columns[j].ColumnName].ToString();
                        //}
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

            DataRow[] drSum = ds.Tables[0].Select("in_item_name like '%������%' or in_item_name like '%С��%' or in_item_name like '%�ܽ�%'");
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
            dd.Columns.Add("Recordtime");
            //����ʱ����ʾ��ʽ,������ֻͬ��ʾ��һ�����ڣ�����ֻͬ��ʾ��һ�з�
            for (int i = 0; i < dd.Rows.Count; i++)
            {
                dd.Rows[i]["Recordtime"] = dd.Rows[i]["datetime"];
                if (!dd.Rows[i]["in_item_name"].ToString().Contains("С��") &&
                    !dd.Rows[i]["in_item_name"].ToString().Contains("�ܽ�") &&
                    !dd.Rows[i]["in_item_name"].ToString().Contains("������"))
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        if (i % 17 == 0)
                        {
                            tempDate = "";
                        }
                        if (tempDate == "")
                        {
                            dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                            continue;
                        }
                        if (tempDate == currDate.ToString("yyyy-MM-dd") && tempTime == currDate.ToString("HH:mm"))//������ʱ�䶼��ͬ������ʵ
                        {
                            dd.Rows[i]["datetime"] = "";
                        }
                        else if (tempDate == currDate.ToString("yyyy-MM-dd"))//������ͬ����ʾСʱ�ͷ�
                        {
                            dd.Rows[i]["datetime"] = currDate.ToString("HH:mm");
                            tempTime = currDate.ToString("HH:mm");
                        }
                        else//��ͬ������ʾ���� Сʱ ��
                        {
                            dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                        }
                    }
                }
                else
                {
                    dd.Rows[i]["datetime"] = Convert.ToDateTime(dd.Rows[i]["datetime"]).ToString("yyyy-MM-dd HH:mm");
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
            //SizeF sizeF = graphics.MeasureString(remark, new Font("����", 8));
            int strlength = System.Text.Encoding.Default.GetBytes(remark).Length;
            //��ע��ռ����
            int remarkRowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(strlength) / 39));//Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            string[] strArr = new string[remarkRowCount];
            string tempperval = "";
            int index = 0;//�����������
            for (int j = 0; j < remark.Length; j++)
            {
                strlength = System.Text.Encoding.Default.GetBytes(tempperval).Length;
                if (strlength < 39 || (strlength == 39 && System.Text.Encoding.Default.GetBytes(remark[j].ToString()).Length!=2))
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
            //Graphics graphics = CreateGraphics();
            //SizeF sizeF = graphics.MeasureString(remark, new Font("����", 8));
            ////��ע��ռ����
            //int remarkRowCount = Convert.ToInt32(Math.Ceiling(sizeF.Width / (45 * 8)));//28.3465 * 8.3Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            //string[] strArr = new string[remarkRowCount];
            //string tempperval = "";
            //int index = 0;//�����������
            //for (int j = 0; j < remark.Length; j++)
            //{
            //    sizeF = graphics.MeasureString(tempperval, new Font("����", 8));
            //    if (sizeF.Width <= 45 * 8)
            //    {
            //        if (tempperval == "")
            //        {
            //            tempperval = remark[j].ToString();
            //        }
            //        else
            //        {
            //            tempperval += remark[j];
            //        }

            //        if (j == remark.Length - 1)
            //        {
            //            strArr[index] = tempperval;
            //            index++;
            //            tempperval = "";
            //            //j--;
            //        }
            //    }
            //    else
            //    {
            //        strArr[index] = tempperval;
            //        index++;
            //        tempperval = "";
            //        j--;
            //    }
            //}

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
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where Patient_Id =" + currentPatient.Id + "  and RECORD_TYPE='O'", 0, "diagnose_name");//�Լ��޸ĵĻ���
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

            DataSet dsResault=ReSetPrintDataSet(ds);

         
            //ArrayList datalist=new ArrayList();
            for (int i = 0; i < dsResault.Tables[0].Rows.Count;i++)
            {  
                string val="";
                if (dsResault.Tables[0].Rows[i]["Fetal_heart_sound"] != null)
                {
                    val = dsResault.Tables[0].Rows[i]["Fetal_heart_sound"].ToString();
                }

                Image _Image = DrawValueImage(val);

                
                System.IO.MemoryStream _ImageMem = new System.IO.MemoryStream();
                _Image.Save(_ImageMem, ImageFormat.Png);
                byte[] _ImageBytes = _ImageMem.GetBuffer();
                dsResault.Tables[0].Rows[i]["Fetal_heart_sound"] = System.Convert.ToBase64String(_ImageBytes);
            }         
            frmNursePrint_Records ff = new frmNursePrint_Records(dsResault,diagnose, currentPatient, "O");
            ff.Show();
        }

        private void �޸���Ŀ��toolStripMenuItem_Click(object sender, EventArgs e)
        {
            string measureTime = GetTime(flgView.Row);
            C1.Win.C1FlexGrid.RowColEventArgs c1e = e as C1.Win.C1FlexGrid.RowColEventArgs;
            string titleName = "";
            if (flgView[flgView.Row, flgView.Col]!=null)
                titleName = flgView[flgView.Row, flgView.Col].ToString();
            frmModifyProjectTitle frm = new frmModifyProjectTitle(titleName,"N");
            frm.ShowDialog();
            if (frm.flag)
            {
                //ȡ��ǰ����ʱ������Ĵ�����id
                string userId = "";
                try
                {
                    userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (userId == null || userId == "")
                    {
                        userId = App.UserAccount.UserInfo.User_id;
                    }
                }
                catch (System.Exception ex)
                {
                    userId = App.UserAccount.UserInfo.User_id;
                }
                string sql = "insert into t_nurse_record" +
                                   "( bed_no, pid, measure_time, item_code, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                   "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" + frm.tName + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '����','" + frm.tName + "','O')";                    

                //����������Ŀ������               
                if (flgView[flgView.Row, flgView.Col]!=null)
                {
                    if (flgView[flgView.Row, flgView.Col].ToString().Trim() != "")
                    {
                        if (ValidateUser(userId))
                        {
                            sql = "update t_nurse_record set item_code='" + frm.tName + "',other_name='" + frm.tName + "' where patient_id=" + currentPatient.Id + " and item_show_name like '%����%' and RECORD_TYPE='O' and measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9')";                   
                        }
                        else
                        {
                            App.Msg("�޸�Ȩ�޲���!");
                            sql = "";
                        }
                    }
                        
                }
               
                try
                {
                    App.ExecuteSQL(sql);
                    btnSearch_Click(sender, e);
                }
                catch
                {
                }
            }
            
        }

        private void flgView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (flgView[flgView.Row, 0] != null)
            {
                if (flgView.Row >= 3 && flgView.Col == 14)
                {
                    string measureTime = GetTime(flgView.Row);
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (!ValidateUser(operateId) && operateId!=null)
                    {
                        App.Msg("�޸�Ȩ�޲���!");
                        btnSearch_Click(sender, e);
                        return;
                    }
                    frmFormula fc = new frmFormula(currentPatient, measureTime, dictColumnName[14]);
                    fc.ShowDialog();
                    if (fc.successflag)
                    {
                        SetTable();
                        oldInAmountName = "";
                        ShowData();
                        SumInOrOutRecordSet(true);
                        ShowSumDataGrid();
                        CellUnit(pipe1, pipe2, pipe3, pipe4);
                    }
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ��ȡģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// ���ģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ��ӱ�עģ��toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flgView[flgView.Row, flgView.Col] != null)
            {
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd(flgView[flgView.Row, flgView.Col].ToString());
                fc.ShowDialog();
            }
        }

        private int PageRowCount = 17;
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
                    string stime = ds.Tables[0].Rows[fullpagerowindex]["Recordtime"].ToString();
                    while (!DateTime.TryParse(stime, out dtime))
                    {
                        fullpagerowindex--;
                        stime = ds.Tables[0].Rows[fullpagerowindex]["Recordtime"].ToString();
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

    }
}
