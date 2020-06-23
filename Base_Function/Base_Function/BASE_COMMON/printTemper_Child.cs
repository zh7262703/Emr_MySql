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
        private Pen blackPen = new Pen(Color.Black, 1);//黑笔
        private Pen lightblackPen = new Pen(Color.Gray, 0.1f);//黑笔
        private Pen redPen = new Pen(Color.Red, 1);    //红笔
        private Pen bluePen = new Pen(Color.Blue, 1);//网格
        private Brush brush = new SolidBrush(Color.Black);
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush whiteBrush = new SolidBrush(Color.White);
        private Font tenFont = new Font("宋体", 10f, FontStyle.Bold);
        private Font nineFont = new Font("宋体", 9f);
        private Font eightFont = new Font("宋体", 8f);
        //private Font eightBlodFont = new Font("宋体", 8f, FontStyle.Bold);
        private Font sevenFont = new Font("宋体", 7f);
        //private Font sevenBlodFont = new Font("宋体", 7f, FontStyle.Bold);
        private Font sixFont = new Font("宋体", 6f);
        private Brush fillBrush = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.FromArgb(0));


        private StringFormat textFormat = new StringFormat();
        private Dictionary<string, string> user = new Dictionary<string, string>();
        private Graphics _graph = null;
        private int mainChildTop = 0;
        private int mainTop = 0;
        private bool isChild = false;
        private int pageIndex = 0;
        private int topRows = 4;//表格上面行数
        private int topRowSpace = 20;
        private int gridRows = 40;//表格行数:一个大格5个数值
        private int gridRowsSpace = 14;
        private int bottomRows = 11;//表格下面竖线到的行数
        private int bottomRosSpace = 25;
        private int gridCols = 42;//表格列数:一个大格6个数值
        private int gridColsWidth = 14;
        private Rectangle headerRec = new Rectangle(40, -40, 660, 220); //40, 0, 660, 120
        private Rectangle mainRec;//y:130,height:910 //1080
        private Rectangle footerRec = new Rectangle(40, 1000, 660, 40);
        private Rectangle footerRecs = new Rectangle(300, 1000, 660, 40);
        private DateTime startTime; //开始时间
        private DateTime endTime;  //结束时间
        private string ToTime = string.Empty;   //入院时间
        private string pid = string.Empty; //病人ID
        public List<DataTable> dbList = null; //数据集合
        private Dictionary<int, List<PointF>> printPoint = null; //普通体温单点信息
        private const int dayWidth = 84;  // 一天的 宽度
        private const int hourWidth = 14; // 一个时间点宽度
        private string dcgDate;
        public DateTime out_time;
        public int pWidth = 800;
        public int pHeight = 1230;//850;
        ///呼吸行高度
        private int rHeight = 30;


        private bool breathUpFlag = false;        //呼吸的上下标志 true 上 false 下

        private bool painUpFlag = false;        //疼痛的上下标志 true 上 false 下

        DataSet ds_operaters = new DataSet();

        private ArrayList CutPoints = new ArrayList();




        /// <summary>
        /// 卡介苗时间
        /// </summary>
        public string DcgDate
        {
            get { return dcgDate; }
            set { dcgDate = value; }
        }

        private string dcgBatchno;
        /// <summary>
        /// 卡介苗批号
        /// </summary>
        public string DcgBatchno
        {
            get { return dcgBatchno; }
            set { dcgBatchno = value; }
        }

        private string hepatitsDate;
        /// <summary>
        /// 乙肝疫苗时间
        /// </summary>
        public string HepatitsDate
        {
            get { return hepatitsDate; }
            set { hepatitsDate = value; }
        }

        private string hepatitsBatchno;
        /// <summary>
        /// 乙肝疫苗批号
        /// </summary>
        public string HepatitsBatchno
        {
            get { return hepatitsBatchno; }
            set { hepatitsBatchno = value; }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 打印用户信息
        /// </summary>
        public Dictionary<string, string> User
        {
            get { return user; }
            set { user = value; }
        }

        private bool isDrawHeader = true;
        /// <summary>
        /// 是否打印页眉
        /// </summary>
        public bool IsDrawHeader
        {
            get { return isDrawHeader; }
            set { isDrawHeader = value; }
        }

        private bool isDrawFooter = true;
        /// <summary>
        /// 是否打印页脚
        /// </summary>
        public bool IsDrawFooter
        {
            get { return isDrawFooter; }
            set { isDrawFooter = value; }
        }

        private string _hospital;
        /// <summary>
        /// 医院名称
        /// </summary>
        public string Hospital
        {
            get { return _hospital; }
            set { _hospital = value; }
        }

        private string _textName;
        /// <summary>
        /// 文书名称
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
        ///// 主函数
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
             * 主体
             */
            if (dbList != null)
            {
                dbList.Clear();
            }
            printPoint = new Dictionary<int, List<PointF>>(); //普通体温单点信息
            printPoint.Add(1, new List<PointF>());  //腋表
            printPoint.Add(2, new List<PointF>());  //口表
            printPoint.Add(3, new List<PointF>());  //肛表
            printPoint.Add(4, new List<PointF>());  //脉搏
            printPoint.Add(5, new List<PointF>());  //心率
            printPoint.Add(6, new List<PointF>());  //降温后温度
            printPoint.Add(7, new List<PointF>());  //口表与脉搏相交
            printPoint.Add(8, new List<PointF>());  //腋表与脉搏相交
            printPoint.Add(9, new List<PointF>());  //肛表与脉搏相交
            printPoint.Add(10, new List<PointF>()); //复测
            //printPoint.Add(11, new List<PointF>()); //呼吸
            printPoint.Add(11, new List<PointF>()); //心率
            //printPoint.Add(13, new List<PointF>());//疼痛评分
            this.isChild = false;
            //mainTop = 792 + mainRec.Top; //
            this.pid = _pid;
            this.ToTime = _toTime;
            currPatient = DataInit.GetInpatientInfoByPid(pid);
            //string in_time = "入院_" + Convert.ToDateTime(user["入院日期:"]).ToString("24hh:mm");

            InitInOrOutTime();
        }

        /// <summary>
        /// 监测添加，出入院事件
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
                //                    "'" + user["床号:"].ToString() + "'," +
                //                    "'" + user["住院号:"].ToString() + "'," +
                //                    "to_TIMESTAMP('" + user["入院日期:"] + "','yyyy-MM-dd hh24:mi')," +
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
                // *入院事件自动添加
                // */
                //DataSet ds = App.GetDataSet("select id from t_vital_signs t where t.patient_id=" + pid + " and  t.describe like '入院%'");
                //if (ds.Tables[0].Rows.Count == 0)
                //{
                //    //还没有加入入院事件
                //    string in_time = "入院_" + Convert.ToDateTime(user["入院日期:"]).ToString("HH:mm");
                //    DateTime timpepoint = GetTimePoint(Convert.ToDateTime(user["入院日期:"].ToString()));
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
                //                    "'" + user["床号:"].ToString() + "'," +
                //                    "'" + user["住院号:"].ToString() + "'," +
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


                DateTime dtin = Convert.ToDateTime(user["入院日期:"]);
                DateTime dtinpoint = GetTimePoint(dtin);
                string describe = string.Empty;
                describe = "入院_" + dtin.ToString("HH:mm");
                //新生儿
                if (currPatient.PId.Contains("_"))
                {
                    dtin = Convert.ToDateTime(currPatient.Birthday);
                    dtinpoint = GetTimePoint(dtin);
                    describe = "出生_" + dtin.ToString("HH:mm");
                }
                DataSet ryds = App.GetDataSet("select id from t_vital_signs t where t.patient_id=" + pid + " and  (t.describe like '%入院%' or t.describe like '%出生%')");
                if (ryds.Tables[0].Rows.Count == 0)
                {
                    string sql = string.Empty;
                    //sql = "update T_VITAL_SIGNS t set t.describe=substr(t.describe,10) where t.patient_id=" + pid + " and  t.describe like '入院%'";
                    //if (currPatient.PId.Contains("_"))
                    //{
                    //    sql = "update T_VITAL_SIGNS t set t.describe=substr(t.describe,10) where t.patient_id=" + pid + " and  t.describe like '出生%'";
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

                DataSet zrds = App.GetDataSet("select a.happen_time from T_Inhospital_Action a where a.patient_id='" + user["编号:"].ToString() + "'  and a.action_type='转入'");

                if (zrds != null && zrds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < zrds.Tables[0].Rows.Count; i++)
                    {
                        string zr_time = "转入_" + Convert.ToDateTime(zrds.Tables[0].Rows[i]["happen_time"]).ToString("HH:mm");
                        DateTime dtout = Convert.ToDateTime(zrds.Tables[0].Rows[i]["happen_time"]);
                        DateTime dtoutpoint = GetTimePoint(dtout);
                        string str_zr = App.ReadSqlVal("select count(*) c from T_VITAL_SIGNS t where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')", 0, "c");
                        string zr_sql = string.Empty;
                        if (str_zr == null || str_zr == "0")//!str_zr.Contains("转入"))
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
                            if (str_zr == null || !str_zr.Contains("转入"))
                            {
                                zr_sql = "update T_VITAL_SIGNS t set t.describe='" + zr_time + "|'||t.describe where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')";
                                App.ExecuteSQL(zr_sql);
                            }
                        }
                    }
                }

                /*
                 * 出院事件自动添加
                 */
                DataSet ds = null;
                if (user["出院日期:"].ToString() != "")
                {
                    string out_h_time = "出院_" + Convert.ToDateTime(user["出院日期:"]).ToString("HH:mm");
                    DateTime dtout = Convert.ToDateTime(user["出院日期:"]);
                    DateTime dtoutpoint = GetTimePoint(dtout);
                    //该病人已经出院
                    ds = App.GetDataSet("select t.id from t_vital_signs t inner join t_in_patient ti on t.patient_id=ti.id where t.patient_id=" + pid + " and (t.describe like '%出院%' or t.describe like '%死亡%' or (instr(ti.pid,'_')>0 and t.describe like '%转出%'))");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        //DateTime timepoint = Convert.ToDateTime(user["出院日期:"].ToString());
                        ////出院但是还没有添加出院事件
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
                        //           "'" + user["床号:"].ToString() + "'," +
                        //           "'" + user["住院号:"].ToString() + "'," +
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

            #region 镇平
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
        ///普通体温单 主函数
        /// </summary>
        /// <param name="_graph">画图设备</param>
        /// <param name="_startTime">开始时间</param>
        /// <param name="_endTime">结束时间</param>
        /// <param name="_pid">病人id</param>
        /// <param name="_toTime">入院时间</param>
        /// <param name="_isChild">是否是新生儿</param>
        public void printMain(Graphics _graph, string _startTime, string _endTime)
        {

            string sql = "select t.measure_time,t.describe from T_VITAL_SIGNS t where t.describe like '%手术%'   and t.patient_id=" +
                          pid + " order by t.measure_time,t.describe asc";
            ds_operaters = App.GetDataSet(sql);

            this.graph = _graph;
            this.graph.SmoothingMode = SmoothingMode.AntiAlias;
            this.graph.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.startTime = Convert.ToDateTime(_startTime); //开始时间
            this.endTime = Convert.ToDateTime(_endTime);
            /***
             * 页眉
             */

            printHeader();
            dbList = null;
            dbList = GetTempertureCount(ToTime, startTime.ToString("yyyy-MM-dd"), endTime.ToString("yyyy-MM-dd"), this.pid);
            if (dbList == null)
            {
                App.Msg("数据库繁忙，稍后再试！");
                return;
            }
            printMain();
            /***
             *页脚
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
        /// 是否新页眉
        /// </summary>
        bool isNewheader = false;

        /// <summary>
        /// 打印页眉
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="graph"></param>
        private void printHeader()
        {
            Font userFont = new Font("宋体", 10f);
            Font hospitalFont = new Font("宋体", 16f, FontStyle.Bold);
            Font hospitalFont_EN = new Font("宋体", 9f, FontStyle.Bold);
            Font hospitalFont_L = new Font("宋体", 10f);
            Font textFont = new Font("宋体", 18f, FontStyle.Bold);
            Font titleFont = new Font("宋体", 15f, FontStyle.Bold);
            Font toptitleFont = new Font("黑体", 16f);
            Font toptitleFont1 = new Font("黑体", 12.5f);


            //TimeSpan ts = Convert.ToDateTime(user["入院日期:"]).Date - Convert.ToDateTime("2014-10-21");
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
                //graph.DrawString("延 安 市 妇 幼 保 健 院", toptitleFont1, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace + 20 + headerRec.Height / 4 - 20, headerRec.Width, headerRec.Height / 3), textFormat);
                graph.DrawString("新生儿体温单", titleFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace + 10 + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                //Image img=Resource.BookHead;
                //graph.DrawImage(img, new RectangleF(headerRec.Left+(headerRec.Width-198)/2, headerRec.Top - headerspace, 198, 52));
                string datestr = Convert.ToDateTime(user["入院日期:"]).ToString("yyyy-MM-dd");
                user["入院日期:"] = datestr;
                //string[] headlist = new string[] { "姓名", "入院日期", "诊断", "病区", "床号", "住院号" };
                string[] headlist = new string[] { "登记号", "姓名", "年龄", "性别", "科室", "床号", "入院日期", "住院号" };
                #region 注释

                //for (int i = 0; i < headlist.Length; i++)
                //{
                //    //登记号
                //    //if (i == 0)
                //    //{
                //    //    string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                //    //    graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300,//300 同住院号
                //    //        headerRec.Top - headerspace + 20 + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                //    //}
                //    if (i == 4)//床号
                //    {
                //        string inch = App.ReadSqlVal("select in_bed_no from t_in_patient where id='" + user["编号:"] + "'", 0, "in_bed_no");
                //        string dqch = getch(inch);
                //        string ch = user[headlist[4] + ":"];
                //        if (dqch != "")
                //        {
                //            ucTempratureEdit ucTE = new ucTempratureEdit();
                //            SizeF chW = ucTE.graphics.MeasureString("床号:", nineFont);
                //            SizeF ochW = ucTE.graphics.MeasureString(inch, nineFont);
                //            SizeF nchW = ucTE.graphics.MeasureString(dqch, nineFont);
                //            string itemtext = headlist[4] + ":" + inch;
                //            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 505, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //            itemtext = "↑";
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
                //    else if (i == 0)//姓名
                //    {
                //        string itemtext = headlist[0] + ":" + user[headlist[0] + ":"];
                //        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left - 20, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    }
                //    //else if (i == 3)//性别
                //    //{
                //    //    string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                //    //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    //}
                //    //else if (i == 4)//年龄
                //    //{
                //    //    string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                //    //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    //}
                //    else if (i == 1)//入院日期
                //    {
                //        string itemtext = headlist[1] + ":" + user[headlist[1] + ":"];
                //        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * 5 - 5, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //    }
                //    else if (i == 3)//病区
                //    {
                //        string oldsection = App.ReadSqlVal("select b.section_name from T_Inhospital_Action a inner join t_sectioninfo b on a.sid=b.sid where a.patient_id='" + user["编号:"] + "' and a.action_type='入区' order by a.happen_time", 0, "section_name");
                //        ////string oldsection = user["科室:"];
                //        //string newsection = getnewsection(oldsection);
                //        ////if (itemtext.Length > 11)
                //        ////{
                //        ////    itemtext = itemtext.Remove(itemtext.Length - 2);
                //        ////}
                //        //if (newsection != "")
                //        //{
                //        //    ucTempratureEdit ucTE = new ucTempratureEdit();
                //        //    SizeF chW = ucTE.graphics.MeasureString("科室:", nineFont);
                //        //    SizeF ochW = ucTE.graphics.MeasureString(oldsection, nineFont);
                //        //    SizeF nchW = ucTE.graphics.MeasureString(newsection, nineFont);
                //        //    string itemtext = "科室:" + oldsection;
                //        //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        //    itemtext = "↑";
                //        //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390 + chW.Width + ochW.Width / 2 - 8, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 12);
                //        //    itemtext = newsection;
                //        //    this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390 + chW.Width + ochW.Width / 2 - nchW.Width / 2, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                //        //}
                //        //else
                //        //{
                //            string itemtext = "科室" + ":" + oldsection;
                //            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + 390,
                //                headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        //}
                //    }
                //    else if (i == 5)//住院号
                //    {
                //        string itemtext = "病案号" + ":" + user[headlist[5] + ":"];
                //        //this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + -5+ gridColsWidth * (6 * i - 1), 
                //        //headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 320,
                //            headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 13,
                //            headerRec.Width, headerRec.Height / 3), textFormat);
                //    }
                //    else if (i == 2)//诊断
                //    {
                //        string ruzd = getzd(user["住院号:"], this.pageIndex);
                //        //string qrzd = getqrzd(user["编号:"]);
                //        //int height = 14;
                //        //int qrheight = 18;
                //        //if (qrzd.Length > 0 && ruzd != qrzd)
                //        //{
                //        //    ucTempratureEdit ucTE = new ucTempratureEdit();
                //        //    SizeF chW = ucTE.graphics.MeasureString("诊断:", nineFont);
                //        //    SizeF ochW = ucTE.graphics.MeasureString(ruzd, nineFont);
                //        //    SizeF nchW = ucTE.graphics.MeasureString(qrzd, nineFont);
                //        //    this.graph.DrawString("诊断:", userFont, brush, headerRec.Left + 205, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                //        //    this.graph.DrawString(ruzd, userFont, brush, new RectangleF(headerRec.Left + 235,
                //        //    headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 13,
                //        //    headerRec.Width - 500, headerRec.Height / 3), textFormat);
                //        //    if (ruzd.Length > 11)
                //        //    {
                //        //        height = 21;
                //        //    }
                //        //    this.graph.DrawString("↑", userFont, brush, headerRec.Left + 306, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - height);
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
                //            this.graph.DrawString("诊断:", userFont, brush, headerRec.Left + 205, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
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
                    {//"登记号",
                        //string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        //graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300,//300 同住院号
                        //headerRec.Top - headerspace + 20 + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                    }
                    else if (i == 1)
                    {//姓名
                        itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6), headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }
                    else if (i == 2)
                    {//年龄
                        //延安市妇幼保健院，页眉年龄特殊处理
                        if (headlist[i] == "年龄" && (user[headlist[i] + ":"].Contains("岁") && user[headlist[i] + ":"].Contains("月") || user[headlist[i] + ":"].Contains("月") && user[headlist[i] + ":"].Contains("天")))
                        {
                            string age_1 = "年龄:";          //年龄：余数
                            string age_2 = "";               //分子          
                            string age_3 = "";               //分母
                            string age_4 = "";               //单位

                            if (user[headlist[i] + ":"].Contains("岁"))
                            {
                                string[] age = user[headlist[i] + ":"].Split('岁');
                                age_1 += age[0];
                                age_2 = age[1].Split('月')[0];
                                age_3 = "12";
                                age_4 = "岁";
                            }
                            else
                            {
                                string[] age = user[headlist[i] + ":"].Split('月');
                                age_1 += age[0];
                                age_2 = age[1].Split('天')[0];
                                age_3 = "30";
                                age_4 = "月";
                            }
                          
                            //年龄：余数
                            this.graph.DrawString(age_1, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                            //分子
                            if (age_2.Length == 1)//一位和两位显示顺寻
                                this.graph.DrawString(age_2, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 45, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25 - 8);
                            else
                                this.graph.DrawString(age_2, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 42, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25 - 8);
                            //分数线
                            this.graph.DrawLine(blackPen, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 44, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 19, headerRec.Left + gridColsWidth * (6 * i - 8) + 30 + 60, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 19);
                            //分母
                            this.graph.DrawString(age_3, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30+42, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25+7);
                            //单位
                            this.graph.DrawString(age_4, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30+58, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                        }
                        else
                        {
                            itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                            this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 30, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                        }
                    }
                    else if (i == 3)
                    {//性别
                        itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 6) + 5, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }
                    else if (i == 4)
                    {//科室
                        string oldsection = App.ReadSqlVal("select INSECTION_NAME from t_in_patient where id='" + user["编号:"] + "'", 0, "INSECTION_NAME");

                        string newsection = getnewsection(oldsection);
                        if (newsection != "")
                        {
                            itemtext = "科室:" + newsection;
                        }
                        else
                        {
                            itemtext = "科室" + ":" + oldsection;
                        }

                        //string itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        //if (itemtext.Length > 11)
                        //{
                        //    itemtext = itemtext.Remove(itemtext.Length - 2);
                        //}
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }
                    else if (i == 5)
                    {//床号
                        string inch = App.ReadSqlVal("select in_bed_no from t_in_patient where id='" + user["编号:"] + "'", 0, "in_bed_no");
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
                    {//入院日期
                        itemtext = headlist[i] + ":" + user[headlist[i] + ":"];
                        this.graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) + 35, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6 - 25);
                    }

                    else if (i == 7)
                    {//住院号
                        itemtext = "住院号:" + user[headlist[i] + ":"];
                        //graph.DrawString(itemtext, userFont, brush, headerRec.Left + gridColsWidth * (6 * i - 8) - 10, headerRec.Top - headerspace + headerRec.Height / 6 * 4 + 6);
                        graph.DrawString(itemtext, userFont, brush, new RectangleF(headerRec.Left + 300, headerRec.Top - headerspace + headerRec.Height / 6 * 3 + 14 - 25, headerRec.Width, headerRec.Height / 3), textFormat);
                    }
                }
            }
            else
            {
                #region 老版界面加载    
                int headerspace = 2;
                graph.DrawString(this.Hospital, hospitalFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace, headerRec.Width, headerRec.Height / 3), textFormat);
                graph.DrawString("体 温 单", titleFont, brush, new RectangleF(headerRec.Left, headerRec.Top - headerspace + headerRec.Height / 4, headerRec.Width, headerRec.Height / 3), textFormat);
                string datestr = Convert.ToDateTime(user["入院日期:"]).ToString("yyyy-MM-dd");
                //string[] headlist = new string[] { "科别", "姓名", "性别", "床号", "住院号", "年龄", "诊断" };
                string[] headlist = new string[] { "床号", "姓名", "性别", "年龄", "入院日期", "病区", "住院号" };
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
        /// 打印页脚
        /// </summary>
        private void printFooter()
        {
            //第 {0} 周(页)
            graph.DrawString(string.Format("第 {0} 页", this.pageIndex), new Font("宋体", 12), brush, 330, 1004);//1044
        }


        /// <summary>
        /// 字体
        /// </summary>
        /// <param name="size"></param>
        /// <param name="isBold"></param>
        private Font getFont(string fontName, int size, FontStyle fontStyle)
        {
            return new Font(fontName, size, fontStyle);
        }

        /// <summary>
        /// 字体
        /// </summary>
        /// <param name="size">字体大小</param>        
        private Font getFont(string fontName, float size)
        {
            return new Font(fontName, size);
        }

        /// <summary>
        /// 设置对齐类型
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
        /// 体温单
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
        /// 普通体温单表格
        /// </summary>
        private void printGrid()
        {
            int leftwidth = 100;
            for (int i = 0; i < 42; i++)  //竖线
            {
                if (i % 6 == 0)
                {
                    blackPen.Width = 2f;
                    graph.DrawLine(blackPen, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top-14, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + 250 + rHeight);//25一行
                    blackPen.Width = 1f;
                }
                else
                {
                    graph.DrawLine(blackPen, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top + (topRows - 1) * topRowSpace-14, mainRec.Left + leftwidth + i * hourWidth, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight);
                    //画血压中间分割线
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
            for (int i = 1; i < gridRows; i++)  //横线
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
        /// 根据当前X坐标返回指定天日期
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
        /// 普通体温单字体
        /// </summary>
        private void printString()
        {
            //行间隔 18 

            //string[] strTemper = new string[] { "42","41", "40", "39", "38", "37", "36", "35" };
            //string[] strPulse = new string[] { "180", "160", "140", "120", "100", "80", "60", "40" };

            string[] strTemper = new string[] {"41", "40", "39", "38", "37", "36", "35" };
            string[] strPulse = new string[] {"160", "140", "120", "100", "80", "60", "40" };
            //string[] strRespire = new string[] { "50", "40", "30", "20", "10" };
            string[] strPainScore = new string[] { "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };
            string[] strTopCaption = new string[] { "日    期", "住院天数", "手术/分娩天数", "时    间" };
            for (int i = 0; i < topRows; i++)
            {
                //if (i == 2)
                //    this.graph.DrawString(strTopCaption[i], nineFont, brush, new RectangleF(mainRec.Left-4, mainRec.Top + i * topRowSpace - 14 + 2, 110, topRowSpace), textFormat);
                //else
                    this.graph.DrawString(strTopCaption[i], nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + i * topRowSpace - 14 + 2, 100, topRowSpace), textFormat);
            }
            //this.graph.DrawString("呼\n吸\n次/分", nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + topRows * topRowSpace, 33, 5*gridRowsSpace), textFormat);
            this.graph.DrawString("脉搏", nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + topRows * topRowSpace-12, 50, 14), textFormat);
            this.graph.DrawString("(次/分)", nineFont, brush, new RectangleF(mainRec.Left, mainRec.Top + topRows * topRowSpace, 50, 2* gridRowsSpace), textFormat);
            this.graph.DrawString("180", tenFont, brush, new RectangleF(mainRec.Left+20, mainRec.Top + topRows * topRowSpace+20, 30, gridRowsSpace), textFormat);
            //this.graph.DrawString("脉\n搏\n次/分", nineFont, brush, new RectangleF(mainRec.Left + 20, mainRec.Top + topRows * topRowSpace, 35, 5 * gridRowsSpace), textFormat);体温\n
            this.graph.DrawString("体温", nineFont, brush, new RectangleF(mainRec.Left + 55, mainRec.Top + topRows * topRowSpace-12, 50, 14), textFormat);
            this.graph.DrawString("(°C)", nineFont, brush, new RectangleF(mainRec.Left + 55, mainRec.Top + topRows * topRowSpace, 50, 2 * gridRowsSpace), textFormat);
            this.graph.DrawString("42", tenFont, brush, new RectangleF(mainRec.Left + 65, mainRec.Top + topRows * topRowSpace+20, 20,gridRowsSpace), textFormat);
            //this.graph.DrawString("疼\n痛\n评\n分", nineFont, brush, new RectangleF(mainRec.Left + 65, mainRec.Top + topRows * topRowSpace + 40 * gridRowsSpace, 20, 10 * gridRowsSpace), textFormat);


            int timeY = mainRec.Top + 58;
            //时间刻度
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int timepoit = 0;
                    timepoit = j * 4 + 2;
                    if (timepoit == 2 || timepoit == 18 || timepoit == 22)
                        //2,18,22点变红
                        this.graph.DrawString(timepoit.ToString(), eightFont, redBrush, new RectangleF(mainRec.Left + 100 + i * 6 * gridColsWidth + j * gridColsWidth - 1, mainRec.Top + 3 * topRowSpace-14, gridColsWidth + 2, topRowSpace), textFormat);
                    else
                        this.graph.DrawString(timepoit.ToString(), eightFont, brush, new RectangleF(mainRec.Left + 100 + i * 6 * gridColsWidth + j * gridColsWidth - 1, mainRec.Top + 3 * topRowSpace-14, gridColsWidth + 2, topRowSpace), textFormat);

                }
            }

            /*
             * 体温
             */
            int strArrTop = mainRec.Top + topRows * topRowSpace + 5 * gridRowsSpace + gridRowsSpace / 2;        
            for (int i = 0; i < strTemper.Length; i++) //strTemper.Length
            {
                this.graph.DrawString(strTemper[i], tenFont, brush, new RectangleF(mainRec.Left + 65, strArrTop - 5, 20, gridRowsSpace), textFormat);
                strArrTop = strArrTop + 5 * gridRowsSpace;
            }

            /*
             * 脉搏
             */
            //strArrTop = mainRec.Top + topRows * topRowSpace + 9 * gridRowsSpace +gridRowsSpace / 2;
            strArrTop = mainRec.Top + topRows * topRowSpace + 5 * gridRowsSpace + gridRowsSpace / 2;          
            for (int i = 0; i < strPulse.Length; i++)
            {
                this.graph.DrawString(strPulse[i], tenFont, brush, new RectangleF(mainRec.Left + 20, strArrTop - 5, 30, gridRowsSpace), textFormat);
                strArrTop = strArrTop + 5 * gridRowsSpace;
            }

            //呼吸
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

            //疼痛评分
            //strArrTop = mainRec.Top + topRows * topRowSpace + 39 * gridRowsSpace + gridRowsSpace / 2;
            //for (int i = 0; i < strPainScore.Length; i++)
            //{
            //    this.graph.DrawString(strPainScore[i], nineFont, brush, new RectangleF(mainRec.Left + 100 - gridColsWidth-1, strArrTop, gridColsWidth+2, gridRowsSpace), textFormat);
            //    strArrTop = strArrTop + gridRowsSpace;
            //}
            //DataTable tempers = dbList[0];
            //string PainMothed = "疼痛评分";
            //for (int i = 0; i < tempers.Rows.Count; i++)
            //{
            //    if (tempers.Rows[i]["PAIN_MOTHED"].ToString() != "")
            //    {
            //        PainMothed =PainMothed+"("+tempers.Rows[i]["PAIN_MOTHED"].ToString()+")";
            //        break;
            //    }
            //}


            strArrTop = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace;
            ///自定义行
            this.graph.DrawString("呼吸(次/分)", nineFont, brush, new RectangleF(mainRec.Left, strArrTop, 100, rHeight), textFormat);
            strArrTop += rHeight;
            //user[headlist[i]  入液量  出液量  
            string[] strBottomCaption;
            //if (user["病区:"].ToString() == "儿科护理单元" || user["病区:"].ToString() == "儿科")
            //{
            //    strBottomCaption = new string[] { "大  便(次)", "尿  量(ml)", "总入量(ml)", "总出量(ml)",  "血压(mmHg)","体  重(kg)",
            //                            "血糖(mmol/L)", strRowCaption1, strRowCaption2, strRowCaption3, strRowCaption4, strRowCaption5};
            //}
            //else
            //{
            //    string strRowCaption6 = "";
            //    strBottomCaption = new string[] { "大  便(次)", "尿  量(ml)", "总入量(ml)", "总出量(ml)",  "血压(mmHg)","体  重(kg)",
            //                             strRowCaption1, strRowCaption2, strRowCaption3, strRowCaption4, strRowCaption5,strRowCaption6};
            //}
            strBottomCaption = new string[] { "液入量","摄入量", 
                                              "尿量", 
                                              "呕吐",  
                                              "性状",
                                              "次数", 
                                              "体  重(kg)",
                                              "头  围(cm)","身  长(cm)","腹  围(cm)","注：呼吸 （用红笔以阿拉伯数字表述）正常便√ 稀便× 不消化○ 脓血便※ 胎粪△",""};
            this.graph.DrawString("入量(ml)", nineFont, brush, new RectangleF(mainRec.Left, strArrTop, 50, bottomRosSpace*2), textFormat);
            this.graph.DrawString("出量(ml)", nineFont, brush, new RectangleF(mainRec.Left, strArrTop + bottomRosSpace * 2, 50, bottomRosSpace * 2), textFormat);
            this.graph.DrawString("大便", nineFont, brush, new RectangleF(mainRec.Left, strArrTop + bottomRosSpace * 4, 50, bottomRosSpace * 2), textFormat);
            for (int i = 0; i < strBottomCaption.Length; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5)
                {
                    this.graph.DrawString(strBottomCaption[i], nineFont, brush, new RectangleF(mainRec.Left+50, strArrTop, 50, bottomRosSpace), textFormat);
                }
                else if(i==10)//标注行 全行显示
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
        /// 普通体温单布局线
        /// </summary>
        private void printLine()
        {
            
            #region 画横线
            int topspace = 20;            
            int topcount = 4;//时间行以上的横线
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

            ///呼吸行顶线
            ///加粗
            blackPen.Width = 2f;
            this.graph.DrawLine(blackPen, mainRec.Left, mainTop, mainRec.Right, mainTop);
            blackPen.Width = 1f;

            int bottomspace = 25;//行高
            int bottomcount = 11;//呼吸下方多少行
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

            #region 画竖线

            //体温单左线
            this.graph.DrawLine(blackPen, mainRec.Left, mainRec.Top + topRows * topRowSpace-14, mainRec.Left, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace);
            //体温脉搏中间分割线
            this.graph.DrawLine(blackPen, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace-14, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace);
            //延安妇幼新生儿 入出量、大便标题中间分割线
            this.graph.DrawLine(blackPen, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight, mainRec.Left + 55, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight+150);

            blackPen.Width = 2f;
            ///最左边线
            this.graph.DrawLine(blackPen, mainRec.Left, mainRec.Top-14, mainRec.Left, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + bottomspace * bottomcount+rHeight);//30一行
            ///最右边线
            this.graph.DrawLine(blackPen, mainRec.Right, mainRec.Top-14, mainRec.Right, mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + bottomspace * bottomcount + rHeight);//30一行
            blackPen.Width = 1f;


            #endregion
        }

        /// <summary>
        /// 普通体温单数据
        /// </summary>
        private void printData()
        {
            printTempers(); //生命体征
            printOther();   //其他信息
        }


        /// <summary>
        /// 获取手术次数
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
                //        if (dbList[0].Rows[i - 1]["describe"].ToString().Contains("手术"))
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
        /// 普通体温单生命体征
        /// </summary>
        private void printTempers()
        {
            DataTable tempers = dbList[0];             //生命体征数据
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
                float timeX = 0;    //X坐标
                float TY = 0;   //体温Y
                float PY = 0;   //脉搏Y
                float HY = 0;   //心率Y
                float BY = 0;   //呼吸Y
                float PainY = 0;   //疼痛评分Y

                float oldTX = 0;//体温X
                float oldTY = 0;//体温Y
                float oldPX = 0;//脉搏X
                float oldPY = 0;//脉搏Y
                float oldHX = 0;//心率X
                float oldHY = 0;//心率Y
                float oldBX = 0;//呼吸X
                float oldBY = 0;//呼吸Y
                float oldPainX = 0;//疼痛评分X
                float oldPainY = 0;//疼痛评分Y
                string measureState = string.Empty; //体温测量类型   

                List<PointF> pulse = new List<PointF>();  //脉搏短促
                List<PointF> heart = new List<PointF>();  //心率短促
                TimeSpan begin = new TimeSpan(this.startTime.Ticks);

                int heart_count = 0; //心率的个数
                int heart_index = 0; //心率的索引

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
                    DataRow currentRow = tempers.Rows[i]; //当前循环行
                    DateTime rowTime = Convert.ToDateTime(currentRow["measure_time"].ToString());//当前记录时间
                    measureState = currentRow["measure_state"].ToString(); //当前记录体温类别
                    string describe = currentRow["describe"].ToString();
                    /***
                     * 如果当前记录行的状态为已测
                     */
                    TimeSpan end = new TimeSpan(rowTime.Ticks);
                    TimeSpan beginToEnd = begin.Subtract(end).Duration();
                    timeX = getX(beginToEnd.Days, rowTime.Hour);       //X坐标

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
                            float.TryParse(temperString, out temperValue);       //体温
                        }
                        if (coolString != "")
                        {
                            float.TryParse(coolString, out coolValue);     //降温后体温
                        }
                        if (pulseString != "")
                        {
                            int.TryParse(pulseString, out pulseValue);     //脉搏
                        }
                        if (heartString != "")
                        {
                            int.TryParse(heartString, out heartValue);     //心率
                        }
                        if (breathString != "")
                        {
                            int.TryParse(breathString, out breathValue);   //呼吸                        
                        }
                        else
                        {
                            breathValue = -1;
                        }
                        if (painString != "")
                        {
                            int.TryParse(painString, out painValue);       //呼吸                        
                        }

                        /*
                         *脉搏 心率 短促 打印
                         */
                        #region  脉搏 心率 短促
                        if (pulseValue >= 20) //脉搏y坐标
                        {

                            //PY = (((180 - (float)pulseValue)) / 4 + 1) * (hourWidth - 2) + mainRec.Top + 63 + 268;
                            PY = ((180 - (float)pulseValue)) / 4 * gridRowsSpace + mainRec.Top + topRows * topRowSpace;
                            if (i > 0)
                            {
                                //float temperFront = 0;//定义上一个体温

                                //if (tempers.Rows[i - 1]["temperature_value"] != null)
                                //{
                                //    if (tempers.Rows[i - 1]["temperature_value"].ToString() != "")
                                //    {

                                //        temperFront = float.Parse(tempers.Rows[i - 1]["temperature_value"].ToString()); //上一个体温
                                //    }
                                //}
                                for (int m = 1; m <= i; m++)
                                {//判断上一个记录是否有不连线的事件
                                    if (tempers.Rows[i - m]["measure_state"] != null)
                                    {
                                        if (tempers.Rows[i - m]["measure_state"].ToString() != "" && tempers.Rows[i - m]["measure_state"].ToString() != "R")
                                        {
                                            float pulse_value = 0;//定义上一个脉搏
                                            if (tempers.Rows[i - m]["pulse_value"].ToString() != "")
                                            {
                                                pulse_value = float.Parse(tempers.Rows[i - m]["pulse_value"].ToString());
                                            }
                                            if (pulse_value >= 20 || tempers.Rows[i - m]["measure_state"].ToString() != "F")
                                            {//脉搏大于等于20或者事件不为F时候
                                                strss = tempers.Rows[i - m]["measure_state"].ToString();
                                                break;
                                            }
                                            string strsj = tempers.Rows[i - m]["describe"].ToString();
                                            if (pulse_value <= 20 && (strsj.Contains("手术") || strsj.Contains("分娩")))
                                            {
                                                oldPX = 0;
                                                oldPY = 0;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            string strsj = tempers.Rows[i - m]["describe"].ToString();
                                            float pulse_value = 0;//脉搏为空而且有手术、分娩的时候，不连线
                                            if (tempers.Rows[i - m]["pulse_value"].ToString() != "")
                                            {
                                                pulse_value = float.Parse(tempers.Rows[i - m]["pulse_value"].ToString());
                                            }
                                            if (pulse_value <= 20 && (strsj.Contains("手术") || strsj.Contains("分娩")))
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
                                {//读取前一个状态为F时打印直线
                                    //if (temperFront > 35 || temperFront == 0)
                                    //{
                                    printPulseLine(timeX, PY, oldPX, oldPY, pulseValue.ToString()); //打印直线
                                    //}
                                }
                            }
                            this.printPoint[4].Add(new PointF(timeX, PY));
                        }
                        if (heartValue >= 20)  //心率
                        {
                            HY = ((180 - (float)heartValue)) / 4 * gridRowsSpace + mainRec.Top + topRows * topRowSpace;
                            //HY = (((180 - (float)heartValue)) / 4 + 1) * (hourWidth - 2) + mainRec.Top + 63 + 268; //心率y坐标                            
                            if (i > 0)
                            {
                                for (int m = 1; m <= i; m++)
                                {
                                    if (tempers.Rows[i - m]["measure_state"] != null)
                                    {
                                        if (tempers.Rows[i - m]["measure_state"].ToString() != "" && tempers.Rows[i - m]["measure_state"].ToString() != "R")
                                        {
                                            float heart_rhythm = 0;//定义上一个心率
                                            if (tempers.Rows[i - m]["heart_rhythm"].ToString() != "")
                                            {
                                                heart_rhythm = float.Parse(tempers.Rows[i - m]["heart_rhythm"].ToString());
                                            }
                                            if (heart_rhythm >= 20 || tempers.Rows[i - m]["measure_state"].ToString() != "F")
                                            {//心率大于等于20或者事件不为F时候
                                                strss = tempers.Rows[i - m]["measure_state"].ToString();
                                                break;
                                            }

                                            string strsj = tempers.Rows[i - m]["describe"].ToString();
                                            if (strsj.Contains("手术") || strsj.Contains("分娩"))
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
                                {//读取前一个状态为F时打印直线
                                    printHeartLine(timeX, HY, oldHX, oldHY, reHeartMesure); ; //打印直线
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
                         *体温打印  上移5
                         */
                        if (temperValue > 0) //体温y坐标
                        {

                            int temperStyle = 1; //高温 不升 正常
                            if (temperValue <= 34)
                            {
                                temperValue = 34;
                                TY = mainRec.Top + topRows * topRowSpace + (42 - (float)temperValue) * 5 * gridRowsSpace;
                                this.graph.DrawString("↓", eightFont, Brushes.Blue, new RectangleF(timeX - gridColsWidth / 2 + 5, mainRec.Top + topRows * topRowSpace + gridRowsSpace * 35 - 12, gridColsWidth, gridRowsSpace * 2), textFormat);
                                //temperStyle = 2; //不升
                                //TY = mainRec.Top + 571;  //576
                            }
                            else if (temperValue >= 42)
                            {
                                temperStyle = 0;  //高温
                                TY = mainRec.Top + 81;
                            }
                            else
                            {
                                TY = mainRec.Top + topRows * topRowSpace + (42 - (float)temperValue) * 5 * gridRowsSpace;
                                //TY = ((42 - (float)temperValue) * 5 + 1) * (hourWidth - 2) + mainRec.Top + 63 + 56;
                            }
                            //TY = TY + gridRowsSpace * 5;
                            //画体温直线
                            if (i > 0)
                            {
                                for (int m = 1; m <= i; m++)
                                {
                                    if (tempers.Rows[i - m]["measure_state"].ToString() != "" && tempers.Rows[i - m]["measure_state"].ToString() != "R")
                                    {
                                        float temperature_value = 0;//定义上一个体温
                                        string temperature = tempers.Rows[i - m]["temperature_value"].ToString();
                                        if (temperature != "")
                                        {
                                            temperature_value = float.Parse(temperature);
                                        }
                                        if (temperature_value > 0 || tempers.Rows[i - m]["measure_state"].ToString() != "F")
                                        {//体温大于0或者事件不为F时候
                                            strss = tempers.Rows[i - m]["measure_state"].ToString();
                                            break;
                                        }
                                    }
                                    string strsj = tempers.Rows[i - m]["describe"].ToString();
                                    if (strsj.Contains("手术") || strsj.Contains("分娩"))
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
                                    {//读取前一个状态为F时打印直线

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

                            if (temperStyle == 2)//连接不升的直线
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
                         * 呼吸 打印
                         */

                        if (breathValue > 0) //打印呼吸
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
                         * 疼痛评分 打印
                         */

                        //if (painValue > 0) //打印呼吸
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
                         * 重设体温 脉搏 心率值 疼痛评分
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
                        printPurseBriefness(pulse, heart); //脉搏短促


                        if (this.printPoint[4].Count > 0)
                        {
                            pulse.Add(this.printPoint[4][this.printPoint[4].Count - 1]);
                        }
                    }

                    #region   事件
                    bool Eventbool = false;
                    if (evertx <= timeX)
                    {
                        evertx = timeX;
                    }

                    if (describe != "")
                    {
                        //if (describe.Contains("入院") && describe.Contains("手术"))
                        //{
                        //    string s1 = string.Empty;
                        //    string s2 = string.Empty;
                        //    string s3 = string.Empty;
                        //    foreach (string var in describe.Split('|'))
                        //    {
                        //        if (var.Contains("入院"))
                        //        {
                        //            s1 = var;
                        //        }
                        //        else if (var.Contains("手术"))
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
                            //if (var.Contains("入院") && var.Contains("手术"))
                            //{
                            //    dt1 = Convert.ToDateTime(var.Split('_')[1]);
                            //}
                            //else
                            //{
                            dt1 = Convert.ToDateTime(var.Substring(var.IndexOf('_') + 1));
                            //}
                            DateTime dt2 = Convert.ToDateTime(rowTime.ToString("HH:mm"));

                            if (DateTime.Compare(dt1, dt2) > 0 && !var.Contains("入院"))
                            {//事件时间比较,入院事件排最前面
                                if (Eventbool == false)
                                {//是否已经打印事件
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


                ////前点第一个点
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
                     * 没有断点
                     */

                    //尾点
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
                     * 有断点
                     */
                    //获取心率对应的断点
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


                    //前点
                    for (int i = 0; i < cutpointheadrs.Count; i++)
                    {
                        for (int k1 = 0; k1 < printPoint[4].Count; k1++)
                        {
                            if (printPoint[4][k1].X >= cutpointheadrs[i].X)
                            {
                                /*
                                 * 断点匹配排除断点
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
                                    //不为断点画前线
                                    this.graph.DrawLine(redPen, cutpointheadrs[i].X, cutpointheadrs[i].Y, printPoint[4][k1 - 1].X, printPoint[4][k1 - 1].Y);
                                }
                            }
                        }
                    }

                    //后点
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
                                        //画后点
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
        /// 事件打印
        /// </summary>
        /// <param name="evertx"></param>
        /// <param name="timeX"></param>
        /// <param name="measureState"></param>
        /// <param name="measureState"></param>
        private bool LQROEvent(float evertx, float timeX, string measureState, int hourWidth)
        {
            //延安妇幼  “请假”类事件是显示在体温35刻度之下 ，不与出入院类事件冲突，所以在有出入院类事件时不用后移一行
            //if (evertx <= timeX)
            //{
                evertx = timeX;
            //}
            //RectangleF otherCharRec = new RectangleF(evertx - 7, mainRec.Top + topRows * topRowSpace, hourWidth, hourWidth);
            RectangleF otherCharRec = new RectangleF(evertx - 7, mainRec.Top + topRows * topRowSpace + 35 * gridRowsSpace+1, hourWidth, hourWidth);//延安妇幼事件显示在35刻度下显示

            if (measureState == "W")
            {
                drawEvent("外出", otherCharRec);
                evertx += hourWidth;
            }
            else if (measureState == "L")
            {
                drawEvent("请假", otherCharRec);                
                evertx += hourWidth;
            }
            else if (measureState == "Q")
            {
                drawEvent("劝阻无效外出", otherCharRec);               
                evertx += hourWidth;
            }
            else if (measureState == "R")
            {
                drawEvent("拒测", otherCharRec);            
                evertx += hourWidth;
            }
            else if (measureState == "J")
            {
                drawEvent("外出检查", otherCharRec);
                evertx += hourWidth;
            }
            else if (measureState == "O")
            {
                drawEvent("私自外出", otherCharRec);             
                evertx += hourWidth;
            }
            else if (measureState == "T")
            {
                drawEvent("停测", otherCharRec);
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
                if (var.Contains("回家待产") || var.Contains("返院待产") || var.Contains("回家待术") || var.Contains("返院待术") || var.Contains("手术"))
                {
                    eventTimeString = eventTime[0];
                }
                else
                {
                    dateEvent = Convert.ToDateTime(eventTime[1]);
                    eventTimeString = eventTime[0] + (var.Contains("死亡") ? "于" : "|") + this.ConvertText(dateEvent.ToString("HH:mm"));
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
                //if (var.Contains("入院") && var.Contains("手术"))
                //{
                //    drawEventInAndOpeation(var, charRec);
                //}
                //else 
                //if (var.Contains("手术"))
                //{                   
                //    dateEvent = Convert.ToDateTime(eventTime[1]);
                //    eventTimeString = eventTime[0] + OpreaterTimes(measure_time) + "|" + this.ConvertText(dateEvent.ToString("HH:mm"));                 
                //}else
                if (var.Contains("回家待产") || var.Contains("返院待产") || var.Contains("回家待术") || var.Contains("返院待术")||var.Contains("手术"))//延安妇幼 手术 不显示时间
                {
                    eventTimeString = eventTime[0];
                }
                else
                {
                    dateEvent = Convert.ToDateTime(eventTime[1]);//(var.Contains("死亡") ? "于" : "|")
                    eventTimeString = eventTime[0] + "|" + this.ConvertText(dateEvent.ToString("HH:mm"));
                }
                drawEvent(eventTimeString, charRec);
            }
        }

        /// <summary>
        /// 入院和手术在时间点
        /// </summary>
        void drawEventInAndOpeation(string eventString, RectangleF rec)
        {
            string[] strs = eventString.Split('_');
            string s = "入院";
            string s2 = strs[1];
            s2 = ConvertText(s2);
            s = s + "·" + "手术" + s2;
            //s = s + s2 + " " + "手术";
            char[] strArr = s.ToCharArray();
            Font newfont = new Font("宋体", 8);//9
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
        /// 普通体温单其他信息
        /// </summary>
        private void printOther()
        {
            DataTable other = dbList[1];
            string str = string.Empty;
            float maxOther = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight;
            mainTop = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight;
            Dictionary<string, float> others = new Dictionary<string, float>();
            //空白行名称1
            string strEmptyItemName1 = "";
            ////空白行名称2
            string strEmptyItemName2 = "";
            ////空白行名称3
            string strEmptyItemName3 = "";
            for (int i = 0; i < other.Rows.Count; i++)
            {
                DataRow currentRow = other.Rows[i];
                DateTime rowTime = Convert.ToDateTime(Convert.ToDateTime(currentRow["record_time"]).ToString("yyyy-MM-dd"));
                TimeSpan begin = new TimeSpan(this.startTime.Ticks);
                TimeSpan end = new TimeSpan(rowTime.Ticks);
                TimeSpan beginToEnd = begin.Subtract(end).Duration();
                int timeX = mainRec.Left + 100 + beginToEnd.Days * gridColsWidth * 6; //X坐标
                RectangleF textRec = new RectangleF(timeX, 0, gridColsWidth * 6, bottomRosSpace);
                ///***
                // * 液入量  
                // */
                string in_amount = currentRow["in_amount"].ToString();
                if (in_amount != "")// && in_amount != "0")
                {
                    textRec.Y = mainTop + bottomRosSpace * 0;
                    this.graph.DrawString(in_amount, nineFont, brush, textRec, textFormat);
                }

                /***
                 * 摄入量
                 */
                string strEmpItemValue2 = currentRow["empty_value2"].ToString();
                if (strEmpItemValue2 != "")
                {
                    textRec.Y = mainTop + bottomRosSpace * 1;
                    this.graph.DrawString(strEmpItemValue2, nineFont, brush, textRec, textFormat);
                }
                
                /***
                 * 尿量
                 */
                string out_amout = currentRow["out_amount"].ToString();
                if (out_amout != "")// && out_amout != "0")
                {
                    textRec.Y = mainTop + bottomRosSpace * 2;
                    this.graph.DrawString(out_amout, nineFont, brush, textRec, textFormat);
                }

                /***
                * 呕吐
                */
                string strEmpItemValue3 = currentRow["empty_value3"].ToString();
                if (strEmpItemValue3 != "")
                {
                    textRec.Y = mainTop + bottomRosSpace * 3;
                    this.graph.DrawString(strEmpItemValue3, nineFont, brush, textRec, textFormat);
                }
                
                /*
                 * 特殊治疗 STOOL_AMOUNT 药物过敏
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
                 * 大便-性状
                 */
                textRec.Y = mainTop + bottomRosSpace * 4;
                #region old
                //string stool_state = currentRow["stool_state"].ToString(); //大便类型
                //if (stool_state == "N" || stool_state=="")
                //{
                //    string stool_count = currentRow["stool_count"].ToString();
                //    this.graph.DrawString(stool_count, nineFont, brush, textRec, textFormat);
                //}
                //else if (stool_state == "I")
                //{
                //    this.graph.DrawString("※", nineFont, brush, textRec, textFormat); //※
                //}
                //else if (stool_state == "G")
                //{
                //    this.graph.DrawString("☆", nineFont, brush, textRec, textFormat);
                //}
                //else if (stool_state == "E")
                //{
                //    this.graph.DrawString("※/E", nineFont, brush, textRec, textFormat); //※
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
                //    ////            stool_count_c += ",※";
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
                 * 大便-次数
                 */
                string strEmpItemValue4 = currentRow["empty_value4"].ToString();
                if (strEmpItemValue4 != "")
                {                    
                    textRec.Y = mainTop + bottomRosSpace * 5;
                    this.graph.DrawString(strEmpItemValue4, nineFont, brush, textRec, textFormat);
                }

                /*
                 *小便
                 */
                //textRec.Y = mainTop + bottomRosSpace * 3;
                //this.graph.DrawString(currentRow["urine"].ToString(), nineFont, brush, textRec, textFormat);


                //***
                // * 体重
                // */               
                string weight = currentRow["weight"].ToString();
                textRec.Y = mainTop + bottomRosSpace * 6;
                if (weight != "")// && weight != "0")
                {
                    this.graph.DrawString(weight, nineFont, brush, textRec, textFormat);
                }

                /***
                * 头围
                */
                string strEmpItemValue5 = currentRow["empty_value5"].ToString();
                if (strEmpItemValue5 != "")
                {
                    textRec.Y = mainTop + bottomRosSpace * 7;
                    this.graph.DrawString(strEmpItemValue5, nineFont, brush, textRec, textFormat);
                }

                //***
                // * 身高
                // */               
                string length = currentRow["length"].ToString();
                textRec.Y = mainTop + bottomRosSpace * 8;
                if (length != "")// && length != "0")
                {
                    this.graph.DrawString(length, nineFont, brush, textRec, textFormat);
                }

                /***
                 * 血压
                 */
                //string bp_blood = currentRow["bp_blood"].ToString();
                //if (bp_blood != "")
                //{
                //    string[] bloodArr = bp_blood.Split(',');
                //    RectangleF itemRec = textRec;
                //    //itemRec.Y = mainTop + bottomRosSpace * 4;
                //    itemRec.Y = mainTop;
                //    Font objfont = new Font("宋体", 7);
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

                ////空白行名称1
                Font EmptyItemNameFont = new Font("宋体", 7);

                //***
                // * 腹围--延安
                // */               
                string strEmpItemValue1 = currentRow["empty_value1"].ToString();
                textRec.Y = mainTop + bottomRosSpace * 9;
                if (strEmpItemValue1 != "")// && length != "0")
                {
                    this.graph.DrawString(strEmpItemValue1, nineFont, brush, textRec, textFormat);
                }
                //***
                // * 过敏药物--延安
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
                //        Font objfont = new Font("宋体", 7);
                //        this.graph.DrawString(strEmpItemValue4, objfont, brush, textRec, textFormat);
                //    }
                //    else if (strEmpItemValue4.Length < 10)
                //    {
                //        Font objfont = new Font("宋体", 6);
                //        this.graph.DrawString(strEmpItemValue4, objfont, brush, textRec, textFormat);
                //    }
                //    else if (strEmpItemValue4.Length < 11)
                //    {
                //        Font objfont = new Font("宋体", 5);
                //        this.graph.DrawString(strEmpItemValue4, objfont, brush, textRec, textFormat);
                //    }
                //    else
                //    {
                //        Font objfont = new Font("宋体",4);
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
                ////空白行值1
                //if (!string.IsNullOrEmpty(strEmptyItemName1))
                //{
                //    string strEmpItemValue1 = currentRow["empty_value1"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 7;
                //    this.graph.DrawString(strEmpItemValue1, nineFont, brush, textRec, textFormat);
                //}
                //空白行名称2
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
                //空白行值2
                //if (!string.IsNullOrEmpty(strEmptyItemName2))
                //{
                //    string strEmpItemValue2 = currentRow["empty_value2"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 9;
                //    this.graph.DrawString(strEmpItemValue2, nineFont, brush, textRec, textFormat);
                //}

                //空白名称3
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
                //空白行值3
                //if (!string.IsNullOrEmpty(strEmptyItemName3))
                //{
                //    string strEmpItemValue3 = currentRow["empty_value3"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 10;
                //    this.graph.DrawString(strEmpItemValue3, nineFont, brush, textRec, textFormat);
                //}

                ////空白名称4
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
                ////空白行值4
                //if (!string.IsNullOrEmpty(strEmptyItemName2))
                //{
                //    string strEmpItemValue2 = currentRow["empty_value4"].ToString();
                //    textRec.Y = mainTop + bottomRosSpace * 8;
                //    this.graph.DrawString(strEmpItemValue2, nineFont, brush, textRec, textFormat);
                //}

                ////空白名称5
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
                ////空白行值5
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
        /// 脉搏短促
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
        /// 普通体温单呼吸
        /// </summary>
        private void printBreath(float x, int hours, int breath, string IS_ASSIST_BR)
        {
            mainTop = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace+2;
            //呼吸机位置
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
                if (!breathUpFlag)//武汉三院呼吸是从下往上，其他地方是从上往下
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
        /// 普通体温单呼吸
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
        /// 普通体温单打印脉搏直线
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
        /// 普通体温单打印呼吸直线
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
        /// 普通体温单打印心率直线
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
            ////填充阴影区
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
        /// 普通体温单打印体温直线
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
        /// 普通体温单类型打印
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="temperStyle">0高温 1正常 2不升</param>
        /// <param name="temperType"></param>
        /// <param name="reMeasure"></param>
        private void printTypeTemper(float startX, float startY, int temperStyle, int temperType, string reMeasure, string val)
        {
            if (temperStyle == 0) //高温
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
                //    this.graph.DrawString("↓", eightFont, brush, startX - 5, startY + 16, StringFormat.GenericTypographic);
                this.graph.DrawString("不升", eightFont, Brushes.Blue, new RectangleF(startX - gridColsWidth / 2, mainRec.Top + topRows * topRowSpace + gridRowsSpace * 33, gridColsWidth, gridRowsSpace * 2), textFormat);
                //float coolY = mainRec.Top + topRows * topRowSpace + (35) * 5 * gridRowsSpace;
                //printCoolingTemper();
                ////画箭头
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
        /// 打印降温温度
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
        ///// 打印皮试
        ///// </summary>
        //private void printSkin(RectangleF rec, string value)
        //{
        //    int length = value.Length;
        //    if (value.Contains("阳性"))
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
        /// 打印各点
        /// </summary>
        private void printPoints()
        {
            //心率
            foreach (PointF p in printPoint[5])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
            }

            //脉搏
            foreach (PointF p in printPoint[4])
            {
                bool overlap = false;//是否和温度重叠
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


            ////呼吸
            //foreach (PointF p in printPoint[11])
            //{
            //    this.graph.FillEllipse(blueBrush, p.X - 3, p.Y - 3, 6, 6);
            //}

            //降温后温度
            foreach (PointF p in printPoint[6])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
            }
            //腋表
            foreach (PointF p in printPoint[1])
            {
                this.graph.DrawLine(bluePen, p.X - 3, p.Y - 3, p.X + 3, p.Y + 3);
                this.graph.DrawLine(bluePen, p.X + 3, p.Y - 3, p.X - 3, p.Y + 3);
            }

            //口表
            bluePen.Width = 2;
            foreach (PointF p in printPoint[2])
            {
                this.graph.FillEllipse(blueBrush, p.X - 4, p.Y - 4, 8, 8);
            }
            bluePen.Width = 1;

            //肛表
            foreach (PointF p in printPoint[3])
            {
                //黑点直径
                float d = 2f;
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.FillEllipse(blueBrush, p.X - d / 2, p.Y - d / 2, d, d);
                this.graph.DrawEllipse(bluePen, p.X - 4, p.Y - 4, 8, 8);
                //this.graph.FillEllipse(blueBrush, p.X - 2, p.Y - 2, 4, 4);
            }

            //疼痛评分
            //foreach (PointF p in printPoint[13])
            //{
            //    PointF p1 = new PointF(p.X - 4, p.Y + (float)3.5);
            //    PointF p2 = new PointF(p.X + 4, p.Y + (float)3.5);
            //    PointF p3 = new PointF(p.X, p.Y - (float)3.5);
            //    this.graph.FillPolygon(Brushes.Black, new PointF[] { p1, p2, p3 });
            //}







            //腋表与脉搏相交
            foreach (PointF p in printPoint[7])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawLine(bluePen, p.X - 2, p.Y - 2, p.X + 2, p.Y + 2);
                this.graph.DrawLine(bluePen, p.X + 2, p.Y - 2, p.X - 2, p.Y + 2);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);


            }

            //口表与脉搏相交
            foreach (PointF p in printPoint[8])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
                this.graph.FillEllipse(blueBrush, p.X - 2, p.Y - 2, 4, 4);

            }

            //肛表与脉搏相交
            foreach (PointF p in printPoint[9])
            {
                this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                this.graph.DrawEllipse(bluePen, p.X - 4, p.Y - 4, 8, 8);
                this.graph.FillEllipse(redBrush, p.X - 2, p.Y - 2, 4, 4);
                //红圈内蓝圈
                //this.graph.FillEllipse(whiteBrush, p.X - 4, p.Y - 4, 8, 8);
                //this.graph.DrawEllipse(redPen, p.X - 4, p.Y - 4, 8, 8);
                //this.graph.DrawEllipse(bluePen, p.X - 2, p.Y - 2, 4, 4);
            }

            //复测
            foreach (PointF p in printPoint[10])
            {

                this.graph.DrawString("V", nineFont, redBrush, p.X - 4, p.Y - 8);
            }

            //心率
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
        /// 普通体温单时间点X轴坐标
        /// </summary>
        /// <param name="howDay">第几天</param>
        /// <param name="howHour">第几点</param>
        /// <returns>X坐标</returns>
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

        #region 打印日期 住院日数

        /// <summary>
        /// 打印日期 住院日数 手术后天数
        /// </summary>
        private void printTime()
        {
            DataSet ds_Special = App.GetDataSet("select t.special,t.record_time from t_temperature_info t where t.patient_id=" + pid + " order by t.record_time asc");
            DateTime dtStart = this.startTime;
            RectangleF dateRec = new RectangleF(0, mainRec.Top, 6 * gridColsWidth, 20);
            string dateString = "";
            DataTable dtSurgery = null;
            DateTime systime = App.GetSystemTime();
            //手术记录和分娩记录集合
            if (dtSurgery == null)
            {
                dtSurgery = dbList[2];
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime oldTime = dtStart;     //下个时间
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
                //体温单天数
                this.graph.DrawString(dateString, nineFont, brush, dateRec, textFormat);

                //普通体温单               


                dateRec.Y = mainRec.Top + 19; //打印height
                //this.graph.DrawString(        //打印天数
                //    ((pageIndex - 1) * 7 + (i + 1)).ToString(), nineFont, brush, dateRec, textFormat);



                

                //住院天数
                TimeSpan tsp = new TimeSpan();
                if (dtStart != null && user["入院日期:"] != "")
                {
                    tsp = Convert.ToDateTime(dtStart) - Convert.ToDateTime(Convert.ToDateTime(user["入院日期:"]).ToShortDateString());
                    int Days = tsp.Days + 1;
                    dateRec.Y = mainRec.Top + 20-14+1;
                    this.graph.DrawString(Days.ToString(), nineFont, brush, dateRec, textFormat);
                }
                /***
                 * 手术后天数
                 */
                if (dtSurgery != null && dtSurgery.Rows.Count > 0)
                {
                    if (DateTime.Compare(dtStart, dtStart.AddDays(i)) < 1)
                    {
                        string surgeryDays = "";
                        for (int j = 0; j < dtSurgery.Rows.Count; j++)
                        {
                            DateTime dttimeRos = Convert.ToDateTime(Convert.ToDateTime(dtSurgery.Rows[j][0]).ToString("yyyy-MM-dd"));//手术分娩事件行
                            TimeSpan abject = oldTime - dttimeRos; //
                            if (abject.Days >= 0 && abject.Days <= 14 && DateTime.Compare(dtStart, dttimeRos) >= 0)
                            {
                                int length = 0;
                                string[] surgerys = dtSurgery.Rows[j]["DESCRIBE"].ToString().Split('|');
                                foreach (string surgeryStr in surgerys)
                                {
                                    if (surgeryStr.Contains("手术") || surgeryStr.Contains("分娩"))
                                    {
                                        length++;
                                    }
                                }
                                if (length > 0)
                                {
                                    if (abject.Days.ToString() == "0")
                                    {
                                        //延安妇幼注释，不需要罗马数字
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
                //药物过敏的打印 血糖打印
                if (user["病区:"].ToString() == "儿科护理单元" || user["病区:"].ToString() == "儿科")
                {
                    string val = "";
                    for (int i1 = 0; i1 < ds_Special.Tables[0].Rows.Count; i1++)
                    {
                        dateRec.Y = mainRec.Top + topRows * topRowSpace + gridRows * gridRowsSpace + rHeight + 6 * bottomRosSpace;
                        if (startTime.AddDays(i) == Convert.ToDateTime(ds_Special.Tables[0].Rows[i1]["record_time"].ToString()))
                        {
                            if (ds_Special.Tables[0].Rows[i1]["special"].ToString() != "")
                            {
                                //如果是当天写的e
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
        /// 手术次数转化为罗马数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string NumberConvertToNoman(int num)
        {
            string return_s = "";
            if (num <= 1)
                return_s = "";
            else if (num > 10)
                return_s = "Ⅺ";
            else if (num >= 2 && num <= 10)
            {
                switch (num)
                {
                    case 2:
                        return_s = "Ⅱ";
                        break;
                    case 3:
                        return_s = "Ⅲ";
                        break;
                    case 4:
                        return_s = "Ⅴ";
                        break;
                    case 5:
                        return_s = "Ⅵ";
                        break;
                    case 6:
                        return_s = "Ⅶ";
                        break;
                    case 7:
                        return_s = "Ⅷ";
                        break;
                    case 8:
                        return_s = "Ⅸ";
                        break;
                    case 9:
                        return_s = "Ⅹ";
                        break;
                    case 10:
                        return_s = "Ⅺ";
                        break;
                }
            }
            else
                return_s = "";
            return return_s;
        }

        #endregion

        #region 将数字时间转中文时间
        /// <summary>
        /// 将阿拉伯数字转换为中文简体
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
                    return NumForChinese(temperHour, 0) + "时";
                }
                else
                {
                    return NumForChinese(temperHour, 0) + "时" + NumForChinese(temperMinute, 1) + "分";
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
                    returnTime = "零";
                }
                if (number == 0)
                {
                    returnTime = "零";
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            returnTime += "一";
                            break;
                        case 2:
                            returnTime += "二";
                            break;
                        case 3:
                            returnTime += "三";
                            break;
                        case 4:
                            returnTime += "四";
                            break;
                        case 5:
                            returnTime += "五";
                            break;
                        case 6:
                            returnTime += "六";
                            break;
                        case 7:
                            returnTime += "七";
                            break;
                        case 8:
                            returnTime += "八";
                            break;
                        case 9:
                            returnTime += "九";
                            break;
                    }
                }
            }
            else
            {
                switch (Convert.ToInt32(number.ToString().Substring(0, 1)))
                {
                    case 1:
                        returnTime = "十";
                        break;
                    case 2:
                        returnTime = "二十";
                        break;
                    case 3:
                        returnTime = "三十";
                        break;
                    case 4:
                        returnTime = "四十";
                        break;
                    case 5:
                        returnTime = "五十";
                        break;
                }
                switch (Convert.ToInt32(number.ToString().Substring(1, 1)))
                {
                    case 1:
                        returnTime += "一";
                        break;
                    case 2:
                        returnTime += "二";
                        break;
                    case 3:
                        returnTime += "三";
                        break;
                    case 4:
                        returnTime += "四";
                        break;
                    case 5:
                        returnTime += "五";
                        break;
                    case 6:
                        returnTime += "六";
                        break;
                    case 7:
                        returnTime += "七";
                        break;
                    case 8:
                        returnTime += "八";
                        break;
                    case 9:
                        returnTime += "九";
                        break;
                }
            }
            return returnTime;
        }
        #endregion

        #region 体温数据查询

        /// <summary>
        /// 新生儿体温7天数据
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
        /// 普通体温单7天的体温
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
                                        "where (describe like '%手术%' or describe like '%分娩%') " +
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
        /// 释放内存
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
                DateTime rydt = Convert.ToDateTime(user["入院日期:"]).AddDays(7 * (i - 1) - 1);
                DateTime bzdt = rydt.AddDays(7);
                string sql = "select b.bed_no from t_inhospital_action a inner join T_SickBedInfo b on a.bed_id=b.bed_id where  a.patient_id='" + user["编号:"] + "' and to_char(a.happen_time,'yyyy-MM-dd') between '" + rydt.ToString("yyyy-MM-dd") + "' and  '" + bzdt.ToString("yyyy-MM-dd") + "' order by a.happen_time desc";
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
                DateTime rydt = Convert.ToDateTime(user["入院日期:"]).AddDays(7 * (i - 1) - 1);
                DateTime bzdt = rydt.AddDays(7);
                DataTable dt = App.GetDataSet("select a.happen_time,b.section_name from T_Inhospital_Action a inner join t_sectioninfo b on a.sid=b.sid where a.patient_id='" + user["编号:"] + "' and to_char(a.happen_time,'yyyy-MM-dd') between '" + rydt.ToString("yyyy-MM-dd") + "' and  '" + bzdt.ToString("yyyy-MM-dd") + "' and a.action_type='转入'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    string dqks = dt.Rows[0]["section_name"].ToString();

                    if (ryks != dqks)
                    {
                        user["转入日期:"] = dt.Rows[0]["happen_time"].ToString();
                        return dqks;
                    }
                }
            }
            return "";
        }

    }
}
