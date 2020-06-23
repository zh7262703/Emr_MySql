using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucQualityList : UserControl
    {
        private string sqlSection_Area = "select t2.sid,t3.said,t2.section_name,t3.sick_area_name from t_section_area t1,t_sectioninfo t2,t_sickareainfo t3 where t1.sid=t2.sid and t1.said=t3.said and t2.section_name not in( '��Ժ��������','��Ժ�����','��Ժ������','��ԺѪ͸�����Ƽ���','��ԺסԺ�����','��Ժ�����','��Ժ��������','��Ժ�����','��Ժ������','��ԺѪ͸��') order by t2.section_name,t2.sid";
        private static string names;
        private static DataView dv;
        private DataTable dataTable;
        private DataRow newrow;
        DataSet CBO_DS;// ��ʼ�������б�����ݼ�
        private bool tempFlag = false;//���ڱ�ʶ�Ƿ���ʾ������

        private string title1 = "";
        private string title2 = "";
        private string title3 = "";
        private string pv = "";
        public ucQualityList()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        public ucQualityList(string name, DataView dataView)
        {
            InitializeComponent();
            try
            {
                names = name;
                dv = dataView;
                this.cboTextType.DataSource = dv;
                this.cboTextType.DisplayMember = "Name";
                this.cboTextType.ValueMember = "ID";
            }
            catch { }

        }

        public void InitCombox()
        {
            try
            {
                Bifrost.WebReference.Class_Table[] cboTables = new Bifrost.WebReference.Class_Table[2];


                cboTables[0] = new Bifrost.WebReference.Class_Table();
                cboTables[0].Sql = sqlSection_Area;
                    //"select distinct(ts.sid),ts.section_name from t_Section_Area tsa inner join t_Sectioninfo ts on tsa.sid=ts.sid  order by ts.section_name,ts.sid";//����
                cboTables[0].Tablename = "YWC";

                cboTables[1] = new Bifrost.WebReference.Class_Table();
                cboTables[1].Sql = sqlSection_Area;
                    //"select SAID,SICK_AREA_NAME from t_sickareainfo order by sick_area_name,said";//����
                cboTables[1].Tablename = "HLB";

                CBO_DS = App.GetDataSet(cboTables);

                if (names == "����")
                {
                    label1.Text = "������";

                    dataTable = CBO_DS.Tables["HLB"];
                    newrow = dataTable.NewRow();
                    newrow[3] = "��ѡ��...";
                    dataTable.Rows.InsertAt(newrow, 0);
                    this.cboSickArea.DataSource = CBO_DS.Tables["HLB"].DefaultView;
                    this.cboSickArea.ValueMember = "SAID";
                    this.cboSickArea.DisplayMember = "SICK_AREA_NAME";
                }
                else
                {
                    label1.Text = "���ң�";
                    dataTable = CBO_DS.Tables["YWC"];
                    newrow = dataTable.NewRow();
                    newrow[2] = "��ѡ��...";
                    dataTable.Rows.InsertAt(newrow, 0);
                    this.cboSickArea.DataSource = CBO_DS.Tables["YWC"].DefaultView;
                    this.cboSickArea.ValueMember = "SID";
                    this.cboSickArea.DisplayMember = "SECTION_NAME";
                }

            }
            catch
            { }

        }

        public void InitTable(DataSet dsQuality)
        {
            
            try
            {
                #region ע��
                //    if (tempFlag)
            //    {
            //        flgView.Clear();
            //        flgView.AllowEditing = false;
            //        flgView.Rows.Count = 1;
            //        flgView.Cols.Count = 10;
            //        flgView[0, 1] = "����";
            //        flgView[0, 2] = "סԺ��";
            //        flgView[0, 3] = "����";
            //        flgView[0, 4] = "��������";
            //        flgView[0, 5] = "�ܴ�ҽ��";
            //        flgView[0, 6] = "������Ϣ";
            //        flgView[0, 7] = "�۷�ֵ";
            //        flgView[0, 8] = "��ʱ����";
            //        flgView[0, 9] = "����";
            //        flgView.Cols[9].Name = "id";
            //        flgView.Cols.Fixed = 0;

            //        string pidTemp = "";
            //        string doctorNameTemp = "";
            //        string nameTemp = "";
            //        string bedNoTemp = "";
            //        string sectionTemp = "";
            //        int tempNum = 0;
            //        bool flag = true;
            //        if (dsQuality.Tables[0].Rows.Count > 0)
            //        {
            //            DataRow[] drList = dsQuality.Tables[0].Select();
            //            for (int i = 0; i < drList.Length; i++)
            //            {
            //                flgView.Rows.Add();

            //                string sectionName = drList[i]["SECTION_NAME"].ToString();
            //                string pid = drList[i]["pid"].ToString();
            //                string sickBedNO = drList[i]["SICK_BED_NO"].ToString();
            //                string patientName = drList[i]["PATIENT_NAME"].ToString();
            //                string currentDoctorName = drList[i]["sick_doctor_name"].ToString();
            //                string patientId = drList[i]["id"].ToString();
            //                if (bedNoTemp == sickBedNO && nameTemp == patientName)
            //                {
            //                    sickBedNO = "";
            //                    patientName = "";
            //                    pid = "";
            //                    currentDoctorName = "";
            //                }
            //                if (sectionTemp == sectionName)
            //                {
            //                    sectionName = "";
            //                    flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                }

            //                if (sectionName != "" && i != 0)
            //                {
            //                    //flgView.Rows[i].StyleNew.ForeColor = Color.Red;
            //                    //���߼Ӵ�
            //                    flgView.Rows[i].StyleNew.Border.Color = Color.Red;
            //                    flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                    flgView.Rows[i].StyleNew.Border.Width = 1;

            //                }
            //                string note = drList[i]["NOTE"].ToString();
            //                string grade = drList[i]["TAKE_GRADE"].ToString();
            //                string noteTime = TimeDiff(Convert.ToDateTime(drList[i]["NOTEZTIME"].ToString()));
                            
            //                flgView[1 + i, 1] = sectionName;
            //                flgView[1 + i, 2] = pid;
            //                flgView[1 + i, 3] = sickBedNO;
            //                flgView[1 + i, 4] = patientName;
            //                flgView[1 + i, 5] = currentDoctorName;
            //                flgView[1 + i, 6] = note;
            //                flgView[1 + i, 7] = grade;
            //                flgView[1 + i, 8] = noteTime;
            //                flgView[1 + i, 9] = patientId;

            //                nameTemp = drList[i]["PATIENT_NAME"].ToString();
            //                bedNoTemp = drList[i]["SICK_BED_NO"].ToString();
            //                sectionTemp = drList[i]["SECTION_NAME"].ToString();

            //            }

            //            flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
            //            flgView.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
            //            flgView.Cols["id"].Visible = false;

            //            flgView.AutoSizeCols();
            //            //flgView.AutoSizeRows();
            //            for (int i = 2; i < flgView.Rows.Count; i++)
            //            {
            //                flgView.Rows[i].Height = 25;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rdoRed.Checked == true)
            //        {
            //            flgView.Clear();
            //            flgView.AllowEditing = false;
            //            flgView.Rows.Count = 1;
            //            flgView.Cols.Count = 10;
            //            //flgView[0, 1] = "����";
            //            flgView[0, 1] = "סԺ��";
            //            flgView[0, 2] = "����";
            //            flgView[0, 3] = "����";
            //            flgView[0, 4] = "��������";
            //            flgView[0, 5] = "�ܴ�ҽʦ";
            //            flgView[0, 6] = "������Ϣ";
            //            flgView[0, 7] = "�۷�ֵ";
            //            flgView[0, 8] = "��ʱ����";
            //            //flgView[0, 9] = "���";
            //            //flgView[0, 8] = "����";
            //            //flgView.Cols[8].Name = "id";
            //            flgView.Cols.Fixed = 0;

            //            string nameTemp = "";
            //            string bedNoTemp = "";
            //            string pidTemp = "";
            //            string doctorNameTemp = "";
            //            int tempNum = 0;
            //            bool flag = true;
            //            if (dsQuality.Tables[0].Rows.Count > 0)
            //            {
            //                DataRow[] drList = dsQuality.Tables[0].Select();
            //                for (int i = 0; i < drList.Length; i++)
            //                {
            //                    flgView.Rows.Add();

            //                    string sectionName = drList[i]["SECTION_NAME"].ToString();
            //                    string pid = drList[i]["pid"].ToString();
            //                    string sickBedNO = drList[i]["SICK_BED_NO"].ToString();
            //                    string patientName = drList[i]["PATIENT_NAME"].ToString();
            //                    string currentDoctorName = drList[i]["sick_doctor_name"].ToString();
            //                    string patientId = drList[i]["id"].ToString();
            //                    if (bedNoTemp == sickBedNO && nameTemp == patientName)
            //                    {
            //                        sickBedNO = "";
            //                        patientName = "";
            //                        pid = "";
            //                        currentDoctorName = "";
            //                        sectionName = "";
            //                        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                    }
            //                    if (sickBedNO != "" && i != 0)
            //                    {
            //                        //flgView.Rows[i].StyleNew.ForeColor = Color.Red;
            //                        //���߼Ӵ�
            //                        flgView.Rows[i].StyleNew.Border.Color = Color.Red;
            //                        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                        flgView.Rows[i].StyleNew.Border.Width = 1;

            //                    }
            //                    string note = drList[i]["NOTE"].ToString();
            //                    string grade = drList[i]["TAKE_GRADE"].ToString();
            //                    string noteTime = TimeDiff(Convert.ToDateTime(drList[i]["NOTEZTIME"].ToString()));
            //                    //Image im;
            //                    //if (Convert.ToInt32(drList[i]["pv"]) == 0)
            //                    //{

            //                    //    im = Image.FromFile(Application.StartupPath + "\\ButtonImage\\yellow.png");
            //                    //}
            //                    //else
            //                    //{
            //                    //    im = Image.FromFile(Application.StartupPath + "\\ButtonImage\\red.png");
            //                    //}
            //                    // flgView[1 + i, 1] = sectionName;
            //                    //flgView.Cols[9].DataType = typeof(Bitmap);
            //                    flgView[1 + i, 1] = pid;
            //                    flgView[1 + i, 2] = sickBedNO;
            //                    flgView[1 + i, 3] = sectionName;
            //                    flgView[1 + i, 4] = patientName;
            //                    flgView[1 + i, 5] = currentDoctorName;
            //                    flgView[1 + i, 6] = note;
            //                    flgView[1 + i, 7] = grade;
            //                    flgView[1 + i, 8] = noteTime;
            //                    //flgView[1 + i, 9] = im;

            //                    nameTemp = drList[i]["PATIENT_NAME"].ToString();
            //                    bedNoTemp = drList[i]["SICK_BED_NO"].ToString();

            //                }

            //                flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            //                flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            //                flgView.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
            //                //flgView.Cols["id"].Visible = false;

            //                flgView.AutoSizeCols();
            //                //flgView.AutoSizeRows();
            //                for (int i = 2; i < flgView.Rows.Count; i++)
            //                {
            //                    flgView.Rows[i].Height = 25;
            //                }

            //            }
            //        }
            //        else if (rdoRedY.Checked == true)
            //        {
            //            flgView.Clear();
            //            flgView.AllowEditing = false;
            //            flgView.Rows.Count = 1;
            //            flgView.Cols.Count = 10;
            //            //flgView[0, 1] = "����";
            //            flgView[0, 1] = "סԺ��";
            //            flgView[0, 2] = "����";
            //            flgView[0, 3] = "����";
            //            flgView[0, 4] = "��������";
            //            flgView[0, 5] = "�ܴ�ҽʦ";
            //            flgView[0, 6] = "������Ϣ";
            //            flgView[0, 7] = "�۷�ֵ";
            //            flgView[0, 8] = "��ʱ����";
            //            flgView[0, 9] = " ";
            //            //flgView[0, 8] = "����";
            //            //flgView.Cols[8].Name = "id";
            //            flgView.Cols.Fixed = 0;

            //            string nameTemp = "";
            //            string bedNoTemp = "";
            //            string pidTemp = "";
            //            string doctorNameTemp = "";
            //            int tempNum = 0;
            //            bool flag = true;
            //            if (dsQuality.Tables[0].Rows.Count > 0)
            //            {
            //                DataRow[] drList = dsQuality.Tables[0].Select();
            //                for (int i = 0; i < drList.Length; i++)
            //                {
            //                    flgView.Rows.Add();

            //                    string sectionName = drList[i]["SECTION_NAME"].ToString();
            //                    string pid = drList[i]["pid"].ToString();
            //                    string sickBedNO = drList[i]["SICK_BED_NO"].ToString();
            //                    string patientName = drList[i]["PATIENT_NAME"].ToString();
            //                    string currentDoctorName = drList[i]["sick_doctor_name"].ToString();
            //                    string patientId = drList[i]["id"].ToString();
            //                    if (bedNoTemp == sickBedNO && nameTemp == patientName && pidTemp == pid)
            //                    {
            //                        sickBedNO = "";
            //                        patientName = "";
            //                        pid = "";
            //                        currentDoctorName = "";
            //                        sectionName = "";
            //                        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                    }
            //                    if (sickBedNO != "" && i != 0)
            //                    {
            //                        //flgView.Rows[i].StyleNew.ForeColor = Color.Red;
            //                        //���߼Ӵ�
            //                        flgView.Rows[i].StyleNew.Border.Color = Color.Red;
            //                        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                        flgView.Rows[i].StyleNew.Border.Width = 1;

            //                    }
            //                    string note = drList[i]["NOTE"].ToString();
            //                    string grade = drList[i]["TAKE_GRADE"].ToString();
            //                    string noteTime = TimeDiff(Convert.ToDateTime(drList[i]["NOTEZTIME"].ToString()));
            //                    Image im;
            //                    if (Convert.ToInt32(drList[i]["pv"]) == 0)
            //                    {

            //                        im = Image.FromFile(Application.StartupPath + "\\yellow.png");
            //                    }
            //                    else
            //                    {
            //                        im = Image.FromFile(Application.StartupPath + "\\red.png");
            //                    }
            //                    // flgView[1 + i, 1] = sectionName;
            //                    flgView.Cols[9].DataType = typeof(Bitmap);
            //                    flgView[1 + i, 1] = pid;
            //                    flgView[1 + i, 2] = sickBedNO;
            //                    flgView[1 + i, 3] = sectionName;
            //                    flgView[1 + i, 4] = patientName;
            //                    flgView[1 + i, 5] = currentDoctorName;
            //                    flgView[1 + i, 6] = note;
            //                    flgView[1 + i, 7] = grade;
            //                    flgView[1 + i, 8] = noteTime;
            //                    flgView[1 + i, 9] = im;

            //                    nameTemp = drList[i]["PATIENT_NAME"].ToString();
            //                    bedNoTemp = drList[i]["SICK_BED_NO"].ToString();
            //                    pidTemp = drList[i]["PID"].ToString();

            //                }

            //                flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            //                flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            //                flgView.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
            //                //flgView.Cols["id"].Visible = false;

            //                flgView.AutoSizeCols();
            //                //flgView.AutoSizeRows();
            //                for (int i = 2; i < flgView.Rows.Count; i++)
            //                {
            //                    flgView.Rows[i].Height = 25;
            //                }

            //            }
            //        }
            //        else
            //        {
            //            flgView.Clear();
            //            flgView.AllowEditing = false;
            //            flgView.Rows.Count = 1;
            //            flgView.Cols.Count = 9;
            //            //flgView[0, 1] = "����";
            //            flgView[0, 1] = "סԺ��";
            //            flgView[0, 2] = "����";
            //            flgView[0, 3] = "����";
            //            flgView[0, 4] = "��������";
            //            flgView[0, 5] = "�ܴ�ҽʦ";
            //            flgView[0, 6] = "������Ϣ";
            //            //flgView[0, 6] = "�۷�ֵ";
            //            //flgView[0, 7] = "��ʱ����";
            //            //flgView[0, 6] = "����";
            //           // flgView.Cols[7].Name = "id";
            //            //flgView.Cols.Fixed = 0;

            //            string nameTemp = "";
            //            string bedNoTemp = "";
            //            string pidTemp = "";
            //            string doctorNameTemp = "";
            //            int tempNum = 0;
            //            bool flag = true;
            //            if (dsQuality.Tables[0].Rows.Count > 0)
            //            {
            //                DataRow[] drList = dsQuality.Tables[0].Select();
            //                for (int i = 0; i < drList.Length; i++)
            //                {
            //                    flgView.Rows.Add();

            //                    string sectionName = drList[i]["SECTION_NAME"].ToString();
            //                    string pid = drList[i]["pid"].ToString();
            //                    string sickBedNO = drList[i]["SICK_BED_NO"].ToString();
            //                    string patientName = drList[i]["PATIENT_NAME"].ToString();
            //                    string currentDoctorName = drList[i]["sick_doctor_name"].ToString();
            //                    string patientId = drList[i]["id"].ToString();
            //                    if (bedNoTemp == sickBedNO && nameTemp == patientName)
            //                    {
            //                        sickBedNO = "";
            //                        patientName = "";
            //                        pid = "";
            //                        currentDoctorName = "";
            //                        sectionName = "";
            //                        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                    }
            //                    if (sickBedNO != "" && i != 0)
            //                    {
            //                        //flgView.Rows[i].StyleNew.ForeColor = Color.Red;
            //                        //���߼Ӵ�
            //                        flgView.Rows[i].StyleNew.Border.Color = Color.Red;
            //                        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                        flgView.Rows[i].StyleNew.Border.Width = 1;

            //                    }
            //                    string note = drList[i]["NOTE"].ToString();
            //                    //string grade = drList[i]["TAKE_GRADE"].ToString();
            //                    //string noteTime = TimeDiff(Convert.ToDateTime(drList[i]["NOTEZTIME"].ToString()));

            //                    // flgView[1 + i, 1] = sectionName;
            //                    flgView[1 + i, 1] = pid;
            //                    flgView[1 + i, 2] = sickBedNO;
            //                    flgView[1 + i, 3] = sectionName;
            //                    flgView[1 + i, 4] = patientName;
            //                    flgView[1 + i, 5] = currentDoctorName;
            //                    flgView[1 + i, 6] = note;
            //                    //flgView[1 + i, 6] = grade;
            //                    //flgView[1 + i, 7] = noteTime;
            //                    //flgView[1 + i, 6] = patientId;

            //                    nameTemp = drList[i]["PATIENT_NAME"].ToString();
            //                    bedNoTemp = drList[i]["SICK_BED_NO"].ToString();

            //                }

            //                flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            //                flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            //                //flgView.Cols["id"].Visible = false;

            //                flgView.AutoSizeCols();
            //                //flgView.AutoSizeRows();
            //                for (int i = 2; i < flgView.Rows.Count; i++)
            //                {
            //                    flgView.Rows[i].Height = 25;
            //                }

            //            }
            //        }
            //    }
            #endregion
                flgView.DataSource = dsQuality.Tables[0];
                flgView.Cols["id"].Visible = false;
                flgView.Cols["sid"].Visible = false;
                flgView.Cols["sick_Doctor_Name"].Visible = false;
                flgView.AllowEditing = false;
                for (int i = 1; i < flgView.Rows.Count; i++)
                {
                    CellRange r = flgView.GetCellRange(i, flgView.Cols["����"].Index);
                    if (flgView.GetData(i, "����").ToString() == "1")
                    {
                        r.Image = imageList1.Images[0];
                        r.Clip = string.Empty;
                    }
                    else if (flgView.GetData(i, "����").ToString() == "0")
                    {
                        r.Image = imageList1.Images[1];
                        r.Clip = string.Empty;
                    }
                    else if (flgView.GetData(i, "����").ToString() == "3")
                    {
                        r.Image = imageList1.Images[2];
                        r.Clip = string.Empty;
                    }
                }
            }
            catch
            {
            }
            
        }

        /// <summary>
        /// ����ʱ���ֵ
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string TimeDiff(DateTime dateTime)
        {
            string dateDiff = null;
            
            TimeSpan ts1 = new TimeSpan(App.GetSystemTime().Ticks);
            TimeSpan ts2 = new TimeSpan(dateTime.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "��"
                    + ts.Hours.ToString() + "Сʱ";
            return dateDiff;

        }

        /// <summary>
        /// ����ʱ���ֵ
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string TimeDiff(DateTime dateTime, DateTime dateTime2)
        {
            string dateDiff = null;

            TimeSpan ts1 = new TimeSpan(dateTime2.Ticks);
            TimeSpan ts2 = new TimeSpan(dateTime.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "��"
                    + ts.Hours.ToString() + "Сʱ";
            return dateDiff;

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            #region ע��
            //string sql = "select tip.id,tip.section_id,tip.section_name,tip.IN_Doctor_Name,tip.pid,tip.sick_bed_no,"
            //           + "tip.patient_name,tip.Sick_Doctor_Name,tqr.note,tqr.noteztime,tqr.take_grade,tqr.pv from t_quality_record tqr inner join t_in_patient tip "
            //            + "on tqr.PATIENT_ID=tip.id";

            //string sqlList = "select tip.idtqr.pid,tqr.red_time,tqr.operate_time,tqr.operate_doctor,tqr.patientname," +
            //            "tqr.text_name,tip.section_name,tip.sick_bed_no from t_Quality_Record_Temp tqr inner join t_in_patient tip on tqr.PATIENT_ID=tip.id";

            //int pv = 1;
           
            //if (this.cboTextType.Text == "��ѡ��..." && this.cboSickArea.Text != "��ѡ��...")
            //{
            //    if (rdoRecord.Checked == true)
            //    {
            //        sqlList = sqlList + " where section_name='" + this.cboSickArea.Text + "'";
            //    }
            //    else
            //    {
            //        if (!rdoRedY.Checked)
            //        {
            //            if (rdoRed.Checked == true)
            //            {
            //                pv = 1;
            //            }
            //            else if (rdoYellow.Checked == true)
            //            {
            //                pv = 0;

            //            }
            //            sql = sql + " where tip.section_name='" + this.cboSickArea.Text + "' and pv=" +
            //                   pv + " order by tip.patient_name,tqr.note desc";
            //        }
            //        else
            //        {
            //            sql = sql + " where tip.section_name='" + this.cboSickArea.Text + "' order by tip.patient_name,tqr.note desc";
            //        }

            //    }
            //}
            //else if (this.cboSickArea.Text == "��ѡ��..." && this.cboTextType.Text != "��ѡ��...")
            //{

            //    if (rdoRecord.Checked == true)
            //    {
            //        sqlList = sqlList + " where text_name='" + this.cboTextType.Text + "'";
            //    }
            //    else
            //    {
            //        if (!rdoRedY.Checked)
            //        {
            //            if (rdoRed.Checked == true)
            //            {
            //                pv = 1;
            //            }
            //            else if (rdoYellow.Checked == true)
            //            {
            //                pv = 0;
            //            }
            //            sql = sql + " where tqr.doctype='" + this.cboTextType.Text + "' and pv=" +
            //                pv + " order by tip.section_name,tip.patient_name,tqr.note desc";
            //        }
            //        else
            //        {
            //            sql = sql + " where tqr.doctype='" + this.cboTextType.Text + "' order by tip.section_name,tip.patient_name,tqr.note desc";
            //        }
            //    }
            //    tempFlag = true;
            //}
            //else
            //{
            //    if (rdoRed.Checked == true)
            //    {
            //        pv = 1;
            //        sql = sql + "  where  pv=" + pv + " order by tip.patient_name,tqr.note desc";
            //    }
            //    else if (rdoYellow.Checked == true)
            //    {
            //        pv = 0;
            //        sql = sql + "  where  pv=" + pv + " order by tip.patient_name,tqr.note desc";
            //    }
            //    else if (rdoRedY.Checked == true)
            //    {
            //        sql = sql + " order by tip.patient_name,tqr.note desc";
            //    }
            //}
            //DataSet dsQuality;

            //if (rdoRecord.Checked == true)
            //{
            //    dsQuality = App.GetDataSet(sqlList);


            //    if (dsQuality != null && dsQuality.Tables[0].Rows.Count != 0)
            //    {
            //        InitTableTemp(dsQuality);
            //    }
            //    else
            //    {
            //        App.Msg("�ò�ѯ����û�ж�Ӧ���ʿؼ�¼");
            //        flgView.Clear();
            //    }


            //}
            //else
            //{
            //    dsQuality = App.GetDataSet(sql);

            //    if (dsQuality != null && dsQuality.Tables[0].Rows.Count != 0)
            //    {
            //        InitTable(dsQuality);
            //    }
            //    else
            //    {
            //        App.Msg("�ò�ѯ����û�ж�Ӧ���ʿؼ�¼");
            //        flgView.Clear();
            //    }

            //}

#endregion
            string sql = "select tip.id,tip.sid,tip.section_name as ��������,tip.sick_Doctor_Name,tip.pid as סԺ��,"+
                         "tip.sick_bed_no as ����,tip.patient_name as ��������,tip.Sick_Doctor_Name as �ܴ�ҽ��,tip.DOCTYPE ��������,tip.note as ������Ϣ," +
                         "to_char(tip.noteztime,'yyyy-MM-dd hh24:mi') as ��ʱʱ��,tip.in_time ��Ժʱ��,tip.leave_time ��Ժʱ��,tip.take_grade as �۷�ֵ,tip.pv as ���� from record_monitor_view tip ";

            string str = '"' + "����(��¼)ҽ��" + '"';
            string sqlList = " select tip.section_name ��������,tip.DOCTYPE ��������,tip.PID סԺ��,tip.sick_bed_no ����,tip.patient_name ��������,tip.sick_doctor_name �ܴ�ҽ��," +
                             "tip.note ������Ϣ,tip.in_time ��Ժʱ��,tip.leave_time ��Ժʱ��,tip.user_name as "+str+",tip.pv ���� from record_monitor_bulu tip";
//flgView.SaveExcel("","",FileFlags.
            string strswitchs = "";
            if (rdoRed.Checked == true)
            {
                pv = " pv=1";
            }
            else if (rdoYellow.Checked == true)
            {
                pv = " pv=0";

            }
            else if (rdoRedY.Checked)
            {
                pv = " (pv=0 or pv=1)";
            }
            else if (rdoRecord.Checked)
            {
                pv = " pv=3";
            }
            if (this.cboTextType.Text == "��ѡ��..." && this.cboSickArea.Text != "��ѡ��...")
            {
                strswitchs=" where tip.section_name='" + this.cboSickArea.Text + "' and" + pv;
                //sql = sql + strswitchs;// +" order by tip.patient_name,tip.note desc";
            }
            else if (this.cboTextType.Text != "��ѡ��..." && this.cboSickArea.Text == "��ѡ��...")
            {
                strswitchs = " where tip.doctype='" + this.cboTextType.Text + "' and " +
                    pv;
                //sql = sql + strswitchs;// +" order by tip.section_name,tip.patient_name,tip.note desc";
                tempFlag = true;
            }
            else if (this.cboSickArea.Text != "��ѡ��..." && this.cboTextType.Text != "��ѡ��...")
            {
                strswitchs= " where tip.doctype='" + this.cboTextType.Text + "'and tip.section_name='" +
                    this.cboSickArea.Text + "' and " + pv;
                //sql = sql +strswitchs;// +" order by tip.section_name,tip.patient_name,tip.note desc";
                tempFlag = true;
            }
            else
            {
                strswitchs=" where " + pv;
                //sql = sql + strswitchs;// +" order by tip.patient_name,tip.note desc";
            }
            DataSet dsQuality;
            if (chbIn_Time.Checked)
            {
                strswitchs=strswitchs+" and in_time between to_date('" + 
                    dtpInStart.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd') and to_date('" + 
                    dtpInEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
            }
            if (chbLeave_Time.Checked)
            {
                strswitchs= strswitchs+" and leave_time between to_date('" + 
                    dtpOutStart.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd') and to_date('" + 
                    dtpOutEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
            }
            sql = sql + strswitchs;
            if (rdoRecord.Checked == true)
            {
                dsQuality = App.GetDataSet(sqlList+strswitchs);
                InitTableTemp(dsQuality);
            }
            else
            {
                dsQuality = App.GetDataSet(sql);

                if (dsQuality != null && dsQuality.Tables[0].Rows.Count != 0)
                {
                    InitTable(dsQuality);
                }
                else
                {
                    App.Msg("�ò�ѯ����û�ж�Ӧ���ʿؼ�¼");
                    flgView.Clear();
                }

            }

        }

        #region  ��ʾ���������¼�ı��
        /// <summary>
        /// ��ʾ���������¼�ı��
        /// </summary>
        /// <param name="dsQuality"></param>
        public void InitTableTemp(DataSet dsQuality)
        {
            #region ע��
            //flgView.Clear();
            //flgView.AllowEditing = false;
            //flgView.Rows.Count = 1;
            //flgView.Cols.Count = 10;
            //flgView[0, 1] = "����";
            //flgView[0, 2] = "סԺ��";
            //flgView[0, 3] = "����";
            //flgView[0, 4] = "��������";
            //flgView[0, 5] = "��������";
            //flgView[0, 6] = "��ʱ���첹��";
            //flgView[0, 7] = "�ܴ�ҽ��";
            //flgView[0, 8] = "���������ʱ��";
            //flgView[0, 9] = "����";
            //flgView.Cols[9].Name = "id";
            //flgView.Cols.Fixed = 0;

            //string nameTemp = "";
            //string bedNoTemp = "";
            //string sectionTemp = "";
            //int tempNum = 0;
            //bool flag = true;
            //if (dsQuality.Tables[0].Rows.Count > 0)
            //{
            //    flgView.DataSource = dsQuality.Tables[0].DefaultView;
            //    DataRow[] drList = dsQuality.Tables[0].Select();
                //for (int i = 0; i < drList.Length; i++)
                //{
                //    flgView.Rows.Add();

                //    string sectionName = drList[i]["SECTION_NAME"].ToString();
                //    string sickBedNO = drList[i]["SICK_BED_NO"].ToString();
                //    string patientName = drList[i]["PATIENTNAME"].ToString();
                //    string pid = drList[i]["PID"].ToString();
                //    string patientId = drList[i]["id"].ToString();
                //    if (bedNoTemp == sickBedNO && nameTemp == patientName)
                //    {
                //        sickBedNO = "";
                //        patientName = "";
                //        pid = "";
                //    }
                //    if (sectionTemp == sectionName)
                //    {
                //        sectionName = "";
                //        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
                //    }

                //    if (sectionName != "" && i != 0)
                //    {
                //        //flgView.Rows[i].StyleNew.ForeColor = Color.Red;
                //        //���߼Ӵ�
                //        flgView.Rows[i].StyleNew.Border.Color = Color.Red;
                //        flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
                //        flgView.Rows[i].StyleNew.Border.Width = 1;

                //    }
                //    string textName = drList[i]["TEXT_NAME"].ToString();
                //    string operatedoctor = drList[i]["OPERATE_DOCTOR"].ToString();
                //    string noteTime = TimeDiff(Convert.ToDateTime(drList[i]["OPERATE_TIME"].ToString()), Convert.ToDateTime(drList[i]["RED_TIME"].ToString()));
                //    DateTime operateTime = Convert.ToDateTime(drList[i]["OPERATE_TIME"].ToString());
                //    flgView[1 + i, 1] = sectionName;
                //    flgView[1 + i, 2] = pid;
                //    flgView[1 + i, 3] = sickBedNO;
                //    flgView[1 + i, 4] = patientName;
                //    flgView[1 + i, 5] = textName;
                //    flgView[1 + i, 6] = noteTime;
                //    flgView[1 + i, 7] = operatedoctor;
                //    flgView[1 + i, 8] = operateTime;
                //    flgView[1 + i, 9] = patientId;
                //    nameTemp = drList[i]["PATIENTNAME"].ToString();
                //    bedNoTemp = drList[i]["SICK_BED_NO"].ToString();
                //    sectionTemp = drList[i]["SECTION_NAME"].ToString();

                //}

                //flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
                //flgView.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
                //flgView.Cols["id"].Visible = false;
                //for (int i = 1; i < flgView.Rows.Count; i++)
                //{
                //    CellRange r = flgView.GetCellRange(i, flgView.Cols["����"].Index);
                //    if (flgView.GetData(i, "����").ToString() == "1")
                //    {
                //        r.Image = imageList1.Images[0];
                //        r.Clip = string.Empty;
                //    }
                //    else if (flgView.GetData(i, "����").ToString() == "0")
                //    {
                //        r.Image = imageList1.Images[1];
                //        r.Clip = string.Empty;
                //    }
                //}
                //flgView.AutoSizeCols();
                //flgView.AutoSizeRows();
                //for (int i = 2; i < flgView.Rows.Count; i++)
                //{
                //    flgView.Rows[i].Height = 25;
            //}
    
    #endregion
            if (dsQuality.Tables[0].Rows.Count > 0)
            {
                flgView.DataSource = dsQuality.Tables[0].DefaultView;
                DataRow[] drList = dsQuality.Tables[0].Select();
                flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
                flgView.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
                //flgView.Cols["id"].Visible = false;
                for (int i = 1; i < flgView.Rows.Count; i++)
                {
                    CellRange r = flgView.GetCellRange(i, flgView.Cols["����"].Index);
                    if (flgView.GetData(i, "����").ToString() == "3")
                    {
                        r.Image = imageList1.Images[2];
                        r.Clip = string.Empty;
                    }
                }
                flgView.AutoSizeCols();
                //flgView.AutoSizeRows();
                //for (int i = 2; i < flgView.Rows.Count; i++)
                //{
                //    flgView.Rows[i].Height = 25;
                //}
            }
        }
        #endregion

        private void ucQualityList_Load(object sender, EventArgs e)
        {
            InitCombox();
            this.cboTextType.DataSource = dv;
            this.cboTextType.DisplayMember = "Name";
            this.cboTextType.ValueMember = "ID";
        }


        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            string id = flgView[flgView.RowSel, "id"].ToString();
            if (id != null && id != "")
            {
                string sql = "select * from t_in_patient t where t.id='" + id + "'";
                DataSet ds1 = App.GetDataSet(sql);
                if (ds1 != null)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        InPatientInfo patientInfo = new InPatientInfo();

                        patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                        patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                        //if (ds1.Tables[0].Rows[0]["Gender_Code"].ToString().Equals("��"))
                        //{
                        patientInfo.Gender_Code = ds1.Tables[0].Rows[0]["Gender_Code"].ToString();
                        //}
                        //else
                        //{
                        //    patientInfo.Gender_Code = "1";
                        //}
                        patientInfo.Marrige_State = ds1.Tables[0].Rows[0]["marriage_state"].ToString();
                        patientInfo.Medicare_no = ds1.Tables[0].Rows[0]["Medicare_no"].ToString();
                        patientInfo.Home_address = ds1.Tables[0].Rows[0]["Home_address"].ToString();
                        patientInfo.HomePostal_code = ds1.Tables[0].Rows[0]["HomePostal_code"].ToString();
                        patientInfo.Home_phone = ds1.Tables[0].Rows[0]["Home_phone"].ToString();
                        patientInfo.Office = ds1.Tables[0].Rows[0]["Office"].ToString();
                        patientInfo.Office_address = ds1.Tables[0].Rows[0]["Office_Address"].ToString();
                        patientInfo.Office_phone = ds1.Tables[0].Rows[0]["Office_phone"].ToString();
                        patientInfo.Relation = ds1.Tables[0].Rows[0]["Relation"].ToString();
                        patientInfo.Relation_address = ds1.Tables[0].Rows[0]["Relation_address"].ToString();
                        patientInfo.Relation_phone = ds1.Tables[0].Rows[0]["Relation_phone"].ToString();
                        patientInfo.RelationPos_code = ds1.Tables[0].Rows[0]["RelationPos_code"].ToString();
                        patientInfo.OfficePos_code = ds1.Tables[0].Rows[0]["OfficePos_code"].ToString();
                        if (ds1.Tables[0].Rows[0]["InHospital_Count"].ToString() != "")
                            patientInfo.InHospital_count = Convert.ToInt32(ds1.Tables[0].Rows[0]["InHospital_Count"].ToString());
                        patientInfo.Cert_Id = ds1.Tables[0].Rows[0]["cert_id"].ToString();
                        patientInfo.Pay_Manager = ds1.Tables[0].Rows[0]["pay_manner"].ToString();
                        patientInfo.In_Circs = ds1.Tables[0].Rows[0]["IN_Circs"].ToString();
                        patientInfo.Natiye_place = ds1.Tables[0].Rows[0]["native_place"].ToString();
                        patientInfo.Birth_place = ds1.Tables[0].Rows[0]["Birth_place"].ToString();
                        patientInfo.Folk_code = ds1.Tables[0].Rows[0]["Folk_code"].ToString();

                        patientInfo.Birthday = ds1.Tables[0].Rows[0]["Birthday"].ToString();
                        patientInfo.PId = ds1.Tables[0].Rows[0]["PId"].ToString();
                        patientInfo.Insection_Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["insection_id"]);
                        patientInfo.Insection_Name = ds1.Tables[0].Rows[0]["insection_name"].ToString();
                        patientInfo.In_Area_Id = ds1.Tables[0].Rows[0]["in_area_id"].ToString();
                        patientInfo.In_Area_Name = ds1.Tables[0].Rows[0]["in_area_name"].ToString();
                        if (ds1.Tables[0].Rows[0]["Age"].ToString() != "")
                            patientInfo.Age = ds1.Tables[0].Rows[0]["Age"].ToString();
                        else
                        {
                            if (patientInfo.Age == "0")
                            {
                                patientInfo.Age = Convert.ToString(App.GetSystemTime().Year - Convert.ToDateTime(patientInfo.Birthday).Year);
                                patientInfo.Age_unit = "��";
                            }
                        }
                        //inpatient.Action_State = row["action_state"].ToString();
                        patientInfo.Sick_Doctor_Id = ds1.Tables[0].Rows[0]["sick_doctor_id"].ToString();
                        patientInfo.Sick_Doctor_Name = ds1.Tables[0].Rows[0]["sick_doctor_name"].ToString();
                        if (ds1.Tables[0].Rows[0]["Sick_Area_Id"] != null)
                            patientInfo.Sike_Area_Id = ds1.Tables[0].Rows[0]["Sick_Area_Id"].ToString();
                        patientInfo.Sick_Area_Name = ds1.Tables[0].Rows[0]["sick_area_name"].ToString();
                        if (ds1.Tables[0].Rows[0]["section_id"].ToString() != "")
                            patientInfo.Section_Id = Int32.Parse(ds1.Tables[0].Rows[0]["section_id"].ToString());
                        patientInfo.Section_Name = ds1.Tables[0].Rows[0]["section_name"].ToString();
                        if (ds1.Tables[0].Rows[0]["in_time"] != null)
                            patientInfo.In_Time = DateTime.Parse(ds1.Tables[0].Rows[0]["in_time"].ToString());
                        patientInfo.State = ds1.Tables[0].Rows[0]["state"].ToString();
                        if (ds1.Tables[0].Rows[0]["sick_bed_id"].ToString() != "")
                            patientInfo.Sick_Bed_Id = Int32.Parse(ds1.Tables[0].Rows[0]["sick_bed_id"].ToString());
                        patientInfo.Sick_Bed_Name = ds1.Tables[0].Rows[0]["sick_bed_no"].ToString();
                        patientInfo.Age_unit = ds1.Tables[0].Rows[0]["age_unit"].ToString();
                        patientInfo.Sick_Degree = Convert.ToString(ds1.Tables[0].Rows[0]["Sick_Degree"]);
                        if (ds1.Tables[0].Rows[0]["Die_flag"].ToString() != "")
                            patientInfo.Die_flag = Convert.ToInt32(ds1.Tables[0].Rows[0]["Die_flag"]);
                        patientInfo.Card_Id = ds1.Tables[0].Rows[0]["card_id"].ToString();
                        patientInfo.Nurse_Level = ds1.Tables[0].Rows[0]["nurse_level"].ToString();
                        patientInfo.Career = ds1.Tables[0].Rows[0]["Career"].ToString();//ְҵ
                        patientInfo.Out_Id = ds1.Tables[0].Rows[0]["out_id"].ToString();//�����
                        patientInfo.Relation_name = ds1.Tables[0].Rows[0]["Relation_Name"].ToString();//��ϵ������


                        ucDoctorOperater fq = new ucDoctorOperater(patientInfo);
                        App.UsControlStyle(fq);
                        App.AddNewBusUcControl(fq,"��������");
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string cols = "";
            if (!cboSickArea.Text.Contains("��ѡ��"))
            {
                title1 = cboSickArea.Text;
            }
            if (!cboTextType.Text.Contains("��ѡ��"))
            {
                title2 = cboTextType.Text;
            }
            if (pv.Trim().Contains("pv=3"))
            {
                title3 = "��¼";
                cols = "��������,סԺ��,��������,��Ժʱ��,�ܴ�ҽ��,����(��¼)ҽ��";
            }
            else
            {
                title3 = "δ���";
                cols = "��������,סԺ��,��������,��Ժʱ��,�ܴ�ҽ��";
            }
            string title=title1+title2+title3;
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Filter = "Excel ������(.xls)|*.xls";
            sfg.FileName = title;
            DialogResult drst= sfg.ShowDialog();
            if(drst== DialogResult.OK)
            {
                SetVisable(cols, true);
                flgView.SaveExcel(sfg.FileName,FileFlags.IncludeFixedCells);
                SetAllVisable(true);
            }
        }
        /// <summary>
        /// ������ʾ����
        /// </summary>
        /// <param name="colnames">�еļ���</param>
        /// <param name="flag">�Ƿ���ʾ</param>
        private void SetVisable(string colnames, bool flag)
        {
            string[] colns = colnames.Split(',');
            foreach (Column item in flgView.Cols)
            {
                bool isvisable = false;
                for (int i = 0; i < colns.Length; i++)
                {
                    if (item.Name.Contains(colns[i]))
                    {
                        item.Visible = flag;
                        isvisable = true;
                        break;
                    }
                }
                if (!isvisable)
                {
                    item.Visible = false;
                }
            }
        }
        /// <summary>
        /// ���ñ���������е���ʾ
        /// </summary>
        /// <param name="flag"></param>
        private void SetAllVisable(bool flag)
        {
            foreach (Column item in flgView.Cols)
            {
                item.Visible = flag;
            }
        }

        private void chbIn_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIn_Time.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void chbLeave_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLeave_Time.Checked)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
        }
    }
}
