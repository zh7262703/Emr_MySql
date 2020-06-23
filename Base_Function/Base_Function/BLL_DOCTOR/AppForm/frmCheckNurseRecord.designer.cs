namespace Base_Function.BLL_DOCTOR.AppForm
{
    partial class frmCheckNurseRecord
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboPatientName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dtpDate);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.cboPatientName);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(740, 70);
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
            this.groupPanel1.Text = "选择病人";
            // 
            // dtpDate
            // 
            // 
            // 
            // 
            this.dtpDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpDate.ButtonDropDown.Visible = true;
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(238, 1);
            // 
            // 
            // 
            this.dtpDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtpDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpDate.MonthCalendar.DisplayMonth = new System.DateTime(2012, 5, 1, 0, 0, 0, 0);
            this.dtpDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpDate.MonthCalendar.TodayButtonVisible = true;
            this.dtpDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(104, 21);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.Value = new System.DateTime(2012, 5, 16, 14, 4, 18, 0);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(186, -1);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "日期：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboPatientName
            // 
            this.cboPatientName.DisplayMember = "Text";
            this.cboPatientName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPatientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatientName.FormattingEnabled = true;
            this.cboPatientName.ItemHeight = 15;
            this.cboPatientName.Location = new System.Drawing.Point(85, 1);
            this.cboPatientName.Name = "cboPatientName";
            this.cboPatientName.Size = new System.Drawing.Size(95, 21);
            this.cboPatientName.TabIndex = 2;
            this.cboPatientName.SelectedIndexChanged += new System.EventHandler(this.cboPatientName_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(4, 1);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "病人姓名：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 70);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(740, 373);
            this.reportViewer1.TabIndex = 1;
            // 
            // frmCheckNurseRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 443);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupPanel1);
            this.Name = "frmCheckNurseRecord";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看护理记录单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCheckNurseRecord_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPatientName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpDate;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}