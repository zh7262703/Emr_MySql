namespace Base_Function.BASE_DATA.KBS
{
    partial class frmSelectSection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSick_section = new System.Windows.Forms.ComboBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(186, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(92, 67);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "选择科室：";
            this.label1.Visible = false;
            // 
            // cbxSick_section
            // 
            this.cbxSick_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSick_section.FormattingEnabled = true;
            this.cbxSick_section.Items.AddRange(new object[] {
            "请选择..."});
            this.cbxSick_section.Location = new System.Drawing.Point(92, 27);
            this.cbxSick_section.Name = "cbxSick_section";
            this.cbxSick_section.Size = new System.Drawing.Size(128, 20);
            this.cbxSick_section.TabIndex = 18;
            this.cbxSick_section.Visible = false;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dataGridViewX1);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.Controls.Add(this.panel2);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(375, 351);
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
            this.groupPanel1.TabIndex = 20;
            this.groupPanel1.Text = "科室列表";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 29);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(369, 267);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 31);
            this.panel1.TabIndex = 12;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(203, 5);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(62, 23);
            this.buttonX1.TabIndex = 10;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(114, 5);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(62, 23);
            this.buttonX2.TabIndex = 9;
            this.buttonX2.Text = "确定";
            this.buttonX2.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.chkSection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 29);
            this.panel2.TabIndex = 1;
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.Location = new System.Drawing.Point(18, 7);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(72, 16);
            this.chkSection.TabIndex = 0;
            this.chkSection.Text = "科室全选";
            this.chkSection.UseVisualStyleBackColor = true;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // frmSelectSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 351);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.cbxSick_section);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.Name = "frmSelectSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科室选择";
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbxSick_section;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}