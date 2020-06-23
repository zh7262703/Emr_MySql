namespace Base_Function.BLL_NURSE.First_cases
{
    partial class FrmCaselist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaselist));
            this.btnSubmit = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSubmit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSubmit.Location = new System.Drawing.Point(268, 244);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(349, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c1FlexGrid1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 228);
            this.panel1.TabIndex = 3;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 18;
            this.c1FlexGrid1.Size = new System.Drawing.Size(681, 228);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 1;
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            // 
            // FrmCaselist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(678, 277);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCaselist";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "诊断显示";
            this.Load += new System.EventHandler(this.FrmCaselist_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSubmit;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
    }
}