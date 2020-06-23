namespace Base_Function.BLL_DOCTOR
{
    partial class frmNotSignature
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cboSignType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbiDoctor = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.btnDoctorSign = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboOutPatient = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxDoctorAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboInPatients = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgvDoctorSign = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorSign)).BeginInit();
            this.SuspendLayout();
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "管床未签字";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(337, 379);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.cboSignType);
            this.groupPanel1.Controls.Add(this.btnDoctorSign);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.cboOutPatient);
            this.groupPanel1.Controls.Add(this.cbxDoctorAll);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.cboInPatients);
            this.groupPanel1.Controls.Add(this.dgvDoctorSign);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(512, 466);
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "管床未签字文书";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(115, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Location = new System.Drawing.Point(-12, 10);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "签名类型：";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboSignType
            // 
            this.cboSignType.DisplayMember = "Text";
            this.cboSignType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSignType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSignType.FormattingEnabled = true;
            this.cboSignType.ItemHeight = 15;
            this.cboSignType.Items.AddRange(new object[] {
            this.cbiDoctor,
            this.comboItem2});
            this.cboSignType.Location = new System.Drawing.Point(69, 10);
            this.cboSignType.Name = "cboSignType";
            this.cboSignType.Size = new System.Drawing.Size(121, 21);
            this.cboSignType.TabIndex = 7;
            // 
            // cbiDoctor
            // 
            this.cbiDoctor.Text = "管床医生";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "上级医生";
            // 
            // btnDoctorSign
            // 
            this.btnDoctorSign.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDoctorSign.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDoctorSign.Location = new System.Drawing.Point(420, 40);
            this.btnDoctorSign.Name = "btnDoctorSign";
            this.btnDoctorSign.Size = new System.Drawing.Size(75, 23);
            this.btnDoctorSign.TabIndex = 6;
            this.btnDoctorSign.Text = "签名";
            this.btnDoctorSign.Click += new System.EventHandler(this.btnDoctorSign_Click);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(196, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "出院病人：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboOutPatient
            // 
            this.cboOutPatient.DisplayMember = "Text";
            this.cboOutPatient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOutPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutPatient.FormattingEnabled = true;
            this.cboOutPatient.ItemHeight = 15;
            this.cboOutPatient.Location = new System.Drawing.Point(277, 41);
            this.cboOutPatient.Name = "cboOutPatient";
            this.cboOutPatient.Size = new System.Drawing.Size(121, 21);
            this.cboOutPatient.TabIndex = 4;
            this.cboOutPatient.SelectedValueChanged += new System.EventHandler(this.cboOutPatient_SelectedIndexChanged);
            // 
            // cbxDoctorAll
            // 
            this.cbxDoctorAll.BackColor = System.Drawing.Color.Transparent;
            this.cbxDoctorAll.Location = new System.Drawing.Point(420, 11);
            this.cbxDoctorAll.Name = "cbxDoctorAll";
            this.cbxDoctorAll.Size = new System.Drawing.Size(75, 23);
            this.cbxDoctorAll.TabIndex = 3;
            this.cbxDoctorAll.Text = "全选";
            this.cbxDoctorAll.CheckedChanged += new System.EventHandler(this.cbxCheckedAll_CheckedChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(196, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "在院病人：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboInPatients
            // 
            this.cboInPatients.DisplayMember = "Text";
            this.cboInPatients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboInPatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInPatients.FormattingEnabled = true;
            this.cboInPatients.ItemHeight = 15;
            this.cboInPatients.Location = new System.Drawing.Point(277, 11);
            this.cboInPatients.Name = "cboInPatients";
            this.cboInPatients.Size = new System.Drawing.Size(121, 21);
            this.cboInPatients.TabIndex = 1;
            this.cboInPatients.SelectedValueChanged += new System.EventHandler(this.cboPatients_SelectedIndexChanged);
            // 
            // dgvDoctorSign
            // 
            this.dgvDoctorSign.AllowUserToAddRows = false;
            this.dgvDoctorSign.AllowUserToDeleteRows = false;
            this.dgvDoctorSign.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDoctorSign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoctorSign.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoctorSign.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDoctorSign.Location = new System.Drawing.Point(0, 69);
            this.dgvDoctorSign.Name = "dgvDoctorSign";
            this.dgvDoctorSign.ReadOnly = true;
            this.dgvDoctorSign.RowTemplate.Height = 23;
            this.dgvDoctorSign.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctorSign.Size = new System.Drawing.Size(504, 374);
            this.dgvDoctorSign.TabIndex = 0;
            this.dgvDoctorSign.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDoctorSign_CellMouseClick);
            // 
            // frmNotSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 466);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmNotSignature";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "未签字文书";
            this.Load += new System.EventHandler(this.frmNotSignature_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorSign)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSignType;
        private DevComponents.Editors.ComboItem cbiDoctor;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.ButtonX btnDoctorSign;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboOutPatient;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbxDoctorAll;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboInPatients;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDoctorSign;

    }
}