namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    partial class frmMsgSendDetailsCheck
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbReceiver = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lbMsgType = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lbShouTiao = new DevComponents.DotNetBar.LabelX();
            this.lbTitle = new DevComponents.DotNetBar.LabelX();
            this.txtContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbLk = new DevComponents.DotNetBar.LabelX();
            this.lblAddTime = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(16, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(97, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "接   收   人：";
            // 
            // lbReceiver
            // 
            this.lbReceiver.Location = new System.Drawing.Point(100, 22);
            this.lbReceiver.Name = "lbReceiver";
            this.lbReceiver.Size = new System.Drawing.Size(569, 23);
            this.lbReceiver.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(16, 47);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(94, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "消 息  类 型：";
            // 
            // lbMsgType
            // 
            this.lbMsgType.Location = new System.Drawing.Point(100, 47);
            this.lbMsgType.Name = "lbMsgType";
            this.lbMsgType.Size = new System.Drawing.Size(75, 23);
            this.lbMsgType.TabIndex = 3;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(16, 72);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(92, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "是否需要收条：";
            // 
            // lbShouTiao
            // 
            this.lbShouTiao.Location = new System.Drawing.Point(100, 72);
            this.lbShouTiao.Name = "lbShouTiao";
            this.lbShouTiao.Size = new System.Drawing.Size(92, 23);
            this.lbShouTiao.TabIndex = 5;
            // 
            // lbTitle
            // 
            this.lbTitle.Location = new System.Drawing.Point(197, 100);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(255, 45);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtContent
            // 
            // 
            // 
            // 
            this.txtContent.Border.Class = "TextBoxBorder";
            this.txtContent.Location = new System.Drawing.Point(12, 159);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(657, 247);
            this.txtContent.TabIndex = 7;
            // 
            // lbLk
            // 
            this.lbLk.Location = new System.Drawing.Point(520, 417);
            this.lbLk.Name = "lbLk";
            this.lbLk.Size = new System.Drawing.Size(119, 23);
            this.lbLk.TabIndex = 8;
            // 
            // lblAddTime
            // 
            this.lblAddTime.Location = new System.Drawing.Point(516, 446);
            this.lblAddTime.Name = "lblAddTime";
            this.lblAddTime.Size = new System.Drawing.Size(163, 23);
            this.lblAddTime.TabIndex = 9;
            // 
            // frmMsgSendDetailsCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 476);
            this.Controls.Add(this.lblAddTime);
            this.Controls.Add(this.lbLk);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbShouTiao);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.lbMsgType);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lbReceiver);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmMsgSendDetailsCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息详细信息查看";
            this.Load += new System.EventHandler(this.frmMsgSendDetailsCheck_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbReceiver;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lbMsgType;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lbShouTiao;
        private DevComponents.DotNetBar.LabelX lbLk;
        private DevComponents.DotNetBar.LabelX lbTitle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtContent;
        private DevComponents.DotNetBar.LabelX lblAddTime;
    }
}