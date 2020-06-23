namespace Digital_Medical_Treatment
{
    partial class frmIllnessDiscussed
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.txtCreater = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatientName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.cbTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.dgvIllness = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.病历概述ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.曲线图配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示屏展示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIllness)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnAdd);
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.txtCreater);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtPatientName);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.dtEndTime);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.dtStartTime);
            this.groupPanel1.Controls.Add(this.cbTime);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1075, 90);
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
            this.groupPanel1.Text = "查询条件";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(980, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(885, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(57, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtCreater
            // 
            // 
            // 
            // 
            this.txtCreater.Border.Class = "TextBoxBorder";
            this.txtCreater.Location = new System.Drawing.Point(742, 14);
            this.txtCreater.Name = "txtCreater";
            this.txtCreater.Size = new System.Drawing.Size(111, 21);
            this.txtCreater.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "创建者:";
            // 
            // txtPatientName
            // 
            // 
            // 
            // 
            this.txtPatientName.Border.Class = "TextBoxBorder";
            this.txtPatientName.Location = new System.Drawing.Point(554, 14);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(111, 21);
            this.txtPatientName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "患者姓名:";
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(303, 14);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(150, 21);
            this.dtEndTime.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "--";
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(100, 14);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(174, 21);
            this.dtStartTime.TabIndex = 1;
            // 
            // cbTime
            // 
            this.cbTime.Location = new System.Drawing.Point(9, 14);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(75, 23);
            this.cbTime.TabIndex = 0;
            this.cbTime.Text = "讨论时间";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.Controls.Add(this.dgvIllness);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 90);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1075, 447);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            this.panelEx1.Text = "panelEx1";
            // 
            // dgvIllness
            // 
            this.dgvIllness.AllowUserToAddRows = false;
            this.dgvIllness.AllowUserToDeleteRows = false;
            this.dgvIllness.BackgroundColor = System.Drawing.Color.White;
            this.dgvIllness.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIllness.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvIllness.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIllness.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIllness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIllness.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvIllness.Location = new System.Drawing.Point(0, 0);
            this.dgvIllness.Name = "dgvIllness";
            this.dgvIllness.ReadOnly = true;
            this.dgvIllness.RowTemplate.Height = 23;
            this.dgvIllness.Size = new System.Drawing.Size(1075, 447);
            this.dgvIllness.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "住院号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "病人id";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "患者姓名";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "性别";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "年龄";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "诊断";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "讨论时间";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "创建者id";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "创建者";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.病历概述ToolStripMenuItem,
            this.曲线图配置ToolStripMenuItem,
            this.显示屏展示ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 92);
            // 
            // 病历概述ToolStripMenuItem
            // 
            this.病历概述ToolStripMenuItem.Name = "病历概述ToolStripMenuItem";
            this.病历概述ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.病历概述ToolStripMenuItem.Text = "病历概述";
            this.病历概述ToolStripMenuItem.Click += new System.EventHandler(this.病历概述ToolStripMenuItem_Click);
            // 
            // 曲线图配置ToolStripMenuItem
            // 
            this.曲线图配置ToolStripMenuItem.Name = "曲线图配置ToolStripMenuItem";
            this.曲线图配置ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.曲线图配置ToolStripMenuItem.Text = "曲线图配置";
            this.曲线图配置ToolStripMenuItem.Click += new System.EventHandler(this.曲线图配置ToolStripMenuItem_Click);
            // 
            // 显示屏展示ToolStripMenuItem
            // 
            this.显示屏展示ToolStripMenuItem.Name = "显示屏展示ToolStripMenuItem";
            this.显示屏展示ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.显示屏展示ToolStripMenuItem.Text = "显示屏展示";
            this.显示屏展示ToolStripMenuItem.Click += new System.EventHandler(this.显示屏展示ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // frmIllnessDiscussed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 537);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.groupPanel1);
            this.Name = "frmIllnessDiscussed";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病情讨论";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIllnessDiscussed_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIllness)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbTime;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvIllness;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCreater;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 病历概述ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 曲线图配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示屏展示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}