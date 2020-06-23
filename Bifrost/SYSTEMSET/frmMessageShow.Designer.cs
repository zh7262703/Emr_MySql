namespace Bifrost.SYSTEMSET
{
    partial class frmMessageShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageShow));
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.RichTxtMessage = new System.Windows.Forms.RichTextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.trvMessage = new System.Windows.Forms.TreeView();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel7.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCreator.Location = new System.Drawing.Point(265, 10);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(63, 14);
            this.lblCreator.TabIndex = 1;
            this.lblCreator.Text = "发布人：";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCreateTime.Location = new System.Drawing.Point(32, 10);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(77, 14);
            this.lblCreateTime.TabIndex = 0;
            this.lblCreateTime.Text = "发布时间：";
            // 
            // RichTxtMessage
            // 
            this.RichTxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichTxtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTxtMessage.Location = new System.Drawing.Point(0, 0);
            this.RichTxtMessage.Name = "RichTxtMessage";
            this.RichTxtMessage.Size = new System.Drawing.Size(428, 277);
            this.RichTxtMessage.TabIndex = 0;
            this.RichTxtMessage.Text = "";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnClose);
            this.panel7.Controls.Add(this.btnSure);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 338);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(632, 48);
            this.panel7.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(320, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(220, 11);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(93, 28);
            this.btnSure.TabIndex = 0;
            this.btnSure.Text = "确定已读";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // trvMessage
            // 
            this.trvMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMessage.ImageIndex = 0;
            this.trvMessage.ImageList = this.imageList1;
            this.trvMessage.Location = new System.Drawing.Point(0, 0);
            this.trvMessage.Name = "trvMessage";
            this.trvMessage.SelectedImageIndex = 0;
            this.trvMessage.Size = new System.Drawing.Size(192, 314);
            this.trvMessage.TabIndex = 0;
            this.trvMessage.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMessage_AfterSelect);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.trvMessage);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(198, 338);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 7;
            this.groupPanel1.Text = "标题";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.RichTxtMessage);
            this.groupPanel2.Controls.Add(this.panel1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(198, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(434, 338);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 8;
            this.groupPanel2.Text = "内容";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCreator);
            this.panel1.Controls.Add(this.lblCreateTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 37);
            this.panel1.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "门诊医生工作站.ico");
            // 
            // frmMessageShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 386);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel7);
            this.DoubleBuffered = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMessageShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息阅读";
            this.Load += new System.EventHandler(this.frmMessageShow_Load);
            this.panel7.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.RichTextBox RichTxtMessage;
        private System.Windows.Forms.Panel panel7;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.TreeView trvMessage;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
    }
}