using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Bifrost;
using System.Reflection;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Base_Function.BASE_COMMON;
using TempertureEditor;
using TempertureEditor.Element;

namespace Base_Function.TEMPERATURES
{
    public partial class ucTemperPrintDataLoad : UserControl
    {
        PrintTp pt = new PrintTp(); //���µ��Ļ��ƶ���

        printTemperDataLoad ph = new printTemperDataLoad();
        PrintDocument pdDocument = new PrintDocument();
        private FieldInfo m_Position;
        private MethodInfo m_SetPositionMethod;
        private bool isMouseDown;
        private Point startPosition;
        private Point endPosition;
        private Point curPos;

        private string in_date = string.Empty;
        private string id = string.Empty;
        private string startTime;
        private string endTime;
        private bool isChild = false;
        PrintDialog pd = new PrintDialog();

        /// <summary>
        /// ��ͨ���µ���ӡ���캯��
        /// </summary>                
        public ucTemperPrintDataLoad(InPatientInfo info)
        {
            InitializeComponent();

            //Comm.startini(); //���µ���ʼ��

            string age = info.Age + info.Age_unit;
            string sex = info.Gender_Code;
            if (string.IsNullOrEmpty(age) || age.Equals("0��"))
            {
                age = DataInit.GetAge(info.Id.ToString());
            }
            if (sex == "0" || sex == "��")
                sex = "��";
            else
                sex = "Ů";
            ph.Hospital = App.HospitalTittle;
            //ph.Bingqu = info.Sick_Area_Name;
            ph.TextName = "�� �� �� ¼ ��";
            ph.User.Add("����:", info.Patient_Name);
            ph.User.Add("����:", age);
            ph.User.Add("�Ա�:", sex);
            ph.User.Add("����:", info.Sick_Area_Name);
            ph.User.Add("����:", info.Sick_Bed_Name);
            ph.User.Add("��Ժ����:", Convert.ToDateTime(info.In_Time).ToString("yyyy-MM-dd HH:mm"));
            ph.User.Add("סԺ��:", info.PId);
            ph.User.Add("ID:", info.Id.ToString());
            ph.User.Add("���:", "");

            ph.Init(info.Id.ToString(), info.In_Time.ToString("yyyy-MM-dd HH:mm"));
            this.id = info.Id.ToString();//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'", 0, "id");
            this.in_date = info.In_Time.ToString("yyyy-MM-dd HH:mm");
            temperInit();
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void temperInit()
        {
            this.ppcPreview.Document = pdDocument;
            this.pd.Document = pdDocument;
            this.pd.AllowSomePages = true;
            this.pd.ShowHelp = true;
            this.pd.UseEXDialog = true;
            this.pdDocument.DefaultPageSettings.Margins.Left = 38;//38
            this.pdDocument.DefaultPageSettings.Margins.Top = 78;  //78
            this.pdDocument.DefaultPageSettings.Landscape = false;
            this.pdDocument.OriginAtMargins = true;
            Type type = typeof(System.Windows.Forms.PrintPreviewControl);
            m_Position = type.GetField("position", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            m_SetPositionMethod = type.GetMethod("SetPositionNoInvalidate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            ppcPreview.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);
            ppcPreview.Click += new EventHandler(ppcPreview_Click);
            ppcPreview.MouseDown += new MouseEventHandler(ppcPreview_MouseDown);
            ppcPreview.MouseUp += new MouseEventHandler(ppcPreview_MouseUp);
            ppcPreview.MouseMove += new MouseEventHandler(ppcPreview_MouseMove);
            pdDocument.PrintPage += new PrintPageEventHandler(pdDocument_PrintPage);
            foreach (PaperSize _papersize in this.pdDocument.PrinterSettings.PaperSizes)
            {
                if (_papersize.PaperName == "A4")
                {
                    pdDocument.DefaultPageSettings.PaperSize = _papersize;
                    break;
                }
            }
            this.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);

            loadTree();
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        int index = 0;              //��ӡ�ڼ�ҳ
        private bool isAll = false; //�Ƿ�ȫ����ӡ
        /// <summary>
        /// ��ӡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (id != "")
                {
                    e.Graphics.ScaleTransform(1f, 0.97f);
                    if (isAll)
                    {//��ʾȫ��
                        ph.PageIndex = index + 1;
                        ph.User["���:"] = TemperatureMethod.GetDiagnose(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
                        ph.User["����:"] = TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
                        ph.User["����:"] = TemperatureMethod.GetBedNo(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
                    
                        StarToEndTime(this.tvTimes.Nodes[index].Text);
  
                        ph.printMain(startTime, endTime);

                        index++;
                        if (index == this.tvTimes.Nodes.Count - 1)
                        {
                            e.HasMorePages = false;
                            index = 0;
                        }
                        else
                        {
                            e.HasMorePages = true;
                        }
                    }
                    else
                    {
                        ph.User["���:"] = TemperatureMethod.GetDiagnose(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
                        ph.User["����:"] = TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
                        ph.User["����:"] = TemperatureMethod.GetBedNo(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
                    

                        ph.printMain(startTime, endTime);

                    }
                }

                if (ph.currentpage.Objs.Count == 0)
                {
                    pt.TemperturePaintInterface(e.Graphics, null);
                }
                else
                {
                    pt.TemperturePaintInterface(e.Graphics, ph.currentpage);
                }
            }
            catch
            {
                MessageBoxEx.Show("�����쳣��û�а�װ��ӡ��");
            }
        }


        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Node select = this.tvTimes.SelectedNode;
                if (select != null)
                {
                    if (select.Text == "��ʾȫ��")
                    {
                        if (MessageBox.Show("ȷ��Ҫ��ӡȫ�����µ���?", "��ܰ��ʾ!"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    this.pdDocument.Print();
                }
            }
            catch (Exception)
            {
                App.Msg("��ӡ���쳣��");
            }
        }


        /// <summary>
        /// ����ʱ����Ŀ
        /// </summary>
        public void loadTree()
        {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            DataTable dt = null;
            if (this.isChild)
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM t_child_vital_signs T WHERE T.DESCRIBE like '%��Ժ%' AND patient_id = '{0}' ORDER BY MEASURE_TIME DESC", this.id)).Tables[0];
            }
            else
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM T_VITAL_SIGNS T WHERE (T.DESCRIBE like '%��Ժ%' OR T.DESCRIBE like '%����%') AND patient_id = '{0}' ORDER BY MEASURE_TIME", this.id)).Tables[0];
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
                Node tn = new Node();
                tn.Text = temper;
                this.tvTimes.Nodes.Add(tn);
                temper = "";
            }
            string tempString = tvTimes.Nodes[tvTimes.Nodes.Count - 1].Text.ToString();
            StarToEndTime(tempString);

            ph.PageIndex = tvTimes.Nodes.Count;
            ph.User["���:"] = TemperatureMethod.GetDiagnose(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
            ph.User["����:"] = TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));
            ph.User["����:"] = TemperatureMethod.GetBedNo(this.id, ph.PageIndex.ToString(), Convert.ToDateTime(startTime), Convert.ToDateTime(endTime)); 

            Node de = new Node();
            de.Text = "��ʾȫ��";
            this.tvTimes.Nodes.Add(de);
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

            ph.currentpage.Objs = new List<ClsDataObj>();
            ph.currentpage.Starttime = startTime + " 00:00:00";
            ph.currentpage.Endtime = endTime + " 23:59:59";
        }

        /// <summary>
        /// ���ڵ� ѡ���ӡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimes_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Node selectNode = this.tvTimes.SelectedNode;
            if (selectNode != null && this.tvTimes.Nodes.Count > 1)
            {
                if (selectNode.Text == "��ʾȫ��")
                {
                    this.isAll = true;
                    this.ppcPreview.Rows = this.tvTimes.Nodes.Count - 1;
                    this.pdDocument.DocumentName = (this.tvTimes.Nodes.Count - 1).ToString();
                }
                else
                {
                    this.isAll = false;
                    string tempString = selectNode.Text;
                    StarToEndTime(tempString);

                    ph.PageIndex = selectNode.Index + 1;
 
                    this.ppcPreview.Rows = 1;
                    this.pdDocument.DocumentName = "1";
                    txtIndex.Text = (selectNode.Index + 1).ToString();
                }
                this.ppcPreview.InvalidatePreview();
            }
        }

        /// <summary>       
        /// ������       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        void ppcPreview_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!SystemInformation.MouseWheelPresent)
            {
                //If have no wheel       
                return;
            }
            int scrollAmount;
            float amount = Math.Abs(e.Delta) / SystemInformation.MouseWheelScrollDelta;
            amount *= SystemInformation.MouseWheelScrollLines;
            amount *= 12;//Row height       
            amount *= (float)ppcPreview.Zoom;//Zoom Rate       
            if (e.Delta < 0)
            {
                scrollAmount = (int)amount;
            }
            else
            {
                scrollAmount = -(int)amount;
            }
            Point curPos = (Point)(m_Position.GetValue(ppcPreview));
            m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + 0, curPos.Y + scrollAmount) });
        }

        /// <summary>       
        /// ����ڿؼ��ϵ��ʱ����Ҫ�����ý��㣬��ΪĬ�ϲ����ý���       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_Click(object sender, EventArgs e)
        {
            ppcPreview.Select();
            ppcPreview.Focus();
        }

        /// <summary>       
        /// ��갴�£���ʼ�϶�       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            startPosition = new Point(e.X, e.Y);
            curPos = (Point)(m_Position.GetValue(ppcPreview));
        }

        /// <summary>       
        /// ����ͷţ�����϶�       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            endPosition = new Point(e.X, e.Y);
            m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + (startPosition.X - endPosition.X), curPos.Y + (startPosition.Y - endPosition.Y)) });
        }

        /// <summary>       
        /// ����ƶ����϶���       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                endPosition = new Point(e.X, e.Y);
                m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + (startPosition.X - endPosition.X), curPos.Y + (startPosition.Y - endPosition.Y)) });
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider1_ValueChanged(object sender, EventArgs e)
        {
            this.ppcPreview.Zoom = float.Parse(this.slider1.Value.ToString("#0.0")) / 10;
        }

        private void ucTemperPrint_Load(object sender, EventArgs e)
        {
            txtIndex.Text = "1";//ҳ���ʼ��
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIndex.Text) > 1)
            {
                this.txtIndex.Text = (Convert.ToInt32(txtIndex.Text) - 1).ToString();
                this.tvTimes.SelectedNode = this.tvTimes.Nodes[Convert.ToInt32(txtIndex.Text) - 1];

            }
            else
            {
                App.Msg("�Ѿ��ǵ�һҳ��");
            }
            this.tvTimes.Focus();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIndex.Text) < tvTimes.Nodes.Count)
            {
                this.tvTimes.SelectedNode = this.tvTimes.Nodes[Convert.ToInt32(txtIndex.Text)];
            }
            else
            {
                App.Msg("�Ѿ������һҳ��");
            }

            this.tvTimes.Focus();

        }

        public int pageCount
        {
            get { return this.tvTimes.Nodes.Count - 1; }
        }

        /// <summary>
        /// ��ӡȫ�����µ�
        /// </summary>
        public int PrintTemper()
        {
            try
            {
                if (this.tvTimes.Nodes.Count > 1)
                {
                    this.isAll = true;
                    this.ppcPreview.Rows = this.tvTimes.Nodes.Count - 1;
                    this.pdDocument.DocumentName = (this.tvTimes.Nodes.Count - 1).ToString();
                    this.ppcPreview.InvalidatePreview();
                    this.pdDocument.Print();
                }
                return this.tvTimes.Nodes.Count - 1;
            }
            catch
            {
                return 0;
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
        


    }
}
