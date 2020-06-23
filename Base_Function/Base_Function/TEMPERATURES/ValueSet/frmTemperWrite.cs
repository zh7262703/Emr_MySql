using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_NURSE.Tempreture_Management;
using Base_Function.MODEL;

namespace Base_Function.TEMPERATURES.ValueSet
{
    /// <summary>
    /// 体温模块的相关值录入
    /// 作者 ：张华
    /// 时间：2013-05-21
    /// </summary>
    public partial class frmTemperWrite : DevComponents.DotNetBar.Office2007Form
    {
        string startDate = "";
        string endDate = "";

        public string dtpTimes_date = "";
        private int isHowTime = 0;
        private bool isOkNow = true;
        private string isQX = "N";//骑线和非骑线显示状态控制
        //this.cbEvent = new comboNoWheel();     


        private string pid;//病人编号                  
        private string bed_no;//床号 
        private string userName;//病人姓名
        private string sex;//性别
        private string age;//年龄
        private string section; //科室
        private string ward;//科别
        private string inTime;//入区时间
        private DateTime SelectTime;//当前日期
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
        /// 初始化疼痛评分选项
        /// </summary>
        //private void IniPiansMothed()
        //{
        //    /*
        //    NRS(数字分级法)
        //    VRS(描述性疼痛量表)
        //    VAS(视觉模拟法)
        //    脸谱法
        //     * */
        //    cboPainGradesMothed.Items.Clear();
        //    Class_SelectObj[] PiansMotheds = new Class_SelectObj[5];
        //    PiansMotheds[0] = new Class_SelectObj();
        //    PiansMotheds[0].Select_Name = "";
        //    PiansMotheds[0].Select_Val = "";

        //    PiansMotheds[1] = new Class_SelectObj();
        //    PiansMotheds[1].Select_Name = "NRS(数字分级法)";
        //    PiansMotheds[1].Select_Val = "NRS";

        //    PiansMotheds[2] = new Class_SelectObj();
        //    PiansMotheds[2].Select_Name = "VRS(描述性疼痛量表)";
        //    PiansMotheds[2].Select_Val = "VRS";

        //    PiansMotheds[3] = new Class_SelectObj();
        //    PiansMotheds[3].Select_Name = "VAS(视觉模拟法)";
        //    PiansMotheds[3].Select_Val = "VAS";

        //    PiansMotheds[4] = new Class_SelectObj();
        //    PiansMotheds[4].Select_Name = "脸谱法";
        //    PiansMotheds[4].Select_Val = "脸谱法";

        //    for (int i = 0; i < PiansMotheds.Length; i++)
        //    {
        //        cboPainGradesMothed.Items.Add(PiansMotheds[i]);
        //    }

        //    cboPainGradesMothed.DisplayMember = "Select_Name";
        //    cboPainGradesMothed.ValueMember = "Select_Val";

        //}

        /// <summary>
        /// 当前选中项
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private void GetSelectItem(string val)
        {
            //for (int i = 0; i < cboPainGradesMothed.Items.Count; i++)
            //{
            //    Class_SelectObj temp = (Class_SelectObj)cboPainGradesMothed.Items[i];
            //    if (temp.Select_Val == val)
            //    {
            //        cboPainGradesMothed.Text = temp.Select_Name;
            //        break;
            //    }
            //}

        }



