namespace Base_Function.BLL_DOCTOR
{
    partial class UcDocRight
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvPatientList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.txtPid);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(841, 77);
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
            this.groupPanel1.Text = "查询";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(241, 9);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "住院号：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(34, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "姓名：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtPid
            // 
            // 
            // 
            // 
            this.txtPid.Border.Class = "TextBoxBorder";
            this.txtPid.Location = new System.Drawing.Point(322, 11);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(100, 21);
            this.txtPid.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(453, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Location = new System.Drawing.Point(115, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 1;
            // 
            // dgvPatientList
            // 
            this.dgvPatientList.AllowUserToAddRows = false;
            this.dgvPatientList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatientList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatientList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPatientList.Location = new System.Drawing.Point(0, 77);
            this.dgvPatientList.Name = "dgvPatientList";
            this.dgvPatientList.ReadOnly = true;
            this.dgvPatientList.RowTemplate.Height = 23;
            this.dgvPatientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatientList.Size = new System.Drawing.Size(841, 344);
            this.dgvPatientList.TabIndex = 1;
            this.dgvPatientList.DoubleClick += new System.EventHandler(this.dgvPatientList_DoubleClick);
            // 
            // UcDocRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dgvPatientList);
            this.Controls.Add(this.groupPanel1);
            this.Name = "UcDocRight";
            this.Size = new System.Drawing.Size(841, 421);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPid;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPatientList;
    }
}
