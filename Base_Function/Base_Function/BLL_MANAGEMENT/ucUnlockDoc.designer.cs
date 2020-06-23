namespace Base_Function.BLL_MANAGEMENT
{
    partial class ucUnlockDoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.解锁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDocList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cheBoxintime = new System.Windows.Forms.CheckBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cboSection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btoQuery = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeStrat = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.txtInNum = new System.Windows.Forms.TextBox();
            this.txtNme = new System.Windows.Forms.TextBox();
            this.cboDoctor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtZYH = new System.Windows.Forms.TextBox();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocList)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.解锁ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 解锁ToolStripMenuItem
            // 
            this.解锁ToolStripMenuItem.Name = "解锁ToolStripMenuItem";
            this.解锁ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.解锁ToolStripMenuItem.Text = "解锁";
            this.解锁ToolStripMenuItem.Click += new System.EventHandler(this.解锁ToolStripMenuItem_Click);
            // 
            // dgvDocList
            // 
            this.dgvDocList.AllowUserToAddRows = false;
            this.dgvDocList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocList.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDocList.Location = new System.Drawing.Point(3, 83);
            this.dgvDocList.Name = "dgvDocList";
            this.dgvDocList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocList.RowTemplate.Height = 23;
            this.dgvDocList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocList.Size = new System.Drawing.Size(921, 370);
            this.dgvDocList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cboDoctor);
            this.panel1.Controls.Add(this.txtNme);
            this.panel1.Controls.Add(this.txtInNum);
            this.panel1.Controls.Add(this.dateTimeEnd);
            this.panel1.Controls.Add(this.dateTimeStrat);
            this.panel1.Controls.Add(this.btoQuery);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.cboSection);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.cheBoxintime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 74);
            this.panel1.TabIndex = 0;
            // 
            // cheBoxintime
            // 
            this.cheBoxintime.AutoSize = true;
            this.cheBoxintime.Location = new System.Drawing.Point(18, 47);
            this.cheBoxintime.Name = "cheBoxintime";
            this.cheBoxintime.Size = new System.Drawing.Size(84, 16);
            this.cheBoxintime.TabIndex = 28;
            this.cheBoxintime.Text = "入院时间：";
            this.cheBoxintime.UseVisualStyleBackColor = true;
            this.cheBoxintime.Click += new System.EventHandler(this.cheBoxintime_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(18, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(54, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "住院号：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(193, 14);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(44, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "姓名：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(358, 14);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(46, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "科室：";
            // 
            // cboSection
            // 
            this.cboSection.DisplayMember = "Text";
            this.cboSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.ItemHeight = 15;
            this.cboSection.Location = new System.Drawing.Point(395, 15);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(95, 21);
            this.cboSection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSection.TabIndex = 5;
            this.cboSection.SelectedIndexChanged += new System.EventHandler(this.cboSection_SelectedIndexChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(525, 14);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(69, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "管床医生：";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(208, 44);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(30, 23);
            this.labelX5.TabIndex = 10;
            this.labelX5.Text = "—";
            // 
            // btoQuery
            // 
            this.btoQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btoQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btoQuery.Location = new System.Drawing.Point(415, 44);
            this.btoQuery.Name = "btoQuery";
            this.btoQuery.Size = new System.Drawing.Size(75, 23);
            this.btoQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btoQuery.TabIndex = 12;
            this.btoQuery.Text = "查询";
            this.btoQuery.Click += new System.EventHandler(this.btoQuery_Click);
            // 
            // dateTimeStrat
            // 
            this.dateTimeStrat.CustomFormat = "yyyy-MM-dd";
            this.dateTimeStrat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStrat.Location = new System.Drawing.Point(95, 45);
            this.dateTimeStrat.Name = "dateTimeStrat";
            this.dateTimeStrat.Size = new System.Drawing.Size(105, 21);
            this.dateTimeStrat.TabIndex = 13;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy-MM-dd";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(227, 45);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(105, 21);
            this.dateTimeEnd.TabIndex = 14;
            // 
            // txtInNum
            // 
            this.txtInNum.Location = new System.Drawing.Point(66, 13);
            this.txtInNum.Name = "txtInNum";
            this.txtInNum.Size = new System.Drawing.Size(103, 21);
            this.txtInNum.TabIndex = 26;
            // 
            // txtNme
            // 
            this.txtNme.Location = new System.Drawing.Point(229, 13);
            this.txtNme.Name = "txtNme";
            this.txtNme.Size = new System.Drawing.Size(103, 21);
            this.txtNme.TabIndex = 27;
            // 
            // cboDoctor
            // 
            this.cboDoctor.DisplayMember = "Text";
            this.cboDoctor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.ItemHeight = 15;
            this.cboDoctor.Location = new System.Drawing.Point(585, 13);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(95, 21);
            this.cboDoctor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDoctor.TabIndex = 29;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDocList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 456);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.txtZYH);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Location = new System.Drawing.Point(699, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 71);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "根据住院号进行解锁";
            // 
            // txtZYH
            // 
            this.txtZYH.Location = new System.Drawing.Point(73, 18);
            this.txtZYH.Name = "txtZYH";
            this.txtZYH.Size = new System.Drawing.Size(103, 21);
            this.txtZYH.TabIndex = 28;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(25, 18);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(54, 23);
            this.labelX6.TabIndex = 27;
            this.labelX6.Text = "住院号：";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(73, 45);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "解锁";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ucUnlockDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucUnlockDoc";
            this.Size = new System.Drawing.Size(927, 456);
            this.Load += new System.EventHandler(this.ucUnlockDoc_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 解锁ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDocList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.TextBox txtZYH;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDoctor;
        private System.Windows.Forms.TextBox txtNme;
        private System.Windows.Forms.TextBox txtInNum;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStrat;
        private DevComponents.DotNetBar.ButtonX btoQuery;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSection;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.CheckBox cheBoxintime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