        private bool IsFirst = true;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="patient_id">病人主键</param>
        /// <param name="patient_id">床号</param>
        public frmTemperWrite(string starttime, string endtime, string Pid, string patient_i, string bedno, DateTime SelectDate)
        {
            InitializeComponent();

            bed_no = bedno;
            pid_ids = patient_i;
            pid = Pid;
            startDate = starttime;
            endDate = endtime;
            //获取患者所有住过的科室
            //PatientAllSection = TemperatureMethod.GetPatientAllSections(pid_ids);
            //cmbSection.DisplayMember = "section_name";
            //cmbSection.ValueMember = "section_name";
            //cmbSection.DataSource = PatientAllSection;
            //获取页码
            GetPageIndex();
            //加载页面信息
            //LoadPageInfo();
            this.txtbedno.Text = TemperatureMethod.GetBedNo(pid_ids, pageindex, Convert.ToDateTime(starttime), Convert.ToDateTime(endtime)); ;
            this.txtDiagnose.Text = TemperatureMethod.GetDiagnose(pid_ids, pageindex, Convert.ToDateTime(starttime), Convert.ToDateTime(endtime)); ;

            this.lblNotice.Text = "注意事项：当前时间点范围为" + starttime + "   至   " + endtime;
            //App.FormStytleSet(this, false);
            if (SelectDate == null)
            {
                dateTimePicker_Select.Value = Convert.ToDateTime(starttime);
            }
            else
            {
                dateTimePicker_Select.Value = Convert.ToDateTime(SelectDate); 
            }
            //if (cboPainGradesMothed.Items.Count == 0)
            //{
            //    IniPiansMothed();
            //}
            IsFirst = false;
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

        private void LoadEmptyRowInfo()
        {
            string sql = "select empty_name1,empty_value1,empty_name2,empty_value2,empty_name3,empty_value3,empty_name4,empty_value4," +
                         "empty_name5,empty_value5 from t_temperature_info a where  a.patient_id=" + pid_ids +
                         " and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") +
                         "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "'";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtEmptyItemName1.Text = ds.Tables[0].Rows[0]["empty_name1"].ToString();
                //txtEmptyItemValue1.Text = ds.Tables[0].Rows[0]["empty_value1"].ToString();
                txtEmptyItemName2.Text = ds.Tables[0].Rows[0]["empty_name2"].ToString();
                //txtEmptyItemValue2.Text = ds.Tables[0].Rows[0]["empty_value2"].ToString();
                txtEmptyItemName3.Text = ds.Tables[0].Rows[0]["empty_name3"].ToString();
                //txtEmptyItemValue3.Text = ds.Tables[0].Rows[0]["empty_value3"].ToString();
                txtEmptyItemName4.Text = ds.Tables[0].Rows[0]["empty_name4"].ToString();
                //txtEmptyItemValue4.Text = ds.Tables[0].Rows[0]["empty_value4"].ToString();
                txtEmptyItemName5.Text = ds.Tables[0].Rows[0]["empty_name5"].ToString();
                //txtEmptyItemValue5.Text = ds.Tables[0].Rows[0]["empty_value5"].ToString();
            }
            //string count = string.Empty;
            //count = App.ReadSqlVal("select count(*) from t_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_value1 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "'", 0, "count(*)");
            //if (count == "0")
            //{
            //    emptyedited1 = true;
            //}
            //else
            //{
            //    emptyedited1 = false;
            //}
            //count = string.Empty;
            //count = App.ReadSqlVal("select count(*) from t_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_value2 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "'", 0, "count(*)");
            //if (count == "0")
            //{
            //    emptyedited2 = true;
            //}
            //else
            //{
            //    emptyedited2 = false;
            //}
            ////txtEmptyItemName4.Enabled = emptyedited1;
            ////txtEmptyItemName1.Enabled = emptyedited2;
            //if (txtEmptyItemName4.Text == "" && txtEmptyItemName4.Enabled == false)
            //{
            //    txtEmptyItemName4.Text = App.ReadSqlVal("select empty_name1 from t_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_name1 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "' order by a.record_time asc", 0, "empty_name1");
            //}
            //if (txtEmptyItemName1.Text == "" && txtEmptyItemName1.Enabled == false)
            //{
            //    txtEmptyItemName1.Text = App.ReadSqlVal("select empty_name2 from t_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_name2 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "' order by a.record_time asc", 0, "empty_name2");
            //}
        }

        private void btnSure_Click(object sender, EventArgs e)
        {

            if (dateTimePicker_Select.Value.Date > Convert.ToDateTime(endDate) ||
                dateTimePicker_Select.Value.Date < Convert.ToDateTime(startDate))
            {
                App.MsgWaring("选择的时间不正确，必选择给定的时间段范围之内的时间！");
                return;
            }

            string time = SelectTime.ToString("yyyy-MM-dd");
            
            DBControl.IsClear_Temperasure(time, this.pid_ids); //根据时间清除数据
            DBControl.IsClear_Others(time, this.pid_ids);
            string title = string.Format("查询时间[{0}]-病人主键[{1}]-病人编号[{2}]-病人姓名[{3}]-床号[{4}]-科室[{5}]-", time, pid_ids, pid, userName, bed_no, section);
            if (Excute() && DBControl.InsertTempers_Others(ExcuteTemperOther()))                      //重新插入数据Remove
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

            //保存页眉信息
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
                int count = 0;
                App.ExecuteBatch(HeadInfo.ToArray());
            }

