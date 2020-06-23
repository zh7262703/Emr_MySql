namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    partial class frmScoreResults
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvObjective = new System.Windows.Forms.DataGridView();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.lblPName = new System.Windows.Forms.Label();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvSubjective = new System.Windows.Forms.DataGridView();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblPid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxRemarks = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjective)).BeginInit();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjective)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvObjective);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlPanel2.Size = new System.Drawing.Size(482, 155);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // dgvObjective
            // 
            this.dgvObjective.BackgroundColor = System.Drawing.Color.White;
            this.dgvObjective.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObjective.Location = new System.Drawing.Point(2, 2);
            this.dgvObjective.Name = "dgvObjective";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvObjective.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvObjective.RowTemplate.Height = 23;
            this.dgvObjective.Size = new System.Drawing.Size(478, 151);
            this.dgvObjective.TabIndex = 1;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "客观评分";
            // 
            // lblGrade
            // 
            this.lblGrade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGrade.ForeColor = System.Drawing.Color.Black;
            this.lblGrade.Location = new System.Drawing.Point(273, 87);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(11, 12);
            this.lblGrade.TabIndex = 78;
            this.lblGrade.Text = "1";
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOperatorName.AutoSize = true;
            this.lblOperatorName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperatorName.ForeColor = System.Drawing.Color.Black;
            this.lblOperatorName.Location = new System.Drawing.Point(445, 55);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(11, 12);
            this.lblOperatorName.TabIndex = 77;
            this.lblOperatorName.Text = "1";
            // 
            // lblPName
            // 
            this.lblPName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPName.AutoSize = true;
            this.lblPName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPName.ForeColor = System.Drawing.Color.Black;
            this.lblPName.Location = new System.Drawing.Point(273, 55);
            this.lblPName.Name = "lblPName";
            this.lblPName.Size = new System.Drawing.Size(11, 12);
            this.lblPName.TabIndex = 76;
            this.lblPName.Text = "1";
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "主观评分";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dgvSubjective);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlPanel1.Size = new System.Drawing.Size(482, 155);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // dgvSubjective
            // 
            this.dgvSubjective.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubjective.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubjective.Location = new System.Drawing.Point(2, 2);
            this.dgvSubjective.Name = "dgvSubjective";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSubjective.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubjective.RowTemplate.Height = 23;
            this.dgvSubjective.Size = new System.Drawing.Size(478, 151);
            this.dgvSubjective.TabIndex = 0;
            // 
            // lblScore
            // 
            this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScore.ForeColor = System.Drawing.Color.Black;
            this.lblScore.Location = new System.Drawing.Point(100, 87);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(11, 12);
            this.lblScore.TabIndex = 74;
            this.lblScore.Text = "1";
            // 
            // lblPid
            // 
            this.lblPid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPid.AutoSize = true;
            this.lblPid.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPid.ForeColor = System.Drawing.Color.Black;
            this.lblPid.Location = new System.Drawing.Point(100, 55);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(11, 12);
            this.lblPid.TabIndex = 73;
            this.lblPid.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(180, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "最终评分结果";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rtxRemarks);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(23, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 116);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "评分备注：";
            // 
            // rtxRemarks
            // 
            this.rtxRemarks.BackColor = System.Drawing.Color.White;
            this.rtxRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxRemarks.Enabled = false;
            this.rtxRemarks.Location = new System.Drawing.Point(3, 17);
            this.rtxRemarks.Name = "rtxRemarks";
            this.rtxRemarks.ReadOnly = true;
            this.rtxRemarks.Size = new System.Drawing.Size(479, 96);
            this.rtxRemarks.TabIndex = 0;
            this.rtxRemarks.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(26, 123);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 180);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Flat;
            this.tabControl1.TabIndex = 72;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(34, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 69;
            this.label6.Text = "总扣分：";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(196, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 68;
            this.label5.Text = "病历等级：";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(373, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 67;
            this.label4.Text = "评分人：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 65;
            this.label2.Text = "住院号：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(196, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 66;
            this.label3.Text = "患者姓名：";
            // 
            // frmScoreResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 437);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblOperatorName);
            this.Controls.Add(this.lblPName);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScoreResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "评分结果";
            this.Load += new System.EventHandler(this.frmScoreResults_Load);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjective)).EndInit();
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjective)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.DataGridView dgvObjective;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblOperatorName;
        private System.Windows.Forms.Label lblPName;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.DataGridView dgvSubjective;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtxRemarks;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}