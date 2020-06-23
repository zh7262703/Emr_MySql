namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucBirthrecord_Statistics
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBirthrecord_Statistics));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbInOut = new System.Windows.Forms.ComboBox();
            this.chkInOutTime = new System.Windows.Forms.CheckBox();
            this.chkBirthTime = new System.Windows.Forms.CheckBox();
            this.dtpBirthEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpBirthStart = new System.Windows.Forms.DateTimePicker();
            this.dtpInOutEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpInOutStart = new System.Windows.Forms.DateTimePicker();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnStatistics = new DevComponents.DotNetBar.ButtonX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgview);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 127);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(972, 377);
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
            this.groupPanel2.TabIndex = 5;
            this.groupPanel2.Text = "统计显示列表";
            // 
            // flgview
            // 
            this.flgview.AllowEditing = false;
            this.flgview.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.flgview.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview.Location = new System.Drawing.Point(0, 0);
            this.flgview.Name = "flgview";
            this.flgview.Rows.DefaultSize = 18;
            this.flgview.Size = new System.Drawing.Size(966, 353);
            this.flgview.StyleInfo = resources.GetString("flgview.StyleInfo");
            this.flgview.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupBox1);
            this.groupPanel1.Controls.Add(this.cboDept);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.btnExcel);
            this.groupPanel1.Controls.Add(this.btnStatistics);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(972, 127);
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
            this.groupPanel1.Text = "统计查询设置";
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbInOut);
            this.groupBox1.Controls.Add(this.chkInOutTime);
            this.groupBox1.Controls.Add(this.chkBirthTime);
            this.groupBox1.Controls.Add(this.dtpBirthEnd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpBirthStart);
            this.groupBox1.Controls.Add(this.dtpInOutEnd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpInOutStart);
            this.groupBox1.Location = new System.Drawing.Point(4, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 86);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // cmbInOut
            // 
            this.cmbInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInOut.FormattingEnabled = true;
            this.cmbInOut.Location = new System.Drawing.Point(145, 20);
            this.cmbInOut.Name = "cmbInOut";
            this.cmbInOut.Size = new System.Drawing.Size(51, 20);
            this.cmbInOut.TabIndex = 52;
            // 
            // chkInOutTime
            // 
            this.chkInOutTime.AutoSize = true;
            this.chkInOutTime.Location = new System.Drawing.Point(5, 22);
            this.chkInOutTime.Name = "chkInOutTime";
            this.chkInOutTime.Size = new System.Drawing.Size(132, 16);
            this.chkInOutTime.TabIndex = 51;
            this.chkInOutTime.Text = "是否选择出入院日期";
            this.chkInOutTime.UseVisualStyleBackColor = true;
            this.chkInOutTime.CheckedChanged += new System.EventHandler(this.chkInOutTime_CheckedChanged);
            // 
            // chkBirthTime
            // 
            this.chkBirthTime.AutoSize = true;
            this.chkBirthTime.Location = new System.Drawing.Point(5, 49);
            this.chkBirthTime.Name = "chkBirthTime";
            this.chkBirthTime.Size = new System.Drawing.Size(120, 16);
            this.chkBirthTime.TabIndex = 50;
            this.chkBirthTime.Text = "是否选择出生日期";
            this.chkBirthTime.UseVisualStyleBackColor = true;
            this.chkBirthTime.CheckedChanged += new System.EventHandler(this.chkBirthTime_CheckedChanged);
            // 
            // dtpBirthEnd
            // 
            this.dtpBirthEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpBirthEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthEnd.Location = new System.Drawing.Point(262, 47);
            this.dtpBirthEnd.Name = "dtpBirthEnd";
            this.dtpBirthEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpBirthEnd.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 46;
            this.label6.Text = "—";
            // 
            // dtpBirthStart
            // 
            this.dtpBirthStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpBirthStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthStart.Location = new System.Drawing.Point(144, 47);
            this.dtpBirthStart.Name = "dtpBirthStart";
            this.dtpBirthStart.Size = new System.Drawing.Size(89, 21);
            this.dtpBirthStart.TabIndex = 45;
            // 
            // dtpInOutEnd
            // 
            this.dtpInOutEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpInOutEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInOutEnd.Location = new System.Drawing.Point(339, 20);
            this.dtpInOutEnd.Name = "dtpInOutEnd";
            this.dtpInOutEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpInOutEnd.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "—";
            // 
            // dtpInOutStart
            // 
            this.dtpInOutStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpInOutStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInOutStart.Location = new System.Drawing.Point(221, 20);
            this.dtpInOutStart.Name = "dtpInOutStart";
            this.dtpInOutStart.Size = new System.Drawing.Size(89, 21);
            this.dtpInOutStart.TabIndex = 40;
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(87, 6);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(135, 20);
            this.cboDept.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(27, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "科室：";
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Location = new System.Drawing.Point(515, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(94, 23);
            this.btnExcel.TabIndex = 49;
            this.btnExcel.Text = "导出excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStatistics.Location = new System.Drawing.Point(415, 6);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(94, 23);
            this.btnStatistics.TabIndex = 45;
            this.btnStatistics.Text = "查 询";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // ucBirthrecord_Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucBirthrecord_Statistics";
            this.Size = new System.Drawing.Size(972, 504);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpInOutEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpInOutStart;
        private DevComponents.DotNetBar.ButtonX btnStatistics;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DateTimePicker dtpBirthEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpBirthStart;
        private System.Windows.Forms.CheckBox chkBirthTime;
        private System.Windows.Forms.ComboBox cmbInOut;
        private System.Windows.Forms.CheckBox chkInOutTime;
    }
}
