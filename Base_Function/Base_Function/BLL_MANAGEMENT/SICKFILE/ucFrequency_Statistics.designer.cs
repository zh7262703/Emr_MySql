namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucFrequency_Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFrequency_Statistics));
            this.flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label11 = new System.Windows.Forms.Label();
            this.cboFrequencyUnit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboFrequency = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpStartYear = new System.Windows.Forms.DateTimePicker();
            this.cboStartMonth = new System.Windows.Forms.ComboBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblWeek = new System.Windows.Forms.Label();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.lblStartMonth = new System.Windows.Forms.Label();
            this.btnStatistics = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flgview
            // 
            this.flgview.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgview.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.flgview.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview.Location = new System.Drawing.Point(0, 0);
            this.flgview.Name = "flgview";
            this.flgview.Rows.DefaultSize = 18;
            this.flgview.Size = new System.Drawing.Size(901, 471);
            this.flgview.StyleInfo = resources.GetString("flgview.StyleInfo");
            this.flgview.TabIndex = 2;
            this.flgview.DoubleClick += new System.EventHandler(this.flgview_DoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "统计单位：";
            // 
            // cboFrequencyUnit
            // 
            this.cboFrequencyUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrequencyUnit.FormattingEnabled = true;
            this.cboFrequencyUnit.Location = new System.Drawing.Point(87, 16);
            this.cboFrequencyUnit.Name = "cboFrequencyUnit";
            this.cboFrequencyUnit.Size = new System.Drawing.Size(90, 20);
            this.cboFrequencyUnit.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "频率：";
            // 
            // cboFrequency
            // 
            this.cboFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrequency.FormattingEnabled = true;
            this.cboFrequency.Location = new System.Drawing.Point(236, 41);
            this.cboFrequency.Name = "cboFrequency";
            this.cboFrequency.Size = new System.Drawing.Size(99, 20);
            this.cboFrequency.TabIndex = 9;
            this.cboFrequency.SelectedValueChanged += new System.EventHandler(this.cboFrequency_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "时间：";
            // 
            // dtpStartYear
            // 
            this.dtpStartYear.CustomFormat = "yyyy-MM-dd";
            this.dtpStartYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartYear.Location = new System.Drawing.Point(87, 40);
            this.dtpStartYear.Name = "dtpStartYear";
            this.dtpStartYear.Size = new System.Drawing.Size(90, 21);
            this.dtpStartYear.TabIndex = 13;
            this.dtpStartYear.ValueChanged += new System.EventHandler(this.dtpStartYear_ValueChanged);
            // 
            // cboStartMonth
            // 
            this.cboStartMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartMonth.FormattingEnabled = true;
            this.cboStartMonth.Items.AddRange(new object[] {
            "1季度",
            "2季度",
            "3季度",
            "4季度"});
            this.cboStartMonth.Location = new System.Drawing.Point(399, 40);
            this.cboStartMonth.Name = "cboStartMonth";
            this.cboStartMonth.Size = new System.Drawing.Size(65, 20);
            this.cboStartMonth.TabIndex = 23;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lblWeek);
            this.groupPanel1.Controls.Add(this.cboWeek);
            this.groupPanel1.Controls.Add(this.lblStartMonth);
            this.groupPanel1.Controls.Add(this.btnStatistics);
            this.groupPanel1.Controls.Add(this.cboFrequencyUnit);
            this.groupPanel1.Controls.Add(this.cboStartMonth);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.dtpStartYear);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.cboFrequency);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(907, 103);
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
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "频次统计查询设置";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(483, 47);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(29, 12);
            this.lblWeek.TabIndex = 29;
            this.lblWeek.Text = "周：";
            this.lblWeek.Visible = false;
            // 
            // cboWeek
            // 
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Items.AddRange(new object[] {
            "1季度",
            "2季度",
            "3季度",
            "4季度"});
            this.cboWeek.Location = new System.Drawing.Point(518, 41);
            this.cboWeek.Name = "cboWeek";
            this.cboWeek.Size = new System.Drawing.Size(65, 20);
            this.cboWeek.TabIndex = 28;
            this.cboWeek.Visible = false;
            // 
            // lblStartMonth
            // 
            this.lblStartMonth.AutoSize = true;
            this.lblStartMonth.Location = new System.Drawing.Point(352, 46);
            this.lblStartMonth.Name = "lblStartMonth";
            this.lblStartMonth.Size = new System.Drawing.Size(41, 12);
            this.lblStartMonth.TabIndex = 27;
            this.lblStartMonth.Text = "季度：";
            // 
            // btnStatistics
            // 
            this.btnStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStatistics.Location = new System.Drawing.Point(598, 38);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(75, 23);
            this.btnStatistics.TabIndex = 25;
            this.btnStatistics.Text = "统 计";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgview);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 103);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(907, 495);
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
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "频次统计显示列表";
            // 
            // ucFrequency_Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucFrequency_Statistics";
            this.Size = new System.Drawing.Size(907, 598);
            this.Load += new System.EventHandler(this.ucFrequency_Statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid flgview;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboFrequencyUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboFrequency;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpStartYear;
        private System.Windows.Forms.ComboBox cboStartMonth;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnStatistics;
        private System.Windows.Forms.Label lblStartMonth;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.ComboBox cboWeek;
    }
}
