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
        PrintTp pt = new PrintTp(); //体温单的绘制对象
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
        private string startDate;   //开始日期
        private string endDate;     //结束日期
        private bool isChild = false;
        private const string _txtDisplayAllNode = "显示全部";

        PrintDialog pd = new PrintDialog();
        private InPatientInfo pat;
        string tfilename;
        private Page currentPage=new Page();

        private List<DataTable> dbList = null; //数据集合
        private DateTime? outTime = null;
        private string id;      //病人主键patient_id 

        /// <summary>
        /// 普通体温单打印构造函数
        /// </summary>                
        public ucTemperPrintDataLoad_child(InPatientInfo info,string templatefilename)
        {
            InitializeComponent();
            cm.startini(templatefilename); //体温单初始化;
            pt.cm = cm;
            pat = info;
            id = pat.Id.ToString();
            this.in_date = info.In_Time.ToString("yyyy-MM-dd HH:mm");
            temperInit();

            


        }

        /// <summary>
        /// 初始化
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
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        int index = 0;              //打印第几页
        private bool isAll = false; //是否全部打印
        /// <summary>
        /// 打印函数
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
                        //初始化一周体温单的开始和结束时间this.startDate, this.endDate
                        panel1.AutoScrollPosition = new Point(0, 0);
                        string tempString = selectNode.Text;
                        StarToEndTime(tempString);

                        currentPage.Objs = new List<ClsDataObj>();
                        currentPage.Starttime = startDate + " 00:00:00";
                        currentPage.Endtime = endDate + " 23:59:59";

                        //模板赋值
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
                MessageBoxEx.Show("数据异常或没有安装打印机");
            }
        }


        /// <summary>
        /// 打印
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
                        if (MessageBox.Show("确定要打印全部体温单吗?", "温馨提示!"
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
                App.Msg("打印机异常！");
            }
        }


        /// <summary>
        /// 加载时间项目
        /// </summary>
        public void loadTree()
        {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = App.GetDataSet(string.Format("select aa.VALTYPE_TIME from t_temperature_record aa where " +
                  "aa.valtype ='操作事件' and (aa.t_val like '出院%' or aa.t_val like '死亡%') and patient_id={0} and template_type='{1}'  order by aa.VALTYPE_TIME asc", pat.Id.ToString(), tempetureDataComm.TEMPLATE_CHILD)).Tables[0];

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
                temper = "第" + (i + 1).ToString() + "页(" + inDatetime.AddDays(i * dayCountPerWeek).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * dayCountPerWeek + dayCountPerWeek - 1).ToString("yyyy-MM-dd") + ")";

                Node tempnode = new Node();
                tempnode.Text = temper;
                tempnode.Name = i.ToString();
                tempnode.Tag = (i + 1).ToString();
                this.tvTimes.Nodes.Add(tempnode);
                temper = "";
            }
            //添加显示全部
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
        /// 设置开始时间 结束时间
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
        /// 树节点 选择打印日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimes_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Node selectNode = this.tvTimes.SelectedNode;
            if (selectNode != null)
            {
                panel1.AutoScrollPosition = new Point(0, 0);

                if (selectNode.Text == _txtDisplayAllNode)  //显示全部
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
                    //初始化一周体温单的开始和结束时间this.startDate, this.endDate
                    string tempString = selectNode.Text;
                    StarToEndTime(tempString);

                    currentPage.Objs = new List<ClsDataObj>();
                    currentPage.Starttime = startDate + " 00:00:00";
                    currentPage.Endtime = endDate + " 23:59:59";

                    //模板赋值
                    tempetureDataComm.GetPageContentByPageObj_child(pat, ref currentPage, selectNode.Tag.ToString(), outTime, ref cm);
                }
                txtIndex.Enabled = btn_up.Enabled = btn_next.Enabled = label1.Enabled = label4.Enabled = !isAll;
                txtIndex.Visible = btn_up.Visible = btn_next.Visible = label1.Visible = label4.Visible = !isAll;
                this.ppcPreview.InvalidatePreview();
            }
        }

        /// <summary>       
        /// 鼠标滚轮       
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
        /// 鼠标在控件上点击时，需要处理获得焦点，因为默认不会获得焦点       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_Click(object sender, EventArgs e)
        {
            ppcPreview.Select();
            ppcPreview.Focus();
        }

        /// <summary>       
        /// 鼠标按下，开始拖动       
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
        /// 鼠标释放，完成拖动       
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
        /// 鼠标移动，拖动中       
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
        /// 缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider1_ValueChanged(object sender, EventArgs e)
        {
            this.ppcPreview.Zoom = float.Parse(this.slider1.Value.ToString("#0.0")) / 10;
        }

        private void ucTemperPrint_Load(object sender, EventArgs e)
        {
            txtIndex.Text = "1";//页码初始化
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
                App.Msg("已经是第一页！");
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
                App.Msg("已经是最后一页！");
            }

            this.tvTimes.Focus();

        }

        public int pageCount
        {
            get { return this.tvTimes.Nodes.Count - 1; }
        }

        /// <summary>
        /// 打印全部体温单
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
        /// 只允许输入数字
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

