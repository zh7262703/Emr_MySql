namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class CaseSearchMark
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
            this.lklNullCondition = new System.Windows.Forms.LinkLabel();
            this.txtDiagnoseName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxOutSick = new System.Windows.Forms.ComboBox();
            this.cbxOutSection = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxInSection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.dtpTimestart = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chbNewborn = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblCount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.cbxDocumentState = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbxTimeType = new System.Windows.Forms.ComboBox();
            this.chbEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.cbxInSick = new System.Windows.Forms.ComboBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.归档退回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pACSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.医嘱单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lklNullCondition
            // 
            this.lklNullCondition.AutoSize = true;
            this.lklNullCondition.BackColor = System.Drawing.Color.Transparent;
            this.lklNullCondition.Location = new System.Drawing.Point(519, 71);
            this.lklNullCondition.Name = "lklNullCondition";
            this.lklNullCondition.Size = new System.Drawing.Size(77, 12);
            this.lklNullCondition.TabIndex = 24;
            this.lklNullCondition.TabStop = true;
            this.lklNullCondition.Text = "重置条件查询";
            this.lklNullCondition.Click += new System.EventHandler(this.lklNullCondition_Click);
            // 
            // txtDiagnoseName
            // 
            this.txtDiagnoseName.Location = new System.Drawing.Point(75, 67);
            this.txtDiagnoseName.Name = "txtDiagnoseName";
            this.txtDiagnoseName.Size = new System.Drawing.Size(251, 21);
            this.txtDiagnoseName.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(20, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "诊断名：";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "",
            "在院",
            "出院"});
            this.cbxStatus.Location = new System.Drawing.Point(244, 34);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(82, 20);
            this.cbxStatus.TabIndex = 20;
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxDoctor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(71, 34);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(102, 20);
            this.cbxDoctor.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(178, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "病人状态：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(4, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "责任医生：";
            // 
            // cbxOutSick
            // 
            this.cbxOutSick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOutSick.FormattingEnabled = true;
            this.cbxOutSick.Location = new System.Drawing.Point(970, 6);
            this.cbxOutSick.Name = "cbxOutSick";
            this.cbxOutSick.Size = new System.Drawing.Size(102, 20);
            this.cbxOutSick.TabIndex = 16;
            // 
            // cbxOutSection
            // 
            this.cbxOutSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOutSection.FormattingEnabled = true;
            this.cbxOutSection.Location = new System.Drawing.Point(784, 6);
            this.cbxOutSection.Name = "cbxOutSection";
            this.cbxOutSection.Size = new System.Drawing.Size(102, 20);
            this.cbxOutSection.TabIndex = 15;
            this.cbxOutSection.SelectedIndexChanged += new System.EventHandler(this.cbxOutSection_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(899, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "出院病区：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(713, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "出院科室：";
            // 
            // cbxInSection
            // 
            this.cbxInSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInSection.FormattingEnabled = true;
            this.cbxInSection.Location = new System.Drawing.Point(423, 5);
            this.cbxInSection.Name = "cbxInSection";
            this.cbxInSection.Size = new System.Drawing.Size(102, 20);
            this.cbxInSection.TabIndex = 11;
            this.cbxInSection.SelectedIndexChanged += new System.EventHandler(this.cbxInSection_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(531, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "入院病区：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(352, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "入院科室：";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(71, 5);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(102, 21);
            this.txtPid.TabIndex = 7;
            // 
            // dtpTimestart
            // 
            this.dtpTimestart.CustomFormat = "yyyy-MM-dd";
            this.dtpTimestart.Enabled = false;
            this.dtpTimestart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimestart.Location = new System.Drawing.Point(190, 3);
            this.dtpTimestart.Name = "dtpTimestart";
            this.dtpTimestart.Size = new System.Drawing.Size(102, 21);
            this.dtpTimestart.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(224, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(102, 21);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(183, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "住院号：";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.BackColor = System.Drawing.Color.Transparent;
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(1080, 636);
            this.ucC1FlexGrid1.TabIndex = 0;
            this.ucC1FlexGrid1.DoubleClick += new System.EventHandler(this.ucC1FlexGrid1_DoubleClick);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.chbNewborn);
            this.groupPanel1.Controls.Add(this.lblCount);
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.cbxDocumentState);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.groupPanel3);
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.cbxInSick);
            this.groupPanel1.Controls.Add(this.lklNullCondition);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.txtDiagnoseName);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cbxStatus);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Controls.Add(this.cbxDoctor);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.cbxOutSick);
            this.groupPanel1.Controls.Add(this.txtPid);
            this.groupPanel1.Controls.Add(this.cbxOutSection);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.cbxInSection);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1086, 117);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "病案查阅";
            // 
            // chbNewborn
            // 
            // 
            // 
            // 
            this.chbNewborn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbNewborn.Location = new System.Drawing.Point(608, 66);
            this.chbNewborn.Name = "chbNewborn";
            this.chbNewborn.Size = new System.Drawing.Size(114, 23);
            this.chbNewborn.TabIndex = 39;
            this.chbNewborn.Text = "是否统计新生儿";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.Location = new System.Drawing.Point(835, 71);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(12, 12);
            this.lblCount.TabIndex = 38;
            this.lblCount.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(742, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 12);
            this.label12.TabIndex = 37;
            this.label12.Text = "当前统计总数：";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(413, 66);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 36;
            this.buttonX1.Text = "导出Excel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // cbxDocumentState
            // 
            this.cbxDocumentState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDocumentState.FormattingEnabled = true;
            this.cbxDocumentState.Items.AddRange(new object[] {
            "全部",
            "已归档",
            "未归档"});
            this.cbxDocumentState.Location = new System.Drawing.Point(423, 34);
            this.cbxDocumentState.Name = "cbxDocumentState";
            this.cbxDocumentState.Size = new System.Drawing.Size(82, 20);
            this.cbxDocumentState.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(352, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "归档状态：";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.cbxTimeType);
            this.groupPanel3.Controls.Add(this.dtpTimestart);
            this.groupPanel3.Controls.Add(this.chbEnable);
            this.groupPanel3.Controls.Add(this.cbxUnit);
            this.groupPanel3.Controls.Add(this.label3);
            this.groupPanel3.Location = new System.Drawing.Point(602, 31);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(470, 32);
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
            this.groupPanel3.TabIndex = 33;
            // 
            // cbxTimeType
            // 
            this.cbxTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTimeType.Enabled = false;
            this.cbxTimeType.FormattingEnabled = true;
            this.cbxTimeType.Items.AddRange(new object[] {
            "入院时间",
            "出院时间"});
            this.cbxTimeType.Location = new System.Drawing.Point(82, 3);
            this.cbxTimeType.Name = "cbxTimeType";
            this.cbxTimeType.Size = new System.Drawing.Size(102, 20);
            this.cbxTimeType.TabIndex = 32;
            // 
            // chbEnable
            // 
            // 
            // 
            // 
            this.chbEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbEnable.Location = new System.Drawing.Point(3, 3);
            this.chbEnable.Name = "chbEnable";
            this.chbEnable.Size = new System.Drawing.Size(75, 23);
            this.chbEnable.TabIndex = 27;
            this.chbEnable.Text = "按日期：";
            this.chbEnable.CheckedChanged += new System.EventHandler(this.chbEnable_CheckedChanged);
            // 
            // cbxUnit
            // 
            this.cbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit.Enabled = false;
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Items.AddRange(new object[] {
            "日",
            "月"});
            this.cbxUnit.Location = new System.Drawing.Point(354, 3);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(50, 20);
            this.cbxUnit.TabIndex = 29;
            this.cbxUnit.SelectedIndexChanged += new System.EventHandler(this.cbxUnit_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(307, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "单位：";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(332, 66);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 26;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxInSick
            // 
            this.cbxInSick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInSick.FormattingEnabled = true;
            this.cbxInSick.Location = new System.Drawing.Point(602, 5);
            this.cbxInSick.Name = "cbxInSick";
            this.cbxInSick.Size = new System.Drawing.Size(102, 20);
            this.cbxInSick.TabIndex = 25;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 117);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1086, 660);
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
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "病案查阅显示列表";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.归档退回ToolStripMenuItem,
            this.pACSToolStripMenuItem,
            this.lISToolStripMenuItem,
            this.医嘱单ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 归档退回ToolStripMenuItem
            // 
            this.归档退回ToolStripMenuItem.Name = "归档退回ToolStripMenuItem";
            this.归档退回ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.归档退回ToolStripMenuItem.Text = "归档退回";
            this.归档退回ToolStripMenuItem.Click += new System.EventHandler(this.归档退回ToolStripMenuItem_Click);
            // 
            // pACSToolStripMenuItem
            // 
            this.pACSToolStripMenuItem.Name = "pACSToolStripMenuItem";
            this.pACSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pACSToolStripMenuItem.Text = "PACS影像报告";
            this.pACSToolStripMenuItem.Click += new System.EventHandler(this.pACSToolStripMenuItem_Click);
            // 
            // lISToolStripMenuItem
            // 
            this.lISToolStripMenuItem.Name = "lISToolStripMenuItem";
            this.lISToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lISToolStripMenuItem.Text = "LIS检验报告";
            this.lISToolStripMenuItem.Click += new System.EventHandler(this.lISToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // 医嘱单ToolStripMenuItem
            // 
            this.医嘱单ToolStripMenuItem.Name = "医嘱单ToolStripMenuItem";
            this.医嘱单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.医嘱单ToolStripMenuItem.Text = "医嘱单";
            this.医嘱单ToolStripMenuItem.Click += new System.EventHandler(this.医嘱单ToolStripMenuItem_Click);
            // 
            // CaseSearchMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "CaseSearchMark";
            this.Size = new System.Drawing.Size(1086, 777);
            this.Load += new System.EventHandler(this.CaseSearchMark_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion       

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTimestart;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.ComboBox cbxOutSick;
        private System.Windows.Forms.ComboBox cbxOutSection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxInSection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiagnoseName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lklNullCondition;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ComboBox cbxInSick;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbEnable;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.ComboBox cbxTimeType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 归档退回ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxDocumentState;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem pACSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbNewborn;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem 医嘱单ToolStripMenuItem;
    }
}
