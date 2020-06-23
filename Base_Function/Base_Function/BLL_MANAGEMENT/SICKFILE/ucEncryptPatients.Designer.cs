namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucEncryptPatients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEncryptPatients));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cboDept = new Bifrost.MultiColumnComboBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpInStart = new System.Windows.Forms.DateTimePicker();
            this.chbEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpInEnd = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cboEntryptLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnNo = new System.Windows.Forms.RadioButton();
            this.rtnYes = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dgvDateList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.labID = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.txtSEC_DIRE_NAME = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lvOwernRoles = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cboEntryPtlevSet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelEx1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateList)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tableLayoutPanel1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1085, 55);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(62, 17);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(96, 21);
            this.txtCode.TabIndex = 48;
            // 
            // cboDept
            // 
            this.cboDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDept.AutoComplete = true;
            this.cboDept.AutoDropdown = true;
            this.cboDept.AutoSelectColumn = true;
            this.cboDept.BackColorEven = System.Drawing.Color.White;
            this.cboDept.BackColorOdd = System.Drawing.Color.White;
            this.cboDept.ColumnNames = "section_name";
            this.cboDept.ColumnWidthDefault = 75;
            this.cboDept.ColumnWidths = "120";
            this.cboDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.LinkedColumnIndex = 0;
            this.cboDept.LinkedTextBox = null;
            this.cboDept.Location = new System.Drawing.Point(211, 16);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(96, 22);
            this.cboDept.SqlColumnNameIndex = 0;
            this.cboDept.TabIndex = 57;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dtpInStart);
            this.groupPanel1.Controls.Add(this.chbEnable);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.dtpInEnd);
            this.groupPanel1.Location = new System.Drawing.Point(313, 11);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(327, 32);
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
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 56;
            // 
            // dtpInStart
            // 
            this.dtpInStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpInStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInStart.Location = new System.Drawing.Point(98, 3);
            this.dtpInStart.Name = "dtpInStart";
            this.dtpInStart.Size = new System.Drawing.Size(89, 21);
            this.dtpInStart.TabIndex = 44;
            // 
            // chbEnable
            // 
            // 
            // 
            // 
            this.chbEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbEnable.Location = new System.Drawing.Point(3, 3);
            this.chbEnable.Name = "chbEnable";
            this.chbEnable.Size = new System.Drawing.Size(109, 20);
            this.chbEnable.TabIndex = 27;
            this.chbEnable.Text = "按住院日期：";
            this.chbEnable.CheckedChanged += new System.EventHandler(this.chbEnable_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 45;
            this.label5.Text = "—";
            // 
            // dtpInEnd
            // 
            this.dtpInEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpInEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInEnd.Location = new System.Drawing.Point(216, 3);
            this.dtpInEnd.Name = "dtpInEnd";
            this.dtpInEnd.Size = new System.Drawing.Size(89, 21);
            this.dtpInEnd.TabIndex = 46;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(1002, 15);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(79, 25);
            this.btnQuery.TabIndex = 55;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboEntryptLevel
            // 
            this.cboEntryptLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEntryptLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntryptLevel.FormattingEnabled = true;
            this.cboEntryptLevel.Items.AddRange(new object[] {
            "-请选择-",
            "1",
            "2",
            "3",
            "4"});
            this.cboEntryptLevel.Location = new System.Drawing.Point(907, 17);
            this.cboEntryptLevel.Name = "cboEntryptLevel";
            this.cboEntryptLevel.Size = new System.Drawing.Size(89, 20);
            this.cboEntryptLevel.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(836, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 53;
            this.label4.Text = "加密等级：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbnNo);
            this.groupBox1.Controls.Add(this.rtnYes);
            this.groupBox1.Location = new System.Drawing.Point(717, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 49);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // rbnNo
            // 
            this.rbnNo.AutoSize = true;
            this.rbnNo.Checked = true;
            this.rbnNo.Location = new System.Drawing.Point(59, 17);
            this.rbnNo.Name = "rbnNo";
            this.rbnNo.Size = new System.Drawing.Size(35, 16);
            this.rbnNo.TabIndex = 1;
            this.rbnNo.TabStop = true;
            this.rbnNo.Text = "否";
            this.rbnNo.UseVisualStyleBackColor = true;
            // 
            // rtnYes
            // 
            this.rtnYes.AutoSize = true;
            this.rtnYes.Location = new System.Drawing.Point(9, 17);
            this.rtnYes.Name = "rtnYes";
            this.rtnYes.Size = new System.Drawing.Size(35, 16);
            this.rtnYes.TabIndex = 0;
            this.rtnYes.Text = "是";
            this.rtnYes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "加密状态：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(164, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "科室：";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 47;
            this.label11.Text = "住院号：";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dgvDateList);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 55);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1085, 285);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // dgvDateList
            // 
            this.dgvDateList.AllowUserToAddRows = false;
            this.dgvDateList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDateList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDateList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDateList.Location = new System.Drawing.Point(0, 0);
            this.dgvDateList.Name = "dgvDateList";
            this.dgvDateList.RowTemplate.Height = 23;
            this.dgvDateList.Size = new System.Drawing.Size(1085, 285);
            this.dgvDateList.TabIndex = 1;
            this.dgvDateList.Click += new System.EventHandler(this.dgvDateList_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.labID);
            this.panelEx3.Controls.Add(this.labUserName);
            this.panelEx3.Controls.Add(this.btnCancel);
            this.panelEx3.Controls.Add(this.btnSure);
            this.panelEx3.Controls.Add(this.txtSEC_DIRE_NAME);
            this.panelEx3.Controls.Add(this.label52);
            this.panelEx3.Controls.Add(this.btnDel);
            this.panelEx3.Controls.Add(this.btnAdd);
            this.panelEx3.Controls.Add(this.groupPanel3);
            this.panelEx3.Controls.Add(this.cboEntryPtlevSet);
            this.panelEx3.Controls.Add(this.label6);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3.Location = new System.Drawing.Point(0, 340);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1085, 187);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(239, 116);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(11, 12);
            this.labID.TabIndex = 358;
            this.labID.Text = " ";
            this.labID.Visible = false;
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(239, 84);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(11, 12);
            this.labUserName.TabIndex = 357;
            this.labUserName.Text = " ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(529, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 356;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(362, 144);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(84, 30);
            this.btnSure.TabIndex = 355;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // txtSEC_DIRE_NAME
            // 
            this.txtSEC_DIRE_NAME.Location = new System.Drawing.Point(241, 44);
            this.txtSEC_DIRE_NAME.Name = "txtSEC_DIRE_NAME";
            this.txtSEC_DIRE_NAME.Size = new System.Drawing.Size(88, 21);
            this.txtSEC_DIRE_NAME.TabIndex = 353;
            this.txtSEC_DIRE_NAME.TextChanged += new System.EventHandler(this.txtSEC_DIRE_NAME_TextChanged);
            this.txtSEC_DIRE_NAME.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSEC_DIRE_NAME_KeyUp);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(188, 47);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(47, 12);
            this.label52.TabIndex = 352;
            this.label52.Text = " 工号：";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(362, 73);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 23);
            this.btnDel.TabIndex = 80;
            this.btnDel.Text = "<";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(362, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 23);
            this.btnAdd.TabIndex = 79;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.lvOwernRoles);
            this.groupPanel3.Location = new System.Drawing.Point(432, 6);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(129, 125);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 78;
            this.groupPanel3.Text = "特别用户";
            // 
            // lvOwernRoles
            // 
            this.lvOwernRoles.AutoArrange = false;
            this.lvOwernRoles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvOwernRoles.CheckBoxes = true;
            this.lvOwernRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvOwernRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOwernRoles.Location = new System.Drawing.Point(0, 0);
            this.lvOwernRoles.MultiSelect = false;
            this.lvOwernRoles.Name = "lvOwernRoles";
            this.lvOwernRoles.Size = new System.Drawing.Size(123, 101);
            this.lvOwernRoles.SmallImageList = this.imageList1;
            this.lvOwernRoles.TabIndex = 76;
            this.lvOwernRoles.UseCompatibleStateImageBehavior = false;
            this.lvOwernRoles.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "现有权限列表";
            this.columnHeader2.Width = 193;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "50.ico");
            this.imageList1.Images.SetKeyName(1, "external2.ico");
            this.imageList1.Images.SetKeyName(2, "FILES4~1.ICO");
            // 
            // cboEntryPtlevSet
            // 
            this.cboEntryPtlevSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntryPtlevSet.FormattingEnabled = true;
            this.cboEntryPtlevSet.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cboEntryPtlevSet.Location = new System.Drawing.Point(100, 44);
            this.cboEntryPtlevSet.Name = "cboEntryPtlevSet";
            this.cboEntryPtlevSet.Size = new System.Drawing.Size(53, 20);
            this.cboEntryPtlevSet.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 55;
            this.label6.Text = "加密等级设置：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnQuery, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupPanel1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboEntryptLevel, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboDept, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1085, 55);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // ucEncryptPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Name = "ucEncryptPatients";
            this.Size = new System.Drawing.Size(1085, 527);
            this.Load += new System.EventHandler(this.ucEncryptPatients_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateList)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDateList;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.DateTimePicker dtpInEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpInStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnNo;
        private System.Windows.Forms.RadioButton rtnYes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cboEntryptLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboEntryPtlevSet;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.ListView lvOwernRoles;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSEC_DIRE_NAME;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labID;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbEnable;
        private Bifrost.MultiColumnComboBox cboDept;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
