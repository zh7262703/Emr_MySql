namespace Base_Function.BASE_DATA
{
    partial class frmWrite_Type_TrvSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWrite_Type_TrvSelect));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.trvDictionary = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 44);
            this.panel1.TabIndex = 2;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(71, 15);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(159, 20);
            this.cmbType.TabIndex = 17;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "文书类型：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.trvDictionary);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(325, 396);
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
            this.groupPanel1.Text = "文书类型展示";
            // 
            // trvDictionary
            // 
            this.trvDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDictionary.HideSelection = false;
            this.trvDictionary.ImageIndex = 3;
            this.trvDictionary.ImageList = this.imageList1;
            this.trvDictionary.Location = new System.Drawing.Point(0, 44);
            this.trvDictionary.Name = "trvDictionary";
            this.trvDictionary.SelectedImageIndex = 3;
            this.trvDictionary.Size = new System.Drawing.Size(319, 328);
            this.trvDictionary.TabIndex = 8;
            this.trvDictionary.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trvDictionary_MouseDoubleClick);
            this.trvDictionary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvDictionary_KeyDown);
            this.trvDictionary.Click += new System.EventHandler(this.trvDictionary_Click);
            // 
            // frmWrite_Type_TrvSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 396);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWrite_Type_TrvSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "父级文书的选择";
            this.Load += new System.EventHandler(this.frmWrite_Type_TrvSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.TreeView trvDictionary;
    }
}