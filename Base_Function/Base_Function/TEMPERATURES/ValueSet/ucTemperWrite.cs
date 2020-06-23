using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;
using Bifrost;

namespace Base_Function.TEMPERATURES.ValueSet
{
    public partial class ucTemperWrite : UserControl
    {
        string startDate = "";
        string endDate = "";

        public string dtpTimes_date = "";
        private int isHowTime = 0;
        private bool isOkNow = true;
        private string isQX = "N";//骑线和非骑线显示状态控制
        //this.cbEvent = new comboNoWheel();     

        private int currentHour=2;//当前时间点
        private string pid;//病人编号                  
        private string bed_no;//床号 
        private string userName;//病人姓名
        private string sex;//性别
        private string age;//年龄
        private string section; //科室
        private string ward;//科别
        private string inTime;//入区时间
        private DateTime SelectTime;//当前日期
        private DateTime sysTime;//系统日期
        private string pid_ids;//病人主键
        private string Date_time_up = "";
        private string Erm = "";//log记录信息
        private string pageindex = string.Empty;
        private DateTime dt_intime;//入区时间
        /// <summary>
        /// txtEmptyItemName1是否可修改
        /// </summary>
        private bool emptyedited1 = false;

        /// <summary>
        /// txtEmptyItemName2是否可修改
        /// </summary>
        private bool emptyedited2 = false;

        private List<DataTable> lists;
        List<Class_T_Vital_Signs> list = new List<Class_T_Vital_Signs>();

        private string[] HeaderInfo;

        /// <summary>
        /// 是否加载完界面.
        /// </summary>
        public bool IsFirst = true;

        /// <summary>
        /// 死亡/出院等事件日期
        /// </summary>
        public DateTime out_time;

