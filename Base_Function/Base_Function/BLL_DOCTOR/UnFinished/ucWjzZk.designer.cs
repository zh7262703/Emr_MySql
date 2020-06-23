namespace Base_Function.BLL_DOCTOR.UnFinished
{
    partial class ucWjzZk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWjzZk));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvZK = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wslx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ywcsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cssj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tx = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZK)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgvZK);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(833, 451);
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
            this.groupPanel1.TabIndex = 0;
            // 
            // dgvZK
            // 
            this.dgvZK.AllowUserToAddRows = false;
            this.dgvZK.AllowUserToDeleteRows = false;
            this.dgvZK.BackgroundColor = System.Drawing.Color.White;
            this.dgvZK.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvZK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pname,
            this.wslx,
            this.tsnr,
            this.ywcsj,
            this.cssj,
            this.tx});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvZK.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvZK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZK.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvZK.Location = new System.Drawing.Point(0, 0);
            this.dgvZK.Name = "dgvZK";
            this.dgvZK.ReadOnly = true;
            this.dgvZK.RowHeadersVisible = false;
            this.dgvZK.RowTemplate.Height = 23;
            this.dgvZK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZK.Size = new System.Drawing.Size(827, 445);
            this.dgvZK.TabIndex = 1;
            this.dgvZK.DoubleClick += new System.EventHandler(this.dgvZK_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "红灯泡.png");
            this.imageList1.Images.SetKeyName(1, "黄灯泡.png");
            // 
            // pname
            // 
            this.pname.HeaderText = "患者姓名";
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            this.pname.Width = 80;
            // 
            // wslx
            // 
            this.wslx.HeaderText = "文书类型";
            this.wslx.Name = "wslx";
            this.wslx.ReadOnly = true;
            // 
            // tsnr
            // 
            this.tsnr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tsnr.HeaderText = "提示内容";
            this.tsnr.Name = "tsnr";
            this.tsnr.ReadOnly = true;
            this.tsnr.Width = 78;
            // 
            // ywcsj
            // 
            this.ywcsj.HeaderText = "应完成时间";
            this.ywcsj.Name = "ywcsj";
            this.ywcsj.ReadOnly = true;
            this.ywcsj.Width = 90;
            // 
            // cssj
            // 
            this.cssj.HeaderText = "剩余/超时 时间";
            this.cssj.Name = "cssj";
            this.cssj.ReadOnly = true;
            this.cssj.Width = 120;
            // 
            // tx
            // 
            this.tx.HeaderText = "提醒";
            this.tx.Name = "tx";
            this.tx.ReadOnly = true;
            this.tx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tx.Width = 40;
            // 
            // ucWjzZk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucWjzZk";
            this.Size = new System.Drawing.Size(833, 451);
            this.Load += new System.EventHandler(this.ucWjzZk_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvZK;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn wslx;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ywcsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn cssj;
        private System.Windows.Forms.DataGridViewImageColumn tx;
    }
}
