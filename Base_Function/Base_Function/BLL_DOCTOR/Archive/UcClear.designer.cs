namespace Base_Function.BLL_DOCTOR.Archive
{
    partial class UcClear
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
            this.splitContainerBody = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.gbxSelect = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flgView = new Bifrost.ucC1FlexGrid();
            this.btnBatch = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.dtpArchive_Time = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainerBody.Panel1.SuspendLayout();
            this.splitContainerBody.Panel2.SuspendLayout();
            this.splitContainerBody.SuspendLayout();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.gbxSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerBody
            // 
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
            this.splitContainerBody.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerBody.Panel2.Controls.Add(this.btnBatch);
            this.splitContainerBody.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerBody.Panel2.Controls.Add(this.btnOk);
            this.splitContainerBody.Panel2.Controls.Add(this.dtpArchive_Time);
            this.splitContainerBody.Panel2.Controls.Add(this.label5);
            this.splitContainerBody.Size = new System.Drawing.Size(867, 623);
            this.splitContainerBody.SplitterDistance = 477;
            this.splitContainerBody.TabIndex = 0;
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
            this.splitContainerTop.Size = new System.Drawing.Size(867, 477);
            this.splitContainerTop.SplitterDistance = 56;
            this.splitContainerTop.TabIndex = 0;
            // 
            // gbxSelect
            // 
            this.gbxSelect.BackColor = System.Drawing.Color.Transparent;
            this.gbxSelect.CanvasColor = System.Drawing.SystemColors.Control;
            this.gbxSelect.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gbxSelect.Controls.Add(this.btnSelect);
            this.gbxSelect.Controls.Add(this.dtpStart);
            this.gbxSelect.Controls.Add(this.cbxState);
            this.gbxSelect.Controls.Add(this.label1);
            this.gbxSelect.Controls.Add(this.label4);
            this.gbxSelect.Controls.Add(this.dtpEnd);
            this.gbxSelect.Controls.Add(this.txtPid);
            this.gbxSelect.Controls.Add(this.label2);
            this.gbxSelect.Controls.Add(this.label3);
            this.gbxSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSelect.Location = new System.Drawing.Point(0, 0);
            this.gbxSelect.Name = "gbxSelect";
            this.gbxSelect.Size = new System.Drawing.Size(867, 56);
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
            this.gbxSelect.TabIndex = 0;
            this.gbxSelect.Text = "查询";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(720, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(61, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 1;
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Items.AddRange(new object[] {
            "--请选择--",
            "已整理",
            "未整理"});
            this.cbxState.Location = new System.Drawing.Point(627, 2);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(87, 20);
            this.cbxState.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "离院日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(565, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "归档状态：";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(218, 2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(141, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(445, 2);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(88, 21);
            this.txtPid.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(204, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(395, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "住院号：";
            // 
            // flgView
            // 
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Size = new System.Drawing.Size(867, 417);
            this.flgView.TabIndex = 1;
            // 
            // btnBatch
            // 
            this.btnBatch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBatch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBatch.Location = new System.Drawing.Point(497, 51);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(100, 40);
            this.btnBatch.TabIndex = 3;
            this.btnBatch.Text = "批量整理";
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(383, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消整理";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(269, 51);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确认整理";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dtpArchive_Time
            // 
            this.dtpArchive_Time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpArchive_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArchive_Time.Location = new System.Drawing.Point(72, 15);
            this.dtpArchive_Time.Name = "dtpArchive_Time";
            this.dtpArchive_Time.Size = new System.Drawing.Size(116, 21);
            this.dtpArchive_Time.TabIndex = 1;
            this.dtpArchive_Time.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "归档时间：";
            this.label5.Visible = false;
            // 
            // UcClear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerBody);
            this.Name = "UcClear";
            this.Size = new System.Drawing.Size(867, 623);
            this.Load += new System.EventHandler(this.UcClear_Load);
            this.splitContainerBody.Panel1.ResumeLayout(false);
            this.splitContainerBody.Panel2.ResumeLayout(false);
            this.splitContainerBody.Panel2.PerformLayout();
            this.splitContainerBody.ResumeLayout(false);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.ResumeLayout(false);
            this.gbxSelect.ResumeLayout(false);
            this.gbxSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerBody;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label4;
        private Bifrost.ucC1FlexGrid flgView;
        private System.Windows.Forms.DateTimePicker dtpArchive_Time;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.GroupPanel gbxSelect;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnBatch;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
    }
}
