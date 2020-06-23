namespace Base_Function.BLL_DOCTOR
{
    partial class frmSurgery_Add
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
            this.txtSurgery_Select = new System.Windows.Forms.TextBox();
            this.chboxType = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(207, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入手术信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "拟施手术名称：";
            // 
            // txtSurgery_Select
            // 
            this.txtSurgery_Select.Location = new System.Drawing.Point(89, 38);
            this.txtSurgery_Select.Name = "txtSurgery_Select";
            this.txtSurgery_Select.Size = new System.Drawing.Size(199, 21);
            this.txtSurgery_Select.TabIndex = 2;
            this.txtSurgery_Select.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // chboxType
            // 
            this.chboxType.AutoSize = true;
            this.chboxType.Location = new System.Drawing.Point(313, 40);
            this.chboxType.Name = "chboxType";
            this.chboxType.Size = new System.Drawing.Size(72, 16);
            this.chboxType.TabIndex = 3;
            this.chboxType.Text = "特殊手术";
            this.chboxType.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(139, 85);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(508, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmSurgery_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 135);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chboxType);
            this.Controls.Add(this.txtSurgery_Select);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSurgery_Add";
            this.Text = "手术登记";
            this.Load += new System.EventHandler(this.frmSurgery_Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSurgery_Select;
        private System.Windows.Forms.CheckBox chboxType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}