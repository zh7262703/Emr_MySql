namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucQcTextCommit_Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQcTextCommit_Statistics));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTimeUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnStatistics = new DevComponents.DotNetBar.ButtonX();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(175, 14);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpEnd.TabIndex = 11;
            this.dtpEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStart_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "—";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(57, 14);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(89, 21);
            this.dtpStart.TabIndex = 9;
            this.dtpStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStart_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "时间：";
            // 
            // cboTimeUnit
            // 
            this.cboTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeUnit.FormattingEnabled = true;
            this.cboTimeUnit.Location = new System.Drawing.Point(360, 15);
            this.cboTimeUnit.Name = "cboTimeUnit";
            this.cboTimeUnit.Size = new System.Drawing.Size(83, 20);
            this.cboTimeUnit.TabIndex = 4;
            this.cboTimeUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStart_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "统计范围：";
            // 
            // flgview
            // 
            this.flgview.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgview.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview.Location = new System.Drawing.Point(0, 77);
            this.flgview.Name = "flgview";
            this.flgview.Rows.DefaultSize = 18;
            this.flgview.Size = new System.Drawing.Size(970, 439);
            this.flgview.StyleInfo = resources.GetString("flgview.StyleInfo");
            this.flgview.TabIndex = 3;
            this.flgview.DoubleClick += new System.EventHandler(this.flgview_DoubleClick);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnExcel);
            this.groupPanel1.Controls.Add(this.dtpEnd);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.btnStatistics);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.dtpStart);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.cboTimeUnit);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(970, 77);
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "时间段统计查询设置";
            // 
            // btnStatistics
            // 
            this.btnStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStatistics.Location = new System.Drawing.Point(608, 15);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(94, 23);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "统 计";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Location = new System.Drawing.Point(744, 15);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(94, 23);
            this.btnExcel.TabIndex = 50;
            this.btnExcel.Text = "导出excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // ucQcTextCommit_Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flgview);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucQcTextCommit_Statistics";
            this.Size = new System.Drawing.Size(970, 516);
            this.Load += new System.EventHandler(this.ucTime_Statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTimeUnit;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnStatistics;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
