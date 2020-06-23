using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Text.RegularExpressions;
using Base_Function.BASE_COMMON;
using Base_Function.TEMPERATURES;
using Base_Function.MODEL;


namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    public partial class TemperInfo : UserControl
    {
        private string pid;//���˱��    
        private string medicare_no;//�ǼǺ�      
        private string bed_no;//���� 
        private string userName;//��������
        private string sex;//�Ա�
        private string age;//����
        private string section; //����
        private string ward;//�Ʊ�
        private string inTime;//����ʱ��
        private DateTime SelectTime;//��ǰ����
        private string pid_ids;//��������
        private string Date_time_up = "";
        private string s_count = "";//����������
        private string Erm = "";//log��¼��Ϣ
        ucTemperatureInfo TemperatureInfo;
        public TemperInfo() {

            InitializeComponent();

            //    this.pid = "243324342";
            //    this.bed_no = "3";
            //    this.userName = "���¾�������";
            //    this.sex = "";
            //    this.age = 20;
            //    this.section = "���ڿ�";
            //    this.ward = "���ڿƲ���";
            //    this.inTime = "2010-6-18  11:08:02";
            //    this.cbResult.SelectedIndex = 0;
            //    this.cbOther.SelectedIndex = 0;
            //    this.cbWeight.SelectedIndex = 0;
            //    this.dtpSeachTime.Value = DateTime.Now;
            //    this.dtpSeachTime.ValueChanged += new EventHandler(dtpSeachTime_ValueChanged);

            //this.tw11pm = new TemperWrite(23);
            //this.tw7pm = new TemperWrite(19);
            //this.tw3pm = new TemperWrite(15);
            //this.tw11am = new TemperWrite(11);
            //this.tw7am = new TemperWrite(7);
            //this.tw3am = new TemperWrite(3);
        }

        private ComboBox resuleBox = new ComboBox();

        /// <summary>
        /// ���µ���¼ҳ���ʼ��
        /// </summary>
        /// <param name="pid">���˱��</param>
        /// <param name="bed_no">����</param>
        /// <param name="userName">��������</param>
        /// <param name="sex">�����Ա�</param>
        /// <param name="age">��������</param>
        /// <param name="section">����</param>
        /// <param name="ward">����</param>
        /// <param name="inTime">��Ժʱ��</param>
        public TemperInfo(string pid,string medicare_no,string bed_no,string userName,string sex,string age,string section,string ward,string inTime,string pids_id) {
            try {
                InitializeComponent();
                this.pid = pid;
                this.medicare_no = medicare_no;
                this.bed_no = bed_no;
                this.userName = userName;
                this.sex = sex;
                this.age = age;
                this.section = section;
                this.ward = ward;
                this.inTime = inTime;
                this.pid_ids = pids_id;
                this.cbResult.SelectedIndex = 0;
                this.cbOther.SelectedIndex = 0;
                this.cbWeight.SelectedIndex = 0;
                this.dtpSeachTime.Value = DateTime.Now;
            } catch {
            }

        }

        /// <summary>
        /// ���µ�Ⱥ¼���뵥¼ҳ���ʼ��
        /// </summary>
        /// <param name="pid">���˱��</param>
        /// <param name="bed_no">����</param>
        /// <param name="userName">��������</param>
        /// <param name="sex">�����Ա�</param>
        /// <param name="age">��������</param>
        /// <param name="section">����</param>
        /// <param name="ward">����</param>
        /// <param name="inTime">��Ժʱ��</param>
        public TemperInfo(ucTemperatureInfo temperature,string pid, string medicare_no,string bed_no, string userName, string sex, string age, string section, string ward, string inTime, DateTime selectTime, string pids_id)
        {
            try {
                InitializeComponent();
                TemperatureInfo = temperature;
                this.pid = pid;
                this.medicare_no = medicare_no;
                this.bed_no = bed_no;
                this.userName = userName;
                this.sex = sex;
                this.age = age;
                this.section = section;
                this.ward = ward;
                this.inTime = inTime;
                this.pid_ids = pids_id;
                this.cbResult.SelectedIndex = 0;
                this.cbOther.SelectedIndex = 0;
                this.cbWeight.SelectedIndex = 0;
                this.dtpSeachTime.Value = selectTime;
            } catch {

            }
        }

        private List<DataTable> lists;

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemperInfo_Load(object sender,EventArgs e) {
            try {
                dgvResult.DataSource = null;
                dgvOther.DataSource = null;
                this.tw3am.IsHowTime = 2;//3��
                this.tw7am.IsHowTime = 6;//7��
                this.tw11am.IsHowTime = 10;//11��
                this.tw3pm.IsHowTime = 14;//����15��
                this.tw7pm.IsHowTime = 18;//����17��
                this.tw11pm.IsHowTime = 22;//����23��
                dtpSeachTime_ValueChanged(sender,e);
                //SelectTime = this.dtpSeachTime.Value;    //���ڿؼ�ʱ��
                comboBoxIni();
                //setTimeNextLast();
                //inRoom();
                ////App.Ini();
                //string time = SelectTime.ToString("yyyy-MM-dd");
                //if (!DBControl.SelectGreaterZero(time, this.pid_ids)) //�ж��Ƿ��н��������
                //{
                //    lists = DBControl.GetTemper(time, pid_ids);       //��ȡ��������
                //    LoadAll(lists);                               //���ص�ҳ����
                //    lists.Clear();

                // this.dtpSeachTime.ValueChanged += new EventHandler(dtpSeachTime_ValueChanged);
                //}

                //inRooms();
            } catch { }

        }
        /// <summary>
        /// ��Ժ������ݲ�������
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRooms() {
            string time = "";
            string sql = "select * from t_vital_signs where PATIENT_ID=" + pid_ids + "";
            DataSet dsp = App.GetDataSet(sql);
            if (dsp.Tables[0].Rows.Count > 0) {
                for (int i = 0; i < dsp.Tables[0].Rows.Count; i++) {
                    if (dsp.Tables[0].Rows[i]["DESCRIBE"].ToString().Contains("��Ժ")) {
                        time = dsp.Tables[0].Rows[i]["MEASURE_TIME"].ToString();
                        break;
                    }
                }
            }
            if (time != "") {
                DateTime dt = Convert.ToDateTime(Convert.ToDateTime(time));

                if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd")) {

                    if (dt.Hour == 2) {
                        TemperControlEnable(true,false,false,false,false,false);
                    } else if (dt.Hour == 6) {
                        TemperControlEnable(true,true,false,false,false,false);
                    } else if (dt.Hour == 10) {
                        TemperControlEnable(true,true,true,false,false,false);
                    } else if (dt.Hour == 14) {
                        TemperControlEnable(true,true,true,true,false,false);
                    } else if (dt.Hour == 18) {
                        TemperControlEnable(true,true,true,true,true,false);
                    } else if (dt.Hour == 22) {
                        TemperControlEnable(true,true,true,true,true,true);
                    }
                } else {
                    DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(time).ToString("yyyy-MM-dd"));
                    if (Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")) > dt1) {
                        TemperControlEnable(false,false,false,false,false,false);
                        this.btnSave.Enabled = false;
                        this.gbOtherInfo.Enabled = false;
                        dgvResult.Enabled = false;
                        pbOtherList.Enabled = false;
                    } else if (Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")) < dt1) {
                        TemperControlEnable(true,true,true,true,true,true);
                    }
                }
            }


        }
        /// <summary>
        /// �ж�һ��ʱ���Ƿ���ڵ�����һ��ʱ��
        /// </summary>
        /// <param name="ts1"></param>
        /// <param name="ts2"></param>
        /// <returns></returns>
        public bool CompareTimes(DateTime ts1,DateTime ts2) {
            if (ts1.ToString("yyyy-MM-dd") == ts2.ToString("yyyy-MM-dd")) {
                return true;
            }

            if (DateTime.Compare(ts1,ts2) > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        ///   �󶨳���������ֵ
        /// </summary>
        public void comboBoxIni() {

            resuleBox.Visible = false;
            resuleBox.SelectedIndexChanged += new EventHandler(resuleBox_SelectedIndexChanged);
            resuleBox.DrawMode = DrawMode.OwnerDrawFixed;
            resuleBox.DataSource = new string[] { "--��ѡ��--","����","����" };
            resuleBox.MeasureItem += new MeasureItemEventHandler(resuleBox_MeasureItem);
            resuleBox.DrawItem += new DrawItemEventHandler(resuleBox_DrawItem);
            resuleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dgvResult.Controls.Add(resuleBox);

        }
        /// <summary>
        /// �ж���һ����һ��
        /// </summary>
        public void setTimeNextLast() {
            // ��һ��  
            this.linkLabel2.Text = this.dtpSeachTime.Value.AddDays(1).ToString("yyyy-MM-dd >>");
            //��һ��
            this.linkLabel1.Text = this.dtpSeachTime.Value.AddDays(-1).ToString("<< yyyy-MM-dd");
        }

        private void resuleBox_MeasureItem(object sender,MeasureItemEventArgs e) {

            //��������������õ׿�߶�
            switch (e.Index) {
                case 0:
                    e.ItemHeight = 15;
                    break;
                case 1:
                    e.ItemHeight = 20;
                    break;
                case 2:
                    e.ItemHeight = 25;
                    break;
            }
            e.ItemWidth = 20;//������Ŀ��
        }

        private void resuleBox_DrawItem(object sender,DrawItemEventArgs e) {
            Brush myBrush = Brushes.Black;

            e.DrawBackground();


            //���������������������ɫ
            switch (e.Index) {
                case 1:
                    myBrush = Brushes.Red;
                    break;
                default:
                    myBrush = Brushes.Black;
                    break;
            }

            //���Ҫ���ô�С����һ���µ�Font�������滻e.Font
            e.Graphics.DrawString(resuleBox.Items[e.Index].ToString(),e.Font,myBrush,e.Bounds,StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
        /// <summary>
        /// �жϵ�ǰѡ�е�ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resuleBox_SelectedIndexChanged(object sender,EventArgs e) {
            if (dgvResult.RowCount > 0) {
                if (((ComboBox)sender).Text == "--��ѡ��--") {
                    this.dgvResult.CurrentCell.Style.ForeColor = Color.Black;
                    this.dgvResult.CurrentCell.Value = "--��ѡ��--";
                    this.dgvResult.CurrentCell.Tag = "0";
                } else if (((ComboBox)sender).Text == "����") {
                    this.dgvResult.CurrentCell.Style.ForeColor = Color.Red;
                    this.dgvResult.CurrentCell.Value = "����";
                    this.dgvResult.CurrentCell.Tag = "1";
                } else {
                    this.dgvResult.CurrentCell.Style.ForeColor = Color.Black;
                    this.dgvResult.CurrentCell.Value = "����";
                    this.dgvResult.CurrentCell.Tag = "2";
                }
                this.resuleBox.Visible = false;
            }
        }

        /// <summary>
        /// Ƥ�Խ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvResult_CurrentCellChanged(object sender,EventArgs e) {
            if (this.dgvResult.CurrentCell != null) {
                if (this.dgvResult.CurrentCell.ColumnIndex == 1 && this.dgvResult.CurrentCell.RowIndex >= 0) {
                    Rectangle rect = this.dgvResult.GetCellDisplayRectangle(this.dgvResult.CurrentCell.ColumnIndex,this.dgvResult.CurrentCell.RowIndex,false);
                    if (rect.Top > 10) {
                        string sexValue = this.dgvResult.CurrentCell.Value.ToString();
                        if (sexValue == "--��ѡ��--") {
                            this.resuleBox.Text = "--��ѡ��--";
                        } else if (sexValue == "����") {
                            this.resuleBox.Text = "����";
                        } else {
                            this.resuleBox.Text = "����";
                        }
                        resuleBox.Left = rect.Left;
                        resuleBox.Top = rect.Top;
                        resuleBox.Width = rect.Width;
                        resuleBox.Height = rect.Height;

                        resuleBox.Visible = true;
                    }
                } else {
                    resuleBox.Visible = false;
                }
            }
        }


        private void dgvResult_Scroll(object sender,ScrollEventArgs e) {
            this.resuleBox.Visible = false;
        }

        private void dgvResult_ColumnWidthChanged(object sender,DataGridViewColumnEventArgs e) {
            this.resuleBox.Visible = false;
        }

        /// <summary>
        /// ���ؽ��ձ�����Ϣ
        /// </summary>
        /// <param name="lists"></param>
        public void LoadAll(List<DataTable> lists) {
            DataTable dt1 = lists[0];
            DataTable dt2 = lists[1];

            if (dt1.Rows.Count > 0) {
                for (int i = 0; i < dt1.Rows.Count; i++) {
                    int hour = Convert.ToInt32(Convert.ToDateTime(dt1.Rows[i]["measure_time"]).ToString("HH"));
                    
                    if (hour >= 1 && hour < 5)
                    { hour = 3; }
                    else if (hour >= 5 && hour < 9)
                    { hour = 7; }
                    else if (hour >= 9 && hour < 13)
                    { hour = 11; }
                    else if (hour >= 13 && hour < 17)
                    { hour = 15; }
                    else if (hour >= 17 && hour < 21)
                    { hour = 19; }
                    else if (hour >= 21 || hour < 1)
                    { hour = 23; }
                    switch (hour) {
                        case 3:
                            this.tw3am.setTempers(dt1.Rows[i],hour.ToString());
                            break;
                        case 7:
                            this.tw7am.setTempers(dt1.Rows[i],hour.ToString());
                            break;
                        case 11:
                            this.tw11am.setTempers(dt1.Rows[i],hour.ToString());
                            break;
                        case 15:
                            this.tw3pm.setTempers(dt1.Rows[i],hour.ToString());
                            break;
                        case 19:
                            this.tw7pm.setTempers(dt1.Rows[i],hour.ToString());
                            break;
                        case 23:
                            this.tw11pm.setTempers(dt1.Rows[i],hour.ToString());
                            break;
                    }
                }
            }
            //-------------------------------------------------------------------------------

            #region ������Ϣ

            if (dt2.Rows.Count > 0) 
            {
                //������
                
                switch (dt2.Rows[0]["stool_state"].ToString()) {
                    case "N":
                        this.rbNormal.Checked = true;
                        if (dt2.Rows[0]["stool_count"].ToString() != "")
                        {// || dt2.Rows[0]["stool_count"].ToString() == "0") {//
                            this.txtNormalDefecate.Text = dt2.Rows[0]["stool_count"].ToString();
                        } else {
                            this.txtNormalDefecate.Text = "";
                        }
                        s_count = dt2.Rows[0]["stool_count"].ToString();
                        setIsTrurFalse("rbNormal",1);
                        break;
                    case "C":
                        this.rbEnema.Checked = true;
                        if (dt2.Rows[0]["clysis_count"].ToString() != "")
                        {// || dt2.Rows[0]["clysis_count"].ToString() != "0") {
                            this.txtEnemaCount.Text = dt2.Rows[0]["clysis_count"].ToString();
                        } else {
                            this.txtEnemaCount.Text = "";
                        }

                        if (dt2.Rows[0]["stool_count_e"].ToString() != "")
                        {// || dt2.Rows[0]["stool_count_e"].ToString() != "0") {
                            this.txtEnemaDefecate.Text = dt2.Rows[0]["stool_count_e"].ToString();
                        } else {
                            this.txtEnemaDefecate.Text = "";
                        }

                        if (dt2.Rows[0]["Stool_count_f"].ToString() != "")
                        {// || dt2.Rows[0]["Stool_count_f"].ToString() != "0") {
                            this.txtEnemaBeforeDefecate.Text = dt2.Rows[0]["Stool_count_f"].ToString();
                        } else {
                            this.txtEnemaBeforeDefecate.Text = "";
                        }

                        setIsTrurFalse("rbEnema",1);
                        break;
                    case "I":
                        this.rbIncontinence.Checked = true;
                        setIsTrurFalse("rbIncontinence",1);
                        break;
                }
                //�����
                if (dt2.Rows[0]["stool_amount"].ToString() != "")
                {//&& dt2.Rows[0]["stool_amount"].ToString() != "0") {
                    this.txtAmongHas.Text = dt2.Rows[0]["stool_amount"].ToString();
                } else {
                    this.txtAmongHas.Text = "";
                }

                this.txtAmontUnit.SelectedIndex = dt2.Rows[0]["stool_amount_unit"].ToString()
                    == "" ? 0 : Convert.ToInt32(dt2.Rows[0]["stool_amount_unit"].ToString());


                //����
                if (dt2.Rows[0]["stale_amount"].ToString() != "")
                {//&& dt2.Rows[0]["stale_amount"].ToString() != "0") {
                    this.txtCatheterization.Text = dt2.Rows[0]["stale_amount"].ToString();
                } else {
                    this.txtCatheterization.Text = "";
                }
                //����
                if (dt2.Rows[0]["in_amount"].ToString() != "")
                {//&& dt2.Rows[0]["in_amount"].ToString() != "0") {
                    this.txtThe.Text = dt2.Rows[0]["in_amount"].ToString();
                } else {
                    this.txtThe.Text = "";
                }

                //����
                if (dt2.Rows[0]["out_amount"].ToString() != "")
                {//&& dt2.Rows[0]["out_amount"].ToString() != "0") {
                    this.txtOut.Text = dt2.Rows[0]["out_amount"].ToString();
                } else {
                    this.txtOut.Text = "";
                }

                //�Ƿ���
                if (dt2.Rows[0]["is_catheter"].ToString() == "Y") {
                    this.ckIsDaoniao.Checked = true;
                } else {
                    this.ckIsDaoniao.Checked = false;
                }

                //̵��
                if (dt2.Rows[0]["SPUTUM_QUANTITY"].ToString() != "" ) //&& dt2.Rows[0]["SPUTUM_QUANTITY"].ToString() != "0")
                {
                    this.txtSputum_quantity.Text = dt2.Rows[0]["SPUTUM_QUANTITY"].ToString();
                }
                else
                {
                    this.txtSputum_quantity.Text = "";
                }

                //������
                if (dt2.Rows[0]["Volume_of_drainage"].ToString() != "")// && dt2.Rows[0]["Volume_of_drainage"].ToString() != "0")
                {
                    string[] str = dt2.Rows[0]["Volume_of_drainage"].ToString().Split('|');
                    this.txtVolume_of_drainage.Text = str[0].ToString();
                    if (str.Length>1)
                    {
                        this.txtVolume_of_drainage2.Text = str[1].ToString();
                    }
                    
                }
                else
                {
                    this.txtVolume_of_drainage.Text = "";
                }

                //Ż����
                if (dt2.Rows[0]["Vomit"].ToString() != "" )//&& dt2.Rows[0]["Vomit"].ToString() != "0")
                {
                    this.txtVomit.Text = dt2.Rows[0]["Vomit"].ToString();
                }
                else
                {
                    this.txtVomit.Text = "";
                }


                //SPO2
                if (dt2.Rows[0]["SPO2"].ToString() != "")
                {
                    this.txtSPO2.Text = dt2.Rows[0]["SPO2"].ToString();
                }
                else
                {
                    this.txtSPO2.Text = "";
                }

                //���
                if (dt2.Rows[0]["length"].ToString() != "")
                {//&& dt2.Rows[0]["length"].ToString() != "0") {
                    this.txtHeight.Text = dt2.Rows[0]["length"].ToString();
                }
                if (dt2.Rows[0]["bp_high"].ToString() != ""){// && dt2.Rows[0]["bp_high"].ToString() != "0") {
                    this.txtBloodOne1.Text = dt2.Rows[0]["bp_high"].ToString();
                }

                //��������
                this.txtSpecial.Text = dt2.Rows[0]["Special"].ToString();
                //����
                switch (dt2.Rows[0]["weighttype"].ToString()) {
                    case "P":
                        this.rdFlatcar.Checked = true;
                        LoadWeight();
                        break;
                    case "W":
                        this.rdBed.Checked = true;
                        LoadWeight();
                        break;
                    case "L":
                        this.rbWheelchairs.Checked = true;
                        LoadWeight();
                        break;
                    default:
                        if (dt2.Rows[0]["weight"].ToString() != "")
                        {//&& dt2.Rows[0]["weight"].ToString() != "0") {
                            if (float.Parse(dt2.Rows[0]["weight"].ToString()) >= 0) {
                                this.rbWeightOk.Checked = true;
                                this.txtWeight.Text = dt2.Rows[0]["weight"].ToString();
                                //this.cbWeight.SelectedIndex = Convert.ToInt32(dt2.Rows[0]["weight_unit"].ToString());
                            }
                        } else {
                            this.txtWeight.Text = "";
                        }
                        break;
                }
                //Ѫѹ
                string bp_blood = dt2.Rows[0]["bp_blood"].ToString();
                if (bp_blood != "") {
                    if (!bp_blood.ToString().Contains(",")) {
                        if (!bp_blood.ToString().Contains("/")) {
                            string oneOrTwo = bp_blood.Substring(0,1);
                            string one = bp_blood.Substring(1,bp_blood.Length - 1);
                            if (oneOrTwo == "O") {
                                if (one.Length > 1) {
                                    this.rbBloodOne.Checked = true;
                                    this.txtBloodOne1.Text = one;
                                    this.txtBloodOne2.Text = "";
                                } else {
                                    this.rbBloodOneNo.Checked = true;
                                }
                            } else {
                                if (one.Length > 1) {
                                    this.rbBloodTwo.Checked = true;
                                    this.txtBloodTwo1.Text = one;
                                    this.txtBloodTwo2.Text = "";
                                } else {
                                    this.rbBloodTwoNo.Checked = true;
                                }
                            }
                        } else {
                            string oneOrTwo = bp_blood.Substring(0,1);
                            string[] one = bp_blood.Substring(1,bp_blood.Length - 1).Split('/');
                            if (oneOrTwo == "O") {
                                if (one.Length > 1) {
                                    this.rbBloodOne.Checked = true;
                                    this.txtBloodOne1.Text = one[0];
                                    this.txtBloodOne2.Text = one[1];
                                } else {
                                    this.rbBloodOneNo.Checked = true;
                                }
                            } else {
                                if (one.Length > 1) {
                                    this.rbBloodTwo.Checked = true;
                                    this.txtBloodTwo1.Text = one[0];
                                    this.txtBloodTwo2.Text = one[1];
                                } else {
                                    this.rbBloodTwoNo.Checked = true;
                                }
                            }
                        }

                    } else {
                        string[] bloodArr = bp_blood.Split(',');
                        if (bloodArr.Length > 1) {
                            string[] bloodOne = bloodArr[0].Substring(1,bloodArr[0].Length - 1).Split('/');

                            if (bloodOne.Length > 1) {
                                this.rbBloodOne.Checked = true;
                                this.txtBloodOne1.Text = bloodOne[0];
                                this.txtBloodOne2.Text = bloodOne[1];
                            } else {
                                this.rbBloodOneNo.Checked = true;
                            }
                            string[] bloodTwo = bloodArr[1].Substring(1,bloodArr[1].Length - 1).Split('/');
                            if (bloodTwo.Length > 1) {
                                this.rbBloodTwo.Checked = true;
                                this.txtBloodTwo1.Text = bloodTwo[0];
                                this.txtBloodTwo2.Text = bloodTwo[1];
                            } else {
                                this.rbBloodTwoNo.Checked = true;
                            }

                        } else {
                            string oneOrTwo = bp_blood.Substring(0,1);
                            string[] one = bp_blood.Substring(1,bp_blood.Length - 1).Split('/');
                            if (oneOrTwo == "O") {
                                if (one.Length > 1) {
                                    this.rbBloodOne.Checked = true;
                                    this.txtBloodOne1.Text = one[0];
                                    this.txtBloodOne2.Text = one[1];
                                } else {
                                    this.rbBloodOneNo.Checked = true;
                                }
                            } else {
                                if (one.Length > 1) {
                                    this.rbBloodTwo.Checked = true;
                                    this.txtBloodTwo1.Text = one[0];
                                    this.txtBloodTwo2.Text = one[1];
                                } else {
                                    this.rbBloodTwoNo.Checked = true;
                                }
                            }
                        }
                    }
                }

                if (this.rbBloodOneNo.Checked) {
                    this.txtBloodOne1.Enabled = false;
                    this.txtBloodOne2.Enabled = false;
                } else {
                    this.rbBloodOne.Checked = true;
                    this.txtBloodOne1.Enabled = true;
                    this.txtBloodOne2.Enabled = true;
                }

                if (this.rbBloodTwoNo.Checked) {
                    this.txtBloodTwo1.Enabled = false;
                    this.txtBloodTwo2.Enabled = false;
                } else {
                    this.rbBloodTwo.Checked = true;
                    this.txtBloodTwo1.Enabled = true;
                    this.txtBloodTwo2.Enabled = true;
                }


                //��������
                string out_other = dt2.Rows[0]["out_other"].ToString();
                if (out_other != "") {
                    string[] outOtherArr = out_other.Split(';');
                    foreach (string s in outOtherArr) {
                        this.dgvOther.Rows.Add(s.Split(':')[0], s.Split(':')[1].Substring(0, s.Split(':')[1].Length), "ɾ��");// - 2
                    }
                }
                //Ƥ�Խ��
                string sensi_test_result_temp = dt2.Rows[0]["sensi_test_result_temp"].ToString();
                if (sensi_test_result_temp != "") {
                    string[] sensi_temp = sensi_test_result_temp.Split('|');
                    int i = 0;
                    foreach (string var in sensi_temp) {
                        i++;
                        this.dgvResult.Rows.Add(var.Split('(')[0],var.Split('(')[1].Substring(0,2),"ɾ��");
                        if (dgvResult.Rows[i - 1].Cells[1].Value.ToString() == "����") {
                            dgvResult.Rows[i - 1].Cells[1].Style.ForeColor = Color.Red;
                        }
                    }
                }


            }
            #endregion
        }

        private void LoadWeight() {
            this.txtWeight.Text = "";
            this.txtWeight.Enabled = false;
            this.cbWeight.SelectedIndex = 0;
            this.cbWeight.Enabled = false;
        }

        /// <summary>
        /// UserControl ��ԭ��ʼ
        /// </summary>
        private void ClearTempers() {
            this.tw3am.Clear();
            this.tw7am.Clear();
            this.tw11am.Clear();
            this.tw3pm.Clear();
            this.tw7pm.Clear();
            this.tw11pm.Clear();
        }


        /// <summary>
        /// ֻ�����������ֺ�С����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInput_KeyPress(object sender,KeyPressEventArgs e) {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete) {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Delete) {
                if ((sender as TextBox).Text.Split('.').Length >= 2) {
                    e.Handled = true;
                    return;
                }
            }

            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete) {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1) {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// ֻ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender,KeyPressEventArgs e) {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete) {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Back) {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1) {
                e.Handled = true;
                return;
            }
        }

        List<Class_T_Vital_Signs> list = new List<Class_T_Vital_Signs>();

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender,EventArgs e) {
            string time = SelectTime.ToString("yyyy-MM-dd");
            DBControl.IsClear(time,this.pid_ids); //����ʱ���������
            string title = string.Format("��ѯʱ��[{0}]-��������[{1}]-���˱��[{2}]-��������[{3}]-����[{4}]-����[{5}]-",time, pid_ids, pid, userName, bed_no, section);
            if (Excute())                      //���²�������Remove
            {
                if (Erm!="")
                {
                    DBControl.ErrorLog("���µ�����ɹ�: �����û�:" + App.UserAccount.UserInfo.User_name,title + Erm);
                }
                App.Msg("���ݱ���ɹ�");
                list.Clear();
                s_count = this.txtNormalDefecate.Text;
                dgvResult.DataSource = null;
                dgvOther.DataSource = null;
                if (TemperatureInfo != null)
                {
                    TemperatureInfo.ucTemperatureInfo_Load(sender, e);
                }
            } else {
                if (Erm != "")
                {
                    DBControl.ErrorLog("���µ�����ʧ��: �����û�:" + App.UserAccount.UserInfo.User_name,title + Erm);
                }
                App.Msg("���ݱ���ʧ��");
                list.Clear();
            }
        }

        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <returns></returns>
        public bool Excute() {
            list.Add(this.tw3am.GetTempers(this.pid,this.bed_no,SelectTime.ToString("yyyy-MM-dd 03:00"),this.pid_ids));
            list.Add(this.tw7am.GetTempers(this.pid,this.bed_no,SelectTime.ToString("yyyy-MM-dd 07:00"),this.pid_ids));
            list.Add(this.tw11am.GetTempers(this.pid,this.bed_no,SelectTime.ToString("yyyy-MM-dd 11:00"),this.pid_ids));
            list.Add(this.tw3pm.GetTempers(this.pid,this.bed_no,SelectTime.ToString("yyyy-MM-dd 15:00"),this.pid_ids));
            list.Add(this.tw7pm.GetTempers(this.pid,this.bed_no,SelectTime.ToString("yyyy-MM-dd 19:00"),this.pid_ids));
            list.Add(this.tw11pm.GetTempers(this.pid,this.bed_no,SelectTime.ToString("yyyy-MM-dd 23:00"),this.pid_ids));
            return DBControl.InsertTempers(list,ExcuteTemperOther());
        }

        /// <summary>
        /// ��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public Class_T_Temperature_Info ExcuteTemperOther()
        {
            Class_T_Temperature_Info tti = new Class_T_Temperature_Info();
            
            //����
            tti.Bed_no = this.bed_no;

            //���˱��
            tti.Pid = this.pid;
            tti.Patient_id = this.pid_ids;
            //������
            if (rbNormal.Checked) //����
            {
                if (this.txtNormalDefecate.Text != "") {
                    tti.Stool_count = this.txtNormalDefecate.Text.ToString();
                }
                tti.Stool_state = "N";
            } else if (rbRengonggangchang.Checked)  //�˹�����
            {
                tti.Stool_state = "G";
            } else if (rbEnema.Checked) //�೦
            {
                if (this.txtEnemaCount.Text != "") {
                    tti.Clysis_count = this.txtEnemaCount.Text.ToString();
                }
                if (this.txtEnemaDefecate.Text != "") {
                    tti.Stool_count_e = this.txtEnemaDefecate.Text.ToString();
                }
                if (this.txtEnemaBeforeDefecate.Text != "") {
                    tti.Stool_count_f = this.txtEnemaBeforeDefecate.Text.Trim();
                }
                tti.Stool_state = "C";
            } else {
                tti.Stool_state = "I";  //ʧ��
            }
            if (s_count!=this.txtNormalDefecate.Text)
            {
                Erm = "�޸�ǰtextֵ:[" + s_count + "]-�޸ĺ�textֵ:[" + this.txtNormalDefecate.Text + "]-�������:[" + tti.Stool_state+"]";
            }
            else
            {
                Erm = "";
            }
            
            //�����
            if (this.txtAmongHas.Text != "") {
                tti.Stool_amount = this.txtAmongHas.Text;
                //tti.sto
            }
            //else
            //{
            //    tti.Stool_amount = "";
            //}

            //��㵥λ
            if (this.txtAmontUnit.Text != "") {
                tti.Stool_amount_unit = this.txtAmontUnit.SelectedIndex.ToString();
            }          

            //����
            if (this.txtCatheterization.Text != "") {
                tti.Stale_amount = this.txtCatheterization.Text;
            }

            //�Ƿ���
            if (this.ckIsDaoniao.Checked) {
                tti.Is_catheter = "Y";
            } else {
                tti.Is_catheter = "N";
            }

            //����
            if (this.rdFlatcar.Checked) {
                tti.Weighttype = "P";//ƽ��
            } else if (this.rdBed.Checked) {
                tti.Weighttype = "W";//�Դ�
            } else if (this.rbWheelchairs.Checked) {
                tti.Weighttype = "L";//����    
            } else {
                if (this.txtWeight.Text != "") {
                    //if (this.cbWeight.SelectedIndex == 0)
                    //{
                    tti.Weight = this.txtWeight.Text;
                    //    tti.Weight_unit = this.cbWeight.SelectedIndex.ToString();
                    //}
                }
            }

            //���
            if (this.txtHeight.Text != "") {
                tti.Length = this.txtHeight.Text;
            }

            //ʱ��
            tti.Record_time = SelectTime.ToString("yyyy-MM-dd HH:mm");

            //����
            if (this.txtThe.Text != "") {
                tti.In_amount = this.txtThe.Text;
            }
            //����-����
            if (this.txtOut.Text != "") {
                tti.Out_amount = this.txtOut.Text;
            }
            //̵��
            if (this.txtSputum_quantity.Text != "")
            {
                tti.Sputum_quantity = this.txtSputum_quantity.Text;
            }
            //������
            if (this.txtVolume_of_drainage.Text != "")
            {
                tti.Volume_of_drainage = this.txtVolume_of_drainage.Text + "|" + this.txtVolume_of_drainage2.Text;
            }
            //Ż����
            if (this.txtVomit.Text != "")
            {
                tti.Vomit = this.txtVomit.Text;
            }
            //��������
            if (this.txtSpecial.Text != "")
            {
                tti.Special =this.txtSpecial.Text;
            }
            //SPO2
            if(this.txtSPO2.Text!="")
            {
                tti.Spo2 = this.txtSPO2.Text;
            }
            string blood = "";
            //Ѫѹ 1
            if (rbBloodOne.Checked) {
                if (txtBloodOne1.Text != "" && txtBloodOne2.Text != "") {
                    blood += "O" + txtBloodOne1.Text + "/" + txtBloodOne2.Text;
                }
            } else if (rbBloodOneNo.Checked) {
                blood += "O" + "�ⲻ��";
            }


            if (rbBloodTwo.Checked) {
                if (txtBloodTwo1.Text != "" && txtBloodTwo2.Text != "") {            //Ѫѹ2
                    if (blood != "") {
                        blood += ",";
                    }
                    blood += "T" + txtBloodTwo1.Text + "/" + txtBloodTwo2.Text;
                }
            } else if (rbBloodTwoNo.Checked) {            //Ѫѹ2
                if (blood != "") {
                    blood += ",";
                }
                blood += "T" + "�ⲻ��";
            }
            tti.Bp_blood = blood;


            //��������
            string outOther = "";
            if (dgvOther.Rows.Count > 0) {
                foreach (DataGridViewRow dr in dgvOther.Rows) {
                    if (dr.Cells[1].Value.ToString() != "") {
                        outOther += dr.Cells[0].Value.ToString() + ":" + dr.Cells[1].Value.ToString() + ";";
                        //if (float.Parse(dr.Cells[1].Value.ToString()) > 0) {
                        //    double temp = 0.0D;
                        //    if (double.TryParse(dr.Cells[1].Value.ToString(),out temp)) {
                        //        outOther += dr.Cells[0].Value.ToString() + ":" + temp.ToString() + "ml;";
                        //    } else {
                        //        outOther += dr.Cells[0].Value.ToString() + ":" + dr.Cells[1].Value.ToString() + ";";
                        //    }
                        //}
                    }
                }
            }

            if (outOther.Length > 1) {
                tti.Out_other = outOther.Substring(0,outOther.Length - 1);
            }

            //Ƥ�Խ��

            string skonList = "";
            if (dgvResult.Rows.Count > 0) {
                foreach (DataGridViewRow dr in dgvResult.Rows) {
                    if (dr.Cells[1].Value.ToString() != "--��ѡ��--") {
                        skonList += dr.Cells[0].Value.ToString() + "(" + dr.Cells[1].Value.ToString() + ")" + "|";
                    }
                }
            }
            if (skonList.Length > 1) {
                tti.Sensi_test_result_temp = skonList.Substring(0,skonList.Length - 1);
            }

            return tti;
        }

        /// <summary>
        /// Ѫѹѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbBlood_Click(object sender,EventArgs e) {
            RadioButton rb = sender as RadioButton;
            switch (rb.Name.ToString()) {
                case "rbBloodOne":
                    txtBloodOne1.Text = "";
                    txtBloodOne2.Text = "";
                    txtBloodOne1.Enabled = true;
                    txtBloodOne2.Enabled = true;
                    break;
                case "rbBloodOneNo":
                    txtBloodOne1.Text = "";
                    txtBloodOne2.Text = "";
                    txtBloodOne1.Enabled = false;
                    txtBloodOne2.Enabled = false;
                    break;
                case "rbBloodTwo":
                    txtBloodTwo1.Text = "";
                    txtBloodTwo2.Text = "";
                    txtBloodTwo1.Enabled = true;
                    txtBloodTwo2.Enabled = true;
                    break;
                case "rbBloodTwoNo":
                    txtBloodTwo1.Text = "";
                    txtBloodTwo2.Text = "";
                    txtBloodTwo1.Enabled = false;
                    txtBloodTwo2.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbWeight_Click(object sender,EventArgs e) {
            RadioButton radioButton = sender as RadioButton;
            bool isWidth = false;
            switch (radioButton.Name.ToString()) {
                case "rbWeightOk"://�ֶ���д����
                    txtWeight.Enabled = true;
                    cbWeight.Enabled = true;
                    break;
                case "rdFlatcar"://ƽ��
                    isWidth = true;
                    break;
                case "rdBed"://�Դ�
                    isWidth = true;
                    break;
                case "rbWheelchairs"://����
                    isWidth = true;
                    break;
            }
            if (isWidth) {
                cbWeight.Enabled = false;
                txtWeight.Text = "";
                txtWeight.Enabled = false;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbNormal_Click(object sender,EventArgs e) {
            RadioButton radioButton = sender as RadioButton;
            //����radioButton.Name���н�����ʾ���ж�
            setIsTrurFalse(radioButton.Name.ToString());
        }
        /// <summary>
        /// ���ݴ������ƽ���ѡ��
        /// </summary>
        /// <param name="name">�������</param>
        private void setIsTrurFalse(string name) {
            switch (name) {
                //����
                case "rbNormal":
                    txtNormalDefecate.Enabled = true;
                    txtEnemaCount.Text = "";
                    if (txtEnemaCount.Text == "") {
                        txtEnemaCount.Text = "0";
                    }
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
                //ʧ��
                case "rbIncontinence":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
                //�೦
                case "rbEnema":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "1";
                    txtEnemaCount.Enabled = true;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = true;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = true;
                    break;
                //�˹��س�
                case "rbRengonggangchang":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
            }
        }
        /// <summary>
        /// ���ݴ������ƺʹ�������ѡ��
        /// </summary>
        /// <param name="name">��������</param>
        /// <param name="xxx">���Ĵ���</param>
        private void setIsTrurFalse(string name,int xxx) {
            switch (name) {
                //����
                case "rbNormal":
                    txtNormalDefecate.Enabled = true;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    //if (txtEnemaDefecate.Text == "")
                    //{
                    //    txtEnemaDefecate.Text = "0";
                    //}
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";

                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
                //ʧ��
                case "rbIncontinence":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
                //�೦
                case "rbEnema":
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Enabled = true;
                    txtEnemaDefecate.Enabled = true;
                    txtEnemaBeforeDefecate.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender,EventArgs e) {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.inTime).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            //�ж�ʱ�䣬�����Ժʱ����ڽ�����ʱ��Ļ����ͽ�����ʾ
            if (inDatetime.CompareTo(today) > 0) {
                App.Msg("��Ժʱ��" + Convert.ToDateTime(this.inTime).ToString("yyyy-MM-dd") + "���ڽ���ʱ��" + DateTime.Now.ToString("yyyy-MM-dd") + "");
                return;
            }

            InPatientInfo currentPatient = DataInit.GetInpatientInfoByPid(pid_ids);
            frmTemperPrint ftt = new frmTemperPrint(currentPatient);//pid, medicare_no, pid_ids, bed_no, userName, sex, age, section, ward, inTime);
            ftt.ShowDialog();
        }

        private string GetSelectItemId(string pid) {
            string Sql = "select PID from T_IN_PATIENT  where ID ='" + pid + "'";
            string ID = App.ReadSqlVal(Sql,0,"PID");
            return ID;
        }
        /// <summary>
        /// ���� ���� ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOther_Click(object sender,EventArgs e) {
            if (cbOther.SelectedIndex != 0) {
                foreach (DataGridViewRow dr in dgvOther.Rows) {
                    if (pbOther.Visible) {
                        if (this.txtOther.Text == dr.Cells[0].Value.ToString()) {
                            App.Msg("�����Ѵ������б��С�����");
                            return;
                        }
                    } else {
                        if (dr.Cells[0].Value.ToString() == this.cbOther.Text.ToString()) {
                            App.Msg("�����Ѵ������б��С�����");
                            return;
                        }
                    }
                }
                if (this.cbOther.Text.ToString() == "����") {
                    if (this.txtOther.Text.Trim() == "") {
                        App.Msg("�����������Ϊ��ֵ");
                        return;
                    }
                    this.dgvOther.Rows.Add(this.txtOther.Text.ToString(),"","ɾ��");
                    this.txtOther.Text = "";
                } else {
                    this.dgvOther.Rows.Add(this.cbOther.Text.ToString(),"","ɾ��");
                }
            }
        }
        /// <summary>
        /// ������Ԫ�������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOther_CellContentClick(object sender,DataGridViewCellEventArgs e) {
            if (dgvOther.Rows.Count > 0 && e.ColumnIndex == 2 && e.RowIndex >= 0) {
                dgvOther.Rows.Remove(dgvOther.Rows[e.RowIndex]);
            }
        }
        /// <summary>
        /// Ƥ�Խ��ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResultClick_Click(object sender,EventArgs e) {
            if (cbResult.SelectedIndex != 0) {
                foreach (DataGridViewRow dr in dgvResult.Rows) {
                    if (dr.Cells[0].Value.ToString() == this.cbResult.Text.ToString()) {
                        App.Msg("�����Ѵ������б��С�����");
                        return;
                    }
                }
                this.dgvResult.Rows.Add(this.cbResult.Text.ToString(),"--��ѡ��--","ɾ��");
            }
        }

        private void dgvResult_CellContentClick(object sender,DataGridViewCellEventArgs e) {
            if (this.dgvResult.Rows.Count > 0 && e.ColumnIndex == 2 && e.RowIndex >= 0) {
                this.dgvResult.Rows.Remove(dgvResult.Rows[e.RowIndex]);
            }
        }
        /// <summary>
        /// ��ǰʱ���ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSeachTime_ValueChanged(object sender,EventArgs e) {
            dgvResult.DataSource = null;
            dgvOther.DataSource = null;
            //��ȡ��ǰʱ��
            SelectTime = this.dtpSeachTime.Value;
            //lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToString("yyyy-MM-dd") + "<<";
            //lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToString("yyyy-MM-dd");
            // ��һ��  
            this.linkLabel2.Text = this.dtpSeachTime.Value.AddDays(1).ToString("yyyy-MM-dd >>");
            //��һ��
            this.linkLabel1.Text = this.dtpSeachTime.Value.AddDays(-1).ToString("<< yyyy-MM-dd");
            inRoom();
            setTimeNextLast();
            ClearInfo();
            s_count = "";
            if (CompareTime(SelectTime,Convert.ToDateTime(this.inTime))) {
                string dateTime = SelectTime.ToString("yyyy-MM-dd");

                if (!DBControl.SelectGreaterZero(dateTime,this.pid_ids)) {
                    lists = DBControl.GetTemper(dateTime,this.pid_ids);
                    LoadAll(lists);
                    lists.Clear();

                }
            }
            inRooms();
            this.tw3am.IsHowTime = 3;//3��
            this.tw7am.IsHowTime = 7;//7��
            this.tw11am.IsHowTime = 11;//11��
            this.tw3pm.IsHowTime = 15;//����15��
            this.tw7pm.IsHowTime = 19;//����19��
            this.tw11pm.IsHowTime = 23;//����23��
        }

        /// <summary>
        /// ��ԭ������Ϣ
        /// </summary>
        private void ClearInfo() {
            ClearTempers();
            ClearOtherTemper();
        }
        //ˢ�´���
        private void ClearOtherTemper() {

            this.txtNormalDefecate.Text = "";
            this.txtNormalDefecate.Enabled = true;
            this.rbNormal.Checked = true;
            this.txtEnemaCount.Text = "";
            this.cbWeight.Enabled = true;
            this.txtWeight.Enabled = true;
            this.txtEnemaCount.Enabled = false;
            this.txtEnemaDefecate.Text = "";
            this.txtEnemaDefecate.Enabled = false;
            this.txtEnemaBeforeDefecate.Text = "";
            this.txtEnemaBeforeDefecate.Enabled = false;
            this.txtThe.Text = "";
            this.txtOut.Text = "";
            this.txtCatheterization.Text = "";
            this.ckIsDaoniao.Checked = false;
            this.cbOther.SelectedIndex = 0;
            this.dgvOther.Rows.Clear();
            this.txtWeight.Text = "";
            this.cbWeight.SelectedIndex = 0;
            this.txtHeight.Text = "";
            this.cbResult.SelectedIndex = 0;
            this.dgvResult.Rows.Clear();
            this.rbWeightOk.Checked = true;
            this.rbBloodOne.Checked = true;
            this.txtAmongHas.Text = "";
            this.rbBloodOne.Checked = true;
            this.rbBloodTwo.Checked = true;
            this.txtBloodOne1.Text = "";
            this.txtBloodOne2.Text = "";
            this.txtBloodTwo1.Text = "";
            this.txtBloodTwo2.Text = "";
            this.txtSputum_quantity.Text = "";
            this.txtVolume_of_drainage.Text = "";
            this.txtVolume_of_drainage2.Text = "";
            this.txtVomit.Text = "";
            this.txtSpecial.Text = "";
        }

        private void txtThe_TextChanged(object sender,EventArgs e) {
            TextBox text = sender as TextBox;
            if (text.Text.Trim() == ".") {
                text.Text = "";
                return;
            }
        }

        private void cbOther_SelectedIndexChanged(object sender,EventArgs e) {
            ComboBox Cobtype = sender as ComboBox;
            if (Cobtype.Name == "cbOther") {
                if (Cobtype.Text == "����") {
                    this.pbOther.Visible = true;
                    this.txtOther.Text = "";
                    //����
                    // this.pbOtherList.Location = new Point(237 + this.pbOther.Size.Width, this.pbOtherList.Location.Y);

                } else {
                    if (this.pbOther.Visible) {
                        this.pbOther.Visible = false;
                        //this.pbOtherList.Location = new Point(237, this.pbOtherList.Location.Y);
                    }

                }
            }
            // this.label2.Focus();
        }
        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_Click(object sender,EventArgs e) {
            this.dtpSeachTime.Value = this.dtpSeachTime.Value.AddDays(-1);
            setTimeNextLast();
            dtpSeachTime_ValueChanged(sender,e);

        }
        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel2_Click(object sender,EventArgs e) {
            this.dtpSeachTime.Value = this.dtpSeachTime.Value.AddDays(1);
            setTimeNextLast();
            dtpSeachTime_ValueChanged(sender,e);

        }

        private void dgvOther_CellValidating(object sender,DataGridViewCellValidatingEventArgs e) {
            if (this.dgvOther.Rows.Count > 0 && e.ColumnIndex == 1 && e.RowIndex >= 0) {
                if (e.FormattedValue.ToString() != "") {
                    if (!CheckNumber(e.FormattedValue.ToString())) {

                        App.Msg("������ĳ�����ʽ����");
                    }
                }
            }
        }

        /// <summary>
        /// ����Ԫ������༭ ���ж��������ֵ�Ƿ���ȷ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOther_CellEndEdit(object sender,DataGridViewCellEventArgs e) {
            //if (this.dgvOther.Rows.Count > 0 && e.ColumnIndex == 1 && e.RowIndex >= 0)
            //{
            //    if (dgvOther.Rows[e.RowIndex].Cells[1].Value != null)
            //    {

            //        if (!CheckNumber(this.dgvOther.Rows[e.RowIndex].Cells[1].Value.ToString()))
            //        {
            //            this.dgvOther.Rows[e.RowIndex].Cells[1].Value = "";
            //            App.Msg("ֻ��������ֵ����!");
            //            dgvOther.Focus();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// ��֤�Ƿ�Ϊ��������
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool CheckNumber(string number) {
            return Regex.IsMatch(number,@"^(\d*)([.]{0,1})(\d{0,5})$");
        }


        /// <summary>
        /// ��Ժ֮ǰ�����ݲ�������
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRoom() {
            
            if (!CompareTime(SelectTime,Convert.ToDateTime(this.inTime))) {
                TemperControlEnable(false,false,false,false,false,false);
                this.btnSave.Enabled = false;
                this.gbOtherInfo.Enabled = false;
            } else {
                this.gbOtherInfo.Enabled = true;
                this.btnSave.Enabled = true;
                if (rbNormal.Checked == true) {
                    if (txtNormalDefecate.Text == "") {
                        txtNormalDefecate.Text = "0";
                    }
                }
                DateTime dt = Convert.ToDateTime(Convert.ToDateTime(this.inTime));
                if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd")) 
                {//������Ժʱ��ε�ǰһ��ʱ���
                    if (dt.Hour >= 1 && dt.Hour < 5) {
                        TemperControlEnable(true,true,true,true,true,true);
                    } else if (dt.Hour >= 5 && dt.Hour < 9) {
                        TemperControlEnable(true, true, true, true, true, true);
                    } else if (dt.Hour >= 9 && dt.Hour < 13) {
                        TemperControlEnable(false, true, true, true, true, true);
                    } else if (dt.Hour >= 13 && dt.Hour < 17) {
                        TemperControlEnable(false, false, true, true, true, true);
                    } else if (dt.Hour >= 17 && dt.Hour < 21) {
                        TemperControlEnable(false, false, false, true, true, true);
                    } else {//21-1
                        TemperControlEnable(false, false, false, false, true, true);
                    }
                }
                else if (DateTime.Compare(Convert.ToDateTime(this.inTime), SelectTime) == 1)
                {
                    if (dt.Hour >= 1 && dt.Hour < 5)
                    {
                        TemperControlEnable(false, false, false, false, false, true);
                    }
                }
                else
                {
                    TemperControlEnable(true, true, true, true, true, true);
                }

            }
        }

        private void TemperControlEnable(bool _a,bool _b, bool _c, bool _d, bool _e, bool _f) {
            this.tw3am.Enabled = _a;
            this.tw7am.Enabled = _b;
            this.tw11am.Enabled = _c;
            this.tw3pm.Enabled = _d;
            this.tw7pm.Enabled = _e;
            this.tw11pm.Enabled = _f;
        }

        /// <summary>
        /// �ж�һ��ʱ���Ƿ���ڵ�����һ��ʱ��
        /// </summary>
        /// <param name="ts1"></param>
        /// <param name="ts2"></param>
        /// <returns></returns>
        public bool CompareTime(DateTime ts1,DateTime ts2) {
            if (ts1.ToString("yyyy-MM-dd") == ts2.ToString("yyyy-MM-dd")) {
                return true;
            }
            

            if (DateTime.Compare(ts1,ts2) > 0) {
                return true;
            }
            else if (DateTime.Compare(ts2, ts1)==1)
            {
                if (ts2.Hour >= 1 && ts2.Hour < 5)
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



        //private void rbEnema_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbEnema.Checked == true)
        //    {
        //        txtEnemaCount.Enabled = true;
        //        txtEnemaDefecate.Enabled = true;
        //    }
        //    else
        //    {
        //        txtEnemaCount.Text = "";
        //        txtEnemaDefecate.Text = "";
        //        txtEnemaCount.Enabled = false;
        //        txtEnemaDefecate.Enabled = false;
        //    }
        //}

        //private void rbNormal_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbNormal.Checked == true)
        //    {
        //        txtNormalDefecate.Enabled = true;
        //        //txtEnemaCount.Enabled = false;
        //        //txtEnemaDefecate.Enabled = false;
        //    }
        //    else
        //    {
        //        txtNormalDefecate.Text = "";
        //        txtNormalDefecate.Enabled = false;
        //    }
        //}

        private void rbWeightOk_CheckedChanged(object sender,EventArgs e) {
            if (rbWeightOk.Checked == true) {
                txtWeight.Enabled = true;
            } else {
                txtWeight.Text = "";
                txtWeight.Enabled = false;

            }
        }

        private void rbBloodOne_CheckedChanged(object sender,EventArgs e) {
            if (rbBloodOne.Checked == true) {
                txtBloodOne1.Enabled = true;
                txtBloodOne2.Enabled = true;
            } else {
                txtBloodOne1.Text = "";
                txtBloodOne2.Text = "";
                txtBloodOne1.Enabled = false;
                txtBloodOne2.Enabled = false;
            }
        }

        private void rbBloodTwo_CheckedChanged(object sender,EventArgs e) {
            if (rbBloodTwo.Checked == true) {
                txtBloodTwo1.Enabled = true;
                txtBloodTwo2.Enabled = true;
            } else {
                txtBloodTwo1.Text = "";
                txtBloodTwo2.Text = "";
                txtBloodTwo1.Enabled = false;
                txtBloodTwo2.Enabled = false;
            }
        }
        #region /*���*/
        private void txtNormalDefecate_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtNormalDefecate") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtEnemaCount_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtEnemaCount") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtEnemaDefecate_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtEnemaDefecate" || textBox.Name == "txtEnemaBeforeDefecate") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }
        #endregion
        #region  /*Ѫѹ*/
        private void txtBloodOne1_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodOne1") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtBloodOne2_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodOne2") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtBloodTwo1_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodTwo1") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtBloodTwo2_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodTwo2") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }
        #endregion
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWeight_TextChanged(object sender,EventArgs e) {

        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeight_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtHeight") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCatheterization_TextChanged(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtCatheterization") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThe_TextChanged_1(object sender,EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtThe") {
                if (textBox.Text == ".") {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtOut_TextChanged(object sender,EventArgs e) {
            if (this.txtOut.Text == ".") {
                this.txtOut.Text = "";
                return;
            }
        }

        private void rbNormal_Click_1(object sender,EventArgs e) {
            setIsTrurFalse(((RadioButton)sender).Name);
        }

        private void rbRengonggangchang_Click(object sender,EventArgs e) {
            setIsTrurFalse(((RadioButton)sender).Name);
        }

        private void dgvResult_CellDoubleClick(object sender,DataGridViewCellEventArgs e) {
            if(e.ColumnIndex == 0){
                
            }

        }

        private void txtSPO2_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSPO2.Text == ".")
            {
                this.txtSPO2.Text = "";
                return;
            }
        }

        private void gbOtherInfo_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxLength_KeyDown(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string txtBox=textBox.Text;
            int nLength = 0;
            for (int i = 0; i < txtBox.Length; i++)
            {
                if (txtBox[i] >= 0x3000 && txtBox[i] <= 0x9FFF)
                    nLength += 2;
                else
                    nLength++;
            }
            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Enter)
            {
                label23.Visible = false;
                e.Handled = false;
                return;
            }
            
            if (nLength >= textBox.MaxLength)
            {
                label23.Visible = true;
                e.Handled = true;
                return;
            }
            else
            {
                label23.Visible = false;
                e.Handled = false;
                return;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
       

    }
}

