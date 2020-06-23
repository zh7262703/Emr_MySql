namespace BifrostMainPro
{
    partial class frmRoleChose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoleChose));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvRoles = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "上2.gif");
            // 
            // lvRoles
            // 
            this.lvRoles.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.lvRoles.Border.Class = "ListViewBorder";
            this.lvRoles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvRoles.DisabledBackColor = System.Drawing.Color.Empty;
            this.lvRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRoles.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvRoles.LargeImageList = this.imageList1;
            this.lvRoles.Location = new System.Drawing.Point(0, 0);
            this.lvRoles.Name = "lvRoles";
            this.lvRoles.Size = new System.Drawing.Size(408, 307);
            this.lvRoles.SmallImageList = this.imageList1;
            this.lvRoles.TabIndex = 1;
            this.lvRoles.UseCompatibleStateImageBehavior = false;
            this.lvRoles.View = System.Windows.Forms.View.List;
            this.lvRoles.SelectedIndexChanged += new System.EventHandler(this.lvRoles_SelectedIndexChanged);
            this.lvRoles.DoubleClick += new System.EventHandler(this.lvRoles_DoubleClick);
            this.lvRoles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvRoles_KeyDown);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.Location = new System.Drawing.Point(134, 3);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(70, 30);
            this.btnSure.TabIndex = 76;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(210, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 77;
            this.btnCancel.Text = "退出(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 38);
            this.panel1.TabIndex = 78;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lvRoles);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(414, 329);
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
            this.groupPanel1.TabIndex = 79;
            this.groupPanel1.Text = "角色列表";
            // 
            // frmRoleChose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(414, 367);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoleChose";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色的选择";
            this.TopLeftCornerSize = 0;
            this.TopRightCornerSize = 0;
            this.Load += new System.EventHandler(this.frmRoleChose_Load);
            this.panel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.ListViewEx lvRoles;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}