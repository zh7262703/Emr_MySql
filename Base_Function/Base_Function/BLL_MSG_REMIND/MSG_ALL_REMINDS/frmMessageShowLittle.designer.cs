namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    partial class frmMessageShowLittle
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageShowLittle));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCK = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxShow = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 47);
            this.panel1.TabIndex = 0;
            // 
            // btnCK
            // 
            this.btnCK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCK.Location = new System.Drawing.Point(141, 12);
            this.btnCK.Name = "btnCK";
            this.btnCK.Size = new System.Drawing.Size(75, 23);
            this.btnCK.TabIndex = 2;
            this.btnCK.Text = "查看";
            this.btnCK.Click += new System.EventHandler(this.btnCK_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBoxShow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 215);
            this.panel2.TabIndex = 1;
            // 
            // txtBoxShow
            // 
            // 
            // 
            // 
            this.txtBoxShow.Border.Class = "TextBoxBorder";
            this.txtBoxShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxShow.Location = new System.Drawing.Point(0, 0);
            this.txtBoxShow.Multiline = true;
            this.txtBoxShow.Name = "txtBoxShow";
            this.txtBoxShow.Size = new System.Drawing.Size(357, 215);
            this.txtBoxShow.TabIndex = 0;
            // 
            // frmMessageShowLittle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageShowLittle";
            this.Text = "消息提醒";
            this.Load += new System.EventHandler(this.frmMessageShowLittle_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btnCK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBoxShow;
    }
}