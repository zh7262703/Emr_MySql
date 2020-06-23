namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucTheday_statistics 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTheday_statistics));
            this.cboStatistics_Unit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.cbxSection = new System.Windows.Forms.ComboBox();
            this.btnStatistics = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboStatistics_Unit
            // 
            this.cboStatistics_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatistics_Unit.FormattingEnabled = true;
            this.cboStatistics_Unit.Location = new System.Drawing.Point(280, 16);
            this.cboStatistics_Unit.Name = "cboStatistics_Unit";
            this.cboStatistics_Unit.Size = new System.Drawing.Size(83, 20);
            this.cboStatistics_Unit.TabIndex = 4;
            this.cboStatistics_Unit.SelectedIndexChanged += new System.EventHandler(this.cboStatistics_Unit_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "统计范围：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "统计时间：";
            // 
            // flgview
            // 
            this.flgview.AllowEditing = false;
            this.flgview.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgview.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.flgview.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview.Location = new System.Drawing.Point(0, 0);
            this.flgview.Name = "flgview";
            this.flgview.Rows.DefaultSize = 18;
            this.flgview.Size = new System.Drawing.Size(779, 477);
            this.flgview.StyleInfo = resources.GetString("flgview.StyleInfo");
            this.flgview.TabIndex = 2;
            this.flgview.DoubleClick += new System.EventHandler(this.flgview_DoubleClick);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dtpTime);
            this.groupPanel1.Controls.Add(this.cbxSection);
            this.groupPanel1.Controls.Add(this.btnStatistics);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cboStatistics_Unit);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(785, 75);
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
            this.groupPanel1.Text = "当日统计查询设置";
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy-MM-dd";
            this.dtpTime.Location = new System.Drawing.Point(78, 15);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(113, 21);
            this.dtpTime.TabIndex = 10;
            // 
            // cbxSection
            // 
            this.cbxSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSection.FormattingEnabled = true;
            this.cbxSection.Location = new System.Drawing.Point(382, 16);
            this.cbxSection.Name = "cbxSection";
            this.cbxSection.Size = new System.Drawing.Size(87, 20);
            this.cbxSection.TabIndex = 9;
            // 
            // btnStatistics
            // 
            this.btnStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStatistics.Location = new System.Drawing.Point(484, 13);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(75, 23);
            this.btnStatistics.TabIndex = 8;
            this.btnStatistics.Text = "统 计";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgview);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 75);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(785, 501);
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
            this.groupPanel2.Text = "当日统计显示列表";
            // 
            // ucTheday_statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucTheday_statistics";
            this.Size = new System.Drawing.Size(785, 576);
            this.Load += new System.EventHandler(this.ucTheday_statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStatistics_Unit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnStatistics;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.ComboBox cbxSection;
    }
}
