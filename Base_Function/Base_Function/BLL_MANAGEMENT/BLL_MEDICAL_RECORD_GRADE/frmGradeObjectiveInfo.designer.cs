namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    partial class frmGradeObjectiveInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradeObjectiveInfo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 46);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(239, 17);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(333, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 18;
            this.c1FlexGrid1.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.Columns;
            this.c1FlexGrid1.Size = new System.Drawing.Size(663, 314);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 21;
            // 
            // frmGradeObjectiveInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 360);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGradeObjectiveInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客观评分项目";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
    }
}