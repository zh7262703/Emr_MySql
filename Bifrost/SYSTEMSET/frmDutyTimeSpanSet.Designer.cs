namespace Bifrost.SYSTEMSET
{
    partial class frmDutyTimeSpanSet
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label3 = new System.Windows.Forms.Label();
            this.cboC1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.cboC2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ucGridviewX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(811, 185);
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
            this.groupPanel1.Text = "信息列表";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnCancel);
            this.groupPanel2.Controls.Add(this.btnSave);
            this.groupPanel2.Controls.Add(this.btnDelete);
            this.groupPanel2.Controls.Add(this.btnUpdate);
            this.groupPanel2.Controls.Add(this.btnAdd);
            this.groupPanel2.Controls.Add(this.cboC2);
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Controls.Add(this.cboC1);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.dtpEnd);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.cboRole);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.dtpStart);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel2.Location = new System.Drawing.Point(0, 185);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(811, 180);
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
            this.groupPanel2.Text = "详细信息";
            // 
            // dtpStart
            // 
            // 
            // 
            // 
            this.dtpStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpStart.ButtonDropDown.Visible = true;
            this.dtpStart.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dtpStart.Location = new System.Drawing.Point(74, 41);
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtpStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpStart.MonthCalendar.DisplayMonth = new System.DateTime(2011, 7, 1, 0, 0, 0, 0);
            this.dtpStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpStart.MonthCalendar.TodayButtonVisible = true;
            this.dtpStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(135, 21);
            this.dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "角色：";
            // 
            // cboRole
            // 
            this.cboRole.DisplayMember = "Text";
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.ItemHeight = 15;
            this.cboRole.Location = new System.Drawing.Point(74, 14);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(135, 21);
            this.cboRole.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "起始时间：";
            // 
            // dtpEnd
            // 
            // 
            // 
            // 
            this.dtpEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpEnd.ButtonDropDown.Visible = true;
            this.dtpEnd.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dtpEnd.Location = new System.Drawing.Point(74, 68);
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtpEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpEnd.MonthCalendar.DisplayMonth = new System.DateTime(2011, 7, 1, 0, 0, 0, 0);
            this.dtpEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpEnd.MonthCalendar.TodayButtonVisible = true;
            this.dtpEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(135, 21);
            this.dtpEnd.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "结束时间：";
            // 
            // cboC1
            // 
            this.cboC1.DisplayMember = "Text";
            this.cboC1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboC1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboC1.FormattingEnabled = true;
            this.cboC1.ItemHeight = 15;
            this.cboC1.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cboC1.Location = new System.Drawing.Point(271, 41);
            this.cboC1.Name = "cboC1";
            this.cboC1.Size = new System.Drawing.Size(48, 21);
            this.cboC1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(224, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "条件：";
            // 
            // cboC2
            // 
            this.cboC2.DisplayMember = "Text";
            this.cboC2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboC2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboC2.FormattingEnabled = true;
            this.cboC2.ItemHeight = 15;
            this.cboC2.Items.AddRange(new object[] {
            this.comboItem3,
            this.comboItem4});
            this.cboC2.Location = new System.Drawing.Point(271, 68);
            this.cboC2.Name = "cboC2";
            this.cboC2.Size = new System.Drawing.Size(48, 21);
            this.cboC2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(225, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "条件：";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(534, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 203;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(449, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 202;
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(364, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 201;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(280, 121);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 200;
            this.btnUpdate.Text = "修改(&M)";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(196, 121);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 199;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = ">";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = ">=";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "<";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "<=";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(805, 161);
            this.ucGridviewX1.TabIndex = 0;
            this.ucGridviewX1.Click += new System.EventHandler(this.ucGridviewX1_Click);
            // 
            // frmDutyTimeSpanSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 365);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel2);
            this.Name = "frmDutyTimeSpanSet";
            this.Text = "角色有效时间设置";
            this.Load += new System.EventHandler(this.frmDutyTimeSpanSet_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboRole;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpStart;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboC2;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboC1;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}