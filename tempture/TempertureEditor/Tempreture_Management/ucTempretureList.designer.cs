namespace TempertureEditor
{
    partial class ucTempretureList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pn_Top = new System.Windows.Forms.Panel();
            this.lblDateNext = new System.Windows.Forms.Label();
            this.lblDatePriview = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.pn_Main = new System.Windows.Forms.Panel();
            this.pn_Content = new System.Windows.Forms.Panel();
            this.dgv_Tempreturelist = new TempertureEditor.Controls.MultiColHeaderDgv();
            this.Col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_BedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_T1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_P1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_R1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_T2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_P2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_R2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_T3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_P3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_R3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_T4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_P4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_R4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_DBCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_TZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_XBCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ZYTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.Col_IsEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pn_Bottom = new System.Windows.Forms.Panel();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonX();
            this.btnExTemperaturePaint = new DevComponents.DotNetBar.ButtonX();
            this.btnTemperaturePaint = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pn_Top.SuspendLayout();
            this.pn_Main.SuspendLayout();
            this.pn_Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tempreturelist)).BeginInit();
            this.pn_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Top
            // 
            this.pn_Top.Controls.Add(this.lblDateNext);
            this.pn_Top.Controls.Add(this.lblDatePriview);
            this.pn_Top.Controls.Add(this.dtpDate);
            this.pn_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Top.Location = new System.Drawing.Point(0, 0);
            this.pn_Top.Name = "pn_Top";
            this.pn_Top.Size = new System.Drawing.Size(887, 43);
            this.pn_Top.TabIndex = 0;
            // 
            // lblDateNext
            // 
            this.lblDateNext.AutoSize = true;
            this.lblDateNext.BackColor = System.Drawing.Color.Transparent;
            this.lblDateNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDateNext.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateNext.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDateNext.Location = new System.Drawing.Point(527, 15);
            this.lblDateNext.Name = "lblDateNext";
            this.lblDateNext.Size = new System.Drawing.Size(91, 14);
            this.lblDateNext.TabIndex = 15;
            this.lblDateNext.Text = "2010-05-16>>";
            this.lblDateNext.Click += new System.EventHandler(this.lblDateNext_Click);
            // 
            // lblDatePriview
            // 
            this.lblDatePriview.AutoSize = true;
            this.lblDatePriview.BackColor = System.Drawing.Color.Transparent;
            this.lblDatePriview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDatePriview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDatePriview.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDatePriview.Location = new System.Drawing.Point(268, 15);
            this.lblDatePriview.Name = "lblDatePriview";
            this.lblDatePriview.Size = new System.Drawing.Size(91, 14);
            this.lblDatePriview.TabIndex = 14;
            this.lblDatePriview.Text = "2010-05-14<<";
            this.lblDatePriview.Click += new System.EventHandler(this.lblDatePriview_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(378, 11);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(130, 21);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // pn_Main
            // 
            this.pn_Main.AutoScroll = true;
            this.pn_Main.Controls.Add(this.pn_Content);
            this.pn_Main.Controls.Add(this.pn_Top);
            this.pn_Main.Controls.Add(this.pn_Bottom);
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 0);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(887, 548);
            this.pn_Main.TabIndex = 0;
            // 
            // pn_Content
            // 
            this.pn_Content.Controls.Add(this.dgv_Tempreturelist);
            this.pn_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Content.Location = new System.Drawing.Point(0, 43);
            this.pn_Content.Name = "pn_Content";
            this.pn_Content.Size = new System.Drawing.Size(887, 470);
            this.pn_Content.TabIndex = 1;
            // 
            // dgv_Tempreturelist
            // 
            this.dgv_Tempreturelist.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Tempreturelist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Tempreturelist.ColumnHeadersHeight = 25;
            this.dgv_Tempreturelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Tempreturelist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_ID,
            this.Col_BedNo,
            this.Col_PatientName,
            this.Col_T1,
            this.Col_P1,
            this.Col_R1,
            this.Col_T2,
            this.Col_P2,
            this.Col_R2,
            this.Col_T3,
            this.Col_P3,
            this.Col_R3,
            this.Col_T4,
            this.Col_P4,
            this.Col_R4,
            this.Col_DBCS,
            this.Col_TZ,
            this.Col_XBCS,
            this.Col_ZYTS,
            this.Col_Print,
            this.Col_IsEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Tempreturelist.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Tempreturelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Tempreturelist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Tempreturelist.Location = new System.Drawing.Point(0, 0);
            this.dgv_Tempreturelist.myColHeaderTreeView = null;
            this.dgv_Tempreturelist.Name = "dgv_Tempreturelist";
            this.dgv_Tempreturelist.RowTemplate.Height = 23;
            this.dgv_Tempreturelist.Size = new System.Drawing.Size(887, 470);
            this.dgv_Tempreturelist.TabIndex = 1;
            this.dgv_Tempreturelist.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_Tempreturelist_CellBeginEdit);
            this.dgv_Tempreturelist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tempreturelist_CellClick);
            this.dgv_Tempreturelist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tempreturelist_CellContentClick);
            this.dgv_Tempreturelist.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tempreturelist_CellEndEdit);
            this.dgv_Tempreturelist.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Tempreturelist_CellFormatting);
            this.dgv_Tempreturelist.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Tempreturelist_CellMouseDoubleClick);
            this.dgv_Tempreturelist.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tempreturelist_CellValueChanged);
            this.dgv_Tempreturelist.SelectionChanged += new System.EventHandler(this.dgv_Tempreturelist_SelectionChanged);
            this.dgv_Tempreturelist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Tempreturelist_MouseDoubleClick);
            // 
            // Col_ID
            // 
            this.Col_ID.DataPropertyName = "ID";
            this.Col_ID.HeaderText = "编号";
            this.Col_ID.Name = "Col_ID";
            this.Col_ID.ReadOnly = true;
            this.Col_ID.Visible = false;
            this.Col_ID.Width = 40;
            // 
            // Col_BedNo
            // 
            this.Col_BedNo.DataPropertyName = "sick_bed_no";
            this.Col_BedNo.HeaderText = "床号";
            this.Col_BedNo.Name = "Col_BedNo";
            this.Col_BedNo.ReadOnly = true;
            this.Col_BedNo.Width = 40;
            // 
            // Col_PatientName
            // 
            this.Col_PatientName.DataPropertyName = "patient_name";
            this.Col_PatientName.HeaderText = "姓名";
            this.Col_PatientName.Name = "Col_PatientName";
            this.Col_PatientName.ReadOnly = true;
            // 
            // Col_T1
            // 
            this.Col_T1.DataPropertyName = "T1";
            this.Col_T1.HeaderText = "T";
            this.Col_T1.Name = "Col_T1";
            this.Col_T1.Width = 30;
            // 
            // Col_P1
            // 
            this.Col_P1.DataPropertyName = "P1";
            this.Col_P1.HeaderText = "P";
            this.Col_P1.Name = "Col_P1";
            this.Col_P1.Width = 30;
            // 
            // Col_R1
            // 
            this.Col_R1.DataPropertyName = "R1";
            this.Col_R1.HeaderText = "R";
            this.Col_R1.Name = "Col_R1";
            this.Col_R1.Width = 30;
            // 
            // Col_T2
            // 
            this.Col_T2.DataPropertyName = "T2";
            this.Col_T2.HeaderText = "T";
            this.Col_T2.Name = "Col_T2";
            this.Col_T2.Width = 30;
            // 
            // Col_P2
            // 
            this.Col_P2.DataPropertyName = "P2";
            this.Col_P2.HeaderText = "P";
            this.Col_P2.Name = "Col_P2";
            this.Col_P2.Width = 30;
            // 
            // Col_R2
            // 
            this.Col_R2.DataPropertyName = "R2";
            this.Col_R2.HeaderText = "R";
            this.Col_R2.Name = "Col_R2";
            this.Col_R2.Width = 30;
            // 
            // Col_T3
            // 
            this.Col_T3.DataPropertyName = "T3";
            this.Col_T3.HeaderText = "T";
            this.Col_T3.Name = "Col_T3";
            this.Col_T3.Width = 30;
            // 
            // Col_P3
            // 
            this.Col_P3.DataPropertyName = "P3";
            this.Col_P3.HeaderText = "P";
            this.Col_P3.Name = "Col_P3";
            this.Col_P3.Width = 30;
            // 
            // Col_R3
            // 
            this.Col_R3.DataPropertyName = "R3";
            this.Col_R3.HeaderText = "R";
            this.Col_R3.Name = "Col_R3";
            this.Col_R3.Width = 30;
            // 
            // Col_T4
            // 
            this.Col_T4.DataPropertyName = "T4";
            this.Col_T4.HeaderText = "T";
            this.Col_T4.Name = "Col_T4";
            this.Col_T4.Width = 30;
            // 
            // Col_P4
            // 
            this.Col_P4.DataPropertyName = "P4";
            this.Col_P4.HeaderText = "P";
            this.Col_P4.Name = "Col_P4";
            this.Col_P4.Width = 30;
            // 
            // Col_R4
            // 
            this.Col_R4.DataPropertyName = "R4";
            this.Col_R4.HeaderText = "R";
            this.Col_R4.Name = "Col_R4";
            this.Col_R4.Width = 30;
            // 
            // Col_DBCS
            // 
            this.Col_DBCS.DataPropertyName = "DBCS";
            this.Col_DBCS.HeaderText = "大便次数";
            this.Col_DBCS.Name = "Col_DBCS";
            this.Col_DBCS.Width = 60;
            // 
            // Col_TZ
            // 
            this.Col_TZ.DataPropertyName = "TZ";
            this.Col_TZ.HeaderText = "体重";
            this.Col_TZ.Name = "Col_TZ";
            this.Col_TZ.Width = 40;
            // 
            // Col_XBCS
            // 
            this.Col_XBCS.DataPropertyName = "XBCS";
            this.Col_XBCS.HeaderText = "小便次数";
            this.Col_XBCS.Name = "Col_XBCS";
            this.Col_XBCS.Width = 60;
            // 
            // Col_ZYTS
            // 
            this.Col_ZYTS.DataPropertyName = "ZYTS";
            this.Col_ZYTS.HeaderText = "住院天数";
            this.Col_ZYTS.Name = "Col_ZYTS";
            this.Col_ZYTS.ReadOnly = true;
            this.Col_ZYTS.Width = 60;
            // 
            // Col_Print
            // 
            this.Col_Print.HeaderText = "打印";
            this.Col_Print.Image = global::TempertureEditor.Properties.Resources.ptRowIcon;
            this.Col_Print.Name = "Col_Print";
            this.Col_Print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_Print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Col_Print.Width = 40;
            // 
            // Col_IsEdit
            // 
            this.Col_IsEdit.HeaderText = "编辑";
            this.Col_IsEdit.Name = "Col_IsEdit";
            this.Col_IsEdit.Visible = false;
            this.Col_IsEdit.Width = 30;
            // 
            // pn_Bottom
            // 
            this.pn_Bottom.Controls.Add(this.btnRefresh);
            this.pn_Bottom.Controls.Add(this.btnExTemperaturePaint);
            this.pn_Bottom.Controls.Add(this.btnTemperaturePaint);
            this.pn_Bottom.Controls.Add(this.btnSave);
            this.pn_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_Bottom.Location = new System.Drawing.Point(0, 513);
            this.pn_Bottom.Name = "pn_Bottom";
            this.pn_Bottom.Size = new System.Drawing.Size(887, 35);
            this.pn_Bottom.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefresh.Location = new System.Drawing.Point(142, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExTemperaturePaint
            // 
            this.btnExTemperaturePaint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExTemperaturePaint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExTemperaturePaint.Enabled = false;
            this.btnExTemperaturePaint.Location = new System.Drawing.Point(482, 7);
            this.btnExTemperaturePaint.Name = "btnExTemperaturePaint";
            this.btnExTemperaturePaint.Size = new System.Drawing.Size(149, 23);
            this.btnExTemperaturePaint.TabIndex = 14;
            this.btnExTemperaturePaint.Text = "打印异常体温单";
            this.btnExTemperaturePaint.Visible = false;
            this.btnExTemperaturePaint.Click += new System.EventHandler(this.btnExTemperaturePaint_Click);
            // 
            // btnTemperaturePaint
            // 
            this.btnTemperaturePaint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTemperaturePaint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTemperaturePaint.Enabled = false;
            this.btnTemperaturePaint.Location = new System.Drawing.Point(333, 7);
            this.btnTemperaturePaint.Name = "btnTemperaturePaint";
            this.btnTemperaturePaint.Size = new System.Drawing.Size(131, 23);
            this.btnTemperaturePaint.TabIndex = 13;
            this.btnTemperaturePaint.Text = "打印记录体温单";
            this.btnTemperaturePaint.Visible = false;
            this.btnTemperaturePaint.Click += new System.EventHandler(this.btnTemperaturePaint_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(239, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // ucTempretureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pn_Main);
            this.DoubleBuffered = true;
            this.Name = "ucTempretureList";
            this.Size = new System.Drawing.Size(887, 548);
            this.Load += new System.EventHandler(this.ucTempretureList_Load);
            this.pn_Top.ResumeLayout(false);
            this.pn_Top.PerformLayout();
            this.pn_Main.ResumeLayout(false);
            this.pn_Content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tempreturelist)).EndInit();
            this.pn_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Top;
        private System.Windows.Forms.Panel pn_Main;
        private System.Windows.Forms.Panel pn_Content;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private Controls.MultiColHeaderDgv dgv_Tempreturelist;
        private System.Windows.Forms.Panel pn_Bottom;
        private DevComponents.DotNetBar.ButtonX btnExTemperaturePaint;
        private DevComponents.DotNetBar.ButtonX btnTemperaturePaint;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Label lblDateNext;
        private System.Windows.Forms.Label lblDatePriview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_BedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_T1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_P1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_R1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_T2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_P2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_R2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_T3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_P3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_R3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_T4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_P4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_R4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_DBCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_TZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_XBCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_ZYTS;
        private System.Windows.Forms.DataGridViewImageColumn Col_Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_IsEdit;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private DevComponents.DotNetBar.ButtonX btnRefresh;
    }
}