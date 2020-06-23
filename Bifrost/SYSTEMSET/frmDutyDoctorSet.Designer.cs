namespace Bifrost.SYSTEMSET
{
    partial class frmDutyDoctorSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDutyDoctorSet));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkAllDoctors = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.advDoctors = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle9 = new DevComponents.DotNetBar.ElementStyle();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.atrvRole = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle6 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle7 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle8 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle11 = new DevComponents.DotNetBar.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkAllSelectDoctors = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.advSelectDoctors = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector3 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle10 = new DevComponents.DotNetBar.ElementStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advDoctors)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atrvRole)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advSelectDoctors)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.chkAllDoctors);
            this.groupPanel1.Controls.Add(this.advDoctors);
            this.groupPanel1.Location = new System.Drawing.Point(136, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(136, 285);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "医生列表";
            // 
            // chkAllDoctors
            // 
            this.chkAllDoctors.BackColor = System.Drawing.Color.Transparent;
            this.chkAllDoctors.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllDoctors.Location = new System.Drawing.Point(0, 0);
            this.chkAllDoctors.Name = "chkAllDoctors";
            this.chkAllDoctors.Size = new System.Drawing.Size(130, 19);
            this.chkAllDoctors.TabIndex = 2;
            this.chkAllDoctors.Text = "全选";
            this.chkAllDoctors.CheckedChanged += new System.EventHandler(this.chkAllDoctors_CheckedChanged);
            // 
            // advDoctors
            // 
            this.advDoctors.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advDoctors.AllowDrop = true;
            this.advDoctors.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advDoctors.BackgroundStyle.Class = "TreeBorderKey";
            this.advDoctors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.advDoctors.ImageList = this.imageList1;
            this.advDoctors.Location = new System.Drawing.Point(0, 20);
            this.advDoctors.MultiSelect = true;
            this.advDoctors.Name = "advDoctors";
            this.advDoctors.NodesConnector = this.nodeConnector2;
            this.advDoctors.NodeStyle = this.elementStyle2;
            this.advDoctors.PathSeparator = ";";
            this.advDoctors.SelectionPerCell = true;
            this.advDoctors.Size = new System.Drawing.Size(130, 241);
            this.advDoctors.Styles.Add(this.elementStyle2);
            this.advDoctors.Styles.Add(this.elementStyle9);
            this.advDoctors.TabIndex = 1;
            this.advDoctors.Text = "advTree2";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "上2.gif");
            this.imageList1.Images.SetKeyName(1, "左1.gif");
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle9
            // 
            this.elementStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.elementStyle9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.elementStyle9.BackColorGradientAngle = 90;
            this.elementStyle9.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderBottomWidth = 1;
            this.elementStyle9.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle9.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderLeftWidth = 1;
            this.elementStyle9.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderRightWidth = 1;
            this.elementStyle9.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderTopWidth = 1;
            this.elementStyle9.CornerDiameter = 4;
            this.elementStyle9.Description = "Green";
            this.elementStyle9.Name = "elementStyle9";
            this.elementStyle9.PaddingBottom = 1;
            this.elementStyle9.PaddingLeft = 1;
            this.elementStyle9.PaddingRight = 1;
            this.elementStyle9.PaddingTop = 1;
            this.elementStyle9.TextColor = System.Drawing.Color.Black;
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(281, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 36);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = ">";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDel.Location = new System.Drawing.Point(281, 140);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(35, 36);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "<";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.atrvRole);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(130, 285);
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
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "医生角色表";
            // 
            // atrvRole
            // 
            this.atrvRole.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.atrvRole.AllowDrop = true;
            this.atrvRole.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.atrvRole.BackgroundStyle.Class = "TreeBorderKey";
            this.atrvRole.ColumnsVisible = false;
            this.atrvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atrvRole.GridColumnLines = false;
            this.atrvRole.ImageIndex = 1;
            this.atrvRole.ImageList = this.imageList1;
            this.atrvRole.Location = new System.Drawing.Point(0, 0);
            this.atrvRole.Name = "atrvRole";
            this.atrvRole.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node4});
            this.atrvRole.NodesConnector = this.nodeConnector1;
            this.atrvRole.NodeStyle = this.elementStyle1;
            this.atrvRole.PathSeparator = ";";
            this.atrvRole.Size = new System.Drawing.Size(124, 261);
            this.atrvRole.Styles.Add(this.elementStyle1);
            this.atrvRole.Styles.Add(this.elementStyle4);
            this.atrvRole.Styles.Add(this.elementStyle5);
            this.atrvRole.Styles.Add(this.elementStyle6);
            this.atrvRole.Styles.Add(this.elementStyle7);
            this.atrvRole.Styles.Add(this.elementStyle8);
            this.atrvRole.Styles.Add(this.elementStyle11);
            this.atrvRole.TabIndex = 0;
            this.atrvRole.Text = "advTree1";
            this.atrvRole.Click += new System.EventHandler(this.atrvRole_Click);
            this.atrvRole.SelectedValueChanged += new System.EventHandler(this.atrvRole_SelectedValueChanged);
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "白班值班医生";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.Text = "夜班值班医生";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.MarginLeft = -20;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle4
            // 
            this.elementStyle4.Name = "elementStyle4";
            // 
            // elementStyle5
            // 
            this.elementStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle5.BackColorGradientAngle = 90;
            this.elementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderBottomWidth = 1;
            this.elementStyle5.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderLeftWidth = 1;
            this.elementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderRightWidth = 1;
            this.elementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderTopWidth = 1;
            this.elementStyle5.CornerDiameter = 4;
            this.elementStyle5.Description = "Blue";
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.PaddingBottom = 1;
            this.elementStyle5.PaddingLeft = 1;
            this.elementStyle5.PaddingRight = 1;
            this.elementStyle5.PaddingTop = 1;
            this.elementStyle5.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle6
            // 
            this.elementStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(108)))), ((int)(((byte)(152)))));
            this.elementStyle6.BackColor2 = System.Drawing.Color.Navy;
            this.elementStyle6.BackColorGradientAngle = 90;
            this.elementStyle6.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderBottomWidth = 1;
            this.elementStyle6.BorderColor = System.Drawing.Color.Navy;
            this.elementStyle6.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderLeftWidth = 1;
            this.elementStyle6.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderRightWidth = 1;
            this.elementStyle6.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderTopWidth = 1;
            this.elementStyle6.CornerDiameter = 4;
            this.elementStyle6.Description = "BlueNight";
            this.elementStyle6.Name = "elementStyle6";
            this.elementStyle6.PaddingBottom = 1;
            this.elementStyle6.PaddingLeft = 1;
            this.elementStyle6.PaddingRight = 1;
            this.elementStyle6.PaddingTop = 1;
            this.elementStyle6.TextColor = System.Drawing.Color.White;
            // 
            // elementStyle7
            // 
            this.elementStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle7.BackColorGradientAngle = 90;
            this.elementStyle7.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderBottomWidth = 1;
            this.elementStyle7.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle7.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderLeftWidth = 1;
            this.elementStyle7.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderRightWidth = 1;
            this.elementStyle7.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderTopWidth = 1;
            this.elementStyle7.CornerDiameter = 4;
            this.elementStyle7.Description = "Blue";
            this.elementStyle7.Name = "elementStyle7";
            this.elementStyle7.PaddingBottom = 1;
            this.elementStyle7.PaddingLeft = 1;
            this.elementStyle7.PaddingRight = 1;
            this.elementStyle7.PaddingTop = 1;
            this.elementStyle7.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle8
            // 
            this.elementStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.elementStyle8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.elementStyle8.BackColorGradientAngle = 90;
            this.elementStyle8.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderBottomWidth = 1;
            this.elementStyle8.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle8.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderLeftWidth = 1;
            this.elementStyle8.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderRightWidth = 1;
            this.elementStyle8.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderTopWidth = 1;
            this.elementStyle8.CornerDiameter = 4;
            this.elementStyle8.Description = "Green";
            this.elementStyle8.Name = "elementStyle8";
            this.elementStyle8.PaddingBottom = 1;
            this.elementStyle8.PaddingLeft = 1;
            this.elementStyle8.PaddingRight = 1;
            this.elementStyle8.PaddingTop = 1;
            this.elementStyle8.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle11
            // 
            this.elementStyle11.Name = "elementStyle11";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 34);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(231, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(152, 5);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(73, 26);
            this.btnSure.TabIndex = 0;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.chkAllSelectDoctors);
            this.groupPanel3.Controls.Add(this.advSelectDoctors);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupPanel3.Location = new System.Drawing.Point(323, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(133, 285);
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
            this.groupPanel3.TabIndex = 5;
            this.groupPanel3.Text = "选中的医生";
            // 
            // chkAllSelectDoctors
            // 
            this.chkAllSelectDoctors.BackColor = System.Drawing.Color.Transparent;
            this.chkAllSelectDoctors.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllSelectDoctors.Location = new System.Drawing.Point(0, 0);
            this.chkAllSelectDoctors.Name = "chkAllSelectDoctors";
            this.chkAllSelectDoctors.Size = new System.Drawing.Size(127, 19);
            this.chkAllSelectDoctors.TabIndex = 3;
            this.chkAllSelectDoctors.Text = "全选";
            this.chkAllSelectDoctors.CheckedChanged += new System.EventHandler(this.chkAllSelectDoctors_CheckedChanged);
            // 
            // advSelectDoctors
            // 
            this.advSelectDoctors.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advSelectDoctors.AllowDrop = true;
            this.advSelectDoctors.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advSelectDoctors.BackgroundStyle.Class = "TreeBorderKey";
            this.advSelectDoctors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.advSelectDoctors.ImageList = this.imageList1;
            this.advSelectDoctors.Location = new System.Drawing.Point(0, 20);
            this.advSelectDoctors.Name = "advSelectDoctors";
            this.advSelectDoctors.NodesConnector = this.nodeConnector3;
            this.advSelectDoctors.NodeStyle = this.elementStyle3;
            this.advSelectDoctors.PathSeparator = ";";
            this.advSelectDoctors.Size = new System.Drawing.Size(127, 241);
            this.advSelectDoctors.Styles.Add(this.elementStyle3);
            this.advSelectDoctors.Styles.Add(this.elementStyle10);
            this.advSelectDoctors.TabIndex = 1;
            this.advSelectDoctors.Text = "advTree3";
            // 
            // nodeConnector3
            // 
            this.nodeConnector3.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle3
            // 
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle10
            // 
            this.elementStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.elementStyle10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.elementStyle10.BackColorGradientAngle = 90;
            this.elementStyle10.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderBottomWidth = 1;
            this.elementStyle10.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle10.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderLeftWidth = 1;
            this.elementStyle10.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderRightWidth = 1;
            this.elementStyle10.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderTopWidth = 1;
            this.elementStyle10.CornerDiameter = 4;
            this.elementStyle10.Description = "Green";
            this.elementStyle10.Name = "elementStyle10";
            this.elementStyle10.PaddingBottom = 1;
            this.elementStyle10.PaddingLeft = 1;
            this.elementStyle10.PaddingRight = 1;
            this.elementStyle10.PaddingTop = 1;
            this.elementStyle10.TextColor = System.Drawing.Color.Black;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupPanel1);
            this.panel2.Controls.Add(this.groupPanel3);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.groupPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 285);
            this.panel2.TabIndex = 6;
            // 
            // frmDutyDoctorSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 319);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDutyDoctorSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "值班医生设置";
            this.Load += new System.EventHandler(this.frmDutyDoctorSet_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advDoctors)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.atrvRole)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advSelectDoctors)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.AdvTree.AdvTree atrvRole;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.AdvTree advDoctors;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.AdvTree.AdvTree advSelectDoctors;
        private DevComponents.AdvTree.NodeConnector nodeConnector3;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.AdvTree.Node node4;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.DotNetBar.ElementStyle elementStyle8;
        private DevComponents.DotNetBar.ElementStyle elementStyle6;
        private DevComponents.DotNetBar.ElementStyle elementStyle7;
        private DevComponents.DotNetBar.ElementStyle elementStyle9;
        private DevComponents.DotNetBar.ElementStyle elementStyle10;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllDoctors;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllSelectDoctors;
        private DevComponents.DotNetBar.ElementStyle elementStyle11;
    }
}