namespace Bifrost
{
    partial class frmPasswordChanged
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
            this.txtNewPasswordAgin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.ucPasswordStrongCheck1 = new Bifrost.ucPasswordStrongCheck();
            this.SuspendLayout();
            // 
            // txtNewPasswordAgin
            // 
            this.txtNewPasswordAgin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPasswordAgin.Location = new System.Drawing.Point(92, 65);
            this.txtNewPasswordAgin.Name = "txtNewPasswordAgin";
            this.txtNewPasswordAgin.PasswordChar = '*';
            this.txtNewPasswordAgin.Size = new System.Drawing.Size(157, 23);
            this.txtNewPasswordAgin.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(23, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "确认密码：";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPassword.Location = new System.Drawing.Point(92, 38);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(157, 23);
            this.txtNewPassword.TabIndex = 37;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(35, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "新密码：";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPassword.Location = new System.Drawing.Point(92, 12);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(157, 23);
            this.txtOldPassword.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "原密码：";
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.Location = new System.Drawing.Point(63, 120);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(76, 19);
            this.btnSure.TabIndex = 44;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(145, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 19);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(23, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "密码校验：";
            // 
            // ucPasswordStrongCheck1
            // 
            this.ucPasswordStrongCheck1.BackColor = System.Drawing.Color.Transparent;
            this.ucPasswordStrongCheck1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucPasswordStrongCheck1.ForeColor = System.Drawing.Color.Maroon;
            this.ucPasswordStrongCheck1.Location = new System.Drawing.Point(92, 92);
            this.ucPasswordStrongCheck1.Name = "ucPasswordStrongCheck1";
            this.ucPasswordStrongCheck1.Size = new System.Drawing.Size(163, 20);
            this.ucPasswordStrongCheck1.TabIndex = 46;
            // 
            // frmPasswordChanged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 168);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucPasswordStrongCheck1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewPasswordAgin);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPasswordChanged";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码修改";
            this.Load += new System.EventHandler(this.frmPasswordChanged_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewPasswordAgin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private ucPasswordStrongCheck ucPasswordStrongCheck1;
        private System.Windows.Forms.Label label2;
    }
}