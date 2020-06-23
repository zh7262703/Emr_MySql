namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    partial class ucBlood_Sugar_Record
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBlood_Sugar_Record));
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.lblBed_no = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHosNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatetime = new System.Windows.Forms.DateTimePicker();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTosign = new System.Windows.Forms.TextBox();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flgView
            // 
            this.flgView.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgView.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 58);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 18;
            this.flgView.Size = new System.Drawing.Size(845, 509);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.TabIndex = 1;
            this.flgView.Click += new System.EventHandler(this.flgView_Click);
            this.flgView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flgView_KeyDown);
            this.flgView.DoubleClick += new System.EventHandler(this.flgView_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(376, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 123;
            this.label7.Text = "住院号：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flgView);
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(845, 600);
            this.splitContainer1.SplitterDistance = 567;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 58);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(845, 509);
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
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "血糖检测单列表";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnPrint);
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.lblBed_no);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.lblPname);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.lblHosNumber);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(845, 58);
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
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(737, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(59, 23);
            this.btnPrint.TabIndex = 130;
            this.btnPrint.Text = "打印";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(654, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(59, 23);
            this.btnSelect.TabIndex = 130;
            this.btnSelect.Text = "刷新";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblBed_no
            // 
            this.lblBed_no.AutoSize = true;
            this.lblBed_no.BackColor = System.Drawing.Color.Transparent;
            this.lblBed_no.Location = new System.Drawing.Point(115, 9);
            this.lblBed_no.Name = "lblBed_no";
            this.lblBed_no.Size = new System.Drawing.Size(59, 12);
            this.lblBed_no.TabIndex = 129;
            this.lblBed_no.Text = "lblBed_no";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(76, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "床号：";
            // 
            // lblPname
            // 
            this.lblPname.AutoSize = true;
            this.lblPname.BackColor = System.Drawing.Color.Transparent;
            this.lblPname.Location = new System.Drawing.Point(267, 9);
            this.lblPname.Name = "lblPname";
            this.lblPname.Size = new System.Drawing.Size(53, 12);
            this.lblPname.TabIndex = 128;
            this.lblPname.Text = "lblPname";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(230, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 120;
            this.label6.Text = "姓名：";
            // 
            // lblHosNumber
            // 
            this.lblHosNumber.AutoSize = true;
            this.lblHosNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblHosNumber.Location = new System.Drawing.Point(425, 9);
            this.lblHosNumber.Name = "lblHosNumber";
            this.lblHosNumber.Size = new System.Drawing.Size(77, 12);
            this.lblHosNumber.TabIndex = 127;
            this.lblHosNumber.Text = "lblHosNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(242, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 115;
            this.label2.Text = "结果值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(464, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 116;
            this.label3.Text = "类型：";
            // 
            // dtpDatetime
            // 
            this.dtpDatetime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatetime.Location = new System.Drawing.Point(79, 13);
            this.dtpDatetime.Name = "dtpDatetime";
            this.dtpDatetime.Size = new System.Drawing.Size(147, 21);
            this.dtpDatetime.TabIndex = 114;
            this.dtpDatetime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDatetime_KeyDown);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(296, 13);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(106, 21);
            this.txtValue.TabIndex = 117;
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(511, 15);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 20);
            this.cboType.TabIndex = 118;
            this.cboType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboType_KeyDown);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Location = new System.Drawing.Point(408, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(41, 12);
            this.lblCount.TabIndex = 119;
            this.lblCount.Text = "mmol/L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(647, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 120;
            this.label4.Text = "签名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(32, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 113;
            this.label1.Text = "时间：";
            // 
            // txtTosign
            // 
            this.txtTosign.Location = new System.Drawing.Point(686, 14);
            this.txtTosign.Name = "txtTosign";
            this.txtTosign.Size = new System.Drawing.Size(105, 21);
            this.txtTosign.TabIndex = 121;
            this.txtTosign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTosign_KeyDown);
            this.txtTosign.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTosign_KeyUp);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(302, 64);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 122;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(383, 64);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 122;
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(461, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 122;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnCancel);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.btnAdd);
            this.groupPanel3.Controls.Add(this.txtTosign);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Controls.Add(this.label4);
            this.groupPanel3.Controls.Add(this.lblCount);
            this.groupPanel3.Controls.Add(this.cboType);
            this.groupPanel3.Controls.Add(this.txtValue);
            this.groupPanel3.Controls.Add(this.dtpDatetime);
            this.groupPanel3.Controls.Add(this.label3);
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Location = new System.Drawing.Point(3, 126);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(845, 10);
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
            this.groupPanel3.TabIndex = 114;
            this.groupPanel3.Text = "编辑信息";
            this.groupPanel3.Visible = false;
            // 
            // ucBlood_Sugar_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucBlood_Sugar_Record";
            this.Size = new System.Drawing.Size(845, 600);
            this.Load += new System.EventHandler(this.ucBlood_Sugar_Record_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid flgView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBed_no;
        private System.Windows.Forms.Label lblPname;
        private System.Windows.Forms.Label lblHosNumber;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.TextBox txtTosign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DateTimePicker dtpDatetime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
