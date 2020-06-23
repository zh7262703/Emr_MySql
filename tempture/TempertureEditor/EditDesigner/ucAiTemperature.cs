using Bifrost;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.EditDesigner.tlElement;
using TempertureEditor.Element;

namespace TempertureEditor.EditDesigner
{
    partial class ucAiTemperature : UserControl
    {
        #region 公共变量、公共方法、控件事件

        private string _clmbFileName = "";

        protected delegate void EventSubHandler(Control sender, params Control[] controls); //sender--消息处理控件,controls-关联参数控件
        private Dictionary<string, EventSubHandler> dicEventHandlers = new Dictionary<string, EventSubHandler>();
        private Dictionary<string, EventSubHandler> dicCustomEventHandlers = new Dictionary<string, EventSubHandler>();
        protected List<Control> listWinControls = new List<Control>();
        protected ParsingFileCLMB _clmb = new ParsingFileCLMB();

        public ParsingFileCLMB Clmb
        {
            get
            {
                return _clmb;
            }
        }

        private InPatientInfo tPatInfo = null;

        Page currentPage = new Page();

        public string startDate;
        public string endDate;
        private string _templateType = "";
        public DateTime? outTime = null;           //根据出院等自动生成事件，生成当前出院时间
        public int pageSelectedIndex = -1;
        private DateTime SelectTime;//当前日期
        private string Operater_end_time = "";     //手术结束时间

        #region 质控用到的变量
        const string operater_type = "术前";
        const string operater_types = "术后";

        private List<string> listOldOptStartTime = new List<string>();    //手术开始时间yyyy-MM-dd HH:mm
        private string oldOptOEndtime;      //手术结束时间yyyy-MM-dd HH:mm
        #endregion
        public string TemplateType
        {
            get
            {
                return _templateType;
            }

            set
            {
                _templateType = value;
            }
        }

        #region UserControl重写函数
        private bool bTabDirection = true; //tab键方向
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

        #endregion
        #region 组件设计器生成的代码
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
        #endregion

        public ucAiTemperature(string clmbFileName)
        {
            _clmbFileName = App.SysPath + "\\" + clmbFileName;
            _clmb.ParsingXml(_clmbFileName);

            #region 注册控件和自定义接口
            dicEventHandlers.Clear();
            dicCustomEventHandlers.Clear();
            // 先注册所有的大模块事件处理接口,否则clmb模块配置不起作用
            RegisterCustomEventHandler("Register_ucMainFrame", Register_ucMainFrame);
            RegisterCustomEventHandler("Register_ucTemperatureFrame", Register_ucTemperatureFrame);
            RegisterCustomEventHandler("Register_ucTemperaturePrintFrame", Register_ucTemperaturePrintFrame);
            RegisterCustomEventHandler("Register_ucTemperatureLrToolBar", Register_ucTemperatureLrToolBar);

            // 根据clmb文件注册相应的子模块事件处理接口
            ucAiTemperatureCustomEventHnadler("MSG_RegisterEventHandler");
            #endregion

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            //创建子控件
            CreateWinControls(this);

            // Load事件
            this.Load += new EventHandler(ucAiTemperature_Load);

        }

        protected bool RegisterEventSubHandler(string iName, EventSubHandler hEvent)
        {
            if (!dicEventHandlers.ContainsKey(iName))
            {
                dicEventHandlers.Add(iName, hEvent);
                return true;
            }
            return false;
        }

        protected bool RegisterCustomEventHandler(string iName, EventSubHandler hEvent)
        {
            if (!dicCustomEventHandlers.ContainsKey(iName))
            {
                dicCustomEventHandlers.Add(iName, hEvent);
                return true;
            }
            return false;
        }

