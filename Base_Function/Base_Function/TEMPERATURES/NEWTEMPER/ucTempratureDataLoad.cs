using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using Bifrost;
using Base_Function.TEMPERATURES.ValueSet;
using Base_Function.BASE_COMMON;
using System.Drawing.Imaging;
using System.Collections;
using Base_Function.MODEL;
using System.Reflection;
using TempertureEditor;
using TempertureEditor.Element;

namespace Base_Function.TEMPERATURES
{
    public partial class ucTempratureDataLoad : UserControl
    {
        PrintTp pt = new PrintTp(); //���µ��Ļ��ƶ���

        printTemperDataLoad ph = new printTemperDataLoad();

        InPatientInfo inPat = new InPatientInfo();

        private string in_date = string.Empty;
        private string pid = string.Empty;
        private string dcgDate = string.Empty;
        private string dcgBatchno = string.Empty;
        private string hepatitsDate = string.Empty;
        private string hepatitsBatchno = string.Empty;
        private string medicare_no = string.Empty;
        private string startTime;
        private string endTime;
        private bool isChild = false;
        private string id = string.Empty;
        public string CurrentNodeStr;
        private string bedno = "";
        private Point m_StarPoint = Point.Empty;        
        private Point m_ViewPoint = Point.Empty;
        ucTemperWrite uc;
        public static ArrayList tempPoints;  //��ȡ��ǰ�������µ��ĵ�
        public static bool IsRefresh;//�Ƿ�ˢ��
        //��¼ҳü��Ϣ
        public static string Diagnose = "";
        public static string Section = "";
        public static string BedNo = "";

        public static void RefreshHeader(string PatientID, string PageIndex, DateTime startTime, DateTime endTime)
        {
            Diagnose = TemperatureMethod.GetDiagnose(PatientID, PageIndex, startTime, endTime);
            Section = TemperatureMethod.GetSection(PatientID, PageIndex, startTime, endTime);
            BedNo = TemperatureMethod.GetBedNo(PatientID, PageIndex, startTime, endTime);
        }

        public ucTempratureDataLoad(InPatientInfo info)
        {
            InitializeComponent();

            this.inPat = info;
            //Comm.startini(); //���µ���ʼ��
            
            string age = info.Age + info.Age_unit;
            string sex = info.Gender_Code;
            if (sex == "0" || sex == "��")
                sex = "��";
            else
                sex = "Ů";
            ph.Hospital = App.HospitalTittle;
            ph.TextName = "�� �� �� ¼ ��";
            ph.User.Add("����:", info.Patient_Name);
            ph.User.Add("����:", age);
            ph.User.Add("�Ա�:", sex);
            ph.User.Add("����:", info.Sick_Area_Name);
            ph.User.Add("����:", info.Sick_Bed_Name);
            ph.User.Add("��Ժ����:", Convert.ToDateTime(info.In_Time).ToString("yyyy-MM-dd HH:mm"));
            ph.User.Add("סԺ��:", info.PId);
            ph.User.Add("ID:", info.Id.ToString());
            string diagnose = "���";
            
            ph.User.Add("���:", diagnose);

            ph.Init(info.Id.ToString(), info.In_Time.ToString("yyyy-MM-dd HH:mm"));
            this.id = info.Id.ToString();
            this.in_date = info.In_Time.ToString("yyyy-MM-dd HH:mm");
            this.pid = info.PId;

            panel4.MouseWheel += new MouseEventHandler(panel_MouseWheel);
            pictureBox1.Click += new EventHandler(panel_Click);
            panel4.Click += new EventHandler(panel_Click);
            panel4.Focus();

            loadTree();

            ucTemperWrite.A_RefleshTemprature += new EventHandler(RefleshTempratureEvent);
        }

        private void RefleshTempratureEvent(object sender, EventArgs e)
        {
            loadTreeRefresh();
        }


