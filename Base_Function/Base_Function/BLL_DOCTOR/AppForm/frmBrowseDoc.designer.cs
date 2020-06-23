namespace Base_Function.BLL_DOCTOR.AppForm
{
    partial class frmBrowseDoc
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
            this.cboPatientName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pnlDoc = new System.Windows.Forms.Panel();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPatientName
            // 
            this.cboPatientName.DisplayMember = "Text";
            this.cboPatientName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPatientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatientName.FormattingEnabled = true;
            this.cboPatientName.ItemHeight = 15;
            this.cboPatientName.Location = new System.Drawing.Point(90, 3);
            this.cboPatientName.Name = "cboPatientName";
            this.cboPatientName.Size = new System.Drawing.Size(122, 21);
            this.cboPatientName.TabIndex = 0;
            this.cboPatientName.SelectedIndexChanged += new System.EventHandler(this.cboPatientName_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(9, 1);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "病人姓名：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboPatientName);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(763, 63);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "选择病人";
            // 
            // pnlDoc
            // 
            this.pnlDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDoc.Location = new System.Drawing.Point(0, 63);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(763, 450);
            this.pnlDoc.TabIndex = 3;
            // 
            // frmBrowseDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 513);
            this.Controls.Add(this.pnlDoc);
            this.Controls.Add(this.groupPanel1);
            this.Name = "frmBrowseDoc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看病情";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBrowseDoc_Load);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPatientName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Panel pnlDoc;



    }
}