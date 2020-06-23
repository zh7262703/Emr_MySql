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
using TempertureEditor;
using TempertureEditor.Element;
using TempertureEditor.Tempreture_Management;
using System.Drawing.Drawing2D;

namespace TempertureEditor.Tempreture_Management
{
    public partial class ucTemperPrintDataLoad_child : UserControl
    {
        PrintTp pt = new PrintTp(); //���µ��Ļ��ƶ���
        Comm cm = new Comm();
        //printTemperDataLoad ph = new printTemperDataLoad();
        PrintDocument pdDocument = new PrintDocument();
        private FieldInfo m_Position;
        private MethodInfo m_SetPositionMethod;
        private bool isMouseDown;
        private Point startPosition;
        private Point endPosition;
        private Point curPos;

        private string in_date = string.Empty;     
        private string startDate;   //��ʼ����
        private string endDate;     //��������
        private bool isChild = false;
        private const string _txtDisplayAllNode = "��ʾȫ��";

        PrintDialog pd = new PrintDialog();
        private InPatientInfo pat;
        string tfilename;
        private Page currentPage=new Page();

        private List<DataTable> dbList = null; //���ݼ���
        private DateTime? outTime = null;
        private string id;      //��������patient_id 

        /// <summary>
        /// ��ͨ���µ���ӡ���캯��
        /// </summary>                
        public ucTemperPrintDataLoad_child(InPatientInfo info,string templatefilename)
        {
            InitializeComponent();
            cm.startini(templatefilename); //���µ���ʼ��;
            pt.cm = cm;
            pat = info;
            id = pat.Id.ToString();
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
            this.pdDocument.DefaultPageSettings.Margins.Left = 30;
            this.pdDocument.DefaultPageSettings.Margins.Top = 0;  //78
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
            ppcPreview.Refresh();

            if (tvTimes.Nodes.Count > 0)
                tvTimes.SelectedNode = tvTimes.Nodes[0];
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
                if (pat != null)
                {
                    // e.Graphics.ScaleTransform(1f, 0.97f);                   

                    if (isAll)
                    {
                        Node selectNode = this.tvTimes.Nodes[index];
                        //��ʼ��һ�����µ��Ŀ�ʼ�ͽ���ʱ��this.startDate, this.endDate
                        panel1.AutoScrollPosition = new Point(0, 0);
                        string tempString = selectNode.Text;
                        StarToEndTime(tempString);

                        currentPage.Objs = new List<ClsDataObj>();
                        currentPage.Starttime = startDate + " 00:00:00";
                        currentPage.Endtime = endDate + " 23:59:59";

                        //ģ�帳ֵ
                        tempetureDataComm.GetPageContentByPageObj_child(pat, ref currentPage, selectNode.Tag.ToString(), outTime, ref cm);
                        pt.TemperturePaintInterface(e.Graphics, currentPage);
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
                    }
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
                    if (select.Text == _txtDisplayAllNode)
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
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = App.GetDataSet(string.Format("select aa.VALTYPE_TIME from t_temperature_record aa where " +
                  "aa.valtype ='�����¼�' and (aa.t_val like '��Ժ%' or aa.t_val like '����%') and patient_id={0} and template_type='{1}'  order by aa.VALTYPE_TIME asc", pat.Id.ToString(), tempetureDataComm.TEMPLATE_CHILD)).Tables[0];

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
            this.tvTimes.Nodes.Clear();

            for (int i = 0; i < weekCount; i++)
            {
                temper = "��" + (i + 1).ToString() + "ҳ(" + inDatetime.AddDays(i * dayCountPerWeek).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * dayCountPerWeek + dayCountPerWeek - 1).ToString("yyyy-MM-dd") + ")";

                Node tempnode = new Node();
                tempnode.Text = temper;
                tempnode.Name = i.ToString();
                tempnode.Tag = (i + 1).ToString();
                this.tvTimes.Nodes.Add(tempnode);
                temper = "";
            }
            //�����ʾȫ��
            if (weekCount > 0)
            {
                Node displayallnode = new Node();
                displayallnode.Text = _txtDisplayAllNode;
                displayallnode.Name = weekCount.ToString();
                displayallnode.Tag = (weekCount + 1).ToString();
                this.tvTimes.Nodes.Add(displayallnode);
            }
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

            //ph.currentpage.Objs = new List<ClsDataObj>();
            //ph.currentpage.Starttime = startTime + " 00:00:00";
            //ph.currentpage.Endtime = endTime + " 23:59:59";
        }

        /// <summary>
        /// ���ڵ� ѡ���ӡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimes_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Node selectNode = this.tvTimes.SelectedNode;
            if (selectNode != null)
            {
                panel1.AutoScrollPosition = new Point(0, 0);

                if (selectNode.Text == _txtDisplayAllNode)  //��ʾȫ��
                {
                    isAll = true;
                    this.ppcPreview.Rows = this.tvTimes.Nodes.Count - 1;
                    this.pdDocument.DocumentName = (this.tvTimes.Nodes.Count - 1).ToString();
                }
                else
                {
                    isAll = false;
                    this.ppcPreview.Rows = 1;
                    this.pdDocument.DocumentName = selectNode.Tag.ToString();

                    txtIndex.Text = selectNode.Tag.ToString();
                    //��ʼ��һ�����µ��Ŀ�ʼ�ͽ���ʱ��this.startDate, this.endDate
                    string tempString = selectNode.Text;
                    StarToEndTime(tempString);

                    currentPage.Objs = new List<ClsDataObj>();
                    currentPage.Starttime = startDate + " 00:00:00";
                    currentPage.Endtime = endDate + " 23:59:59";

                    //ģ�帳ֵ
                    tempetureDataComm.GetPageContentByPageObj_child(pat, ref currentPage, selectNode.Tag.ToString(), outTime, ref cm);
                }
                txtIndex.Enabled = btn_up.Enabled = btn_next.Enabled = label1.Enabled = label4.Enabled = !isAll;
                txtIndex.Visible = btn_up.Visible = btn_next.Visible = label1.Visible = label4.Visible = !isAll;
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
               
                this.tvTimes.SelectedNode = this.tvTimes.Nodes[this.tvTimes.SelectedNode.Index - 1];
                this.txtIndex.Text = (Convert.ToInt32(this.tvTimes.SelectedNode.Index) + 1).ToString();

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
                this.txtIndex.Text = (Convert.ToInt32(this.tvTimes.SelectedNode.Index) + 1).ToString();
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

