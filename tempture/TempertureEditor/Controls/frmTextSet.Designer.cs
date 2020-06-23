namespace TempertureEditor.Controls
{
    partial class frmTextSet
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
            this.lblId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTDirection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numD_X = new System.Windows.Forms.NumericUpDown();
            this.numD_Y = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFontType = new System.Windows.Forms.ComboBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.picFontShow = new System.Windows.Forms.PictureBox();
            this.txtSpan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numD_Times = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFontShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Times)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(23, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(29, 12);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "内容：";
            // 
            // txtVal
            // 
            this.txtVal.Location = new System.Drawing.Point(64, 39);
            this.txtVal.Multiline = true;
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(239, 77);
            this.txtVal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "显示方式：";
            // 
            // cboTDirection
            // 
            this.cboTDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTDirection.FormattingEnabled = true;
            this.cboTDirection.Items.AddRange(new object[] {
            "横",
            "竖"});
            this.cboTDirection.Location = new System.Drawing.Point(64, 122);
            this.cboTDirection.Name = "cboTDirection";
            this.cboTDirection.Size = new System.Drawing.Size(61, 20);
            this.cboTDirection.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "X：";
            // 
            // numD_X
            // 
            this.numD_X.Location = new System.Drawing.Point(152, 123);
            this.numD_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_X.Name = "numD_X";
            this.numD_X.Size = new System.Drawing.Size(62, 21);
            this.numD_X.TabIndex = 6;
            // 
            // numD_Y
            // 
            this.numD_Y.Location = new System.Drawing.Point(249, 123);
            this.numD_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Y.Name = "numD_Y";
            this.numD_Y.Size = new System.Drawing.Size(62, 21);
            this.numD_Y.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "字体：";
            // 
            // cboFontType
            // 
            this.cboFontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontType.FormattingEnabled = true;
            this.cboFontType.Location = new System.Drawing.Point(65, 172);
            this.cboFontType.Name = "cboFontType";
            this.cboFontType.Size = new System.Drawing.Size(59, 20);
            this.cboFontType.TabIndex = 10;
            this.cboFontType.SelectedIndexChanged += new System.EventHandler(this.cboFontType_SelectedIndexChanged);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(102, 219);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(112, 30);
            this.btnSure.TabIndex = 11;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.button1_Click);
            // 
            // picFontShow
            // 
            this.picFontShow.BackColor = System.Drawing.Color.White;
            this.picFontShow.Location = new System.Drawing.Point(133, 174);
            this.picFontShow.Name = "picFontShow";
            this.picFontShow.Size = new System.Drawing.Size(169, 38);
            this.picFontShow.TabIndex = 12;
            this.picFontShow.TabStop = false;
            this.picFontShow.Paint += new System.Windows.Forms.PaintEventHandler(this.picFontShow_Paint);
            // 
            // txtSpan
            // 
            this.txtSpan.Location = new System.Drawing.Point(160, 147);
            this.txtSpan.Name = "txtSpan";
            this.txtSpan.Size = new System.Drawing.Size(54, 21);
            this.txtSpan.TabIndex = 21;
            this.txtSpan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpan_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "间隔：";
            // 
            // numD_Times
            // 
            this.numD_Times.Location = new System.Drawing.Point(65, 146);
            this.numD_Times.Name = "numD_Times";
            this.numD_Times.Size = new System.Drawing.Size(50, 21);
            this.numD_Times.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "展示频次：";
            // 
            // cboDirection
            // 
            this.cboDirection.AutoCompleteCustomSource.AddRange(new string[] {
            "左",
            "右",
            "上",
            "下"});
            this.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDirection.FormattingEnabled = true;
            this.cboDirection.Items.AddRange(new object[] {
            "左",
            "右",
            "上",
            "下"});
            this.cboDirection.Location = new System.Drawing.Point(249, 147);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.Size = new System.Drawing.Size(62, 20);
            this.cboDirection.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "方向：";
            // 
            // frmTextSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 272);
            this.Controls.Add(this.cboDirection);
            this.Controls.Add(this.txtSpan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numD_Times);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.picFontShow);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.cboFontType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numD_Y);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numD_X);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTDirection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTextSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体温单-文字设置";
            this.Load += new System.EventHandler(this.frmTextSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFontShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Times)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTDirection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numD_X;
        private System.Windows.Forms.NumericUpDown numD_Y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFontType;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.PictureBox picFontShow;
        private System.Windows.Forms.TextBox txtSpan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numD_Times;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDirection;
        private System.Windows.Forms.Label label6;
    }
}