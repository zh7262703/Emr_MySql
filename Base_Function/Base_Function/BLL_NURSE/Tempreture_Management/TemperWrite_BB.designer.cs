namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    partial class TemperWrite_BB
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
            this.cbTemperType = new System.Windows.Forms.ComboBox();
            this.txtTemper = new System.Windows.Forms.TextBox();
            this.cbReiteration = new System.Windows.Forms.CheckBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.txtDown.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 109;
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
            this.cbEvent.Location = new System.Drawing.Point(7, 63);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(134, 20);
            this.cbEvent.TabIndex = 134;
            this.cbEvent.Visible = false;
            // 
            // TemperWrite_BB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cbEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDown);
            this.Controls.Add(this.cbTemperType);
            this.Controls.Add(this.txtTemper);
            this.Controls.Add(this.cbReiteration);
            this.Name = "TemperWrite_BB";
            this.Size = new System.Drawing.Size(150, 92);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTemperType;
        private System.Windows.Forms.TextBox txtTemper;
        private System.Windows.Forms.CheckBox cbReiteration;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEvent;

    }
}
