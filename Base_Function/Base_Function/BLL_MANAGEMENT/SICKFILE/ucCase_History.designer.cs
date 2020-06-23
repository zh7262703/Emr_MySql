namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucCase_History
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param Name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtpStartYear = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboFrequencyItem = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.btnStatistics = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(411, 18);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(15, 14);
            this.chkTime.TabIndex = 16;
            this.chkTime.UseVisualStyleBackColor = true;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.Location = new System.Drawing.Point(16, 18);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(15, 14);
            this.chkSection.TabIndex = 15;
            this.chkSection.UseVisualStyleBackColor = true;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(286, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 21);
            this.textBox1.TabIndex = 14;
            // 
            // dtpStartYear
            // 
            this.dtpStartYear.CustomFormat = "yyyy-MM-dd";
            this.dtpStartYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartYear.Location = new System.Drawing.Point(527, 14);
            this.dtpStartYear.Name = "dtpStartYear";
            this.dtpStartYear.Size = new System.Drawing.Size(118, 21);
            this.dtpStartYear.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(432, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "临床归档时间：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "住院号：";
            // 
            // cboFrequencyItem
            // 
            this.cboFrequencyItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrequencyItem.FormattingEnabled = true;
            this.cboFrequencyItem.Location = new System.Drawing.Point(84, 15);
            this.cboFrequencyItem.Name = "cboFrequencyItem";
            this.cboFrequencyItem.Size = new System.Drawing.Size(127, 20);
            this.cboFrequencyItem.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "科室：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnStatistics);
            this.groupPanel1.Controls.Add(this.chkTime);
            this.groupPanel1.Controls.Add(this.textBox1);
            this.groupPanel1.Controls.Add(this.chkSection);
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.cboFrequencyItem);
            this.groupPanel1.Controls.Add(this.dtpStartYear);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(799, 72);
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
            this.groupPanel1.TabIndex = 7;
            this.groupPanel1.Text = "病历入库查询设置";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 72);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(799, 521);
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
            this.groupPanel2.TabIndex = 8;
            this.groupPanel2.Text = "病历入库显示列表";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(793, 497);
            this.ucC1FlexGrid1.TabIndex = 1;
            this.ucC1FlexGrid1.Load += new System.EventHandler(this.ucC1FlexGrid1_Load);
            // 
            // btnStatistics
            // 
            this.btnStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStatistics.Location = new System.Drawing.Point(651, 13);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(75, 23);
            this.btnStatistics.TabIndex = 17;
            this.btnStatistics.Text = "查 询";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // ucCase_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucCase_History";
            this.Size = new System.Drawing.Size(799, 593);
            this.Load += new System.EventHandler(this.ucCase_History_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpStartYear;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboFrequencyItem;
        private System.Windows.Forms.Label label12;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkTime;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnStatistics;
    }
}
