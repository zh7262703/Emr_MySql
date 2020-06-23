namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    partial class frmFormula
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUpL = new System.Windows.Forms.TextBox();
            this.txtUpR = new System.Windows.Forms.TextBox();
            this.txtDownL = new System.Windows.Forms.TextBox();
            this.txtDownR = new System.Windows.Forms.TextBox();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.radioButton_Formula = new System.Windows.Forms.RadioButton();
            this.radioButton_Normal = new System.Windows.Forms.RadioButton();
            this.txtNormalVal = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(2, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 2);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(104, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 76);
            this.panel2.TabIndex = 1;
            // 
            // txtUpL
            // 
            this.txtUpL.Location = new System.Drawing.Point(4, 13);
            this.txtUpL.Name = "txtUpL";
            this.txtUpL.Size = new System.Drawing.Size(94, 21);
            this.txtUpL.TabIndex = 2;
            // 
            // txtUpR
            // 
            this.txtUpR.Location = new System.Drawing.Point(112, 13);
            this.txtUpR.Name = "txtUpR";
            this.txtUpR.Size = new System.Drawing.Size(94, 21);
            this.txtUpR.TabIndex = 3;
            // 
            // txtDownL
            // 
            this.txtDownL.Location = new System.Drawing.Point(4, 48);
            this.txtDownL.Name = "txtDownL";
            this.txtDownL.Size = new System.Drawing.Size(94, 21);
            this.txtDownL.TabIndex = 4;
            // 
            // txtDownR
            // 
            this.txtDownR.Location = new System.Drawing.Point(112, 48);
            this.txtDownR.Name = "txtDownR";
            this.txtDownR.Size = new System.Drawing.Size(94, 21);
            this.txtDownR.TabIndex = 5;
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(69, 176);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(72, 26);
            this.btnSure.TabIndex = 6;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(147, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radioButton_Formula
            // 
            this.radioButton_Formula.AutoSize = true;
            this.radioButton_Formula.Location = new System.Drawing.Point(12, 12);
            this.radioButton_Formula.Name = "radioButton_Formula";
            this.radioButton_Formula.Size = new System.Drawing.Size(59, 16);
            this.radioButton_Formula.TabIndex = 8;
            this.radioButton_Formula.Text = "多胞胎";
            this.radioButton_Formula.UseVisualStyleBackColor = true;
            // 
            // radioButton_Normal
            // 
            this.radioButton_Normal.AutoSize = true;
            this.radioButton_Normal.Checked = true;
            this.radioButton_Normal.Location = new System.Drawing.Point(12, 113);
            this.radioButton_Normal.Name = "radioButton_Normal";
            this.radioButton_Normal.Size = new System.Drawing.Size(59, 16);
            this.radioButton_Normal.TabIndex = 9;
            this.radioButton_Normal.TabStop = true;
            this.radioButton_Normal.Text = "单胞胎";
            this.radioButton_Normal.UseVisualStyleBackColor = true;
            // 
            // txtNormalVal
            // 
            this.txtNormalVal.Location = new System.Drawing.Point(38, 139);
            this.txtNormalVal.Name = "txtNormalVal";
            this.txtNormalVal.Size = new System.Drawing.Size(103, 21);
            this.txtNormalVal.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.txtUpL);
            this.panel3.Controls.Add(this.txtUpR);
            this.panel3.Controls.Add(this.txtDownL);
            this.panel3.Controls.Add(this.txtDownR);
            this.panel3.Location = new System.Drawing.Point(38, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 79);
            this.panel3.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(161, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 40);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // frmFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 219);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtNormalVal);
            this.Controls.Add(this.radioButton_Normal);
            this.Controls.Add(this.radioButton_Formula);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "胎心音";
            this.Load += new System.EventHandler(this.frmFormula_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUpL;
        private System.Windows.Forms.TextBox txtUpR;
        private System.Windows.Forms.TextBox txtDownL;
        private System.Windows.Forms.TextBox txtDownR;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.RadioButton radioButton_Formula;
        private System.Windows.Forms.RadioButton radioButton_Normal;
        private System.Windows.Forms.TextBox txtNormalVal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}