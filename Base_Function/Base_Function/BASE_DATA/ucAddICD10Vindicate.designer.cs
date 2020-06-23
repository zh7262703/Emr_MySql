namespace Base_Function.BASE_DATA
{
    partial class ucAddICD10Vindicate 
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtVindicateName = new System.Windows.Forms.TextBox();
            this.cxbisDiagnoseCode = new System.Windows.Forms.CheckBox();
            this.cobisberbalistdocter = new System.Windows.Forms.CheckBox();
            this.txtDiaselogCode = new System.Windows.Forms.TextBox();
            this.txtfivecode = new System.Windows.Forms.TextBox();
            this.txtspellcode = new System.Windows.Forms.TextBox();
            this.txtDaiMa = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMuLuID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.btnconfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(334, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "诊断名：";
            // 
            // txtVindicateName
            // 
            this.txtVindicateName.Location = new System.Drawing.Point(409, 5);
            this.txtVindicateName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVindicateName.Name = "txtVindicateName";
            this.txtVindicateName.Size = new System.Drawing.Size(198, 23);
            this.txtVindicateName.TabIndex = 0;
            // 
            // cxbisDiagnoseCode
            // 
            this.cxbisDiagnoseCode.AutoSize = true;
            this.cxbisDiagnoseCode.BackColor = System.Drawing.Color.Transparent;
            this.cxbisDiagnoseCode.Location = new System.Drawing.Point(407, 67);
            this.cxbisDiagnoseCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cxbisDiagnoseCode.Name = "cxbisDiagnoseCode";
            this.cxbisDiagnoseCode.Size = new System.Drawing.Size(122, 21);
            this.cxbisDiagnoseCode.TabIndex = 27;
            this.cxbisDiagnoseCode.Text = "是否ICD10诊断码";
            this.cxbisDiagnoseCode.UseVisualStyleBackColor = false;
            this.cxbisDiagnoseCode.CheckedChanged += new System.EventHandler(this.cxbisDiagnoseCode_CheckedChanged);
            // 
            // cobisberbalistdocter
            // 
            this.cobisberbalistdocter.AutoSize = true;
            this.cobisberbalistdocter.BackColor = System.Drawing.Color.Transparent;
            this.cobisberbalistdocter.Location = new System.Drawing.Point(291, 67);
            this.cobisberbalistdocter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cobisberbalistdocter.Name = "cobisberbalistdocter";
            this.cobisberbalistdocter.Size = new System.Drawing.Size(75, 21);
            this.cobisberbalistdocter.TabIndex = 26;
            this.cobisberbalistdocter.Text = "是否中医";
            this.cobisberbalistdocter.UseVisualStyleBackColor = false;
            // 
            // txtDiaselogCode
            // 
            this.txtDiaselogCode.Enabled = false;
            this.txtDiaselogCode.Location = new System.Drawing.Point(685, 64);
            this.txtDiaselogCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiaselogCode.Name = "txtDiaselogCode";
            this.txtDiaselogCode.Size = new System.Drawing.Size(236, 23);
            this.txtDiaselogCode.TabIndex = 25;
            this.txtDiaselogCode.TextChanged += new System.EventHandler(this.txtDiaselogCode_TextChanged);
            this.txtDiaselogCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaselogCode_KeyDown);
            this.txtDiaselogCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiaselogCode_KeyUp);
            // 
            // txtfivecode
            // 
            this.txtfivecode.Location = new System.Drawing.Point(134, 64);
            this.txtfivecode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtfivecode.Name = "txtfivecode";
            this.txtfivecode.ReadOnly = true;
            this.txtfivecode.Size = new System.Drawing.Size(116, 23);
            this.txtfivecode.TabIndex = 24;
            // 
            // txtspellcode
            // 
            this.txtspellcode.Location = new System.Drawing.Point(805, 18);
            this.txtspellcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtspellcode.Name = "txtspellcode";
            this.txtspellcode.ReadOnly = true;
            this.txtspellcode.Size = new System.Drawing.Size(116, 23);
            this.txtspellcode.TabIndex = 23;
            // 
            // txtDaiMa
            // 
            this.txtDaiMa.Location = new System.Drawing.Point(134, 18);
            this.txtDaiMa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDaiMa.Name = "txtDaiMa";
            this.txtDaiMa.ReadOnly = true;
            this.txtDaiMa.Size = new System.Drawing.Size(116, 23);
            this.txtDaiMa.TabIndex = 22;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(343, 18);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(116, 23);
            this.txtName.TabIndex = 21;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // txtMuLuID
            // 
            this.txtMuLuID.Location = new System.Drawing.Point(560, 18);
            this.txtMuLuID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMuLuID.Name = "txtMuLuID";
            this.txtMuLuID.ReadOnly = true;
            this.txtMuLuID.Size = new System.Drawing.Size(116, 23);
            this.txtMuLuID.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "ICD10诊断码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(68, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "五笔码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(740, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "拼音码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "目录ID：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "名称：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(82, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "代码：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtVindicateName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1046, 71);
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
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "查询";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(625, 0);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(87, 33);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(1046, 600);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 71);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1046, 333);
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
            this.groupPanel2.Text = "诊断名称列表";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(1040, 307);
            this.ucGridviewX1.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btncancel);
            this.groupPanel3.Controls.Add(this.btnconfirm);
            this.groupPanel3.Controls.Add(this.btnDelete);
            this.groupPanel3.Controls.Add(this.btnUpdate);
            this.groupPanel3.Controls.Add(this.btnAdd);
            this.groupPanel3.Controls.Add(this.cxbisDiagnoseCode);
            this.groupPanel3.Controls.Add(this.label7);
            this.groupPanel3.Controls.Add(this.cobisberbalistdocter);
            this.groupPanel3.Controls.Add(this.txtDiaselogCode);
            this.groupPanel3.Controls.Add(this.txtfivecode);
            this.groupPanel3.Controls.Add(this.txtspellcode);
            this.groupPanel3.Controls.Add(this.txtDaiMa);
            this.groupPanel3.Controls.Add(this.txtName);
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Controls.Add(this.txtMuLuID);
            this.groupPanel3.Controls.Add(this.label3);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Controls.Add(this.label4);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1046, 190);
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
            this.groupPanel3.Text = "ICD10编辑列表";
            // 
            // btncancel
            // 
            this.btncancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncancel.Location = new System.Drawing.Point(664, 114);
            this.btncancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(87, 33);
            this.btncancel.TabIndex = 42;
            this.btncancel.Text = "取 消";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnconfirm
            // 
            this.btnconfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnconfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnconfirm.Location = new System.Drawing.Point(569, 114);
            this.btnconfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(87, 33);
            this.btnconfirm.TabIndex = 41;
            this.btnconfirm.Text = "确 定";
            this.btnconfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(475, 114);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 33);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "删 除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(380, 114);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 33);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.Text = "修 改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(286, 114);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 33);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "添 加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucAddICD10Vindicate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucAddICD10Vindicate";
            this.Size = new System.Drawing.Size(1046, 600);
            this.Load += new System.EventHandler(this.frmAddICD10Vindicate_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVindicateName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cxbisDiagnoseCode;
        private System.Windows.Forms.CheckBox cobisberbalistdocter;
        private System.Windows.Forms.TextBox txtDiaselogCode;
        private System.Windows.Forms.TextBox txtfivecode;
        private System.Windows.Forms.TextBox txtspellcode;
        private System.Windows.Forms.TextBox txtDaiMa;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMuLuID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btncancel;
        private DevComponents.DotNetBar.ButtonX btnconfirm;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private Bifrost.ucGridviewX ucGridviewX1;
    }
}