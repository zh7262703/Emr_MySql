using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Xml;
using Bifrost;
using DevComponents.DotNetBar;
using Bifrost.SYSTEMSET;

namespace BifrostMainPro
{
    /// <summary>
    /// 新主界面
    /// </summary>
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        #region 消息提醒使用的标识
        private static string isWindowPop = "0";  //判断是否窗体已弹出
        private static string isCheckNews = "0";  //判断系统是否第一次查询过消息，而且还没查询到
        private static bool isWindowOpen = false;    //判断当前窗体是否开启
        private static bool istbtnMessageMide_Click = false; //是否单击过当前消息提醒窗体 
        #endregion

        private int childFormNumber = 0;

        public static bool isReset = false;                    //判断是否是注销操作

        //private ArrayList Openforms = new ArrayList(); //记录打开窗体的步骤（dll名+函数名+窗体类型）

        Thread NoticeLight = new Thread(new ThreadStart(ShowNoticeLight));

        Thread UploadDoc = new Thread(new ThreadStart(UploadDocfiles));    //时时上传文书图片文件

        private int cunum = 0;                           //小灯计数

        private static bool Huizhenflag = false;         //会诊显示信号 true 显示 false 不显示

        private static bool ZhiKongflag = false;         //质量控制显示信号 true 显示 false 不显示 

        private static bool Bkglflag = false;            //报卡管理 true限制 false不显示

        private static bool MessageFlag = false;         //消息提醒 true显示 false不显示

        private static int CurrentChildFormsCount = 0;

        private string opstr = "";                       //操作字符串 

        //private int ActioMaxId = 0;                    //检测移动表

        private string ServerIp = "";
        public static XmlDocument updateDoc = new XmlDocument();

        public static int AccountType = 0;

        private string strToolSet = "";                  //按钮设置

        private RibbonBar tempToolbar = new RibbonBar();   //临时寄存工具栏

        bool toolbarflodflag = false;
        WebRequest req;

        int toobarHeight = 0;

        public static int isupdate = 0;

        public static string MsgContent = "";
        public static string MsgURL = "";

