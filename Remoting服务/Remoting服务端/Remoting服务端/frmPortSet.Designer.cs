namespace Remoting服务端
{
    partial class frmPortSet
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCpuId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegsit = new System.Windows.Forms.TextBox();
            this.lblRegist = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegist = new System.Windows.Forms.Button();
            this.chkHttp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口号：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "9999";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "CPUID：";
            // 
            // txtCpuId
            // 
            this.txtCpuId.BackColor = System.Drawing.Color.White;
            this.txtCpuId.Location = new System.Drawing.Point(119, 41);
            this.txtCpuId.Name = "txtCpuId";
            this.txtCpuId.ReadOnly = true;
            this.txtCpuId.Size = new System.Drawing.Size(151, 21);
            this.txtCpuId.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "注册码：";
            // 
            // txtRegsit
            // 
            this.txtRegsit.Location = new System.Drawing.Point(119, 68);
            this.txtRegsit.Name = "txtRegsit";
            this.txtRegsit.Size = new System.Drawing.Size(151, 21);
            this.txtRegsit.TabIndex = 6;
            // 
            // lblRegist
            // 
            this.lblRegist.AutoSize = true;
            this.lblRegist.ForeColor = System.Drawing.Color.Blue;
            this.lblRegist.Location = new System.Drawing.Point(274, 70);
            this.lblRegist.Name = "lblRegist";
            this.lblRegist.Size = new System.Drawing.Size(41, 12);
            this.lblRegist.TabIndex = 7;
            this.lblRegist.Text = "已注册";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(71, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "未注册版的试用天数为100天";
            // 
            // btnRegist
            // 
            this.btnRegist.Location = new System.Drawing.Point(276, 69);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(42, 20);
            this.btnRegist.TabIndex = 9;
            this.btnRegist.Text = "注册";
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // chkHttp
            // 
            this.chkHttp.AutoSize = true;
            this.chkHttp.Location = new System.Drawing.Point(277, 18);
            this.chkHttp.Name = "chkHttp";
            this.chkHttp.Size = new System.Drawing.Size(72, 16);
            this.chkHttp.TabIndex = 10;
            this.chkHttp.Text = "http协议";
            this.chkHttp.UseVisualStyleBackColor = true;
            this.chkHttp.CheckedChanged += new System.EventHandler(this.chkHttp_CheckedChanged);
            // 
            // frmPortSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 158);
            this.Controls.Add(this.chkHttp);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRegist);
            this.Controls.Add(this.txtRegsit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCpuId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPortSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "相关设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPortSet_FormClosing);
            this.Load += new System.EventHandler(this.frmPortSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCpuId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegsit;
        private System.Windows.Forms.Label lblRegist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.CheckBox chkHttp;
    }
}