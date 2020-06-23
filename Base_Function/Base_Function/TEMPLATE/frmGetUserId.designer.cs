namespace Base_Function.TEMPLATE
{
    partial class frmGetUserId
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetUserId));
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 12);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "姓   名： ";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(112, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(40, 73);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(66, 23);
            this.btnSure.TabIndex = 10;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(75, 12);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(125, 21);
            this.txtAccount.TabIndex = 8;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            this.txtAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "工   号： ";
            // 
            // frmGetUserId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 107);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetUserId";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医生确认";
            this.Load += new System.EventHandler(this.frmGetUserId_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label1;
    }
}