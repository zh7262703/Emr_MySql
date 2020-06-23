using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;
using Base_Function.TEMPERATURES.ValueSet;


namespace Base_Function.BLL_NURSE.Tempreture_Management
{

    public partial class TemperWrite : UserControl
    {

        public string dtpTimes_date = "";
        private int isHowTime = 0;
        private bool isOkNow = true;

        public int IsHowTime
        {
            get { return this.isHowTime; }
            set { this.isHowTime = value; }
        }

        private bool isQiXian;

        public bool IsQiXian
        {
            get { return isQiXian; }
            set { isQiXian = value; }
        }

        private DateTime curDateTime;

        public DateTime CurDateTime
        {
            get { return curDateTime; }
            set { curDateTime = value; }
        }
        //this.cbEvent = new comboNoWheel();        

        public List<string> oldOperations = new List<string>();
        public List<string> newOPerations = new List<string>();

        public TemperWrite()
        {
            InitializeComponent();
            this.cbEvent.SelectedIndex = 0;
            this.cbAddEvent.SelectedIndex = 0;
            this.cbTemperType.SelectedIndex = 0;
            this.cboPainGradesMothed.SelectedIndex = 0;
            this.cbTemperTypeQX.SelectedIndex = 0;
            this.cboPainGradesMothedQX.SelectedIndex = 0;
            this.dtpSurgeryEndTime.Enabled = false;
            //this.isHowTime = howTime;
            this.dtpSurgeryEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm"));

            //�ж����¡�������������������ֵ��С
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
        /// ��ʹ���ַ���
        /// </summary>
        private string painmothed;
        public string Painmothed
        {
            get { return painmothed; }
            set { painmothed = value; }
        }

        //private void ckChu_Click(object sender, EventArgs e)
        //{
        //    //txtHeart.Text = "";
        //    if (!ckHeartRate.Checked)
        //    {
        //        txtHeart.Text = "";
        //        txtHeart.Enabled = ckChu.Checked;
        //    }
        //    //ckHeartRate.Enabled = ckChu.Checked;
        //    //ckHeartRate.Checked = false;
        //}


        /// <summary>
        /// ��ѯ������Ϣ
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
                                        "describe, remark, heart_rhythm,operations_time,PAIN_VALUE,pain_value2 from t_vital_signs WHERE " +
                                        "to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ORDER BY MEASURE_TIME", time, pid);
            DataTable dt1 = App.GetDataSet(sql).Tables[0];
            list.Add(dt1);
            return list;
        }


        /// <summary>
        /// ֻ�����������ֺ�С����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Delete)
            {
                if ((sender as TextBox).Text.Split('.').Length >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }

        }

        /// <summary>
        /// ֻ������������
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
            if (dr["is_qixian"].ToString() != "Y") //����
            {
                
                #region �������µ�¼��

                if (dr["temperature_body"].ToString() != "")
                {
                    this.cbTemperType.SelectedIndex = Convert.ToInt32(dr["temperature_body"].ToString());//���²�����λ
                }
                else
                {
                    this.cbTemperType.SelectedIndex = 0;
                }
                if (dr["temperature_value"].ToString() != "" && dr["temperature_value"].ToString() != "0")
                {
                    this.txtTemper.Text = float.Parse(dr["temperature_value"].ToString()).ToString("#0.0");//���²���ֵ

                }
                else
                {
                    this.txtTemper.Text = "";
                }

                if (dr["re_measure"].ToString() == "Y") //�����־
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
                    this.txtPulse.Text = dr["pulse_value"].ToString(); //��������ֵ
                }
                else
                {
                    this.txtPulse.Text = "";
                }

                if (dr["heart_rhythm"].ToString() != "" && dr["heart_rhythm"].ToString() != "0")
                {
                    this.txtHeart.Text = dr["heart_rhythm"].ToString();     //���ʲ���ֵ

                    if (dr["is_assist_hr"].ToString() == "Y")  //������е������־
                        this.ckHeartRate.Checked = true;
                    else
                        this.ckHeartRate.Checked = false;
                }


