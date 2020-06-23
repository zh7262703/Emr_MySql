namespace TempertureEditor.Controls
{
    partial class frmMainSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numD_Width = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numD_Height = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Height)).BeginInit();
            this.SuspendLayout();
            // 
            // numD_Width
            // 
            this.numD_Width.Location = new System.Drawing.Point(82, 12);
            this.numD_Width.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Width.Name = "numD_Width";
            this.numD_Width.Size = new System.Drawing.Size(104, 21);
            this.numD_Width.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "宽度";
            // 
            // numD_Height
            // 
            this.numD_Height.Location = new System.Drawing.Point(82, 39);
            this.numD_Height.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Height.Name = "numD_Height";
            this.numD_Height.Size = new System.Drawing.Size(104, 21);
            this.numD_Height.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "高度";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(67, 79);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(99, 30);
            this.btnSure.TabIndex = 10;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // frmMainSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 131);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.numD_Height);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numD_Width);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主区域设置";
            this.Load += new System.EventHandler(this.frmMainSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numD_Width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numD_Height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSure;
    }
}