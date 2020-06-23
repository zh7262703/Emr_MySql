namespace Bifrost.Hook
{
    partial class FrmPassWordChecked
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
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(59, 12);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(189, 21);
            this.txtPassWord.TabIndex = 0;
            this.txtPassWord.UseSystemPasswordChar = true;
            this.txtPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassWord_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "密码：";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Location = new System.Drawing.Point(59, 39);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "重新登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(173, 39);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出程序";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmPassWordChecked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 75);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassWord);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPassWordChecked";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录超时";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPassWordChecked_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.ButtonX btnExit;
    }
}