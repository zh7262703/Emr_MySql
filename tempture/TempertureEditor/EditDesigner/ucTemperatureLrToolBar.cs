using Bifrost;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.EditDesigner.tlElement;
using TempertureEditor.Tempreture_Management;

namespace TempertureEditor.EditDesigner
{
    partial class ucAiTemperature
    {
        private void Register_ucTemperatureLrToolBar(Control sender, params Control[] controls)
        {
            #region 注册接口:增加特殊控件处理函数后,在此添加新函数至容器

            //控件事件,
            RegisterEventSubHandler("btn_up_Click", btn_up_Click);
            RegisterEventSubHandler("btn_next_Click", btn_next_Click);
            RegisterEventSubHandler("cboPageIndex_SelectedIndexChanged", cboPageIndex_SelectedIndexChanged);
            RegisterEventSubHandler("writerTime_SelectedIndexChanged", writerTime_SelectedIndexChanged);
            RegisterEventSubHandler("TemperTypeChanged", TemperTypeChanged);
            RegisterEventSubHandler("ControlTemperatureVisable", ControlTemperatureVisable);
            RegisterEventSubHandler("ckChu_CheckedChanged", ckChu_CheckedChanged);
            RegisterEventSubHandler("ckBreath_CheckedChanged", ckBreath_CheckedChanged);
            RegisterEventSubHandler("ckHeartRate_CheckedChanged", ckHeartRate_CheckedChanged);
            RegisterEventSubHandler("cbAddEvent_SelectedIndexChanged", cbAddEvent_SelectedIndexChanged);
            RegisterEventSubHandler("ListBoxAddItem", ListBoxAddItem);
            RegisterEventSubHandler("ListBoxRemoveItem", ListBoxRemoveItem);
            RegisterEventSubHandler("btnSure_Click", btnSure_Click);
            RegisterEventSubHandler("btnReset_Click", btnReset_Click);

            #endregion

            #region 注册自定义事件处理接口
            RegisterCustomEventHandler("ucTemperatureLrToolBar_Load", ucTemperatureLrToolBar_Load);
            RegisterCustomEventHandler("LoadPageInfo", LoadPageInfo);
            RegisterCustomEventHandler("setDateTimeMinOrMax", setDateTimeMinOrMax);
            RegisterCustomEventHandler("cboTime_LoadItemsByTemplate", cboTime_LoadItemsByTemplate);
            RegisterCustomEventHandler("cboTime_SelectIndexByNowTime", cboTime_SelectIndexByNowTime);
            RegisterCustomEventHandler("enableInputByInHospitalTime", enableInputByInHospitalTime);
            RegisterCustomEventHandler("TemperClear", TemperClear);
            RegisterCustomEventHandler("RefreshData", RefreshData);
            RegisterCustomEventHandler("GetEndOperaterEndTime", GetEndOperaterEndTime);
            #endregion

        }



        #region 控件事件处理
        private void cboPageIndex_SelectedIndexChanged(Control sender, params Control[] controls)
        {
            ComboBox cboPageIndex = (ComboBox)sender;
            pageSelectedIndex = cboPageIndex.SelectedIndex;
            if (cboPageIndex.SelectedIndex != -1 && cboPageIndex.Items.Count > 0)
            {
                //初始化一周体温单的开始和结束时间this.startDate, this.endDate
                //panel1.AutoScrollPosition = new Point(0, 0);
                string tempString = cboPageIndex.SelectedItem.ToString();
                StarToEndTime(tempString);

                //设置dateTimePicker_Select可选范围
                ucAiTemperatureCustomEventHnadler("MSG_setDateTimeMinOrMax");

                //重新加载体温单数据,并绘制
                ((ucAiTemperature)this.Parent.Parent.Parent).ucAiTemperatureCustomEventHnadler("MSG_TemperatureReportRefreshData");
            }
        }

