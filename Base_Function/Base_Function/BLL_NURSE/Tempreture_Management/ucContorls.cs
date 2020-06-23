using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;

namespace Bifrost_Nurse.UControl
{
    public partial class ucContorls : UserControl
    {
        private int isHowTime = 0;
        private bool isOkNow = true;
        public ucContorls()
        {
            InitializeComponent();
            this.cbEvent.SelectedIndex = 0;
            this.cbAddEvent.SelectedIndex = 0;
            this.dtpSurgeryEndTime.Enabled = false;
            //ythis.rbtnTemperture.Checked = false;
            this.dtpSurgeryEndTime.Value = Convert.ToDateTime(App.GetSystemTime().ToString("HH:mm"));
            this.chkTemperture.Checked = false;
            this.lblTemperture.Visible = true;
        }
        public int IsHowTime
        {
            get { return this.isHowTime; }
            set { this.isHowTime = value; }
        }
        private void ucContorls_Load(object sender, EventArgs e)
        {
            this.cbEvent.SelectedIndex = 0;
            this.cbAddEvent.SelectedIndex = 0;
            this.dtpSurgeryEndTime.Enabled = false;
            this.dtpSurgeryEndTime.Value = Convert.ToDateTime(App.GetSystemTime().ToString("HH:mm"));
            this.chkTemperture.Checked = false;
            this.lblTemperture.Visible = true;
        }
        private void txtTemper_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Name == "txtTemper")
            {
                //if (textBox.Text == ".")
                //{
                //    textBox.Text = "";
                //    return;
                //}

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

                if (this.txtTemper.Text == "")
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
        /// ֻ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789.";
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
            //this.label2.Focus();
        }
        /// <summary>
        /// ����һ������ʵ��
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="bed_no"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Class_T_CHILD_VITAL_SIGNS GetTempers(string child_id, string time)
        {

            if (this.txtTemper.Text == "" && chkTemperture.Checked==false)
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
            tvs.Patient_id = child_id; //����
            tvs.Measure_time = time;
          
            if (this.txtTemper.Text != "")
            {
                tvs.Temperature_value = float.Parse(this.txtTemper.Text);        //���²���ֵ
            }
            else if (chkTemperture.Checked==true)
            {
                float value = 34;
                tvs.Temperature_value = value;
            }
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
            if (cbReiteration.Checked==true)   //�����־
                tvs.Re_measure = "Y";
            else
                tvs.Re_measure = "N";

            //switch (this.cbEvent.Text) //����״̬
            //{
            //    case "�Ѳ�":
            //        tvs.Temp_state = "F";
            //        break;
            //    case "˽�����":
            //        tvs.Temp_state = "O";
            //        break;
            //    case "���":
            //        tvs.Temp_state = "L";
            //        break;
            //    case "�ܲ�":
            //        tvs.Temp_state = "R";
            //        break;
            //}

            string eventsString = "";


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
        public void setTempers(DataRow dr)
        {

            isOkNow = false;
            string eventState = dr["TEMP_STATE"].ToString();
            if (dr["TEMPERATURE_VALUE"].ToString() != "" && dr["TEMPERATURE_VALUE"].ToString() != "0")
            {
                double  tr = 34.0;
                if (Convert.ToDouble(dr["TEMPERATURE_VALUE"].ToString()) != tr)
                {
                    this.txtTemper.Text = float.Parse(dr["TEMPERATURE_VALUE"].ToString()).ToString("#0.0");//���²���ֵ
                }
                else
                {
                    chkTemperture.Checked = true;
                    label2.Visible = true;
                    this.txtTemper.Text = "";

                }
                if (this.txtDown.Visible)
                {
                    if (dr["cooling_value"].ToString() != "" && dr["cooling_value"].ToString() != "0")
                    {
                        this.txtDown.Text = float.Parse(dr["cooling_value"].ToString()).ToString("#0.0");
                    }
                }
                
            }
            else
            {

                this.txtTemper.Text = "";
                //this.rbtnTemperture.Enabled = false;
            }

            if (dr["RE_MEASURE"].ToString() == "Y") //�����־
            {
                this.cbReiteration.Checked = true;
            }
            else
            {
                this.cbReiteration.Checked = false;
            }

            if (eventState != "")
            {
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
                    case "R":
                        this.cbEvent.SelectedIndex = 4;
                        break;
                }
            }


            if (dr["DESCRIBE"].ToString() != "")
            {
                if (lbEvents.Items.Count > 0)
                    lbEvents.Items.Clear();
                foreach (string var in dr["DESCRIBE"].ToString().Split('|'))
                {
                    this.lbEvents.Items.Add(var);
                }
            }
            isOkNow = true;
        }
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (this.cbAddEvent.Text != "--��ѡ��--")
            {
                DateTime dt = this.dtpAddEventTime.Value;
                switch (isHowTime)
                {
                    case 2:
                        if (dt.Hour >= 0 && dt.Hour < 4)
                        {

                        }
                        else
                        {
                            App.Msg("2am���¼�ʱ�䷶Χ���賿0���������賿4��֮��");

                            return;
                        }
                        break;
                    case 6:
                        if (dt.Hour >= 4 && dt.Hour < 8)
                        { }
                        else
                        {
                            App.Msg("6am���¼�ʱ�䷶Χ���賿4��������8��֮��");

                            return;
                        }
                        break;
                    case 10:
                        if (dt.Hour >= 8 && dt.Hour < 12)
                        { }
                        else
                        {
                            App.Msg("10am���¼�ʱ�䷶Χ������8��������12��֮��");

                            return;
                        }
                        break;
                    case 14:
                        if (dt.Hour >= 12 && dt.Hour < 16)
                        { }
                        else
                        {
                            App.Msg("2pm���¼�ʱ�䷶Χ������12��������16��֮��");

                            return;
                        }
                        break;
                    case 18:
                        if (dt.Hour >= 16 && dt.Hour < 20)
                        { }
                        else
                        {
                            App.Msg("6pm���¼�ʱ�䷶Χ������16��������20��֮��");

                            return;
                        }
                        break;
                    case 22:
                        if (dt.Hour >= 20 || dt.Hour < 0)
                        { }
                        else
                        {
                            App.Msg("10pm���¼�ʱ�䷶Χ������20���������賿0��֮��");

                            return;
                        }
                        break;
                }
                string even = "";
                string time = this.dtpAddEventTime.Value.ToString("HH:mm");
                DateTime times = Convert.ToDateTime(dtpSurgeryEndTime.Value.ToString(" HH:mm"));
              

                if (this.cbAddEvent.Text == "����")
                {
                    if (times > Convert.ToDateTime(time))
                    {
                        even = this.cbAddEvent.Text + ":" + this.dtpAddEventTime.Value.ToString("HH:mm") + "_" +this.dtpSurgeryEndTime.Value.ToString("HH:mm");
                    }
                    else
                    {
                        App.Msg("��������ʱ��������������ʼʱ�䣡");
                    }
                }
                else
                {
                        even = this.cbAddEvent.Text + "_" + this.dtpAddEventTime.Value.ToString("HH:mm");
                }
                if (!isExist(even))
                {
                    bool Evafale = getTimes(time);
                    if (Evafale == false)
                    {
                        //ListViewItem list = new ListViewItem();
                        //list.Text = even;
                        this.lbEvents.Items.Add(even);
                    }
                    else
                    {
                        App.Msg("������ͬʱ�䣡");
                    }
                }
                else
                {
                    App.Msg("������ͬ�¼���");
                }
            }
        }
        private void cbAddEvent_Click(object sender, EventArgs e)
        {

          
        }
        /// <summary>
        /// �жϹ�ϵ�Ƿ��ظ�����
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExist(string  name)
        {
            bool flag = false;
          
            //label1.Text = dr[listBox1.ValueMember].ToString(); 

            for (int i = 0; i < lbEvents.Items.Count; i++)
            {
                if (lbEvents.Items[i].ToString() == name.ToString())
                  {
                      flag = true;
                  }
      
       
            }
            return flag;
        }
        private bool getTimes(string time)
        {
            bool flag = false;
            for (int i = 0; i < lbEvents.Items.Count; i++)
            {
                if (lbEvents.Items[i].ToString().Contains(time))
                {
                    flag= true;
                }
            }
            return flag;
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

        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isOkNow)
            {
                string name = (sender as ComboBox).Name;
                if (this.cbEvent.SelectedIndex != 1)
                {
                    isOkNow = false;
                    this.txtTemper.Text = "";
                    this.cbReiteration.Checked = false;
                    //this.lblTemperture.Visible = false;
                    this.chkTemperture.Checked = false;
                    this.cbAddEvent.SelectedIndex = 0;
                    this.lblTemperture.Visible = true;
                    this.dtpAddEventTime.Value = Convert.ToDateTime(App.GetSystemTime().ToString("HH:mm"));
                    isOkNow = true;
                   
                }
            }
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
            this.dtpSurgeryEndTime.Enabled = false;
            this.txtTemper.Text = "";
            this.lblTemperture.Visible = true;
            this.cbReiteration.Checked = false;
            this.chkTemperture.Checked = false;
            this.lbEvents.Items.Clear();
            //this.lbEvents.Enabled = false;
            this.dtpAddEventTime.Value = Convert.ToDateTime(App.GetSystemTime().ToString("HH:mm"));
        }

        //private void rbtnTemperture_CheckedChanged(object sender, EventArgs e)
        //{

        //    if (rbtnTemperture.Checked == true)
        //    {
        //        txtTemper.Text = "";
        //        rbtnTemperture.Checked = true;
        //    }
        //    else
        //    {
        //        rbtnTemperture.Checked = false;
        //    }
        //}

        private void txtTemper_Click(object sender, EventArgs e)
        {
            chkTemperture.Checked = false;
        }

        private void chkTemperture_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTemperture.Checked == true)
            {
                txtTemper.Text = "";
                label2.Visible = true;
                //lblTemperture.Visible = true;
                chkTemperture.Checked = true;
            }
            else
            {
                //lblTemperture.Visible = false;
                label2.Visible = false;
                chkTemperture.Checked = false;
            }
        }


     
    }
}
