namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    partial class UcInout_Amount
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnOthers = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "lblName";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(89, 6);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 21);
            this.txtValue.TabIndex = 1;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(196, 11);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(17, 12);
            this.lblUnit.TabIndex = 2;
            this.lblUnit.Text = "ml";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(219, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOthers
            // 
            this.btnOthers.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOthers.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOthers.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOthers.Location = new System.Drawing.Point(268, 5);
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(20, 22);
            this.btnOthers.TabIndex = 7;
            this.btnOthers.Text = "＋";
            this.btnOthers.Visible = false;
            this.btnOthers.Click += new System.EventHandler(this.btnOthers_Click);
            // 
            // UcInout_Amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnOthers);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblName);
            this.Name = "UcInout_Amount";
            this.Size = new System.Drawing.Size(307, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnit;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.TextBox txtValue;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnOthers;
    }
}