        /// <summary>
        /// 体温单刷新
        /// </summary>
        public static EventHandler A_RefleshTemprature;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="patient_id">病人主键</param>
        /// <param name="patient_id">床号</param>
        public ucTemperWrite(string starttime, string endtime, string Pid, string patient_i, string bedno, DateTime SelectDate)
        {
            InitializeComponent();

            try
            {
                //ucTemperWrite_load( starttime,  endtime,  Pid,  patient_i,  bedno,  SelectDate);
                bed_no = bedno;
                pid_ids = patient_i;
                pid = Pid;
                startDate = starttime;
                endDate = endtime;

                out_time = SelectDate;

                //获取页码
                GetPageIndex();
                ////加载页面信息
                ////LoadPageInfo();
                //this.txtbedno.Text = TemperatureMethod.GetBedNo(pid_ids, pageindex, Convert.ToDateTime(starttime), Convert.ToDateTime(endtime)); ;
                //this.txtDiagnose.Text = TemperatureMethod.GetDiagnose(pid_ids, pageindex, Convert.ToDateTime(starttime), Convert.ToDateTime(endtime)); ;

                setDateTimeMinOrMax();
                dateTimePicker_Select.Value = dateTimePicker_Select.MaxDate;
                setHourTime(Convert.ToDateTime(sysTime).Hour);
                IsFirst = false;
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 设置可操作日期段
        /// </summary>
        /// <param name="dateT"></param>
        public void setDateTimeMinOrMax()
        {
            sysTime = App.GetSystemTime();
            //先还原默认,再重设
            dateTimePicker_Select.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePicker_Select.MaxDate = DateTimePicker.MaximumDateTime;

            dateTimePicker_Select.MinDate = Convert.ToDateTime(startDate).Date;

            if (out_time.Date >= Convert.ToDateTime(startDate).Date && out_time.Date < Convert.ToDateTime(endDate).Date)
            {
                if (sysTime.Date <= out_time.Date)
                    dateTimePicker_Select.MaxDate = sysTime.Date;
                else
                    dateTimePicker_Select.MaxDate = out_time.Date;
            }
            else
            {
                if (sysTime.Date <= Convert.ToDateTime(endDate).Date)
                    dateTimePicker_Select.MaxDate = sysTime.Date;
                else
                    dateTimePicker_Select.MaxDate = Convert.ToDateTime(endDate).Date;
            }
        }
        private void setHourTime(int hour)
        {
            //int hour = Convert.ToInt32(dateTimePicker_Select.Value.ToString("HH"));
            int hourindex = 0;
            if (hour >= 0 && hour < 4)
            { hourindex = 0; }
            else if (hour >= 4 && hour < 8)
            { hourindex = 1; }
            else if (hour >= 8 && hour < 12)
            { hourindex = 2; }
            else if (hour >= 12 && hour < 16)
            { hourindex = 3; }
            else if (hour >= 16 && hour < 20)
            { hourindex = 4; }
            else if (hour >= 20 || hour < 0)
            { hourindex = 5; }

            cboTime.SelectedIndex = hourindex;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="patient_id">病人主键</param>
        /// <param name="patient_id">床号</param>
        public void ucTemperWrite_load(string starttime, string endtime, string Pid, string patient_i, string bedno, DateTime SelectDate)
        {
            try
            {
                bed_no = bedno;
                pid_ids = patient_i;
                pid = Pid;
                startDate = starttime;
                endDate = endtime;
                //获取页码
                GetPageIndex();

                setDateTimeMinOrMax();

                if (SelectDate == null )
                {
                    SelectDate = Convert.ToDateTime(endtime);
                }
                if (SelectDate.Date > sysTime.Date)
                {
                    SelectDate = sysTime;
                }
                dateTimePicker_Select.Value = Convert.ToDateTime(SelectDate).Date;
                setHourTime(Convert.ToDateTime(SelectDate).Hour);
                
            }
            catch (System.Exception ex)
            {

            }
        }

        private void GetPageIndex()
        {
            this.inTime = App.ReadSqlVal("select in_time from t_in_patient  where id='" + pid_ids + "'", 0, "in_time").ToString();
            DateTime intime = Convert.ToDateTime(this.inTime).Date;
            dt_intime = intime;
            DateTime time2 = Convert.ToDateTime(this.startDate).Date;
            int i = 1;
            if (intime.Date > time2.Date)
                return;
            while (intime.Date != time2.Date)
            {
                i++;
                time2 = time2.AddDays(-7);
            }
            pageindex = i.ToString();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (dateTimePicker_Select.Value.Date > sysTime.Date ||dateTimePicker_Select.Value.Date > Convert.ToDateTime(endDate) ||
                dateTimePicker_Select.Value.Date < Convert.ToDateTime(startDate))
            {
                App.MsgWaring("选择的日期不正确，只能选择当前页七天的日期范围，并且不能超过当前日期，否则无法保存!");
                return;
            }

            string time = SelectTime.ToString("yyyy-MM-dd");
            DateTime dtTime = SelectTime;

            //体温根据时间点段 前2小时,后1小时59分 清除数据
            DBControl.IsClear_Temperasure_Time(SelectTime, this.pid_ids); 
            DBControl.IsClear_Others(time, this.pid_ids);
            string title = string.Format("查询时间[{0}]-病人主键[{1}]-病人编号[{2}]-病人姓名[{3}]-床号[{4}]-科室[{5}]-", time, pid_ids, pid, userName, bed_no, section);
            if (Excute() && DBControl.InsertTempers_Others(ExcuteTemperOther()) && PageInfoRefresh())                      //重新插入数据Remove
            {
                if (Erm != "")
                {

                    DBControl.ErrorLog("体温单保存成功: 操作用户:" + App.UserAccount.UserInfo.User_name, title + Erm);
                }
                App.Msg("数据保存成功");
                list.Clear();
            }
            else
            {
                if (Erm != "")
                {
                    DBControl.ErrorLog("体温单保存失败: 操作用户:" + App.UserAccount.UserInfo.User_name, title + Erm);
                }
                App.Msg("数据保存失败");
                list.Clear();
            }


            //刷新体温单
            if (A_RefleshTemprature != null)
            {
                A_RefleshTemprature(sender, e);
                setOldDateTime(dtTime);
            }

            //保存页眉信息
            //if (this.txtbedno.Text.Trim().Length > 0 || txtDiagnose.Text.Trim().Length > 0)
            //{
            //    string bedno = this.txtbedno.Text.Trim();
            //    string section_name = string.Empty;
            //    //section_name = cmbSection.SelectedValue.ToString();
            //    //section_name = txtSection.Text;
            //    string diag = txtDiagnose.Text.Trim();
            //    List<string> HeadInfo = new List<string>();
            //    string sql = string.Empty;
            //    sql = "delete from t_temperature_pageinfo a where a.patient_id='" + this.pid_ids + "' and pageindex='" + pageindex + "'";
            //    HeadInfo.Add(sql);
            //    sql = " insert into t_temperature_pageinfo(id,pageindex,bedno,diagnose,diagnose_count,section_name,patient_id)values('" + App.GenId().ToString() + "','" + pageindex + "','" + bedno + "','" + diag + "','" + DiagnoseCount + "','" + section_name + "','" + pid_ids + "')";
            //    HeadInfo.Add(sql);
            //    int count = 0;
            //    if (App.ExecuteBatch(HeadInfo.ToArray()) > 0)
            //    {
            //        ucTempratureEdit.RefreshHeader(this.pid_ids, pageindex,Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
            //    }
            //}

            #region 手术质控信息
            List<string> Operations = new List<string>();
            if (this.oldOperations.Count > 0 || this.newOperations.Count > 0)
            {
                string beforeOperation = "";
                string afterOperation = "";
                if (string.IsNullOrEmpty(age))
                {
                    age = App.ReadSqlVal("select age from t_in_patient where id='" + pid_ids + "'", 0, "age");
                }
                foreach (string var in this.oldOperations)
                {
                    if (newOperations.Exists(delegate(string s) { return s == var; }))
                    {
                        continue;
                    }
                    else
                    {
                        beforeOperation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE,ywcstate) values('" + pid + "','术前',to_timestamp('" + var.Split(',')[0] + "','syyyy-mm-dd hh24:mi:ss')," + pid_ids + ",'" + age + "','-','1')";
                        afterOperation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE,ywcstate) values('" + pid + "','术后',to_timestamp('" + var.Split(',')[1] + "','syyyy-mm-dd hh24:mi:ss')," + pid_ids + ",'" + age + "','-','1')";
                        Operations.Add(beforeOperation);
                        Operations.Add(afterOperation);
                    }
                }

                foreach (string var in newOperations)
                {
                    if (oldOperations.Exists(delegate(string s) { return s == var; }))
                    {
                        continue;
                    }
                    else
                    {
                        beforeOperation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE,ywcstate) values('" + pid + "','术前',to_timestamp('" + var.Split(',')[0] + "','syyyy-mm-dd hh24:mi:ss')," + pid_ids + ",'" + age + "','','1')";
                        afterOperation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE,ywcstate) values('" + pid + "','术后',to_timestamp('" + var.Split(',')[1] + "','syyyy-mm-dd hh24:mi:ss')," + pid_ids + ",'" + age + "','','1')";
                        Operations.Add(beforeOperation);
                        Operations.Add(afterOperation);
                    }
                }

                if (Operations.Count > 0)
                {
                    App.ExecuteBatch(Operations.ToArray());
                }
            }

