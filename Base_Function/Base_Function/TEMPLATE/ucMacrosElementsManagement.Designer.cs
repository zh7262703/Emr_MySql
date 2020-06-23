namespace Base_Function.TEMPLATE
{
    partial class ucMacrosElementsManagement
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvMacrosElements = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.button2 = new DevComponents.DotNetBar.ButtonX();
            this.pText = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvMacrosElements
            // 
            this.tvMacrosElements.ContextMenuStrip = this.contextMenuStrip1;
            this.tvMacrosElements.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvMacrosElements.Location = new System.Drawing.Point(0, 0);
            this.tvMacrosElements.Name = "tvMacrosElements";
            this.tvMacrosElements.Size = new System.Drawing.Size(238, 457);
            this.tvMacrosElements.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(238, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 35);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 21);
            this.textBox1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "患者Id";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Location = new System.Drawing.Point(363, 10);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(82, 18);
            this.buttonX2.TabIndex = 14;
            this.buttonX2.Text = "清空元素内容";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Location = new System.Drawing.Point(294, 10);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(63, 18);
            this.buttonX1.TabIndex = 14;
            this.buttonX1.Text = "清空";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.Location = new System.Drawing.Point(225, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 18);
            this.button2.TabIndex = 14;
            this.button2.Text = "测试";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pText
            // 
            this.pText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pText.Location = new System.Drawing.Point(238, 35);
            this.pText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pText.Name = "pText";
            this.pText.Size = new System.Drawing.Size(476, 422);
            this.pText.TabIndex = 4;
            // 
            // ucMacrosElementsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tvMacrosElements);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ucMacrosElementsManagement";
            this.Size = new System.Drawing.Size(714, 457);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvMacrosElements;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.ButtonX button2;
        private System.Windows.Forms.Panel pText;
        public DevComponents.DotNetBar.ButtonX buttonX1;
        public DevComponents.DotNetBar.ButtonX buttonX2;
    }
}
