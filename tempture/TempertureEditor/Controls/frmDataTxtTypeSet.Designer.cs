namespace TempertureEditor.Controls
{
    partial class frmDataTxtTypeSet
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
            this.numD_Y = new System.Windows.Forms.NumericUpDown();
            this.numD_X = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numD_Height = new System.Windows.Forms.NumericUpDown();
            this.numD_Width = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cboShowType = new System.Windows.Forms.ComboBox();
            this.cboFontType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboAlign = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cboTDirection = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).BeginInit();
            this.SuspendLayout();
            // 
            // numD_Y
            // 
            this.numD_Y.Location = new System.Drawing.Point(106, 81);
            this.numD_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Y.Name = "numD_Y";
            this.numD_Y.Size = new System.Drawing.Size(58, 21);
            this.numD_Y.TabIndex = 11;
            // 
            // numD_X
            // 
            this.numD_X.Location = new System.Drawing.Point(106, 54);
            this.numD_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_X.Name = "numD_X";
            this.numD_X.Size = new System.Drawing.Size(58, 21);
            this.numD_X.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "坐标Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "坐标X";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(149, 21);
            this.txtName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "宽";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "高";
            // 
            // numD_Height
            // 
            this.numD_Height.Location = new System.Drawing.Point(197, 81);
            this.numD_Height.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Height.Name = "numD_Height";
            this.numD_Height.Size = new System.Drawing.Size(58, 21);
            this.numD_Height.TabIndex = 15;
            // 
            // numD_Width
            // 
            this.numD_Width.Location = new System.Drawing.Point(197, 54);
            this.numD_Width.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numD_Width.Name = "numD_Width";
            this.numD_Width.Size = new System.Drawing.Size(58, 21);
            this.numD_Width.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "类型";
            // 
            // cboShowType
            // 
            this.cboShowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShowType.FormattingEnabled = true;
            this.cboShowType.Items.AddRange(new object[] {
            "",
            "上下",
            "下上"});
            this.cboShowType.Location = new System.Drawing.Point(106, 108);
            this.cboShowType.Name = "cboShowType";
            this.cboShowType.Size = new System.Drawing.Size(103, 20);
            this.cboShowType.TabIndex = 17;
            // 
            // cboFontType
            // 
            this.cboFontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontType.FormattingEnabled = true;
            this.cboFontType.Location = new System.Drawing.Point(106, 133);
            this.cboFontType.Name = "cboFontType";
            this.cboFontType.Size = new System.Drawing.Size(103, 20);
            this.cboFontType.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "字体";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "显示方式";
            // 
            // cboAlign
            // 
            this.cboAlign.AutoCompleteCustomSource.AddRange(new string[] {
            "左",
            "右",
            "上",
            "下"});
            this.cboAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlign.FormattingEnabled = true;
            this.cboAlign.Items.AddRange(new object[] {
            "center",
            "left",
            "right"});
            this.cboAlign.Location = new System.Drawing.Point(106, 185);
            this.cboAlign.Name = "cboAlign";
            this.cboAlign.Size = new System.Drawing.Size(61, 20);
            this.cboAlign.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "对齐方式";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 37);
            this.button1.TabIndex = 26;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboTDirection
            // 
            this.cboTDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTDirection.FormattingEnabled = true;
            this.cboTDirection.Items.AddRange(new object[] {
            "横",
            "竖"});
            this.cboTDirection.Location = new System.Drawing.Point(106, 159);
            this.cboTDirection.Name = "cboTDirection";
            this.cboTDirection.Size = new System.Drawing.Size(61, 20);
            this.cboTDirection.TabIndex = 27;
            // 
            // frmDataTxtTypeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 297);
            this.Controls.Add(this.cboTDirection);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboAlign);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboFontType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboShowType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numD_Height);
            this.Controls.Add(this.numD_Width);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numD_Y);
            this.Controls.Add(this.numD_X);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataTxtTypeSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文字数据类型设置";
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numD_Y;
        private System.Windows.Forms.NumericUpDown numD_X;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numD_Height;
        private System.Windows.Forms.NumericUpDown numD_Width;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboShowType;
        private System.Windows.Forms.ComboBox cboFontType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAlign;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboTDirection;
    }
}