            #endregion

        }


        /// <summary>
        /// 设置时间为原始时间
        /// </summary>
        private void setOldDateTime(DateTime dt)
        {
            try
            {
                dateTimePicker_Select.Value = dt.Date;
                setHourTime(dt.Hour);
            }
            catch { }
        }

        /// <summary>
        /// 手术old事件
        /// </summary>
        public List<string> oldOperations = new List<string>();
        /// <summary>
        /// 手术new事件
        /// </summary>
        public List<string> newOperations = new List<string>();

        /// <summary>
        /// 保存体温信息
        /// </summary>
        /// <returns></returns>
        public bool Excute()
        {
            this.newOperations.Clear();
            list.Add(this.tw.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd"), this.pid_ids));
            foreach (string var in this.tw.newOPerations)
            {
                if (this.newOperations.Exists(delegate(string s) { return s == var; }))
                {
                    continue;
                }
                else
                {
                    this.newOperations.Add(var);
                }
            }
            
            return DBControl.InsertTempers(list);
        }

        /// <summary>
        /// 保存页眉信息
        /// </summary>
        /// <returns></returns>
        private bool PageInfoRefresh()
        {
            if (this.txtbedno.Text.Trim().Length > 0 || txtDiagnose.Text.Trim().Length > 0)
            {
                string bedno = this.txtbedno.Text.Trim();
                string section_name = string.Empty;
                //section_name = cmbSection.SelectedValue.ToString();
                //section_name = txtSection.Text;
                string diag = txtDiagnose.Text.Trim();
                List<string> HeadInfo = new List<string>();
                string sql = string.Empty;
                sql = "delete from t_temperature_pageinfo a where a.patient_id='" + this.pid_ids + "' and pageindex='" + pageindex + "'";
                HeadInfo.Add(sql);
                sql = " insert into t_temperature_pageinfo(id,pageindex,bedno,diagnose,diagnose_count,section_name,patient_id)values('" + App.GenId().ToString() + "','" + pageindex + "','" + bedno + "','" + diag + "','" + DiagnoseCount + "','" + section_name + "','" + pid_ids + "')";
                HeadInfo.Add(sql);

                try
                {
                    App.ExecuteBatch(HeadInfo.ToArray());
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 查询体温其他信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static List<DataTable> GetTemper(string time, string pid)
        {
            List<DataTable> objlist = new List<DataTable>();
            DataSet ds = new DataSet();
            string sql2 = string.Format("select stool_count," +
                                        "stool_state, clysis_count, stool_count_e," +
                                        "stool_amount, stool_amount_unit, stale_amount," +
                                        "is_catheter, weighttype, weight, weight_unit," +
                                        "weight_special, length, sensi_test_code, sensi_test_result," +
                                        "sensi_test_result_temp, record_id, record_time, in_amount," +
                                        "out_amount, out_amount1, out_amount2, out_amount3," +
                                        "remark, bp_high, bp_low, bp_unit,out_other, bp_blood,Stool_count_f," +
                                        "SPO2,SPUTUM_QUANTITY,VOLUME_OF_DRAINAGE,VOMIT,Special,URINE,URINE_STATE,SHIT_STATE,empty_name1,empty_value1,empty_name2,empty_value2,shit,,empty_name3,empty_value3,empty_name4,empty_value4,empty_name5,empty_value5,urine_count,water_amount from t_temperature_info WHERE " +
                                        "to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID = '{1}' ", time, pid);
            DataTable dt2 = App.GetDataSet(sql2).Tables[0];
            if (dt2.Rows.Count > 0)
                objlist.Add(dt2);
            else
                return null;
            return objlist;
        }

        /// <summary>
        /// 返回体温其他信息
        /// </summary>
        /// <returns></returns>
        public Class_T_Temperature_Info ExcuteTemperOther()
        {
            //以前的:血压1、2，入量，大便，尿量，体重，身高，药物过敏，1、2、3个空白行
            //附一:血压12,大便次数,小便次数,尿量,引流量,饮水量,输入量,体重,身高,备注
            Class_T_Temperature_Info tti = new Class_T_Temperature_Info();
            ////页眉床号
            //tti.Bed_no = this.txtbedno.Text;
            ////页眉诊断
            //tti.Diagnose = this.txtDiagnose.Text;

            //病人编号
            tti.Pid = this.pid;
            tti.Patient_id = this.pid_ids;

            //血压 1、2
            tti.Bp_blood = cmbBp.Text.Trim();

            tti.Bp_blood2 = cmbBp2.Text.Trim();

            //大便次数
            tti.Shit = cmbShit.Text;

            //小便次数
            tti.Urine_count = txtURINE_COUNT.Text;

            //尿量
            tti.Urine = cmbUrine.Text;

            //引流量
            tti.Volume_of_drainage = this.txtVOLUME_OF_DRAINAGE.Text;

            //饮水量
            tti.Water_amount = this.txtWATER_AMOUNT.Text;

            //输入量:总入量
            tti.In_amount = this.txtIn.Text;

            //体重
            tti.Weight = cmbWeight.Text;

            //身高
            tti.Length = txtHeight.Text;

            //备注
            tti.Remark = txtREMARK.Text;

            //药物过敏
            //tti.Sensi = this.txtSensi.Text;


            //时间
            tti.Record_time = dateTimePicker_Select.Value.ToString("yyyy-MM-dd HH:mm");



            //出量-总量
            //if (this.txtOut.Text != "")
            //{
            //    tti.Out_amount = this.txtOut.Text;
            //}
            //特殊治疗
            //if (this.txtDragInfact.Text != "")
            //{
            //    tti.Special = this.txtDragInfact.Text;
            //}



            //tti.Empty_name1 = txtEmptyItemName1.Text;
            //tti.Empty_value1 = txtEmptyItemValue1.Text;
            //tti.Empty_name2 = txtEmptyItemName2.Text;
            //tti.Empty_value2 = txtEmptyItemValue2.Text;
            //tti.Empty_name3 = txtEmptyItemName3.Text;
            //tti.Empty_value3 = txtEmptyItemValue3.Text;
            //tti.Empty_name4 = txtEmptyItemName4.Text;
            //tti.Empty_value4 = txtEmptyItemValue4.Text;
            //tti.Empty_name5 = txtEmptyItemName5.Text;
            //tti.Empty_value5 = txtEmptyItemValue5.Text;
            return tti;
        }


        
        /// <summary>
        /// 判断一个时间是否大于等于另一个时间
        /// </summary>
        /// <param name="ts1"></param>
        /// <param name="ts2"></param>
        /// <returns></returns>
        public bool CompareTime(DateTime ts1, DateTime ts2)
        {
            if (ts1.ToString("yyyy-MM-dd") == ts2.ToString("yyyy-MM-dd"))
            {
                return true;
            }
            if (DateTime.Compare(ts1, ts2) > 0)
            {
                return true;
            }
            else if (DateTime.Compare(ts2, ts1) == 1)
            {
                if (ts2.Hour >= 0 && ts2.Hour < 4)
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


        /// <summary>
        /// 加载今日保存信息
        /// </summary>
        /// <param name="lists"></param>
        public void LoadAll(List<DataTable> lists)
        {
            this.oldOperations.Clear();
            DataTable dt1 = lists[0];
            #region 体温单信息加载
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int hour = Convert.ToInt32(Convert.ToDateTime(dt1.Rows[i]["measure_time"]).ToString("HH"));

                    if (hour >= 0 && hour < 4)
                    { hour = 2; }
                    else if (hour >= 4 && hour < 8)
                    { hour = 6; }
                    else if (hour >= 8 && hour < 12)
                    { hour = 10; }
                    else if (hour >= 12 && hour < 16)
                    { hour = 14; }
                    else if (hour >= 16 && hour < 20)
                    { hour = 18; }
                    else if (hour >= 20 || hour < 0)
                    { hour = 22; }
                    if (hour == currentHour)
                    {
                        this.tw.setTempers(dt1.Rows[i], hour.ToString());
                        foreach (string var in this.tw.oldOperations)
                        {
                            if (this.oldOperations.Exists(delegate(string s) { return s == var; }))
                            {
                                continue;
                            }
                            else
                            {
                                this.oldOperations.Add(var);
                            }
                        }

                        //if (tw.Painmothed != "")
                        //{
                        //    GetSelectItem(tw.Painmothed);
                        //}
                    }
                }
            }
            #endregion

            DataTable dt2 = lists[1];
            #region 其他信息

            if (dt2.Rows.Count > 0)
            {//附一:血压12,大便次数,小便次数,尿量,引流量,饮水量,输入量,体重,身高,备注

                //血压1
                string bp_blood = dt2.Rows[0]["bp_blood"].ToString();
                if (bp_blood != "")
                {
                    if (bp_blood.Contains(","))
                    {
                        cmbBp.Text = bp_blood.Split(',')[0];
                        //cmbBp2.Text = bp_blood.Split(',')[1];
                    }
                    else
                    {
                        cmbBp.Text = bp_blood;
                    }
                }
                //血压2
                string bp_blood2 = dt2.Rows[0]["bp_blood2"].ToString();
                if (bp_blood2 != "")
                {
                    cmbBp2.Text = bp_blood2;
                }
                //大便次数
                if (dt2.Rows[0]["shit"].ToString() != "")
                {
                    this.cmbShit.Text = dt2.Rows[0]["shit"].ToString();
                }
                else
                {
                    this.cmbShit.Text = "";
                }
                //小便次数
                if (dt2.Rows[0]["URINE_COUNT"].ToString() != "")
                {
                    this.txtURINE_COUNT.Text = dt2.Rows[0]["URINE_COUNT"].ToString();
                }
                else
                {
                    this.txtURINE_COUNT.Text = "";
                }
                //小便量
                if (dt2.Rows[0]["URINE"].ToString() != "")
                {
                    this.cmbUrine.Text = dt2.Rows[0]["URINE"].ToString();
                }
                else
                {
                    this.cmbUrine.Text = "";
                }

                //引流量
                if (dt2.Rows[0]["VOLUME_OF_DRAINAGE"].ToString() != "")
                {
                    this.txtVOLUME_OF_DRAINAGE.Text = dt2.Rows[0]["VOLUME_OF_DRAINAGE"].ToString();
                }
                else
                {
                    txtVOLUME_OF_DRAINAGE.Text = "";
                }

                //饮水量
                if (dt2.Rows[0]["WATER_AMOUNT"].ToString() != "")
                {
                    this.txtWATER_AMOUNT.Text = dt2.Rows[0]["WATER_AMOUNT"].ToString();
                }
                else
                {
                    txtWATER_AMOUNT.Text = "";
                }

                //输入量
                if (dt2.Rows[0]["in_amount"].ToString() != "")
                {
                    this.txtIn.Text = dt2.Rows[0]["in_amount"].ToString();
                }
                else
                {
                    txtIn.Text = "";
                }

                //体重
                if (dt2.Rows[0]["weight"].ToString().Length > 0)
                {
                    cmbWeight.Text = dt2.Rows[0]["weight"].ToString();
                }
                //身高
                if (dt2.Rows[0]["length"].ToString().Length > 0)
                {
                    txtHeight.Text = dt2.Rows[0]["length"].ToString();
                }
                //备注
                if (dt2.Rows[0]["REMARK"].ToString().Length > 0)
                {
                    txtREMARK.Text = dt2.Rows[0]["REMARK"].ToString();
                }
                
                
            }

            #endregion
        }

        DataTable PatientAllSection = null;

        private void GetDiagnose()
        {
            string diagnose = "";
            string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + pid_ids + " order by a.diagnose_sort asc ";
            sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + pid_ids + " and a.diagnose_type = '403' order by a.diagnose_sort";
            DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
            if (dtdiagnose != null)
            {
                for (int i = 0; i < dtdiagnose.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                        DiagnoseCount = Convert.ToString(i + 1);
                    }
                    else if (i >= 3)
                    {
                        break;
                    }
                    else
                    {
                        diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                        DiagnoseCount = Convert.ToString(i + 1);
                    }
                }
            }
            Diagnose = diagnose;
        }

        /// <summary>
        /// 还原窗体信息
        /// </summary>
        private void ClearInfo()
        {
            ClearTempers();
            if (!IsFirst)
                ClearOtherInfo();
        }

        /// <summary>
        /// UserControl 还原初始
        /// </summary>
        private void ClearTempers()
        {
            this.tw.Clear();
        }

        private void ClearOtherInfo()
        {
            ////附一:血压12,大便次数,小便次数,尿量,引流量,饮水量,输入量,体重,身高,备注
            this.cmbBp.Text = "";
            this.cmbBp2.Text = "";
            
            //大便次数
            cmbShit.Text = "";
            //小便次数
            txtURINE_COUNT.Text = "";
            //尿量
            cmbUrine.Text = "";
            //引流量
            this.txtVOLUME_OF_DRAINAGE.Text = "";
            //饮水量
            this.txtWATER_AMOUNT.Text = "";
            //输入量:总入量
            this.txtIn.Text = "";
            //体重
            cmbWeight.Text = "";
            //身高
            txtHeight.Text = "";
            //备注
            txtREMARK.Text = "";          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Refresh();
       
            DateTime dtTime = SelectTime;
            if (A_RefleshTemprature != null)
            {
                A_RefleshTemprature(sender, e);
                setOldDateTime(dtTime);
            }
        }

        private void dateTimePicker_Select_ValueChanged(object sender, EventArgs e)
        {
            if (!IsFirst)
                Refresh();
        }

        private string Diagnose = string.Empty;
        private string DiagnoseCount = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSelectDiagnose frm = new FrmSelectDiagnose(this.pid_ids.ToString(), Diagnose, DiagnoseCount);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Diagnose = frm.Diagnose;
                DiagnoseCount = frm.Index.ToString();
            }
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            base.OnKeyPress(e);
        }

        TextBox txt;
        private void txtAddArrow_Click(object sender, EventArgs e)
        {
            txt = sender as TextBox;

        }

        private void btnAddArrow_Click(object sender, EventArgs e)
        {
            try
            {
                string strInsertText = "→";
                int start = this.txt.SelectionStart;
                this.txt.Text = this.txt.Text.Insert(start, strInsertText);
                this.txt.Focus();
                this.txt.SelectionStart = start;
                this.txt.SelectionLength = strInsertText.Length;
            }
            catch (System.Exception ex)
            {

            }
        }

        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentHour = int.Parse(cboTime.Text.Substring(0, 2));
            Refresh();
        }

        /// <summary>
        /// 刷新加载数据
        /// </summary>
        private void Refresh()
        {
            try
            {
                //获取当前时间
                SelectTime = Convert.ToDateTime(this.dateTimePicker_Select.Value.ToString("yyyy-MM-dd ") + cboTime.Text);

                this.txtbedno.Text = TemperatureMethod.GetBedNo(pid_ids, pageindex, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
                this.txtDiagnose.Text = TemperatureMethod.GetDiagnose(pid_ids, pageindex, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));

                this.tw.IsHowTime = currentHour;//时间点
                this.tw.CurDateTime = SelectTime.Date;

                GetPageIndex();
                ClearInfo();
                if (CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
                {
                    string dateTime = SelectTime.ToString("yyyy-MM-dd");
                    if (!DBControl.SelectGreaterZero(dateTime, this.pid_ids))
                    {
                        lists = DBControl.GetTemper(dateTime, this.pid_ids);
                        LoadAll(lists);
                        lists.Clear();
                    }
                }
                //inRooms();
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 将回车键替换成Tab键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)　　// 按下的是回车键
            {
                //if (ActiveControl is TextBox || ActiveControl is ComboBox)
                //    keyData = Keys.Tab;
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
