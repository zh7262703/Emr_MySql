namespace TempertureEditor.Controls
{
    partial class frmLineSet
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
            this.label2 = new System.Windows.Forms.Label();
            this.numD_X1 = new System.Windows.Forms.NumericUpDown();
            this.numD_Y1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numD_Y2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numD_X2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPenType = new System.Windows.Forms.ComboBox();
            this.picPenShow = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numD_Times = new System.Windows.Forms.NumericUpDown();
            this.lblLineId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSpan = new System.Windows.Forms.TextBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDirctionType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPenShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Times)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始坐标 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "X1";
            // 
            // numD_X1
            // 
            this.numD_X1.Location = new System.Drawing.Point(122, 43);
            this.numD_X1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_X1.Name = "numD_X1";
            this.numD_X1.Size = new System.Drawing.Size(50, 21);
            this.numD_X1.TabIndex = 2;
            // 
            // numD_Y1
            // 
            this.numD_Y1.Location = new System.Drawing.Point(213, 43);
            this.numD_Y1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Y1.Name = "numD_Y1";
            this.numD_Y1.Size = new System.Drawing.Size(50, 21);
            this.numD_Y1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y1";
            // 
            // numD_Y2
            // 
            this.numD_Y2.Location = new System.Drawing.Point(213, 70);
            this.numD_Y2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Y2.Name = "numD_Y2";
            this.numD_Y2.Size = new System.Drawing.Size(50, 21);
            this.numD_Y2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y2";
            // 
            // numD_X2
            // 
            this.numD_X2.Location = new System.Drawing.Point(122, 70);
            this.numD_X2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_X2.Name = "numD_X2";
            this.numD_X2.Size = new System.Drawing.Size(50, 21);
            this.numD_X2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "X2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "结束坐标";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "画笔类型";
            // 
            // cboPenType
            // 
            this.cboPenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPenType.FormattingEnabled = true;
            this.cboPenType.Location = new System.Drawing.Point(122, 96);
            this.cboPenType.Name = "cboPenType";
            this.cboPenType.Size = new System.Drawing.Size(50, 20);
            this.cboPenType.TabIndex = 11;
            this.cboPenType.SelectedIndexChanged += new System.EventHandler(this.cboPenType_SelectedIndexChanged);
            // 
            // picPenShow
            // 
            this.picPenShow.BackColor = System.Drawing.Color.White;
            this.picPenShow.Location = new System.Drawing.Point(191, 97);
            this.picPenShow.Name = "picPenShow";
            this.picPenShow.Size = new System.Drawing.Size(116, 58);
            this.picPenShow.TabIndex = 12;
            this.picPenShow.TabStop = false;
            this.picPenShow.Click += new System.EventHandler(this.picPenShow_Click);
            this.picPenShow.Paint += new System.Windows.Forms.PaintEventHandler(this.picPenShow_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "展示频次";
            // 
            // numD_Times
            // 
            this.numD_Times.Location = new System.Drawing.Point(122, 166);
            this.numD_Times.Name = "numD_Times";
            this.numD_Times.Size = new System.Drawing.Size(50, 21);
            this.numD_Times.TabIndex = 14;
            // 
            // lblLineId
            // 
            this.lblLineId.AutoSize = true;
            this.lblLineId.Location = new System.Drawing.Point(27, 20);
            this.lblLineId.Name = "lblLineId";
            this.lblLineId.Size = new System.Drawing.Size(41, 12);
            this.lblLineId.TabIndex = 15;
            this.lblLineId.Text = "线的ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "间隔大小";
            // 
            // txtSpan
            // 
            this.txtSpan.Location = new System.Drawing.Point(239, 165);
            this.txtSpan.Name = "txtSpan";
            this.txtSpan.Size = new System.Drawing.Size(54, 21);
            this.txtSpan.TabIndex = 17;
            this.txtSpan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpan_KeyPress);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(154, 222);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(92, 30);
            this.btnSure.TabIndex = 18;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "方向";
            // 
            // cboDirctionType
            // 
            this.cboDirctionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDirctionType.FormattingEnabled = true;
            this.cboDirctionType.Items.AddRange(new object[] {
            "左",
            "右",
            "上",
            "下"});
            this.cboDirctionType.Location = new System.Drawing.Point(122, 193);
            this.cboDirctionType.Name = "cboDirctionType";
            this.cboDirctionType.Size = new System.Drawing.Size(50, 20);
            this.cboDirctionType.TabIndex = 20;
            // 
            // frmLineSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 264);
            this.Controls.Add(this.cboDirctionType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.txtSpan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblLineId);
            this.Controls.Add(this.numD_Times);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.picPenShow);
            this.Controls.Add(this.cboPenType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numD_Y2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numD_X2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numD_Y1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numD_X1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLineSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体温单-线";
            this.Load += new System.EventHandler(this.frmLineSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numD_X1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPenShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Times)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numD_X1;
        private System.Windows.Forms.NumericUpDown numD_Y1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numD_Y2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numD_X2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboPenType;
        private System.Windows.Forms.PictureBox picPenShow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numD_Times;
        private System.Windows.Forms.Label lblLineId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSpan;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDirctionType;
    }
}