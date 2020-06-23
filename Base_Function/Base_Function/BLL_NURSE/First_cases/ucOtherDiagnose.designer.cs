namespace Base_Function.BLL_NURSE.First_cases
{
    partial class ucOtherDiagnose
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtOtherDiagnose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtICD10 = new System.Windows.Forms.TextBox();
            this.cboInCondition = new System.Windows.Forms.ComboBox();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "其他诊断：";
            // 
            // txtOtherDiagnose
            // 
            this.txtOtherDiagnose.Location = new System.Drawing.Point(69, 2);
            this.txtOtherDiagnose.Name = "txtOtherDiagnose";
            this.txtOtherDiagnose.Size = new System.Drawing.Size(151, 21);
            this.txtOtherDiagnose.TabIndex = 1;
            this.txtOtherDiagnose.DoubleClick += new System.EventHandler(this.txtOtherDiagnose_DoubleClick);
            this.txtOtherDiagnose.TextChanged += new System.EventHandler(this.txtOtherDiagnose_TextChanged);
            this.txtOtherDiagnose.Leave += new System.EventHandler(this.txtOtherDiagnose_Leave);
            this.txtOtherDiagnose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOtherDiagnose_KeyUp);
            this.txtOtherDiagnose.Enter += new System.EventHandler(this.txtOtherDiagnose_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "疾病编码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "入院病情：";
            // 
            // txtICD10
            // 
            this.txtICD10.Location = new System.Drawing.Point(69, 25);
            this.txtICD10.Name = "txtICD10";
            this.txtICD10.Size = new System.Drawing.Size(81, 21);
            this.txtICD10.TabIndex = 4;
            // 
            // cboInCondition
            // 
            this.cboInCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInCondition.FormattingEnabled = true;
            this.cboInCondition.Items.AddRange(new object[] {
            "  ",
            "有",
            "临床未确定",
            "情况不明",
            "无"});
            this.cboInCondition.Location = new System.Drawing.Point(216, 26);
            this.cboInCondition.Name = "cboInCondition";
            this.cboInCondition.Size = new System.Drawing.Size(85, 20);
            this.cboInCondition.TabIndex = 6;
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Location = new System.Drawing.Point(225, 1);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(75, 23);
            this.checkBoxX1.TabIndex = 7;
            this.checkBoxX1.Text = "中医诊断";
            this.checkBoxX1.MouseLeave += new System.EventHandler(this.checkBoxX1_MouseLeave);
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            this.checkBoxX1.MouseEnter += new System.EventHandler(this.checkBoxX1_MouseEnter);
            // 
            // ucOtherDiagnose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.cboInCondition);
            this.Controls.Add(this.txtICD10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOtherDiagnose);
            this.Controls.Add(this.label1);
            this.Name = "ucOtherDiagnose";
            this.Size = new System.Drawing.Size(304, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOtherDiagnose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtICD10;
        private System.Windows.Forms.ComboBox cboInCondition;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
    }
}