        private void writerTime_SelectedIndexChanged(Control sender, params Control[] controls)
        {
            DateTimePicker dateTimePicker_Select = (DateTimePicker)controls[0];
            ComboBox cboTime = (ComboBox)controls[1];
            Label lbTime = (Label)controls[2];
            lbTime.Text = cboTime.Text;
            string text = cboTime.Text;
            if (text == "24:00")
            {
                text = "00:00";
            }

            SelectTime = Convert.ToDateTime(dateTimePicker_Select.Value.ToString("yyyy-MM-dd ") + text);
            ucAiTemperatureCustomEventHnadler("MSG_cboTime_enableInputByInHospitalTime");
            //重置录入窗口
            ucAiTemperatureCustomEventHnadler("MSG_TemperClear");
            ucAiTemperatureCustomEventHnadler("MSG_RefreshData");

        }
        private void TemperTypeChanged(Control sender, params Control[] controls)
        {
            ComboBox cbTemperType = (ComboBox)controls[0];
            TextBox txtTemper = (TextBox)controls[1];
            CheckBox ckReiteration = (CheckBox)controls[2];

            if (ckReiteration.Checked)
            {
                _clmb.dicVars[txtTemper.Name] = _clmb.dicVars[cbTemperType.Text] + "复测";
            }
            else
            {
                _clmb.dicVars[txtTemper.Name] = _clmb.dicVars[cbTemperType.Text];
            }

        }

        private void btn_up_Click(Control sender, params Control[] controls)
        {
            ComboBox cboPageIndex = (ComboBox)controls[0];
            if (cboPageIndex.SelectedIndex != -1 && cboPageIndex.Items.Count > 0)
            {
                if (cboPageIndex.SelectedIndex != 0)
                {
                    cboPageIndex.SelectedIndex -= 1;
                }
                else
                {
                    App.Msg("已经是第一页！");
                }
            }
        }

        private void btn_next_Click(Control sender, params Control[] controls)
        {
            ComboBox cboPageIndex = (ComboBox)controls[0];
            if (cboPageIndex.SelectedIndex != -1 && cboPageIndex.Items.Count > 0)
            {
                if (cboPageIndex.SelectedIndex != cboPageIndex.Items.Count - 1)
                {
                    cboPageIndex.SelectedIndex += 1;
                }
                else
                {
                    App.Msg("已经是最后一页！");
                }
            }
        }

        private void ControlTemperatureVisable(Control sender, params Control[] controls)
        {
            float highTemper = float.Parse(_clmb.dicVars["HighTemper"]);
            TextBox txtTemper = (TextBox)controls[0];
            TextBox txtDown = (TextBox)controls[1];
            Label lbDown = (Label)controls[2];

            if (txtTemper.Text.Trim() != "")
            {
                txtDown.Visible = lbDown.Visible = (float.Parse(txtTemper.Text) >= highTemper);
                txtDown.Enabled = lbDown.Enabled = (float.Parse(txtTemper.Text) >= highTemper);
            }
            else
            {
                txtDown.Visible = txtDown.Enabled = false;
            }
        }

        private void ckChu_CheckedChanged(Control sender, params Control[] controls)
        {
            CheckBox ckChu = (CheckBox)sender;
            TextBox txtHeart = (TextBox)controls[0];
            CheckBox ckHeartRate = (CheckBox)controls[1];

            if (!ckChu.Checked)
                txtHeart.Text = "";
            txtHeart.Enabled = ckChu.Checked;
            ckHeartRate.Enabled = ckChu.Checked;
        }

        private void ckBreath_CheckedChanged(Control sender, params Control[] controls)
        {
            CheckBox ckBreath = (CheckBox)sender;
            TextBox txtBreathing = (TextBox)controls[0];

            if (_clmb.dicVars[txtBreathing.Name] != "呼吸次数")
            {
                if (ckBreath.Checked)
                {
                    _clmb.dicVars[txtBreathing.Name] = "辅助呼吸";
                }
                else
                {
                    _clmb.dicVars[txtBreathing.Name] = "呼吸";
                }
            }
        }

        private void ckHeartRate_CheckedChanged(Control sender, params Control[] controls)
        {
            CheckBox ckHeartRate = (CheckBox)sender;
            TextBox txtHeart = (TextBox)controls[0];

            if (ckHeartRate.Checked)
            {
                _clmb.dicVars[txtHeart.Name] = "起搏心率";
            }
            else
            {
                _clmb.dicVars[txtHeart.Name] = "心率";
            }
        }

