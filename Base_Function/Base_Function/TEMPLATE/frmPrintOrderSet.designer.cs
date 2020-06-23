namespace Base_Function.TEMPLATE
{
    partial class frmPrintOrderSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintOrderSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.trvTextView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置打印顺序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListBook = new System.Windows.Forms.ImageList(this.components);
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGvText = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnAutoOrder = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGvText)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(740, 528);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.trvTextView);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(202, 528);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "文书结构";
            // 
            // trvTextView
            // 
            this.trvTextView.ContextMenuStrip = this.contextMenuStrip1;
            this.trvTextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTextView.ImageIndex = 0;
            this.trvTextView.ImageList = this.imgListBook;
            this.trvTextView.Location = new System.Drawing.Point(0, 0);
            this.trvTextView.Name = "trvTextView";
            this.trvTextView.SelectedImageIndex = 0;
            this.trvTextView.Size = new System.Drawing.Size(196, 504);
            this.trvTextView.TabIndex = 0;
            this.trvTextView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTextView_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置打印顺序ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // 设置打印顺序ToolStripMenuItem
            // 
            this.设置打印顺序ToolStripMenuItem.Name = "设置打印顺序ToolStripMenuItem";
            this.设置打印顺序ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.设置打印顺序ToolStripMenuItem.Text = "设置打印顺序";
            // 
            // imgListBook
            // 
            this.imgListBook.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBook.ImageStream")));
            this.imgListBook.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBook.Images.SetKeyName(0, "paintm.ico");
            this.imgListBook.Images.SetKeyName(1, "joym.ico");
            this.imgListBook.Images.SetKeyName(2, "manilla.ico");
            this.imgListBook.Images.SetKeyName(3, "net1m.ico");
            this.imgListBook.Images.SetKeyName(4, "net2m.ico");
            this.imgListBook.Images.SetKeyName(5, "New Text Doc.ico");
            this.imgListBook.Images.SetKeyName(6, "NOTEPA~1.ICO");
            this.imgListBook.Images.SetKeyName(7, "NOTEPA~2.ICO");
            this.imgListBook.Images.SetKeyName(8, "NOTEPA~3.ICO");
            this.imgListBook.Images.SetKeyName(9, "NOTEPA~4.ICO");
            this.imgListBook.Images.SetKeyName(10, "NOTEPA~5.ICO");
            this.imgListBook.Images.SetKeyName(11, "notesg.ico");
            this.imgListBook.Images.SetKeyName(12, "notesm.ico");
            this.imgListBook.Images.SetKeyName(13, "BETEXT~1.ICO");
            this.imgListBook.Images.SetKeyName(14, "FORMATED.ICO");
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dataGvText);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(534, 453);
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
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "子文书列表";
            // 
            // dataGvText
            // 
            this.dataGvText.AllowUserToAddRows = false;
            this.dataGvText.BackgroundColor = System.Drawing.Color.White;
            this.dataGvText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGvText.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGvText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGvText.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGvText.Location = new System.Drawing.Point(0, 0);
            this.dataGvText.Name = "dataGvText";
            this.dataGvText.RowTemplate.Height = 23;
            this.dataGvText.Size = new System.Drawing.Size(528, 429);
            this.dataGvText.TabIndex = 0;
            this.dataGvText.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGvText_CellMouseDoubleClick);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.btnAutoOrder);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(0, 453);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(534, 75);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel3.TabIndex = 1;
            this.groupPanel3.Text = "设置项";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(267, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAutoOrder
            // 
            this.btnAutoOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoOrder.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoOrder.Location = new System.Drawing.Point(195, 14);
            this.btnAutoOrder.Name = "btnAutoOrder";
            this.btnAutoOrder.Size = new System.Drawing.Size(66, 28);
            this.btnAutoOrder.TabIndex = 0;
            this.btnAutoOrder.Text = "自动排序";
            this.btnAutoOrder.Click += new System.EventHandler(this.btnAutoOrder_Click);
            // 
            // frmPrintOrderSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 528);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPrintOrderSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文书打印顺序的设置";
            this.Load += new System.EventHandler(this.frmPrintOrderSet_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGvText)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.TreeView trvTextView;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGvText;
        private System.Windows.Forms.ImageList imgListBook;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置打印顺序ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnAutoOrder;
    }
}