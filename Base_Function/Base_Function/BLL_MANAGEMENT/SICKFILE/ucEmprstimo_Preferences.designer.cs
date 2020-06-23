namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucEmprstimo_Preferences
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
            this.cboOutside_Hospital_TimeUnit = new System.Windows.Forms.ComboBox();
            this.cboHospital_TimeUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutside_Hospital_Time = new System.Windows.Forms.TextBox();
            this.txtHospital_Time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutside_Hospital_Markup = new System.Windows.Forms.TextBox();
            this.txtHospital_Markup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDocumentDays = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboOutside_Hospital_TimeUnit
            // 
            this.cboOutside_Hospital_TimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutside_Hospital_TimeUnit.FormattingEnabled = true;
            this.cboOutside_Hospital_TimeUnit.Location = new System.Drawing.Point(572, 123);
            this.cboOutside_Hospital_TimeUnit.Name = "cboOutside_Hospital_TimeUnit";
            this.cboOutside_Hospital_TimeUnit.Size = new System.Drawing.Size(68, 20);
            this.cboOutside_Hospital_TimeUnit.TabIndex = 16;
            // 
            // cboHospital_TimeUnit
            // 
            this.cboHospital_TimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHospital_TimeUnit.FormattingEnabled = true;
            this.cboHospital_TimeUnit.Location = new System.Drawing.Point(572, 85);
            this.cboHospital_TimeUnit.Name = "cboHospital_TimeUnit";
            this.cboHospital_TimeUnit.Size = new System.Drawing.Size(68, 20);
            this.cboHospital_TimeUnit.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(24, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "归还登记";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "院外时间单位设置：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "院内时间单位设置：";
            // 
            // txtOutside_Hospital_Time
            // 
            this.txtOutside_Hospital_Time.Location = new System.Drawing.Point(370, 123);
            this.txtOutside_Hospital_Time.Name = "txtOutside_Hospital_Time";
            this.txtOutside_Hospital_Time.Size = new System.Drawing.Size(75, 21);
            this.txtOutside_Hospital_Time.TabIndex = 7;
            this.txtOutside_Hospital_Time.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutside_Hospital_Time_KeyDown);
            // 
            // txtHospital_Time
            // 
            this.txtHospital_Time.Location = new System.Drawing.Point(370, 85);
            this.txtHospital_Time.Name = "txtHospital_Time";
            this.txtHospital_Time.Size = new System.Drawing.Size(75, 21);
            this.txtHospital_Time.TabIndex = 6;
            this.txtHospital_Time.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHospital_Time_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "院外时间参数设置：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "院内时间参数设置：";
            // 
            // txtOutside_Hospital_Markup
            // 
            this.txtOutside_Hospital_Markup.Location = new System.Drawing.Point(162, 123);
            this.txtOutside_Hospital_Markup.Name = "txtOutside_Hospital_Markup";
            this.txtOutside_Hospital_Markup.Size = new System.Drawing.Size(75, 21);
            this.txtOutside_Hospital_Markup.TabIndex = 3;
            this.txtOutside_Hospital_Markup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutside_Hospital_Markup_KeyDown);
            // 
            // txtHospital_Markup
            // 
            this.txtHospital_Markup.Location = new System.Drawing.Point(162, 85);
            this.txtHospital_Markup.Name = "txtHospital_Markup";
            this.txtHospital_Markup.Size = new System.Drawing.Size(75, 21);
            this.txtHospital_Markup.TabIndex = 2;
            this.txtHospital_Markup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHospital_Markup_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "院外借阅时间设置标识：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "院内借阅时间设置标识：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtDocumentDays);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.btnCancel);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.cboOutside_Hospital_TimeUnit);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.cboHospital_TimeUnit);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.txtHospital_Markup);
            this.groupPanel1.Controls.Add(this.txtOutside_Hospital_Markup);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtHospital_Time);
            this.groupPanel1.Controls.Add(this.txtOutside_Hospital_Time);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(670, 374);
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
            this.groupPanel1.Text = "病案归还日期参数设置";
            // 
            // txtDocumentDays
            // 
            this.txtDocumentDays.Location = new System.Drawing.Point(162, 202);
            this.txtDocumentDays.Name = "txtDocumentDays";
            this.txtDocumentDays.Size = new System.Drawing.Size(75, 21);
            this.txtDocumentDays.TabIndex = 20;
            this.txtDocumentDays.Text = "1";
            this.txtDocumentDays.TextChanged += new System.EventHandler(this.txtDocumentDays_TextChanged);
            this.txtDocumentDays.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDocumentDays_KeyUp);
            this.txtDocumentDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumentDays_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "出院后归档天数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(24, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "出院归档天数";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(338, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(257, 234);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "确 定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucEmprstimo_Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucEmprstimo_Preferences";
            this.Size = new System.Drawing.Size(670, 374);
            this.Load += new System.EventHandler(this.ucEmprstimo_Preferences_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutside_Hospital_Time;
        private System.Windows.Forms.TextBox txtHospital_Time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutside_Hospital_Markup;
        private System.Windows.Forms.TextBox txtHospital_Markup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboOutside_Hospital_TimeUnit;
        private System.Windows.Forms.ComboBox cboHospital_TimeUnit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDocumentDays;
        private System.Windows.Forms.Label label9;

    }
}
