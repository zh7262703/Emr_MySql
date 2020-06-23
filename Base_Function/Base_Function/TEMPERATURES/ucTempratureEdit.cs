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
using Base_Function.MODEL;
using System.Collections;
using System.Reflection;

namespace Base_Function.TEMPERATURES
{
    public partial class ucTempratureEdit : UserControl
    {
        printTemper ph = new printTemper();

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

        private Point start = new Point();//�������
        private Point end = new Point();//�����յ�
        private bool blnDraw = false;//�Ƿ�ʼ������
        private string bedno = "";
        Graphics g;
        Graphics g_p;

        private int begin_x;        //ͼƬ��ʼλ��
        private int begin_y;

        private Image image_ori;    //��ԭʼ��ͼƬ
        private Image image_dest;   //�����ź��ͼƬ

        private float zoom;           //��С�Ŵ�ٷݱȣ�ÿ10%Ϊһ�����ݡ�ÿ�����Ŷ�������ԭʼ��ͼƬ

        private Point m_StarPoint = Point.Empty;        //for �϶�
        private Point m_ViewPoint = Point.Empty;
        private bool m_StarMove = false;

        int w;                      //���ź��ͼƬ��С
        int h;


        public Graphics graphics;//�ַ�������

        Point currentMousePoint;
        public static ArrayList tempPoints;  //��ȡ��ǰ�������µ��ĵ�


        public ucTempratureEdit()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
        }

        public ucTempratureEdit(string pid, string medicare_no, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time)
        {
            InitializeComponent();
            if (sex == "0" || sex == "��")
                sex = "��";
            else
                sex = "Ů";
            if (string.IsNullOrEmpty(age) || age.Equals("0��") )
            {
                age = DataInit.GetAge(id);
            }

            ph.Hospital = App.HospitalTittle;
            ph.Bingqu = ward;
            this.bedno = bedNo;
            //this.id = id;
            ph.TextName = "�� �� �� ¼ ��";
            ph.User.Add("����:", name);
            ph.User.Add("�Ա�:", sex);
            ph.User.Add("����:", section);
            ph.User.Add("����:", age);
            ph.User.Add("����:", bedNo);
            ph.User.Add("��Ժ����:", Convert.ToDateTime(in_time).ToString("yyyy-MM-dd HH:mm"));
            ph.User.Add("�ǼǺ�:", medicare_no);
            ph.User.Add("סԺ��:", pid);
            ph.User.Add("ת������:", "");
            ph.User.Add("���:", id);//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'  and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + ph.User["��Ժ����:"] + "'", 0, "id"));
            string diagnose = "";
            string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + id + " order by a.diagnose_sort asc ";
            sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + id + " and a.diagnose_type = '403' order by a.diagnose_sort";
            DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
            if (dtdiagnose != null)
            {
                for (int i = 0; i < dtdiagnose.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                    }
                    else if (i >= 3)
                    {
                        break;
                    }
                    else
                    {
                        diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                    }
                }
            }
            ph.User.Add("���:", diagnose);
            //DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='����' and t.patient_id=" + id + "");
            DataSet ds = App.GetDataSet(" select a.leave_time from t_in_patient a where a.id='" + id + "' and a.leave_time is not null");
            if (ds.Tables[0].Rows.Count > 0)
                ph.User.Add("��Ժ����:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
            else
                ph.User.Add("��Ժ����:", "");
            ph.Init(id, in_time);
            this.in_date = in_time;
            this.id = id;
            this.pid = pid;
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Width = ph.pWidth;
            pictureBox1.Height = ph.pHeight;

            panel1.MouseWheel += new MouseEventHandler(panel_MouseWheel);
            pictureBox1.Click += new EventHandler(panel_Click);
            panel1.Click += new EventHandler(panel_Click);

            panel1.Focus();
            loadTree();
        }

