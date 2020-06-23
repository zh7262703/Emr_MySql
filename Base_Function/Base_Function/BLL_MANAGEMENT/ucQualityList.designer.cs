namespace Base_Function.BLL_MANAGEMENT
{
    partial class ucQualityList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQualityList));
            this.chbLeave_Time = new System.Windows.Forms.CheckBox();
            this.chbIn_Time = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpOutStart = new System.Windows.Forms.DateTimePicker();
            this.dtpOutEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpInStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpInEnd = new System.Windows.Forms.DateTimePicker();
            this.rdoRedY = new System.Windows.Forms.RadioButton();
            this.rdoYellow = new System.Windows.Forms.RadioButton();
            this.rdoRed = new System.Windows.Forms.RadioButton();
            this.rdoRecord = new System.Windows.Forms.RadioButton();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.cboTextType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSickArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbLeave_Time
            // 
            this.chbLeave_Time.AutoSize = true;
            this.chbLeave_Time.Location = new System.Drawing.Point(518, 42);
            this.chbLeave_Time.Name = "chbLeave_Time";
            this.chbLeave_Time.Size = new System.Drawing.Size(15, 14);
            this.chbLeave_Time.TabIndex = 15;
            this.chbLeave_Time.UseVisualStyleBackColor = true;
            this.chbLeave_Time.CheckedChanged += new System.EventHandler(this.chbLeave_Time_CheckedChanged);
            // 
            // chbIn_Time
            // 
            this.chbIn_Time.AutoSize = true;
            this.chbIn_Time.Location = new System.Drawing.Point(519, 11);
            this.chbIn_Time.Name = "chbIn_Time";
            this.chbIn_Time.Size = new System.Drawing.Size(15, 14);
            this.chbIn_Time.TabIndex = 15;
            this.chbIn_Time.UseVisualStyleBackColor = true;
            this.chbIn_Time.CheckedChanged += new System.EventHandler(this.chbIn_Time_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpOutStart);
            this.panel2.Controls.Add(this.dtpOutEnd);
            this.panel2.Location = new System.Drawing.Point(536, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 24);
            this.panel2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "出院时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "-";
            // 
            // dtpOutStart
            // 
            this.dtpOutStart.Location = new System.Drawing.Point(70, 2);
            this.dtpOutStart.Name = "dtpOutStart";
            this.dtpOutStart.Size = new System.Drawing.Size(97, 21);
            this.dtpOutStart.TabIndex = 13;
            // 
            // dtpOutEnd
            // 
            this.dtpOutEnd.Location = new System.Drawing.Point(185, 2);
            this.dtpOutEnd.Name = "dtpOutEnd";
            this.dtpOutEnd.Size = new System.Drawing.Size(97, 21);
            this.dtpOutEnd.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpInStart);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpInEnd);
            this.panel1.Location = new System.Drawing.Point(537, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 28);
            this.panel1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "入院时间：";
            // 
            // dtpInStart
            // 
            this.dtpInStart.Location = new System.Drawing.Point(70, 4);
            this.dtpInStart.Name = "dtpInStart";
            this.dtpInStart.Size = new System.Drawing.Size(97, 21);
            this.dtpInStart.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "-";
            // 
            // dtpInEnd
            // 
            this.dtpInEnd.Location = new System.Drawing.Point(184, 4);
            this.dtpInEnd.Name = "dtpInEnd";
            this.dtpInEnd.Size = new System.Drawing.Size(97, 21);
            this.dtpInEnd.TabIndex = 13;
            // 
            // rdoRedY
            // 
            this.rdoRedY.AutoSize = true;
            this.rdoRedY.BackColor = System.Drawing.Color.Transparent;
            this.rdoRedY.Location = new System.Drawing.Point(143, 14);
            this.rdoRedY.Name = "rdoRedY";
            this.rdoRedY.Size = new System.Drawing.Size(101, 16);
            this.rdoRedY.TabIndex = 12;
            this.rdoRedY.Text = "显示红灯+黄灯";
            this.rdoRedY.UseVisualStyleBackColor = false;
            // 
            // rdoYellow
            // 
            this.rdoYellow.AutoSize = true;
            this.rdoYellow.BackColor = System.Drawing.Color.Transparent;
            this.rdoYellow.Location = new System.Drawing.Point(344, 13);
            this.rdoYellow.Name = "rdoYellow";
            this.rdoYellow.Size = new System.Drawing.Size(95, 16);
            this.rdoYellow.TabIndex = 11;
            this.rdoYellow.TabStop = true;
            this.rdoYellow.Text = "显示黄灯警告";
            this.rdoYellow.UseVisualStyleBackColor = false;
            // 
            // rdoRed
            // 
            this.rdoRed.AutoSize = true;
            this.rdoRed.BackColor = System.Drawing.Color.Transparent;
            this.rdoRed.Checked = true;
            this.rdoRed.Location = new System.Drawing.Point(246, 14);
            this.rdoRed.Name = "rdoRed";
            this.rdoRed.Size = new System.Drawing.Size(95, 16);
            this.rdoRed.TabIndex = 10;
            this.rdoRed.TabStop = true;
            this.rdoRed.Text = "显示红灯警告";
            this.rdoRed.UseVisualStyleBackColor = false;
            // 
            // rdoRecord
            // 
            this.rdoRecord.AutoSize = true;
            this.rdoRecord.BackColor = System.Drawing.Color.Transparent;
            this.rdoRecord.Location = new System.Drawing.Point(8, 15);
            this.rdoRecord.Name = "rdoRecord";
            this.rdoRecord.Size = new System.Drawing.Size(131, 16);
            this.rdoRecord.TabIndex = 9;
            this.rdoRecord.TabStop = true;
            this.rdoRecord.Text = "显示补上文书的记录";
            this.rdoRecord.UseVisualStyleBackColor = false;
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Location = new System.Drawing.Point(942, 39);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(861, 38);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cboTextType
            // 
            this.cboTextType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextType.FormattingEnabled = true;
            this.cboTextType.Location = new System.Drawing.Point(301, 40);
            this.cboTextType.Name = "cboTextType";
            this.cboTextType.Size = new System.Drawing.Size(130, 20);
            this.cboTextType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(241, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "文书类型：";
            // 
            // cboSickArea
            // 
            this.cboSickArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSickArea.FormattingEnabled = true;
            this.cboSickArea.Location = new System.Drawing.Point(40, 39);
            this.cboSickArea.Name = "cboSickArea";
            this.cboSickArea.Size = new System.Drawing.Size(130, 20);
            this.cboSickArea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "病区：";
            // 
            // flgView
            // 
            this.flgView.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgView.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 20;
            this.flgView.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgView.Size = new System.Drawing.Size(1143, 481);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.TabIndex = 4;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "red.png");
            this.imageList1.Images.SetKeyName(1, "yellow.png");
            this.imageList1.Images.SetKeyName(2, "bule.png");
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.chbLeave_Time);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.Controls.Add(this.chbIn_Time);
            this.groupPanel1.Controls.Add(this.panel2);
            this.groupPanel1.Controls.Add(this.cboSickArea);
            this.groupPanel1.Controls.Add(this.rdoRedY);
            this.groupPanel1.Controls.Add(this.cboTextType);
            this.groupPanel1.Controls.Add(this.rdoYellow);
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.rdoRed);
            this.groupPanel1.Controls.Add(this.btnExcel);
            this.groupPanel1.Controls.Add(this.rdoRecord);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1149, 95);
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
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "查询条件";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 95);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1149, 505);
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
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "查询结果";
            // 
            // ucQualityList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucQualityList";
            this.Size = new System.Drawing.Size(1149, 600);
            this.Load += new System.EventHandler(this.ucQualityList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.ComboBox cboTextType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSickArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoYellow;
        private System.Windows.Forms.RadioButton rdoRed;
        private System.Windows.Forms.RadioButton rdoRecord;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView;
        private System.Windows.Forms.RadioButton rdoRedY;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInEnd;
        private System.Windows.Forms.DateTimePicker dtpOutEnd;
        private System.Windows.Forms.DateTimePicker dtpInStart;
        private System.Windows.Forms.DateTimePicker dtpOutStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbLeave_Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbIn_Time;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
    }
}
