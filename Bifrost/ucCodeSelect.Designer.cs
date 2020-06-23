namespace Leadron
{
    /// <summary>
    /// 快码查询
    /// </summary>
    partial class ucCodeSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCodeSelect));
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.SuspendLayout();
            // 
            // fg
            // 
            this.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            this.fg.ColumnInfo = "1,1,0,0,0,0,Columns:0{Width:20;Name:\"No\";AllowMerging:True;Style:\"EditMask:\"\"1\"\";" +
                "DataType:System.Decimal;TextAlign:RightCenter;\";}\t";
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.Location = new System.Drawing.Point(0, 0);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.DefaultSize = 18;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.Size = new System.Drawing.Size(362, 373);
            this.fg.StyleInfo = resources.GetString("fg.StyleInfo");
            this.fg.TabIndex = 3;
            this.fg.Tree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fg.Tree.NodeImageCollapsed = ((System.Drawing.Image)(resources.GetObject("fg.Tree.NodeImageCollapsed")));
            this.fg.Tree.NodeImageExpanded = ((System.Drawing.Image)(resources.GetObject("fg.Tree.NodeImageExpanded")));
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fg_KeyDown);
            this.fg.DoubleClick += new System.EventHandler(this.fg_DoubleClick);
            // 
            // ucCodeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fg);
            this.DoubleBuffered = true;
            this.Name = "ucCodeSelect";
            this.Size = new System.Drawing.Size(362, 373);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// 表格控件
        /// </summary>
        public C1.Win.C1FlexGrid.C1FlexGrid fg;
    }
}
