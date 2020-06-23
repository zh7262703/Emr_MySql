namespace Base_Function.BLL_FOLLOW.Element
{
    partial class ucTextBox
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
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_content
            // 
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_content.Location = new System.Drawing.Point(0, 0);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(377, 32);
            this.panel_content.TabIndex = 0;
            this.panel_content.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel_content_ControlRemoved);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(383, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(38, 32);
            this.panel1.TabIndex = 1;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX2.Location = new System.Drawing.Point(20, 0);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(18, 32);
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = ">>";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonX1.Location = new System.Drawing.Point(0, 0);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(20, 32);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "<<";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // ucTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_content);
            this.Name = "ucTextBox";
            this.Size = new System.Drawing.Size(421, 32);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;

    }
}
