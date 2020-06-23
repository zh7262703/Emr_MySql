namespace TempertureEditor.Controls
{
    partial class frmRecSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.numD_X = new System.Windows.Forms.NumericUpDown();
            this.numD_Y = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numD_Width = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numD_Height = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPenType = new System.Windows.Forms.ComboBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.picPenShow = new System.Windows.Forms.PictureBox();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPenShow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始X";
            // 
            // numD_X
            // 
            this.numD_X.Location = new System.Drawing.Point(66, 35);
            this.numD_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_X.Name = "numD_X";
            this.numD_X.Size = new System.Drawing.Size(104, 21);
            this.numD_X.TabIndex = 1;
            // 
            // numD_Y
            // 
            this.numD_Y.Location = new System.Drawing.Point(66, 62);
            this.numD_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Y.Name = "numD_Y";
            this.numD_Y.Size = new System.Drawing.Size(104, 21);
            this.numD_Y.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "起始Y";
            // 
            // numD_Width
            // 
            this.numD_Width.Location = new System.Drawing.Point(66, 89);
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
            this.label3.Location = new System.Drawing.Point(25, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "宽度";
            // 
            // numD_Height
            // 
            this.numD_Height.Location = new System.Drawing.Point(66, 116);
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
            this.label4.Location = new System.Drawing.Point(25, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "高度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "画笔类型";
            // 
            // cboPenType
            // 
            this.cboPenType.FormattingEnabled = true;
            this.cboPenType.Location = new System.Drawing.Point(66, 142);
            this.cboPenType.Name = "cboPenType";
            this.cboPenType.Size = new System.Drawing.Size(72, 20);
            this.cboPenType.TabIndex = 9;
            this.cboPenType.SelectedIndexChanged += new System.EventHandler(this.cboPenType_SelectedIndexChanged);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(71, 168);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(99, 30);
            this.btnSure.TabIndex = 10;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // picPenShow
            // 
            this.picPenShow.BackColor = System.Drawing.Color.White;
            this.picPenShow.Location = new System.Drawing.Point(143, 139);
            this.picPenShow.Name = "picPenShow";
            this.picPenShow.Size = new System.Drawing.Size(85, 25);
            this.picPenShow.TabIndex = 13;
            this.picPenShow.TabStop = false;
            this.picPenShow.Paint += new System.Windows.Forms.PaintEventHandler(this.picPenShow_Paint);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(25, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 12);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "ID：";
            // 
            // frmRecSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 222);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.picPenShow);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.cboPenType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numD_Height);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numD_Width);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numD_Y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numD_X);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主区域设置";
            this.Load += new System.EventHandler(this.frmRecSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPenShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numD_X;
        private System.Windows.Forms.NumericUpDown numD_Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numD_Width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numD_Height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPenType;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.PictureBox picPenShow;
        private System.Windows.Forms.Label lblID;
    }
}