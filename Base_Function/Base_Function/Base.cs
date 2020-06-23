using System;
using System.Collections.Generic;
using System.Text;
using Base_Function.BASE_DATA;
using Bifrost;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_DOCTOR.NApply_Medical_Record;
using Base_Function.BLL_MANAGEMENT;
using Base_Function.BLL_MANAGEMENT.ServerLink;
using Base_Function.BLL_MANAGEMENT.SICKFILE;
using Base_Function.TEMPERATURES;
using Base_Function.TEMPLATE;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;
using Base_Function.EMERGENCY;
using Base_Function.Treatment_Group_Count;
using Digital_Medical_Treatment;
using Base_Function.BLL_FOLLOW;
using Base_Function.BLL_FOLLOW.StaticsAnalysis;
using Base_Function.BLL_FOLLOW.Element;
using Base_Function.BLL_NURSE.SickInformational;
using Base_Function.BLL_MANAGEMENT.NURSE_MANAGE;
using Base_Function.BLL_DOCTOR.Doc_Return;
using Senyint.QualityControlSeting.UserControls;
using Base_Function.TJBB;
using Base_Function.BLL_MANAGEMENT.SICKFILE.BINGANCODE;
using Base_Function.BLL_DOCTOR.Consultation_Manager;

namespace Base_Function
{
    /// <summary>
    /// 基础数据维护的功能
    /// </summary>
    public class Base
    {        

        /// <summary>
        /// 文书维护        
        /// </summary>
        public void frmTextSetShow()
        {
            ucWrite_Type fm = new ucWrite_Type();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "文书维护");
        }


