using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;


namespace Base_Function.BLL_NURSE.Tempreture_Management
{

    public partial class TemperWrite_Child : UserControl
    {

        public string dtpTimes_date = "";
        private int isHowTime = 0;
        private bool isOkNow = true;
        //this.cbEvent = new comboNoWheel();  
        private DateTime curDateTime;

        public DateTime CurDateTime
        {
            get { return curDateTime; }
            set { curDateTime = value; }
        }
        

        public TemperWrite_Child()
        {
            InitializeComponent();
            this.cbEvent.SelectedIndex = 0;
            this.cbAddEvent.SelectedIndex = 0;
            this.cbTemperType.SelectedIndex = 0;                     

        }

        public int IsHowTime
        {
            get { return this.isHowTime; }
            set { this.isHowTime = value; }
        }

        /// <summary>
        /// 疼痛评分方法
        /// </summary>
        private string painmothed;
        public string Painmothed
        {
            get { return painmothed; }
            set { painmothed = value; }
        }

        private void ckChu_Click(object sender, EventArgs e)
        {
         
        }

       
        /// <summary>
        /// 查询体温信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static List<DataTable> GetTemper(string time, string pid)
        {
            List<DataTable> list = new List<DataTable>();
            DataSet ds = new DataSet();
            string sql = string.Format("select measure_time, " +
                                        "temperature_value, temperature_body, " +
                                        "re_measure, cooling_value, cooling_type," +
                                        "pulse_value, is_briefness, is_assist_hr, " +
                                        "breath_value, is_assist_br, measure_state, " +
                                        "describe, remark, heart_rhythm,operations_time,PAIN_VALUE from t_child_vital_signs WHERE " +
                                        "to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ORDER BY MEASURE_TIME", time, pid);
            DataTable dt1 = App.GetDataSet(sql).Tables[0];       
            list.Add(dt1);           
            return list;
        }