        private FieldInfo m_Position;
        private MethodInfo m_SetPositionMethod;
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
            if (this.panel1.RectangleToScreen(
              panel1.DisplayRectangle).Contains(mousePoint))
            {
                //����
                panel1.AutoScrollPosition = new Point(0, panel1.VerticalScroll.Value - e.Delta);
            }
        }

        /// <summary>       
        /// ����ڿؼ��ϵ��ʱ����Ҫ�����ý��㣬��ΪĬ�ϲ����ý���       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void panel_Click(object sender, EventArgs e)
        {
            panel1.Focus();
        }


        /// <summary>
        /// ����ʱ����Ŀ
        /// </summary>
        public void loadTree()
        {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

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
            if (pid.Contains("_"))
            {
                inDatetime = Convert.ToDateTime(App.ReadSqlVal(" select to_char(birthday,'yyyy-MM-dd') birthday from t_in_patient where id=" + this.id, 0, "birthday"));
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
                temper = "��" + (i + 1).ToString() + "��(" + inDatetime.AddDays(i * 7).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * 7 + 6).ToString("yyyy-MM-dd") + ")";
                Node tn = new Node();
                tn.Text = temper;
                this.tvTimes.Nodes.Add(tn);
                temper = "";
            }
            string tempString = tvTimes.Nodes[tvTimes.Nodes.Count - 1].Text.ToString();
            StarToEndTime(tempString);
            //������Ϣ
            //ph.User["����:"] = GetTransferBed();
            //ph.User["���:"] = GetDiagnose(GetPageIndex());
            //ph.User["����:"] = App.UserAccount.CurrentSelectRole.Role_type=="N"? ph.User["����:"]:TemperatureMethod.GetSection(this.id, GetPageIndex());
            ph.User.Add("����:", TemperatureMethod.GetSection(this.id, GetPageIndex()));
            ph.PageIndex = tvTimes.Nodes.Count;
            //Node de = new Node();
            //de.Text = "��ʾȫ��";
            //this.tvTimes.Nodes.Add(de);
        }

        private string GetDiagnose()
        {
            string diagnose = "";
            string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + id + " order by a.diagnose_sort asc ";
            sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + id + " and a.diagnose_type = '403' order by a.diagnose_sort";
            DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
            if (dtdiagnose != null)
            {
                for (int i = 0; i < dtdiagnose.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                    }
                    else if (i >= 3)
                    {
                        break;
                    }
                    else
                    {
                        diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                    }
                }
            }
            return diagnose;
        }

        private string GetTransferBed()
        {
            //string bed = string.Empty;
            string weekfirstbed = string.Empty;
            string inbed = App.ReadSqlVal("select a.in_bed_no bed from t_in_patient a where a.id=" + this.id, 0, "bed");
            DateTime intime = Convert.ToDateTime(this.in_date).Date;
            DateTime time1 = Convert.ToDateTime(this.startTime).Date;
            DateTime time2 = Convert.ToDateTime(this.endTime).Date;
            string sql = string.Empty;
            string pageindex = string.Empty;
            pageindex = GetPageIndex();
            return GetBedNo(pageindex);
        }

        private string GetBedNo(string pindex)
        {
            string sql = " select a.id,a.pageindex,a.bedno,a.diagnose,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + this.id + "' and a.pageindex='" + pindex + "'";
            string bed = string.Empty;
            DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            if (pageheadtable.Rows.Count > 0)
            {
                bed = pageheadtable.Rows[0]["bedno"].ToString();
            }
            else
            {
                bed = this.bedno;
            }
            return bed;
        }

        private string GetDiagnose(string pindex)
        {
            string diagnose = string.Empty;
            string sql = " select a.id,a.pageindex,a.diagnose,diagnose_count,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + this.id + "' and a.pageindex='" + pindex + "'";
            DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            if (pageheadtable.Rows.Count > 0)
            {
                if (pageheadtable.Rows[0]["diagnose_count"].ToString().Length > 0)
                {
                    diagnose = pageheadtable.Rows[0]["diagnose"].ToString();
                }
                else
                {
                    diagnose = GetDiagnose();
                }
            }
            else
            {
                diagnose = GetDiagnose();
            }
            return diagnose;
        }

        private string GetPageIndex()
        {
            DateTime intime = Convert.ToDateTime(App.ReadSqlVal("select in_time from t_in_patient  where id='" + this.id + "'", 0, "in_time")).Date;
            DateTime time2 = Convert.ToDateTime(this.startTime).Date;
            //int i = 1;
            //if (intime.Date > time2.Date)
            //    return "1";
            //while (intime.Date != time2.Date)
            //{
            //    i++;
            //    time2 = time2.AddDays(-7);
            //}
            int i = 1;
            if (intime.Date > time2.Date)
                return "1";
            while (intime.Date != time2.Date)
            {
                i++;
                time2 = time2.AddDays(-1);
            }
            i = (int)Math.Ceiling((double)i / 7);
            return i.ToString();
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

        private void FormTest_Load(object sender, EventArgs e)
        {

        }

        private void tvTimes_Click(object sender, EventArgs e)
        {

        }

        private void tvTimes_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Node selectNode = this.tvTimes.SelectedNode;
            if (selectNode != null && this.tvTimes.Nodes.Count > 1)
            {
                panel1.AutoScrollPosition = new Point(0, 0);
                string tempString = selectNode.Text;
                string temp = tempString.Split('(')[1].ToString();
                string howWeek = tempString.Split('(')[0].ToString();
                string weeks = howWeek.Substring(1, howWeek.Length - 2);
                string[] startEndDate = temp.Substring(0, temp.Length - 1).Split('~');
                this.startTime = startEndDate[0];
                this.endTime = startEndDate[1];
                ph.PageIndex = selectNode.Index + 1;
                //ph.User["����:"] = GetTransferBed();
                //ph.User["���:"] = GetDiagnose(GetPageIndex());
                //ph.User["����:"] = TemperatureMethod.GetSection(this.id, GetPageIndex());
                pictureBox1.Left = 0;
                pictureBox1.Top = 0;
                pictureBox1.Width = ph.pWidth;
                pictureBox1.Height = ph.pHeight;
                pictureBox1.Refresh();
            }
        }

        private void ppcPreview_Paint(object sender, PaintEventArgs e)
        {

        }

        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush yellowBrush = new SolidBrush(Color.Yellow);
        private Pen greenPen = new Pen(Color.Green);
        private Font nineFont = new Font("����", 9f);
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Base_Function.TEMPERATURES.ucTempratureEdit.tempPoints = new ArrayList();
            e.Graphics.TranslateTransform(38, 78);
            ph.printMain(e.Graphics, this.startTime, this.endTime);
        }


        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from T_TEMPRETURE_OP_SET where OPERATER_FORM='TemperPrints.ValueSet.frmTemperWrite'");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //if (ds.Tables[0].Rows[i]["OPERATER_FORM"].ToString() == "TemperPrints.ValueSet.frmTemperWrite")
                    //{
                    float d_x = Convert.ToSingle(ds.Tables[0].Rows[i]["START_X"].ToString());
                    float d_y = Convert.ToSingle(ds.Tables[0].Rows[i]["START_Y"].ToString());
                    float d_h = Convert.ToSingle(ds.Tables[0].Rows[i]["HEIGHT"].ToString());
                    float d_w = Convert.ToSingle(ds.Tables[0].Rows[i]["WIDTH"].ToString());
                    if (isInArea(e.X, e.Y, d_x, d_y, d_w, d_h))
                    {
                        DateTime selectdate = ph.GetSelectDay(e.X);
                        frmTemperWrite fc = new frmTemperWrite(this.startTime, this.endTime, this.pid, this.id, this.bedno, selectdate);
                        fc.ShowDialog();
                        pictureBox1.Refresh();
                        return;
                    }

                }
                //App.MsgErr("������û�����ò������ԣ�");
            }
            catch (Exception ex) 
            {
                string exMsg = ex.Message;
                App.MsgErr("���µ��༭�������ʧ��!");//"������û�����ò������ԣ�");
            }
            
                
            

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expandableSplitter1_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {


            this.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.currentMousePoint = new Point(e.X - 28, e.Y - 78);
            this.Refresh();

        }
    }
}