            string sql_empty = "update t_temperature_info set empty_name1='" + txtEmptyItemName1.Text + "',empty_name2='" + txtEmptyItemName2.Text + "',empty_name3='" + txtEmptyItemName3.Text + "',empty_name4='" + txtEmptyItemName4.Text + "'," +
                         "empty_name5='" + txtEmptyItemName5.Text + "' where  patient_id=" + pid_ids +
                         " and to_char(record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") +
                         "' and to_char(record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "'";
            App.ExecuteSQL(sql_empty);

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

            this.Close();
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
            list.Add(this.tw2am.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd"), this.pid_ids));
            foreach (string var in this.tw2am.newOPerations)
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
            list.Add(this.tw6am.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd"), this.pid_ids));
            foreach (string var in this.tw6am.newOPerations)
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
            list.Add(this.tw10am.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd"), this.pid_ids));
            foreach (string var in this.tw10am.newOPerations)
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
            list.Add(this.tw2pm.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd"), this.pid_ids));
            foreach (string var in this.tw2pm.newOPerations)
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
            list.Add(this.tw6pm.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd"), this.pid_ids));
            foreach (string var in this.tw6pm.newOPerations)
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
            list.Add(this.tw10pm.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd"), this.pid_ids));
            foreach (string var in this.tw10pm.newOPerations)
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


        private void TemperControlEnable(bool _a, bool _b, bool _c, bool _d, bool _e, bool _f)
        {
            this.tw2am.Enabled = _a;
            this.tw6am.Enabled = _b;
            this.tw10am.Enabled = _c;
            this.tw2pm.Enabled = _d;
            this.tw6pm.Enabled = _e;
            this.tw10pm.Enabled = _f;
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
        /// 入院之前的数据不能输入
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRoom()
        {

            if (!CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
            {
                TemperControlEnable(false, false, false, false, false, false);
                this.btnSure.Enabled = false;
                return;
            }
            else
            {
                this.btnSure.Enabled = true;
                DateTime dt = Convert.ToDateTime(Convert.ToDateTime(this.inTime));
                if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd"))
                {//开放入院时间段的前一个时间段
                    if (dt.Hour >= 0 && dt.Hour < 4)
                    {
                        TemperControlEnable(true, true, true, true, true, true);
                    }
                    else if (dt.Hour >= 4 && dt.Hour < 8)
                    {
                        TemperControlEnable(false, true, true, true, true, true);
                    }
                    else if (dt.Hour >= 8 && dt.Hour < 12)
                    {
                        TemperControlEnable(false, false, true, true, true, true);
                    }
                    else if (dt.Hour >= 12 && dt.Hour < 16)
                    {
                        TemperControlEnable(false, false, false, true, true, true);
                    }
                    else if (dt.Hour >= 16 && dt.Hour < 20)
                    {
                        TemperControlEnable(false, false, false, false, true, true);
                    }
                    else
                    {//21-1
                        TemperControlEnable(false, false, false, false, false, true);
                    }
                }
                //else if (DateTime.Compare(Convert.ToDateTime(this.inTime), SelectTime) == 1)
                //{
                //    if (dt.Hour >= 0 && dt.Hour < 4)
                //    {
                //        TemperControlEnable(false, false, false, false, false, true);
                //    }
                //}
                else
                {
                    TemperControlEnable(true, true, true, true, true, true);
                }

            }
        }

        /// <summary>
        /// 出院后的数据不能输入
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRooms()
        {
            if (!CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
            {
                TemperControlEnable(false, false, false, false, false, false);
                this.btnSure.Enabled = false;
                return;
            }
            else
            {
                this.btnSure.Enabled = true;
                DateTime dt = Convert.ToDateTime(Convert.ToDateTime(this.inTime));
                if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd"))
                {//开放入院时间段的前一个时间段
                    if (dt.Hour >= 0 && dt.Hour < 4)
                    {
                        TemperControlEnable(true, true, true, true, true, true);
                    }
                    else if (dt.Hour >= 4 && dt.Hour < 8)
                    {
                        TemperControlEnable(false, true, true, true, true, true);
                    }
                    else if (dt.Hour >= 8 && dt.Hour < 12)
                    {
                        TemperControlEnable(false, false, true, true, true, true);
                    }
                    else if (dt.Hour >= 12 && dt.Hour < 16)
                    {
                        TemperControlEnable(false, false, false, true, true, true);
                    }
                    else if (dt.Hour >= 16 && dt.Hour < 20)
                    {
                        TemperControlEnable(false, false, false, false, true, true);
                    }
                    else
                    {//21-1
                        TemperControlEnable(false, false, false, false, false, true);
                    }
                    return;
                }
                //else if (DateTime.Compare(Convert.ToDateTime(this.inTime), SelectTime) == 1)
                //{
                //    if (dt.Hour >= 0 && dt.Hour < 4)
                //    {
                //        TemperControlEnable(false, false, false, false, false, true);
                //        return;
                //    }
                //}
                else
                {
                    TemperControlEnable(true, true, true, true, true, true);
                }

            }
            string time = "";
            string sql = "select * from t_vital_signs where PATIENT_ID=" + pid_ids + "";
            DataSet dsp = App.GetDataSet(sql);
            if (dsp.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
                {
                    if (dsp.Tables[0].Rows[i]["DESCRIBE"].ToString().Contains("出院"))
                    {
                        time = dsp.Tables[0].Rows[i]["MEASURE_TIME"].ToString();
                        break;
                    }
                }
            }
            if (time != "")
            {
                DateTime dt = Convert.ToDateTime(Convert.ToDateTime(time));

                if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd"))
                {

                    if (dt.Hour == 2)
                    {
                        TemperControlEnable(true, false, false, false, false, false);
                    }
                    else if (dt.Hour == 6)
                    {
                        TemperControlEnable(true, true, false, false, false, false);
                    }
                    else if (dt.Hour == 10)
                    {
                        TemperControlEnable(true, true, true, false, false, false);
                    }
                    else if (dt.Hour == 14)
                    {
                        TemperControlEnable(true, true, true, true, false, false);
                    }
                    else if (dt.Hour == 18)
                    {
                        TemperControlEnable(true, true, true, true, true, false);
                    }
                    else if (dt.Hour == 22)
                    {
                        TemperControlEnable(true, true, true, true, true, true);
                    }
                }
                else
                {
                    DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(time).ToString("yyyy-MM-dd"));
                    if (Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")) > dt1)
                    {
                        TemperControlEnable(false, false, false, false, false, false);
                        this.btnSure.Enabled = false;
                    }
                    else if (Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")) < dt1)
                    {
                        TemperControlEnable(true, true, true, true, true, true);
                    }
                }
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
                    switch (hour)
                    {
                        case 2:
                            this.tw2am.setTempers(dt1.Rows[i], hour.ToString());

                            foreach (string var in this.tw2am.oldOperations)
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

                            if (tw2am.Painmothed != "")
                            {
                                GetSelectItem(tw2am.Painmothed);
                            }
                            break;
                        case 6:
                            this.tw6am.setTempers(dt1.Rows[i], hour.ToString());

                            foreach (string var in this.tw6am.oldOperations)
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

                            if (tw6am.Painmothed != "")
                            {
                                GetSelectItem(tw6am.Painmothed);
                            }
                            break;
                        case 10:
                            this.tw10am.setTempers(dt1.Rows[i], hour.ToString());

                            foreach (string var in this.tw10am.oldOperations)
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

                            if (tw10am.Painmothed != "")
                            {
                                GetSelectItem(tw10am.Painmothed);
                            }
                            break;
                        case 14:
                            this.tw2pm.setTempers(dt1.Rows[i], hour.ToString());

                            foreach (string var in this.tw2pm.oldOperations)
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

                            if (tw2pm.Painmothed != "")
                            {
                                GetSelectItem(tw2pm.Painmothed);
                            }
                            break;
                        case 18:
                            this.tw6pm.setTempers(dt1.Rows[i], hour.ToString());

                            foreach (string var in this.tw6pm.oldOperations)
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

                            if (tw6pm.Painmothed != "")
                            {
                                GetSelectItem(tw6pm.Painmothed);
                            }
                            break;
                        case 22:
                            this.tw10pm.setTempers(dt1.Rows[i], hour.ToString());

                            foreach (string var in this.tw10pm.oldOperations)
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

                            if (tw10pm.Painmothed != "")
                            {
                                GetSelectItem(tw10pm.Painmothed);
                            }
                            break;
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
                
                ////药物过敏
                //if (dt2.Rows[0]["Sensi"].ToString() == "")
                //{
                //    TimeSpan ts_ = SelectTime.Date - dt_intime.Date;
                //    if ((ts_.Days + 1) % 7 == 1)
                //    {
                //        string sensi = App.ReadSqlVal("select sensi from t_temperature_info where patient_id='" + this.pid_ids + "' order by record_time desc", 0, "sensi");
                //        this.txtSensi.Text = sensi;
                //    }
                //}
                //else
                //{
                //    this.txtSensi.Text = dt2.Rows[0]["Sensi"].ToString();
                //}

                ////this.txtDragInfact.Text = dt2.Rows[0]["Special"].ToString();

                //////空白列名称1
                //string stremptyname1 = dt2.Rows[0]["empty_name1"].ToString();
                //txtEmptyItemName1.Text = stremptyname1;
                ////空白列值1
                //string stremptyvalue1 = dt2.Rows[0]["empty_value1"].ToString();
                //txtEmptyItemValue1.Text = stremptyvalue1;
                //////空白列名称2
                //string stremptyname2 = dt2.Rows[0]["empty_name2"].ToString();
                //txtEmptyItemName2.Text = stremptyname2;
                ////空白列值2
                //string stremptyvalue2 = dt2.Rows[0]["empty_value2"].ToString();
                //txtEmptyItemValue2.Text = stremptyvalue2;

                //////空白列名称3
                //string stremptyname3 = dt2.Rows[0]["empty_name3"].ToString();
                //txtEmptyItemName3.Text = stremptyname3;
                ////空白列值3
                //string stremptyvalue3 = dt2.Rows[0]["empty_value3"].ToString();
                //txtEmptyItemValue3.Text = stremptyvalue3;
                //////空白列名称4
                //string stremptyname4 = dt2.Rows[0]["empty_name4"].ToString();
                //txtEmptyItemName4.Text = stremptyname4;
                ////空白列值4
                //string stremptyvalue4 = dt2.Rows[0]["empty_value4"].ToString();
                //txtEmptyItemValue4.Text = stremptyvalue4;

                //////空白列名称5
                //string stremptyname5 = dt2.Rows[0]["empty_name5"].ToString();
                //txtEmptyItemName5.Text = stremptyname5;
                ////空白列值5
                //string stremptyvalue5 = dt2.Rows[0]["empty_value5"].ToString();
                //txtEmptyItemValue5.Text = stremptyvalue5;

                ////出总量
                //if (dt2.Rows[0]["out_amount"].ToString() != "")
                //{
                //    this.txtOut.Text = dt2.Rows[0]["out_amount"].ToString();
                //}
                //else
                //{
                //    this.txtOut.Text = "";
                //}
            }

            #endregion
        }

        DataTable PatientAllSection = null;

        void LoadPageInfo()
        {
            string sql = " select a.id,a.pageindex,a.bedno,a.diagnose,a.diagnose_count,section_name,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + this.pid_ids + "' and a.pageindex='" + this.pageindex + "'";

            DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            if (pageheadtable.Rows.Count > 0)
            {
                this.txtbedno.Text = pageheadtable.Rows[0]["bedno"].ToString();
                this.txtDiagnose.Text = pageheadtable.Rows[0]["diagnose"].ToString();
                //this.DiagnoseCount = pageheadtable.Rows[0]["diagnose_count"].ToString();
                if (!string.IsNullOrEmpty(pageheadtable.Rows[0]["section_name"].ToString()))
                {
                    //this.cmbSection.SelectedValue = pageheadtable.Rows[0]["section_name"].ToString();
                    //this.txtSection.Text = pageheadtable.Rows[0]["section_name"].ToString();
                }
                else
                {
                    //this.cmbSection.SelectedValue = App.ReadSqlVal("select section_name from t_in_patient a where a.id='" + pid_ids + "'", 0, "section_name");
                    //this.txtSection.Text = App.ReadSqlVal("select section_name from t_in_patient a where a.id='" + pid_ids + "'", 0, "section_name");
                }
            }
            else
            {
                //this.txtBedNo.Text = this.bed_no;
                //this.txtSection.Text = App.ReadSqlVal("select section_name from t_in_patient a where a.id='" + pid_ids + "'", 0, "section_name");


            }
            //if (DiagnoseCount.Length > 0)
            //{
            //    //this.txtDiagnose.Text = Diagnose;
            //}
            //else
            //{
            //    GetDiagnose();
            //    //this.txtDiagnose.Text = Diagnose;
            //}
        }

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
            this.tw2am.Clear();
            this.tw6am.Clear();
            this.tw10am.Clear();
            this.tw2pm.Clear();
            this.tw6pm.Clear();
            this.tw10pm.Clear();
        }

        private void ClearOtherInfo()
        {
            //this.txtbedno.Text = "";
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

            this.txtEmptyItemName1.Text = "";
            this.txtEmptyItemValue1.Text = "";
            this.txtEmptyItemName2.Text = "";
            this.txtEmptyItemValue2.Text = "";
            this.txtEmptyItemName3.Text = "";
            this.txtEmptyItemValue3.Text = "";
            this.txtEmptyItemName4.Text = "";
            this.txtEmptyItemValue4.Text = "";
            this.txtEmptyItemName5.Text = "";
            this.txtEmptyItemValue5.Text = "";            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker_Select_ValueChanged(object sender, EventArgs e)
        {
            //IniPiansMothed();
            //获取当前时间
            SelectTime = this.dateTimePicker_Select.Value;

            #region 加载时间
            this.tw2am.IsHowTime = 2;//2点
            //this.tw2am.IsQiXian = chkQX.Checked;
            //this.tw2am.lbTime.Text = this.tw2am.IsHowTime.ToString() + ":00";
            //this.tw2am.ckqixian.Checked = chkQX.Checked;
            this.tw2am.CurDateTime = SelectTime.Date;

            this.tw6am.IsHowTime = 6;//6点
            //this.tw6am.IsQiXian = chkQX.Checked;
            //this.tw6am.lbTime.Text = this.tw6am.IsHowTime.ToString() + ":00";
            //this.tw6am.ckqixian.Checked = chkQX.Checked;
            this.tw6am.CurDateTime = SelectTime.Date;

            this.tw10am.IsHowTime = 10;//10点
            //this.tw10am.IsQiXian = chkQX.Checked;
            //this.tw10am.lbTime.Text = this.tw10am.IsHowTime.ToString() + ":00";
            //this.tw10am.ckqixian.Checked = chkQX.Checked;
            this.tw10am.CurDateTime = SelectTime.Date;

            this.tw2pm.IsHowTime = 14;//下午14点
            //this.tw2pm.IsQiXian = chkQX.Checked;
            //this.tw2pm.lbTime.Text = this.tw2pm.IsHowTime.ToString() + ":00";
            //this.tw2pm.ckqixian.Checked = chkQX.Checked;
            this.tw2pm.CurDateTime = SelectTime.Date;

            this.tw6pm.IsHowTime = 18;//下午18点
            //this.tw6pm.IsQiXian = chkQX.Checked;
            //this.tw6pm.lbTime.Text = this.tw6pm.IsHowTime.ToString() + ":00";
            //this.tw6pm.ckqixian.Checked = chkQX.Checked;
            this.tw6pm.CurDateTime = SelectTime.Date;

            this.tw10pm.IsHowTime = 22;//下午22点
            //this.tw10pm.IsQiXian = chkQX.Checked;
            //this.tw10pm.lbTime.Text = this.tw10pm.IsHowTime.ToString() + ":00";
            //this.tw10pm.ckqixian.Checked = chkQX.Checked;
            this.tw10pm.CurDateTime = SelectTime.Date;
            #endregion

            GetPageIndex();
            //lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToString("yyyy-MM-dd") + "<<";
            //lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToString("yyyy-MM-dd");     
            //inRoom();
            //if (!IsFirst)
            //{
            ClearInfo();
            //}
            if (CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
            {
                string dateTime = SelectTime.ToString("yyyy-MM-dd");

                if (!DBControl.SelectGreaterZero(dateTime, this.pid_ids))
                {
                    lists = DBControl.GetTemper(dateTime, this.pid_ids);
                    LoadAll(lists);
                    lists.Clear();
                }
                else
                {
                    TimeSpan ts_ = SelectTime.Date - dt_intime.Date;
                    if ((ts_.Days + 1) % 7 == 1)
                    {
                        string sensi = App.ReadSqlVal("select sensi from t_temperature_info where patient_id='" + this.pid_ids + "' order by record_time desc", 0, "sensi");
                        this.txtSensi.Text = sensi;
                    }
                }
            }
            //附一未用到注掉
            //LoadEmptyRowInfo();
            inRooms();
            
        }

        private void frmTemperWrite_Load(object sender, EventArgs e)
        {

        }

        private void tw6pm_Load(object sender, EventArgs e)
        {

        }

        private void tw2am_Load(object sender, EventArgs e)
        {

        }

        private void tw6am_Load(object sender, EventArgs e)
        {

        }

        private void cboPainGradesMothed_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboPainGradesMothed.SelectedItem != null)
            //{
            //    Class_SelectObj temp = (Class_SelectObj)cboPainGradesMothed.SelectedItem;
            //    this.tw2am.Painmothed = temp.Select_Val;
            //    this.tw6am.Painmothed = temp.Select_Val;
            //    this.tw10am.Painmothed = temp.Select_Val;
            //    this.tw2pm.Painmothed = temp.Select_Val;
            //    this.tw6pm.Painmothed = temp.Select_Val;
            //    this.tw10pm.Painmothed = temp.Select_Val;
            //}
        }

        private void txtDragInfact_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Down)
            //    {
            //        App.SelectFastCodeCheck();
            //    }
            //    else if (e.KeyCode == Keys.Left)
            //    {

            //    }
            //    else if (e.KeyCode == Keys.Right)
            //    {

            //    }
            //    else if (e.KeyCode == Keys.Escape)
            //    {
            //        App.HideFastCodeCheck();
            //    }
            //    else
            //    {
            //        if (!App.FastCodeFlag)
            //        {
            //            if (txtDragInfact.Text.Trim() != "")
            //            {
            //                App.SelectObj = null;
            //                string sql_select = "select id as 编号,name as 名称 from t_data_code d where d.type=195 and upper(d.shortcut_code) like '" + txtDragInfact.Text.ToUpper().Trim() + "%'";
            //                App.FastCodeCheck(sql_select, txtDragInfact, "名称", "编号");
            //            }
            //        }
            //        App.FastCodeFlag = false;
            //    }
            //}
            //catch
            //{ }
            //finally
            //{
            //    App.FastCodeFlag = false;
            //}
        }

        private void cmbBp_TextChanged(object sender, EventArgs e)
        {
            string str = cmbBp.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (this.txtBedNo.Text.Trim().Length > 0)
            //{
            //    this.txtBedNo.Text += "→";
            //}
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

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            //if (cmbSection.SelectedValue == null)
            //{
            //    App.Msg("请选择一个科室！");
            //    return;
            //}
            //if (txtSection.Text.Length == 0)
            //{
            //    txtSection.Text = cmbSection.SelectedValue.ToString();
            //}
            //else
            //{
            //    string[] sections = txtSection.Text.Split(new string[] { "→" }, StringSplitOptions.None);
            //    if (sections[sections.Length-1].Equals(cmbSection.SelectedValue.ToString()))
            //    {
            //        App.Msg("转出转入科室不能为同一个科室,请重新添加！");
            //        return;
            //    }
            //    else
            //    {
            //        txtSection.Text += "→" + cmbSection.SelectedValue.ToString();
            //    }
            //}
        }

        private void btnClearSection_Click(object sender, EventArgs e)
        {
            //if (txtSection.Text.Length > 0)
            //{
            //    txtSection.Text = string.Empty;
            //    string[] sections = txtSection.Text.Split(new string[] { "→" }, StringSplitOptions.None);
            //    for (int i = 0; i < sections.Length - 1; i++)
            //    {
            //        if (i == 0)
            //        {
            //            txtSection.Text = sections[i];
            //        }
            //        else
            //        {
            //            txtSection.Text += "→" + sections[i];
            //        }
            //    }
            //}
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
            string strInsertText = "→";
            int start = this.txt.SelectionStart;
            this.txt.Text = this.txt.Text.Insert(start, strInsertText);
            this.txt.Focus();
            this.txt.SelectionStart = start;
            this.txt.SelectionLength = strInsertText.Length;
        }

    }

}