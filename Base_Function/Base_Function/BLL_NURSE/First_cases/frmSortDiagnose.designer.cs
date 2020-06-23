namespace Base_Function.BLL_NURSE.First_cases
{
    partial class frmSortDiagnose
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icd10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ischinese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.icd10,
            this.incondition,
            this.name,
            this.ischinese});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(604, 336);
            this.dataGridViewX1.TabIndex = 1;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonX4);
            this.groupPanel1.Controls.Add(this.buttonX3);
            this.groupPanel1.Controls.Add(this.buttonX2);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(0, 287);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(604, 49);
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
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(344, 11);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 23);
            this.buttonX4.TabIndex = 3;
            this.buttonX4.Text = "关闭";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(242, 11);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.TabIndex = 2;
            this.buttonX3.Text = "确定";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(139, 11);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "下移一行";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(36, 11);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(82, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "上移一行";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.Frozen = true;
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 60;
            // 
            // icd10
            // 
            this.icd10.DataPropertyName = "icd10";
            this.icd10.Frozen = true;
            this.icd10.HeaderText = "ICD10";
            this.icd10.Name = "icd10";
            this.icd10.ReadOnly = true;
            // 
            // incondition
            // 
            this.incondition.DataPropertyName = "incondition";
            this.incondition.Frozen = true;
            this.incondition.HeaderText = "入院病情";
            this.incondition.Name = "incondition";
            this.incondition.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.Frozen = true;
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 200;
            // 
            // ischinese
            // 
            this.ischinese.DataPropertyName = "ischinese";
            this.ischinese.HeaderText = "是否中医诊断";
            this.ischinese.Name = "ischinese";
            this.ischinese.ReadOnly = true;
            // 
            // frmSortDiagnose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 336);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSortDiagnose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出院诊断顺序调整";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn icd10;
        private System.Windows.Forms.DataGridViewTextBoxColumn incondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ischinese;
    }
}