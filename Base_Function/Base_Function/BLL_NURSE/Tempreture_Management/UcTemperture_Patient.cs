using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    public partial class UcTemperture_Patient : UserControl
    {
        bool isSave = false;                 //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string Patient_sql = "";    //��ѯ������
        private List<DataTable> lists;
        List<Class_T_CHILD_VITAL_SIGNS> list = new List<Class_T_CHILD_VITAL_SIGNS>();
        private DateTime SelectTime;
        private string inTime;//��������
        private string child_ID;//Ӥ�����
        private string child_name;//Ӥ������
        private string sex;//Ӥ���Ա�
        private string mother_bed;//ĸ�״���
        private string bcg_date;//��������ʱ��
        private string bcg_count;//������������
        private string hepatitis_b_vaccine_date;//�Ҹ��������ʱ��
        private string hepatitis_b_vaccine_count;//�Ҹ���������

        private string pid;//ĸ��סԺ��

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }


        public UcTemperture_Patient()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ���س�ʼֵ 
        /// </summary>
        /// <param name="pid">����סԺ��</param>
        public UcTemperture_Patient(string pid)
        {
            try

            {
                InitializeComponent();
                this.Pid = pid;
                Patient_sql = @"select n.ID as Ӥ�����,NEWBORN_NAME as ����������,n.PID as ĸ�׵�סԺ��,t.sick_bed_no as ����," +
                  @"to_char(n.BIRTHDAY,'yyyy-MM-dd  HH24:mi') as ��������,SEX as �Ա�,NEWBORN_WEIGHT as ����,to_char(BCG_DATE,'yyyy-MM-dd HH24:mi') as ���������ʱ��," +
                  @"BCG_BATCHNO as ����������,to_char(HEPATITIS_B_VACCINE_DATE,'yyyy-MM-dd HH24:mi') as �Ҹ��������ʱ��," +
                  @"HEPATITIS_B_VACCINE_NUM as �Ҹ��������� from t_new_born_patient n inner join t_in_patient t on t.pid=n.pid  where n.PID='" + Pid + "' order by n.ID desc";
            }
            catch
            {
                
            }
        }
        /// <summary>
        /// ���س�ʼֵ 
        /// </summary>
        /// <param name="pid">����סԺ��</param>
        public UcTemperture_Patient(string pid,string childID)
        {
            try
            {
                InitializeComponent();
                this.Pid = pid;
                Patient_sql = @"select n.ID as Ӥ�����,NEWBORN_NAME as ����������,n.PID as ĸ�׵�סԺ��,t.sick_bed_no as ����," +
                  @"to_char(n.BIRTHDAY,'yyyy-MM-dd  HH24:mi') as ��������,SEX as �Ա�,NEWBORN_WEIGHT as ����,to_char(BCG_DATE,'yyyy-MM-dd HH24:mi') as ���������ʱ��," +
                  @"BCG_BATCHNO as ����������,to_char(HEPATITIS_B_VACCINE_DATE,'yyyy-MM-dd HH24:mi') as �Ҹ��������ʱ��," +
                  @"HEPATITIS_B_VACCINE_NUM as �Ҹ��������� from t_new_born_patient n inner join t_in_patient t on t.pid=n.pid  where n.PID='" + Pid + "' and n.ID='" + childID + "' order by n.ID desc";
            }
            catch
            {

            }
        }
        /// <summary>
        /// ����ĸ�׵�Pid��ѯ������
        /// </summary>
        private void Child_Patient()
        {
            try
            {
                string sql = Patient_sql ;
                DataSet ds = App.GetDataSet(sql);
                c1FlexGrid1.DataSource = ds.Tables[0].DefaultView;
                //c1FlexGrid1.DataSource(sql, "Ӥ�����", "Ӥ�����,����������,ĸ�׵�סԺ��,����,��������,�Ա�,����,���������ʱ��,����������,�Ҹ��������ʱ��,�Ҹ���������", "Ӥ�����,����������,ĸ�׵�סԺ��,����,��������,�Ա�,����,���������ʱ��,����������,�Ҹ��������ʱ��,�Ҹ���������");
                c1FlexGrid1.AllowEditing = false;
            }
            catch
            {
            }
        }
        /// <summary>
        /// �����ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcTemperture_Patient_Load(object sender, EventArgs e)
        {
            try
            {
                Child_Patient();
                cboColour.SelectedIndex = 0;
                cboFunicle.SelectedIndex=0;
                this.tw2am.IsHowTime = 2;
                this.tw6am.IsHowTime = 6;
                this.tw10am.IsHowTime = 10;
                this.tw2pm.IsHowTime = 14;
                this.tw6pm.IsHowTime = 18;
                this.tw10pm.IsHowTime = 22;
                SelectTime = Convert.ToDateTime(this.dtpTime.Value.ToString("yyyy-MM-dd"));    //���ڿؼ�ʱ��
                setTimeNextLast();
                inRoom();
                ClearInfo();
                txtColor_other.Enabled = false;
                //c1FlexGrid1.Click += new EventHandler(ucC1FlexGrid1_Click);
            }
            catch
            { }

        }
        /// <summary>
        /// ��ѯʱ����һ����һ��
        /// </summary>
        public void setTimeNextLast()
        {
            // ��һ��  
            this.lkbStarttime.Text = this.dtpTime.Value.AddDays(-1).ToString("<< yyyy-MM-dd");

            //��һ��
            this.lkbEndtime.Text = this.dtpTime.Value.AddDays(1).ToString("yyyy-MM-dd >>");

        }
        /// <summary>
        /// ��������֮ǰ�����ݲ�������
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRoom()
        {

            if (!CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
            {
                TemperControlEnable(false, false, false, false, false, false);
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                //this.chkBreast_milk.Enabled = false;
                //this.chkCattle_milk.Enabled = false;
                cboFood.Enabled = false;
                txtCount.Enabled = false;
                cboFunicle.Enabled = false;
                panel1.Enabled = false;
                this.rdtnHave.Enabled = false;
                this.rdtnNothing.Enabled = false;
                this.txtNumberTimes.Enabled = false;
                this.cboColour.Enabled = false;
                this.cboFunicle.Enabled = false;
                this.txtWeight.Enabled = false;
                this.btnPreserve.Enabled = true;
                //App.Msg("��������֮ǰ�����ݲ������룡");
            }
            else
            {
                isSave = false;
                Edit(isSave);
                DateTime dt = Convert.ToDateTime(Convert.ToDateTime(this.inTime));
                if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd"))
                {
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
        /// �ж�һ��ʱ���Ƿ���ڵ�����һ��ʱ��
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
            else
            {
                return false;
            }
        }
        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel > 0)
            {
                ClearInfo();
                child_ID = c1FlexGrid1[c1FlexGrid1.RowSel, "Ӥ�����"].ToString();
                lblID.Text = child_ID;
                lblname.Text = c1FlexGrid1[c1FlexGrid1.RowSel, "����������"].ToString();
                child_name = lblname.Text;
                sex = c1FlexGrid1[c1FlexGrid1.RowSel, "�Ա�"].ToString();
                mother_bed = c1FlexGrid1[c1FlexGrid1.RowSel, "����"].ToString();
                lblTime.Text = c1FlexGrid1[c1FlexGrid1.RowSel, "���������ʱ��"].ToString();
                bcg_date = lblTime.Text;
                lblCount.Text = c1FlexGrid1[c1FlexGrid1.RowSel, "����������"].ToString();
                bcg_count = lblCount.Text;
                lblTimes.Text = c1FlexGrid1[c1FlexGrid1.RowSel, "�Ҹ��������ʱ��"].ToString();
                hepatitis_b_vaccine_date = lblTimes.Text;
                lblCounts.Text = c1FlexGrid1[c1FlexGrid1.RowSel, "�Ҹ���������"].ToString();
                hepatitis_b_vaccine_count = lblCounts.Text;
                inTime = c1FlexGrid1[c1FlexGrid1.RowSel, "��������"].ToString();
                txtWeight.Text = c1FlexGrid1[c1FlexGrid1.RowSel, "����"].ToString();
                TimeSpan sp = new TimeSpan();
                DateTime Nowtime = Convert.ToDateTime(App.GetSystemTime().ToShortDateString());
                sp = Nowtime - Convert.ToDateTime(inTime);
                lblDay.Text = sp.Days.ToString();
                if (child_ID != "")
                {
                    string time = SelectTime.ToString("yyyy-MM-dd");
                    if (!DBClass.SelectGreaterZero(time, this.child_ID)) //�ж��Ƿ��н��������
                    {
                        lists = DBClass.GetTemper(time, child_ID);       //��ȡ��������
                        LoadAll(lists);                               //���ص�ҳ����
                        lists.Clear();                                //���Lists
                    }
                }
            }
        }
        /// <summary>
        /// ���ؽ��ձ�����Ϣ
        /// </summary>
        /// <param name="lists"></param>
        public void LoadAll(List<DataTable> lists)
        {
            DataTable dt1 = lists[0];
            DataTable dt2 = lists[1];

            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int hour = Convert.ToInt32(Convert.ToDateTime(dt1.Rows[i]["MEASURE_TIME"]).ToString("HH"));
                    switch (hour)
                    {
                        case 2:
                            this.tw2am.setTempers(dt1.Rows[i]);
                            break;
                        case 6:
                            this.tw6am.setTempers(dt1.Rows[i]);
                            break;
                        case 10:
                            this.tw10am.setTempers(dt1.Rows[i]);
                            break;
                        case 14:
                            this.tw2pm.setTempers(dt1.Rows[i]);
                            break;
                        case 18:
                            this.tw6pm.setTempers(dt1.Rows[i]);
                            break;
                        case 22:
                            this.tw10pm.setTempers(dt1.Rows[i]);
                            break;
                    }
                }
            }
            //-------------------------------------------------------------------------------

            #region ������Ϣ

            if (dt2.Rows.Count > 0)
            {
                //ι����ʽ
                cboFood.Text = dt2.Rows[0]["FEED_STYLE"].ToString();
                //if (dt2.Rows[0]["FEED_STYLE"].ToString() == "M")
                //{
                //    this.chkBreast_milk.Checked = true;
                //}
                //else if (dt2.Rows[0]["FEED_STYLE"].ToString() == "N")
                //{
                //    this.chkCattle_milk.Checked = true;
                //}
                //else if (dt2.Rows[0]["FEED_STYLE"].ToString() == "A")
                //{
                //    this.chkBreast_milk.Checked = true;
                //    this.chkCattle_milk.Checked = true;
                //}
                //����
                //if (dt2.Rows[0]["ICTERUS"].ToString() == "Y")
                //{
                //    rdtnHave.Checked = true;
                //}
                //else
                //{
                //    rdtnNothing.Checked = true;
                //}
                //������
                if (dt2.Rows[0]["STOOL_COUNT"].ToString() != "" && dt2.Rows[0]["STOOL_COUNT"].ToString() != "0")
                {
                    this.txtNumberTimes.Text = dt2.Rows[0]["STOOL_COUNT"].ToString();
                }
                //��ɫ
                if (dt2.Rows[0]["STOOL_COLOR"].ToString() != "")
                {
                    this.cboColour.Text =dt2.Rows[0]["STOOL_COLOR"].ToString();
                }
                if (this.cboColour.Text == "����")
                {
                    txtColor_other.Text = dt2.Rows[0]["NUTRUE_OTHERNAME"].ToString();
                    txtColor_other.Visible = true;
                }
                else
                {
                    txtColor_other.Visible = false;
                }
                //����
                txtWeight.Text = dt2.Rows[0]["WEIGHT"].ToString();
                //���
                if (dt2.Rows[0]["UMBILICALCORD"].ToString() != "")
                {
                    cboFunicle.Text = dt2.Rows[0]["UMBILICALCORD"].ToString();
                }
                //��ɫ
                if (dt2.Rows[0]["COLOUR_FACE"].ToString() != "")
                {
                    cboColor_Face.Text = dt2.Rows[0]["COLOUR_FACE"].ToString();
                }
                //����
                if (dt2.Rows[0]["BREATHE"].ToString() != "")
                {
                    cboBreathe.Text = dt2.Rows[0]["BREATHE"].ToString();
                }
                //����
                if (dt2.Rows[0]["CRY"].ToString() != "")
                {
                    cboCry.Text = dt2.Rows[0]["CRY"].ToString();
                }
                //��Ӧ
                if (dt2.Rows[0]["REACTION"].ToString() != "")
                {
                    cboReaction.Text = dt2.Rows[0]["REACTION"].ToString();
                }
                //��
                if (dt2.Rows[0]["DIAPER"].ToString() != "")
                {
                    txtCount.Text = dt2.Rows[0]["DIAPER"].ToString();
                }
            }
            #endregion
        }
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <returns></returns>
        public bool Excute()
        {
            list.Add(this.tw2am.GetTempers(this.child_ID, SelectTime.ToString("yyyy-MM-dd 02:00")));
            list.Add(this.tw6am.GetTempers(this.child_ID, SelectTime.ToString("yyyy-MM-dd 06:00")));
            list.Add(this.tw10am.GetTempers(this.child_ID, SelectTime.ToString("yyyy-MM-dd 10:00")));
            list.Add(this.tw2pm.GetTempers(this.child_ID, SelectTime.ToString("yyyy-MM-dd  14:00")));
            list.Add(this.tw6pm.GetTempers(this.child_ID, SelectTime.ToString("yyyy-MM-dd  18:00")));
            list.Add(this.tw10pm.GetTempers(this.child_ID, SelectTime.ToString("yyyy-MM-dd 22:00")));
            return DBClass.InsertTempers(list, ExcuteTemperOther());
        }
        /// <summary>
        /// ��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public Class_T_CHILD_TEMPERATURE_INFO ExcuteTemperOther()
        {
            Class_T_CHILD_TEMPERATURE_INFO tti = new Class_T_CHILD_TEMPERATURE_INFO();

            //Ӥ�����
            tti.Child_id = this.child_ID;
            //��ʳ
            //if (cboFood.Text == "--��ѡ��--")
            //{
            //    cboFood.Text = "";
            //}
            tti.Feed_style = cboFood.Text;
            //����Y--�� ��--N
            string Mark = "";
            //if (!rdtnHave.Checked)
            //{
            //    Mark = "N";
            //}
            tti.Icterus = Mark;
            tti.Stool_count = txtNumberTimes.Text;
            //�������
            //if (cboColour.Text == "--��ѡ��--")
            //{
            //    cboColour.Text = "";
            //}
            tti.Stool_color = cboColour.Text;
            tti.Nature_0ther = txtColor_other.Text;

            //���
            //if (cboFunicle.Text == "--��ѡ��--")
            //{
            //    cboFunicle.Text = "";
            //}
            tti.Umbilicalcord = cboFunicle.Text;
            tti.Weight = txtWeight.Text;

            //ʱ��
            tti.Record_time = SelectTime.ToString("yyyy-MM-dd ");
            //��ɫ
            //if (cboColor_Face.Text == "--��ѡ��--")
            //{
            //    cboColor_Face.Text = "";
            //}
            tti.Color_face = cboColor_Face.Text;
            //����
            //if (cboBreathe.Text == "--��ѡ��--")
            //{
            //    cboBreathe.Text = "";
            //}
            tti.Breathe = cboBreathe.Text;
            //����
            //if (cboCry.Text == "--��ѡ��--")
            //{
            //    cboCry.Text = "";
            //}
            tti.Cry = cboCry.Text;
            //��Ӧ
            //if (cboReaction.Text == "--��ѡ��--")
            //{
            //    cboReaction.Text = "";
            //}
            tti.Reaction = cboReaction.Text;
            tti.Diaper = txtCount.Text;

            return tti;
        }
        /// <summary>
        /// �ύ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!isSave)
            {
                    string time = SelectTime.ToString("yyyy-MM-dd");
                    DBClass.IsClear(time, this.child_ID); //����ʱ���������
                    if (Excute())                      //���²�������
                    {
                        App.Msg("���ݱ���ɹ�");
                        //btnCancel_Click(sender,e);
                        list.Clear();
                        //lblID.Text = "";
                        //lblname.Text = "";
                    }
                    else
                    {
                        App.Msg("���ݱ���ʧ��");
                        list.Clear();
                    }
            }

        }
        /// <summary>
        /// ά��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreserve_Click(object sender, EventArgs e)
        {

            if (lblID.Text != "")
            {
                string times = dtpTime.Value.ToString("yyyy-MM-dd");
                SelectTime = Convert.ToDateTime(times);
                if (!CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
                {
                    TemperControlEnable(false, false, false, false, false, false);
                    this.btnSave.Enabled = false;
                    this.btnCancel.Enabled = false;
                    //this.chkBreast_milk.Enabled = false;
                    //this.chkCattle_milk.Enabled = false;
                    cboFood.Enabled = false;
                    txtCount.Enabled = false;
                    cboFunicle.Enabled = false;
                    if (cboColour.Text == "����")
                    {
                        txtColor_other.Visible = true;
                        txtColor_other.Enabled = true;
                    }
                    else
                    {
                        txtColor_other.Visible = false;
                    }
                    panel1.Enabled = false;
                    this.rdtnHave.Enabled = false;
                    this.rdtnNothing.Enabled = false;
                    this.txtNumberTimes.Enabled = false;
                    this.cboColour.Enabled = false;
                    this.cboFunicle.Enabled = false;
                    this.txtWeight.Enabled = false;
                    this.btnPreserve.Enabled = true;
                    App.Msg("��������֮ǰ�����ݲ������룡");
                }
                else
                {
                    isSave = false;
                    Edit(isSave);
                    DateTime dt = Convert.ToDateTime(Convert.ToDateTime(this.inTime));
                    if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd"))
                    {
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
                        {
                            TemperControlEnable(false, false, false, false, false, true);
                        }
                    }
                    else
                    {
                        TemperControlEnable(true, true, true, true, true, true);
                    }
                }
                inRooms();
            }
            else
            {
                App.Msg("��ѡ��������!");
            }
        }
        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkbStarttime_Click(object sender, EventArgs e)
        {
            this.dtpTime.Value = this.dtpTime.Value.AddDays(-1);
            setTimeNextLast();
        }
        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkbEndtime_Click(object sender, EventArgs e)
        {
            this.dtpTime.Value = this.dtpTime.Value.AddDays(1);
            setTimeNextLast();
        }
        /// <summary>
        /// UserControl ��ԭ��ʼ
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
        /// <summary>
        /// ��ԭ������Ϣ
        /// </summary>
        private void ClearInfo()
        {
            ClearTempers();
            ClearOtherTemper();
        }
        //ˢ�´���
        private void ClearOtherTemper()
        {

            this.tw2am.Enabled = false;
            this.tw6am.Enabled = false;
            this.tw10am.Enabled = false;
            this.tw2pm.Enabled = false;
            this.tw6pm.Enabled = false;
            this.tw10pm.Enabled = false;
            this.txtNumberTimes.Text = "";
            this.txtWeight.Text = "";
            txtCount.Text = "";
            cboColour.SelectedIndex = 0;
            cboFood.Enabled = false;
            txtCount.Enabled = false;
            cboFunicle.Enabled = false;
            //cboFood.Text="";
            //cboFunicle.Text = "";
            //cboFunicle.Text = "";
            //cboColor_Face.Text = "";
            //cboBreathe.Text = "";
            //cboCry.Text = "";
            //cboReaction.Text = "";
            cboFood.SelectedIndex = 0;
            cboFunicle.SelectedIndex = 0;
            cboFunicle.SelectedIndex = 0;
            cboColor_Face.SelectedIndex = 0;
            cboBreathe.SelectedIndex = 0;
            cboCry.SelectedIndex = 0;
            cboReaction.SelectedIndex = 0;
            panel1.Enabled = false;
            if (cboColour.Text == "����")
            {
                txtColor_other.Visible = true;
                txtColor_other.Enabled = false;
            }
            else
            {
                txtColor_other.Visible = false;
                txtColor_other.Text = "";
            }
            this.rdtnHave.Enabled = false;
            this.rdtnNothing.Enabled = false;
            this.rdtnHave.Checked = false; 
            this.rdtnNothing.Checked = false;
            this.txtNumberTimes.Enabled = false;
            this.cboColour.Enabled = false;
            this.cboFunicle.Enabled = false;
            this.txtWeight.Enabled = false;
            this.btnPreserve.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;

        }
        /// <summary>
        /// �༭״̬
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            this.tw2am.Enabled = true;
            this.tw6am.Enabled = true;
            this.tw10am.Enabled = true;
            this.tw2pm.Enabled = true;
            this.tw6pm.Enabled = true;
            this.tw10pm.Enabled = true;
            if (flag)
            {
                cboFood.Text = "";
                cboFunicle.Text = "";
                cboFunicle.Text = "";
                cboColor_Face.Text = "";
                cboBreathe.Text = "";
                cboCry.Text = "";
                cboReaction.Text = "";
            }
            //this.chkBreast_milk.Enabled = true;
            //this.chkCattle_milk.Enabled = true;
            cboFood.Enabled = true;
            txtCount.Enabled = true;
            cboFunicle.Enabled = true;
            if (cboColour.Text == "����")
            {
                txtColor_other.Visible = true;
                txtColor_other.Enabled = true;
            }
            else
            {
                txtColor_other.Visible = false;
            }
            panel1.Enabled = true;
            this.rdtnHave.Enabled = true;
            this.rdtnNothing.Enabled = true;
            this.txtNumberTimes.Enabled = true;
            this.cboColour.Enabled = true;
            this.cboFunicle.Enabled = true;
            this.txtWeight.Enabled = true;
            this.btnPreserve.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
        }
       /// <summary>
       /// ʱ���ѯ
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ClearInfo();
                SelectTime = this.dtpTime.Value;
                inRoom();
                setTimeNextLast();
                if (CompareTime(Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), Convert.ToDateTime(this.inTime)))
                {
                    string dateTime = SelectTime.ToString("yyyy-MM-dd");

                    if (child_ID != "")
                    {
                        if (!DBClass.SelectGreaterZero(dateTime, this.child_ID))
                        {
                            lists = DBClass.GetTemper(dateTime, this.child_ID);
                            LoadAll(lists);
                            lists.Clear();
                        }
                    }
                }
                inRooms();
            }
            catch
            {
            }
        }
        /// <summary>
        /// ��Ժ������ݲ�������
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRooms()
        {
            string time = "";
            string sql = "select * from t_child_vital_signs where CHILD_ID=" + child_ID + "";
            DataSet dsp = App.GetDataSet(sql);
            if (dsp.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
                {
                    if (dsp.Tables[0].Rows[i]["DESCRIBE"].ToString().Contains("��Ժ"))
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
                    DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(time).ToShortDateString());
                    if (Convert.ToDateTime(SelectTime.ToShortDateString()) > dt1)
                    {
                        TemperControlEnable(false, false, false, false, false, false);
                        this.btnSave.Enabled = false;
                        this.btnCancel.Enabled = false;
                        cboFood.Enabled = false;
                        txtCount.Enabled = false;
                        cboFunicle.Enabled = false;
                        panel1.Enabled = false;
                        this.rdtnHave.Enabled = false;
                        this.rdtnNothing.Enabled = false;
                        this.txtNumberTimes.Enabled = false;
                        this.cboColour.Enabled = false;
                        this.cboFunicle.Enabled = false;
                        this.txtWeight.Enabled = false;
                        this.btnPreserve.Enabled = true;
                        App.Msg("�ѳ�Ժ��������д����");
                    }
                    else if (Convert.ToDateTime(SelectTime.ToShortDateString()) < dt1)
                    {
                        TemperControlEnable(true, true, true, true, true, true);
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
        public bool CompareTimes(DateTime ts1, DateTime ts2)
        {
            if (ts1.ToString("yyyy-MM-dd") == ts2.ToString("yyyy-MM-dd"))
            {
                return true;
            }

            if (DateTime.Compare(ts1, ts2) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void rdtnHave_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnHave.Checked == true)
            {
                rdtnNothing.Checked = false;
            }
        }

        private void rdtnNothing_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnNothing.Checked == true)
            {
                rdtnHave.Checked = false;
            }
        }
        /// <summary>
        /// ��ӡ���µ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanint_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "")
            {
                //string PID = GetSelectItemId(child_ID);
                //frmTemperPrint fp = new frmTemperPrint(child_name, mother_bed, sex, inTime, Pid, child_ID, bcg_date, bcg_count, hepatitis_b_vaccine_date, hepatitis_b_vaccine_count);
                //fp.ShowDialog();
            }
            else
            {
                App.Msg("��ѡ����������");
            }
        }
        private string GetSelectItemId(string pid)
        {
            string Sql = "select PID from T_IN_PATIENT  where ID ='" + pid + "'";
            string ID = App.ReadSqlVal(Sql, 0, "PID");
            return ID;
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInfo();
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
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumberTimes_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtNumberTimes")
            {
                if (textBox.Text == ".")
                {
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
        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtWeight")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }
        /// <summary>
        /// �����ж�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboColour.Text == "����")
            {
                txtColor_other.Visible = true;
            }
            else
            {
                txtColor_other.Visible = false;
            }
        }


    
    }
}
