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
using TempertureEditor.Element;
using TempertureEditor;

namespace Base_Function.BASE_COMMON
{
    public class printTemperDataLoad
    {
        public TempertureEditor.Element.Page currentpage = new TempertureEditor.Element.Page(); //当前页

       
        private Dictionary<string, string> user = new Dictionary<string, string>();
        private int pageIndex = 0;
        private int leftwidth = 110;//左边第一列宽度
        private int gridColsWidth = 12;//宽度
        private Rectangle mainRec;//y:130,height:910 //1080
        private DateTime startTime; //开始时间
        private DateTime endTime;  //结束时间
        private string ToTime = string.Empty;   //入院时间
        private string pid = string.Empty; //病人ID
        public List<DataTable> dbList = null; //数据集合
        private const int dayWidth = 72;  // 一天的 宽度
        private const int hourWidth = 12; // 一个时间点宽度
        public DateTime out_time;

        DataSet ds_operaters = new DataSet();
        InPatientInfo currPatient;

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


        public void Init(string _pid, string _toTime)
        {
            /***
             * 主体
             */
            if (dbList != null)
            {
                dbList.Clear();
            }
            this.pid = _pid;
            this.ToTime = _toTime;
            currPatient = DataInit.GetInpatientInfoByPid(pid);

            InitInOrOutTime();
        }

