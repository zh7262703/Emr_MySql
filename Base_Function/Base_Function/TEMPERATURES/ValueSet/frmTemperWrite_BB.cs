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
    /// ����ģ������ֵ¼��
    /// ���� ���Ż�
    /// ʱ�䣺2013-05-21
    /// </summary>
    public partial class frmTemperWrite_BB : DevComponents.DotNetBar.Office2007Form
    {
        string startDate = "";
        string endDate = "";

        public string dtpTimes_date = "";
        private int isHowTime = 0;
        private bool isOkNow = true;
        //this.cbEvent = new comboNoWheel();     


        private string pid;//���˱��                  
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
        private string Erm = "";//log��¼��Ϣ
        private string pageindex = string.Empty;
        /// <summary>
        /// txtEmptyItemName1�Ƿ���޸�
        /// </summary>
        private bool emptyedited1 = false;

        /// <summary>
        /// txtEmptyItemName2�Ƿ���޸�
        /// </summary>
        private bool emptyedited2 = false;

        private List<DataTable> lists;
        List<Class_T_CHILD_VITAL_SIGNS> list = new List<Class_T_CHILD_VITAL_SIGNS>();

        private bool IsFirst = true;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="starttime">��ʼʱ��</param>
        /// <param name="endtime">����ʱ��</param>
        /// <param name="patient_id">��������</param>
        /// <param name="patient_id">����</param>
        public frmTemperWrite_BB(string starttime, string endtime, string Pid, string patient_i, string bedno, DateTime SelectDate)
        {
            InitializeComponent();

            bed_no = bedno;
            pid_ids = patient_i;
            pid = Pid;
            startDate = starttime;
            endDate = endtime;
            GetPageIndex();
            this.lblNotice.Text = "ע�������ǰʱ��㷶ΧΪ" + starttime + "   ��   " + endtime;
            //App.FormStytleSet(this, false);
            if (SelectDate == null)
            {
                dateTimePicker_Select.Value = Convert.ToDateTime(starttime);
            }
            else
            {
                dateTimePicker_Select.Value = SelectDate;
            }
            IsFirst = false;
        }

        private void GetPageIndex()
        {
            DateTime intime = Convert.ToDateTime(App.ReadSqlVal("select in_time from t_BB_patient  where id='" + pid_ids + "'", 0, "in_time")).Date;
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
            if (dateTimePicker_Select.Value.Date > Convert.ToDateTime(endDate) ||
           dateTimePicker_Select.Value.Date < Convert.ToDateTime(startDate))
            {
                App.MsgWaring("ѡ���ʱ�䲻��ȷ����ѡ�������ʱ��η�Χ֮�ڵ�ʱ�䣡");
                return;
            }


            string time = SelectTime.ToString("yyyy-MM-dd");
            DBControl.IsClear_ChildTemperasure(time, this.pid_ids); //����ʱ���������
            string title = string.Format("��ѯʱ��[{0}]-��������[{1}]-���˱��[{2}]-��������[{3}]-����[{4}]-����[{5}]-", time, pid_ids, pid, userName, bed_no, section);
            if (Excute() && DBControl.InsertTempers_Others(ExcuteTemperOther()))                      //���²�������Remove
            {
                if (Erm != "")
                {
                    DBControl.ErrorLog("���µ�����ɹ�: �����û�:" + App.UserAccount.UserInfo.User_name, title + Erm);
                }
                App.Msg("���ݱ���ɹ�");
                list.Clear();
            }
            else
            {
                if (Erm != "")
                {
                    DBControl.ErrorLog("���µ�����ʧ��: �����û�:" + App.UserAccount.UserInfo.User_name, title + Erm);
                }
                App.Msg("���ݱ���ʧ��");
                list.Clear();
            }

            ////����ҳü��Ϣ
            //if (this.txtBedNo.Text.Trim().Length > 0)
            //{
            //    string bedno = this.txtBedNo.Text.Trim();
            //    string diagnose = string.Empty;
            //    string diagnosecount = string.Empty;
            //    List<string> HeadInfo = new List<string>();
            //    string sql = string.Empty;
            //    sql = "delete from t_temperature_pageinfo a where a.patient_id='" + this.pid_ids + "' and pageindex='" + pageindex + "'";
            //    HeadInfo.Add(sql);
            //    sql = " insert into t_temperature_pageinfo(id,pageindex,bedno,diagnose,diagnose_count,patient_id)values('" + App.GenId().ToString() + "','" + pageindex + "','" + bedno + "','" + diagnose + "','" + diagnosecount + "','" + pid_ids + "')";
            //    HeadInfo.Add(sql);
            //    int count = 0;
            //    App.ExecuteBatch(HeadInfo.ToArray());
            //}
            this.Close();
        }

        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <returns></returns>
        public bool Excute()
        {
            list.Add(this.tw3am.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd 02:00"), this.pid_ids));
            list.Add(this.tw7am.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd 06:00"), this.pid_ids));
            list.Add(this.tw11am.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd 10:00"), this.pid_ids));
            list.Add(this.tw3pm.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd 14:00"), this.pid_ids));
            list.Add(this.tw7pm.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd 18:00"), this.pid_ids));
            list.Add(this.tw11pm.GetTempers(this.pid, this.bed_no, SelectTime.ToString("yyyy-MM-dd 22:00"), this.pid_ids));
            return DBControl.InsertTempers(list);
        }


        private void TemperControlEnable(bool _a, bool _b, bool _c, bool _d, bool _e, bool _f)
        {
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
        /// ��Ժ֮ǰ�����ݲ�������
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRoom()
        {

            if (!CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
            {
                TemperControlEnable(false, false, false, false, false, false);
                this.btnSure.Enabled = false;
            }
            else
            {
                this.btnSure.Enabled = true;
                DateTime dt = Convert.ToDateTime(Convert.ToDateTime(this.inTime));
                if (SelectTime.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd"))
                {//������Ժʱ��ε�ǰһ��ʱ���
                    if (dt.Hour >= 0 && dt.Hour < 4)
                    {
                        TemperControlEnable(true, true, true, true, true, true);
                    }
                    else if (dt.Hour >= 4 && dt.Hour < 8)
                    {
                        TemperControlEnable(true, true, true, true, true, true);
                    }
                    else if (dt.Hour >= 8 && dt.Hour < 12)
                    {
                        TemperControlEnable(false, true, true, true, true, true);
                    }
                    else if (dt.Hour >= 12 && dt.Hour < 16)
                    {
                        TemperControlEnable(false, false, true, true, true, true);
                    }
                    else if (dt.Hour >= 16 && dt.Hour < 20)
                    {
                        TemperControlEnable(false, false, false, true, true, true);
                    }
                    else
                    {//21-1
                        TemperControlEnable(false, false, false, false, true, true);
                    }
                }
                else if (DateTime.Compare(Convert.ToDateTime(this.inTime), SelectTime) == 1)
                {
                    if (dt.Hour >= 0 && dt.Hour < 4)
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

        /// <summary>
        /// ��Ժ������ݲ�������
        /// </summary>
        /// <param name="inRoomTime"></param>
        public void inRooms()
        {
            string time = "";
            string sql = "select * from t_vital_signs where PATIENT_ID=" + pid_ids + "";
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


        //private void LoadEmptyRowInfo()
        //{
        //    string count = string.Empty;
        //    count = App.ReadSqlVal("select count(*) from t_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_value1 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "'", 0, "count(*)");
        //    if (count == "0")
        //    {
        //        emptyedited1 = true;
        //    }
        //    else
        //    {
        //        emptyedited1 = false;
        //    }
        //    count = string.Empty;
        //    count = App.ReadSqlVal("select count(*) from t_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_value2 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "'", 0, "count(*)");
        //    if (count == "0")
        //    {
        //        emptyedited2 = true;
        //    }
        //    else
        //    {
        //        emptyedited2 = false;
        //    }
        //    //txtEmptyItemName1.Enabled = emptyedited1;
        //    //txtEmptyItemName2.Enabled = emptyedited2;
        //    //if (txtEmptyItemName1.Text == "" && txtEmptyItemName1.Enabled == false)
        //    //{
        //    //    txtEmptyItemName1.Text = App.ReadSqlVal("select empty_name1 from t_child_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_name1 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "' order by a.record_time asc", 0, "empty_name1");
        //    //}
        //    //if (txtEmptyItemName2.Text == "" && txtEmptyItemName2.Enabled == false)
        //    //{
        //    //    txtEmptyItemName2.Text = App.ReadSqlVal("select empty_name2 from t_child_temperature_info a where  a.patient_id=" + pid_ids + " and a.empty_name2 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + "' order by a.record_time asc", 0, "empty_name2");
        //    //}
        //}

        //void LoadPageInfo()
        //{
        //    string sql = " select a.id,a.pageindex,a.bedno,a.diagnose,a.diagnose_count,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + this.pid_ids + "' and a.pageindex='" + this.pageindex + "'";

        //    DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
        //    if (pageheadtable.Rows.Count > 0)
        //    {
        //        //this.txtBedNo.Text = pageheadtable.Rows[0]["bedno"].ToString();
        //        //this.Diagnose = pageheadtable.Rows[0]["diagnose"].ToString();
        //        //this.DiagnoseCount = pageheadtable.Rows[0]["diagnose_count"].ToString();
        //    }
        //    else
        //    {
        //        this.txtBedNo.Text = this.bed_no;
        //    }
        //    //if (DiagnoseCount.Length > 0)
        //    //{
        //    //    this.txtDiagnose.Text = Diagnose;
        //    //}
        //    //else
        //    //{
        //    //    Diagnose = TemperatureMethod.GetDiagnose(this.pid_ids);
        //    //    this.txtDiagnose.Text = Diagnose;
        //    //}
        //}

        /// <summary>
        /// ���ؽ��ձ�����Ϣ
        /// </summary>
        /// <param name="lists"></param>
        public void LoadAll(List<DataTable> lists)
        {
            DataTable dt1 = lists[0];

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
                            this.tw3am.setTempers(dt1.Rows[i], hour.ToString());
                            break;
                        case 6:
                            this.tw7am.setTempers(dt1.Rows[i], hour.ToString());
                            break;
                        case 10:
                            this.tw11am.setTempers(dt1.Rows[i], hour.ToString());
                            break;
                        case 14:
                            this.tw3pm.setTempers(dt1.Rows[i], hour.ToString());
                            break;
                        case 18:
                            this.tw7pm.setTempers(dt1.Rows[i], hour.ToString());
                            break;
                        case 22:
                            this.tw11pm.setTempers(dt1.Rows[i], hour.ToString());
                            break;
                    }
                }
            }

            DataTable dt2 = lists[1];
            #region ������Ϣ

            if (dt2.Rows.Count > 0)
            {
                //������
                if (dt2.Rows[0]["stool_count"].ToString() != "")
                {
                    txtDBCS.Text = dt2.Rows[0]["stool_count"].ToString();
                }
                //�����ɫ
                if (dt2.Rows[0]["stool_color"].ToString() != "")
                {
                    txtDBXZ.Text = dt2.Rows[0]["stool_color"].ToString();
                }
                //С��
                if (dt2.Rows[0]["xb"].ToString() != "")
                {
                    txtXB.Text = dt2.Rows[0]["xb"].ToString();
                }
                //����
                if (dt2.Rows[0]["weight"].ToString().Length > 0)
                {
                    txtTZ.Text = dt2.Rows[0]["weight"].ToString();
                }
                //����
                if (dt2.Rows[0]["feed_style"].ToString().Length > 0)
                {
                    cboBR.Text = dt2.Rows[0]["feed_style"].ToString();
                }
                //���
                if (dt2.Rows[0]["Umbilicalcord"].ToString().Length > 0)
                {
                    txtQD.Text = dt2.Rows[0]["Umbilicalcord"].ToString();
                }
                //һ�����
                if (dt2.Rows[0]["ybqk"].ToString().Length > 0)
                {
                    txtYBQK.Text = dt2.Rows[0]["ybqk"].ToString();
                }
                //ǩ��
                if (dt2.Rows[0]["qm"].ToString().Length > 0)
                {
                    txtQM.Text = dt2.Rows[0]["qm"].ToString();
                }
            }
            #endregion
            //------------------------------------------------------------------------------- 

            //LoadPageInfo();
        }


        private void ClearOtherInfo()
        {
            //this.cmbShit.Text = "";
            //this.cmbUrine.Text = "";
            //this.cmbWeight.Text = "";
            //this.cmbBp.Text = "";
            //this.cmbBp2.Text = "";
            //this.txtIn.Text = "";
            //this.txtOut.Text = "";
            //this.txtDragInfact.Text = "";
            //this.txtEmptyItemName1.Text = "";
            //this.txtEmptyItemName1.Enabled = false;
            //this.txtEmptyItemName2.Text = "";
            //this.txtEmptyItemName2.Enabled = false;
            //this.txtEmptyItemValue1.Text = "";
            //this.txtEmptyItemValue2.Text = "";
        }

        /// <summary>
        /// ��ԭ������Ϣ
        /// </summary>
        private void ClearInfo()
        {
            ClearTempers();
            ClearOtherInfo();
        }

        /// <summary>
        /// UserControl ��ԭ��ʼ
        /// </summary>
        private void ClearTempers()
        {
            this.tw3am.Clear();
            this.tw7am.Clear();
            this.tw11am.Clear();
            this.tw3pm.Clear();
            this.tw7pm.Clear();
            this.tw11pm.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker_Select_ValueChanged(object sender, EventArgs e)
        {
            //��ȡ��ǰʱ��
            SelectTime = this.dateTimePicker_Select.Value;
            //lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToString("yyyy-MM-dd") + "<<";
            //lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToString("yyyy-MM-dd");
            GetPageIndex();
            inRoom();
            if (!IsFirst)
            {
                ClearInfo();
            }
            if (CompareTime(SelectTime, Convert.ToDateTime(this.inTime)))
            {
                string dateTime = SelectTime.ToString("yyyy-MM-dd");

                if (!DBControl.ChildTemperatureCurDayHaveData(dateTime, this.pid_ids))
                {
                    lists = DBControl.GetChildTemper(dateTime, this.pid_ids);
                    LoadAll(lists);
                    lists.Clear();
                }
            }
            //LoadEmptyRowInfo();
            inRooms();
            this.tw3am.IsHowTime = 2;//2��
            this.tw3am.CurDateTime = SelectTime.Date;
            this.tw7am.IsHowTime = 6;//6��
            this.tw7am.CurDateTime = SelectTime.Date;
            this.tw11am.IsHowTime = 10;//10��
            this.tw11am.CurDateTime = SelectTime.Date;
            this.tw3pm.IsHowTime = 14;//����14��
            this.tw3pm.CurDateTime = SelectTime.Date;
            this.tw7pm.IsHowTime = 18;//����18��
            this.tw7pm.CurDateTime = SelectTime.Date;
            this.tw11pm.IsHowTime = 22;//����22��
            this.tw11pm.CurDateTime = SelectTime.Date;
        }

        private void frmTemperWrite_Load(object sender, EventArgs e)
        {
            //dateTimePicker_Select.Value = Convert.ToDateTime(this.startDate);
        }

        public Class_T_CHILD_TEMPERATURE_INFO ExcuteTemperOther()
        {
            Class_T_CHILD_TEMPERATURE_INFO tti = new Class_T_CHILD_TEMPERATURE_INFO();
            //����
            //tti.Bed_no = this.bed_no;
            //���˱��
            tti.Id = App.GenId().ToString();
            tti.Pid = this.pid;
            tti.Patient_ID = this.pid_ids;
            //������
            tti.Stool_count = txtDBCS.Text;
            //�������
            tti.Stool_color = txtDBXZ.Text;
            //С��
            tti.Urine = txtXB.Text;
            //���
            tti.Umbilicalcord = txtQD.Text;
            //һ�����
            tti.Ybqk = txtYBQK.Text;
            //����
            tti.Feed_style = cboBR.Text;
            //����
            tti.Weight = txtTZ.Text;
            //ǩ��
            tti.Qm = txtQM.Text;
            //ʱ��
            tti.Record_time = dateTimePicker_Select.Value.ToString("yyyy-MM-dd HH:mm");

            //tti.Empty_name1 = txtEmptyItemName1.Text;
            //tti.Empty_value1 = txtEmptyItemValue1.Text;
            //tti.Empty_name2 = txtEmptyItemName2.Text;
            //tti.Empty_value2 = txtEmptyItemValue2.Text;
            return tti;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (this.txtBedNo.Text.Trim().Length > 0)
            //{
            //    this.txtBedNo.Text += "��";
            //}
        }


        //private string Diagnose = string.Empty;
        //private string DiagnoseCount = string.Empty;

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FrmSelectDiagnose frm = new FrmSelectDiagnose(this.pid_ids.ToString(), Diagnose, DiagnoseCount);
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        Diagnose = frm.Diagnose;
        //        DiagnoseCount = frm.Index.ToString();
        //    }
        //}

    }

}