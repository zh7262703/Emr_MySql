namespace Base_Function.BLL_MANAGEMENT
{
    partial class UcLight
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
            this.pbxYel = new System.Windows.Forms.PictureBox();
            this.lblDocName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblYel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxYel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxYel
            // 
            this.pbxYel.Location = new System.Drawing.Point(39, 0);
            this.pbxYel.Margin = new System.Windows.Forms.Padding(0);
            this.pbxYel.Name = "pbxYel";
            this.pbxYel.Size = new System.Drawing.Size(20, 20);
            this.pbxYel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxYel.TabIndex = 4;
            this.pbxYel.TabStop = false;
            this.pbxYel.DoubleClick += new System.EventHandler(this.UcLight_DoubleClick);
            // 
            // lblDocName
            // 
            this.lblDocName.AutoSize = true;
            this.lblDocName.Location = new System.Drawing.Point(0, 2);
            this.lblDocName.Name = "lblDocName";
            this.lblDocName.Size = new System.Drawing.Size(29, 19);
            this.lblDocName.TabIndex = 3;
            this.lblDocName.Text = "病程";
            this.lblDocName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblDocName.UseCompatibleTextRendering = true;
            this.lblDocName.DoubleClick += new System.EventHandler(this.UcLight_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbxYel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblYel);
            this.panel1.Location = new System.Drawing.Point(26, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(71, 20);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "[";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(59, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "]";
            // 
            // lblYel
            // 
            this.lblYel.AutoSize = true;
            this.lblYel.Location = new System.Drawing.Point(9, 5);
            this.lblYel.Margin = new System.Windows.Forms.Padding(0);
            this.lblYel.Name = "lblYel";
            this.lblYel.Size = new System.Drawing.Size(23, 12);
            this.lblYel.TabIndex = 8;
            this.lblYel.Text = "100";
            this.lblYel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblYel.DoubleClick += new System.EventHandler(this.UcLight_DoubleClick);
            // 
            // UcLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDocName);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UcLight";
            this.Size = new System.Drawing.Size(98, 21);
            this.DoubleClick += new System.EventHandler(this.UcLight_DoubleClick);
            this.MouseLeave += new System.EventHandler(this.UcLight_MouseLeave);
            this.Click += new System.EventHandler(this.UcLight_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UcLight_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbxYel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxYel;
        private System.Windows.Forms.Label lblDocName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblYel;
    }
}
