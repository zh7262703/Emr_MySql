namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucOverthirtySum_Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOverthirtySum_Statistics));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnStatistics = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnWritetime = new System.Windows.Forms.RadioButton();
            this.dtpWriteEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpWriteStart = new System.Windows.Forms.DateTimePicker();
            this.rbnIntime = new System.Windows.Forms.RadioButton();
            this.dtpInEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpInStart = new System.Windows.Forms.DateTimePicker();
            this.rbnOuttime = new System.Windows.Forms.RadioButton();
            this.dtpOutEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOutStart = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgview);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 170);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(902, 416);
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
            this.groupPanel2.Text = "统计显示列表";
            // 
            // flgview
            // 
            this.flgview.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgview.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.flgview.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview.Location = new System.Drawing.Point(0, 0);
            this.flgview.Name = "flgview";
            this.flgview.Rows.DefaultSize = 18;
            this.flgview.Size = new System.Drawing.Size(896, 392);
            this.flgview.StyleInfo = resources.GetString("flgview.StyleInfo");
            this.flgview.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboUnit);
            this.groupPanel1.Controls.Add(this.btnExcel);
            this.groupPanel1.Controls.Add(this.btnStatistics);
            this.groupPanel1.Controls.Add(this.groupBox1);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(902, 170);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "统计查询设置";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(60, 0);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(90, 20);
            this.cboUnit.TabIndex = 6;
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Location = new System.Drawing.Point(492, 69);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(94, 23);
            this.btnExcel.TabIndex = 51;
            this.btnExcel.Text = "导出excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStatistics.Location = new System.Drawing.Point(492, 35);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(94, 23);
            this.btnStatistics.TabIndex = 50;
            this.btnStatistics.Text = "统 计";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbnWritetime);
            this.groupBox1.Controls.Add(this.dtpWriteEnd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpWriteStart);
            this.groupBox1.Controls.Add(this.rbnIntime);
            this.groupBox1.Controls.Add(this.dtpInEnd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpInStart);
            this.groupBox1.Controls.Add(this.rbnOuttime);
            this.groupBox1.Controls.Add(this.dtpOutEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpOutStart);
            this.groupBox1.Location = new System.Drawing.Point(3, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 118);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // rbnWritetime
            // 
            this.rbnWritetime.AutoSize = true;
            this.rbnWritetime.Checked = true;
            this.rbnWritetime.Location = new System.Drawing.Point(7, 89);
            this.rbnWritetime.Name = "rbnWritetime";
            this.rbnWritetime.Size = new System.Drawing.Size(71, 16);
            this.rbnWritetime.TabIndex = 48;
            this.rbnWritetime.TabStop = true;
            this.rbnWritetime.Text = "书写日期";
            this.rbnWritetime.UseVisualStyleBackColor = true;
            // 
            // dtpWriteEnd
            // 
            this.dtpWriteEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpWriteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWriteEnd.Location = new System.Drawing.Point(271, 86);
            this.dtpWriteEnd.Name = "dtpWriteEnd";
            this.dtpWriteEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpWriteEnd.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 46;
            this.label7.Text = "—";
            // 
            // dtpWriteStart
            // 
            this.dtpWriteStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpWriteStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWriteStart.Location = new System.Drawing.Point(153, 86);
            this.dtpWriteStart.Name = "dtpWriteStart";
            this.dtpWriteStart.Size = new System.Drawing.Size(89, 21);
            this.dtpWriteStart.TabIndex = 45;
            // 
            // rbnIntime
            // 
            this.rbnIntime.AutoSize = true;
            this.rbnIntime.Location = new System.Drawing.Point(7, 20);
            this.rbnIntime.Name = "rbnIntime";
            this.rbnIntime.Size = new System.Drawing.Size(71, 16);
            this.rbnIntime.TabIndex = 43;
            this.rbnIntime.Text = "入院日期";
            this.rbnIntime.UseVisualStyleBackColor = true;
            // 
            // dtpInEnd
            // 
            this.dtpInEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpInEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInEnd.Location = new System.Drawing.Point(271, 17);
            this.dtpInEnd.Name = "dtpInEnd";
            this.dtpInEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpInEnd.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "—";
            // 
            // dtpInStart
            // 
            this.dtpInStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpInStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInStart.Location = new System.Drawing.Point(153, 17);
            this.dtpInStart.Name = "dtpInStart";
            this.dtpInStart.Size = new System.Drawing.Size(89, 21);
            this.dtpInStart.TabIndex = 40;
            // 
            // rbnOuttime
            // 
            this.rbnOuttime.AutoSize = true;
            this.rbnOuttime.Location = new System.Drawing.Point(7, 54);
            this.rbnOuttime.Name = "rbnOuttime";
            this.rbnOuttime.Size = new System.Drawing.Size(71, 16);
            this.rbnOuttime.TabIndex = 38;
            this.rbnOuttime.Text = "出院日期";
            this.rbnOuttime.UseVisualStyleBackColor = true;
            // 
            // dtpOutEnd
            // 
            this.dtpOutEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpOutEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutEnd.Location = new System.Drawing.Point(271, 51);
            this.dtpOutEnd.Name = "dtpOutEnd";
            this.dtpOutEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpOutEnd.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "—";
            // 
            // dtpOutStart
            // 
            this.dtpOutStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpOutStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutStart.Location = new System.Drawing.Point(153, 51);
            this.dtpOutStart.Name = "dtpOutStart";
            this.dtpOutStart.Size = new System.Drawing.Size(89, 21);
            this.dtpOutStart.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "统计单位：";
            // 
            // ucOverthirtySum_Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucOverthirtySum_Statistics";
            this.Size = new System.Drawing.Size(902, 586);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ComboBox cboUnit;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private DevComponents.DotNetBar.ButtonX btnStatistics;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnWritetime;
        private System.Windows.Forms.DateTimePicker dtpWriteEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpWriteStart;
        private System.Windows.Forms.RadioButton rbnIntime;
        private System.Windows.Forms.DateTimePicker dtpInEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpInStart;
        private System.Windows.Forms.RadioButton rbnOuttime;
        private System.Windows.Forms.DateTimePicker dtpOutEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOutStart;
        private System.Windows.Forms.Label label11;
    }
}
