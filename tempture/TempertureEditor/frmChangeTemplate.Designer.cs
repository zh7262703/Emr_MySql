namespace TempertureEditor
{
    partial class frmChangeTemplate
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
            this.btnTemplateChoose = new System.Windows.Forms.Button();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTemplateChoose
            // 
            this.btnTemplateChoose.Location = new System.Drawing.Point(281, 25);
            this.btnTemplateChoose.Name = "btnTemplateChoose";
            this.btnTemplateChoose.Size = new System.Drawing.Size(37, 20);
            this.btnTemplateChoose.TabIndex = 5;
            this.btnTemplateChoose.Text = "...";
            this.btnTemplateChoose.UseVisualStyleBackColor = true;
            this.btnTemplateChoose.Click += new System.EventHandler(this.btnTemplateChoose_Click);
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.BackColor = System.Drawing.Color.White;
            this.txtTemplatePath.Location = new System.Drawing.Point(64, 24);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.ReadOnly = true;
            this.txtTemplatePath.Size = new System.Drawing.Size(209, 21);
            this.txtTemplatePath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择模板：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "TempertureSet.xml";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(105, 62);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(102, 29);
            this.btnSure.TabIndex = 13;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // frmChangeTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 103);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.btnTemplateChoose);
            this.Controls.Add(this.txtTemplatePath);
            this.Controls.Add(this.label1);
            this.Name = "frmChangeTemplate";
            this.Text = "提取体温单模板";
            this.Load += new System.EventHandler(this.frmChangeTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTemplateChoose;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSure;
    }
}