        #region 第1种实现方式
        /*
 public void CreateWinControls(Control dockWinControl)
 {
     dockWinControl.SuspendLayout();
     listWinControls.Clear();
     string type;
     foreach (TlControl tlControl in _clmb.listTlControls)
     {
         Control winControl = null;
         type = tlControl.Type;

         if (type == "GroupBox")
         {
             winControl = new GroupBox();
             winControl.SuspendLayout();

             ((GroupBox)winControl).ForeColor = ((TlGroupBox)tlControl).ForeColor;
             ((GroupBox)winControl).Text = ((TlGroupBox)tlControl).Text;
         }
         else if (type == "Label")
         {
             winControl = new Label();

             ((Label)winControl).ForeColor = ((TlLabel)tlControl).ForeColor;
             ((Label)winControl).AutoSize = ((TlLabel)tlControl).AutoSize;
             ((Label)winControl).Text = ((TlLabel)tlControl).Text;
         }
         else if (type == "ComboBox")
         {
             winControl = new ComboBox();

             ((ComboBox)winControl).DropDownStyle = (ComboBoxStyle)((TlComboBox)tlControl).DropDownStyle;
             ((ComboBox)winControl).Items.AddRange(((TlComboBox)tlControl).ListItems.ToArray());

         }
         else if (type == "TextBox")
         {
             winControl = new TextBox();
         }
         else if (type == "Button")
         {
             winControl = new Button();
             ((Button)winControl).Text = ((TlButton)tlControl).Text;
         }
         else if (type == "CheckBox")
         {
             winControl = new CheckBox();

             ((CheckBox)winControl).ForeColor = ((TlCheckBox)tlControl).ForeColor;
             ((CheckBox)winControl).AutoSize = ((TlCheckBox)tlControl).AutoSize;
             ((CheckBox)winControl).Text = ((TlCheckBox)tlControl).Text;
         }
         else if (type == "ListBox")
         {
             winControl = new ListBox();
         }
         else if (type == "Panel")
         {
             winControl = new Panel();
             winControl.SuspendLayout();
         }
         else if (type == "DateTimePicker")
         {
             winControl = new DateTimePicker();

             ((DateTimePicker)winControl).ShowUpDown = ((TlDateTimePicker)tlControl).ShowUpDown;
             ((DateTimePicker)winControl).Format = (DateTimePickerFormat)((TlDateTimePicker)tlControl).Format;
             ((DateTimePicker)winControl).CustomFormat = ((TlDateTimePicker)tlControl).CustomFormat;
         }

         if (winControl != null)
         {                   
             winControl.Name = tlControl.Name;
             winControl.Location = new Point(tlControl.X, tlControl.Y);
             winControl.Size = new Size(tlControl.Width, tlControl.Height);
             winControl.TabIndex = tlControl.TabIndex;
             winControl.Visible = tlControl.Visable;
             winControl.Enabled = tlControl.Enable;
             winControl.TabStop = tlControl.TabStop;
             winControl.Dock = (DockStyle)tlControl.Dock;

             foreach (TlFont tlFont in listTlFonts)
             {
                 if (tlControl.FontName == tlFont.Name)
                 {
                     winControl.Font = new Font(tlFont.FamilyName, tlFont.EmSize, (FontStyle)tlFont.Style);
                     break;
                 }
             }

             listWinControls.Add(winControl);

         }
     }

     //遍历处理控件Controls.Add();
     foreach (Control winControl in listWinControls)
     {
         foreach (TlControl tlControl in _clmb.listTlControls)
         {
             if (winControl.Name == tlControl.Name)
             {
                 foreach (Control winParentControl in listWinControls)
                 {
                     if (tlControl.TlParentControl == null)
                     {
                         if (!dockWinControl.Controls.Contains(winControl))
                         {
                             dockWinControl.Controls.Add(winControl);
                         }
                         break;
                     }
                     else if (winParentControl.Name == tlControl.TlParentControl.Name)
                     {
                         winParentControl.Controls.Add(winControl);
                         break;
                     }
                 }
                 break;
             }
         }
     }


     foreach (Control winControl in listWinControls)
     {
         foreach (TlControl tlControl in _clmb.listTlControls)
         {
             if (winControl.Name == tlControl.Name)
             {
                 if (tlControl.Type == "Panel" || tlControl.Type == "GroupBox")
                 {
                     winControl.ResumeLayout(true);
                     break;
                 }
             }
         }
     }
     dockWinControl.ResumeLayout(false);
 }
 */
        #endregion

