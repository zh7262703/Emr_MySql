namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    partial class TemperWrite_Child
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
            this.cbAddEvent = new System.Windows.Forms.ComboBox();
            this.txtBreathing = new System.Windows.Forms.TextBox();
            this.cbTemperType = new System.Windows.Forms.ComboBox();
            this.txtTemper = new System.Windows.Forms.TextBox();
            this.cbReiteration = new System.Windows.Forms.CheckBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbEvents = new System.Windows.Forms.ListBox();
            this.dtpAddEventTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.btnAddEvent = new DevComponents.DotNetBar.ButtonX();
            this.ckBreath = new System.Windows.Forms.CheckBox();
            this.txtPulse = new System.Windows.Forms.TextBox();
            this.PulseCheck = new System.Windows.Forms.CheckBox();
            this.txtHeartRate = new System.Windows.Forms.TextBox();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.dtpSurgeryEndTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cbAddEvent
            // 
            this.cbAddEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddEvent.FormattingEnabled = true;
            this.cbAddEvent.Items.AddRange(new object[] {
            "--请选择--",
            "入室",
            "注射卡介苗",
            "注射乙肝疫苗",
            "手术",
            "死亡",
            "出院",
            "转入",
            "转出"});
            this.cbAddEvent.Location = new System.Drawing.Point(7, 179);
            this.cbAddEvent.Name = "cbAddEvent";
            this.cbAddEvent.Size = new System.Drawing.Size(85, 20);
            this.cbAddEvent.TabIndex = 87;
            this.cbAddEvent.SelectedIndexChanged += new System.EventHandler(this.cbAddEvent_SelectedIndexChanged);
            // 
            // txtBreathing
            // 
            this.txtBreathing.Location = new System.Drawing.Point(8, 96);
            this.txtBreathing.MaxLength = 3;
            this.txtBreathing.Name = "txtBreathing";
            this.txtBreathing.ShortcutsEnabled = false;
            this.txtBreathing.Size = new System.Drawing.Size(55, 21);
            this.txtBreathing.TabIndex = 99;
            this.txtBreathing.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtBreathing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // cbTemperType
            // 
            this.cbTemperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemperType.FormattingEnabled = true;
            this.cbTemperType.Items.AddRange(new object[] {
            "腋表",
            "口表",
            "肛表"});
            this.cbTemperType.Location = new System.Drawing.Point(7, 13);
            this.cbTemperType.Name = "cbTemperType";
            this.cbTemperType.Size = new System.Drawing.Size(56, 20);
            this.cbTemperType.TabIndex = 88;
            this.cbTemperType.SelectedIndexChanged += new System.EventHandler(this.cbTemperType_SelectedIndexChanged);
            // 
            // txtTemper
            // 
            this.txtTemper.Location = new System.Drawing.Point(69, 13);
            this.txtTemper.MaxLength = 4;
            this.txtTemper.Name = "txtTemper";
            this.txtTemper.ShortcutsEnabled = false;
            this.txtTemper.Size = new System.Drawing.Size(39, 21);
            this.txtTemper.TabIndex = 89;
            this.txtTemper.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtTemper.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxInput_KeyPress);
            // 
            // cbReiteration
            // 
            this.cbReiteration.AutoSize = true;
            this.cbReiteration.Location = new System.Drawing.Point(114, 15);
            this.cbReiteration.Name = "cbReiteration";
            this.cbReiteration.Size = new System.Drawing.Size(36, 16);
            this.cbReiteration.TabIndex = 94;
            this.cbReiteration.Text = "∨";
            this.cbReiteration.UseVisualStyleBackColor = true;
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(69, 36);
            this.txtDown.Name = "txtDown";
            this.txtDown.ShortcutsEnabled = false;
            this.txtDown.Size = new System.Drawing.Size(39, 21);
            this.txtDown.TabIndex = 103;
            this.txtDown.Visible = false;
            this.txtDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxInput_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 104;
            this.label1.Text = "↓";
            this.label1.Visible = false;
            // 
            // lbEvents
            // 
            this.lbEvents.FormattingEnabled = true;
            this.lbEvents.ItemHeight = 12;
            this.lbEvents.Location = new System.Drawing.Point(7, 263);
            this.lbEvents.Name = "lbEvents";
            this.lbEvents.Size = new System.Drawing.Size(135, 40);
            this.lbEvents.TabIndex = 106;
            // 
            // dtpAddEventTime
            // 
            this.dtpAddEventTime.CustomFormat = "HH:mm";
            this.dtpAddEventTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAddEventTime.Location = new System.Drawing.Point(7, 207);
            this.dtpAddEventTime.Name = "dtpAddEventTime";
            this.dtpAddEventTime.ShowUpDown = true;
            this.dtpAddEventTime.Size = new System.Drawing.Size(134, 21);
            this.dtpAddEventTime.TabIndex = 107;
            this.dtpAddEventTime.Value = new System.DateTime(2010, 6, 13, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 109;
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(117, 176);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(20, 23);
            this.btnClear.TabIndex = 129;
            this.btnClear.Text = "-";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddEvent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddEvent.Location = new System.Drawing.Point(94, 176);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(20, 23);
            this.btnAddEvent.TabIndex = 128;
            this.btnAddEvent.Text = "+";
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // ckBreath
            // 
            this.ckBreath.AutoSize = true;
            this.ckBreath.Font = new System.Drawing.Font("宋体", 15.5F);
            this.ckBreath.Location = new System.Drawing.Point(68, 96);
            this.ckBreath.Name = "ckBreath";
            this.ckBreath.Size = new System.Drawing.Size(40, 25);
            this.ckBreath.TabIndex = 130;
            this.ckBreath.Text = "®";
            this.ckBreath.UseVisualStyleBackColor = true;
            // 
            // txtPulse
            // 
            this.txtPulse.Location = new System.Drawing.Point(8, 64);
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.Size = new System.Drawing.Size(55, 21);
            this.txtPulse.TabIndex = 131;
            this.txtPulse.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            // 
            // PulseCheck
            // 
            this.PulseCheck.AutoSize = true;
            this.PulseCheck.Location = new System.Drawing.Point(68, 67);
            this.PulseCheck.Name = "PulseCheck";
            this.PulseCheck.Size = new System.Drawing.Size(36, 16);
            this.PulseCheck.TabIndex = 132;
            this.PulseCheck.Text = "绌";
            this.PulseCheck.UseVisualStyleBackColor = true;
            this.PulseCheck.CheckedChanged += new System.EventHandler(this.PusleCheck_CheckedChanged);
            // 
            // txtHeartRate
            // 
            this.txtHeartRate.Location = new System.Drawing.Point(8, 123);
            this.txtHeartRate.Name = "txtHeartRate";
            this.txtHeartRate.Size = new System.Drawing.Size(55, 21);
            this.txtHeartRate.TabIndex = 133;
            this.txtHeartRate.Visible = false;
            // 
            // cbEvent
            // 
            this.cbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Items.AddRange(new object[] {
            "--请选择--",
            "已测",
            "私自外出",
            "请假",
            "劝阻无效外出",
            "拒测"});
            this.cbEvent.Location = new System.Drawing.Point(7, 150);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(134, 20);
            this.cbEvent.TabIndex = 134;
            // 
            // dtpSurgeryEndTime
            // 
            this.dtpSurgeryEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpSurgeryEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSurgeryEndTime.Location = new System.Drawing.Point(7, 234);
            this.dtpSurgeryEndTime.Name = "dtpSurgeryEndTime";
            this.dtpSurgeryEndTime.ShowUpDown = true;
            this.dtpSurgeryEndTime.Size = new System.Drawing.Size(134, 21);
            this.dtpSurgeryEndTime.TabIndex = 135;
            this.dtpSurgeryEndTime.Value = new System.DateTime(2010, 6, 25, 0, 0, 0, 0);
            // 
            // TemperWrite_Child
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dtpSurgeryEndTime);
            this.Controls.Add(this.cbEvent);
            this.Controls.Add(this.txtHeartRate);
            this.Controls.Add(this.PulseCheck);
            this.Controls.Add(this.txtPulse);
            this.Controls.Add(this.ckBreath);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpAddEventTime);
            this.Controls.Add(this.lbEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDown);
            this.Controls.Add(this.cbAddEvent);
            this.Controls.Add(this.txtBreathing);
            this.Controls.Add(this.cbTemperType);
            this.Controls.Add(this.txtTemper);
            this.Controls.Add(this.cbReiteration);
            this.Name = "TemperWrite_Child";
            this.Size = new System.Drawing.Size(150, 308);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAddEvent;
        private System.Windows.Forms.TextBox txtBreathing;
        private System.Windows.Forms.ComboBox cbTemperType;
        private System.Windows.Forms.TextBox txtTemper;
        private System.Windows.Forms.CheckBox cbReiteration;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbEvents;
        private System.Windows.Forms.DateTimePicker dtpAddEventTime;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private DevComponents.DotNetBar.ButtonX btnAddEvent;
        private System.Windows.Forms.CheckBox ckBreath;
        private System.Windows.Forms.TextBox txtPulse;
        private System.Windows.Forms.CheckBox PulseCheck;
        private System.Windows.Forms.TextBox txtHeartRate;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.DateTimePicker dtpSurgeryEndTime;

    }
}
