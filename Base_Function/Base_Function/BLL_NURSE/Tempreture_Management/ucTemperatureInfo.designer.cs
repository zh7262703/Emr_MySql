namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    partial class ucTemperatureInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param Name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTemperatureInfo));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnTemperRemind = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.lblDateNext = new System.Windows.Forms.Label();
            this.lblDatePriview = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExTemperaturePaint_1 = new DevComponents.DotNetBar.ButtonX();
            this.btnTemperaturePaint_1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "print.bmp");
            this.imageList1.Images.SetKeyName(1, "yellow.gif");
            this.imageList1.Images.SetKeyName(2, "red.gif");
            this.imageList1.Images.SetKeyName(3, "prints.bmp");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1011, 700);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.radioButton2);
            this.groupPanel1.Controls.Add(this.radioButton1);
            this.groupPanel1.Controls.Add(this.btnTemperRemind);
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.lblDateNext);
            this.groupPanel1.Controls.Add(this.lblDatePriview);
            this.groupPanel1.Controls.Add(this.dtpDate);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1011, 86);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "查询设置";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(94, 2);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 21);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "新生儿";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 2);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 21);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "非新生儿";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnTemperRemind
            // 
            this.btnTemperRemind.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTemperRemind.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTemperRemind.Location = new System.Drawing.Point(177, 2);
            this.btnTemperRemind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTemperRemind.Name = "btnTemperRemind";
            this.btnTemperRemind.Size = new System.Drawing.Size(78, 30);
            this.btnTemperRemind.TabIndex = 5;
            this.btnTemperRemind.Text = "特温提醒";
            this.btnTemperRemind.Visible = false;
            this.btnTemperRemind.Click += new System.EventHandler(this.btnTemperRemind_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(773, 2);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(78, 30);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "查找";
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblDateNext
            // 
            this.lblDateNext.AutoSize = true;
            this.lblDateNext.BackColor = System.Drawing.Color.Transparent;
            this.lblDateNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDateNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateNext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDateNext.Location = new System.Drawing.Point(637, 9);
            this.lblDateNext.Name = "lblDateNext";
            this.lblDateNext.Size = new System.Drawing.Size(92, 17);
            this.lblDateNext.TabIndex = 3;
            this.lblDateNext.Text = ">>2010-05-16";
            this.lblDateNext.Visible = false;
            this.lblDateNext.Click += new System.EventHandler(this.lblDateNext_Click);
            // 
            // lblDatePriview
            // 
            this.lblDatePriview.AutoSize = true;
            this.lblDatePriview.BackColor = System.Drawing.Color.Transparent;
            this.lblDatePriview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDatePriview.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDatePriview.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDatePriview.Location = new System.Drawing.Point(336, 9);
            this.lblDatePriview.Name = "lblDatePriview";
            this.lblDatePriview.Size = new System.Drawing.Size(92, 17);
            this.lblDatePriview.TabIndex = 0;
            this.lblDatePriview.Text = "2010-05-14<<";
            this.lblDatePriview.Click += new System.EventHandler(this.lblDatePriview_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(457, 6);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(151, 23);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Controls.Add(this.panel1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1011, 608);
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
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "体温单群录";
            // 
            // flgView
            // 
            this.flgView.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgView.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flgView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 20;
            this.flgView.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgView.Size = new System.Drawing.Size(1005, 523);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData;
            this.flgView.TabIndex = 2;
            this.flgView.Click += new System.EventHandler(this.flgView_Click);
            this.flgView.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.flgView_AfterSelChange);
            this.flgView.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.flgView_StartEdit);
            this.flgView.EnterCell += new System.EventHandler(this.flgView_EnterCell);
            this.flgView.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.flgView_AfterEdit);
            this.flgView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flgView_KeyDown);
            this.flgView.LeaveCell += new System.EventHandler(this.flgView_LeaveCell);
            this.flgView.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.flgView_AfterDataRefresh);
            this.flgView.DoubleClick += new System.EventHandler(this.flgView_DoubleClick);
            this.flgView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flgView_KeyUp);
            this.flgView.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.flgView_CellChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExTemperaturePaint_1);
            this.panel1.Controls.Add(this.btnTemperaturePaint_1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 523);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 59);
            this.panel1.TabIndex = 5;
            // 
            // btnExTemperaturePaint_1
            // 
            this.btnExTemperaturePaint_1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExTemperaturePaint_1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExTemperaturePaint_1.Location = new System.Drawing.Point(619, 16);
            this.btnExTemperaturePaint_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExTemperaturePaint_1.Name = "btnExTemperaturePaint_1";
            this.btnExTemperaturePaint_1.Size = new System.Drawing.Size(174, 33);
            this.btnExTemperaturePaint_1.TabIndex = 11;
            this.btnExTemperaturePaint_1.Text = "打印异常体温单";
            this.btnExTemperaturePaint_1.Click += new System.EventHandler(this.btnExTemperaturePaint_1_Click);
            // 
            // btnTemperaturePaint_1
            // 
            this.btnTemperaturePaint_1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTemperaturePaint_1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTemperaturePaint_1.Location = new System.Drawing.Point(446, 16);
            this.btnTemperaturePaint_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTemperaturePaint_1.Name = "btnTemperaturePaint_1";
            this.btnTemperaturePaint_1.Size = new System.Drawing.Size(153, 33);
            this.btnTemperaturePaint_1.TabIndex = 10;
            this.btnTemperaturePaint_1.Text = "打印记录体温单";
            this.btnTemperaturePaint_1.Click += new System.EventHandler(this.btnTemperaturePaint_1_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(336, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 33);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucTemperatureInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucTemperatureInfo";
            this.Size = new System.Drawing.Size(1011, 700);
            this.Load += new System.EventHandler(this.ucTemperatureInfo_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblDateNext;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDatePriview;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnExTemperaturePaint_1;
        private DevComponents.DotNetBar.ButtonX btnTemperaturePaint_1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnTemperRemind;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
