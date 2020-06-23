namespace Bifrost
{
    partial class frmHightLevelSign
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
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNewName = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewAccount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工   号： ";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(71, 23);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(125, 21);
            this.txtAccount.TabIndex = 1;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            this.txtAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccount_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密   码：";
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(50, 2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(66, 23);
            this.btnSure.TabIndex = 3;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(122, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(71, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(125, 21);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 79);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 12);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "姓   名： ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 28);
            this.panel1.TabIndex = 7;
            // 
            // lblNewName
            // 
            this.lblNewName.AutoSize = true;
            this.lblNewName.Location = new System.Drawing.Point(15, 80);
            this.lblNewName.Name = "lblNewName";
            this.lblNewName.Size = new System.Drawing.Size(65, 12);
            this.lblNewName.TabIndex = 12;
            this.lblNewName.Text = "姓   名： ";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(71, 51);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(125, 21);
            this.txtNewPassword.TabIndex = 11;
            this.txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPassword_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "密   码：";
            // 
            // txtNewAccount
            // 
            this.txtNewAccount.Location = new System.Drawing.Point(71, 24);
            this.txtNewAccount.Name = "txtNewAccount";
            this.txtNewAccount.Size = new System.Drawing.Size(125, 21);
            this.txtNewAccount.TabIndex = 9;
            this.txtNewAccount.TextChanged += new System.EventHandler(this.txtNewAccount_TextChanged);
            this.txtNewAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewAccount_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "工   号： ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNewAccount);
            this.panel2.Controls.Add(this.lblNewName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtNewPassword);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 101);
            this.panel2.TabIndex = 13;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "原签名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(15, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "新签名";
            // 
            // frmHightLevelSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(239, 237);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmHightLevelSign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上级医师签名";
            this.Load += new System.EventHandler(this.frmHightLevelSign_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNewName;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}