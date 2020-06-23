namespace TempertureEditor.Controls
{
    partial class frmFontSet
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
            this.chkIta = new System.Windows.Forms.CheckBox();
            this.chkUnderLine = new System.Windows.Forms.CheckBox();
            this.cboFtype = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtTname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "效果显示";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 71);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTname);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkIta);
            this.groupBox2.Controls.Add(this.chkUnderLine);
            this.groupBox2.Controls.Add(this.cboFtype);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.txtFontSize);
            this.groupBox2.Controls.Add(this.chkBold);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnColor);
            this.groupBox2.Controls.Add(this.txtColor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // chkIta
            // 
            this.chkIta.AutoSize = true;
            this.chkIta.Location = new System.Drawing.Point(299, 127);
            this.chkIta.Name = "chkIta";
            this.chkIta.Size = new System.Drawing.Size(54, 16);
            this.chkIta.TabIndex = 12;
            this.chkIta.Text = " 斜体";
            this.chkIta.UseVisualStyleBackColor = true;
            this.chkIta.CheckedChanged += new System.EventHandler(this.chkIta_CheckedChanged);
            // 
            // chkUnderLine
            // 
            this.chkUnderLine.AutoSize = true;
            this.chkUnderLine.Location = new System.Drawing.Point(240, 126);
            this.chkUnderLine.Name = "chkUnderLine";
            this.chkUnderLine.Size = new System.Drawing.Size(60, 16);
            this.chkUnderLine.TabIndex = 11;
            this.chkUnderLine.Text = "下划线";
            this.chkUnderLine.UseVisualStyleBackColor = true;
            this.chkUnderLine.CheckedChanged += new System.EventHandler(this.chkUnderLine_CheckedChanged);
            // 
            // cboFtype
            // 
            this.cboFtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFtype.FormattingEnabled = true;
            this.cboFtype.Location = new System.Drawing.Point(72, 68);
            this.cboFtype.Name = "cboFtype";
            this.cboFtype.Size = new System.Drawing.Size(118, 20);
            this.cboFtype.TabIndex = 10;
            this.cboFtype.SelectedIndexChanged += new System.EventHandler(this.cboFtype_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 27);
            this.button1.TabIndex = 9;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(30, 22);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(47, 12);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "字体ID:";
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(72, 121);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(118, 21);
            this.txtFontSize.TabIndex = 7;
            this.txtFontSize.Text = "10";
            this.txtFontSize.TextChanged += new System.EventHandler(this.txtFontSize_TextChanged);
            this.txtFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFontSize_KeyPress);
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Location = new System.Drawing.Point(196, 126);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(48, 16);
            this.chkBold.TabIndex = 6;
            this.chkBold.Text = "粗体";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "大小：";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(196, 94);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(37, 19);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "...";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.Color.White;
            this.txtColor.Location = new System.Drawing.Point(72, 94);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(118, 21);
            this.txtColor.TabIndex = 3;
            this.txtColor.Text = "0,0,0";
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "颜色：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型：";
            // 
            // txtTname
            // 
            this.txtTname.Location = new System.Drawing.Point(72, 41);
            this.txtTname.Name = "txtTname";
            this.txtTname.Size = new System.Drawing.Size(118, 21);
            this.txtTname.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "名称：";
            // 
            // frmFontSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 305);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFontSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字体设置";
            this.Load += new System.EventHandler(this.frmFontSet_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox cboFtype;
        private System.Windows.Forms.CheckBox chkIta;
        private System.Windows.Forms.CheckBox chkUnderLine;
        private System.Windows.Forms.TextBox txtTname;
        private System.Windows.Forms.Label label4;
    }
}