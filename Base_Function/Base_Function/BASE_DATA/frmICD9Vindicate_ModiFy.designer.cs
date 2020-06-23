namespace Base_Function.BASE_DATA
{
    partial class frmICD9Vindicate_ModiFy
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
            this.label7 = new System.Windows.Forms.Label();
            this.txtfivecode = new System.Windows.Forms.TextBox();
            this.txtDaiMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.btnconfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.txtWbCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtspellCode = new System.Windows.Forms.TextBox();
            this.txtICD9name = new System.Windows.Forms.TextBox();
            this.txtICD9code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(-164, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "代码：";
            // 
            // txtfivecode
            // 
            this.txtfivecode.Location = new System.Drawing.Point(-119, 127);
            this.txtfivecode.Name = "txtfivecode";
            this.txtfivecode.ReadOnly = true;
            this.txtfivecode.Size = new System.Drawing.Size(100, 21);
            this.txtfivecode.TabIndex = 38;
            // 
            // txtDaiMa
            // 
            this.txtDaiMa.Location = new System.Drawing.Point(-119, 94);
            this.txtDaiMa.Name = "txtDaiMa";
            this.txtDaiMa.ReadOnly = true;
            this.txtDaiMa.Size = new System.Drawing.Size(100, 21);
            this.txtDaiMa.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(-176, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "五笔码：";
            // 
            // btncancel
            // 
            this.btncancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncancel.Location = new System.Drawing.Point(277, 103);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 44;
            this.btncancel.Text = "取 消";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnconfirm
            // 
            this.btnconfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnconfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnconfirm.Location = new System.Drawing.Point(196, 103);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(75, 23);
            this.btnconfirm.TabIndex = 43;
            this.btnconfirm.Text = "确 定";
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(115, 103);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 45;
            this.btnAdd.Text = "添 加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtWbCode
            // 
            this.txtWbCode.Location = new System.Drawing.Point(305, 49);
            this.txtWbCode.Name = "txtWbCode";
            this.txtWbCode.ReadOnly = true;
            this.txtWbCode.Size = new System.Drawing.Size(132, 21);
            this.txtWbCode.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(19, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "ICD9编码：";
            // 
            // txtspellCode
            // 
            this.txtspellCode.Location = new System.Drawing.Point(96, 49);
            this.txtspellCode.Name = "txtspellCode";
            this.txtspellCode.Size = new System.Drawing.Size(138, 21);
            this.txtspellCode.TabIndex = 51;
            // 
            // txtICD9name
            // 
            this.txtICD9name.Location = new System.Drawing.Point(305, 6);
            this.txtICD9name.Name = "txtICD9name";
            this.txtICD9name.Size = new System.Drawing.Size(132, 21);
            this.txtICD9name.TabIndex = 0;
            this.txtICD9name.TextChanged += new System.EventHandler(this.txtICD9name_TextChanged);
            // 
            // txtICD9code
            // 
            this.txtICD9code.BackColor = System.Drawing.SystemColors.Control;
            this.txtICD9code.Enabled = false;
            this.txtICD9code.Location = new System.Drawing.Point(96, 6);
            this.txtICD9code.Name = "txtICD9code";
            this.txtICD9code.Size = new System.Drawing.Size(138, 21);
            this.txtICD9code.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(246, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "五笔码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(252, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "名 称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(19, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "拼音码：";
            // 
            // frmICD9Vindicate_ModiFy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 152);
            this.ControlBox = false;
            this.Controls.Add(this.txtWbCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtspellCode);
            this.Controls.Add(this.txtICD9name);
            this.Controls.Add(this.txtICD9code);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtfivecode);
            this.Controls.Add(this.txtDaiMa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmICD9Vindicate_ModiFy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义手术维护";
            this.Load += new System.EventHandler(this.frmICD10Vindicate_ModiFy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtfivecode;
        private System.Windows.Forms.TextBox txtDaiMa;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btncancel;
        private DevComponents.DotNetBar.ButtonX btnconfirm;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.TextBox txtWbCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtspellCode;
        private System.Windows.Forms.TextBox txtICD9name;
        private System.Windows.Forms.TextBox txtICD9code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}