namespace Base_Function.BLL_MANAGEMENT
{
    partial class Spotcheck_Grade
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
            this.flgView = new Bifrost.ucC1FlexGrid();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkSick = new System.Windows.Forms.CheckBox();
            this.cboSections = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSick = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkGravenurserecord = new System.Windows.Forms.CheckBox();
            this.chkTemperture = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSelete = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flgView
            // 
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Size = new System.Drawing.Size(779, 306);
            this.flgView.TabIndex = 0;
            this.flgView.Click += new System.EventHandler(this.flgView_Click);
            this.flgView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.flgView_MouseDoubleClick);
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.BackColor = System.Drawing.Color.Transparent;
            this.chkTime.Location = new System.Drawing.Point(13, 13);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(15, 14);
            this.chkTime.TabIndex = 33;
            this.chkTime.UseVisualStyleBackColor = false;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.BackColor = System.Drawing.Color.Transparent;
            this.chkSection.Location = new System.Drawing.Point(274, 42);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(15, 14);
            this.chkSection.TabIndex = 32;
            this.chkSection.UseVisualStyleBackColor = false;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // chkSick
            // 
            this.chkSick.AutoSize = true;
            this.chkSick.BackColor = System.Drawing.Color.Transparent;
            this.chkSick.Location = new System.Drawing.Point(72, 42);
            this.chkSick.Name = "chkSick";
            this.chkSick.Size = new System.Drawing.Size(15, 14);
            this.chkSick.TabIndex = 31;
            this.chkSick.UseVisualStyleBackColor = false;
            this.chkSick.CheckedChanged += new System.EventHandler(this.chkSick_CheckedChanged);
            // 
            // cboSections
            // 
            this.cboSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSections.FormattingEnabled = true;
            this.cboSections.Location = new System.Drawing.Point(326, 37);
            this.cboSections.Name = "cboSections";
            this.cboSections.Size = new System.Drawing.Size(121, 20);
            this.cboSections.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(289, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "科室：";
            // 
            // cboSick
            // 
            this.cboSick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSick.FormattingEnabled = true;
            this.cboSick.Location = new System.Drawing.Point(123, 39);
            this.cboSick.Name = "cboSick";
            this.cboSick.Size = new System.Drawing.Size(121, 20);
            this.cboSick.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(87, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "病区：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(25, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "抽查：";
            // 
            // chkGravenurserecord
            // 
            this.chkGravenurserecord.AutoSize = true;
            this.chkGravenurserecord.BackColor = System.Drawing.Color.Transparent;
            this.chkGravenurserecord.Location = new System.Drawing.Point(507, 14);
            this.chkGravenurserecord.Name = "chkGravenurserecord";
            this.chkGravenurserecord.Size = new System.Drawing.Size(96, 16);
            this.chkGravenurserecord.TabIndex = 25;
            this.chkGravenurserecord.Text = "危重护理记录";
            this.chkGravenurserecord.UseVisualStyleBackColor = false;
            this.chkGravenurserecord.CheckedChanged += new System.EventHandler(this.chkGravenurserecord_CheckedChanged);
            // 
            // chkTemperture
            // 
            this.chkTemperture.AutoSize = true;
            this.chkTemperture.BackColor = System.Drawing.Color.Transparent;
            this.chkTemperture.Location = new System.Drawing.Point(441, 14);
            this.chkTemperture.Name = "chkTemperture";
            this.chkTemperture.Size = new System.Drawing.Size(60, 16);
            this.chkTemperture.TabIndex = 24;
            this.chkTemperture.Text = "体温单";
            this.chkTemperture.UseVisualStyleBackColor = false;
            this.chkTemperture.CheckedChanged += new System.EventHandler(this.chkTemperture_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(346, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "抽查文书种类：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(209, 11);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(122, 21);
            this.dtpEndTime.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(191, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "－";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(67, 11);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(122, 21);
            this.dtpStartTime.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "日期：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnSelete);
            this.groupPanel1.Controls.Add(this.chkTime);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.chkSection);
            this.groupPanel1.Controls.Add(this.chkSick);
            this.groupPanel1.Controls.Add(this.dtpStartTime);
            this.groupPanel1.Controls.Add(this.cboSections);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.dtpEndTime);
            this.groupPanel1.Controls.Add(this.cboSick);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.chkTemperture);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.chkGravenurserecord);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(785, 91);
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
            this.groupPanel1.Text = "历史记录查询设置";
            // 
            // btnSelete
            // 
            this.btnSelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelete.Location = new System.Drawing.Point(593, 32);
            this.btnSelete.Name = "btnSelete";
            this.btnSelete.Size = new System.Drawing.Size(75, 23);
            this.btnSelete.TabIndex = 34;
            this.btnSelete.Text = "查询";
            this.btnSelete.Click += new System.EventHandler(this.btnSelete_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 91);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(785, 330);
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
            this.groupPanel2.Text = "历史记录显示列表";
            // 
            // Spotcheck_Grade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "Spotcheck_Grade";
            this.Size = new System.Drawing.Size(785, 421);
            this.Load += new System.EventHandler(this.Spotcheck_Grade_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bifrost.ucC1FlexGrid flgView;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkSick;
        private System.Windows.Forms.ComboBox cboSections;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkGravenurserecord;
        private System.Windows.Forms.CheckBox chkTemperture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSelete;
    }
}
