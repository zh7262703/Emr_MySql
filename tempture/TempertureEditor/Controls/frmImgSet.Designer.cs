namespace TempertureEditor.Controls
{
    partial class frmImgSet
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImgPath = new System.Windows.Forms.TextBox();
            this.btnPicChoose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numD_x1 = new System.Windows.Forms.NumericUpDown();
            this.numD_y1 = new System.Windows.Forms.NumericUpDown();
            this.numD_Hight = new System.Windows.Forms.NumericUpDown();
            this.numD_Width = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numD_x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_y1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Hight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片";
            // 
            // txtImgPath
            // 
            this.txtImgPath.BackColor = System.Drawing.Color.White;
            this.txtImgPath.Location = new System.Drawing.Point(47, 19);
            this.txtImgPath.Name = "txtImgPath";
            this.txtImgPath.ReadOnly = true;
            this.txtImgPath.Size = new System.Drawing.Size(225, 21);
            this.txtImgPath.TabIndex = 1;
            // 
            // btnPicChoose
            // 
            this.btnPicChoose.Location = new System.Drawing.Point(278, 20);
            this.btnPicChoose.Name = "btnPicChoose";
            this.btnPicChoose.Size = new System.Drawing.Size(37, 20);
            this.btnPicChoose.TabIndex = 2;
            this.btnPicChoose.Text = "...";
            this.btnPicChoose.UseVisualStyleBackColor = true;
            this.btnPicChoose.Click += new System.EventHandler(this.btnPicChoose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y";
            // 
            // numD_x1
            // 
            this.numD_x1.Location = new System.Drawing.Point(35, 53);
            this.numD_x1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_x1.Name = "numD_x1";
            this.numD_x1.Size = new System.Drawing.Size(59, 21);
            this.numD_x1.TabIndex = 5;
            // 
            // numD_y1
            // 
            this.numD_y1.Location = new System.Drawing.Point(129, 53);
            this.numD_y1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_y1.Name = "numD_y1";
            this.numD_y1.Size = new System.Drawing.Size(59, 21);
            this.numD_y1.TabIndex = 6;
            // 
            // numD_Hight
            // 
            this.numD_Hight.Location = new System.Drawing.Point(129, 80);
            this.numD_Hight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Hight.Name = "numD_Hight";
            this.numD_Hight.Size = new System.Drawing.Size(59, 21);
            this.numD_Hight.TabIndex = 10;
            this.numD_Hight.ValueChanged += new System.EventHandler(this.numD_Hight_ValueChanged);
            // 
            // numD_Width
            // 
            this.numD_Width.Location = new System.Drawing.Point(35, 80);
            this.numD_Width.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Width.Name = "numD_Width";
            this.numD_Width.Size = new System.Drawing.Size(59, 21);
            this.numD_Width.TabIndex = 9;
            this.numD_Width.ValueChanged += new System.EventHandler(this.numD_Width_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "高";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "宽";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 142);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片显示";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 122);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(414, 116);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(176, 261);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(102, 29);
            this.btnSure.TabIndex = 12;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // frmImgSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 313);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numD_Hight);
            this.Controls.Add(this.numD_Width);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numD_y1);
            this.Controls.Add(this.numD_x1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPicChoose);
            this.Controls.Add(this.txtImgPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImgSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片设置";
            this.Load += new System.EventHandler(this.frmImgSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numD_x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_y1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Hight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImgPath;
        private System.Windows.Forms.Button btnPicChoose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numD_x1;
        private System.Windows.Forms.NumericUpDown numD_y1;
        private System.Windows.Forms.NumericUpDown numD_Hight;
        private System.Windows.Forms.NumericUpDown numD_Width;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Panel panel1;
    }
}