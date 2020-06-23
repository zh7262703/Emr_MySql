namespace Base_Function.BLL_MANAGEMENT.SICKFILE.fuyou
{
    partial class ucQuality_Count
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuality_Count));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkInTime = new System.Windows.Forms.CheckBox();
            this.cmbSaties = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFrequencyUnit = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupBox1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(836, 156);
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
            this.groupPanel1.TabIndex = 6;
            this.groupPanel1.Text = "质控查询设置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkInTime);
            this.groupBox1.Controls.Add(this.cmbSaties);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFrequencyUnit);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 132);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // chkInTime
            // 
            this.chkInTime.AutoSize = true;
            this.chkInTime.Location = new System.Drawing.Point(25, 81);
            this.chkInTime.Name = "chkInTime";
            this.chkInTime.Size = new System.Drawing.Size(84, 16);
            this.chkInTime.TabIndex = 45;
            this.chkInTime.Text = "入院日期：";
            this.chkInTime.UseVisualStyleBackColor = true;
            // 
            // cmbSaties
            // 
            this.cmbSaties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSaties.FormattingEnabled = true;
            this.cmbSaties.Location = new System.Drawing.Point(281, 28);
            this.cmbSaties.Name = "cmbSaties";
            this.cmbSaties.Size = new System.Drawing.Size(90, 20);
            this.cmbSaties.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(210, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "提醒状态：";
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Location = new System.Drawing.Point(471, 78);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 42;
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(233, 79);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpEnd.TabIndex = 34;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(366, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "查 询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "—";
            // 
            // cmbFrequencyUnit
            // 
            this.cmbFrequencyUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequencyUnit.FormattingEnabled = true;
            this.cmbFrequencyUnit.Location = new System.Drawing.Point(94, 28);
            this.cmbFrequencyUnit.Name = "cmbFrequencyUnit";
            this.cmbFrequencyUnit.Size = new System.Drawing.Size(90, 20);
            this.cmbFrequencyUnit.TabIndex = 4;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(115, 79);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(89, 21);
            this.dtpStart.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "统计单位：";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgview);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 156);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(836, 282);
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
            this.groupPanel2.TabIndex = 7;
            this.groupPanel2.Text = "质控统计显示列表";
            // 
            // flgview
            // 
            this.flgview.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgview.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.flgview.ColumnInfo = "10,1,0,0,0,0,Columns:1{Style:\"TextAlign:CenterCenter;\";StyleFixed:\"TextAlign:Cent" +
                "erCenter;\";}\t";
            this.flgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview.Location = new System.Drawing.Point(0, 0);
            this.flgview.Name = "flgview";
            this.flgview.Rows.DefaultSize = 18;
            this.flgview.Size = new System.Drawing.Size(830, 258);
            this.flgview.StyleInfo = resources.GetString("flgview.StyleInfo");
            this.flgview.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // ucQuality_Count
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucQuality_Count";
            this.Size = new System.Drawing.Size(836, 438);
            this.Load += new System.EventHandler(this.ucQuality_Count_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.ComboBox cmbFrequencyUnit;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.ComboBox cmbSaties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkInTime;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview;

    }
}
