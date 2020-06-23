namespace Base_Function.BASE_DATA
{
    partial class frmImportSouthPatient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.dgvHISPatient = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbxSickBedNo = new System.Windows.Forms.ComboBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbxSickArea = new System.Windows.Forms.ComboBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboSickDoctor = new System.Windows.Forms.ComboBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbTime = new System.Windows.Forms.CheckBox();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHISPatient)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ckbTime);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.dtpEndTime);
            this.groupPanel1.Controls.Add(this.dtpStartTime);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.txtPid);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(794, 66);
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
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "查询设置";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(246, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 6;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(177, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 18);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "病人姓名：";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Location = new System.Drawing.Point(9, 4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 18);
            this.labelX5.TabIndex = 5;
            this.labelX5.Text = "住院号：";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(71, 3);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(100, 21);
            this.txtPid.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(706, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvHISPatient
            // 
            this.dgvHISPatient.AllowUserToAddRows = false;
            this.dgvHISPatient.AllowUserToDeleteRows = false;
            this.dgvHISPatient.BackgroundColor = System.Drawing.Color.White;
            this.dgvHISPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHISPatient.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHISPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHISPatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvHISPatient.Location = new System.Drawing.Point(0, 0);
            this.dgvHISPatient.Name = "dgvHISPatient";
            this.dgvHISPatient.ReadOnly = true;
            this.dgvHISPatient.RowTemplate.Height = 23;
            this.dgvHISPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHISPatient.Size = new System.Drawing.Size(788, 329);
            this.dgvHISPatient.TabIndex = 2;
            this.dgvHISPatient.Click += new System.EventHandler(this.dgvHISPatient_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cbxSickBedNo);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.cbxSickArea);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.cboSickDoctor);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel2.Location = new System.Drawing.Point(0, 419);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(794, 59);
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
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "编辑设置";
            // 
            // cbxSickBedNo
            // 
            this.cbxSickBedNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSickBedNo.FormattingEnabled = true;
            this.cbxSickBedNo.Location = new System.Drawing.Point(457, 1);
            this.cbxSickBedNo.Name = "cbxSickBedNo";
            this.cbxSickBedNo.Size = new System.Drawing.Size(117, 20);
            this.cbxSickBedNo.TabIndex = 15;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(393, 1);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(73, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "床号：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbxSickArea
            // 
            this.cbxSickArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSickArea.FormattingEnabled = true;
            this.cbxSickArea.Location = new System.Drawing.Point(262, 1);
            this.cbxSickArea.Name = "cbxSickArea";
            this.cbxSickArea.Size = new System.Drawing.Size(117, 20);
            this.cbxSickArea.TabIndex = 13;
            this.cbxSickArea.SelectedIndexChanged += new System.EventHandler(this.cbxSickArea_SelectedIndexChanged);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(198, 1);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(73, 23);
            this.labelX2.TabIndex = 12;
            this.labelX2.Text = "病区：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cboSickDoctor
            // 
            this.cboSickDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSickDoctor.FormattingEnabled = true;
            this.cboSickDoctor.Location = new System.Drawing.Point(71, 0);
            this.cboSickDoctor.Name = "cboSickDoctor";
            this.cboSickDoctor.Size = new System.Drawing.Size(117, 20);
            this.cboSickDoctor.TabIndex = 11;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(6, 1);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(73, 23);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "管床医生：";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(319, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.dgvHISPatient);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 66);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(794, 353);
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
            this.groupPanel3.TabIndex = 12;
            this.groupPanel3.Text = "病人列表";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 478);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 42);
            this.panel1.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(400, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(455, 3);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(103, 21);
            this.dtpStartTime.TabIndex = 8;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(581, 3);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(103, 21);
            this.dtpEndTime.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(564, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "-";
            // 
            // ckbTime
            // 
            this.ckbTime.AutoSize = true;
            this.ckbTime.BackColor = System.Drawing.Color.Transparent;
            this.ckbTime.Location = new System.Drawing.Point(377, 5);
            this.ckbTime.Name = "ckbTime";
            this.ckbTime.Size = new System.Drawing.Size(72, 16);
            this.ckbTime.TabIndex = 11;
            this.ckbTime.Text = "按时段：";
            this.ckbTime.UseVisualStyleBackColor = false;
            this.ckbTime.CheckedChanged += new System.EventHandler(this.ckbTime_CheckedChanged);
            // 
            // frmImportSouthPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 520);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportSouthPatient";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动导入南区HIS病人信息";
            this.Load += new System.EventHandler(this.frmImportSouthPatient_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHISPatient)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.TextBox txtPid;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvHISPatient;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox cboSickDoctor;
        private System.Windows.Forms.ComboBox cbxSickBedNo;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ComboBox cbxSickArea;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.CheckBox ckbTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
    }
}