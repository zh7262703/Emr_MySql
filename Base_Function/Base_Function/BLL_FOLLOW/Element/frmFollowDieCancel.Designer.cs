namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmFollowDieCancel
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
            this.rbtnFollowYes = new System.Windows.Forms.RadioButton();
            this.rbtnFollowNo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFollowInfo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbCancelReason = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.lbShema = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnFollowYes
            // 
            this.rbtnFollowYes.AutoSize = true;
            this.rbtnFollowYes.Checked = true;
            this.rbtnFollowYes.Location = new System.Drawing.Point(7, 13);
            this.rbtnFollowYes.Name = "rbtnFollowYes";
            this.rbtnFollowYes.Size = new System.Drawing.Size(47, 16);
            this.rbtnFollowYes.TabIndex = 0;
            this.rbtnFollowYes.TabStop = true;
            this.rbtnFollowYes.Text = "随访";
            this.rbtnFollowYes.UseVisualStyleBackColor = true;
            this.rbtnFollowYes.CheckedChanged += new System.EventHandler(this.rbtnFollowYes_CheckedChanged);
            // 
            // rbtnFollowNo
            // 
            this.rbtnFollowNo.AutoSize = true;
            this.rbtnFollowNo.Location = new System.Drawing.Point(7, 94);
            this.rbtnFollowNo.Name = "rbtnFollowNo";
            this.rbtnFollowNo.Size = new System.Drawing.Size(59, 16);
            this.rbtnFollowNo.TabIndex = 1;
            this.rbtnFollowNo.TabStop = true;
            this.rbtnFollowNo.Text = "不随访";
            this.rbtnFollowNo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnFollowYes);
            this.panel1.Controls.Add(this.rbtnFollowNo);
            this.panel1.Location = new System.Drawing.Point(25, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 143);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "随访方案:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "不随访原因:";
            // 
            // cmbFollowInfo
            // 
            this.cmbFollowInfo.DisplayMember = "Text";
            this.cmbFollowInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFollowInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollowInfo.FormattingEnabled = true;
            this.cmbFollowInfo.ItemHeight = 15;
            this.cmbFollowInfo.Location = new System.Drawing.Point(258, 12);
            this.cmbFollowInfo.Name = "cmbFollowInfo";
            this.cmbFollowInfo.Size = new System.Drawing.Size(160, 21);
            this.cmbFollowInfo.TabIndex = 5;
            // 
            // cmbCancelReason
            // 
            this.cmbCancelReason.DisplayMember = "Text";
            this.cmbCancelReason.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCancelReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCancelReason.FormattingEnabled = true;
            this.cmbCancelReason.ItemHeight = 15;
            this.cmbCancelReason.Location = new System.Drawing.Point(258, 132);
            this.cmbCancelReason.Name = "cmbCancelReason";
            this.cmbCancelReason.Size = new System.Drawing.Size(160, 21);
            this.cmbCancelReason.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(136, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(296, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbShema
            // 
            this.lbShema.AutoSize = true;
            this.lbShema.Location = new System.Drawing.Point(258, 59);
            this.lbShema.Name = "lbShema";
            this.lbShema.Size = new System.Drawing.Size(41, 12);
            this.lbShema.TabIndex = 9;
            this.lbShema.Text = "label3";
            // 
            // frmFollowDieCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 262);
            this.Controls.Add(this.lbShema);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbCancelReason);
            this.Controls.Add(this.cmbFollowInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "frmFollowDieCancel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnFollowYes;
        private System.Windows.Forms.RadioButton rbtnFollowNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbFollowInfo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCancelReason;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.Label lbShema;
    }
}