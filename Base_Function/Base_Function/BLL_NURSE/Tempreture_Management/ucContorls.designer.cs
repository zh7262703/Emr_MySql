namespace Bifrost_Nurse.UControl
{
    partial class ucContorls
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
            this.dtpSurgeryEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpAddEventTime = new System.Windows.Forms.DateTimePicker();
            this.cbAddEvent = new System.Windows.Forms.ComboBox();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.cbReiteration = new System.Windows.Forms.CheckBox();
            this.txtTemper = new System.Windows.Forms.TextBox();
            this.lbEvents = new System.Windows.Forms.ListBox();
            this.btnAddEvent = new DevComponents.DotNetBar.ButtonX();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.chkTemperture = new System.Windows.Forms.CheckBox();
            this.lblTemperture = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpSurgeryEndTime
            // 
            this.dtpSurgeryEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpSurgeryEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSurgeryEndTime.Location = new System.Drawing.Point(12, 143);
            this.dtpSurgeryEndTime.Name = "dtpSurgeryEndTime";
            this.dtpSurgeryEndTime.ShowUpDown = true;
            this.dtpSurgeryEndTime.Size = new System.Drawing.Size(105, 21);
            this.dtpSurgeryEndTime.TabIndex = 124;
            this.dtpSurgeryEndTime.Value = new System.DateTime(2010, 6, 25, 0, 0, 0, 0);
            // 
            // dtpAddEventTime
            // 
            this.dtpAddEventTime.CustomFormat = "HH:mm";
            this.dtpAddEventTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAddEventTime.Location = new System.Drawing.Point(12, 116);
            this.dtpAddEventTime.Name = "dtpAddEventTime";
            this.dtpAddEventTime.ShowUpDown = true;
            this.dtpAddEventTime.Size = new System.Drawing.Size(105, 21);
            this.dtpAddEventTime.TabIndex = 123;
            this.dtpAddEventTime.Value = new System.DateTime(2010, 6, 13, 0, 0, 0, 0);
            // 
            // cbAddEvent
            // 
            this.cbAddEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddEvent.FormattingEnabled = true;
            this.cbAddEvent.Items.AddRange(new object[] {
            "--请选择--",
            "入室",
            "手术",
            "出院",
            "转出科室",
            "死亡"});
            this.cbAddEvent.Location = new System.Drawing.Point(12, 95);
            this.cbAddEvent.Name = "cbAddEvent";
            this.cbAddEvent.Size = new System.Drawing.Size(59, 20);
            this.cbAddEvent.TabIndex = 119;
            this.cbAddEvent.SelectedIndexChanged += new System.EventHandler(this.cbAddEvent_SelectedIndexChanged);
            this.cbAddEvent.Click += new System.EventHandler(this.cbAddEvent_Click);
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
            "拒测"});
            this.cbEvent.Location = new System.Drawing.Point(12, 67);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(105, 20);
            this.cbEvent.TabIndex = 117;
            this.cbEvent.SelectedIndexChanged += new System.EventHandler(this.cbEvent_SelectedIndexChanged);
            // 
            // cbReiteration
            // 
            this.cbReiteration.AutoSize = true;
            this.cbReiteration.Location = new System.Drawing.Point(65, 7);
            this.cbReiteration.Name = "cbReiteration";
            this.cbReiteration.Size = new System.Drawing.Size(36, 16);
            this.cbReiteration.TabIndex = 118;
            this.cbReiteration.Text = "∨";
            this.cbReiteration.UseVisualStyleBackColor = true;
            // 
            // txtTemper
            // 
            this.txtTemper.Location = new System.Drawing.Point(12, 2);
            this.txtTemper.MaxLength = 8;
            this.txtTemper.Name = "txtTemper";
            this.txtTemper.Size = new System.Drawing.Size(47, 21);
            this.txtTemper.TabIndex = 116;
            this.txtTemper.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtTemper.Click += new System.EventHandler(this.txtTemper_Click);
            this.txtTemper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // lbEvents
            // 
            this.lbEvents.FormattingEnabled = true;
            this.lbEvents.HorizontalScrollbar = true;
            this.lbEvents.ItemHeight = 12;
            this.lbEvents.Location = new System.Drawing.Point(11, 172);
            this.lbEvents.Name = "lbEvents";
            this.lbEvents.ScrollAlwaysVisible = true;
            this.lbEvents.Size = new System.Drawing.Size(106, 40);
            this.lbEvents.TabIndex = 125;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddEvent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddEvent.Location = new System.Drawing.Point(73, 92);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(20, 23);
            this.btnAddEvent.TabIndex = 126;
            this.btnAddEvent.Text = "+";
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(96, 92);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(20, 23);
            this.btnClear.TabIndex = 127;
            this.btnClear.Text = "-";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkTemperture
            // 
            this.chkTemperture.AutoSize = true;
            this.chkTemperture.Location = new System.Drawing.Point(17, 49);
            this.chkTemperture.Name = "chkTemperture";
            this.chkTemperture.Size = new System.Drawing.Size(15, 14);
            this.chkTemperture.TabIndex = 128;
            this.chkTemperture.UseVisualStyleBackColor = true;
            this.chkTemperture.CheckedChanged += new System.EventHandler(this.chkTemperture_CheckedChanged);
            // 
            // lblTemperture
            // 
            this.lblTemperture.AutoSize = true;
            this.lblTemperture.Location = new System.Drawing.Point(30, 50);
            this.lblTemperture.Name = "lblTemperture";
            this.lblTemperture.Size = new System.Drawing.Size(41, 12);
            this.lblTemperture.TabIndex = 129;
            this.lblTemperture.Text = "≤35℃";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(71, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 130;
            this.label2.Text = "↓";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 132;
            this.label1.Text = "↓";
            this.label1.Visible = false;
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(18, 26);
            this.txtDown.Name = "txtDown";
            this.txtDown.ShortcutsEnabled = false;
            this.txtDown.Size = new System.Drawing.Size(39, 21);
            this.txtDown.TabIndex = 131;
            this.txtDown.Visible = false;
            // 
            // ucContorls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTemperture);
            this.Controls.Add(this.chkTemperture);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.lbEvents);
            this.Controls.Add(this.dtpSurgeryEndTime);
            this.Controls.Add(this.dtpAddEventTime);
            this.Controls.Add(this.cbAddEvent);
            this.Controls.Add(this.cbEvent);
            this.Controls.Add(this.cbReiteration);
            this.Controls.Add(this.txtTemper);
            this.Name = "ucContorls";
            this.Size = new System.Drawing.Size(125, 235);
            this.Load += new System.EventHandler(this.ucContorls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpSurgeryEndTime;
        private System.Windows.Forms.DateTimePicker dtpAddEventTime;
        private System.Windows.Forms.ComboBox cbAddEvent;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.CheckBox cbReiteration;
        private System.Windows.Forms.TextBox txtTemper;
        private System.Windows.Forms.ListBox lbEvents;
        private DevComponents.DotNetBar.ButtonX btnAddEvent;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private System.Windows.Forms.CheckBox chkTemperture;
        private System.Windows.Forms.Label lblTemperture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDown;

    }
}
