using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using Bifrost;
using System.Data;
using System.Collections;
using Base_Function.TEMPERATURES;
using System.Globalization;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON
{
    public class printTemper_Child
    {
        private Pen blackPen = new Pen(Color.Black, 1);//�ڱ�
        private Pen lightblackPen = new Pen(Color.Gray, 0.1f);//�ڱ�
        private Pen redPen = new Pen(Color.Red, 1);    //���
        private Pen bluePen = new Pen(Color.Blue, 1);//����
        private Brush brush = new SolidBrush(Color.Black);
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush whiteBrush = new SolidBrush(Color.White);
        private Font tenFont = new Font("����", 10f, FontStyle.Bold);
        private Font nineFont = new Font("����", 9f);
        private Font eightFont = new Font("����", 8f);
        //private Font eightBlodFont = new Font("����", 8f, FontStyle.Bold);
        private Font sevenFont = new Font("����", 7f);
        //private Font sevenBlodFont = new Font("����", 7f, FontStyle.Bold);
        private Font sixFont = new Font("����", 6f);
        private Brush fillBrush = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.FromArgb(0));


        private StringFormat textFormat = new StringFormat();
        private Dictionary<string, string> user = new Dictionary<string, string>();
        private Graphics _graph = null;
        private int mainChildTop = 0;
        private int mainTop = 0;
        private bool isChild = false;
        private int pageIndex = 0;
        private int topRows = 4;//�����������
        private int topRowSpace = 20;
        private int gridRows = 40;//�������:һ�����5����ֵ
        private int gridRowsSpace = 14;
        private int bottomRows = 11;//����������ߵ�������
        private int bottomRosSpace = 25;
        private int gridCols = 42;//�������:һ�����6����ֵ
        private int gridColsWidth = 14;
        private Rectangle headerRec = new Rectangle(40, -40, 660, 220); //40, 0, 660, 120
        private Rectangle mainRec;//y:130,height:910 //1080
        private Rectangle footerRec = new Rectangle(40, 1000, 660, 40);
        private Rectangle footerRecs = new Rectangle(300, 1000, 660, 40);
        private DateTime startTime; //��ʼʱ��
        private DateTime endTime;  //����ʱ��
        private string ToTime = string.Empty;   //��Ժʱ��
        private string pid = string.Empty; //����ID
        public List<DataTable> dbList = null; //���ݼ���
        private Dictionary<int, List<PointF>> printPoint = null; //��ͨ���µ�����Ϣ
        private const int dayWidth = 84;  // һ��� ���
        private const int hourWidth = 14; // һ��ʱ�����
        private string dcgDate;
        public DateTime out_time;
        public int pWidth = 800;
        public int pHeight = 1230;//850;
        ///�����и߶�
        private int rHeight = 30;


        private bool breathUpFlag = false;        //���������±�־ true �� false ��

        private bool painUpFlag = false;        //��ʹ�����±�־ true �� false ��

        DataSet ds_operaters = new DataSet();

        private ArrayList CutPoints = new ArrayList();




        /// <summary>
        /// ������ʱ��
        /// </summary>
        public string DcgDate
        {
            get { return dcgDate; }
            set { dcgDate = value; }
        }

        private string dcgBatchno;
        /// <summary>
        /// ����������
        /// </summary>
        public string DcgBatchno
        {
            get { return dcgBatchno; }
            set { dcgBatchno = value; }
        }

        private string hepatitsDate;
        /// <summary>
        /// �Ҹ�����ʱ��
        /// </summary>
        public string HepatitsDate
        {
            get { return hepatitsDate; }
            set { hepatitsDate = value; }
        }

        private string hepatitsBatchno;
        /// <summary>
        /// �Ҹ���������
        /// </summary>
        public string HepatitsBatchno
        {
            get { return hepatitsBatchno; }
            set { hepatitsBatchno = value; }
        }

        /// <summary>
        /// ��ǰҳ��
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// ��ӡ�û���Ϣ
        /// </summary>
        public Dictionary<string, string> User
        {
            get { return user; }
            set { user = value; }
        }

        private bool isDrawHeader = true;
        /// <summary>
        /// �Ƿ��ӡҳü
        /// </summary>
        public bool IsDrawHeader
        {
            get { return isDrawHeader; }
            set { isDrawHeader = value; }
        }

        private bool isDrawFooter = true;
        /// <summary>
        /// �Ƿ��ӡҳ��
        /// </summary>
        public bool IsDrawFooter
        {
            get { return isDrawFooter; }
            set { isDrawFooter = value; }
        }

        private string _hospital;
        /// <summary>
        /// ҽԺ����
        /// </summary>
        public string Hospital
        {
            get { return _hospital; }
            set { _hospital = value; }
        }

        private string _textName;
        /// <summary>
        /// ��������
        /// </summary>
        public string TextName
        {
            get { return _textName; }
            set { _textName = value; }
        }



        public Graphics graph
        {
            get { return _graph; }
            set { _graph = value; }
        }

        InPatientInfo currPatient;
        ///// <summary>
        ///// ������
        ///// </summary>
        ///// <param name="_graph"></param>
        //public void printMain(Graphics _graph)
        //{
        //    this.graph = _graph;
        //    this.graph.SmoothingMode = SmoothingMode.AntiAlias;
        //    this.graph.TextRenderingHint = TextRenderingHint.AntiAlias;
        //    setFormat(StringAlignment.Center, StringAlignment.Center, StringTrimming.EllipsisCharacter);
        //    printHeader();
        //    mainChildTop = 570 + mainRec.Top;
        //    mainTop = 614 + mainRec.Top; //600
        //    //printMain();
        //    printChildMain();
        //    printFooter();
        //}

        public void Init(string _pid, string _toTime)
        {
            setFormat(StringAlignment.Center, StringAlignment.Center, StringTrimming.EllipsisCharacter);
            /***
             * ����
             */
            if (dbList != null)
            {
                dbList.Clear();
            }
            printPoint = new Dictionary<int, List<PointF>>(); //��ͨ���µ�����Ϣ
            printPoint.Add(1, new List<PointF>());  //Ҹ��
            printPoint.Add(2, new List<PointF>());  //�ڱ�
            printPoint.Add(3, new List<PointF>());  //�ر�
            printPoint.Add(4, new List<PointF>());  //����
            printPoint.Add(5, new List<PointF>());  //����
            printPoint.Add(6, new List<PointF>());  //���º��¶�
            printPoint.Add(7, new List<PointF>());  //�ڱ��������ཻ
            printPoint.Add(8, new List<PointF>());  //Ҹ���������ཻ
            printPoint.Add(9, new List<PointF>());  //�ر��������ཻ
            printPoint.Add(10, new List<PointF>()); //����
            //printPoint.Add(11, new List<PointF>()); //����
            printPoint.Add(11, new List<PointF>()); //����
            //printPoint.Add(13, new List<PointF>());//��ʹ����
            this.isChild = false;
            //mainTop = 792 + mainRec.Top; //
            this.pid = _pid;
            this.ToTime = _toTime;
            currPatient = DataInit.GetInpatientInfoByPid(pid);
            //string in_time = "��Ժ_" + Convert.ToDateTime(user["��Ժ����:"]).ToString("24hh:mm");

            InitInOrOutTime();
        }

        /// <summary>
        /// �����ӣ�����Ժ�¼�
        /// </summary>
        private void InitInOrOutTime()
        {
            try
            {

                //string var_time = "";
                //string sql = "insert into t_vital_signs ( " +
                //                    "bed_no," +
                //                    "pid," +
                //                    "measure_time," +
                //                    "temperature_value," +
                //                    "temperature_body," +
                //                    "re_measure," +
                //                    "cooling_value," +
                //                    "pulse_value," +
                //                    "is_briefness," +
                //                    "is_assist_hr," +
                //                    "breath_value," +
                //                    "is_assist_br," +
                //                    "describe," +
                //                    "patient_id" +
                //                    ")values(" +
                //                    "'" + user["����:"].ToString() + "'," +
                //                    "'" + user["סԺ��:"].ToString() + "'," +
                //                    "to_TIMESTAMP('" + user["��Ժ����:"] + "','yyyy-MM-dd hh24:mi')," +
                //                    "'0'," +
                //                    "'0'," +
                //                    "'N'," +
                //                    "'0.0'," +
                //                    "'0'," +
                //                    "'N'," +
                //                    "'N'," +
                //                    "'0'," +
                //                    "'N'," +
                //                    "'" + var_time + "'," + pid + ")";
                ///*
                // *��Ժ�¼��Զ����
                // */
                //DataSet ds = App.GetDataSet("select id from t_vital_signs t where t.patient_id=" + pid + " and  t.describe like '��Ժ%'");
                //if (ds.Tables[0].Rows.Count == 0)
                //{
                //    //��û�м�����Ժ�¼�
                //    string in_time = "��Ժ_" + Convert.ToDateTime(user["��Ժ����:"]).ToString("HH:mm");
                //    DateTime timpepoint = GetTimePoint(Convert.ToDateTime(user["��Ժ����:"].ToString()));
                //    string sql_in = "insert into t_vital_signs ( " +
                //                    "bed_no," +
                //                    "pid," +
                //                    "measure_time," +
                //                    "temperature_value," +
                //                    "temperature_body," +
                //                    "re_measure," +
                //                    "cooling_value," +
                //                    "pulse_value," +
                //                    "is_briefness," +
                //                    "is_assist_hr," +
                //                    "breath_value," +
                //                    "is_assist_br," +
                //                    "describe," +
                //                    "patient_id" +
                //                    ")values(" +
                //                    "'" + user["����:"].ToString() + "'," +
                //                    "'" + user["סԺ��:"].ToString() + "'," +
                //                    "to_TIMESTAMP('" + timpepoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')," +
                //                    "'0'," +
                //                    "'0'," +
                //                    "'N'," +
                //                    "'0.0'," +
                //                    "'0'," +
                //                    "'N'," +
                //                    "'N'," +
                //                    "'0'," +
                //                    "'N'," +
                //                    "'" + in_time + "'," + pid + ")";
                //    App.ExecuteSQL(sql_in);
                //}


                DateTime dtin = Convert.ToDateTime(user["��Ժ����:"]);
                DateTime dtinpoint = GetTimePoint(dtin);
                string describe = string.Empty;
                describe = "��Ժ_" + dtin.ToString("HH:mm");
                //������
                if (currPatient.PId.Contains("_"))
                {
                    dtin = Convert.ToDateTime(currPatient.Birthday);
                    dtinpoint = GetTimePoint(dtin);
                    describe = "����_" + dtin.ToString("HH:mm");
                }
                DataSet ryds = App.GetDataSet("select id from t_vital_signs t where t.patient_id=" + pid + " and  (t.describe like '%��Ժ%' or t.describe like '%����%')");
                if (ryds.Tables[0].Rows.Count == 0)
                {
                    string sql = string.Empty;
                    //sql = "update T_VITAL_SIGNS t set t.describe=substr(t.describe,10) where t.patient_id=" + pid + " and  t.describe like '��Ժ%'";
                    //if (currPatient.PId.Contains("_"))
                    //{
                    //    sql = "update T_VITAL_SIGNS t set t.describe=substr(t.describe,10) where t.patient_id=" + pid + " and  t.describe like '����%'";
                    //}
                    //App.ExecuteSQL(sql);
                    sql = "update T_VITAL_SIGNS t set t.describe='" + describe + "|'||t.describe where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtinpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')";
                    int count = App.ExecuteSQL(sql);
                    if (count == 0)
                    {
                        int id = App.GenId();
                        string sql_in = "insert into T_VITAL_SIGNS (id,measure_time,describe,patient_id,measure_state,temperature_body)values("
                                        + id + ","
                                        + "to_date('" + dtinpoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')"
                                        + ",'" + describe + "'"
                                        + "," + pid + ",'F','0')";
                        App.ExecuteSQL(sql_in);
                    }
                }

                DataSet zrds = App.GetDataSet("select a.happen_time from T_Inhospital_Action a where a.patient_id='" + user["���:"].ToString() + "'  and a.action_type='ת��'");

                if (zrds != null && zrds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < zrds.Tables[0].Rows.Count; i++)
                    {
                        string zr_time = "ת��_" + Convert.ToDateTime(zrds.Tables[0].Rows[i]["happen_time"]).ToString("HH:mm");
                        DateTime dtout = Convert.ToDateTime(zrds.Tables[0].Rows[i]["happen_time"]);
                        DateTime dtoutpoint = GetTimePoint(dtout);
                        string str_zr = App.ReadSqlVal("select count(*) c from T_VITAL_SIGNS t where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')", 0, "c");
                        string zr_sql = string.Empty;
                        if (str_zr == null || str_zr == "0")//!str_zr.Contains("ת��"))
                        {
                            string sql_in = "insert into T_VITAL_SIGNS (id,measure_time,describe,patient_id,measure_state,temperature_body)values("
                                                + App.GenId() + ","
                                                + "to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')"
                                                + ",'" + zr_time + "'"
                                                + "," + pid + ",'F','0')";
                            App.ExecuteSQL(sql_in);
                        }
                        else
                        {
                            str_zr = App.ReadSqlVal("select t.describe from T_VITAL_SIGNS t where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')", 0, "describe");
                            if (str_zr == null || !str_zr.Contains("ת��"))
                            {
                                zr_sql = "update T_VITAL_SIGNS t set t.describe='" + zr_time + "|'||t.describe where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')";
                                App.ExecuteSQL(zr_sql);
                            }
                        }
                    }
                }

                /*
                 * ��Ժ�¼��Զ����
                 */
                DataSet ds = null;
                if (user["��Ժ����:"].ToString() != "")
                {
                    string out_h_time = "��Ժ_" + Convert.ToDateTime(user["��Ժ����:"]).ToString("HH:mm");
                    DateTime dtout = Convert.ToDateTime(user["��Ժ����:"]);
                    DateTime dtoutpoint = GetTimePoint(dtout);
                    //�ò����Ѿ���Ժ
                    ds = App.GetDataSet("select t.id from t_vital_signs t inner join t_in_patient ti on t.patient_id=ti.id where t.patient_id=" + pid + " and (t.describe like '%��Ժ%' or t.describe like '%����%' or (instr(ti.pid,'_')>0 and t.describe like '%ת��%'))");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        //DateTime timepoint = Convert.ToDateTime(user["��Ժ����:"].ToString());
                        ////��Ժ���ǻ�û����ӳ�Ժ�¼�
                        //string sql_out = "insert into t_vital_signs ( " +
                        //           "bed_no," +
                        //           "pid," +
                        //           "measure_time," +
                        //           "temperature_value," +
                        //           "temperature_body," +
                        //           "re_measure," +
                        //           "cooling_value," +
                        //           "pulse_value," +
                        //           "is_briefness," +
                        //           "is_assist_hr," +
                        //           "breath_value," +
                        //           "is_assist_br," +
                        //           "describe," +
                        //           "patient_id" +
                        //           ")values(" +
                        //           "'" + user["����:"].ToString() + "'," +
                        //           "'" + user["סԺ��:"].ToString() + "'," +
                        //           "to_TIMESTAMP('" +timepoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')," +
                        //           "'0'," +
                        //           "'0'," +
                        //           "'N'," +
                        //           "'0.0'," +
                        //           "'0'," +
                        //           "'N'," +
                        //           "'N'," +
                        //           "'0'," +
                        //           "'N'," +
                        //           "'" + out_h_time + "'," + pid + ")";


                        int id = App.GenId();
                        string sql_out = "insert into T_VITAL_SIGNS (id,measure_time,describe,patient_id,measure_state,temperature_body)values("
                                        + id + ","
                                        + "to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')"
                                        + ",'" + out_h_time + "'"
                                        + "," + pid + ",'F','0')";
                        App.ExecuteSQL(sql_out);
                    }
                }
            }
            catch
            { }
        }

        private DateTime GetTimePoint(DateTime dt)
        {
            DateTime dtReturn = dt.Date;
            #region 2,6,10,14,18,22
            if (dt < dt.Date.AddHours(4))
            {
                dtReturn = dtReturn.AddHours(2);
            }
            else if (dt < dt.Date.AddHours(8))
            {
                dtReturn = dtReturn.AddHours(6);
            }
            else if (dt < dt.Date.AddHours(12))
            {
                dtReturn = dtReturn.AddHours(10);
            }
            else if (dt < dt.Date.AddHours(16))
            {
                dtReturn = dtReturn.AddHours(14);
            }
            else if (dt < dt.Date.AddHours(20))
            {
                dtReturn = dtReturn.AddHours(18);
            }
            else
            {
                dtReturn = dtReturn.AddHours(22);
            }
            #endregion

            #region ��ƽ
            //if (dt < dt.Date.AddHours(6))
            //{
            //    dtReturn = dtReturn.AddHours(4);
            //}
            //else if (dt < dt.Date.AddHours(10))
            //{
            //    dtReturn = dtReturn.AddHours(8);
            //}
            //else if (dt < dt.Date.AddHours(14))
            //{
            //    dtReturn = dtReturn.AddHours(12);
            //}
            //else if (dt < dt.Date.AddHours(18))
            //{
            //    dtReturn = dtReturn.AddHours(16);
            //}
            //else if (dt < dt.Date.AddHours(22))
            //{
            //    dtReturn = dtReturn.AddHours(20);
            //}
            //else
            //{
            //    dtReturn = dtReturn.AddHours(23);
            //}
            #endregion
            return dtReturn;
        }

        /// <summary>
        ///��ͨ���µ� ������
        /// </summary>
        /// <param name="_graph">��ͼ�豸</param>
        /// <param name="_startTime">��ʼʱ��</param>
        /// <param name="_endTime">����ʱ��</param>
        /// <param name="_pid">����id</param>
        /// <param name="_toTime">��Ժʱ��</param>
        /// <param name="_isChild">�Ƿ���������</param>
        public void printMain(Graphics _graph, string _startTime, string _endTime)
        {

            string sql = "select t.measure_time,t.describe from T_VITAL_SIGNS t where t.describe like '%����%'   and t.patient_id=" +
                          pid + " order by t.measure_time,t.describe asc";
            ds_operaters = App.GetDataSet(sql);

            this.graph = _graph;
            this.graph.SmoothingMode = SmoothingMode.AntiAlias;
            this.graph.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.startTime = Convert.ToDateTime(_startTime); //��ʼʱ��
            this.endTime = Convert.ToDateTime(_endTime);
            /***
             * ҳü
             */

            printHeader();
            dbList = null;
            dbList = GetTempertureCount(ToTime, startTime.ToString("yyyy-MM-dd"), endTime.ToString("yyyy-MM-dd"), this.pid);
            if (dbList == null)
            {
                App.Msg("���ݿⷱæ���Ժ����ԣ�");
                return;
            }
            printMain();
            /***
             *ҳ��
             */

            printFooter();
        }




        string _bingqu = "";
        public string Bingqu
        {
            get
            {
                return this._bingqu;
            }

            set
            {
                _bingqu = value;
            }
        }

        /// <summary>
        /// �Ƿ���ҳü
        /// </summary>
        bool isNewheader = false;

        /// <summary>
        /// ��ӡҳü
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="graph"></param>
        private void printHeader()
        {
            Font userFont = new Font("����", 10f);
            Font hospitalFont = new Font("����", 16f, FontStyle.Bold);
            Font hospitalFont_EN = new Font("����", 9f, FontStyle.Bold);
            Font hospitalFont_L = new Font("����", 10f);
            Font textFont = new Font("����", 18f, FontStyle.Bold);
            Font titleFont = new Font("����", 15f, FontStyle.Bold);
            Font toptitleFont = new Font("����", 16f);
            Font toptitleFont1 = new Font("����", 12.5f);


            //TimeSpan ts = Convert.ToDateTime(user["��Ժ����:"]).Date - Convert.ToDateTime("2014-10-21");
            //if (ts.Days >= 0)
            //{
            isNewheader = true;
            //}
            //else
            //{
            //    isNewheader = false;
            //}
            if (isNewheader)
            {
                headerRec = new Rectangle(headerRec.Left, -110, headerRec.Width, headerRec.Height);
                int headerspace = 2;
                //graph.DrawString(this.Hospital, hospitalFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace+20, headerRec.Width, headerRec.Height / 3), textFormat);

                graph.DrawString(Bifrost.App.HospitalTittle.Replace("\\r\\n", "\r\n"), toptitleFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace + 20 + headerRec.Height / 4 - 40, headerRec.Width, headerRec.Height / 3), textFormat);
                //graph.DrawString("�� �� �� �� �� �� �� Ժ", toptitleFont1, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace + 20 + headerRec.Height / 4 - 20, headerRec.Width, headerRec.Height / 3), textFormat);
                graph.DrawString("���������µ�", titleFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace + 10 + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                //Image img=Resource.BookHead;
                //graph.DrawImage(img, new RectangleF(headerRec.Left+(headerRec.Width-198)/2, headerRec.Top - headerspace, 198, 52));
                string datestr = Convert.ToDateTime(user["��Ժ����:"]).ToString("yyyy-MM-dd");
                user["��Ժ����:"] = datestr;
                //string[] headlist = new string[] { "����", "��Ժ����", "���", "����", "����", "סԺ��" };
                string[] headlist = new string[] { "�ǼǺ�", "����", "����", "�Ա�", "����", "����", "��Ժ����", "סԺ��" };
                #region ע��

                //for (int i = 0; i < headlist.Length; i++)
                //{
                //    //�ǼǺ�
                //    //if (i == 0)
                //    //{
                //    //    string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                //    //    graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300,//300 ͬסԺ��
                //    //        headerRec.Top - headerspace + 20 + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                //    //}
                //    if (i == 4)//����
                //    {
                //        string inch = App.ReadSqlVal("select in_bed_no from t_in_patient where id='" + user["���:"] + "'", 0, "in_bed_no");
                //        string dqch = getch(inch);
                //        string ch = user[headlist[4] + ":"];
                //        if (dqch != "")
                //        {
                //            ucTempratureEdit ucTE = new ucTempratureEdit();
                //            SizeF chW = ucTE.graphics.MeasureString("����:", nineFont);
                //            SizeF ochW = ucTE.graphics.MeasureString(inch, nineFont);
                //            SizeF nchW = ucTE.graphics.MeasureString(dqch, nineFont);
                //            string itemtext = headlist[4] + ":" + inch;
                //            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 505, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //            itemtext = "��";
                //            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 505 + chW.Width + (ochW.Width / 2) - 8, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 12);
                //            itemtext = dqch;
                //            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 505 + chW.Width + (ochW.Width / 2) - (nchW.Width / 2) - 2, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                //        }
                //        else
                //        {
                //            string itemtext = headlist[4] + ":" + inch;
                //            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 505, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        }
                //    }
                //    else if (i == 0)//����
                //    {
                //        string itemtext = headlist[0] + ":" + user[headlist[0] + ":"];
                //        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left - 20, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    }
                //    //else if (i == 3)//�Ա�
                //    //{
                //    //    string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                //    //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    //}
                //    //else if (i == 4)//����
                //    //{
                //    //    string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                //    //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    //}
                //    else if (i == 1)//��Ժ����
                //    {
                //        string itemtext = headlist[1] + ":" + user[headlist[1] + ":"];
                //        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * 5 - 5, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    }
                //    else if (i == 3)//����
                //    {
                //        string oldsection = App.ReadSqlVal("select b.section_name from T_Inhospital_Action a inner join t_sectioninfo b on a.sid=b.sid where a.patient_id='" + user["���:"] + "' and a.action_type='����' order by a.happen_time", 0, "section_name");
                //        ////string oldsection = user["����:"];
                //        //string newsection = getnewsection(oldsection);
                //        ////if (itemtext.Length > 11)
                //        ////{
                //        ////    itemtext = itemtext.Remove(itemtext.Length - 2);
                //        ////}
                //        //if (newsection != "")
                //        //{
                //        //    ucTempratureEdit ucTE = new ucTempratureEdit();
                //        //    SizeF chW = ucTE.graphics.MeasureString("����:", nineFont);
                //        //    SizeF ochW = ucTE.graphics.MeasureString(oldsection, nineFont);
                //        //    SizeF nchW = ucTE.graphics.MeasureString(newsection, nineFont);
                //        //    string itemtext = "����:" + oldsection;
                //        //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        //    itemtext = "��";
                //        //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390 + chW.Width + ochW.Width / 2 - 8, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 12);
                //        //    itemtext = newsection;
                //        //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390 + chW.Width + ochW.Width / 2 - nchW.Width / 2, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                //        //}
                //        //else
                //        //{
                //            string itemtext = "����" + ":" + oldsection;
                //            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390,
                //                headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        //}
                //    }
                //    else if (i == 5)//סԺ��
                //    {
                //        string itemtext = "������" + ":" + user[headlist[5] + ":"];
                //        //this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + -5+ gridColsWidth * (6 * i - 1), 
                //        //headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 320,
                //            headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 13,
                //            headerRec.Width, headerRec.Height / 3), textFormat);
                //    }
                //    else if (i == 2)//���
                //    {
                //        string ruzd = getzd(user["סԺ��:"], this.pageIndex);
                //        //string qrzd = getqrzd(user["���:"]);
                //        //int height = 14;
                //        //int qrheight = 18;
                //        //if (qrzd.Length > 0 && ruzd != qrzd)
                //        //{
                //        //    ucTempratureEdit ucTE = new ucTempratureEdit();
                //        //    SizeF chW = ucTE.graphics.MeasureString("���:", nineFont);
                //        //    SizeF ochW = ucTE.graphics.MeasureString(ruzd, nineFont);
                //        //    SizeF nchW = ucTE.graphics.MeasureString(qrzd, nineFont);
                //        //    this.graph.DrawString("���:", userFont, brush, headerRec.Left + 205, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        //    this.graph.DrawString(ruzd, userFont, brush, new RectangleF(headerRec.Left + 235,
                //        //    headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 13,
                //        //    headerRec.Width - 500, headerRec.Height / 3), textFormat);
                //        //    if (ruzd.Length > 11)
                //        //    {
                //        //        height = 21;
                //        //    }
                //        //    this.graph.DrawString("��", userFont, brush, headerRec.Left + 306, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - height);
                //        //    if (height == 21)
                //        //    {
                //        //        qrheight = 28;
                //        //    }
                //        //    else if (qrzd.Length > 11)
                //        //    {
                //        //        qrheight = 21;
                //        //    }
                //        //    this.graph.DrawString(qrzd, userFont, brush, new RectangleF(headerRec.Left + 235,
                //        //    headerRec.Top - headerspace + headerRec.Height / 6 * 3 - qrheight,
                //        //    headerRec.Width - 500, headerRec.Height / 3), textFormat);
                //        //}
                //        //else
                //        //{
                //            this.graph.DrawString("���:", userFont, brush, headerRec.Left + 205, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //            this.graph.DrawString(ruzd, userFont, brush, new RectangleF(headerRec.Left + 235,
                //            headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 13,
                //            headerRec.Width - 500, headerRec.Height / 3), textFormat);
                //        //}
                //    }
                //}
                #endregion
                for (int i = 0; i < headlist.Length; i++)
                {
                    string itemtext = "";
                    if (i == 0)
                    {//"�ǼǺ�",
                        //string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        //graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300,//300 ͬסԺ��
                        //headerRec.Top - headerspace + 20 + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                    }
                    else if (i == 1)
                    {//����
                        itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6), headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }
                    else if (i == 2)
                    {//����
                        //�Ӱ��и��ױ���Ժ��ҳü�������⴦��
                        if (headlist[i] == "����" && (user[headlist[i] + ":"].Contains("��") && user[headlist[i] + ":"].Contains("��") || user[headlist[i] + ":"].Contains("��") && user[headlist[i] + ":"].Contains("��")))
                        {
                            string age_1 = "����:";          //���䣺����
                            string age_2 = "";               //����          
                            string age_3 = "";               //��ĸ
                            string age_4 = "";               //��λ

                            if (user[headlist[i] + ":"].Contains("��"))
                            {
                                string[] age = user[headlist[i] + ":"].Split('��');
                                age_1 += age[0];
                                age_2 = age[1].Split('��')[0];
                                age_3 = "12";
                                age_4 = "��";
                            }
                            else
                            {
                                string[] age = user[headlist[i] + ":"].Split('��');
                                age_1 += age[0];
                                age_2 = age[1].Split('��')[0];
                                age_3 = "30";
                                age_4 = "��";
                            }
                          
                            //���䣺����
                            this.graph.DrawString(age_1, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                            //����
                            if (age_2.Length == 1)//һλ����λ��ʾ˳Ѱ
                                this.graph.DrawString(age_2, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 45, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25 - 8);
                            else
                                this.graph.DrawString(age_2, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 42, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25 - 8);
                            //������
                            this.graph.DrawLine(blackPen, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 44, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 19, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 60, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 19);
                            //��ĸ
                            this.graph.DrawString(age_3, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30+42, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25+7);
                            //��λ
                            this.graph.DrawString(age_4, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30+58, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                        }
                        else
                        {
                            itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                        }
                    }
                    else if (i == 3)
                    {//�Ա�
                        itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6) + 5, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }
                    else if (i == 4)
                    {//����
                        string oldsection = App.ReadSqlVal("select INSECTION_NAME from t_in_patient where id='" + user["���:"] + "'", 0, "INSECTION_NAME");

                        string newsection = getnewsection(oldsection);
                        if (newsection != "")
                        {
                            itemtext = "����:" + newsection;
                        }
                        else
                        {
                            itemtext = "����" + ":" + oldsection;
                        }

                        //string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        //if (itemtext.Length > 11)
                        //{
                        //    itemtext = itemtext.Remove(itemtext.Length - 2);
                        //}
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }
                    else if (i == 5)
                    {//����
                        string inch = App.ReadSqlVal("select in_bed_no from t_in_patient where id='" + user["���:"] + "'", 0, "in_bed_no");
                        string dqch = getch(inch);
                        string ch = user[headlist[i] + ":"];
                        if (dqch != "")
                        {
                            itemtext = headlist[i] + ":" + dqch;
                        }
                        else
                        {
                            itemtext = headlist[i] + ":" + inch;
                        }
                        //string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }
                    else if (i == 6)
                    {//��Ժ����
                        itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 35, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }

                    else if (i == 7)
                    {//סԺ��
                        itemtext = "סԺ��:" + user[headlist[i] + ":"];
                        //graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                        graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300, headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 14 - 25, headerRec.Width, headerRec.Height / 3), textFormat);
                    }
                }
            }
            else
            {
                #region �ϰ�������    
                int headerspace = 2;
                graph.DrawString(this.Hospital, hospitalFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace, headerRec.Width, headerRec.Height / 3), textFormat);
                graph.DrawString("�� �� ��", titleFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                string datestr = Convert.ToDateTime(user["��Ժ����:"]).ToString("yyyy-MM-dd");
                //string[] headlist = new string[] { "�Ʊ�", "����", "�Ա�", "����", "סԺ��", "����", "���" };
                string[] headlist = new string[] { "����", "����", "�Ա�", "����", "��Ժ����", "����", "סԺ��" };
                for (int i = 0; i < headlist.Length; i++)
                {
                    if (i == 0)
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300,
                            headerRec.Top - headerspace + 20 + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                        //    string itemtext = headlist[i] + ":" + user[headlist[i]+ ":"];
                        //    this.graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 100 + gridColsWidth * (6 * i + 6),
                        //        headerRec.Top - headerspace + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3));
                    }
                    else if (i == 6)
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 440,
                            headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                    }
                    else if (i == 1)
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6), headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                    }
                    else if (i == 2)
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 10 + gridColsWidth * (6 * i - 8), headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                    }
                    else if (i == 3)
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                    }
                    else if (i == 4)
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                    }
                    else if (i == 5)
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                    }
                    else
                    {
                        string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        //this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + -5 + gridColsWidth * (6 * i - 1), headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                        graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300,
                                         headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 15,
                                         headerRec.Width, headerRec.Height / 3), textFormat);
                    }
                }
                #endregion
            }
            userFont.Dispose();
            hospitalFont.Dispose();
            textFont.Dispose();
        }

        /// <summary>
        /// ��ӡҳ��
        /// </summary>
        private void printFooter()
        {
            //�� {0} ��(ҳ)
            graph.DrawString(string.Format("�� {0} ҳ", this.pageIndex), new Font("����", 12), brush, 330, 1004);//1044
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="size"></param>
        /// <param name="isBold"></param>
        private Font getFont(string fontName, int size, FontStyle fontStyle)
        {
            return new Font(fontName, size, fontStyle);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="size">�����С</param>        
        private Font getFont(string fontName, float size)
        {
            return new Font(fontName, size);
        }

        /// <summary>
        /// ���ö�������
        /// </summary>
        /// <param name="alignment"></param>
        /// <param name="linAlignment"></param>
        /// <param name="trimming"></param>
        private void setFormat(StringAlignment alignment, StringAlignment linAlignment, StringTrimming trimming)
        {
            this.textFormat.Alignment = alignment;
            this.textFormat.LineAlignment = linAlignment;
            this.textFormat.Trimming = trimming;
        }

        /// <summary>
        /// ���µ�
        /// </summary>
        public void printMain()
        {
            int mainheight = topRows * topRowSpace + gridRows * gridRowsSpace + rHeight + bottomRows * bottomRosSpace;
            int mainwidth = 100 + gridCols * gridColsWidth;
            if (isNewheader)
            {
                mainRec = new Rectangle(40, 49, mainwidth, mainheight);
            }
            else
            {
                mainRec = new Rectangle(40, 49, mainwidth, mainheight);
            }
            printGrid();
            printLine();
            printString();
            //px = 0;
            //py = 0;



            printTime();
            printData();
            printPoints();
            dbList.Clear();
        }



        /// <summary>
        /// ��ͨ���µ����
        /// </summary>
        private void printGrid()
        {
            int leftwidth = 100;
            for (int i = 0; i < 42; i++)  //����
            {
                if (i % 6 == 0)
                {
                    blackPen.Width = 2f;
                    graph.DrawLine(blackPen, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top-14, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + 250 + rHeight);//25һ��
                    blackPen.Width = 1f;
                }
                else
                {
                    graph.DrawLine(blackPen, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top + (topRows - 1) * topRowSpace-14, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight);
                    //��Ѫѹ�м�ָ���
                    //if ((i - 3) % 6 == 0)
                    //{
                    //    graph.DrawLine(blackPen, mainRec.Left + leftwidth + i * hourWidth,
                    //    mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + bottomRosSpace * 4 - 10 - 50,
                    //    mainRec.Left + leftwidth + i * hourWidth,
                    //    mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + bottomRosSpace * 5 - 10 - 110);
                    //}
                }
            }
            mainTop = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace;
            for (int i = 1; i < gridRows; i++)  //����
            {                
                if (i % 5 == 0)
                {
                    blackPen.Width = 2f;
                    graph.DrawLine(blackPen, mainRec.Left + leftwidth, mainRec.Top + topRows * topRowSpace + i * gridRowsSpace, mainRec.Right, mainRec.Top + topRows * topRowSpace + i * gridRowsSpace);
                    blackPen.Width = 1f;
                }
                else
                {
                    graph.DrawLine(blackPen, mainRec.Left + leftwidth, mainRec.Top + topRows * topRowSpace + i * gridRowsSpace, mainRec.Right, mainRec.Top + topRows * topRowSpace + i * gridRowsSpace);
                }
                             
            }
        }

        /// <summary>
        /// ���ݵ�ǰX���귵��ָ��������
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public DateTime GetSelectDay(int x)
        {
            for (int i = 1; i <= 7; i++)
            {
                int objWidth = 40;
                if (x >= mainRec.Left + 100 + objWidth + (i - 1) * 6 * gridColsWidth && x < mainRec.Left + objWidth + 100 + i * 6 * gridColsWidth)
                {
                    return startTime.AddDays(i - 1);
                }
            }
            return App.GetSystemTime();
        }

        /// <summary>
        /// ��ͨ���µ�����
        /// </summary>
        private void printString()
        {
            //�м�� 18 

            //string[] strTemper = new string[] { "42","41", "40", "39", "38", "37", "36", "35" };
            //string[] strPulse = new string[] { "180", "160", "140", "120", "100", "80", "60", "40" };

            string[] strTemper = new string[] {"41", "40", "39", "38", "37", "36", "35" };
            string[] strPulse = new string[] {"160", "140", "120", "100", "80", "60", "40" };
            //string[] strRespire = new string[] { "50", "40", "30", "20", "10" };
            string[] strPainScore = new string[] { "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };
            string[] strTopCaption = new string[] { "��    ��", "סԺ����", "����/��������", "ʱ    ��" };
            for (int i = 0; i < topRows; i++)
            {
                //if (i == 2)
                //    this.graph.DrawString(strTopCaption[i], nineFont, brush, new RectangleF(mainRec.Left-4, mainRec.Top + i * topRowSpace - 14 + 2, 110, topRowSpace), textFormat);
                //else
                    this.graph.DrawString(strTopCaption[i], nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + i * topRowSpace - 14 + 2, 100, topRowSpace), textFormat);
            }
            //this.graph.DrawString("��\n��\n��/��", nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + topRows * topRowSpace, 33, 5*gridRowsSpace), textFormat);
            this.graph.DrawString("����", nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + topRows * topRowSpace-12, 50, 14), textFormat);
            this.graph.DrawString("(��/��)", nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + topRows * topRowSpace, 50, 2* gridRowsSpace), textFormat);
            this.graph.DrawString("180", tenFont, brush, new RectangleF(mainRec.Left+20, mainRec.Top + topRows * topRowSpace+20, 30, gridRowsSpace), textFormat);
            //this.graph.DrawString("��\n��\n��/��", nineFont, brush, new RectangleF(mainRec.Left + 20, mainRec.Top + topRows * topRowSpace, 35, 5 * gridRowsSpace), textFormat);����\n
            this.graph.DrawString("����", nineFont, brush, new RectangleF(mainRec.Left + 55, mainRec.Top + topRows * topRowSpace-12, 50, 14), textFormat);
            this.graph.DrawString("(��C)", nineFont, brush, new RectangleF(mainRec.Left + 55, mainRec.Top + topRows * topRowSpace, 50, 2 * gridRowsSpace), textFormat);
            this.graph.DrawString("42", tenFont, brush, new RectangleF(mainRec.Left + 65, mainRec.Top + topRows * topRowSpace+20, 20,gridRowsSpace), textFormat);
            //this.graph.DrawString("��\nʹ\n��\n��", nineFont, brush, new RectangleF(mainRec.Left + 65, mainRec.Top + topRows * topRowSpace + 40 * gridRowsSpace, 20, 10 * gridRowsSpace), textFormat);


            int timeY = mainRec.Top + 58;
            //ʱ��̶�
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int timepoit = 0;
                    timepoit = j * 4 + 2;
                    if (timepoit == 2 || timepoit == 18 || timepoit == 22)
                        //2,18,22����
                        this.graph.DrawString(timepoit.ToString(), eightFont, redBrush, new RectangleF(mainRec.Left + 100 + i * 6 * gridColsWidth + j * gridColsWidth - 1, mainRec.Top + 3 * topRowSpace-14, gridColsWidth + 2, topRowSpace), textFormat);
                    else
                        this.graph.DrawString(timepoit.ToString(), eightFont, brush, new RectangleF(mainRec.Left + 100 + i * 6 * gridColsWidth + j * gridColsWidth - 1, mainRec.Top + 3 * topRowSpace-14, gridColsWidth + 2, topRowSpace), textFormat);

                }
            }

            /*
             * ����
             */
            int strArrTop = mainRec.Top + topRows * topRowSpace + 5 * gridRowsSpace + gridRowsSpace / 2;        
            for (int i = 0; i < strTemper.Length; i++) //strTemper.Length
            {
                this.graph.DrawString(strTemper[i], tenFont, brush, new RectangleF(mainRec.Left + 65, strArrTop - 5, 20, gridRowsSpace), textFormat);
                strArrTop = strArrTop + 5 * gridRowsSpace;
            }

            /*
             * ����
             */
            //strArrTop = mainRec.Top + topRows * topRowSpace + 9 * gridRowsSpace +gridRowsSpace / 2;
            strArrTop = mainRec.Top + topRows * topRowSpace + 5 * gridRowsSpace + gridRowsSpace / 2;          
            for (int i = 0; i < strPulse.Length; i++)
            {
                this.graph.DrawString(strPulse[i], tenFont, brush, new RectangleF(mainRec.Left + 20, strArrTop - 5, 30, gridRowsSpace), textFormat);
                strArrTop = strArrTop + 5 * gridRowsSpace;
            }

            //����
            //strArrTop = mainRec.Top + topRows * topRowSpace + 29 * gridRowsSpace + gridRowsSpace / 2;
            //for (int i = 0; i < strRespire.Length; i++)
            //{
            //    if (i == strRespire.Length - 1)
            //    {
            //        this.graph.DrawString(strRespire[i], tenFont, brush, new RectangleF(mainRec.Left, strArrTop - gridRowsSpace / 2, 30, gridRowsSpace), textFormat);
            //    }
            //    else
            //    {
            //        this.graph.DrawString(strRespire[i], tenFont, brush, new RectangleF(mainRec.Left, strArrTop, 30, gridRowsSpace), textFormat);
            //        strArrTop = strArrTop + 5 * gridRowsSpace;
            //    }
            //}

            //��ʹ����
            //strArrTop = mainRec.Top + topRows * topRowSpace + 39 * gridRowsSpace + gridRowsSpace / 2;
            //for (int i = 0; i < strPainScore.Length; i++)
            //{
            //    this.graph.DrawString(strPainScore[i], nineFont, brush, new RectangleF(mainRec.Left + 100 - gridColsWidth-1, strArrTop, gridColsWidth+2, gridRowsSpace), textFormat);
            //    strArrTop = strArrTop + gridRowsSpace;
            //}
            //DataTable tempers = dbList[0];
            //string PainMothed = "��ʹ����";
            //for (int i = 0; i < tempers.Rows.Count; i++)
            //{
            //    if (tempers.Rows[i]["PAIN_MOTHED"].ToString() != "")
            //    {
            //        PainMothed =PainMothed+"("+tempers.Rows[i]["PAIN_MOTHED"].ToString()+")";
            //        break;
            //    }
            //}


            strArrTop = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace;
            ///�Զ�����
            this.graph.DrawString("����(��/��)", nineFont, brush, new RectangleF(mainRec.Left, strArrTop, 100, rHeight), textFormat);
            strArrTop += rHeight;
            //user[headlist[i]  ��Һ��  ��Һ��  
            string[] strBottomCaption;
            //if (user["����:"].ToString() == "���ƻ���Ԫ" || user["����:"].ToString() == "����")
            //{
            //    strBottomCaption = new string[] { "��  ��(��)", "��  ��(ml)", "������(ml)", "�ܳ���(ml)",  "Ѫѹ(mmHg)","��  ��(kg)",
            //                            "Ѫ��(mmol/L)", strRowCaption1, strRowCaption2, strRowCaption3, strRowCaption4, strRowCaption5};
            //}
            //else
            //{
            //    string strRowCaption6 = "";
            //    strBottomCaption = new string[] { "��  ��(��)", "��  ��(ml)", "������(ml)", "�ܳ���(ml)",  "Ѫѹ(mmHg)","��  ��(kg)",
            //                             strRowCaption1, strRowCaption2, strRowCaption3, strRowCaption4, strRowCaption5,strRowCaption6};
            //}
            strBottomCaption = new string[] { "Һ����","������", 
                                              "����", 
                                              "Ż��",  
                                              "��״",
                                              "����", 
                                              "��  ��(kg)",
                                              "ͷ  Χ(cm)","��  ��(cm)","��  Χ(cm)","ע������ ���ú���԰��������ֱ������������ ϡ��� �������� ŧѪ��� ̥���",""};
            this.graph.DrawString("����(ml)", nineFont, brush, new RectangleF(mainRec.Left, strArrTop, 50, bottomRosSpace*2), textFormat);
            this.graph.DrawString("����(ml)", nineFont, brush, new RectangleF(mainRec.Left, strArrTop + bottomRosSpace * 2, 50, bottomRosSpace * 2), textFormat);
            this.graph.DrawString("���", nineFont, brush, new RectangleF(mainRec.Left, strArrTop + bottomRosSpace * 4, 50, bottomRosSpace * 2), textFormat);
            for (int i = 0; i < strBottomCaption.Length; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5)
                {
                    this.graph.DrawString(strBottomCaption[i], nineFont, brush, new RectangleF(mainRec.Left+50, strArrTop, 50, bottomRosSpace), textFormat);
                }
                else if(i==10)//��ע�� ȫ����ʾ
                {
                    //StringFormat textFormat_BZ = textFormat;
                    textFormat.Alignment = StringAlignment.Near;
                    this.graph.DrawString(strBottomCaption[i], nineFont, brush, new RectangleF(mainRec.Left, strArrTop, 100 + gridCols * gridColsWidth, bottomRosSpace), textFormat);
                    textFormat.Alignment = StringAlignment.Center;
                 
                }else{
                this.graph.DrawString(strBottomCaption[i], nineFont, brush, new RectangleF(mainRec.Left, strArrTop, 100, bottomRosSpace), textFormat);
                }
                
                strArrTop += bottomRosSpace;
            }
        }

        /// <summary>
        /// ��ͨ���µ�������
        /// </summary>
        private void printLine()
        {
            
            #region ������
            int topspace = 20;            
            int topcount = 4;//ʱ�������ϵĺ���
            for (int i = 0; i <= topcount; i++)
            {
                if (i == 0)
                {        
                    blackPen.Width = 2f;
                    this.graph.DrawLine(blackPen, mainRec.Left, mainRec.Top + i * topspace-14, mainRec.Right, mainRec.Top + i * topspace-14);
                    blackPen.Width = 1f;
                }                
                this.graph.DrawLine(blackPen, mainRec.Left, mainRec.Top + i * topspace-14, mainRec.Right, mainRec.Top + i * topspace-14);
            }

            blackPen.Width = 2f;
            this.graph.DrawLine(blackPen, mainRec.Left+100, mainRec.Top + 4 * topspace, mainRec.Right, mainRec.Top + 4 * topspace);
            blackPen.Width = 1f;
            this.graph.DrawLine(blackPen, mainRec.Left, mainRec.Top + 4 * topspace, mainRec.Left+100, mainRec.Top + 4 * topspace);

            ///�����ж���
            ///�Ӵ�
            blackPen.Width = 2f;
            this.graph.DrawLine(blackPen, mainRec.Left, mainTop, mainRec.Right, mainTop);
            blackPen.Width = 1f;

            int bottomspace = 25;//�и�
            int bottomcount = 11;//�����·�������
            for (int i = 0; i <= bottomcount; i++)
            {
                if (i == 1||i==3||i==5)
                    this.graph.DrawLine(blackPen, mainRec.Left + 55, mainTop + rHeight + (bottomspace * i), mainRec.Right, mainTop + rHeight + (bottomspace * i));
                else
                {
                    //this.graph.DrawLine(blackPen, mainRec.Left, mainTop + rHeight + (bottomspace * i), mainRec.Right, mainTop + rHeight + (bottomspace * i));
                    if (i == bottomcount)
                        blackPen.Width = 2f;
                    this.graph.DrawLine(blackPen, mainRec.Left, mainTop + rHeight + (bottomspace * i), mainRec.Right, mainTop + rHeight + (bottomspace * i));
                    blackPen.Width = 1f;
                }
            }
            #endregion

            #region ������

            //���µ�����
            this.graph.DrawLine(blackPen, mainRec.Left, mainRec.Top + topRows * topRowSpace-14, mainRec.Left, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace);
            //���������м�ָ���
            this.graph.DrawLine(blackPen, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace-14, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace);
            //�Ӱ����������� ��������������м�ָ���
            this.graph.DrawLine(blackPen, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight+150);

            blackPen.Width = 2f;
            ///�������
            this.graph.DrawLine(blackPen, mainRec.Left, mainRec.Top-14, mainRec.Left, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + bottomspace * bottomcount+rHeight);//30һ��
            ///���ұ���
            this.graph.DrawLine(blackPen, mainRec.Right, mainRec.Top-14, mainRec.Right, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + bottomspace * bottomcount + rHeight);//30һ��
            blackPen.Width = 1f;


            #endregion
        }

        /// <summary>
        /// ��ͨ���µ�����
        /// </summary>
        private void printData()
        {
            printTempers(); //��������
            printOther();   //������Ϣ
        }


        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="mesurtime"></param>
        /// <returns></returns>
        private string OpreaterTimes(string mesurtime)
        {
            try
            {
                //int index = 0;               
                //dbList[0].DefaultView.Sort = "measure_time ASC";
                //for (int i = 1; i <= dbList[0].Rows.Count; i++)
                //{
                //    if (dbList[0].Rows[i - 1]["describe"].ToString()!="")
                //    {
                //        if (dbList[0].Rows[i - 1]["describe"].ToString().Contains("����"))
                //        {
                //            index = index + 1; 
                //            if (mesurtime == dbList[0].Rows[i - 1]["measure_time"].ToString())
                //            {
                //                break;                               
                //            }
                //        }
                //    }
                //}


                int index = 0;
                for (int i = 0; i < ds_operaters.Tables[0].Rows.Count; i++)
                {
                    if (mesurtime == ds_operaters.Tables[0].Rows[i]["measure_time"].ToString())
                    {
                        index = i + 1;
                    }
                }

                if (index > 1)
                    return index.ToString();
                else
                    return "";

            }
            catch
            { return ""; }
        }

        /// <summary>
        /// ��ͨ���µ���������
        /// </summary>
        private void printTempers()
        {
            DataTable tempers = dbList[0];             //������������
            float eventOld = 0;
            float evertx = 0;
            string str = GetLastEvent();
            CutPoints.Clear();

            if (str != "")
            {
                evertx = mainRec.Left + 105;
                str = str.Substring(0, str.Length - 1);
                foreach (string var in str.Split('|'))
                {
                    DrawEvent(evertx, var);
                    evertx += hourWidth;
                }
            }

            bool pbstartflag = false;
            bool pbendflag = false;
            if (tempers.Rows.Count > 0)
            {
                float timeX = 0;    //X����
                float TY = 0;   //����Y
                float PY = 0;   //����Y
                float HY = 0;   //����Y
                float BY = 0;   //����Y
                float PainY = 0;   //��ʹ����Y

                float oldTX = 0;//����X
                float oldTY = 0;//����Y
                float oldPX = 0;//����X
                float oldPY = 0;//����Y
                float oldHX = 0;//����X
                float oldHY = 0;//����Y
                float oldBX = 0;//����X
                float oldBY = 0;//����Y
                float oldPainX = 0;//��ʹ����X
                float oldPainY = 0;//��ʹ����Y
                string measureState = string.Empty; //���²�������   

                List<PointF> pulse = new List<PointF>();  //�����̴�
                List<PointF> heart = new List<PointF>();  //���ʶ̴�
                TimeSpan begin = new TimeSpan(this.startTime.Ticks);

                int heart_count = 0; //���ʵĸ���
                int heart_index = 0; //���ʵ�����

                //bool iscut = false;
                for (int i = 0; i < tempers.Rows.Count; i++)
                {
                    DataRow currentRow = tempers.Rows[i];
                    if (currentRow["heart_rhythm"].ToString() != "")
                    {
                        if (Convert.ToInt32(currentRow["heart_rhythm"].ToString()) >= 20)
                            heart_count++;
                    }
                }


                List<int> pb_indexs = new List<int>();

                for (int i = 0; i < tempers.Rows.Count; i++)
                {
                    DataRow currentRow = tempers.Rows[i]; //��ǰѭ����
                    DateTime rowTime = Convert.ToDateTime(currentRow["measure_time"].ToString());//��ǰ��¼ʱ��
                    measureState = currentRow["measure_state"].ToString(); //��ǰ��¼�������
                    string describe = currentRow["describe"].ToString();
                    /***
                     * �����ǰ��¼�е�״̬Ϊ�Ѳ�
                     */
                    TimeSpan end = new TimeSpan(rowTime.Ticks);
                    TimeSpan beginToEnd = begin.Subtract(end).Duration();
                    timeX = getX(beginToEnd.Days, rowTime.Hour);       //X����

                    if (measureState != "R")
                    {
                        float temperValue = 0;
                        float coolValue = 0;
                        int pulseValue = 0;
                        int heartValue = 0;
                        int breathValue = 0;
                        int painValue = 0;

                        string temperString = currentRow["temperature_value"].ToString();
                        string coolString = currentRow["cooling_value"].ToString();
                        string pulseString = currentRow["pulse_value"].ToString();
                        string heartString = currentRow["heart_rhythm"].ToString();
                        string breathString = currentRow["breath_value"].ToString();
                        string painString = currentRow["PAIN_VALUE"].ToString();
                        string reMeasure = currentRow["re_measure"].ToString();
                        string reHeartMesure = currentRow["is_assist_hr"].ToString();

                        string strss = "";
                        if (temperString != "")
                        {
                            float.TryParse(temperString, out temperValue);       //����
                        }
                        if (coolString != "")
                        {
                            float.TryParse(coolString, out coolValue);     //���º�����
                        }
                        if (pulseString != "")
                        {
                            int.TryParse(pulseString, out pulseValue);     //����
                        }
                        if (heartString != "")
                        {
                            int.TryParse(heartString, out heartValue);     //����
                        }
                        if (breathString != "")
                        {
                            int.TryParse(breathString, out breathValue);   //����                        
                        }
                        else
                        {
                            breathValue = -1;
                        }
                        if (painString != "")
                        {
                            int.TryParse(painString, out painValue);       //����                        
                        }

                        /*
                         *���� ���� �̴� ��ӡ
                         */
                        #region  ���� ���� �̴�
                        if (pulseValue >= 20) //����y����
                        {

                            //PY = (((180 - (float)pulseValue)) / 4 + 1) * (hourWidth - 2) + mainRec.Top + 63 + 268;
                            PY = ((180 - (float)pulseValue)) / 4 * gridRowsSpace + mainRec.Top + topRows * topRowSpace;
                            if (i > 0)
                            {
                                //float temperFront = 0;//������һ������

                                //if (tempers.Rows[i - 1]["temperature_value"] != null)
                                //{
                                //    if (tempers.Rows[i - 1]["temperature_value"].ToString() != "")
                                //    {

                                //        temperFront = float.Parse(tempers.Rows[i - 1]["temperature_value"].ToString()); //��һ������
                                //    }
                                //}
                                for (int m = 1; m <= i; m++)
                                {//�ж���һ����¼�Ƿ��в����ߵ��¼�
                                    if (tempers.Rows[i - m]["measure_state"] != null)
                                    {
                                        if (tempers.Rows[i - m]["measure_state"].ToString() != "" && tempers.Rows[i - m]["measure_state"].ToString() != "R")
                                        {
                                            float pulse_value = 0;//������һ������
                                            if (tempers.Rows[i - m]["pulse_value"].ToString() != "")
                                            {
                                                pulse_value = float.Parse(tempers.Rows[i - m]["pulse_value"].ToString());
                                            }
                                            if (pulse_value >= 20 || tempers.Rows[i - m]["measure_state"].ToString() != "F")
                                            {//�������ڵ���20�����¼���ΪFʱ��
                                                strss = tempers.Rows[i - m]["measure_state"].ToString();
                                                break;
                                            }
                                            string strsj = tempers.Rows[i - m]["describe"].ToString();
                                            if (pulse_value <= 20 && (strsj.Contains("����") || strsj.Contains("����")))
                                            {
                                                oldPX = 0;
                                                oldPY = 0;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            string strsj = tempers.Rows[i - m]["describe"].ToString();
                                            float pulse_value = 0;//����Ϊ�ն����������������ʱ�򣬲�����
                                            if (tempers.Rows[i - m]["pulse_value"].ToString() != "")
                                            {
                                                pulse_value = float.Parse(tempers.Rows[i - m]["pulse_value"].ToString());
                                            }
                                            if (pulse_value <= 20 && (strsj.Contains("����") || strsj.Contains("����")))
                                            {
                                                oldPX = 0;
                                                oldPY = 0;
                                                break;
                                            }
                                        }
                                    }
                                }
                                strss = strss + measureState;
                                if (strss.Substring(0, 1).Contains("F"))
                                {//��ȡǰһ��״̬ΪFʱ��ӡֱ��
                                    //if (temperFront > 35 || temperFront == 0)
                                    //{
                                    printPulseLine(timeX, PY, oldPX, oldPY, pulseValue.ToString()); //��ӡֱ��
                                    //}
                                }
                            }
                            this.printPoint[4].Add(new PointF(timeX, PY));
                        }
                        if (heartValue >= 20)  //����
                        {
                            HY = ((180 - (float)heartValue)) / 4 * gridRowsSpace + mainRec.Top + topRows * topRowSpace;
                            //HY = (((180 - (float)heartValue)) / 4 + 1) * (hourWidth - 2) + mainRec.Top + 63 + 268; //����y����                            
                            if (i > 0)
                            {
                                for (int m = 1; m <= i; m++)
                                {
                                    if (tempers.Rows[i - m]["measure_state"] != null)
                                    {
                                        if (tempers.Rows[i - m]["measure_state"].ToString() != "" && tempers.Rows[i - m]["measure_state"].ToString() != "R")
                                        {
                                            float heart_rhythm = 0;//������һ������
                                            if (tempers.Rows[i - m]["heart_rhythm"].ToString() != "")
                                            {
                                                heart_rhythm = float.Parse(tempers.Rows[i - m]["heart_rhythm"].ToString());
                                            }
                                            if (heart_rhythm >= 20 || tempers.Rows[i - m]["measure_state"].ToString() != "F")
                                            {//���ʴ��ڵ���20�����¼���ΪFʱ��
                                                strss = tempers.Rows[i - m]["measure_state"].ToString();
                                                break;
                                            }

                                            string strsj = tempers.Rows[i - m]["describe"].ToString();
                                            if (strsj.Contains("����") || strsj.Contains("����"))
                                            {
                                                oldHX = 0;
                                                oldHY = 0;
                                                break;
                                            }
                                        }
                                    }
                                }
                                strss = strss + measureState;
                                if (strss.Substring(0, 1).Contains("F"))
                                {//��ȡǰһ��״̬ΪFʱ��ӡֱ��
                                    printHeartLine(timeX, HY, oldHX, oldHY, reHeartMesure); ; //��ӡֱ��
                                }
                            }
                            this.printPoint[5].Add(new PointF(timeX, HY));
                            
                        }

                        if (PY > 0 && HY > 0)
                        {
                            pulse.Add(new PointF(timeX, PY));
                            heart.Add(new PointF(timeX, HY));
                        }


                        //if (PY > 0 && HY > 0)// 
                        //{
                        //    this.graph.DrawLine(redPen, timeX, PY, timeX, HY);
                        //}
                        #endregion

                        /*
                         *���´�ӡ  ����5
                         */
                        if (temperValue > 0) //����y����
                        {

                            int temperStyle = 1; //���� ���� ����
                            if (temperValue <= 34)
                            {
                                temperValue = 34;
                                TY = mainRec.Top + topRows * topRowSpace + (42 - (float)temperValue) * 5 * gridRowsSpace;
                                this.graph.DrawString("��", eightFont, Brushes.Blue, new RectangleF(timeX - gridColsWidth / 2 + 5, mainRec.Top + topRows * topRowSpace + gridRowsSpace * 35 - 12, gridColsWidth, gridRowsSpace * 2), textFormat);
                                //temperStyle = 2; //����
                                //TY = mainRec.Top + 571;  //576
                            }
                            else if (temperValue >= 42)
                            {
                                temperStyle = 0;  //����
                                TY = mainRec.Top + 81;
                            }
                            else
                            {
                                TY = mainRec.Top + topRows * topRowSpace + (42 - (float)temperValue) * 5 * gridRowsSpace;
                                //TY = ((42 - (float)temperValue) * 5 + 1) * (hourWidth - 2) + mainRec.Top + 63 + 56;
                            }
                            //TY = TY + gridRowsSpace * 5;
                            //������ֱ��
                            if (i > 0)
                            {
                                for (int m = 1; m <= i; m++)
                                {
                                    if (tempers.Rows[i - m]["measure_state"].ToString() != "" && tempers.Rows[i - m]["measure_state"].ToString() != "R")
                                    {
                                        float temperature_value = 0;//������һ������
                                        string temperature = tempers.Rows[i - m]["temperature_value"].ToString();
                                        if (temperature != "")
                                        {
                                            temperature_value = float.Parse(temperature);
                                        }
                                        if (temperature_value > 0 || tempers.Rows[i - m]["measure_state"].ToString() != "F")
                                        {//���´���0�����¼���ΪFʱ��
                                            strss = tempers.Rows[i - m]["measure_state"].ToString();
                                            break;
                                        }
                                    }
                                    string strsj = tempers.Rows[i - m]["describe"].ToString();
                                    if (strsj.Contains("����") || strsj.Contains("����"))
                                    {
                                        oldTX = 0;
                                        oldTY = 0;
                                        break;
                                    }
                                }
                                strss = strss + measureState;
                                if (strss.Length > 0)
                                {
                                    if (strss.Substring(0, 1).Contains("F"))
                                    {//��ȡǰһ��״̬ΪFʱ��ӡֱ��

                                        if (temperStyle == 2)
                                        {
                                            //printTemperLine(timeX, TY - 20, oldTX, oldTY);
                                        }
                                        else
                                        {
                                            printTemperLine(timeX, TY, oldTX, oldTY);
                                        }
                                    }
                                }
                            }

                            int temprtType = Convert.ToInt32(currentRow["temperature_body"]);
                            printTypeTemper(timeX, TY, temperStyle, temprtType, reMeasure, temperValue.ToString());

                            if (coolValue > 34 && coolValue < 42)
                            {
                                float coolY = mainRec.Top + topRows * topRowSpace + (42 - (float)coolValue) * 5 * gridRowsSpace;
                                printCoolingTemper(timeX, TY, coolY, coolValue.ToString());
                            }

                            if (temperStyle == 2)//���Ӳ�����ֱ��
                            {
                                TY = 0;
                            }

                            oldTX = 0;
                            oldTY = 0;
                        }

                        if (TY > 0)
                        {
                            if (((PY - TY) < 1 && (PY - TY) > -1) || ((HY - TY) < 1 && (HY - TY > -1)))
                            {
                                this.printPoint[7 + Convert.ToInt32(currentRow["temperature_body"])].Add(new PointF(timeX, TY));
                               
                            }
                        }

                        if (painValue > 0 && painValue <= 10)
                        {
                            PainY = mainRec.Top + topRows * topRowSpace + 40 * gridRowsSpace + (10 - painValue) * gridRowsSpace;
                            this.printPoint[13].Add(new PointF(timeX, PainY));
                            

                            if (printPoint[13].Count > 1)
                            {
                                this.graph.DrawLine(blackPen, timeX, PainY, printPoint[13][printPoint[13].Count - 2].X, printPoint[13][printPoint[13].Count - 2].Y);
                            }
                        }

                        /***
                         * ���� ��ӡ
                         */

                        if (breathValue > 0) //��ӡ����
                        {
                            if (breathUpFlag)
                            {
                                breathUpFlag = false;
                            }
                            else
                            {
                                breathUpFlag = true;
                            }
                            printBreath(timeX, rowTime.Hour, breathValue, currentRow["IS_ASSIST_BR"].ToString());
                        }
                        if (breathValue == 0)
                        {
                            if (currentRow["IS_ASSIST_BR"].ToString().Equals("Y"))
                            {
                                if (breathUpFlag)
                                {
                                    breathUpFlag = false;
                                }
                                else
                                {
                                    breathUpFlag = true;
                                }
                                printBreath(timeX, rowTime.Hour, breathValue, currentRow["IS_ASSIST_BR"].ToString());
                            }
                            else
                            {
                                if (breathUpFlag)
                                {
                                    breathUpFlag = false;
                                }
                                else
                                {
                                    breathUpFlag = true;
                                }
                                printBreath(timeX, rowTime.Hour, breathValue, currentRow["IS_ASSIST_BR"].ToString());
                            }
                        }


                        /***
                         * ��ʹ���� ��ӡ
                         */

                        //if (painValue > 0) //��ӡ����
                        //{

                        //    if (painUpFlag)
                        //    {
                        //        painUpFlag = false;
                        //    }
                        //    else
                        //    {
                        //        painUpFlag = true;
                        //    }
                        //    printPain(timeX, rowTime.Hour, painValue);
                        //}


                        /***
                         * �������� ���� ����ֵ ��ʹ����
                         */

                        if (TY > 0)
                        {
                            oldTX = timeX;
                            oldTY = TY;
                            TY = 0;
                        }

                        if (PY > 0)
                        {
                            oldPX = timeX;
                            oldPY = PY;
                            PY = 0;
                        }

                        if (HY > 0)
                        {
                            oldHX = timeX;
                            oldHY = HY;
                            HY = 0;
                        }

                        if (BY > 0)
                        {
                            oldBX = timeX;
                            oldBY = BY;
                            BY = 0;
                        }

                        if (PainY > 0)
                        {
                            oldPainX = timeX;
                            oldPainY = PainY;
                            PainY = 0;
                        }
                    }
                    else
                    {

                        oldTX = 0;
                        oldTY = 0;
                        oldHX = 0;
                        oldHY = 0;
                        oldPX = 0;
                        oldPY = 0;
                        oldPainX = 0;
                        oldPainY = 0;
                        pbstartflag = false;
                        printPurseBriefness(pulse, heart); //�����̴�


                        if (this.printPoint[4].Count > 0)
                        {
                            pulse.Add(this.printPoint[4][this.printPoint[4].Count - 1]);
                        }
                    }

                    #region   �¼�
                    bool Eventbool = false;
                    if (evertx <= timeX)
                    {
                        evertx = timeX;
                    }

                    if (describe != "")
                    {
                        //if (describe.Contains("��Ժ") && describe.Contains("����"))
                        //{
                        //    string s1 = string.Empty;
                        //    string s2 = string.Empty;
                        //    string s3 = string.Empty;
                        //    foreach (string var in describe.Split('|'))
                        //    {
                        //        if (var.Contains("��Ժ"))
                        //        {
                        //            s1 = var;
                        //        }
                        //        else if (var.Contains("����"))
                        //        {
                        //            s2 = "_" + var;
                        //        }
                        //        else
                        //        {
                        //            s3 += "|" + var;
                        //        }
                        //    }
                        //    describe = s1 + s2 + s3;
                        //}
                        foreach (string var in describe.Split('|'))
                        {
                            if (var == "" || var.IndexOf('_') == -1)
                            {
                                continue;
                            }

                            DateTime dt1;
                            //if (var.Contains("��Ժ") && var.Contains("����"))
                            //{
                            //    dt1 = Convert.ToDateTime(var.Split('_')[1]);
                            //}
                            //else
                            //{
                            dt1 = Convert.ToDateTime(var.Substring(var.IndexOf('_') + 1));
                            //}
                            DateTime dt2 = Convert.ToDateTime(rowTime.ToString("HH:mm"));

                            if (DateTime.Compare(dt1, dt2) > 0 && !var.Contains("��Ժ"))
                            {//�¼�ʱ��Ƚ�,��Ժ�¼�����ǰ��
                                if (Eventbool == false)
                                {//�Ƿ��Ѿ���ӡ�¼�
                                    //if (LQROEvent(evertx, timeX, measureState, hourWidth))
                                    //{
                                    //    Eventbool = true;
                                    //    evertx += hourWidth;
                                    //}
                                }
                                if (evertx == eventOld)
                                {
                                    evertx += hourWidth;
                                }

                                DrawEvent(evertx, var, currentRow["measure_time"].ToString());
                                eventOld = evertx;
                                evertx += hourWidth;
                            }
                            else
                            {
                                if (evertx == eventOld)
                                {
                                    evertx += hourWidth;
                                }
                                DrawEvent(evertx, var, currentRow["measure_time"].ToString());
                                eventOld = evertx;
                                evertx += hourWidth;
                            }
                        }
                    }
                    #endregion

                    if (Eventbool == false)
                    {
                        LQROEvent(evertx, timeX, measureState, hourWidth);
                        //if (LQROEvent(evertx, timeX, measureState, hourWidth))
                            //evertx += hourWidth;
                    }
                }


                ////ǰ���һ����
                // for (int i = 0; i < printPoint[4].Count; i++)
                // {
                //     if (heart.Count > 0)
                //     {
                //         if (heart[0].X == printPoint[4][i].X)
                //         {
                //             if (i > 0)
                //             {
                //                 this.graph.DrawLine(redPen, heart[0].X, heart[0].Y, printPoint[4][i - 1].X, printPoint[4][i - 1].Y);
                //             }
                //         }
                //     }
                // }
                if (heart.Count > 1)
                {
                    printPurseBriefness(pulse, heart);
                }
                if (pb_indexs.Count == 0)
                {
                    /*
                     * û�жϵ�
                     */

                    //β��
                    //for (int i = 0; i < printPoint[4].Count; i++)
                    //{
                    //    if (heart.Count > 0)
                    //    {
                    //        if (heart[heart.Count - 1].X == printPoint[4][i].X)
                    //        {
                    //            if (i < printPoint[4].Count - 1)
                    //            {
                    //                this.graph.DrawLine(redPen, heart[heart.Count - 1].X, heart[heart.Count - 1].Y, printPoint[4][i + 1].X, printPoint[4][i + 1].Y);
                    //            }
                    //        }
                    //    }
                    //}
                }
                else
                {
                    List<PointF> cutpointheadrs = new List<PointF>();
                    /*
                     * �жϵ�
                     */
                    //��ȡ���ʶ�Ӧ�Ķϵ�
                    for (int i = 0; i < heart.Count; i++)
                    {
                        for (int k = 0; k < pb_indexs.Count; k++)
                        {
                            if (heart[i].X >= printPoint[4][pb_indexs[i]].X)
                            {
                                cutpointheadrs.Add(heart[i]);
                            }
                        }
                    }


                    //ǰ��
                    for (int i = 0; i < cutpointheadrs.Count; i++)
                    {
                        for (int k1 = 0; k1 < printPoint[4].Count; k1++)
                        {
                            if (printPoint[4][k1].X >= cutpointheadrs[i].X)
                            {
                                /*
                                 * �ϵ�ƥ���ų��ϵ�
                                 */
                                bool flag = false;
                                for (int k2 = 0; k2 < pb_indexs.Count; k2++)
                                {
                                    if (k1 - 1 == pb_indexs[k2])
                                    {
                                        flag = true;
                                    }
                                }

                                if (!flag)
                                {
                                    //��Ϊ�ϵ㻭ǰ��
                                    this.graph.DrawLine(redPen, cutpointheadrs[i].X, cutpointheadrs[i].Y, printPoint[4][k1 - 1].X, printPoint[4][k1 - 1].Y);
                                }
                            }
                        }
                    }

                    //���
                    for (int i = 0; i < cutpointheadrs.Count; i++)
                    {

                        for (int j = 0; j < heart.Count; j++)
                        {
                            if (heart[j].X == cutpointheadrs[i].X)
                            {
                                for (int k1 = 0; k1 < printPoint[4].Count; k1++)
                                {
                                    if (printPoint[4][k1].X > heart[j - 1].X)
                                    {
                                        //�����
                                        this.graph.DrawLine(redPen, heart[j - 1].X, heart[j - 1].Y, printPoint[4][k1].X, printPoint[4][k1].Y);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //tempers = null;
            breathUpFlag = false;
            //painUpFlag = false;
        }
       
        /// <summary>
        /// �¼���ӡ
        /// </summary>
        /// <param name="evertx"></param>
        /// <param name="timeX"></param>
        /// <param name="measureState"></param>
        /// <param name="measureState"></param>
        private bool LQROEvent(float evertx, float timeX, string measureState, int hourWidth)
        {
            //�Ӱ�����  ����١����¼�����ʾ������35�̶�֮�� ���������Ժ���¼���ͻ���������г���Ժ���¼�ʱ���ú���һ��
            //if (evertx <= timeX)
            //{
                evertx = timeX;
            //}
            //RectangleF otherCharRec = new RectangleF(evertx - 7, mainRec.Top + topRows * topRowSpace, hourWidth, hourWidth);
            RectangleF otherCharRec = new RectangleF(evertx - 7, mainRec.Top + topRows * topRowSpace + 35 * gridRowsSpace+1, hourWidth, hourWidth);//�Ӱ������¼���ʾ��35�̶�����ʾ

            if (measureState == "W")
            {
                drawEvent("���", otherCharRec);
                evertx += hourWidth;
            }
            else if (measureState == "L")
            {
                drawEvent("���", otherCharRec);                
                evertx += hourWidth;
            }
            else if (measureState == "Q")
            {
                drawEvent("Ȱ����Ч���", otherCharRec);               
                evertx += hourWidth;
            }
            else if (measureState == "R")
            {
                drawEvent("�ܲ�", otherCharRec);            
                evertx += hourWidth;
            }
            else if (measureState == "J")
            {
                drawEvent("������", otherCharRec);
                evertx += hourWidth;
            }
            else if (measureState == "O")
            {
                drawEvent("˽�����", otherCharRec);             
                evertx += hourWidth;
            }
            else if (measureState == "T")
            {
                drawEvent("ͣ��", otherCharRec);
                evertx += hourWidth;
            }
            else
            {
                return false;
            }
            return true;
        }
        private void DrawEvent(float evertx, string var)
        {
            RectangleF charRec = new RectangleF(evertx - 7, mainRec.Top + topRows * topRowSpace, hourWidth, hourWidth);//88
            if (evertx - 7 < mainRec.Left + 688)
            {
                string[] eventTime = var.Split('_');
                DateTime dateEvent;
                string eventTimeString = "";
                if (var.Contains("�ؼҴ���") || var.Contains("��Ժ����") || var.Contains("�ؼҴ���") || var.Contains("��Ժ����") || var.Contains("����"))
                {
                    eventTimeString = eventTime[0];
                }
                else
                {
                    dateEvent = Convert.ToDateTime(eventTime[1]);
                    eventTimeString = eventTime[0] + (var.Contains("����") ? "��" : "|") + this.ConvertText(dateEvent.ToString("HH:mm"));
                }
                drawEvent(eventTimeString, charRec);
            }
        }

        private void DrawEvent(float evertx, string var, string measure_time)
        {
            DateTime timepoint = GetTimePoint(Convert.ToDateTime(measure_time));

            RectangleF charRec = new RectangleF(evertx - 7, mainRec.Top + topRows * topRowSpace+2, hourWidth, hourWidth);//88
            if (evertx - 7 < mainRec.Left + 688)
            {
                string[] eventTime = var.Split('_');
                DateTime dateEvent;
                string eventTimeString = "";
                //if (var.Contains("��Ժ") && var.Contains("����"))
                //{
                //    drawEventInAndOpeation(var, charRec);
                //}
                //else 
                //if (var.Contains("����"))
                //{                   
                //    dateEvent = Convert.ToDateTime(eventTime[1]);
                //    eventTimeString = eventTime[0] + OpreaterTimes(measure_time) + "|" + this.ConvertText(dateEvent.ToString("HH:mm"));                 
                //}else
                if (var.Contains("�ؼҴ���") || var.Contains("��Ժ����") || var.Contains("�ؼҴ���") || var.Contains("��Ժ����")||var.Contains("����"))//�Ӱ����� ���� ����ʾʱ��
                {
                    eventTimeString = eventTime[0];
                }
                else
                {
                    dateEvent = Convert.ToDateTime(eventTime[1]);//(var.Contains("����") ? "��" : "|")
                    eventTimeString = eventTime[0] + "|" + this.ConvertText(dateEvent.ToString("HH:mm"));
                }
                drawEvent(eventTimeString, charRec);
            }
        }

        /// <summary>
        /// ��Ժ��������ʱ���
        /// </summary>
        void drawEventInAndOpeation(string eventString, RectangleF rec)
        {
            string[] strs = eventString.Split('_');
            string s = "��Ժ";
            string s2 = strs[1];
            s2 = ConvertText(s2);
            s = s + "��" + "����" + s2;
            //s = s + s2 + " " + "����";
            char[] strArr = s.ToCharArray();
            Font newfont = new Font("����", 8);//9
            for (int i = 0; i < strArr.Length; i++)
            {
                this.graph.DrawString(strArr[i].ToString(), newfont, redBrush, rec, textFormat);
                //rec.Y += 13;
                //if (strArr[i].ToString().Equals(" "))
                //{
                //    rec.Y += 8;
                //}
                //else
                //{
                rec.Y += 11;
                //}
            }
        }

        public string GetLastEvent()
        {
            DateTime lastTime = this.startTime.AddDays(-1);
            string sql = string.Format("SELECT MEASURE_TIME,DESCRIBE FROM t_vital_signs WHERE to_char(MEASURE_TIME,'yyyy-MM-dd')= '{0}' AND PATIENT_ID = '{1}' order by MEASURE_TIME", lastTime.ToString("yyyy-MM-dd"), pid);
            DataTable table = App.GetDataSet(sql).Tables[0];
            if (table.Rows.Count < 1)
            {
                return "";
            }
            float eventOld = 0;
            float evertx = 0;
            string eventStr = string.Empty;
            foreach (DataRow dr in table.Rows)
            {
                string describe = dr["DESCRIBE"].ToString();
                if (describe != "")
                {
                    DateTime rowTime = Convert.ToDateTime(dr["measure_time"].ToString());
                    float timeX = getX(6, rowTime.Hour);
                    if (evertx <= timeX)
                    {
                        evertx = timeX;
                    }
                    foreach (string var in describe.Split('|'))
                    {
                        if (evertx == eventOld)
                        {
                            evertx += hourWidth;
                        }
                        if (evertx - 7 >= mainRec.Left + 688)
                        {
                            eventStr += (var + "|");
                        }
                        eventOld = evertx;
                        evertx += hourWidth;
                    }
                }

            }
            return eventStr;
        }

        /// <summary>
        /// ��ͨ���µ�������Ϣ
        /// </summary>
        private void printOther()
        {
            DataTable other = dbList[1];
            string str = string.Empty;
            float maxOther = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight;
            mainTop = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight;
            Dictionary<string, float> others = new Dictionary<string, float>();
            //�հ�������1
            string strEmptyItemName1 = "";
            ////�հ�������2
            string strEmptyItemName2 = "";
            ////�հ�������3
            string strEmptyItemName3 = "";
            for (int i = 0; i < other.Rows.Count; i++)
            {
                DataRow currentRow = other.Rows[i];
                DateTime rowTime = Convert.ToDateTime(Convert.ToDateTime(currentRow["record_time"]).ToString("yyyy-MM-dd"));
                TimeSpan begin = new TimeSpan(this.startTime.Ticks);
                TimeSpan end = new TimeSpan(rowTime.Ticks);
                TimeSpan beginToEnd = begin.Subtract(end).Duration();
                int timeX = mainRec.Left + 100 + beginToEnd.Days * gridColsWidth * 6; //X����
                RectangleF textRec = new RectangleF(timeX, 0, gridColsWidth * 6, bottomRosSpace);
                ///***
                // * Һ����  
                // */
                string in_amount = currentRow["in_amount"].ToString();
                if (in_amount != "")// && in_amount != "0")
                {
                    textRec.Y = mainTop + bottomRosSpace * 0;
                    this.graph.DrawString(in_amount, nineFont, brush, textRec, textFormat);
                }

                /***
                 * ������
                 */
                string strEmpItemValue2 = currentRow["empty_value2"].ToString();
                if (strEmpItemValue2 != "")
                {
                    textRec.Y = mainTop + bottomRosSpace * 1;
                    this.graph.DrawString(strEmpItemValue2, nineFont, brush, textRec, textFormat);
                }
                
                /***
                 * ����
                 */
                string out_amout = currentRow["out_amount"].ToString();
                if (out_amout != "")// && out_amout != "0")
                {
                    textRec.Y = mainTop + bottomRosSpace * 2;
                    this.graph.DrawString(out_amout, nineFont, brush, textRec, textFormat);
                }

                /***
                * Ż��
                */
                string strEmpItemValue3 = currentRow["empty_value3"].ToString();
                if (strEmpItemValue3 != "")
                {
                    textRec.Y = mainTop + bottomRosSpace * 3;
                    this.graph.DrawString(strEmpItemValue3, nineFont, brush, textRec, textFormat);
                }
                
                /*
                 * �������� STOOL_AMOUNT ҩ�����
                 */
                //string SPECIAL = currentRow["SPECIAL"].ToString();
                //if (SPECIAL != "" && SPECIAL != "0")
                //{ 
                //    textRec.Y = mainTop + 186;
                //    this.graph.DrawString(SPECIAL, nineFont, brush, textRec, textFormat);
                //}                
                //textRec.Y = mainTop + 186;
                //this.graph.DrawString(GetSpecialVal(ds_special, currentRow["record_time"].ToString()), nineFont, brush, textRec, textFormat);
                          

                /***
                 * ���-��״
                 */
                textRec.Y = mainTop + bottomRosSpace * 4;
                #region old
                //string stool_state = currentRow["stool_state"].ToString(); //�������
                //if (stool_state == "N" || stool_state=="")
                //{
                //    string stool_count = currentRow["stool_count"].ToString();
                //    this.graph.DrawString(stool_count, nineFont, brush, textRec, textFormat);
                //}
                //else if (stool_state == "I")
                //{
                //    this.graph.DrawString("��", nineFont, brush, textRec, textFormat); //��
                //}
                //else if (stool_state == "G")
                //{
                //    this.graph.DrawString("��", nineFont, brush, textRec, textFormat);
                //}
                //else if (stool_state == "E")
                //{
                //    this.graph.DrawString("��/E", nineFont, brush, textRec, textFormat); //��
                //}
                //else if (stool_state == "C")
                //{
                //    string stool_count_e = currentRow["stool_count_e"].ToString();
                //    string stool_count_f = currentRow["stool_count_f"].ToString();
                //    string clysis_count = currentRow["clysis_count"].ToString();
                //    string shit_state = currentRow["SHIT_STATE"] == null ? "" : currentRow["SHIT_STATE"].ToString(); 
                //    string stool_count_c = "";
                //    ////if (clysis_count != "")
                //    ////{
                //    ////    stool_count_c=clysis_count;
                //    ////}
                //    ////else
                //    ////{
                //    ////    if (stool_count_f != "" && stool_count_e!="")
                //    ////    {
                //    ////        stool_count_c = stool_count_f + "," + stool_count_e;
                //    ////    }
                //    ////    else if (stool_count_f != "")
                //    ////    {
                //    ////        stool_count_c = stool_count_f;
                //    ////        if (shit_state == "I")
                //    ////        {
                //    ////            stool_count_c += ",��";
                //    ////        }
                //    ////    }
                //    ////    else if (stool_count_e != "")
                //    ////    {
                //    ////        stool_count_c = stool_count_e;
                //    ////    }

                //    ////}
                //    if (stool_count_f.Length>0 && stool_count_f != "0")
                //    {
                //        stool_count_c = stool_count_f + ",";
                //    }
                //    if (clysis_count == "0" || clysis_count == "1" || clysis_count == "")
                //    {
                //        stool_count_c += stool_count_e + "/E";
                //    }
                //    else
                //    {
                //        stool_count_c += stool_count_e + "/" + clysis_count + "E";
                //    }
                //    //if (stool_count_f.Length>0&&stool_count_f != "0")
                //    //{
                //    //    stool_count_c = stool_count_f + "," + stool_count_e + "/E";
                //    //}
                //    //else
                //    //{
                //    //    stool_count_c =stool_count_e + "/E";
                //    //}
                //this.graph.DrawString(stool_count_c, nineFont, brush, textRec, textFormat);
                #endregion
                this.graph.DrawString(currentRow["shit"].ToString(), nineFont, brush, textRec, textFormat);

                /***
                 * ���-����
                 */
                string strEmpItemValue4 = currentRow["empty_value4"].ToString();
                if (strEmpItemValue4 != "")
                {                    
                    textRec.Y = mainTop + bottomRosSpace * 5;
                    this.graph.DrawString(strEmpItemValue4, nineFont, brush, textRec, textFormat);
                }

                /*
                 *С��
                 */
                //textRec.Y = mainTop + bottomRosSpace * 3;
                //this.graph.DrawString(currentRow["urine"].ToString(), nineFont, brush, textRec, textFormat);


                //***
                // * ����
                // */               
                string weight = currentRow["weight"].ToString();
                textRec.Y = mainTop + bottomRosSpace * 6;
                if (weight != "")// && weight != "0")
                {
                    this.graph.DrawString(weight, nineFont, brush, textRec, textFormat);
                }

                /***
                * ͷΧ
                */
                string strEmpItemValue5 = currentRow["empty_value5"].ToString();
                if (strEmpItemValue5 != "")
                {
                    textRec.Y = mainTop + bottomRosSpace * 7;
                    this.graph.DrawString(strEmpItemValue5, nineFont, brush, textRec, textFormat);
                }

                //***
                // * ���
                // */               
                string length = currentRow["length"].ToString();
                textRec.Y = mainTop + bottomRosSpace * 8;
                if (length != "")// && length != "0")
                {
                    this.graph.DrawString(length, nineFont, brush, textRec, textFormat);
                }

                /***
                 * Ѫѹ
                 */
                //string bp_blood = currentRow["bp_blood"].ToString();
                //if (bp_blood != "")
                //{
                //    string[] bloodArr = bp_blood.Split(',');
                //    RectangleF itemRec = textRec;
                //    //itemRec.Y = mainTop + bottomRosSpace * 4;
                //    itemRec.Y = mainTop;
                //    Font objfont = new Font("����", 7);
                //    itemRec.Width = gridColsWidth * 6;
                //    if (bloodArr.Length > 1)
                //    {
                //        if (bloodArr[0].Length >= 7 || bloodArr[1].Length >= 7)
                //        {
                //            this.graph.DrawString(bloodArr[0].Substring(0, bloodArr[0].Length), objfont, brush, itemRec, textFormat);
                //            //itemRec.X += gridColsWidth * 3;
                //            itemRec.Y += bottomRosSpace;
                //            this.graph.DrawString(bloodArr[1].Substring(0, bloodArr[1].Length), objfont, brush, itemRec, textFormat);
                //        }
                //        else
                //        {
                //            this.graph.DrawString(bloodArr[0].Substring(0, bloodArr[0].Length), eightFont, brush, itemRec, textFormat);
                //            //itemRec.X += gridColsWidth * 3;
                //            itemRec.Y += bottomRosSpace;
                //            this.graph.DrawString(bloodArr[1].Substring(0, bloodArr[1].Length), eightFont, brush, itemRec, textFormat);
                //        }
                //    }
                //    else
                //    {
                //        if (bloodArr[0].Length >= 7)
                //        {
                //            this.graph.DrawString(bp_blood.Substring(0, bp_blood.Length), objfont, brush, itemRec, textFormat);
                //        }
                //        else
                //        {
                //            this.graph.DrawString(bp_blood.Substring(0, bp_blood.Length), eightFont, brush, itemRec, textFormat);
                //        }
                //    }
                //}

                ////�հ�������1
                Font EmptyItemNameFont = new Font("����", 7);

                //***
                // * ��Χ--�Ӱ�
                // */               
                string strEmpItemValue1 = currentRow["empty_value1"].ToString();
                textRec.Y = mainTop + bottomRosSpace * 9;
                if (strEmpItemValue1 != "")// && length != "0")
                {
                    this.graph.DrawString(strEmpItemValue1, nineFont, brush, textRec, textFormat);
                }
                //***
                // * ����ҩ��--�Ӱ�
                // */               
                //string strEmpItemValue4 = currentRow["empty_value4"].ToString();
                //textRec.Y = mainTop + bottomRosSpace * 8;
                //if (strEmpItemValue4 != "")// && length != "0")
                //{
                //    if (strEmpItemValue4.Length <7)
                //    {
                //        this.graph.DrawString(strEmpItemValue4, nineFont, brush, textRec, textFormat);                    
                //    }
                //    else if (strEmpItemValue4.Length<8)
                //    {                        
                //        this.graph.DrawString(strEmpItemValue4, eightFont, brush, textRec, textFormat);
                //    }
                //    else if (strEmpItemValue4.Length < 9)
                //    {
                //        Font objfont = new Font("����", 7);
                //        this.graph.DrawString(strEmpItemValue4, objfont, brush, textRec, textFormat);
                //    }
                //    else if (strEmpItemValue4.Length < 10)
                //    {
                //        Font objfont = new Font("����", 6);
                //        this.graph.DrawString(strEmpItemValue4, objfont, brush, textRec, textFormat);
                //    }
                //    else if (strEmpItemValue4.Length < 11)
                //    {
                //        Font objfont = new Font("����", 5);
                //        this.graph.DrawString(strEmpItemValue4, objfont, brush, textRec, textFormat);
                //    }
                //    else
                //    {
                //        Font objfont = new Font("����",4);
                //        this.graph.DrawString(strEmpItemValue4, objfont, brush, textRec, textFormat);
                //    }
                //}

                //if (i == 0)
                //{
                //    DataRow[] drsempty1 = other.Select(" empty_name1 is not null");
                //    if (drsempty1.Length > 0)
                //    {
                //        strEmptyItemName1 = drsempty1[0]["empty_name1"].ToString();
                //        RectangleF itemRec = textRec;
                //        itemRec.X = mainRec.X;
                //        itemRec.Y = mainTop + bottomRosSpace * 7;
                //        itemRec.Width = 100;
                //        if (strEmptyItemName1.Length <= 7)
                //        {
                //            this.graph.DrawString(strEmptyItemName1, nineFont, brush, itemRec, textFormat);
                //        }
                //        else if (strEmptyItemName1.Length <= 10)
                //        {
                //            this.graph.DrawString(strEmptyItemName1, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //        else
                //        {
                //            RectangleF rf = itemRec;
                //            rf.Height = rf.Height + 2;
                //            this.graph.DrawString(strEmptyItemName1, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //    }
                //}
                ////�հ���ֵ1
                //if (!string.IsNullOrEmpty(strEmptyItemName1))
                //{
                //    string strEmpItemValue1 = currentRow["empty_value1"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 7;
                //    this.graph.DrawString(strEmpItemValue1, nineFont, brush, textRec, textFormat);
                //}
                //�հ�������2
                //if (i == 0)
                //{
                //    DataRow[] drsempty2 = other.Select(" empty_name2 is not null");
                //    if (drsempty2.Length > 0)
                //    {
                //        strEmptyItemName2 = drsempty2[0]["empty_name2"].ToString();
                //        RectangleF itemRec = textRec;
                //        itemRec.X = mainRec.X;
                //        itemRec.Y = mainTop + bottomRosSpace * 9;
                //        itemRec.Width = 100;
                //        if (strEmptyItemName2.Length <= 7)
                //        {
                //            this.graph.DrawString(strEmptyItemName2, nineFont, brush, itemRec, textFormat);
                //        }
                //        else if (strEmptyItemName2.Length <= 10)
                //        {
                //            this.graph.DrawString(strEmptyItemName2, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //        else
                //        {
                //            RectangleF rf = itemRec;
                //            rf.Height = rf.Height + 2;
                //            this.graph.DrawString(strEmptyItemName2, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //    }
                //}
                //�հ���ֵ2
                //if (!string.IsNullOrEmpty(strEmptyItemName2))
                //{
                //    string strEmpItemValue2 = currentRow["empty_value2"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 9;
                //    this.graph.DrawString(strEmpItemValue2, nineFont, brush, textRec, textFormat);
                //}

                //�հ�����3
                //if (i == 0)
                //{
                //    DataRow[] drsempty2 = other.Select(" empty_name3 is not null");
                //    if (drsempty2.Length > 0)
                //    {
                //        strEmptyItemName3 = drsempty2[0]["empty_name3"].ToString();
                //        RectangleF itemRec = textRec;
                //        itemRec.X = mainRec.X;
                //        itemRec.Y = mainTop + bottomRosSpace * 10;
                //        itemRec.Width = 100;
                //        if (strEmptyItemName3.Length <= 7)
                //        {
                //            this.graph.DrawString(strEmptyItemName3, nineFont, brush, itemRec, textFormat);
                //        }
                //        else if (strEmptyItemName3.Length <= 10)
                //        {
                //            this.graph.DrawString(strEmptyItemName3, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //        else
                //        {
                //            RectangleF rf = itemRec;
                //            rf.Height = rf.Height + 2;
                //            this.graph.DrawString(strEmptyItemName3, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //    }
                //}
                //�հ���ֵ3
                //if (!string.IsNullOrEmpty(strEmptyItemName3))
                //{
                //    string strEmpItemValue3 = currentRow["empty_value3"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 10;
                //    this.graph.DrawString(strEmpItemValue3, nineFont, brush, textRec, textFormat);
                //}

                ////�հ�����4
                //if (i == 0)
                //{
                //    DataRow[] drsempty2 = other.Select(" empty_name4 is not null");
                //    if (drsempty2.Length > 0)
                //    {
                //        strEmptyItemName2 = drsempty2[0]["empty_name4"].ToString();
                //        RectangleF itemRec = textRec;
                //        itemRec.X = mainRec.X;
                //        itemRec.Y = mainTop + bottomRosSpace * 10;
                //        itemRec.Width = 100;
                //        if (strEmptyItemName2.Length <= 7)
                //        {
                //            this.graph.DrawString(strEmptyItemName2, nineFont, brush, itemRec, textFormat);
                //        }
                //        else if (strEmptyItemName2.Length <= 10)
                //        {
                //            this.graph.DrawString(strEmptyItemName2, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //        else
                //        {
                //            RectangleF rf = itemRec;
                //            rf.Height = rf.Height + 2;
                //            this.graph.DrawString(strEmptyItemName2, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //    }
                //}
                ////�հ���ֵ4
                //if (!string.IsNullOrEmpty(strEmptyItemName2))
                //{
                //    string strEmpItemValue2 = currentRow["empty_value4"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 8;
                //    this.graph.DrawString(strEmpItemValue2, nineFont, brush, textRec, textFormat);
                //}

                ////�հ�����5
                //if (i == 0)
                //{
                //    DataRow[] drsempty2 = other.Select(" empty_name5 is not null");
                //    if (drsempty2.Length > 0)
                //    {
                //        strEmptyItemName2 = drsempty2[0]["empty_name5"].ToString();
                //        RectangleF itemRec = textRec;
                //        itemRec.X = mainRec.X;
                //        itemRec.Y = mainTop + bottomRosSpace * 11;
                //        itemRec.Width = 100;
                //        if (strEmptyItemName2.Length <= 7)
                //        {
                //            this.graph.DrawString(strEmptyItemName2, nineFont, brush, itemRec, textFormat);
                //        }
                //        else if (strEmptyItemName2.Length <= 10)
                //        {
                //            this.graph.DrawString(strEmptyItemName2, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //        else
                //        {
                //            RectangleF rf = itemRec;
                //            rf.Height = rf.Height + 2;
                //            this.graph.DrawString(strEmptyItemName2, EmptyItemNameFont, brush, itemRec, textFormat);
                //        }
                //    }
                //}
                ////�հ���ֵ5
                //if (!string.IsNullOrEmpty(strEmptyItemName2))
                //{
                //    string strEmpItemValue2 = currentRow["empty_value5"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 11;
                //    this.graph.DrawString(strEmpItemValue2, nineFont, brush, textRec, textFormat);
                //}

            }
            others.Clear();
        }


        /// <summary>
        /// �����̴�
        /// </summary>
        /// <param name="pulse"></param>
        /// <param name="heart"></param>
        private void printPurseBriefness(List<PointF> pulse, List<PointF> heart)
        {
            //if (heart.Count > 0)
            //{
            //    heart.Reverse();
            //    foreach (PointF pd in heart)
            //    {
            //        pulse.Add(pd);
            //    }
            //    this.graph.FillPolygon(fillBrush, pulse.ToArray());
            //    heart.Clear();
            //    pulse.Clear();
            //}
            if (heart.Count > 0)
            {
                for (int i = 0; i < heart.Count; i++)
                {
                    PointF pheart = heart[i];
                    PointF ppulse = pulse.Find(delegate(PointF pf) { return pf.X == pheart.X; });
                    if (ppulse != null && ppulse.X > 0)
                    {
                        this.graph.DrawLine(redPen, pheart, ppulse);
                        if (i > 0)
                        {
                            PointF pheartold = heart[i - 1];
                            PointF ppulseold = pulse.Find(delegate(PointF pf) { return pf.X == pheartold.X; });
                            int index = 1;
                            PointF pheart2 = GetPoint(pheartold, pheart, pheart.X - index * gridColsWidth / 2);
                            while (pheart2 != pheartold)
                            {
                                PointF ppulse2 = GetPoint(ppulseold, ppulse, ppulse.X - index * gridColsWidth / 2);
                                this.graph.DrawLine(redPen, pheart2, ppulse2);
                                index++;
                                pheart2 = GetPoint(pheartold, pheart, pheart.X - index * gridColsWidth / 2);
                            }
                        }
                    }
                }
            }

        }

        private PointF GetPoint(PointF pf1, PointF pf2, float pfx)
        {
            float pfy = (pfx - pf1.X) * (pf2.Y - pf1.Y) / (pf2.X - pf1.X) + pf1.Y;
            return new PointF(pfx, pfy);
        }

        /// <summary>
        /// ��ͨ���µ�����
        /// </summary>
        private void printBreath(float x, int hours, int breath, string IS_ASSIST_BR)
        {
            mainTop = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace+2;
            //������λ��
            int RStartPosition = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace+2;
            if (IS_ASSIST_BR.ToLower() == "y")
            {
                if (breathUpFlag)
                {
                    this.graph.DrawEllipse(blackPen, new Rectangle((int)x - 5, (int)RStartPosition + rHeight / 2, 10, 10));
                    this.graph.DrawString("R", sevenFont, brush, x - 2, RStartPosition + rHeight / 2, StringFormat.GenericTypographic);
                }
                else
                {
                    this.graph.DrawEllipse(blackPen, new Rectangle((int)x - 5, (int)RStartPosition + 2, 10, 10));
                    this.graph.DrawString("R", sevenFont, brush, x - 2, RStartPosition + 2, StringFormat.GenericTypographic);
                }
            }
            else
            {
                if (!breathUpFlag)//�人��Ժ�����Ǵ������ϣ������ط��Ǵ�������
                {
                    this.graph.DrawString(breath.ToString(), sevenFont, brush, new RectangleF(x - 6, mainTop + rHeight / 2, gridColsWidth, rHeight / 2));
                }
                else
                {

                    this.graph.DrawString(breath.ToString(), sevenFont, brush, new RectangleF(x - 6, mainTop, gridColsWidth, rHeight / 2));
                }
            }
        }

        /// <summary>
        /// ��ͨ���µ�����
        /// </summary>
        private void printPain(float x, int hours, int paine_value)
        {
            if (painUpFlag)
            {
                this.graph.DrawString(paine_value.ToString(), nineFont, brush, new RectangleF(x - 6, mainTop + 24, 24, 21));
            }
            else
            {
                this.graph.DrawString(paine_value.ToString(), nineFont, brush, new RectangleF(x - 6, mainTop + 34, 24, 21));
            }
        }

        /// <summary>
        /// ��ͨ���µ���ӡ����ֱ��
        /// </summary>
        private void printPulseLine(float startX, float startY, float oldX, float oldY,string val)
        {
            if (oldX > 0 && oldY > 0)
            {
                this.graph.DrawLine(redPen, startX, startY, oldX, oldY);
            }
            this.printPoint[4].Add(new PointF(startX, startY));
            
        }

        /// <summary>
        /// ��ͨ���µ���ӡ����ֱ��
        /// </summary>
        private void printBreathLine(float startX, float startY, float oldX, float oldY)
        {
            //if (oldX > 0 && oldY > 0)
            //{
            //    this.graph.DrawLine(bluePen, startX, startY, oldX, oldY);
            //}
            //this.printPoint[11].Add(new PointF(startX, startY));
        }

        /// <summary>
        /// ��ͨ���µ���ӡ����ֱ��
        /// </summary>
        private void printHeartLine(float startX, float startY, float oldX, float oldY, string reHeartMesure)
        {
            if (oldX > 0 && oldY > 0)
            {
                this.graph.DrawLine(redPen, startX, startY, oldX, oldY);
            }
            //if (reHeartMesure == "Y")
            //{
            //    this.printPoint[12].Add(new PointF(startX, startY));
            //}
            //else
            //{
            //    this.printPoint[5].Add(new PointF(startX, startY));
            //}
            ////�����Ӱ��
            //if (this.printPoint[5].Count > 1)
            //{
            //    int count = this.printPoint[5].Count;
            //    PointF pHeartStart = this.printPoint[5][count - 2];
            //    PointF pHeartEnd = this.printPoint[5][count - 1];
            //    PointF pPulseStart = this.printPoint[4].Find(delegate(PointF pf) { return pf.X == pHeartStart.X; });
            //    PointF pPulseEnd = this.printPoint[4].Find(delegate(PointF pf) { return pf.X == pHeartEnd.X; });

            //    if (pPulseStart != null && pPulseEnd != null)
            //    {
            //        if (pPulseStart.X > 0 && pPulseEnd.X > 0)
            //        {
            //            this.graph.FillPolygon(fillBrush, new PointF[] { pHeartStart, pHeartEnd, pPulseEnd, pPulseStart });
            //        }
            //    }
            //}
            //this.printPoint[5].Add(new PointF(startX, startY));
        }

        /// <summary>
        /// ��ͨ���µ���ӡ����ֱ��
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="oldX"></param>
        /// <param name="oldY"></param>
        private void printTemperLine(float startX, float startY, float oldX, float oldY)
        {
            if (oldX > 0 && oldY > 0)
            {
                this.graph.DrawLine(bluePen, startX, startY, oldX, oldY);
            }
        }

        /// <summary>
        /// ��ͨ���µ����ʹ�ӡ
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="temperStyle">0���� 1���� 2����</param>
        /// <param name="temperType"></param>
        /// <param name="reMeasure"></param>
        private void printTypeTemper(float startX, float startY, int temperStyle, int temperType, string reMeasure, string val)
        {
            if (temperStyle == 0) //����
            {
                using (Pen rowPen = new Pen(Color.Blue))
                {
                    this.printPoint[temperType + 1].Add(new PointF(startX, startY));
                    
                    AdjustableArrowCap aac = new AdjustableArrowCap(4, 4, true);
                    rowPen.CustomEndCap = aac;
                    this.graph.DrawLine(rowPen, startX, startY, startX, startY - 12);
                }
            }

            else if (temperStyle == 1)
            {
                this.printPoint[temperType + 1].Add(new PointF(startX, startY));
                
            }

            else if (temperStyle == 2)
            {
                //    this.graph.DrawString("*", eightFont, brush, startX - 5, startY + 2, StringFormat.GenericTypographic);
                //    this.graph.DrawString("��", eightFont, brush, startX - 5, startY + 16, StringFormat.GenericTypographic);
                this.graph.DrawString("����", eightFont, Brushes.Blue, new RectangleF(startX - gridColsWidth / 2, mainRec.Top + topRows * topRowSpace + gridRowsSpace * 33, gridColsWidth, gridRowsSpace * 2), textFormat);
                //float coolY = mainRec.Top + topRows * topRowSpace + (35) * 5 * gridRowsSpace;
                //printCoolingTemper();
                ////����ͷ
                //using (Pen rowPen = new Pen(Color.Blue))
                //{
                //    //this.printPoint[temperType + 1].Add(new PointF(startX, startY));
                //    AdjustableArrowCap aac = new AdjustableArrowCap(4, 4, true);
                //    rowPen.CustomEndCap = aac;
                //    this.graph.DrawLine(rowPen, startX, startY - 20, startX, startY);
                //}
            }
            if (reMeasure == "Y")
            {
                this.printPoint[10].Add(new PointF(startX + 5, startY));
              
            }
        }

        /// <summary>
        /// ��ӡ�����¶�
        /// </summary>
        private void printCoolingTemper(float X, float startY, float coolY,string val)
        {
            using (Pen coolPen = new Pen(Color.Red))
            {
                coolPen.DashPattern = new float[] { 3, 3 };
                this.graph.DrawLine(coolPen, X, startY, X, coolY);
                this.printPoint[6].Add(new PointF(X, coolY));
            
            }
        }


        ///// <summary>
        ///// ��ӡƤ��
        ///// </summary>
        //private void printSkin(RectangleF rec, string value)
        //{
        //    int length = value.Length;
        //    if (value.Contains("����"))
        //    {
        //        rec.Y += 3;
        //        SizeF sz = graph.MeasureString(value, eightFont);
        //        int margin = Convert.ToInt32((rec.Width - sz.Width) / 2);
        //        for (int i = 0; i < value.Length; i++)
        //        {
        //            string str = value[i].ToString();
        //            if (i == value.Length - 3 || i == value.Length - 2)
        //            {
        //                graph.DrawString(str, eightFont, redBrush, rec.X + margin, rec.Y);
        //            }
        //            else
        //            {
        //                graph.DrawString(str, eightFont, brush, rec.X + margin, rec.Y);
        //            }
        //            margin += Convert.ToInt32(graph.MeasureString(str, eightFont, 200, StringFormat.GenericTypographic).Width);
        //        }
        //    }
        //    else
        //    {
        //        this.graph.DrawString(value, eightFont, brush, rec, textFormat);
        //    }
        //}

        /// <summary>
        /// ��ӡ����
        /// </summary>
        private void printPoints()
        {
            //����
            foreach (PointF p in printPoint[5])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
            }

            //����
            foreach (PointF p in printPoint[4])
            {
                bool overlap = false;//�Ƿ���¶��ص�
                for (int i = 0; i < printPoint[1].Count; i++)
                {
                    if (p.X == printPoint[1][i].X && p.Y == printPoint[1][i].Y + 2)
                    {
                        printPoint[1].RemoveAt(i);
                        printPoint[7].Add(p);
                        overlap = true;
                        break;
                    }

                }
                for (int i = 0; i < printPoint[2].Count; i++)
                {
                    if (p.X == printPoint[2][i].X && p.Y == printPoint[2][i].Y + 2)
                    {
                        printPoint[2].RemoveAt(i);
                        printPoint[8].Add(p);
                        overlap = true;
                        break;
                    }
                }
                for (int i = 0; i < printPoint[3].Count; i++)
                {
                    if (p.X == printPoint[3][i].X && p.Y == printPoint[3][i].Y + 2)
                    {
                        printPoint[3].RemoveAt(i);
                        printPoint[9].Add(p);
                        overlap = true;
                        break;
                    }
                }
                if (!overlap)
                {
                    this.graph.FillEllipse(redBrush, p.X - 4, p.Y - 4, 8, 8);
                }

            }


            ////����
            //foreach (PointF p in printPoint[11])
            //{
            //    this.graph.FillEllipse(blueBrush, p.X - 3, p.Y - 3, 6, 6);
            //}

            //���º��¶�
            foreach (PointF p in printPoint[6])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
            }
            //Ҹ��
            foreach (PointF p in printPoint[1])
            {
                this.graph.DrawLine(bluePen, p.X - 3, p.Y - 3, p.X + 3, p.Y + 3);
                this.graph.DrawLine(bluePen, p.X + 3, p.Y - 3, p.X - 3, p.Y + 3);
            }

            //�ڱ�
            bluePen.Width = 2;
            foreach (PointF p in printPoint[2])
            {
                this.graph.FillEllipse(blueBrush, p.X - 4, p.Y - 4, 8, 8);
            }
            bluePen.Width = 1;

            //�ر�
            foreach (PointF p in printPoint[3])
            {
                //�ڵ�ֱ��
                float d = 2f;
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.FillEllipse(blueBrush, p.X - d / 2, p.Y - d / 2, d, d);
                this.graph.DrawEllipse(bluePen, p.X - 4, p.Y - 4, 8, 8);
                //this.graph.FillEllipse(blueBrush, p.X - 2, p.Y - 2, 4, 4);
            }

            //��ʹ����
            //foreach (PointF p in printPoint[13])
            //{
            //    PointF p1 = new PointF(p.X - 4, p.Y + (float)3.5);
            //    PointF p2 = new PointF(p.X + 4, p.Y + (float)3.5);
            //    PointF p3 = new PointF(p.X, p.Y - (float)3.5);
            //    this.graph.FillPolygon(Brushes.Black, new PointF[] { p1, p2, p3 });
            //}







            //Ҹ���������ཻ
            foreach (PointF p in printPoint[7])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawLine(bluePen, p.X - 2, p.Y - 2, p.X + 2, p.Y + 2);
                this.graph.DrawLine(bluePen, p.X + 2, p.Y - 2, p.X - 2, p.Y + 2);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);


            }

            //�ڱ��������ཻ
            foreach (PointF p in printPoint[8])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
                this.graph.FillEllipse(blueBrush, p.X - 2, p.Y - 2, 4, 4);

            }

            //�ر��������ཻ
            foreach (PointF p in printPoint[9])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(bluePen, p.X - 4, p.Y - 4, 8, 8);
                this.graph.FillEllipse(redBrush, p.X - 2, p.Y - 2, 4, 4);
                //��Ȧ����Ȧ
                //this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                //this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
                //this.graph.DrawEllipse(bluePen, p.X - 2, p.Y - 2, 4, 4);
            }

            //����
            foreach (PointF p in printPoint[10])
            {

                this.graph.DrawString("V", nineFont, redBrush, p.X - 4, p.Y - 8);
            }

            //����
            foreach (PointF p in printPoint[11])
            {
                this.graph.DrawString("H", nineFont, redBrush, p.X - 3, p.Y - 10);
            }

            printPoint[1].Clear();

            printPoint[2].Clear();

            printPoint[3].Clear();

            printPoint[4].Clear();

            printPoint[5].Clear();

            printPoint[6].Clear();

            printPoint[7].Clear();

            printPoint[8].Clear();

            printPoint[9].Clear();

            printPoint[10].Clear();

            printPoint[11].Clear();

            //printPoint[12].Clear();

            //printPoint[13].Clear();
        }

        /// <summary>
        /// ��ͨ���µ�ʱ���X������
        /// </summary>
        /// <param name="howDay">�ڼ���</param>
        /// <param name="howHour">�ڼ���</param>
        /// <returns>X����</returns>
        private float getX(int howDay, int howHour)
        {

            if (howHour >= 0 && howHour < 4)
            {
                howHour = 2;
            }
            else if ((howHour >= 4 && howHour < 8))
            {
                howHour = 6;
            }
            else if ((howHour >= 8 && howHour < 12))
            {
                howHour = 10;
            }
            else if ((howHour >= 12 && howHour < 16))
            {
                howHour = 14;
            }
            else if ((howHour >= 16 && howHour < 20))
            {
                howHour = 18;
            }
            else
            {
                howHour = 22;
            }
            if (howHour % 4 == 2)
            {
                return mainRec.Left + 100 + gridColsWidth / 2 + (howHour - 2) / 4 * gridColsWidth + howDay * dayWidth;
            }
            //if (howHour >= 0 && howHour < 6)
            //{
            //    howHour = 4;
            //}
            //else if ((howHour >= 6 && howHour < 10))
            //{
            //    howHour = 8;
            //}
            //else if ((howHour >= 10 && howHour < 14))
            //{
            //    howHour = 12;
            //}
            //else if ((howHour >= 14 && howHour < 18))
            //{
            //    howHour = 16;
            //}
            //else if ((howHour >= 18 && howHour < 22))
            //{
            //    howHour = 20;
            //}
            //else
            //{
            //    howHour = 24;
            //}
            //if (howHour % 4 == 0)
            //{
            //    return mainRec.Left + 100 + gridColsWidth / 2 + (howHour - 2) / 4 * gridColsWidth + howDay * dayWidth;
            //}
            //switch (howHour)
            //{
            //    case 2:
            //        return mainRec.Left + (float)107 + howDay * dayWidth;
            //    case 6:
            //        return mainRec.Left + (float)121 + howDay * dayWidth;
            //    case 10:
            //        return mainRec.Left + (float)135 + howDay * dayWidth;
            //    case 14:
            //        return mainRec.Left + (float)149 + howDay * dayWidth;
            //    case 18:
            //        return mainRec.Left + (float)163 + howDay * dayWidth;
            //    case 22:
            //        return mainRec.Left + (float)177 + howDay * dayWidth;
            //}
            return 0;
        }

        private void drawEvent(string eventString, RectangleF rec)
        {
            if (eventString.Length > 10)
            {
                rec.Height = 139;
                this.graph.DrawString(eventString, eightFont, redBrush, rec, textFormat);
            }
            else
            {
                char[] strArr = eventString.ToCharArray();
                for (int i = 0; i < strArr.Length; i++)
                {
                    this.graph.DrawString(strArr[i].ToString(), nineFont, redBrush, rec, textFormat);
                    rec.Y += 14;
                }
            }
        }

        #region ��ӡ���� סԺ����

        /// <summary>
        /// ��ӡ���� סԺ���� ����������
        /// </summary>
        private void printTime()
        {
            DataSet ds_Special = App.GetDataSet("select t.special,t.record_time from t_temperature_info t where t.patient_id=" + pid + " order by t.record_time asc");
            DateTime dtStart = this.startTime;
            RectangleF dateRec = new RectangleF(0, mainRec.Top, 6 * gridColsWidth, 20);
            string dateString = "";
            DataTable dtSurgery = null;
            DateTime systime = App.GetSystemTime();
            //������¼�ͷ����¼����
            if (dtSurgery == null)
            {
                dtSurgery = dbList[2];
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime oldTime = dtStart;     //�¸�ʱ��
                dateRec.X = mainRec.Left + 100 + i * 6 * gridColsWidth;
                dateRec.Y = mainRec.Top + 1-14;
                //if ((out_time < (i == 0 ? dtStart : dtStart.AddDays(1)) && out_time.Year > 2000) || (i == 0 ? dtStart > systime : dtStart.AddDays(1) > systime))
                //{
                //    return;
                //}
                if (i == 0)
                {
                    dateString = oldTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    oldTime = dtStart.AddDays(1);
                    if (oldTime.Month != dtStart.Month)
                    {
                        if (oldTime.Year != dtStart.Year)
                        {
                            dateString = oldTime.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            dateString = oldTime.ToString("MM-dd");
                        }
                    }
                    else
                    {
                        dateString = oldTime.ToString("dd");
                    }
                    dtStart = oldTime;
                }
                //���µ�����
                this.graph.DrawString(dateString, nineFont, brush, dateRec, textFormat);

                //��ͨ���µ�               


                dateRec.Y = mainRec.Top + 19; //��ӡheight
                //this.graph.DrawString(        //��ӡ����
                //    ((pageIndex - 1) * 7 + (i + 1)).ToString(), nineFont, brush, dateRec, textFormat);



                

                //סԺ����
                TimeSpan tsp = new TimeSpan();
                if (dtStart != null && user["��Ժ����:"] != "")
                {
                    tsp = Convert.ToDateTime(dtStart) - Convert.ToDateTime(Convert.ToDateTime(user["��Ժ����:"]).ToShortDateString());
                    int Days = tsp.Days + 1;
                    dateRec.Y = mainRec.Top + 20-14+1;
                    this.graph.DrawString(Days.ToString(), nineFont, brush, dateRec, textFormat);
                }
                /***
                 * ����������
                 */
                if (dtSurgery != null && dtSurgery.Rows.Count > 0)
                {
                    if (DateTime.Compare(dtStart, dtStart.AddDays(i)) < 1)
                    {
                        string surgeryDays = "";
                        for (int j = 0; j < dtSurgery.Rows.Count; j++)
                        {
                            DateTime dttimeRos = Convert.ToDateTime(Convert.ToDateTime(dtSurgery.Rows[j][0]).ToString("yyyy-MM-dd"));//���������¼���
                            TimeSpan abject = oldTime - dttimeRos; //
                            if (abject.Days >= 0 && abject.Days <= 14 && DateTime.Compare(dtStart, dttimeRos) >= 0)
                            {
                                int length = 0;
                                string[] surgerys = dtSurgery.Rows[j]["DESCRIBE"].ToString().Split('|');
                                foreach (string surgeryStr in surgerys)
                                {
                                    if (surgeryStr.Contains("����") || surgeryStr.Contains("����"))
                                    {
                                        length++;
                                    }
                                }
                                if (length > 0)
                                {
                                    if (abject.Days.ToString() == "0")
                                    {
                                        //�Ӱ�����ע�ͣ�����Ҫ��������
                                        //if (j > 0)
                                        //{
                                        //    //surgeryDays = surgeryDays + "(" + Convert.ToString(j + 1) + ")";
                                        //    //surgeryDays = NumberConvertToNoman(j + 1) + "-0";
                                        //    surgeryDays = NumberConvertToNoman(j + 1) + "/" + surgeryDays;
                                            
                                        //}
                                        //else
                                        //{
                                        //    surgeryDays = "";//II-0
                                        //}

                                    }
                                    else
                                    {
                                        if (surgeryDays != "")
                                        {
                                            surgeryDays = abject.Days.ToString() + "/" + surgeryDays;
                                        }
                                        else
                                        {
                                            surgeryDays = abject.Days.ToString();
                                        }
                                    }
                                }
                            }
                        }
                        if (surgeryDays.Length > 0)
                        {
                            dateRec.Y = mainRec.Top + 40-14+1;
                            this.graph.DrawString(surgeryDays, nineFont, redBrush, dateRec, textFormat);
                        }
                    }
                }
                //ҩ������Ĵ�ӡ Ѫ�Ǵ�ӡ
                if (user["����:"].ToString() == "���ƻ���Ԫ" || user["����:"].ToString() == "����")
                {
                    string val = "";
                    for (int i1 = 0; i1 < ds_Special.Tables[0].Rows.Count; i1++)
                    {
                        dateRec.Y = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight + 6 * bottomRosSpace;
                        if (startTime.AddDays(i) == Convert.ToDateTime(ds_Special.Tables[0].Rows[i1]["record_time"].ToString()))
                        {
                            if (ds_Special.Tables[0].Rows[i1]["special"].ToString() != "")
                            {
                                //����ǵ���д��e
                                val = ds_Special.Tables[0].Rows[i1]["special"].ToString();
                                this.graph.DrawString(val, nineFont, brush, dateRec, textFormat);
                                break;
                            }
                        }
                    }
                    if (i == 0)
                    {
                        this.graph.DrawString(val, nineFont, redBrush, dateRec, textFormat);
                    }
                }
            }
        }


        /// <summary>
        /// ��������ת��Ϊ��������
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string NumberConvertToNoman(int num)
        {
            string return_s = "";
            if (num <= 1)
                return_s = "";
            else if (num > 10)
                return_s = "��";
            else if (num >= 2 && num <= 10)
            {
                switch (num)
                {
                    case 2:
                        return_s = "��";
                        break;
                    case 3:
                        return_s = "��";
                        break;
                    case 4:
                        return_s = "��";
                        break;
                    case 5:
                        return_s = "��";
                        break;
                    case 6:
                        return_s = "��";
                        break;
                    case 7:
                        return_s = "��";
                        break;
                    case 8:
                        return_s = "��";
                        break;
                    case 9:
                        return_s = "��";
                        break;
                    case 10:
                        return_s = "��";
                        break;
                }
            }
            else
                return_s = "";
            return return_s;
        }

        #endregion

        #region ������ʱ��ת����ʱ��
        /// <summary>
        /// ������������ת��Ϊ���ļ���
        /// </summary>
        /// <param name="time">HH:mm</param>
        /// <returns></returns>
        public string ConvertText(string time)
        {
            string[] stringArr = time.Split(':');
            if (stringArr.Length > 1)
            {
                int temperHour = Convert.ToInt32(stringArr[0]);
                int temperMinute = Convert.ToInt32(stringArr[1]);
                if (temperMinute == 00)
                {
                    return NumForChinese(temperHour, 0) + "ʱ";
                }
                else
                {
                    return NumForChinese(temperHour, 0) + "ʱ" + NumForChinese(temperMinute, 1) + "��";
                }
            }
            return "";
        }

        public string NumForChinese(int number, int type)
        {
            string returnTime = "";
            if (number < 10)
            {
                if (type == 1)
                {
                    returnTime = "��";
                }
                if (number == 0)
                {
                    returnTime = "��";
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            returnTime += "һ";
                            break;
                        case 2:
                            returnTime += "��";
                            break;
                        case 3:
                            returnTime += "��";
                            break;
                        case 4:
                            returnTime += "��";
                            break;
                        case 5:
                            returnTime += "��";
                            break;
                        case 6:
                            returnTime += "��";
                            break;
                        case 7:
                            returnTime += "��";
                            break;
                        case 8:
                            returnTime += "��";
                            break;
                        case 9:
                            returnTime += "��";
                            break;
                    }
                }
            }
            else
            {
                switch (Convert.ToInt32(number.ToString().Substring(0, 1)))
                {
                    case 1:
                        returnTime = "ʮ";
                        break;
                    case 2:
                        returnTime = "��ʮ";
                        break;
                    case 3:
                        returnTime = "��ʮ";
                        break;
                    case 4:
                        returnTime = "��ʮ";
                        break;
                    case 5:
                        returnTime = "��ʮ";
                        break;
                }
                switch (Convert.ToInt32(number.ToString().Substring(1, 1)))
                {
                    case 1:
                        returnTime += "һ";
                        break;
                    case 2:
                        returnTime += "��";
                        break;
                    case 3:
                        returnTime += "��";
                        break;
                    case 4:
                        returnTime += "��";
                        break;
                    case 5:
                        returnTime += "��";
                        break;
                    case 6:
                        returnTime += "��";
                        break;
                    case 7:
                        returnTime += "��";
                        break;
                    case 8:
                        returnTime += "��";
                        break;
                    case 9:
                        returnTime += "��";
                        break;
                }
            }
            return returnTime;
        }
        #endregion

        #region �������ݲ�ѯ

        /// <summary>
        /// ����������7������
        /// </summary>
        /// <returns></returns>
        public List<DataTable> getChildTemperureCount(string startTime, string endTime, string pid)
        {
            List<DataTable> childList = new List<DataTable>();
            try
            {
                string sql = string.Format(" select child_id,cooling_value,measure_time,temperature_value,re_measure,describe,temp_state "
                                           + " from t_child_vital_signs "
                                           + " where to_char(measure_time,'yyyy-mm-dd') "
                                           + " between '{0}' "
                                           + " and '{1}' "
                                           + " and child_id = '{2}' "
                                           + " order by measure_time ", startTime, endTime, pid);
                string sql2 = string.Format(" select child_id, feed_style, icterus, stool_count, stool_color, umbilicalcord,COLOUR_FACE,BREATHE,CRY,REACTION,DIAPER,weight,NUTRUE_OTHERNAME,record_time "
                                          + " from t_child_temperature_info"
                                          + " where to_char(record_time,'yyyy-MM-dd')"
                                          + " between '{0}'"
                                          + " and '{1}'"
                                          + " and child_id = '{2}'"
                                          + " order by record_time", startTime, endTime, pid);
                string sql3 = string.Format("select NEWBORN_WEIGHT from T_NEW_BORN_PATIENT where id = '{0}'", pid);
                childList.Add(App.GetDataSet(sql).Tables[0]);
                childList.Add(App.GetDataSet(sql2).Tables[0]);
                childList.Add(App.GetDataSet(sql3).Tables[0]);
            }
            catch (Exception)
            {

                throw;
            }
            return childList;
        }

        /// <summary>
        /// ��ͨ���µ�7�������
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DataTable> GetTempertureCount(string inTime, string startTime, string endTime, string pid)
        {
            List<DataTable> list = new List<DataTable>();
            string sql = string.Format("select measure_time, " +
                                        "temperature_value, temperature_body, " +
                                        "re_measure, cooling_value, cooling_type," +
                                        "pulse_value, is_briefness, is_assist_hr, " +
                                        "breath_value, is_assist_br, measure_state, " +
                                        "describe, remark, heart_rhythm,PAIN_VALUE,PAIN_MOTHED from t_vital_signs " +
                                        "WHERE to_char(MEASURE_TIME,'yyyy-MM-dd') " +
                                        "BETWEEN '{0}' AND '{1}' AND PATIENT_ID = '{2}' ORDER BY MEASURE_TIME ASC", startTime, endTime, pid);

            string sql2 = string.Format("select stool_count, stool_state, clysis_count, stool_count_e,stool_count_f, " +
                                        "stool_amount, stool_amount_unit, stale_amount, is_catheter, weighttype, " +
                                        "weight, weight_unit, weight_special, length, sensi_test_code, sensi_test_result, " +
                                        "sensi_test_result_temp, record_id, record_time, in_amount, out_amount, out_amount1, " +
                                        "out_amount2, out_amount3, remark, bp_high, bp_low, bp_unit,out_other, bp_blood,SPECIAL,SPUTUM_QUANTITY,VOLUME_OF_DRAINAGE,VOMIT,URINE,URINE_STATE,SHIT_STATE,empty_name1,empty_value1,empty_name2,empty_value2,shit,empty_name3,empty_value3,empty_name4,empty_value4,empty_name5,empty_value5 from t_temperature_info " +
                                        "WHERE to_char(record_time,'yyyy-MM-dd') BETWEEN '{0}' AND '{1}' AND PATIENT_ID = '{2}' ORDER BY record_time", startTime, endTime, pid);

            string sql3 = string.Format("select measure_time,DESCRIBE from t_vital_signs " +
                                        "where (describe like '%����%' or describe like '%����%') " +
                                        "and PATIENT_ID ='{0}' " +
                                        "and to_char(MEASURE_TIME,'yyyy-MM-dd') BETWEEN '{1}' AND '{2}' " +
                                        "ORDER BY MEASURE_TIME ASC", pid, DateTime.Parse(inTime).ToString("yyyy-MM-dd"), endTime);
            try
            {
                list.Add(App.GetDataSet(sql).Tables[0]);
                list.Add(App.GetDataSet(sql2).Tables[0]);
                list.Add(App.GetDataSet(sql3).Tables[0]);
            }
            catch
            {
                return null;
            }
            //if (returnList != null && list.Count > 0)
            //{
            //    returnList(list);
            //}
            return list;
        }

        #endregion

        /// <summary>
        /// �ͷ��ڴ�
        /// </summary>
        public void printDispose()
        {
            blackPen.Dispose();
            redPen.Dispose();
            bluePen.Dispose();
            brush.Dispose();
            redBrush.Dispose();
            blueBrush.Dispose();
            whiteBrush.Dispose();
            tenFont.Dispose();
            nineFont.Dispose();
            //nineFont.Dispose();
            eightFont.Dispose();
            fillBrush.Dispose();
            textFormat.Dispose();
        }


        private string getzd(string his_id, int pageindex)
        {
            try
            {
                string sqlselect = "select * from diagnose_view@dbhislink where diagnosis_type=1 and diagnosis_no=1 and his_id='" + his_id + "' order by diagnosis_date desc";
                DataTable dt = App.GetDataSet(sqlselect).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["diagnosis_desc"].ToString();
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string getqrzd(string pid)
        {
            string sqlselect = "";
            string sql = "select * from T_Patients_Doc where textkind_id='121' and patient_id='" + pid + "'";
            DataTable dtsw = App.GetDataSet(sql).Tables[0];
            string sql2 = "select * from t_diagnose_item where diagnose_type=405 and patient_id='" + pid + "' order by diagnose_sort";
            DataTable dtxz = App.GetDataSet(sql2).Tables[0];
            if (dtsw.Rows.Count > 0)
            {
                sqlselect = "select * from t_diagnose_item where diagnose_type=407 and patient_id='" + pid + "'";
            }
            else if (dtxz.Rows.Count > 0)
            {
                sqlselect = sql2;
            }
            else
            {
                sqlselect = "select * from t_diagnose_item where diagnose_type=7923 and patient_id='" + pid + "'";
            }
            DataTable dt = App.GetDataSet(sqlselect).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["diagnose_name"].ToString();
            }
            return "";
        }


        private string getch(string rych)
        {
            int dqym = this.pageIndex;
            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            for (int i = dqym; i > 0; i--)
            {
                DateTime rydt = Convert.ToDateTime(user["��Ժ����:"]).AddDays(7 * (i - 1) - 1);
                DateTime bzdt = rydt.AddDays(7);
                string sql = "select b.bed_no from t_inhospital_action a inner join T_SickBedInfo b on a.bed_id=b.bed_id where  a.patient_id='" + user["���:"] + "' and to_char(a.happen_time,'yyyy-MM-dd') between '" + rydt.ToString("yyyy-MM-dd") + "' and  '" + bzdt.ToString("yyyy-MM-dd") + "' order by a.happen_time desc";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string zcch = ds.Tables[0].Rows[0]["bed_no"].ToString();
                    if (rych != zcch)
                    {
                        return zcch;
                    }
                }
            }
            return "";
        }

        private string getnewsection(string ryks)
        {
            int dqym = this.pageIndex;
            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            for (int i = dqym; i > 0; i--)
            {
                DateTime rydt = Convert.ToDateTime(user["��Ժ����:"]).AddDays(7 * (i - 1) - 1);
                DateTime bzdt = rydt.AddDays(7);
                DataTable dt = App.GetDataSet("select a.happen_time,b.section_name from T_Inhospital_Action a inner join t_sectioninfo b on a.sid=b.sid where a.patient_id='" + user["���:"] + "' and to_char(a.happen_time,'yyyy-MM-dd') between '" + rydt.ToString("yyyy-MM-dd") + "' and  '" + bzdt.ToString("yyyy-MM-dd") + "' and a.action_type='ת��'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    string dqks = dt.Rows[0]["section_name"].ToString();

                    if (ryks != dqks)
                    {
                        user["ת������:"] = dt.Rows[0]["happen_time"].ToString();
                        return dqks;
                    }
                }
            }
            return "";
        }

    }
}
