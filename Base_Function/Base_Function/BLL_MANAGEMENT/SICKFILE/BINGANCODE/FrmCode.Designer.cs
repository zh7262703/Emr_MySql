namespace Base_Function.BLL_MANAGEMENT.SICKFILE.BINGANCODE
{
    partial class FrmCode
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
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(197, 128);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 11;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(107, 128);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "确定";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "申请原因：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(90, 8);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(226, 106);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // FrmCode
            // 
            this.ClientSize = new System.Drawing.Size(337, 158);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.DoubleBuffered = true;
            this.Name = "FrmCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病案编目修改申请";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}