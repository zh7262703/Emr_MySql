namespace Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND
{
    partial class frmChooseMsg
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lvMsg = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMsgType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.cbxDoctor2 = new System.Windows.Forms.CheckedListBox();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lvMsg);
            this.groupPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(135, 9);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(627, 303);
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
            this.groupPanel1.TabIndex = 6;
            this.groupPanel1.Text = "消息内容";
            // 
            // lvMsg
            // 
            // 
            // 
            // 
            this.lvMsg.Border.Class = "ListViewBorder";
            this.lvMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvMsg.GridLines = true;
            this.lvMsg.Location = new System.Drawing.Point(0, 0);
            this.lvMsg.Name = "lvMsg";
            this.lvMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvMsg.Size = new System.Drawing.Size(621, 274);
            this.lvMsg.TabIndex = 7;
            this.lvMsg.UseCompatibleStateImageBehavior = false;
            this.lvMsg.View = System.Windows.Forms.View.List;
            this.lvMsg.DoubleClick += new System.EventHandler(this.lvMsg_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "消息类型：";
            // 
            // cbxMsgType
            // 
            this.cbxMsgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMsgType.FormattingEnabled = true;
            this.cbxMsgType.Location = new System.Drawing.Point(1, 27);
            this.cbxMsgType.Name = "cbxMsgType";
            this.cbxMsgType.Size = new System.Drawing.Size(119, 20);
            this.cbxMsgType.TabIndex = 1;
            this.cbxMsgType.SelectedIndexChanged += new System.EventHandler(this.cbxMsgType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "接收人：";
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(67, 58);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(122, 20);
            this.cbxDoctor.TabIndex = 4;
            this.cbxDoctor.Visible = false;
            // 
            // cbxDoctor2
            // 
            this.cbxDoctor2.FormattingEnabled = true;
            this.cbxDoctor2.Location = new System.Drawing.Point(0, 84);
            this.cbxDoctor2.Name = "cbxDoctor2";
            this.cbxDoctor2.Size = new System.Drawing.Size(120, 228);
            this.cbxDoctor2.TabIndex = 7;
            // 
            // frmChooseMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 312);
            this.Controls.Add(this.cbxDoctor2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.cbxDoctor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxMsgType);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChooseMsg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主动消息选择";
            this.Load += new System.EventHandler(this.frmChooseMsg_Load);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMsgType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.CheckedListBox cbxDoctor2;
        private DevComponents.DotNetBar.Controls.ListViewEx lvMsg;
    }
}