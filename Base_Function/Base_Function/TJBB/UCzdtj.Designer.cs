namespace Base_Function.TJBB
{
    partial class UCzdtj
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
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.dtiInEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtiInStart = new System.Windows.Forms.DateTimePicker();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoLeaveTime = new System.Windows.Forms.RadioButton();
            this.rdoInTime = new System.Windows.Forms.RadioButton();
            this.txtZDMC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboZDLX = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtiLeaveEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtiLeaveStart = new System.Windows.Forms.DateTimePicker();
            this.cboYBLX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Location = new System.Drawing.Point(812, 43);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv.ColumnHeadersHeight = 20;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(0, 129);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.ShowEditingIcon = false;
            this.dgv.Size = new System.Drawing.Size(1057, 525);
            this.dgv.TabIndex = 5;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(706, 43);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dtiInEnd
            // 
            this.dtiInEnd.CustomFormat = "yyyy-MM-dd";
            this.dtiInEnd.Location = new System.Drawing.Point(273, 36);
            this.dtiInEnd.Name = "dtiInEnd";
            this.dtiInEnd.Size = new System.Drawing.Size(124, 21);
            this.dtiInEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(255, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // dtiInStart
            // 
            this.dtiInStart.CustomFormat = "yyyy-MM-dd";
            this.dtiInStart.Location = new System.Drawing.Point(123, 36);
            this.dtiInStart.Name = "dtiInStart";
            this.dtiInStart.Size = new System.Drawing.Size(124, 21);
            this.dtiInStart.TabIndex = 3;
            // 
            // cboSection
            // 
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(119, 7);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(183, 20);
            this.cboSection.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(78, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室:";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rdoLeaveTime);
            this.groupPanel1.Controls.Add(this.rdoInTime);
            this.groupPanel1.Controls.Add(this.txtZDMC);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.cboZDLX);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.btnExcel);
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.dtiLeaveEnd);
            this.groupPanel1.Controls.Add(this.dtiInEnd);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.dtiLeaveStart);
            this.groupPanel1.Controls.Add(this.dtiInStart);
            this.groupPanel1.Controls.Add(this.cboYBLX);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cboSection);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1057, 129);
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "科室统计";
            // 
            // rdoLeaveTime
            // 
            this.rdoLeaveTime.AutoSize = true;
            this.rdoLeaveTime.BackColor = System.Drawing.Color.Transparent;
            this.rdoLeaveTime.Location = new System.Drawing.Point(39, 65);
            this.rdoLeaveTime.Name = "rdoLeaveTime";
            this.rdoLeaveTime.Size = new System.Drawing.Size(77, 16);
            this.rdoLeaveTime.TabIndex = 12;
            this.rdoLeaveTime.Text = "出院时间:";
            this.rdoLeaveTime.UseVisualStyleBackColor = false;
            // 
            // rdoInTime
            // 
            this.rdoInTime.AutoSize = true;
            this.rdoInTime.BackColor = System.Drawing.Color.Transparent;
            this.rdoInTime.Checked = true;
            this.rdoInTime.Location = new System.Drawing.Point(39, 39);
            this.rdoInTime.Name = "rdoInTime";
            this.rdoInTime.Size = new System.Drawing.Size(77, 16);
            this.rdoInTime.TabIndex = 11;
            this.rdoInTime.TabStop = true;
            this.rdoInTime.Text = "入院时间:";
            this.rdoInTime.UseVisualStyleBackColor = false;
            // 
            // txtZDMC
            // 
            this.txtZDMC.Location = new System.Drawing.Point(477, 63);
            this.txtZDMC.Name = "txtZDMC";
            this.txtZDMC.Size = new System.Drawing.Size(183, 21);
            this.txtZDMC.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(417, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "诊断名称:";
            // 
            // cboZDLX
            // 
            this.cboZDLX.FormattingEnabled = true;
            this.cboZDLX.Location = new System.Drawing.Point(477, 38);
            this.cboZDLX.Name = "cboZDLX";
            this.cboZDLX.Size = new System.Drawing.Size(183, 20);
            this.cboZDLX.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(417, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "诊断类型:";
            // 
            // dtiLeaveEnd
            // 
            this.dtiLeaveEnd.CustomFormat = "yyyy-MM-dd";
            this.dtiLeaveEnd.Location = new System.Drawing.Point(273, 63);
            this.dtiLeaveEnd.Name = "dtiLeaveEnd";
            this.dtiLeaveEnd.Size = new System.Drawing.Size(124, 21);
            this.dtiLeaveEnd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(255, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "-";
            // 
            // dtiLeaveStart
            // 
            this.dtiLeaveStart.CustomFormat = "yyyy-MM-dd";
            this.dtiLeaveStart.Location = new System.Drawing.Point(123, 63);
            this.dtiLeaveStart.Name = "dtiLeaveStart";
            this.dtiLeaveStart.Size = new System.Drawing.Size(124, 21);
            this.dtiLeaveStart.TabIndex = 3;
            // 
            // cboYBLX
            // 
            this.cboYBLX.FormattingEnabled = true;
            this.cboYBLX.Location = new System.Drawing.Point(392, 7);
            this.cboYBLX.Name = "cboYBLX";
            this.cboYBLX.Size = new System.Drawing.Size(183, 20);
            this.cboYBLX.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(332, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "医保类型:";
            // 
            // UCzdtj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupPanel1);
            this.Name = "UCzdtj";
            this.Size = new System.Drawing.Size(1057, 654);
            this.Load += new System.EventHandler(this.UCzdtj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnExcel;
        private System.Windows.Forms.DataGridView dgv;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.DateTimePicker dtiInEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtiInStart;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DateTimePicker dtiLeaveEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtiLeaveStart;
        private System.Windows.Forms.ComboBox cboYBLX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboZDLX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZDMC;
        private System.Windows.Forms.RadioButton rdoInTime;
        private System.Windows.Forms.RadioButton rdoLeaveTime;
    }
}
