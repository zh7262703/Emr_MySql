namespace Base_Function.TEMPERATURES.ValueSet
{
    partial class frmTemperWrite_BB
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.dateTimePicker_Select = new System.Windows.Forms.DateTimePicker();
            this.lblNotice = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tw11pm = new Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB();
            this.lbl11pm = new System.Windows.Forms.Label();
            this.tw7pm = new Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB();
            this.lbl7pm = new System.Windows.Forms.Label();
            this.tw3pm = new Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB();
            this.label19 = new System.Windows.Forms.Label();
            this.tw11am = new Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB();
            this.label4 = new System.Windows.Forms.Label();
            this.tw7am = new Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB();
            this.label3 = new System.Windows.Forms.Label();
            this.tw3am = new Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboBR = new System.Windows.Forms.ComboBox();
            this.txtQM = new System.Windows.Forms.TextBox();
            this.txtYBQK = new System.Windows.Forms.TextBox();
            this.txtQD = new System.Windows.Forms.TextBox();
            this.txtTZ = new System.Windows.Forms.TextBox();
            this.txtXB = new System.Windows.Forms.TextBox();
            this.txtDBXZ = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDBCS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lshit = new System.Windows.Forms.Label();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(375, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 153;
            this.label8.Text = "日期：";
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(412, 315);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(85, 33);
            this.btnSure.TabIndex = 163;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(503, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 33);
            this.btnCancel.TabIndex = 164;
            this.btnCancel.Text = "退出";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dateTimePicker_Select
            // 
            this.dateTimePicker_Select.Location = new System.Drawing.Point(457, 3);
            this.dateTimePicker_Select.Name = "dateTimePicker_Select";
            this.dateTimePicker_Select.Size = new System.Drawing.Size(132, 21);
            this.dateTimePicker_Select.TabIndex = 165;
            this.dateTimePicker_Select.ValueChanged += new System.EventHandler(this.dateTimePicker_Select_ValueChanged);
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(10, 0);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(65, 12);
            this.lblNotice.TabIndex = 194;
            this.lblNotice.Text = "注意事项：";
            this.lblNotice.Visible = false;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.tw11pm);
            this.groupPanel2.Controls.Add(this.lbl11pm);
            this.groupPanel2.Controls.Add(this.tw7pm);
            this.groupPanel2.Controls.Add(this.lbl7pm);
            this.groupPanel2.Controls.Add(this.tw3pm);
            this.groupPanel2.Controls.Add(this.label19);
            this.groupPanel2.Controls.Add(this.tw11am);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.tw7am);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.tw3am);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 57);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1004, 116);
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
            this.groupPanel2.TabIndex = 195;
            this.groupPanel2.Text = "生命体征";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 98;
            this.label1.Text = "项目/时间";
            // 
            // tw11pm
            // 
            this.tw11pm.BackColor = System.Drawing.Color.Transparent;
            this.tw11pm.CurDateTime = new System.DateTime(((long)(0)));
            this.tw11pm.IsHowTime = 0;
            this.tw11pm.Location = new System.Drawing.Point(821, 25);
            this.tw11pm.Name = "tw11pm";
            this.tw11pm.Painmothed = null;
            this.tw11pm.Size = new System.Drawing.Size(147, 65);
            this.tw11pm.TabIndex = 108;
            // 
            // lbl11pm
            // 
            this.lbl11pm.AutoSize = true;
            this.lbl11pm.BackColor = System.Drawing.Color.Transparent;
            this.lbl11pm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl11pm.Location = new System.Drawing.Point(873, 6);
            this.lbl11pm.Name = "lbl11pm";
            this.lbl11pm.Size = new System.Drawing.Size(53, 16);
            this.lbl11pm.TabIndex = 94;
            this.lbl11pm.Text = "22:00";
            // 
            // tw7pm
            // 
            this.tw7pm.BackColor = System.Drawing.Color.Transparent;
            this.tw7pm.CurDateTime = new System.DateTime(((long)(0)));
            this.tw7pm.IsHowTime = 0;
            this.tw7pm.Location = new System.Drawing.Point(675, 25);
            this.tw7pm.Name = "tw7pm";
            this.tw7pm.Painmothed = null;
            this.tw7pm.Size = new System.Drawing.Size(167, 65);
            this.tw7pm.TabIndex = 107;
            // 
            // lbl7pm
            // 
            this.lbl7pm.AutoSize = true;
            this.lbl7pm.BackColor = System.Drawing.Color.Transparent;
            this.lbl7pm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl7pm.Location = new System.Drawing.Point(730, 6);
            this.lbl7pm.Name = "lbl7pm";
            this.lbl7pm.Size = new System.Drawing.Size(53, 16);
            this.lbl7pm.TabIndex = 93;
            this.lbl7pm.Text = "18:00";
            // 
            // tw3pm
            // 
            this.tw3pm.BackColor = System.Drawing.Color.Transparent;
            this.tw3pm.CurDateTime = new System.DateTime(((long)(0)));
            this.tw3pm.IsHowTime = 0;
            this.tw3pm.Location = new System.Drawing.Point(528, 25);
            this.tw3pm.Name = "tw3pm";
            this.tw3pm.Painmothed = null;
            this.tw3pm.Size = new System.Drawing.Size(162, 65);
            this.tw3pm.TabIndex = 106;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(9, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 97;
            this.label19.Text = "体温(℃)";
            // 
            // tw11am
            // 
            this.tw11am.BackColor = System.Drawing.Color.Transparent;
            this.tw11am.CurDateTime = new System.DateTime(((long)(0)));
            this.tw11am.IsHowTime = 0;
            this.tw11am.Location = new System.Drawing.Point(382, 25);
            this.tw11am.Name = "tw11am";
            this.tw11am.Painmothed = null;
            this.tw11am.Size = new System.Drawing.Size(180, 71);
            this.tw11am.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(592, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 92;
            this.label4.Text = "14:00";
            // 
            // tw7am
            // 
            this.tw7am.BackColor = System.Drawing.Color.Transparent;
            this.tw7am.CurDateTime = new System.DateTime(((long)(0)));
            this.tw7am.IsHowTime = 0;
            this.tw7am.Location = new System.Drawing.Point(237, 25);
            this.tw7am.Name = "tw7am";
            this.tw7am.Painmothed = null;
            this.tw7am.Size = new System.Drawing.Size(163, 65);
            this.tw7am.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(435, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 91;
            this.label3.Text = "10:00";
            // 
            // tw3am
            // 
            this.tw3am.BackColor = System.Drawing.Color.Transparent;
            this.tw3am.CurDateTime = new System.DateTime(((long)(0)));
            this.tw3am.IsHowTime = 0;
            this.tw3am.Location = new System.Drawing.Point(91, 25);
            this.tw3am.Name = "tw3am";
            this.tw3am.Painmothed = null;
            this.tw3am.Size = new System.Drawing.Size(160, 71);
            this.tw3am.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(290, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 90;
            this.label2.Text = "6:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(134, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "2:00";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dateTimePicker_Select);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.lblNotice);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1004, 57);
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
            this.groupPanel1.TabIndex = 196;
            this.groupPanel1.Text = "日期时间";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.cboBR);
            this.groupPanel3.Controls.Add(this.txtQM);
            this.groupPanel3.Controls.Add(this.txtYBQK);
            this.groupPanel3.Controls.Add(this.txtQD);
            this.groupPanel3.Controls.Add(this.txtTZ);
            this.groupPanel3.Controls.Add(this.txtXB);
            this.groupPanel3.Controls.Add(this.txtDBXZ);
            this.groupPanel3.Controls.Add(this.label14);
            this.groupPanel3.Controls.Add(this.txtDBCS);
            this.groupPanel3.Controls.Add(this.label9);
            this.groupPanel3.Controls.Add(this.label11);
            this.groupPanel3.Controls.Add(this.label7);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Controls.Add(this.label13);
            this.groupPanel3.Controls.Add(this.label12);
            this.groupPanel3.Controls.Add(this.lshit);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel3.Location = new System.Drawing.Point(0, 173);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1004, 130);
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
            this.groupPanel3.TabIndex = 198;
            this.groupPanel3.Text = "其他信息";
            // 
            // cboBR
            // 
            this.cboBR.FormattingEnabled = true;
            this.cboBR.Items.AddRange(new object[] {
            "母乳",
            "混合"});
            this.cboBR.Location = new System.Drawing.Point(75, 59);
            this.cboBR.Name = "cboBR";
            this.cboBR.Size = new System.Drawing.Size(128, 20);
            this.cboBR.TabIndex = 138;
            // 
            // txtQM
            // 
            this.txtQM.Location = new System.Drawing.Point(454, 59);
            this.txtQM.Name = "txtQM";
            this.txtQM.Size = new System.Drawing.Size(125, 21);
            this.txtQM.TabIndex = 137;
            // 
            // txtYBQK
            // 
            this.txtYBQK.Location = new System.Drawing.Point(843, 16);
            this.txtYBQK.Name = "txtYBQK";
            this.txtYBQK.Size = new System.Drawing.Size(125, 21);
            this.txtYBQK.TabIndex = 137;
            // 
            // txtQD
            // 
            this.txtQD.Location = new System.Drawing.Point(637, 16);
            this.txtQD.Name = "txtQD";
            this.txtQD.Size = new System.Drawing.Size(125, 21);
            this.txtQD.TabIndex = 137;
            // 
            // txtTZ
            // 
            this.txtTZ.Location = new System.Drawing.Point(275, 59);
            this.txtTZ.Name = "txtTZ";
            this.txtTZ.Size = new System.Drawing.Size(125, 21);
            this.txtTZ.TabIndex = 137;
            // 
            // txtXB
            // 
            this.txtXB.Location = new System.Drawing.Point(454, 16);
            this.txtXB.Name = "txtXB";
            this.txtXB.Size = new System.Drawing.Size(125, 21);
            this.txtXB.TabIndex = 137;
            // 
            // txtDBXZ
            // 
            this.txtDBXZ.Location = new System.Drawing.Point(275, 16);
            this.txtDBXZ.Name = "txtDBXZ";
            this.txtDBXZ.Size = new System.Drawing.Size(125, 21);
            this.txtDBXZ.TabIndex = 137;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(419, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 136;
            this.label14.Text = "签名";
            // 
            // txtDBCS
            // 
            this.txtDBCS.Location = new System.Drawing.Point(75, 16);
            this.txtDBCS.Name = "txtDBCS";
            this.txtDBCS.Size = new System.Drawing.Size(128, 21);
            this.txtDBCS.TabIndex = 137;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(782, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 136;
            this.label9.Text = "一般情况";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(38, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 134;
            this.label11.Text = "哺乳";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(599, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 136;
            this.label7.Text = "脐带";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(216, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 134;
            this.label6.Text = "大便性质";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(237, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 136;
            this.label13.Text = "体重";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(419, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 136;
            this.label12.Text = "小便";
            // 
            // lshit
            // 
            this.lshit.AutoSize = true;
            this.lshit.BackColor = System.Drawing.Color.Transparent;
            this.lshit.Location = new System.Drawing.Point(16, 20);
            this.lshit.Name = "lshit";
            this.lshit.Size = new System.Drawing.Size(53, 12);
            this.lshit.TabIndex = 134;
            this.lshit.Text = "大便次数";
            // 
            // frmTemperWrite_BB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 359);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTemperWrite_BB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体温脉搏信息录入";
            this.Load += new System.EventHandler(this.frmTemperWrite_Load);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Select;
        private System.Windows.Forms.Label lblNotice;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Label label1;
        private Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB tw11pm;
        private System.Windows.Forms.Label lbl11pm;
        private Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB tw7pm;
        private System.Windows.Forms.Label lbl7pm;
        private Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB tw3pm;
        private System.Windows.Forms.Label label19;
        private Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB tw11am;
        private System.Windows.Forms.Label label4;
        private Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB tw7am;
        private System.Windows.Forms.Label label3;
        private Base_Function.BLL_NURSE.Tempreture_Management.TemperWrite_BB tw3am;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lshit;
        private System.Windows.Forms.TextBox txtDBXZ;
        private System.Windows.Forms.TextBox txtDBCS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXB;
        private System.Windows.Forms.TextBox txtYBQK;
        private System.Windows.Forms.TextBox txtQD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtQM;
        private System.Windows.Forms.TextBox txtTZ;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboBR;
    }
}