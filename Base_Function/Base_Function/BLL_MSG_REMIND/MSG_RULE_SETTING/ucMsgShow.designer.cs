namespace Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING
{
    partial class ucMsgShow
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
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtMsgStatus = new System.Windows.Forms.ComboBox();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new System.Windows.Forms.ComboBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWarnSubstance = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvMsgInfoNew = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel6.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgInfoNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel6
            // 
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.txtMsgStatus);
            this.groupPanel6.Controls.Add(this.btnExport);
            this.groupPanel6.Controls.Add(this.txtName);
            this.groupPanel6.Controls.Add(this.btnSearch);
            this.groupPanel6.Controls.Add(this.label6);
            this.groupPanel6.Controls.Add(this.txtPatientID);
            this.groupPanel6.Controls.Add(this.label5);
            this.groupPanel6.Controls.Add(this.label3);
            this.groupPanel6.Controls.Add(this.dtpEnd);
            this.groupPanel6.Controls.Add(this.labelX5);
            this.groupPanel6.Controls.Add(this.dtpBegin);
            this.groupPanel6.Controls.Add(this.label1);
            this.groupPanel6.Controls.Add(this.cbWarnSubstance);
            this.groupPanel6.Controls.Add(this.label2);
            this.groupPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel6.Location = new System.Drawing.Point(0, 0);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(757, 101);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 21;
            this.groupPanel6.Text = "查询条件";
            // 
            // txtMsgStatus
            // 
            this.txtMsgStatus.FormattingEnabled = true;
            this.txtMsgStatus.Items.AddRange(new object[] {
            "未回复",
            "已回复",
            "需要收条",
            "不需要收条"});
            this.txtMsgStatus.Location = new System.Drawing.Point(301, 44);
            this.txtMsgStatus.Name = "txtMsgStatus";
            this.txtMsgStatus.Size = new System.Drawing.Size(104, 20);
            this.txtMsgStatus.TabIndex = 37;
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(637, 43);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 36;
            this.btnExport.Text = "导出";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtName
            // 
            this.txtName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtName.FormattingEnabled = true;
            this.txtName.Location = new System.Drawing.Point(611, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 20);
            this.txtName.TabIndex = 35;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(556, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(231, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "回复状态:";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(89, 43);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(121, 21);
            this.txtPatientID.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(31, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "患者id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(554, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "发布人:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(427, 9);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(104, 21);
            this.dtpEnd.TabIndex = 25;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(411, 7);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(10, 23);
            this.labelX5.TabIndex = 24;
            this.labelX5.Text = "-";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(301, 9);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(104, 21);
            this.dtpBegin.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(231, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "发布时间:";
            // 
            // cbWarnSubstance
            // 
            this.cbWarnSubstance.FormattingEnabled = true;
            this.cbWarnSubstance.Items.AddRange(new object[] {
            "全部提醒",
            "质控提醒",
            "检验提醒",
            "Pacs检查提醒",
            "状态提醒",
            "体征提醒",
            "医嘱提醒",
            "其他提醒",
            "主动提醒",
            "评分提醒",
            "消息发布提醒"});
            this.cbWarnSubstance.Location = new System.Drawing.Point(89, 8);
            this.cbWarnSubstance.Name = "cbWarnSubstance";
            this.cbWarnSubstance.Size = new System.Drawing.Size(121, 20);
            this.cbWarnSubstance.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "提醒内容:";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvMsgInfoNew);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 101);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(757, 258);
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
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 23;
            this.groupPanel2.Text = "消息显示内容";
            // 
            // dgvMsgInfoNew
            // 
            this.dgvMsgInfoNew.AllowUserToAddRows = false;
            this.dgvMsgInfoNew.AllowUserToDeleteRows = false;
            this.dgvMsgInfoNew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMsgInfoNew.BackgroundColor = System.Drawing.Color.White;
            this.dgvMsgInfoNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMsgInfoNew.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMsgInfoNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMsgInfoNew.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMsgInfoNew.Location = new System.Drawing.Point(0, 0);
            this.dgvMsgInfoNew.Name = "dgvMsgInfoNew";
            this.dgvMsgInfoNew.RowTemplate.Height = 23;
            this.dgvMsgInfoNew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMsgInfoNew.Size = new System.Drawing.Size(751, 234);
            this.dgvMsgInfoNew.TabIndex = 18;
            // 
            // flgview
            // 
            this.flgview.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview.Location = new System.Drawing.Point(0, 0);
            this.flgview.Name = "flgview";
            this.flgview.Rows.DefaultSize = 18;
            this.flgview.Size = new System.Drawing.Size(240, 150);
            this.flgview.TabIndex = 0;
            // 
            // ucMsgShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel6);
            this.Name = "ucMsgShow";
            this.Size = new System.Drawing.Size(757, 359);
            this.Load += new System.EventHandler(this.ucMsgShow_Load);
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgInfoNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flgview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private System.Windows.Forms.ComboBox cbWarnSubstance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMsgInfoNew;
        private System.Windows.Forms.ComboBox txtName;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private System.Windows.Forms.ComboBox txtMsgStatus;
    }
}
