namespace BifrostMainPro
{
    partial class MDIParent1
    {
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabOpenForms = new DevComponents.DotNetBar.TabStrip();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.MenuBar = new DevComponents.DotNetBar.Bar();
            this.buttonItem14 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem15 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem16 = new DevComponents.DotNetBar.ButtonItem();
            this.Messagebar = new DevComponents.DotNetBar.Bar();
            this.toolStripLabel = new DevComponents.DotNetBar.LabelItem();
            this.labelItemBktx = new DevComponents.DotNetBar.LabelItem();
            this.toolHuizhen = new DevComponents.DotNetBar.ButtonItem();
            this.toolZhikong = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnTemplate = new DevComponents.DotNetBar.ButtonItem();
            this.toolbar = new DevComponents.DotNetBar.Bar();
            this.tbtnResetSystem = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnRoleChose = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnPassword = new DevComponents.DotNetBar.ButtonItem();
            this.tbtnAccountClear = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnWrite = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnSectionAccountSets = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnSign = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnCheck = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnModify = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnLook = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnImport = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnOutPut = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnSmallTemplateSave = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnTemplateSave = new DevComponents.DotNetBar.ButtonItem();
            this.ttsbtnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnTempSave = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnCommit = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnDutySet = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnZLGF = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnBKSB = new DevComponents.DotNetBar.ButtonItem();
            this.tsbtnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.系统的一些参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Messagebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "timeout.ico");
            this.imageList1.Images.SetKeyName(1, "noprotocol.ico");
            this.imageList1.Images.SetKeyName(2, "NOTEPA~5.ICO");
            this.imageList1.Images.SetKeyName(3, "NOTEPA~1.ICO");
            this.imageList1.Images.SetKeyName(4, "NOTEPA~2.ICO");
            this.imageList1.Images.SetKeyName(5, "NOTEPA~4.ICO");
            this.imageList1.Images.SetKeyName(6, "BEEDIT~1.ICO");
            this.imageList1.Images.SetKeyName(7, "BEDRAW~1.ICO");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "tabItem1";
            // 
            // tabOpenForms
            // 
            this.tabOpenForms.AutoSelectAttachedControl = true;
            this.tabOpenForms.CanReorderTabs = false;
            this.tabOpenForms.CloseButtonOnTabsVisible = true;
            this.tabOpenForms.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabOpenForms.CloseButtonVisible = true;
            this.tabOpenForms.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabOpenForms.Location = new System.Drawing.Point(0, 461);
            this.tabOpenForms.MdiAutoHide = false;
            this.tabOpenForms.Name = "tabOpenForms";
            this.tabOpenForms.SelectedTab = null;
            this.tabOpenForms.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabOpenForms.Size = new System.Drawing.Size(1220, 24);
            this.tabOpenForms.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabOpenForms.TabIndex = 9;
            this.tabOpenForms.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabOpenForms.TabScrollAutoRepeat = true;
            this.tabOpenForms.Text = "tabStrip1";
            this.tabOpenForms.ThemeAware = true;
            this.tabOpenForms.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.tabOpenForms_SelectedTabChanged);
            this.tabOpenForms.TabItemClose += new DevComponents.DotNetBar.TabStrip.UserActionEventHandler(this.tabOpenForms_TabItemClose);
            // 
            // tabItem2
            // 
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "tabItem2";
            // 
            // MenuBar
            // 
            this.MenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1220, 25);
            this.MenuBar.Stretch = true;
            this.MenuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.MenuBar.TabIndex = 11;
            this.MenuBar.TabStop = false;
            this.MenuBar.Text = "bar1";
            // 
            // buttonItem14
            // 
            this.buttonItem14.ImagePaddingHorizontal = 8;
            this.buttonItem14.Name = "buttonItem14";
            this.buttonItem14.SubItemsExpandWidth = 14;
            this.buttonItem14.Text = "buttonItem14";
            // 
            // buttonItem15
            // 
            this.buttonItem15.ImagePaddingHorizontal = 8;
            this.buttonItem15.Name = "buttonItem15";
            this.buttonItem15.SubItemsExpandWidth = 14;
            this.buttonItem15.Text = "buttonItem15";
            // 
            // buttonItem16
            // 
            this.buttonItem16.ImagePaddingHorizontal = 8;
            this.buttonItem16.Name = "buttonItem16";
            this.buttonItem16.SubItemsExpandWidth = 14;
            this.buttonItem16.Text = "buttonItem16";
            // 
            // Messagebar
            // 
            this.Messagebar.AccessibleDescription = "bar1 (Messagebar)";
            this.Messagebar.AccessibleName = "bar1";
            this.Messagebar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.Messagebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Messagebar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.toolStripLabel,
            this.labelItemBktx,
            this.toolHuizhen,
            this.toolZhikong});
            this.Messagebar.Location = new System.Drawing.Point(0, 66);
            this.Messagebar.Name = "Messagebar";
            this.Messagebar.Size = new System.Drawing.Size(1220, 25);
            this.Messagebar.Stretch = true;
            this.Messagebar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.Messagebar.TabIndex = 18;
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
            // labelItemBktx
            // 
            this.labelItemBktx.Name = "labelItemBktx";
            this.labelItemBktx.Text = "报卡退回提醒";
            // 
            // toolHuizhen
            // 
            this.toolHuizhen.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.toolHuizhen.ImagePaddingHorizontal = 8;
            this.toolHuizhen.Name = "toolHuizhen";
            this.toolHuizhen.SubItemsExpandWidth = 14;
            this.toolHuizhen.Text = "会诊提醒";
            this.toolHuizhen.Tooltip = "会诊提醒";
            this.toolHuizhen.Click += new System.EventHandler(this.toolHuizhen_Click);
            // 
            // toolZhikong
            // 
            this.toolZhikong.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.toolZhikong.ImagePaddingHorizontal = 8;
            this.toolZhikong.Name = "toolZhikong";
            this.toolZhikong.SubItemsExpandWidth = 14;
            this.toolZhikong.Text = "质控提醒 ";
            this.toolZhikong.Tooltip = "质控提醒";
            this.toolZhikong.Click += new System.EventHandler(this.toolZhikong_Click);
            // 
            // tsbtnTemplate
            // 
            this.tsbtnTemplate.AutoCheckOnClick = true;
            this.tsbtnTemplate.BeginGroup = true;
            this.tsbtnTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnTemplate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTemplate.Image")));
            this.tsbtnTemplate.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnTemplate.ImagePaddingHorizontal = 8;
            this.tsbtnTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnTemplate.Name = "tsbtnTemplate";
            this.tsbtnTemplate.OptionGroup = "Color";
            this.tsbtnTemplate.SubItemsExpandWidth = 14;
            this.tsbtnTemplate.Text = "提取模板";
            this.tsbtnTemplate.ThemeAware = true;
            this.tsbtnTemplate.Tooltip = "提取模板";
            this.tsbtnTemplate.Click += new System.EventHandler(this.tsbtnTemplate_Click);
            // 
            // toolbar
            // 
            this.toolbar.AccessibleDescription = "bar1 (toolbar)";
            this.toolbar.AccessibleName = "bar1";
            this.toolbar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbtnResetSystem,
            this.tbtnRoleChose,
            this.tbtnPassword,
            this.tbtnAccountClear,
            this.tsbtnWrite,
            this.tsbtnSectionAccountSets,
            this.tsbtnSign,
            this.tsbtnCheck,
            this.tsbtnModify,
            this.tsbtnDelete,
            this.tsbtnLook,
            this.tsbtnImport,
            this.tsbtnOutPut,
            this.tsbtnTemplate,
            this.tsbtnSmallTemplateSave,
            this.tsbtnTemplateSave,
            this.ttsbtnPrint,
            this.tsbtnTempSave,
            this.tsbtnCommit,
            this.tsbtnDutySet,
            this.tsbtnZLGF,
            this.tsbtnBKSB,
            this.tsbtnHelp});
            this.toolbar.Location = new System.Drawing.Point(0, 25);
            this.toolbar.Name = "toolbar";
            this.toolbar.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolbar.Size = new System.Drawing.Size(1220, 41);
            this.toolbar.Stretch = true;
            this.toolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.toolbar.TabIndex = 17;
            this.toolbar.TabStop = false;
            this.toolbar.Text = "bar1";
            this.toolbar.ThemeAware = true;
            // 
            // tbtnResetSystem
            // 
            this.tbtnResetSystem.AutoCheckOnClick = true;
            this.tbtnResetSystem.BeginGroup = true;
            this.tbtnResetSystem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnResetSystem.Image = ((System.Drawing.Image)(resources.GetObject("tbtnResetSystem.Image")));
            this.tbtnResetSystem.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnResetSystem.ImagePaddingHorizontal = 8;
            this.tbtnResetSystem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnResetSystem.Name = "tbtnResetSystem";
            this.tbtnResetSystem.OptionGroup = "Color";
            this.tbtnResetSystem.Text = "系统注销";
            this.tbtnResetSystem.ThemeAware = true;
            this.tbtnResetSystem.Tooltip = "系统注销";
            this.tbtnResetSystem.Click += new System.EventHandler(this.tbtnResetSystem_Click);
            // 
            // tbtnRoleChose
            // 
            this.tbtnRoleChose.AutoCheckOnClick = true;
            this.tbtnRoleChose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnRoleChose.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRoleChose.Image")));
            this.tbtnRoleChose.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnRoleChose.ImagePaddingHorizontal = 8;
            this.tbtnRoleChose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnRoleChose.Name = "tbtnRoleChose";
            this.tbtnRoleChose.OptionGroup = "Color";
            this.tbtnRoleChose.SubItemsExpandWidth = 14;
            this.tbtnRoleChose.Text = "角色切换";
            this.tbtnRoleChose.ThemeAware = true;
            this.tbtnRoleChose.Tooltip = "角色切换";
            this.tbtnRoleChose.Click += new System.EventHandler(this.tbtnRoleChose_Click);
            // 
            // tbtnPassword
            // 
            this.tbtnPassword.AutoCheckOnClick = true;
            this.tbtnPassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnPassword.Image = ((System.Drawing.Image)(resources.GetObject("tbtnPassword.Image")));
            this.tbtnPassword.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnPassword.ImagePaddingHorizontal = 8;
            this.tbtnPassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnPassword.Name = "tbtnPassword";
            this.tbtnPassword.OptionGroup = "Color";
            this.tbtnPassword.SubItemsExpandWidth = 14;
            this.tbtnPassword.Text = "密码修改";
            this.tbtnPassword.ThemeAware = true;
            this.tbtnPassword.Tooltip = "密码修改";
            this.tbtnPassword.Click += new System.EventHandler(this.tbtnPassword_Click);
            // 
            // tbtnAccountClear
            // 
            this.tbtnAccountClear.AutoCheckOnClick = true;
            this.tbtnAccountClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tbtnAccountClear.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAccountClear.Image")));
            this.tbtnAccountClear.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tbtnAccountClear.ImagePaddingHorizontal = 8;
            this.tbtnAccountClear.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tbtnAccountClear.Name = "tbtnAccountClear";
            this.tbtnAccountClear.OptionGroup = "Color";
            this.tbtnAccountClear.SubItemsExpandWidth = 14;
            this.tbtnAccountClear.Text = "帐号注销";
            this.tbtnAccountClear.ThemeAware = true;
            this.tbtnAccountClear.Tooltip = "帐号注销";
            this.tbtnAccountClear.Visible = false;
            this.tbtnAccountClear.Click += new System.EventHandler(this.tbtnAccountClear_Click);
            // 
            // tsbtnWrite
            // 
            this.tsbtnWrite.AutoCheckOnClick = true;
            this.tsbtnWrite.BeginGroup = true;
            this.tsbtnWrite.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnWrite.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnWrite.Image")));
            this.tsbtnWrite.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnWrite.ImagePaddingHorizontal = 8;
            this.tsbtnWrite.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnWrite.Name = "tsbtnWrite";
            this.tsbtnWrite.OptionGroup = "Color";
            this.tsbtnWrite.SubItemsExpandWidth = 14;
            this.tsbtnWrite.Text = "书写";
            this.tsbtnWrite.ThemeAware = true;
            this.tsbtnWrite.Tooltip = "书写";
            this.tsbtnWrite.Visible = false;
            this.tsbtnWrite.Click += new System.EventHandler(this.tsbtnWrite_Click);
            // 
            // tsbtnSectionAccountSets
            // 
            this.tsbtnSectionAccountSets.AutoCheckOnClick = true;
            this.tsbtnSectionAccountSets.BeginGroup = true;
            this.tsbtnSectionAccountSets.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnSectionAccountSets.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSectionAccountSets.Image")));
            this.tsbtnSectionAccountSets.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnSectionAccountSets.ImagePaddingHorizontal = 8;
            this.tsbtnSectionAccountSets.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnSectionAccountSets.Name = "tsbtnSectionAccountSets";
            this.tsbtnSectionAccountSets.OptionGroup = "Color";
            this.tsbtnSectionAccountSets.SubItemsExpandWidth = 14;
            this.tsbtnSectionAccountSets.Text = "科室账号维护";
            this.tsbtnSectionAccountSets.ThemeAware = true;
            this.tsbtnSectionAccountSets.Tooltip = "科室账号维护";
            this.tsbtnSectionAccountSets.Visible = false;
            this.tsbtnSectionAccountSets.Click += new System.EventHandler(this.tsbtnSectionAccountSets_Click);
            // 
            // tsbtnSign
            // 
            this.tsbtnSign.AutoCheckOnClick = true;
            this.tsbtnSign.BeginGroup = true;
            this.tsbtnSign.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnSign.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSign.Image")));
            this.tsbtnSign.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnSign.ImagePaddingHorizontal = 8;
            this.tsbtnSign.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnSign.Name = "tsbtnSign";
            this.tsbtnSign.OptionGroup = "Color";
            this.tsbtnSign.SubItemsExpandWidth = 14;
            this.tsbtnSign.Text = "签字";
            this.tsbtnSign.ThemeAware = true;
            this.tsbtnSign.Tooltip = "签字";
            this.tsbtnSign.Visible = false;
            this.tsbtnSign.Click += new System.EventHandler(this.tsbtnSign_Click);
            // 
            // tsbtnCheck
            // 
            this.tsbtnCheck.AutoCheckOnClick = true;
            this.tsbtnCheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnCheck.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCheck.Image")));
            this.tsbtnCheck.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnCheck.ImagePaddingHorizontal = 8;
            this.tsbtnCheck.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnCheck.Name = "tsbtnCheck";
            this.tsbtnCheck.OptionGroup = "Color";
            this.tsbtnCheck.SubItemsExpandWidth = 14;
            this.tsbtnCheck.Text = "审核";
            this.tsbtnCheck.ThemeAware = true;
            this.tsbtnCheck.Tooltip = "审核";
            this.tsbtnCheck.Visible = false;
            this.tsbtnCheck.Click += new System.EventHandler(this.tsbtnCheck_Click);
            // 
            // tsbtnModify
            // 
            this.tsbtnModify.AutoCheckOnClick = true;
            this.tsbtnModify.BeginGroup = true;
            this.tsbtnModify.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModify.Image")));
            this.tsbtnModify.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnModify.ImagePaddingHorizontal = 8;
            this.tsbtnModify.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnModify.Name = "tsbtnModify";
            this.tsbtnModify.OptionGroup = "Color";
            this.tsbtnModify.SubItemsExpandWidth = 14;
            this.tsbtnModify.Text = "修改";
            this.tsbtnModify.ThemeAware = true;
            this.tsbtnModify.Tooltip = "修改";
            this.tsbtnModify.Visible = false;
            this.tsbtnModify.Click += new System.EventHandler(this.tsbtnModify_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.AutoCheckOnClick = true;
            this.tsbtnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnDelete.ImagePaddingHorizontal = 8;
            this.tsbtnDelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.OptionGroup = "Color";
            this.tsbtnDelete.SubItemsExpandWidth = 14;
            this.tsbtnDelete.Text = "删除";
            this.tsbtnDelete.ThemeAware = true;
            this.tsbtnDelete.Tooltip = "删除";
            this.tsbtnDelete.Visible = false;
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // tsbtnLook
            // 
            this.tsbtnLook.AutoCheckOnClick = true;
            this.tsbtnLook.BeginGroup = true;
            this.tsbtnLook.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnLook.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLook.Image")));
            this.tsbtnLook.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnLook.ImagePaddingHorizontal = 8;
            this.tsbtnLook.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnLook.Name = "tsbtnLook";
            this.tsbtnLook.OptionGroup = "Color";
            this.tsbtnLook.SubItemsExpandWidth = 14;
            this.tsbtnLook.Text = "查看";
            this.tsbtnLook.ThemeAware = true;
            this.tsbtnLook.Tooltip = "查看";
            this.tsbtnLook.Visible = false;
            this.tsbtnLook.Click += new System.EventHandler(this.tsbtnLook_Click);
            // 
            // tsbtnImport
            // 
            this.tsbtnImport.AutoCheckOnClick = true;
            this.tsbtnImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnImport.Image")));
            this.tsbtnImport.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnImport.ImagePaddingHorizontal = 8;
            this.tsbtnImport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnImport.Name = "tsbtnImport";
            this.tsbtnImport.OptionGroup = "Color";
            this.tsbtnImport.SubItemsExpandWidth = 14;
            this.tsbtnImport.Text = "导入";
            this.tsbtnImport.ThemeAware = true;
            this.tsbtnImport.Tooltip = "导入";
            this.tsbtnImport.Visible = false;
            this.tsbtnImport.Click += new System.EventHandler(this.tsbtnImport_Click);
            // 
            // tsbtnOutPut
            // 
            this.tsbtnOutPut.AutoCheckOnClick = true;
            this.tsbtnOutPut.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnOutPut.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOutPut.Image")));
            this.tsbtnOutPut.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnOutPut.ImagePaddingHorizontal = 8;
            this.tsbtnOutPut.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnOutPut.Name = "tsbtnOutPut";
            this.tsbtnOutPut.OptionGroup = "Color";
            this.tsbtnOutPut.SubItemsExpandWidth = 14;
            this.tsbtnOutPut.Text = "导出";
            this.tsbtnOutPut.ThemeAware = true;
            this.tsbtnOutPut.Tooltip = "导出";
            this.tsbtnOutPut.Visible = false;
            this.tsbtnOutPut.Click += new System.EventHandler(this.tsbtnOutPut_Click);
            // 
            // tsbtnSmallTemplateSave
            // 
            this.tsbtnSmallTemplateSave.AutoCheckOnClick = true;
            this.tsbtnSmallTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnSmallTemplateSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSmallTemplateSave.Image")));
            this.tsbtnSmallTemplateSave.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnSmallTemplateSave.ImagePaddingHorizontal = 8;
            this.tsbtnSmallTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnSmallTemplateSave.Name = "tsbtnSmallTemplateSave";
            this.tsbtnSmallTemplateSave.OptionGroup = "Color";
            this.tsbtnSmallTemplateSave.SubItemsExpandWidth = 14;
            this.tsbtnSmallTemplateSave.Text = "保存小模板";
            this.tsbtnSmallTemplateSave.ThemeAware = true;
            this.tsbtnSmallTemplateSave.Tooltip = "保存小模板";
            this.tsbtnSmallTemplateSave.Click += new System.EventHandler(this.tsbtnSmallTemplateSave_Click);
            // 
            // tsbtnTemplateSave
            // 
            this.tsbtnTemplateSave.AutoCheckOnClick = true;
            this.tsbtnTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnTemplateSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTemplateSave.Image")));
            this.tsbtnTemplateSave.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnTemplateSave.ImagePaddingHorizontal = 8;
            this.tsbtnTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnTemplateSave.Name = "tsbtnTemplateSave";
            this.tsbtnTemplateSave.OptionGroup = "Color";
            this.tsbtnTemplateSave.SubItemsExpandWidth = 14;
            this.tsbtnTemplateSave.Text = "保存模板";
            this.tsbtnTemplateSave.ThemeAware = true;
            this.tsbtnTemplateSave.Tooltip = "保存模板";
            this.tsbtnTemplateSave.Click += new System.EventHandler(this.tsbtnTemplateSave_Click);
            // 
            // ttsbtnPrint
            // 
            this.ttsbtnPrint.AutoCheckOnClick = true;
            this.ttsbtnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.ttsbtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("ttsbtnPrint.Image")));
            this.ttsbtnPrint.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.ttsbtnPrint.ImagePaddingHorizontal = 8;
            this.ttsbtnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ttsbtnPrint.Name = "ttsbtnPrint";
            this.ttsbtnPrint.OptionGroup = "Color";
            this.ttsbtnPrint.SubItemsExpandWidth = 14;
            this.ttsbtnPrint.Text = "打印";
            this.ttsbtnPrint.ThemeAware = true;
            this.ttsbtnPrint.Tooltip = "打印";
            this.ttsbtnPrint.Click += new System.EventHandler(this.ttsbtnPrint_Click);
            // 
            // tsbtnTempSave
            // 
            this.tsbtnTempSave.AutoCheckOnClick = true;
            this.tsbtnTempSave.BeginGroup = true;
            this.tsbtnTempSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnTempSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTempSave.Image")));
            this.tsbtnTempSave.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnTempSave.ImagePaddingHorizontal = 8;
            this.tsbtnTempSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnTempSave.Name = "tsbtnTempSave";
            this.tsbtnTempSave.OptionGroup = "Color";
            this.tsbtnTempSave.SubItemsExpandWidth = 14;
            this.tsbtnTempSave.Text = "暂存";
            this.tsbtnTempSave.ThemeAware = true;
            this.tsbtnTempSave.Tooltip = "暂存";
            this.tsbtnTempSave.Click += new System.EventHandler(this.tsbtnTempSave_Click);
            // 
            // tsbtnCommit
            // 
            this.tsbtnCommit.AutoCheckOnClick = true;
            this.tsbtnCommit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnCommit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCommit.Image")));
            this.tsbtnCommit.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnCommit.ImagePaddingHorizontal = 8;
            this.tsbtnCommit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnCommit.Name = "tsbtnCommit";
            this.tsbtnCommit.OptionGroup = "Color";
            this.tsbtnCommit.SubItemsExpandWidth = 14;
            this.tsbtnCommit.Text = "提交";
            this.tsbtnCommit.ThemeAware = true;
            this.tsbtnCommit.Tooltip = "提交";
            this.tsbtnCommit.Click += new System.EventHandler(this.tsbtnCommit_Click);
            // 
            // tsbtnDutySet
            // 
            this.tsbtnDutySet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnDutySet.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDutySet.Image")));
            this.tsbtnDutySet.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnDutySet.ImagePaddingHorizontal = 8;
            this.tsbtnDutySet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnDutySet.Name = "tsbtnDutySet";
            this.tsbtnDutySet.Text = "值班设置";
            this.tsbtnDutySet.ThemeAware = true;
            this.tsbtnDutySet.Click += new System.EventHandler(this.tsbtnDutySet_Click);
            // 
            // tsbtnZLGF
            // 
            this.tsbtnZLGF.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnZLGF.Icon = ((System.Drawing.Icon)(resources.GetObject("tsbtnZLGF.Icon")));
            this.tsbtnZLGF.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnZLGF.ImagePaddingHorizontal = 8;
            this.tsbtnZLGF.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnZLGF.Name = "tsbtnZLGF";
            this.tsbtnZLGF.Text = "诊疗规范";
            this.tsbtnZLGF.ThemeAware = true;
            this.tsbtnZLGF.Click += new System.EventHandler(this.tsbtnZLGF_Click);
            // 
            // tsbtnBKSB
            // 
            this.tsbtnBKSB.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnBKSB.Icon = ((System.Drawing.Icon)(resources.GetObject("tsbtnBKSB.Icon")));
            this.tsbtnBKSB.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnBKSB.ImagePaddingHorizontal = 8;
            this.tsbtnBKSB.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnBKSB.Name = "tsbtnBKSB";
            this.tsbtnBKSB.Text = "报卡管理";
            this.tsbtnBKSB.ThemeAware = true;
            this.tsbtnBKSB.Click += new System.EventHandler(this.tsbtnBKSB_Click);
            // 
            // tsbtnHelp
            // 
            this.tsbtnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tsbtnHelp.Icon = ((System.Drawing.Icon)(resources.GetObject("tsbtnHelp.Icon")));
            this.tsbtnHelp.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.tsbtnHelp.ImagePaddingHorizontal = 8;
            this.tsbtnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tsbtnHelp.Name = "tsbtnHelp";
            this.tsbtnHelp.Text = "操作帮助";
            this.tsbtnHelp.ThemeAware = true;
            this.tsbtnHelp.Click += new System.EventHandler(this.tsbtnHelp_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统的一些参数ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 48);
            // 
            // 系统的一些参数ToolStripMenuItem
            // 
            this.系统的一些参数ToolStripMenuItem.Name = "系统的一些参数ToolStripMenuItem";
            this.系统的一些参数ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.系统的一些参数ToolStripMenuItem.Text = "系统的一些参数";
            this.系统的一些参数ToolStripMenuItem.Click += new System.EventHandler(this.系统的一些参数ToolStripMenuItem_Click);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1220, 485);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.Messagebar);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.tabOpenForms);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIParent1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MDIParent1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParent1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDIParent1_FormClosed);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.MdiChildActivate += new System.EventHandler(this.MDIParent1_MdiChildActivate);
            this.DoubleClick += new System.EventHandler(this.MDIParent1_DoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MDIParent1_MouseMove);
            this.Resize += new System.EventHandler(this.MDIParent1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.MenuBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Messagebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabStrip tabOpenForms;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.Bar MenuBar;
        private DevComponents.DotNetBar.ButtonItem buttonItem14;
        private DevComponents.DotNetBar.ButtonItem buttonItem15;
        private DevComponents.DotNetBar.ButtonItem buttonItem16;
        private DevComponents.DotNetBar.Bar Messagebar;
        private DevComponents.DotNetBar.LabelItem toolStripLabel;
        private DevComponents.DotNetBar.ButtonItem toolHuizhen;
        private DevComponents.DotNetBar.ButtonItem toolZhikong;
        private DevComponents.DotNetBar.ButtonItem tsbtnTemplate;
        private DevComponents.DotNetBar.Bar toolbar;
        private DevComponents.DotNetBar.ButtonItem tbtnResetSystem;
        private DevComponents.DotNetBar.ButtonItem tbtnRoleChose;
        private DevComponents.DotNetBar.ButtonItem tbtnPassword;
        private DevComponents.DotNetBar.ButtonItem tsbtnWrite;
        private DevComponents.DotNetBar.ButtonItem tsbtnSign;
        private DevComponents.DotNetBar.ButtonItem tsbtnCheck;
        private DevComponents.DotNetBar.ButtonItem tsbtnModify;
        private DevComponents.DotNetBar.ButtonItem tsbtnDelete;
        private DevComponents.DotNetBar.ButtonItem tsbtnLook;
        private DevComponents.DotNetBar.ButtonItem tsbtnImport;
        private DevComponents.DotNetBar.ButtonItem tsbtnOutPut;
        private DevComponents.DotNetBar.ButtonItem tsbtnTemplateSave;
        private DevComponents.DotNetBar.ButtonItem ttsbtnPrint;
        private DevComponents.DotNetBar.ButtonItem tsbtnTempSave;
        private DevComponents.DotNetBar.ButtonItem tsbtnCommit;
        private DevComponents.DotNetBar.ButtonItem tsbtnSmallTemplateSave;
        private DevComponents.DotNetBar.ButtonItem tsbtnZLGF;
        private DevComponents.DotNetBar.ButtonItem tsbtnDutySet;
        private DevComponents.DotNetBar.ButtonItem tsbtnBKSB;
        private DevComponents.DotNetBar.LabelItem labelItemBktx;
        private DevComponents.DotNetBar.ButtonItem tsbtnHelp;
        private DevComponents.DotNetBar.ButtonItem tbtnAccountClear;
        private DevComponents.DotNetBar.ButtonItem tsbtnSectionAccountSets;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统的一些参数ToolStripMenuItem;
    }
}



