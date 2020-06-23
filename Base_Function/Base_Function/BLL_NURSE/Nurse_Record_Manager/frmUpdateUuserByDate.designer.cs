namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    partial class frmUpdateUuserByDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateUuserByDate));
            this.flgGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmtDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.flgGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flgGrid
            // 
            this.flgGrid.AllowEditing = false;
            this.flgGrid.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.flgGrid.Location = new System.Drawing.Point(3, 3);
            this.flgGrid.Name = "flgGrid";
            this.flgGrid.Rows.DefaultSize = 18;
            this.flgGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.flgGrid.Size = new System.Drawing.Size(259, 166);
            this.flgGrid.StyleInfo = resources.GetString("flgGrid.StyleInfo");
            this.flgGrid.TabIndex = 0;
            this.flgGrid.Click += new System.EventHandler(this.flgGrid_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmtDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmtDelete
            // 
            this.tsmtDelete.Name = "tsmtDelete";
            this.tsmtDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmtDelete.Text = "删除";
            this.tsmtDelete.Click += new System.EventHandler(this.tsmtDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目名称：";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(313, 57);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(140, 21);
            this.txtValue.TabIndex = 2;
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "值  ：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(328, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "时间：";
            this.label4.Visible = false;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(313, 105);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(140, 21);
            this.dtpTime.TabIndex = 6;
            this.dtpTime.Visible = false;
            // 
            // btncancel
            // 
            this.btncancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncancel.Location = new System.Drawing.Point(371, 138);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 9;
            this.btncancel.Text = "取消";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(290, 138);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmUpdateUuserByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 173);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flgGrid);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateUuserByDate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "时间段内修改护理记录单";
            this.Load += new System.EventHandler(this.frmUpdateUuserByDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flgGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid flgGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmtDelete;
        private DevComponents.DotNetBar.ButtonX btncancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
    }
}