        /// <summary>
        /// ˢ��ʱ����Ŀ
        /// </summary>
        public void loadTreeRefresh()
        {
            int oldIndex = cboTime.SelectedIndex;
            cboTime.Items.Clear();

            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            DataTable dt = null;
            if (!this.isChild)
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM T_VITAL_SIGNS T WHERE (T.DESCRIBE like '%��Ժ%' OR T.DESCRIBE like '%����%') AND patient_id = '{0}' ORDER BY MEASURE_TIME", this.id)).Tables[0];
            }
            else
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM t_child_vital_signs T WHERE T.DESCRIBE like '%��Ժ%' AND Patient_ID = '{0}' ORDER BY MEASURE_TIME DESC", this.id)).Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                today = Convert.ToDateTime(dt.Rows[0]["MEASURE_TIME"].ToString());
                ph.out_time = today;
                uc.out_time = today;
            }
            else
            {
                ph.out_time = today;
                uc.out_time = today;
            }
            TimeSpan ts1 = new TimeSpan(inDatetime.Ticks);
            TimeSpan ts2 = new TimeSpan(today.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int weekCount = 0;
            if ((ts.Days + 1) % 7 == 0)
                weekCount = (ts.Days + 1) / 7;
            else
                weekCount = (ts.Days + 1) / 7 + 1;

            string temper = "";
            for (int i = 0; i < weekCount; i++)
            {
                temper = "��" + (i + 1).ToString() + "ҳ(" + inDatetime.AddDays(i * 7).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * 7 + 6).ToString("yyyy-MM-dd") + ")";
                cboTime.Items.Add(temper);
                temper = "";
            }

