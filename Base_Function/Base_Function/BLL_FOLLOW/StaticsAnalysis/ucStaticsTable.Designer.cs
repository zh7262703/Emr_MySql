namespace Base_Function.BLL_FOLLOW.StaticsAnalysis
{
    partial class ucStaticsTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStaticsTable));
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.cbxSection = new System.Windows.Forms.ComboBox();
            this.btnExportToExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvShow = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.c1Chart1 = new C1.Win.C1Chart.C1Chart();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(628, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(71, 27);
            this.btnPrint.TabIndex = 351;
            this.btnPrint.Text = "打印柱状图";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnPrint);
            this.groupPanel1.Controls.Add(this.comboBox1);
            this.groupPanel1.Controls.Add(this.dtpTime);
            this.groupPanel1.Controls.Add(this.lblTime);
            this.groupPanel1.Controls.Add(this.lblSection);
            this.groupPanel1.Controls.Add(this.cbxSection);
            this.groupPanel1.Controls.Add(this.btnExportToExcel);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1056, 65);
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
            this.groupPanel1.TabIndex = 8;
            this.groupPanel1.Text = "查询";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-请选择-",
            "男",
            "女"});
            this.comboBox1.Location = new System.Drawing.Point(338, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(47, 20);
            this.comboBox1.TabIndex = 350;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy-MM-dd";
            this.dtpTime.Enabled = false;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(229, 13);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(103, 21);
            this.dtpTime.TabIndex = 349;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(182, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(41, 12);
            this.lblTime.TabIndex = 345;
            this.lblTime.Text = "时间：";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(24, 17);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(41, 12);
            this.lblSection.TabIndex = 338;
            this.lblSection.Text = "科室：";
            // 
            // cbxSection
            // 
            this.cbxSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSection.Enabled = false;
            this.cbxSection.FormattingEnabled = true;
            this.cbxSection.Items.AddRange(new object[] {
            "-请选择-",
            "男",
            "女"});
            this.cbxSection.Location = new System.Drawing.Point(71, 14);
            this.cbxSection.Name = "cbxSection";
            this.cbxSection.Size = new System.Drawing.Size(92, 20);
            this.cbxSection.TabIndex = 337;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportToExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportToExcel.Location = new System.Drawing.Point(541, 7);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(71, 27);
            this.btnExportToExcel.TabIndex = 1;
            this.btnExportToExcel.Text = "导出Excel";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(450, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 27);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvShow);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 65);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1056, 222);
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
            this.groupPanel2.TabIndex = 9;
            this.groupPanel2.Text = "查询结果";
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.BackgroundColor = System.Drawing.Color.White;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShow.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvShow.Location = new System.Drawing.Point(0, 0);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowTemplate.Height = 23;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(1050, 198);
            this.dgvShow.TabIndex = 3;
            // 
            // c1Chart1
            // 
            this.c1Chart1.BackColor = System.Drawing.Color.White;
            this.c1Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1Chart1.ForeColor = System.Drawing.Color.Transparent;
            this.c1Chart1.Location = new System.Drawing.Point(0, 0);
            this.c1Chart1.Name = "c1Chart1";
            this.c1Chart1.PropBag = resources.GetString("c1Chart1.PropBag");
            this.c1Chart1.Size = new System.Drawing.Size(1050, 324);
            this.c1Chart1.TabIndex = 8;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.c1Chart1);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(0, 287);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1056, 348);
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
            this.groupPanel3.TabIndex = 10;
            this.groupPanel3.Text = "柱状图";
            // 
            // ucStaticsTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel3);
            this.Name = "ucStaticsTable";
            this.Size = new System.Drawing.Size(1056, 635);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cbxSection;
        private DevComponents.DotNetBar.ButtonX btnExportToExcel;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvShow;
        private C1.Win.C1Chart.C1Chart c1Chart1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
