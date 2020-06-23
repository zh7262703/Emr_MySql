namespace Base_Function.BASE_DATA
{
    partial class ucTextRead
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTextRead));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCNameID = new System.Windows.Forms.TextBox();
            this.txtCname = new System.Windows.Forms.TextBox();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnReflesh = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnModify = new DevComponents.DotNetBar.ButtonX();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSNameID = new System.Windows.Forms.TextBox();
            this.txtSTitleName = new System.Windows.Forms.TextBox();
            this.txtCTitleName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textSInputName = new System.Windows.Forms.TextBox();
            this.rdoSInputYes = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoCYes = new System.Windows.Forms.RadioButton();
            this.rdoSYes = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCInputName = new System.Windows.Forms.TextBox();
            this.rdoCinputYes = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.trvText = new System.Windows.Forms.TreeView();
            this.imgListBook = new System.Windows.Forms.ImageList(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lisBoxDocTittle = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(420, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 188;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(340, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 187;
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(260, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 186;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(64, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 119;
            this.label1.Text = "当前文书名称：";
            this.label1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(379, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "当前文书ID：";
            this.label8.Visible = false;
            // 
            // txtCNameID
            // 
            this.txtCNameID.Enabled = false;
            this.txtCNameID.Location = new System.Drawing.Point(462, 85);
            this.txtCNameID.MaxLength = 50;
            this.txtCNameID.Name = "txtCNameID";
            this.txtCNameID.Size = new System.Drawing.Size(126, 21);
            this.txtCNameID.TabIndex = 2;
            this.txtCNameID.Visible = false;
            // 
            // txtCname
            // 
            this.txtCname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCname.Location = new System.Drawing.Point(190, 85);
            this.txtCname.MaxLength = 20;
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(173, 21);
            this.txtCname.TabIndex = 1;
            this.txtCname.Visible = false;
            this.txtCname.TextChanged += new System.EventHandler(this.txtCname_TextChanged);
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.ContextMenuStrip = this.contextMenuStrip1;
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(453, 294);
            this.ucGridviewX1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(459, 318);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 4;
            this.groupPanel2.Text = "读取信息列表";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnReflesh);
            this.groupPanel3.Controls.Add(this.btnAdd);
            this.groupPanel3.Controls.Add(this.btnModify);
            this.groupPanel3.Controls.Add(this.label9);
            this.groupPanel3.Controls.Add(this.label7);
            this.groupPanel3.Controls.Add(this.txtSNameID);
            this.groupPanel3.Controls.Add(this.txtSTitleName);
            this.groupPanel3.Controls.Add(this.txtCTitleName);
            this.groupPanel3.Controls.Add(this.panel1);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Controls.Add(this.txtSName);
            this.groupPanel3.Controls.Add(this.panel3);
            this.groupPanel3.Controls.Add(this.btnCancel);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.btnDelete);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Controls.Add(this.label8);
            this.groupPanel3.Controls.Add(this.txtCNameID);
            this.groupPanel3.Controls.Add(this.txtCname);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(0, 318);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(601, 87);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 3;
            this.groupPanel3.Text = "文书读取关系信息编辑";
            // 
            // btnReflesh
            // 
            this.btnReflesh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReflesh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReflesh.Location = new System.Drawing.Point(501, 30);
            this.btnReflesh.Name = "btnReflesh";
            this.btnReflesh.Size = new System.Drawing.Size(75, 23);
            this.btnReflesh.TabIndex = 355;
            this.btnReflesh.Text = "刷新(&R)";
            this.btnReflesh.Click += new System.EventHandler(this.btnReflesh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(99, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 354;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModify.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModify.Location = new System.Drawing.Point(179, 30);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 353;
            this.btnModify.Text = "修改(&M)";
            this.btnModify.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(90, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 352;
            this.label9.Text = "目标文本块标题名称：";
            this.label9.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(148, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 351;
            this.label7.Text = "当前文本块标题名称：";
            // 
            // txtSNameID
            // 
            this.txtSNameID.Enabled = false;
            this.txtSNameID.Location = new System.Drawing.Point(488, 100);
            this.txtSNameID.MaxLength = 50;
            this.txtSNameID.Name = "txtSNameID";
            this.txtSNameID.Size = new System.Drawing.Size(126, 21);
            this.txtSNameID.TabIndex = 350;
            this.txtSNameID.Visible = false;
            // 
            // txtSTitleName
            // 
            this.txtSTitleName.Location = new System.Drawing.Point(216, 126);
            this.txtSTitleName.Name = "txtSTitleName";
            this.txtSTitleName.Size = new System.Drawing.Size(173, 21);
            this.txtSTitleName.TabIndex = 5;
            this.txtSTitleName.Visible = false;
            // 
            // txtCTitleName
            // 
            this.txtCTitleName.Location = new System.Drawing.Point(274, 3);
            this.txtCTitleName.Name = "txtCTitleName";
            this.txtCTitleName.Size = new System.Drawing.Size(173, 21);
            this.txtCTitleName.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textSInputName);
            this.panel1.Controls.Add(this.rdoSInputYes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rdoCYes);
            this.panel1.Controls.Add(this.rdoSYes);
            this.panel1.Location = new System.Drawing.Point(32, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 31);
            this.panel1.TabIndex = 349;
            this.panel1.Visible = false;
            // 
            // textSInputName
            // 
            this.textSInputName.Enabled = false;
            this.textSInputName.Location = new System.Drawing.Point(283, 31);
            this.textSInputName.Name = "textSInputName";
            this.textSInputName.Size = new System.Drawing.Size(173, 21);
            this.textSInputName.TabIndex = 5;
            this.textSInputName.Visible = false;
            // 
            // rdoSInputYes
            // 
            this.rdoSInputYes.AutoSize = true;
            this.rdoSInputYes.Location = new System.Drawing.Point(158, 31);
            this.rdoSInputYes.Name = "rdoSInputYes";
            this.rdoSInputYes.Size = new System.Drawing.Size(119, 16);
            this.rdoSInputYes.TabIndex = 1;
            this.rdoSInputYes.Text = "是，输入域名称：";
            this.rdoSInputYes.UseVisualStyleBackColor = true;
            this.rdoSInputYes.Visible = false;
            this.rdoSInputYes.CheckedChanged += new System.EventHandler(this.rdoSInputYes_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "否是新增的输入域：";
            this.label2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "是否是标题：";
            this.label4.Visible = false;
            // 
            // rdoCYes
            // 
            this.rdoCYes.AutoSize = true;
            this.rdoCYes.Checked = true;
            this.rdoCYes.Location = new System.Drawing.Point(105, 12);
            this.rdoCYes.Name = "rdoCYes";
            this.rdoCYes.Size = new System.Drawing.Size(119, 16);
            this.rdoCYes.TabIndex = 1;
            this.rdoCYes.TabStop = true;
            this.rdoCYes.Text = "文本块标题名称：";
            this.rdoCYes.UseVisualStyleBackColor = true;
            this.rdoCYes.CheckedChanged += new System.EventHandler(this.rdoCYes_CheckedChanged);
            // 
            // rdoSYes
            // 
            this.rdoSYes.AutoSize = true;
            this.rdoSYes.Checked = true;
            this.rdoSYes.Location = new System.Drawing.Point(229, 10);
            this.rdoSYes.Name = "rdoSYes";
            this.rdoSYes.Size = new System.Drawing.Size(119, 16);
            this.rdoSYes.TabIndex = 1;
            this.rdoSYes.TabStop = true;
            this.rdoSYes.Text = "文本块标题名称：";
            this.rdoSYes.UseVisualStyleBackColor = true;
            this.rdoSYes.CheckedChanged += new System.EventHandler(this.rdoSYes_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(90, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 348;
            this.label5.Text = "目标文书名称：";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(405, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 347;
            this.label6.Text = "目标文书ID：";
            this.label6.Visible = false;
            // 
            // txtSName
            // 
            this.txtSName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSName.Location = new System.Drawing.Point(216, 100);
            this.txtSName.MaxLength = 20;
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(173, 21);
            this.txtSName.TabIndex = 345;
            this.txtSName.Visible = false;
            this.txtSName.TextChanged += new System.EventHandler(this.txtSName_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtCInputName);
            this.panel3.Controls.Add(this.rdoCinputYes);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Location = new System.Drawing.Point(29, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(625, 28);
            this.panel3.TabIndex = 344;
            this.panel3.Visible = false;
            // 
            // txtCInputName
            // 
            this.txtCInputName.Enabled = false;
            this.txtCInputName.Location = new System.Drawing.Point(287, 32);
            this.txtCInputName.Name = "txtCInputName";
            this.txtCInputName.Size = new System.Drawing.Size(173, 21);
            this.txtCInputName.TabIndex = 5;
            this.txtCInputName.Visible = false;
            // 
            // rdoCinputYes
            // 
            this.rdoCinputYes.AutoSize = true;
            this.rdoCinputYes.Location = new System.Drawing.Point(155, 34);
            this.rdoCinputYes.Name = "rdoCinputYes";
            this.rdoCinputYes.Size = new System.Drawing.Size(119, 16);
            this.rdoCinputYes.TabIndex = 1;
            this.rdoCinputYes.Text = "是，输入域名称：";
            this.rdoCinputYes.UseVisualStyleBackColor = true;
            this.rdoCinputYes.Visible = false;
            this.rdoCinputYes.CheckedChanged += new System.EventHandler(this.rdoCinputYes_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "否是新增的输入域：";
            this.label3.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(25, 7);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 12);
            this.label31.TabIndex = 2;
            this.label31.Text = "是否是标题：";
            this.label31.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.expandableSplitter1);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel4);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(812, 405);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 6;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.trvText);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(207, 405);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "文书列表";
            // 
            // trvText
            // 
            this.trvText.CheckBoxes = true;
            this.trvText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvText.HideSelection = false;
            this.trvText.ImageIndex = 0;
            this.trvText.ImageList = this.imgListBook;
            this.trvText.Location = new System.Drawing.Point(0, 0);
            this.trvText.Name = "trvText";
            this.trvText.SelectedImageIndex = 0;
            this.trvText.Size = new System.Drawing.Size(201, 381);
            this.trvText.TabIndex = 0;
            this.trvText.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvText_AfterCheck);
            this.trvText.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvText_NodeMouseClick);
            this.trvText.Click += new System.EventHandler(this.trvText_Click);
            // 
            // imgListBook
            // 
            this.imgListBook.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBook.ImageStream")));
            this.imgListBook.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBook.Images.SetKeyName(0, "paintm.ico");
            this.imgListBook.Images.SetKeyName(1, "joym.ico");
            this.imgListBook.Images.SetKeyName(2, "manilla.ico");
            this.imgListBook.Images.SetKeyName(3, "net1m.ico");
            this.imgListBook.Images.SetKeyName(4, "net2m.ico");
            this.imgListBook.Images.SetKeyName(5, "New Text Doc.ico");
            this.imgListBook.Images.SetKeyName(6, "NOTEPA~1.ICO");
            this.imgListBook.Images.SetKeyName(7, "NOTEPA~2.ICO");
            this.imgListBook.Images.SetKeyName(8, "NOTEPA~3.ICO");
            this.imgListBook.Images.SetKeyName(9, "NOTEPA~4.ICO");
            this.imgListBook.Images.SetKeyName(10, "NOTEPA~5.ICO");
            this.imgListBook.Images.SetKeyName(11, "notesg.ico");
            this.imgListBook.Images.SetKeyName(12, "notesm.ico");
            this.imgListBook.Images.SetKeyName(13, "BETEXT~1.ICO");
            this.imgListBook.Images.SetKeyName(14, "FORMATED.ICO");
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandableSplitter1.ExpandableControl = this.groupPanel4;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(459, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 318);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 6;
            this.expandableSplitter1.TabStop = false;
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.lisBoxDocTittle);
            this.groupPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupPanel4.Location = new System.Drawing.Point(465, 0);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(136, 318);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 5;
            this.groupPanel4.Text = "文书标题";
            // 
            // lisBoxDocTittle
            // 
            this.lisBoxDocTittle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisBoxDocTittle.FormattingEnabled = true;
            this.lisBoxDocTittle.ItemHeight = 12;
            this.lisBoxDocTittle.Location = new System.Drawing.Point(0, 0);
            this.lisBoxDocTittle.Name = "lisBoxDocTittle";
            this.lisBoxDocTittle.Size = new System.Drawing.Size(130, 292);
            this.lisBoxDocTittle.TabIndex = 0;
            this.lisBoxDocTittle.SelectedIndexChanged += new System.EventHandler(this.lisBoxDocTittle_SelectedIndexChanged);
            // 
            // ucTextRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucTextRead";
            this.Size = new System.Drawing.Size(812, 405);
            this.Load += new System.EventHandler(this.ucTextRead_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCNameID;
        private System.Windows.Forms.TextBox txtCname;
        private Bifrost.ucGridviewX ucGridviewX1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtCInputName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoCinputYes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCTitleName;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.RadioButton rdoCYes;
        private System.Windows.Forms.TextBox txtSNameID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textSInputName;
        private System.Windows.Forms.TextBox txtSTitleName;
        private System.Windows.Forms.RadioButton rdoSInputYes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoSYes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ImageList imgListBook;
        private System.Windows.Forms.TreeView trvText;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnModify;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private System.Windows.Forms.ListBox lisBoxDocTittle;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.ButtonX btnReflesh;
    }
}
