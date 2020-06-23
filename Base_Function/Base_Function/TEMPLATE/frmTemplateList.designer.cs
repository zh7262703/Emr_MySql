namespace Base_Function.TEMPLATE
{
    partial class frmTemplateList
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
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.ucTempList_Big1 = new Base_Function.TEMPLATE.ucTempList_Big();
            this.tabBig = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.ucTempList_Small1 = new Base_Function.TEMPLATE.ucTempList_Small();
            this.tabSmall = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(378, 504);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(60, 22);
            this.btnSure.TabIndex = 9;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(444, 504);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 22);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 498);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabBig);
            this.tabControl1.Tabs.Add(this.tabSmall);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.ucTempList_Big1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(882, 472);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabBig;
            // 
            // ucTempList_Big1
            // 
            this.ucTempList_Big1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTempList_Big1.Kindtid = "0";
            this.ucTempList_Big1.Location = new System.Drawing.Point(1, 1);
            this.ucTempList_Big1.Name = "ucTempList_Big1";
            this.ucTempList_Big1.Section_id = "";
            this.ucTempList_Big1.Size = new System.Drawing.Size(880, 470);
            this.ucTempList_Big1.TabIndex = 0;
            this.ucTempList_Big1.Tid = null;
            // 
            // tabBig
            // 
            this.tabBig.AttachedControl = this.tabControlPanel1;
            this.tabBig.Name = "tabBig";
            this.tabBig.Text = "大模板";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.ucTempList_Small1);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(882, 472);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabSmall;
            // 
            // ucTempList_Small1
            // 
            this.ucTempList_Small1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTempList_Small1.Location = new System.Drawing.Point(1, 1);
            this.ucTempList_Small1.Name = "ucTempList_Small1";
            this.ucTempList_Small1.Size = new System.Drawing.Size(880, 470);
            this.ucTempList_Small1.TabIndex = 0;
            this.ucTempList_Small1.Tid = null;
            // 
            // tabSmall
            // 
            this.tabSmall.AttachedControl = this.tabControlPanel2;
            this.tabSmall.Name = "tabSmall";
            this.tabSmall.Text = "小模板";
            // 
            // frmTemplateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 538);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTemplateList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板列表";
            this.Load += new System.EventHandler(this.frmTemplateList_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTemplateList_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabBig;
        private ucTempList_Big ucTempList_Big1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private ucTempList_Small ucTempList_Small1;
        private DevComponents.DotNetBar.TabItem tabSmall;
    }
}