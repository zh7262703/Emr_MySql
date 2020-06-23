namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    partial class frmModifyProjectTitle
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
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtTitleName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.cboNurseDict = new System.Windows.Forms.ComboBox();
            this.btnInsertDataBase = new DevComponents.DotNetBar.ButtonX();
            this.rdoConstomTittle = new System.Windows.Forms.RadioButton();
            this.rdonurseDict = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(159, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTitleName
            // 
            // 
            // 
            // 
            this.txtTitleName.Border.Class = "TextBoxBorder";
            this.txtTitleName.Location = new System.Drawing.Point(92, 12);
            this.txtTitleName.Name = "txtTitleName";
            this.txtTitleName.Size = new System.Drawing.Size(137, 21);
            this.txtTitleName.TabIndex = 3;
            this.txtTitleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTitleName_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(78, 79);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboNurseDict
            // 
            this.cboNurseDict.FormattingEnabled = true;
            this.cboNurseDict.Location = new System.Drawing.Point(92, 41);
            this.cboNurseDict.Name = "cboNurseDict";
            this.cboNurseDict.Size = new System.Drawing.Size(137, 20);
            this.cboNurseDict.TabIndex = 8;
            // 
            // btnInsertDataBase
            // 
            this.btnInsertDataBase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsertDataBase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInsertDataBase.Location = new System.Drawing.Point(235, 12);
            this.btnInsertDataBase.Name = "btnInsertDataBase";
            this.btnInsertDataBase.Size = new System.Drawing.Size(72, 23);
            this.btnInsertDataBase.TabIndex = 9;
            this.btnInsertDataBase.Text = "加入基础库";
            this.btnInsertDataBase.Click += new System.EventHandler(this.btnInsertDataBase_Click);
            // 
            // rdoConstomTittle
            // 
            this.rdoConstomTittle.AutoSize = true;
            this.rdoConstomTittle.Checked = true;
            this.rdoConstomTittle.Location = new System.Drawing.Point(3, 12);
            this.rdoConstomTittle.Name = "rdoConstomTittle";
            this.rdoConstomTittle.Size = new System.Drawing.Size(83, 16);
            this.rdoConstomTittle.TabIndex = 10;
            this.rdoConstomTittle.TabStop = true;
            this.rdoConstomTittle.Text = "自定义项目";
            this.rdoConstomTittle.UseVisualStyleBackColor = true;
            this.rdoConstomTittle.CheckedChanged += new System.EventHandler(this.rdoConstomTittle_CheckedChanged);
            // 
            // rdonurseDict
            // 
            this.rdonurseDict.AutoSize = true;
            this.rdonurseDict.Location = new System.Drawing.Point(3, 42);
            this.rdonurseDict.Name = "rdonurseDict";
            this.rdonurseDict.Size = new System.Drawing.Size(83, 16);
            this.rdonurseDict.TabIndex = 11;
            this.rdonurseDict.Text = "已经有项目";
            this.rdonurseDict.UseVisualStyleBackColor = true;
            // 
            // frmModifyProjectTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 119);
            this.Controls.Add(this.rdonurseDict);
            this.Controls.Add(this.rdoConstomTittle);
            this.Controls.Add(this.btnInsertDataBase);
            this.Controls.Add(this.cboNurseDict);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTitleName);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyProjectTitle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义项目名称";
            this.Load += new System.EventHandler(this.frmModifyProjectTitle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTitleName;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.ComboBox cboNurseDict;
        private DevComponents.DotNetBar.ButtonX btnInsertDataBase;
        private System.Windows.Forms.RadioButton rdoConstomTittle;
        private System.Windows.Forms.RadioButton rdonurseDict;
    }
}