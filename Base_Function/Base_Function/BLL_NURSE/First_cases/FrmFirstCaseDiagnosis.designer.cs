namespace Base_Function.BLL_NURSE.First_cases
{
    partial class FrmFirstCaseDiagnosis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.typename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagnosename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icd10code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incondition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sicknumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.patientid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ischinese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel7 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnCDiagZH = new DevComponents.DotNetBar.ButtonX();
            this.btnCDiagName = new DevComponents.DotNetBar.ButtonX();
            this.btnDiagDown = new DevComponents.DotNetBar.ButtonX();
            this.btnDiagUp = new DevComponents.DotNetBar.ButtonX();
            this.btnDiagSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnDiagInsert = new DevComponents.DotNetBar.ButtonX();
            this.btnDiagDelete = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.groupPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typename,
            this.typecode,
            this.diagnosename,
            this.icd10code,
            this.incondition,
            this.sicknumber,
            this.turnto,
            this.patientid,
            this.ischinese});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(990, 479);
            this.dataGridViewX1.TabIndex = 2;
            this.dataGridViewX1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewX1_CellBeginEdit);
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellClick);
            this.dataGridViewX1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewX1_EditingControlShowing);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // typename
            // 
            this.typename.DataPropertyName = "typename";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.typename.DefaultCellStyle = dataGridViewCellStyle1;
            this.typename.HeaderText = "诊断类型";
            this.typename.Name = "typename";
            this.typename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.typename.Width = 120;
            // 
            // typecode
            // 
            this.typecode.DataPropertyName = "typecode";
            this.typecode.HeaderText = "typecode";
            this.typecode.Name = "typecode";
            this.typecode.Visible = false;
            // 
            // diagnosename
            // 
            this.diagnosename.DataPropertyName = "diagnosename";
            this.diagnosename.HeaderText = "诊断名称";
            this.diagnosename.Name = "diagnosename";
            this.diagnosename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.diagnosename.Width = 300;
            // 
            // icd10code
            // 
            this.icd10code.DataPropertyName = "icd10code";
            this.icd10code.HeaderText = "诊断编码";
            this.icd10code.Name = "icd10code";
            this.icd10code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // incondition
            // 
            this.incondition.DataPropertyName = "incondition";
            this.incondition.HeaderText = "入院病情";
            this.incondition.Items.AddRange(new object[] {
            "",
            "有",
            "临床未确定",
            "情况不明",
            "无"});
            this.incondition.Name = "incondition";
            this.incondition.Width = 80;
            // 
            // sicknumber
            // 
            this.sicknumber.DataPropertyName = "sicknumber";
            this.sicknumber.HeaderText = "病理号";
            this.sicknumber.Name = "sicknumber";
            this.sicknumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // turnto
            // 
            this.turnto.DataPropertyName = "turnto";
            this.turnto.HeaderText = "转归情况";
            this.turnto.Items.AddRange(new object[] {
            "治愈",
            "好转",
            "未愈"});
            this.turnto.Name = "turnto";
            this.turnto.Width = 80;
            // 
            // patientid
            // 
            this.patientid.DataPropertyName = "patientid";
            this.patientid.HeaderText = "patientid";
            this.patientid.Name = "patientid";
            this.patientid.Visible = false;
            // 
            // ischinese
            // 
            this.ischinese.DataPropertyName = "ischinese";
            this.ischinese.HeaderText = "ischinese";
            this.ischinese.Name = "ischinese";
            this.ischinese.Visible = false;
            // 
            // groupPanel7
            // 
            this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel7.Controls.Add(this.btnCDiagZH);
            this.groupPanel7.Controls.Add(this.btnCDiagName);
            this.groupPanel7.Controls.Add(this.btnDiagDown);
            this.groupPanel7.Controls.Add(this.btnDiagUp);
            this.groupPanel7.Controls.Add(this.btnDiagSelect);
            this.groupPanel7.Controls.Add(this.btnDiagInsert);
            this.groupPanel7.Controls.Add(this.btnDiagDelete);
            this.groupPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel7.Location = new System.Drawing.Point(0, 0);
            this.groupPanel7.Name = "groupPanel7";
            this.groupPanel7.Size = new System.Drawing.Size(990, 41);
            // 
            // 
            // 
            this.groupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel7.Style.BackColorGradientAngle = 90;
            this.groupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderBottomWidth = 1;
            this.groupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderLeftWidth = 1;
            this.groupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderRightWidth = 1;
            this.groupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderTopWidth = 1;
            this.groupPanel7.Style.CornerDiameter = 4;
            this.groupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel7.TabIndex = 3;
            // 
            // btnCDiagZH
            // 
            this.btnCDiagZH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCDiagZH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCDiagZH.Location = new System.Drawing.Point(720, 6);
            this.btnCDiagZH.Name = "btnCDiagZH";
            this.btnCDiagZH.Size = new System.Drawing.Size(75, 23);
            this.btnCDiagZH.TabIndex = 6;
            this.btnCDiagZH.Text = "中医症候";
            this.btnCDiagZH.Visible = false;
            this.btnCDiagZH.Click += new System.EventHandler(this.btnCDiagZH_Click);
            // 
            // btnCDiagName
            // 
            this.btnCDiagName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCDiagName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCDiagName.Location = new System.Drawing.Point(639, 6);
            this.btnCDiagName.Name = "btnCDiagName";
            this.btnCDiagName.Size = new System.Drawing.Size(75, 23);
            this.btnCDiagName.TabIndex = 5;
            this.btnCDiagName.Text = "中医诊断";
            this.btnCDiagName.Click += new System.EventHandler(this.btnCDiagName_Click);
            // 
            // btnDiagDown
            // 
            this.btnDiagDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDiagDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDiagDown.Location = new System.Drawing.Point(394, 6);
            this.btnDiagDown.Name = "btnDiagDown";
            this.btnDiagDown.Size = new System.Drawing.Size(75, 23);
            this.btnDiagDown.TabIndex = 4;
            this.btnDiagDown.Text = "下移";
            this.btnDiagDown.Click += new System.EventHandler(this.btnDiagDown_Click);
            // 
            // btnDiagUp
            // 
            this.btnDiagUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDiagUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDiagUp.Location = new System.Drawing.Point(313, 6);
            this.btnDiagUp.Name = "btnDiagUp";
            this.btnDiagUp.Size = new System.Drawing.Size(75, 23);
            this.btnDiagUp.TabIndex = 3;
            this.btnDiagUp.Text = "上移";
            this.btnDiagUp.Click += new System.EventHandler(this.btnDiagUp_Click);
            // 
            // btnDiagSelect
            // 
            this.btnDiagSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDiagSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDiagSelect.Location = new System.Drawing.Point(190, 6);
            this.btnDiagSelect.Name = "btnDiagSelect";
            this.btnDiagSelect.Size = new System.Drawing.Size(117, 23);
            this.btnDiagSelect.TabIndex = 2;
            this.btnDiagSelect.Text = "提取病历诊断";
            this.btnDiagSelect.Click += new System.EventHandler(this.btnDiagSelect_Click);
            // 
            // btnDiagInsert
            // 
            this.btnDiagInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDiagInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDiagInsert.Location = new System.Drawing.Point(475, 6);
            this.btnDiagInsert.Name = "btnDiagInsert";
            this.btnDiagInsert.Size = new System.Drawing.Size(75, 23);
            this.btnDiagInsert.TabIndex = 1;
            this.btnDiagInsert.Text = "插入行";
            this.btnDiagInsert.Click += new System.EventHandler(this.btnDiagInsert_Click);
            // 
            // btnDiagDelete
            // 
            this.btnDiagDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDiagDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDiagDelete.Location = new System.Drawing.Point(556, 6);
            this.btnDiagDelete.Name = "btnDiagDelete";
            this.btnDiagDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDiagDelete.TabIndex = 0;
            this.btnDiagDelete.Text = "删除行";
            this.btnDiagDelete.Click += new System.EventHandler(this.btnDiagDelete_Click);
            // 
            // FrmFirstCaseDiagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 520);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.groupPanel7);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFirstCaseDiagnosis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "患者病案首页诊断";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.groupPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typename;
        private System.Windows.Forms.DataGridViewTextBoxColumn typecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnosename;
        private System.Windows.Forms.DataGridViewTextBoxColumn icd10code;
        private System.Windows.Forms.DataGridViewComboBoxColumn incondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn sicknumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn turnto;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ischinese;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel7;
        private DevComponents.DotNetBar.ButtonX btnCDiagZH;
        private DevComponents.DotNetBar.ButtonX btnCDiagName;
        private DevComponents.DotNetBar.ButtonX btnDiagDown;
        private DevComponents.DotNetBar.ButtonX btnDiagUp;
        private DevComponents.DotNetBar.ButtonX btnDiagSelect;
        private DevComponents.DotNetBar.ButtonX btnDiagInsert;
        private DevComponents.DotNetBar.ButtonX btnDiagDelete;
    }
}