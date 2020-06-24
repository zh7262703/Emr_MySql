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
    /// ��������
    /// </summary>
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        #region ��Ϣ����ʹ�õı�ʶ
        private static string isWindowPop = "0";  //�ж��Ƿ����ѵ���
        private static string isCheckNews = "0";  //�ж�ϵͳ�Ƿ��һ�β�ѯ����Ϣ�����һ�û��ѯ��
        private static bool isWindowOpen = false;    //�жϵ�ǰ�����Ƿ���
        private static bool istbtnMessageMide_Click = false; //�Ƿ񵥻�����ǰ��Ϣ���Ѵ��� 
        #endregion

        private int childFormNumber = 0;

        public static bool isReset = false;                    //�ж��Ƿ���ע������

        //private ArrayList Openforms = new ArrayList(); //��¼�򿪴���Ĳ��裨dll��+������+�������ͣ�

        Thread NoticeLight = new Thread(new ThreadStart(ShowNoticeLight));

        Thread UploadDoc = new Thread(new ThreadStart(UploadDocfiles));    //ʱʱ�ϴ�����ͼƬ�ļ�

        private int cunum = 0;                           //С�Ƽ���

        private static bool Huizhenflag = false;         //������ʾ�ź� true ��ʾ false ����ʾ

        private static bool ZhiKongflag = false;         //����������ʾ�ź� true ��ʾ false ����ʾ 

        private static bool Bkglflag = false;            //�������� true���� false����ʾ

        private static bool MessageFlag = false;         //��Ϣ���� true��ʾ false����ʾ

        private static int CurrentChildFormsCount = 0;

        private string opstr = "";                       //�����ַ��� 

        //private int ActioMaxId = 0;                    //����ƶ���

        private string ServerIp = "";
        public static XmlDocument updateDoc = new XmlDocument();

        public static int AccountType = 0;

        private string strToolSet = "";                  //��ť����

        private RibbonBar tempToolbar = new RibbonBar();   //��ʱ�Ĵ湤����

        bool toolbarflodflag = false;
        WebRequest req;

        int toobarHeight = 0;

        public static int isupdate = 0;

        public static string MsgContent = "";
        public static string MsgURL = "";

        /// <summary>
        /// ������
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

        #region �Զ��巽��

        /// <summary>
        /// �����¹��ܹ�����
        /// </summary>
        private void AddToobar()
        {
            #region ��ʼ������������������
            //ϵͳע��
            ButtonItem tbtnResetSystem = new ButtonItem();
            tbtnResetSystem.AutoCheckOnClick = true;
            tbtnResetSystem.BeginGroup = false;
            tbtnResetSystem.Image = global::BifrostMainPro.Resource1.ϵͳע��;
            tbtnResetSystem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnResetSystem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
            tbtnResetSystem.Name = "tbtnResetSystem";
            tbtnResetSystem.OptionGroup = "Color";
            tbtnResetSystem.Text = "ϵͳע��";
            tbtnResetSystem.ThemeAware = true;
            tbtnResetSystem.Tooltip = "ϵͳע��";
            tbtnResetSystem.Click += new System.EventHandler(this.tbtnResetSystem_Click);

            //��ɫ�л�
            ButtonItem tbtnRoleChose = new ButtonItem();
            tbtnRoleChose.AutoCheckOnClick = true;
            tbtnRoleChose.BeginGroup = false;
            tbtnRoleChose.Image = global::BifrostMainPro.Resource1.��ɫ�л�;
            tbtnRoleChose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnRoleChose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tbtnRoleChose.Name = "tbtnRoleChose";
            tbtnRoleChose.OptionGroup = "Color";
            tbtnRoleChose.Text = "��ɫ�л�";
            tbtnRoleChose.ThemeAware = true;
            tbtnRoleChose.Tooltip = "��ɫ�л�";
            tbtnRoleChose.Click += new System.EventHandler(this.tbtnRoleChose_Click);

            //�����޸�
            ButtonItem tbtnPassword = new ButtonItem();
            tbtnPassword.AutoCheckOnClick = true;
            tbtnPassword.BeginGroup = false;
            tbtnPassword.Image = global::BifrostMainPro.Resource1.�����޸�;
            tbtnPassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnPassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tbtnPassword.Name = "tbtnPassword";
            tbtnPassword.OptionGroup = "Color";
            tbtnPassword.Text = "�����޸�";
            tbtnPassword.ThemeAware = true;
            tbtnPassword.Tooltip = "�����޸�";
            tbtnPassword.Click += new System.EventHandler(this.tbtnPassword_Click);

            //�ʺ�ע��
            ButtonItem tbtnAccountClear = new ButtonItem();
            tbtnAccountClear.AutoCheckOnClick = true;
            tbtnAccountClear.BeginGroup = false;
            tbtnAccountClear.Image = global::BifrostMainPro.Resource1.�˺�ע��;
            tbtnAccountClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tbtnAccountClear.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tbtnAccountClear.Name = "tbtnAccountClear";
            tbtnAccountClear.OptionGroup = "Color";
            tbtnAccountClear.Text = "�ʺ�ע��";
            tbtnAccountClear.ThemeAware = true;
            tbtnAccountClear.Tooltip = "�ʺ�ע��";
            tbtnAccountClear.Click += new System.EventHandler(this.tbtnAccountClear_Click);


            //�����˺�ά��
            ButtonItem tsbtnSectionAccountSets = new ButtonItem();
            tsbtnSectionAccountSets.AutoCheckOnClick = true;
            tsbtnSectionAccountSets.BeginGroup = false;
            tsbtnSectionAccountSets.Image = global::BifrostMainPro.Resource1.�����˺�ά��;
            tsbtnSectionAccountSets.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnSectionAccountSets.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnSectionAccountSets.Name = "tsbtnSectionAccountSets";
            tsbtnSectionAccountSets.OptionGroup = "Color";
            tsbtnSectionAccountSets.Text = "�����˺�ά��";
            tsbtnSectionAccountSets.ThemeAware = true;
            tsbtnSectionAccountSets.Tooltip = "�����˺�ά��";
            tsbtnSectionAccountSets.Click += new System.EventHandler(this.tsbtnSectionAccountSets_Click);


            //��ȡģ��
            ButtonItem tsbtnTemplate = new ButtonItem();
            tsbtnTemplate.AutoCheckOnClick = true;
            tsbtnTemplate.BeginGroup = false;
            tsbtnTemplate.Image = global::BifrostMainPro.Resource1.��ȡģ��;
            tsbtnTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnTemplate.Name = "tsbtnTemplate";
            tsbtnTemplate.OptionGroup = "Color";
            tsbtnTemplate.Text = "��ȡģ��";
            tsbtnTemplate.ThemeAware = true;
            tsbtnTemplate.Tooltip = "��ȡģ��";
            tsbtnTemplate.Click += new System.EventHandler(this.tsbtnTemplate_Click);


            //����Сģ��
            ButtonItem tsbtnSmallTemplateSave = new ButtonItem();
            tsbtnSmallTemplateSave.AutoCheckOnClick = true;
            tsbtnSmallTemplateSave.BeginGroup = false;
            tsbtnSmallTemplateSave.Image = global::BifrostMainPro.Resource1.����Сģ��;
            tsbtnSmallTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnSmallTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnSmallTemplateSave.Name = "tsbtnSmallTemplateSave";
            tsbtnSmallTemplateSave.OptionGroup = "Color";
            tsbtnSmallTemplateSave.Text = "����Сģ��";
            tsbtnSmallTemplateSave.ThemeAware = true;
            tsbtnSmallTemplateSave.Tooltip = "����Сģ��";
            tsbtnSmallTemplateSave.Click += new System.EventHandler(this.tsbtnSmallTemplateSave_Click);

            //����ģ��
            ButtonItem tsbtnTemplateSave = new ButtonItem();
            tsbtnTemplateSave.AutoCheckOnClick = true;
            tsbtnTemplateSave.BeginGroup = false;
            tsbtnTemplateSave.Image = global::BifrostMainPro.Resource1.����ģ��;
            tsbtnTemplateSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnTemplateSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnTemplateSave.Name = "tsbtnTemplateSave";
            tsbtnTemplateSave.OptionGroup = "Color";
            tsbtnTemplateSave.Text = "����ģ��";
            tsbtnTemplateSave.ThemeAware = true;
            tsbtnTemplateSave.Tooltip = "����ģ��";
            tsbtnTemplateSave.Click += new System.EventHandler(this.tsbtnTemplateSave_Click);

            //��ӡ
            ButtonItem ttsbtnPrint = new ButtonItem();
            ttsbtnPrint.AutoCheckOnClick = true;
            ttsbtnPrint.BeginGroup = false;
            ttsbtnPrint.Image = global::BifrostMainPro.Resource1.��ӡ;
            ttsbtnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ttsbtnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            ttsbtnPrint.Name = "ttsbtnPrint";
            ttsbtnPrint.OptionGroup = "Color";
            ttsbtnPrint.Text = "��ӡ";
            ttsbtnPrint.ThemeAware = true;
            ttsbtnPrint.Tooltip = "��ӡ";
            ttsbtnPrint.Click += new System.EventHandler(this.ttsbtnPrint_Click);

            //����
            ButtonItem ttsbtnPrintContinue = new ButtonItem();
            ttsbtnPrintContinue.AutoCheckOnClick = true;
            ttsbtnPrintContinue.BeginGroup = false;
            ttsbtnPrintContinue.Image = global::BifrostMainPro.Resource1.����;
            ttsbtnPrintContinue.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ttsbtnPrintContinue.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            ttsbtnPrintContinue.Name = "ttsbtnPrintContinue";
            ttsbtnPrintContinue.OptionGroup = "Color";
            ttsbtnPrintContinue.Text = "����";
            ttsbtnPrintContinue.ThemeAware = true;
            ttsbtnPrintContinue.Tooltip = "����";
            ttsbtnPrintContinue.Click += new System.EventHandler(this.ttsbtnPrintContinue_Click);

            //֪��ͬ��������ӡ
            ButtonItem ttsbtnBachePrint = new ButtonItem();
            ttsbtnBachePrint.AutoCheckOnClick = true;
            ttsbtnBachePrint.BeginGroup = false;
            ttsbtnBachePrint.Image = global::BifrostMainPro.Resource1.��ӡ֪��ͬ����;
            ttsbtnBachePrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ttsbtnBachePrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            ttsbtnBachePrint.Name = "ttsbtnBachePrint";
            ttsbtnBachePrint.OptionGroup = "Color";
            ttsbtnBachePrint.Text = "��ӡ֪��ͬ����";
            ttsbtnBachePrint.ThemeAware = true;
            ttsbtnBachePrint.Tooltip = "��ӡ֪��ͬ����";
            ttsbtnBachePrint.Click += new System.EventHandler(this.ttsbtnBachePrint_Click);

            //�ݴ�
            ButtonItem tsbtnTempSave = new ButtonItem();
            tsbtnTempSave.AutoCheckOnClick = true;
            tsbtnTempSave.BeginGroup = false;
            tsbtnTempSave.Image = global::BifrostMainPro.Resource1.�ݴ�;
            tsbtnTempSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnTempSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnTempSave.Name = "tsbtnTempSave";
            tsbtnTempSave.OptionGroup = "Color";
            tsbtnTempSave.Text = "�ݴ�";
            tsbtnTempSave.ThemeAware = true;
            tsbtnTempSave.Tooltip = "�ݴ�";
            tsbtnTempSave.Click += new System.EventHandler(this.tsbtnTempSave_Click);

            //�ύ
            ButtonItem tsbtnCommit = new ButtonItem();
            tsbtnCommit.AutoCheckOnClick = true;
            tsbtnCommit.BeginGroup = false;
            tsbtnCommit.Image = global::BifrostMainPro.Resource1.�ύ;
            tsbtnCommit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCommit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCommit.Name = "tsbtnCommit";
            tsbtnCommit.OptionGroup = "Color";
            tsbtnCommit.Text = "�ύ";
            tsbtnCommit.ThemeAware = true;
            tsbtnCommit.Tooltip = "�ύ";
            tsbtnCommit.Click += new System.EventHandler(this.tsbtnCommit_Click);

            //ֵ������
            ButtonItem tsbtnDutySet = new ButtonItem();
            tsbtnDutySet.AutoCheckOnClick = true;
            tsbtnDutySet.BeginGroup = false;
            tsbtnDutySet.Image = global::BifrostMainPro.Resource1.����Ȩ�������;
            tsbtnDutySet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnDutySet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnDutySet.Name = "tsbtnDutySet";
            tsbtnDutySet.OptionGroup = "Color";
            tsbtnDutySet.Text = "ֵ������";
            tsbtnDutySet.ThemeAware = true;
            tsbtnDutySet.Tooltip = "ֵ������";
            tsbtnDutySet.Click += new System.EventHandler(this.tsbtnDutySet_Click);

            //���ƹ淶
            ButtonItem tsbtnZLGF = new ButtonItem();
            tsbtnZLGF.AutoCheckOnClick = true;
            tsbtnZLGF.BeginGroup = false;
            tsbtnZLGF.Image = global::BifrostMainPro.Resource1.����Ȩ�������;
            tsbtnZLGF.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnZLGF.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnZLGF.Name = "tsbtnZLGF";
            tsbtnZLGF.OptionGroup = "Color";
            tsbtnZLGF.Text = "���ƹ淶";
            tsbtnZLGF.ThemeAware = true;
            tsbtnZLGF.Tooltip = "���ƹ淶";
            tsbtnZLGF.Click += new System.EventHandler(this.tsbtnZLGF_Click);

            //��������
            ButtonItem tsbtnBKSB = new ButtonItem();
            tsbtnBKSB.AutoCheckOnClick = true;
            tsbtnBKSB.BeginGroup = false;
            tsbtnBKSB.Image = global::BifrostMainPro.Resource1.��������;
            tsbtnBKSB.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnBKSB.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnBKSB.Name = "tsbtnBKSB";
            tsbtnBKSB.OptionGroup = "Color";
            tsbtnBKSB.Text = "��������";
            tsbtnBKSB.ThemeAware = true;
            tsbtnBKSB.Tooltip = "��������";
            tsbtnBKSB.Click += new System.EventHandler(this.tsbtnBKSB_Click);

            //��������
            ButtonItem tsbtnHelp = new ButtonItem();
            tsbtnHelp.AutoCheckOnClick = true;
            tsbtnHelp.BeginGroup = false;
            tsbtnHelp.Image = global::BifrostMainPro.Resource1.��������;
            tsbtnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnHelp.Name = "tsbtnHelp";
            tsbtnHelp.OptionGroup = "Color";
            tsbtnHelp.Text = "��������";
            tsbtnHelp.ThemeAware = true;
            tsbtnHelp.Tooltip = "��������";
            tsbtnHelp.Click += new System.EventHandler(this.tsbtnHelp_Click);

            //�鿴����
            ButtonItem tsbtnCheckSick = new ButtonItem();
            tsbtnCheckSick.AutoCheckOnClick = true;
            tsbtnCheckSick.BeginGroup = false;
            tsbtnCheckSick.Image = global::BifrostMainPro.Resource1.���в�������;
            tsbtnCheckSick.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckSick.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckSick.Name = "tsbtnCheckSick";
            tsbtnCheckSick.OptionGroup = "Color";
            tsbtnCheckSick.Text = "�鿴����";
            tsbtnCheckSick.ThemeAware = true;
            tsbtnCheckSick.Tooltip = "�鿴����";
            tsbtnCheckSick.Click += new System.EventHandler(this.tsbtnCheckSick_Click);


            //�鿴����
            ButtonItem tsbtnCheckTemprature = new ButtonItem();
            tsbtnCheckTemprature.AutoCheckOnClick = true;
            tsbtnCheckTemprature.BeginGroup = false;
            tsbtnCheckTemprature.Image = global::BifrostMainPro.Resource1.�鿴����;
            tsbtnCheckTemprature.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckTemprature.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckTemprature.Name = "tsbtnCheckTemprature";
            tsbtnCheckTemprature.OptionGroup = "Color";
            tsbtnCheckTemprature.Text = "�鿴����";
            tsbtnCheckTemprature.ThemeAware = true;
            tsbtnCheckTemprature.Tooltip = "�鿴����";
            tsbtnCheckTemprature.Click += new System.EventHandler(this.tsbtnCheckTemprature_Click);

            //�鿴�����¼��
            ButtonItem tsbtnCheckNurseRecord = new ButtonItem();
            tsbtnCheckNurseRecord.AutoCheckOnClick = true;
            tsbtnCheckNurseRecord.BeginGroup = false;
            tsbtnCheckNurseRecord.Image = global::BifrostMainPro.Resource1.���в�������;
            tsbtnCheckNurseRecord.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckNurseRecord.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckNurseRecord.Name = "tsbtnCheckNurseRecord";
            tsbtnCheckNurseRecord.OptionGroup = "Color";
            tsbtnCheckNurseRecord.Text = "�鿴�����¼��";
            tsbtnCheckNurseRecord.ThemeAware = true;
            tsbtnCheckNurseRecord.Tooltip = "�鿴�����¼��";
            tsbtnCheckNurseRecord.Click += new System.EventHandler(this.tsbtnCheckNurseRecord_Click);

            //�鿴��������
            ButtonItem tsbtnCheckLis = new ButtonItem();
            tsbtnCheckLis.AutoCheckOnClick = true;
            tsbtnCheckLis.BeginGroup = false;
            tsbtnCheckLis.Image = global::BifrostMainPro.Resource1.���в�������;
            tsbtnCheckLis.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckLis.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckLis.Name = "tsbtnCheckLis";
            tsbtnCheckLis.OptionGroup = "Color";
            tsbtnCheckLis.Text = "�鿴��������";
            tsbtnCheckLis.ThemeAware = true;
            tsbtnCheckLis.Tooltip = "�鿴��������";
            tsbtnCheckLis.Click += new System.EventHandler(this.tsbtnCheckLis_Click);

            //�鿴Ӱ�񱨸���
            ButtonItem tsbtnCheckPacs = new ButtonItem();
            tsbtnCheckPacs.AutoCheckOnClick = true;
            tsbtnCheckPacs.BeginGroup = false;
            tsbtnCheckPacs.Image = global::BifrostMainPro.Resource1.���в�������;
            tsbtnCheckPacs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckPacs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckPacs.Name = "tsbtnCheckPacs";
            tsbtnCheckPacs.OptionGroup = "Color";
            tsbtnCheckPacs.Text = "�鿴Ӱ�񱨸���";
            tsbtnCheckPacs.ThemeAware = true;
            tsbtnCheckPacs.Tooltip = "�鿴Ӱ�񱨸���";
            tsbtnCheckPacs.Click += new System.EventHandler(this.tsbtnCheckPacs_Click);

            //�鿴��������
            ButtonItem tsbtnCheckOperator = new ButtonItem();
            tsbtnCheckOperator.AutoCheckOnClick = true;
            tsbtnCheckOperator.BeginGroup = false;
            tsbtnCheckOperator.Image = global::BifrostMainPro.Resource1.������������;
            tsbtnCheckOperator.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnCheckOperator.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnCheckOperator.Name = "tsbtnCheckOperator";
            tsbtnCheckOperator.OptionGroup = "Color";
            tsbtnCheckOperator.Text = "�鿴Ӱ�񱨸���";
            tsbtnCheckOperator.ThemeAware = true;
            tsbtnCheckOperator.Tooltip = "�鿴Ӱ�񱨸���";
            tsbtnCheckOperator.Click += new System.EventHandler(this.tsbtnCheckOperator_Click);

            //������������
            ButtonItem tsbtnPatientSickInfoApply = new ButtonItem();
            tsbtnPatientSickInfoApply.AutoCheckOnClick = true;
            tsbtnPatientSickInfoApply.BeginGroup = false;
            tsbtnPatientSickInfoApply.Image = global::BifrostMainPro.Resource1.������������;
            tsbtnPatientSickInfoApply.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnPatientSickInfoApply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnPatientSickInfoApply.Name = "tsbtnPatientSickInfoApply";
            tsbtnPatientSickInfoApply.OptionGroup = "Color";
            tsbtnPatientSickInfoApply.Text = "������������";
            tsbtnPatientSickInfoApply.ThemeAware = true;
            tsbtnPatientSickInfoApply.Tooltip = "������������";
            tsbtnPatientSickInfoApply.Click += new System.EventHandler(this.tsbtnPatientSickInfoApply_Click);


            //�鵵�˻�����
            ButtonItem tsbtnBackSickInfoApply = new ButtonItem();
            tsbtnBackSickInfoApply.AutoCheckOnClick = true;
            tsbtnBackSickInfoApply.BeginGroup = false;
            tsbtnBackSickInfoApply.Image = global::BifrostMainPro.Resource1.�鵵�˻�����;
            tsbtnBackSickInfoApply.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnBackSickInfoApply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnBackSickInfoApply.Name = "tsbtnBackSickInfoApply";
            tsbtnBackSickInfoApply.OptionGroup = "Color";
            tsbtnBackSickInfoApply.Text = "�鵵�˻�����";
            tsbtnBackSickInfoApply.ThemeAware = true;
            tsbtnBackSickInfoApply.Tooltip = "�鵵�˻�����";
            tsbtnBackSickInfoApply.Click += new System.EventHandler(this.tsbtnBackSickInfoApply_Click);

            //���в�������
            ButtonItem tsbtnUsedSickInfoCheck = new ButtonItem();
            tsbtnUsedSickInfoCheck.AutoCheckOnClick = true;
            tsbtnUsedSickInfoCheck.BeginGroup = false;
            tsbtnUsedSickInfoCheck.Image = global::BifrostMainPro.Resource1.���в�������;
            tsbtnUsedSickInfoCheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnUsedSickInfoCheck.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnUsedSickInfoCheck.Name = "tsbtnUsedSickInfoCheck";
            tsbtnUsedSickInfoCheck.OptionGroup = "Color";
            tsbtnUsedSickInfoCheck.Text = "���в�������";
            tsbtnUsedSickInfoCheck.ThemeAware = true;
            tsbtnUsedSickInfoCheck.Tooltip = "���в�������";
            tsbtnUsedSickInfoCheck.Click += new System.EventHandler(this.tsbtnUsedSickInfoCheck_Click);


            //����Ȩ�������
            ButtonItem tsbtnDocRights = new ButtonItem();
            tsbtnDocRights.AutoCheckOnClick = true;
            tsbtnDocRights.BeginGroup = false;
            tsbtnDocRights.Image = global::BifrostMainPro.Resource1.����Ȩ�������;
            tsbtnDocRights.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnDocRights.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnDocRights.Name = "tsbtnDocRights";
            tsbtnDocRights.OptionGroup = "Color";
            tsbtnDocRights.Text = "����Ȩ�������";
            tsbtnDocRights.ThemeAware = true;
            tsbtnDocRights.Tooltip = "����Ȩ�������";
            tsbtnDocRights.Click += new System.EventHandler(this.tsbtnDocRights_Click);

            //��������
            ButtonItem tsbtnMedicalRecordFinishing = new ButtonItem();
            tsbtnMedicalRecordFinishing.AutoCheckOnClick = true;
            tsbtnMedicalRecordFinishing.BeginGroup = false;
            tsbtnMedicalRecordFinishing.Image = global::BifrostMainPro.Resource1.��������;
            tsbtnMedicalRecordFinishing.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnMedicalRecordFinishing.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnMedicalRecordFinishing.Name = "tsbtnMedicalRecordFinishing";
            tsbtnMedicalRecordFinishing.OptionGroup = "Color";
            tsbtnMedicalRecordFinishing.Text = "��������";
            tsbtnMedicalRecordFinishing.ThemeAware = true;
            tsbtnMedicalRecordFinishing.Tooltip = "��������";
            tsbtnMedicalRecordFinishing.Click += new System.EventHandler(this.tsbtnMedicalRecordFinishing_Click);

            //�����鵵
            ButtonItem tsbtnMedicalRecords = new ButtonItem();
            tsbtnMedicalRecords.AutoCheckOnClick = true;
            tsbtnMedicalRecords.BeginGroup = false;
            tsbtnMedicalRecords.Image = global::BifrostMainPro.Resource1.�����鵵;
            tsbtnMedicalRecords.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnMedicalRecords.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnMedicalRecords.Name = "tsbtnMedicalRecords";
            tsbtnMedicalRecords.OptionGroup = "Color";
            tsbtnMedicalRecords.Text = "�����鵵";
            tsbtnMedicalRecords.ThemeAware = true;
            tsbtnMedicalRecords.Tooltip = "�����鵵";
            tsbtnMedicalRecords.Click += new System.EventHandler(this.tsbtnMedicalRecords_Click);

            //δ��ɹ���
            ButtonItem tsbtnUnfinishedWork = new ButtonItem();
            tsbtnUnfinishedWork.AutoCheckOnClick = true;
            tsbtnUnfinishedWork.BeginGroup = false;
            tsbtnUnfinishedWork.Image = global::BifrostMainPro.Resource1.δ���;
            tsbtnUnfinishedWork.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            tsbtnUnfinishedWork.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            tsbtnUnfinishedWork.Name = "tsbtnUnfinishedWork";
            tsbtnUnfinishedWork.OptionGroup = "Color";
            tsbtnUnfinishedWork.Text = "δ��ɹ���";
            tsbtnUnfinishedWork.ThemeAware = true;
            tsbtnUnfinishedWork.Tooltip = "δ��ɹ���";
            tsbtnUnfinishedWork.Click += new System.EventHandler(this.tsbtnUnfinishedWork_Click);

            //��ϱ༭
            ButtonItem btnInsertDiosgin = new ButtonItem();
            btnInsertDiosgin.AutoCheckOnClick = true;
            btnInsertDiosgin.BeginGroup = false;
            btnInsertDiosgin.Image = global::BifrostMainPro.Resource1.��ϱ༭;
            btnInsertDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            btnInsertDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
            btnInsertDiosgin.Name = "btnInsertDiosgin";
            btnInsertDiosgin.OptionGroup = "Color";
            btnInsertDiosgin.Text = "��ϱ༭";
            btnInsertDiosgin.ThemeAware = true;
            btnInsertDiosgin.Tooltip = "��ϱ༭";
            btnInsertDiosgin.Click += new System.EventHandler(this.tsbtnInsertDiosgin_Click);

            //ˢ�����
            ButtonItem btnRefreshDiosgin = new ButtonItem();
            btnRefreshDiosgin.AutoCheckOnClick = true;
            btnRefreshDiosgin.BeginGroup = false;
            btnRefreshDiosgin.Image = global::BifrostMainPro.Resource1.ˢ�����;
            btnRefreshDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            btnRefreshDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
            btnRefreshDiosgin.Name = "btnRefreshDiosgin";
            btnRefreshDiosgin.OptionGroup = "Color";
            btnRefreshDiosgin.Text = "ˢ�����";
            btnRefreshDiosgin.ThemeAware = true;
            btnRefreshDiosgin.Tooltip = "ˢ�����";
            btnRefreshDiosgin.Click += new System.EventHandler(this.tsbtnRefreshDiosgin_Click);
            #endregion

            /*
             * ��ͼ����빤����            
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

            tbtnReportBack.Image = global::BifrostMainPro.Resource1.����Ȩ�������;
            tbtnConsultationMide.Image = global::BifrostMainPro.Resource1.����Ȩ�������;
            tbtnQualityMide.Image = global::BifrostMainPro.Resource1.�ʿ�����;
            tbtnMessageMide.Image = global::BifrostMainPro.Resource1.��Ϣ����;
            tbtnGrade.Image = global::BifrostMainPro.Resource1.��������;

            for (int i = 0; i < midebar.Items.Count; i++)
            {
                ButtonItem temp = (ButtonItem)midebar.Items[i];
                temp.ImageFixedSize = new Size(30, 30);
                temp.ImagePosition = eImagePosition.Left;
            }
        }

        /// <summary>
        /// ��ʾ��������ť
        /// </summary>
        private void ShowToolBars()
        {
            toolbar.Items.Clear();
            string strTools = "";
            //������һ�޸�ͳһ��ʽ:���������÷�ҽ����ʿ��¼ֻ��ʾ:ϵͳע��,��ɫ�л�,�����޸�
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
            toolbar.Width = toolbar.Parent.Width;  //���������ť��ʾ��ȫ
            toolbar.Refresh();
        }

        /// <summary>
        /// ��ʾ��ť���ô���
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
                App.MsgErr("���������ù����޷����ã�����ԭ��" + ex.Message);
            }

        }


        /// <summary>
        /// �жϲ˵���ť�Ƿ����Ȩ��
        /// </summary>
        /// <param name="code">����</param>
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
                     * ����Ƿ����
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

                        Sqls[0] = "select a.id ���" +
                                " from t_consultaion_apply a " +
                                " where a.consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.submited='Y' and consul_record_submite_state=0";
                        ds_D_HZ = App.GetDataSet(Sqls[0]);
                        ds_D_BK = App.GetDataSet("select id from t_fecter_report_card t where t.state=2 and t.sid=" + App.UserAccount.CurrentSelectRole.Section_Id + "");
                    }




                    if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                    {
                        /*
                         * ����
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
                         * ҽ���ʿ�
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
                         *�������� 
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
                         * ��ʿ�ʿ�
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
                    ///*��Ϣ����
                    // */
                    //if (ds_M_MESSAGE.Tables[0].Rows.Count > 0)
                    //{
                    //    MessageFlag = true;
                    //}
                    //else
                    //{
                    //    MessageFlag = false;
                    //}


                    #region ��Ϣ�����Զ��������幦��
                    if (isWindowPop == "0" && isCheckNews == "0")  //�ж���Ϣ�鿴�������Ƿ񵯳�����0��û�е�������1���Ѿ���������������ȷʵϵͳ�Ѿ��Զ���������0��û�м����� 1���Ѿ���������
                    {
                        //�Զ�������Ϣ���Ѵ��壨��������Ϣʱ��
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
                        //��Ϣ���������н�����Ϊ����ȫԺ��
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
                        //��Ϣ���������н�����Ϊ����ȫԺҽ����ȫԺ��ʿ��
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
                        //��Ϣ���������н�����Ϊ�������ң�
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
                        //��Ϣ���������н�����Ϊ����������
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
                        //��Ϣ���������н�����Ϊ�������ˣ�
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
                        if (isWindowOpen == false)//�жϴ����Ƿ��ڴ�״̬
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
                            //��Ϣ���������н�����Ϊ����ȫԺ��
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
                            //��Ϣ���������н�����Ϊ����ȫԺҽ����ȫԺ��ʿ��
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
                            //��Ϣ���������н�����Ϊ�������ң�
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
                            //��Ϣ���������н�����Ϊ����������
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
                            //��Ϣ���������н�����Ϊ�������ˣ�
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
                                Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShowLittle f = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShowLittle(App.UserAccount.UserInfo.User_id);//������Ϣ���һ������
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
        /// ʱʱ�ϴ�����ͼƬ
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

                //�����ϴ�û���ϴ���ɵ�����
                App.UpLoadUnfinshDocs();

                Thread.Sleep(300000);
            }
        }

        /// <summary>
        /// ������еĲ˵�
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
        /// ��ʼ��ϵͳ
        /// </summary>
        private void IniSystem()
        {
            //App.Progress("ϵͳ���ڳ�ʼ�������Ժ�...");
            if (App.UserAccount != null)
            {
                if (App.UserAccount.CurrentSelectRole != null)
                {
                    for (int i = 0; i < this.toolbar.Items.Count; i++)
                    {

                        if (this.toolbar.Items[i].Name == "tsbtnDutySet")
                        {
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("������") || App.UserAccount.CurrentSelectRole.Role_name.Contains("�Ƹ�����"))
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

                    App.MdiFormTittle = "��ǰ�û���" + App.UserAccount.UserInfo.User_name + "     ����:" + App.UserAccount.Account_name + "     ְ�ƣ�" + App.UserAccount.UserInfo.U_tech_post_name + "     ��ɫ��" + App.UserAccount.CurrentSelectRole.Role_name;
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "0" && App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        App.MdiFormTittle = App.MdiFormTittle + "     ���ң�" + App.UserAccount.CurrentSelectRole.Section_name;
                    }
                    else if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "0" && App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        App.MdiFormTittle = App.MdiFormTittle + "     ������" + App.UserAccount.CurrentSelectRole.Sickarea_name;
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
                        //�˵���
                        MenuPermissions[i] = new Class_Permission();
                        MenuPermissions[i].Id = ds.Tables["permssion"].Rows[i]["id"].ToString();
                        MenuPermissions[i].Perm_code = ds.Tables["permssion"].Rows[i]["PERM_CODE"].ToString();
                        MenuPermissions[i].Perm_name = ds.Tables["permssion"].Rows[i]["PERM_NAME"].ToString();
                        MenuPermissions[i].Perm_kind = ds.Tables["permssion"].Rows[i]["PERM_KIND"].ToString();
                        MenuPermissions[i].Num = ds.Tables["permssion"].Rows[i]["NUM"].ToString();

                        //�˵�����ϸ��Ϣ
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
                    //ˢ�������
                    IniMenuTreeview(MenuPermissions, ribbonControl_main);
                    for (int i = 0; i < ribbonControl_main.Items.Count; i++)
                    {
                        if (ribbonControl_main.Items[i].GetType().ToString() == "DevComponents.DotNetBar.ButtonItem")
                            IniMenuTrvNode(MenuPermissions, (ButtonItem)ribbonControl_main.Items[i]);
                    }

                    //�����ӽڵ�Ϊ�յ����˵�
                    HideAllRootNoChildsMenu();


                    //���ù������ؼ�                      
                    //App.BtnEnableSet(App.UserAccount.CurrentSelectRole.Permissions, this.toolStrip1);  
                    //IniToolBar();
                    this.Cursor = Cursors.Default;

                    //���ع�������ť
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
        /// ��ʼ�������� 
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
        /// ��ʼ���˵����ĸ����
        /// </summary>
        /// <param name="MenuPermissions">�˵����</param>
        /// <param name="trv">�˵���</param>
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
        /// ��ʼ���˵����ӽ��
        /// </summary>
        /// <param name="MenuPermissions">���в˵���</param>
        /// <param name="tn">�˵������</param>
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
        /// ��������û���ӽڵ�ĸ��ڵ�˵�
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
        /// ��ʾ������
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
                         * ��ʽ�ʺ�
                         */
                        if (App.UserAccount.CurrentSelectRole.Role_type == "M")
                        {
                            //ϵͳ����Ա
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            //ҽ��
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("����"))
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
                            //��ʿ                    
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("Base_Function.Base");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmShow");
                            object tmpobj = assmble.CreateInstance("Base_Function.Base");
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "H")
                        {
                            //����                   
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("Base_Function.Base");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmUCEParamShow");
                            object tmpobj = assmble.CreateInstance("Base_Function.Base");//ThreadManagement.Template.frmUCEParamShow;ThreadManagement.frmUCEParam
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "Y" || App.UserAccount.CurrentSelectRole.Role_type == "Z")
                        {
                            //ҽ�̴�                 
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
                            //���鰸����                   
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                            Type tmpType = assmble.GetType("Base_Function.Base");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmFormTestShow");
                            object tmpobj = assmble.CreateInstance("Base_Function.Base");
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "O")
                        {
                            //����
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("�����Ӱ���ҽʦ") ||
                                App.UserAccount.CurrentSelectRole.Role_name.Contains("����"))
                            {
                                //���鰸����                   
                                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                                Type tmpType = assmble.GetType("Base_Function.Base");
                                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmRightRun");
                                object tmpobj = assmble.CreateInstance("Base_Function.Base");
                                tmpM.Invoke(tmpobj, null);
                                flag = true;

                                #region ������������
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
                            //opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//��¼�򿪴���Ĳ��裨dll��+������+�������ͣ�                          
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
                             * ��ʱ�ʺ�
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
                                //opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//��¼�򿪴���Ĳ��裨dll��+������+�������ͣ�                          
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
                App.MsgErr("��ʼ������ԭ��" + ex.Message);
            }
        }

        /// <summary>
        /// ����Ƿ�����Ѵ򿪵��Ӵ���
        /// </summary>
        /// <param name="strfunct">����ĺ�����</param>
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
        /// ��ô򿪴��������
        /// </summary>
        /// <param name="strfunct">����ĺ�����</param>
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
        /// ���в˵��Ĺ���
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
                            //���´���  
                            tmpM.Invoke(tmpobj, null);
                            //DevComponents.DotNetBar.TabItem temptab = new DevComponents.DotNetBar.TabItem();
                            //temptab.Name = Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();
                            //temptab.Text = Application.OpenForms[Application.OpenForms.Count - 1].Text;
                            //temptab.AttachedControl = (Control)Application.OpenForms[Application.OpenForms.Count - 1];
                            //opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//��¼�򿪴���Ĳ��裨dll��+������+�������ͣ�                          
                            //App.Openforms.Add(opstr);//Inhospital_Info.Test.FrmShow;Inhospital_Info.frmMain

                            //tabOpenForms.Tabs.Add(temptab);
                            //tabOpenForms.Refresh();
                            //opstr = "";
                            //tabOpenForms.SelectedTab = tabOpenForms.Tabs[tabOpenForms.Tabs.Count - 1];

                        }
                        else//���Ѿ��еĴ���
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
                    App.MsgErr("�ٵ��ò˵�����ʱ����ԭ��:" + ex.Message);
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

            #region �����Զ�����ʽ
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
                    * ������                     
                    */
                    if (App.UserAccount.Kind == 53 || App.UserAccount.Kind == 54 || App.UserAccount.Kind == 7921 || App.UserAccount.Kind == 52 || App.UserAccount.Kind == 70)
                    {
                        //ʵϰ�����о�����������
                        tbtnAccountClear.Enabled = true;
                        tbtnAccountClear.Visible = true;
                    }
                    //this.Show();
                    //��ɫ����

                    if (!App.isOtherSystemRefrenceflag)
                    {
                        frmRoleChose fmRole = new frmRoleChose();
                        App.ButtonStytle(fmRole, false);
                        fmRole.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        fmRole.ControlBox = false;
                        fmRole.MaximizeBox = false;
                        fmRole.MinimizeBox = false;
                        fmRole.ShowDialog();

                        //App.Progress("���ڳ�ʼ��ϵͳ�����Ժ�..."); 
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
                        if (App.UserAccount.CurrentSelectRole.Role_name.Contains("����") &&
                            Convert.ToInt16(App.UserAccount.CurrentSelectRole.Rnages.Length) > 0)
                        {
                            if (App.UserAccount.CurrentSelectRole.Rnages.Length > 0)
                            {
                                tsbtnSectionAccountSets.Enabled = true;
                                tsbtnSectionAccountSets.Visible = true;
                                //�人��Էע��(������ȷָʾ:����Ժ��Ҳ������)
                                //if (App.UserAccount.CurrentSelectRole.Role_name.Trim() == "������")
                                //{//��ɫְ��Ϊ�������Ρ����û����ӡ��������֡�����
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
                     * �����ʺ�
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
                //������³�����Ҫ���µĻ�
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
                        if (App.Ask("�Ƿ���Ҫ�˳���") == false)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            //if (App.sr != null)
                            //{
                            //    App.sr.RcDispose();
                            //}
                            SetBookLock();//������������
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
        /// ������������
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
        /// ��ɫ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnRoleChose_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                bool flag = true;
                flag = App.Ask("��ɫ�л�֮ǰ��ȷ���ر��Ѵ򿪵Ĵ�����");
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
        /// ϵͳע��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnResetSystem_Click(object sender, EventArgs e)
        {
            if (App.Ask("���Ҫע��ϵͳ��"))
            {
                isReset = true;
                Application.Restart();
            }
        }

        /// <summary>
        /// �����޸�
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
        /// �˺�ע��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnAccountClear_Click(object sender, EventArgs e)
        {
            #region

            if (App.Ask("ע���ʺ�֮�󣬵�ǰ�ʺž��޷���¼��ǰϵͳ��ȷ��Ҫע����"))
            {
                string result = "";
                if (App.UserAccount.Kind == 53 || App.UserAccount.Kind == 54 || App.UserAccount.Kind == 7921)
                {
                    //ʵϰ�����о�����������
                    result = "";
                }
                else if (App.UserAccount.Kind == 52)
                {

                    //��ʽ
                    DataSet ds_docs = App.GetDataSet("select t.tid,t3.patient_name,t3.pid,t2.textname,t.doc_name,t.havedoctorsign from t_patients_doc t inner join t_text t2 on t.textkind_id=t2.id inner join t_in_patient t3 on t.patient_id=t3.id where t.createid=" + App.UserAccount.UserInfo.User_id + "");
                    if (ds_docs != null)
                    {
                        if (ds_docs.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds_docs.Tables[0].Rows.Count; i++)
                            {
                                if (ds_docs.Tables[0].Rows[i]["havedoctorsign"].ToString() != "Y")
                                {

                                    string strtemp = "����������" + ds_docs.Tables[0].Rows[i]["patient_name"].ToString() + ",סԺ�ţ�" + ds_docs.Tables[0].Rows[i]["pid"].ToString() + ",�������ͣ�" + ds_docs.Tables[0].Rows[i]["textname"].ToString() + ",�������ƣ�" + ds_docs.Tables[0].Rows[i]["doc_name"].ToString();
                                    if (result == "")
                                    {
                                        result = "�㻹��һЩ����û��ǩ����\n";
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


                    ////ע������
                    //string[] sqls = new string[2];
                    //sqls[0] = "delete from t_acc_role_range a where a.acc_role_id in (select b.id from t_acc_role b where b.account_id=" + App.UserAccount.Account_id + ")";
                    //sqls[1] = "delete from t_acc_role c where c.account_id=" + App.UserAccount.Account_id + "";

                    //if (App.ExecuteBatch(sqls) > 0)
                    //{
                    //    App.Msg("�ʺ�ע���ɹ���");
                    //    LogHelper.Account_SystemLog(App.UserAccount.Account_id, "ע��", "");
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
        /// �������˺�ά��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSectionAccountSets_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("����") &&
               App.UserAccount.CurrentSelectRole.Rnages.Length > 0)
            {
                frmUserInfoAccountSet1 AccountSet = new frmUserInfoAccountSet1();
                App.FormStytleSet(AccountSet, false);
                AccountSet.ShowDialog();
            }
            else
            {
                App.MsgWaring("�ù���ֻ�п����β���ʹ�ã�");
            }
        }

        /// <summary>
        /// ϵͳ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnHelp_Click(object sender, EventArgs e)
        {
            frmHelp fc = new frmHelp();
            fc.Show();
        }


        /// <summary>
        /// ���ƹ淶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnZLGF_Click(object sender, EventArgs e)
        {
            frmZLGF fc = new frmZLGF();
            fc.Show();
        }

        /// <summary>
        /// ֵ������
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
                if (tbtnQualityMide.Image == global::BifrostMainPro.Resource1.�ʿ�����)
                    tbtnQualityMide.Image = global::BifrostMainPro.Resource1.�ʿ�����2;
                else
                    tbtnQualityMide.Image = global::BifrostMainPro.Resource1.�ʿ�����;
            }
            else
            {
                tbtnQualityMide.Image = global::BifrostMainPro.Resource1.�ʿ�����;
            }


            if (MessageFlag)
            {

                if (tbtnMessageMide.Image == global::BifrostMainPro.Resource1.��Ϣ����)
                    tbtnMessageMide.Image = global::BifrostMainPro.Resource1.��Ϣ����2;
                else
                    tbtnMessageMide.Image = global::BifrostMainPro.Resource1.��Ϣ����;
            }

            if (isupdate == 1)
            {
                App.ShowTip("��Ϣ��ʾ", "�Ѿ����˸��µİ汾���뼰ʱ����ϵͳ��");
                isupdate = 0;
            }

            if (MsgContent != "")
            {
                App.ShowTip("��Ϣ��ʾ", MsgContent, MsgURL);
                MsgContent = "";
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            App.ReleaseLockedDoc();
            base.OnClosed(e);
        }



        /// <summary>
        /// �ر�ϵͳ        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// ����������
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
                App.A_OutPut = null;
            }
        }

        //֪��ͬ�����ӡ��ť����
        private void ttsbtnBachePrint_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_BachePrint(sender, e);
            }
            catch
            {
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
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
        /// ҽ��վ�ʿ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnQualityMide_Click(object sender, EventArgs e)
        {
            frmQuitlyNotice fr = new frmQuitlyNotice();
            fr.ShowDialog();
        }

        /// <summary>
        /// �����ο�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnGrade_Click(object sender, EventArgs e)
        {
            //ucfrmMainGradeRepart uc = new ucfrmMainGradeRepart(App.UserAccount.CurrentSelectRole.Section_name);
            //uc.Dock = DockStyle.Fill;
            //frmApp fm = new frmApp();
            //fm.Text = "��������";
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
                App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
            }
        }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnMessageMide_Click(object sender, EventArgs e)
        {
            ////Bifrost.SYSTEMSET.frmMessageShow fc = new frmMessageShow();
            ////fc.ShowDialog();
            ////DataSet ds_M_MESSAGE = App.GetDataSet("select * from T_MSG_INFO t where t.receive_user like '%" + App.UserAccount.UserInfo.User_id + "%' and (select count(*) from T_MSG_USER a where a.MSG_ID=t.id and USER_ID=" + App.UserAccount.UserInfo.User_id + ")=0");
            /////*��Ϣ����
            //// */
            ////if (ds_M_MESSAGE.Tables[0].Rows.Count > 0)
            ////{
            ////    MessageFlag = true;
            ////}
            ////else
            ////{
            ////    MessageFlag = false;
            ////}
            //App.MsgWaring("�ù�����δ��ʽ���ã�");

            #region ��Ϣ����ʹ��
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

        #region ��ʽ����ɫѡ��

        private string mainstyle = "";//��ȡ���õ���ʽ
        private string maincolor = "";//��ȡ��ʽ��Ӧ����ɫ

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