namespace TempertureEditor.Controls
{
    partial class frmPensSet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTname = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "效果显示";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 73);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTname);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtWidth);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnColor);
            this.groupBox2.Controls.Add(this.txtColor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblId);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 176);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "画笔设置";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 27);
            this.button1.TabIndex = 14;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(67, 96);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(118, 21);
            this.txtWidth.TabIndex = 13;
            this.txtWidth.Text = "1";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "大小：";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(191, 69);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(37, 19);
            this.btnColor.TabIndex = 10;
            this.btnColor.Text = "...";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.Color.White;
            this.txtColor.Location = new System.Drawing.Point(67, 69);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(118, 21);
            this.txtColor.TabIndex = 9;
            this.txtColor.Text = "0,0,0";
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "颜色：";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(25, 25);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(53, 12);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "画笔ID：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "名称：";
            // 
            // txtTname
            // 
            this.txtTname.Location = new System.Drawing.Point(67, 42);
            this.txtTname.Name = "txtTname";
            this.txtTname.Size = new System.Drawing.Size(118, 21);
            this.txtTname.TabIndex = 16;
            // 
            // frmPensSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 269);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPensSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "画笔设置";
            this.Load += new System.EventHandler(this.frmPensSet_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox txtTname;
        private System.Windows.Forms.Label label1;
    }
}