namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class UcReportcard_management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcReportcard_management));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkRY_Time = new System.Windows.Forms.CheckBox();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkKS = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackSection = new DevComponents.DotNetBar.ButtonX();
            this.btnAccessFile = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(825, 453);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboState);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.dtpEndTime);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.dtpStartTime);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.chkRY_Time);
            this.groupPanel1.Controls.Add(this.cboSection);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.chkKS);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(825, 88);
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
            this.groupPanel1.Text = "查询设置";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "--请选择--",
            "待审核",
            "已归档",
            "退回科室"});
            this.cboState.Location = new System.Drawing.Point(558, 38);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(100, 20);
            this.cboState.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(505, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "归档状态";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(666, 35);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(336, 37);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(145, 21);
            this.dtpEndTime.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(313, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "至";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(174, 37);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(133, 21);
            this.dtpStartTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(121, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "入院日期";
            // 
            // chkRY_Time
            // 
            this.chkRY_Time.AutoSize = true;
            this.chkRY_Time.BackColor = System.Drawing.Color.Transparent;
            this.chkRY_Time.Location = new System.Drawing.Point(108, 42);
            this.chkRY_Time.Name = "chkRY_Time";
            this.chkRY_Time.Size = new System.Drawing.Size(15, 14);
            this.chkRY_Time.TabIndex = 3;
            this.chkRY_Time.UseVisualStyleBackColor = false;
            this.chkRY_Time.CheckedChanged += new System.EventHandler(this.chkRY_Time_CheckedChanged);
            // 
            // cboSection
            // 
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(150, 10);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(121, 20);
            this.cboSection.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(121, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "科室";
            // 
            // chkKS
            // 
            this.chkKS.AutoSize = true;
            this.chkKS.BackColor = System.Drawing.Color.Transparent;
            this.chkKS.Location = new System.Drawing.Point(108, 13);
            this.chkKS.Name = "chkKS";
            this.chkKS.Size = new System.Drawing.Size(15, 14);
            this.chkKS.TabIndex = 0;
            this.chkKS.UseVisualStyleBackColor = false;
            this.chkKS.CheckedChanged += new System.EventHandler(this.chkKS_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBackSection);
            this.panel1.Controls.Add(this.btnAccessFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 42);
            this.panel1.TabIndex = 6;
            // 
            // btnBackSection
            // 
            this.btnBackSection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBackSection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBackSection.Location = new System.Drawing.Point(370, 11);
            this.btnBackSection.Name = "btnBackSection";
            this.btnBackSection.Size = new System.Drawing.Size(78, 23);
            this.btnBackSection.TabIndex = 10;
            this.btnBackSection.Text = "退回科室";
            this.btnBackSection.Click += new System.EventHandler(this.btnBackSection_Click);
            // 
            // btnAccessFile
            // 
            this.btnAccessFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccessFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccessFile.Location = new System.Drawing.Point(289, 11);
            this.btnAccessFile.Name = "btnAccessFile";
            this.btnAccessFile.Size = new System.Drawing.Size(75, 23);
            this.btnAccessFile.TabIndex = 9;
            this.btnAccessFile.Text = "存档";
            this.btnAccessFile.Click += new System.EventHandler(this.btnAccessFile_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(825, 361);
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
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "报卡管理显示";
            // 
            // flgView
            // 
            this.flgView.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgView.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 18;
            this.flgView.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgView.Size = new System.Drawing.Size(819, 337);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData;
            this.flgView.TabIndex = 3;
            this.flgView.Click += new System.EventHandler(this.flgView_Click);
            this.flgView.DoubleClick += new System.EventHandler(this.flgView_DoubleClick);
            // 
            // UcReportcard_management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UcReportcard_management";
            this.Size = new System.Drawing.Size(825, 453);
            this.Load += new System.EventHandler(this.UcReportcard_management_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnAccessFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRY_Time;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkKS;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView;
        private DevComponents.DotNetBar.ButtonX btnBackSection;
    }
}