            if (oldIndex <= cboTime.Items.Count - 1)
            {
                cboTime.SelectedIndex = oldIndex;
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
        /// ����ҳü
        /// </summary>
        private void LoadHeader()
        {
            ph.User["���:"] = Diagnose;
            ph.User["����:"] = Section;
            ph.User["����:"] = BedNo;
        }

        /// <summary>
        /// ����ʱ����Ŀ
        /// </summary>
        public void loadTree()
        {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            DataTable dt = null;
            if (!this.isChild)
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM T_VITAL_SIGNS T WHERE (T.DESCRIBE like '%��Ժ%' OR T.DESCRIBE like '%����%') AND patient_id = '{0}' ORDER BY MEASURE_TIME", this.id)).Tables[0];
            }
            else
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM t_child_vital_signs T WHERE T.DESCRIBE like '%��Ժ%' AND Patient_ID = '{0}' ORDER BY MEASURE_TIME DESC", this.id)).Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                today = Convert.ToDateTime(dt.Rows[0]["MEASURE_TIME"].ToString());
                ph.out_time = today;
            }
            TimeSpan ts1 = new TimeSpan(inDatetime.Ticks);
            TimeSpan ts2 = new TimeSpan(today.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int weekCount = 0;
            if ((ts.Days + 1) % 7 == 0)
                weekCount = (ts.Days + 1) / 7;
            else
                weekCount = (ts.Days + 1) / 7 + 1;

            string temper = "";
            for (int i = 0; i < weekCount; i++)
            {
                temper = "��" + (i + 1).ToString() + "ҳ(" + inDatetime.AddDays(i * 7).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * 7 + 6).ToString("yyyy-MM-dd") + ")";
                cboTime.Items.Add(temper);
                temper = "";
            }
            cboTime.SelectedIndex = cboTime.Items.Count - 1;
            panel5.Controls.Clear();
            uc = new ucTemperWrite(this.startTime, this.endTime, this.pid, this.id, this.bedno, today);//Convert.ToDateTime(startTime)
            panel5.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
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
            this.startTime = startEndDate[0];
            this.endTime = startEndDate[1];
        }
       
        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush yellowBrush = new SolidBrush(Color.Yellow);
        private Pen greenPen = new Pen(Color.Green);
        private Font nineFont = new Font("����", 9f);

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.TranslateTransform(38, 48);

            //if (ph.currentpage.Objs.Count == 0)
            //{
            //    pt.TemperturePaintInterface(e.Graphics, null);
            //}
            //else
            //{
            //    pt.TemperturePaintInterface(e.Graphics, ph.currentpage);
            //}

            //this.pictureBox1.Width = Comm.MaxWidth;
            //this.pictureBox1.Height = Comm.MaxHeight;


            e.Graphics.DrawImageUnscaled(bmp, 38, 48);

            //this.pictureBox1.Width = Comm.MaxWidth;
            //this.pictureBox1.Height = Comm.MaxHeight;


        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                float d_x = 174+38;
                float d_y = 194+48;
                float d_h = 820;
                float d_w = 504;
                if (isInArea(e.X, e.Y, d_x, d_y, d_w, d_h))
                {
                    DateTime selectdate = ph.GetSelectDay(e.X);
                    uc.ucTemperWrite_load(this.startTime, this.endTime, this.pid, this.id, this.bedno, selectdate);
                    pictureBox1.Refresh();
                    return;
                }


                //DataSet ds = App.GetDataSet("select * from T_TEMPRETURE_OP_SET where OPERATER_FORM='TemperPrints.ValueSet.frmTemperWrite'");
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    float d_x = Convert.ToSingle(ds.Tables[0].Rows[i]["START_X"].ToString());
                //    float d_y = Convert.ToSingle(ds.Tables[0].Rows[i]["START_Y"].ToString());
                //    float d_h = Convert.ToSingle(ds.Tables[0].Rows[i]["HEIGHT"].ToString());
                //    float d_w = Convert.ToSingle(ds.Tables[0].Rows[i]["WIDTH"].ToString());
                //    if (isInArea(e.X, e.Y, d_x, d_y, d_w, d_h))
                //    {
                //        DateTime selectdate = ph.GetSelectDay(e.X);
                //        uc.ucTemperWrite_load(this.startTime, this.endTime, this.pid, this.id, this.bedno, selectdate);
                //        pictureBox1.Refresh();
                //        return;
                //    }

                //}
            }
            catch(System.Exception ex)
            {
                string msg = ex.Message;
            }

        }

        private Bitmap bmp;

        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTime.SelectedIndex != -1 && this.cboTime.Items.Count > 0)
            {
                panel1.AutoScrollPosition = new Point(0, 0);
                string tempString = cboTime.SelectedItem.ToString();
                StarToEndTime(tempString);

                ph.PageIndex = cboTime.SelectedIndex + 1;
                RefreshHeader(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));

                ph.currentpage.Objs = new List<ClsDataObj>();
                ph.currentpage.Starttime = startTime + " 00:00:00";
                ph.currentpage.Endtime = endTime + " 23:59:59";

                LoadHeader();
                ph.printMain(this.startTime, this.endTime);

                bmp = new Bitmap(750, 1120);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    if (ph.currentpage.Objs.Count == 0)
                    {
                        pt.TemperturePaintInterface(g, null);
                    }
                    else
                    {
                        pt.TemperturePaintInterface(g, ph.currentpage);
                    }
                }


                pictureBox1.Refresh();

                if (uc != null)
                {
                    uc.ucTemperWrite_load(this.startTime, this.endTime, this.pid, this.id, this.bedno, Convert.ToDateTime(endTime));
                }

                //panel1.AutoScrollPosition = new Point(0, 0);
                //string tempString = cboTime.SelectedItem.ToString();
                //StarToEndTime(tempString);
                //ph.PageIndex = cboTime.SelectedIndex+1;//selectNode.Index + 1;

                //RefreshHeader(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));

                //pictureBox1.Left = 0;
                //pictureBox1.Top = 0;
                //pictureBox1.Width = ph.pWidth;
                //pictureBox1.Height = ph.pHeight;
                //pictureBox1.Refresh();
                //if (uc!=null)
                //{
                //    uc.ucTemperWrite_load(this.startTime, this.endTime, this.pid, this.id, this.bedno, Convert.ToDateTime(endTime));
                //}
                
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (cboTime.SelectedIndex != -1 && this.cboTime.Items.Count > 0)
            {
                if (cboTime.SelectedIndex != 0)
                {
                    cboTime.SelectedIndex -= 1;
                }
                else
                {
                    App.Msg("�Ѿ��ǵ�һҳ��");
                }
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (cboTime.SelectedIndex != -1 && this.cboTime.Items.Count > 0)
            {
                if (cboTime.SelectedIndex != this.cboTime.Items.Count-1)
                {
                    cboTime.SelectedIndex += 1;
                }
                else
                {
                    App.Msg("�Ѿ������һҳ��");
                }
            }
        }


    }
}
