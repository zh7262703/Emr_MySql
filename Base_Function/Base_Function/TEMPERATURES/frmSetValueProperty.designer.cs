namespace Base_Function.TEMPERATURES
{
    partial class frmSetValueProperty
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
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.label_Width = new System.Windows.Forms.Label();
            this.lable_Height = new System.Windows.Forms.Label();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArea_name = new System.Windows.Forms.TextBox();
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(67, 13);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(71, 12);
            this.label_X.TabIndex = 0;
            this.label_X.Text = "起点位置X：";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(283, 13);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(71, 12);
            this.label_Y.TabIndex = 1;
            this.label_Y.Text = "起点位置Y：";
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(67, 45);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(65, 12);
            this.label_Width.TabIndex = 2;
            this.label_Width.Text = "区域高度：";
            // 
            // lable_Height
            // 
            this.lable_Height.AutoSize = true;
            this.lable_Height.Location = new System.Drawing.Point(283, 45);
            this.lable_Height.Name = "lable_Height";
            this.lable_Height.Size = new System.Drawing.Size(65, 12);
            this.lable_Height.TabIndex = 3;
            this.lable_Height.Text = "区域宽度：";
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(119, 162);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(86, 37);
            this.btnSure.TabIndex = 4;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(216, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 37);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "区域名称：";
            // 
            // txtArea_name
            // 
            this.txtArea_name.Location = new System.Drawing.Point(138, 79);
            this.txtArea_name.Name = "txtArea_name";
            this.txtArea_name.Size = new System.Drawing.Size(189, 21);
            this.txtArea_name.TabIndex = 7;
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.Location = new System.Drawing.Point(138, 106);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Size = new System.Drawing.Size(189, 21);
            this.txtOperatorName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "对应的操作：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(214, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "（对应的操作界面）";
            // 
            // frmSetValueProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 226);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOperatorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtArea_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.lable_Height);
            this.Controls.Add(this.label_Width);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_X);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetValueProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置操作属性";
            this.Load += new System.EventHandler(this.frmSetValueProperty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Label label_Width;
        private System.Windows.Forms.Label lable_Height;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArea_name;
        private System.Windows.Forms.TextBox txtOperatorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}