namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class UCConsultation_Statistic
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
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboConsulType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboConsulTimeType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtPid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cbxInSection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.ucGridviewX1);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 83);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(848, 403);
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
            this.groupPanel3.TabIndex = 6;
            this.groupPanel3.Text = "会诊列表";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(842, 379);
            this.ucGridviewX1.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.Controls.Add(this.cbxInSection);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Controls.Add(this.cboConsulType);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.checkBoxX1);
            this.groupPanel2.Controls.Add(this.cboConsulTimeType);
            this.groupPanel2.Controls.Add(this.dtpEnd);
            this.groupPanel2.Controls.Add(this.labelX5);
            this.groupPanel2.Controls.Add(this.dtpBegin);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.txtPid);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.txtName);
            this.groupPanel2.Controls.Add(this.btnSearch);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(848, 83);
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
            this.groupPanel2.TabIndex = 5;
            this.groupPanel2.Text = "查询";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(383, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(84, 21);
            this.labelX4.TabIndex = 16;
            this.labelX4.Text = "按会诊类型：";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboConsulType
            // 
            this.cboConsulType.DisplayMember = "Text";
            this.cboConsulType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboConsulType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsulType.FormattingEnabled = true;
            this.cboConsulType.ItemHeight = 15;
            this.cboConsulType.Items.AddRange(new object[] {
            this.comboItem3,
            this.comboItem4});
            this.cboConsulType.Location = new System.Drawing.Point(473, 3);
            this.cboConsulType.Name = "cboConsulType";
            this.cboConsulType.Size = new System.Drawing.Size(97, 21);
            this.cboConsulType.TabIndex = 15;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "发会诊";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "接会诊";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(27, 30);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(67, 21);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "按时间段：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxX1.Location = new System.Drawing.Point(2, 28);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(21, 23);
            this.checkBoxX1.TabIndex = 13;
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // cboConsulTimeType
            // 
            this.cboConsulTimeType.DisplayMember = "Text";
            this.cboConsulTimeType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboConsulTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsulTimeType.Enabled = false;
            this.cboConsulTimeType.FormattingEnabled = true;
            this.cboConsulTimeType.ItemHeight = 15;
            this.cboConsulTimeType.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem5,
            this.comboItem6});
            this.cboConsulTimeType.Location = new System.Drawing.Point(100, 30);
            this.cboConsulTimeType.Name = "cboConsulTimeType";
            this.cboConsulTimeType.Size = new System.Drawing.Size(97, 21);
            this.cboConsulTimeType.TabIndex = 12;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "申请日期";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "会诊日期";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(334, 30);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(104, 21);
            this.dtpEnd.TabIndex = 11;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Location = new System.Drawing.Point(318, 28);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(10, 23);
            this.labelX5.TabIndex = 10;
            this.labelX5.Text = "-";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd";
            this.dtpBegin.Enabled = false;
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(208, 30);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(104, 21);
            this.dtpBegin.TabIndex = 9;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(202, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(66, 21);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "住院号：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtPid
            // 
            // 
            // 
            // 
            this.txtPid.Border.Class = "TextBoxBorder";
            this.txtPid.Location = new System.Drawing.Point(274, 3);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(100, 21);
            this.txtPid.TabIndex = 3;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(26, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(67, 21);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "患者姓名：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Location = new System.Drawing.Point(99, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(97, 21);
            this.txtName.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(749, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.Location = new System.Drawing.Point(584, 3);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(43, 21);
            this.labelX6.TabIndex = 20;
            this.labelX6.Text = "科室：";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cbxInSection
            // 
            this.cbxInSection.DisplayMember = "Text";
            this.cbxInSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxInSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInSection.FormattingEnabled = true;
            this.cbxInSection.ItemHeight = 15;
            this.cbxInSection.Location = new System.Drawing.Point(633, 3);
            this.cbxInSection.Name = "cbxInSection";
            this.cbxInSection.Size = new System.Drawing.Size(97, 21);
            this.cbxInSection.TabIndex = 19;
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "入院时间";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "出院时间";
            // 
            // UCConsultation_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Name = "UCConsultation_Statistic";
            this.Size = new System.Drawing.Size(848, 486);
            this.Load += new System.EventHandler(this.UCConsultation_Statistic_Load);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private Bifrost.ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboConsulType;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboConsulTimeType;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxInSection;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
    }
}
