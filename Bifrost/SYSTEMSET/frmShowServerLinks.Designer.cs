namespace Bifrost.SYSTEMSET
{
    partial class frmShowServerLinks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowServerLinks));
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.ucServerLinkShow1 = new Bifrost.SYSTEMSET.ucServerLinkShow();
            this.ucDeletePatientDoc1 = new Bifrost.SYSTEMSET.ucDeletePatientDoc();
            this.ucPatientDocCheck1 = new Bifrost.SYSTEMSET.ucPatientDocCheck();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.ucOperaterLog1 = new Bifrost.SYSTEMSET.ucOperaterLog();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(807, 383);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Tabs.Add(this.tabItem4);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.ucDeletePatientDoc1);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(807, 357);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(156)))), ((int)(((byte)(184)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            this.tabControlPanel3.Text = "病人";
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "病人文书的删除";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.ucServerLinkShow1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(664, 357);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(156)))), ((int)(((byte)(184)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "当前登录用户的检测";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.ucPatientDocCheck1);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(807, 357);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(156)))), ((int)(((byte)(184)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "电子病历使用情况";
            // 
            // ucServerLinkShow1
            // 
            this.ucServerLinkShow1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ucServerLinkShow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucServerLinkShow1.Location = new System.Drawing.Point(1, 1);
            this.ucServerLinkShow1.Name = "ucServerLinkShow1";
            this.ucServerLinkShow1.Size = new System.Drawing.Size(662, 355);
            this.ucServerLinkShow1.TabIndex = 0;
            // 
            // ucDeletePatientDoc1
            // 
            this.ucDeletePatientDoc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDeletePatientDoc1.Location = new System.Drawing.Point(1, 1);
            this.ucDeletePatientDoc1.Name = "ucDeletePatientDoc1";
            this.ucDeletePatientDoc1.Size = new System.Drawing.Size(805, 355);
            this.ucDeletePatientDoc1.TabIndex = 0;
            // 
            // ucPatientDocCheck1
            // 
            this.ucPatientDocCheck1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ucPatientDocCheck1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPatientDocCheck1.Location = new System.Drawing.Point(1, 1);
            this.ucPatientDocCheck1.Name = "ucPatientDocCheck1";
            this.ucPatientDocCheck1.Size = new System.Drawing.Size(805, 355);
            this.ucPatientDocCheck1.TabIndex = 0;
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "操作日志查看";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.ucOperaterLog1);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(807, 357);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(156)))), ((int)(((byte)(184)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // ucOperaterLog1
            // 
            this.ucOperaterLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOperaterLog1.Location = new System.Drawing.Point(1, 1);
            this.ucOperaterLog1.Name = "ucOperaterLog1";
            this.ucOperaterLog1.Size = new System.Drawing.Size(805, 355);
            this.ucOperaterLog1.TabIndex = 0;
            // 
            // frmShowServerLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 383);
            this.Controls.Add(this.tabControl1);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            //this.Name = "frmShowServerLinks";
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看登录系统的账户列表";
            this.Load += new System.EventHandler(this.frmShowServerLinks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private ucServerLinkShow ucServerLinkShow1;
        private ucPatientDocCheck ucPatientDocCheck1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private ucDeletePatientDoc ucDeletePatientDoc1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private ucOperaterLog ucOperaterLog1;

    }
}