        private void cbAddEvent_SelectedIndexChanged(Control sender, params Control[] controls)
        {
            ComboBox cbAddEvent = (ComboBox)sender;
            DateTimePicker dtpSurgeryEndTime = (DateTimePicker)controls[0];

            if (cbAddEvent.Text == "手术")
            {
                dtpSurgeryEndTime.Enabled = true;
            }
            else
            {
                dtpSurgeryEndTime.Enabled = false;
            }

        }

        private void ListBoxAddItem(Control sender, params Control[] controls)
        {
            ListBox listBox = (ListBox)controls[0];
            ComboBox cbAddEvent = (ComboBox)controls[1];
            ComboBox cboTime = (ComboBox)controls[2];
            DateTimePicker dtpAddEventTime = (DateTimePicker)controls[3];
            List<string> listExcludeEvents = new List<string>(_clmb.dicVars["ExcludeEvents"].Split(','));
            if (!listExcludeEvents.Contains(cbAddEvent.Text))
            {
                //判断事件时间有效性
                if (!checkEventTimeValid(cboTime.Text, dtpAddEventTime.Value))
                    return;

                string even = tempetureDataComm.ConvertOptEventToDBString(dtpAddEventTime.Value, cbAddEvent.Text);
                listBox.Items.Add(even);

            }

        }

        private void ListBoxRemoveItem(Control sender, params Control[] controls)
        {
            ListBox listBox = (ListBox)controls[0];

            if (listBox.Items.Count > 0)
            {
                if (listBox.SelectedItem != null)
                {
                    listBox.Items.Remove(listBox.SelectedItem);
                }
            }
        }

