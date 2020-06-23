using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using Bifrost;
using System.Drawing.Imaging;
using System.Collections;
using System.Reflection;
using TempertureEditor;
using TempertureEditor.Element;

namespace TempertureEditor.Tempreture_Management
{
    public partial class ucTempratureDataLoad_child : UserControl
    {
        PrintTp pt = new PrintTp(); //���µ��Ļ��ƶ���

        Page currentPage = new Page();
        Comm cm = new Comm();
        InPatientInfo tPatInfo = new InPatientInfo();
        
        private string in_date = string.Empty;
        private string pid = string.Empty;
        private string dcgDate = string.Empty;
        private string dcgBatchno = string.Empty;
        private string hepatitsDate = string.Empty;
        private string hepatitsBatchno = string.Empty;
        private string medicare_no = string.Empty;
        private string startDate;
        private string endDate;
        public string CurrentNodeStr;
        private Point m_StarPoint = Point.Empty;
        private Point m_ViewPoint = Point.Empty;

        private DateTime SelectTime;//��ǰ����

        private DateTime curDateTime;
        public List<string> oldOperations = new List<string>();
        public List<string> newOPerations = new List<string>();

        private DateTime? outTime = null;           //���ݳ�Ժ���Զ������¼������ɵ�ǰ��Ժʱ��
        private List<string> listOldOptStartTime = new List<string>();    //������ʼʱ��yyyy-MM-dd HH:mm
        private string oldOptOEndtime;      //��������ʱ��yyyy-MM-dd HH:mm

        //��¼�쳣ֵ��Χ
        double dTmax = 0;
        double dTmin = 0;
        int iRmax = 0;
        int iRmin = 0;
        int iPmax = 0;
        int iPmin = 0;
        public DateTime CurDateTime
        {
            get { return curDateTime; }
            set { curDateTime = value; }
        }

        public string dtpTimes_date = "";
        private int isHowTime = 0;
        private bool isOkNow = true;

        public int IsHowTime
        {
            get { return this.isHowTime; }
            set { this.isHowTime = value; }
        }

        public ucTempratureDataLoad_child(InPatientInfo info, string tfilename)
        {
            InitializeComponent();
            cm.startini(tfilename); //���µ���ʼ��;
            pt.cm = cm;
            this.tPatInfo = info;

            //��ʼʼ��cboTimeѡ������
            cboTime.Items.Clear();
            string[] times = tempetureDataComm.GetTemperatureWriteTime(tempetureDataComm.TEMPLATE_CHILD);
            cboTime.Items.AddRange(times);

            //�ж����¡�������������������ֵ��С
            LoadSymbolVaildScope();
            DateTime sysTime = App.GetSystemTime();
            dateTimePicker_Select.Value = sysTime;    //���õ�ǰʱ��

            this.in_date = info.In_Time.ToString("yyyy-MM-dd HH:mm");
            this.pid = info.PId;
            
            panel4.MouseWheel += new MouseEventHandler(panel_MouseWheel);
            pictureBox1.Click += new EventHandler(panel_Click);
            panel4.Click += new EventHandler(panel_Click);
            panel4.Focus();

            loadTree();

        }

        private void RefleshTempratureEvent(object sender, EventArgs e)
        {
            loadTreeRefresh();
        }