        /// <summary>
        /// 监测添加，出入院事件
        /// </summary>
        private void InitInOrOutTime()
        {
            try
            {
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
        public void printMain(string _startTime, string _endTime)
        {

            string sql = "select t.measure_time,t.describe from T_VITAL_SIGNS t where t.describe like '%手术%'   and t.patient_id=" +
                          pid + " order by t.measure_time,t.describe asc";
            ds_operaters = App.GetDataSet(sql);

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

        /// <summary>
        /// 打印页眉
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="graph"></param>
        private void printHeader()
        {
            string datestr = Convert.ToDateTime(user["入院日期:"]).ToString("yyyy-MM-dd");
            user["入院日期:"] = datestr;
            string[] headlist = new string[] { "姓名", "年龄", "性别", "诊断", "病房", "床号", "入院日期", "住院号" };

            for (int i = 0; i < headlist.Length; i++)
            {
                string itemtext = "";
                if (i == 0)
                {//"姓名",
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbxm = new ClsDataObj();
                    tojbxm.Val = itemtext;
                    tojbxm.Rdatatime = "";
                    tojbxm.Typename = "姓名";
                    tojbxm.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbxm);
                }
                else if (i == 1)
                {//年龄
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbAge = new ClsDataObj();
                    tojbAge.Val = itemtext;
                    tojbAge.Rdatatime = "";
                    tojbAge.Typename = "年龄";
                    tojbAge.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbAge);
                }
                else if (i == 2)
                {//性别
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbSex = new ClsDataObj();
                    tojbSex.Val = itemtext;
                    tojbSex.Rdatatime = "";
                    tojbSex.Typename = "性别";
                    tojbSex.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbSex);
                }
                else if (i == 3)
                {//诊断
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbDiag = new ClsDataObj();
                    tojbDiag.Val = itemtext;
                    tojbDiag.Rdatatime = "";
                    tojbDiag.Typename = "诊断";
                    tojbDiag.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbDiag);
                }
                else if (i == 4)
                {//病房就是病人科室
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbSickRoom = new ClsDataObj();
                    tojbSickRoom.Val = itemtext;
                    tojbSickRoom.Rdatatime = "";
                    tojbSickRoom.Typename = "科室";
                    tojbSickRoom.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbSickRoom);
                }
                else if (i == 5)
                {//床号
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbBedNo = new ClsDataObj();
                    tojbBedNo.Val = itemtext;
                    tojbBedNo.Rdatatime = "";
                    tojbBedNo.Typename = "床位";
                    tojbBedNo.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbBedNo);
                }
                else if (i == 6)
                {//入院日期
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbInTime = new ClsDataObj();
                    tojbInTime.Val = itemtext;
                    tojbInTime.Rdatatime = "";
                    tojbInTime.Typename = "入院时间";
                    tojbInTime.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbInTime);
                }
                else if (i == 7)
                {//住院号
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbPid = new ClsDataObj();
                    tojbPid.Val = itemtext;
                    tojbPid.Rdatatime = "";
                    tojbPid.Typename = "住院号";
                    tojbPid.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbPid);
                }
            }
        }

        
        /// <summary>
        /// 打印页脚
        /// </summary>
        private void printFooter()
        {
            ClsDataObj tojbPageNum = new ClsDataObj();
            tojbPageNum.Val = this.pageIndex.ToString();
            tojbPageNum.Rdatatime = "";
            tojbPageNum.Typename = "页码";
            tojbPageNum.setdataxy(currentpage.Starttime);
            currentpage.Objs.Add(tojbPageNum);
        }

        /// <summary>
        /// 体温单
        /// </summary>
        public void printMain()
        {
            mainRec = new Rectangle(64, 134, 614, 880);

            printTime();
            printData();

            dbList.Clear();
        }


        /// <summary>
        /// 根据当前X坐标返回指定天日期
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public DateTime GetSelectDay(int x)
        {
            DateTime nowTime=App.GetSystemTime();
            for (int i = 1; i <= 7; i++)
            {
                int objWidth = 38;
                if (x >= mainRec.Left + leftwidth + objWidth + (i - 1) * 6 * gridColsWidth && x < mainRec.Left + objWidth + leftwidth + i * 6 * gridColsWidth)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        if (x >= mainRec.Left + leftwidth + objWidth + (i - 1) * 6 * gridColsWidth + (j - 1) * gridColsWidth && x < mainRec.Left + objWidth + leftwidth + (i - 1) * 6 * gridColsWidth + j * gridColsWidth)
                        {
                            DateTime dtime = startTime.AddDays(i - 1).Date;
                            if (dtime.Date > nowTime.Date)
                            {
                                return nowTime;
                            }
                            switch (j)
                            {//2.6.10.14.18.22
                                case 1:
                                    return dtime.AddHours(2);
                                case 2:
                                    return dtime.AddHours(6);
                                case 3:
                                    return dtime.AddHours(10);
                                case 4:
                                    return dtime.AddHours(14);
                                case 5:
                                    return dtime.AddHours(18);
                                case 6:
                                    return dtime.AddHours(22);
                            }
                        }
                    }
                }
            }
            return nowTime;
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
        /// 普通体温单生命体征
        /// </summary>
        private void printTempers()
        {
            DataTable tempers = dbList[0];             //生命体征数据

            if (tempers.Rows.Count > 0)
            {
                string measureState = string.Empty; //体温测量类型   
                string IS_ASSIST_BR = string.Empty;//呼吸辅助器

                TimeSpan begin = new TimeSpan(this.startTime.Ticks);
                string is_qixian = string.Empty;//是否骑线

                for (int i = 0; i < tempers.Rows.Count; i++)
                {
                    DataRow currentRow = tempers.Rows[i]; //当前循环行
                    string IS_ASSIST_BR_old = i > 0 ? tempers.Rows[i - 1]["IS_ASSIST_BR"].ToString() : "";//上一行呼吸辅助器
                    DateTime rowTime = Convert.ToDateTime(currentRow["measure_time"].ToString());//当前记录时间
                    string measureTime = rowTime.ToString("yyyy-MM-dd HH:mm:ss");
                    measureState = currentRow["measure_state"].ToString(); //当前记录体温类别
                    string describe = currentRow["describe"].ToString();
                    IS_ASSIST_BR = currentRow["IS_ASSIST_BR"].ToString();
                    is_qixian = currentRow["is_qixian"].ToString();//是否骑线
                    /***
                     * 如果当前记录行的状态为已测
                     */

                    if (measureState != "R")
                    {
                        float temperValue = 0;
                        float coolValue = 0;
                        int pulseValue = 0;
                        int heartValue = 0;
                        int breathValue = 0;
                        int painValue = -1;
                        int painValue2 = -1;

                        string temperString = currentRow["temperature_value"].ToString();//体温
                        string coolString = currentRow["cooling_value"].ToString();      //降温后体温
                        string pulseString = currentRow["pulse_value"].ToString();       //脉搏
                        string heartString = currentRow["heart_rhythm"].ToString();      //心率
                        string breathString = currentRow["breath_value"].ToString();     //呼吸 
                        string painString = currentRow["PAIN_VALUE"].ToString();         //疼痛 
                        string pain2String = currentRow["PAIN_VALUE2"].ToString();       //疼痛复值 
                        string reMeasure = currentRow["re_measure"].ToString();          //复测标志
                        string reHeartMesure = currentRow["is_assist_hr"].ToString();
                        int temprtType = Convert.ToInt32(currentRow["temperature_body"]);//腋表、口表、肛表
                        

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
                            int.TryParse(painString, out painValue);       //疼痛                       
                        }
                        if (pain2String != "")
                        {
                            int.TryParse(pain2String, out painValue2);       //疼痛复值                       
                        }

                        #region 体温

                        if (temperValue > 0 && temperValue < 35)
                        {
                            ClsDataObj tojbtemp = new ClsDataObj();
                            tojbtemp.Val = "不升";
                            tojbtemp.Rdatatime = measureTime;
                            tojbtemp.Typename = "体温不升";
                            tojbtemp.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbtemp);
                        }
                        else if (temperValue >= 35)
                        {
                            if (reMeasure == "Y")
                            {
                                if (temprtType == 0) //腋表
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "腋温复测骑线";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "腋温复测";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                }
                                else if (temprtType == 1) //口表
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "口温复测骑线";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "口温复测";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                }
                                else //肛表
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "肛温复测骑线";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "肛温复测";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                }
                            }
                            else
                            {
                                if (temprtType == 0) //腋表
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "腋温骑线";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "腋温";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                }
                                else if (temprtType == 1) //口表
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "口温骑线";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "口温";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                }
                                else //肛表
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "肛温骑线";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "肛温";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                }
                            }
                        }

                        if (coolValue > 33 && coolValue < 42)
                        {
                            if (is_qixian == "Y")
                            {
                                ClsDataObj tojbcool = new ClsDataObj();
                                tojbcool.Val = coolValue.ToString();
                                tojbcool.Rdatatime = measureTime;
                                tojbcool.Typename = "体温↓骑线";
                                tojbcool.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbcool);
                            }
                            else
                            {
                                ClsDataObj tojbcool = new ClsDataObj();
                                tojbcool.Val = coolValue.ToString();
                                tojbcool.Rdatatime = measureTime;
                                tojbcool.Typename = "体温↓";
                                tojbcool.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbcool);
                            }
                        }
                        #endregion

                        #region 脉搏

                        if (pulseValue > 0)
                        {
                            if (is_qixian == "Y")
                            {
                                ClsDataObj tojbpulse = new ClsDataObj();
                                tojbpulse.Val = pulseValue.ToString();
                                tojbpulse.Rdatatime = measureTime;
                                tojbpulse.Typename = "脉搏骑线";
                                tojbpulse.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbpulse);
                            }
                            else
                            {
                                ClsDataObj tojbpulse = new ClsDataObj();
                                tojbpulse.Val = pulseValue.ToString();
                                tojbpulse.Rdatatime = measureTime;
                                tojbpulse.Typename = "脉搏";
                                tojbpulse.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbpulse);
                            }
                        }
                        #endregion

                        #region 心率

                        if (heartValue > 0)
                        {
                            if (is_qixian == "Y")
                            {
                                ClsDataObj tojbheart = new ClsDataObj();
                                tojbheart.Val = heartValue.ToString();
                                tojbheart.Rdatatime = measureTime;
                                tojbheart.Typename = "心率骑线";
                                tojbheart.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbheart);
                            }
                            else
                            {
                                ClsDataObj tojbheart = new ClsDataObj();
                                tojbheart.Val = heartValue.ToString();
                                tojbheart.Rdatatime = measureTime;
                                tojbheart.Typename = "心率";
                                tojbheart.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbheart);
                            }
                        }

                        #endregion 

                        #region 呼吸

                        if (breathValue >= 0)
                        {
                            if (IS_ASSIST_BR == "Y")
                            {
                                if (is_qixian == "Y")
                                {
                                    ClsDataObj tojbassbr = new ClsDataObj();
                                    tojbassbr.Val = breathValue.ToString();
                                    tojbassbr.Rdatatime = measureTime;
                                    tojbassbr.Typename = "人工呼吸骑线";
                                    tojbassbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbassbr);
                                }
                                else
                                {
                                    ClsDataObj tojbassbr = new ClsDataObj();
                                    tojbassbr.Val = breathValue.ToString();
                                    tojbassbr.Rdatatime = measureTime;
                                    tojbassbr.Typename = "人工呼吸";
                                    tojbassbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbassbr);
                                }
                            }
                            else
                            {
                                if (is_qixian == "Y")
                                {
                                    ClsDataObj tojbbr = new ClsDataObj();
                                    tojbbr.Val = breathValue.ToString();
                                    tojbbr.Rdatatime = measureTime;
                                    tojbbr.Typename = "呼吸骑线";
                                    tojbbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbbr);
                                }
                                else
                                {
                                    ClsDataObj tojbbr = new ClsDataObj();
                                    tojbbr.Val = breathValue.ToString();
                                    tojbbr.Rdatatime = measureTime;
                                    tojbbr.Typename = "呼吸";
                                    tojbbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbbr);
                                }
                            }

                            ClsDataObj tojbbrs = new ClsDataObj();
                            tojbbrs.Val = breathValue.ToString();
                            tojbbrs.Rdatatime = measureTime;
                            tojbbrs.Typename = "呼吸S";
                            tojbbrs.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbbrs);
                        }

                        #endregion
                    }
                    else
                    {}

                    #region   事件
                    
                    if (describe != "")
                    {
                        //1、 同一格如有多个事件，显示方式为同一格上下显示。不跨格
                        string s1 = string.Empty;
                        string s2 = string.Empty;
                        foreach (string var in describe.Split('|'))
                        {
                            if (var == "" || var.IndexOf('_') == -1)
                            {
                                continue;
                            }
                            string[] eventTime = var.Split('_');
                            string eventT = eventTime[0];
                            if (eventT.Contains("入院"))
                            {
                                s1 = eventT;
                            }
                            else if (!eventT.Contains("手术") && !eventT.Contains("分娩"))
                            {
                                if (!string.IsNullOrEmpty(s1) || !string.IsNullOrEmpty(s2))
                                    s2 += "|";
                                s2 += eventT;
                            }
                        }
                        describe = s1 + s2;

                        //string measure_time = currentRow["measure_time"].ToString();
                        //DateTime timepoint = GetTimePoint(Convert.ToDateTime(measure_time));

                        ClsDataObj tojbEvent = new ClsDataObj();
                        tojbEvent.Val = describe;
                        tojbEvent.Rdatatime = measureTime;
                        tojbEvent.Typename = "事件";
                        tojbEvent.setdataxy(currentpage.Starttime);
                        currentpage.Objs.Add(tojbEvent);
                    }
                    #endregion

                    bool Eventbool = false;
                    if (Eventbool == false)
                    {
                        string eventStr = GetEventState(measureState);

                        if (!string.IsNullOrEmpty(eventStr))
                        {
                            ClsDataObj tojbEvent = new ClsDataObj();
                            tojbEvent.Val = eventStr;
                            tojbEvent.Rdatatime = measureTime;
                            tojbEvent.Typename = "事件";
                            tojbEvent.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbEvent);
                        }
                    }
                }
 
            }

        }

        private string GetEventState(string state)
        {
            string text = "";
            switch (state)
            {
                case "W":
                    text = "外出";
                    break;
                case "L":
                    text = "请假";
                    break;
                case "Q":
                    text = "劝阻无效外出";
                    break;
                case "R":
                    text = "拒测";
                    break;
                case "J":
                    text = "外出检查";
                    break;
                case "O":
                    text = "私自外出";
                    break;
                case "T":
                    text = "停测";
                    break;
            }

            return text;
        }

        
        /// <summary>
        /// 普通体温单其他信息
        /// </summary>
        private void printOther()
        {
            DataTable other = dbList[1];

            for (int i = 0; i < other.Rows.Count; i++)
            {
                DataRow currentRow = other.Rows[i];
                DateTime rowTime = Convert.ToDateTime(Convert.ToDateTime(currentRow["record_time"]).ToString("yyyy-MM-dd"));

                /*
                 * 血压
                 */
                string bp_blood = currentRow["bp_blood"].ToString();
                if (bp_blood != "")
                {
                    ClsDataObj tojbBlood = new ClsDataObj();
                    tojbBlood.Val = bp_blood;
                    tojbBlood.Rdatatime = rowTime.ToString();
                    tojbBlood.Typename = "收缩血压";
                    tojbBlood.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbBlood);
                }

                string bp_blood2 = currentRow["bp_blood2"].ToString();
                if (bp_blood2 != "")
                {
                    ClsDataObj tojbBlood = new ClsDataObj();
                    tojbBlood.Val = bp_blood;
                    tojbBlood.Rdatatime = rowTime.ToString();
                    tojbBlood.Typename = "舒张血压";
                    tojbBlood.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbBlood);
                }

                //1大便次数
                ClsDataObj tojbShit = new ClsDataObj();
                tojbShit.Val = currentRow["shit"].ToString();
                tojbShit.Rdatatime = rowTime.ToString();
                tojbShit.Typename = "大便次数";
                tojbShit.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbShit);

                
                //2小便次数
                ClsDataObj tojbUrinecount = new ClsDataObj();
                tojbUrinecount.Val = currentRow["urine_count"].ToString();
                tojbUrinecount.Rdatatime = rowTime.ToString();
                tojbUrinecount.Typename = "小便次数";
                tojbUrinecount.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbUrinecount);

                //3尿量
                ClsDataObj tojbUrine = new ClsDataObj();
                tojbUrine.Val = currentRow["urine"].ToString();
                tojbUrine.Rdatatime = rowTime.ToString();
                tojbUrine.Typename = "尿量";
                tojbUrine.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbUrine);
                
                //4引流量
                ClsDataObj tojbVOLUME = new ClsDataObj();
                tojbVOLUME.Val = currentRow["VOLUME_OF_DRAINAGE"].ToString();
                tojbVOLUME.Rdatatime = rowTime.ToString();
                tojbVOLUME.Typename = "引流量";
                tojbVOLUME.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbVOLUME);

                //5饮水量
                ClsDataObj tojbWateramount = new ClsDataObj();
                tojbWateramount.Val = currentRow["WATER_AMOUNT"].ToString();
                tojbWateramount.Rdatatime = rowTime.ToString();
                tojbWateramount.Typename = "饮水量";
                tojbWateramount.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbWateramount);

                //6输入量
                ClsDataObj tojbInamount = new ClsDataObj();
                tojbInamount.Val = currentRow["in_amount"].ToString();
                tojbInamount.Rdatatime = rowTime.ToString();
                tojbInamount.Typename = "输入量";
                tojbInamount.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbInamount);
                
                //7体重               
                ClsDataObj tojbWeight = new ClsDataObj();
                tojbWeight.Val = currentRow["weight"].ToString();
                tojbWeight.Rdatatime = rowTime.ToString();
                tojbWeight.Typename = "体重";
                tojbWeight.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbWeight);
                
                //8身高
                ClsDataObj tojbLength = new ClsDataObj();
                tojbLength.Val = currentRow["length"].ToString();
                tojbLength.Rdatatime = rowTime.ToString();
                tojbLength.Typename = "身高";
                tojbLength.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbLength);

                //9备注
                ClsDataObj tojbRemark = new ClsDataObj();
                tojbRemark.Val = currentRow["remark"].ToString();
                tojbRemark.Rdatatime = rowTime.ToString();
                tojbRemark.Typename = "备注";
                tojbRemark.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbRemark);
            }
        }

        #region 打印日期 住院日数

        /// <summary>
        /// 打印日期 住院日数 手术后天数
        /// </summary>
        private void printTime()
        {
            DateTime dtStart = this.startTime;
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
                if ((out_time < (i == 0 ? dtStart : dtStart.AddDays(1)) && out_time.Year > 2000) || (i == 0 ? dtStart > systime : dtStart.AddDays(1) > systime))
                {
                    return;
                }
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
                ClsDataObj tojbdt = new ClsDataObj();
                tojbdt.Val = dateString;
                tojbdt.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                tojbdt.Typename = "日期";
                tojbdt.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbdt);
               

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
                                string[] surgerys = dtSurgery.Rows[j]["DESCRIBE"].ToString().Split('|');
                                foreach (string surgeryStr in surgerys)
                                {
                                    string surgery = "";
                                    if (surgeryStr.Contains("手术") || surgeryStr.Contains("分娩"))
                                    {
                                        surgery = surgeryStr.Contains("手术") ? "手术" : "分娩";
                                        if (abject.Days.ToString() == "0")
                                        {
                                            if (j > 0)
                                                surgeryDays = surgeryDays + "/" + surgery;//NumberConvertToNoman(j + 1);
                                            else
                                                surgeryDays = surgery;//I
                                        }
                                        else
                                        {
                                            if (surgeryDays != "")
                                                surgeryDays = surgeryDays + "/" + abject.Days.ToString();
                                            else
                                                surgeryDays = abject.Days.ToString();
                                        }
                                    }
                                }
                            }
                        }

                        if (surgeryDays.Length > 0)
                        {
                            //体温单天数
                            ClsDataObj tojbOper = new ClsDataObj();
                            tojbOper.Val = surgeryDays;
                            tojbOper.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                            tojbOper.Typename = "手术天数";
                            tojbOper.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbOper);                      
                        }
                    }
                }

                //住院天数
                TimeSpan tsp = new TimeSpan();
                if (dtStart != null && user["入院日期:"] != "")
                {
                    tsp = Convert.ToDateTime(dtStart) - Convert.ToDateTime(Convert.ToDateTime(user["入院日期:"]).ToString("yyyy-MM-dd"));
                    int Days = tsp.Days + 1;

                    //体温单天数
                    ClsDataObj tojbDay = new ClsDataObj();
                    tojbDay.Val = Days.ToString();
                    tojbDay.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                    tojbDay.Typename = "住院天数";
                    tojbDay.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbDay);
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
                        return_s = "Ⅳ";
                        break;
                    case 5:
                        return_s = "Ⅴ";
                        break;
                    case 6:
                        return_s = "Ⅵ";
                        break;
                    case 7:
                        return_s = "Ⅶ";
                        break;
                    case 8:
                        return_s = "Ⅷ";
                        break;
                    case 9:
                        return_s = "Ⅸ";
                        break;
                    case 10:
                        return_s = "Ⅹ";
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
                                        "describe, remark, heart_rhythm,PAIN_VALUE,PAIN_MOTHED,pain_value2,is_qixian from t_vital_signs " +
                                        "WHERE to_char(MEASURE_TIME,'yyyy-MM-dd') " +
                                        "BETWEEN '{0}' AND '{1}' AND PATIENT_ID = '{2}' ORDER BY MEASURE_TIME ASC", startTime, endTime, pid);

            string sql2 = string.Format("select stool_count, stool_state, clysis_count, stool_count_e,stool_count_f, " +
                                        "stool_amount, stool_amount_unit, stale_amount, is_catheter, weighttype, " +
                                        "weight, weight_unit, weight_special, length, sensi_test_code, sensi_test_result, " +
                                        "sensi_test_result_temp, record_id, record_time, in_amount, out_amount, out_amount1, " +
                                        "out_amount2, out_amount3, remark, bp_high, bp_low, bp_unit,out_other, bp_blood,bp_blood2,SPECIAL,SPUTUM_QUANTITY,VOLUME_OF_DRAINAGE,VOMIT,URINE,URINE_STATE,SHIT_STATE,empty_name1,empty_value1,empty_name2,empty_value2,shit,empty_name3,empty_value3,empty_name4,empty_value4,empty_name5,empty_value5,sensi,urine_count,water_amount from t_temperature_info " +
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
            return list;
        }

        #endregion

    }
}
