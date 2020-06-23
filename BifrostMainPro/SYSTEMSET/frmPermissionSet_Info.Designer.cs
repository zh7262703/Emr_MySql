namespace LeadronTest.SYSTEMSET
{
    partial class frmPermissionSet_Info
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
            this.cboKindMenu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMenuCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDllName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOpenImageFile = new System.Windows.Forms.Button();
            this.txtInocPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.txtFunctinName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOpenFunctionFile = new System.Windows.Forms.Button();
            this.txtDllpath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtButtonCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtButtonName = new System.Windows.Forms.TextBox();
            this.cboKindButton = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboKindMenu
            // 
            this.cboKindMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKindMenu.Enabled = false;
            this.cboKindMenu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboKindMenu.FormattingEnabled = true;
            this.cboKindMenu.Items.AddRange(new object[] {
            "菜单",
            "按钮"});
            this.cboKindMenu.Location = new System.Drawing.Point(100, 67);
            this.cboKindMenu.Name = "cboKindMenu";
            this.cboKindMenu.Size = new System.Drawing.Size(144, 20);
            this.cboKindMenu.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "权限种类：";
            // 
            // txtMenuName
            // 
            this.txtMenuName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMenuName.Location = new System.Drawing.Point(100, 37);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(144, 21);
            this.txtMenuName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(29, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "权限名称：";
            // 
            // txtMenuCode
            // 
            this.txtMenuCode.Enabled = false;
            this.txtMenuCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMenuCode.Location = new System.Drawing.Point(100, 6);
            this.txtMenuCode.Name = "txtMenuCode";
            this.txtMenuCode.Size = new System.Drawing.Size(144, 21);
            this.txtMenuCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "权限码：";
            // 
            // btnCancel
            // 
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(333, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSure.Location = new System.Drawing.Point(254, 315);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(73, 23);
            this.btnSure.TabIndex = 17;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDllName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtVersion);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnOpenImageFile);
            this.groupBox1.Controls.Add(this.txtInocPath);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.picIcon);
            this.groupBox1.Controls.Add(this.txtFunctinName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnOpenFunctionFile);
            this.groupBox1.Controls.Add(this.txtDllpath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 179);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "菜单功能设置";
            // 
            // txtDllName
            // 
            this.txtDllName.BackColor = System.Drawing.SystemColors.Window;
            this.txtDllName.Location = new System.Drawing.Point(289, 47);
            this.txtDllName.Name = "txtDllName";
            this.txtDllName.Size = new System.Drawing.Size(92, 21);
            this.txtDllName.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(230, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "类库名称：";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(85, 144);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(144, 21);
            this.txtVersion.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "版本号：";
            // 
            // btnOpenImageFile
            // 
            this.btnOpenImageFile.Location = new System.Drawing.Point(340, 116);
            this.btnOpenImageFile.Name = "btnOpenImageFile";
            this.btnOpenImageFile.Size = new System.Drawing.Size(41, 20);
            this.btnOpenImageFile.TabIndex = 8;
            this.btnOpenImageFile.Text = "...";
            this.btnOpenImageFile.UseVisualStyleBackColor = true;
            this.btnOpenImageFile.Click += new System.EventHandler(this.btnOpenImageFile_Click);
            // 
            // txtInocPath
            // 
            this.txtInocPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtInocPath.Location = new System.Drawing.Point(85, 117);
            this.txtInocPath.Name = "txtInocPath";
            this.txtInocPath.Size = new System.Drawing.Size(249, 21);
            this.txtInocPath.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "图标：";
            // 
            // picIcon
            // 
            this.picIcon.Image = global::LeadronTest.Properties.Resources.BESHEX_1;
            this.picIcon.Location = new System.Drawing.Point(85, 74);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(38, 37);
            this.picIcon.TabIndex = 5;
            this.picIcon.TabStop = false;
            // 
            // txtFunctinName
            // 
            this.txtFunctinName.Location = new System.Drawing.Point(85, 47);
            this.txtFunctinName.Name = "txtFunctinName";
            this.txtFunctinName.Size = new System.Drawing.Size(144, 21);
            this.txtFunctinName.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "函数名称：";
            // 
            // btnOpenFunctionFile
            // 
            this.btnOpenFunctionFile.Location = new System.Drawing.Point(340, 19);
            this.btnOpenFunctionFile.Name = "btnOpenFunctionFile";
            this.btnOpenFunctionFile.Size = new System.Drawing.Size(41, 20);
            this.btnOpenFunctionFile.TabIndex = 2;
            this.btnOpenFunctionFile.Text = "...";
            this.btnOpenFunctionFile.UseVisualStyleBackColor = true;
            this.btnOpenFunctionFile.Click += new System.EventHandler(this.btnOpenFunctionFile_Click);
            // 
            // txtDllpath
            // 
            this.txtDllpath.BackColor = System.Drawing.SystemColors.Window;
            this.txtDllpath.Location = new System.Drawing.Point(85, 20);
            this.txtDllpath.Name = "txtDllpath";
            this.txtDllpath.Size = new System.Drawing.Size(249, 21);
            this.txtDllpath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "功能类库：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 309);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMenuCode);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMenuName);
            this.tabPage1.Controls.Add(this.cboKindMenu);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "菜单";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtButtonCode);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtButtonName);
            this.tabPage2.Controls.Add(this.cboKindButton);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(425, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "按钮";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtButtonCode
            // 
            this.txtButtonCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtButtonCode.Location = new System.Drawing.Point(115, 27);
            this.txtButtonCode.Name = "txtButtonCode";
            this.txtButtonCode.Size = new System.Drawing.Size(144, 21);
            this.txtButtonCode.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(56, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "权限码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(44, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "权限名称：";
            // 
            // txtButtonName
            // 
            this.txtButtonName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtButtonName.Location = new System.Drawing.Point(115, 58);
            this.txtButtonName.Name = "txtButtonName";
            this.txtButtonName.Size = new System.Drawing.Size(144, 21);
            this.txtButtonName.TabIndex = 20;
            // 
            // cboKindButton
            // 
            this.cboKindButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKindButton.Enabled = false;
            this.cboKindButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboKindButton.FormattingEnabled = true;
            this.cboKindButton.Items.AddRange(new object[] {
            "菜单",
            "按钮"});
            this.cboKindButton.Location = new System.Drawing.Point(115, 88);
            this.cboKindButton.Name = "cboKindButton";
            this.cboKindButton.Size = new System.Drawing.Size(144, 20);
            this.cboKindButton.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(44, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "权限种类：";
            // 
            // frmPermissionSet_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 355);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermissionSet_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单或按钮设置";
            this.Load += new System.EventHandler(this.frmPermissionSet_Info_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKindMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMenuCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenFunctionFile;
        private System.Windows.Forms.TextBox txtDllpath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFunctinName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtButtonCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtButtonName;
        private System.Windows.Forms.ComboBox cboKindButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOpenImageFile;
        private System.Windows.Forms.TextBox txtInocPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtDllName;
        private System.Windows.Forms.Label label11;
    }
}