        /// <summary>
        /// 数据字典类型信息
        /// </summary>
        public void frmTypeinfoShow()
        {
            ucTypeinfo uc = new ucTypeinfo();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "数据字典类型信息");

        }




        /// <summary>
        /// 数据字典类型信息
        /// </summary>
        public void frmCardFlagPat()
        {
            CardFlagPat uc = new CardFlagPat();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "典型病例");

        }


        /// <summary>
        /// 模板审核
        /// </summary>
        public void TemplateCheck()
        {
            ucTemplateCheck uc = new ucTemplateCheck();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "模板审核");
        }

        /// <summary>
        /// 知识库维护
        /// </summary>
        public void frmKBSCommonShow()
        {
            frmKBSCommonSection uc = new frmKBSCommonSection();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "知识库维护");
        }

        /// <summary>
        /// 诊断统计
        /// </summary>
        public void frmZdtjShow()
        {
            UCzdtj uc = new UCzdtj();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "诊断、医保类型统计");

        }

        /// <summary>
        /// 科室统计
        /// </summary>
        public void frmKstjShow()
        {
            UCkstj uc = new UCkstj();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "科室统计");

        }


        /// <summary>
        /// 宏元素管理
        /// </summary>
        public void ShowMacrosElements()
        {
            ucMacrosElementsManagement uc = new ucMacrosElementsManagement();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "宏元素管理");
        }

        /// <summary>
        /// 数据字典维护
        /// </summary>
        public void frmDictionaryShow()
        {
            ucDictionary uc = new ucDictionary();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "数据字典维护");

        }

        /// <summary>
        /// 科室信息
        /// </summary>
        public void frmSectionShow()
        {
            ucSection uc = new ucSection();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "科室信息");

        }

        /// <summary>
        /// 病区信息
        /// </summary>
        public void frmSickAreaInfoShow()
        {
            ucSickAreaInfo uc = new ucSickAreaInfo();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病区信息");

        }
        /// <summary>
        /// 病区的关系设置
        /// </summary>
        public void frmSick_relationShow()
        {
            ucSick_relation uc = new ucSick_relation();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病区的关系设置");

        }
        /// <summary>
        /// 病区与科室的关系设置
        /// </summary>
        public void frmSick_sectionShow()
        {
            ucSick_section uc = new ucSick_section();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病区与科室的关系设置");

        }

        /// <summary>
        /// 科室与病区的关系设置
        /// </summary>
        public void frmSick_AreaShow()
        {
            ucSick_area uc = new ucSick_area();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "科室与病区的关系设置");

        }


        /// <summary>
        ///病房信息
        /// </summary>
        public void frmSickRoomInfoShow()
        {
            ucSickRoomInfo uc = new ucSickRoomInfo();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病房信息");

        }
        /// <summary>
        ///病床信息
        /// </summary>
        public void frmSickBedInfoShow()
        {
            ucSickBedInfo uc = new ucSickBedInfo();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病床信息");
        }


        /// <summary>
        /// 大科与小科的关系设置
        /// </summary>
        public void frmScienceShow()
        {
            ucScience uc = new ucScience();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "大科与小科的关系设置");
        }


        /// <summary>
        /// 用户信息
        /// </summary>
        public void frmUserShow()
        {
            ucUser uc = new ucUser();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "用户信息");

        }

        /// <summary>
        /// 临时用户信息
        /// </summary>
        public void frmInterim_userInfoShow()
        {
            ucInterim_userInfo uc = new ucInterim_userInfo();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "临时用户信息");

        }

        /// <summary>
        /// 分院信息
        /// </summary>
        public void frmSub_HospitalInfoShow()
        {
            ucSub_HospitalInfo uc = new ucSub_HospitalInfo();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "分院信息");

        }

        /// <summary>
        /// 诊疗护理组的信息
        /// </summary>
        public void frmDiagnosis_TreatShow()
        {
            ucDiagnosis_Treat uc = new ucDiagnosis_Treat();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "诊疗护理组的信息");
        }

        /// <summary>
        /// 诊疗护理组与帐户的关系
        /// </summary>
        public void frmDiagnosis_AccountShow()
        {
            ucDiagnosis_Account uc = new ucDiagnosis_Account();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "诊疗护理组与帐户的关系");
        }
       
        /// <summary>
        ///诊断名称定义信息
        /// </summary>
        public void frmDiag_DEFShow()
        {
            ucDiag_DEF uc = new ucDiag_DEF();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "诊断名称定义信息");
        }

        /// <summary>
        /// 诊断名称自定义
        /// </summary>
        public void frmAddICD10VindicateShow()
        {

            ucAddICD10Vindicate uc = new ucAddICD10Vindicate();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "ICD9诊断名称自定义");
        }

        /// <summary>
        /// 手术称自定义
        /// </summary>
        public void frmAddICD9InfoShow()
        {
            ucAddICD9Info uc = new ucAddICD9Info();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "手术称自定义");
        }


        /// <summary>
        /// ICD10信息维护
        /// </summary>
        public void frmSuffererInfoShowShow()
        {
            ucICD10Vindicate uc = new ucICD10Vindicate();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "ICD10信息维护");
        }
        /// <summary>
        /// ICD9信息维护
        /// </summary>
        public void frmICD9InfoShow()
        {
            ucICD9Vindicates uc = new ucICD9Vindicates();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "ICD9信息维护");
        }

        /// <summary>
        /// 节假日维护
        /// </summary>
        public void FrmDay_ToFile()
        {
            ucDay_ToFile uc = new ucDay_ToFile();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "节假日维护");

        }

        /// <summary>
        ///病人记录信息
        /// </summary>
        public void frmIn_PatientShow()
        {
            ucIn_Patient uc = new ucIn_Patient();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病人记录信息");

        }

        /// <summary>
        ///病种类
        /// </summary>
        public void frmDisease_TypeShow()
        {
            ucDisease_Type uc = new ucDisease_Type();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病种类");
        }

        /// <summary>
        ///出入液量项目信息
        /// </summary>
        public void frmMinimShow()
        {
            ucMinim uc = new ucMinim();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "出入液量记录信息");

        }

        /// <summary>
        /// 性别关键词维护
        /// </summary>
        public void frmSex_Phrase()
        {
            frmSex_Phrase uc = new frmSex_Phrase();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "性别关键词维护");

        }

        /// <summary>
        /// 主窗体
        /// </summary>
        public void FrmShow()
        {           
            ucMain uc = new ucMain();
            App.UsControlStyle(uc);
            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                App.AddNewBusUcControl(uc, "护士站");
            }
            else
            {
                App.AddNewBusUcControl(uc, "医生站");
            }         
        }

        /// <summary>
        /// 运行病例查阅
        /// </summary>
        public void FrmRightRun()
        {           
            UCMedicalRightRun_Search uc = new UCMedicalRightRun_Search();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "运行病历的查阅");
        }


        /// <summary>
        /// 护理部-质控规则设置界面
        /// </summary>
        public void frmUCEParamShow()
        {
            //ucUCEParam uc = new ucUCEParam();
            //App.UsControlStyle(uc);
            //App.AddNewBusUcControl(uc, App.UserAccount.CurrentSelectRole.Role_name);//"护理部调度参数设置");           
        }

        /// <summary>
        /// 医务处-质控规则设置界面
        /// </summary>
        public void frmYWCParamShow()
        {

            //ucYWCParam uc = new ucYWCParam();
            //App.UsControlStyle(uc);
            //App.AddNewBusUcControl(uc, App.UserAccount.CurrentSelectRole.Role_name);//"医务科工作站");          
        }

        /// <summary>
        /// 病案室工作站
        /// </summary>
        public void frmFormTestShow()
        {
            //ucMain_SickFile uc = new ucMain_SickFile();
            //App.UsControlStyle(uc);
            //App.AddNewBusUcControl(uc, App.UserAccount.CurrentSelectRole.Role_name);//"病案室工作站");
        }
        /// <summary>
        /// 出入液量
        /// </summary>
        public void teest()
        {
            //Ucdddd uc = new Ucdddd();
            //App.UsControlStyle(uc);
            //App.AddNewBusUcControl(uc, "出入液量");
        }

        /// <summary>
        /// 病历入库
        /// </summary>
        public void testfrmTest()
        {
            UcTest uc = new UcTest();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病历入库");
        }

        /// <summary>
        /// 显示当前登录客户端列表
        /// </summary>
        public void frmShowServerLinkList()
        {
            ucShowServerLinks uc = new ucShowServerLinks();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "显示当前登录客户端列表");
        }

        /// <summary>
        ///护理标记信息
        /// </summary>
        public void frmNurse_MarkShow()
        {
            ucNurse_Mark uc = new ucNurse_Mark();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "护理标记信息");
        }

        /// <summary>
        /// 体温单设置
        /// </summary>
        public void ucTempratrueSet()
        {
            ucTempratureSet uc = new ucTempratureSet();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "体温单属性设置");
        }

        /// <summary>
        /// 模版管理
        /// </summary>
        public void frmTemplateShow()
        {
            Template.fmT = new TextEditor.frmText();
            Template.fmS = new TextEditor.frmText();
            UcTemManagement fm = new UcTemManagement();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "模版管理器");
        }

        /// <summary>
        /// 模版关键字过滤
        /// </summary>
        public void frmFilterKeyWordShow()
        {
            ucFilterKeyWord fkw = new ucFilterKeyWord();
            //fkw.MdiParent = App.ParentForm;
            App.UsControlStyle(fkw);
            //App.SetMainFrmMsgToolBarText("模版关键字过滤");
            //fkw.Show();
            App.AddNewBusUcControl(fkw, "模版关键字过滤");
        }

        /// <summary>
        /// 文书管理
        /// </summary>
        public void frmDocumentShow()
        {
            Template.fmT = new TextEditor.frmText();
            frmDocument fd = new frmDocument();
            fd.MdiParent = App.ParentForm;
            App.ButtonStytle(fd, true);
            App.SetMainFrmMsgToolBarText("文书管理");
            fd.Show();
        }

        /// <summary>
        /// 护理单班次
        /// </summary>
        public void frmTake_over_SEQShow()
        {
            ucTake_over_SEQ uc = new ucTake_over_SEQ();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "护理单班次");
        }

        /// <summary>
        /// 交接班记录
        /// </summary>
        public void SickRopert()
        {
            ucfrmSickReport uc = new ucfrmSickReport();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "交接班记录");
        }


        /// <summary>
        /// 费用大类关系设置
        /// </summary>
        public void FeeClassSet()
        {
            ucFeeClassSet uc = new ucFeeClassSet();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "费用大类关系设置");
        }

        /// <summary>
        /// his字典同步
        /// 诊断字典
        /// 手术字典
        /// </summary>
        public void HisDictSync()
        {
            ucHisDictSync uc = new ucHisDictSync();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "字典同步");
        }

        public void AddCDiagnose()
        {
            ucCDiagDict uc = new ucCDiagDict();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "中医字典维护");
        }

        /// <summary>
        /// 查看首页诊断字典
        /// </summary>
        public void SearchFirstDiagDict()
        {
            ucFirstDiagDict uc = new ucFirstDiagDict();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "首页诊断字典查看");
        }

        /// <summary>
        /// 首页手术字典查看
        /// </summary>
        public void SearchOperation()
        {
            ucSearchOperation uc = new ucSearchOperation();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "首页手术字典查看");
        }

        /// <summary>
        /// 科室评分
        /// </summary>
        public void DepartmentScore()
        {
            ucfrmMainGradeRepart uc = new ucfrmMainGradeRepart(App.UserAccount.CurrentSelectRole.Section_name);
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "科室评分");
            //uc.Dock = DockStyle.Fill;
            //frmApp fm = new frmApp();
            //fm.Text = "科室评分";
            //fm.Controls.Add(uc);
            //App.FormStytleSet(fm, false);
            //fm.WindowState = FormWindowState.Normal;
            //fm.Show();
        }

        /// <summary>
        /// 超时时间设置
        /// </summary>
        public void UCTimeOutSetShow()
        {
            UCTimeOutSet uc = new UCTimeOutSet();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "超时时间设置");

        }

        /// <summary>
        ///  质控办文书统计
        /// </summary>
        public void QcTextCommitStatistics()
        {
            ucQcTextCommit_Statistics uc = new ucQcTextCommit_Statistics();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "质控办文书统计");
        }

        /// <summary>
        /// 诊疗组患者统计
        /// </summary>
        public void UCTreatmentGroup_StatisticsShow()
        {
            UCTreatmentGroup_Statistics uc = new UCTreatmentGroup_Statistics();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "诊疗组患者统计");
        }
        /// <summary>
        /// 加载管床医生监控列表
        /// </summary>
        public void RecordMonitorShow()
        {
            ucRecordMonitor uc = new ucRecordMonitor("医务处", App.UserAccount.CurrentSelectRole.Section_name);
            App.ucRecord = uc;
        }

        /// <summary>
        /// 交接班记录
        /// </summary>
        public void ucShowHandover()
        {
            BLL_DOCTOR.HandoverRecord.UcHandoverRecord uc = new Base_Function.BLL_DOCTOR.HandoverRecord.UcHandoverRecord();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "交接班记录");
        }

        /// <summary>
        /// 传染病维护
        /// </summary>
        public void ucInfection()
        {
            Infection.UcInfection uc = new Base_Function.Infection.UcInfection();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "传染病维护");
        }

        /// <summary>
        /// 在线病人查阅
        /// </summary>
        public void ucUserfrmQueryLevy()
        {
            QueryAllLevy uc = new QueryAllLevy();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "在线病人查阅");
        }

       

        ///// <summary>
        ///// 烧伤科统计
        ///// </summary>
        //public void UC_SSKTJShow()
        //{
        //    UC_SSKTJ uc = new UC_SSKTJ();
        //    App.UsControlStyle(uc);
        //    App.AddNewBusUcControl(uc, "烧伤科统计");
        //}
        /// <summary>
        /// 急诊
        /// </summary>
        public void UCJZ()
        {
            ucJZ uc = new ucJZ();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "急诊患者");
        }

        

        /// <summary>
        /// 数字化病区
        /// </summary>
        public void Digital_Medical_Treatment()
        {
            frmIndex uc = new frmIndex();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "数字化病区");
        }

        /// <summary>
        ///随访时间类别设置
        /// </summary>
        public void FollowVisite()
        {
            ucFollowTimeTypeSet uc = new ucFollowTimeTypeSet();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访时间类别");
        }
        /// <summary>
        /// 设置随访失败次数
        /// </summary>
        public void FollowFailedTimes()
        {
            ucFollowFailedTimes uc = new ucFollowFailedTimes();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访失败次数设置");
        }
        /// <summary>
        /// 随访问卷类型
        /// </summary>
        public void ShowFollowWriteType()
        {
            ucFollowWrite_Type uc = new ucFollowWrite_Type();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访问卷类型");
        }
        /// <summary>
        /// 随访方案制定
        /// </summary>
        public void ShowFollowSolution()
        {
            ucfollowInfoList uc = new ucfollowInfoList();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访方案设置");
        }
        /// <summary>
        /// 随访模板管理
        /// </summary>
        public void ShowFollowModelManage()
        {
            Template.fmT = new TextEditor.frmText();
            ucFollowTemplateManagement uc = new ucFollowTemplateManagement();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访模板管理");
        }

        /// <summary>
        /// 随访监测页面
        /// </summary>
        public void ShowTest()
        {
            ucTest uc = new ucTest();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访监测");
        }
        /// <summary>
        /// 随访状态
        /// </summary>
        public void StateSet()
        {
            ucFollowStateSet uc = new ucFollowStateSet();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访状态");
        }
        /// <summary>
        /// 随访取消原因
        /// </summary>
        public void CancelReasonSet()
        {
            ucFollowCancelReasonSet uc = new ucFollowCancelReasonSet();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "随访取消原因");
        }

        public void StaticsShow()
        {
            ucStaticsTable uc = new ucStaticsTable();
            App.Ini();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "统计报表");
        }

        /// <summary>
        /// 元素维护
        /// </summary>
        public void frmKnowledgeShow()
        {
            frKnowledge uc = new frKnowledge();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "元素维护");
        }

        /// <summary>
        /// 病历等级加密
        /// </summary>
        public void frmEncryptPatientsShow()
        {
            ucEncryptPatients uc = new ucEncryptPatients();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病历等级加密");
        }



        /// <summary>
        /// 文书自动读取设置
        /// </summary>
        public void TextRead()
        {
            ucTextRead uc = new ucTextRead();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "文书自动读取设置");
        }

        #region 消息提醒功能新增加的窗体
        ///// <summary>
        ///// 在线病人查阅
        ///// </summary>
        //public void ucUserfrmQueryLevy()
        //{
        //    UserfrmQueryLevy uc = new UserfrmQueryLevy();
        //    App.UsControlStyle(uc);
        //    App.AddNewBusUcControl(uc, "在线病人查阅");
        //}
        /// <summary>
        /// 消息提醒报表查看
        /// </summary>
        public void ucMsgShow()
        {
            Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING.ucMsgShow uc = new Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING.ucMsgShow();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "消息提醒报表查看");

        }
        /// <summary>
        /// 消息提醒条目设定
        /// </summary>
        public void ucMsgParam()
        {
            Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING.ucMsgParam uc = new Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING.ucMsgParam();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "消息提醒条目设定");

        }
        /// <summary>
        /// 主动消息类型维护
        /// </summary>
        public void MsgType()
        {
            Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND.ucMsgType uc = new Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND.ucMsgType();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "主动消息类型维护");
        }
        /// <summary>
        /// 主动消息内容维护
        /// </summary>
        public void MessageSet()
        {
            Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND.ucMessageSet uc = new Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND.ucMessageSet();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "主动消息内容维护");
        }
        /// <summary>
        /// 新增消息发布提醒
        /// </summary>
        public void MsgSendDetails()
        {
            Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.ucMsgSendDetails uc = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.ucMsgSendDetails();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "新增消息发布提醒");
        }
        /// <summary>
        /// 查询消息发布提醒
        /// </summary>
        public void MsgSend()
        {
            Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.ucMsgSend uc = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.ucMsgSend();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "查询消息发布提醒");
        }
        #endregion

        #region 病案评分功能新增加的窗体

        /// <summary>
        /// 评分设置
        /// </summary>
        public void MedicalMark()
        {
            ////Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMark_NEW uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMark_NEW();
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMarkControl uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.ucMedicalMarkControl();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "评分设置");
        }
        /// <summary>
        /// 全院评分
        /// </summary>
        public void frmMainGradeRepart()
        {
            //Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmMainGradeRepart uc = new Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmMainGradeRepart();
            //App.UsControlStyle(uc);
            //App.AddNewBusUcControl(uc, "全院评分");
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality("H");
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "全院评分");
        }
        /// <summary>
        /// 科室自评
        /// </summary>
        public void frmMainGradeRepartSection()
        {
            //Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmMainGradeRepartSection uc = new Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmMainGradeRepartSection();
            //App.UsControlStyle(uc);
            //App.AddNewBusUcControl(uc, "科室自评");
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality("S");
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "科室自评");
        }
        /// <summary>
        /// 医生自评
        /// </summary>
        public void frmMainGradeRepartDoctor()
        {
            //Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmMainGradeRepartDoctor uc = new Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmMainGradeRepartDoctor();
            //App.UsControlStyle(uc);
            //App.AddNewBusUcControl(uc, "医生自评");
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality("D");
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "医生自评");
        }
        /// <summary>
        /// 终末质控
        /// </summary>
        public void frmMainGradeRepartEnd()
        {
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQuality("E");
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "终末质控");
        }
        /// <summary>
        /// 病历评分
        /// </summary>
        public void frmMainGradeRepartScore()
        {
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQualityTest uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQualityTest("M");
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病历评分");
        }

        /// <summary>
        /// 临时护士长维护
        /// </summary>
        public void TempHeadNurse()
        {
            ucTempHeadNurse uc = new ucTempHeadNurse();
            App.UsControlStyle(uc);

            FrmPOPForm frm = new FrmPOPForm(uc);
            frm.Text = "临时护士长维护";
            frm.ShowDialog();
            //App.AddNewBusUcControl(uc, "临时护士长维护");
        }



        /// <summary>
        /// 评分总结报表
        /// </summary>
        public void ucQualityResultShow()
        {
            Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQualityResult uc = new Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score.ucQualityResult();//定义消息框的一个对象
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病人评分情况");
        }
        /// <summary>
        /// 报表查询
        /// </summary>
        public void frmStochasticRepartType()
        {
            Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmStochasticRepartType uc = new Base_Function.BLL_MEDICAL_RECORD_GRADE.ucfrmStochasticRepartType();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "报表查询");
        }
        #endregion

        #region 医务处、护理部、病案室

        /// <summary>
        /// 病案管理--在院病人病案查阅
        /// </summary>
        public void QueryLevy_Show()
        {
            UserfrmQueryLevy uc = new UserfrmQueryLevy();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "在院病人病案查阅");
        }

        /// <summary>
        /// 病案管理--运行病历查阅授权
        /// </summary>
        public void ucMedicalRightRun_Show()
        {
            UcMedicalRightRun uc = new UcMedicalRightRun();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "运行病历查阅授权");
        }

        /// <summary>
        /// 病案管理--病案查阅
        /// </summary>
        public void caseSearchMark_Show()
        {
            CaseSearchMark uc = new CaseSearchMark();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "病案查阅");
        }

        /// <summary>
        /// LIS检查项目设置
        /// </summary>
        public void ucLisItem_Show()
        {
            UCLisItem uc = new UCLisItem();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "LIS检查项目设置");
        }

        /// <summary>
        /// LIS危急值查看--当日查询
        /// </summary>
        public void ucSearchByDay_Show()
        {
            UCSearchByDay uc = new UCSearchByDay();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "LIS危急值当日查询");
        }

        /// <summary>
        /// LIS危急值查看--时间段查询
        /// </summary>
        public void ucLisTimeSpanQuerry_Show()
        {
            ucLisTimeSpanQuerry uc = new ucLisTimeSpanQuerry();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "LIS危急值时间段查询");
        }

        /// <summary>
        /// 报表统计管理--不规则确定诊断统计
        /// </summary>
        public void ucfrmDiagnoseTime_Show()
        {
            ucfrmDiagnoseTime uc = new ucfrmDiagnoseTime();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "不规则确定诊断统计");
        }


        /// <summary>
        /// 报表统计管理--未及时转科统计
        /// </summary>
        public void ucTurnSection_Show()
        {
            UCTurnSection uc = new UCTurnSection();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "未及时转科统计");
        }


        /// <summary>
        /// 报表管理--会诊统计
        /// </summary>
        public void ucConsultationCount_Show()
        {
            UCConsultation_Statistic uc = new UCConsultation_Statistic();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "会诊统计");
        }

        /// <summary>
        /// 报表管理--特殊病历--病危
        /// </summary>
        public void BingWei_Show()
        {
            bool isvisable = false;
            string old_Name = string.Empty;
            string new_Name = string.Empty;
            string[] cols = null;
            string sql = GetSql("病危", ref isvisable, out old_Name, out new_Name, ref cols);
            UcCase uccase = null;
            if (cols != null)
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name, cols);
            }
            else
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name);
            }
            uccase.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uccase, "病危");
        }

        /// <summary>
        /// 报表管理--特殊病历--病重
        /// </summary>
        public void BingZhong_Show()
        {
            bool isvisable = false;
            string old_Name = string.Empty;
            string new_Name = string.Empty;
            string[] cols = null;
            string sql = GetSql("病重", ref isvisable, out old_Name, out new_Name, ref cols);
            UcCase uccase = null;
            if (cols != null)
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name, cols);
            }
            else
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name);
            }
            uccase.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uccase, "病重");
        }

        /// <summary>
        /// 报表管理--特殊病历--危重 
        /// </summary>
        public void Weizhong_Show()
        {
            bool isvisable = false;
            string old_Name = string.Empty;
            string new_Name = string.Empty;
            string[] cols = null;
            string sql = GetSql("危+重", ref isvisable, out old_Name, out new_Name, ref cols);
            UcCase uccase = null;
            if (cols != null)
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name, cols);
            }
            else
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name);
            }
            uccase.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uccase, "危+重");
        }

        /// <summary>
        /// 报表管理--特殊病历--手术 
        /// </summary>
        public void Operator_Show()
        {
            bool isvisable = false;
            string old_Name = string.Empty;
            string new_Name = string.Empty;
            string[] cols = null;
            string sql = GetSql("手术", ref isvisable, out old_Name, out new_Name, ref cols);
            UcCase uccase = null;
            if (cols != null)
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name, cols);
            }
            else
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name);
            }
            uccase.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uccase, "手术");
        }

        /// <summary>
        /// 报表管理--特殊病历--死亡
        /// </summary>
        public void Dead_Show()
        {
            bool isvisable = false;
            string old_Name = string.Empty;
            string new_Name = string.Empty;
            string[] cols = null;
            string sql = GetSql("死亡", ref isvisable, out old_Name, out new_Name, ref cols);
            UcCase uccase = null;
            if (cols != null)
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name, cols);
            }
            else
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name);
            }
            uccase.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uccase, "死亡");
        }

        /// <summary>
        /// 报表管理--输血记录
        /// </summary>
        public void Blood_Show()
        {
            bool isvisable = false;
            string old_Name = string.Empty;
            string new_Name = string.Empty;
            string[] cols = null;
            string sql = GetSql("输血记录", ref isvisable, out old_Name, out new_Name, ref cols);
            UcCase uccase = null;
            if (cols != null)
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name, cols);
            }
            else
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name);
            }
            uccase.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uccase, "输血记录");
        }

        /// <summary>
        /// 报表管理--抢救记录
        /// </summary>
        public void Qiangjiu_Show()
        {
            bool isvisable = false;
            string old_Name = string.Empty;
            string new_Name = string.Empty;
            string[] cols = null;
            string sql = GetSql("抢救记录", ref isvisable, out old_Name, out new_Name, ref cols);
            UcCase uccase = null;
            if (cols != null)
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name, cols);
            }
            else
            {
                uccase = new UcCase(sql, isvisable, old_Name, new_Name);
            }
            uccase.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uccase, "抢救记录");
        }

        /// <summary>
        /// 报表管理--帐号异动信息
        /// </summary>
        public void ucAccountAction_Show()
        {
            UcAccountAction uc = new UcAccountAction();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "帐号异动信息");
        }



        /// <summary>
        /// 会诊审核设置
        /// </summary>
        public void AuditConfiguration()
        {
            ucAuditConfiguration uc = new ucAuditConfiguration();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "会诊审核设置");
        }


        /// <summary>
        /// 会诊审核设置
        /// </summary>
        public void AuditConsultation()
        {
            ucAuditConsultation uc = new ucAuditConsultation();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "会诊审核");
        }


        /// <summary>
        /// 住院超过30天上报--科室统计
        /// </summary>
        public void ucOverthirty_Show()
        {
            ucOverthirty_Statistics uc = new ucOverthirty_Statistics();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "科室统计");
        }

        /// <summary>
        ///  住院超过30天上报--全院统计
        /// </summary>
        public void ucOverthirtySum_Show()
        {
            ucOverthirtySum_Statistics uc = new ucOverthirtySum_Statistics();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "全院统计");
        }

        /// <summary>
        /// 新生儿分娩情况统计表
        /// </summary>
        public void ucBirthrecord_Show()
        {
            ucBirthrecord_Statistics uc = new ucBirthrecord_Statistics();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "全院统计");
        }

        /// <summary>
        /// 疑难病例讨论记录
        /// </summary>
        public void ucDiscuss_Show()
        {
            ucDiscuss_Statistics uc = new ucDiscuss_Statistics();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "疑难病例讨论记录");
        }


        /// <summary>
        ///文书统计报表 
        /// </summary>
        public void ucDocument_Show()
        {
            ucDocument_statistics uc = new ucDocument_statistics();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "文书统计报表");
        }
        /// <summary>
        /// 关键字维护
        /// </summary>
        public void ShowKey_Words()
        {
            ucKey_Words uc = new ucKey_Words();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "关键字维护");
        }

        /// <summary>
        /// 纸质病案管理--纸质归档登记
        /// </summary>
        public void ucPaperArchiveRegister_Show()
        {
            UcPaperArchiveRegister uc = new UcPaperArchiveRegister();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "纸质归档登记");
        }

        /// <summary>
        /// 纸质病案管理--借阅登记
        /// </summary>
        public void ucLoan_Registration_Show()
        {
            ucLoan_Registration uc = new ucLoan_Registration();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "借阅登记");
        }

        /// <summary>
        /// 纸质病案管理--借阅管理
        /// </summary>
        public void ucEmprstimo_Management_Show()
        {
            ucEmprstimo_Management uc = new ucEmprstimo_Management();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "借阅管理");
        }

        /// <summary>
        /// 纸质病案管理--参数设置
        /// </summary>
        public void ucEmprstimo_Preferences_Show()
        {
            ucEmprstimo_Preferences uc = new ucEmprstimo_Preferences();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "参数设置");
        }

        /// <summary>
        /// 归档时效性统计
        /// </summary>
        public void archiveStatistics_Show()
        {
            ArchiveStatistics uc = new ArchiveStatistics();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "归档时效性统计");
        }

        /// <summary>
        /// 病历入库
        /// </summary>
        public void ucCase_History_Show()
        {
            ucCase_History uc = new ucCase_History();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "病历入库");
        }

        /// <summary>
        /// 病历申请处理
        /// </summary>
        public void ucCase_History_Apply_Totreat_Show()
        {
            ucCase_History_Apply_Totreat uc = new ucCase_History_Apply_Totreat();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "病历申请处理");
        }

        /// <summary>
        /// 报卡处理        
        /// </summary>
        public void cardManagement_Show()
        {
            ucCase_History_Apply_Totreat uc = new ucCase_History_Apply_Totreat();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "报卡处理");
        }

        /// <summary>
        /// 诊断管理        
        /// </summary>
        public void diagnosisManagement_Show()
        {
            DiagnosisManagement uc = new DiagnosisManagement();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "诊断管理");
        }

        /// <summary>
        /// 病历复印查阅      
        /// </summary>
        public void CoseCopyRegister_Show()
        {
            CoseCopyRegister uc = new CoseCopyRegister();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "病历复印查阅");
        }

        /// <summary>
        /// 病案退回审核
        /// </summary>
        public void UcApply_DocReturn_Show()
        {
            UcApply_DocReturn_Record_Room uc = new UcApply_DocReturn_Record_Room();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "病案退回审核");
        }

        /// <summary>
        /// 病案借阅审核
        /// </summary>
        public void UcApply_Medical_Show()
        {
            UcApply_Medical_Record_Room uc = new UcApply_Medical_Record_Room();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "病案借阅审核");
        }


        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="strtext">当前item的文本</param>
        /// <param name="isVisable">是否显示在院，出院</param>
        /// <param name="old_name">原来列</param>
        /// <param name="new_name">新列</param>
        /// <param name="cols">要隐藏的列</param>
        /// <returns></returns>
        private string GetSql(string strtext, ref bool isVisable, out string old_name, out string new_name, ref string[] cols)
        {
            string sql = string.Empty;
            old_name = "";
            new_name = "";
            switch (strtext)
            {
                //病危,病重,危+重选项页未使用,所以注释了
                //case "病危":
                //    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室," +
                //           " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,a.id,a.BIRTHDAY from t_in_patient a" +
                //           " inner join (select min(id) id,patient_id from t_diagnose_item "+
                //           " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id"+
                //           " inner join t_diagnose_item c on b.id = c.id"+
                //           " where a.sick_degree='3'  and a.die_time is null  order by 住院号)";
                //    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                //    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                //    cols = new string[2];
                //    cols[0] = "id";
                //    cols[1] = "BIRTHDAY";
                //    break;
                //case "病重":
                //    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室," +
                //           " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,a.id,a.BIRTHDAY from t_in_patient a" +
                //           " inner join (select min(id) id,patient_id from t_diagnose_item " +
                //           " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id" +
                //           " inner join t_diagnose_item c on b.id = c.id" +
                //           " where a.sick_degree='2'  and a.die_time is null  order by 住院号)";
                //    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                //    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                //    cols = new string[2];
                //    cols[0] = "id";
                //    cols[1] = "BIRTHDAY";
                //    break;
                //case "危+重":
                //    string str = @"""危+重""";
                //    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室," +
                //           " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间," +
                //           " (case a.sick_degree when '1' then '病危' else '病重' end) " + str + " ,a.id,a.BIRTHDAY from t_in_patient a" +
                //           " inner join (select min(id) id,patient_id from t_diagnose_item " +
                //           " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id" +
                //           " inner join t_diagnose_item c on b.id = c.id" +
                //           " where a.sick_degree in('3','2')  and a.die_time is null  order by 住院号)";
                //    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time,sick_degree";
                //    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间,危+重";
                //    cols = new string[2];
                //    cols[0] = "id";
                //    cols[1] = "BIRTHDAY";
                //    break;
                case "手术":

                    //                    sql = @"select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then  '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, 
                    //                              a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, 
                    //                              to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,to_char(f.operations_time, 'yyyy-MM-dd HH24:mi') 手术时间, 
                    //                              a.die_time,a.id,a.BIRTHDAY from t_in_patient a 
                    //                              left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c 
                    //                              on a.id=c.patient_id 
                    //                              inner join (select patient_id,t.operations_time  from t_vital_signs t where t.describe like '%手术%') f 
                    //                              on a.id = f.patient_id order by 姓名)";
                    sql = @"select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then  '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, 
                              a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, 
                              to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,REPLACE(doc_name, '术后首次病程记录', '')  术后首次病程记录, 
                              a.die_time,a.id,a.BIRTHDAY from t_in_patient a 
                              left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c 
                              on a.id=c.patient_id 
                              inner join (select tp.tid, tp.patient_id, tp.doc_name from t_patients_doc tp  where textkind_id = 136 and tp.submitted = 'Y') f 
                              on a.id = f.patient_id order by 姓名)";
                    //20140313:LWM改 手术时间, 手术及操作名称 这两个字段统一取病案首页中手术页的记录.
                    //sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then  '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, " +
                    //          "a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, " +
                    //          "to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,o.oper_date 手术时间, o.oper_name 手术及操作名称, " +
                    //          "a.die_time,a.id,a.BIRTHDAY from t_in_patient a " +
                    //          " inner join  cover_operation o on a.id = o.patient_id " +
                    //          " left join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c " +
                    //          " on a.id=c.patient_id " +
                    //          " order by 住院号)";
                    cols = new string[3];
                    cols[0] = "die_time";
                    cols[1] = "id";
                    cols[2] = "BIRTHDAY";
                    break;
                case "死亡":
                    //sql =" select * from (select a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,"+
                    //     " a.age 年龄,a.Age_unit 年龄单位,a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生," +
                    //     " b.入院诊断,b.死亡诊断,a.in_time 入院时间,a.die_time 死亡时间 from t_in_patient a"+
                    //     " inner join (select patient_id,"+
                    //     " max(case diagnose_type when '408' then diagnose_name end) 入院诊断,"+
                    //     " max(case diagnose_type when '407' then diagnose_name end) 死亡诊断 "+
                    //     " from t_diagnose_item "+
                    //     " where id in (select min(id) from t_diagnose_item "+
                    //     " where diagnose_type='407' and patient_id is not null"+
                    //     " group by patient_id,diagnose_type union"+
                    //     " select min(id) from t_diagnose_item "+
                    //     " where diagnose_type='408' and patient_id is not null"+
                    //     " group by patient_id,diagnose_type) "+
                    //     " group by patient_id) b on a.id = b.patient_id " +
                    //     " inner join (select min(tid) tid,patient_id from t_patients_doc "+
                    //     " where textkind_id=138 group by patient_id order by patient_id) c on b.patient_id=c.patient_id)";
                    //old_name = "patient_name 姓名,gender_code,age,section_name,sick_area_name,sick_doctor_name,in_diagnose,in_time,dead_diagnose,die_time";
                    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间,死亡诊断,死亡时间";
                    sql = "select * from (select a.pid 住院号,a.patient_name 姓名, (case a.gender_code when '1' then  '女' else  '男' end) 性别, " +
                          "case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, a.section_name 科室, a.sick_area_name 病区, a.sick_doctor_name 管床医生, " +
                          "b.入院诊断, b.死亡诊断, to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间, to_char(a.die_time, 'yyyy-MM-dd HH24:mi') 死亡时间,a.id,a.BIRTHDAY " +
                          "from t_in_patient a " +
                          "left outer join (select patient_id, max(case diagnose_type when '408' then diagnose_name end) 入院诊断, " +
                          "max(case diagnose_type when '407' then diagnose_name end) 死亡诊断 " +
                          "from t_diagnose_item where id in " +
                          "(select min(id) from t_diagnose_item where diagnose_type = '407' and patient_id is not null " +
                          "group by patient_id, diagnose_type " +
                          "union " +
                          "select min(id) from t_diagnose_item where diagnose_type = '408' and patient_id is not null " +
                          "group by patient_id, diagnose_type) " +
                          "group by patient_id) b " +
                          "on a.id = b.patient_id where a.DIE_FLAG=1  order by 住院号)";
                    cols = new string[2];
                    cols[0] = "id";
                    cols[1] = "BIRTHDAY";
                    break;
                case "输血记录":
                    //sql = "select e.* from (select a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,concat(age,age_unit) 年龄,a.section_name 科室," +
                    //       " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time,'yyyy-MM-dd HH24:mi') 入院时间," +
                    //       " a.die_time,a.id from t_in_patient a inner join (select min(id) id,patient_id from t_diagnose_item "+
                    //       " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id "+
                    //       " left join t_diagnose_item c on b.id = c.id "+
                    //       " order by patient_name) e "+
                    //       " inner join (select min(tid) tid,patient_id from t_patients_doc "+
                    //       " where textkind_id=153 group by patient_id order by patient_id) f on e.id = f.patient_id";
                    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别, " +
                           "case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室,a.sick_area_name 病区, " +
                           "a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, " +
                           "to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间, " +
                           "REPLACE(doc_name,'临床输血申请单','') 临床输血申请单,a.die_time,a.id,a.BIRTHDAY " +
                           "from t_in_patient a " +
                           "left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c " +
                           "on a.id=c.patient_id " +
                           "inner join (select tp.tid,tp.patient_id,tp.doc_name from t_patients_doc tp  where textkind_id = 47555630 and tp.submitted='Y') f " +
                           "on a.id = f.patient_id order by 住院号)";
                    isVisable = true;
                    cols = new string[3];
                    cols[0] = "die_time";
                    cols[1] = "id";
                    cols[2] = "BIRTHDAY";
                    break;
                case "抢救记录":
                    //sql = "select e.* from (select a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,a.age 年龄,a.Age_unit 年龄单位,a.section_name 科室," +
                    //    " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time,'yyyy-MM-dd HH24:mi') 入院时间," +
                    //    " a.die_time,a.id from t_in_patient a inner join (select min(id) id,patient_id from t_diagnose_item " +
                    //    " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id " +
                    //    " left join t_diagnose_item c on b.id = c.id " +
                    //    " order by patient_name) e " +
                    //    " inner join (select min(tid) tid,patient_id from t_patients_doc " +
                    //    " where textkind_id=132 group by patient_id order by patient_id) f on e.id = f.patient_id";
                    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别, " +
                           "case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室,a.sick_area_name 病区, " +
                           "a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, " +
                           "to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,REPLACE(doc_name,'抢救记录','') 抢救记录, " +
                           "a.die_time,a.id,a.BIRTHDAY " +
                           "from t_in_patient a " +
                           "left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c " +
                           "on a.id=c.patient_id " +
                           "inner join (select tp.tid,tp.patient_id,tp.doc_name from t_patients_doc tp  where textkind_id = 132 and tp.submitted='Y') f " +
                           "on a.id = f.patient_id order by 住院号)";
                    isVisable = true;
                    cols = new string[3];
                    cols[0] = "die_time";
                    cols[1] = "id";
                    cols[2] = "BIRTHDAY";
                    break;
                default:
                    break;
            }
            return sql;
        }


        /// <summary>
        /// 护理部-监测值
        /// </summary>
        public void ucSetMonitoringValue_Show()
        {
            ucSetMonitoringValue uc = new ucSetMonitoringValue();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(uc, "监测值");
        }

        /// <summary>
        ///封存文书
        /// </summary>
        public void ucSafeUpDoc_Show()
        {
            ucSafeUpDoc ucUpDoc = new ucSafeUpDoc();
            ucUpDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(ucUpDoc, "封存文书");
        }

        /// <summary>
        ///解锁文书
        /// </summary>
        public void ucUnlockDoc_Show()
        {
            ucUnlockDoc ucDoc = new ucUnlockDoc();
            ucDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            App.AddNewBusUcControl(ucDoc, "解锁文书");
        }
        #endregion

        #region 质控统计功能新增加的函数
        /// <summary>
        /// 护士操作提醒
        /// </summary>
        public void QcRemindHL()
        {

            UcRemind uc = new UcRemind();
            ///传入病区代码
            uc.InitializeUc(App.UserAccount.CurrentSelectRole.Sickarea_Id);
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "护士工作提醒");
        }
        /// <summary>
        /// 护理监控
        /// </summary>
        public void QcStatisticsHL()
        {
            UcQcStatistics uc = new UcQcStatistics();
            uc.Category = "HL";
            uc.StatisticsType = "";
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "护理质控统计");
        }

        /// <summary>
        /// 科室监控
        /// </summary>
        public void QcStatisticsYlKs()
        {
            UcQcStatistics ucQcStatisticsKs = new UcQcStatistics();
            ucQcStatisticsKs.Category = "YL";
            ucQcStatisticsKs.StatisticsType = "section";
            App.UsControlStyle(ucQcStatisticsKs);
            App.AddNewBusUcControl(ucQcStatisticsKs, "科室质控统计");
        }

        /// <summary>
        /// 医生监控
        /// </summary>
        public void QcStatisticsYlYs()
        {
            UcQcStatistics ucQcStatisticsKs = new UcQcStatistics();
            ucQcStatisticsKs.Category = "YL";
            ucQcStatisticsKs.StatisticsType = "doctor";
            App.UsControlStyle(ucQcStatisticsKs);
            App.AddNewBusUcControl(ucQcStatisticsKs, "医生质控统计");
        }


        /// <summary>
        /// 护理质控查询(质控科)
        /// </summary>
        public void QcHLQuery()
        {
            UcQuery ucQuery = new UcQuery();
            ucQuery.Category = "HL";
            ucQuery.StrVisible = "1,2,3,4,5,0";
            ucQuery.Section = "全部";
            App.AddNewBusUcControl(ucQuery, "护理质控查询");
        }

        /// <summary>
        /// 医疗质控查询(质控科)
        /// </summary>
        public void QcYLQuery()
        {
            UcQuery ucQuery = new UcQuery();
            ucQuery.Category = "YL";
            ucQuery.StrVisible = "1,2,3,4,5,0";
            ucQuery.Section = "全部";
            App.AddNewBusUcControl(ucQuery, "医疗质控查询");
        }


        /// <summary>
        /// 护士质控查询
        /// </summary>
        public void QcHSQuery()
        {
            UcQuery ucQuery = new UcQuery();
            ucQuery.StrVisible = "1,3";
            ucQuery.Category = "HL";
            ucQuery.Section = App.UserAccount.CurrentSelectRole.Sickarea_name;
            App.AddNewBusUcControl(ucQuery, "护士质控查询");
        }

        /// <summary>
        /// 医生质控查询
        /// </summary>
        public void QcYSQuery()
        {
            UcQuery ucQuery = new UcQuery();
            ucQuery.Category = "YL";
            ucQuery.StrVisible = "1,3";
            ucQuery.Section = App.UserAccount.CurrentSelectRole.Section_name;
            App.AddNewBusUcControl(ucQuery, "医生质控查询");
        }


        #endregion

        #region 编目修改
        /// <summary>
        /// 病案编目-病案室
        /// </summary>
        public void ShowMedicalRecordCatalogue()
        {
            MedicalRecordCatalogue uc = new MedicalRecordCatalogue();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病案编目");
        }
        /// <summary>
        /// 病案编目-医生站
        /// </summary>
        public void ShowMedicalRecordCatalogueDoctor()
        {
            MedicalRecordCatalogue uc = new MedicalRecordCatalogue();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "编目状态查询");
        }
        /// <summary>
        /// 病案编目-修改审核
        /// </summary>
        public void ShowCodeModifyManage()
        {
            UcCodeModifyManage uc = new UcCodeModifyManage();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "病案编目修改审核");
        }
         


        #endregion

    }
}
