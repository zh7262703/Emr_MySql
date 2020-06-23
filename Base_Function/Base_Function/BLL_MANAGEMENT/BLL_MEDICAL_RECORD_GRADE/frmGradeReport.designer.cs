namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    partial class frmGradeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradeReport));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.buttonX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(761, 36);
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
            this.groupPanel2.TabIndex = 9;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(312, 4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(109, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "打印报表";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 36);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 18;
            this.c1FlexGrid1.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.Columns;
            this.c1FlexGrid1.Size = new System.Drawing.Size(761, 318);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 10;
            // 
            // frmGradeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 354);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.groupPanel2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGradeReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "评分报表";
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;

    }
}