using DevComponents.DotNetBar;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace BifrostMainPro
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //[DllImport("XEFORHIS.dll")]
        //public static extern bool XePacsRelease();

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);

                //XePacsRelease();
                KillProcess("PacsForEmr");
            }
            catch
            { }
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName">进程名</param>
        private void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName == processName)
                {
                    item.Kill();
                }
            }

        }


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ImageList imageList1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl_main = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.toolbar = new DevComponents.DotNetBar.RibbonBar();
            this.midebar = new DevComponents.DotNetBar.RibbonBar();
            this.tbtnReportBack = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnConsultationMide = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnQualityMide = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnDutySet = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnCommit = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnTempSave = new DevComponents.DotNetBar.ButtonItem();
            this.ttsbtnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnTemplateSave = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnSmallTemplateSave = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnTemplate = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnSectionAccountSets = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnAccountClear = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnPassword = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnRoleChose = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnResetSystem = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnMessageMide = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnGrade = new DevComponents.DotNetBar.ButtonItem();
            this.office2007StartButton2 = new DevComponents.DotNetBar.Office2007StartButton();
            this.btnToolSet = new DevComponents.DotNetBar.ButtonItem();
            this.AppCommandTheme = new DevComponents.DotNetBar.Command(this.components);
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem_Tools = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem14 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem28 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem29 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem30 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem31 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem15 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem32 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem33 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem34 = new DevComponents.DotNetBar.ButtonItem();
            this.lblUserInfo = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer6 = new DevComponents.DotNetBar.ItemContainer();
            this.Messagebar = new DevComponents.DotNetBar.Bar();
            this.toolStripLabel = new DevComponents.DotNetBar.LabelItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.系统的一些参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonItem16 = new DevComponents.DotNetBar.ButtonItem();
            this.tabControl_Main = new DevComponents.DotNetBar.TabControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsbtnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnBKSB = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnZLGF = new DevComponents.DotNetBar.ButtonItem();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonChangeStyle = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem68 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleMetro = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem69 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem70 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem71 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleCustom = new DevComponents.DotNetBar.ColorPickerDropDown();
            imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonControl_main.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Messagebar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl_Main)).BeginInit();
            this.tabControl_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.SetKeyName(0, "保存小模版.png");
            imageList1.Images.SetKeyName(1, "被授权文书操作.png");
            imageList1.Images.SetKeyName(2, "病案归档.png");
            imageList1.Images.SetKeyName(3, "病案借阅申请.png");
            imageList1.Images.SetKeyName(4, "病案整理.png");
            imageList1.Images.SetKeyName(5, "操作帮助.png");
            imageList1.Images.SetKeyName(6, "打印.png");
            imageList1.Images.SetKeyName(7, "打印知情同意书.png");
            imageList1.Images.SetKeyName(8, "归档退回申请.png");
            imageList1.Images.SetKeyName(9, "角色切换.png");
            imageList1.Images.SetKeyName(10, "密码修改.png");
            imageList1.Images.SetKeyName(11, "提交.png");
            imageList1.Images.SetKeyName(12, "系统注销.png");
            imageList1.Images.SetKeyName(13, "消息提醒.png");
            imageList1.Images.SetKeyName(14, "运行病历查阅.png");
            imageList1.Images.SetKeyName(15, "暂存.png");
            imageList1.Images.SetKeyName(16, "账号注销.png");
            imageList1.Images.SetKeyName(17, "质控提醒.png");
            imageList1.Images.SetKeyName(18, "消息提醒2.png");
            imageList1.Images.SetKeyName(19, "质控提醒2.png");
            // 
            // ribbonControl_main
            // 
            this.ribbonControl_main.AntiAlias = false;
            this.ribbonControl_main.AutoExpand = false;
            this.ribbonControl_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.ribbonControl_main.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl_main.CanCustomize = false;
            this.ribbonControl_main.CaptionVisible = true;
            this.ribbonControl_main.CausesValidation = false;
            this.ribbonControl_main.Controls.Add(this.ribbonPanel1);
            this.ribbonControl_main.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl_main.EnableQatPlacement = false;
            this.ribbonControl_main.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ribbonControl_main.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl_main.Images = imageList1;
            this.ribbonControl_main.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.office2007StartButton2,
            this.ribbonTabItem_Tools,
            this.buttonItem14,
            this.buttonItem15});
            this.ribbonControl_main.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl_main.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl_main.Name = "ribbonControl_main";
            this.ribbonControl_main.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblUserInfo});
            this.ribbonControl_main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ribbonControl_main.Size = new System.Drawing.Size(1150, 114);
            this.ribbonControl_main.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl_main.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl_main.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl_main.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl_main.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl_main.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl_main.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl_main.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl_main.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl_main.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl_main.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl_main.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl_main.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl_main.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl_main.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl_main.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl_main.TabGroupHeight = 14;
            this.ribbonControl_main.TabIndex = 1;
            this.ribbonControl_main.Text = "电子病历系统";
            this.ribbonControl_main.UseCustomizeDialog = false;
            this.ribbonControl_main.Click += new System.EventHandler(this.ribbonControl_main_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.AutoSize = true;
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.toolbar);
            this.ribbonPanel1.Controls.Add(this.midebar);
            this.ribbonPanel1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 56);
            this.ribbonPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.ribbonPanel1.Size = new System.Drawing.Size(1150, 58);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // toolbar
            // 
            this.toolbar.AutoOverflowEnabled = false;
            this.toolbar.AutoSizeItems = false;
            this.toolbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            // 
            // 
            // 
            this.toolbar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.toolbar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.toolbar.ContainerControlProcessDialogKey = true;
            this.toolbar.DispatchShortcuts = true;
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbar.DragDropSupport = true;
            this.toolbar.Images = imageList1;
            this.toolbar.Location = new System.Drawing.Point(3, 0);
            this.toolbar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(719, 56);
            this.toolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "常用操作";
            // 
            // 
            // 
            this.toolbar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.toolbar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.toolbar.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            this.toolbar.Paint += new System.Windows.Forms.PaintEventHandler(this.toolbar_Paint);
            this.toolbar.Leave += new System.EventHandler(this.toolbar_Leave);
            // 
            // midebar
            // 
            this.midebar.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.midebar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.midebar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.midebar.ContainerControlProcessDialogKey = true;
            this.midebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.midebar.DragDropSupport = true;
            this.midebar.Images = imageList1;
            this.midebar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbtnReportBack,
            this.tbtnConsultationMide,
            this.tbtnQualityMide,
            this.tbtnMessageMide,
            this.tbtnGrade});
            this.midebar.Location = new System.Drawing.Point(722, 0);
            this.midebar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.midebar.Name = "midebar";
            this.midebar.Size = new System.Drawing.Size(425, 56);
            this.midebar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.midebar.TabIndex = 1;
            this.midebar.Text = "监测提醒";
            // 
            // 
            // 
            this.midebar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.midebar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.midebar.TitleVisible = false;
            // 
            // tbtnReportBack
            // 
            this.tbtnReportBack.AutoCheckOnClick = true;
            this.tbtnReportBack.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnReportBack.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnReportBack.Name = "tbtnReportBack";
            this.tbtnReportBack.OptionGroup = "Color";
            this.tbtnReportBack.SubItemsExpandWidth = 14;
            this.tbtnReportBack.Text = "报卡退回提醒";
            this.tbtnReportBack.Tooltip = "报卡退回提醒";
            this.tbtnReportBack.Visible = false;
            // 
            // tbtnConsultationMide
            // 
            this.tbtnConsultationMide.AutoCheckOnClick = true;
            this.tbtnConsultationMide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnConsultationMide.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnConsultationMide.Name = "tbtnConsultationMide";
            this.tbtnConsultationMide.OptionGroup = "Color";
            this.tbtnConsultationMide.SubItemsExpandWidth = 14;
            this.tbtnConsultationMide.Text = "会诊提醒";
            this.tbtnConsultationMide.Tooltip = "会诊提醒";
            this.tbtnConsultationMide.Visible = false;
            this.tbtnConsultationMide.MouseLeave += new System.EventHandler(this.tbtnConsultationMide_MouseLeave);
            // 
            // tbtnQualityMide
            // 
            this.tbtnQualityMide.AutoCheckOnClick = true;
            this.tbtnQualityMide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnQualityMide.ImageIndex = 37;
            this.tbtnQualityMide.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnQualityMide.Name = "tbtnQualityMide";
            this.tbtnQualityMide.OptionGroup = "Color";
            this.tbtnQualityMide.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tsbtnDutySet,
            this.tsbtnCommit,
            this.tsbtnTempSave,
            this.ttsbtnPrint,
            this.tsbtnTemplateSave,
            this.tsbtnSmallTemplateSave,
            this.tsbtnTemplate,
            this.tsbtnSectionAccountSets,
            this.tbtnAccountClear,
            this.tbtnPassword,
            this.tbtnRoleChose,
            this.tbtnResetSystem});
            this.tbtnQualityMide.SubItemsExpandWidth = 14;
            this.tbtnQualityMide.Text = "质控提醒";
            this.tbtnQualityMide.Tooltip = "质控提醒";
            this.tbtnQualityMide.Visible = false;
            this.tbtnQualityMide.Click += new System.EventHandler(this.tbtnQualityMide_Click);
            // 
            // tsbtnDutySet
            // 
            this.tsbtnDutySet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnDutySet.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDutySet.Image")));
            this.tsbtnDutySet.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnDutySet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnDutySet.Name = "tsbtnDutySet";
            this.tsbtnDutySet.Text = "值班设置";
            // 
            // tsbtnCommit
            // 
            this.tsbtnCommit.AutoCheckOnClick = true;
            this.tsbtnCommit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnCommit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCommit.Image")));
            this.tsbtnCommit.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnCommit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnCommit.Name = "tsbtnCommit";
            this.tsbtnCommit.OptionGroup = "Color";
            this.tsbtnCommit.SubItemsExpandWidth = 14;
            this.tsbtnCommit.Text = "提交";
            this.tsbtnCommit.Tooltip = "提交";
            // 
            // tsbtnTempSave
            // 
            this.tsbtnTempSave.AutoCheckOnClick = true;
            this.tsbtnTempSave.BeginGroup = true;
            this.tsbtnTempSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnTempSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTempSave.Image")));
            this.tsbtnTempSave.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnTempSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnTempSave.Name = "tsbtnTempSave";
            this.tsbtnTempSave.OptionGroup = "Color";
            this.tsbtnTempSave.SubItemsExpandWidth = 14;
            this.tsbtnTempSave.Text = "暂存";
            this.tsbtnTempSave.Tooltip = "暂存";
            // 
            // ttsbtnPrint
            // 
            this.ttsbtnPrint.AutoCheckOnClick = true;
            this.ttsbtnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.ttsbtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("ttsbtnPrint.Image")));
            this.ttsbtnPrint.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.ttsbtnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ttsbtnPrint.Name = "ttsbtnPrint";
            this.ttsbtnPrint.OptionGroup = "Color";
            this.ttsbtnPrint.SubItemsExpandWidth = 14;
            this.ttsbtnPrint.Text = "打印";
            this.ttsbtnPrint.Tooltip = "打印";
            // 
            // tsbtnTemplateSave
            // 
            this.tsbtnTemplateSave.AutoCheckOnClick = true;
            this.tsbtnTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnTemplateSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTemplateSave.Image")));
            this.tsbtnTemplateSave.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnTemplateSave.Name = "tsbtnTemplateSave";
            this.tsbtnTemplateSave.OptionGroup = "Color";
            this.tsbtnTemplateSave.SubItemsExpandWidth = 14;
            this.tsbtnTemplateSave.Text = "保存模板";
            this.tsbtnTemplateSave.Tooltip = "保存模板";
            // 
            // tsbtnSmallTemplateSave
            // 
            this.tsbtnSmallTemplateSave.AutoCheckOnClick = true;
            this.tsbtnSmallTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnSmallTemplateSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSmallTemplateSave.Image")));
            this.tsbtnSmallTemplateSave.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnSmallTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnSmallTemplateSave.Name = "tsbtnSmallTemplateSave";
            this.tsbtnSmallTemplateSave.OptionGroup = "Color";
            this.tsbtnSmallTemplateSave.SubItemsExpandWidth = 14;
            this.tsbtnSmallTemplateSave.Text = "保存小模板";
            this.tsbtnSmallTemplateSave.Tooltip = "保存小模板";
            // 
            // tsbtnTemplate
            // 
            this.tsbtnTemplate.AutoCheckOnClick = true;
            this.tsbtnTemplate.BeginGroup = true;
            this.tsbtnTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnTemplate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTemplate.Image")));
            this.tsbtnTemplate.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnTemplate.Name = "tsbtnTemplate";
            this.tsbtnTemplate.OptionGroup = "Color";
            this.tsbtnTemplate.SubItemsExpandWidth = 14;
            this.tsbtnTemplate.Text = "提取模板";
            this.tsbtnTemplate.Tooltip = "提取模板";
            // 
            // tsbtnSectionAccountSets
            // 
            this.tsbtnSectionAccountSets.AutoCheckOnClick = true;
            this.tsbtnSectionAccountSets.BeginGroup = true;
            this.tsbtnSectionAccountSets.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnSectionAccountSets.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSectionAccountSets.Image")));
            this.tsbtnSectionAccountSets.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnSectionAccountSets.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnSectionAccountSets.Name = "tsbtnSectionAccountSets";
            this.tsbtnSectionAccountSets.OptionGroup = "Color";
            this.tsbtnSectionAccountSets.SubItemsExpandWidth = 14;
            this.tsbtnSectionAccountSets.Text = "科室账号维护";
            this.tsbtnSectionAccountSets.Tooltip = "科室账号维护";
            this.tsbtnSectionAccountSets.Visible = false;
            this.tsbtnSectionAccountSets.Click += new System.EventHandler(this.tsbtnSectionAccountSets_Click);
            // 
            // tbtnAccountClear
            // 
            this.tbtnAccountClear.AutoCheckOnClick = true;
            this.tbtnAccountClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnAccountClear.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAccountClear.Image")));
            this.tbtnAccountClear.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnAccountClear.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnAccountClear.Name = "tbtnAccountClear";
            this.tbtnAccountClear.OptionGroup = "Color";
            this.tbtnAccountClear.SubItemsExpandWidth = 14;
            this.tbtnAccountClear.Text = "帐号注销";
            this.tbtnAccountClear.Tooltip = "帐号注销";
            this.tbtnAccountClear.Visible = false;
            this.tbtnAccountClear.Click += new System.EventHandler(this.tbtnAccountClear_Click);
            // 
            // tbtnPassword
            // 
            this.tbtnPassword.AutoCheckOnClick = true;
            this.tbtnPassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnPassword.Image = ((System.Drawing.Image)(resources.GetObject("tbtnPassword.Image")));
            this.tbtnPassword.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnPassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnPassword.Name = "tbtnPassword";
            this.tbtnPassword.OptionGroup = "Color";
            this.tbtnPassword.SubItemsExpandWidth = 14;
            this.tbtnPassword.Text = "密码修改";
            this.tbtnPassword.Tooltip = "密码修改";
            this.tbtnPassword.Click += new System.EventHandler(this.tbtnPassword_Click);
            // 
            // tbtnRoleChose
            // 
            this.tbtnRoleChose.AutoCheckOnClick = true;
            this.tbtnRoleChose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnRoleChose.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRoleChose.Image")));
            this.tbtnRoleChose.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnRoleChose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnRoleChose.Name = "tbtnRoleChose";
            this.tbtnRoleChose.OptionGroup = "Color";
            this.tbtnRoleChose.SubItemsExpandWidth = 14;
            this.tbtnRoleChose.Text = "角色切换";
            this.tbtnRoleChose.Tooltip = "角色切换";
            this.tbtnRoleChose.Click += new System.EventHandler(this.tbtnRoleChose_Click);
            // 
            // tbtnResetSystem
            // 
            this.tbtnResetSystem.AutoCheckOnClick = true;
            this.tbtnResetSystem.BeginGroup = true;
            this.tbtnResetSystem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnResetSystem.Image = ((System.Drawing.Image)(resources.GetObject("tbtnResetSystem.Image")));
            this.tbtnResetSystem.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnResetSystem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnResetSystem.Name = "tbtnResetSystem";
            this.tbtnResetSystem.OptionGroup = "Color";
            this.tbtnResetSystem.Text = "系统注销";
            this.tbtnResetSystem.Tooltip = "系统注销";
            this.tbtnResetSystem.Click += new System.EventHandler(this.tbtnResetSystem_Click);
            // 
            // tbtnMessageMide
            // 
            this.tbtnMessageMide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnMessageMide.ImageIndex = 35;
            this.tbtnMessageMide.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnMessageMide.Name = "tbtnMessageMide";
            this.tbtnMessageMide.SubItemsExpandWidth = 14;
            this.tbtnMessageMide.Text = "消息提醒";
            this.tbtnMessageMide.Tooltip = "消息提醒";
            this.tbtnMessageMide.Visible = false;
            this.tbtnMessageMide.Click += new System.EventHandler(this.tbtnMessageMide_Click);
            // 
            // tbtnGrade
            // 
            this.tbtnGrade.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnGrade.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnGrade.Name = "tbtnGrade";
            this.tbtnGrade.SubItemsExpandWidth = 14;
            this.tbtnGrade.Text = "科室评分";
            this.tbtnGrade.Tooltip = "科室评分";
            this.tbtnGrade.Visible = false;
            this.tbtnGrade.Click += new System.EventHandler(this.tbtnGrade_Click);
            // 
            // office2007StartButton2
            // 
            this.office2007StartButton2.AutoExpandOnClick = true;
            this.office2007StartButton2.CanCustomize = false;
            this.office2007StartButton2.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.office2007StartButton2.Icon = ((System.Drawing.Icon)(resources.GetObject("office2007StartButton2.Icon")));
            this.office2007StartButton2.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.office2007StartButton2.ImagePaddingHorizontal = 0;
            this.office2007StartButton2.ImagePaddingVertical = 1;
            this.office2007StartButton2.Name = "office2007StartButton2";
            this.office2007StartButton2.ShowSubItems = false;
            this.office2007StartButton2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnToolSet,
            this.buttonChangeStyle,
            this.buttonItem2});
            this.office2007StartButton2.Text = "&文件";
            this.office2007StartButton2.Click += new System.EventHandler(this.office2007StartButton2_Click);
            // 
            // btnToolSet
            // 
            this.btnToolSet.Name = "btnToolSet";
            this.btnToolSet.Text = "工具栏管理";
            this.btnToolSet.Click += new System.EventHandler(this.btnToolSet_Click);
            // 
            // AppCommandTheme
            // 
            this.AppCommandTheme.Name = "AppCommandTheme";
            this.AppCommandTheme.Executed += new System.EventHandler(this.AppCommandTheme_Executed);
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "关闭系统";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // ribbonTabItem_Tools
            // 
            this.ribbonTabItem_Tools.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.ribbonTabItem_Tools.Checked = true;
            this.ribbonTabItem_Tools.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.ribbonTabItem_Tools.ImageIndex = 16;
            this.ribbonTabItem_Tools.Name = "ribbonTabItem_Tools";
            this.ribbonTabItem_Tools.Panel = this.ribbonPanel1;
            this.ribbonTabItem_Tools.Text = "工具栏";
            this.ribbonTabItem_Tools.Click += new System.EventHandler(this.ribbonTabItem_Tools_Click);
            // 
            // buttonItem14
            // 
            this.buttonItem14.AutoExpandOnClick = true;
            this.buttonItem14.Name = "buttonItem14";
            this.buttonItem14.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem28,
            this.buttonItem29,
            this.buttonItem30,
            this.buttonItem31});
            this.buttonItem14.Text = "系统设置";
            // 
            // buttonItem28
            // 
            this.buttonItem28.Name = "buttonItem28";
            this.buttonItem28.Text = "buttonItem28";
            // 
            // buttonItem29
            // 
            this.buttonItem29.Name = "buttonItem29";
            this.buttonItem29.Text = "buttonItem29";
            // 
            // buttonItem30
            // 
            this.buttonItem30.Name = "buttonItem30";
            this.buttonItem30.Text = "buttonItem30";
            // 
            // buttonItem31
            // 
            this.buttonItem31.Name = "buttonItem31";
            this.buttonItem31.Text = "buttonItem31";
            // 
            // buttonItem15
            // 
            this.buttonItem15.AutoExpandOnClick = true;
            this.buttonItem15.Name = "buttonItem15";
            this.buttonItem15.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem32,
            this.buttonItem33,
            this.buttonItem34});
            this.buttonItem15.Text = "基础数据维护";
            // 
            // buttonItem32
            // 
            this.buttonItem32.Name = "buttonItem32";
            this.buttonItem32.Text = "buttonItem32";
            // 
            // buttonItem33
            // 
            this.buttonItem33.Name = "buttonItem33";
            this.buttonItem33.Text = "buttonItem33";
            // 
            // buttonItem34
            // 
            this.buttonItem34.Name = "buttonItem34";
            this.buttonItem34.Text = "buttonItem34";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Text = "当前用户：               ";
            this.lblUserInfo.Click += new System.EventHandler(this.lblUserInfo_Click);
            // 
            // itemContainer6
            // 
            // 
            // 
            // 
            this.itemContainer6.BackgroundStyle.Class = "RibbonFileMenuBottomContainer";
            this.itemContainer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer6.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.itemContainer6.Name = "itemContainer6";
            // 
            // 
            // 
            this.itemContainer6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // Messagebar
            // 
            this.Messagebar.AccessibleDescription = "bar1 (Messagebar)";
            this.Messagebar.AccessibleName = "bar1";
            this.Messagebar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.Messagebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Messagebar.Font = new System.Drawing.Font("宋体", 9F);
            this.Messagebar.IsMaximized = false;
            this.Messagebar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.toolStripLabel});
            this.Messagebar.Location = new System.Drawing.Point(5, 115);
            this.Messagebar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Messagebar.Name = "Messagebar";
            this.Messagebar.Size = new System.Drawing.Size(1150, 17);
            this.Messagebar.Stretch = true;
            this.Messagebar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.Messagebar.TabIndex = 21;
            this.Messagebar.TabStop = false;
            this.Messagebar.Text = "bar1";
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Stretch = true;
            this.toolStripLabel.Text = "显示客户信息";
            this.toolStripLabel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.toolStripLabel.Width = 50;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统的一些参数ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // 系统的一些参数ToolStripMenuItem
            // 
            this.系统的一些参数ToolStripMenuItem.Name = "系统的一些参数ToolStripMenuItem";
            this.系统的一些参数ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.系统的一些参数ToolStripMenuItem.Text = "系统的一些参数";
            // 
            // buttonItem16
            // 
            this.buttonItem16.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem16.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonItem16.Name = "buttonItem16";
            this.buttonItem16.SubItemsExpandWidth = 24;
            this.buttonItem16.Text = "退出系统";
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.BackColor = System.Drawing.Color.White;
            this.tabControl_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabControl_Main.CanReorderTabs = true;
            this.tabControl_Main.CloseButtonOnTabsVisible = true;
            this.tabControl_Main.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabControl_Main.CloseButtonVisible = true;
            this.tabControl_Main.Controls.Add(this.pictureBox1);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.ForeColor = System.Drawing.Color.Black;
            this.tabControl_Main.Location = new System.Drawing.Point(5, 132);
            this.tabControl_Main.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl_Main.SelectedTabIndex = -1;
            this.tabControl_Main.Size = new System.Drawing.Size(1150, 571);
            this.tabControl_Main.Style = DevComponents.DotNetBar.eTabStripStyle.Flat;
            this.tabControl_Main.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.tabControl_Main.TabIndex = 22;
            this.tabControl_Main.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl_Main.Text = "tabControl1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1150, 546);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tsbtnHelp
            // 
            this.tsbtnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnHelp.Icon = ((System.Drawing.Icon)(resources.GetObject("tsbtnHelp.Icon")));
            this.tsbtnHelp.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnHelp.Name = "tsbtnHelp";
            this.tsbtnHelp.Text = "操作帮助";
            this.tsbtnHelp.Click += new System.EventHandler(this.tsbtnHelp_Click);
            // 
            // tsbtnBKSB
            // 
            this.tsbtnBKSB.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnBKSB.Icon = ((System.Drawing.Icon)(resources.GetObject("tsbtnBKSB.Icon")));
            this.tsbtnBKSB.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnBKSB.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnBKSB.Name = "tsbtnBKSB";
            this.tsbtnBKSB.Text = "报卡管理";
            // 
            // tsbtnZLGF
            // 
            this.tsbtnZLGF.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnZLGF.Icon = ((System.Drawing.Icon)(resources.GetObject("tsbtnZLGF.Icon")));
            this.tsbtnZLGF.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnZLGF.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnZLGF.Name = "tsbtnZLGF";
            this.tsbtnZLGF.Text = "诊疗规范";
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(5, 703);
            this.dockSite4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(1150, 0);
            this.dockSite4.TabIndex = 26;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(5, 132);
            this.dockSite1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 571);
            this.dockSite1.TabIndex = 23;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(1155, 132);
            this.dockSite2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 571);
            this.dockSite2.TabIndex = 24;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(5, 703);
            this.dockSite8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(1150, 0);
            this.dockSite8.TabIndex = 30;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(5, 1);
            this.dockSite5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 702);
            this.dockSite5.TabIndex = 27;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(1155, 1);
            this.dockSite6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 702);
            this.dockSite6.TabIndex = 28;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(5, 1);
            this.dockSite7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(1150, 0);
            this.dockSite7.TabIndex = 29;
            this.dockSite7.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(5, 1);
            this.dockSite3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(1150, 0);
            this.dockSite3.TabIndex = 25;
            this.dockSite3.TabStop = false;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // buttonChangeStyle
            // 
            this.buttonChangeStyle.AutoExpandOnClick = true;
            this.buttonChangeStyle.Command = this.AppCommandTheme;
            this.buttonChangeStyle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonChangeStyle.Name = "buttonChangeStyle";
            this.buttonChangeStyle.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem68,
            this.buttonStyleMetro,
            this.buttonItem1,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem69,
            this.buttonItem6,
            this.buttonItem7,
            this.buttonItem8,
            this.buttonItem70,
            this.buttonItem71,
            this.buttonStyleCustom});
            this.buttonChangeStyle.Text = "界面样式";
            // 
            // buttonItem68
            // 
            this.buttonItem68.Command = this.AppCommandTheme;
            this.buttonItem68.CommandParameter = "Office2016";
            this.buttonItem68.Name = "buttonItem68";
            this.buttonItem68.OptionGroup = "style";
            this.buttonItem68.Text = "Office 2016";
            // 
            // buttonStyleMetro
            // 
            this.buttonStyleMetro.Command = this.AppCommandTheme;
            this.buttonStyleMetro.CommandParameter = "Metro";
            this.buttonStyleMetro.Name = "buttonStyleMetro";
            this.buttonStyleMetro.OptionGroup = "style";
            this.buttonStyleMetro.Text = "Metro/Office 2013";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Command = this.AppCommandTheme;
            this.buttonItem1.CommandParameter = "Office2010Blue";
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.OptionGroup = "style";
            this.buttonItem1.Text = "Office 2010 Blue";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Command = this.AppCommandTheme;
            this.buttonItem3.CommandParameter = "Office2010Silver";
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.OptionGroup = "style";
            this.buttonItem3.Text = "Office 2010 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonItem4
            // 
            this.buttonItem4.Command = this.AppCommandTheme;
            this.buttonItem4.CommandParameter = "Office2010Black";
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.OptionGroup = "style";
            this.buttonItem4.Text = "Office 2010 Black";
            // 
            // buttonItem5
            // 
            this.buttonItem5.Command = this.AppCommandTheme;
            this.buttonItem5.CommandParameter = "VisualStudio2010Blue";
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.OptionGroup = "style";
            this.buttonItem5.Text = "Visual Studio 2010";
            // 
            // buttonItem69
            // 
            this.buttonItem69.Command = this.AppCommandTheme;
            this.buttonItem69.CommandParameter = "Windows7Blue";
            this.buttonItem69.Name = "buttonItem69";
            this.buttonItem69.OptionGroup = "style";
            this.buttonItem69.Text = "Windows 7";
            // 
            // buttonItem6
            // 
            this.buttonItem6.Command = this.AppCommandTheme;
            this.buttonItem6.CommandParameter = "Office2007Blue";
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.OptionGroup = "style";
            this.buttonItem6.Text = "Office 2007 <font color=\"Blue\"><b>Blue</b></font>";
            // 
            // buttonItem7
            // 
            this.buttonItem7.Command = this.AppCommandTheme;
            this.buttonItem7.CommandParameter = "Office2007Black";
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.OptionGroup = "style";
            this.buttonItem7.Text = "Office 2007 <font color=\"black\"><b>Black</b></font>";
            // 
            // buttonItem8
            // 
            this.buttonItem8.Command = this.AppCommandTheme;
            this.buttonItem8.CommandParameter = "Office2007Silver";
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.OptionGroup = "style";
            this.buttonItem8.Text = "Office 2007 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonItem70
            // 
            this.buttonItem70.Command = this.AppCommandTheme;
            this.buttonItem70.CommandParameter = "Office2007VistaGlass";
            this.buttonItem70.Name = "buttonItem70";
            this.buttonItem70.OptionGroup = "style";
            this.buttonItem70.Text = "Vista Glass";
            // 
            // buttonItem71
            // 
            this.buttonItem71.Command = this.AppCommandTheme;
            this.buttonItem71.CommandParameter = "VisualStudio2012Light";
            this.buttonItem71.Name = "buttonItem71";
            this.buttonItem71.OptionGroup = "style";
            this.buttonItem71.Text = "Visual Studio 2012 Light";
            // 
            // buttonStyleCustom
            // 
            this.buttonStyleCustom.BeginGroup = true;
            this.buttonStyleCustom.Command = this.AppCommandTheme;
            this.buttonStyleCustom.Name = "buttonStyleCustom";
            this.buttonStyleCustom.Text = "Custom scheme";
            this.buttonStyleCustom.Tooltip = "Custom color scheme is created based on currently selected color table. Try selec" +
    "ting Silver or Blue color table and then creating custom color scheme.";
            this.buttonStyleCustom.SelectedColorChanged += new System.EventHandler(this.buttonStyleCustom_SelectedColorChanged);
            this.buttonStyleCustom.ColorPreview += new DevComponents.DotNetBar.ColorPreviewEventHandler(this.buttonStyleCustom_ColorPreview);
            this.buttonStyleCustom.ExpandChange += new System.EventHandler(this.buttonStyleCustom_ExpandChange);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 705);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.Messagebar);
            this.Controls.Add(this.ribbonControl_main);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "电子病历系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ribbonControl_main.ResumeLayout(false);
            this.ribbonControl_main.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Messagebar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl_Main)).EndInit();
            this.tabControl_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl_main;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar toolbar;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem_Tools;
        private DevComponents.DotNetBar.ButtonItem buttonItem14;
        private DevComponents.DotNetBar.ButtonItem buttonItem28;
        private DevComponents.DotNetBar.ButtonItem buttonItem29;
        private DevComponents.DotNetBar.ButtonItem buttonItem30;
        private DevComponents.DotNetBar.ButtonItem buttonItem31;
        private DevComponents.DotNetBar.ButtonItem buttonItem15;
        private DevComponents.DotNetBar.ButtonItem buttonItem32;
        private DevComponents.DotNetBar.ButtonItem buttonItem33;
        private DevComponents.DotNetBar.ButtonItem buttonItem34;
        private DevComponents.DotNetBar.Office2007StartButton office2007StartButton2;
        private DevComponents.DotNetBar.ItemContainer itemContainer6;
        private DevComponents.DotNetBar.LabelItem lblUserInfo;
        private DevComponents.DotNetBar.Bar Messagebar;
        private DevComponents.DotNetBar.LabelItem toolStripLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统的一些参数ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonItem btnToolSet;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem16;
        private DevComponents.DotNetBar.TabControl tabControl_Main;
        private DevComponents.DotNetBar.ButtonItem tsbtnHelp;
        private DevComponents.DotNetBar.ButtonItem tsbtnBKSB;
        private DevComponents.DotNetBar.ButtonItem tsbtnZLGF;
        private DevComponents.DotNetBar.ButtonItem tsbtnDutySet;
        private DevComponents.DotNetBar.ButtonItem tsbtnCommit;
        private DevComponents.DotNetBar.ButtonItem tsbtnTempSave;
        private DevComponents.DotNetBar.ButtonItem ttsbtnPrint;
        private DevComponents.DotNetBar.ButtonItem tsbtnTemplateSave;
        private DevComponents.DotNetBar.ButtonItem tsbtnSmallTemplateSave;
        private DevComponents.DotNetBar.ButtonItem tsbtnTemplate;
        private DevComponents.DotNetBar.ButtonItem tsbtnSectionAccountSets;
        private DevComponents.DotNetBar.ButtonItem tbtnAccountClear;
        private DevComponents.DotNetBar.ButtonItem tbtnPassword;
        private DevComponents.DotNetBar.ButtonItem tbtnRoleChose;
        private DevComponents.DotNetBar.ButtonItem tbtnResetSystem;
        private DevComponents.DotNetBar.RibbonBar midebar;
        private DevComponents.DotNetBar.ButtonItem tbtnReportBack;
        private DevComponents.DotNetBar.ButtonItem tbtnConsultationMide;
        private DevComponents.DotNetBar.ButtonItem tbtnQualityMide;
        private DevComponents.DotNetBar.ButtonItem tbtnMessageMide;
        private DevComponents.DotNetBar.ButtonItem tbtnGrade;
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private Command AppCommandTheme;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ButtonItem buttonChangeStyle;
        private ButtonItem buttonItem68;
        private ButtonItem buttonStyleMetro;
        private ButtonItem buttonItem1;
        private ButtonItem buttonItem3;
        private ButtonItem buttonItem4;
        private ButtonItem buttonItem5;
        private ButtonItem buttonItem69;
        private ButtonItem buttonItem6;
        private ButtonItem buttonItem7;
        private ButtonItem buttonItem8;
        private ButtonItem buttonItem70;
        private ButtonItem buttonItem71;
        private ColorPickerDropDown buttonStyleCustom;
    }
}