                if (dr["is_briefness"].ToString() == "Y")       //�������
                {
                    this.ckChu.Checked = true;
                    //this.txtHeart.Text = "";
                    this.txtHeart.Enabled = true;
                    this.ckHeartRate.Enabled = true;

                }
                else
                    this.ckChu.Checked = false;

                if (dr["breath_value"].ToString() != "")// && dr["breath_value"].ToString() != "0"
                {
                    this.txtBreathing.Text = dr["breath_value"].ToString(); //��������ֵ
                }
                else
                {
                    this.txtBreathing.Text = "";
                }

                if (dr["PAIN_VALUE"].ToString() != "")
                {
                    this.txtPainGrades.Text = dr["PAIN_VALUE"].ToString();
                    //Painmothed = dr["PAIN_MOTHED"].ToString();
                }
                else
                {
                    this.txtPainGrades.Text = "";
                }
                if (dr["PAIN_VALUE2"].ToString() != "")
                {
                    this.txtPainGrades2.Text = dr["PAIN_VALUE2"].ToString();
                    //Painmothed = dr["PAIN_MOTHED"].ToString();
                }
                else
                {
                    this.txtPainGrades2.Text = "";
                }

                if (dr["PAIN_MOTHED"].ToString() != "" && dr["PAIN_MOTHED"].ToString() != "0")
                {
                    this.cboPainGradesMothed.Text = dr["PAIN_MOTHED"].ToString();
                    //Painmothed = dr["PAIN_MOTHED"].ToString();
                }
                else
                {
                    this.cboPainGradesMothed.Text = "";
                    //this.cboPainGradesMothed.Text = dr["PAIN_MOTHED"].ToString();
                }

                //����������
                if (dr["IS_ASSIST_BR"].ToString() == "Y")
                {
                    this.ckBreath.Checked = true;
                }
                else
                {
                    this.ckBreath.Checked = false;
                }
                #endregion

