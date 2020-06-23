namespace Base_Function.BLL_DOCTOR.HandoverRecord
{
    partial class FrmSetSectionHandoverTimePoint
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.daystart = new System.Windows.Forms.DateTimePicker();
            this.dayend = new System.Windows.Forms.DateTimePicker();
            this.nightend = new System.Windows.Forms.DateTimePicker();
            this.nightstart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "白班：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "开始时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "结束时间：";
            // 
            // daystart
            // 
            this.daystart.CustomFormat = "HH:mm";
            this.daystart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.daystart.Location = new System.Drawing.Point(134, 34);
            this.daystart.Name = "daystart";
            this.daystart.Size = new System.Drawing.Size(56, 21);
            this.daystart.TabIndex = 4;
            // 
            // dayend
            // 
            this.dayend.CustomFormat = "HH:mm";
            this.dayend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dayend.Location = new System.Drawing.Point(271, 34);
            this.dayend.Name = "dayend";
            this.dayend.Size = new System.Drawing.Size(53, 21);
            this.dayend.TabIndex = 5;
            // 
            // nightend
            // 
            this.nightend.CustomFormat = "HH:mm";
            this.nightend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nightend.Location = new System.Drawing.Point(271, 75);
            this.nightend.Name = "nightend";
            this.nightend.Size = new System.Drawing.Size(53, 21);
            this.nightend.TabIndex = 10;
            // 
            // nightstart
            // 
            this.nightstart.CustomFormat = "HH:mm";
            this.nightstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nightstart.Location = new System.Drawing.Point(134, 75);
            this.nightstart.Name = "nightstart";
            this.nightstart.Size = new System.Drawing.Size(56, 21);
            this.nightstart.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "结束时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "开始时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "夜班：";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(78, 123);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(103, 36);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 11;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(187, 123);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(103, 36);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 12;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmSetSectionHandoverTimePoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 190);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.nightend);
            this.Controls.Add(this.nightstart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dayend);
            this.Controls.Add(this.daystart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSetSectionHandoverTimePoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科室交接班时间点设置";
            this.Load += new System.EventHandler(this.FrmSetSectionHandoverTimePoint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker daystart;
        private System.Windows.Forms.DateTimePicker dayend;
        private System.Windows.Forms.DateTimePicker nightend;
        private System.Windows.Forms.DateTimePicker nightstart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}