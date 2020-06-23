namespace Base_Function.BLL_NURSE.First_cases
{
    partial class frmSelDiag
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.选择 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.诊断名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.附属诊断 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.病名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.症候 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpatientid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(765, 485);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dataGridViewX1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(765, 459);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.patient_id,
            this.选择,
            this.诊断名称,
            this.编码,
            this.附属诊断});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(763, 457);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellClick);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "西医诊断";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dataGridViewX2);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(765, 459);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFlag,
            this.病名,
            this.cCode,
            this.症候,
            this.cid,
            this.cpatientid});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.RowTemplate.Height = 23;
            this.dataGridViewX2.Size = new System.Drawing.Size(763, 457);
            this.dataGridViewX2.TabIndex = 0;
            this.dataGridViewX2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX2_CellEndEdit);
            this.dataGridViewX2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX2_CellClick);
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "中医诊断";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonX2);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(0, 435);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(765, 50);
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
            this.groupPanel1.TabIndex = 1;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(437, 12);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "取消";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(308, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // patient_id
            // 
            this.patient_id.DataPropertyName = "patient_id";
            this.patient_id.HeaderText = "patient_id";
            this.patient_id.Name = "patient_id";
            this.patient_id.Visible = false;
            // 
            // 选择
            // 
            this.选择.DataPropertyName = "选择";
            this.选择.HeaderText = "选择";
            this.选择.Name = "选择";
            this.选择.Width = 80;
            // 
            // 诊断名称
            // 
            this.诊断名称.DataPropertyName = "诊断名称";
            this.诊断名称.HeaderText = "诊断名称";
            this.诊断名称.Name = "诊断名称";
            this.诊断名称.ReadOnly = true;
            this.诊断名称.Width = 300;
            // 
            // 编码
            // 
            this.编码.DataPropertyName = "编码";
            this.编码.HeaderText = "编码";
            this.编码.Name = "编码";
            // 
            // 附属诊断
            // 
            this.附属诊断.DataPropertyName = "附属诊断";
            this.附属诊断.HeaderText = "附属诊断";
            this.附属诊断.Name = "附属诊断";
            this.附属诊断.ReadOnly = true;
            this.附属诊断.Width = 200;
            // 
            // cFlag
            // 
            this.cFlag.DataPropertyName = "选择";
            this.cFlag.HeaderText = "选择";
            this.cFlag.Name = "cFlag";
            this.cFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cFlag.Width = 80;
            // 
            // 病名
            // 
            this.病名.DataPropertyName = "病名";
            this.病名.HeaderText = "病名";
            this.病名.Name = "病名";
            this.病名.ReadOnly = true;
            this.病名.Width = 300;
            // 
            // cCode
            // 
            this.cCode.DataPropertyName = "编码";
            this.cCode.HeaderText = "编码";
            this.cCode.Name = "cCode";
            // 
            // 症候
            // 
            this.症候.DataPropertyName = "症候";
            this.症候.HeaderText = "症候";
            this.症候.Name = "症候";
            this.症候.ReadOnly = true;
            this.症候.Width = 200;
            // 
            // cid
            // 
            this.cid.DataPropertyName = "cid";
            this.cid.HeaderText = "cid";
            this.cid.Name = "cid";
            this.cid.Visible = false;
            // 
            // cpatientid
            // 
            this.cpatientid.DataPropertyName = "cpatientid";
            this.cpatientid.HeaderText = "cpatientid";
            this.cpatientid.Name = "cpatientid";
            this.cpatientid.Visible = false;
            // 
            // frmSelDiag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 485);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelDiag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "诊断选择";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 选择;
        private System.Windows.Forms.DataGridViewTextBoxColumn 诊断名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 附属诊断;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病名;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn 症候;
        private System.Windows.Forms.DataGridViewTextBoxColumn cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpatientid;


    }
}