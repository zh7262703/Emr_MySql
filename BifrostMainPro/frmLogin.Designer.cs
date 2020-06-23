namespace BifrostMainPro
{
    partial class frmLogin
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
                if (isUpdate)
                {
                    System.Diagnostics.Process proc = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + "\\EmrUpdate.exe");
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtAccount = new Bifrost.TextBoxEx();
            this.txtPassword = new Bifrost.TextBoxEx();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAccountType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnXSure = new DevComponents.DotNetBar.ButtonX();
            this.btnXCancel = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccount
            // 
            this.txtAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccount.BackGroundText = "用户名";
            this.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccount.Font = new System.Drawing.Font("宋体", 9F);
            this.txtAccount.Location = new System.Drawing.Point(630, 200);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(142, 21);
            this.txtAccount.TabIndex = 3;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            this.txtAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccount_KeyDown);
            this.txtAccount.Leave += new System.EventHandler(this.txtAccount_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackGroundText = "口令";
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("宋体", 9F);
            this.txtPassword.Location = new System.Drawing.Point(630, 227);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(142, 21);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user.ico");
            this.imageList1.Images.SetKeyName(1, "DNA2WholeLifeSafe.ico");
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(458, 75);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(18, 21);
            this.checkBoxX1.TabIndex = 14;
            this.checkBoxX1.Text = "checkBoxX1";
            this.checkBoxX1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(236, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "类  型";
            this.label1.Visible = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVersion.Location = new System.Drawing.Point(628, 308);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(41, 12);
            this.lblVersion.TabIndex = 17;
            this.lblVersion.Text = "label2";
            this.lblVersion.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblVersion_DragEnter);
            this.lblVersion.DragLeave += new System.EventHandler(this.lblVersion_DragLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(768, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "手动更新";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // cboAccountType
            // 
            this.cboAccountType.DisplayMember = "Text";
            this.cboAccountType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.ForeColor = System.Drawing.Color.Black;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.ItemHeight = 15;
            this.cboAccountType.Items.AddRange(new object[] {
            this.comboItem3,
            this.comboItem4});
            this.cboAccountType.Location = new System.Drawing.Point(292, 79);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(143, 21);
            this.cboAccountType.TabIndex = 16;
            this.cboAccountType.Visible = false;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "一般";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "临时";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "临时";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "一般";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(917, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(978, 481);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // btnXSure
            // 
            this.btnXSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXSure.BackColor = System.Drawing.Color.White;
            this.btnXSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXSure.Location = new System.Drawing.Point(630, 259);
            this.btnXSure.Name = "btnXSure";
            this.btnXSure.Size = new System.Drawing.Size(69, 30);
            this.btnXSure.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXSure.TabIndex = 25;
            this.btnXSure.Text = "登录";
            this.btnXSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnXCancel
            // 
            this.btnXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXCancel.BackColor = System.Drawing.Color.White;
            this.btnXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXCancel.Location = new System.Drawing.Point(705, 259);
            this.btnXCancel.Name = "btnXCancel";
            this.btnXCancel.Size = new System.Drawing.Size(67, 30);
            this.btnXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXCancel.TabIndex = 26;
            this.btnXCancel.Text = "取消";
            this.btnXCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 481);
            this.Controls.Add(this.btnXCancel);
            this.Controls.Add(this.btnXSure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboAccountType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bifrost.TextBoxEx txtAccount;
        private Bifrost.TextBoxEx txtPassword;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboAccountType;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.ButtonX btnXSure;
        private DevComponents.DotNetBar.ButtonX btnXCancel;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}