        /// <summary>
        /// 主界面
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            //this.AutoScaleMode = AutoScaleMode.None;
            ServerIp = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini"));
            req = WebRequest.Create(ServerIp + @"/WebSite1/Update.xml");
            App.tabMain = tabControl_Main;
            //App.tittleuserinfo = toolStripLabel;
            AddToobar();

        }

        #region 自定义方法

        /// <summary>
        /// 插入新功能工具栏
        /// </summary>
        private void AddToobar()
        {
            #region 初始化新增工具栏功能项
            //系统注销
            ButtonItem tbtnResetSystem = new ButtonItem();
            tbtnResetSystem.AutoCheckOnClick = true;
            tbtnResetSystem.BeginGroup = false;
            tbtnResetSystem.Image = global::BifrostMainPro.Resource1.系统注销;
            tbtnResetSystem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnResetSystem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
            tbtnResetSystem.Name = "tbtnResetSystem";
            tbtnResetSystem.OptionGroup = "Color";
            tbtnResetSystem.Text = "系统注销";
            tbtnResetSystem.ThemeAware = true;
            tbtnResetSystem.Tooltip = "系统注销";
            tbtnResetSystem.Click += new System.EventHandler(this.tbtnResetSystem_Click);

            //角色切换
            ButtonItem tbtnRoleChose = new ButtonItem();
            tbtnRoleChose.AutoCheckOnClick = true;
            tbtnRoleChose.BeginGroup = false;
            tbtnRoleChose.Image = global::BifrostMainPro.Resource1.角色切换;
            tbtnRoleChose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnRoleChose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tbtnRoleChose.Name = "tbtnRoleChose";
            tbtnRoleChose.OptionGroup = "Color";
            tbtnRoleChose.Text = "角色切换";
            tbtnRoleChose.ThemeAware = true;
            tbtnRoleChose.Tooltip = "角色切换";
            tbtnRoleChose.Click += new System.EventHandler(this.tbtnRoleChose_Click);

            //密码修改
            ButtonItem tbtnPassword = new ButtonItem();
            tbtnPassword.AutoCheckOnClick = true;
            tbtnPassword.BeginGroup = false;
            tbtnPassword.Image = global::BifrostMainPro.Resource1.密码修改;
            tbtnPassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnPassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tbtnPassword.Name = "tbtnPassword";
            tbtnPassword.OptionGroup = "Color";
            tbtnPassword.Text = "密码修改";
            tbtnPassword.ThemeAware = true;
            tbtnPassword.Tooltip = "密码修改";
            tbtnPassword.Click += new System.EventHandler(this.tbtnPassword_Click);

            //帐号注销
            ButtonItem tbtnAccountClear = new ButtonItem();
            tbtnAccountClear.AutoCheckOnClick = true;
            tbtnAccountClear.BeginGroup = false;
            tbtnAccountClear.Image = global::BifrostMainPro.Resource1.账号注销;
            tbtnAccountClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnAccountClear.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tbtnAccountClear.Name = "tbtnAccountClear";
            tbtnAccountClear.OptionGroup = "Color";
            tbtnAccountClear.Text = "帐号注销";
            tbtnAccountClear.ThemeAware = true;
            tbtnAccountClear.Tooltip = "帐号注销";
            tbtnAccountClear.Click += new System.EventHandler(this.tbtnAccountClear_Click);


            //科室账号维护
            ButtonItem tsbtnSectionAccountSets = new ButtonItem();
            tsbtnSectionAccountSets.AutoCheckOnClick = true;
            tsbtnSectionAccountSets.BeginGroup = false;
            tsbtnSectionAccountSets.Image = global::BifrostMainPro.Resource1.科室账号维护;
            tsbtnSectionAccountSets.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnSectionAccountSets.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnSectionAccountSets.Name = "tsbtnSectionAccountSets";
            tsbtnSectionAccountSets.OptionGroup = "Color";
            tsbtnSectionAccountSets.Text = "科室账号维护";
            tsbtnSectionAccountSets.ThemeAware = true;
            tsbtnSectionAccountSets.Tooltip = "科室账号维护";
            tsbtnSectionAccountSets.Click += new System.EventHandler(this.tsbtnSectionAccountSets_Click);


            //提取模板
            ButtonItem tsbtnTemplate = new ButtonItem();
            tsbtnTemplate.AutoCheckOnClick = true;
            tsbtnTemplate.BeginGroup = false;
            tsbtnTemplate.Image = global::BifrostMainPro.Resource1.提取模板;
            tsbtnTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnTemplate.Name = "tsbtnTemplate";
            tsbtnTemplate.OptionGroup = "Color";
            tsbtnTemplate.Text = "提取模板";
            tsbtnTemplate.ThemeAware = true;
            tsbtnTemplate.Tooltip = "提取模板";
            tsbtnTemplate.Click += new System.EventHandler(this.tsbtnTemplate_Click);


            //保存小模板
            ButtonItem tsbtnSmallTemplateSave = new ButtonItem();
            tsbtnSmallTemplateSave.AutoCheckOnClick = true;
            tsbtnSmallTemplateSave.BeginGroup = false;
            tsbtnSmallTemplateSave.Image = global::BifrostMainPro.Resource1.保存小模板;
            tsbtnSmallTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnSmallTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnSmallTemplateSave.Name = "tsbtnSmallTemplateSave";
            tsbtnSmallTemplateSave.OptionGroup = "Color";
            tsbtnSmallTemplateSave.Text = "保存小模板";
            tsbtnSmallTemplateSave.ThemeAware = true;
            tsbtnSmallTemplateSave.Tooltip = "保存小模板";
            tsbtnSmallTemplateSave.Click += new System.EventHandler(this.tsbtnSmallTemplateSave_Click);

            //保存模板
            ButtonItem tsbtnTemplateSave = new ButtonItem();
            tsbtnTemplateSave.AutoCheckOnClick = true;
            tsbtnTemplateSave.BeginGroup = false;
            tsbtnTemplateSave.Image = global::BifrostMainPro.Resource1.保存模板;
            tsbtnTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnTemplateSave.Name = "tsbtnTemplateSave";
            tsbtnTemplateSave.OptionGroup = "Color";
            tsbtnTemplateSave.Text = "保存模板";
            tsbtnTemplateSave.ThemeAware = true;
            tsbtnTemplateSave.Tooltip = "保存模板";
            tsbtnTemplateSave.Click += new System.EventHandler(this.tsbtnTemplateSave_Click);

            //打印
            ButtonItem ttsbtnPrint = new ButtonItem();
            ttsbtnPrint.AutoCheckOnClick = true;
            ttsbtnPrint.BeginGroup = false;
            ttsbtnPrint.Image = global::BifrostMainPro.Resource1.打印;
            ttsbtnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ttsbtnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            ttsbtnPrint.Name = "ttsbtnPrint";
            ttsbtnPrint.OptionGroup = "Color";
            ttsbtnPrint.Text = "打印";
            ttsbtnPrint.ThemeAware = true;
            ttsbtnPrint.Tooltip = "打印";
            ttsbtnPrint.Click += new System.EventHandler(this.ttsbtnPrint_Click);

            //续打
            ButtonItem ttsbtnPrintContinue = new ButtonItem();
            ttsbtnPrintContinue.AutoCheckOnClick = true;
            ttsbtnPrintContinue.BeginGroup = false;
            ttsbtnPrintContinue.Image = global::BifrostMainPro.Resource1.续打;
            ttsbtnPrintContinue.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ttsbtnPrintContinue.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            ttsbtnPrintContinue.Name = "ttsbtnPrintContinue";
            ttsbtnPrintContinue.OptionGroup = "Color";
            ttsbtnPrintContinue.Text = "续打";
            ttsbtnPrintContinue.ThemeAware = true;
            ttsbtnPrintContinue.Tooltip = "续打";
            ttsbtnPrintContinue.Click += new System.EventHandler(this.ttsbtnPrintContinue_Click);

            //知情同意书批打印
            ButtonItem ttsbtnBachePrint = new ButtonItem();
            ttsbtnBachePrint.AutoCheckOnClick = true;
            ttsbtnBachePrint.BeginGroup = false;
            ttsbtnBachePrint.Image = global::BifrostMainPro.Resource1.打印知情同意书;
            ttsbtnBachePrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ttsbtnBachePrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            ttsbtnBachePrint.Name = "ttsbtnBachePrint";
            ttsbtnBachePrint.OptionGroup = "Color";
            ttsbtnBachePrint.Text = "打印知情同意书";
            ttsbtnBachePrint.ThemeAware = true;
            ttsbtnBachePrint.Tooltip = "打印知情同意书";
            ttsbtnBachePrint.Click += new System.EventHandler(this.ttsbtnBachePrint_Click);

            //暂存
            ButtonItem tsbtnTempSave = new ButtonItem();
            tsbtnTempSave.AutoCheckOnClick = true;
            tsbtnTempSave.BeginGroup = false;
            tsbtnTempSave.Image = global::BifrostMainPro.Resource1.暂存;
            tsbtnTempSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnTempSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnTempSave.Name = "tsbtnTempSave";
            tsbtnTempSave.OptionGroup = "Color";
            tsbtnTempSave.Text = "暂存";
            tsbtnTempSave.ThemeAware = true;
            tsbtnTempSave.Tooltip = "暂存";
            tsbtnTempSave.Click += new System.EventHandler(this.tsbtnTempSave_Click);

            //提交
            ButtonItem tsbtnCommit = new ButtonItem();
            tsbtnCommit.AutoCheckOnClick = true;
            tsbtnCommit.BeginGroup = false;
            tsbtnCommit.Image = global::BifrostMainPro.Resource1.提交;
            tsbtnCommit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCommit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCommit.Name = "tsbtnCommit";
            tsbtnCommit.OptionGroup = "Color";
            tsbtnCommit.Text = "提交";
            tsbtnCommit.ThemeAware = true;
            tsbtnCommit.Tooltip = "提交";
            tsbtnCommit.Click += new System.EventHandler(this.tsbtnCommit_Click);

            //值班设置
            ButtonItem tsbtnDutySet = new ButtonItem();
            tsbtnDutySet.AutoCheckOnClick = true;
            tsbtnDutySet.BeginGroup = false;
            tsbtnDutySet.Image = global::BifrostMainPro.Resource1.被授权文书操作;
            tsbtnDutySet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnDutySet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnDutySet.Name = "tsbtnDutySet";
            tsbtnDutySet.OptionGroup = "Color";
            tsbtnDutySet.Text = "值班设置";
            tsbtnDutySet.ThemeAware = true;
            tsbtnDutySet.Tooltip = "值班设置";
            tsbtnDutySet.Click += new System.EventHandler(this.tsbtnDutySet_Click);

            //诊疗规范
            ButtonItem tsbtnZLGF = new ButtonItem();
            tsbtnZLGF.AutoCheckOnClick = true;
            tsbtnZLGF.BeginGroup = false;
            tsbtnZLGF.Image = global::BifrostMainPro.Resource1.被授权文书操作;
            tsbtnZLGF.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnZLGF.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnZLGF.Name = "tsbtnZLGF";
            tsbtnZLGF.OptionGroup = "Color";
            tsbtnZLGF.Text = "诊疗规范";
            tsbtnZLGF.ThemeAware = true;
            tsbtnZLGF.Tooltip = "诊疗规范";
            tsbtnZLGF.Click += new System.EventHandler(this.tsbtnZLGF_Click);

            //报卡管理
            ButtonItem tsbtnBKSB = new ButtonItem();
            tsbtnBKSB.AutoCheckOnClick = true;
            tsbtnBKSB.BeginGroup = false;
            tsbtnBKSB.Image = global::BifrostMainPro.Resource1.报卡管理;
            tsbtnBKSB.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnBKSB.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnBKSB.Name = "tsbtnBKSB";
            tsbtnBKSB.OptionGroup = "Color";
            tsbtnBKSB.Text = "报卡管理";
            tsbtnBKSB.ThemeAware = true;
            tsbtnBKSB.Tooltip = "报卡管理";
            tsbtnBKSB.Click += new System.EventHandler(this.tsbtnBKSB_Click);

            //操作帮助
            ButtonItem tsbtnHelp = new ButtonItem();
            tsbtnHelp.AutoCheckOnClick = true;
            tsbtnHelp.BeginGroup = false;
            tsbtnHelp.Image = global::BifrostMainPro.Resource1.操作帮助;
            tsbtnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnHelp.Name = "tsbtnHelp";
            tsbtnHelp.OptionGroup = "Color";
            tsbtnHelp.Text = "操作帮助";
            tsbtnHelp.ThemeAware = true;
            tsbtnHelp.Tooltip = "操作帮助";
            tsbtnHelp.Click += new System.EventHandler(this.tsbtnHelp_Click);

            //查看病情
            ButtonItem tsbtnCheckSick = new ButtonItem();
            tsbtnCheckSick.AutoCheckOnClick = true;
            tsbtnCheckSick.BeginGroup = false;
            tsbtnCheckSick.Image = global::BifrostMainPro.Resource1.运行病历查阅;
            tsbtnCheckSick.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckSick.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckSick.Name = "tsbtnCheckSick";
            tsbtnCheckSick.OptionGroup = "Color";
            tsbtnCheckSick.Text = "查看病情";
            tsbtnCheckSick.ThemeAware = true;
            tsbtnCheckSick.Tooltip = "查看病情";
            tsbtnCheckSick.Click += new System.EventHandler(this.tsbtnCheckSick_Click);


            //查看体温
            ButtonItem tsbtnCheckTemprature = new ButtonItem();
            tsbtnCheckTemprature.AutoCheckOnClick = true;
            tsbtnCheckTemprature.BeginGroup = false;
            tsbtnCheckTemprature.Image = global::BifrostMainPro.Resource1.查看体温;
            tsbtnCheckTemprature.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckTemprature.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckTemprature.Name = "tsbtnCheckTemprature";
            tsbtnCheckTemprature.OptionGroup = "Color";
            tsbtnCheckTemprature.Text = "查看体温";
            tsbtnCheckTemprature.ThemeAware = true;
            tsbtnCheckTemprature.Tooltip = "查看体温";
            tsbtnCheckTemprature.Click += new System.EventHandler(this.tsbtnCheckTemprature_Click);

            //查看护理记录单
            ButtonItem tsbtnCheckNurseRecord = new ButtonItem();
            tsbtnCheckNurseRecord.AutoCheckOnClick = true;
            tsbtnCheckNurseRecord.BeginGroup = false;
            tsbtnCheckNurseRecord.Image = global::BifrostMainPro.Resource1.运行病历查阅;
            tsbtnCheckNurseRecord.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckNurseRecord.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckNurseRecord.Name = "tsbtnCheckNurseRecord";
            tsbtnCheckNurseRecord.OptionGroup = "Color";
            tsbtnCheckNurseRecord.Text = "查看护理记录单";
            tsbtnCheckNurseRecord.ThemeAware = true;
            tsbtnCheckNurseRecord.Tooltip = "查看护理记录单";
            tsbtnCheckNurseRecord.Click += new System.EventHandler(this.tsbtnCheckNurseRecord_Click);

            //查看检验检查结果
            ButtonItem tsbtnCheckLis = new ButtonItem();
            tsbtnCheckLis.AutoCheckOnClick = true;
            tsbtnCheckLis.BeginGroup = false;
            tsbtnCheckLis.Image = global::BifrostMainPro.Resource1.运行病历查阅;
            tsbtnCheckLis.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckLis.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckLis.Name = "tsbtnCheckLis";
            tsbtnCheckLis.OptionGroup = "Color";
            tsbtnCheckLis.Text = "查看检验检查结果";
            tsbtnCheckLis.ThemeAware = true;
            tsbtnCheckLis.Tooltip = "查看检验检查结果";
            tsbtnCheckLis.Click += new System.EventHandler(this.tsbtnCheckLis_Click);

            //查看影像报告结果
            ButtonItem tsbtnCheckPacs = new ButtonItem();
            tsbtnCheckPacs.AutoCheckOnClick = true;
            tsbtnCheckPacs.BeginGroup = false;
            tsbtnCheckPacs.Image = global::BifrostMainPro.Resource1.运行病历查阅;
            tsbtnCheckPacs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckPacs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckPacs.Name = "tsbtnCheckPacs";
            tsbtnCheckPacs.OptionGroup = "Color";
            tsbtnCheckPacs.Text = "查看影像报告结果";
            tsbtnCheckPacs.ThemeAware = true;
            tsbtnCheckPacs.Tooltip = "查看影像报告结果";
            tsbtnCheckPacs.Click += new System.EventHandler(this.tsbtnCheckPacs_Click);

            //查看手术审批
            ButtonItem tsbtnCheckOperator = new ButtonItem();
            tsbtnCheckOperator.AutoCheckOnClick = true;
            tsbtnCheckOperator.BeginGroup = false;
            tsbtnCheckOperator.Image = global::BifrostMainPro.Resource1.病案借阅申请;
            tsbtnCheckOperator.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckOperator.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckOperator.Name = "tsbtnCheckOperator";
            tsbtnCheckOperator.OptionGroup = "Color";
            tsbtnCheckOperator.Text = "查看影像报告结果";
            tsbtnCheckOperator.ThemeAware = true;
            tsbtnCheckOperator.Tooltip = "查看影像报告结果";
            tsbtnCheckOperator.Click += new System.EventHandler(this.tsbtnCheckOperator_Click);

            //病案借阅申请
            ButtonItem tsbtnPatientSickInfoApply = new ButtonItem();
            tsbtnPatientSickInfoApply.AutoCheckOnClick = true;
            tsbtnPatientSickInfoApply.BeginGroup = false;
            tsbtnPatientSickInfoApply.Image = global::BifrostMainPro.Resource1.病案借阅申请;
            tsbtnPatientSickInfoApply.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnPatientSickInfoApply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnPatientSickInfoApply.Name = "tsbtnPatientSickInfoApply";
            tsbtnPatientSickInfoApply.OptionGroup = "Color";
            tsbtnPatientSickInfoApply.Text = "病案借阅申请";
            tsbtnPatientSickInfoApply.ThemeAware = true;
            tsbtnPatientSickInfoApply.Tooltip = "病案借阅申请";
            tsbtnPatientSickInfoApply.Click += new System.EventHandler(this.tsbtnPatientSickInfoApply_Click);


            //归档退回申请
            ButtonItem tsbtnBackSickInfoApply = new ButtonItem();
            tsbtnBackSickInfoApply.AutoCheckOnClick = true;
            tsbtnBackSickInfoApply.BeginGroup = false;
            tsbtnBackSickInfoApply.Image = global::BifrostMainPro.Resource1.归档退回申请;
            tsbtnBackSickInfoApply.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnBackSickInfoApply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnBackSickInfoApply.Name = "tsbtnBackSickInfoApply";
            tsbtnBackSickInfoApply.OptionGroup = "Color";
            tsbtnBackSickInfoApply.Text = "归档退回申请";
            tsbtnBackSickInfoApply.ThemeAware = true;
            tsbtnBackSickInfoApply.Tooltip = "归档退回申请";
            tsbtnBackSickInfoApply.Click += new System.EventHandler(this.tsbtnBackSickInfoApply_Click);

            //运行病历查阅
            ButtonItem tsbtnUsedSickInfoCheck = new ButtonItem();
            tsbtnUsedSickInfoCheck.AutoCheckOnClick = true;
            tsbtnUsedSickInfoCheck.BeginGroup = false;
            tsbtnUsedSickInfoCheck.Image = global::BifrostMainPro.Resource1.运行病历查阅;
            tsbtnUsedSickInfoCheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnUsedSickInfoCheck.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnUsedSickInfoCheck.Name = "tsbtnUsedSickInfoCheck";
            tsbtnUsedSickInfoCheck.OptionGroup = "Color";
            tsbtnUsedSickInfoCheck.Text = "运行病历查阅";
            tsbtnUsedSickInfoCheck.ThemeAware = true;
            tsbtnUsedSickInfoCheck.Tooltip = "运行病历查阅";
            tsbtnUsedSickInfoCheck.Click += new System.EventHandler(this.tsbtnUsedSickInfoCheck_Click);


            //被授权文书操作
            ButtonItem tsbtnDocRights = new ButtonItem();
            tsbtnDocRights.AutoCheckOnClick = true;
            tsbtnDocRights.BeginGroup = false;
            tsbtnDocRights.Image = global::BifrostMainPro.Resource1.被授权文书操作;
            tsbtnDocRights.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnDocRights.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnDocRights.Name = "tsbtnDocRights";
            tsbtnDocRights.OptionGroup = "Color";
            tsbtnDocRights.Text = "被授权文书操作";
            tsbtnDocRights.ThemeAware = true;
            tsbtnDocRights.Tooltip = "被授权文书操作";
            tsbtnDocRights.Click += new System.EventHandler(this.tsbtnDocRights_Click);

            //病案整理
            ButtonItem tsbtnMedicalRecordFinishing = new ButtonItem();
            tsbtnMedicalRecordFinishing.AutoCheckOnClick = true;
            tsbtnMedicalRecordFinishing.BeginGroup = false;
            tsbtnMedicalRecordFinishing.Image = global::BifrostMainPro.Resource1.病案整理;
            tsbtnMedicalRecordFinishing.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnMedicalRecordFinishing.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnMedicalRecordFinishing.Name = "tsbtnMedicalRecordFinishing";
            tsbtnMedicalRecordFinishing.OptionGroup = "Color";
            tsbtnMedicalRecordFinishing.Text = "病案整理";
            tsbtnMedicalRecordFinishing.ThemeAware = true;
            tsbtnMedicalRecordFinishing.Tooltip = "病案整理";
            tsbtnMedicalRecordFinishing.Click += new System.EventHandler(this.tsbtnMedicalRecordFinishing_Click);

            //病案归档
            ButtonItem tsbtnMedicalRecords = new ButtonItem();
            tsbtnMedicalRecords.AutoCheckOnClick = true;
            tsbtnMedicalRecords.BeginGroup = false;
            tsbtnMedicalRecords.Image = global::BifrostMainPro.Resource1.病案归档;
            tsbtnMedicalRecords.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnMedicalRecords.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnMedicalRecords.Name = "tsbtnMedicalRecords";
            tsbtnMedicalRecords.OptionGroup = "Color";
            tsbtnMedicalRecords.Text = "病案归档";
            tsbtnMedicalRecords.ThemeAware = true;
            tsbtnMedicalRecords.Tooltip = "病案归档";
            tsbtnMedicalRecords.Click += new System.EventHandler(this.tsbtnMedicalRecords_Click);

            //未完成工作
            ButtonItem tsbtnUnfinishedWork = new ButtonItem();
            tsbtnUnfinishedWork.AutoCheckOnClick = true;
            tsbtnUnfinishedWork.BeginGroup = false;
            tsbtnUnfinishedWork.Image = global::BifrostMainPro.Resource1.未完成;
            tsbtnUnfinishedWork.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnUnfinishedWork.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnUnfinishedWork.Name = "tsbtnUnfinishedWork";
            tsbtnUnfinishedWork.OptionGroup = "Color";
            tsbtnUnfinishedWork.Text = "未完成工作";
            tsbtnUnfinishedWork.ThemeAware = true;
            tsbtnUnfinishedWork.Tooltip = "未完成工作";
            tsbtnUnfinishedWork.Click += new System.EventHandler(this.tsbtnUnfinishedWork_Click);

            //诊断编辑
            ButtonItem btnInsertDiosgin = new ButtonItem();
            btnInsertDiosgin.AutoCheckOnClick = true;
            btnInsertDiosgin.BeginGroup = false;
            btnInsertDiosgin.Image = global::BifrostMainPro.Resource1.诊断编辑;
            btnInsertDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            btnInsertDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
            btnInsertDiosgin.Name = "btnInsertDiosgin";
            btnInsertDiosgin.OptionGroup = "Color";
            btnInsertDiosgin.Text = "诊断编辑";
            btnInsertDiosgin.ThemeAware = true;
            btnInsertDiosgin.Tooltip = "诊断编辑";
            btnInsertDiosgin.Click += new System.EventHandler(this.tsbtnInsertDiosgin_Click);

            //刷新诊断
            ButtonItem btnRefreshDiosgin = new ButtonItem();
            btnRefreshDiosgin.AutoCheckOnClick = true;
            btnRefreshDiosgin.BeginGroup = false;
            btnRefreshDiosgin.Image = global::BifrostMainPro.Resource1.刷新诊断;
            btnRefreshDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            btnRefreshDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
            btnRefreshDiosgin.Name = "btnRefreshDiosgin";
            btnRefreshDiosgin.OptionGroup = "Color";
            btnRefreshDiosgin.Text = "刷新诊断";
            btnRefreshDiosgin.ThemeAware = true;
            btnRefreshDiosgin.Tooltip = "刷新诊断";
            btnRefreshDiosgin.Click += new System.EventHandler(this.tsbtnRefreshDiosgin_Click);
            #endregion

            /*
             * 将图标插入工具栏            
             */
            tempToolbar.Items.Add(tbtnResetSystem);
            tempToolbar.Items.Add(tbtnRoleChose);
            tempToolbar.Items.Add(tbtnPassword);
            tempToolbar.Items.Add(tbtnAccountClear);
            tempToolbar.Items.Add(tsbtnSectionAccountSets);
            tempToolbar.Items.Add(tsbtnTemplate);
            tempToolbar.Items.Add(tsbtnSmallTemplateSave);
            tempToolbar.Items.Add(tsbtnTemplateSave);
            tempToolbar.Items.Add(ttsbtnPrint);
            tempToolbar.Items.Add(ttsbtnPrintContinue);
            tempToolbar.Items.Add(tsbtnTempSave);
            tempToolbar.Items.Add(tsbtnCommit);
            tempToolbar.Items.Add(tsbtnDutySet);
            tempToolbar.Items.Add(tsbtnZLGF);
            tempToolbar.Items.Add(tsbtnBKSB);
            tempToolbar.Items.Add(tsbtnHelp);
            tempToolbar.Items.Add(tsbtnCheckSick);
            tempToolbar.Items.Add(tsbtnCheckTemprature);
            tempToolbar.Items.Add(tsbtnCheckNurseRecord);
            tempToolbar.Items.Add(tsbtnCheckLis);
            tempToolbar.Items.Add(tsbtnCheckPacs);
            tempToolbar.Items.Add(tsbtnCheckOperator);
            tempToolbar.Items.Add(tsbtnPatientSickInfoApply);
            tempToolbar.Items.Add(tsbtnBackSickInfoApply);
            tempToolbar.Items.Add(tsbtnUsedSickInfoCheck);
            tempToolbar.Items.Add(tsbtnDocRights);
            tempToolbar.Items.Add(tsbtnMedicalRecordFinishing);
            tempToolbar.Items.Add(tsbtnMedicalRecords);
            tempToolbar.Items.Add(tsbtnUnfinishedWork);            
            tempToolbar.Items.Add(btnInsertDiosgin);
            tempToolbar.Items.Add(btnRefreshDiosgin);
            //tempToolbar.Items.Add(ttsbtnBachePrint);

            for (int i = 0; i < tempToolbar.Items.Count; i++)
            {
                ButtonItem temp = (ButtonItem)tempToolbar.Items[i];
                temp.MouseLeave += new EventHandler(tbtnConsultationMide_MouseLeave);
                temp.ImageFixedSize = new Size(30, 30);
                temp.ImagePosition = eImagePosition.Left;

            }

            toobarHeight = toolbar.Height;

            tbtnReportBack.Image = global::BifrostMainPro.Resource1.被授权文书操作;
            tbtnConsultationMide.Image = global::BifrostMainPro.Resource1.被授权文书操作;
            tbtnQualityMide.Image = global::BifrostMainPro.Resource1.质控提醒;
            tbtnMessageMide.Image = global::BifrostMainPro.Resource1.消息提醒;
            tbtnGrade.Image = global::BifrostMainPro.Resource1.科室评分;

            for (int i = 0; i < midebar.Items.Count; i++)
            {
                ButtonItem temp = (ButtonItem)midebar.Items[i];
                temp.ImageFixedSize = new Size(30, 30);
                temp.ImagePosition = eImagePosition.Left;
            }
        }

        /// <summary>
        /// 显示工具栏按钮
        /// </summary>
        private void ShowToolBars()
        {
            toolbar.Items.Clear();
            string strTools = "";
            //大连附一修改统一格式:工具栏设置非医生护士登录只显示:系统注销,角色切换,密码修改
            if (App.UserAccount.CurrentSelectRole != null && App.UserAccount.CurrentSelectRole.Role_type != "D" && App.UserAccount.CurrentSelectRole.Role_type != "N")
            {
                strTools = @"tbtnResetSystem,tbtnRoleChose,tbtnPassword";
                //tbtnQualityMide.Visible = false;
                midebar.Visible = false;
            }
            else
            {
                strTools = App.ReadSqlVal("select TOOL_BUTTON_SET from T_ACCOUNT_SET where ACCOUNT_ID=" + App.UserAccount.Account_id + "", 0, "TOOL_BUTTON_SET"); //TOOLS
                //tbtnQualityMide.Visible = true;
                midebar.Visible = false;
            }
            if (strTools == null)
                strTools = "";
            if (strTools.Trim() == "")
                strTools = App.Read_ConfigInfo("SYSTEMSET", "TOOLS", Application.StartupPath + "\\Config.ini"); //TOOLS
            if (strTools != "")
            {
                for (int j = 0; j < strTools.Split(',').Length; j++)
                {
                    for (int i = 0; i < tempToolbar.Items.Count; i++)
                    {
                        if (strTools.Split(',')[j] == tempToolbar.Items[i].Name)
                            toolbar.Items.Add(tempToolbar.Items[i].Copy());
                    }
                }
            }
            toolbar.Width = toolbar.Parent.Width;  //不加这个按钮显示不全
            toolbar.Refresh();
        }

        /// <summary>
        /// 显示按钮设置窗体
        /// </summary>
        private void ShowToolsSet()
        {
            try
            {

                DevComponents.DotNetBar.ButtonItem[] btnItems = new ButtonItem[tempToolbar.Items.Count];
                for (int i = 0; i < tempToolbar.Items.Count; i++)
                {

                    btnItems[i] = (ButtonItem)tempToolbar.Items[i];
                    //btnItems[i].ImageFixedSize = new Size(30, 30);
                }
                frmToolItemSet fm = new frmToolItemSet(btnItems);
                App.FormStytleSet(fm, false);
                fm.ShowDialog();
                //ShowToolBars();
            }
            catch (Exception ex)
            {
                App.MsgErr("工具栏设置功能无法启用，错误原因：" + ex.Message);
            }

        }


        /// <summary>
        /// 判断菜单或按钮是否具有权限
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        private bool IsHaveRight(string code)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < App.UserAccount.CurrentSelectRole.Permissions.Length; i++)
                {
                    if (App.UserAccount.CurrentSelectRole.Permissions[i].Perm_code == code)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch
            {
                return false;
            }
        }

        private static void ShowNoticeLight()
        {
            do
            {

                try
                {
                    /*
                     * 监测是否更新
                     */
                    XmlDocument doc = new XmlDocument();
                    doc.Load("http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite1/Update.xml");

                    if (Convert.ToSingle(doc.GetElementsByTagName("vsersion")[0].InnerText) > Convert.ToSingle(App.ProgrameVersion))
                    {
                        isupdate = 1;
                    }

                    DataSet dsMsg = App.GetDataSet("select * from T_PUBLIC_MESSAGE where ENDABLE='Y'");
                    if (dsMsg.Tables[0].Rows.Count > 0)
                    {
                        MsgURL = dsMsg.Tables[0].Rows[0]["URL"].ToString();
                        MsgContent = dsMsg.Tables[0].Rows[0]["content"].ToString();
                    }
                    else
                    {
                        MsgContent = "";
                        MsgURL = "";
                    }

                }
                catch
                {

                }
                try
                {

                    DataSet ds_N_ZK = new DataSet();
                    DataSet ds_D_HZ = new DataSet();
                    DataSet ds_D_ZK = new DataSet();
                    DataSet ds_D_BK = new DataSet();
                    DataSet ds_M_MESSAGE = new DataSet();
                    //Leadron.WebReference.Class_Table[] tabs = new Leadron.WebReference.Class_Table[2];
                    string[] Sqls = new string[3];


                    if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                    {
                        Sqls[1] = "select tip.sick_area_name from t_quality_record tqr inner join t_in_patient tip on tqr.pid=tip.pid where tqr.section_sickaera=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " order by tip.sick_bed_id,tqr.noteztime asc";
                        ds_N_ZK = App.GetDataSet(Sqls[1]);
                    }
                    else
                    {

                        Sqls[1] = "select tip.sick_area_name from t_quality_record tqr inner join t_in_patient tip on tqr.pid=tip.pid where tqr.section_sickaera=" + App.UserAccount.CurrentSelectRole.Section_Id + " order by tip.sick_bed_id,tqr.noteztime asc";
                        ds_D_ZK = App.GetDataSet(Sqls[1]);

                        Sqls[0] = "select a.id 序号" +
                                " from t_consultaion_apply a " +
                                " where a.consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.submited='Y' and consul_record_submite_state=0";
                        ds_D_HZ = App.GetDataSet(Sqls[0]);
                        ds_D_BK = App.GetDataSet("select id from t_fecter_report_card t where t.state=2 and t.sid=" + App.UserAccount.CurrentSelectRole.Section_Id + "");
                    }




                    if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                    {
                        /*
                         * 会诊
                         */
                        if (ds_D_HZ.Tables[0].Rows.Count > 0)
                        {
                            Huizhenflag = true;
                        }
                        else
                        {
                            Huizhenflag = false;
                        }

                        /*
                         * 医生质控
                         */
                        if (ds_D_ZK.Tables[0].Rows.Count > 0)
                        {
                            ZhiKongflag = true;
                        }
                        else
                        {
                            ZhiKongflag = false;
                        }

                        /*
                         *报卡提醒 
                         */
                        if (ds_D_BK.Tables[0].Rows.Count > 0)
                        {
                            Bkglflag = true;
                        }
                        else
                        {
                            Bkglflag = false;
                        }

                    }
                    else
                    {
                        /*
                         * 护士质控
                         */
                        if (ds_N_ZK.Tables[0].Rows.Count > 0)
                        {
                            ZhiKongflag = true;
                        }
                        else
                        {
                            ZhiKongflag = false;
                        }
                    }


                    //ds_M_MESSAGE = App.GetDataSet("select * from T_MSG_INFO t where t.receive_user like '%" + App.UserAccount.UserInfo.User_id + "%' and (select count(*) from T_MSG_USER a where a.MSG_ID=t.id and USER_ID=" + App.UserAccount.UserInfo.User_id + ")=0");
                    ///*消息提醒
                    // */
                    //if (ds_M_MESSAGE.Tables[0].Rows.Count > 0)
                    //{
                    //    MessageFlag = true;
                    //}
                    //else
                    //{
                    //    MessageFlag = false;
                    //}


                    #region 消息提醒自动弹出窗体功能
                    if (isWindowPop == "0" && isCheckNews == "0")  //判断消息查看主窗体是否弹出过（0：没有弹出过，1：已经弹出过），而且确实系统已经自动检索过（0：没有检索过 1：已经检索过）
                    {
                        //自动弹出消息提醒窗体（若存在消息时）
                        string str0ne_Sql = @"select distinct(m.id),
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m, t_in_patient p, t_msg_setting t
                             where m.pid = p.id
                               and t.WARN_TYPE = m.WARN_TYPE
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '0'
                               and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0 and m.receive_user_id='" + App.UserAccount.UserInfo.User_id + "'";
                        //消息发布提醒中接收人为——全院：
                        string strSend_sql0ne = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.make_sure is null
                               and m.msg_status = '1'
                               and m.content_id='1'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                        //消息发布提醒中接收人为——全院医生或全院护士：
                        string strSend_sqlTwo = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.make_sure is null
                               and m.msg_status = '1'
                               and p.role_type in ('D','N')
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                        //消息发布提醒中接收人为——科室：
                        string strSend_sqlThree = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.make_sure is null
                               and m.msg_status = '1'
                               and m.content_id='4'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                        //消息发布提醒中接收人为——病区：
                        string strSend_sqlFour = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.make_sure is null
                               and m.msg_status = '1'
                               and m.content_id='5'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                        //消息发布提醒中接收人为——个人：
                        string strSend_sqlFive = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.make_sure is null
                               and m.msg_status = '1'
                               and m.content_id='6'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                        string strSql = str0ne_Sql + " union " + strSend_sql0ne + " union " + strSend_sqlTwo + " union " + strSend_sqlThree + " union " + strSend_sqlFour + " union " + strSend_sqlFive;
                        DataSet ds_testNewShow = App.GetDataSet(strSql);
                        if (ds_testNewShow.Tables[0].Rows.Count > 0)
                        {

                            List<string> sqls = new List<string>();
                            Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShow frm = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShow();
                            isWindowOpen = true;
                           // frm.ShowDialog();
                            isWindowOpen = false;
                            isWindowPop = "1";
                            foreach (DataRow dr in ds_testNewShow.Tables[0].Rows)
                            {
                                DataRow[] drs = ds_testNewShow.Tables[0].Select("id='" + dr["id"].ToString() + "'");
                                if (drs.Length > 0)
                                {
                                    string strSqlUpdateOne = "update t_msg_info t set t.read_flag='true' where t.id='" + drs[0]["id"] + "'";
                                    sqls.Add(strSqlUpdateOne);
                                    string strSqlUpdateTwo = "update (select t2.read_flag from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + drs[0]["id"] + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.read_flag='true'";
                                    sqls.Add(strSqlUpdateTwo);
                                    App.ExecuteBatch(sqls.ToArray());
                                }
                            }
                        }
                        else
                        {
                            isCheckNews = "1";
                        }

                    }
                    else
                    {
                        if (isWindowOpen == false)//判断窗体是否处于打开状态
                        {
                            string strSqlNewOne = @"select distinct(m.id),
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m, t_in_patient p, t_msg_setting t 
                             where m.pid = p.id
                               and t.WARN_TYPE = m.WARN_TYPE
                               and t.MSG_START_UP = '1'
                               and t.MSG_VOLUNTARILY_POP = '1'
                               and m.msg_status = '0'
                               and m.read_flag is null
                               and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0 and m.receive_user_id='" + App.UserAccount.UserInfo.User_id + "'";
                            //消息发布提醒中接收人为——全院：
                            string strSend_sql0ne = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.read_flag is null
                               and m.msg_status = '1'
                               and m.content_id='1'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                            //消息发布提醒中接收人为——全院医生或全院护士：
                            string strSend_sqlTwo = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.read_flag is null
                               and m.msg_status = '1'
                               and p.role_type in ('D','N')
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                            //消息发布提醒中接收人为——科室：
                            string strSend_sqlThree = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.read_flag is null
                               and m.msg_status = '1'
                               and m.content_id='4'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                            //消息发布提醒中接收人为——病区：
                            string strSend_sqlFour = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.read_flag is null
                               and m.msg_status = '1'
                               and m.content_id='5'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                            //消息发布提醒中接收人为——个人：
                            string strSend_sqlFive = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.id=p.id
                               and p.read_flag is null
                               and m.msg_status = '1'
                               and m.content_id='6'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                            string strSqlNew = strSqlNewOne + " union " + strSend_sql0ne + " union " + strSend_sqlTwo + " union " + strSend_sqlThree + " union " + strSend_sqlFour + " union " + strSend_sqlFive;
                            DataSet ds_testNewShow = App.GetDataSet(strSqlNew);
                            if (ds_testNewShow.Tables[0].Rows.Count > 0)
                            {
                                Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShowLittle f = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShowLittle(App.UserAccount.UserInfo.User_id);//定义消息框的一个对象
                                isWindowOpen = true;
                               // f.ShowDialog();
                                isWindowOpen = false;

                            }
                        }
                    }
                    #endregion




                }
                catch
                { }
                Thread.Sleep(120000);
            }
            while (true);
        }

        /// <summary>
        /// 时时上传文书图片
        /// </summary>
        private static void UploadDocfiles()
        {
            while (1 != 0)
            {
                try
                {
                    string pth = App.SysPath + "\\temp";
                    DirectoryInfo Dir = new DirectoryInfo(pth);
                    foreach (FileInfo tfile in Dir.GetFiles())
                    {
                        if (App.UpLoadFtp(pth + "\\" + tfile.ToString(), tfile.ToString(), "D", tfile.ToString().Split('_')[0]))
                        {
                            File.Delete(pth + "\\" + tfile.ToString());
                        }

                    }

                }
                catch
                { }

                //附带上传没有上传完成的文书
                App.UpLoadUnfinshDocs();

                Thread.Sleep(300000);
            }
        }

        /// <summary>
        /// 清除所有的菜单
        /// </summary>
        private void Menu_Clear()
        {
            for (int i = 0; i < ribbonControl_main.Items.Count; i++)
            {
                if (ribbonControl_main.Items[i].GetType().ToString() == "DevComponents.DotNetBar.ButtonItem")
                {
                    ribbonControl_main.Items.Remove(ribbonControl_main.Items[i]);
                    Menu_Clear();
                }
            }
        }


        /// <summary>
        /// 初始化系统
        /// </summary>
        private void IniSystem()
        {
            //App.Progress("系统正在初始化，请稍后...");
            if (App.UserAccount != null)
            {
                if (App.UserAccount.CurrentSelectRole != null)
                {
                    for (int i = 0; i < this.toolbar.Items.Count; i++)
                    {

                        if (this.toolbar.Items[i].Name == "tsbtnDutySet")
                        {
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("科主任") || App.UserAccount.CurrentSelectRole.Role_name.Contains("科副主任"))
                            {
                                this.toolbar.Items[i].Visible = true;
                            }
                            else
                            {
                                this.toolbar.Items[i].Visible = false;
                            }
                        }
                    }

                    this.Cursor = Cursors.WaitCursor;

                    App.MdiFormTittle = "当前用户：" + App.UserAccount.UserInfo.User_name + "     工号:" + App.UserAccount.Account_name + "     职称：" + App.UserAccount.UserInfo.U_tech_post_name + "     角色：" + App.UserAccount.CurrentSelectRole.Role_name;
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "0" && App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        App.MdiFormTittle = App.MdiFormTittle + "     科室：" + App.UserAccount.CurrentSelectRole.Section_name;
                    }
                    else if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "0" && App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        App.MdiFormTittle = App.MdiFormTittle + "     病区：" + App.UserAccount.CurrentSelectRole.Sickarea_name;
                    }
                    else
                    {

                    }

                    App.ParentForm = this;
                    lblUserInfo.Text = App.MdiFormTittle;


                    //MenuBar.Items.Clear();
                    Menu_Clear();

                    Class_Table[] tabsqls = new Class_Table[2];

                    tabsqls[0] = new Class_Table();
                    tabsqls[0].Sql = "select * from t_permission where PERM_KIND='1' order by num asc";
                    tabsqls[0].Tablename = "permssion";

                    tabsqls[1] = new Class_Table();
                    tabsqls[1].Sql = "select PERM_CODE,FUNCTION,VERSION,DLLNAME from t_permission_fuctions";//,FUNCTIONIMAGE 
                    tabsqls[1].Tablename = "permission_fuctions";

                    DataSet ds = App.GetDataSet(tabsqls);
                    Class_Permission[] MenuPermissions = new Class_Permission[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //菜单项
                        MenuPermissions[i] = new Class_Permission();
                        MenuPermissions[i].Id = ds.Tables["permssion"].Rows[i]["id"].ToString();
                        MenuPermissions[i].Perm_code = ds.Tables["permssion"].Rows[i]["PERM_CODE"].ToString();
                        MenuPermissions[i].Perm_name = ds.Tables["permssion"].Rows[i]["PERM_NAME"].ToString();
                        MenuPermissions[i].Perm_kind = ds.Tables["permssion"].Rows[i]["PERM_KIND"].ToString();
                        MenuPermissions[i].Num = ds.Tables["permssion"].Rows[i]["NUM"].ToString();

                        //菜单项详细信息
                        MenuPermissions[i].Permission_Info = new Class_Permission_Info();

                        DataRow[] dsinforows = ds.Tables["permission_fuctions"].Select("PERM_CODE='" + MenuPermissions[i].Perm_code + "'");
                        if (dsinforows != null)
                        {
                            if (dsinforows.Length > 0)
                            {
                                MenuPermissions[i].Permission_Info.Perm_code = dsinforows[0]["PERM_CODE"].ToString();
                                MenuPermissions[i].Permission_Info.Function = dsinforows[0]["FUNCTION"].ToString();
                                MenuPermissions[i].Permission_Info.Version = dsinforows[0]["VERSION"].ToString();
                                MenuPermissions[i].Permission_Info.DllName = dsinforows[0]["DLLNAME"].ToString();
                                //MenuPermissions[i].Permission_Info.Dll = (byte[])dsinfo.Tables[0].Rows[0]["PERM_DLL"];
                                //MenuPermissions[i].Permission_Info.FunctionImage = (byte[])dsinforows[0]["FUNCTIONIMAGE"];
                                //MenuPermissions[i].Permission_Info.Ismainfrom = dsinforows[0]["ismainfrom"].ToString();
                            }
                        }
                    }
                    //刷新树结点
                    IniMenuTreeview(MenuPermissions, ribbonControl_main);
                    for (int i = 0; i < ribbonControl_main.Items.Count; i++)
                    {
                        if (ribbonControl_main.Items[i].GetType().ToString() == "DevComponents.DotNetBar.ButtonItem")
                            IniMenuTrvNode(MenuPermissions, (ButtonItem)ribbonControl_main.Items[i]);
                    }

                    //隐藏子节点为空的主菜单
                    HideAllRootNoChildsMenu();


                    //设置工具栏控件                      
                    //App.BtnEnableSet(App.UserAccount.CurrentSelectRole.Permissions, this.toolStrip1);  
                    //IniToolBar();
                    this.Cursor = Cursors.Default;

                    //加载工具栏按钮
                    ShowToolBars();
                }
                //this.Show();
                //this.Activate();

                this.Focus();
                ShowMainFrm();
                //App.HideProgress();
            }
        }


        /// <summary>
        /// 初始化工具栏 
        /// </summary>
        private void IniToolBar()
        {

            for (int i = 0; i < this.toolbar.Items.Count; i++)
            {
                if (this.toolbar.Items[i].Name != "tbtnResetSystem" &&
                    this.toolbar.Items[i].Name != "tbtnRoleChose" &&
                    this.toolbar.Items[i].Name != "tbtnAccountClear" &&
                    this.toolbar.Items[i].Name != "tsbtnSectionAccountSets" &&
                    this.toolbar.Items[i].Name != "tbtnPassword" &&
                    this.toolbar.Items[i].Name != "tsbtnZLGF" &&
                    this.toolbar.Items[i].Name != "tsbtnHelp" &&
                    this.toolbar.Items[i].Name != "tsbtnDutySet" &&
                    this.toolbar.Items[i].Name != "tsbtnSmallTemplateSave"
                   )
                {
                    this.toolbar.Items[i].Enabled = false;
                }

                if (this.toolbar.Items[i].Name == "tsbtnDutySet")
                {

                    this.toolbar.Items[i].Visible = false;

                }
            }
            //tsbtnSectionAccountSets.Visible = true;
            //tsbtnSectionAccountSets.Enabled = true;
        }

        /// <summary>
        /// 初始化菜单树的根结点
        /// </summary>
        /// <param name="MenuPermissions">菜单项集合</param>
        /// <param name="trv">菜单树</param>
        private void IniMenuTreeview(Class_Permission[] MenuPermissions, DevComponents.DotNetBar.RibbonControl Menu)
        {
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == 3)
                {
                    //ToolStripMenuItem mn = new ToolStripMenuItem();
                    //mn.Text = MenuPermissions[i].Perm_name;
                    //mn.Name = MenuPermissions[i].Perm_code;
                    //mn.Tag = MenuPermissions[i];
                    //mn.Image = App.ByteToImg(MenuPermissions[i].Permission_Info.FunctionImage);
                    //mn.Click += new EventHandler(AllMenuItem_Click);
                    //Menu.Items.Add(mn);


                    ButtonItem mn = new ButtonItem();
                    mn.ButtonStyle = eButtonStyle.ImageAndText;
                    mn.PopupType = ePopupType.Menu;
                    mn.Text = MenuPermissions[i].Perm_name;
                    mn.Name = MenuPermissions[i].Perm_code;
                    mn.Tag = MenuPermissions[i];
                    mn.Image = App.ByteToImg(MenuPermissions[i].Permission_Info.FunctionImage);
                    mn.ImageFixedSize = new Size(16, 16);
                    mn.Click += new EventHandler(AllMenuItem_Click);
                    mn.AutoExpandOnClick = true;
                    Menu.Items.Add(mn);
                    //Menu.RecalcSize();
                }
            }
        }

        /// <summary>
        /// 初始化菜单树子结点
        /// </summary>
        /// <param name="MenuPermissions">所有菜单项</param>
        /// <param name="tn">菜单树结点</param>
        private void IniMenuTrvNode(Class_Permission[] MenuPermissions, ButtonItem Item)
        {
            Class_Permission tempPermission = (Class_Permission)Item.Tag;
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == tempPermission.Perm_code.Length + 2 &&
                    MenuPermissions[i].Perm_code.Substring(0, tempPermission.Perm_code.Length).Contains(tempPermission.Perm_code))
                {
                    if (IsHaveRight(MenuPermissions[i].Perm_code))
                    {
                        ButtonItem mn = new ButtonItem();
                        mn.Text = MenuPermissions[i].Perm_name;
                        mn.Name = MenuPermissions[i].Perm_code;
                        mn.Tag = MenuPermissions[i];
                        mn.PopupType = ePopupType.Menu;
                        mn.Image = App.ByteToImg(MenuPermissions[i].Permission_Info.FunctionImage);
                        mn.ImageFixedSize = new Size(16, 16);
                        mn.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.SystemDefault;
                        mn.Click += new EventHandler(AllMenuItem_Click);
                        IniMenuTrvNode(MenuPermissions, mn);
                        Item.SubItems.Add(mn);
                    }
                }
            }
        }


        /// <summary>
        /// 隐藏所有没有子节点的根节点菜单
        /// </summary>
        private void HideAllRootNoChildsMenu()
        {
            for (int i = 0; i < ribbonControl_main.Items.Count; i++)
            {
                if (ribbonControl_main.Items[i].GetType().ToString() == "DevComponents.DotNetBar.ButtonItem")
                {
                    ButtonItem MenuItem = (ButtonItem)ribbonControl_main.Items[i];
                    if (MenuItem.SubItems.Count == 0)
                    {
                        if (!IsHaveRight(MenuItem.Name))
                        {
                            ribbonControl_main.Items[i].Visible = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 显示主界面
        /// </summary>
        private void ShowMainFrm()
        {
            try
            {
                if (App.UserAccount != null)
                {
                    bool flag = false;
                    if (App.UserAccount.CurrentSelectRole != null)
                    {

                        //tsbtnTemplateSave.Visible = false;
                        /*
                         * 正式帐号
                         */
                        if (App.UserAccount.CurrentSelectRole.Role_type == "M")
                        {
                            //系统管理员
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            //医生
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("门诊"))
                            {
                                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Bifrost_MZ_EMR.dll");
                                Type tmpType = assmble.GetType("Bifrost_MZ_EMR.Test");
                                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("UcShowMain");
                                object tmpobj = assmble.CreateInstance("Bifrost_MZ_EMR.Test");
                                tmpM.Invoke(tmpobj, null);
                                flag = true;
                            }
                            else
                            {
                                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                                Type tmpType = assmble.GetType("Base_Function.Base");
                                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmShow");
                                object tmpobj = assmble.CreateInstance("Base_Function.Base");
                                tmpM.Invoke(tmpobj, null);
                                flag = true;
                            }

                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //护士                    
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("Base_Function.Base");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmShow");
                            object tmpobj = assmble.CreateInstance("Base_Function.Base");
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "H")
                        {
                            //护理部                   
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("Base_Function.Base");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmUCEParamShow");
                            object tmpobj = assmble.CreateInstance("Base_Function.Base");//ThreadManagement.Template.frmUCEParamShow;ThreadManagement.frmUCEParam
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "Y" || App.UserAccount.CurrentSelectRole.Role_type == "Z")
                        {
                            //医教处                 
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("Base_Function.Base");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmYWCParamShow");
                            object tmpobj = assmble.CreateInstance("Base_Function.Base");//ThreadManagement.Template.frmYWCParamShow
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "B" ||
                       App.UserAccount.CurrentSelectRole.Role_type == "U")
                        {
                            //病情案管理                   
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("Base_Function.Base");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmFormTestShow");
                            object tmpobj = assmble.CreateInstance("Base_Function.Base");
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "O")
                        {
                            //其他
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("检验科影像科医师") ||
                                App.UserAccount.CurrentSelectRole.Role_name.Contains("辅助"))
                            {
                                //病情案管理                   
                                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                                Type tmpType = assmble.GetType("Base_Function.Base");
                                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmRightRun");
                                object tmpobj = assmble.CreateInstance("Base_Function.Base");
                                tmpM.Invoke(tmpobj, null);
                                flag = true;

                                #region 工具栏的设置
                                for (int i = 0; i < this.toolbar.Items.Count; i++)
                                {
                                    if (this.toolbar.Items[i].Name != "tbtnResetSystem" &&
                                        this.toolbar.Items[i].Name != "tbtnRoleChose" &&
                                        this.toolbar.Items[i].Name != "tbtnAccountClear" &&
                                        this.toolbar.Items[i].Name != "tsbtnSectionAccountSets" &&
                                        this.toolbar.Items[i].Name != "tbtnPassword" &&
                                        this.toolbar.Items[i].Name != "tsbtnHelp")
                                    {
                                        this.toolbar.Items[i].Visible = false;
                                    }
                                    else
                                    {
                                        this.toolbar.Items[i].Enabled = true;
                                    }
                                }

                                //labelItemBktx.Visible = false;
                                //toolHuizhen.Visible = false;
                                //toolZhikong.Visible = false;
                                #endregion
                            }
                        }
                        //if (App.UserAccount.CurrentSelectRole.Role_type != "D")
                        //{
                            for (int i = 0; i < this.toolbar.Items.Count; i++)
                                {
                                    if (this.toolbar.Items[i].Name == "btnInsertDiosgin" ||
                                        this.toolbar.Items[i].Name == "btnRefreshDiosgin" )
                                    {
                                        this.toolbar.Items[i].Enabled = false;
                                    }
                                }
                        //}

                        //if (flag)
                        //{
                            //DevComponents.DotNetBar.TabItem temptab = new DevComponents.DotNetBar.TabItem();
                            //temptab.Name = Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();
                            //temptab.Text = Application.OpenForms[Application.OpenForms.Count - 1].Text;
                            //temptab.AttachedControl = (Control)Application.OpenForms[Application.OpenForms.Count - 1];
                            //opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//记录打开窗体的步骤（dll名+函数名+窗体类型）                          
                            //App.Openforms.Add(opstr);
                            //tabOpenForms.Tabs.Add(temptab);
                            //tabOpenForms.Refresh();
                        //}
                        //toolHuizhen.Image = imageList1.Images[0];
                        //toolZhikong.Image = imageList1.Images[1];
                    }
                    else
                    {
                        if (frmMain.AccountType != 0)
                        {
                            /*
                             * 临时帐号
                             */
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("frameEMR.test");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmTempAccount_UserInfo");
                            object tmpobj = assmble.CreateInstance("frameEMR.test");
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                            if (flag)
                            {
                                //DevComponents.DotNetBar.TabItem temptab = new DevComponents.DotNetBar.TabItem();
                                //temptab.Name = Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();
                                //temptab.Text = Application.OpenForms[Application.OpenForms.Count - 1].Text;
                                //temptab.AttachedControl = (Control)Application.OpenForms[Application.OpenForms.Count - 1];
                                //opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//记录打开窗体的步骤（dll名+函数名+窗体类型）                          
                                //App.Openforms.Add(opstr);
                                //tabOpenForms.Tabs.Add(temptab);
                                //tabOpenForms.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.HideProgress();
                App.MsgErr("初始化出错，原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 检查是否存在已打开的子窗体
        /// </summary>
        /// <param name="strfunct">窗体的函数名</param>
        /// <returns></returns>
        private bool checkchildFrmExist(string strfunct)
        {
            for (int i = 0; i < App.Openforms.Count; i++)
            {
                if (App.Openforms[i].ToString().Contains(strfunct))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获得打开窗体的类型
        /// </summary>
        /// <param name="strfunct">窗体的函数名</param>
        /// <returns></returns>
        private string Getfrmtype(string strfunct)
        {
            try
            {
                for (int i = 0; i < App.Openforms.Count; i++)
                {
                    if (App.Openforms[i].ToString().Contains(strfunct))
                    {
                        return App.Openforms[i].ToString().Split(';')[1];
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 所有菜单的功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ButtonItem temp = (ButtonItem)sender;
            if (temp.Tag != null)
            {
                try
                {

                    Class_Permission tempPermission = (Class_Permission)temp.Tag;
                    if (tempPermission.Permission_Info.Function.Trim() != "")
                    {
                        System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\" + tempPermission.Permission_Info.DllName);
                        string namespacestr = assmble.ManifestModule.Name.Split('.')[0];
                        if (tempPermission.Permission_Info.DllName == "Base_App.dll")
                        {
                            namespacestr = "Bifrost";
                        }

                        Type tmpType = assmble.GetType(namespacestr + "." + tempPermission.Permission_Info.Function.Split('.')[0]);
                        System.Reflection.MethodInfo tmpM = tmpType.GetMethod(tempPermission.Permission_Info.Function.Split('.')[1]);
                        object tmpobj = assmble.CreateInstance(namespacestr + "." + tempPermission.Permission_Info.Function.Split('.')[0]);
                        opstr = namespacestr + "." + tempPermission.Permission_Info.Function;
                        if (!checkchildFrmExist(opstr))
                        {
                            //打开新窗体  
                            tmpM.Invoke(tmpobj, null);
                            //DevComponents.DotNetBar.TabItem temptab = new DevComponents.DotNetBar.TabItem();
                            //temptab.Name = Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();
                            //temptab.Text = Application.OpenForms[Application.OpenForms.Count - 1].Text;
                            //temptab.AttachedControl = (Control)Application.OpenForms[Application.OpenForms.Count - 1];
                            //opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//记录打开窗体的步骤（dll名+函数名+窗体类型）                          
                            //App.Openforms.Add(opstr);//Inhospital_Info.Test.FrmShow;Inhospital_Info.frmMain

                            //tabOpenForms.Tabs.Add(temptab);
                            //tabOpenForms.Refresh();
                            //opstr = "";
                            //tabOpenForms.SelectedTab = tabOpenForms.Tabs[tabOpenForms.Tabs.Count - 1];

                        }
                        else//打开已经有的窗体
                        {
                            //string frmtype = Getfrmtype(opstr);
                            //for (int j = 0; j < tabOpenForms.Tabs.Count; j++)
                            //{
                            //    if (frmtype == tabOpenForms.Tabs[j].Name)
                            //    {
                            //        tabOpenForms.SelectedTab = tabOpenForms.Tabs[j];
                            //        tabOpenForms.Refresh();
                            //        break;
                            //    }
                            //}
                            return;
                        }
                    }
                    //IniToolBar();
                }
                catch (Exception ex)
                {
                    App.MsgErr("再调用菜单功能时出错，原因:" + ex.Message);
                }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
        }

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {

            #region 设置自定义样式
            string Colorstr = App.Read_ConfigInfo("SYSTEMSET", "MAINCOLOR", App.SysPath + "\\Config.ini");
            string stylestr = App.Read_ConfigInfo("SYSTEMSET", "MAINSTYLE", App.SysPath + "\\Config.ini");

            if (stylestr != "")
            {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), stylestr);
                StyleManager.ChangeStyle(style, Color.Empty);
            }
            if (Colorstr != "")
            {

                Color tempColor = System.Drawing.Color.FromArgb(Convert.ToInt16(Colorstr.Split(',')[0]),
                    Convert.ToInt16(Colorstr.Split(',')[1]),
                    Convert.ToInt16(Colorstr.Split(',')[2]),
                    Convert.ToInt16(Colorstr.Split(',')[3]));

                //if (StyleManager.IsMetro(StyleManager.Style))
                //    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
                //else
                //    StyleManager.ColorTint = (Color)source.CommandParameter;
                if (StyleManager.IsMetro(StyleManager.Style))
                    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, tempColor);
                else
                    StyleManager.ColorTint = tempColor;



                //                buttonStyleCustom.SelectedColor =
                //              buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor;
                //              StyleManager.ColorTint = buttonStyleCustom.SelectedColor;
            }

            for (int i = 0; i < buttonChangeStyle.SubItems.Count; i++)
            {
                if (buttonChangeStyle.SubItems[i].CommandParameter != null)
                {
                    if (buttonChangeStyle.SubItems[i].CommandParameter.ToString() == stylestr)
                    {
                        ButtonItem tempbtnitem = (ButtonItem)buttonChangeStyle.SubItems[i];
                        tempbtnitem.Checked = true;
                    }
                }
            }
            #endregion

            IniToolBar();
            if (App.UserAccount != null)
            {
                if (App.UserAccount.UserInfo != null)
                {

                    /*
                    * 工具栏                     
                    */
                    if (App.UserAccount.Kind == 53 || App.UserAccount.Kind == 54 || App.UserAccount.Kind == 7921 || App.UserAccount.Kind == 52 || App.UserAccount.Kind == 70)
                    {
                        //实习生、研究生、进修生
                        tbtnAccountClear.Enabled = true;
                        tbtnAccountClear.Visible = true;
                    }
                    //this.Show();
                    //角色设置

                    if (!App.isOtherSystemRefrenceflag)
                    {
                        frmRoleChose fmRole = new frmRoleChose();
                        App.ButtonStytle(fmRole, false);
                        fmRole.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        fmRole.ControlBox = false;
                        fmRole.MaximizeBox = false;
                        fmRole.MinimizeBox = false;
                        fmRole.ShowDialog();

                        //App.Progress("正在初始化系统，请稍后..."); 
                    }
                    else
                    {
                        bool isHaveMoreRolesRanges = false;
                        if (App.UserAccount.Roles.Length > 1)
                        {
                            isHaveMoreRolesRanges = true;
                        }
                        else
                        {
                            if (App.UserAccount.Roles[0].Rnages.Length > 1)
                            {
                                isHaveMoreRolesRanges = true;
                            }
                            else
                            {
                                App.UserAccount.CurrentSelectRole = App.UserAccount.Roles[0];
                            }
                        }

                        if (isHaveMoreRolesRanges)
                        {
                            if (App.UserAccount.CurrentSelectRole == null)
                            {
                                frmRoleChose fmRole = new frmRoleChose();
                                App.ButtonStytle(fmRole, false);

                                fmRole.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                                fmRole.ControlBox = false;
                                fmRole.MaximizeBox = false;
                                fmRole.MinimizeBox = false;
                                fmRole.ShowDialog();
                            }
                        }
                    }

                    //strToolSet = App.Read_ConfigInfo("SYSTEMSET", "TOOLS", Application.StartupPath + "\\Config.ini");
                    //if (strToolSet == "")
                    //{
                    //    ShowToolsSet();
                    //}
                    //else
                    //{
                    //    ShowToolBars();
                    //}

                    IniSystem();


                    if (App.UserAccount.CurrentSelectRole != null)
                    {
                        if (App.UserAccount.CurrentSelectRole.Role_name.Contains("主任") &&
                            Convert.ToInt16(App.UserAccount.CurrentSelectRole.Rnages.Length) > 0)
                        {
                            if (App.UserAccount.CurrentSelectRole.Rnages.Length > 0)
                            {
                                tsbtnSectionAccountSets.Enabled = true;
                                tsbtnSectionAccountSets.Visible = true;
                                //武汉东苑注释(需求明确指示:他是院长也不给他)
                                //if (App.UserAccount.CurrentSelectRole.Role_name.Trim() == "科主任")
                                //{//角色职务为“科主任”的用户增加“科室评分”功能
                                //    tbtnGrade.Enabled = true;
                                //    tbtnGrade.Visible = true;
                                //    midebar.Refresh();
                                //}
                            }
                        }
                    }
                }
                else
                {
                    /*
                     * 测试帐号
                     */
                    App.ParentForm = this;
                    ShowMainFrm();

                    for (int i = 0; i < this.toolbar.Items.Count; i++)
                    {
                        if (this.toolbar.Items[i].Name != "tbtnResetSystem" &&
                            this.toolbar.Items[i].Name != "tbtnPassword")
                        {
                            this.toolbar.Items[i].Enabled = false;
                            this.toolbar.Items[i].Visible = false;
                        }
                    }

                }
            }
            CurrentChildFormsCount = Application.OpenForms.Count;
            //this.Visible=true;
            if (App.UserAccount == null)
            {
                Application.Exit();
            }
            //else
            //{
            //    if (App.UserAccount.UserInfo == null)
            //    {
            //        Application.Exit();
            //    }
            //}
            try
            {
                //如果更新程序需要更新的话
                if (File.Exists(App.SysPath + "\\EmrUpdate.ex"))
                {
                    if (File.Exists(App.SysPath + "\\EmrUpdate.exe"))
                        File.Delete(App.SysPath + "\\EmrUpdate.exe");
                    File.Move(App.SysPath + "\\EmrUpdate.ex", App.SysPath + "\\EmrUpdate.exe");
                }
            }
            catch
            { }
            NoticeLight.IsBackground = true;
            NoticeLight.Start();

            UploadDoc.IsBackground = true;
            UploadDoc.Start();


            toolbar.Width = toolbar.Width + 1;

         


        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (App.UserAccount != null)
            {
                if (App.UserAccount.UserInfo != null)
                {
                    if (!isReset)
                    {
                        if (App.Ask("是否正要退出吗？") == false)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            //if (App.sr != null)
                            //{
                            //    App.sr.RcDispose();
                            //}
                            SetBookLock();//锁定护理文书
                            NoticeLight.Abort();
                            UploadDoc.Abort();
                            // App.SendtoServerMes.Abort();
                            //  Application.ExitThread();
                            Application.Exit();
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 锁定护理文书
        /// </summary>
        private void SetBookLock()
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].GetType().ToString() == "DevComponents.DotNetBar.TabControl")
                    {
                        if (this.Controls[i].Controls[0].Controls[0].GetType().ToString() == "Base_Function.BLL_DOCTOR.ucMain")
                        {
                            Base_Function.BLL_DOCTOR.ucMain ucMain = this.Controls[i].Controls[0].Controls[0] as Base_Function.BLL_DOCTOR.ucMain;
                            if (ucMain.Controls[0].GetType().ToString() == "DevComponents.DotNetBar.TabControl")
                            {
                                DevComponents.DotNetBar.TabControl tabC = ucMain.Controls[0] as DevComponents.DotNetBar.TabControl;
                                for (int j = 0; j < tabC.Tabs.Count; j++)
                                {
                                    if (tabC.Tabs[j].Text.Contains(ucMain.currentPatient.Patient_Name))
                                    {
                                        for (int k = 0; k < tabC.Tabs[j].AttachedControl.Controls.Count; k++)
                                        {
                                            if (tabC.Tabs[1].AttachedControl.Controls[k].Name == "ucDoctorOperater")
                                            {
                                                Base_Function.BLL_DOCTOR.ucDoctorOperater ucDoc = tabC.Tabs[1].AttachedControl.Controls[k] as Base_Function.BLL_DOCTOR.ucDoctorOperater;
                                                ucDoc.IsLockBook(ucMain.currentPatient.Id, "0");
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        /// <summary>
        /// 角色设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnRoleChose_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                bool flag = true;
                flag = App.Ask("角色切换之前，确定关闭已打开的窗体吗？");
                if (flag == true)
                {
                    Form[] frmList = this.MdiChildren;
                    foreach (Form frm in frmList)
                    {
                        frm.Close();
                    }
                    //tabOpenForms.Tabs.Clear();
                    //App.Openforms.Clear();
                    //CurrentChildFormsCount = Application.OpenForms.Count;
                    //tabOpenForms.Refresh();
                }
                else
                    return;
            }
            Class_Role CurrentTemp = App.UserAccount.CurrentSelectRole;
            frmRoleChose fm = new frmRoleChose();
            App.ButtonStytle(fm, false);
            fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            fm.ControlBox = false;
            fm.MaximizeBox = false;
            fm.MinimizeBox = false;
            fm.ShowDialog();

            //if (CurrentTemp != App.UserAccount.CurrentSelectRole)
            //{  

            App.MdiFormTittle = "";
            tabControl_Main.Tabs.Clear();
            IniSystem();

            //lblUserInfo.Text = this.Text;
            //this.Text = "";
            //}
        }

        /// <summary>
        /// 系统注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnResetSystem_Click(object sender, EventArgs e)
        {
            if (App.Ask("真的要注销系统吗？"))
            {
                isReset = true;
                Application.Restart();
            }
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnPassword_Click(object sender, EventArgs e)
        {
            frmPasswordChanged frm = new frmPasswordChanged();
            App.ButtonStytle(frm, false);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            frm.ControlBox = false;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.ShowDialog();
        }

        /// <summary>
        /// 账号注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnAccountClear_Click(object sender, EventArgs e)
        {
            #region

            if (App.Ask("注销帐号之后，当前帐号就无法登录当前系统，确定要注销吗？"))
            {
                string result = "";
                if (App.UserAccount.Kind == 53 || App.UserAccount.Kind == 54 || App.UserAccount.Kind == 7921)
                {
                    //实习生、研究生、进修生
                    result = "";
                }
                else if (App.UserAccount.Kind == 52)
                {

                    //正式
                    DataSet ds_docs = App.GetDataSet("select t.tid,t3.patient_name,t3.pid,t2.textname,t.doc_name,t.havedoctorsign from t_patients_doc t inner join t_text t2 on t.textkind_id=t2.id inner join t_in_patient t3 on t.patient_id=t3.id where t.createid=" + App.UserAccount.UserInfo.User_id + "");
                    if (ds_docs != null)
                    {
                        if (ds_docs.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds_docs.Tables[0].Rows.Count; i++)
                            {
                                if (ds_docs.Tables[0].Rows[i]["havedoctorsign"].ToString() != "Y")
                                {

                                    string strtemp = "病人姓名：" + ds_docs.Tables[0].Rows[i]["patient_name"].ToString() + ",住院号：" + ds_docs.Tables[0].Rows[i]["pid"].ToString() + ",文书类型：" + ds_docs.Tables[0].Rows[i]["textname"].ToString() + ",文书名称：" + ds_docs.Tables[0].Rows[i]["doc_name"].ToString();
                                    if (result == "")
                                    {
                                        result = "你还有一些文书没有签名：\n";
                                        result = result + strtemp;

                                    }
                                    else
                                    {
                                        result = result + "\n" + strtemp;
                                    }
                                }
                            }
                        }
                    }
                }

                if (result == "")
                {


                    ////注销操作
                    //string[] sqls = new string[2];
                    //sqls[0] = "delete from t_acc_role_range a where a.acc_role_id in (select b.id from t_acc_role b where b.account_id=" + App.UserAccount.Account_id + ")";
                    //sqls[1] = "delete from t_acc_role c where c.account_id=" + App.UserAccount.Account_id + "";

                    //if (App.ExecuteBatch(sqls) > 0)
                    //{
                    //    App.Msg("帐号注销成功！");
                    //    LogHelper.Account_SystemLog(App.UserAccount.Account_id, "注销", "");
                    //    isReset = true;
                    //    Application.Restart();
                    //} 

                    frmPassWordConfirmDel fc = new frmPassWordConfirmDel();
                    fc.ShowDialog();
                }
                else
                {
                    App.MsgWaring(result);
                }
            }
            #endregion
        }

        /// <summary>
        /// 科主任账号维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSectionAccountSets_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("主任") &&
               App.UserAccount.CurrentSelectRole.Rnages.Length > 0)
            {
                frmUserInfoAccountSet1 AccountSet = new frmUserInfoAccountSet1();
                App.FormStytleSet(AccountSet, false);
                AccountSet.ShowDialog();
            }
            else
            {
                App.MsgWaring("该功能只有科主任才能使用！");
            }
        }

        /// <summary>
        /// 系统帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnHelp_Click(object sender, EventArgs e)
        {
            frmHelp fc = new frmHelp();
            fc.Show();
        }


        /// <summary>
        /// 诊疗规范
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnZLGF_Click(object sender, EventArgs e)
        {
            frmZLGF fc = new frmZLGF();
            fc.Show();
        }

        /// <summary>
        /// 值班设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnDutySet_Click(object sender, EventArgs e)
        {
            Bifrost.SYSTEMSET.frmDutyDoctorSet fc = new Bifrost.SYSTEMSET.frmDutyDoctorSet();
            App.ButtonStytle(fc, false);
            fc.ShowDialog();
        }


        private void ribbonControl_main_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ZhiKongflag)
            {
                if (tbtnQualityMide.Image == global::BifrostMainPro.Resource1.质控提醒)
                    tbtnQualityMide.Image = global::BifrostMainPro.Resource1.质控提醒2;
                else
                    tbtnQualityMide.Image = global::BifrostMainPro.Resource1.质控提醒;
            }
            else
            {
                tbtnQualityMide.Image = global::BifrostMainPro.Resource1.质控提醒;
            }


            if (MessageFlag)
            {

                if (tbtnMessageMide.Image == global::BifrostMainPro.Resource1.消息提醒)
                    tbtnMessageMide.Image = global::BifrostMainPro.Resource1.消息提醒2;
                else
                    tbtnMessageMide.Image = global::BifrostMainPro.Resource1.消息提醒;
            }

            if (isupdate == 1)
            {
                App.ShowTip("消息提示", "已经有了更新的版本，请及时更新系统！");
                isupdate = 0;
            }

            if (MsgContent != "")
            {
                App.ShowTip("消息提示", MsgContent, MsgURL);
                MsgContent = "";
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            App.ReleaseLockedDoc();
            base.OnClosed(e);
        }



        /// <summary>
        /// 关闭系统        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 工具栏管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToolSet_Click(object sender, EventArgs e)
        {
            ShowToolsSet();
            //ShowToolBars();
        }

        #region ButtonEventsSet
        private void tsbtnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Write(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Write = null;
            }
        }

        private void tsbtnSign_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Sign(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Sign = null;
            }
        }

        private void tsbtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Check(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Check = null;
            }
        }

        private void tsbtnModify_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Modify(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Modify = null;
            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Delete(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Delete = null;
            }
        }

        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Look(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Look = null;
            }
        }

        private void tsbtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Import(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Import = null;
            }
        }

        private void tsbtnOutPut_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_OutPut(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_OutPut = null;
            }
        }

        //知情同意书打印按钮方法
        private void ttsbtnBachePrint_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_BachePrint(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Print = null;
            }
        }

        private void tsbtnTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Template(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Template = null;
            }
        }

        private void tsbtnTemplateSave_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_TemplateSave(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_TemplateSave = null;
            }
        }

        private void tsbtnSmallTemplateSave_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_SmallTemplateSave(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
            }
        }

        private void ttsbtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Print(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Print = null;
            }
        }

        private void ttsbtnPrintContinue_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_PrintContinue(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_PrintContinue = null;
            }
        }


        private void tsbtnTempSave_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_TempSave(sender, e);
                if (App.A_RefleshTreeBook != null)
                {
                    App.A_RefleshTreeBook(sender, e);
                }
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_TempSave = null;
            }
        }

        private void tsbtnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Commit(sender, e);
                if (App.A_RefleshTreeBook != null)
                {
                    App.A_RefleshTreeBook(sender, e);
                }
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Commit = null;
            }
        }

        private void tsbtnBKSB_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_BKSB(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_BKSB = null;
            }
        }

        private void tsbtnCheckSick_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_CheckSick(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_CheckSick = null;
            }
        }

        private void tsbtnCheckTemprature_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_CheckTemprature(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_CheckTemprature = null;
            }
        }

        private void tsbtnCheckNurseRecord_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_tsbtnCheckNurseRecord(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_tsbtnCheckNurseRecord = null;
            }
        }

        private void tsbtnCheckLis_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_CheckLis(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_CheckLis = null;
            }
        }

        private void tsbtnCheckPacs_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_CheckPacs(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_CheckPacs = null;
            }
        }

        private void tsbtnCheckOperator_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_CheckOperator(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_CheckOperator = null;
            }
        }

        private void tsbtnPatientSickInfoApply_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_PatientSickInfoApply(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_PatientSickInfoApply = null;
            }
        }

        private void tsbtnBackSickInfoApply_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_BackSickInfoApply(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_BackSickInfoApply = null;
            }
        }

        private void tsbtnUsedSickInfoCheck_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_UsedSickInfoCheck(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_UsedSickInfoCheck = null;
            }
        }

        private void tsbtnDocRights_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_DocRights(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_DocRights = null;
            }
        }

        private void tsbtnMedicalRecordFinishing_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_MedicalRecordFinishing(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_MedicalRecordFinishing = null;
            }
        }

        private void tsbtnMedicalRecords_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_MedicalRecords(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_MedicalRecords = null;
            }
        }

        private void tsbtnUnfinishedWork_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_UnfinishedWork(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_UnfinishedWork = null;
            }
        }

        private void tsbtnInsertDiosgin_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_btnInsertDiosgin(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_btnInsertDiosgin = null;
            }
        }

        private void tsbtnRefreshDiosgin_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_btnRefreshDiosgin(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_btnRefreshDiosgin = null;
            }
        }
        #endregion

        private void toolbar_Paint(object sender, PaintEventArgs e)
        {
        }

        private void toolbar_Leave(object sender, EventArgs e)
        {
            // ButtonItem temp = (ButtonItem)sender;

        }

        private void tbtnConsultationMide_MouseLeave(object sender, EventArgs e)
        {
            ButtonItem temp = (ButtonItem)sender;
            temp.Checked = false;
        }

        /// <summary>
        /// 医生站质控提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnQualityMide_Click(object sender, EventArgs e)
        {
            frmQuitlyNotice fr = new frmQuitlyNotice();
            fr.ShowDialog();
        }

        /// <summary>
        /// 科主任科室评分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnGrade_Click(object sender, EventArgs e)
        {
            //ucfrmMainGradeRepart uc = new ucfrmMainGradeRepart(App.UserAccount.CurrentSelectRole.Section_name);
            //uc.Dock = DockStyle.Fill;
            //frmApp fm = new frmApp();
            //fm.Text = "科室评分";
            //fm.Controls.Add(uc);
            //App.FormStytleSet(fm, false);
            //fm.WindowState = FormWindowState.Normal;
            //fm.Show();

            try
            {
                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                Type tmpType = assmble.GetType("Base_Function.Base");
                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("DepartmentScore");
                object tmpobj = assmble.CreateInstance("Base_Function.Base");
                tmpM.Invoke(tmpobj, null);
            }
            catch (System.Exception ex)
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
            }
        }

        /// <summary>
        /// 消息提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnMessageMide_Click(object sender, EventArgs e)
        {
            ////Bifrost.SYSTEMSET.frmMessageShow fc = new frmMessageShow();
            ////fc.ShowDialog();
            ////DataSet ds_M_MESSAGE = App.GetDataSet("select * from T_MSG_INFO t where t.receive_user like '%" + App.UserAccount.UserInfo.User_id + "%' and (select count(*) from T_MSG_USER a where a.MSG_ID=t.id and USER_ID=" + App.UserAccount.UserInfo.User_id + ")=0");
            /////*消息提醒
            //// */
            ////if (ds_M_MESSAGE.Tables[0].Rows.Count > 0)
            ////{
            ////    MessageFlag = true;
            ////}
            ////else
            ////{
            ////    MessageFlag = false;
            ////}
            //App.MsgWaring("该功能尚未正式启用！");

            #region 消息提醒使用
            try
            {
                Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShow fc = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShow();
                istbtnMessageMide_Click = true;
               // fc.ShowDialog();
                istbtnMessageMide_Click = false;

            }
            catch
            {

            }
            #endregion

        }


        private void ribbonTabItem_Tools_Click(object sender, EventArgs e)
        {
            if (!toolbarflodflag)
            {
                ribbonControl_main.Height = ribbonControl_main.Height - toobarHeight;
                toolbarflodflag = true;
            }
            else
            {
                ribbonControl_main.Height = ribbonControl_main.Height + toobarHeight;
                toolbarflodflag = false;
            }

        }

        private void lblUserInfo_Click(object sender, EventArgs e)
        {

        }

        private void office2007StartButton2_Click(object sender, EventArgs e)
        {

        }

        #region 样式和颜色选择

        private string mainstyle = "";//获取设置的样式
        private string maincolor = "";//获取样式对应的颜色

        private bool m_ColorSelected = false;
        private eStyle m_BaseStyle = eStyle.Office2010Silver;
        private void buttonStyleCustom_ExpandChange(object sender, System.EventArgs e)
        {
            if (buttonStyleCustom.Expanded)
            {
                // Remember the starting color scheme to apply if no color is selected during live-preview
                m_ColorSelected = false;
                m_BaseStyle = StyleManager.Style;
            }
            else
            {
                if (!m_ColorSelected)
                {
                    if (StyleManager.IsMetro(StyleManager.Style))
                        StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Default;
                    else
                        StyleManager.ChangeStyle(m_BaseStyle, Color.Empty);
                }
            }
        }

        private void buttonStyleCustom_ColorPreview(object sender, DevComponents.DotNetBar.ColorPreviewEventArgs e)
        {
            if (StyleManager.IsMetro(StyleManager.Style))
            {
                Color baseColor = e.Color;
                StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, baseColor);
            }
            else
                StyleManager.ColorTint = e.Color;
         
            App.Write_ConfigInfo("SYSTEMSET", "MAINCOLOR", maincolor, App.SysPath + "\\Config.ini");
        }

        private void buttonStyleCustom_SelectedColorChanged(object sender, System.EventArgs e)
        {
            m_ColorSelected = true; // Indicate that color was selected for buttonStyleCustom_ExpandChange method
            buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor;

            maincolor = "" + buttonStyleCustom.SelectedColor.A.ToString() +
                        "," + buttonStyleCustom.SelectedColor.R.ToString() +
                        "," + buttonStyleCustom.SelectedColor.G.ToString() +
                        "," + buttonStyleCustom.SelectedColor.B.ToString() + "";
            App.Write_ConfigInfo("SYSTEMSET", "MAINCOLOR", maincolor, App.SysPath + "\\Config.ini");
        }


        private void AppCommandTheme_Executed(object sender, EventArgs e)
        {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
                mainstyle = source.CommandParameter.ToString();
                // Using StyleManager change the style and color tinting
                StyleManager.ChangeStyle(style, Color.Empty);
                //if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                //    buttonFile.BackstageTabEnabled = false;
                //else
                //    buttonFile.BackstageTabEnabled = true;
                maincolor = "";
                App.Write_ConfigInfo("SYSTEMSET", "MAINCOLOR", maincolor, App.SysPath + "\\Config.ini");
                App.Write_ConfigInfo("SYSTEMSET", "MAINSTYLE", mainstyle, App.SysPath + "\\Config.ini");
            }
            else if (source.CommandParameter is Color)
            {
                if (StyleManager.IsMetro(StyleManager.Style))
                    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
                else
                    StyleManager.ColorTint = (Color)source.CommandParameter;
                App.Write_ConfigInfo("SYSTEMSET", "MAINCOLOR", maincolor, App.SysPath + "\\Config.ini");
            }           
        }
        #endregion

        private void buttonStyleOffice2010Blue_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}