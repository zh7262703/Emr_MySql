namespace Base_Function.BLL_MANAGEMENT
{
    partial class QueryAllLevy
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbBox = new System.Windows.Forms.ComboBox();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.归档退回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消息提醒ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纸质病历上交ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pACS影像报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lIS检验报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手术麻醉报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医嘱单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cmbBox);
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.txtPatientName);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.txtPid);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(940, 77);
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
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "查询设置";
            // 
            // cmbBox
            // 
            this.cmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox.FormattingEnabled = true;
            this.cmbBox.Items.AddRange(new object[] {
            "未归档",
            "已归档"});
            this.cmbBox.Location = new System.Drawing.Point(474, 9);
            this.cmbBox.Name = "cmbBox";
            this.cmbBox.Size = new System.Drawing.Size(66, 25);
            this.cmbBox.TabIndex = 10;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(560, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(90, 28);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(273, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "姓名：";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(320, 10);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(130, 23);
            this.txtPatientName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(729, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "绿色：消息已读";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(729, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "黄色：有未发消息";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(729, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "红色：有未读消息";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(54, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "住院号：";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(113, 10);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(130, 23);
            this.txtPid.TabIndex = 5;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 77);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(940, 669);
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
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 4;
            this.groupPanel2.Text = "病人列表";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.ContextMenuStrip = this.contextMenuStrip1;
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(934, 643);
            this.ucGridviewX1.TabIndex = 1;
            this.ucGridviewX1.DoubleClick += new System.EventHandler(this.fg_DoubleClick);
            this.ucGridviewX1.MouseHover += new System.EventHandler(this.fg_MouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.归档退回ToolStripMenuItem,
            this.消息提醒ToolStripMenuItem,
            this.纸质病历上交ToolStripMenuItem,
            this.pACS影像报告ToolStripMenuItem,
            this.lIS检验报告ToolStripMenuItem,
            this.手术麻醉报告ToolStripMenuItem,
            this.医嘱单ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 180);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 归档退回ToolStripMenuItem
            // 
            this.归档退回ToolStripMenuItem.Name = "归档退回ToolStripMenuItem";
            this.归档退回ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.归档退回ToolStripMenuItem.Text = "归档退回";
            this.归档退回ToolStripMenuItem.Click += new System.EventHandler(this.归档退回ToolStripMenuItem_Click);
            // 
            // 消息提醒ToolStripMenuItem
            // 
            this.消息提醒ToolStripMenuItem.Name = "消息提醒ToolStripMenuItem";
            this.消息提醒ToolStripMenuItem.ShowShortcutKeys = false;
            this.消息提醒ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.消息提醒ToolStripMenuItem.Text = "消息提醒";
            this.消息提醒ToolStripMenuItem.Visible = false;
            this.消息提醒ToolStripMenuItem.Click += new System.EventHandler(this.消息提醒ToolStripMenuItem_Click);
            // 
            // 纸质病历上交ToolStripMenuItem
            // 
            this.纸质病历上交ToolStripMenuItem.Name = "纸质病历上交ToolStripMenuItem";
            this.纸质病历上交ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.纸质病历上交ToolStripMenuItem.Text = "纸质病历上交";
            this.纸质病历上交ToolStripMenuItem.Click += new System.EventHandler(this.纸质病历上交ToolStripMenuItem_Click);
            // 
            // pACS影像报告ToolStripMenuItem
            // 
            this.pACS影像报告ToolStripMenuItem.Name = "pACS影像报告ToolStripMenuItem";
            this.pACS影像报告ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pACS影像报告ToolStripMenuItem.Text = "PACS影像报告";
            this.pACS影像报告ToolStripMenuItem.Click += new System.EventHandler(this.pACS影像报告ToolStripMenuItem_Click);
            // 
            // lIS检验报告ToolStripMenuItem
            // 
            this.lIS检验报告ToolStripMenuItem.Name = "lIS检验报告ToolStripMenuItem";
            this.lIS检验报告ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lIS检验报告ToolStripMenuItem.Text = "LIS检验报告";
            this.lIS检验报告ToolStripMenuItem.Click += new System.EventHandler(this.lIS检验报告ToolStripMenuItem_Click);
            // 
            // 手术麻醉报告ToolStripMenuItem
            // 
            this.手术麻醉报告ToolStripMenuItem.Name = "手术麻醉报告ToolStripMenuItem";
            this.手术麻醉报告ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.手术麻醉报告ToolStripMenuItem.Text = "手术麻醉报告";
            this.手术麻醉报告ToolStripMenuItem.Visible = false;
            this.手术麻醉报告ToolStripMenuItem.Click += new System.EventHandler(this.手术麻醉报告ToolStripMenuItem_Click);
            // 
            // 医嘱单ToolStripMenuItem
            // 
            this.医嘱单ToolStripMenuItem.Name = "医嘱单ToolStripMenuItem";
            this.医嘱单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.医嘱单ToolStripMenuItem.Text = "医嘱单";
            this.医嘱单ToolStripMenuItem.Click += new System.EventHandler(this.医嘱单ToolStripMenuItem_Click);
            // 
            // QueryAllLevy
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "QueryAllLevy";
            this.Size = new System.Drawing.Size(940, 746);
            this.Load += new System.EventHandler(this.QueryAllLevy_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPid;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.ComboBox cmbBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 归档退回ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消息提醒ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 纸质病历上交ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pACS影像报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lIS检验报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手术麻醉报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医嘱单ToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Bifrost.ucGridviewX ucGridviewX1;
    }
}