        private void ckChu_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckChu.Checked)
                txtHeart.Text = "";
            txtHeart.Enabled = ckChu.Checked;
            ckHeartRate.Enabled = ckChu.Checked;
        }




        /// <summary>
        /// ˢ��ʱ����Ŀ
        /// </summary>
        public void loadTreeRefresh()
        {
            int oldIndex = cboPageIndex.SelectedIndex;
            
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = App.GetDataSet(string.Format("select aa.VALTYPE_TIME from t_temperature_record aa where " +
                  "aa.valtype ='�����¼�' and (aa.t_val like '��Ժ%' or aa.t_val like '����%') and patient_id={0} and template_type='{1}'  order by aa.VALTYPE_TIME asc", tPatInfo.Id.ToString(), tempetureDataComm.TEMPLATE_CHILD)).Tables[0];
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
                temper = "��" + (i + 1).ToString() + "ҳ(" + inDatetime.AddDays(i * dayCountPerWeek).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * dayCountPerWeek + dayCountPerWeek - 1).ToString("yyyy-MM-dd") + ")";
                cboPageIndex.Items.Add(temper);
                temper = "";
            }

            if (oldIndex <= cboPageIndex.Items.Count - 1)
            {
                cboPageIndex.SelectedIndex = oldIndex;
            }

        }

        /// <summary>       
        /// ������       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        void panel_MouseWheel(object sender, MouseEventArgs e)
        {
            //��ȡ���λ��
            Point mousePoint = new Point(e.X, e.Y);
            //�������Ա������λ��
            mousePoint.Offset(this.Location.X, this.Location.Y);
            //�ж��Ƿ���panel��
            if (this.panel4.RectangleToScreen(
              panel4.DisplayRectangle).Contains(mousePoint))
            {
                //����
                panel4.AutoScrollPosition = new Point(0, panel4.VerticalScroll.Value - e.Delta);
            }
        }

        /// <summary>       
        /// ����ڿؼ��ϵ��ʱ����Ҫ�����ý��㣬��ΪĬ�ϲ����ý���       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void panel_Click(object sender, EventArgs e)
        {
            panel4.Focus();
        }

        /// <summary>
        /// ����ʱ����Ŀ
        /// </summary>
        public void loadTree()
        {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = App.GetDataSet(string.Format("select aa.VALTYPE_TIME from t_temperature_record aa where " +
                              "aa.valtype ='�����¼�' and (aa.t_val like '��Ժ%' or aa.t_val like '����%') and patient_id={0} and template_type='{1}'  order by aa.VALTYPE_TIME asc", tPatInfo.Id.ToString(), tempetureDataComm.TEMPLATE_CHILD)).Tables[0];
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
                temper = "��" + (i + 1).ToString() + "ҳ(" + inDatetime.AddDays(i * dayCountPerWeek).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * dayCountPerWeek + dayCountPerWeek - 1).ToString("yyyy-MM-dd") + ")";
                cboPageIndex.Items.Add(temper);
                temper = "";
            }

            cboPageIndex.SelectedIndex = cboPageIndex.Items.Count - 1;

        }

        /// <summary>
        /// ������ײ
        /// </summary>
        /// <param name="current_x">��ǰ�������X</param>
        /// <param name="current_y">��ǰ�������Y</param>
        /// <param name="data_x"></param>
        /// <param name="data_y"></param>
        /// <param name="data_width"></param>
        /// <param name="data_height"></param>
        /// <returns></returns>
        private bool isInArea(float current_x, float current_y, float data_x, float data_y, float data_width, float data_height)
        {
            if (current_x >= data_x && current_x <= data_x + data_width)
            {
                if (current_y >= data_y && current_y <= data_y + data_height)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���ÿ�ʼʱ�� ����ʱ��
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

        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush yellowBrush = new SolidBrush(Color.Yellow);
        private Pen greenPen = new Pen(Color.Green);
        private Font nineFont = new Font("����", 9f);

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
          
            if (currentPage.Objs != null)
            {
                if (currentPage.Objs.Count == 0)
                {
                    pt.TemperturePaintInterface(e.Graphics, null);
                }
                else
                {
                    pt.TemperturePaintInterface(e.Graphics, currentPage);
                }
            }

            
            GC.Collect();

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                float d_x = 174 + 38;
                float d_y = 194 + 48;
                float d_h = 820;
                float d_w = 504;
                if (isInArea(e.X, e.Y, d_x, d_y, d_w, d_h))
                {
                    pictureBox1.Refresh();
                    return;
                }

            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
            }

        }

        private Bitmap bmp;

        private void cboPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPageIndex.SelectedIndex != -1 && this.cboPageIndex.Items.Count > 0)
            {
                
                //��ʼ��һ�����µ��Ŀ�ʼ�ͽ���ʱ��this.startDate, this.endDate
                panel1.AutoScrollPosition = new Point(0, 0);
                string tempString = cboPageIndex.SelectedItem.ToString();
                StarToEndTime(tempString);

                currentPage.Objs = new List<ClsDataObj>();
                currentPage.Starttime = startDate + " 00:00:00";
                currentPage.Endtime = endDate + " 23:59:59";
                
                //ģ�帳ֵ
                tempetureDataComm.GetPageContentByPageObj_child(tPatInfo, ref currentPage, (cboPageIndex.SelectedIndex + 1).ToString(), outTime,ref cm);
                //����dateTimePicker_Select��ѡ��Χ
                setDateTimeMinOrMax();
                pictureBox1.Refresh();
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (cboPageIndex.SelectedIndex != -1 && this.cboPageIndex.Items.Count > 0)
            {
                if (cboPageIndex.SelectedIndex != 0)
                {
                    cboPageIndex.SelectedIndex -= 1;
                }
                else
                {
                    App.Msg("�Ѿ��ǵ�һҳ��");
                }
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (cboPageIndex.SelectedIndex != -1 && this.cboPageIndex.Items.Count > 0)
            {
                if (cboPageIndex.SelectedIndex != this.cboPageIndex.Items.Count - 1)
                {
                    cboPageIndex.SelectedIndex += 1;
                }
                else
                {
                    App.Msg("�Ѿ������һҳ��");
                }
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            DateTime sysTime = App.GetSystemTime();
            if (dateTimePicker_Select.Value.Date > sysTime.Date || dateTimePicker_Select.Value.Date > Convert.ToDateTime(endDate) ||
               dateTimePicker_Select.Value.Date < Convert.ToDateTime(startDate))
            {
                App.MsgWaring("ѡ������ڲ���ȷ��ֻ��ѡ��ǰҳ��������ڷ�Χ�����Ҳ��ܳ�����ǰ���ڣ������޷�����!");
            }

            string measureRemark = "";
            string valCategory = "";
            string ctype = "";
            string l_val = "";
            string lsql = "";
            List<string> sqls = new List<string>();
            //�����ǰʱ�������            
            sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                     " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and  MEASURE_TIME=to_date('" + SelectTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')");


            //��֯����
            #region ��ʱ���¼������
            if (cbTemperType.Text == "Ҹ��")
            {
                ctype = "Ҹ��";
                if (ckReiteration.Checked)
                {
                    ctype = "Ҹ�¸���";
                }

            }
            else if (cbTemperType.Text == "�ڱ�")
            {
                ctype = "����";
                if (ckReiteration.Checked)
                {
                    ctype = "���¸���";
                }

            }
            else if (cbTemperType.Text == "�ر�")
            {
                ctype = "����";
                if (ckReiteration.Checked)
                {
                    ctype = "���¸���";
                }
            }


            if (txtTemper.Text.Trim() != "")
            {
                l_val = txtTemper.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }


            if (ckReiteration.Checked)
            {
                ctype = "�����־";
                l_val = "Y";
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }
            if (ckChu.Checked)
            {
                ctype = "�������";
                l_val = "Y";
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            if (ckBreath.Checked)
            {
                ctype = "������־";
                l_val = "Y";
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            if (ckHeartRate.Checked)
            {
                ctype = "���ʱ�־";
                l_val = "Y";
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            if (txtDown.Text.Trim() != "")
            {
                ctype = "���¡�";
                l_val = txtDown.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));

            }
            //����
            if (txtPulse.Text.Trim() != "")
            {
                ctype = "����";
                l_val = txtPulse.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }
            //����
            if (txtBreathing.Text.Trim() != "")
            {
                if (ckBreath.Checked)
                {
                    measureRemark = "����";
                    valCategory = "����";
                }
                ctype = "��������";
                l_val = txtBreathing.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
              }

            //����
            if (txtHeart.Text.Trim() != "")
            {
                ctype = "����";
                if (ckHeartRate.Checked)
                    ctype = "������";
                l_val = txtHeart.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //�ж��¼�
            if (cbEvent.Text.Trim() != "" &&
                !cbEvent.Text.Contains("��ѡ��"))
            {
                ctype = "�¼�";
                l_val = cbEvent.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }
            try
            {
                //�����¼�
                string operater_type = "��ǰ";
                string operater_types = "����";
                string pid = tPatInfo.PId;
                string pids_id = tPatInfo.Id.ToString();
                bool bContainOperater = false;
                foreach (object strval in lbEvents.Items)
                {
                    string Operater_start_time = Convert.ToDateTime(SelectTime).ToString("yyyy-MM-dd") + " " + strval.ToString().Split('_')[1];

                    ctype = "�����¼�";
                    l_val = strval.ToString();
                    sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, Convert.ToDateTime(Operater_start_time), tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));

                    if (strval.ToString().Contains("����"))
                    {
                        //�����Ļ��н���ʱ��
                        ctype = "��������ʱ��";
                        string Operater_end_time = l_val = dtpSurgeryEndTime.Value.ToString("yyyy-MM-dd HH:mm");
                        sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, Convert.ToDateTime(Operater_start_time), tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));

                        //�������ʿ����ݿ����

                        if (!listOldOptStartTime.Contains(Operater_start_time))
                        {
                            string operation_startTime = Operater_start_time;
                            string sql_operation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,agestr) values('" + pid + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','yyyy-mm-dd hh24:mi')," + pids_id + ",'" + tPatInfo.Age + "')";
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
                                string sql_updateOld = "update t_job_temp set event_type='-' where OPERATE_TYPE='" + operater_types + "' and to_char(OPERATE_TIME, 'yyyy-mm-dd hh24:mi')='" + oldOptOEndtime + "' and PATIENT_ID=" + pids_id;
                                sqls.Add(sql_updateOld);
                            }
                            string sql_operations = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,agestr) values('" + pid + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','yyyy-mm-dd hh24:mi')," + pids_id + ",'" + tPatInfo.Age + "')";
                            sqls.Add(sql_operations);
                        }
                    }
                }

                foreach (string oldStartTime in listOldOptStartTime)
                {
                    string sql_updateOld = "update t_job_temp set event_type='-' where OPERATE_TYPE='" + operater_type + "' and to_char(OPERATE_TIME, 'yyyy-mm-dd hh24:mi')='" + oldStartTime + "' and PATIENT_ID=" + pids_id;
                    sqls.Add(sql_updateOld);

                    if (!bContainOperater)
                    {
                        //����
                        sql_updateOld = "update t_job_temp set event_type='-' where OPERATE_TYPE='" + operater_types + "' and to_char(OPERATE_TIME, 'yyyy-mm-dd hh24:mi')='" + oldOptOEndtime + "' and PATIENT_ID=" + pids_id;
                        sqls.Add(sql_updateOld);
                    }
                }
            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(msg);
            }
            //��Ժ
            if (cmbLy.Text.Trim() != "")
            {
                ctype = "��Ժ";
                l_val = cmbLy.Text.Trim();
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }
            #endregion

            #region ����¼������(ע�⣺����¼�����ݣ�ֻ�����ڣ�����¼��ʱ��)

            //Ѫѹ1
            ctype = "Ѫѹ1";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (cmbBp.Text.Trim() != "")
            {
                l_val = cmbBp.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //Ѫѹ2
            ctype = "Ѫѹ2";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (cmbBp2.Text.Trim() != "")
            {
                l_val = cmbBp2.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //������
            ctype = "������";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                       " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (cmbShit.Text.Trim() != "")
            {
                l_val = cmbShit.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //С�����
            ctype = "С�����";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (cmbUrine.Text.Trim() != "")
            {
                l_val = cmbUrine.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }
            
            //������
            ctype = "������";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtVOLUME_OF_DRAINAGE.Text.Trim() != "")
            {
                l_val = txtVOLUME_OF_DRAINAGE.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //������
            ctype = "������";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtInAmount.Text.Trim() != "")
            {
                l_val = txtInAmount.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //�ܳ���
            ctype = "�ܳ���";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtOutAmount.Text.Trim() != "")
            {
                l_val = txtOutAmount.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //���
            ctype = "���";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (cmbHeight.Text.Trim() != "")
            {
                l_val = cmbHeight.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //����
            ctype = "����";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (cmbWeight.Text.Trim() != "")
            {
                l_val = cmbWeight.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //����
            ctype = "����";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtUrineAmount.Text.Trim() != "")
            {
                l_val = txtUrineAmount.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //ͷΧ
            ctype = "ͷΧ";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtTouWei.Text.Trim() != "")
            {
                l_val = txtTouWei.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //������
            ctype = "������";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtIntLiquidAmount.Text.Trim() != "")
            {
                l_val = txtIntLiquidAmount.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //������
            ctype = "������";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtInMouthAmount.Text.Trim() != "")
            {
                l_val = txtInMouthAmount.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }

            //�����
            ctype = "�����";
            lsql = "delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                           " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + SelectTime.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
            sqls.Add(lsql);
            if (txtShitAmount.Text.Trim() != "")
            {
                l_val = txtShitAmount.Text;
                sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, Convert.ToDateTime(SelectTime.ToString("yyyy-MM-dd")), ctype, l_val, SelectTime, tempetureDataComm.TEMPLATE_CHILD, measureRemark, valCategory));
            }


            #endregion

            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                App.Msg("�����Ѿ��ɹ���");
                loadTreeRefresh();
                TemperClear();
                refleshData();
                pictureBox1.Refresh();
            }
            else
            {
                App.Msg("����ʧ�ܣ�");
            }


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


            if (isOkNow)
            {
                if (this.txtTemper.Text == "" && this.txtPulse.Text == "" && this.txtBreathing.Text == "" && this.txtHeart.Text == "")
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
        /// ����¼��ʱ�������¼�ʱ�䷶Χ
        /// </summary>
        /// <returns></returns>
        private bool checkEventTimeValid()
        {
            DateTime dtStart = new DateTime();
            DateTime dtEnd = new DateTime();

            DateTime dtMeasure = SelectTime;

            if (!tempetureDataComm.GetDateTimeRangeByMeasure(dtMeasure, dtpAddEventTime.Value, ref dtStart, ref dtEnd, tempetureDataComm.TEMPLATE_CHILD))
            {
                string tip = string.Format("{0}ʱ�䷶Χ��{1}��{2}", cboTime.Text, dtStart.ToString("HH:mm"), dtEnd.ToString("HH:mm"));
                App.Msg(tip);
                return false;
            }
            return true;
        }
       
        /// <summary>
        /// �����¼���Ӵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (this.cbAddEvent.Text != "--��ѡ��--")
            {
                //�ж��¼�ʱ����Ч��
                if (!checkEventTimeValid())
                    return;
             
                string even = tempetureDataComm.ConvertOptEventToDBString(this.dtpAddEventTime.Value, this.cbAddEvent.Text);
                this.lbEvents.Items.Add(even);
            }
        }

        /// <summary>
        /// �����¼�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        }
        /// <summary>
        /// �����¼�ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbTime.Text = cboTime.Text;
            string text = cboTime.Text;
            bool bAddOneDay = false;
            if (text == "24:00")
            {
                text = "00:00";
            }

            SelectTime = Convert.ToDateTime(this.dateTimePicker_Select.Value.ToString("yyyy-MM-dd ") + text);
            enableInputByInHospitalTime(tPatInfo.In_Time, SelectTime);
            //����¼�봰��
            this.TemperClear();
            this.refleshData();
            pictureBox1.Refresh();
        }

        /// <summary>
        /// ����ˢ������
        /// </summary>
        private void TemperClear()
        {
            //��ȡ��ǰʱ��    
            this.cbEvent.SelectedIndex = 0;
            this.cbAddEvent.SelectedIndex = 0;
            this.cbTemperType.SelectedIndex = 0;
            this.dtpSurgeryEndTime.Enabled = false;
            this.txtTemper.Text = "";
            this.txtDown.Text = "";
            this.txtDown.Visible = false;
            this.label1.Visible = false;
            this.ckReiteration.Checked = false;
            this.txtPulse.Text = "";
            this.ckChu.Checked = false;
            this.txtBreathing.Text = "";
            this.ckBreath.Checked = false;
            this.txtHeart.Text = "";
            this.ckHeartRate.Checked = false;
            //this.txtHeart.Enabled = false;
            //this.ckHeartRate.Enabled = false;
            this.lbEvents.Items.Clear();
            //�ؼ��¼�ʱ�䷶Χ
            string text = cboTime.Text;
            if (text == "24:00")
            {
                text = "00:00";
            }
            this.dtpAddEventTime.Value = Convert.ToDateTime(this.dateTimePicker_Select.Value.ToString("yyyy-MM-dd ") + text);
            this.dtpSurgeryEndTime.Value = Convert.ToDateTime(this.dateTimePicker_Select.Value.ToString("yyyy-MM-dd ") + text);
            this.cmbLy.Text = "";   //��Ժ


            this.cmbBp.Text = "";
            this.cmbBp2.Text = "";

            //������
            cmbShit.Text = "";

            //С�����
            cmbUrine.Text = "";
            
            //������
            txtVOLUME_OF_DRAINAGE.Text = "";

            //������
            txtInAmount.Text = "";

            //�ܳ���
            txtOutAmount.Text = "";

            //���
            cmbHeight.Text = "";

            //����
            cmbWeight.Text = "";

            //����
            txtUrineAmount.Text = "";

            //ͷΧ
            txtTouWei.Text = "";

            //������
            txtIntLiquidAmount.Text = "";

            //������
            txtInMouthAmount.Text = "";

            //�����
            txtShitAmount.Text = "";
            
        }

        /// <summary>
        /// ����ʱ���ˢ������
        /// </summary>
        private void refleshData()
        {
            try
            {
                string sql = "select * from T_TEMPERATURE_RECORD t where t.measure_time=to_date('" +
                               SelectTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and t.patient_id=" + tPatInfo.Id.ToString() +
                               " and t.template_type='" + tempetureDataComm.TEMPLATE_CHILD + "'";
                DataSet ds = App.GetDataSet(sql);

                lbEvents.Items.Clear();
                listOldOptStartTime.Clear();
                oldOptOEndtime = "";
                foreach (DataRow trow in ds.Tables[0].Rows)
                {
                    if (trow["VALTYPE"].ToString() == "�����־")
                    {
                        ckReiteration.Checked = (trow["T_VAL"].ToString() == "Y");
                    }
                    else if (trow["VALTYPE"].ToString() == "�������")
                    {
                        ckChu.Checked = (trow["T_VAL"].ToString() == "Y");
                    }
                    else if (trow["VALTYPE"].ToString() == "������־")
                    {
                        ckBreath.Checked = (trow["T_VAL"].ToString() == "Y");
                    }
                    else if (trow["VALTYPE"].ToString() == "���ʱ�־")
                    {
                        ckHeartRate.Checked = (trow["T_VAL"].ToString() == "Y");
                    }
                    else if (trow["VALTYPE"].ToString() == "���¡�")
                    {
                        txtDown.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "Ҹ��" || trow["VALTYPE"].ToString() == "Ҹ�¸���")
                    {
                        cbTemperType.Text = "Ҹ��";
                        txtTemper.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "����" || trow["VALTYPE"].ToString() == "���¸���")
                    {
                        cbTemperType.Text = "�ڱ�";
                        txtTemper.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "����" || trow["VALTYPE"].ToString() == "���¸���")
                    {
                        cbTemperType.Text = "�ر�";
                        txtTemper.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "����")
                    {
                        txtPulse.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "����")
                    {
                        txtHeart.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "������")
                    {
                        txtHeart.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString().Contains("����"))
                    {
                        txtBreathing.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "�¼�")
                    {
                        cbEvent.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "�����¼�")
                    {
                        string optEvent = trow["T_VAL"].ToString();
                        lbEvents.Items.Add(optEvent);
                        if (optEvent.Contains("����"))
                        {
                            listOldOptStartTime.Add(SelectTime.ToString("yyyy-MM-dd") + " " + optEvent.ToString().Split('_')[1]);
                        }
                    }
                    else if (trow["VALTYPE"].ToString() == "��������ʱ��")
                    {
                        dtpSurgeryEndTime.Value = Convert.ToDateTime(trow["T_VAL"].ToString());
                        oldOptOEndtime = dtpSurgeryEndTime.Value.ToString("yyyy-MM-dd HH:mm");
                    }
                    else if (trow["VALTYPE"].ToString() == "��Ժ")
                    {
                        cmbLy.Text = trow["T_VAL"].ToString();
                    }
                }
                //����¼��
                string sql2 = "select * from T_TEMPERATURE_RECORD t where to_char(t.measure_time,'yyyy-MM-dd')='" +
                               SelectTime.ToString("yyyy-MM-dd") + "' and t.patient_id=" + tPatInfo.Id.ToString() +
                               " and t.template_type='" + tempetureDataComm.TEMPLATE_CHILD + "'";
                DataSet ds2 = App.GetDataSet(sql2);
                foreach (DataRow trow in ds2.Tables[0].Rows)
                {
                    if (trow["VALTYPE"].ToString() == "Ѫѹ1")
                    {
                        cmbBp.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "Ѫѹ2")
                    {
                        cmbBp2.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "������")
                    {
                        cmbShit.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "С�����")
                    {
                        cmbUrine.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "������")
                    {
                        txtVOLUME_OF_DRAINAGE.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "������")
                    {
                        txtInAmount.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "�ܳ���")
                    {
                        txtOutAmount.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "���")
                    {
                        cmbHeight.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "����")
                    {
                        cmbWeight.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "����")
                    {
                        txtUrineAmount.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "ͷΧ")
                    {
                        txtTouWei.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "������")
                    {
                        txtIntLiquidAmount.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "������")
                    {
                        txtInMouthAmount.Text = trow["T_VAL"].ToString();
                    }
                    else if (trow["VALTYPE"].ToString() == "�����")
                    {
                        txtShitAmount.Text = trow["T_VAL"].ToString();
                    }

                }
                /*
                //������ʾ����
                string sql3 = "select * from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                       " and template_type='" + tempetureDataComm.TEMPLATE_CHILD + "' and measure_time between to_date('" + currentPage.Starttime +
                       "','yyyy-MM-dd hh24:mi:ss') and to_date('" + currentPage.Endtime + "','yyyy-MM-dd hh24:mi:ss') and VALTYPE='�Զ�������'";
                DataSet ds3 = App.GetDataSet(sql3);
                foreach (DataRow trow in ds3.Tables[0].Rows)
                {
                    if (trow["VALTYPE"].ToString() == "�Զ�������")
                    {
                        txtCustomName.Text = trow["T_VAL"].ToString();
                    }
                }
                */
            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(msg);
            }
            
        }
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


        private void dateTimePicker_Select_ValueChanged(object sender, EventArgs e)
        {
            this.lbTime.Text = cboTime.Text;
            string text = cboTime.Text;
            if (text == "24:00")
            {
                text = "00:00";
            }
            
            SelectTime = Convert.ToDateTime(this.dateTimePicker_Select.Value.ToString("yyyy-MM-dd ") + text);
            enableInputByInHospitalTime(tPatInfo.In_Time, SelectTime);
            this.TemperClear();
            this.refleshData();
            pictureBox1.Refresh();
        }

        /// <summary>
        /// ���ÿɲ������ڶ�
        /// </summary>
        /// <param name="dateT"></param>
        public void setDateTimeMinOrMax()
        {
            DateTime sysTime = App.GetSystemTime();
            //�Ȼ�ԭĬ��,������
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
        /// ������Ժǰʱ����ֹ¼��
        /// </summary>
        /// <param name="dtInHostpital">��Ժʱ��</param>
        /// <param name="dtEnableTime">У��ʱ���</param>
        /// <returns></returns>
        private bool enableInputByInHospitalTime(DateTime dtInHostpital, DateTime dtEnableTime)
        {
            DateTime dtStart = new DateTime();
            DateTime dtEnd = new DateTime();

            tempetureDataComm.GetDateTimeRangeByMeasure(dtEnableTime, dtInHostpital, ref dtStart, ref dtEnd, tempetureDataComm.TEMPLATE_CHILD);

            //��ȷ���ֺ�,���бȽ�
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

            return bEnable;
        }
        private void cboTime_SelectIndexByDateTime(DateTime dt)
        {
            DateTime dtWrite = tempetureDataComm.GetInsertDateTime(dt, tempetureDataComm.TEMPLATE_CHILD);

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
        private void ucTempratureDataLoad_child_Load(object sender, EventArgs e)
        {
            dateTimePicker_Select.Value = dateTimePicker_Select.MaxDate;
            DateTime dtCurWrite = App.GetSystemTime();
            cboTime_SelectIndexByDateTime(dtCurWrite);
            this.pictureBox1.Width = cm.MaxWidth;
            this.pictureBox1.Height = cm.MaxHeight + 100;
        }
        /// <summary>
        /// ���ð�ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.TemperClear();
        }

        private bool bTabDirection = true; //tab������
        protected override bool ProcessTabKey(bool forward)
        {
            forward = bTabDirection;
            return base.ProcessTabKey(forward);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    {
                        bTabDirection = true;
                        SendKeys.Send("{Tab}");
                        SendKeys.Flush();
                        return true;
                    }
                case Keys.Up:
                    {
                        bTabDirection = false;
                        SendKeys.Send("{Tab}");
                        return true;
                    }
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panel4_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((panel4.Width - pictureBox1.Width) / 2, -panel4.VerticalScroll.Value);
        }
    }
}

