namespace Base_Function.BLL_MANAGEMENT
{
    partial class frmNotice
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtPATIENT_NAME = new System.Windows.Forms.TextBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtTITLE = new System.Windows.Forms.TextBox();
            this.txtCONTENT = new System.Windows.Forms.TextBox();
            this.txtOPERATOR_USER = new System.Windows.Forms.TextBox();
            this.dtpIN_TIME = new System.Windows.Forms.DateTimePicker();
            this.dtpADD_TIME = new System.Windows.Forms.DateTimePicker();
            this.chkRECEIVE_USER = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "患者姓名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "入院时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "患者ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "接收人:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "标    题:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "内    容:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "发布时间:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "发布人:";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(249, 142);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(330, 142);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "提交";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(411, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPATIENT_NAME
            // 
            this.txtPATIENT_NAME.Enabled = false;
            this.txtPATIENT_NAME.Location = new System.Drawing.Point(83, 5);
            this.txtPATIENT_NAME.Name = "txtPATIENT_NAME";
            this.txtPATIENT_NAME.Size = new System.Drawing.Size(100, 21);
            this.txtPATIENT_NAME.TabIndex = 11;
            // 
            // txtPID
            // 
            this.txtPID.Enabled = false;
            this.txtPID.Location = new System.Drawing.Point(459, 5);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(100, 21);
            this.txtPID.TabIndex = 13;
            // 
            // txtTITLE
            // 
            this.txtTITLE.Location = new System.Drawing.Point(83, 34);
            this.txtTITLE.Name = "txtTITLE";
            this.txtTITLE.Size = new System.Drawing.Size(535, 21);
            this.txtTITLE.TabIndex = 15;
            // 
            // txtCONTENT
            // 
            this.txtCONTENT.Location = new System.Drawing.Point(83, 63);
            this.txtCONTENT.Multiline = true;
            this.txtCONTENT.Name = "txtCONTENT";
            this.txtCONTENT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCONTENT.Size = new System.Drawing.Size(535, 42);
            this.txtCONTENT.TabIndex = 16;
            // 
            // txtOPERATOR_USER
            // 
            this.txtOPERATOR_USER.Location = new System.Drawing.Point(292, 113);
            this.txtOPERATOR_USER.Name = "txtOPERATOR_USER";
            this.txtOPERATOR_USER.Size = new System.Drawing.Size(100, 21);
            this.txtOPERATOR_USER.TabIndex = 17;
            // 
            // dtpIN_TIME
            // 
            this.dtpIN_TIME.Enabled = false;
            this.dtpIN_TIME.Location = new System.Drawing.Point(266, 5);
            this.dtpIN_TIME.Name = "dtpIN_TIME";
            this.dtpIN_TIME.Size = new System.Drawing.Size(122, 21);
            this.dtpIN_TIME.TabIndex = 18;
            // 
            // dtpADD_TIME
            // 
            this.dtpADD_TIME.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpADD_TIME.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpADD_TIME.Location = new System.Drawing.Point(83, 113);
            this.dtpADD_TIME.Name = "dtpADD_TIME";
            this.dtpADD_TIME.ShowUpDown = true;
            this.dtpADD_TIME.Size = new System.Drawing.Size(127, 21);
            this.dtpADD_TIME.TabIndex = 19;
            // 
            // chkRECEIVE_USER
            // 
            this.chkRECEIVE_USER.FormattingEnabled = true;
            this.chkRECEIVE_USER.Location = new System.Drawing.Point(629, 5);
            this.chkRECEIVE_USER.Name = "chkRECEIVE_USER";
            this.chkRECEIVE_USER.ScrollAlwaysVisible = true;
            this.chkRECEIVE_USER.Size = new System.Drawing.Size(120, 100);
            this.chkRECEIVE_USER.TabIndex = 21;
            // 
            // frmNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 171);
            this.Controls.Add(this.chkRECEIVE_USER);
            this.Controls.Add(this.dtpADD_TIME);
            this.Controls.Add(this.dtpIN_TIME);
            this.Controls.Add(this.txtOPERATOR_USER);
            this.Controls.Add(this.txtCONTENT);
            this.Controls.Add(this.txtTITLE);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.txtPATIENT_NAME);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息提醒";
            this.Load += new System.EventHandler(this.frmNotice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.TextBox txtPATIENT_NAME;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.TextBox txtTITLE;
        private System.Windows.Forms.TextBox txtCONTENT;
        private System.Windows.Forms.TextBox txtOPERATOR_USER;
        private System.Windows.Forms.DateTimePicker dtpIN_TIME;
        private System.Windows.Forms.DateTimePicker dtpADD_TIME;
        private System.Windows.Forms.CheckedListBox chkRECEIVE_USER;
    }
}