        private void btnSure_Click(Control sender, params Control[] controls)
        {
            DateTimePicker dateTimePicker_Select = (DateTimePicker)controls[0];
            GroupBox groupBox1 = (GroupBox)controls[1];
            GroupBox groupBox2 = (GroupBox)controls[2];


            DateTime sysTime = App.GetSystemTime();
            if (dateTimePicker_Select.Value.Date > sysTime.Date || dateTimePicker_Select.Value.Date > Convert.ToDateTime(endDate) ||
               dateTimePicker_Select.Value.Date < Convert.ToDateTime(startDate))
            {
                App.MsgWaring("选择的日期不正确，只能选择当前页七天的日期范围，并且不能超过当前日期，否则无法保存!");
            }

            string measureRemark = "";
            string valCategory = "";
            string ctype = "";
            string l_val = "";
            string lsql = "";
            List<string> sqls = new List<string>();

            //清除当前时间点数据            
            sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                     " and template_type='" + _templateType + "' and  MEASURE_TIME=to_date('" + SelectTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')");

            for (int i = 3; i < controls.Length; i++)
            {
                int index = listWinControls.IndexOf(controls[i]);
                string type = _clmb.listTlControls[index].Type;

                    ctype = _clmb.dicVars[controls[i].Name];
                    if (groupBox2.Controls.Contains(controls[i])) //按天录入数据
                    {
                        lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                               " and template_type='" + _templateType + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
                        sqls.Add(lsql);
                    }

                    if (controls[i].Visible == false || controls[i].Enabled == false)
                    {
                        continue;   //不可见或不可操作控件直接跳过
                    }

                    l_val = ""; //初始化为空
                    if (type == "ComboBox")
                    {
                        ComboBox winControl = (ComboBox)controls[i];

                        if (winControl.DropDownStyle == ComboBoxStyle.DropDownList)
                        {
                            if (winControl.Items.Count > 0)
                            {
                                l_val = winControl.Items[winControl.SelectedIndex].ToString();

                                List<string> listExcludeEvents = new List<string>(_clmb.dicVars["ExcludeEvents"].Split(','));
                                if (listExcludeEvents.Contains(l_val))
                                {
                                    l_val = "";
                                }
                            }
                        }
                        else
                        {
                            l_val = winControl.Text.Trim();
                        }
                        if (l_val != "")
                        {
                            sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, _templateType, measureRemark, valCategory));
                        }
                    }
                    else if (type == "TextBox")
                    {
                        TextBox winControl = (TextBox)controls[i];

                        l_val = winControl.Text.Trim();

                        if (l_val != "")
                        {
                            sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, _templateType, measureRemark, valCategory));
                        }
                    }
                    else if (type == "CheckBox")
                    {
                        CheckBox winControl = (CheckBox)controls[i];

                        if (winControl.Checked)
                        {
                            l_val = "Y";
                        }

                        if (l_val != "")
                        {
                            sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, _templateType, measureRemark, valCategory));
                        }
                    }
                    else if (type == "ListBox")
                    {
                        ListBox winControl = (ListBox)controls[i];

                        foreach (object strval in winControl.Items)
                        {
                            l_val = strval.ToString();

                            string Operater_start_time = "";
                            if (ctype == "操作事件")
                            {
                                Operater_start_time = Convert.ToDateTime(SelectTime).ToString("yyyy-MM-dd") + " " + strval.ToString().Split('_')[1];

                                if (l_val.Contains("手术"))
                                {
                                    ucAiTemperatureCustomEventHnadler("MSG_GetEndOperaterEndTime");
                                    sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, "手术结束时间", Operater_end_time, Convert.ToDateTime(Operater_start_time), _templateType, measureRemark, valCategory));

                                    #region 以下是质控数据库更新

                                    if (!listOldOptStartTime.Contains(Operater_start_time))
                                    {
                                        string operation_startTime = Operater_start_time;
                                        string sql_operation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age) values('" + tPatInfo.PId + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','yyyy-mm-dd hh24:mi')," + tPatInfo.Id.ToString() + "," + tPatInfo.Age + ")";
                                        sqls.Add(sql_operation);
                                    }
                                    else
                                    {
                                        listOldOptStartTime.Remove(Operater_start_time);
                                    }
                                    if (oldOptOEndtime != Operater_end_time)
                                    {
                                        string operation_endTime = Operater_end_time;

                                        if (oldOptOEndtime != "")
                                        {
                                            string sql_updateOld = "update t_job_temp set event_type='-' where OPERATE_TYPE='" + operater_types + "' and to_char(OPERATE_TIME, 'yyyy-mm-dd hh24:mi')='" + oldOptOEndtime + "' and PATIENT_ID=" + tPatInfo.Id.ToString();
                                            sqls.Add(sql_updateOld);
                                        }
                                        string sql_operations = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age) values('" + tPatInfo.PId + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','yyyy-mm-dd hh24:mi')," + tPatInfo.Id.ToString() + "," + tPatInfo.Age + ")";
                                        sqls.Add(sql_operations);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    Operater_start_time = SelectTime.ToString("yyyy-MM-dd HH:mm");
                                }
                                if (l_val != "")
                                {
                                    sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, Convert.ToDateTime(Operater_start_time), _templateType, measureRemark, valCategory));
                                }
                            }
                        }

                        #region 以下是质控数据库更新
                        foreach (string oldStartTime in listOldOptStartTime)
                        {
                            string sql_updateOld = "update t_job_temp set event_type='-' where OPERATE_TYPE='" + operater_type + "' and to_char(OPERATE_TIME, 'yyyy-mm-dd hh24:mi')='" + oldStartTime + "' and PATIENT_ID=" + tPatInfo.Id.ToString();
                            sqls.Add(sql_updateOld);

                            //术后
                            sql_updateOld = "update t_job_temp set event_type='-' where OPERATE_TYPE='" + operater_types + "' and to_char(OPERATE_TIME, 'yyyy-mm-dd hh24:mi')='" + oldOptOEndtime + "' and PATIENT_ID=" + tPatInfo.Id.ToString();
                            sqls.Add(sql_updateOld);
                        }
                        #endregion

                    }
                    else if (type == "DateTimePicker")
                    {
                        DateTimePicker winControl = (DateTimePicker)controls[i];

                        l_val = winControl.Value.ToString("yyyy-MM-dd HH:mm");

                        sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, winControl.Value, _templateType, measureRemark, valCategory));
                    }
                }

            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                App.Msg("操作已经成功！");

                //重新加载体温单数据,并绘制
                ((ucAiTemperature)this.Parent.Parent.Parent).ucAiTemperatureCustomEventHnadler("MSG_TemperatureReportRefreshData");

                //重新计算并加载页码信息
                this.ucAiTemperatureCustomEventHnadler("MSG_LoadPageInfo");
                this.ucAiTemperatureCustomEventHnadler("MSG_TemperClear");
                this.ucAiTemperatureCustomEventHnadler("MSG_RefreshData");
            }
            else
            {
                App.Msg("操作失败！");
            }

        }

        private void btnReset_Click(Control sender, params Control[] controls)
        {
            ucAiTemperatureCustomEventHnadler("MSG_TemperClear");

        }

        #endregion

        #region 自定义事件处理


        private void ucTemperatureLrToolBar_Load(Control sender, params Control[] controls)
        {

        }

        private void LoadPageInfo(Control sender, params Control[] controls)
        {
            ComboBox cboPageIndex = (ComboBox)controls[0];

            DateTime inDatetime = Convert.ToDateTime(tPatInfo.In_Time.ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = App.GetDataSet(string.Format("select aa.VALTYPE_TIME from t_temperature_record aa where " +
                              "aa.valtype ='操作事件' and (aa.t_val like '出院%' or aa.t_val like '死亡%') and patient_id={0} and template_type='{1}'  order by aa.VALTYPE_TIME asc", tPatInfo.Id.ToString(), _templateType)).Tables[0];
            outTime = null;
            if (dt.Rows.Count > 0)
            {
                outTime = Convert.ToDateTime(dt.Rows[0]["VALTYPE_TIME"]);
                today = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0]["VALTYPE_TIME"]).ToString("yyyy-MM-dd"));
            }

            TimeSpan ts1 = new TimeSpan(inDatetime.Ticks);
            TimeSpan ts2 = new TimeSpan(today.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int weekCount = 0;
            const int dayCountPerWeek = 7;
            if ((ts.Days + 1) % dayCountPerWeek == 0)
                weekCount = (ts.Days + 1) / dayCountPerWeek;
            else
                weekCount = (ts.Days + 1) / dayCountPerWeek + 1;

            string temper = "";
            cboPageIndex.Items.Clear();
            for (int i = 0; i < weekCount; i++)
            {
                temper = "第" + (i + 1).ToString() + "页(" + inDatetime.AddDays(i * dayCountPerWeek).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * dayCountPerWeek + dayCountPerWeek - 1).ToString("yyyy-MM-dd") + ")";
                cboPageIndex.Items.Add(temper);
                temper = "";
            }

            cboPageIndex.SelectedIndex = cboPageIndex.Items.Count - 1;

        }

        /// <summary>
        /// 设置可操作日期段
        /// </summary>
        /// <param name="dateT"></param>
        private void setDateTimeMinOrMax(Control sender, params Control[] controls)
        {

            DateTimePicker dateTimePicker_Select = (DateTimePicker)controls[0];

            DateTime sysTime = App.GetSystemTime();
            //先还原默认,再重设
            dateTimePicker_Select.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePicker_Select.MaxDate = DateTimePicker.MaximumDateTime;

            dateTimePicker_Select.MinDate = Convert.ToDateTime(startDate).Date;

            if (outTime != null && ((DateTime)outTime).Date >= Convert.ToDateTime(startDate).Date && ((DateTime)outTime).Date < Convert.ToDateTime(endDate).Date)
            {
                if (sysTime.Date <= ((DateTime)outTime).Date)
                {
                    dateTimePicker_Select.MaxDate = sysTime.Date;
                }
                else
                    dateTimePicker_Select.MaxDate = ((DateTime)outTime).Date;
            }
            else
            {
                if (sysTime.Date <= Convert.ToDateTime(endDate).Date)
                    dateTimePicker_Select.MaxDate = sysTime.Date;
                else
                    dateTimePicker_Select.MaxDate = Convert.ToDateTime(endDate).Date;
            }
        }
        /// <summary>
        /// 根据当模板类型加载录入时间点选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="controls"></param>
        private void cboTime_LoadItemsByTemplate(Control sender, params Control[] controls)
        {
            ComboBox cboTime = (ComboBox)controls[0];

            string[] times = tempetureDataComm.GetTemperatureWriteTime(_templateType);

            cboTime.Items.Clear();
            cboTime.Items.AddRange(times);
        }
        /// <summary>
        /// 根据当前时间初始化cboTime-录入时间点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="controls"></param>
        private void cboTime_SelectIndexByNowTime(Control sender, params Control[] controls)
        {
            ComboBox cboTime = (ComboBox)controls[0];
            DateTime dt = App.GetSystemTime();

            DateTime dtWrite = tempetureDataComm.GetInsertDateTime(dt, _templateType);

            string sWriteTime = dtWrite.ToString("HH:mm");
            int index = 0;
            for (; index < cboTime.Items.Count; index++)
            {
                if (cboTime.Items[index].ToString() == sWriteTime)
                {
                    break;
                }
            }

            if (index < cboTime.Items.Count)
            {
                cboTime.SelectedIndex = index;
            }
        }

        /// <summary>
        /// 控制入院前时间点禁止录入
        /// </summary>
        /// <param name="dtInHostpital">入院时间</param>
        /// <param name="dtEnableTime">校验时间点</param>
        /// <returns></returns>
        private void enableInputByInHospitalTime(Control sender, params Control[] controls)
        {
            GroupBox groupBox1 = (GroupBox)controls[0];
            GroupBox groupBox2 = (GroupBox)controls[1];

            DateTime dtInHostpital = tPatInfo.In_Time;
            DateTime dtEnableTime = SelectTime;
            DateTime dtStart = new DateTime();
            DateTime dtEnd = new DateTime();

            tempetureDataComm.GetDateTimeRangeByMeasure(dtEnableTime, dtInHostpital, ref dtStart, ref dtEnd, _templateType);

            //精确到分后,进行比较
            dtInHostpital = Convert.ToDateTime(dtInHostpital.ToString("yyyy-MM-dd HH:mm"));
            bool bEnable = dtEnd >= dtInHostpital;
            foreach (Control cl in groupBox1.Controls)
            {
                cl.Enabled = bEnable;
            }

            foreach (Control cl in groupBox2.Controls)
            {
                cl.Enabled = bEnable;
            }

            //return bEnable;
        }

        private void TemperClear(Control sender, params Control[] controls)
        {
            GroupBox groupBox1 = (GroupBox)controls[0];
            GroupBox groupBox2 = (GroupBox)controls[1];
            foreach (Control cl in groupBox1.Controls)
            {
                ControlClear(cl);
            }

            foreach (Control cl in groupBox2.Controls)
            {
                ControlClear(cl);
            }

            #region 重置质控相关变量 
            listOldOptStartTime.Clear();
            oldOptOEndtime = "";
            #endregion
        }

        private void RefreshData(Control sender, params Control[] controls)
        {
            GroupBox groupBox1 = (GroupBox)controls[0];
            GroupBox groupBox2 = (GroupBox)controls[1];

            // 按时间点或天分别存储控件
            List<Control> listControls1 = new List<Control>();      //按时间点录入控件
            List<Control> listControls2 = new List<Control>();      //按天录入控件

            for (int i = 2; i < controls.Length; i++)
            {
                if (groupBox1.Controls.Contains(controls[i]))
                {
                    listControls1.Add(controls[i]);
                }
                else if (groupBox2.Controls.Contains(controls[i]))
                {
                    listControls2.Add(controls[i]);
                }
            }

            // 初始化数据
            string sql = "select * from T_TEMPERATURE_RECORD t where t.measure_time=to_date('" +
                               SelectTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and t.patient_id=" + tPatInfo.Id.ToString() +
                               " and t.template_type='" + _templateType + "'";
            DataSet ds = App.GetDataSet(sql);

            foreach (DataRow trow in ds.Tables[0].Rows)
            {
                foreach (Control cl in listControls1)
                {
                    if (trow["VALTYPE"].ToString() == _clmb.dicVars[cl.Name])
                    {
                        SetControlData(cl, trow["T_VAL"].ToString());
                        break;
                    }
                }
            }

            string sql2 = "select * from T_TEMPERATURE_RECORD t where to_char(t.measure_time,'yyyy-MM-dd')='" +
                              SelectTime.ToString("yyyy-MM-dd") + "' and t.patient_id=" + tPatInfo.Id.ToString() +
                              " and t.template_type='" + _templateType + "'";
            DataSet ds2 = App.GetDataSet(sql2);
            foreach (DataRow trow in ds2.Tables[0].Rows)
            {
                foreach (Control cl in listControls2)
                {
                    if (trow["VALTYPE"].ToString() == _clmb.dicVars[cl.Name])
                    {
                        SetControlData(cl, trow["T_VAL"].ToString());
                        break;
                    }
                }
            }
        }
        private void GetEndOperaterEndTime(Control sender, params Control[] controls)
        {
            DateTimePicker dtpSurgeryEndTime = (DateTimePicker)controls[0];

            Operater_end_time = dtpSurgeryEndTime.Value.ToString("yyyy-MM-dd HH:mm");
        }
        #endregion

        #region 本类中辅助函数

        public void ucTemperatureLrToolBar_InitData(InPatientInfo tPatInfo)
        {
            this.tPatInfo = tPatInfo;
            _templateType = ((ucAiTemperature)this.Parent.Parent.Parent).Clmb.TemplateType;

            ucAiTemperatureCustomEventHnadler("MSG_LoadPageInfo");
            ucAiTemperatureCustomEventHnadler("MSG_cboTime_LoadItemsByTemplate");
            ucAiTemperatureCustomEventHnadler("MSG_cboTime_SelectIndexByNowTime");

        }

        /// <summary>
        /// 设置开始时间 结束时间
        /// </summary>
        /// <param name="tempString"></param>
        private void StarToEndTime(string tempString)
        {
            string temp = tempString.Split('(')[1].ToString();
            string howWeek = tempString.Split('(')[0].ToString();
            string weeks = howWeek.Substring(1, howWeek.Length - 2);
            string[] startEndDate = temp.Substring(0, temp.Length - 1).Split('~');
            this.startDate = startEndDate[0];
            this.endDate = startEndDate[1];
        }

        /// <summary>
        /// 根据录入时间点控制事件时间范围
        /// </summary>
        /// <param name="dtAddEvent">dtpAddEventTime.Value</param>
        /// <param name="writeTimes">cboTime.Tex</param>
        /// <returns></returns>
        private bool checkEventTimeValid(string sWriteTime, DateTime dtAddEvent)
        {
            DateTime dtStart = new DateTime();
            DateTime dtEnd = new DateTime();

            DateTime dtMeasure = SelectTime;
            if (sWriteTime == "24:00")
            {
                dtMeasure = SelectTime.AddDays(1);
            }
            if (!tempetureDataComm.GetDateTimeRangeByMeasure(dtMeasure, dtAddEvent, ref dtStart, ref dtEnd, _templateType))
            {
                string tip = string.Format("{0}时间范围：{1}到{2}", sWriteTime, dtStart.ToString("HH:mm"), dtEnd.ToString("HH:mm"));
                App.Msg(tip);
                return false;
            }
            return true;
        }

        #region 生命体征异常值提醒

        //记录异常值范围
        double dTmax = 0;
        double dTmin = 0;
        int iRmax = 0;
        int iRmin = 0;
        int iPmax = 0;
        int iPmin = 0;


        private void LoadSymbolVaildScope()
        {
            string sql = "select * from T_TEMPERATURE_MONITORING";
            DataSet dssql = App.GetDataSet(sql);
            if (dssql != null && dssql.Tables.Count > 0 && dssql.Tables[0].Rows.Count > 0)
            {
                DataRow row = dssql.Tables[0].Rows[0];
                if (!double.TryParse(row["temperaturemin"].ToString(), out dTmin))
                    dTmin = 34;
                if (!double.TryParse(row["temperaturemax"].ToString(), out dTmax))
                    dTmax = 42;
                if (!int.TryParse(row["breathmin"].ToString(), out iRmin))
                    iRmin = 0;
                if (!int.TryParse(row["breathmax"].ToString(), out iRmax))
                    iRmax = 30;
                if (!int.TryParse(row["pulsemin"].ToString(), out iPmin))
                    iPmin = 0;
                if (!int.TryParse(row["pulsemax"].ToString(), out iPmax))
                    iPmax = 230;
            }
            else
            {
                dTmin = 34;
                dTmax = 42;
                iRmin = 0;
                iRmax = 30;
                iPmin = 0;
                iPmax = 230;
            }
        }


        /// <summary>
        /// 录入的值是否需要提示异常信息
        /// </summary>
        /// <param name="Sign"></param>
        /// <param name="SignValue"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        bool IsNeedRemind(string Sign, string SignValue, ref string Msg)
        {
            bool b = false;
            switch (Sign)
            {
                case "体温":
                    double t = 0;
                    double.TryParse(SignValue, out t);
                    if (t < dTmin || t > dTmax)
                    {
                        b = true;
                        Msg = "患者体温必须在" + dTmin.ToString() + "和" + dTmax.ToString() + "之间";
                    }
                    else
                        b = false;
                    break;
                case "呼吸":
                    int r = 0;
                    int.TryParse(SignValue, out r);
                    if (r < iRmin || r > iRmax)
                    {
                        b = true;
                        Msg = "患者呼吸必须在" + iRmin.ToString() + "和" + iRmax.ToString() + "之间";
                    }
                    else
                        b = false;
                    break;
                case "脉搏":
                case "心率":
                    int p = 0;
                    int.TryParse(SignValue, out p);
                    if (p < iPmin || p > iPmax)
                    {
                        b = true;
                        Msg = "患者" + Sign + "必须在" + iPmin.ToString() + "和" + iPmax.ToString() + "之间";
                    }
                    else
                        b = false;
                    break;
                default:
                    b = false;
                    break;
            }
            return b;
        }
        #endregion

        private void ControlClear(Control cl)
        {
            int index = listWinControls.IndexOf(cl);

            if (index >= 0 && index < _clmb.listTlControls.Count)
            {
                cl.Visible = _clmb.listTlControls[index].Visable;
                cl.Enabled = _clmb.listTlControls[index].Enable;

                string type = _clmb.listTlControls[index].Type;
                if (type == "ComboBox")
                {
                    ComboBox winControl = (ComboBox)cl;

                    if (winControl.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        if (winControl.Items.Count > 0)
                        {
                            winControl.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        winControl.Text = "";
                    }
                }
                else if (type == "TextBox")
                {
                    TextBox winControl = (TextBox)cl;

                    winControl.Text = "";
                }
                else if (type == "CheckBox")
                {
                    CheckBox winControl = (CheckBox)cl;

                    winControl.Checked = ((TlCheckBox)_clmb.listTlControls[index]).Checked;
                }
                else if (type == "ListBox")
                {
                    ListBox winControl = (ListBox)cl;

                    winControl.Items.Clear();
                }
                else if (type == "DateTimePicker")
                {
                    DateTimePicker winControl = (DateTimePicker)cl;

                    winControl.Value = SelectTime;
                }

            }
        }

        private void SetControlData(Control cl, string value)
        {
            int index = listWinControls.IndexOf(cl);
            string type = _clmb.listTlControls[index].Type;
            string ctype = _clmb.dicVars[cl.Name];  //数据类型

            if (type == "ComboBox")
            {
                ComboBox winControl = (ComboBox)cl;

                winControl.Text = value;

            }
            else if (type == "TextBox")
            {
                TextBox winControl = (TextBox)cl;

                winControl.Text = value;
            }
            else if (type == "CheckBox")
            {
                CheckBox winControl = (CheckBox)cl;

                winControl.Checked = (value == "Y");
            }
            else if (type == "ListBox")
            {
                ListBox winControl = (ListBox)cl;

                winControl.Items.Add(value);

                if (value.Contains("手术"))
                {
                    listOldOptStartTime.Add(SelectTime.ToString("yyyy-MM-dd") + " " + value.Split('_')[1]);
                }
            }
            else if (type == "DateTimePicker")
            {
                DateTimePicker winControl = (DateTimePicker)cl;

                winControl.Value = Convert.ToDateTime(value);

                if (ctype == "手术结束时间")
                {
                    oldOptOEndtime = winControl.Value.ToString("yyyy-MM-dd HH:mm");
                }
            }
        }
        #endregion

      
    }
}