        /// <summary>
        /// 只允许输入数字和小数点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInput_KeyPress(object sender, KeyEventArgs e)
        {
            string AstrictChar = "0123456789";
            string text = (sender as TextBox).Text;
            if (text == "" && (Keys)(e.KeyCode) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }
            if ((Keys)(e.KeyCode) == Keys.Back)
            {
                return;
            }
            if ((Keys)(e.KeyCode) == Keys.Delete)
            {
                if (text.Split('.').Length >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
            string[] arr = text.Split('.');
            if (arr.Length > 1)
            {
                if (arr[1].Length >= 1)
                {
                    e.Handled = true;
                    return;
                }
            }
            if ((Keys)(e.KeyCode) == Keys.Back || (Keys)(e.KeyCode) == Keys.Delete)
            {
                return;
            }
            if (AstrictChar.IndexOf(e.KeyCode.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }
            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        public void setTempers(DataRow dr, string hour)
        {
            isOkNow = false;
            string eventState = dr["measure_state"].ToString();

            if (dr["temperature_body"].ToString() != "")
            {
                this.cbTemperType.SelectedIndex = Convert.ToInt32(dr["temperature_body"].ToString());//体温测量部位
            }
            else
            {
                this.cbTemperType.SelectedIndex = 0;
            }
            if (dr["temperature_value"].ToString() != "" && dr["temperature_value"].ToString() != "0")
            {
                this.txtTemper.Text = float.Parse(dr["temperature_value"].ToString()).ToString("#0.0");//体温测量值

            }
            else
            {
                this.txtTemper.Text = "";
            }

            if (dr["re_measure"].ToString() == "Y") //复测标志
                this.cbReiteration.Checked = true;
            else
                this.cbReiteration.Checked = false;

            if (dr["temperature_value"].ToString() != "" && dr["temperature_value"].ToString() != "0")
            {
                //if (this.txtDown.Visible)
                //{
                if (dr["cooling_value"].ToString() != "" && dr["cooling_value"].ToString() != "0")
                {
                    this.txtDown.Text = float.Parse(dr["cooling_value"].ToString()).ToString("#0.0");
                }
                //}
            }
            if (dr["pulse_value"].ToString() != "" && dr["pulse_value"].ToString() != "0")
            {
                this.txtPulse.Text = dr["pulse_value"].ToString(); //脉搏测量值
            }
            else
            {
                this.txtPulse.Text = "";
            }

            if (dr["is_briefness"].ToString() == "Y")       //脉搏短绌
            {
                this.PulseCheck.Checked = true;
                this.txtHeartRate.Text = "";
                this.txtHeartRate.Enabled = true;
                this.txtHeartRate.Text = dr["heart_rhythm"].ToString();     //心率测量值
            }
            else
                this.PulseCheck.Checked = false;

            if (dr["breath_value"].ToString() != "" && dr["breath_value"].ToString() != "0")
            {
                this.txtBreathing.Text = dr["breath_value"].ToString(); //呼吸测量值
            }
            else
            {
                this.txtBreathing.Text = "";
            }

            //if (dr["PAIN_VALUE"].ToString() != "" && dr["PAIN_VALUE"].ToString() != "0")
            //{
            //    txtPainGrades.Text = dr["PAIN_VALUE"].ToString();
            //    Painmothed = dr["PAIN_MOTHED"].ToString();
            //}
            //else
            //{
            //    txtPainGrades.Text = "";
            //}

            //呼吸辅助器
            if (dr["IS_ASSIST_BR"].ToString() == "Y")
            {
                this.ckBreath.Checked = true;
            }
            else
            {
                this.ckBreath.Checked = false;
            }

            if (eventState != "")
            {
                isOkNow = true;
                switch (eventState) //测量状态
                {
                    case "F":
                        this.cbEvent.SelectedIndex = 1;
                        break;
                    case "O":
                        this.cbEvent.SelectedIndex = 2;
                        break;
                    case "L":
                        this.cbEvent.SelectedIndex = 3;
                        break;
                    case "Q":
                        this.cbEvent.SelectedIndex = 4;
                        break;
                    case "R":
                        this.cbEvent.SelectedIndex = 5;
                        break;
                }
                isOkNow = false;
            }
            else
            {
                //if (this.txtTemper.Text == "" && this.txtPulse.Text == "" && this.txtBreathing.Text == "")
                //{
                //    if (this.cbEvent.SelectedIndex == 1)
                //    {
                //        this.cbEvent.SelectedIndex = 0;
                //    }
                //}
                //else
                //{
                //    this.cbEvent.SelectedIndex = 1;
                //}

            }
            if (dr["describe"].ToString() != "")
            {
                if (lbEvents.Items.Count > 0) { }
                //lbEvents.Items.Clear();
                string[] strs = dr["describe"].ToString().Split('|');
                for (int i = 0; i < strs.Length; i++)
                {
                    this.lbEvents.Items.Add(strs[i]);
                }
                //foreach (string var in dr["describe"].ToString().Split('|'))
                //{
                //    this.lbEvents.Items.Add(var);
                //}
                if (dr["describe"].ToString().Contains("手术"))
                {
                    dtpSurgeryEndTime.Value = Convert.ToDateTime(dr["operations_time"].ToString());
                }
                if (dr["describe"].ToString().Contains("出院"))
                {
                    dtpTimes_date = hour;
                }
            }
            isOkNow = true;
        }

        /// <summary>
        /// 返回一个体温实体
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="bed_no"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Class_T_CHILD_VITAL_SIGNS GetTempers(string pid, string bed_no, string time, string pid_Ids)
        {
            if (this.txtTemper.Text == "" && this.txtPulse.Text == "" && this.txtBreathing.Text == "")
            {
                if (this.cbEvent.SelectedIndex == 0 || this.cbEvent.SelectedIndex == 1)
                {
                    this.cbEvent.SelectedIndex = 0;
                    if (this.lbEvents.Items.Count < 1)
                    {
                        return null;
                    }
                }
            }
            Class_T_CHILD_VITAL_SIGNS tvs = new Class_T_CHILD_VITAL_SIGNS();
            tvs.ID = App.GenId().ToString();
            tvs.Bed_no = bed_no; //床号
            tvs.Pid = pid;       //住院病人ID
            tvs.Measure_time = time;
            tvs.Patient_id = pid_Ids;

            if (this.txtTemper.Text != "")
            {
                tvs.Temperature_value = float.Parse(this.txtTemper.Text);        //体温测量值
            }
            tvs.Temperature_body = this.cbTemperType.SelectedIndex.ToString();//测量部位

            if (cbReiteration.Checked)   //复测标志
                tvs.Re_measure = "Y";
            else
                tvs.Re_measure = "N";

            if (this.txtDown.Visible)
            {
                if (this.txtDown.Text != "")
                {
                    if (float.Parse(this.txtDown.Text) > 0)
                    {
                        tvs.Cooling_value = float.Parse(this.txtDown.Text);
                    }
                }
            }

            tvs.Cooling_type = ""; //降温措施

            if (this.PulseCheck.Checked)
            {
                tvs.Is_briefness = "Y";
            }
            else
            {
                tvs.Is_briefness = "N";
            }
            if (this.txtHeartRate.Text != "")
                tvs.Heart_rhythm = Convert.ToInt32(this.txtHeartRate.Text);//心率测量值

            if (this.PulseCheck.Checked)
                tvs.Is_assist_hr = "Y";  //心率器械辅助
            else
                tvs.Is_assist_hr = "N";


            if (this.txtPulse.Text != "")
                tvs.Pulse_value = int.Parse(this.txtPulse.Text);



            if (this.txtBreathing.Text != "")
                tvs.Breath_value = Convert.ToInt32(this.txtBreathing.Text); //呼吸测量值

            if (this.ckBreath.Checked)
                tvs.Is_assist_br = "Y";//呼吸器械辅助
            else
                tvs.Is_assist_br = "N";         
            tvs.Remark = "";

            string eventsString = "";

            switch (this.cbEvent.Text) //测量状态
            {
                case "已测":
                    tvs.Measure_state = "F";
                    break;
                case "私自外出":
                    tvs.Measure_state = "O";
                    break;
                case "请假":
                    tvs.Measure_state = "L";
                    break;
                case "劝阻无效外出":
                    tvs.Measure_state = "Q";
                    break;
                case "拒测":
                    tvs.Measure_state = "R";
                    break;
            }

            if (this.lbEvents.Items.Count > 0)
            {
                foreach (object var in this.lbEvents.Items)
                {
                    eventsString += var.ToString() + "|";
                }
                tvs.Describe = eventsString.Substring(0, eventsString.Length - 1);
            }
            return tvs;
        }

        /// <summary>
        /// 判断是否 需要降温处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTemper_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Name == "txtTemper")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }

                if (textBox.Text != "")
                {
                    if (float.Parse(textBox.Text) >= 39)
                    {
                        this.txtDown.Visible = true;
                        this.label1.Visible = true;
                    }
                    else
                    {
                        this.txtDown.Visible = false;
                        this.label1.Visible = false;
                    }
                }
                else
                {
                    this.txtDown.Visible = false;
                    this.label1.Visible = false;
                }
            }


            if (isOkNow)
            {

                if (this.txtTemper.Text == "" && this.txtPulse.Text == "" && this.txtBreathing.Text == "")
                {
                    if (this.cbEvent.SelectedIndex == 1)
                    {
                        this.cbEvent.SelectedIndex = 0;
                    }
                }
                else
                {
                    this.cbEvent.SelectedIndex = 1;
                }

                textBox.Focus();
            }         
        }

        /// <summary>
        /// 时间点的范围
        /// </summary>
        private List<DateTime> TimeList = null;

        private void SetTimeList()
        {
            TimeList = new List<DateTime>();
            DateTime dt = CurDateTime.Date;
            TimeList.Add(dt);
            dt = dt.AddHours(5);
            TimeList.Add(dt);
            dt = dt.AddHours(4);
            TimeList.Add(dt);
            dt = dt.AddHours(4);
            TimeList.Add(dt);
            dt = dt.AddHours(4);
            TimeList.Add(dt);
            dt = dt.AddHours(4);
            TimeList.Add(dt);
            dt = dt.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private List<string> TitleList = null;
        /// <summary>
        /// 时间点标题
        /// </summary>
        private void SetTitleList()
        {
            TitleList = new List<string>();
            //TitleList.Add("4:00");
            //TitleList.Add("7:00");
            //TitleList.Add("12:00");
            //TitleList.Add("15:00");
            //TitleList.Add("20:00");
            //TitleList.Add("24:00");

            TitleList.Add("3:00");
            TitleList.Add("7:00");
            TitleList.Add("11:00");
            TitleList.Add("15:00");
            TitleList.Add("19:00");
            TitleList.Add("23:00");
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (this.cbAddEvent.Text != "--请选择--")
            {
                SetTimeList();
                SetTitleList();
                DateTime dt = CurDateTime.Date.AddHours(this.dtpAddEventTime.Value.Hour).AddMinutes(this.dtpAddEventTime.Value.Minute).AddSeconds(this.dtpAddEventTime.Value.Second);
                int i = (isHowTime - 2) / 4;
                string strMsg = TitleList[i] + "的事件时间范围在" + TimeList[i].ToString("yyyy-MM-dd HH:mm:ss") + "点至" + ((i + 1) == 6 ? TimeList[0].AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") : TimeList[i + 1].ToString("yyyy-MM-dd HH:mm:ss")) + "之间";
                switch (isHowTime)
                {
                    case 2:
                        if (dt >= TimeList[i] && dt < TimeList[i + 1])
                        { }
                        else
                        {
                            App.Msg(strMsg);
                            return;
                        }
                        break;
                    case 6:
                        if (dt >= TimeList[i] && dt < TimeList[i + 1])
                        { }
                        else
                        {
                            App.Msg(strMsg);
                            return;
                        }
                        break;
                    case 10:
                        if (dt >= TimeList[i] && dt < TimeList[i + 1])
                        { }
                        else
                        {
                            App.Msg(strMsg);
                            return;
                        }
                        break;
                    case 14:
                        if (dt >= TimeList[i] && dt < TimeList[i + 1])
                        { }
                        else
                        {
                            App.Msg(strMsg);
                            return;
                        }
                        break;
                    case 18:
                        if (dt >= TimeList[i] && dt < TimeList[i + 1])
                        { }
                        else
                        {
                            App.Msg(strMsg);
                            return;
                        }
                        break;
                    case 22:
                        if (dt >= TimeList[i])
                        { }
                        else
                        {
                            App.Msg(strMsg);
                            return;
                        }
                        break;
                }

                string even = this.cbAddEvent.Text + "_" + this.dtpAddEventTime.Value.ToString("HH:mm");
                this.lbEvents.Items.Add(even);
            }
        }

        private void cbAddEvent_SelectedIndexChanged(object sender, EventArgs e)
        {           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lbEvents.Items.Count > 0)
            {
                if (lbEvents.SelectedItem != null)
                {
                    lbEvents.Items.Remove(lbEvents.SelectedItem);
                }
            }
        }
        /// <summary>
        /// 当填写了体温、脉搏、呼吸、心率后，在事件处选择了请假，私自外出，
        /// 劝阻无效外出以及已测，不要清空上述数据，当选择了 拒测 时要清空上述数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isOkNow)
            //{
            //    string name = (sender as ComboBox).Name;
            //    if (this.cbEvent.SelectedIndex != 1 &&
            //        this.cbEvent.SelectedIndex != 2 &&
            //        this.cbEvent.SelectedIndex != 3 &&
            //        this.cbEvent.SelectedIndex != 4)
            //    {
            //        isOkNow = false;
            //        this.cbTemperType.SelectedIndex = 0;
            //        this.txtTemper.Text = "";
            //        this.txtDown.Text = "";
            //        this.txtDown.Visible = false;
            //        this.label1.Visible = false;
            //        this.cbReiteration.Checked = false;
            //        this.txtPulse.Text = "";
            //        this.ckChu.Checked = false;
            //        this.ckHeartRate.Checked = false;
            //        this.txtBreathing.Text = "";
            //        this.ckBreath.Checked = false;
            //        this.txtHeart.Text = "";
            //        this.cbAddEvent.SelectedIndex = 0;
            //        this.dtpAddEventTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm")); //Convert.ToDateTime(no);
            //        this.txtHeart.Enabled = false;
            //        isOkNow = true;
            //        this.ckHeartRate.Enabled = false;
            //    }
            //}
            //this.label2.Focus();
        }

        public void Clear()
        {
            this.TemperClear();
        }

        private void TemperClear()
        {
            this.cbEvent.SelectedIndex = 0;
            this.cbAddEvent.SelectedIndex = 0;
            this.cbTemperType.SelectedIndex = 0;            
            this.txtTemper.Text = "";
            this.txtDown.Text = "";
            this.txtDown.Visible = false;
            this.label1.Visible = false;
            this.cbReiteration.Checked = false;         
            this.txtBreathing.Text = "";           
            this.lbEvents.Items.Clear();
            this.dtpAddEventTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm"));                    
        }

        private void cbTemperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label2.Focus();
        }

        private void txtHeart_Leave(object sender, EventArgs e)
        {           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboPainGradesMothed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PusleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PulseCheck.Checked)
            {
                this.txtHeartRate.Visible = true;
                this.txtHeartRate.Text = "";
            }
            else
            {
                this.txtHeartRate.Visible = false;
                this.txtHeartRate.Text = "";
            }
        }

    }

}
