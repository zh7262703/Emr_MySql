namespace TempertureEditor.Controls
{
    partial class frmDataLineTypeSet
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numD_X = new System.Windows.Forms.NumericUpDown();
            this.numD_Y = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numD_SpanY = new System.Windows.Forms.NumericUpDown();
            this.numD_SpanX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSymbol = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.txtBaseVal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPenType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBrokenSet = new System.Windows.Forms.TextBox();
            this.btnSure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_SpanY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_SpanX)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(62, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 21);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "坐标X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "坐标Y";
            // 
            // numD_X
            // 
            this.numD_X.Location = new System.Drawing.Point(62, 39);
            this.numD_X.Name = "numD_X";
            this.numD_X.Size = new System.Drawing.Size(58, 21);
            this.numD_X.TabIndex = 4;
            // 
            // numD_Y
            // 
            this.numD_Y.Location = new System.Drawing.Point(62, 66);
            this.numD_Y.Name = "numD_Y";
            this.numD_Y.Size = new System.Drawing.Size(58, 21);
            this.numD_Y.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "偏移X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "偏移Y";
            // 
            // numD_SpanY
            // 
            this.numD_SpanY.Location = new System.Drawing.Point(182, 66);
            this.numD_SpanY.Name = "numD_SpanY";
            this.numD_SpanY.Size = new System.Drawing.Size(58, 21);
            this.numD_SpanY.TabIndex = 9;
            // 
            // numD_SpanX
            // 
            this.numD_SpanX.Location = new System.Drawing.Point(182, 39);
            this.numD_SpanX.Name = "numD_SpanX";
            this.numD_SpanX.Size = new System.Drawing.Size(58, 21);
            this.numD_SpanX.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "标签名称";
            // 
            // cboSymbol
            // 
            this.cboSymbol.FormattingEnabled = true;
            this.cboSymbol.Location = new System.Drawing.Point(62, 93);
            this.cboSymbol.Name = "cboSymbol";
            this.cboSymbol.Size = new System.Drawing.Size(127, 20);
            this.cboSymbol.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "刻度范围";
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(62, 119);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(89, 21);
            this.txtScale.TabIndex = 13;
            this.txtScale.TextChanged += new System.EventHandler(this.txtScale_TextChanged);
            this.txtScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScale_KeyPress);
            // 
            // txtBaseVal
            // 
            this.txtBaseVal.Location = new System.Drawing.Point(62, 146);
            this.txtBaseVal.Name = "txtBaseVal";
            this.txtBaseVal.Size = new System.Drawing.Size(89, 21);
            this.txtBaseVal.TabIndex = 15;
            this.txtBaseVal.TextChanged += new System.EventHandler(this.txtBaseVal_TextChanged);
            this.txtBaseVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseVal_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "基础数值";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "画笔";
            // 
            // cboPenType
            // 
            this.cboPenType.FormattingEnabled = true;
            this.cboPenType.Location = new System.Drawing.Point(62, 173);
            this.cboPenType.Name = "cboPenType";
            this.cboPenType.Size = new System.Drawing.Size(86, 20);
            this.cboPenType.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "中断";
            // 
            // txtBrokenSet
            // 
            this.txtBrokenSet.Location = new System.Drawing.Point(62, 198);
            this.txtBrokenSet.Name = "txtBrokenSet";
            this.txtBrokenSet.Size = new System.Drawing.Size(213, 21);
            this.txtBrokenSet.TabIndex = 19;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(146, 238);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(82, 31);
            this.btnSure.TabIndex = 20;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // frmDataTextTypeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 297);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.txtBrokenSet);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboPenType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBaseVal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboSymbol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numD_SpanY);
            this.Controls.Add(this.numD_SpanX);
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
            this.Name = "frmDataTextTypeSet";
            this.Text = "点线数据类型设置";
            this.Load += new System.EventHandler(this.frmDataTextTypeSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numD_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_SpanY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numD_SpanX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numD_X;
        private System.Windows.Forms.NumericUpDown numD_Y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numD_SpanY;
        private System.Windows.Forms.NumericUpDown numD_SpanX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSymbol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.TextBox txtBaseVal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPenType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBrokenSet;
        private System.Windows.Forms.Button btnSure;
    }
}