        #region 第2种实现方式, 要求:listTlControlst和listWinControls一一对应,效率更高
        public void CreateWinControls(Control dockWinControl)
        {
            //dockWinControl.SuspendLayout();
            listWinControls.Clear();
            string type;
            for (int i = 0; i < _clmb.listTlControls.Count; i++)
            {
                Control winControl = null;
                type = _clmb.listTlControls[i].Type;

                if (type == "GroupBox")
                {
                    winControl = new GroupBox();
                    //winControl.SuspendLayout();

                    ((GroupBox)winControl).ForeColor = ((TlGroupBox)_clmb.listTlControls[i]).ForeColor;
                    // ((GroupBox)winControl).Text = ((TlGroupBox)_clmb.listTlControls[i]).Text;
                }
                else if (type == "Label")
                {
                    winControl = new Label();

                    ((Label)winControl).ForeColor = ((TlLabel)_clmb.listTlControls[i]).ForeColor;
                    ((Label)winControl).AutoSize = ((TlLabel)_clmb.listTlControls[i]).AutoSize;
                    // ((Label)winControl).Text = ((TlLabel)_clmb.listTlControls[i]).Text;
                }
                else if (type == "ComboBox")
                {
                    winControl = new ComboBox();

                    ((ComboBox)winControl).DropDownStyle = (ComboBoxStyle)((TlComboBox)_clmb.listTlControls[i]).DropDownStyle;
                    ((ComboBox)winControl).Items.AddRange(((TlComboBox)_clmb.listTlControls[i]).ListItems.ToArray());

                    if (_clmb.listTlControls[i].DicEvents.ContainsKey("SelectedIndexChanged"))
                    {
                        ((ComboBox)winControl).SelectedIndexChanged += new EventHandler(controlEvent_SelectedIndexChanged);
                    }
                }
                else if (type == "TextBox")
                {
                    winControl = new TextBox();

                }
                else if (type == "Button")
                {
                    winControl = new Button();

                }
                else if (type == "ButtonX")
                {
                    winControl = new DevComponents.DotNetBar.ButtonX();

                    if (((TlButtonX)_clmb.listTlControls[i]).Image != "")
                    {
                        ((DevComponents.DotNetBar.ButtonX)winControl).Image = (System.Drawing.Bitmap)(global::TempertureEditor.Properties.Resources.ResourceManager.GetObject(((TlButtonX)_clmb.listTlControls[i]).Image, global::TempertureEditor.Properties.Resources.Culture));
                    }

                    ((DevComponents.DotNetBar.ButtonX)winControl).AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
                    ((DevComponents.DotNetBar.ButtonX)winControl).ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
                }
                else if (type == "PrintPreviewControl")
                {
                    winControl = new PrintPreviewControl();

                    ((PrintPreviewControl)winControl).UseAntiAlias = true;
                    ((PrintPreviewControl)winControl).AutoZoom = false;
                    ((PrintPreviewControl)winControl).Zoom = 1D;
                }
                else if (type == "CheckBox")
                {
                    winControl = new CheckBox();

                    ((CheckBox)winControl).ForeColor = ((TlCheckBox)_clmb.listTlControls[i]).ForeColor;
                    ((CheckBox)winControl).AutoSize = ((TlCheckBox)_clmb.listTlControls[i]).AutoSize;
                    ((CheckBox)winControl).Text = ((TlCheckBox)_clmb.listTlControls[i]).Text;
                    ((CheckBox)winControl).Checked = ((TlCheckBox)_clmb.listTlControls[i]).Checked;

                    ((CheckBox)winControl).CheckedChanged += new EventHandler(controlEvent_CheckedChanged);
                    ((CheckBox)winControl).CheckStateChanged += new EventHandler(controlEvent_CheckStateChanged);
                }
                else if (type == "RadioButton")
                {
                    winControl = new RadioButton();

                    ((RadioButton)winControl).ForeColor = ((TlRadioButton)_clmb.listTlControls[i]).ForeColor;
                    ((RadioButton)winControl).AutoSize = ((TlRadioButton)_clmb.listTlControls[i]).AutoSize;
                    // ((RadioButton)winControl).Text = ((TlRadioButton)_clmb.listTlControls[i]).Text;
                    ((RadioButton)winControl).UseVisualStyleBackColor = ((TlRadioButton)_clmb.listTlControls[i]).UseVisualStyleBackColor;
                    ((RadioButton)winControl).Checked = ((TlRadioButton)_clmb.listTlControls[i]).Checked;

                    ((RadioButton)winControl).CheckedChanged += new EventHandler(controlEvent_CheckedChanged);
                }
                else if (type == "ListBox")
                {
                    winControl = new ListBox();
                }
                else if (type == "Panel" || type == "PanelControl" || type == "GroupPanel")
                {
                    if (type == "Panel")
                    {
                        winControl = new Panel();
                    }
                    else
                    {
                        if (type == "PanelControl")
                        {
                            winControl = new PanelControl();
                        }
                        else
                        {
                            if (type == "GroupPanel")
                            {
                                winControl = new GroupPanel();
                            }
                            else
                            {

                            }
                        }
                        #region 未实现配置样式
                        ((PanelControl)winControl).Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
                        ((PanelControl)winControl).Style.BackColorGradientAngle = 90;
                        ((PanelControl)winControl).Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
                        ((PanelControl)winControl).Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
                        ((PanelControl)winControl).Style.BorderBottomWidth = 1;
                        ((PanelControl)winControl).Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
                        ((PanelControl)winControl).Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
                        ((PanelControl)winControl).Style.BorderLeftWidth = 1;
                        ((PanelControl)winControl).Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
                        ((PanelControl)winControl).Style.BorderRightWidth = 1;
                        ((PanelControl)winControl).Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
                        ((PanelControl)winControl).Style.BorderTopWidth = 1;
                        ((PanelControl)winControl).Style.CornerDiameter = 4;
                        ((PanelControl)winControl).Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
                        ((PanelControl)winControl).Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
                        ((PanelControl)winControl).Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
                        ((PanelControl)winControl).Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
                        ((PanelControl)winControl).StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                        ((PanelControl)winControl).StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                        #endregion

                        ((PanelControl)winControl).ShowFocusRectangle = ((TlPanelControl)_clmb.listTlControls[i]).ShowFocusRectangle;
                        ((PanelControl)winControl).ColorSchemeStyle = (eDotNetBarStyle)((TlPanelControl)_clmb.listTlControls[i]).ColorSchemeStyle;
                        ((PanelControl)winControl).CanvasColor = ((TlPanelControl)_clmb.listTlControls[i]).CanvasColor;
                    }
                    ((Panel)winControl).AutoScroll = ((TlPanel)_clmb.listTlControls[i]).AutoScroll;
                }
                else if (type == "DateTimePicker")
                {
                    winControl = new DateTimePicker();

                    ((DateTimePicker)winControl).ShowUpDown = ((TlDateTimePicker)_clmb.listTlControls[i]).ShowUpDown;
                    ((DateTimePicker)winControl).Format = (DateTimePickerFormat)((TlDateTimePicker)_clmb.listTlControls[i]).Format;
                    ((DateTimePicker)winControl).CustomFormat = ((TlDateTimePicker)_clmb.listTlControls[i]).CustomFormat;

                    if (_clmb.listTlControls[i].DicEvents.ContainsKey("ValueChanged"))
                    {
                        ((DateTimePicker)winControl).ValueChanged += new EventHandler(controlEvent_ValueChanged);
                    }
                }
                else if (type == "PictureBox")
                {
                    winControl = new PictureBox();
                    ((PictureBox)winControl).BackColor = ((TlPictureBox)_clmb.listTlControls[i]).BackColor;
                }
                else if (type == "ExpandableSplitter")
                {
                    winControl = new DevComponents.DotNetBar.ExpandableSplitter();
                    ((DevComponents.DotNetBar.ExpandableSplitter)winControl).Style = (DevComponents.DotNetBar.eSplitterStyle)((TlExpandableSplitter)_clmb.listTlControls[i]).Style;
                }
                else if (type == "AdvTree")
                {
                    winControl = new DevComponents.AdvTree.AdvTree();
                    ((DevComponents.AdvTree.AdvTree)winControl).ForeColor = ((TlAdvTree)_clmb.listTlControls[i]).ForeColor;
                    ((DevComponents.AdvTree.AdvTree)winControl).AllowDrop = ((TlAdvTree)_clmb.listTlControls[i]).AllowDrop;

                    ((DevComponents.AdvTree.AdvTree)winControl).AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
                    ((DevComponents.AdvTree.AdvTree)winControl).BackgroundStyle.Class = "TreeBorderKey";
                    ((DevComponents.AdvTree.AdvTree)winControl).BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    ((DevComponents.AdvTree.AdvTree)winControl).NodeSpacing = 2;
                    ((DevComponents.AdvTree.AdvTree)winControl).PathSeparator = ";";
                }
                else if (type == "Slider")
                {
                    winControl = new DevComponents.DotNetBar.Controls.Slider();
                    ((DevComponents.DotNetBar.Controls.Slider)winControl).Minimum = ((TlSlider)_clmb.listTlControls[i]).Minimum;
                    ((DevComponents.DotNetBar.Controls.Slider)winControl).Maximum = ((TlSlider)_clmb.listTlControls[i]).Maximum;
                    ((DevComponents.DotNetBar.Controls.Slider)winControl).Value = ((TlSlider)_clmb.listTlControls[i]).Value;

                    ((DevComponents.DotNetBar.Controls.Slider)winControl).BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    ((DevComponents.DotNetBar.Controls.Slider)winControl).Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                }
                else if (type == "ucAiTemperature")
                {
                    winControl = new ucAiTemperature(((TlAiTemperature)_clmb.listTlControls[i]).ClmbFileName);
                }
                /*
                else if (type == "ucTemperatureFrame")
                {
                    winControl = new ucTemperatureFrame(((TlAiTemperature)_clmb.listTlControls[i]).ClmbFileName);
                }
                */
                else if (type == "ucTemperatureReport")
                {
                    winControl = new ucTemperatureReport(((TlTemperatureReport)_clmb.listTlControls[i]).TmbFileName);
                }
                else if (type == "RibbonBar")
                {
                    winControl = new RibbonBar();
                    ((RibbonBar)winControl).Style = (eDotNetBarStyle)((TlRibbonBar)_clmb.listTlControls[i]).Style;
                    ((RibbonBar)winControl).TitleVisible = ((TlRibbonBar)_clmb.listTlControls[i]).TitleVisible;
                    ((RibbonBar)winControl).AutoOverflowEnabled = ((TlRibbonBar)_clmb.listTlControls[i]).AutoOverflowEnabled;
                    ((RibbonBar)winControl).ContainerControlProcessDialogKey = ((TlRibbonBar)_clmb.listTlControls[i]).ContainerControlProcessDialogKey;
                }

                if (winControl != null)
                {
                    if (_clmb.listTlControls[i].BackColor != null)
                    {
                        winControl.BackColor = (Color)_clmb.listTlControls[i].BackColor;
                    }
                    winControl.Name = _clmb.listTlControls[i].Name;
                    winControl.Location = new Point(_clmb.listTlControls[i].X, _clmb.listTlControls[i].Y);
                    winControl.Size = new Size(_clmb.listTlControls[i].Width, _clmb.listTlControls[i].Height);
                    winControl.TabIndex = _clmb.listTlControls[i].TabIndex;
                    winControl.Visible = _clmb.listTlControls[i].Visable;
                    winControl.Enabled = _clmb.listTlControls[i].Enable;
                    winControl.TabStop = _clmb.listTlControls[i].TabStop;
                    foreach (TlFont tlFont in _clmb.listTlFonts)
                    {
                        if (_clmb.listTlControls[i].FontName == tlFont.Name)
                        {
                            winControl.Font = new Font(tlFont.FamilyName, tlFont.EmSize, (FontStyle)tlFont.Style);
                            break;
                        }
                    }
                    winControl.Dock = (DockStyle)_clmb.listTlControls[i].Dock;
                    winControl.Text = _clmb.listTlControls[i].Text;

                    // 注: 不能使用if/else,因为同个控件可能要处理多个事件
                    if (_clmb.listTlControls[i].DicEvents.ContainsKey("Click"))
                    {
                        winControl.Click += new EventHandler(controlEvent_Click);
                    }

                    if (_clmb.listTlControls[i].DicEvents.ContainsKey("TextChanged"))
                    {
                        winControl.TextChanged += new EventHandler(controlEvent_TextChanged);
                    }

                    if (_clmb.listTlControls[i].DicEvents.ContainsKey("SizeChanged"))
                    {
                        winControl.SizeChanged += new EventHandler(controlEvent_SizeChanged);
                    }


                    listWinControls.Add(winControl);
                }
            }

            //特殊类型处理,需在所有控件创建后处理
            for (int i = 0; i < _clmb.listTlControls.Count; i++)
            {
                if (_clmb.listTlControls[i].Type == "ExpandableSplitter")
                {
                    ((DevComponents.DotNetBar.ExpandableSplitter)listWinControls[i]).ExpandableControl = listWinControls.Find(cl => cl.Name == ((TlExpandableSplitter)_clmb.listTlControls[i]).ExpandableControl); //等同以下注释代码功能

                    /*
                    foreach (Control tmpControl in listWinControls)
                    {
                        if (tmpControl.Name == ((TlExpandableSplitter)_clmb.listTlControls[i]).ExpandableControl)
                        {
                            ((DevComponents.DotNetBar.ExpandableSplitter)listWinControls[i]).ExpandableControl = tmpControl;
                            break;
                        }
                    }
                    */
                }
                /*
                if (_clmb.listTlControls[i].Type == "RibbonBar")
                {
                    foreach (string itemName in ((TlRibbonBar)_clmb.listTlControls[i]).ListItems)
                    {
                        Control findControl = listWinControls.Find(cl => cl.Name == itemName);
                        if (findControl != null)
                        {
                          //  ((RibbonBar)listWinControls[i]).Items.Add((BaseItem)findControl);


                         }
                    }
                }
                */
            }
            //遍历处理控件Controls.Add(); 当同一DockStyle时,如都为DockStyle.Top时,倒序Add才能按配置文件的正序展示
            for (int i = listWinControls.Count - 1; i >= 0; i--)
            {
                Control winControl = listWinControls[i];

                if (_clmb.listTlControls[i].TlParentControl == null)
                {
                    if (!dockWinControl.Controls.Contains(winControl))
                    {
                        dockWinControl.Controls.Add(winControl);
                    }
                }
                else
                {
                    foreach (Control winParentControl in listWinControls)
                    {
                        if (winParentControl.Name == _clmb.listTlControls[i].TlParentControl.Name)
                        {
                            winParentControl.Controls.Add(winControl);
                            break;
                        }
                    }
                }
            }

            /*
            for (int i = listWinControls.Count - 1; i >= 0 ; i--)
            {
                Control winControl = listWinControls[i];
                if (_clmb.listTlControls[i].Type == "Panel" || _clmb.listTlControls[i].Type == "GroupBox")
                {
                    winControl.ResumeLayout(true);
                    break;
                }
            }
            */
            //dockWinControl.ResumeLayout(false);

        }
        #endregion



