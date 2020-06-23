namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    partial class TemperWrite
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
            this.cbAddEvent = new System.Windows.Forms.ComboBox();
            this.txtBreathing = new System.Windows.Forms.TextBox();
            this.cbTemperType = new System.Windows.Forms.ComboBox();
            this.txtTemper = new System.Windows.Forms.TextBox();
            this.ckHeartRate = new System.Windows.Forms.CheckBox();
            this.ckChu = new System.Windows.Forms.CheckBox();
            this.cbReiteration = new System.Windows.Forms.CheckBox();
            this.txtHeart = new System.Windows.Forms.TextBox();
            this.txtPulse = new System.Windows.Forms.TextBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbEvents = new System.Windows.Forms.ListBox();
            this.dtpAddEventTime = new System.Windows.Forms.DateTimePicker();
            this.dtpSurgeryEndTime = new System.Windows.Forms.DateTimePicker();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.btnAddEvent = new DevComponents.DotNetBar.ButtonX();
            this.ckBreath = new System.Windows.Forms.CheckBox();
            this.txtPainGrades = new System.Windows.Forms.TextBox();
            this.cboPainGradesMothed = new System.Windows.Forms.ComboBox();
            this.txtPainGrades2 = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPainGradesMothedQX = new System.Windows.Forms.ComboBox();
            this.cbTemperTypeQX = new System.Windows.Forms.ComboBox();
            this.txtPainGrades2QX = new System.Windows.Forms.TextBox();
            this.txtPulseQX = new System.Windows.Forms.TextBox();
            this.txtPainGradesQX = new System.Windows.Forms.TextBox();
            this.txtHeartQX = new System.Windows.Forms.TextBox();
            this.ckBreathQX = new System.Windows.Forms.CheckBox();
            this.cbReiterationQX = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckChuQX = new System.Windows.Forms.CheckBox();
            this.txtDownQX = new System.Windows.Forms.TextBox();
            this.ckHeartRateQX = new System.Windows.Forms.CheckBox();
            this.txtBreathingQX = new System.Windows.Forms.TextBox();
            this.txtTemperQX = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAddEvent
            // 
            this.cbAddEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddEvent.FormattingEnabled = true;
            this.cbAddEvent.Items.AddRange(new object[] {
            "--请选择--",
            "入院",
            "转入",
            "转出",
            "手术",
            "分娩",
            "出院",
            "死亡",
            "回室",
            "回家待产",
            "返院待产",
            "回家待术",
            "返院待术"});
            this.cbAddEvent.Location = new System.Drawing.Point(5, 221);
            this.cbAddEvent.Name = "cbAddEvent";
            this.cbAddEvent.Size = new System.Drawing.Size(103, 20);
            this.cbAddEvent.TabIndex = 23;
            this.cbAddEvent.SelectedIndexChanged += new System.EventHandler(this.cbAddEvent_SelectedIndexChanged);
            // 
            // txtBreathing
            // 
            this.txtBreathing.Location = new System.Drawing.Point(5, 139);
            this.txtBreathing.MaxLength = 3;
            this.txtBreathing.Name = "txtBreathing";
            this.txtBreathing.ShortcutsEnabled = false;
            this.txtBreathing.Size = new System.Drawing.Size(39, 21);
            this.txtBreathing.TabIndex = 7;
            this.txtBreathing.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtBreathing.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtBreathing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // cbTemperType
            // 
            this.cbTemperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemperType.FormattingEnabled = true;
            this.cbTemperType.Items.AddRange(new object[] {
            "腋表",
            "口表",
            "肛表"});
            this.cbTemperType.Location = new System.Drawing.Point(5, 28);
            this.cbTemperType.Name = "cbTemperType";
            this.cbTemperType.Size = new System.Drawing.Size(72, 20);
            this.cbTemperType.TabIndex = 1;
            this.cbTemperType.SelectedIndexChanged += new System.EventHandler(this.cbTemperType_SelectedIndexChanged);
            // 
            // txtTemper
            // 
            this.txtTemper.Location = new System.Drawing.Point(5, 55);
            this.txtTemper.MaxLength = 4;
            this.txtTemper.Name = "txtTemper";
            this.txtTemper.ShortcutsEnabled = false;
            this.txtTemper.Size = new System.Drawing.Size(39, 21);
            this.txtTemper.TabIndex = 2;
            this.txtTemper.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtTemper.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtTemper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInput_KeyPress);
            // 
            // ckHeartRate
            // 
            this.ckHeartRate.AutoSize = true;
            this.ckHeartRate.Enabled = false;
            this.ckHeartRate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckHeartRate.Location = new System.Drawing.Point(46, 168);
            this.ckHeartRate.Name = "ckHeartRate";
            this.ckHeartRate.Size = new System.Drawing.Size(39, 21);
            this.ckHeartRate.TabIndex = 10;
            this.ckHeartRate.Text = "Ⓗ";
            this.ckHeartRate.UseVisualStyleBackColor = true;
            // 
            // ckChu
            // 
            this.ckChu.AutoSize = true;
            this.ckChu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckChu.Location = new System.Drawing.Point(46, 112);
            this.ckChu.Name = "ckChu";
            this.ckChu.Size = new System.Drawing.Size(39, 21);
            this.ckChu.TabIndex = 6;
            this.ckChu.Text = "绌";
            this.ckChu.UseVisualStyleBackColor = true;
            this.ckChu.CheckedChanged += new System.EventHandler(this.ckChu_CheckedChanged);
            // 
            // cbReiteration
            // 
            this.cbReiteration.AutoSize = true;
            this.cbReiteration.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbReiteration.Location = new System.Drawing.Point(46, 57);
            this.cbReiteration.Name = "cbReiteration";
            this.cbReiteration.Size = new System.Drawing.Size(36, 21);
            this.cbReiteration.TabIndex = 3;
            this.cbReiteration.Text = "∨";
            this.cbReiteration.UseVisualStyleBackColor = true;
            // 
            // txtHeart
            // 
            this.txtHeart.Enabled = false;
            this.txtHeart.Location = new System.Drawing.Point(5, 167);
            this.txtHeart.MaxLength = 3;
            this.txtHeart.Name = "txtHeart";
            this.txtHeart.ShortcutsEnabled = false;
            this.txtHeart.Size = new System.Drawing.Size(39, 21);
            this.txtHeart.TabIndex = 9;
            this.txtHeart.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtHeart.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtHeart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // txtPulse
            // 
            this.txtPulse.Location = new System.Drawing.Point(5, 111);
            this.txtPulse.MaxLength = 3;
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.ShortcutsEnabled = false;
            this.txtPulse.Size = new System.Drawing.Size(39, 21);
            this.txtPulse.TabIndex = 5;
            this.txtPulse.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtPulse.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtPulse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(5, 83);
            this.txtDown.Name = "txtDown";
            this.txtDown.ShortcutsEnabled = false;
            this.txtDown.Size = new System.Drawing.Size(39, 21);
            this.txtDown.TabIndex = 4;
            this.txtDown.Visible = false;
            this.txtDown.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtDown.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInput_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(46, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 104;
            this.label1.Text = "↓";
            this.label1.Visible = false;
            // 
            // lbEvents
            // 
            this.lbEvents.FormattingEnabled = true;
            this.lbEvents.ItemHeight = 12;
            this.lbEvents.Location = new System.Drawing.Point(5, 304);
            this.lbEvents.Name = "lbEvents";
            this.lbEvents.Size = new System.Drawing.Size(155, 40);
            this.lbEvents.TabIndex = 28;
            // 
            // dtpAddEventTime
            // 
            this.dtpAddEventTime.CustomFormat = "HH:mm";
            this.dtpAddEventTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAddEventTime.Location = new System.Drawing.Point(5, 248);
            this.dtpAddEventTime.Name = "dtpAddEventTime";
            this.dtpAddEventTime.ShowUpDown = true;
            this.dtpAddEventTime.Size = new System.Drawing.Size(154, 21);
            this.dtpAddEventTime.TabIndex = 26;
            this.dtpAddEventTime.Value = new System.DateTime(2010, 6, 13, 0, 0, 0, 0);
            // 
            // dtpSurgeryEndTime
            // 
            this.dtpSurgeryEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpSurgeryEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSurgeryEndTime.Location = new System.Drawing.Point(5, 276);
            this.dtpSurgeryEndTime.Name = "dtpSurgeryEndTime";
            this.dtpSurgeryEndTime.ShowUpDown = true;
            this.dtpSurgeryEndTime.Size = new System.Drawing.Size(154, 21);
            this.dtpSurgeryEndTime.TabIndex = 27;
            this.dtpSurgeryEndTime.Value = new System.DateTime(2010, 6, 25, 0, 0, 0, 0);
            // 
            // cbEvent
            // 
            this.cbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Items.AddRange(new object[] {
            "--请选择--",
            "已测",
            "私自外出",
            "请假",
            "劝阻无效外出",
            "拒测"});
            this.cbEvent.Location = new System.Drawing.Point(5, 194);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(154, 20);
            this.cbEvent.TabIndex = 22;
            this.cbEvent.SelectedIndexChanged += new System.EventHandler(this.cbEvent_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(137, 220);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(20, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "-";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddEvent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddEvent.Location = new System.Drawing.Point(114, 220);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(20, 23);
            this.btnAddEvent.TabIndex = 24;
            this.btnAddEvent.Text = "+";
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // ckBreath
            // 
            this.ckBreath.AutoSize = true;
            this.ckBreath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckBreath.Location = new System.Drawing.Point(46, 139);
            this.ckBreath.Name = "ckBreath";
            this.ckBreath.Size = new System.Drawing.Size(39, 21);
            this.ckBreath.TabIndex = 8;
            this.ckBreath.Text = "®";
            this.ckBreath.UseVisualStyleBackColor = true;
            // 
            // txtPainGrades
            // 
            this.txtPainGrades.Location = new System.Drawing.Point(5, 376);
            this.txtPainGrades.MaxLength = 3;
            this.txtPainGrades.Name = "txtPainGrades";
            this.txtPainGrades.ShortcutsEnabled = false;
            this.txtPainGrades.Size = new System.Drawing.Size(72, 21);
            this.txtPainGrades.TabIndex = 30;
            this.txtPainGrades.Visible = false;
            // 
            // cboPainGradesMothed
            // 
            this.cboPainGradesMothed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPainGradesMothed.FormattingEnabled = true;
            this.cboPainGradesMothed.Items.AddRange(new object[] {
            "数字法",
            "脸谱法"});
            this.cboPainGradesMothed.Location = new System.Drawing.Point(5, 349);
            this.cboPainGradesMothed.Name = "cboPainGradesMothed";
            this.cboPainGradesMothed.Size = new System.Drawing.Size(72, 20);
            this.cboPainGradesMothed.TabIndex = 29;
            this.cboPainGradesMothed.Visible = false;
            this.cboPainGradesMothed.SelectedIndexChanged += new System.EventHandler(this.cboPainGradesMothed_SelectedIndexChanged);
            // 
            // txtPainGrades2
            // 
            this.txtPainGrades2.Location = new System.Drawing.Point(5, 404);
            this.txtPainGrades2.MaxLength = 3;
            this.txtPainGrades2.Name = "txtPainGrades2";
            this.txtPainGrades2.ShortcutsEnabled = false;
            this.txtPainGrades2.Size = new System.Drawing.Size(72, 21);
            this.txtPainGrades2.TabIndex = 31;
            this.txtPainGrades2.Visible = false;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lbTime.ForeColor = System.Drawing.Color.Blue;
            this.lbTime.Location = new System.Drawing.Point(7, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(53, 16);
            this.lbTime.TabIndex = 134;
            this.lbTime.Text = "00:00";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboPainGradesMothedQX);
            this.groupBox1.Controls.Add(this.cbTemperTypeQX);
            this.groupBox1.Controls.Add(this.txtPainGrades2QX);
            this.groupBox1.Controls.Add(this.txtPulseQX);
            this.groupBox1.Controls.Add(this.txtPainGradesQX);
            this.groupBox1.Controls.Add(this.txtHeartQX);
            this.groupBox1.Controls.Add(this.ckBreathQX);
            this.groupBox1.Controls.Add(this.cbReiterationQX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckChuQX);
            this.groupBox1.Controls.Add(this.txtDownQX);
            this.groupBox1.Controls.Add(this.ckHeartRateQX);
            this.groupBox1.Controls.Add(this.txtBreathingQX);
            this.groupBox1.Controls.Add(this.txtTemperQX);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(81, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(86, 180);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "     ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 12);
            this.label3.TabIndex = 166;
            this.label3.Text = "骑线";
            // 
            // cboPainGradesMothedQX
            // 
            this.cboPainGradesMothedQX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPainGradesMothedQX.FormattingEnabled = true;
            this.cboPainGradesMothedQX.Items.AddRange(new object[] {
            "数字法",
            "脸谱法"});
            this.cboPainGradesMothedQX.Location = new System.Drawing.Point(4, 184);
            this.cboPainGradesMothedQX.Name = "cboPainGradesMothedQX";
            this.cboPainGradesMothedQX.Size = new System.Drawing.Size(72, 20);
            this.cboPainGradesMothedQX.TabIndex = 32;
            this.cboPainGradesMothedQX.Visible = false;
            // 
            // cbTemperTypeQX
            // 
            this.cbTemperTypeQX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemperTypeQX.FormattingEnabled = true;
            this.cbTemperTypeQX.Items.AddRange(new object[] {
            "腋表",
            "口表",
            "肛表"});
            this.cbTemperTypeQX.Location = new System.Drawing.Point(4, 17);
            this.cbTemperTypeQX.Name = "cbTemperTypeQX";
            this.cbTemperTypeQX.Size = new System.Drawing.Size(72, 20);
            this.cbTemperTypeQX.TabIndex = 12;
            this.cbTemperTypeQX.SelectedIndexChanged += new System.EventHandler(this.cbTemperType_SelectedIndexChanged);
            // 
            // txtPainGrades2QX
            // 
            this.txtPainGrades2QX.Location = new System.Drawing.Point(4, 239);
            this.txtPainGrades2QX.MaxLength = 3;
            this.txtPainGrades2QX.Name = "txtPainGrades2QX";
            this.txtPainGrades2QX.ShortcutsEnabled = false;
            this.txtPainGrades2QX.Size = new System.Drawing.Size(72, 21);
            this.txtPainGrades2QX.TabIndex = 34;
            this.txtPainGrades2QX.Visible = false;
            // 
            // txtPulseQX
            // 
            this.txtPulseQX.Location = new System.Drawing.Point(4, 100);
            this.txtPulseQX.MaxLength = 3;
            this.txtPulseQX.Name = "txtPulseQX";
            this.txtPulseQX.ShortcutsEnabled = false;
            this.txtPulseQX.Size = new System.Drawing.Size(39, 21);
            this.txtPulseQX.TabIndex = 16;
            this.txtPulseQX.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtPulseQX.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtPulseQX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // txtPainGradesQX
            // 
            this.txtPainGradesQX.Location = new System.Drawing.Point(4, 211);
            this.txtPainGradesQX.MaxLength = 3;
            this.txtPainGradesQX.Name = "txtPainGradesQX";
            this.txtPainGradesQX.ShortcutsEnabled = false;
            this.txtPainGradesQX.Size = new System.Drawing.Size(72, 21);
            this.txtPainGradesQX.TabIndex = 33;
            this.txtPainGradesQX.Visible = false;
            // 
            // txtHeartQX
            // 
            this.txtHeartQX.Enabled = false;
            this.txtHeartQX.Location = new System.Drawing.Point(4, 156);
            this.txtHeartQX.MaxLength = 3;
            this.txtHeartQX.Name = "txtHeartQX";
            this.txtHeartQX.ShortcutsEnabled = false;
            this.txtHeartQX.Size = new System.Drawing.Size(39, 21);
            this.txtHeartQX.TabIndex = 20;
            this.txtHeartQX.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtHeartQX.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtHeartQX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // ckBreathQX
            // 
            this.ckBreathQX.AutoSize = true;
            this.ckBreathQX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckBreathQX.Location = new System.Drawing.Point(45, 128);
            this.ckBreathQX.Name = "ckBreathQX";
            this.ckBreathQX.Size = new System.Drawing.Size(39, 21);
            this.ckBreathQX.TabIndex = 19;
            this.ckBreathQX.Text = "®";
            this.ckBreathQX.UseVisualStyleBackColor = true;
            // 
            // cbReiterationQX
            // 
            this.cbReiterationQX.AutoSize = true;
            this.cbReiterationQX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbReiterationQX.Location = new System.Drawing.Point(45, 46);
            this.cbReiterationQX.Name = "cbReiterationQX";
            this.cbReiterationQX.Size = new System.Drawing.Size(36, 21);
            this.cbReiterationQX.TabIndex = 14;
            this.cbReiterationQX.Text = "∨";
            this.cbReiterationQX.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(45, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 161;
            this.label2.Text = "↓";
            this.label2.Visible = false;
            // 
            // ckChuQX
            // 
            this.ckChuQX.AutoSize = true;
            this.ckChuQX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckChuQX.Location = new System.Drawing.Point(45, 101);
            this.ckChuQX.Name = "ckChuQX";
            this.ckChuQX.Size = new System.Drawing.Size(39, 21);
            this.ckChuQX.TabIndex = 17;
            this.ckChuQX.Text = "绌";
            this.ckChuQX.UseVisualStyleBackColor = true;
            this.ckChuQX.CheckedChanged += new System.EventHandler(this.ckChuQX_CheckedChanged);
            // 
            // txtDownQX
            // 
            this.txtDownQX.Location = new System.Drawing.Point(4, 72);
            this.txtDownQX.Name = "txtDownQX";
            this.txtDownQX.ShortcutsEnabled = false;
            this.txtDownQX.Size = new System.Drawing.Size(39, 21);
            this.txtDownQX.TabIndex = 15;
            this.txtDownQX.Visible = false;
            this.txtDownQX.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtDownQX.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtDownQX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInput_KeyPress);
            // 
            // ckHeartRateQX
            // 
            this.ckHeartRateQX.AutoSize = true;
            this.ckHeartRateQX.Enabled = false;
            this.ckHeartRateQX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckHeartRateQX.Location = new System.Drawing.Point(45, 157);
            this.ckHeartRateQX.Name = "ckHeartRateQX";
            this.ckHeartRateQX.Size = new System.Drawing.Size(39, 21);
            this.ckHeartRateQX.TabIndex = 21;
            this.ckHeartRateQX.Text = "Ⓗ";
            this.ckHeartRateQX.UseVisualStyleBackColor = true;
            // 
            // txtBreathingQX
            // 
            this.txtBreathingQX.Location = new System.Drawing.Point(4, 128);
            this.txtBreathingQX.MaxLength = 3;
            this.txtBreathingQX.Name = "txtBreathingQX";
            this.txtBreathingQX.ShortcutsEnabled = false;
            this.txtBreathingQX.Size = new System.Drawing.Size(39, 21);
            this.txtBreathingQX.TabIndex = 18;
            this.txtBreathingQX.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtBreathingQX.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtBreathingQX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // txtTemperQX
            // 
            this.txtTemperQX.Location = new System.Drawing.Point(4, 44);
            this.txtTemperQX.MaxLength = 4;
            this.txtTemperQX.Name = "txtTemperQX";
            this.txtTemperQX.ShortcutsEnabled = false;
            this.txtTemperQX.Size = new System.Drawing.Size(39, 21);
            this.txtTemperQX.TabIndex = 13;
            this.txtTemperQX.TextChanged += new System.EventHandler(this.txtTemper_TextChanged);
            this.txtTemperQX.Leave += new System.EventHandler(this.txtBox_Leave);
            this.txtTemperQX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInput_KeyPress);
            // 
            // TemperWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.dtpSurgeryEndTime);
            this.Controls.Add(this.dtpAddEventTime);
            this.Controls.Add(this.lbEvents);
            this.Controls.Add(this.cbAddEvent);
            this.Controls.Add(this.cbEvent);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.cboPainGradesMothed);
            this.Controls.Add(this.txtPainGrades2);
            this.Controls.Add(this.txtPainGrades);
            this.Controls.Add(this.ckBreath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDown);
            this.Controls.Add(this.txtBreathing);
            this.Controls.Add(this.cbTemperType);
            this.Controls.Add(this.txtTemper);
            this.Controls.Add(this.ckHeartRate);
            this.Controls.Add(this.ckChu);
            this.Controls.Add(this.cbReiteration);
            this.Controls.Add(this.txtHeart);
            this.Controls.Add(this.txtPulse);
            this.Name = "TemperWrite";
            this.Size = new System.Drawing.Size(170, 434);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAddEvent;
        private System.Windows.Forms.TextBox txtBreathing;
        private System.Windows.Forms.ComboBox cbTemperType;
        private System.Windows.Forms.TextBox txtTemper;
        private System.Windows.Forms.CheckBox ckHeartRate;
        private System.Windows.Forms.CheckBox ckChu;
        private System.Windows.Forms.CheckBox cbReiteration;
        private System.Windows.Forms.TextBox txtHeart;
        private System.Windows.Forms.TextBox txtPulse;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbEvents;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.DateTimePicker dtpAddEventTime;
        private System.Windows.Forms.DateTimePicker dtpSurgeryEndTime;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private DevComponents.DotNetBar.ButtonX btnAddEvent;
        private System.Windows.Forms.CheckBox ckBreath;
        private System.Windows.Forms.TextBox txtPainGrades;
        private System.Windows.Forms.ComboBox cboPainGradesMothed;
        private System.Windows.Forms.TextBox txtPainGrades2;
        public System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPainGradesMothedQX;
        private System.Windows.Forms.ComboBox cbTemperTypeQX;
        private System.Windows.Forms.TextBox txtPainGrades2QX;
        private System.Windows.Forms.TextBox txtPulseQX;
        private System.Windows.Forms.TextBox txtPainGradesQX;
        private System.Windows.Forms.TextBox txtHeartQX;
        private System.Windows.Forms.CheckBox ckBreathQX;
        private System.Windows.Forms.CheckBox cbReiterationQX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckChuQX;
        private System.Windows.Forms.TextBox txtDownQX;
        private System.Windows.Forms.CheckBox ckHeartRateQX;
        private System.Windows.Forms.TextBox txtBreathingQX;
        private System.Windows.Forms.TextBox txtTemperQX;
        private System.Windows.Forms.Label label3;

    }
}