                if (eventState != "")
                {
                    isOkNow = true;
                    switch (eventState) //����״̬
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
                if (dr["describe"].ToString() != "")
                {
                    if (lbEvents.Items.Count > 0) { }
                    //lbEvents.Items.Clear();
                    string[] strs = dr["describe"].ToString().Split('|');
                    //foreach (string var in dr["describe"].ToString().Split('|'))
                    //{
                    //    this.lbEvents.Items.Add(var);
                    //}
                    if (dr["describe"].ToString().Contains("����"))
                    {
                        dtpSurgeryEndTime.Value = Convert.ToDateTime(dr["operations_time"].ToString());
                    }
                    for (int i = 0; i < strs.Length; i++)
                    {
                        this.lbEvents.Items.Add(strs[i]);
                        if (strs[i].Contains("����"))
                        {
                            oldOperations.Add(Convert.ToDateTime(dr["measure_time"].ToString()).ToString("yyyy-MM-dd") + " " + strs[i].Split('_')[1] + "," + dtpSurgeryEndTime.Value.ToString("yyyy-MM-dd HH:mm"));
                        }
                    }
                    if (dr["describe"].ToString().Contains("��Ժ"))
                    {
                        dtpTimes_date = hour;
                    }
                }
                isOkNow = true;
            }
            else
            {
                #region �������µ�¼��

                if (dr["temperature_body"].ToString() != "")
                    this.cbTemperTypeQX.SelectedIndex = Convert.ToInt32(dr["temperature_body"].ToString());//���²�����λ
                else
                    this.cbTemperTypeQX.SelectedIndex = 0;

                if (dr["temperature_value"].ToString() != "" && dr["temperature_value"].ToString() != "0")
                    this.txtTemperQX.Text = float.Parse(dr["temperature_value"].ToString()).ToString("#0.0");//���²���ֵ
                else
                    this.txtTemperQX.Text = "";

                if (dr["re_measure"].ToString() == "Y") //�����־
                    this.cbReiterationQX.Checked = true;
                else
                    this.cbReiterationQX.Checked = false;

                if (dr["temperature_value"].ToString() != "" && dr["temperature_value"].ToString() != "0")
                {
                    if (dr["cooling_value"].ToString() != "" && dr["cooling_value"].ToString() != "0")
                        this.txtDownQX.Text = float.Parse(dr["cooling_value"].ToString()).ToString("#0.0");
                }

                if (dr["pulse_value"].ToString() != "" && dr["pulse_value"].ToString() != "0")
                    this.txtPulseQX.Text = dr["pulse_value"].ToString(); //��������ֵ
                else
                    this.txtPulseQX.Text = "";

                if (dr["heart_rhythm"].ToString() != "" && dr["heart_rhythm"].ToString() != "0")
                {
                    this.txtHeartQX.Text = dr["heart_rhythm"].ToString();     //���ʲ���ֵ

                    if (dr["is_assist_hr"].ToString() == "Y")  //������е������־
                        this.ckHeartRateQX.Checked = true;
                    else
                        this.ckHeartRateQX.Checked = false;
                }

                if (dr["is_briefness"].ToString() == "Y")       //�������
                {
                    this.ckChuQX.Checked = true;
                    this.txtHeartQX.Enabled = true;
                    this.ckHeartRateQX.Enabled = true;
                }
                else
                    this.ckChuQX.Checked = false;

                if (dr["breath_value"].ToString() != "")// && dr["breath_value"].ToString() != "0"
                    this.txtBreathingQX.Text = dr["breath_value"].ToString(); //��������ֵ
                else
                    this.txtBreathingQX.Text = "";

                if (dr["PAIN_VALUE"].ToString() != "")
                    this.txtPainGradesQX.Text = dr["PAIN_VALUE"].ToString();
                else
                    this.txtPainGradesQX.Text = "";
                
                if (dr["PAIN_VALUE2"].ToString() != "")
                    this.txtPainGrades2QX.Text = dr["PAIN_VALUE2"].ToString();
                else
                    this.txtPainGrades2QX.Text = "";

                if (dr["PAIN_MOTHED"].ToString() != "" && dr["PAIN_MOTHED"].ToString() != "0")
                    this.cboPainGradesMothedQX.Text = dr["PAIN_MOTHED"].ToString();
                else
                    this.cboPainGradesMothedQX.Text = "";

                //����������
                if (dr["IS_ASSIST_BR"].ToString() == "Y")
                    this.ckBreathQX.Checked = true;
                else
                    this.ckBreathQX.Checked = false;
                #endregion
                this.cbEvent.SelectedIndex = 1;
            }
        }
        //public void Date()
        //{
        //    string date = "";
        //    date = dtpTimes_date;
        //    return date;

        //}
        /// <summary>
        /// ����һ������ʵ��
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="bed_no"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Class_T_Vital_Signs GetTempers(string pid, string bed_no, string time, string pid_Ids)
        {
            newOPerations.Clear();
            if (this.txtTemper.Text == "" && this.txtPulse.Text == "" && this.txtBreathing.Text == "" && this.txtHeart.Text == "" && this.txtPainGrades.Text == ""&&
                this.txtTemperQX.Text == "" && this.txtPulseQX.Text == "" && this.txtBreathingQX.Text == "" && this.txtHeartQX.Text == "" && this.txtPainGradesQX.Text == "")
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
            Class_T_Vital_Signs tvs = new Class_T_Vital_Signs();

            //if (IsQiXian)   //����
            //    tvs.Is_qixian = "Y";
            //else
            //    tvs.Is_qixian = "N";
            tvs.Bed_no = bed_no; //����
            tvs.Pid = pid;       //סԺ����ID
            tvs.Measure_time = time + " " + lbTime.Text;//time;

            tvs.Patient_id = pid_Ids;

            #region �������µ���¼

            if (this.txtTemper.Text != "")
            {
                tvs.Temperature_value = float.Parse(this.txtTemper.Text);        //���²���ֵ
            }
            tvs.Temperature_body = this.cbTemperType.SelectedIndex.ToString();//������λ

            if (cbReiteration.Checked)   //�����־
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

            tvs.Cooling_type = ""; //���´�ʩ

            if (this.txtPulse.Text != "")
                tvs.Pulse_value = Convert.ToInt32(this.txtPulse.Text);//��������ֵ

            if (this.txtPainGrades.Text != "")
            {
                tvs.Pain_mothed = this.cboPainGradesMothed.Text;
                tvs.Pain_value = this.txtPainGrades.Text;//��ʹ����
                tvs.Pain_value2 = this.txtPainGrades2.Text;//��ʹ���ָ�ֵ
            }

            if (ckChu.Checked)                     //�������
                tvs.Is_briefness = "Y";
            else
                tvs.Is_briefness = "N";

            if (this.txtHeart.Text != "")
                tvs.Heart_rhythm = Convert.ToInt32(this.txtHeart.Text);//���ʲ���ֵ

            if (this.ckHeartRate.Checked)
                tvs.Is_assist_hr = "Y";  //������е����
            else
                tvs.Is_assist_hr = "N";

            //if (this.txtBreathing.Text != "")
            tvs.Breath_value = this.txtBreathing.Text; //��������ֵ

            if (this.ckBreath.Checked)
                tvs.Is_assist_br = "Y";//������е����
            else
                tvs.Is_assist_br = "N";
#endregion
            tvs.Is_qixian = "N";
            #region �������µ���¼
            if (this.txtTemperQX.Text != "" || 
                this.txtPulseQX.Text != "" || 
                this.txtHeartQX.Text != "" || 
                this.txtBreathingQX.Text != "" || 
                this.txtPainGradesQX.Text != "")
            {
                tvs.Is_qixian = "Y";
                if (this.txtTemperQX.Text != "")
                {
                    tvs.Temperature_valueQX = float.Parse(this.txtTemperQX.Text);     //���²���ֵ
                }
                tvs.Temperature_bodyQX = this.cbTemperTypeQX.SelectedIndex.ToString();//������λ

                if (cbReiterationQX.Checked)   //�����־
                    tvs.Re_measureQX = "Y";
                else
                    tvs.Re_measureQX = "N";

                if (this.txtDownQX.Visible)
                {
                    if (this.txtDownQX.Text != "")
                    {
                        if (float.Parse(this.txtDownQX.Text) > 0)
                        {
                            tvs.Cooling_valueQX = float.Parse(this.txtDownQX.Text);
                        }
                    }
                }

                tvs.Cooling_typeQX = ""; //���´�ʩ

                if (this.txtPulseQX.Text != "")
                    tvs.Pulse_valueQX = Convert.ToInt32(this.txtPulseQX.Text);//��������ֵ


                if (ckChuQX.Checked)                     //�������
                    tvs.Is_briefnessQX = "Y";
                else
                    tvs.Is_briefnessQX = "N";

                if (this.txtHeartQX.Text != "")
                    tvs.Heart_rhythmQX = Convert.ToInt32(this.txtHeartQX.Text);//���ʲ���ֵ

                if (this.ckHeartRateQX.Checked)
                    tvs.Is_assist_hrQX = "Y";  //������е����
                else
                    tvs.Is_assist_hrQX = "N";

                tvs.Breath_valueQX = this.txtBreathingQX.Text; //��������ֵ

                if (this.ckBreathQX.Checked)
                    tvs.Is_assist_brQX = "Y";//������е����
                else
                    tvs.Is_assist_brQX = "N";


                if (this.txtPainGradesQX.Text != "")
                {
                    tvs.Pain_valueQX = this.txtPainGradesQX.Text;//��ʹ����
                    tvs.Pain_mothedQX = this.cboPainGradesMothedQX.Text;
                    tvs.Pain_value2QX = this.txtPainGrades2QX.Text;//��ʹ���ָ�ֵ
                }
            }

            #endregion

            switch (this.cbEvent.Text) //����״̬
            {
                case "�Ѳ�":
                    tvs.Measure_state = "F";
                    break;
                case "˽�����":
                    tvs.Measure_state = "O";
                    break;
                case "���":
                    tvs.Measure_state = "L";
                    break;
                case "Ȱ����Ч���":
                    tvs.Measure_state = "Q";
                    break;
                case "�ܲ�":
                    tvs.Measure_state = "R";
                    break;
            }

            tvs.Remark = "";

            string eventsString = "";


            if (this.lbEvents.Items.Count > 0)
            {
                foreach (object var in this.lbEvents.Items)
                {
                    eventsString += var.ToString() + "|";
                    if (var.ToString().Contains("����"))
                    {
                        newOPerations.Add(Convert.ToDateTime(tvs.Measure_time).ToString("yyyy-MM-dd") + " " + var.ToString().Split('_')[1] + "," + dtpSurgeryEndTime.Value.ToString("yyyy-MM-dd HH:mm"));
                    }
                }
                tvs.Describe = eventsString.Substring(0, eventsString.Length - 1);
                if (tvs.Describe.ToString().Contains("����"))
                {
                    tvs.Operater_before_time = Convert.ToDateTime(time).ToString("yyyy-MM-dd") + " " + dtpAddEventTime.Value.ToString("HH:mm");
                    tvs.Operater_after_time = dtpSurgeryEndTime.Value.ToString("yyyy-MM-dd HH:mm");
                }
            }
            return tvs;
        }

        /// <summary>
        /// �ж��Ƿ� ��Ҫ���´���
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
                    if (float.Parse(textBox.Text) >= 38.5)
                    {
                        this.txtDown.Visible = true;
                        this.label1.Visible = true;
                    }
                    else
                    {
                        this.txtDown.Visible = false;
                        this.label1.Visible = false;
                    }
                    if (cbTemperType.SelectedIndex == 0 && float.Parse(textBox.Text) >= 38)
                    {
                        this.txtDown.Visible = true;
                        this.label1.Visible = true;
                    }
                }
                else
                {
                    this.txtDown.Visible = false;
                    this.label1.Visible = false;
                }
            }
            if (textBox.Name == "txtTemperQX")
            {//���߽���
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
                if (textBox.Text != "")
                {
                    if (float.Parse(textBox.Text) >= 38.5)
                    {
                        this.txtDownQX.Visible = true;
                        this.label2.Visible = true;
                    }
                    else
                    {
                        this.txtDownQX.Visible = false;
                        this.label2.Visible = false;
                    }
                    if (cbTemperTypeQX.SelectedIndex == 0 && float.Parse(textBox.Text) >= 38)
                    {
                        this.txtDownQX.Visible = true;
                        this.label2.Visible = true;
                    }
                }
                else
                {
                    this.txtDownQX.Visible = false;
                    this.label2.Visible = false;
                }
            }


            if (isOkNow)
            {
                if (this.txtTemper.Text == "" && this.txtPulse.Text == "" && this.txtBreathing.Text == "" && this.txtHeart.Text == "" && this.txtPainGrades.Text == ""&&
                    this.txtTemperQX.Text == "" && this.txtPulseQX.Text == "" && this.txtBreathingQX.Text == "" && this.txtHeartQX.Text == "" && this.txtPainGradesQX.Text == "")
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
        /// ʱ���ķ�Χ
        /// </summary>
        private List<DateTime> TimeList = null;

        private void SetTimeList()
        {
            TimeList = new List<DateTime>();
            DateTime dt = CurDateTime.Date;
            TimeList.Add(dt);
            dt = dt.AddHours(4);
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
            TimeList.Add(dt);
        }

        private List<string> TitleList = null;

        /// <summary>
        /// ʱ������
        /// </summary>
        private void SetTitleList()
        {
            TitleList = new List<string>();
            TitleList.Add("2:00");
            TitleList.Add("6:00");
            TitleList.Add("10:00");
            TitleList.Add("14:00");
            TitleList.Add("18:00");
            TitleList.Add("22:00");
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (this.cbAddEvent.Text != "--��ѡ��--")
            {
                SetTimeList();
                SetTitleList();
                DateTime dt = CurDateTime.Date.AddHours(this.dtpAddEventTime.Value.Hour).AddMinutes(this.dtpAddEventTime.Value.Minute).AddSeconds(this.dtpAddEventTime.Value.Second);
                int i = (isHowTime - 2) / 4;
                //TimeList[i].ToString("yyyy-MM-dd HH:mm:ss") + "����" + ((i + 1) == 6 ? TimeList[0].AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") :
                string strMsg = TitleList[i] + "���¼�ʱ�䷶Χ��" + TimeList[i + 1].ToString("yyyy-MM-dd HH:mm:ss") + "֮��";
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
            if (cbAddEvent.Text == "����")
            {
                this.dtpSurgeryEndTime.Enabled = true;
            }
            else
            {
                this.dtpSurgeryEndTime.Enabled = false;
            }
            this.label2.Focus();
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
        /// ����д�����¡����������������ʺ����¼���ѡ������٣�˽�������
        /// Ȱ����Ч����Լ��Ѳ⣬��Ҫ����������ݣ���ѡ���� �ܲ� ʱҪ�����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isOkNow)
            {
                string name = (sender as ComboBox).Name;
                if (this.cbEvent.SelectedIndex != 1 &&
                    this.cbEvent.SelectedIndex != 2 &&
                    this.cbEvent.SelectedIndex != 3 &&
                    this.cbEvent.SelectedIndex != 4 &&
                    this.cbEvent.SelectedIndex != 5)
                {
                    isOkNow = false;
                    this.cbTemperType.SelectedIndex = 0;
                    this.txtTemper.Text = "";
                    this.txtDown.Text = "";
                    this.txtDown.Visible = false;
                    this.label1.Visible = false;
                    this.cbReiteration.Checked = false;
                    this.txtPulse.Text = "";
                    this.ckChu.Checked = false;
                    this.ckHeartRate.Checked = false;
                    this.txtBreathing.Text = "";
                    this.ckBreath.Checked = false;
                    this.txtHeart.Text = "";
                    this.txtPainGrades.Text = "";
                    this.cbAddEvent.SelectedIndex = 0;
                    this.dtpAddEventTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm")); //Convert.ToDateTime(no);
                    //this.txtHeart.Enabled = false;
                    isOkNow = true;
                    //this.ckHeartRate.Enabled = false;
                }
            }
            this.label2.Focus();
        }

        public void Clear()
        {
            this.TemperClear();
        }

        private void TemperClear()
        {
            
            this.lbTime.Text = IsHowTime.ToString() + ":00";
            
            this.cbEvent.SelectedIndex = 0;
            this.cbAddEvent.SelectedIndex = 0;
            this.cbTemperType.SelectedIndex = 0;
            this.dtpSurgeryEndTime.Enabled = false;
            this.txtTemper.Text = "";
            this.txtDown.Text = "";
            this.txtDown.Visible = false;
            this.label1.Visible = false;
            this.cbReiteration.Checked = false;
            this.txtPulse.Text = "";
            this.ckChu.Checked = false;
            this.txtBreathing.Text = "";
            this.ckBreath.Checked = false;
            this.txtHeart.Text = "";
            this.ckHeartRate.Checked = false;
            this.cboPainGradesMothed.SelectedIndex = 0;
            this.txtPainGrades.Text = "";
            this.txtPainGrades2.Text = "";
            this.lbEvents.Items.Clear();
            this.dtpAddEventTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm"));
            this.dtpSurgeryEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm"));
            //this.txtHeart.Enabled = false;
            //this.ckHeartRate.Enabled = false;
            //txtPainGrades.Text = "";

            this.cbTemperTypeQX.SelectedIndex = 0;
            this.txtTemperQX.Text = "";
            this.txtDownQX.Text = "";
            this.cbReiterationQX.Checked = false;
            this.txtPulseQX.Text = "";
            this.ckChuQX.Checked = false;
            this.txtBreathingQX.Text = "";
            this.ckBreathQX.Checked = false;
            this.txtHeartQX.Text = "";
            this.ckHeartRateQX.Checked = false;
            this.cboPainGradesMothedQX.SelectedIndex = 0;
            this.txtPainGradesQX.Text = "";
            this.txtPainGrades2QX.Text = "";
        }

        private void cbTemperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label2.Focus();
        }

        private void cboPainGradesMothed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPainGradesMothed.Text != "")
            {
                this.Painmothed = this.cboPainGradesMothed.Text;
            }
        }

        private void ckChu_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckChu.Checked)
                txtHeart.Text = "";
            txtHeart.Enabled = ckChu.Checked;
            ckHeartRate.Enabled = ckChu.Checked;
        }

        private void ckChuQX_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckChuQX.Checked)
                txtHeartQX.Text = "";
            txtHeartQX.Enabled = ckChuQX.Checked;
            ckHeartRateQX.Enabled = ckChuQX.Checked;
        }

        /// <summary>
        /// ���س����滻��Tab��
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)����// ���µ��ǻس���
            {
                //if (ActiveControl is TextBox || ActiveControl is ComboBox)
                //    keyData = Keys.Tab;
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        //��¼�쳣ֵ��Χ
        double dTmax = 0;
        double dTmin = 0;
        int iRmax = 0;
        int iRmin = 0;
        int iPmax = 0;
        int iPmin = 0;
        /// <summary>
        /// ¼���ֵ�Ƿ���Ҫ��ʾ�쳣��Ϣ
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
                case "����":
                    double t = 0;
                    double.TryParse(SignValue, out t);
                    if (t < dTmin || t > dTmax)
                    {
                        b = true;
                        Msg = "�������±�����" + dTmin.ToString() + "��" + dTmax.ToString() + "֮��";
                    }
                    else
                        b = false;
                    break;
                case "����":
                    int r = 0;
                    int.TryParse(SignValue, out r);
                    if (r < iRmin || r > iRmax)
                    {
                        b = true;
                        Msg = "���ߺ���������" + iRmin.ToString() + "��" + iRmax.ToString() + "֮��";
                    }
                    else
                        b = false;
                    break;
                case "����":
                case "����":
                    int p = 0;
                    int.TryParse(SignValue, out p);
                    if (p < iPmin || p > iPmax)
                    {
                        b = true;
                        Msg = "����" + Sign + "������" + iPmin.ToString() + "��" + iPmax.ToString() + "֮��";
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

        private void txtBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string msg = string.Empty;
            string TPRH = string.Empty;
            if (textBox.Name.Contains("txtTemper") || textBox.Name.Contains("txtDown"))
            {
                TPRH = "����";
            }
            else if (textBox.Name.Contains("txtPulse"))
            {
                TPRH = "����";
            }
            else if (textBox.Name.Contains("txtBreathing"))
            {
                TPRH = "����";
            }
            else if (textBox.Name.Contains("txtHeart"))
            {
                TPRH = "����";
            }
            if (!string.IsNullOrEmpty(textBox.Text) && IsNeedRemind(TPRH, textBox.Text.ToString(), ref msg))
            {
                App.Msg(msg);
                textBox.Text = "";
                return;
            }
        }
    }

}
