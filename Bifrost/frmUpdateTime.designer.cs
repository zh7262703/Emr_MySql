namespace Bifrost
{
    partial class frmUpdateTime
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
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy-MM-dd  HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(131, 7);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(159, 21);
            this.dtpTime.TabIndex = 1;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(65, 11);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(65, 12);
            this.lblRecord.TabIndex = 2;
            this.lblRecord.Text = "记录时间：";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(65, 38);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(65, 12);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "记录名称：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(131, 35);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(159, 22);
            this.txtContent.TabIndex = 4;
            this.txtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(107, 92);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(188, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "医    生：";
            this.label1.Visible = false;
            // 
            // txtDoctor
            // 
            this.txtDoctor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDoctor.Location = new System.Drawing.Point(131, 62);
            this.txtDoctor.Multiline = true;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(159, 22);
            this.txtDoctor.TabIndex = 4;
            this.txtDoctor.Visible = false;
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            this.txtDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyDown);
            this.txtDoctor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyUp);
            // 
            // frmUpdateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 123);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.dtpTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateTime";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文书时间";
            this.Load += new System.EventHandler(this.frmUpdateTime_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpdateTime_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDoctor;
    }
}