        #region winform事件

        private void ucAiTemperature_Load(object sender, EventArgs e)
        {
            ucAiTemperatureCustomEventHnadler("MSG_Load");
        }

        private void controlEvent_Click(object sender, EventArgs e)
        {
            EventHnadler("Click", (Control)sender);
        }

        private void controlEvent_TextChanged(object sender, EventArgs e)
        {
            EventHnadler("TextChanged", (Control)sender);
        }

        private void controlEvent_SizeChanged(object sender, EventArgs e)
        {
            EventHnadler("SizeChanged", (Control)sender);
        }
        private void controlEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHnadler("SelectedIndexChanged", (Control)sender);
        }

        private void controlEvent_ValueChanged(object sender, EventArgs e)
        {
            EventHnadler("ValueChanged", (Control)sender);
        }

        private void controlEvent_CheckedChanged(object sender, EventArgs e)
        {
            EventHnadler("CheckedChanged", (Control)sender);
        }

        private void controlEvent_CheckStateChanged(object sender, EventArgs e)
        {
            EventHnadler("CheckStateChanged", (Control)sender);
        }
        #endregion

        #region winform控件事件处理
        private void EventHnadler(string eventName, Control winControl)
        {
            int index = listWinControls.IndexOf(winControl);
            if (index >= 0 && index < listWinControls.Count)
            {
                TlControl tlControl = _clmb.listTlControls[index];

                if (!tlControl.DicEvents.ContainsKey(eventName))
                {
                    // 当配置文件中的该控件未处理eventName对应的事件,直接跳过.
                    return;
                }
                string value = tlControl.DicEvents[eventName];
                int pos = value.IndexOf('(');
                if (pos >= 0)
                {
                    List<Control> listControls = new List<Control>();
                    string funName = value.Substring(0, pos);
                    string sFunParams = value.Substring(pos + 1, value.Length - pos - 2);//最后字符为')'
                    if (sFunParams != "")
                    {
                        string[] funParams = sFunParams.Split(',');
                        foreach (string funParam in funParams)
                        {
                            foreach (Control cl in listWinControls)
                            {
                                if (cl.Name == funParam.Trim())
                                {
                                    listControls.Add(cl);
                                    break;
                                }
                            }
                        }
                    }
                    if (dicEventHandlers.ContainsKey(funName))
                    {
                        dicEventHandlers[funName](winControl, listControls.ToArray());
                    }
                }
            }
        }
        #endregion

        #region ucAiTemperature自定义事件处理
        public void ucAiTemperatureCustomEventHnadler(string eventName)
        {
            if (!_clmb.dicCustomEventHandlers.ContainsKey(eventName))
            {
                // 当配置文件中的该自定义事件未处理eventName对应的事件,直接跳过.
                return;
            }
            string value = _clmb.dicCustomEventHandlers[eventName];
            int pos = value.IndexOf('(');
            if (pos >= 0)
            {
                List<Control> listControls = new List<Control>();
                string funName = value.Substring(0, pos);
                string sFunParams = value.Substring(pos + 1, value.Length - pos - 2);//最后字符为')'
                if (sFunParams != "")
                {
                    string[] funParams = sFunParams.Split(',');
                    foreach (string funParam in funParams)
                    {
                        foreach (Control cl in listWinControls)
                        {
                            if (cl.Name == funParam.Trim())
                            {
                                listControls.Add(cl);
                                break;
                            }
                        }
                    }
                }
                if (dicCustomEventHandlers.ContainsKey(funName))
                {
                    dicCustomEventHandlers[funName](this, listControls.ToArray());
                }
            }
        }
        #endregion
    }
}
