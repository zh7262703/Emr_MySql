namespace Base_Function.BLL_MANAGEMENT.ServerLink
{
    partial class ucDeletePatientDoc
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.btnQuarry = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除文书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownday = new System.Windows.Forms.NumericUpDown();
            this.btnguidang = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoDocTime = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownday)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人主键：";
            // 
            // txtPatientId
            // 
            this.txtPatientId.Location = new System.Drawing.Point(96, 17);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(158, 21);
            this.txtPatientId.TabIndex = 1;
            // 
            // btnQuarry
            // 
            this.btnQuarry.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuarry.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuarry.Location = new System.Drawing.Point(272, 14);
            this.btnQuarry.Name = "btnQuarry";
            this.btnQuarry.Size = new System.Drawing.Size(76, 26);
            this.btnQuarry.TabIndex = 2;
            this.btnQuarry.Text = "查询";
            this.btnQuarry.Click += new System.EventHandler(this.btnQuarry_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dataGridViewX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 82);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(827, 360);
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
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "病人文书列表";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(821, 336);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除文书ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // 删除文书ToolStripMenuItem
            // 
            this.删除文书ToolStripMenuItem.Name = "删除文书ToolStripMenuItem";
            this.删除文书ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.删除文书ToolStripMenuItem.Text = "删除文书";
            this.删除文书ToolStripMenuItem.Click += new System.EventHandler(this.删除文书ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAutoDocTime);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownday);
            this.panel1.Controls.Add(this.btnguidang);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPatientId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnQuarry);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 82);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(565, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "天";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(485, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "满：";
            // 
            // numericUpDownday
            // 
            this.numericUpDownday.Location = new System.Drawing.Point(520, 19);
            this.numericUpDownday.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownday.Name = "numericUpDownday";
            this.numericUpDownday.Size = new System.Drawing.Size(39, 21);
            this.numericUpDownday.TabIndex = 16;
            this.numericUpDownday.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // btnguidang
            // 
            this.btnguidang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnguidang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnguidang.Location = new System.Drawing.Point(598, 14);
            this.btnguidang.Name = "btnguidang";
            this.btnguidang.Size = new System.Drawing.Size(90, 28);
            this.btnguidang.TabIndex = 15;
            this.btnguidang.Text = "自动归档操作";
            this.btnguidang.Click += new System.EventHandler(this.btnguidang_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(354, 14);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(76, 26);
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "同步DOCNAME";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "XXX";
            // 
            // btnAutoDocTime
            // 
            this.btnAutoDocTime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoDocTime.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoDocTime.Location = new System.Drawing.Point(694, 14);
            this.btnAutoDocTime.Name = "btnAutoDocTime";
            this.btnAutoDocTime.Size = new System.Drawing.Size(107, 28);
            this.btnAutoDocTime.TabIndex = 19;
            this.btnAutoDocTime.Text = "自动生成归档时间";
            this.btnAutoDocTime.Click += new System.EventHandler(this.btnAutoDocTime_Click);
            // 
            // ucDeletePatientDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "ucDeletePatientDoc";
            this.Size = new System.Drawing.Size(827, 442);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientId;
        private DevComponents.DotNetBar.ButtonX btnQuarry;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除文书ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownday;
        private DevComponents.DotNetBar.ButtonX btnguidang;
        private DevComponents.DotNetBar.ButtonX btnAutoDocTime;
    }
}
