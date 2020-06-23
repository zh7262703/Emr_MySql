namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class CoseCopyRegister 
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
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.labData = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.casenum = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.labcaseNum = new System.Windows.Forms.Label();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.checkKindred = new System.Windows.Forms.CheckBox();
            this.checkDeath = new System.Windows.Forms.CheckBox();
            this.checkDelegate = new System.Windows.Forms.CheckBox();
            this.txtWorkCard = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtCaseName = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtApplyName = new System.Windows.Forms.TextBox();
            this.labIDcard = new System.Windows.Forms.Label();
            this.labCaseName = new System.Windows.Forms.Label();
            this.labWarkCard = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labCopyContent = new System.Windows.Forms.Label();
            this.labApplyName = new System.Windows.Forms.Label();
            this.cbbapplyunit = new System.Windows.Forms.ComboBox();
            this.lblapplyunit = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.btnDalete = new DevComponents.DotNetBar.ButtonX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chkFYNR = new System.Windows.Forms.CheckedListBox();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy-MM";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(457, 8);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(111, 21);
            this.dtpTime.TabIndex = 13;
            // 
            // labData
            // 
            this.labData.AutoSize = true;
            this.labData.BackColor = System.Drawing.Color.Transparent;
            this.labData.Location = new System.Drawing.Point(410, 12);
            this.labData.Name = "labData";
            this.labData.Size = new System.Drawing.Size(41, 12);
            this.labData.TabIndex = 10;
            this.labData.Text = "日期：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(269, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 21);
            this.txtName.TabIndex = 9;
            // 
            // casenum
            // 
            this.casenum.Location = new System.Drawing.Point(73, 9);
            this.casenum.Name = "casenum";
            this.casenum.Size = new System.Drawing.Size(114, 21);
            this.casenum.TabIndex = 8;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.BackColor = System.Drawing.Color.Transparent;
            this.labName.Location = new System.Drawing.Point(222, 12);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(53, 12);
            this.labName.TabIndex = 7;
            this.labName.Text = "申请人：";
            // 
            // labcaseNum
            // 
            this.labcaseNum.AutoSize = true;
            this.labcaseNum.BackColor = System.Drawing.Color.Transparent;
            this.labcaseNum.Location = new System.Drawing.Point(19, 12);
            this.labcaseNum.Name = "labcaseNum";
            this.labcaseNum.Size = new System.Drawing.Size(53, 12);
            this.labcaseNum.TabIndex = 4;
            this.labcaseNum.Text = "病历号：";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(1025, 399);
            this.ucC1FlexGrid1.TabIndex = 0;
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            // 
            // checkKindred
            // 
            this.checkKindred.AutoSize = true;
            this.checkKindred.BackColor = System.Drawing.Color.Transparent;
            this.checkKindred.Location = new System.Drawing.Point(661, 53);
            this.checkKindred.Name = "checkKindred";
            this.checkKindred.Size = new System.Drawing.Size(108, 16);
            this.checkKindred.TabIndex = 18;
            this.checkKindred.Text = "近亲属关系证明";
            this.checkKindred.UseVisualStyleBackColor = false;
            // 
            // checkDeath
            // 
            this.checkDeath.AutoSize = true;
            this.checkDeath.BackColor = System.Drawing.Color.Transparent;
            this.checkDeath.Location = new System.Drawing.Point(389, 53);
            this.checkDeath.Name = "checkDeath";
            this.checkDeath.Size = new System.Drawing.Size(72, 16);
            this.checkDeath.TabIndex = 17;
            this.checkDeath.Text = "死亡证明";
            this.checkDeath.UseVisualStyleBackColor = false;
            // 
            // checkDelegate
            // 
            this.checkDelegate.AutoSize = true;
            this.checkDelegate.BackColor = System.Drawing.Color.Transparent;
            this.checkDelegate.Location = new System.Drawing.Point(89, 53);
            this.checkDelegate.Name = "checkDelegate";
            this.checkDelegate.Size = new System.Drawing.Size(60, 16);
            this.checkDelegate.TabIndex = 16;
            this.checkDelegate.Text = "委托书";
            this.checkDelegate.UseVisualStyleBackColor = false;
            // 
            // txtWorkCard
            // 
            this.txtWorkCard.Location = new System.Drawing.Point(661, 28);
            this.txtWorkCard.Name = "txtWorkCard";
            this.txtWorkCard.Size = new System.Drawing.Size(137, 21);
            this.txtWorkCard.TabIndex = 15;
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(389, 28);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(115, 21);
            this.txtIDCard.TabIndex = 14;
            // 
            // txtCaseName
            // 
            this.txtCaseName.Location = new System.Drawing.Point(89, 28);
            this.txtCaseName.Name = "txtCaseName";
            this.txtCaseName.Size = new System.Drawing.Size(121, 21);
            this.txtCaseName.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(661, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 21);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // txtApplyName
            // 
            this.txtApplyName.Location = new System.Drawing.Point(389, 4);
            this.txtApplyName.Name = "txtApplyName";
            this.txtApplyName.Size = new System.Drawing.Size(115, 21);
            this.txtApplyName.TabIndex = 11;
            // 
            // labIDcard
            // 
            this.labIDcard.AutoSize = true;
            this.labIDcard.BackColor = System.Drawing.Color.Transparent;
            this.labIDcard.Location = new System.Drawing.Point(318, 31);
            this.labIDcard.Name = "labIDcard";
            this.labIDcard.Size = new System.Drawing.Size(65, 12);
            this.labIDcard.TabIndex = 9;
            this.labIDcard.Text = "身份证号：";
            // 
            // labCaseName
            // 
            this.labCaseName.AutoSize = true;
            this.labCaseName.BackColor = System.Drawing.Color.Transparent;
            this.labCaseName.Location = new System.Drawing.Point(30, 31);
            this.labCaseName.Name = "labCaseName";
            this.labCaseName.Size = new System.Drawing.Size(53, 12);
            this.labCaseName.TabIndex = 6;
            this.labCaseName.Text = "病历号：";
            // 
            // labWarkCard
            // 
            this.labWarkCard.AutoSize = true;
            this.labWarkCard.BackColor = System.Drawing.Color.Transparent;
            this.labWarkCard.Location = new System.Drawing.Point(601, 31);
            this.labWarkCard.Name = "labWarkCard";
            this.labWarkCard.Size = new System.Drawing.Size(53, 12);
            this.labWarkCard.TabIndex = 5;
            this.labWarkCard.Text = "工作证：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(589, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "复印日期：";
            // 
            // labCopyContent
            // 
            this.labCopyContent.AutoSize = true;
            this.labCopyContent.BackColor = System.Drawing.Color.Transparent;
            this.labCopyContent.Location = new System.Drawing.Point(18, 73);
            this.labCopyContent.Name = "labCopyContent";
            this.labCopyContent.Size = new System.Drawing.Size(65, 12);
            this.labCopyContent.TabIndex = 3;
            this.labCopyContent.Text = "复印内容：";
            // 
            // labApplyName
            // 
            this.labApplyName.AutoSize = true;
            this.labApplyName.BackColor = System.Drawing.Color.Transparent;
            this.labApplyName.Location = new System.Drawing.Point(306, 7);
            this.labApplyName.Name = "labApplyName";
            this.labApplyName.Size = new System.Drawing.Size(77, 12);
            this.labApplyName.TabIndex = 2;
            this.labApplyName.Text = "申请人姓名：";
            // 
            // cbbapplyunit
            // 
            this.cbbapplyunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbapplyunit.FormattingEnabled = true;
            this.cbbapplyunit.Location = new System.Drawing.Point(89, 4);
            this.cbbapplyunit.Name = "cbbapplyunit";
            this.cbbapplyunit.Size = new System.Drawing.Size(154, 20);
            this.cbbapplyunit.TabIndex = 1;
            // 
            // lblapplyunit
            // 
            this.lblapplyunit.AutoSize = true;
            this.lblapplyunit.BackColor = System.Drawing.Color.Transparent;
            this.lblapplyunit.Location = new System.Drawing.Point(18, 7);
            this.lblapplyunit.Name = "lblapplyunit";
            this.lblapplyunit.Size = new System.Drawing.Size(65, 12);
            this.lblapplyunit.TabIndex = 0;
            this.lblapplyunit.Text = "申请单位：";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 61);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1031, 423);
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
            this.groupPanel2.Text = "病历复印登记显示列表";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnPrint);
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.dtpTime);
            this.groupPanel1.Controls.Add(this.labData);
            this.groupPanel1.Controls.Add(this.labcaseNum);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Controls.Add(this.casenum);
            this.groupPanel1.Controls.Add(this.labName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1031, 61);
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
            this.groupPanel1.Text = "病历复印登记设置";
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(675, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "导出Excel";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(594, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.chkFYNR);
            this.groupPanel3.Controls.Add(this.labApplyName);
            this.groupPanel3.Controls.Add(this.lblapplyunit);
            this.groupPanel3.Controls.Add(this.cbbapplyunit);
            this.groupPanel3.Controls.Add(this.labCopyContent);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Controls.Add(this.labWarkCard);
            this.groupPanel3.Controls.Add(this.labCaseName);
            this.groupPanel3.Controls.Add(this.labIDcard);
            this.groupPanel3.Controls.Add(this.txtApplyName);
            this.groupPanel3.Controls.Add(this.dateTimePicker1);
            this.groupPanel3.Controls.Add(this.txtCaseName);
            this.groupPanel3.Controls.Add(this.checkKindred);
            this.groupPanel3.Controls.Add(this.txtIDCard);
            this.groupPanel3.Controls.Add(this.checkDeath);
            this.groupPanel3.Controls.Add(this.txtWorkCard);
            this.groupPanel3.Controls.Add(this.checkDelegate);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1031, 162);
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
            this.groupPanel3.TabIndex = 9;
            this.groupPanel3.Text = "添加病历复印";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnDalete);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 49);
            this.panel1.TabIndex = 8;
            // 
            // btncancel
            // 
            this.btncancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btncancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncancel.Location = new System.Drawing.Point(640, 13);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 8;
            this.btncancel.Text = "取 消";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnDalete
            // 
            this.btnDalete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDalete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDalete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDalete.Location = new System.Drawing.Point(478, 13);
            this.btnDalete.Name = "btnDalete";
            this.btnDalete.Size = new System.Drawing.Size(75, 23);
            this.btnDalete.TabIndex = 8;
            this.btnDalete.Text = "删 除";
            this.btnDalete.Click += new System.EventHandler(this.btnDalete_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(559, 13);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "确 定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(397, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "修 改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(316, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "添 加";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupPanel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 211);
            this.panel2.TabIndex = 10;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // chkFYNR
            // 
            this.chkFYNR.FormattingEnabled = true;
            this.chkFYNR.HorizontalScrollbar = true;
            this.chkFYNR.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.chkFYNR.Location = new System.Drawing.Point(86, 71);
            this.chkFYNR.MultiColumn = true;
            this.chkFYNR.Name = "chkFYNR";
            this.chkFYNR.Size = new System.Drawing.Size(712, 68);
            this.chkFYNR.TabIndex = 30;
            // 
            // CoseCopyRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "CoseCopyRegister";
            this.Size = new System.Drawing.Size(1031, 695);
            this.Load += new System.EventHandler(this.CoseCopyRegister_Load);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labcaseNum;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox casenum;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labData;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.ComboBox cbbapplyunit;
        private System.Windows.Forms.Label lblapplyunit;
        private System.Windows.Forms.Label labIDcard;
        private System.Windows.Forms.Label labCaseName;
        private System.Windows.Forms.Label labWarkCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labCopyContent;
        private System.Windows.Forms.Label labApplyName;
        private System.Windows.Forms.TextBox txtApplyName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtCaseName;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.TextBox txtWorkCard;
        private System.Windows.Forms.CheckBox checkDelegate;
        private System.Windows.Forms.CheckBox checkDeath;
        private System.Windows.Forms.CheckBox checkKindred;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btncancel;
        private DevComponents.DotNetBar.ButtonX btnDalete;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckedListBox chkFYNR;
    }
}
