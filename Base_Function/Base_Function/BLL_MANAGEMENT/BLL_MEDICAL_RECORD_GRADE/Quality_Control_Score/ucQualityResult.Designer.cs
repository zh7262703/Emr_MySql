namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    partial class ucQualityResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSerch = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpIntime2 = new System.Windows.Forms.DateTimePicker();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkPid = new System.Windows.Forms.CheckBox();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpInTime1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSerch
            // 
            this.btnSerch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSerch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSerch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSerch.Location = new System.Drawing.Point(915, 9);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(86, 23);
            this.btnSerch.TabIndex = 61;
            this.btnSerch.Text = "查 询";
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(417, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 17);
            this.label10.TabIndex = 58;
            this.label10.Text = "-";
            // 
            // dtpIntime2
            // 
            this.dtpIntime2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpIntime2.CustomFormat = "yyyy-MM-dd";
            this.dtpIntime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIntime2.Location = new System.Drawing.Point(429, 9);
            this.dtpIntime2.Name = "dtpIntime2";
            this.dtpIntime2.Size = new System.Drawing.Size(88, 23);
            this.dtpIntime2.TabIndex = 59;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.chkPid);
            this.groupPanel1.Controls.Add(this.txtPid);
            this.groupPanel1.Controls.Add(this.cmbGrade);
            this.groupPanel1.Controls.Add(this.label13);
            this.groupPanel1.Controls.Add(this.btnSerch);
            this.groupPanel1.Controls.Add(this.dtpIntime2);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.dtpInTime1);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1292, 65);
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
            this.groupPanel1.TabIndex = 6;
            this.groupPanel1.Text = "查询";
            // 
            // chkPid
            // 
            this.chkPid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkPid.AutoSize = true;
            this.chkPid.Location = new System.Drawing.Point(706, 10);
            this.chkPid.Name = "chkPid";
            this.chkPid.Size = new System.Drawing.Size(87, 21);
            this.chkPid.TabIndex = 98;
            this.chkPid.Text = "住院号查询";
            this.chkPid.UseVisualStyleBackColor = true;
            this.chkPid.Click += new System.EventHandler(this.chkPid_Click);
            // 
            // txtPid
            // 
            this.txtPid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPid.Enabled = false;
            this.txtPid.Location = new System.Drawing.Point(800, 9);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(100, 23);
            this.txtPid.TabIndex = 97;
            // 
            // cmbGrade
            // 
            this.cmbGrade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Items.AddRange(new object[] {
            "全部",
            "甲级",
            "丙级",
            "乙级"});
            this.cmbGrade.Location = new System.Drawing.Point(615, 8);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(58, 25);
            this.cmbGrade.TabIndex = 95;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(539, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 94;
            this.label13.Text = "病历等级：";
            // 
            // dtpInTime1
            // 
            this.dtpInTime1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpInTime1.CustomFormat = "yyyy-MM-dd";
            this.dtpInTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInTime1.Location = new System.Drawing.Point(324, 9);
            this.dtpInTime1.Name = "dtpInTime1";
            this.dtpInTime1.Size = new System.Drawing.Size(88, 23);
            this.dtpInTime1.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "入院日期：";
            // 
            // dgvPatient
            // 
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AllowUserToResizeColumns = false;
            this.dgvPatient.AllowUserToResizeRows = false;
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPatient.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPatient.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatient.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatient.Location = new System.Drawing.Point(0, 65);
            this.dgvPatient.MultiSelect = false;
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvPatient.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatient.RowTemplate.Height = 23;
            this.dgvPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatient.Size = new System.Drawing.Size(1292, 497);
            this.dgvPatient.TabIndex = 7;
            this.dgvPatient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellDoubleClick);
            // 
            // ucQualityResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucQualityResult";
            this.Size = new System.Drawing.Size(1292, 562);
            this.Load += new System.EventHandler(this.ucQualityResult_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSerch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpIntime2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DateTimePicker dtpInTime1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkPid;
        private System.Windows.Forms.TextBox txtPid;
    }
}
