using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class MedicalRecordCatalogue
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_pid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbxTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.multiColumnComboBox_State = new Bifrost.MultiColumnComboBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbxInSection = new Bifrost.MultiColumnComboBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.cbx_selectTime = new System.Windows.Forms.ComboBox();
            this.btn_println = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_Name = new Bifrost.MultiColumnComboBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.tableLayoutPanel1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1432, 64);
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
            this.groupPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.Controls.Add(this.txt_pid, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxTime, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.multiColumnComboBox_State, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxInSection, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 13, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpEndTime, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX5, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpStartTime, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbx_selectTime, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_println, 14, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_Name, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1426, 59);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // txt_pid
            // 
            this.txt_pid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txt_pid.Border.Class = "TextBoxBorder";
            this.txt_pid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_pid.Location = new System.Drawing.Point(628, 17);
            this.txt_pid.Margin = new System.Windows.Forms.Padding(4);
            this.txt_pid.Name = "txt_pid";
            this.txt_pid.Size = new System.Drawing.Size(102, 25);
            this.txt_pid.TabIndex = 27;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(4, 17);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(54, 24);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "状态：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbxTime
            // 
            this.cbxTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTime.AutoSize = true;
            this.cbxTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbxTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbxTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTime.Location = new System.Drawing.Point(738, 17);
            this.cbxTime.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.Size = new System.Drawing.Size(58, 24);
            this.cbxTime.TabIndex = 11;
            this.cbxTime.Text = "时间";
            this.cbxTime.CheckedChanged += new System.EventHandler(this.cbxTime_CheckedChanged);
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(551, 17);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(69, 24);
            this.labelX3.TabIndex = 24;
            this.labelX3.Text = "住院号：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // multiColumnComboBox_State
            // 
            this.multiColumnComboBox_State.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.multiColumnComboBox_State.AutoComplete = true;
            this.multiColumnComboBox_State.AutoDropdown = true;
            this.multiColumnComboBox_State.AutoSelectColumn = true;
            this.multiColumnComboBox_State.BackColorEven = System.Drawing.Color.White;
            this.multiColumnComboBox_State.BackColorOdd = System.Drawing.Color.White;
            this.multiColumnComboBox_State.ColumnNames = "name";
            this.multiColumnComboBox_State.ColumnWidthDefault = 75;
            this.multiColumnComboBox_State.ColumnWidths = "100";
            this.multiColumnComboBox_State.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.multiColumnComboBox_State.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.multiColumnComboBox_State.FormattingEnabled = true;
            this.multiColumnComboBox_State.LinkedColumnIndex = 0;
            this.multiColumnComboBox_State.LinkedTextBox = null;
            this.multiColumnComboBox_State.Location = new System.Drawing.Point(66, 15);
            this.multiColumnComboBox_State.Margin = new System.Windows.Forms.Padding(4);
            this.multiColumnComboBox_State.Name = "multiColumnComboBox_State";
            this.multiColumnComboBox_State.Size = new System.Drawing.Size(102, 28);
            this.multiColumnComboBox_State.SqlColumnNameIndex = 0;
            this.multiColumnComboBox_State.TabIndex = 23;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(176, 17);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(54, 24);
            this.labelX2.TabIndex = 15;
            this.labelX2.Text = "科室：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbxInSection
            // 
            this.cbxInSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxInSection.AutoComplete = true;
            this.cbxInSection.AutoDropdown = true;
            this.cbxInSection.AutoSelectColumn = true;
            this.cbxInSection.BackColorEven = System.Drawing.Color.White;
            this.cbxInSection.BackColorOdd = System.Drawing.Color.White;
            this.cbxInSection.ColumnNames = "section_name";
            this.cbxInSection.ColumnWidthDefault = 75;
            this.cbxInSection.ColumnWidths = "100";
            this.cbxInSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxInSection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxInSection.FormattingEnabled = true;
            this.cbxInSection.LinkedColumnIndex = 0;
            this.cbxInSection.LinkedTextBox = null;
            this.cbxInSection.Location = new System.Drawing.Point(238, 15);
            this.cbxInSection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxInSection.Name = "cbxInSection";
            this.cbxInSection.Size = new System.Drawing.Size(102, 28);
            this.cbxInSection.SqlColumnNameIndex = 0;
            this.cbxInSection.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(1233, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 29);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(1109, 16);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(116, 27);
            this.dtpEndTime.TabIndex = 13;
            // 
            // labelX5
            // 
            this.labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(1097, 16);
            this.labelX5.Margin = new System.Windows.Forms.Padding(4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(4, 26);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "-";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(972, 16);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(117, 27);
            this.dtpStartTime.TabIndex = 12;
            // 
            // cbx_selectTime
            // 
            this.cbx_selectTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_selectTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_selectTime.Enabled = false;
            this.cbx_selectTime.FormattingEnabled = true;
            this.cbx_selectTime.Items.AddRange(new object[] {
            "入院时间",
            "出院时间",
            "编目时间"});
            this.cbx_selectTime.Location = new System.Drawing.Point(804, 18);
            this.cbx_selectTime.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_selectTime.Name = "cbx_selectTime";
            this.cbx_selectTime.Size = new System.Drawing.Size(160, 23);
            this.cbx_selectTime.TabIndex = 28;
            // 
            // btn_println
            // 
            this.btn_println.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_println.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_println.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_println.Enabled = false;
            this.btn_println.Location = new System.Drawing.Point(1333, 15);
            this.btn_println.Margin = new System.Windows.Forms.Padding(4);
            this.btn_println.Name = "btn_println";
            this.btn_println.Size = new System.Drawing.Size(89, 29);
            this.btn_println.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_println.TabIndex = 29;
            this.btn_println.Text = "打印";
            this.btn_println.Visible = false;
            this.btn_println.Click += new System.EventHandler(this.btn_println_Click);
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(348, 17);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(85, 24);
            this.labelX4.TabIndex = 25;
            this.labelX4.Text = "病人姓名：";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.AutoComplete = true;
            this.txt_Name.AutoDropdown = true;
            this.txt_Name.AutoSelectColumn = true;
            this.txt_Name.BackColorEven = System.Drawing.Color.White;
            this.txt_Name.BackColorOdd = System.Drawing.Color.White;
            this.txt_Name.ColumnNames = "patient_name";
            this.txt_Name.ColumnWidthDefault = 75;
            this.txt_Name.ColumnWidths = "100";
            this.txt_Name.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txt_Name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Name.FormattingEnabled = true;
            this.txt_Name.LinkedColumnIndex = 0;
            this.txt_Name.LinkedTextBox = null;
            this.txt_Name.Location = new System.Drawing.Point(441, 15);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(102, 28);
            this.txt_Name.SqlColumnNameIndex = 0;
            this.txt_Name.TabIndex = 23;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 64);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1432, 470);
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
            this.groupPanel2.TabIndex = 3;
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.AutoSize = true;
            this.ucGridviewX1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(1426, 464);
            this.ucGridviewX1.TabIndex = 0;
            this.ucGridviewX1.Click += new System.EventHandler(this.ucGridviewX1_Click);
            this.ucGridviewX1.DoubleClick += new System.EventHandler(this.ucGridviewX1_DoubleClick);
            // 
            // MedicalRecordCatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MedicalRecordCatalogue";
            this.Size = new System.Drawing.Size(1432, 534);
            this.groupPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbxTime;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private Bifrost.ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private MultiColumnComboBox multiColumnComboBox_State;
        private Bifrost.MultiColumnComboBox cbxInSection;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_pid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbx_selectTime;
        private DevComponents.DotNetBar.ButtonX btn_println;
        private Bifrost.MultiColumnComboBox txt_Name;



    }
}
