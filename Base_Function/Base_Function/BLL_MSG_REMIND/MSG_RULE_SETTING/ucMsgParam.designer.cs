namespace Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING
{
    partial class ucMsgParam
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabItem22 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMsgInfoNew = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSG_SECTION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wARNTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WARN_TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSG_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSG_BORDER_VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSGSECTION_ID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MSG_VOLUNTARILY_POP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MSG_START_UP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.T_MSG_sETTINGbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dstMsg_Setting = new Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING.dstMsg_Setting();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgInfoNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_MSG_sETTINGbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstMsg_Setting)).BeginInit();
            this.SuspendLayout();
            // 
            // tabItem22
            // 
            this.tabItem22.Name = "tabItem22";
            this.tabItem22.Text = "医务处调度参数";
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "医务处调度参数";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 41);
            this.panel1.TabIndex = 59;
            // 
            // btnSend
            // 
            this.btnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSend.Location = new System.Drawing.Point(385, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "保存";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMsgInfoNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(844, 434);
            this.panel2.TabIndex = 60;
            // 
            // dgvMsgInfoNew
            // 
            this.dgvMsgInfoNew.AllowUserToAddRows = false;
            this.dgvMsgInfoNew.AllowUserToDeleteRows = false;
            this.dgvMsgInfoNew.AutoGenerateColumns = false;
            this.dgvMsgInfoNew.BackgroundColor = System.Drawing.Color.White;
            this.dgvMsgInfoNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsgInfoNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MSG_SECTION_NAME,
            this.wARNTYPEDataGridViewTextBoxColumn,
            this.WARN_TYPE_NAME,
            this.MSG_TYPE,
            this.MSG_BORDER_VALUE,
            this.MSGSECTION_ID,
            this.MSG_VOLUNTARILY_POP,
            this.MSG_START_UP});
            this.dgvMsgInfoNew.DataSource = this.T_MSG_sETTINGbindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMsgInfoNew.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMsgInfoNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMsgInfoNew.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMsgInfoNew.Location = new System.Drawing.Point(0, 0);
            this.dgvMsgInfoNew.Name = "dgvMsgInfoNew";
            this.dgvMsgInfoNew.RowTemplate.Height = 23;
            this.dgvMsgInfoNew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMsgInfoNew.Size = new System.Drawing.Size(844, 434);
            this.dgvMsgInfoNew.TabIndex = 18;
            this.dgvMsgInfoNew.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMsgInfoNew_CellFormatting);
            this.dgvMsgInfoNew.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvMsgInfoNew_RowStateChanged);
            this.dgvMsgInfoNew.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMsgInfoNew_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // MSG_SECTION_NAME
            // 
            this.MSG_SECTION_NAME.DataPropertyName = "MSG_SECTION_NAME";
            this.MSG_SECTION_NAME.HeaderText = "MSG_SECTION_NAME";
            this.MSG_SECTION_NAME.Name = "MSG_SECTION_NAME";
            this.MSG_SECTION_NAME.ReadOnly = true;
            this.MSG_SECTION_NAME.Visible = false;
            // 
            // wARNTYPEDataGridViewTextBoxColumn
            // 
            this.wARNTYPEDataGridViewTextBoxColumn.DataPropertyName = "WARN_TYPE";
            this.wARNTYPEDataGridViewTextBoxColumn.HeaderText = "WARN_TYPE";
            this.wARNTYPEDataGridViewTextBoxColumn.Name = "wARNTYPEDataGridViewTextBoxColumn";
            this.wARNTYPEDataGridViewTextBoxColumn.Visible = false;
            // 
            // WARN_TYPE_NAME
            // 
            this.WARN_TYPE_NAME.DataPropertyName = "WARN_TYPE_NAME";
            this.WARN_TYPE_NAME.HeaderText = "类型提醒名称";
            this.WARN_TYPE_NAME.Name = "WARN_TYPE_NAME";
            // 
            // MSG_TYPE
            // 
            this.MSG_TYPE.DataPropertyName = "MSG_TYPE";
            this.MSG_TYPE.HeaderText = "消息类型";
            this.MSG_TYPE.Name = "MSG_TYPE";
            this.MSG_TYPE.Width = 200;
            // 
            // MSG_BORDER_VALUE
            // 
            this.MSG_BORDER_VALUE.DataPropertyName = "MSG_BORDER_VALUE";
            this.MSG_BORDER_VALUE.HeaderText = "消息提醒界限值";
            this.MSG_BORDER_VALUE.Name = "MSG_BORDER_VALUE";
            this.MSG_BORDER_VALUE.Width = 200;
            // 
            // MSGSECTION_ID
            // 
            this.MSGSECTION_ID.HeaderText = "启用科室";
            this.MSGSECTION_ID.Name = "MSGSECTION_ID";
            this.MSGSECTION_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MSGSECTION_ID.Text = "显示科室";
            this.MSGSECTION_ID.UseColumnTextForButtonValue = true;
            // 
            // MSG_VOLUNTARILY_POP
            // 
            this.MSG_VOLUNTARILY_POP.DataPropertyName = "MSG_VOLUNTARILY_POP";
            this.MSG_VOLUNTARILY_POP.HeaderText = "自动弹出";
            this.MSG_VOLUNTARILY_POP.Name = "MSG_VOLUNTARILY_POP";
            // 
            // MSG_START_UP
            // 
            this.MSG_START_UP.DataPropertyName = "MSG_START_UP";
            this.MSG_START_UP.HeaderText = "启动";
            this.MSG_START_UP.Name = "MSG_START_UP";
            // 
            // T_MSG_sETTINGbindingSource
            // 
            this.T_MSG_sETTINGbindingSource.DataMember = "t_msg_setting";
            this.T_MSG_sETTINGbindingSource.DataSource = this.dstMsg_Setting;
            // 
            // dstMsg_Setting
            // 
            this.dstMsg_Setting.DataSetName = "dstMsg_Setting";
            this.dstMsg_Setting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucMsgParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucMsgParam";
            this.Size = new System.Drawing.Size(844, 475);
            this.Load += new System.EventHandler(this.ucMsgParam_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgInfoNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_MSG_sETTINGbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstMsg_Setting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabItem tabItem22;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnSend;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMsgInfoNew;
        private System.Windows.Forms.BindingSource T_MSG_sETTINGbindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn mSGSECTIONDataGridViewTextBoxColumn;
        //private DstMsg_Setting dstMsg_Setting;
        private System.Windows.Forms.DataGridViewTextBoxColumn wARNTYPENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mSGTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mSGBORDERVALUEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn mSGSECTIONIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mSGVOLUNTARILYPOPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mSGSTARTUPDataGridViewTextBoxColumn;
        private dstMsg_Setting dstMsg_Setting;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSG_SECTION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn wARNTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WARN_TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSG_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSG_BORDER_VALUE;
        private System.Windows.Forms.DataGridViewButtonColumn MSGSECTION_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MSG_VOLUNTARILY_POP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MSG_START_UP;
    }
}
