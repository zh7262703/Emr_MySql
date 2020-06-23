namespace Base_Function.BLL_MANAGEMENT.NURSE_MANAGE
{
    partial class ucDocument_statistics
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chbTime = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.cbxWard = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxText = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgv = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.病案查阅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pACSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手术麻醉报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医嘱单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbTime
            // 
            this.chbTime.AutoSize = true;
            this.chbTime.BackColor = System.Drawing.Color.Transparent;
            this.chbTime.Location = new System.Drawing.Point(542, 12);
            this.chbTime.Name = "chbTime";
            this.chbTime.Size = new System.Drawing.Size(78, 16);
            this.chbTime.TabIndex = 7;
            this.chbTime.Text = "创建时间:";
            this.chbTime.UseVisualStyleBackColor = false;
            this.chbTime.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(721, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(732, 10);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(101, 21);
            this.dtpEnd.TabIndex = 5;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(620, 10);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(101, 21);
            this.dtpStart.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(849, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.cbxWard);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.chbTime);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.dtpEnd);
            this.groupPanel1.Controls.Add(this.dtpStart);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.cbxText);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1033, 67);
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
            this.groupPanel1.Text = "查询";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(930, 9);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 10;
            this.buttonX1.Text = "导出Excel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // cbxWard
            // 
            this.cbxWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWard.FormattingEnabled = true;
            this.cbxWard.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbxWard.Location = new System.Drawing.Point(352, 10);
            this.cbxWard.Name = "cbxWard";
            this.cbxWard.Size = new System.Drawing.Size(176, 20);
            this.cbxWard.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(315, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "病区:";
            // 
            // cbxText
            // 
            this.cbxText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxText.FormattingEnabled = true;
            this.cbxText.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbxText.Location = new System.Drawing.Point(86, 10);
            this.cbxText.Name = "cbxText";
            this.cbxText.Size = new System.Drawing.Size(223, 20);
            this.cbxText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文书类型:";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgv);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 67);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1033, 395);
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
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "结果";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1027, 371);
            this.dgv.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.病案查阅ToolStripMenuItem,
            this.pACSToolStripMenuItem,
            this.lISToolStripMenuItem,
            this.手术麻醉报告ToolStripMenuItem,
            this.医嘱单ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 114);
            // 
            // 病案查阅ToolStripMenuItem
            // 
            this.病案查阅ToolStripMenuItem.Name = "病案查阅ToolStripMenuItem";
            this.病案查阅ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.病案查阅ToolStripMenuItem.Text = "病案查阅";
            this.病案查阅ToolStripMenuItem.Click += new System.EventHandler(this.病案查阅ToolStripMenuItem_Click);
            // 
            // pACSToolStripMenuItem
            // 
            this.pACSToolStripMenuItem.Name = "pACSToolStripMenuItem";
            this.pACSToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.pACSToolStripMenuItem.Text = "PACS影像报告";
            this.pACSToolStripMenuItem.Click += new System.EventHandler(this.pACSToolStripMenuItem_Click);
            // 
            // lISToolStripMenuItem
            // 
            this.lISToolStripMenuItem.Name = "lISToolStripMenuItem";
            this.lISToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.lISToolStripMenuItem.Text = "LIS检验报告";
            this.lISToolStripMenuItem.Click += new System.EventHandler(this.lISToolStripMenuItem_Click);
            // 
            // 手术麻醉报告ToolStripMenuItem
            // 
            this.手术麻醉报告ToolStripMenuItem.Name = "手术麻醉报告ToolStripMenuItem";
            this.手术麻醉报告ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.手术麻醉报告ToolStripMenuItem.Text = "手术麻醉报告";
            this.手术麻醉报告ToolStripMenuItem.Click += new System.EventHandler(this.手术麻醉报告ToolStripMenuItem_Click);
            // 
            // 医嘱单ToolStripMenuItem
            // 
            this.医嘱单ToolStripMenuItem.Name = "医嘱单ToolStripMenuItem";
            this.医嘱单ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.医嘱单ToolStripMenuItem.Text = "医嘱单";
            this.医嘱单ToolStripMenuItem.Click += new System.EventHandler(this.医嘱单ToolStripMenuItem_Click);
            // 
            // ucDocument_statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucDocument_statistics";
            this.Size = new System.Drawing.Size(1033, 462);
            this.Load += new System.EventHandler(this.ucDocument_statistics_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ComboBox cbxText;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv;
        private System.Windows.Forms.ComboBox cbxWard;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 病案查阅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pACSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手术麻醉报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医嘱单ToolStripMenuItem;

    }
}
