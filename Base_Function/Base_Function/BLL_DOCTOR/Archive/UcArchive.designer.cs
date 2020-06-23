namespace Base_Function.BLL_DOCTOR.Archive
{
    partial class UcArchive
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
            this.flgView = new Bifrost.ucC1FlexGrid();
            this.dtpArchive_Time = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.gbxSelect = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkYgdbr = new System.Windows.Forms.CheckBox();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainerBody = new System.Windows.Forms.SplitContainer();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnFan = new DevComponents.DotNetBar.ButtonX();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnAll = new DevComponents.DotNetBar.ButtonX();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.gbxSelect.SuspendLayout();
            this.splitContainerBody.Panel1.SuspendLayout();
            this.splitContainerBody.Panel2.SuspendLayout();
            this.splitContainerBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // flgView
            // 
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Size = new System.Drawing.Size(856, 431);
            this.flgView.TabIndex = 1;
            // 
            // dtpArchive_Time
            // 
            this.dtpArchive_Time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpArchive_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArchive_Time.Location = new System.Drawing.Point(66, 6);
            this.dtpArchive_Time.Name = "dtpArchive_Time";
            this.dtpArchive_Time.Size = new System.Drawing.Size(141, 21);
            this.dtpArchive_Time.TabIndex = 1;
            this.dtpArchive_Time.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "归档时间：";
            this.label5.Visible = false;
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop.Name = "splitContainerTop";
            this.splitContainerTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTop.Panel1
            // 
            this.splitContainerTop.Panel1.Controls.Add(this.gbxSelect);
            // 
            // splitContainerTop.Panel2
            // 
            this.splitContainerTop.Panel2.Controls.Add(this.flgView);
            this.splitContainerTop.Size = new System.Drawing.Size(856, 492);
            this.splitContainerTop.SplitterDistance = 57;
            this.splitContainerTop.TabIndex = 0;
            // 
            // gbxSelect
            // 
            this.gbxSelect.CanvasColor = System.Drawing.SystemColors.Control;
            this.gbxSelect.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gbxSelect.Controls.Add(this.chkYgdbr);
            this.gbxSelect.Controls.Add(this.btnSelect);
            this.gbxSelect.Controls.Add(this.label2);
            this.gbxSelect.Controls.Add(this.dateTimePicker1);
            this.gbxSelect.Controls.Add(this.dtpStart);
            this.gbxSelect.Controls.Add(this.label1);
            this.gbxSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSelect.Location = new System.Drawing.Point(0, 0);
            this.gbxSelect.Name = "gbxSelect";
            this.gbxSelect.Size = new System.Drawing.Size(856, 57);
            // 
            // 
            // 
            this.gbxSelect.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gbxSelect.Style.BackColorGradientAngle = 90;
            this.gbxSelect.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gbxSelect.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxSelect.Style.BorderBottomWidth = 1;
            this.gbxSelect.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gbxSelect.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxSelect.Style.BorderLeftWidth = 1;
            this.gbxSelect.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxSelect.Style.BorderRightWidth = 1;
            this.gbxSelect.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxSelect.Style.BorderTopWidth = 1;
            this.gbxSelect.Style.CornerDiameter = 4;
            this.gbxSelect.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gbxSelect.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gbxSelect.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gbxSelect.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gbxSelect.TabIndex = 1;
            this.gbxSelect.Text = "查询";
            // 
            // chkYgdbr
            // 
            this.chkYgdbr.AutoSize = true;
            this.chkYgdbr.Location = new System.Drawing.Point(344, 5);
            this.chkYgdbr.Name = "chkYgdbr";
            this.chkYgdbr.Size = new System.Drawing.Size(96, 16);
            this.chkYgdbr.TabIndex = 10;
            this.chkYgdbr.Text = "已归档的病人";
            this.chkYgdbr.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(446, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(178, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(192, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(35, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(-1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期：";
            // 
            // splitContainerBody
            // 
            this.splitContainerBody.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBody.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBody.Name = "splitContainerBody";
            this.splitContainerBody.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBody.Panel1
            // 
            this.splitContainerBody.Panel1.Controls.Add(this.splitContainerTop);
            // 
            // splitContainerBody.Panel2
            // 
            this.splitContainerBody.Panel2.Controls.Add(this.btnSave);
            this.splitContainerBody.Panel2.Controls.Add(this.btnFan);
            this.splitContainerBody.Panel2.Controls.Add(this.btnNo);
            this.splitContainerBody.Panel2.Controls.Add(this.btnAll);
            this.splitContainerBody.Panel2.Controls.Add(this.txtOperator);
            this.splitContainerBody.Panel2.Controls.Add(this.label4);
            this.splitContainerBody.Panel2.Controls.Add(this.dtpArchive_Time);
            this.splitContainerBody.Panel2.Controls.Add(this.label5);
            this.splitContainerBody.Size = new System.Drawing.Size(856, 643);
            this.splitContainerBody.SplitterDistance = 492;
            this.splitContainerBody.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(540, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "归档封存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFan
            // 
            this.btnFan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFan.Location = new System.Drawing.Point(324, 53);
            this.btnFan.Name = "btnFan";
            this.btnFan.Size = new System.Drawing.Size(100, 40);
            this.btnFan.TabIndex = 9;
            this.btnFan.Text = "反选";
            this.btnFan.Click += new System.EventHandler(this.btnFan_Click);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.Location = new System.Drawing.Point(432, 53);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(100, 40);
            this.btnNo.TabIndex = 9;
            this.btnNo.Text = "不选";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnAll
            // 
            this.btnAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAll.Location = new System.Drawing.Point(216, 53);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(100, 40);
            this.btnAll.TabIndex = 9;
            this.btnAll.Text = "全选";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(320, 6);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(100, 21);
            this.txtOperator.TabIndex = 8;
            this.txtOperator.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "归档封存操作者：";
            this.label4.Visible = false;
            // 
            // UcArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerBody);
            this.Name = "UcArchive";
            this.Size = new System.Drawing.Size(856, 643);
            this.Load += new System.EventHandler(this.UcArchive_Load);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.ResumeLayout(false);
            this.gbxSelect.ResumeLayout(false);
            this.gbxSelect.PerformLayout();
            this.splitContainerBody.Panel1.ResumeLayout(false);
            this.splitContainerBody.Panel2.ResumeLayout(false);
            this.splitContainerBody.Panel2.PerformLayout();
            this.splitContainerBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bifrost.ucC1FlexGrid flgView;
        private System.Windows.Forms.DateTimePicker dtpArchive_Time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainerBody;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.GroupPanel gbxSelect;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnFan;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnAll;
        private System.Windows.Forms.CheckBox chkYgdbr;
    }
}
