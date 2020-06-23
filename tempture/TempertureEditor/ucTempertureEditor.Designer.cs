namespace TempertureEditor
{
    partial class ucTempertureEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTempertureEditor));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("画笔");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("字体");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("标签");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("体温单元素");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("数据设置");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTemperatureShow = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlbllocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnPrintShow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnUp = new System.Windows.Forms.ToolStripButton();
            this.tbtnDowm = new System.Windows.Forms.ToolStripButton();
            this.tbtnLeft = new System.Windows.Forms.ToolStripButton();
            this.tbtnRight = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.tcboreType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDataBind = new System.Windows.Forms.ToolStripButton();
            this.tbtnloadtempleFile = new System.Windows.Forms.ToolStripButton();
            this.tbtnnewtempleFile = new System.Windows.Forms.ToolStripButton();
            this.tbtnsaveas = new System.Windows.Forms.ToolStripButton();
            this.tbtnsyncodetype = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trvTemperture = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.创建主边框ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加矩形区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.删除对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tbtnAddPen = new System.Windows.Forms.ToolStripButton();
            this.tbtnFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnAddLine = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddRec = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddText = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddDataType = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDataType = new System.Windows.Forms.ToolStripButton();
            this.tbtnTextType = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDel = new System.Windows.Forms.ToolStripButton();
            this.tbtnReflesh = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTemperatureShow)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(913, 492);
            this.splitContainer1.SplitterDistance = 609;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.statusStrip1);
            this.groupBox3.Controls.Add(this.toolStrip1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 492);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "效果展示";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picTemperatureShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 425);
            this.panel1.TabIndex = 1;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // picTemperatureShow
            // 
            this.picTemperatureShow.BackColor = System.Drawing.Color.White;
            this.picTemperatureShow.Location = new System.Drawing.Point(3, 3);
            this.picTemperatureShow.Name = "picTemperatureShow";
            this.picTemperatureShow.Size = new System.Drawing.Size(354, 301);
            this.picTemperatureShow.TabIndex = 0;
            this.picTemperatureShow.TabStop = false;
            this.picTemperatureShow.Paint += new System.Windows.Forms.PaintEventHandler(this.picTemperatureShow_Paint);
            this.picTemperatureShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTemperatureShow_MouseDown);
            this.picTemperatureShow.MouseLeave += new System.EventHandler(this.picTemperatureShow_MouseLeave);
            this.picTemperatureShow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTemperatureShow_MouseMove);
            this.picTemperatureShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picTemperatureShow_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbllocation});
            this.statusStrip1.Location = new System.Drawing.Point(3, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(603, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlbllocation
            // 
            this.tlbllocation.Name = "tlbllocation";
            this.tlbllocation.Size = new System.Drawing.Size(77, 17);
            this.tlbllocation.Text = "当前鼠标坐标";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnPrintShow,
            this.toolStripSeparator2,
            this.tbtnUp,
            this.tbtnDowm,
            this.tbtnLeft,
            this.tbtnRight,
            this.btnAlignCenter,
            this.tcboreType,
            this.toolStripSeparator3,
            this.tbtnDataBind,
            this.tbtnloadtempleFile,
            this.tbtnnewtempleFile,
            this.tbtnsaveas,
            this.tbtnsyncodetype});
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(603, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnPrintShow
            // 
            this.toolbtnPrintShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnPrintShow.Enabled = false;
            this.toolbtnPrintShow.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnPrintShow.Image")));
            this.toolbtnPrintShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPrintShow.Name = "toolbtnPrintShow";
            this.toolbtnPrintShow.Size = new System.Drawing.Size(23, 22);
            this.toolbtnPrintShow.Text = "打印浏览";
            this.toolbtnPrintShow.Click += new System.EventHandler(this.toolbtnPrintShow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnUp
            // 
            this.tbtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnUp.Image = ((System.Drawing.Image)(resources.GetObject("tbtnUp.Image")));
            this.tbtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnUp.Name = "tbtnUp";
            this.tbtnUp.Size = new System.Drawing.Size(23, 22);
            this.tbtnUp.Text = "toolStripButton1";
            this.tbtnUp.ToolTipText = "上";
            this.tbtnUp.Click += new System.EventHandler(this.tbtnUp_Click);
            // 
            // tbtnDowm
            // 
            this.tbtnDowm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDowm.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDowm.Image")));
            this.tbtnDowm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDowm.Name = "tbtnDowm";
            this.tbtnDowm.Size = new System.Drawing.Size(23, 22);
            this.tbtnDowm.Text = "toolStripButton2";
            this.tbtnDowm.ToolTipText = "下";
            this.tbtnDowm.Click += new System.EventHandler(this.tbtnDowm_Click);
            // 
            // tbtnLeft
            // 
            this.tbtnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnLeft.Image = ((System.Drawing.Image)(resources.GetObject("tbtnLeft.Image")));
            this.tbtnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnLeft.Name = "tbtnLeft";
            this.tbtnLeft.Size = new System.Drawing.Size(23, 22);
            this.tbtnLeft.Text = "toolStripButton3";
            this.tbtnLeft.ToolTipText = "左";
            this.tbtnLeft.Click += new System.EventHandler(this.tbtnLeft_Click);
            // 
            // tbtnRight
            // 
            this.tbtnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRight.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRight.Image")));
            this.tbtnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnRight.Name = "tbtnRight";
            this.tbtnRight.Size = new System.Drawing.Size(23, 22);
            this.tbtnRight.Text = "toolStripButton4";
            this.tbtnRight.ToolTipText = "右";
            this.tbtnRight.Click += new System.EventHandler(this.tbtnRight_Click);
            // 
            // btnAlignCenter
            // 
            this.btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter.Image = global::TempertureEditor.Properties.Resources.Webcontrol_ConnectionsZone;
            this.btnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignCenter.Name = "btnAlignCenter";
            this.btnAlignCenter.Size = new System.Drawing.Size(23, 22);
            this.btnAlignCenter.Text = "居中对齐";
            this.btnAlignCenter.ToolTipText = "居中对齐";
            this.btnAlignCenter.Click += new System.EventHandler(this.btnAlignCenter_Click);
            // 
            // tcboreType
            // 
            this.tcboreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcboreType.Items.AddRange(new object[] {
            "选中项",
            "整体"});
            this.tcboreType.Name = "tcboreType";
            this.tcboreType.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDataBind
            // 
            this.tbtnDataBind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDataBind.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDataBind.Image")));
            this.tbtnDataBind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDataBind.Name = "tbtnDataBind";
            this.tbtnDataBind.Size = new System.Drawing.Size(23, 22);
            this.tbtnDataBind.Text = "绑定数据";
            this.tbtnDataBind.Click += new System.EventHandler(this.tbtnDataBind_Click);
            // 
            // tbtnloadtempleFile
            // 
            this.tbtnloadtempleFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnloadtempleFile.Image = ((System.Drawing.Image)(resources.GetObject("tbtnloadtempleFile.Image")));
            this.tbtnloadtempleFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnloadtempleFile.Name = "tbtnloadtempleFile";
            this.tbtnloadtempleFile.Size = new System.Drawing.Size(23, 22);
            this.tbtnloadtempleFile.Text = "提取模版";
            this.tbtnloadtempleFile.Click += new System.EventHandler(this.tbtnloadtempleFile_Click);
            // 
            // tbtnnewtempleFile
            // 
            this.tbtnnewtempleFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnnewtempleFile.Image = ((System.Drawing.Image)(resources.GetObject("tbtnnewtempleFile.Image")));
            this.tbtnnewtempleFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnnewtempleFile.Name = "tbtnnewtempleFile";
            this.tbtnnewtempleFile.Size = new System.Drawing.Size(23, 22);
            this.tbtnnewtempleFile.Text = "新建模板";
            this.tbtnnewtempleFile.Click += new System.EventHandler(this.tbtnnewtempleFile_Click);
            // 
            // tbtnsaveas
            // 
            this.tbtnsaveas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnsaveas.Image = ((System.Drawing.Image)(resources.GetObject("tbtnsaveas.Image")));
            this.tbtnsaveas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnsaveas.Name = "tbtnsaveas";
            this.tbtnsaveas.Size = new System.Drawing.Size(23, 22);
            this.tbtnsaveas.Text = "另存为";
            this.tbtnsaveas.Click += new System.EventHandler(this.tbtnsaveas_Click);
            // 
            // tbtnsyncodetype
            // 
            this.tbtnsyncodetype.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnsyncodetype.Image = ((System.Drawing.Image)(resources.GetObject("tbtnsyncodetype.Image")));
            this.tbtnsyncodetype.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnsyncodetype.Name = "tbtnsyncodetype";
            this.tbtnsyncodetype.Size = new System.Drawing.Size(23, 22);
            this.tbtnsyncodetype.Text = "同步模板数据类型至病历数据库常量表";
            this.tbtnsyncodetype.Click += new System.EventHandler(this.tbtnsyncodetype_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer2.Size = new System.Drawing.Size(300, 492);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvTemperture);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "体温单元素";
            // 
            // trvTemperture
            // 
            this.trvTemperture.ContextMenuStrip = this.contextMenuStrip1;
            this.trvTemperture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTemperture.HideSelection = false;
            this.trvTemperture.ImageIndex = 1;
            this.trvTemperture.ImageList = this.imageList1;
            this.trvTemperture.Location = new System.Drawing.Point(3, 17);
            this.trvTemperture.Name = "trvTemperture";
            treeNode1.ForeColor = System.Drawing.Color.Red;
            treeNode1.Name = "pens";
            treeNode1.Text = "画笔";
            treeNode2.ForeColor = System.Drawing.Color.Red;
            treeNode2.Name = "fonts";
            treeNode2.Text = "字体";
            treeNode3.ForeColor = System.Drawing.Color.Red;
            treeNode3.Name = "symbol";
            treeNode3.Text = "标签";
            treeNode4.ForeColor = System.Drawing.Color.Blue;
            treeNode4.Name = "element";
            treeNode4.Text = "体温单元素";
            treeNode5.ForeColor = System.Drawing.Color.Green;
            treeNode5.Name = "vdataset";
            treeNode5.Text = "数据设置";
            this.trvTemperture.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.trvTemperture.SelectedImageIndex = 1;
            this.trvTemperture.Size = new System.Drawing.Size(294, 250);
            this.trvTemperture.TabIndex = 0;
            this.trvTemperture.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTemperture_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.创建主边框ToolStripMenuItem,
            this.添加图片ToolStripMenuItem,
            this.画线ToolStripMenuItem,
            this.添加文字ToolStripMenuItem,
            this.添加矩形区域ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.删除对象ToolStripMenuItem,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 176);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // 创建主边框ToolStripMenuItem
            // 
            this.创建主边框ToolStripMenuItem.Name = "创建主边框ToolStripMenuItem";
            this.创建主边框ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.创建主边框ToolStripMenuItem.Text = "创建体温单主区域";
            this.创建主边框ToolStripMenuItem.Click += new System.EventHandler(this.创建主边框ToolStripMenuItem_Click);
            // 
            // 添加图片ToolStripMenuItem
            // 
            this.添加图片ToolStripMenuItem.Name = "添加图片ToolStripMenuItem";
            this.添加图片ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.添加图片ToolStripMenuItem.Text = "添加图片";
            this.添加图片ToolStripMenuItem.Click += new System.EventHandler(this.添加图片ToolStripMenuItem_Click);
            // 
            // 画线ToolStripMenuItem
            // 
            this.画线ToolStripMenuItem.Name = "画线ToolStripMenuItem";
            this.画线ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.画线ToolStripMenuItem.Text = "添加画线";
            this.画线ToolStripMenuItem.Click += new System.EventHandler(this.画线ToolStripMenuItem_Click);
            // 
            // 添加文字ToolStripMenuItem
            // 
            this.添加文字ToolStripMenuItem.Name = "添加文字ToolStripMenuItem";
            this.添加文字ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.添加文字ToolStripMenuItem.Text = "添加文字";
            this.添加文字ToolStripMenuItem.Click += new System.EventHandler(this.添加文字ToolStripMenuItem_Click);
            // 
            // 添加矩形区域ToolStripMenuItem
            // 
            this.添加矩形区域ToolStripMenuItem.Name = "添加矩形区域ToolStripMenuItem";
            this.添加矩形区域ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.添加矩形区域ToolStripMenuItem.Text = "添加矩形区域";
            this.添加矩形区域ToolStripMenuItem.Click += new System.EventHandler(this.添加矩形区域ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 6);
            // 
            // 删除对象ToolStripMenuItem
            // 
            this.删除对象ToolStripMenuItem.Name = "删除对象ToolStripMenuItem";
            this.删除对象ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.删除对象ToolStripMenuItem.Text = "删除对象";
            this.删除对象ToolStripMenuItem.Click += new System.EventHandler(this.删除对象ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 6);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "02094.ico");
            this.imageList1.Images.SetKeyName(1, "NOTEPA~1.ICO");
            this.imageList1.Images.SetKeyName(2, "NOTEPA~2.ICO");
            this.imageList1.Images.SetKeyName(3, "NOTEPA~3.ICO");
            this.imageList1.Images.SetKeyName(4, "NOTEPA~5.ICO");
            this.imageList1.Images.SetKeyName(5, "01042.ico");
            this.imageList1.Images.SetKeyName(6, "06050.ico");
            this.imageList1.Images.SetKeyName(7, "ButtonX.ico");
            this.imageList1.Images.SetKeyName(8, "PEN04.ICO");
            this.imageList1.Images.SetKeyName(9, "ExpandablePanel.ico");
            this.imageList1.Images.SetKeyName(10, "06578.ico");
            this.imageList1.Images.SetKeyName(11, "00060.ico");
            this.imageList1.Images.SetKeyName(12, "03517.ico");
            this.imageList1.Images.SetKeyName(13, "reversi.ico");
            this.imageList1.Images.SetKeyName(14, "TextFile.ico");
            this.imageList1.Images.SetKeyName(15, "StyleSheet.ico");
            this.imageList1.Images.SetKeyName(16, "03977.ico");
            this.imageList1.Images.SetKeyName(17, "02087.ico");
            this.imageList1.Images.SetKeyName(18, "ARW06DN.ICO");
            this.imageList1.Images.SetKeyName(19, "ARW06LT.ICO");
            this.imageList1.Images.SetKeyName(20, "ARW06RT.ICO");
            this.imageList1.Images.SetKeyName(21, "ARW06UP.ICO");
            this.imageList1.Images.SetKeyName(22, "Icon1.ico");
            this.imageList1.Images.SetKeyName(23, "GRAPH02.ICO");
            this.imageList1.Images.SetKeyName(24, "Provider.ico");
            this.imageList1.Images.SetKeyName(25, "打印.ico");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnAddPen,
            this.tbtnFont,
            this.toolStripSeparator1,
            this.tbtnAddLine,
            this.tbtnAddRec,
            this.tbtnAddText,
            this.tbtnAddDataType,
            this.tbtnAddImage,
            this.toolStripSeparator4,
            this.tbtnDataType,
            this.tbtnTextType,
            this.toolStripSeparator6,
            this.tbtnDel,
            this.tbtnReflesh});
            this.toolStrip2.Location = new System.Drawing.Point(3, 267);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(294, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tbtnAddPen
            // 
            this.tbtnAddPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddPen.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddPen.Image")));
            this.tbtnAddPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddPen.Name = "tbtnAddPen";
            this.tbtnAddPen.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddPen.Text = "添加画笔";
            this.tbtnAddPen.Click += new System.EventHandler(this.tbtnAddPen_Click);
            // 
            // tbtnFont
            // 
            this.tbtnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFont.Enabled = false;
            this.tbtnFont.Image = ((System.Drawing.Image)(resources.GetObject("tbtnFont.Image")));
            this.tbtnFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFont.Name = "tbtnFont";
            this.tbtnFont.Size = new System.Drawing.Size(23, 22);
            this.tbtnFont.Text = "添加字体";
            this.tbtnFont.Click += new System.EventHandler(this.tbtnFont_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnAddLine
            // 
            this.tbtnAddLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddLine.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddLine.Image")));
            this.tbtnAddLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddLine.Name = "tbtnAddLine";
            this.tbtnAddLine.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddLine.Text = "添加线";
            this.tbtnAddLine.Click += new System.EventHandler(this.tbtnAddLine_Click);
            // 
            // tbtnAddRec
            // 
            this.tbtnAddRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddRec.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddRec.Image")));
            this.tbtnAddRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddRec.Name = "tbtnAddRec";
            this.tbtnAddRec.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddRec.Text = "添加矩形框";
            this.tbtnAddRec.Click += new System.EventHandler(this.tbtnAddRec_Click);
            // 
            // tbtnAddText
            // 
            this.tbtnAddText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddText.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddText.Image")));
            this.tbtnAddText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddText.Name = "tbtnAddText";
            this.tbtnAddText.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddText.Text = "添加文字";
            this.tbtnAddText.Click += new System.EventHandler(this.tbtnAddText_Click);
            // 
            // tbtnAddDataType
            // 
            this.tbtnAddDataType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddDataType.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddDataType.Image")));
            this.tbtnAddDataType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddDataType.Name = "tbtnAddDataType";
            this.tbtnAddDataType.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddDataType.Text = "添加数据设置";
            this.tbtnAddDataType.Click += new System.EventHandler(this.tbtnAddDataType_Click);
            // 
            // tbtnAddImage
            // 
            this.tbtnAddImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddImage.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddImage.Image")));
            this.tbtnAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddImage.Name = "tbtnAddImage";
            this.tbtnAddImage.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddImage.Text = "toolStripButton1";
            this.tbtnAddImage.Click += new System.EventHandler(this.tbtnAddImage_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDataType
            // 
            this.tbtnDataType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDataType.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDataType.Image")));
            this.tbtnDataType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDataType.Name = "tbtnDataType";
            this.tbtnDataType.Size = new System.Drawing.Size(23, 22);
            this.tbtnDataType.Text = "点线数据设置";
            this.tbtnDataType.Click += new System.EventHandler(this.tbtnDataType_Click);
            // 
            // tbtnTextType
            // 
            this.tbtnTextType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnTextType.Image = ((System.Drawing.Image)(resources.GetObject("tbtnTextType.Image")));
            this.tbtnTextType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnTextType.Name = "tbtnTextType";
            this.tbtnTextType.Size = new System.Drawing.Size(23, 22);
            this.tbtnTextType.Text = "文字数据设置";
            this.tbtnTextType.Click += new System.EventHandler(this.tbtnTextType_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDel
            // 
            this.tbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDel.Image")));
            this.tbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDel.Name = "tbtnDel";
            this.tbtnDel.Size = new System.Drawing.Size(23, 22);
            this.tbtnDel.Text = "删除元素";
            this.tbtnDel.Click += new System.EventHandler(this.tbtnDel_Click);
            // 
            // tbtnReflesh
            // 
            this.tbtnReflesh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnReflesh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnReflesh.Name = "tbtnReflesh";
            this.tbtnReflesh.Size = new System.Drawing.Size(23, 22);
            this.tbtnReflesh.Text = "刷新";
            this.tbtnReflesh.Click += new System.EventHandler(this.tbtnReflesh_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(300, 193);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ucTempertureEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucTempertureEditor";
            this.Size = new System.Drawing.Size(913, 492);
            this.Load += new System.EventHandler(this.ucTempertureEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTemperatureShow)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picTemperatureShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView trvTemperture;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 画线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加文字ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建主边框ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 添加矩形区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 删除对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnPrintShow;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tbtnAddPen;
        private System.Windows.Forms.ToolStripButton tbtnFont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnAddLine;
        private System.Windows.Forms.ToolStripButton tbtnAddRec;
        private System.Windows.Forms.ToolStripButton tbtnAddText;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlbllocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnUp;
        private System.Windows.Forms.ToolStripButton tbtnDowm;
        private System.Windows.Forms.ToolStripButton tbtnLeft;
        private System.Windows.Forms.ToolStripButton tbtnRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox tcboreType;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tbtnDel;
        private System.Windows.Forms.ToolStripButton tbtnReflesh;
        private System.Windows.Forms.ToolStripButton tbtnDataBind;
        private System.Windows.Forms.ToolStripButton tbtnAddDataType;
        private System.Windows.Forms.ToolStripMenuItem 添加图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tbtnAddImage;
        private System.Windows.Forms.ToolStripButton tbtnDataType;
        private System.Windows.Forms.ToolStripButton tbtnTextType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripButton tbtnloadtempleFile;
        private System.Windows.Forms.ToolStripButton tbtnnewtempleFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton tbtnsaveas;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton tbtnsyncodetype;
    }
}