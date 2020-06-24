using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data;
using System.Reflection;
using C1.Win.C1FlexGrid;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualBasic;
using System.Xml;
using DataOperater;
using DevComponents.DotNetBar;
using System.Management;
using DevComponents.DotNetBar.Controls;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting.Channels.Http;
using Bifrost.Hook;
using Bifrost.NurseTemplate;
using NAudio.Wave;
using VoiceRecorder.Audio;
using DataOperater.Model;
using MySql.Data.MySqlClient;

namespace Bifrost
{
    /// <summary>
    /// 框架公共函数库  
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>    
	public class App
    {

        /*
         *说明：
         *    设计公共函数库的主要目的是为了提高软件的开发效率，以及个程序个模块之间的统一性。
         * 将一些常用的方法以及数据库、服务器的连接等进行统一的封装和管理，降低系统代码之间的偶合性，
         * 为今后的维护工作提供方便，降低维护成本。111111    
         */


        //申明INI文件的写操作函数WritePrivateProfileString()
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //申明INI文件的读操作函数GetPrivateProfileString()
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        private static Thread timedProgress;
        private static string progressmsg;

        public static Thread SendtoServerMes;
        public static string ReceiveServerMsg;

        /// <summary>
        /// 上传未完成的文书
        /// </summary>
        public static Thread UploadFilesUnFinsheddoc;


        /// <summary>
        /// 程序当前路径
        /// </summary>
        public static string SysPath = Directory.GetCurrentDirectory();

        private static string stat;

        //当前应用程序的路径             
        private static string apppath;
       
        //判断是否已经进行过了初始化设置
        private static bool startflag = false;

        // 当前最佳服务器       
        private static string IpPort = "";


        // 最佳服务器的地址        
        private static string BestIp = "";
        private static string lujin = "";

        // 所有服务器的IP和端口号列表         
        public static string[] ServerList;

        //根据所在医院的区域值获取的服务器的IP和端口号列表
        public static string[] ServerList2;

        //当前系统的版本好
        public static string ProgrameVersion = "";

        // 连接方式              
        public static string linkFormat = "0";

        // 快捷码查询列表         
        private static frmCodeSelect uccodeselect = new frmCodeSelect();

        // 用于存放快捷码查询结果       
        public static Class_SelectObj SelectObj = null;

        // 快码查询是否结束 true结束 false未结束        
        public static bool FastCodeFlag = false;

        // 记录打开窗体的步骤（dll名+函数名+窗体类型）       
        public static ArrayList Openforms;

        /// <summary>
        /// 服务器端的一些触发消息操作集合
        /// </summary>
        public static string ServiceOpersXml = "";

        // Excel文件的路径      
        public static string ExcelFileName = "";

        // Excel中的表名       
        public static string tableName = "";

        /// <summary>
        /// 路径用户
        /// </summary>
        public static string EcpUser = "newecp.";
        /// <summary>
        /// BI用户
        /// </summary>
        public static string BIUser = "bisj.";

        /// <summary>
        /// 护理记录单模版选择内容
        /// </summary>
        public static string NurseResault = "";

        // 签名对象的一些信息       
        internal static Class_DocSign DocSign;

        // 获取当前登录用户的帐号        
        public static Class_Account UserAccount;

        // 当前主窗体的标题      
        public static string MdiFormTittle = "";

        // 当前程序的主窗体        
        public static Form ParentForm = null;

        /// <summary>
        /// Remoting映射类，该类主要功能是
        /// 是使可户端与服务器端建立映射关系，从而进行数据库的操作。
        /// </summary>
        public static DbHelp Operater = null;
        public static DbHelp Operater2 = null;

        // 医院名称      
        public static string HospitalTittle = "";

        // 检验检查的结果      
        public static string LisResault = "";

        //医嘱结果
        public static string His_Yz_Resault = "";

        //Pasc的结果
        public static string PascResault = "";

        // 消息提示框       
        private static AlertCustom m_AlertOnLoad = null;

        private static FtpWebRequest reqFTP;

        /// <summary>
        /// 管理界面的主容器
        /// </summary>
        public static DevComponents.DotNetBar.TabControl tabMain;

        /// <summary>
        /// 管理界面的工具栏
        /// </summary>
        public static DevComponents.DotNetBar.RibbonBar MainToolBar;

        /// <summary>
        /// 管床医生监控列表
        /// </summary>
        public static Control ucRecord;

        // RoleFlag   0--默认文书权限都能使用  1--默认文书权限都不能使用       
        private static string Roleflag;

        // Refreshflag 0--编辑器中的复制粘贴可用  1--复制病历可用  
        public static string Refreshflag;

        //上级医师查房时间
        public static string CurrentUpdateTime = "";

        //上级医师查房内容
        public static string CurrentUpdateContent = "";

        //上级医师查房ID
        public static string CurrentHightDoctorId = "";

        /// <summary>
        /// 当前打开的所有文书
        /// </summary>
        public static ArrayList OperaterDocIdS = new ArrayList();

        /// <summary>
        /// 当前所处的分院
        /// </summary>
        public static int CurrentHospitalId = 0;

        /// <summary>
        /// 当前选中的Remoting地址
        /// </summary>
        public static string remotingIp = "";

        /// <summary>
        /// 分院使用区域列表
        /// </summary>
        public static string[] HosptalIds;

        /// <summary>
        /// 其他系统调用标志  true 是  false 否
        /// </summary>
        public static bool isOtherSystemRefrenceflag = false;
        public static string OtherSystemAccount = "";
        public static string OtherSystemHisId = "";
        public static string OtherSystemDept = "";             //其他系统的标志 D 科室 N 病区  + 代码

        //Pasc的结果(影像学意见)
        public static string PascResault_YJ = "";

        public static string[] ServerListUrl;
        
        /// <summary>
        /// 当前选中的WebServie地址
        /// </summary>
        public static string webserviceIp = "";


        #region 临床路径全局变量
        public const string ITEM_CODEDoctor = "938"; //医生
        public const string ITEM_CODENurse = "959";//护士
        public const string ITEM_CODEVariation = "940";//变异
        /// <summary>
        /// 数据库用户名
        /// </summary>
        public static readonly string tablespace = "ecp.";

        public static string Second_HospitalTitle = "浙  江  省  新  华  医  院";

        /// <summary>
        /// 住院流程查看
        /// </summary>
        public static event EventHandler On_Zhuyuan = null;
        /// <summary>
        /// 提前模板
        /// </summary>
        public static event EventHandler On_GetTemplete = null;
        /// <summary>
        /// 保存模板
        /// </summary>
        public static event EventHandler On_SaveTemplete = null;
        #endregion



        /// <summary>
        /// 初始化函数
        /// </summary>
		public App()
        { 
            //
            // TODO: 在此处添加构造函数逻辑
            //			            
        }

        #region 属性
        #endregion

        #region 钩子注册
        /// <summary>
        /// 键盘钩子
        /// </summary>
        static KeyBordHook kh;
        /// <summary>
        /// 鼠标钩子
        /// </summary>
        static MouseHook mh;
        public static void StartHook()
        {
            if (kh == null)
                kh = new KeyBordHook();
            kh.Start();
            kh.OnKeyPressEvent += new KeyPressEventHandler(kh_OnKeyPressEvent);

            if (mh == null)
                mh = new MouseHook();
            mh.Start();
            mh.OnMouseActivity += new MouseEventHandler(mh_OnMouseActivity);
        }

        static void kh_OnKeyPressEvent(object sender, KeyPressEventArgs e)
        {
            if (App.UserAccount != null)
            {
                if (DateTime.Now > App.UserAccount.Enable_end_time)
                {
                    //kh.Stop();
                    //kh.OnKeyPressEvent -= new KeyPressEventHandler(kh_OnKeyPressEvent);
                    StopHook();
                    FrmPassWordChecked frmPass = new FrmPassWordChecked();
                    frmPass.StartPosition = FormStartPosition.CenterScreen;
                    frmPass.ShowDialog();
                }
                else
                {
                    if (App.UserAccount.TimeOut_Unit == "分")
                    {
                        App.UserAccount.Enable_end_time = DateTime.Now.AddMinutes(App.UserAccount.TimeOut);
                    }
                    else
                    {
                        App.UserAccount.Enable_end_time = DateTime.Now.AddSeconds(App.UserAccount.TimeOut);
                    }
                }
            }
        }

        static void mh_OnMouseActivity(object sender, MouseEventArgs e)
        {
            if (App.UserAccount != null)
            {
                if (DateTime.Now > App.UserAccount.Enable_end_time)
                {
                    //mh.Stop();
                    //mh.OnMouseActivity -= new MouseEventHandler(mh_OnMouseActivity);
                    StopHook();
                    FrmPassWordChecked frmPass = new FrmPassWordChecked();
                    frmPass.StartPosition = FormStartPosition.CenterScreen;
                    frmPass.ShowDialog();
                }
                else
                {
                    if (App.UserAccount.TimeOut_Unit == "分")
                    {
                        App.UserAccount.Enable_end_time = DateTime.Now.AddMinutes(App.UserAccount.TimeOut);
                    }
                    else
                    {
                        App.UserAccount.Enable_end_time = DateTime.Now.AddSeconds(App.UserAccount.TimeOut);
                    }
                }
            }
        }
        /// <summary>
        /// 注销钩子
        /// </summary>
        public static void StopHook()
        {
            kh.Stop();
            kh.OnKeyPressEvent -= new KeyPressEventHandler(kh_OnKeyPressEvent);
            mh.Stop();
            mh.OnMouseActivity -= new MouseEventHandler(mh_OnMouseActivity);
        }
        #endregion

        /// <summary>
        /// 获取当前程序路径
        /// </summary>
        public static string AppPath
        {
            get
            {
                if (apppath == null || apppath == "")
                {
                    apppath = Application.StartupPath;
                }
                return apppath;
            }
        }

        /// <summary>
        /// 初始化Web服务
        /// </summary>
        public static void iniwebservice()
        {
            //WebService = new Bifrost.WebReference.Service();
            //string webip = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebService_EMR/Service.asmx";
            //WebService.Url = webip;

        }

        /// <summary>
        /// 释放锁定的文书
        /// 关闭系统或者切换角色 释放之前操作中锁定的文书 
        /// </summary>
        public static void ReleaseLockedDoc()
        {
            int CurrentProcessID = System.Diagnostics.Process.GetCurrentProcess().Id;
            string sql = "delete from t_patient_doc_locked where processid=" + CurrentProcessID;
            App.ExecuteSQL(sql);
        }

        /// <summary>
        /// 关闭患者操作界面时 释放之前操作该患者是锁定的文书
        /// </summary>
        /// <param name="_patient_id"></param>
        public static void ReleaseLockedDoc(string _patient_id)
        {
            int CurrentProcessID = System.Diagnostics.Process.GetCurrentProcess().Id;
            string sql = "delete from t_patient_doc_locked where processid=" + CurrentProcessID;
            sql += " and patient_id=" + _patient_id;
            App.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取源图片名称集合
        /// </summary>
        /// <returns></returns>
        public static string[] GetImgSourcesFiles()
        {
            try
            {
                //WebReference.Service web = new Bifrost.WebReference.Service();
                //return web.GetImageSourceFiles();
                //return WebService.GetImageSourceFiles();
                return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 关闭文书操作界面时 释放之前用户操作该文书时锁定的文书
        /// </summary>
        /// <param name="_patient_id"></param>
        public static void ReleaseLockedDoc(string _patient_id, string _tid)
        {
            int CurrentProcessID = System.Diagnostics.Process.GetCurrentProcess().Id;
            string sql = "delete from t_patient_doc_locked where processid=" + CurrentProcessID;
            sql += " and patient_id=" + _patient_id;
            sql += " and tid=" + _tid;
            App.ExecuteSQL(sql);
        }

        /// <summary>
        /// 患者的某个文书是否锁定
        /// </summary>
        /// <param name="_patient_id"></param>
        /// <param name="_tid"></param>
        /// <returns></returns>
        public static bool IsDocLocked(string _patient_id, string _tid)
        {
            string sql = "select count(0) col from t_patient_doc_locked where 1=1";
            sql += " and patient_id=" + _patient_id;
            sql += " and tid=" + _tid;
            string col = App.ReadSqlVal(sql, 0, "col");
            if (string.IsNullOrEmpty(col) || col == "0")
                return false;
            return true;
        }

        /// <summary>
        /// 锁住患者的操作的文书
        /// </summary>
        /// <param name="_patient_id"></param>
        /// <param name="_tid"></param>
        public static void LockedDoc(string _patient_id, string _tid)
        {
            try
            {
                if (IsDocLocked(_patient_id, _tid) == false)
                {
                    string sql = "insert into t_patient_doc_locked (user_id, ip, processid, patient_id, tid, locktime) values ('" + App.UserAccount.UserInfo.User_id + "','" + GetHostIp() + "', '" + System.Diagnostics.Process.GetCurrentProcess().Id + "', '" + _patient_id + "', '" + _tid + "', sysdate)";
                    App.ExecuteSQL(sql);
                }
            }
            catch { }
        }

        #region 数据库操作


        /*
         *说明：
         *当前的数据库使用的Oracle，数据库操作方式主要有两种：
         * 1.WebService方式：这种方式通过Http协议，稳定安全，但是性能弱了一点。
         * 2.Remoting方式：这种方式主要通过TCP/IP协议，执行效率较高，但安全性没有前者好。
         * 目前主要采用的是第二种方式。
         *
         * 在每次对数据库进行操作的时候，都会通过RegeditRemotingChanel方法，进行服务器的检测，
         * 保证系统的正常运行，一但发现服务器异常，就会自动进行服务器的切换。
         */

        /// <summary>
        /// 测试数据库是否可以连接
        /// </summary>
        /// <returns></returns>
        public static bool ConnectTest()
        {
            try
            {
               
                    if (RegeditRemotingChanel())
                    {
                        bool flag = Operater.ConnectTest_MySql();
                        return flag;
                    }
                    else
                    {
                        return false;
                    }
                
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="CmdString">查询语句</param>        
        /// <returns></returns>
        public static DataSet GetDataSet(string CmdString)
        {
            try
            {
                if (CmdString != "")
                {
                   
                        DataSet ds = new DataSet();
                        if (RegeditRemotingChanel())
                        {
                            ds = Operater.GetDataSet_MySql(CmdString);
                        }
                        return ds;
                    
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 归档病人护理记录单数据转移
        /// </summary>
        /// <param name="Sqls">执行语句集合</param>
        /// <param name="patient_Id">病人主键ID</param>
        /// <param name="IsFile">是否归档</param>
        /// <returns></returns>
        public static ArrayList GetData_Transfer_SQL(ArrayList Sqls, string patient_Id, bool IsFile)
        {
            try
            {
                //string SqlActions_Delete = "";
                string SqlActions_Insert = "";
                string SqlActions_Del = "";
                if (IsFile)
                {
                    //归档操作
                    //SqlActions_Delete = "";//如果多次会导致数据丢失delete from T_NURSE_RECORD_HISTORY where patient_id='" + patient_Id + "' ";
                    SqlActions_Insert = "insert into T_NURSE_RECORD_HISTORY select ID,BED_NO,PID,MEASURE_TIME,ITEM_CODE,ITEM_VALUE,LIE_POS,STATUS_MEASURE,STATE,CREAT_ID,CREATE_TIME,UPDATE_ID,UPDATE_TIME,C_STATE,OTHER_NAME,PATIENT_ID,DIAGNOSE_NAME,ITEM_SHOW_NAME,RECORD_TYPE from T_NURSE_RECORD where patient_id='" + patient_Id + "' order by id";
                    SqlActions_Del = "delete from T_NURSE_RECORD where patient_id='" + patient_Id + "'";
                }
                else
                {
                    //归档退回操作
                    //SqlActions_Delete = "";//如果多次退档同一病人会导致数据丢失delete from T_NURSE_RECORD where patient_id='" + patient_Id + "' ";
                    SqlActions_Insert = "insert into T_NURSE_RECORD select ID,BED_NO,PID,MEASURE_TIME,ITEM_CODE,ITEM_VALUE,LIE_POS,STATUS_MEASURE,STATE,CREAT_ID,CREATE_TIME,UPDATE_ID,UPDATE_TIME,C_STATE,OTHER_NAME,PATIENT_ID,DIAGNOSE_NAME,ITEM_SHOW_NAME,RECORD_TYPE from T_NURSE_RECORD_HISTORY where patient_id='" + patient_Id + "' order by id";
                    SqlActions_Del = "delete from T_NURSE_RECORD_HISTORY where patient_id='" + patient_Id + "'";
                }

                //Sqls.Add(SqlActions_Delete);
                Sqls.Add(SqlActions_Insert);
                Sqls.Add(SqlActions_Del);
                return Sqls;
            }
            catch
            {
                return Sqls;
            }
        }

        /// <summary>
        /// PACS查看
        /// </summary>
        /// <param name="inPatient"></param>
        public static void frmShowPACS(InPatientInfo inPatient)
        {
            try
            {
                HisInStance.frm_Pasc fc = new HisInStance.frm_Pasc(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
                fc.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 护理记录单模版添加
        /// </summary>
        /// <param name="template_content">模板的内容</param>
        public static void frmShowTemplateAdd(string template_content)
        {
            try
            {
                frmTemplateAdd fc = new frmTemplateAdd(template_content);
                App.FormStytleSet(fc, false);
                fc.Show();
                fc.Focus();
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// LIS查看
        /// </summary>
        /// <param name="patient_id"></param>
        public static void frmShowLIS(string patient_id)
        {
            try
            {
                Bifrost.HisInstance.FrmLis fc = new Bifrost.HisInstance.FrmLis(patient_id);
                App.FormStytleSet(fc, false);
                fc.Show();
                fc.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 护理记录单模版管理
        /// </summary>
        public static void frmShowTemplateList()
        {
            try
            {
                frmTemplateList fc = new frmTemplateList();
                //App.FormStytleSet(fc, false);
                //fc.Show();
                //fc.Focus();
                fc.ShowDialog();
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 医嘱单查看
        /// </summary>
        /// <param name="inPatient"></param>
        public static void frmShowYZ(InPatientInfo inPatient)
        {
            try
            {
                Bifrost.HisInstance.frmYZ fc = new Bifrost.HisInstance.frmYZ(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
                fc.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 手术麻醉报告
        /// </summary>
        /// <param name="inPatient">用户实体</param>
        public static void frmShowSSMZ(InPatientInfo inPatient)
        {
            try
            {
                if (inPatient != null)
                {
                    //参数	    示例	    说明	            备注
                    //IP	    175.16.8.68	服务指向	
                    //Type	    Patient_id	病人ID号	        根据HIS
                    //Visit_id	Visit_id	住院次数或住院标识	根据HIS
                    //Mr_class	1001	    1001:麻醉
                    //His_no		        麻醉：his手术流水号 His手术流水号
                    //                      （可为空）	        （可为空）
                    //tp://175.16.8.68/DocareInterfaceV4/main/Patient_history.aspx?patient_id=ZY010013134663&visit_id=1&mr_class=1001&his_no=27103

                    string urlSSMZ = @"http://175.16.8.68/DocareInterfaceV4/main/Patient_history.aspx?patient_id=" + inPatient.His_id + "&visit_id=" + inPatient.InHospital_count + "&mr_class=1001&his_no=";
                    HisInStance.frmPicShow fc = new HisInStance.frmPicShow(urlSSMZ);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                    fc.Focus();
                }
            }
            catch
            {
                //App.MsgErr("请先选择病人!");
            }
        }

        /// <summary>  
        /// 根据where获取医嘱
        /// </summary>  
        /// <param name="where">从and开始写</param>  
        public static DataSet GetHisYz(string time, string his_id)
        {
            try
            {
                ////string[] His_id = his_id.Split('-');
                //WebReference.Service web = new Bifrost.WebReference.Service();
                //string sql = @"select ZYH,KSSJ,YZMC,YCJL,YCSL,SYPC,YPYF,XMMC,YPDJ,TZSJ,CZGH,FHGH,FYSX,YSGH,YSXGGH,TZYS,BZXX,LSYZ,XMLX,zfpb from zlhis.intf_emr_yzxx where zyh='" + his_id + "'";
                //DataSet ds_yz = web.GetDataSet(sql);
                //return ds_yz;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="TabSqls">查询语句集合</param>        
        /// <returns></returns>
        public static DataSet GetDataSet(Class_Table[] TabSqls)
        {
            try
            {
                
                    DataSet ds = new DataSet();
                    if (RegeditRemotingChanel())
                    {
                        DataOperater.Model.Class_Table[] TabSql2s = new DataOperater.Model.Class_Table[TabSqls.Length];
                        for (int i = 0; i < TabSqls.Length; i++)
                        {
                            TabSql2s[i] = new DataOperater.Model.Class_Table();
                            TabSql2s[i].Sql = TabSqls[i].Sql;
                            TabSql2s[i].Tablename = TabSqls[i].Tablename;
                        }
                        ds = Operater.GetDataSets_MySql(TabSql2s);
                    }
                    return ds;
               
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据行号和列名返回值
        /// </summary>
        /// <param name="CmdString">SQl语句</param>
        /// <param name="rowindex">行号</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        public static string ReadSqlVal(string CmdString, int rowindex, string colName)
        {
            try
            {
                
                    string val = "";
                    if (RegeditRemotingChanel())
                    {
                        val = Operater.ReadSqlVal_MySql(CmdString, rowindex, colName);
                    }
                    return val;
               
            }
            catch
            {
                return "";
            }
        }

        public static int GenId()
        {
            try
            {
                //if (ReadSqlVal("select count(" + Idname + ") from " + tablename + "", 0, Idname) != "0")
                //{
                //    string val = ReadSqlVal("select max(" + Idname + ") as " + Idname + " from " + tablename + "", 0, Idname);
                //    if (val.Trim() != "")
                //        return Convert.ToInt32(val) + 1;
                //    else
                //        return 1;
                //}
                //else
                //{
                //    return 1;
                //}
                string val = ReadSqlVal("select T_GENID.NEXTVAL col from dual WHERE ROWNUM =1", 0, "col");
                if (val == null)
                    return 1;
                return Convert.ToInt32(val);
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// 自动生成ID
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="Idname">id字段名</param>
        /// <returns></returns>
        public static int GenId(string tablename, string Idname)
        {
            try
            {
                if (ReadSqlVal("select count(" + Idname + ") from " + tablename + "", 0, Idname) != "0")
                {
                    string val = ReadSqlVal("select max(" + Idname + ") as " + Idname + " from " + tablename + "", 0, Idname);
                    if (val.Trim() != "")
                        return Convert.ToInt32(val) + 1;
                    else
                        return 1;
                }
                else
                {
                    return 1;
                }
                //string val = ReadSqlVal("select T_GENID.NEXTVAL col from dual WHERE ROWNUM =1", 0, "col");//select T_GENID.NEXTVAL as " + Idname + " from dual WHERE ROWNUM =1
                //if (val==null)
                //    return 1;
                //return Convert.ToInt64(val);
            }
            catch
            {
                return 1;
            }
        }

        public static int GenTextId()
        {
            try
            {

                string val = ReadSqlVal("select COVER_APPEND_ID.NEXTVAL col from dual WHERE ROWNUM =1", 0, "col");
                if (val == null)
                    return 1;
                return Convert.ToInt32(val);
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// 创建帐号主键
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="Idname">主键名</param>
        /// <param name="hospitalid">分院</param>
        public static int GenAccountId(string hospitalid)
        {
            try
            {
                if (ReadSqlVal("select count(ACCOUNT_ID) as ACCOUNT_ID from T_ACCOUNT where HSID=" + hospitalid + "", 0, "ACCOUNT_ID") != "0")
                {
                    string val = ReadSqlVal("select max(ACCOUNT_ID) as ACCOUNT_ID from T_ACCOUNT where HSID=" + hospitalid + "", 0, "ACCOUNT_ID");

                    if (val.Trim() != "")
                        return Convert.ToInt32(val) + 1;
                    else
                    {
                        if (hospitalid == "201")
                        {
                            return 1000000001;
                        }
                        else
                            return 1;

                    }
                }
                else
                {
                    if (hospitalid == "201")
                    {
                        return 1000000001;
                    }
                    else
                        return 1;
                }
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// 返回影响数据库的行数
        /// </summary>
        /// <param name="CmdString">查询语句</param>
        /// <returns></returns>
        public static int ExecuteSQL(string CmdString)
        {
            try
            {
               
                int cot = 0;
                if (RegeditRemotingChanel())
                {
                    cot = Operater.ExecuteSQL_MySql(CmdString);
                }
                return cot;
               
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 批处理SQl返回影响数据库的行数
        /// </summary>
        /// <param name="CmdStrings">查询语句集合</param>       
        public static int ExecuteBatch(string[] CmdStrings)
        {
          
                int cot = 0;
                if (RegeditRemotingChanel())
                {
                    cot = Operater.ExecuteBatch_MySql(CmdStrings);
                }
                return cot;
            
           
        }

        /// <summary>
        /// 以带参数的形式执行操作
        /// </summary>
        /// <param name="CmdString">SQL语句</param>
        /// <param name="Parameters">参数集合</param>       
        /// <returns></returns>        
        public static int ExecuteSQL(string CmdString, MySqlDBParameter[] Parameters)
        {
            try
            {


                    MySqlSDBParameter[] pmets = new MySqlSDBParameter[Parameters.Length];
                    for (int i = 0; i < Parameters.Length; i++)
                    {
                        pmets[i] = new MySqlSDBParameter();
                        pmets[i].ParameterName = Parameters[i].ParameterName;
                        pmets[i].Value = Parameters[i].Value;

                        getMySqlTypeProperty(Parameters[i], ref pmets[i]);
                    }
                    if (RegeditRemotingChanel())
                    {
                        return Operater.ExecuteSQLWithParams_MySql(CmdString, pmets);
                    }
                    else
                    {
                        return 0;
                    }
                
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        public static void RunProcedure(string storedProcName, MySqlDBParameter[] parameters)
        {
            try
            {
                
                    if (RegeditRemotingChanel())
                    {
                        MySqlSDBParameter[] pmets = new MySqlSDBParameter[parameters.Length];
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            pmets[i] = new MySqlSDBParameter();
                            pmets[i].ParameterName = parameters[i].ParameterName;
                            pmets[i].Value = parameters[i].Value;
                            if (parameters[i].Direction ==ParameterDirection.Output)
                            {
                                pmets[i].Direction = ParameterDirection.Output;
                            }
                            else if (parameters[i].Direction == ParameterDirection.Input)
                            {
                                pmets[i].Direction = ParameterDirection.Input;
                            }
                            else if (parameters[i].Direction == ParameterDirection.InputOutput)
                            {
                                pmets[i].Direction = ParameterDirection.InputOutput;
                            }
                            else
                            {
                                pmets[i].Direction = ParameterDirection.ReturnValue;
                            }

                            getMySqlTypeProperty(parameters[i], ref pmets[i]);
                        }
                        Operater.RunProcedure_MySql(storedProcName, pmets);
                    }
               
            }
            catch
            { }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        public static DataSet RunProcedureGetDataSet(string storedProcName, MySqlDBParameter[] parameters)
        {
            try
            {
                //if (linkFormat == "0")
                //{
                //    if (RegeditRemotingChanel())
                //    {
                //        MySqlDBParameter[] pmets = new MySqlDBParameter[parameters.Length];
                //        for (int i = 0; i < parameters.Length; i++)
                //        {
                //            pmets[i] = new MySqlDBParameter();
                //            pmets[i].ParameterName = parameters[i].ParameterName;
                //            pmets[i].Value = parameters[i].Value;
                //            if (parameters[i].Direction == ParameterDirection.Output)
                //            {
                //                pmets[i].Direction = ParameterDirection.Output;
                //            }
                //            else if (parameters[i].Direction == ParameterDirection.Input)
                //            {
                //                pmets[i].Direction = ParameterDirection.Input;
                //            }
                //            else if (parameters[i].Direction == ParameterDirection.InputOutput)
                //            {
                //                pmets[i].Direction = ParameterDirection.InputOutput;
                //            }
                //            else
                //            {
                //                pmets[i].Direction = ParameterDirection.ReturnValue;
                //            }

                //            getOracleTypeProperty(parameters[i], ref pmets[i]);
                //        }
                //        return Operater.RunProcedureGetData(storedProcName, pmets);
                //    }
                //}
                //else
                //{
                //    if (RegeditWebServiceChanel())
                //    {
                //        return WebService.RunProcedureGetData(storedProcName, parameters);
                //    }
                //}
                return null;
            }
            catch
            {
                return null;
            }
        }

        //Operater.RunProcedureGetData()

        /// <summary>
        /// 分页设置
        /// </summary>
        /// <param name="p_SqlSelect">查询语句</param>
        /// <param name="p_KeyColumn">主键</param>
        /// <param name="p_Order">排序方式 true:ASC false DESC</param>
        /// <param name="p_PageSize">每页行数</param>
        /// <param name="p_PageIndex">当前页码</param>
        /// <param name="p_RowCount">返回行数</param>
        /// <param name="p_PageCount">返回页数</param>
        /// <returns></returns>
        public static DataSet DataSetPage(string p_SqlSelect, string p_KeyColumn, bool p_Order, int p_PageSize, int p_PageIndex, ref int p_RowCount, ref int p_PageCount)
        {
            try
            {

                p_RowCount = int.Parse(ReadSqlVal("SELECT Count(*) FROM (" + p_SqlSelect + ")", 0, @"Count(*)"));
                int _StarRowIndex = (p_PageIndex - 1) * p_PageSize + 1;
                int _EndRowIndex = _StarRowIndex + p_PageSize - 1;
                if (p_RowCount % p_PageSize == 0)
                    p_PageCount = p_RowCount / p_PageSize;
                else
                    p_PageCount = p_RowCount / p_PageSize + 1;
                //string _SelectCommand = "SELECT * FROM (SELECT a.*, row_number() over(ORDER BY " + p_KeyColumn + " " + (p_Order ? "asc" : "desc") + ") as rn FROM (" + p_SqlSelect + ") a) WHERE rn BETWEEN " + _StarRowIndex.ToString() + " AND " + _EndRowIndex.ToString();
                //return GetDataSet(_SelectCommand);

                string _SelectCommand = p_SqlSelect + "  LIMIT  "+ _StarRowIndex.ToString()+","+ p_PageSize.ToString();
                return GetDataSet(_SelectCommand);


            }
            catch
            {
                p_PageCount = 0;
                p_RowCount = 0;
                return null;
            }
        }

        /// <summary>
        /// SQL关键字过滤
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSQLChar(string str)
        {
            if (str == String.Empty)
                return String.Empty; str = str.Replace("'", "‘");
            str = str.Replace(";", "；");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("@", "＠");
            str = str.Replace("=", "＝");
            str = str.Replace("+", "＋");
            str = str.Replace("*", "＊");
            str = str.Replace("&", "＆");
            str = str.Replace("#", "＃");
            str = str.Replace("%", "％");
            str = str.Replace("$", "￥");

            return str;
        }

        /// <summary>
        /// 转义特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSQLCharEN(string str)
        {
            if (str == String.Empty)
                return String.Empty;
            str = str.Replace("'", "''");
            return str;
        }

        /// <summary>
        /// 各分院之间数据同步
        /// </summary>
        /// <param name="curhospitalid">当前初始分院</param>
        /// <param name="Sqls">SQLS集合</param>
        public static void SynchronizationDataBase(string curhospitalid, ArrayList Sqls, string accantName)
        {
            if (curhospitalid != "")
            {
                if (App.HosptalIds != null)
                {
                    try
                    {
                        string[] sqlss = new string[Sqls.Count];
                        for (int i = 0; i < Sqls.Count; i++)
                        {
                            sqlss[i] = Sqls[i].ToString();
                        }
                        for (int i = 0; i < App.HosptalIds.Length; i++)
                        {
                            if (App.HosptalIds[i] != curhospitalid)
                            {
                                App.CurrentHospitalId = Convert.ToInt16(App.HosptalIds[i]);
                                if (!string.IsNullOrEmpty(accantName))
                                {
                                    if (App.GetDataSet("SELECT COUNT(ID) T_ACCOUNT WHERE ACCOUNT_NAME='" + accantName + "'").Tables[0].Rows[0][0].ToString() != "0")
                                    {
                                        App.ExecuteBatch(sqlss);
                                    }
                                }

                            }
                        }
                    }
                    catch
                    {
                        App.MsgErr("东西院和南院帐号同步操作失败！");
                    }
                    App.CurrentHospitalId = Convert.ToInt16(curhospitalid);
                }
            }
        }

        /// <summary>
        /// 各分院之间数据同步
        /// </summary>
        /// <param name="curhospitalid">当前初始分院</param>
        /// <param name="Sqls">SQLS集合</param>
        public static void SynchronizationDataBase(string curhospitalid, string Sql)
        {
            if (curhospitalid != "")
            {
                if (App.HosptalIds != null)
                {
                    try
                    {
                        for (int i = 0; i < App.HosptalIds.Length; i++)
                        {
                            if (App.HosptalIds[i] != curhospitalid)
                            {
                                App.CurrentHospitalId = Convert.ToInt16(App.HosptalIds[i]);
                                App.ExecuteSQL(Sql);
                            }
                        }
                    }
                    catch
                    {
                        App.MsgErr("东西院和南院帐号同步操作失败！");
                    }

                    App.CurrentHospitalId = Convert.ToInt16(curhospitalid);
                }
            }
        }

        /// <summary>
        /// 各分院之间数据同步  加账号和用户信息的关系
        /// </summary>
        /// <param name="curhospitalid">当前初始分院</param>
        /// <param name="Sqls">SQLS集合</param>
        /// <param name="Account_id">账号主键</param>
        /// <param name="User_id">用户主键</param>
        public static void SynchronizationDataBase(string curhospitalid, string Sql, string Account_id, string User_id, string AccountName)
        {
            if (curhospitalid != "")
            {
                if (App.HosptalIds != null)
                {
                    try
                    {
                        for (int i = 0; i < App.HosptalIds.Length; i++)
                        {
                            if (App.HosptalIds[i] != curhospitalid)
                            {
                                List<string> sqls = new List<string>();
                                App.CurrentHospitalId = Convert.ToInt16(App.HosptalIds[i]);
                                if (AccountName != null && AccountName != "")
                                {
                                    if (App.GetDataSet("SELECT COUNT(ACCOUNT_NAME) FROM T_ACCOUNT WHERE ACCOUNT_NAME='" + AccountName + "'").Tables[0].Rows[0][0].ToString() == "0")
                                    {
                                        sqls.Add(Sql);
                                    }
                                }
                                sqls.Add("delete from t_account_user t where t.account_id=" + Account_id + " and t.user_id=" + User_id + "");
                                string id = App.GenId().ToString();//"t_account_user","id"
                                sqls.Add("insert into T_ACCOUNT_USER(ID,ACCOUNT_ID,USER_ID)values(" + id + "," + Account_id + "," + User_id + ")");
                                App.ExecuteBatch(sqls.ToArray());

                            }
                        }
                    }
                    catch
                    {
                        App.MsgErr("东西院和南院帐号同步操作失败！");
                    }

                    App.CurrentHospitalId = Convert.ToInt16(curhospitalid);
                }
            }
        }
        #endregion            

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSystemTime()
        {
           

            try
            {
                if (linkFormat == "0")
                {                  

                    return Operater.GetSystemTime();
                }
                else
                {
                    string sql = " select   sysdate   time   from   dual ";
                    string dateTime = ReadSqlVal(sql, 0, "time");
                    return dateTime == null ? DateTime.Now : Convert.ToDateTime(dateTime);

                }
            }
            catch
            {
                return System.DateTime.Now;
            }
        }

        /// <summary>
        /// 设置菜单按钮的状态
        /// </summary>
        /// <param name="toolButtonName">按钮名</param>
        /// <param name="flag">状态</param>
        public static void SetToolButtonByUser(string toolButtonName, bool flag)
        {
            try
            {
                for (int i = 0; i < ParentForm.Controls.Count; i++)
                {
                    GetToolButton(ParentForm.Controls[i], toolButtonName, flag);
                }
            }
            catch
            {
            }
        }




        private static void GetToolButton(Control cl, string toolButtonName, bool flag)
        {
            if (cl.Name == "toolbar")
            {
                RibbonBar temptool = (RibbonBar)cl;
                for (int k = 0; k < temptool.Items.Count; k++)
                {
                    ButtonItem temp = (ButtonItem)temptool.Items[k];
                    if (temptool.Items[k].Name.ToLower() == toolButtonName.ToLower())
                    {
                        temptool.Items[k].Enabled = flag;
                        temptool.Refresh();
                    }
                }
            }
            else
            {
                if (cl.Controls.Count > 0)
                {
                    for (int i = 0; i < cl.Controls.Count; i++)
                    {
                        GetToolButton(cl.Controls[i], toolButtonName, flag);
                    }
                }
            }
        }

        /// <summary>
        /// 检测网络是否连通 返回响应时间
        /// </summary>
        /// <param name="ip">网络地址例如“192.168.1.10”或“www.163.com”</param>
        /// <returns>-1响应失败</returns>
        public static long PingResult(string ip)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "aa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            //Wait seconds for a reply. 
            int timeout = 500;

            System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
            if (reply.Status.ToString().ToLower().Trim() == "success")
            {
                return reply.RoundtripTime;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        ///  获取最佳服务器
        /// </summary>
        /// <param name="ServerList">服务器列表</param>
        /// <returns>最佳服务器</returns>
        public static string GetBestServerUri(string[] ServerList)
        {
            if (ServerList != null)
            {
                long[] Reslect = new long[ServerList.Length];
                /*
                 * 获取响应的毫秒数
                 */
                for (int i = 0; i < ServerList.Length; i++)
                {
                    Reslect[i] = PingResult(ServerList[i].Split(':')[0]);
                }

                /*
                 * 获取最佳服务器
                 */
                long bestindex = 0;
                long temptime = 0;
                for (int i = 0; i < Reslect.Length; i++)
                {
                    if (Reslect[i] != 0)
                    {
                        if (i == 0)
                        {
                            temptime = Reslect[i];
                            bestindex = i;
                        }
                        else
                        {
                            if (Reslect[i] < temptime)
                            {
                                temptime = Reslect[i];
                                bestindex = i;
                            }
                        }
                    }
                }
                return ServerList[bestindex];
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 重定向服务器根据延迟情况自动寻找合适的服务器
        /// </summary>
        /// <returns></returns>
        public static bool RegeditRemotingChanel()
        {
            try
            {
                int restindex = 0;
                /*
                 *获取本院的连接remoting连接
                 */
                //ReSetSLink:
                ArrayList CurrentRemotings = new ArrayList();

                /*
                 * 说明有分院设置
                 */
                for (int i = 0; i < ServerList.Length; i++)
                {
                    if (ServerList[i].Split(',')[1].ToString().Trim() == CurrentHospitalId.ToString().Trim())
                    {
                        CurrentRemotings.Add(ServerList[i]);
                    }
                }

                /*
                 * 检测哪些remoting是有用的
                 */
                ArrayList CurrentUseFullRemotings = new ArrayList(); //目前可以使用的remoting集合
                for (int i = 0; i < CurrentRemotings.Count; i++)
                {
                    try
                    {
                        string remotingIp = CurrentRemotings[i].ToString();
                        string uri = "tcp://" + remotingIp.Split(',')[0].ToString() + "/TcpService";
                        object o = Activator.GetObject(typeof(DbHelp), uri);
                        Operater = (DbHelp)o;
                        Operater.ConnectTest_MySql();//remoting操作是否正确
                        CurrentUseFullRemotings.Add(CurrentRemotings[i].ToString());
                    }
                    catch
                    {

                    }
                }


                /*
                 * 绑定remoting
                 */
                if (CurrentUseFullRemotings.Count > 1)
                {
                    Random tn = new Random();
                    remotingIp = CurrentUseFullRemotings[tn.Next(0, CurrentUseFullRemotings.Count - 1)].ToString();
                }
                else
                {
                    remotingIp = CurrentUseFullRemotings[0].ToString();
                }

                string uri2 = "tcp://" + remotingIp.Split(',')[0].ToString() + "/TcpService";
                object o2 = Activator.GetObject(typeof(DbHelp), uri2);
                Operater = (DbHelp)o2;
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 重定向服务器根据延迟情况自动寻找合适的服务器
        /// </summary>
        /// <returns></returns>
        public static bool RegeditWebServiceChanel()
        {
            try
            {

                ///*
                //* 检测哪些WebService是有用的
                //*/
                //ArrayList CurrentUseFullRemotings = new ArrayList(); //目前可以使用的WebService集合
                //for (int i = 0; i < ServerListUrl.Length; i++)
                //{
                //    try
                //    {
                //        string webip = @"http://" + ServerListUrl[i] + @"/WebSite1/Service.asmx";
                //        WebService.Url = webip;
                //        if (WebService.ConnectTest())
                //        {
                //            CurrentUseFullRemotings.Add(ServerListUrl[i]);
                //        }
                //    }
                //    catch
                //    {
                //        ReSetWebServiceUrl();
                //    }
                //}



                ///*
                // * 绑定WebService
                // */
                //if (CurrentUseFullRemotings.Count > 1)
                //{
                //    Random tn = new Random();
                //    webserviceIp = CurrentUseFullRemotings[tn.Next(0, CurrentUseFullRemotings.Count - 1)].ToString();
                //}
                //else
                //{
                //    webserviceIp = CurrentUseFullRemotings[0].ToString();
                //}

                //string url2 = @"http://" + webserviceIp + @"/WebSite1/Service.asmx";
                //WebService.Url = url2;

                return true;
            }
            catch
            {
                return false;
            }

        }


        /// <summary>
        /// 获取可用的url地址列表
        /// </summary>
        private static void ReSetWebServiceUrl()
        {
            //string AllService = Read_ConfigInfo("WebServerPath", "UrlList", SysPath + "\\Config.ini");
            //ArrayList serlist = new ArrayList();
            //string[] tempurls = AllService.Split(';');
            //for (int i = 0; i < tempurls.Length; i++)
            //{
            //    try
            //    {
            //        string webip = @"http://" + tempurls[i] + @"/WebSite1/Service.asmx";
            //        WebService.Url = webip;
            //        if (WebService.ConnectTest())
            //        {
            //            serlist.Add(tempurls[i]);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ex.Message.ToString();
            //    }
            //}

            //ServerListUrl = new string[serlist.Count];
            //for (int i = 0; i < serlist.Count; i++)
            //{
            //    ServerListUrl[i] = serlist[i].ToString();
            //}
        }


        /// <summary>
        /// 系统初始化
        /// </summary>
        public static void Ini()
        {

            /*
             * 说明：
             * 1.是获取一些系统运行所需的必要参数，例如：当前的程序的执行路径，以及服务器端列表等。
             * 2.与服务器端建立连接选择最佳的服务器。
             * 
             */
            try
            {

                //WebService = new Bifrost.WebReference.Service();
                //string webip1 = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite1/Service.asmx";
                //WebService.Url = webip1;
                //App.Progress("系统初始化，请稍候...");                             

                //Write_ConfigInfo("Editor", "Hospitalname", "首都医科大学附属北京同仁医院", SysPath + "\\Config.ini");
                SysPath = Application.StartupPath;
                //一些基础信息
                HospitalTittle = Read_ConfigInfo("Editor", "Hospitalname", SysPath + "\\Config.ini");


                Openforms = new ArrayList();
                string AllService = Read_ConfigInfo("WebServerPath", "ServiceList", SysPath + "\\Config.ini");

                //获取文书权限的默认方式
                //RoleFlag   0--默认文书权限都能使用  1--默认文书权限都不能使用
                Roleflag = App.Read_ConfigInfo("WebServerPath", "RoleFlag", SysPath + "\\Config.ini").Trim();
                if (Roleflag == "")
                {
                    App.Write_ConfigInfo("WebServerPath", "RoleFlag", "0", SysPath + "\\Config.ini");
                    Roleflag = "0";
                }

                //获得转换方式
                Refreshflag = App.Read_ConfigInfo("WebServerPath", "RefreshFlag", SysPath + "\\Config.ini").Trim();
                if (Refreshflag == "")
                {
                    App.Write_ConfigInfo("WebServerPath", "RefreshFlag", "0", SysPath + "\\Config.ini");
                    Refreshflag = "0";
                }

                ReSetWebServiceUrl();
                CurrentHospitalId = 1;
                HosptalIds = new String[] { "1" };


                //if (AllService != "")
                //{
                //    ReSetServerLink();
                //    CurrentHospitalId = GetCurrentHospitalId(ServerList);
                //    HosptalIds = GetHospitalIds(ServerList);
                //}
                //else
                //{
                //    AllService = "localhost:9999;192.168.1.70:9999;192.168.1.30:9999";
                //    ServerList = AllService.Split(';');
                //    Write_ConfigInfo("WebServerPath", "ServiceList", AllService, SysPath + "\\Config.ini");
                //}

                ProgrameVersion = Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Version", Application.StartupPath + "\\Config.ini"));

                //if (CurrentHospitalId != 0)
                //    ServerList2 = GetServerListByHospitalId(ServerList, CurrentHospitalId);
                //else
             
                if (!startflag)
                {

                    linkFormat = Read_ConfigInfo("WebServerPath", "LinkFormat", SysPath + "\\Config.ini");
                    if (linkFormat == "0")
                    {
                        /*
                         * remoting方式
                         */
                        //BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
                        //provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Low;
                        //Hashtable props = new Hashtable();
                        //props["name"] = "tcp_rem";
                        ////props["timeout"] = 10000;//设置超时时间 
                        //TcpChannel _tcpChannel = new TcpChannel(props, null, null);
                        //ChannelServices.RegisterChannel(_tcpChannel, false);
                        ReSetServerLink();

                        ServerList2 = ServerList;

                        //获取最佳的服务器
                        Random tn = new Random();
                        IpPort = ServerList[tn.Next(0, ServerList2.Length)];//GetBestServerUri(ServerList); 
                        BestIp = IpPort.Split(':')[0];
                        if (IpPort != null)
                        {
                            if (IpPort.Contains(","))
                            {
                                remotingIp = IpPort;
                                IpPort = IpPort.Split(',')[0];
                            }
                            IpPort = @"tcp://" + IpPort + @"/TcpService";
                        }

                    }
                    else
                    {
                        /*
                         * webservice方式
                         */
                        //if (WebService == null)
                        //{
                        //    WebService = new WebReference.Service();
                        //}
                        //string webip = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebService_EMR/Service.asmx";
                        //WebService.Url = webip;

                        //if (WebService.ConnectTest() == false)
                        //{
                        //    MsgErr("数据库未正常连接");
                        //}
                        ReSetWebServiceUrl();
                    }
                    startflag = true;
                }
                SendtoServerMes = new Thread(new ThreadStart(SendMessageToServer));
                SendtoServerMes.IsBackground = true;
            }
            catch (Exception ex)
            {
                MsgErr("系统初始化失败,可能由于网络连接不正常,服务器未启动或参数设置不正确！详细原因:" + ex.ToString());
                Application.Exit();
            }
            //finally
            //{
            //    App.HideProgress();
            //}
        }

        private static void ReSetServerLink()
        {
            string AllService = Read_ConfigInfo("WebServerPath", "ServiceList", SysPath + "\\Config.ini");
            ArrayList serlist = new ArrayList();
            string[] tempurls = AllService.Split(';');
            for (int i = 0; i < tempurls.Length; i++)
            {
                string ipport = tempurls[i].Split(',')[0].ToString().Split(':')[0];
                int port = Convert.ToInt16(tempurls[i].Split(',')[0].ToString().Split(':')[1]);
                try
                {
                    TcpClient connection = new TcpClientWithTimeout(ipport, port, 1000).Connect();
                    serlist.Add(tempurls[i]);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            ServerList = new string[serlist.Count];
            for (int i = 0; i < serlist.Count; i++)
            {
                ServerList[i] = serlist[i].ToString();
            }
        }

        /// <summary>
        /// 弹出消息提示窗体2
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        public static void ShowTip(string title, string content)
        {
            try
            {
                m_AlertOnLoad = new AlertCustom(title, content, "");
                Rectangle r = Screen.GetWorkingArea(Application.OpenForms[0]);
                m_AlertOnLoad.Location = new Point(r.Right - m_AlertOnLoad.Width, r.Bottom - m_AlertOnLoad.Height);
                m_AlertOnLoad.AutoClose = true;
                m_AlertOnLoad.AutoCloseTimeOut = 15;
                m_AlertOnLoad.AlertAnimation = eAlertAnimation.BottomToTop;
                m_AlertOnLoad.AlertAnimationDuration = 700;
                m_AlertOnLoad.Show(false);
            }
            catch
            { }
        }

        /// <summary>
        /// 弹出消息提示窗体2
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="url">连接</param>
        public static void ShowTip(string title, string content, string url)
        {
            try
            {
                m_AlertOnLoad = new AlertCustom(title, content, url);
                Rectangle r = Screen.GetWorkingArea(Application.OpenForms[0]);
                m_AlertOnLoad.Location = new Point(r.Right - m_AlertOnLoad.Width, r.Bottom - m_AlertOnLoad.Height);
                m_AlertOnLoad.AutoClose = true;
                m_AlertOnLoad.AutoCloseTimeOut = 15;
                m_AlertOnLoad.AlertAnimation = eAlertAnimation.BottomToTop;
                m_AlertOnLoad.AlertAnimationDuration = 700;
                m_AlertOnLoad.Show(false);
            }
            catch
            { }
        }


        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section">章节</param>
        /// <param name="key">关键词</param>
        /// <param name="keyvalue">要写入的值</param>
        /// <param name="path">INI文件路径</param>
        public static void Write_ConfigInfo(string section, string key, string keyvalue, string path)
        {
            WritePrivateProfileString(section, key, keyvalue, path);
        }


        /// <summary>
        /// 读取INI文件信息
        /// </summary>
        /// <param name="section">章节</param>
        /// <param name="key">关键词</param>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string Read_ConfigInfo(string section, string key, string path)
        {
            try
            {
                //获取配置信息
                StringBuilder temp1 = new StringBuilder(2550);
                int i1 = GetPrivateProfileString(section, key, "", temp1, 2550, path);
                return temp1.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// 编历窗体所有Button控件，改变按钮样式
        /// </summary>
        /// <param name="frm">窗体</param>
        public static void ButtonStytle(System.Windows.Forms.Form frm)
        {

            foreach (System.Windows.Forms.Control ctr in frm.Controls)
            {
                GetControl(ctr);
            }
            frm.ControlBox = true;
            frm.MaximizeBox = true;
            frm.MinimizeBox = true;
            frm.ShowIcon = true;
            frm.ShowInTaskbar = false;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        }

        /// <summary>
        /// 控件样式设置
        /// </summary>
        /// <param name="Ctl">控件</param>
        public static void UsControlStyle(System.Windows.Forms.Control Ctl)
        {
            GetControl(Ctl);
        }

        /// <summary>
        /// 编历窗体所有Button控件，改变按钮样式
        /// </summary>
        /// <param name="frm">窗体</param>
        /// <param name="isMaxSize">是否全屏显示</param>
        public static void ButtonStytle(System.Windows.Forms.Form frm, bool isMaxSize)
        {

            GetControl(frm);
            frm.ShowIcon = true;
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;            
            if (isMaxSize)
            {
                frm.ControlBox = false;
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }

        }

        /// <summary>
        /// 窗体样式的设定
        /// </summary>
        /// <param name="f">窗体</param>
        public static void FormStytleSet(System.Windows.Forms.Form f)
        {
            try
            {
                foreach (System.Windows.Forms.Control ctr in f.Controls)
                {
                    GetControl(ctr);
                }
                f.ControlBox = false;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                f.ShowIcon = false;
                f.ShowInTaskbar = true;
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                f.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch
            {

            }
        }


        /// <summary>
        /// 窗体样式的设定
        /// </summary>
        /// <param name="f">窗体</param>
        /// <param name="flag">是否改变窗体尺寸和其他一些属性</param>
        public static void FormStytleSet(System.Windows.Forms.Form f, bool flag)
        {
            try
            {
                foreach (System.Windows.Forms.Control ctr in f.Controls)
                {
                    GetControl(ctr);
                }
                if (flag)
                {
                    f.ControlBox = false;
                    f.MaximizeBox = false;
                    f.MinimizeBox = false;
                    f.ShowIcon = false;
                    f.ShowInTaskbar = true;
                    f.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                    f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    f.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 进度开始
        /// </summary>
        /// <param name="Message">信息</param>
        public static void Progress(string Message)
        {
            try
            {
                progressmsg = Message;
                StartProgressServerice();
            }
            catch
            { }
        }

        /// <summary>
        /// 进度结束
        /// </summary>
        public static void HideProgress()
        {
            try
            {
                timedProgress.Abort();
            }
            catch
            { }
        }


        /// <summary>
        /// 以字节流的形式读取文件
        /// </summary>
        /// <param name="PathFile">文件路径</param>
        /// <returns></returns>
        public static byte[] ReadBinFile(string PathFile)
        {
            try
            {
                FileStream input = new FileStream(PathFile, FileMode.OpenOrCreate);
                BinaryReader reader = new BinaryReader(input);
                int length = (int)input.Length;
                byte[] buffer = reader.ReadBytes(length);
                reader.Close();
                return buffer;
            }
            catch (Exception exception)
            {
                stat = exception.Message;
                return null;
            }
        }

        /// <summary>
        /// Bitmap格式的转换
        /// </summary>
        /// <param name="ImageByte">字节流</param>
        /// <returns></returns>
        public static Bitmap ByteToImg(byte[] ImageByte)
        {
            if (ImageByte == null)
            {
                return null;
            }
            try
            {
                return new Bitmap(new MemoryStream(ImageByte));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 判断是否是数值类型
        /// </summary>
        /// <param name="str">需要判断的参数</param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            try
            {
                double.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 消息提示框
        /// </summary>
        /// <param name="text">消息</param>
        public static void Msg(string text)
        {
            //MessageBoxEx.UseSystemLocalizedString = true;
            //MessageBoxEx.Show(text, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);	
            MessageBox.Show(text, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 消息提示框
        /// </summary>
        /// <param name="text">消息</param>
        /// <param name="parentfrm">父窗体</param>
        public static void Msg(string text, Form parentfrm)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            MessageBoxEx.Show(parentfrm, text, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 错误消息提示
        /// </summary>
        /// <param name="text">错误信息</param>
        public static void MsgErr(string text)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            MessageBoxEx.Show(text, "错误信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 警告消息提示
        /// </summary>
        /// <param name="text">错误信息</param>
        public static void MsgWaring(string text)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            MessageBoxEx.Show(text, "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 消息询问提示框
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static bool Ask(string msg)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            return (MessageBoxEx.Show(msg, "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        /// <summary>
        /// 获取Excel数据
        /// </summary>		
        /// <returns></returns>
        public static DataSet ReadExcel()
        {
            ExcelFileName = "";
            tableName = "";
            frmExcelInfo f = new frmExcelInfo();
            f.ShowDialog();
            if (ExcelFileName != string.Empty && tableName != string.Empty)
            {
                DataSet myDS = new DataSet();
                //数据库连接字符串 
                string myConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                //查询字符串 
                string mySQLstr = "SELECT * FROM [" + tableName + "$]";
                //连接数据库操作 
                OleDbConnection myConnection = new OleDbConnection(myConn);
                try
                {
                    //执行SQL语句操作 
                    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(mySQLstr, myConnection);
                    //打开Excel
                    myConnection.Open();
                    //向DataSet填充数据
                    myDataAdapter.Fill(myDS);
                    Console.Read();
                }
                catch
                {
                    return null;
                }
                finally
                {
                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close();
                }
                return myDS;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回五笔码
        /// </summary>
        /// <param name="inputstring">字符串</param>
        /// <returns></returns>
        public static string GetWBcode(string inputstring)
        {
            #region old
            //string thisletter = ToDBC(inputstring.Trim());
            //int letterlen = thisletter.Length;
            //string pystring = "";

            //string LETTER1 = "ghgdgvatuggunnenkouftgqxnttrtnnmxgtucnladqturugivfryifeqfeofhqg ffmdgcgyyyyyyyuyywwnwwwwwwwwwwwhwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwgwwwwwwwwwwwwwwwww                                                               wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww wwwwwwwwwfwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww                                                               wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwgwwwwwwwwwwwwwwwwwww wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwabwwtdhvaufdffftuffitmgwugwwummmdmmmmjmajppppppppppppduuuuuuuuuuuuuuuuuuuuuu                                                               uuuuuuthntmmmmmmmmubbvvttfrefnvxevnwckffmggffebfgggyhkwfquftdaa ugmxcygwydgymnmtwamwxugnfmcacvtlyhqwkhwwiywwrwtyxnlrylrrdriurufucafgfgttgycfuyfusxdtjcakweonsfgxvrqattuuhyatthdtyaqqqqqqqqqqqqq                                               ";
            //LETTER1 = LETTER1 + "                tqqtxaaaaaaaaaaaaaaaaaaaaaaaaaanavflnnfeaxghhmqavqtwgwkswqdddrd dddddddddddddddddddddddidddcvdccngcccffnntcfcnpfnhokvkbkkykkkkkkkknkdkkkkkkktkkekikkkkktkkkkkkkkkkkkkkkkxkkkkkkkukkkkkkk kkkkkk                                                               kkkkkkkkkkmkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkdkkgkkfkkk kkkkkkkkkkkkkkkkukkkktukkyykkhkkkkyrkdkkkkkkkkkkkkkkfkkkkkkkdkkkkkkkkkkkkkfktkkkkkkigkkkfkkkkfkkkkkkkkkkkkkeklkfkkkkkgkkkkkkkkk                                                               kkkkkkkkkkkkikkkkkkkkkkkkkkkkkkkkkkkkkkkkkdkkkkkkkkkkkekkkkkykk kkkkkkkkkkkukkkkfkkkkkkkkkkkkkkkkkkkkkkkkkkkfkkkgkkkkkkkkkfxkkyqkkkkkkkkkkkkkkkukkkkjkfkakkkkkkmlllllllltlllllllllllllcllllllll                                                               llllllllllllffffffdftfffdffjffffffffffxfirffgfifjffffffffffffff ffwfffffufsrffffffffffffffffffffffftifftffbffffmfffrffffsffffffffffffffffffffffbifyfaffgffsffffffffffffffcffffffffffvfffffffiyf                               ";
            //LETTER1 = LETTER1 + "                                ffflfffffvffofffffffifffffafffifbfffffffiyfffyffflyffffffffffff vfnffffffffbfffffffffyfbfbnfffffffffffffeffnfswffffffiffgfdffflffffffufhffffflfffnfffffffffffffjetttytcfwqodqqqvqqqqayanndddddd                                                               dddgdddyhuqddcddddddgdctudddndddlxdvvvvvvvnvvvvvvvvvvvvbvnjvvvv vvvvvvqvvvvvvvlvvvvvvwvvvvvvhvvvvvvvvvvvvvvlvvvvvvgvvvvvvvvvvvvvrvvvvvvvvvvvvvvnvvvvvvvvvvvvvvvvvvvbkvvvvvvvvvvvvvvdvvvvvvavvvv                                                               vvvvvvvvvvvgvxvvvvvvvvvvvvvvvvvvvvvvvvavvvvvvvvvtvvvvvvvvvvvvvv evvvvvvvvvtvvvvvvvvvovvvvvvgvvvvvavvvfvvvvvvvvgvvuvvvvvvvvvvvvvvvdvvvvvavvvvvvvvvvvvvvvuvvvvvvvvvvvvvvvvvdvhivvvvvvvvvvvfvvvvvv                                                               vvvvxvvvbbbnbxbbbbabbyfrnbbbxppppppppppppppppppppppjppppppppppp ppppppppppppppppppppppppppppeyaggfngvfouiwthiidjaiwwdwvgfvvvvvvgvnnnnnncnrnnnnnnnnnnnnnnnnnuttmmmmmmmmmbmmmmmmcmmmmmmmmmmmmmmmm               ";
            //LETTER1 = LETTER1 + "                                                mmmmmmmmmmmmmmimmmmmwmmmmmmmmmmmmmmmmmmmmmmmmmmmqmmmmqmmwmmmimm mmmpmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmtmmcmmmmkmmmmmmmmwmmmmmommmmmmmmmmmmmmmmmmmmmmmmmmgmmmmmmmmmmmmmmmmmmmmmmbmm                                                               mmmmmmmwmmmmmmmmmmmtmmmmmmmmmmmmmmmmmmmmmmmmmmxmmmmmmmmvygevaaa grvabnuchtmnmmqymwmmmyvmmuvwmmmwvgjmmmmammmmmmmmfmmmtmmmetmmmmmmdmmmmuumnmmmmfmmmmmmgufxyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy                                                               yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyvmrlslwfwnaaagqxxxuxxxxxxx xxxuxxxxxxxxxxxpxoxxxuxxxxxxxxxnxxnvxvvvyyagmpsgttttttttttttttttttttttttttttttttttttqtttttttttrtnfnntnvnnnyyngnrnntnnnnnnnnnnnn                                                               nnnnnnnndmnnxrwnnnnqnnnnfswnvnnnnnnnnnnnvnnntnnnnnbnnbnnnnygwnn nnnwnnrnnnqnnnnannntntynngnnfnunpnnnnnsnnhnnipnanntnnjnnnngnrnvfnnndnnnnnnfnnnnnnnnnnnnncnpenvnnnnfnnunnnnnnlnnnnsnnbnnnnlinnn";
            //LETTER1 = LETTER1 + "n                                                               wncnnannnngnlnntnnnnnfnfnntnghnnnnnyafnndnwunnddttntnnwqnnnunnn ssnfnnnnndnnnnonnnnnnnnpnnnnnnnnannnnannneynnnnnndqninnnnnnonnninnnnnnnynngnntnnnnennnnnnxannnuuqaamamduwiwsgdphkhhhygyyynyyyyy                                                               rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrfrrrrrrrrrrrrrrr rrvrrrrrrrrrrfrrrrrrrrrrrrrrrvrrrrrrirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrr                                                               rrrdrrrrrrrrrrrrrrrrrrrrrgrtrrrrirrrrrrrrrrrrrrrrrrrrrrrrrrrrrr rrrrtrrrrrrrrrrrwrrrrrrrrrrrrrrrrrrrrrrrrrfrrrrrrrrgffrrrrrrrrrrrrfrluryrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrlrrrrrrrrrr                                                               rrrrrrrawrrdrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr rxrrrrrrrrfudfgnfwrhqncwghtwfdwugmwuwmcjjoduicjtnmmubkhaqftutllwufwwyyyyyyyyyyqckvfalrnqlafvaoqrxnyyyyyyyygyyy";
            //LETTER1 = LETTER1 + "yyyyyyyyyyyyarmjj                                                               jjjjjmjjjgjjjjjjjgjjjjjjjdjjjjjjjjjjjnjjjjjjjjjjjjjjjjjjgjjjjjj jjjvjjrjjjjjjjjjjsyjjjjjjjjjjjljjnjjjjjcjjjjjjujjjjjjjjdjjlfjjjjjjjjjjjjujjjrjjjjdjjjjjjjjjjjjkjjjjjjjjjjjjjjjjjxjjjjjjqvfjuajw                                                               jfuweeemeeeelyeaeeaeeeegfsssessssssgssssssssssynssssssssssssgss sssfswssssxssssssssssssssssssssscspssafsssssssfsswsspssssssssssssssssssssssssssssigsfsdsssssstswsssussssssssssssssssvsssfssssss                                                               sssssissssssssssssssssssssssssssssssssssssspwstsssspssssssssshs sssssssstyssssasssdssssgssssswssssssysssssssssssbassssssssssywsssssssssssswfssssssssssswsssssssssssssssssswssssssssssssssscssss                                                               sssssssssossssssussussssssssssssssfsssrssssssssjsssossssssssess ssystsssssssssksssfssssssssssssslswsssssssnsssfssssfsssxsssssssssssssssssswsssssssssssssssssss";
            //LETTER1 = LETTER1 + "ssssssssssssssssrssssssssssssssss                                                               dssssssnsssssssssssssssssssssssssbssssssssssssslswsssssssssssss ssssssssssssssssssssodsssssssssssssssslsssssssssssgssssssssssssssgsssssbsssssssssssbssssssssswssssssssssxsssssssswssssjwqvbrylu                                                               ftwhyxgcocqqsammswyrtaaahuthffvouwllfwcahhhhhhhvhhhdhhdwhgggggg gggggggggggggggggggggggggggggggyfaqffqfvylavqafxtfxlqttxiltnwtbttttgrttcttjttdjjcktfucyktatlqrrrrrrrrrrrrcyniiiiiiiiiiiiiiiiimi                                                               iiiiiiiifiiiiiiiiiiiiiiipiiiiiiigiiiiiiiiiiiiiiiiiisiiiiiiiiiii iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiitiiiiiiiiiiiidiiiiiiiiiiieiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                               iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiwiiiiiiiiiiiiiiiiiidiiiiiiiiiiiii iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiitiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii";
            //LETTER1 = LETTER1 + "eiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiioiiiiiiiiiiiiiiii                                                               iiiiiiiiiiiiiifiiiiiiiiiiifiiiiiiiiiiiiiiiifiiiiiiiiiiiiiiinixi iiiiiiiiieiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieiiiiiiiiiiiiiiiiiiiiiiiiiiiiwiiiiiiiiiiiiiiiiiiiiiiiiiiiitiiiiiiiiiiiiiiiiiiii                                                               iiijiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiit iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiixiiiiiiiiiiiiiiiiriiiiioooqoooofvaowoooooooooooaojooooooooooooooqoooonooooooqwoogtooooodfoo                                                               obooooooogooroooooooooookwovoooynoorboooouoooootobyoooooooooooo oojoooojooooooooooooooofoooaoooojhooooooooooovooooooooooooooocoootocoooooooooooooooooooootooodooofxoooooooooooootfoooooooosooos                                                               oooionoowoowoooooooooooooooooyooooofooohoooaooooooooooqoooooooo ooooooyooooooeereeelwqgnnnnnnhttttttttttttirrrrrrrrrrrrrrrurrr";
            //LETTER1 = LETTER1 + "rytrrrrrrrfrrrrroryrnfrrrrrrrrrrrwtrwdqqqqqqqqqqnwqqqhqqqqqqqqqqq                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ";
            //LETTER1 = LETTER1 + "                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            //LETTER1 = LETTER1 + "                                                                                                                                                                                                                                                                                                                                                                                                                              qqqqqqqqqqqqqqqqqqqqqdqqqdsqqqqjqqqqqqqqqqqqqqqqqqqqqqqqqmqqqqq qqqqnqqqqqquqqqqqqqqqiqqqqqqqqqqq                                                                                                                                                             qqqqqqkqqhqqqqqqqyyyggtggggggggggggggggggghaggggggggggggggggggg ggggggggggggggggggggggggggggggggg                                                                                                                                                             gggggggggggggggggggggggggggggjggggggggggggggggggggggggggggggggg gggggggggggggg";
            //LETTER1 = LETTER1 + "gggggoggigggggfgggg                                                                                                                                                             gggaggggggggggggggggigggggggggggggggggggggggggggggggggggggggggg ggggggggggggxggggggrrfrgagqwypgqg                                                                                                                                                             dcqkdqgittcytguotukuagotqyhhahijtyuggttqjtmlllrljeyhlllgoyillyl yflrllwllolvwllllglvilgllllvlllll                                                                                                                                                             gjlgncfuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu uuuuuuuuuuuuuuuuuuuuuyuuuuuuuuuuu                                                                                                                                                             uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuwwwqwrrrrrrrrrrrrrfrrr";
            //LETTER1 = LETTER1 + "r rrrrrrrrrrrrrrrrrhhfasfuhqhfyfhegkbfrkkyruatadebarpwrjmepejmmggrpwtniarrkktwucrkardfflwrsdrwmrtggrrtwstrrwuulxddssexsdjqwyaeqyv                                                               xdtdqiigfivaxvlatwhdfiwaxhhhhhhhhhhhhhhhhhhhhhhlhhhdhhhxhhhhhhh hhhhhhhhhhlhwhhhhhhhhhhhhhhhhhlhhafwwqprrjeqosddrudumqwqttopdastmxgdkugtxkttgaaxxxtyuuuunnnnnbalxmywyyuuuysheguukusyiiprrusgtqo                                                               thhhhhhlhhnhhhhhhhghhhhhrhhhhfhhlhehhahhhhhhbhhhhhhhhhhhhhhhhhh hhghhhhhhhhhhhhhhhhhhhxhhhhcccccxuugarrqiffrqtwrteeiicrhkpfidhtunrqfsfmhkeeaahcggnnoatwiarosgadtwminkrcaasdrpwuyrherrjqyxquuyjq                                                               qttttttddddddkddddddddddddddddddddkddvdddddddddddddddddddddkddd dddddddddddddrdidddddddddaddddaddfiitwedijkwfrqfkivkolrrrtisadijnibfprtfsdktttiybkctkurjinxcbhwnffroyujmprslktttwxhntpbsdkqqibs                                                               ddidddddddddddkdddkdddddddddkddddddddddddddddd";
            //LETTER1 = LETTER1 + "ddddkdddldddkdddd ddddddddddddddddddddddddddddddgdddwfrqtrkpswtkkupmyuwkorqtdssdixdnxuadhtuuyhgmubatqwwuostwktprmweuoinsdfdrrrrqrdturdkgwfggwwwtv                                                               dddwdddnddddddwdddddddddldddsddddudddddddppppppppppppppppppfphp pppppppppppppppppppppppppppppppppcbrmuurejrwniyxniriasvrkwqpngtnuuttrkowthwcfwimttqinvryfatuuuxfridhmgrjwqynuindkmunrkqykwdjryc                                                               ppppppppoppppppppptpppppppppppppppmhtttttttottttttttttttttttttt tttttttuttttttyttttttttttttttttttshkqshqpytatanfswnuiqrubggufhgtqyfhmsqeyivutqwoxfubcfkkyglqrrrkqdftmktmnbjmtwpyvgdrjkqldqbqqif                                                               tyttttttttttttttttttttttyfttttttytttqtxtttttttttttttttttttttttt ttttttttttpppppppppppppppppppppppavltwtuigamttsdqtmorramqqifayeybvwyxyadkneaykeyixaskrwxfsiodwwnodfsjmqmuotuxydmwgfgeqrrlmrtwwe                                                               pppppppppppppppppppppppppppppp";
            //LETTER1 = LETTER1 + "pppuuuuuuuuuuuuuuuuuuuruuauuuuuuu uuuuuttttttttttttttttttttttttttttiippxgrlwwweeyyfgsmtwwwweqpybvxkkkynsquifasstefdtnummqrexmistryyuorqttssraweupaasjubqwtxskdgyu                                                               ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt ttttttttttttttttttttttqttttttttttfbsaaaadwtwpxaaraaqqiaqfsmqdaktwibvfdjmweddlytrkprptrnsuppctqrnixiyqgffdjqulrywsskkwlisqyljyfk                                                               tttttttttttttttttttttttttttttttttttttttttttttttttt tttttttttttt tttttttttttttttttttttttttttttttttmbirypcsnafwipbkpfrrjnnoiidstfkyyfvdkikkaasttwwweuiifpplklutqnkystnlkojiipxxkwqkdwrktqgfadjqoi                                                               tttttttttttttttttttttttttttttttttttttttttttttttooooojooooqooooo oxooooooooooovoooooooooooootoooooxhkrgiyakwqigawystnifcgsgxrkkuuoipxanadjtrmnojmnydritnjlvndfgjmtwoiyyxaqvfiipiwoaaafwpffaslttt                                                               ooooooooooooof";
            //LETTER1 = LETTER1 + "oooooioooooooonoooooboowaboxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxrxxxxxxsxxxxxxxeqyiycvxxfsgltwequivvxrminarutwwynippyyvnbvxxfsgwplagslqwtwllvgjjituuuycvxasgddrrtwuuasjkmmqtw                                                               xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxwdxxxxxxxxxxxxxxcxuxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxdxxxxwtwqiiivwuuuixauuyaubasdweuuicvkrqtweqqqxxvfsllkprrxttbffassrhuixqvaaalwwuynmtrqwipjqwyfagsroi                                                               xxxxxxxxxxxvxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxaxxxxxtxxxxxxxxx xxrxxxxxxxxxxxxxxxxxxxxxxyxxxxxxxncadahjqynooxfajcgfaqtuuuuuoprpxgdqqvidfhvvtyuarquncanktiibrrahkkqwqnonrkvwuuxrrrrweiuyxfaqpvm                                                               xxxxxxxxxxxxxoxxxxxxtxxxxxxxxxxxxxxxxfxeexxxxxxxxxxxxxxxxxxfxxx xxxxxxxxaxxxxxlxxxxxxxxxxxxxxxgxxwuivckkhkgrsmnffafdrynorryofrotfassdjtfksidypyhkvvfkpabrrkrpskpasypdfrkeftwnpfatqsdhjufdmpadrw                                                             ";
            //LETTER1 = LETTER1 + "  xxnxxxtxxxxxxlxaxxxxxxnxxxxxxxxxxxxxxxxxoxxxxxlxxxxxxxxxxxxxxxx xxxxxxxxxxxrrrrrrrrrorrrrlyhlrrlmqnifjrlrryufrkjeukaggassrtuuiyrjnxoigsqyyyirapfwvsoiaqfqadlwcreoissudttttqyigsjqpaagsgddddtwww                                                               lplllllllllllllllllllllllllmllllllllgduguuuuuueuuuuuvuuuiuuuuuu uuuuuuunnndnnnjsvnnnnnfwqmvwnpnmnuuoivlgkwbalqynipweqyoxouiiygljjyyrbwuopbibrqyogggiqgsdfjwqiuwyrgafhqwuuvbmwkwigsdqqyuisuddktp                                                               kpnnnnnnsnnroffwhlffffffddmdddgddddddddddddbbbbbbbbbbbbbbbbabbb bbbbutbbbbbbbbbbbbbbbftbbbbbbbinbbdrbsortibahhyorhhqsdfkmyipvbnckqwynnxhrtyixyyyiqtrlrlwwixyajllqtcpaicxvygdjckkkfngfdehqyiajni                                                               uygvyeepweeeeeekeeeeeeeeeeeehedeemeeeeeeheeeeeeeeeqeefebmeeleev eeeeeeeeeeedeeemeweeeeeeeeeeeeeeeyaayynaqaqtcqqajmeqtgsssfoinvqtujpvvuuwaasjqqsbhsyyoyxoteipppshxjqqvxdarhatiyvagnrltnujjkqqwyr                                             ";
            //LETTER1 = LETTER1 + "                  eeeeeeeeeaeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeyeeeeeeeheeeeeef meeeeeeeeeeeeeeeeeeeeeeeendeeeeedaaseyyyrgalliipbycartyvxaaaaashhttwkkqvvxrevddflcgrenuikqmvcvfwinrwaeuiarrdrrwvsqnrbakqqiwsqup                                                               eeweeeeeeyeexaeaananttwtttggfggfqtvwwwawwttttwwwttntttttttttttt tttttttttttttttttttttttttttttttttrirrqxeipgvvvvjhurnoykaaaakwikkrmngrrttiisitthluuryuderkqopkikefdmbswikwdryifasdteeerdfdfrrngl                                                               ttttaumbnaaaaaaaaaaaamaaaaaaaaaaaaaqaaaaaaaaaaaaaaaaaaaaaaataaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabakeuhauwnntwtcsissrurhwkbrfaagwuynfihidrrourqwaaaafsluiyjiaasdgauiiiasdhlmeyyppcfmtwyddkrtyiiyr                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaahaaaaaaaaaaaaaaaaaanidrqqtttwyflqquikiylmquskeufaxrsqynshtwaaramwpaaenpqwudgaarwpiglrwqiajrnxyygptrrgfluifajmtnci                             ";
            //LETTER1 = LETTER1 + "                                  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbhfflassrwuuducroufasdipvqomiyfrkyqrxartwwvfwyvvxrwjaaaagoipxprcmajwbvdeitplbagquiaxriaeqppdc                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaawackfrcrvgqiswadqqixwkqtjgasmmopubrmeuiyxfwuijhiisrtoaquikvxdmjtwfrtnipydjkwtivxpipvajnifttttx                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaagaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaidtecjrqyiynnfdrjwwqpyktwncvaffasgrrrrjkktwwtqqynppynrupdrweuuassgrlhwinnmyyajjlltvnsssgdjjyoi                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaavndryejsrfcdyihtkhkeyduoarkltnxgdfklwwqnswwwupyyrtrkaswggswuipyvsatkbbxmdmtubbbrtaskxgfqrfwpvf             ";
            //LETTER1 = LETTER1 + "                                                  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaagaaaaaaa aaaaaaaaaaaarvhhhhhhhhkuhghhahhihqrkkearcdsddifrwuifsuiyyftpdrkmifriieyowtifiriixasiibydtaeuusjkqrjkkwfkniungifltntertvhkmqmdko                                                               jjjjjjjjjjxjjjjjyjjfjjjjjjjjjjjwjjjjjjjjjjjjsjjjjfjjjjfejfjjwjj jjjjjjjjjdjajjjjjjjjjjjjjjjjjjtjjitwyyrtcsshmqmusrtxuwruthtpltwinfkqilrtejpvggnrreqbccserkrkjivgpgqgyigfvopdrjrnpvdeigysmtjyyyd                                                               fjajjsjjjfjjjjejjjjajjjjjgjjjgjjjjjjjjjqfjjjjjjjjjjjnjjjjjjyjjt jjjjjujjjjjjtjjfjffjjjscjffjjyoeymtqffslknyixaatwwnxfakllktwiynnbuijyuxktyukwwrjiptfariakqqiynfasgkxggrtrwwfdfjtqtnyaassddjkkqt                                                               jjfjjjjnjbaywfjjjnnjjfjajjjjjjjjjjgjjfjjujjjjjjjdjjjjjjjjfajjfg fjajljxjjjajhjjjjjjjjfjjjjasjtjdjttqteqnooiinsdynvfqitbcxhjafljmwqgddkrqtwqxdjttuixvjbgfeequpbbxsdqttyixupyskyaaswtqadfikkqi";
            //LETTER1 = LETTER1 + "pij                                                               ubjfjjuejtjyjjjjjfjjgxijaytttttttvttttttttttttttttppppppppppppy pppappppypppppppppppppdpyppppppppifsiktushjjafrraweypsrqniiynaaqruunnwtjeqniggggtsfsnvkqeqidcwwuskqtpxfdfhketyaswvyynvvxxlkpeyy                                                               yppxyppppppppppppppppqpppyppppprypnpvpypppppppppyppphrppjpppppp ppppyyppppppeppppypppbptpyopypppptuhxaaipftkttqyvcvgiyybndralkuaajmtiakgygkuoifgdjmtyuuoidrhtidfadddkuopycgmmtsrwuuibrwuusirevg                                                               ppfypnppppyppppppppppppppppppppppppppppppppppppppppppuppppppppp pgssssssssmcimfmttegnpnhqirifmfvgraepyvkeasiskbwjubdrokjeyigfarqwwyagktwexipvxsjwnncnarjkmwteqxuyyuunyuiyyyynnnxaalrubvkqipqvxb                                                               othmwakfuumpofhlatwuehumghgapfammqqrqqqqqquqdqqqqqqqqqdqqqqwqqx qqqqqyyyvyyyyyyyyyyyyyymyyyyyuyyyqasmyyxaaaajqyejxdjkrweuyykjkiiyccexwwndmmqqiiseddwtycxgiggshjwwwwqniibcvfg";
            //LETTER1 = LETTER1 + "mtpyngfadkjkmtwwqyi                                                               yyyyyyyyyyyyyyyyyyyyyyyyyytyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy dyyyyyyywyyyyyyyyyyyyyyyyyyyyyyyyippcccqipfffdrllklqixfadqbjxfkqrtenudfkqbcfasjueadvffppfgdkrltmeagooagjickktroogrmimtfnumrkisl                                                               yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyhyyyy yyayyyyyyyyyywyyyyyyyyyyyyyyyyyyyquhssktoyryppwphtqoigllmnashhuixsuuixiisdmmweubrjrifjliyvyrrrlfqayigafsdghqwsuyfrqbarhtqqngrgg                                                               yyyyyyyytyyyyyyyyyyyyyyyyyyyyyyyeyyjyyyyoyyyyyyyyyyyyyyyyyyyyyy yyyyayyyyyyyyyyyyyfyyfyyxyyyyyyyymuuyasfkjteeipxbfsgrwwfrhkkxxfrrgglmmrtttrquiipkkkqyxtetwwtmyiyxlevkqpncgsjrqyyetofrhkyasejmqt                                                               yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyykyyyyyyyyyuyyyyyyyyyhawyyyyyyyyt yyyxuyywtwyyyyyyyyyyyyyyyyyyyyyyywipcrrrfdlrmtsyuuruusqwgbxyurrhhgaskuoiuuuuiibhwoibtipdskpx";
            //LETTER1 = LETTER1 + "uxqfdrtkyypybxqtksjluujdwswwwy                                                                    twwwwwwewwwwwmmwgagbmbbbggguggggggggghgggegggfggggggeeeeeeeeeee eeeeeeeeeeeeeeeemfcqmaammmwwmwxgrfgggagggbggghjtxttqrqttvttiybenhfgffdddddddddaaaaaafhjqqcdmmgdopasdwatmmwwwwwwwwwwwwwwwwwwwwww                                                               fhamhgkcmlwmmxmmmqlfmwmmmusmhmyhmhmhmppmmmhhsfmmihmyafmmmmpmrfh mvmmhwhgmmfemhmmpamajmmfgmyhmtdmmwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwttwniuuuqqqqqmmyuyuyyyyyyyyuuuu                                                               mymuahlqmdmhmuhcmmmyfffffffffffffffffffffffffffffffffffffffffff fffffffffffffffkkkkkkkkkkkkkkkkkkupppyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyybbbbbbbbbbbbbbbbbbbbbfayyqygguo                                                               kkkkkkkkkkkkkkkkkkkwkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk kkkkkkkkkklkkkkkkkkkkkkkkkkkkkkkkqcggrwqqpgktqeroasgautubfdqqdqvylbjlvohpbiq";
            //LETTER1 = LETTER1 + "ccccwgwygyhffffffffffffffffffffffffffffffffffffffff                                                               kydkkkkkkkkknkkakkkkkkkkkktkkktkkakkkkkkkkkkttttttttttttttttttt tttttttlllpllllllllllllllllllllglffffffffffffffffffaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                                                               lllllllclllulllllllllllllllllallllllflmlllllllllllllllllillllll llflldlslllllllllllllllllllwllfllaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                                                               llllllllllllllllllllllllwlglxllllllllctugebuuhueuumskegevftmffb ntgegdydgkhnajyqpflmdspggqfthsrgcaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaydddyendddddrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr                                                               yglilwsdaccrmwyhjffajdunujhypkmfnfqvblrnfucxuucgghtknafsnckkdta lywfttttqlgsnmfvqfywrpfgodqnglffdrrrrrrrrrrrrraaaqkkkkkkkkkk";
            //LETTER1 = LETTER1 + "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkqqqtqvttlqqvyuuxntipkquwtxtcdntqiamnuwnqadrqclundtojqqqqpdpcnitywfrttftytdgkggyggfwmqggmbusvtuxhqhnnafwtpwwxxvyptdygqtwxkyyaeyqngfqjqtwkvqueuqouhokwmayffydaaqtakkukkkkkkkkkkkkkkkkukkikkkikkkkkkkkqkkkspkkkkxkdkkkvkkkkkkkkkkkkskkkkkkkkqkklllllllllllmmmvmmmoqjjjgddbggpbqfyjdhshhbsjqghfqqqqsqpesqqccbqhtvjqgrhgtcktgqphtqmtgswsssssssssssfssssssssssssssssstssssslssotsusjsssdussssssssyqssssswsssspttfqqqqqqqqqcqqgqwqqqqmmmmmmmmmmmmmgnmymmmmmwmmmmmmmmmmmmmmmmmmmmmmmgmmmmmmmmmummutltttttfttttteqqrqqqqqqqqqqqbqqqqqqqaqfadmqnbsdmqvqshqcdxfuhklgqqfutcevqqvqmqqqfqqrftdkqqgubsashqqqqqqqqqqqqqqqqgqqqqqqqqqqqququqqquqqqqqqqqcwqmqqqqqqqqqqoqqqqqcqqqqqqqqhqqqqqqqkqqxqqqqqqcqqqqqqqqqqqqbqqnqqqqqqqqqqqqjqqtqqqqqqqqqgqqqqqqqqqqyyyyyyysyqyqyyyyyncvnnnndnndtncnninnnnnnunnnngnnqstbqwvfqtyoqiqidmqqqfagummgrfgkgtkfgggexxplfqdjsxjqqmqnjdtqqoeqqqqqbqmqcqqqqqqqqiqqqmqqqqusqqqqqqqdqqqqqqqquqqqqrfqjqqqqqqpqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqnnannnnnnnn";
            //LETTER1 = LETTER1 + "ndjnsnqnnmnnnqnnnnnftnngbuuuuuuuuuuuuuuuuquuuuuuunniiiseiiiuiqtiiiibiiiiiqiiiiiiiiieqsjqqqesqccqfjftqtjoqfuuuwcqqwbcfifqxyyjijrjijqjqfjhwqujgwgquahjqqqqqqffqrqqqaqnqquqqqqqqqqfuqquqomqqqriqqqqqqwqqqqqqqqqfqqqqdqqtrqqyqqyqqqqqquqaqcqqqqqiqtqqqqqiiiiiiiiiiiiiiqiiiiiiiituiiqiiiiqiiigjgiyiiiiiiiiiiiiiiiiiiiiiiiiquiqiiigiiiqtifiiiiibiiiiiqityqqyktkgsuaiqqfitwwjqfyqvmbvkfqtqdhqnycqvfqqqclgutlpkqqyddqjqgqqgqqqqquqqqgqaqqfqqyqqqqqqqqtqhqqqqppqqqqquhwqqeqqqqaqqaqqqqqdaqdixqqqjqqqqqqqwqrqqqqsqbqxqqvqqtiifiiiimqiciiisgqpmxppyppppppvayeatmttgfggqtcgfiqcftmvasunqyjqjohqepvcqxxnnscmnnvvvxthxhvtvvvqmhsqqqkququwwuubgsqcnqsdqknqqodwqptqyqyybqqcqcveququqqqumqwawdhqqqquqqqtqqqgqqqqtqqqqqqrcqqcpqqqqaqqqqqqqqqqmqtqxqiqqovwqhqqqqftqqqqqqqqdjqsqqqqpqqqqqqqqnqqqqqqdvqvvvcvvuvvvyuvtvvvviqvsltqjcuvqvvcyvvtvbfvvvqvvvvqlvvdqlvuoooccxccvccqctcxccbcqccqqcscxxxdxojlkfqtfusdgsyfqfpqejdqqgpgsqskrrxdqmmdqdfmggkddqoblhyqcyqsoeukswqqxqqqqfqfqqqqqfhqhqqqbflymqqqqqiqqmqcmqqqqqqqqmgqsqeubuqqqqquubqjqamqqseqhqqaqqqqqsqqqqqqq";
            //LETTER1 = LETTER1 + "blgqqxxxqxcxtsuckctxxqxyxyxxqxxxexxxyxqyxxtxxtqxcqxxuxxxlxfxxaxxqdvvjogdgcjtyjggdcaggggsqqngggprgrguuoijfedqtafqaatjjqpffpyoyydgoexpkheqdggggaaqshintjqqnunhuttjkhqqqqqmqyqteauqqqeqqhqcqtqfflqheqqqsqaqejdqqtqqjgquuqqqqqqyhytbjhqqqrqqfqqeqqbqkoqbqqpqqqvqdqqqqqaaahgggkjgpugpfgggdgqmgwjffsbsqycsussdjduqcdsqssqusjsssssseuausnnnssssmsscqycjmsrushsrtsshhstlsqqrqtchihtbcqqtqksfkrgfrpjrrrajyqccqqdqydcrqyyudtamgtqyqpddaqhtqqcqeqqjqqqsupodkumasauubyuadtuqqwcuuuwawuuqujuqulafugffaaptajutqaauutuujufjqtuuuobuuccguuufluuquqdqvhujhshsfcclqtjuqdquslssusssdptuqssstlpwsqnqsbgcejcsskscsbnquvpfgggejhtqgxaueblllqcllldclelmccqquyqftmdquiqiiqtfqtkeqbujqcqqqqogttjmdqwncycqqtqqqtaqedbbbtvqqtunungqqqqwouqvvuecpatuuuqfqhumbbbbbbqlqesbbwccdfcbkdqxjmbmcxbpqbdqcbbucbqmbjqmcbbbbvbqbbbvbhaklmoggwihudqkqqdqaacukqmqeqjsjjjhqtqjqafbjjjqqqyjkanjjjjqcgqmrhuemcfqrusqajwucqjummptddgagllxfqdpthjwdqwhqpbqircqglajfvqttdqqqmgftvstcqpanqqgqlbtttrmocleqqqfqqcbcbbscddbbqvckckebbyeanubbebroawanqffomvwutqiqqjyvqbqfqwwqqqfcqyyvfwftedh";
            //LETTER1 = LETTER1 + "hdqgfgaftfffuacfftftfcpqqowtsjqqwfurjqrrvrfqncctepevplqufmedqlcprpokmewetequueuuujekejajqsfeyeexquuuxxqqejqkteeimmtctawhahhtkuqtactcqcqdweddqwqmthdnegrrcdosjqoxquoqdqamaiirwqqpcscqfqdajghhfudfltyufaylddqalhullwvdvhdodsddhgdccjdcacamdmojumqsucutaqqeaeaapxchkeaeqdoqqqyaopdalaahsghqahwqtqttymhnumujyoqyulaquqqvtjougcfuhcqcfohfhhsjqwunmomuaohyhhxxuxqqyqypjqcpqpupqqcjpqqljvuvtvfqmpjqqmqcqqqhuphyhvqqcwcjgtpprcwqcqcwssaqptaqqpfifqjfcekdqlqwwvtchhqnnuquotflqmcttthhlqqqlqqttdququujyhuqyqqciqymmlcqjcqyqctqrdqfpyytqltcdlpplqqtdgcfxtrkckoseruutqkctbqffftqttvktctcddsctcqcqrrqttukqyuqctfcydmmqqwctqpqhtuhfqhfdqeeqvyqhtdthhcccdgqqoqqychqqkpqquq";


            //char[] c = thisletter.ToCharArray();
            //for (int i = 0; i < c.Length; i++)
            //{

            //    byte[] sarr = System.Text.Encoding.Default.GetBytes(c[i].ToString());
            //    if ((int)sarr[0] > 128)
            //    {
            //        int QW = 254 * ((int)sarr[0] - 129) + (int)sarr[1] - 64 + 1;
            //        if (QW < 1)
            //        {
            //            pystring += "?";
            //        }
            //        else
            //        {
            //            if (QW > LETTER1.Length)
            //            {
            //                pystring += "?";
            //            }
            //            else
            //            {
            //                pystring += LETTER1.Substring(QW - 1, 1);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        pystring += c[i].ToString();
            //    }
            //}
            //return pystring;
            #endregion

            SpellAndWbCode sw = new SpellAndWbCode();
            return sw.GetWBCode(inputstring);
        }

        /// <summary>
        /// 获取拼音码
        /// </summary>
        /// <param name="cn">字符串</param>
        /// <returns></returns>
        public static string getSpell(string cn)
        {
            return Class_Font_Spell_First.GetChineseSpell(cn);
        }

        /// <summary> 
        /// 转全角的函数(SBC case) 
        /// </summary> 
        /// <param name="input">任意字符串</param> 
        /// <returns>全角字符串</returns> 
        public static string ToSBC(string input)
        {
            return Strings.StrConv(input, VbStrConv.Wide, 0);
        }

        /// <summary>
        /// 根据Code查询T_HOSPITAL_CONFIG中的Value值
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetHospitalConfig(string code)
        {
            return App.ReadSqlVal("select t.value from T_HOSPITAL_CONFIG t where t.code='" + code + "'", 0, "value");
        }

        /// <summary> 
        /// 转半角的函数(DBC case) 
        /// </summary> 
        /// <param name="input">任意字符串</param> 
        /// <returns>半角字符串</returns>    
        public static string ToDBC(string input)
        {
            return Strings.StrConv(input, VbStrConv.Narrow, 0);
        }

        /// <summary>
        /// 判断当前值是否是数值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool isNumval(string val)
        {
            try
            {
                decimal.Parse(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否含有数字
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool isHaveNumval(string val)
        {
            try
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (isNumval(val.Substring(i, 1)))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 节点的上移
        /// </summary>
        /// <param name="ObjNode">选中节点</param>
        /// <param name="trvTypedCategory">树控件</param>
        public static void TrvNodeMovUp(TreeNode ObjNode, TreeView trvTypedCategory)
        {
            //----节点的向上移动   
            if (ObjNode != null)
            {
                TreeNode newnode = new TreeNode();
                //--------如果选中节点为最顶节点   
                if (ObjNode.Index == 0)
                {
                    //-------------   
                }
                else if (ObjNode.Index != 0)
                {
                    newnode = (TreeNode)ObjNode.Clone();
                    //-------------若选中节点为根节点   
                    if (ObjNode.Level == 0)
                    {
                        trvTypedCategory.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
                    }
                    //-------------若选中节点并非根节点   
                    else if (ObjNode.Level != 0)
                    {
                        ObjNode.Parent.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
                    }
                    ObjNode.Remove();
                    ObjNode = newnode;
                    trvTypedCategory.SelectedNode = ObjNode;
                }
            }
        }

        /// <summary>
        /// 节点的下移
        /// </summary>
        /// <param name="ObjNode">树节点</param>
        /// <param name="trvTypedCategory">树控件</param>
        public static void TrvNodeMovDown(TreeNode ObjNode, TreeView trvTypedCategory)
        {
            //----节点的向下移动   
            if (ObjNode != null)
            {
                TreeNode newnode = new TreeNode();
                //-------------如果选中的是根节点   
                if (ObjNode.Level == 0)
                {
                    //---------如果选中节点为最底节点   
                    if (ObjNode.Index == trvTypedCategory.Nodes.Count - 1)
                    {
                        //---------------   
                    }
                    //---------如果选中的不是最底的节点   
                    else
                    {
                        newnode = (TreeNode)ObjNode.Clone();
                        trvTypedCategory.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
                        ObjNode.Remove();
                        ObjNode = newnode;

                    }
                }
                //-------------如果选中节点不是根节点   
                else if (ObjNode.Level != 0)
                {
                    //---------如果选中最底的节点   
                    if (ObjNode.Index == ObjNode.Parent.Nodes.Count - 1)
                    {
                        //-----------   
                    }
                    //---------如果选中的不是最低的节点   
                    else
                    {
                        newnode = (TreeNode)ObjNode.Clone();
                        ObjNode.Parent.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
                        ObjNode.Remove();
                        ObjNode = newnode;
                    }
                }
                trvTypedCategory.SelectedNode = ObjNode;
            }
        }

        ///// <summary>
        ///// 节点的上移
        ///// </summary>
        ///// <param name="ObjNode">选中节点</param>
        ///// <param name="trvTypedCategory">树控件</param>
        //public static void TrvNodeMovUp(Node ObjNode, DevComponents.AdvTree.AdvTree trvTypedCategory)
        //{
        //    //----节点的向上移动   
        //    if (ObjNode != null)
        //    {
        //        Node newnode = new Node();
        //        //--------如果选中节点为最顶节点   
        //        if (ObjNode.Index == 0)
        //        {
        //            //-------------   
        //        }
        //        else if (ObjNode. != 0)
        //        {
        //            newnode = (Node)ObjNode.Clone();
        //            //-------------若选中节点为根节点   
        //            if (ObjNode.Level == 0)
        //            {
        //                trvTypedCategory.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
        //            }
        //            //-------------若选中节点并非根节点   
        //            else if (ObjNode.Level != 0)
        //            {
        //                ObjNode.Parent.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
        //            }
        //            ObjNode.Remove();
        //            ObjNode = newnode;
        //            trvTypedCategory.SelectedNode = ObjNode;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 节点的下移
        ///// </summary>
        ///// <param name="ObjNode">树节点</param>
        ///// <param name="trvTypedCategory">树控件</param>
        //public static void TrvNodeMovDown(TreeNode ObjNode, DevComponents.AdvTree.AdvTree trvTypedCategory)
        //{
        //    //----节点的向下移动   
        //    if (ObjNode != null)
        //    {
        //        TreeNode newnode = new TreeNode();
        //        //-------------如果选中的是根节点   
        //        if (ObjNode.Level == 0)
        //        {
        //            //---------如果选中节点为最底节点   
        //            if (ObjNode.Index == trvTypedCategory.Nodes.Count - 1)
        //            {
        //                //---------------   
        //            }
        //            //---------如果选中的不是最底的节点   
        //            else
        //            {
        //                newnode = (TreeNode)ObjNode.Clone();
        //                trvTypedCategory.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
        //                ObjNode.Remove();
        //                ObjNode = newnode;

        //            }
        //        }
        //        //-------------如果选中节点不是根节点   
        //        else if (ObjNode.Level != 0)
        //        {
        //            //---------如果选中最底的节点   
        //            if (ObjNode.Index == ObjNode.Parent.Nodes.Count - 1)
        //            {
        //                //-----------   
        //            }
        //            //---------如果选中的不是最低的节点   
        //            else
        //            {
        //                newnode = (TreeNode)ObjNode.Clone();
        //                ObjNode.Parent.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
        //                ObjNode.Remove();
        //                ObjNode = newnode;
        //            }
        //        }
        //        trvTypedCategory.SelectedNode = ObjNode;
        //    }
        //}

        /// <summary>
        /// 移除ListView当中选中的节点
        /// </summary>
        /// <param name="trv">树控件</param>
        public static void RemoveSelectNodes(ListView lv)
        {
            for (int i = 0; i < lv.Items.Count; i++)
            {
                if (lv.Items[i].Checked)
                {
                    lv.Items.Remove(lv.Items[i]);
                    RemoveSelectNodes(lv);
                    break;
                }
            }
        }

        /// <summary>
        /// 移除树当中选中的节点
        /// </summary>
        /// <param name="trv">树控件</param>
        public static void RemoveSelectNodes(TreeView trv)
        {
            for (int i = 0; i < trv.Nodes.Count; i++)
            {
                if (trv.Nodes[i].Checked)
                {
                    trv.Nodes.Remove(trv.Nodes[i]);
                    RemoveSelectNodes(trv);
                    break;
                }
            }
        }

        /// <summary>
        /// 获取本机IP
        /// </summary>
        /// <returns></returns>
        public static string GetHostIp()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr;
                for (int i = 0; i < ipHost.AddressList.Length; i++)
                {
                    if (IPAddressCheck(ipHost.AddressList[i].ToString()))
                    {
                        ipAddr = ipHost.AddressList[i];
                        return ipAddr.ToString();
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
        /// 向服务器发送消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="Currentip">本机Ip</param>
        public static void SendMessage(string msg, string Currentip)
        {           
                Operater.sendmymsg(msg, Currentip);
           
        }

        /// <summary>
        /// 获取服务器端触发消息
        /// </summary>                         
        private static void GetServerOpersXml()
        {
            //do
            //{
            //    try
            //    {
            //        if (WebService == null)
            //        {
            //            WebService = new Bifrost.WebReference.Service();
            //            string webip = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite1/Service.asmx";
            //            WebService.Url = webip;
            //        }
            //        ServiceOpersXml = WebService.GetAllCurrentOpersXml();
            //        Thread.Sleep(10000);
            //    }
            //    catch
            //    { }
            //}
            //while (1 != 0);
        }


        /// <summary>
        /// 向服务器发送消息
        /// </summary>
        /// <param name="TargetSectionID"></param>
        /// <param name="content"></param>       
        public static void SenderMessage(string TargetSectionID, string content)
        {
            string SenderIp = App.GetHostIp();
            if (linkFormat == "0")
            {
                Operater.SenderCurrentOpersXml(SenderIp, TargetSectionID, content);
            }
            else
            {
                //WebService.sendmymsg(msg, Currentip);
            }
        }



        /// <summary>
        /// 获取转科等操作消息
        /// </summary>
        /// <returns></returns>
        public static string getMesContent(string[] SectionIds)
        {
            try
            {
                XmlNodeList nodeslist;       //玩家集合信息
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.LoadXml(ServiceOpersXml);//Operater.GetAllCurrentOpersXml()
                nodeslist = XmlDoc.SelectSingleNode("Users").ChildNodes;
                for (int i = 0; i < nodeslist.Count; i++)
                {
                    if (nodeslist[i].Attributes["opflag"].Value == "0")
                    {
                        for (int j = 0; j < SectionIds.Length; j++)
                        {
                            if (nodeslist[i].Attributes["TargetSectionId"].Value == SectionIds[j])
                            {
                                return nodeslist[i].Attributes["content"].Value;
                            }
                        }
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
        /// 入院登记操作消息
        /// </summary>
        /// <param name="said">病区消息</param>
        /// <returns></returns>
        public static string getMesSarContent(string said)
        {
            try
            {
                XmlNodeList nodeslist;       //玩家集合信息
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.LoadXml(ServiceOpersXml);  //Operater.GetAllCurrentOpersXml()
                nodeslist = XmlDoc.SelectSingleNode("Users").ChildNodes;
                for (int i = 0; i < nodeslist.Count; i++)
                {
                    if (nodeslist[i].Attributes["opflag"].Value == "0")
                    {
                        for (int j = 0; j < nodeslist[i].Attributes.Count; j++)
                        {
                            if (nodeslist[i].Attributes[i].Name == "Area")
                            {
                                if (nodeslist[i].Attributes["Area"].Value == said)
                                {
                                    return nodeslist[i].Attributes["content"].Value;
                                }
                            }
                        }
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
        /// 设置临时消息
        /// </summary>
        /// <param name="Content"></param>
        public static void AddTempUserMsg(string Content)
        {
            try
            {
                XmlNodeList nodeslist;       //玩家集合信息
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "\\UsersTemp.xml");
                nodeslist = doc.SelectSingleNode("Users").ChildNodes;
                bool flag = false;
                for (int i = 0; i < nodeslist.Count; i++)
                {
                    if (nodeslist[i].Attributes["content"].Value.Trim() == Content.Trim())
                    {
                        flag = true;
                        return;
                    }
                }
                if (!flag)
                {
                    XmlElement xe1 = doc.CreateElement("User");
                    xe1.SetAttribute("content", Content);
                    doc.SelectSingleNode("Users").AppendChild(xe1);
                    doc.Save("UsersTemp.xml");
                }
                if (doc.SelectSingleNode("Users").ChildNodes.Count > 20)
                {
                    doc.SelectSingleNode("Users").RemoveChild(doc.SelectSingleNode("Users").ChildNodes[0]);
                }
            }
            catch
            { }
        }


        /// <summary>
        /// 判断是否已经读过相关内容
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static bool IsReceiceMsg(string Content)
        {
            try
            {
                XmlNodeList nodeslist;       //玩家集合信息
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(Application.StartupPath + "\\UsersTemp.xml");
                nodeslist = XmlDoc.SelectSingleNode("Users").ChildNodes;
                for (int i = 0; i < nodeslist.Count; i++)
                {
                    if (nodeslist[i].Attributes["content"].Value.Trim() == Content.Trim())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 主窗体消息栏中的消息
        /// </summary>
        /// <param name="val">参数</param>
        public static void SetMainFrmMsgToolBarText(string val)
        {
            if (ParentForm != null)
            {
                for (int i = 0; i < ParentForm.Controls.Count; i++)
                {
                    if (ParentForm.Controls[i].GetType().ToString().Contains("DevComponents.DotNetBar.Bar"))
                    {
                        Bar temp = (Bar)ParentForm.Controls[i];
                        if (SetMainFrmMsgToolText(val, temp.Items))
                            temp.Refresh();
                        return;
                    }
                    //if (ParentForm.Controls[i].Controls.Count > 0)
                    //{
                    //    SetMainFrmMsgToolBarText(val);
                    //}
                }
            }
        }

        /// <summary>
        /// 根据权限判断按钮是否可用判断按钮
        /// </summary>
        /// <param name="btnPermission">按钮权限集合</param>
        /// <param name="Control">工具栏主控件</param>
        public static void BtnEnableSet(Class_Permission[] btnPermission, ToolStrip Control)
        {
            if (btnPermission != null)
            {
                for (int j = 0; j < Control.Items.Count; j++)
                {
                    bool Enableflag = false;
                    for (int i = 0; i < btnPermission.Length; i++)
                    {
                        if (btnPermission[i].Perm_code == Control.Items[j].Name)
                        {
                            Enableflag = true;
                        }
                    }
                    if (Enableflag)
                    {
                        Control.Items[j].Enabled = true;
                    }
                }
            }
        }


        /// <summary>
        /// 判断是否是有效的Ip地址 true有效 false无效
        /// </summary>
        /// <param name="addressString">IP地址</param>
        /// <returns></returns>
        public static bool IPAddressCheck(string addressString)
        {
            try
            {
                string webServerAddress;
                Regex r = new Regex(@"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");//IP地址的正则表达式
                Match m;
                webServerAddress = addressString;
                webServerAddress = webServerAddress.Trim();
                m = r.Match(webServerAddress);
                if (m.Success)   //进一步判断IP地址的合法性
                {
                    char[] charArray = new char[] { '.' };
                    string[] stringArray;
                    int j = 0;
                    stringArray = webServerAddress.Split(charArray);
                    for (int i = 0; i < stringArray.Length; i++)
                    {
                        if (int.Parse(stringArray[i]) <= 255)
                            j++;
                        else
                            break;
                    }
                    if (j == 4)
                        return true;// 满足IP地址格式的要求
                    else
                        return false;//非法地址
                }

                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 快码查询
        /// </summary>
        /// <param name="Sql">查询语句</param>
        /// <param name="trlTepm">当前控件</param>
        /// <param name="Sel_Name"></param>
        /// <param name="Sel_Val"></param>     
        public static void FastCodeCheck(string Sql, Control trlTepm, string Sel_Name, string Sel_Val)
        {

            if (!App.CheckChineseEncode(trlTepm.Text) && !App.isHaveNumval(trlTepm.Text))
            {
                uccodeselect.IniucCodeSelect(Sql, trlTepm, Sel_Name, Sel_Val);
                trlTepm.Focus();
            }
        }

        ///<summary>
        /// 快码查询
        /// 病案编目
        /// 适用于所有表格编辑弹窗
        /// </summary>
        /// <param name="Sql">查询语句</param>
        /// <param name="trlTepm">当前控件</param>
        /// <param name="Sel_Name"></param>
        /// <param name="Sel_Val"></param>     
        public static void FastCodeCheck(string Sql, Control trlTepm, string Sel_Name, string Sel_Val, string BABM)
        {
            uccodeselect.IniucCodeSelect(Sql, trlTepm, Sel_Name, Sel_Val, BABM);
            trlTepm.Focus();
        }


        /// <summary>
        /// 聚焦快码查询界面
        /// </summary>
        public static void SelectFastCodeCheck()
        {
            if (uccodeselect != null)
            {
                uccodeselect.Fg_Focus();
            }
        }

        /// <summary>
        /// 关闭快码查询界面
        /// </summary>
        public static void HideFastCodeCheck()
        {
            if (uccodeselect != null)
            {
                uccodeselect.Hide();
            }
        }

        /// <summary>
        /// 截取时间串
        /// </summary>
        /// <param name="strval">字符串</param>
        /// <returns></returns>
        public static string GetTimeString(string strval)
        {
            int right = 0;
            string timestr = "";

            string val = ToDBC(strval);

            //2011-2-16 8:23 类型
            if (val.Contains(":"))
            {
                for (int i = 0; i < val.Split(':')[1].TrimStart().Length; i++)
                {
                    try
                    {
                        DateTime dt = Convert.ToDateTime(val.Split(':')[0].TrimStart() + ":" + val.Split(':')[1].Substring(0, i + 1));
                        right++;
                    }
                    catch
                    {

                    }
                    if (right == 2)
                    {
                        timestr = val.Split(':')[0].TrimStart() + ":" + val.Split(':')[1].Substring(0, i + 1);
                        return timestr;
                    }
                }
            }
            else
            {
                //2011-2-16 类型
                //bool flag = false;
                timestr = strval.Split(' ')[0];
                //for (int i = 0; i < timestr.Length; i++)
                //{

                //    string str=""; 
                //    try
                //    {
                //        str = str + timestr[i];
                //        Convert.ToDateTime(str);
                //        flag = true;
                //    }
                //    catch
                //    {
                //        flag = false;
                //    }
                //    if (flag)
                //        return str;
                //}

            }

            return timestr;
        }

        /// <summary>
        /// 获取年龄时间 
        /// </summary>
        /// <param name="birthday">出生日期</param>
        /// <param name="In_Time">入院时间</param>
        /// <param name="unitflag">是否显示单位 true显示 false 不显示</param>
        /// <returns></returns>
        public static string GetTheAgeTime(DateTime birthday, DateTime In_Time, bool unitflag)
        {
            try
            {
                int year = 0;
                int month = 0;
                int day = 0;
                //int day, month, year;
                //生日的年，月，日
                int birthdayYear = birthday.Year;
                int birthdayMonth = birthday.Month;
                int birthdayDay = birthday.Day;
                //当前时间的年,月,日
                int nowYear = In_Time.Year;
                int nowMonth = In_Time.Month;
                int nowDay = In_Time.Day;

                //得到天
                if (nowDay >= birthdayDay)
                {
                    day = nowDay - birthdayDay;
                }
                else
                {
                    nowMonth -= 1;
                    day = GetDay(nowMonth, nowYear) + nowDay - birthdayDay;
                }

                //得到月
                if (nowMonth >= birthdayMonth)
                {
                    month = nowMonth - birthdayMonth;
                }
                else
                {
                    nowYear -= 1;
                    month = 12 + nowMonth - birthdayMonth;
                }
                //得到年
                year = nowYear - birthdayYear;
                if (year == 0)
                {
                    if (month == 0)
                    {
                        if (day > 0)
                        {
                            if (unitflag)
                                return day.ToString() + @"/30月";
                            else
                                return day.ToString() + @"/30";
                        }
                    }
                    else
                    {
                        if (day > 0)
                        {
                            if (unitflag)
                                return month.ToString() + " " + day.ToString() + @"/30月";
                            else
                                return month.ToString() + " " + day.ToString() + @"/30";
                        }
                        else
                        {
                            if (unitflag)
                                return month.ToString() + "月";
                            else
                                return month.ToString();
                        }
                    }
                }
                else
                {
                    if (unitflag)
                        return year.ToString() + "岁";
                    else
                        return year.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 用于刷新Grid方法（一次表刷新）
        /// </summary>
        /// <param name="flgView">表格控件</param>
        /// <param name="items">对象数组</param>
        /// <param name="colInfos">显示列数组</param>
        /// <param name="rowflexnum">表头所占的行数</param>
        public static void ArrayToGrid(C1.Win.C1FlexGrid.C1FlexGrid flgView, object[] items, ColumnInfo[] colInfos, int rowflexnum)
        {
            try
            {
                flgView.Cols.Count = colInfos.Length;
                flgView.Rows.Count = items.Length + rowflexnum;

                DataTable tb = new DataTable();
                //tb=ArrayToTable.Convert(items);

                tb = ObjectArrayToDataSet(items).Tables[0]; ;

                //帮定列名
                for (int i = 0; i < colInfos.Length; i++)
                {
                    if (colInfos[i].Name != null)
                        flgView[0, i] = colInfos[i].Name;
                }
                //表格数据绑定
                for (int row = 0; row < tb.Rows.Count; row++)
                {

                    for (int col = 0; col < colInfos.Length; col++)
                    {
                        for (int tabcol = 0; tabcol < tb.Columns.Count; tabcol++)
                        {
                            if (colInfos[col].Field != null)
                            {
                                if (tb.Columns[tabcol].ColumnName.ToLower().Trim() == colInfos[col].Field.ToLower().Trim())
                                {
                                    flgView[row + rowflexnum, col] = tb.Rows[row][col].ToString();
                                }
                            }
                        }
                    }
                }

                //隐藏列
                for (int i = 0; i < colInfos.Length; i++)
                {
                    for (int j = 0; j < flgView.Cols.Count; j++)
                    {
                        if (colInfos[i].Name != null)
                        {
                            if (colInfos[i].Name.Trim().ToLower() == flgView.Cols[j].Caption.Trim().ToLower())
                            {
                                flgView.Cols[j].Visible = colInfos[i].visible;

                            }
                        }
                    }
                }

                flgView.AutoSizeCols();
            }
            catch (Exception ex)
            {
                MsgErr("表格刷新失败，具体原因:" + ex.ToString());
            }

        }

        /// <summary>
        /// 将对象数组转换为数据集
        /// </summary>
        /// <param name="objArr">对象集合</param>
        /// <returns></returns>
        public static DataSet ObjectArrayToDataSet(object[] objArr)
        {
            if (objArr.Length == 0)
                return null;
            DataSet ds = CreateDataSet(objArr[0].GetType());
            ds = FillDataSet(ds, objArr);
            return ds;
        }

        /// <summary>
        /// 根据用户主键返回用户的的详细信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public static Class_User GetUserInfoById(string id)
        {
            DataSet ds = GetDataSet("select t.*,a.name as 职称,b.name as 职务 from t_userinfo t inner join t_data_code a on a.id=t.u_tech_post inner join t_data_code b on b.id=t.u_position where t.user_id=" + id + "");
            if (ds.Tables[0] != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Class_User userinfo = new Class_User();
                    userinfo.User_id = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                    userinfo.User_name = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                    userinfo.U_gender_code = ds.Tables[0].Rows[0]["Gender_Code"].ToString();
                    userinfo.Birth_date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Birthday"].ToString());
                    userinfo.U_tech_post = ds.Tables[0].Rows[0]["U_TECH_POST"].ToString();
                    userinfo.U_seniority = ds.Tables[0].Rows[0]["U_SENIORITY"].ToString();
                    userinfo.In_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["IN_TIME"].ToString());
                    userinfo.U_position = ds.Tables[0].Rows[0]["U_POSITION"].ToString();
                    userinfo.U_recipe_power = ds.Tables[0].Rows[0]["U_RECIPE_POWER"].ToString();
                    userinfo.Section_id = ds.Tables[0].Rows[0]["SECTION_ID"].ToString();
                    userinfo.Sickarea_id = ds.Tables[0].Rows[0]["SICKAREA_ID"].ToString();
                    userinfo.Phone = ds.Tables[0].Rows[0]["PHONE"].ToString();
                    userinfo.Mobile_phone = ds.Tables[0].Rows[0]["MOBILE_PHONE"].ToString();
                    userinfo.Email = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                    userinfo.Enable_flag = ds.Tables[0].Rows[0]["Enable"].ToString();
                    userinfo.Profession_card = ds.Tables[0].Rows[0]["PROFESSION_CARD"].ToString();
                    userinfo.Prof_card_name = ds.Tables[0].Rows[0]["PROF_CARD_NAME"].ToString();
                    userinfo.Pass_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["PASS_TIME"].ToString());
                    userinfo.Receive_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["RECEIVE_TIME"].ToString());
                    userinfo.Register_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["REGISTER_TIME"].ToString());
                    userinfo.U_tech_post_name = ds.Tables[0].Rows[0]["职称"].ToString();
                    userinfo.U_position_name = ds.Tables[0].Rows[0]["职务"].ToString();
                    return userinfo;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 主容器插入用户控件
        /// </summary>
        /// <param name="User_Control">用户自定义控件</param>
        /// <param name="Tab_Text">名称</param>
        public static void AddNewBusUcControl(Control User_Control, string Tab_Text)
        {
            TabControlPanel p_temp = new TabControlPanel();
            TabItem t_temp = new TabItem();
            t_temp.AttachedControl = p_temp;
            if (!Tab_Text.Equals("医生站") && !Tab_Text.Equals("护士站"))
            {
                t_temp.Click += new EventHandler(page_Click);
            }
            p_temp.Controls.Add(User_Control);
            t_temp.Text = Tab_Text;
            tabMain.Controls.Add(p_temp);
            tabMain.Tabs.Add(t_temp);
            p_temp.Dock = DockStyle.Fill;
            User_Control.Dock = DockStyle.Fill;
            tabMain.Refresh();
            tabMain.SelectedTab = t_temp;
        }


        /// <summary>
        /// 清空主容器
        /// </summary>
        public static void ClearBusUcControl()
        {
            tabMain.Tabs.Clear();
        }


        #region 系统级菜单的显示
        /// <summary>
        /// 功能设置菜单
        /// </summary>
        public void frmPerssionShow()
        {
            frmPermissionSet fm = new frmPermissionSet();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "功能设置菜单");
        }

        /// <summary>
        /// 角色权限设置
        /// </summary>
        public void frmRoleSetShow()
        {
            frmRoleSet fm = new frmRoleSet();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "角色权限设置");
        }

        /// <summary>
        /// 用户帐号设置
        /// </summary>
        public void frmAccountShow()
        {
            frmAccount fm = new frmAccount();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "用户帐号设置");
        }

        /// <summary>
        /// 用户操作日志查询
        /// </summary>
        public void frmOperaterLogShow()
        {

            Bifrost.SYSTEMSET.frmOperaterShow fm = new Bifrost.SYSTEMSET.frmOperaterShow();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "用户操作日志查询");
        }


        /// <summary>
        /// 设置帐号
        /// </summary>
        /// <param name="User">用户实体</param>
        public static void frmAccountSetByUser(Class_User User)
        {
            frmAccountSimpleSet fm = new frmAccountSimpleSet(User);
            App.FormStytleSet(fm, false);
            fm.ShowDialog();
        }

        /// <summary>
        /// 功能设置菜单
        /// </summary>
        public void frmDocRoleSetShow()
        {
            frmDocRoleSet fm = new frmDocRoleSet();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "功能设置菜单");
        }

        /// <summary>
        /// 显示当前登录客户端列表
        /// </summary>
        public void frmShowServerLinkList()
        {
            SYSTEMSET.frmShowServerLinks fr = new Bifrost.SYSTEMSET.frmShowServerLinks();
            App.UsControlStyle(fr);
            App.AddNewBusUcControl(fr, "显示当前登录客户端列表");
        }

        /// <summary>
        /// 显示角色有效时间设定
        /// </summary>
        public void frmShowRoleTimeSpan()
        {
            SYSTEMSET.frmDutyTimeSpanSet fr = new Bifrost.SYSTEMSET.frmDutyTimeSpanSet();
            App.UsControlStyle(fr);
            App.AddNewBusUcControl(fr, "显示角色有效时间设定");
        }

        /// <summary>
        /// 危重护理项目的维护
        /// </summary>
        public void frmShowNurseMask()
        {
            SYSTEMSET.ucNurseMask fr = new Bifrost.SYSTEMSET.ucNurseMask();
            App.UsControlStyle(fr);
            App.AddNewBusUcControl(fr, "危重护理项目的维护");
        }


        /// <summary>
        /// 病案系统接口调用
        /// </summary>
        public void frmBaInsert()
        {
            HisInStance.frmBa_Insert fm = new HisInStance.frmBa_Insert();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "创新病案系统接口");
        }

        #endregion


        #region 文书操作
        /// <summary>
        /// 插入模版标签
        /// </summary>
        /// <param name="TID">模版ID</param>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static string InsertLabelContent(int TID, XmlDocument xmlDoc)
        {
            string str = "";
            try
            {
                //str = WebService.InsertLableContent(TID, xmlDoc);
               
                    str = Operater.InsertLableContent(TID, xmlDoc.OuterXml);
                
               
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 插入模板
        /// </summary>
        /// <param name="PID">病人主ID(HIS)</param>
        /// <param name="xmlDoc">文书(xml类型)</param>
        /// <returns></returns>
        public static string InsertModel(string PID, int textKind_ID, XmlDocument xmlDoc, int belongToSys_ID, int sickKind_ID, string textName)
        {
            string str = "";
            try
            {
                

                    str = Operater.InsertModel(PID, textKind_ID, xmlDoc.OuterXml, belongToSys_ID, sickKind_ID, textName);
              
                return str;
            }
            catch
            {
            }
            return str;
        }



        /// <summary>
        /// 插入标签--------测试用
        /// </summary>
        /// <param name="TID">住院病人文书代码</param>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        private static string InsertLabelModel(int TID, XmlDocument xmlDoc)
        {
            //string str = "";
            //try
            //{
            //    str = WebService.InsertLableModel(TID, xmlDoc);
            //    return str;
            //}
            //catch
            //{

            //}
            return "";
        }

        /// <summary>
        /// 插入结构化--------测试用
        /// </summary>
        /// <param name="LID">模版集合标签代码</param>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        private static string InsertStructValue(int LID, XmlDocument xmlDoc)
        {
            //string str = "";
            //try
            //{
            //    str = WebService.InsertStructValue(LID, xmlDoc);
            //    return str;
            //}
            //catch
            //{

            //}
            return "";
        }





        /// <summary>
        /// 查询标签模版的文本内容（span节点），用于关键词过滤
        /// </summary>
        /// <returns></returns>
        public static string ModelLableText()
        {
            string str = "select lable_model from t_model_lable where lid=4";
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                DataSet ds;
               
                ds = Operater.GetDataSet_MySql(str);
               
                //DataSet ds = WebService.GetDataSet(str);


                XmlDocument xmlDoc = new XmlDocument();
                string strxml = ds.Tables[0].Rows[0]["lable_model"].ToString();
                xmlDoc.LoadXml(strxml);

                XmlElement xmlElement = xmlDoc.DocumentElement;

                foreach (XmlNode spanNode in xmlElement.ChildNodes)
                {
                    //if (divNode.Name == "div")
                    //{
                    //    if (divNode.HasChildNodes)
                    //    {           
                    //        foreach (XmlNode spanNode in divNode.ChildNodes)
                    //        {
                    if (spanNode.Name == "span")
                    {
                        string selValue = spanNode.InnerText;
                        return selValue;
                    }
                    //        }
                    //    }
                    //}
                }

                return "";

            }
            catch (Exception ex) { return ex.ToString(); }
        }



        /// <summary>
        /// 获取文书权限
        /// </summary>
        /// <param name="Text_id">文书主键</param>       
        /// <param name="patient_group_id">当前病人的诊疗或护理组</param>
        /// <param name="Sick_Doctor_Id">当前病人的诊疗或护理组</param>
        /// <returns></returns>
        public static ArrayList Get_Text_Button_Rights(int Text_id, int patient_group_id, int Sick_Doctor_Id)
        {
            try
            {
                #region 初始化按钮Enable属性
                for (int i = 0; i < ParentForm.Controls.Count; i++)
                {
                    if (ParentForm.Controls[i].Name == "toolbar")
                    {
                        Bar temptool = (Bar)ParentForm.Controls[i];
                        for (int k = 0; k < temptool.Items.Count; k++)
                        {
                            ButtonItem temp = (ButtonItem)temptool.Items[k];
                            /*
                             * 如果当按钮是 注销 角色选择 一律Enable为true tsbtnDutySet tsbtnHelp
                             */
                            if (temptool.Items[k].Name == "tbtnResetSystem" ||
                               temptool.Items[k].Name == "tbtnRoleChose" ||
                               temptool.Items[k].Name == "tbtnAccountClear" ||
                               temptool.Items[k].Name == "tsbtnSectionAccountSet" ||
                               temptool.Items[k].Name == "tbtnPassword" ||
                               temptool.Items[k].Name == "tsbtnZLGF" ||
                               temptool.Items[k].Name == "tsbtnHelp" ||
                               temptool.Items[k].Name == "tsbtnBKSB" ||
                               temptool.Items[k].Name == "tsbtnDutySet" ||
                               temptool.Items[k].Name == "tsbtnSmallTemplateSave")
                            {
                                temptool.Items[k].Enabled = true;
                            }
                        }

                        for (int k = 0; k < temptool.Items.Count; k++)
                        {
                            ButtonItem temp = (ButtonItem)temptool.Items[k];
                            /*
                             * 如果当按钮是 注销 角色选择 一律Enable为true tsbtnHelp
                             */
                            if (temptool.Items[k].Name != "tbtnResetSystem" &&
                               temptool.Items[k].Name != "tbtnRoleChose" &&
                                temptool.Items[k].Name != "tbtnAccountClear" &&
                               temptool.Items[k].Name != "tsbtnSectionAccountSet" &&
                               temptool.Items[k].Name != "tbtnPassword" &&
                               temptool.Items[k].Name != "tsbtnZLGF" &&
                               temptool.Items[k].Name != "tsbtnHelp" &&
                               temptool.Items[k].Name != "tsbtnBKSB" &&
                               temptool.Items[k].Name != "tsbtnDutySet" &&
                                temptool.Items[k].Name != "tsbtnSmallTemplateSave")
                            {
                                temptool.Items[k].Enabled = false;
                            }
                        }
                    }
                }
                #endregion

                #region 配置权限设定
                //所有的文书操作
                DataSet ds_Text_Operater = App.GetDataSet("select * from t_permission where perm_kind=2");

                //职务或职称
                DataSet ds_job = App.GetDataSet("select flag,jobtitle,types,levels,textcontrol from t_text_jobtitle_relation a inner join T_IN_DOC_JOBTITLE b on a.jobtitle=b.jobtitle_id where texttype=" + Text_id + "");

                //其他权限
                DataSet ds_OtherRight = App.GetDataSet("select * from t_text_other_set where texttype=" + Text_id + "");

                //职务职称级别表
                DataSet ds_Levels = App.GetDataSet("select * from T_IN_DOC_JOBTITLE");

                //当前帐号所拥有的诊疗组信息
                DataSet ds_Group = App.GetDataSet("select * from T_TREATORNURSE_GROUP a inner join t_tng_account b on a.tng_id=b.tng_id where b.account_id=" + App.UserAccount.Account_id + "");

                //职务 交集
                ArrayList JobRights = new ArrayList();

                //按钮其他权限一 交集
                ArrayList buttonRights1 = new ArrayList();

                //按钮其他权限二 并集00
                ArrayList buttonRights2 = new ArrayList();

                //有权限的操作
                ArrayList buttons = new ArrayList();

                if (App.UserAccount != null)
                {
                    if (App.UserAccount.UserInfo != null)
                    {
                        for (int i = 0; i < ds_Text_Operater.Tables[0].Rows.Count; i++)
                        {
                            int buttonid = Convert.ToInt16(ds_Text_Operater.Tables[0].Rows[i]["id"]);
                            string buttoncode = ds_Text_Operater.Tables[0].Rows[i]["perm_code"].ToString();
                            JobRights.Clear();
                            buttonRights1.Clear();
                            buttonRights2.Clear();
                            /*
                             * 职务职称
                             */
                            DataRow[] jobs = ds_job.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < jobs.Length; j++)
                            {
                                JobRights.Add(jobs[j]);
                            }

                            /*
                             *获取所有的其他权限 
                             */

                            DataRow[] OtherRights = ds_OtherRight.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < OtherRights.Length; j++)
                            {
                                if (OtherRights[j]["other_name"].ToString().Trim() == "仅管床" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "仅执业证书" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "仅本诊疗组")
                                {
                                    buttonRights1.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                                else
                                {
                                    buttonRights2.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                            }

                            /*
                             * 权限效验
                             */
                            bool flagJob = false;
                            bool flagbutton1 = false;
                            bool flagbutton2_shixi = false;
                            bool flagbutton2_jinxiu = false;
                            if (JobRights.Count > 0)
                            {
                                for (int j = 0; j < JobRights.Count; j++)
                                {
                                    DataRow temprow = (DataRow)JobRights[j];
                                    string Sign = temprow["flag"].ToString().Trim();
                                    string jobtitle = temprow["jobtitle"].ToString().Trim(); //职务或职称ID
                                    string types = temprow["types"].ToString().Trim();       //类型
                                    int levels = Convert.ToInt16(temprow["levels"].ToString().Trim());     //级别

                                    //职务
                                    if (types == "1" || types == "2")
                                    {
                                        DataRow[] Rows = ds_Levels.Tables[0].Select("jobtitle_id=" + App.UserAccount.CurrentSelectRole.Role_id + " and types=" + types + "");
                                        if (Rows.Length > 0)
                                        {
                                            int alevel = Convert.ToInt16(Rows[0]["levels"]);
                                            flagJob = false;
                                            if (Sign.Contains(">"))
                                            {
                                                if (alevel > levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("<"))
                                            {
                                                if (alevel < levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("="))
                                            {
                                                if (alevel == levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≥"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≤"))
                                            {
                                                if (alevel <= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            flagJob = false;
                                        }
                                    }

                                    //职称
                                    if (types == "3" || types == "4")
                                    {
                                        DataRow[] Rows = ds_Levels.Tables[0].Select("jobtitle_id=" + App.UserAccount.UserInfo.U_tech_post + " and types=" + types + "");
                                        if (Rows.Length > 0)
                                        {
                                            int alevel = Convert.ToInt16(Rows[0]["levels"]);
                                            flagJob = false;
                                            if (Sign.Contains(">"))
                                            {
                                                if (alevel > levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("<"))
                                            {
                                                if (alevel < levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("="))
                                            {
                                                if (alevel == levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≥"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≤"))
                                            {
                                                if (alevel <= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            flagJob = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                flagJob = true;
                            }

                            if (buttonRights1.Count > 0)
                            {
                                for (int j = 0; j < buttonRights1.Count; j++)
                                {
                                    //相关职业证书                                   
                                    if (buttonRights1[j].ToString() == "仅管床")
                                    {
                                        if (App.UserAccount.UserInfo.User_id == UserAccount.UserInfo.User_id)
                                        {
                                            flagbutton1 = true;
                                        }
                                        else
                                        {
                                            flagbutton1 = false;
                                            break;
                                        }
                                    }

                                    if (buttonRights1[j].ToString() == "仅执业证书")
                                    {
                                        if (App.UserAccount.UserInfo.Profession_card.Contains("true"))
                                        {
                                            flagbutton1 = true;
                                        }
                                        else
                                        {
                                            flagbutton1 = false;
                                            break;
                                        }
                                    }

                                    //if (buttonRights1[j].ToString() == "仅本诊疗组")
                                    //{
                                    //    //诊疗组设置 tng_id
                                    //    flagbutton1 = false;
                                    //    if (ds_Group.Tables[0].Rows.Count > 0)
                                    //    {
                                    //        if (patient_group_id != 0)  //此部分正在构建中……
                                    //        {
                                    //            for (int k = 0; k < ds_Group.Tables[0].Rows.Count; k++)
                                    //            {
                                    //                if (ds_Group.Tables[0].Rows[k]["tng_id"].ToString() == patient_group_id.ToString())
                                    //                {
                                    //                    flagbutton1 = true;
                                    //                }
                                    //            }
                                    //        }
                                    //        //else   //patient_group_id = 0,此时病人没有诊疗组或护理组
                                    //        //{
                                    //        //    flagbutton1 = true;
                                    //        //}
                                    //    }
                                    //    //else  //登录账号没有诊疗护理组的情况
                                    //    //{
                                    //    //    flagbutton1 = true;
                                    //    //}
                                    //}
                                }
                            }
                            else
                            {
                                flagbutton1 = true;
                            }

                            if (buttonRights2.Count > 0)
                            {
                                if (UserAccount.Kind == 53)
                                {
                                    for (int j = 0; j < buttonRights2.Count; j++)
                                    {
                                        //帐户性质 53可实习 54可进修
                                        if (buttonRights2[j].ToString().Trim() == "可实习")
                                        {
                                            flagbutton2_shixi = true;
                                        }
                                        //if (buttonRights2[j].ToString().Trim() == "可进修")
                                        //{
                                        //    flagbutton2_jinxiu = true;
                                        //}
                                    }
                                }
                            }
                            //if (Roleflag == "0")   //如果变量Roleflag=0,默认权限无效
                            //{
                            //    buttons.Add(buttoncode);
                            //}
                            //else
                            //{
                            if (JobRights.Count == 0 && buttonRights1.Count == 0)
                            {
                                if (UserAccount.Kind != 53)
                                    buttons.Add(buttoncode);
                                else
                                {
                                    if (flagbutton2_shixi)
                                    {
                                        buttons.Add(buttoncode);
                                    }
                                }
                            }
                            else
                            {
                                if (UserAccount.Kind == 53)
                                {
                                    if (flagJob && flagbutton1 && flagbutton2_shixi)
                                    {
                                        buttons.Add(buttoncode);
                                    }
                                }
                                if (UserAccount.Kind != 53)
                                {
                                    if (flagJob && flagbutton1)
                                    {
                                        buttons.Add(buttoncode);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 身份判别             
                if (Text_id != 151 && Text_id != 389) //是否为手术记录 235
                {
                    if (App.UserAccount.UserInfo.User_id != Sick_Doctor_Id.ToString() &&
                          Sick_Doctor_Id != 0 &&
                          App.UserAccount.Kind != 53 &&
                          App.UserAccount.Kind != 54 &&
                          App.UserAccount.Kind != 7921 &&
                          App.UserAccount.Kind != 70 &&
                          App.UserAccount.CurrentSelectRole.Role_id != "22" &&
                          App.UserAccount.CurrentSelectRole.Role_id != "23" &&
                          App.UserAccount.CurrentSelectRole.Role_id != "229" &&
                          App.UserAccount.CurrentSelectRole.Role_id != "232" &&
                          App.UserAccount.CurrentSelectRole.Role_id != "233" &&
                          App.UserAccount.CurrentSelectRole.Role_id != "235" &&
                          App.UserAccount.CurrentSelectRole.Role_id != "228")
                    {
                        buttons = new ArrayList();
                        if (GetTheHighLevelUserId(App.UserAccount.UserInfo.User_id, Sick_Doctor_Id.ToString()) == App.UserAccount.UserInfo.User_id)
                        {
                            //同一职务的话需要判断职称
                            buttons.Add("tsbtnTemplate");
                            buttons.Add("tsbtnModify");
                            buttons.Add("tsbtnCommit");
                            buttons.Add("ttsbtnPrint");
                            buttons.Add("tsbtnTemplateSave");
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_id == "228" ||
                            App.UserAccount.CurrentSelectRole.Role_id == "229" ||
                             App.UserAccount.CurrentSelectRole.Role_id == "235" ||
                            App.UserAccount.CurrentSelectRole.Role_id == "232" ||
                            App.UserAccount.CurrentSelectRole.Role_id == "233")
                        {
                            //同一职务的话需要判断职称
                            buttons.Add("tsbtnTemplate");
                            buttons.Add("tsbtnWrite");
                            buttons.Add("tsbtnModify");
                            buttons.Add("tsbtnCommit");
                            buttons.Add("ttsbtnPrint");
                            buttons.Add("tsbtnTemplateSave");
                        }

                    }
                    else if (Text_id != 0 && App.UserAccount.UserInfo.User_id != Sick_Doctor_Id.ToString() &&
                        Text_id != 126 &&
                        Text_id != 127 &&
                        Text_id != 158 && App.UserAccount.Kind == 53)
                    {
                        buttons = new ArrayList();
                    }
                    else if (App.UserAccount.UserInfo.User_id != Sick_Doctor_Id.ToString() && App.UserAccount.Kind == 52)
                    {
                        if (App.UserAccount.CurrentSelectRole.Role_id == "22" || App.UserAccount.CurrentSelectRole.Role_id == "23")
                        {
                            //for (int i = 0; i < buttons.Count; i++)
                            //{
                            //    if (buttons[i].ToString() == "tsbtnWrite")
                            //    {
                            //        buttons.Remove(buttons[i]);
                            //        break;
                            //    }
                            //}
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_id == "228" ||
                            App.UserAccount.CurrentSelectRole.Role_id == "229" ||
                             App.UserAccount.CurrentSelectRole.Role_id == "235" ||
                            App.UserAccount.CurrentSelectRole.Role_id == "232" ||
                            App.UserAccount.CurrentSelectRole.Role_id == "233"
                            )
                        {
                            buttons.Add("tsbtnWrite");
                        }
                    }
                    else if (App.UserAccount.UserInfo.User_id == Sick_Doctor_Id.ToString())
                    {
                        buttons.Add("tsbtnTemplate");
                        buttons.Add("tsbtnModify");
                        buttons.Add("tsbtnCommit");
                        buttons.Add("tsbtnTempSave");
                    }
                }
                else
                {
                    //if (App.UserAccount.UserInfo.Profession_card == "true")
                    //{
                    buttons.Add("tsbtnTemplate");
                    buttons.Add("tsbtnModify");
                    buttons.Add("tsbtnCommit");
                    buttons.Add("tsbtnTempSave");
                    buttons.Add("tsbtnWrite");
                    //}
                    //else
                    //{
                    //    for (int i = 0; i < buttons.Count; i++)
                    //    {
                    //        if (buttons[i].ToString() == "tsbtnWrite")
                    //        {
                    //            buttons.Remove(buttons[i]);
                    //            break;
                    //        }
                    //    }
                    //}
                }


                //刷新主窗体按钮
                if (ParentForm != null)
                {
                    for (int i = 0; i < ParentForm.Controls.Count; i++)
                    {
                        if (ParentForm.Controls[i].Name == "toolbar")
                        {
                            Bar temptool = (Bar)ParentForm.Controls[i];
                            for (int k = 0; k < temptool.Items.Count; k++)
                            {
                                ButtonItem temp = (ButtonItem)temptool.Items[k];
                                bool enableflag = false;
                                for (int j = 0; j < buttons.Count; j++)
                                {
                                    if (temp.Name == buttons[j].ToString())
                                    {
                                        enableflag = true;
                                        break;
                                    }
                                }
                                if (enableflag)
                                {
                                    temptool.Items[k].Enabled = true;
                                }
                            }
                        }
                    }
                }
                #endregion

                return buttons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///权限过滤设置 
        /// </summary>
        /// <param name="Text_id"></param>
        /// <param name="patient_group_id"></param>
        /// <param name="Sick_Doctor_Id"></param>
        /// <param name="obj"></param>
        /// <param name="OperateType">0修改或创建 1浏览</param>
        public static string Get_Text_Buttns_Set_rights(int patient_group_id, int Sick_Doctor_Id, object obj, InPatientInfo currentPatient, int OperateType)
        {

            if (obj == null)
            {
                App.SetToolButtonByUser("tsbtnTemplate", false);
                App.SetToolButtonByUser("tsbtnTemplateSave", false);
                App.SetToolButtonByUser("ttsbtnPrint", false);
                App.SetToolButtonByUser("tsbtnTempSave", false);
                App.SetToolButtonByUser("tsbtnCommit", false);
                return "";
            }
            if (obj.GetType().ToString().Contains("TreeNode"))
            {
                if (OperateType == 0)
                {
                    #region treenode创建或修改
                    bool flag = false;  //当前帐号对该份文书是否有书写的权限
                    TreeNode Temp = obj as TreeNode;
                    if (Temp.Name != "" && currentPatient != null)
                    {
                        string account_Type = App.UserAccount.CurrentSelectRole.Role_type;
                        if (account_Type == "D")   //当前用户是医生
                        {
                            //对文书的操作权限控制
                            int textId = 0; //文书ID
                            if (Temp != null)
                            {
                                //病人文书
                                if (Temp.Tag.GetType().ToString() == "Bifrost.Patient_Doc")
                                {
                                    Patient_Doc doc = Temp.Tag as Patient_Doc;
                                    textId = doc.Textkind_id;
                                }
                                //文书类型
                                if (Temp.Tag.GetType().ToString() == "Bifrost.Class_Text")
                                {
                                    Class_Text text = Temp.Tag as Class_Text;
                                    textId = text.Id;
                                }
                            }
                            ArrayList list = App.Get_Text_Button_Rights(textId, currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id));
                            if (list.Count == 0)
                            {
                                return "您的权限不足！";
                            }
                            for (int i = 0; i < list.Count; i++)
                            {
                                string Button_Write = list[i] as string;
                                if (Temp.Tag.GetType().ToString().Contains("Class_Text"))
                                {
                                    Class_Text temtxt = (Class_Text)Temp.Tag;
                                    if (temtxt.Issimpleinstance == "1")
                                    {
                                        //多例文书
                                        if (Button_Write == "tsbtnWrite")    //判断该登录帐号是否有创建该份文书的权限
                                        {
                                            flag = true;
                                            break;
                                        }
                                        if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                        {
                                            if (temtxt.Id == 138 || temtxt.Id == 158)
                                            {
                                                return "";//"1、【住院病程记录】下的【出院/死亡前最后一次病程】未书写的情况下不可以书写【出院记录】下的【死亡记录】或【出院记录】;\n2、【出院/死亡前最后一次病程】已书写，但未经过管床医师与上级医师签名的情况下，也不可书写【出院记录】下的【死亡记录】或【出院记录】;";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //单例文书
                                        string temptid = isExitRecord(temtxt.Id, currentPatient.Id);
                                        if (temptid != null && temptid != "")
                                        {
                                            if (Button_Write == "tsbtnModify")    //判断该登录帐号是否有创建该份文书的权限
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (Button_Write == "tsbtnWrite")    //判断该登录帐号是否有创建该份文书的权限
                                            {
                                                flag = true;
                                                break;
                                            }
                                            if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                            {
                                                if (temtxt.Id == 138 || temtxt.Id == 158)
                                                {
                                                    return "";//"1、【住院病程记录】下的【出院/死亡前最后一次病程】未书写的情况下不可以书写【出院记录】下的【死亡记录】或【出院记录】;\n2、【出院/死亡前最后一次病程】已书写，但未经过管床医师与上级医师签名的情况下，也不可书写【出院记录】下的【死亡记录】或【出院记录】;";
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (Temp.Tag.GetType().ToString().Contains("Patient_Doc"))
                                {
                                    if (Button_Write == "tsbtnModify")    //判断该登录帐号是否有创建该份文书的权限
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            if (!flag)
                            {
                                return "您还没有对该份文书书写的权限！";
                            }
                        }
                    }
                    #endregion
                }
                else if (OperateType == 1)
                {
                    #region 浏览
                    App.SetToolButtonByUser("tsbtnTemplate", false);
                    App.SetToolButtonByUser("tsbtnTemplateSave", false);
                    App.SetToolButtonByUser("ttsbtnPrint", true);
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    App.SetToolButtonByUser("tsbtnCommit", false);
                    #endregion                    
                }
            }
            if (obj.GetType().ToString().Contains("DevComponents.AdvTree.Node"))
            {
                if (OperateType == 0)
                {
                    #region treenode创建或修改
                    bool flag = false;  //当前帐号对该份文书是否有书写的权限
                    DevComponents.AdvTree.Node Temp = obj as DevComponents.AdvTree.Node;
                    if (Temp.Name != "" && currentPatient != null)
                    {
                        string account_Type = App.UserAccount.CurrentSelectRole.Role_type;
                        if (account_Type == "D")   //当前用户是医生
                        {
                            //对文书的操作权限控制
                            int textId = 0; //文书ID
                            if (Temp != null)
                            {
                                //病人文书
                                if (Temp.Tag.GetType().ToString() == "Bifrost.Patient_Doc")
                                {
                                    Patient_Doc doc = Temp.Tag as Patient_Doc;
                                    textId = doc.Textkind_id;
                                }
                                //文书类型
                                if (Temp.Tag.GetType().ToString() == "Bifrost.Class_Text")
                                {
                                    Class_Text text = Temp.Tag as Class_Text;
                                    textId = text.Id;
                                }
                                if (textId != 1201 || textId != 1202)
                                {
                                    App.SetToolButtonByUser("tsbtnBKSB", false);
                                }
                                else
                                {
                                    App.SetToolButtonByUser("tsbtnBKSB", true);
                                }
                            }
                            ArrayList list = App.Get_Text_Button_Rights(textId, currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id));
                            if (list.Count == 0)
                            {
                                return "您的权限不足！";
                            }
                            for (int i = 0; i < list.Count; i++)
                            {
                                string Button_Write = list[i] as string;
                                if (Temp.Tag.GetType().ToString().Contains("Class_Text"))
                                {
                                    Class_Text temtxt = (Class_Text)Temp.Tag;
                                    if (temtxt.Issimpleinstance == "1")
                                    {
                                        //多例文书
                                        if (Button_Write == "tsbtnWrite")    //判断该登录帐号是否有创建该份文书的权限
                                        {
                                            flag = true;
                                            break;
                                        }
                                        if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                        {
                                            if (temtxt.Id == 138 || temtxt.Id == 158)
                                            {
                                                return "";//"1、【住院病程记录】下的【出院/死亡前最后一次病程】未书写的情况下不可以书写【出院记录】下的【死亡记录】或【出院记录】;\n2、【出院/死亡前最后一次病程】已书写，但未经过管床医师与上级医师签名的情况下，也不可书写【出院记录】下的【死亡记录】或【出院记录】;";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //单例文书
                                        string temptid = isExitRecord(temtxt.Id, currentPatient.Id);
                                        if (temptid != null && temptid != "")
                                        {
                                            if (Button_Write == "tsbtnModify")    //判断该登录帐号是否有创建该份文书的权限
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (Button_Write == "tsbtnWrite")    //判断该登录帐号是否有创建该份文书的权限
                                            {
                                                flag = true;
                                                break;
                                            }
                                            if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                            {
                                                if (temtxt.Id == 138 || temtxt.Id == 158)
                                                {
                                                    return "";//"1、【住院病程记录】下的【出院/死亡前最后一次病程】未书写的情况下不可以书写【出院记录】下的【死亡记录】或【出院记录】;\n2、【出院/死亡前最后一次病程】已书写，但未经过管床医师与上级医师签名的情况下，也不可书写【出院记录】下的【死亡记录】或【出院记录】;";
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (Temp.Tag.GetType().ToString().Contains("Patient_Doc"))
                                {
                                    if (Button_Write == "tsbtnModify")    //判断该登录帐号是否有创建该份文书的权限
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            if (!flag)
                            {
                                return "您还没有对该份文书书写的权限！";
                            }
                        }
                    }
                    #endregion
                }
                else if (OperateType == 1)
                {
                    #region 浏览
                    App.SetToolButtonByUser("tsbtnTemplate", false);
                    App.SetToolButtonByUser("tsbtnTemplateSave", false);
                    App.SetToolButtonByUser("ttsbtnPrint", true);
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    App.SetToolButtonByUser("tsbtnCommit", false);
                    #endregion
                }
            }
            else if (obj.GetType().ToString().Contains("DevComponents.DotNetBar.TabItem"))
            {
                //切换TAB页
                string sql = "";
                DevComponents.DotNetBar.TabItem temptab = obj as DevComponents.DotNetBar.TabItem;
                InPatientInfo inpatient = temptab.Tag as InPatientInfo;
                if (temptab.Text.Contains("浏览"))
                {
                    App.SetToolButtonByUser("tsbtnTemplate", false);
                    App.SetToolButtonByUser("tsbtnTemplateSave", false);
                    App.SetToolButtonByUser("ttsbtnPrint", true);
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    App.SetToolButtonByUser("tsbtnCommit", false);
                }
                else
                {
                    string textId = "0";     //文书ID         
                    string tabtype = "";  //文书类型

                    if (temptab.Name.Split(';').Length == 2)//修改文书
                    {
                        textId = temptab.Name.Split(';')[0].ToString();
                        tabtype = temptab.Name.Split(';')[1].ToString();
                    }
                    if (temptab.Name.Split(';').Length >= 3)//新建文书
                    {
                        textId = temptab.Name.Split(';')[2].ToString();
                        tabtype = temptab.Name.Split(';')[1].ToString();
                    }

                    if (tabtype.Contains("Patient_Doc"))
                    {
                        sql = "select submitted from t_patients_doc where tid=" + textId;
                    }
                    else if (tabtype.Contains("Class_Text"))
                    {
                        sql = "select submitted from t_patients_doc where textkind_id=" + textId + " and patient_id=" + currentPatient.Id;
                    }

                    ArrayList list = App.Get_Text_Button_Rights(Convert.ToInt32(textId), currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id));
                }
                if (sql != "")
                {
                    string submitted = App.ReadSqlVal(sql, 0, "submitted");
                    if (submitted == "Y")
                    {
                        App.SetToolButtonByUser("tsbtnTempSave", false);
                    }
                    else
                    {
                        App.SetToolButtonByUser("tsbtnTempSave", true);
                    }
                }
            }
            return "";

        }


        /// <summary>
        /// 是否需要审签  true 需要审签 false 不需要审签
        /// </summary>
        /// <param name="user_id">文书创者</param>
        /// <returns></returns>
        public static bool IsNeedCheck(string user_id)
        {
            try
            {
                string KindId = App.ReadSqlVal("select a.kind as KindId from t_account a inner join t_account_user b on a.account_id=b.account_id where b.user_id=" + user_id + " and rownum=1", 0, "KindId");
                if (KindId == "53" || KindId == "54" || KindId == "7921")
                {
                    //实习，进修，研究生
                    return true;
                }
                else if (KindId == "70")
                {
                    //轮转医生
                    //select count(t.user_id) as num from t_userinfo t where t.profession_card='true' and t.user_id=                  59808581
                    string num = App.ReadSqlVal("select count(t.user_id) as num from t_userinfo t where t.profession_card='true' and t.user_id=" + user_id + "", 0, "num");
                    if (num != "")
                    {
                        if (num == "0")
                        {
                            //无证
                            return true;
                        }
                        else
                        {
                            //有证
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 文书是否可以创建  true 可以创建 false 不可创建
        /// </summary>
        /// <param name="Text_id">文书类型</param>
        /// <returns></returns>
        public static bool DocIsCanWrite(string Text_id, string patient_id)
        {
            /*
             * 1、【住院病程记录】下的【出院/死亡前最后一次病程】未书写的情况下不可以书写【出院记录】下的【死亡记录】或【出院记录】；
               2、【出院/死亡前最后一次病程】已书写，但未经过管床医师与上级医师签名的情况下，也不可书写【出院记录】下的【死亡记录】或【出院记录】；

             */

            //844   138死亡记录  158出院记录
            if (Text_id == "138" || Text_id == "158")
            {
                DataSet ds = App.GetDataSet("select tid from T_PATIENTS_DOC a where a.textkind_id=844 and a.patient_id=" + patient_id + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        //"select t.jobtitle_id,a.name,t.levels from T_IN_DOC_JOBTITLE t inner join t_Data_Code a on t.jobtitle_id=a.id where types=3"

        /// <summary>
        /// 判断是否大于等于主治医师
        /// </summary>
        /// <param name="User_id">用户实体</param>
        /// <returns></returns>
        public static bool IsHigherMasterDoctor(string User_id)
        {
            try
            {
                //主治医师 的ID为  leves=2
                if (User_id.Trim() != "")
                {
                    string U_tech_post = App.ReadSqlVal("select t.u_tech_post from t_userinfo t where t.user_id=" + User_id + "", 0, "u_tech_post");
                    DataSet ds = App.GetDataSet("select t.jobtitle_id,a.name,t.levels from T_IN_DOC_JOBTITLE t inner join t_Data_Code a on t.jobtitle_id=a.id where types=3 and t.jobtitle_id=" + U_tech_post + "");
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (App.UserAccount.Kind == 52 ||
                                App.UserAccount.Kind == 70)
                            {
                                if (Convert.ToInt32(ds.Tables[0].Rows[0]["levels"]) >= 1)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断当前账户是否是护士长 true 是 false 否
        /// </summary> 
        /// <returns></returns>
        public static bool IsMasterNurser()
        {
            try
            {
                if (App.UserAccount.CurrentSelectRole.Role_name.Contains("护士长"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// 文书权限设置
        /// </summary>
        /// <param name="Text_id">文书主键</param>
        /// <param name="Patient_Doctor_id">当前文书管床医生</param>
        /// <param name="patient_group_id">诊疗组或护理ID</param>
        /// <returns></returns>
        public static ArrayList Text_Rights_Set(int Text_id, int Patient_Doctor_id, int patient_group_id)
        {
            try
            {
                if (Text_id == 0 && Patient_Doctor_id == 0)
                {
                    for (int i = 0; i < ParentForm.Controls.Count; i++)
                    {
                        if (ParentForm.Controls[i].Name == "Bar")
                        {

                            Bar temptool = (Bar)ParentForm.Controls[i];
                            for (int k = 0; k < temptool.Items.Count; k++)
                            {
                                ButtonItem temp = (ButtonItem)temptool.Items[k];
                                if (temptool.Items[k].Name != "tbtnResetSystem" &&
                                    temptool.Items[k].Name != "tbtnRoleChose" &&
                                    temptool.Items[k].Name != "tbtnAccountClear" &&
                                    temptool.Items[k].Name != "tsbtnSectionAccountSet" &&
                                    temptool.Items[k].Name != "tbtnPassword" &&
                                    temptool.Items[k].Name != "tsbtnZLGF" &&
                                    temptool.Items[k].Name != "tsbtnHelp" &&
                                    temptool.Items[k].Name != "tsbtnBKSB" &&
                                    temptool.Items[k].Name != "tsbtnDutySet" &&
                                    temptool.Items[k].Name != "tsbtnSmallTemplateSave")
                                {
                                    temptool.Items[k].Enabled = false;
                                }
                            }
                        }
                    }
                    return null;
                }

                //所有的文书操作
                DataSet ds_Text_Operater = App.GetDataSet("select * from t_permission where perm_kind=2");

                //职务或职称
                DataSet ds_job = App.GetDataSet("select flag,jobtitle,types,levels,textcontrol from t_text_jobtitle_relation a inner join T_IN_DOC_JOBTITLE b on a.jobtitle=b.jobtitle_id where texttype=" + Text_id + "");

                //其他权限
                DataSet ds_OtherRight = App.GetDataSet("select * from t_text_other_set where texttype=" + Text_id + "");

                //职务职称级别表
                DataSet ds_Levels = App.GetDataSet("select * from T_IN_DOC_JOBTITLE");

                //当前帐号所拥有的诊疗组信息
                DataSet ds_Group = App.GetDataSet("select * from T_TREATORNURSE_GROUP a inner join t_tng_account b on a.tng_id=b.tng_id where b.account_id=" + App.UserAccount.Account_id + "");

                //bool IsZhiWuZhiCheng = false;
                //bool IsOtherRights = false;


                //职务 交集
                ArrayList JobRights = new ArrayList();

                //按钮其他权限一 交集
                ArrayList buttonRights1 = new ArrayList();

                //按钮其他权限二 并集
                ArrayList buttonRights2 = new ArrayList();

                //有权限的操作
                ArrayList buttons = new ArrayList();

                if (App.UserAccount != null)
                {
                    if (App.UserAccount.UserInfo != null)
                    {
                        for (int i = 0; i < ds_Text_Operater.Tables[0].Rows.Count; i++)
                        {
                            int buttonid = Convert.ToInt16(ds_Text_Operater.Tables[0].Rows[i]["id"]);
                            string buttoncode = ds_Text_Operater.Tables[0].Rows[i]["perm_code"].ToString();
                            JobRights.Clear();
                            buttonRights1.Clear();
                            buttonRights2.Clear();
                            /*
                             * 职务职称
                             */
                            DataRow[] jobs = ds_job.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < jobs.Length; j++)
                            {
                                //allrights.add(ds_otherright.tables[0].rows[i]["other_name"].tostring().trim());
                                JobRights.Add(jobs[j]);
                            }

                            /*
                             *获取所有的其他权限 
                             */

                            DataRow[] OtherRights = ds_OtherRight.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < OtherRights.Length; j++)
                            {
                                if (OtherRights[j]["other_name"].ToString().Trim() == "仅管床" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "仅执业证书" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "仅本诊疗组")
                                {
                                    buttonRights1.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                                else
                                {
                                    buttonRights2.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                            }

                            /*
                             * 权限效验 判断是否有相应的操作权限
                             */
                            bool flagJob = false;
                            bool flagbutton1 = false;
                            bool flagbutton2_shixi = false;
                            bool flagbutton2_jinxiu = false;
                            if (JobRights.Count > 0)
                            {
                                for (int j = 0; j < JobRights.Count; j++)
                                {
                                    DataRow temprow = (DataRow)JobRights[j];
                                    string Sign = temprow["flag"].ToString().Trim();
                                    string jobtitle = temprow["jobtitle"].ToString().Trim(); //职务或职称ID
                                    string types = temprow["types"].ToString().Trim();       //类型
                                    int levels = Convert.ToInt16(temprow["levels"].ToString().Trim());     //级别

                                    //职务
                                    if (types == "1" || types == "2")
                                    {
                                        DataRow[] Rows = ds_Levels.Tables[0].Select("jobtitle_id=" + App.UserAccount.CurrentSelectRole.Role_id + " and types=" + types + "");
                                        if (Rows.Length > 0)
                                        {
                                            int alevel = Convert.ToInt16(Rows[0]["levels"]);
                                            flagJob = false;
                                            if (Sign.Contains(">"))
                                            {
                                                if (alevel > levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("<"))
                                            {
                                                if (alevel < levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("="))
                                            {
                                                if (alevel == levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≥"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≤"))
                                            {
                                                if (alevel <= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            flagJob = false;
                                        }
                                    }

                                    //职称
                                    if (types == "3" || types == "4")
                                    {
                                        DataRow[] Rows = ds_Levels.Tables[0].Select("jobtitle_id=" + App.UserAccount.UserInfo.U_tech_post + " and types=" + types + "");
                                        if (Rows.Length > 0)
                                        {
                                            int alevel = Convert.ToInt16(Rows[0]["levels"]);
                                            flagJob = false;
                                            if (Sign.Contains(">"))
                                            {
                                                if (alevel > levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("<"))
                                            {
                                                if (alevel < levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("="))
                                            {
                                                if (alevel == levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≥"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("≤"))
                                            {
                                                if (alevel <= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            flagJob = false;
                                        }
                                    }

                                }
                            }
                            else
                            {
                                flagJob = true;
                            }

                            if (buttonRights1.Count > 0)
                            {
                                for (int j = 0; j < buttonRights1.Count; j++)
                                {
                                    //相关职业证书                                   
                                    if (buttonRights1[j].ToString() == "仅管床")
                                    {
                                        if (App.UserAccount.UserInfo.User_id == Patient_Doctor_id.ToString())
                                        {
                                            flagbutton1 = true;
                                        }
                                        else
                                        {
                                            flagbutton1 = false;
                                            break;
                                        }
                                    }

                                    if (buttonRights1[j].ToString() == "仅执业证书")
                                    {
                                        if (App.UserAccount.UserInfo.Profession_card.Contains("true"))
                                        {
                                            flagbutton1 = true;
                                        }
                                        else
                                        {
                                            flagbutton1 = false;
                                            break;
                                        }
                                    }

                                    if (buttonRights1[j].ToString() == "仅本诊疗组")
                                    {
                                        //诊疗组设置 tng_id
                                        flagbutton1 = false;
                                        if (ds_Group.Tables[0].Rows.Count > 0)
                                        {
                                            if (patient_group_id != 0)
                                            {
                                                for (int k = 0; k < ds_Group.Tables[0].Rows.Count; k++)
                                                {
                                                    if (ds_Group.Tables[0].Rows[k]["tng_id"].ToString() == patient_group_id.ToString())
                                                    {
                                                        flagbutton1 = true;
                                                    }
                                                }
                                            }
                                            //else   //patient_group_id = 0,此时病人没有诊疗组或护理组
                                            //{
                                            //    flagbutton1 = true;
                                            //}
                                        }
                                        //else   //登录账号没有诊疗护理组的情况
                                        //{
                                        //    flagbutton1 = true;
                                        //}

                                    }
                                }
                            }
                            else
                            {
                                flagbutton1 = true;
                            }

                            if (buttonRights2.Count > 0)
                            {

                                for (int j = 0; j < buttonRights2.Count; j++)
                                {
                                    //帐户性质 53可实习 54可进修
                                    if (buttonRights2[j].ToString().Trim() == "可实习")
                                    {
                                        flagbutton2_shixi = true;
                                    }

                                    //if (buttonRights2[j].ToString().Trim() == "可进修")
                                    //{
                                    //    flagbutton2_jinxiu = true;
                                    //}
                                }
                            }

                            if (Roleflag == "0")      //如果变量Roleflag=0,默认权限无效
                            {
                                buttons.Add(buttoncode);
                            }
                            else
                            {
                                if (JobRights.Count == 0 && buttonRights1.Count == 0)
                                {
                                    if (Roleflag == "0")
                                    {
                                        buttons.Add(buttoncode);
                                    }
                                }
                                else
                                {
                                    if (App.UserAccount.Kind == 53)
                                    {
                                        if (flagJob && flagbutton1 && flagbutton2_shixi)
                                        {
                                            buttons.Add(buttoncode);
                                        }
                                    }
                                    //if (App.UserAccount.Kind == 53)
                                    //{
                                    //    if (flagJob && flagbutton1 && flagbutton2_jinxiu)
                                    //    {
                                    //        buttons.Add(buttoncode);
                                    //    }
                                    //}
                                    if (App.UserAccount.Kind != 53 && App.UserAccount.Kind != 54)
                                    {
                                        if (flagJob && flagbutton1)
                                        {
                                            buttons.Add(buttoncode);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //刷新主窗体按钮
                if (ParentForm != null)
                {
                    for (int i = 0; i < ParentForm.Controls.Count; i++)
                    {
                        if (ParentForm.Controls[i].Name == "toolbar")
                        {
                            Bar temptool = (Bar)ParentForm.Controls[i];
                            for (int k = 0; k < temptool.Items.Count; k++)
                            {
                                bool flag = false;
                                ButtonItem temp = (ButtonItem)temptool.Items[k];
                                for (int j = 0; j < ds_Text_Operater.Tables[0].Rows.Count; j++)
                                {
                                    if (temp.Name.Trim().ToLower() == ds_Text_Operater.Tables[0].Rows[j]["perm_code"].ToString().Trim().ToLower())
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag)
                                {
                                    bool enableflag = false;
                                    for (int j = 0; j < buttons.Count; j++)
                                    {
                                        if (temp.Name == buttons[j].ToString())
                                        {
                                            enableflag = true;
                                            break;
                                        }
                                    }
                                    if (enableflag)
                                    {
                                        temptool.Items[k].Enabled = true;
                                    }
                                    else
                                    {
                                        temptool.Items[k].Enabled = false;
                                    }
                                }
                                else
                                {
                                    temptool.Items[k].Enabled = true;
                                }
                            }
                        }
                    }
                }
                return buttons;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }
        }

        /// <summary>
        /// 文书浏览
        /// </summary>
        public static void Text_Preview()
        {
            //刷新主窗体按钮
            if (ParentForm != null)
            {
                for (int i = 0; i < ParentForm.Controls.Count; i++)
                {
                    if (ParentForm.Controls[i].Name == "Bar")
                    {
                        Bar temptool = (Bar)ParentForm.Controls[i];
                        for (int k = 3; k < temptool.Items.Count; k++)
                        {
                            ButtonItem temp = (ButtonItem)temptool.Items[k];
                            temptool.Items[k].Enabled = false;

                        }
                        for (int k = 3; k < temptool.Items.Count; k++)
                        {
                            ButtonItem temp = (ButtonItem)temptool.Items[k];
                            if (temp.Name.Trim().ToLower() == "ttsbtnprint")
                            {
                                temptool.Items[k].Enabled = true;
                            }
                            else if (temp.Name.Trim().ToLower() == "tsbtntempsave")
                            {
                                temptool.Items[k].Enabled = true;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < ParentForm.Controls.Count; i++)
            {
                if (ParentForm.Controls[i].Name == "toolbar")
                {
                    Bar temptool = (Bar)ParentForm.Controls[i];
                    for (int k = 0; k < temptool.Items.Count; k++)
                    {
                        ButtonItem temp = (ButtonItem)temptool.Items[k];
                        /*
                         * 如果当按钮是 注销 角色选择 一律Enable为true
                         */
                        if (temptool.Items[k].Name == "tbtnResetSystem" ||
                           temptool.Items[k].Name == "tbtnRoleChose" ||
                           temptool.Items[k].Name == "tbtnAccountClear" ||
                           temptool.Items[k].Name == "tsbtnSectionAccountSet" ||
                           temptool.Items[k].Name == "tbtnPassword" ||
                           temptool.Items[k].Name == "tsbtnZLGF" ||
                           temptool.Items[k].Name == "tsbtnHelp" ||
                           temptool.Items[k].Name == "tsbtnBKSB" ||
                           temptool.Items[k].Name == "tsbtnDutySet" ||
                           temptool.Items[k].Name == "tsbtnSmallTemplateSave")
                        {
                            temptool.Items[k].Enabled = true;
                        }
                    }

                    for (int k = 0; k < temptool.Items.Count; k++)
                    {
                        ButtonItem temp = (ButtonItem)temptool.Items[k];
                        /*
                         * 如果当按钮是 注销 角色选择 一律Enable为true
                         */
                        if (temptool.Items[k].Name != "tbtnResetSystem" &&
                           temptool.Items[k].Name != "tbtnRoleChose" &&
                           temptool.Items[k].Name != "tbtnAccountClear" &&
                           temptool.Items[k].Name != "tsbtnSectionAccountSet" &&
                           temptool.Items[k].Name != "tbtnPassword" &&
                           temptool.Items[k].Name != "tsbtnZLGF" &&
                           temptool.Items[k].Name != "tsbtnHelp" &&
                           temptool.Items[k].Name != "tsbtnBKSB" &&
                           temptool.Items[k].Name != "tsbtnDutySet" &&
                           temptool.Items[k].Name != "tsbtnSmallTemplateSave")
                        {
                            temptool.Items[k].Enabled = false;
                        }
                    }

                    for (int k = 0; k < temptool.Items.Count; k++)
                    {
                        ButtonItem temp = (ButtonItem)temptool.Items[k];
                        if (temp.Name.Trim().ToLower() == "ttsbtnprint")
                        {
                            temptool.Items[k].Enabled = true;
                        }
                        //else if (temp.Name.Trim().ToLower() == "tsbtntempsave")
                        //{
                        //    temptool.Items[k].Enabled = true;
                        //}

                    }
                }
            }
        }

        /// <summary>
        /// 获取标准24小时制的时间
        /// </summary>
        /// <param name="Time">时间参数</param>
        /// <returns></returns>
        public static string GetNomalTime(string Time)
        {

            string reutrntime = "00:00:00";
            try
            {
                //am
                if (Time.ToString().ToLower().Contains("am"))
                {
                    string amtime = "";
                    for (int i = 1; i <= 12; i++)
                    {
                        amtime = i.ToString() + "am";
                        if (amtime.ToLower().Trim() == Time.ToString().ToLower().Trim())
                        {
                            if (i.ToString().Length == 1)
                            {
                                reutrntime = "0" + i.ToString() + ":" + "00:00";
                            }
                            else
                            {
                                reutrntime = i.ToString() + ":" + "00:00";
                            }
                        }
                    }
                }
                //pm
                else if (Time.ToString().ToLower().Contains("pm"))
                {
                    string pmtime = "";
                    for (int i = 1; i <= 12; i++)
                    {
                        pmtime = i.ToString() + "pm";
                        if (pmtime.ToLower().Trim() == Time.ToString().ToLower().Trim())
                        {
                            int temp = i + 12;
                            reutrntime = temp.ToString() + ":" + "00:00";
                        }
                    }
                }
                else
                {
                    reutrntime = Time;
                }
                return reutrntime;
            }
            catch
            {
                return "00:00:00";
            }
        }

        /// <summary>
        /// 获取固定时间点
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetFixTime(DateTime time)
        {
            int timeInt = time.Hour;
            string fixTime = "";
            if (timeInt <= 12)
            {

                fixTime = timeInt.ToString() + "am";

            }
            else
            {
                int newTime = timeInt - 12;
                fixTime = newTime.ToString() + "pm";

            }
            return fixTime;
        }


        /// <summary>
        /// 判断是否含有中文字符
        /// </summary>
        /// <param name="srcString">字符串参数</param>
        /// <returns></returns>
        public static bool CheckChineseEncode(string srcString)
        {
            int strLen = srcString.Length;
            //字符串的长度，一个字母和汉字都算一个
            int bytLeng = System.Text.Encoding.UTF8.GetBytes(srcString).Length;
            //字符串的字节数，字母占1位，汉字占2位,注意，一定要UTF8
            bool chkResult = false;
            if (strLen < bytLeng)
            //如果字符串的长度比字符串的字节数小，当然就是其中有汉字啦^-^
            {
                chkResult = true;
            }
            return chkResult;
        }


        /// <summary>
        /// 插入诊断上级医师签名
        /// </summary>
        public static Class_DocSign InSerterHighLevelDigSign()
        {
            frmHightLevelDigSign fr = new frmHightLevelDigSign("", "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }


        /// <summary>
        /// 插入上级医师签名
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign()
        {
            frmHightLevelSign fr = new frmHightLevelSign("", "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// 插入管床医师签名
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign(string Type)
        {
            frmHightLevelSign fr = new frmHightLevelSign(Type, "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// 插入管护士/师签名
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign_Nurse(string Type)
        {
            frmHightLevelSign_Nurse fr = new frmHightLevelSign_Nurse(Type, "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// 修改医师签名
        /// </summary>
        /// <param name="Type">类型S</param>
        /// <param name="userid">Userid</param>
        /// <returns></returns>
        public static Class_DocSign InSerterHighLevelSign(string Type, string userid)
        {
            frmHightLevelSign fr = new frmHightLevelSign(Type, userid);
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// 修改护士/师签名
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign_Nurse(string Type, string userid)
        {
            frmHightLevelSign_Nurse fr = new frmHightLevelSign_Nurse(Type, userid);
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// 根据职务职称返回级别高的人 0判别失败 不为0成功
        /// </summary>
        /// <param name="User_A_Id">员工A</param>
        /// <param name="User_B_Id">员工B</param>
        /// <returns>0判别失败 否则的话返回高级别的userid</returns>
        public static string GetTheHighLevelUserId(string User_A_Id, string User_B_Id)
        {
            try
            {
                if (User_A_Id.Trim() == "")
                {
                    if (User_B_Id != "")
                    {
                        return User_B_Id;
                    }
                }
                if (User_B_Id.Trim() == "")
                {
                    if (User_A_Id != "")
                    {
                        return User_A_Id;
                    }
                }

                if (App.UserAccount.CurrentSelectRole.Role_type != "N")
                {
                    //获取职务职称关系表
                    DataSet ds = App.GetDataSet("select * from t_in_doc_jobtitle");

                    /*
                     * 获取A员工的实例
                     */
                    Class_User tinfo_A = new Class_User();
                    DataSet ds_infoA = App.GetDataSet("select * from T_USERINFO where user_id=" + User_A_Id + "");
                    tinfo_A.User_id = User_A_Id;
                    tinfo_A.User_name = ds_infoA.Tables[0].Rows[0]["USER_NAME"].ToString();
                    tinfo_A.U_tech_post = ds_infoA.Tables[0].Rows[0]["U_TECH_POST"].ToString(); //职称

                    if (UserAccount.UserInfo.User_id == tinfo_A.User_id)
                    {
                        tinfo_A.U_position = UserAccount.CurrentSelectRole.Role_id;  //职务
                    }
                    else
                    {
                        string sql_u = "select a.role_id from t_acc_role a inner join t_account_user b on a.account_id=b.account_id where b.user_id=" + User_A_Id + "";
                        DataSet ds_a_u = GetDataSet(sql_u);
                        tinfo_A.U_position = ds_a_u.Tables[0].Rows[0]["role_id"].ToString();

                    }

                    /*
                     * 获取B员工的实例
                     */
                    Class_User tinfo_B = new Class_User();
                    DataSet ds_infoB = App.GetDataSet("select * from T_USERINFO where user_id=" + User_B_Id + "");
                    tinfo_B.User_id = User_B_Id;
                    tinfo_B.User_name = ds_infoB.Tables[0].Rows[0]["USER_NAME"].ToString();
                    tinfo_B.U_tech_post = ds_infoB.Tables[0].Rows[0]["U_TECH_POST"].ToString(); //职称


                    if (UserAccount.UserInfo.User_id == tinfo_B.User_id)
                    {
                        tinfo_B.U_position = UserAccount.CurrentSelectRole.Role_id;  //职务
                    }
                    else
                    {
                        string sql_u = "select a.role_id from t_acc_role a inner join t_account_user b on a.account_id=b.account_id where b.user_id=" + User_B_Id + "";
                        DataSet ds_b_u = GetDataSet(sql_u);
                        tinfo_B.U_position = ds_b_u.Tables[0].Rows[0]["role_id"].ToString();
                    }

                    // tinfo_B.U_position = ds_infoB.Tables[0].Rows[0]["U_POSITION"].ToString();  //职务

                    string leave_a = "0";
                    string leave_b = "0";
                    string userid = "0";
                    DataRow[] rowas;
                    DataRow[] rowbs;

                    /*
                     * 职务的判断
                     */
                    rowas = ds.Tables[0].Select("JOBTITLE_ID=" + tinfo_A.U_position + "");
                    if (rowas.Length > 0)
                    {
                        leave_a = rowas[0]["LEVELS"].ToString();
                    }

                    rowbs = ds.Tables[0].Select("JOBTITLE_ID=" + tinfo_B.U_position + "");
                    if (rowbs.Length > 0)
                    {
                        leave_b = rowbs[0]["LEVELS"].ToString();
                    }

                    if (Convert.ToInt16(leave_a) > Convert.ToInt16(leave_b))
                    {
                        userid = User_A_Id;
                    }
                    else if (Convert.ToInt16(leave_a) < Convert.ToInt16(leave_b))
                    {
                        userid = User_B_Id;
                    }
                    else
                    {
                        /*
                         * 职称的判断
                         */
                        rowas = ds.Tables[0].Select("JOBTITLE_ID=" + tinfo_A.U_tech_post + "");
                        if (rowas.Length > 0)
                        {
                            leave_a = rowas[0]["LEVELS"].ToString();
                        }

                        rowbs = ds.Tables[0].Select("JOBTITLE_ID=" + tinfo_B.U_tech_post + "");
                        if (rowbs.Length > 0)
                        {
                            leave_b = rowbs[0]["LEVELS"].ToString();
                        }

                        if (Convert.ToInt16(leave_a) > Convert.ToInt16(leave_b))
                        {
                            userid = User_A_Id;
                        }
                        else if (Convert.ToInt16(leave_a) < Convert.ToInt16(leave_b))
                        {
                            userid = User_B_Id;
                        }
                    }
                    return userid;
                }
                else
                {
                    return App.UserAccount.UserInfo.User_id;
                }
            }
            catch
            {
                return "0";
            }

        }

        /// <summary>
        /// 获取检验检查的结果
        /// </summary>
        /// <param name="pid">病人住院号</param>
        public static void ShowLisResault(string pid)
        {
            LisResault = "";
            Bifrost.HisInstance.FrmLis fm = new Bifrost.HisInstance.FrmLis(pid);
            fm.Show();

        }

        /// <summary>
        /// 添加当前操作文书信息
        /// </summary>
        /// <param name="?"></param>
        public static void AddCurrentDocMsg(string DocName)
        {
            OperaterDocIdS.Add(DocName);
        }

        /// <summary>
        /// 删除当前操作文书信息
        /// </summary>
        /// <param name="?"></param>
        public static void DelCurrentDocMsg(string DocName)
        {
            OperaterDocIdS.Remove(DocName);
        }

        /// <summary>
        /// 判断当前文书是否已经被人打开
        /// </summary>
        /// <param name="DocName"></param>
        /// <returns></returns>
        public static bool isCurrentOperating(string DocName)
        {
            try
            {
                bool flag = false;
                if (ReceiveServerMsg.Contains(DocName))
                {
                    flag = true;
                }
                return flag;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 清空当前操作的文书信息
        /// </summary>
        public static void ClearCurrentDocMsgs()
        {
            OperaterDocIdS.Clear();
        }

        public static void SendMessageToServer()
        {
            while (-1 != 0)
            {
                try
                {
                    
                    if (App.UserAccount != null)
                    {
                        if (App.UserAccount.UserInfo != null)
                        {
                            ReceiveServerMsg = "";
                            #region 新源代码
                            string host = Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini"));
                            IPAddress ServerIp = IPAddress.Parse(host);
                            string uri = "tcp://" + ServerIp + ":2000/TcpService";
                            object o = Activator.GetObject(typeof(DbHelp), uri);

                            Operater2 = (DbHelp)o;
                            string sendStr = App.GetHostIp() + ";" + App.UserAccount.UserInfo.User_name + ";" + App.UserAccount.UserInfo.U_position_name + ";" + App.UserAccount.UserInfo.U_tech_post_name + ";" + App.UserAccount.Account_name + @"!";
                            /*
                            * 当前正在操作的文书和病人ID集合
                            */
                            for (int i = 0; i < OperaterDocIdS.Count; i++)
                            {
                                sendStr = sendStr + "," + OperaterDocIdS[i].ToString();
                            }
                            Operater2.SetSeverMessages(sendStr);
                            ReceiveServerMsg = Operater2.GetSeverMessages();
                            #endregion
                            Thread.Sleep(5000);
                        }
                    }
                }
                catch
                {
                    //return;                                 
                }
            }
        }




        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        private static String response = String.Empty;

        private static void ConnectCallback(IAsyncResult ar)
        {
            try {
                // 从state对象获取socket.  
                Socket client = (Socket)ar.AsyncState;
                // 完成连接.  
                client.EndConnect(ar);
                // 连接已完成，主线程继续.  
                connectDone.Set();
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }

        private static string Receive(Socket client)
        {
            try
            {   // 构造容器state.  
                StateObject state = new StateObject();
                state.workSocket = client;
                // 从远程目标接收数据.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
                return state.sb.ToString();
            }
            catch (Exception e) {
                return "";
            }

        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // 从输入参数异步state对象中获取state和socket对象  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                //从远程设备读取数据  
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {  // 有数据，存储.  
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                    // 继续读取.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {  // 所有数据读取完毕.  
                    if (state.sb.Length > 1)
                    { response = state.sb.ToString(); }  // 所有数据读取完毕的指示信号.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }

        private static void Send(Socket client, String data)
        {  // 格式转换.  
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            // 开始发送数据到远程设备.  
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // 从state对象中获取socket  
                Socket client = (Socket)ar.AsyncState;
                // 完成数据发送.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                // 指示数据已经发送完成，主线程继续.  
                sendDone.Set();
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }



        /// <summary>
        /// 转换中文星期几的函数
        /// </summary>
        /// <param name="date">日期时间</param>
        /// <returns></returns>
        public static string dateToChsWeek(System.DateTime date)
        {
            string week = date.DayOfWeek.ToString();
            switch (week)
            {
                case "Monday": return "星期一";
                case "Tuesday": return "星期二";
                case "Wednesday": return "星期三";
                case "Thursday": return "星期四";
                case "Friday": return "星期五";
                case "Saturday": return "星期六";
                default: return "星期日";
            }
        }

        /// <summary>
        /// 过滤界面中的SQL关键字 
        /// </summary>
        /// <param name="fr"></param>
        public static void ReplaceSQLCharFormUserControl(Form fr)
        {
            foreach (System.Windows.Forms.Control ctr in fr.Controls)
            {
                SetSqlsControl(ctr);
            }
        }

        /// <summary>
        /// 文书提前质控时间
        /// </summary>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="textType_Id">文书类型</param>
        /// <param name="xmldocument">xml文书</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument)
        {
            return "";
        }

        /// <summary>
        /// 文书提前质控时间
        /// </summary>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="textType_Id">文书类型</param>
        /// <param name="xmldocument">xml文书</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument, out bool isOkDiagnose)
        {
            isOkDiagnose = false;
            return "";
        }


        /// <summary>
        /// 文书提前质控时间
        /// </summary>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="textType_Id">文书类型</param>
        /// <param name="xmldocument">xml文书</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument, out bool isOkDiagnose, out string referDiagnoseTime, bool isNew)
        {
            isOkDiagnose = false;
            referDiagnoseTime = "";
            return "";
        }

        /// <summary>
        /// 文书提前质控时间
        /// </summary>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="textType_Id">文书类型</param>
        /// <param name="xmldocument">xml文书</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument, out bool isOkDiagnose, out string referDiagnoseTime, int replaceHigher, bool isNew)
        {
            string patient_id = patient_Id;//病人ID
            string document_id = textType_Id;//文书ID
            DateTime in_time = new DateTime();//入院时间
            DateTime record_time = new DateTime();//记录时间
            DateTime sign_time = new DateTime();//签名时间
            DateTime inital_time = new DateTime();//初步诊断时间
            DateTime confirm_time = new DateTime();//确定诊断时间            
            DateTime out_time = new DateTime();//出院时间
            DateTime reference_time = new DateTime();//参考时间,空时间，用于比较时间是否是空
            DateTime tittle_time = new DateTime();//标题时间
            string doc_tittle = "";
            isOkDiagnose = false;
            referDiagnoseTime = "";
            /*
             * 获取病人相关的匹配数据,入院时间（参考时间），出院时间等
             * 医务处规则表,文书类型，偏移时间，预警值，执行周期
             */
            string SqlInfo = "select a.in_time,b.happen_time,b.action_type from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id where a.id=" + patient_Id + " and b.next_id=0";
            DataSet PatientInfods = App.GetDataSet(SqlInfo);
            if (PatientInfods != null)
            {
                if (PatientInfods.Tables[0].Rows.Count > 0)
                {
                    in_time = Convert.ToDateTime(PatientInfods.Tables[0].Rows[0]["in_time"].ToString());
                    if (PatientInfods.Tables[0].Rows[0]["action_type"].ToString() == "出区")
                    {
                        out_time = Convert.ToDateTime(PatientInfods.Tables[0].Rows[0]["happen_time"].ToString());
                    }

                }
            }
            DataSet ruleds = App.GetDataSet("select aa.*,bb.code from t_quality_var_ywc aa inner join t_data_code bb on aa.document_type=bb.id");

            /*
             * 遍历XML文档获取相关值（记录时间，签名时间,确定诊断时间，初步诊断时间,标题时间）
             */

            XmlNode bodynode = xmldocument.ChildNodes[0].SelectSingleNode("body");
            #region 文书标题
            if (bodynode.ChildNodes[0].Attributes["title"] != null)
                doc_tittle = bodynode.ChildNodes[0].Attributes["title"].Value;
            #endregion
            if (bodynode != null)
            {
                #region 获取记录时间
                if (bodynode.ChildNodes[0].Attributes[0].Name == "id")
                {
                    if (bodynode.ChildNodes[0].Attributes["id"].Value == "tableHead")
                    {

                        XmlNode tablenode = bodynode.SelectSingleNode("table/row/cell/input[@name='us_jlrq']");
                        string jlrq = "";
                        for (int i = 0; i < tablenode.ChildNodes.Count; i++)
                        {
                            if (tablenode.ChildNodes[i].OuterXml.ToString().Contains("deleter"))
                            {
                                continue;
                            }
                            if (jlrq == "")
                            {
                                jlrq = tablenode.ChildNodes[i].InnerText;
                            }
                            else
                            {
                                jlrq = jlrq + tablenode.ChildNodes[i].InnerText;
                            }
                        }

                        if (jlrq != "")
                        {
                            //记录时间
                            jlrq = jlrq.Replace("：", ":");
                            record_time = Convert.ToDateTime(jlrq.Replace("，", " "));
                        }
                    }
                }
            }
            #endregion
            #region 获取文书签名时间
            XmlNode signnode = bodynode.SelectSingleNode("input[@name='文书时间']");
            string qmsj = "";
            if (signnode != null)
            {
                for (int i = 0; i < signnode.ChildNodes.Count; i++)
                {
                    if (signnode.ChildNodes[i].OuterXml.ToString().Contains("deleter"))
                    {
                        continue;
                    }
                    if (qmsj == "")
                    {
                        qmsj = signnode.ChildNodes[i].InnerText;
                    }
                    else
                    {
                        qmsj = qmsj + signnode.ChildNodes[i].InnerText;
                    }
                }
            }
            if (qmsj != "")
            {
                //签名时间
                qmsj = qmsj.Replace("：", ":");
                sign_time = Convert.ToDateTime(qmsj.Replace("，", " "));
            }
            #endregion
            #region 获取初步诊断 和 确定诊断 时间
            string cbzdTime = "";
            string sjTime = "";
            XmlNode footnode = bodynode.SelectSingleNode("div[@id='divFoot']");
            XmlNodeList footnodeList = xmldocument.GetElementsByTagName("input");
            for (int i = 0; i < footnodeList.Count; i++)
            {
                if (footnodeList[i].Attributes["name"].Value == "普通医师日期")
                {

                    for (int chnu = 0; chnu < footnodeList[i].ChildNodes.Count; chnu++)
                    {

                        if (footnodeList[i].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            cbzdTime += footnodeList[i].ChildNodes[chnu].InnerText;
                        }

                    }
                }
                if (footnodeList[i].Attributes["name"].Value == "上级医师日期")
                {

                    //foreach (XmlNode node in footnodeList[i].ChildNodes)
                    //{
                    //    sjTime += node.InnerText;
                    //}
                    for (int chnu = 0; chnu < footnodeList[i].ChildNodes.Count; chnu++)
                    {

                        if (footnodeList[i].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            sjTime += footnodeList[i].ChildNodes[chnu].InnerText;
                        }
                    }
                }

            }
            if (cbzdTime != "")
            {
                //初步诊断时间
                cbzdTime = cbzdTime.Replace("：", ":");
                inital_time = Convert.ToDateTime(cbzdTime.Replace("，", " "));
            }
            if (sjTime != "")
            {
                //确定诊断时间
                sjTime = sjTime.Replace("：", ":");
                confirm_time = Convert.ToDateTime(sjTime.Replace("，", " "));
            }

            #endregion
            /*
             * 规则的遍历同时返回结果
             * 参考时间+偏移时间 预警时间和当前时间比较
             * 当前时间>参考时间&&当前时间<参考时间+偏移时间-预警时间表示时间正常
             * 当前时间>参考时间+偏移时间-预警时间&&参考时间+偏移时间表示当前文书在预警时间内，要速度完成
             * 当前时间>参考时间+偏移时间表示文书已经超时
             */

            for (int i = 0; i < ruleds.Tables[0].Rows.Count; i++)
            {
                int turntime = 0;
                string unit = "";
                try
                {
                    turntime = Convert.ToInt16(ruleds.Tables[0].Rows[i]["true_time"]);
                }
                catch
                {
                    //
                }
                unit = ruleds.Tables[0].Rows[i]["truetime_unit"].ToString();
                if (ruleds.Tables[0].Rows[i]["code"].ToString() == textType_Id || textType_Id == "890" || textType_Id == "891" || textType_Id == "844" || textType_Id == "1162" || textType_Id == "1161" || textType_Id == "1201" || textType_Id == "151"
)
                {
                    if (textType_Id == "119")//已测试
                    {
                        // 1.入院记录
                        return Class_Doc_Rule.In_Area_Rule(in_time, record_time, inital_time, confirm_time, reference_time, turntime, unit, ref isOkDiagnose, ref referDiagnoseTime);
                    }
                    else if (textType_Id == "120")
                    {
                        // 2. 24小时内入出院记录                       
                        return Class_Doc_Rule.In_Out_Area_Rule(turntime, unit, in_time, sign_time, xmldocument);
                    }
                    else if (textType_Id == "121")
                    {
                        // 3. 24小时内入院死亡记录                       
                        return Class_Doc_Rule.In_Die_Area_Rule(turntime, unit, in_time, sign_time, xmldocument);
                    }
                    else if (textType_Id == "1162" || textType_Id == "1201")
                    {
                        #region 4.计划生育门诊/住院病历
                        //北京市计划生育门诊/住院病历
                        return Class_Doc_Rule.Beijing_Birth_Control_Record_Rule(in_time, sign_time, xmldocument, out_time, doc_tittle);
                        #endregion
                    }
                    //else if (textType_Id == "1161")//住院病历中：文书签名时间（文书签名下面的时间）没有
                    //{
                    //    //一日病房住院病历（诊刮）
                    //    return Class_Doc_Rule.Day_Medical_Record_Curattage_Rule(in_time, sign_time, xmldocument, out_time);
                    //}
                    else if (textType_Id == "125")//已测试
                    {
                        // 6.首次病程记录                       
                        return Class_Doc_Rule.First_Medical_Record_Rule(turntime, unit, tittle_time, doc_tittle, in_time);
                    }
                    //else if (textType_Id == "126")
                    //{
                    //    // 7.病程记录.一般病程记录                        
                    //    return Class_Doc_Rule.Day_Medical_Record_Rule(patient_id, in_time, turntime, unit, tittle_time, doc_tittle, replaceHigher);
                    //}
                    //else if (textType_Id == "127")//已测试
                    //{
                    //    //8.9.上级查房记录                      
                    //    return Class_Doc_Rule.Higher_Docter_Check_Rule(doc_tittle, patient_id, in_time, tittle_time);
                    //}

                    else if (textType_Id == "130")//已测试
                    {
                        //10.病程记录--转出记录                       
                        return Class_Doc_Rule.Turn_Out_Rule(tittle_time, doc_tittle, patient_Id, reference_time, out_time, in_time);
                    }
                    else if (textType_Id == "301")//已测试
                    {
                        //11.病程记录--转入记录                      
                        return Class_Doc_Rule.Turn_In_Rule(in_time, reference_time, out_time, patient_id, turntime, unit, tittle_time, doc_tittle, isNew);
                    }
                    else if (textType_Id == "890")//同891没有
                    {
                        //12.交班记录                                              
                        return Class_Doc_Rule.JiaoBan_Record_Rule(tittle_time, doc_tittle, reference_time, in_time);
                    }
                    else if (textType_Id == "891")//已测试没有
                    {
                        // 13.接班记录                       
                        return Class_Doc_Rule.JieBan_Record_Rule(tittle_time, doc_tittle, in_time, patient_Id);
                    }
                    //else if (textType_Id == "136")//没有上护士站没有
                    //{
                    //    #region 14.术后首次病程记录
                    //    //手术结束时间取自护士站的体温单,护士站没有上
                    //    return "术后首次病程记录由于时间取自护士站，护士站没有上";
                    //    #endregion
                    //}
                    else if (textType_Id == "131")//阶段小结是周期性的，true_time，truetime_unit应该是runcycle,runcycleunit
                    {

                        //DateTime temptime = new DateTime();
                        tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
                        turntime = Convert.ToInt16(ruleds.Tables[0].Rows[i]["runcycle"]);
                        unit = ruleds.Tables[0].Rows[i]["runcycleunit"].ToString();
                        //15.阶段小结                       
                        return Class_Doc_Rule.Stage_Summary_Rule(tittle_time, doc_tittle, turntime, unit, in_time, patient_Id);
                    }
                    //else if (textType_Id == "133")//请会诊时间和文书时间
                    //{
                    //    // 16.会诊记录           
                    //    return Class_Doc_Rule.Consultaion_Record_Rule(patient_id, turntime, unit, tittle_time, doc_tittle);
                    //}
                    //else if (textType_Id == "151")
                    //{
                    //    //手术记录
                    //    return Class_Doc_Rule.Operation_Record_Rule(patient_Id, xmldocument, in_time, isNew);
                    //}
                    else if (textType_Id == "158")//已测试，出院前最后一次病程时间
                    {
                        //17.1出院记录                       
                        return Class_Doc_Rule.Out_Record_Rule(patient_id, in_time, tittle_time, doc_tittle, xmldocument);
                    }
                    else if (textType_Id == "138")//同17.1 没有进行测试
                    {
                        //17.2死亡记录                     
                        return Class_Doc_Rule.Die_Record_Rule(patient_id, in_time, tittle_time, doc_tittle, xmldocument);
                    }
                    else if (textType_Id == "844")
                    {
                        // 17.3  最后一次病程记录                      
                        return Class_Doc_Rule.Last_Medical_Record_Rule(tittle_time, doc_tittle, in_time);
                    }
                    else if (textType_Id == "139")//没有测试
                    {
                        //18.死亡病例讨论记录                       
                        return Class_Doc_Rule.Die_Discussion_Record(patient_Id, turntime, unit, out_time, tittle_time, doc_tittle);
                    }

                }
            }
            return "";
        }

        /// <summary>
        /// 将动态数组转换为字符串数组
        /// </summary>
        /// <param name="templist"></param>
        /// <returns></returns>
        public static string[] ChangeArryListToStrings(ArrayList templist)
        {
            if (templist != null)
            {
                string[] Strs = new string[templist.Count];
                for (int i = 0; i < templist.Count; i++)
                {
                    Strs[i] = templist[i].ToString();
                }
                return Strs;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据分院值获取，服务器列表
        /// </summary>
        /// <param name="ServerList">服务器总列表</param>
        /// <param name="type">区域值</param>
        /// <returns></returns>
        public static string[] GetServerListByHospitalId(string[] serverlist, int type)
        {
            if (ServerList != null)
            {
                ArrayList tempserverlists = new ArrayList();
                for (int i = 0; i < serverlist.Length; i++)
                {
                    if (serverlist[i].Split(',')[1].ToString().Trim() == type.ToString().Trim())
                        tempserverlists.Add(serverlist[i]);
                }
                if (tempserverlists.Count > 0)
                {
                    return ChangeArryListToStrings(tempserverlists);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取区域值集合
        /// </summary>
        /// <param name="serverlist">服务器列表</param>
        /// <returns></returns>
        private static string[] GetHospitalIds(string[] serverlist)
        {
            try
            {
                ArrayList hospIds = new ArrayList();
                for (int i = 0; i < serverlist.Length; i++)
                {
                    if (hospIds.Count == 0)
                    {
                        hospIds.Add(serverlist[i].Split(',')[1].ToString());
                    }
                    else
                    {
                        bool falg = false;
                        for (int j = 0; j < hospIds.Count; j++)
                        {
                            if (hospIds[j].ToString() == serverlist[i].Split(',')[1].ToString())
                            {
                                falg = true;
                            }
                        }
                        if (!falg)
                            hospIds.Add(serverlist[i].Split(',')[1].ToString());
                    }
                }
                return ChangeArryListToStrings(hospIds);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取授权文书操作权限
        /// </summary>
        /// <param name="patient_id">病人主键</param>
        /// <param name="textid">文书类型</param>
        /// <param name="operater">操作方式 0 创建 1浏览 2修改</param>
        /// <returns></returns>
        public static string GetOutTextRigthsSet(string patient_id, string textid, int operater)
        {
            DataSet ds = App.GetDataSet("select * from T_SET_TEXT_RIGHTS where PATIENT_ID=" + patient_id + "");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList templist = new ArrayList();
                    string textids = ds.Tables[0].Rows[0]["TEXT_ID"].ToString();
                    string relation = ds.Tables[0].Rows[0]["RELATION_ID"].ToString();
                    string stype = ds.Tables[0].Rows[0]["RIGHT_TYPE"].ToString();
                    string function = ds.Tables[0].Rows[0]["FUNCTIONS"].ToString();
                    DateTime d1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["BEGIN_TIME"].ToString());
                    DateTime d2 = Convert.ToDateTime(ds.Tables[0].Rows[0]["END_TIME"].ToString());


                    if (DateTime.Compare(GetSystemTime(), d1) >= 0 && DateTime.Compare(d2, GetSystemTime()) >= 0)
                    {
                        for (int i = 0; i < relation.Split(',').Length; i++)
                        {
                            if (stype == "S")
                            {
                                //科室
                                if (relation.Split(',')[i] == App.UserAccount.CurrentSelectRole.Section_Id)
                                {
                                    for (int j = 0; j < function.Split(',').Length; j++)
                                    {
                                        if (function.Split(',')[j] == "创建" && operater == 0)
                                        {
                                            SetToolButtonByUser("tsbtnCommit", true);
                                            SetToolButtonByUser("ttsbtnPrint", true);
                                            SetToolButtonByUser("tsbtnTemplate", true);
                                            SetToolButtonByUser("tsbtnTemplateSave", true);
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "查看" && operater == 1)
                                        {
                                            //SetToolButtonByUser("tsbtnCommit", true);
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "修改" && operater == 2)
                                        {
                                            SetToolButtonByUser("tsbtnCommit", true);
                                            SetToolButtonByUser("ttsbtnPrint", true);
                                            SetToolButtonByUser("tsbtnTemplate", true);
                                            SetToolButtonByUser("tsbtnTemplateSave", true);
                                            return "";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //个人
                                //科室
                                if (relation.Split(',')[i] == App.UserAccount.UserInfo.User_id)
                                {
                                    for (int j = 0; j < function.Split(',').Length; j++)
                                    {
                                        if (function.Split(',')[j] == "创建" && operater == 0)
                                        {
                                            SetToolButtonByUser("tsbtnCommit", true);
                                            SetToolButtonByUser("ttsbtnPrint", true);
                                            SetToolButtonByUser("tsbtnTemplate", true);
                                            SetToolButtonByUser("tsbtnTemplateSave", true);
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "查看" && operater == 1)
                                        {
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "修改" && operater == 2)
                                        {
                                            SetToolButtonByUser("tsbtnCommit", true);
                                            SetToolButtonByUser("ttsbtnPrint", true);
                                            SetToolButtonByUser("tsbtnTemplate", true);
                                            SetToolButtonByUser("tsbtnTemplateSave", true);
                                            return "";
                                        }
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        return "授权已经超出时效";
                    }
                    return "该操作没有得到授权";
                }
                else
                {
                    return "该操作没有得到授权";
                }
            }
            else
            {
                return "该操作没有得到授权";
            }
        }

        #endregion

        #region 工具栏按钮事件集合
        /// <summary>
        /// 书写
        /// </summary>
        public static EventHandler A_Write;

        /// <summary>
        /// 签字
        /// </summary>
        public static EventHandler A_Sign;

        /// <summary>
        /// 审核
        /// </summary>
        public static EventHandler A_Check;

        /// <summary>
        /// 修改
        /// </summary>
        public static EventHandler A_Modify;

        /// <summary>
        /// 删除
        /// </summary>
        public static EventHandler A_Delete;

        /// <summary>
        /// 查看
        /// </summary>
        public static EventHandler A_Look;

        /// <summary>
        /// 导入
        /// </summary>
        public static EventHandler A_Import;

        /// <summary>
        /// 导出
        /// </summary>
        public static EventHandler A_OutPut;

        /// <summary>
        /// 提取模版
        /// </summary>
        public static EventHandler A_Template;

        /// <summary>
        /// 保存为模版
        /// </summary>
        public static EventHandler A_TemplateSave;

        /// <summary>
        /// 提取路径模版
        /// </summary>
        public static EventHandler A_Path_Template;

        /// <summary>
        /// 保存为路径模版
        /// </summary>
        public static EventHandler A_Path_TemplateSave;

        /// <summary>
        /// 知情同意书批打印事件
        /// </summary>
        public static EventHandler A_BachePrint;

        /// <summary>
        /// 保存为小模版
        /// </summary>
        public static EventHandler A_SmallTemplateSave;

        /// <summary>
        /// 打印事件
        /// </summary>
        public static EventHandler A_Print;

        /// <summary>
        /// 续打印事件
        /// </summary>
        public static EventHandler A_PrintContinue;

        /// <summary>
        /// 暂存
        /// </summary>
        public static EventHandler A_TempSave;

        /// <summary>
        /// 提交
        /// </summary>
        public static EventHandler A_Commit;

        /// <summary>
        /// 刷新树控件
        /// </summary>
        public static EventHandler A_RefleshTreeBook;

        /// <summary>
        /// 感染病文书上报
        /// </summary>
        public static EventHandler A_BKSB;

        /// <summary>
        /// 会诊提醒
        /// </summary>
        public static EventHandler A_HZTX;

        /// <summary>
        /// 查看病程
        /// </summary>
        public static EventHandler A_CheckSick;

        /// <summary>
        /// 查看体温单
        /// </summary>
        public static EventHandler A_CheckTemprature;

        /// <summary>
        /// 查看护理记录单
        /// </summary>
        public static EventHandler A_tsbtnCheckNurseRecord;

        /// <summary>
        /// 查看检验检查结果
        /// </summary>
        public static EventHandler A_CheckLis;

        /// <summary>
        /// 查看影像报告
        /// </summary>
        public static EventHandler A_CheckPacs;

        /// <summary>
        /// 手术审批
        /// </summary>
        public static EventHandler A_CheckOperator;

        /// <summary>
        /// 病案借阅申请
        /// </summary>
        public static EventHandler A_PatientSickInfoApply;

        /// <summary>
        /// 归档退回申请
        /// </summary>
        public static EventHandler A_BackSickInfoApply;

        /// <summary>
        /// 运行病历查阅
        /// </summary>
        public static EventHandler A_UsedSickInfoCheck;

        /// <summary>
        /// 被授权文书操作
        /// </summary>
        public static EventHandler A_DocRights;

        /// <summary>
        /// 病案整理
        /// </summary>
        public static EventHandler A_MedicalRecordFinishing;

        /// <summary>
        /// 病案归档
        /// </summary>
        public static EventHandler A_MedicalRecords;

        /// <summary>
        /// 未完成工作
        /// </summary>
        public static EventHandler A_UnfinishedWork;

        ///// <summary>
        ///// 诊断编辑
        ///// </summary>
        public static EventHandler A_btnInsertDiosgin;

        ///// <summary>
        ///// 刷新诊断
        ///// </summary>
        public static EventHandler A_btnRefreshDiosgin;
        #endregion

        #region FlexGrid操作


        /// <summary>
        ///  给表格帮定数据集
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="Grid"></param>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        public static int reFleshFlexGrid(DataSet ds, ref C1FlexGrid Grid, string oldName, string newName)
        {
            try
            {
                if (ds != null)
                {
                    if (oldName != string.Empty && newName != string.Empty)
                    {
                        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                        {
                            for (int j = 0; j < oldName.Split(',').Length; j++)
                            {
                                if (ds.Tables[0].Columns[i].ColumnName.ToLower() == oldName.Split(',')[j].ToLower())
                                {
                                    ds.Tables[0].Columns[i].Caption = newName.Split(',')[j];
                                }
                            }
                        }
                    }
                    Grid.DataSource = ds.Tables[0].DefaultView;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region DataGridViewX操作
        /// <summary>
        ///  给表格帮定数据集
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="Grid"></param>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        public static int reFleshGridViewX(DataSet ds, ref DataGridViewX Grid, string oldName, string newName)
        {
            try
            {
                if (ds != null)
                {
                    Grid.DataSource = ds.Tables[0].DefaultView;
                    if (oldName != string.Empty && newName != string.Empty)
                    {
                        for (int i = 0; i < Grid.Columns.Count; i++)
                        {
                            for (int j = 0; j < oldName.Split(',').Length; j++)
                            {
                                if (Grid.Columns[i].HeaderText.ToLower() == oldName.Split(',')[j].ToLower())
                                {
                                    Grid.Columns[i].HeaderText = newName.Split(',')[j];
                                }
                            }
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 临床路径       

        #region 序列化方法
        /// <summary>
        /// Function:soap序列化方法
        /// CreateTime:2011-12-2
        /// Author:Kenneth
        /// </summary>
        /// <param name="obj">类型Object</param>
        /// <returns>Object</returns>
        public static void SerializableObject(Object obj, string fileName)
        {
            using (FileStream fs = new FileStream(App.SysPath + fileName + ".dat", FileMode.Create))
            {
                SoapFormatter soapF = new SoapFormatter();
                soapF.Serialize(fs, obj);
            }
        }
        /// <summary>
        /// Function:soap反序列化方法
        /// CreateTime:2011-12-2
        /// Author:Kenneth
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Object DeserializeObject(string fileName)
        {
            Object obj = null;
            using (FileStream fs = new FileStream(App.SysPath + fileName + ".dat", FileMode.Open))
            {
                SoapFormatter soapF = new SoapFormatter();
                obj = (Object)soapF.Deserialize(fs);
            }
            return obj;
        }

        #endregion

        #region 读取文书xml
        /// <summary>
        /// 读取文书xml
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadXmlDoc(string path)
        {
            StringBuilder strout = new StringBuilder();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            strout.Length = 0;
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            while (sr.Peek() > -1)
            {
                strout.Append(sr.ReadLine() + "\n");
            }
            sr.Close();

            return strout.ToString();
        }

        #endregion

        #region 保存修改后的xml文书
        /// <summary>
        /// 保存修改后的xml文书
        /// </summary>
        /// <param name="selectDocSql">查询当前病人文书返回xml</param>
        /// <param name="path">xml文件保存路径</param>
        public static void SaveXmlDoc(string selectDocSql, string headid, string MainTitle, string ScendTitle)
        {
            List<string> listSql = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            string docpath = App.SysPath + @"\Integration.xml";
            string patient_Doc = App.ReadSqlVal(selectDocSql, 0, "patient_Doc");
            if (patient_Doc != string.Empty && patient_Doc != null)
            {
                xmldoc.LoadXml(patient_Doc);
                XmlNodeList xml = xmldoc.GetElementsByTagName("span");
                XmlNodeList xmlcell = xmldoc.GetElementsByTagName("cell");
                if (xml.Item(2).Attributes["id"] != null)
                {
                    if (xml.Item(2).Attributes["id"].Value == headid)
                    {
                        if (ScendTitle != "")
                        {
                            xml.Item(2).InnerText = MainTitle;


                            XmlElement xmlsapn = xmldoc.CreateElement("span");
                            xmlsapn.SetAttribute("operatercreater", "1");
                            xmlsapn.SetAttribute("forecolor", "#000000");
                            xmlsapn.InnerText = "(" + ScendTitle + ")";

                            XmlElement xP = xmldoc.CreateElement("p");
                            xP.SetAttribute("align", "2");
                            xP.SetAttribute("operatercreater", "0");
                            XmlNodeList xmlsapnlist = xmlcell.Item(1).SelectNodes("span");
                            if (xmlsapnlist.Count == 2)
                            {

                                xml.Item(3).InnerText = "(" + ScendTitle + ")";

                            }
                            else
                            {
                                xmlcell.Item(1).AppendChild(xmlsapn);
                                xmlcell.Item(1).AppendChild(xP);
                            }
                        }
                        else
                        {
                            xml.Item(2).InnerText = MainTitle;
                            XmlNodeList xmlsapnlist = xmlcell.Item(1).SelectNodes("span");
                            if (xmlsapnlist.Count == 2)
                            {
                                xml.Item(3).InnerText = ScendTitle;
                            }
                        }
                    }

                }
                if (File.Exists(docpath)) //如果xml存在，先删除xml
                {
                    File.Delete(docpath);
                }
                xmldoc.Save(docpath);
            }
        }
        #endregion

        #region 修改主副标题
        /// <summary>
        /// 修改主副标题(带病人实例)
        /// </summary>
        /// <param name="updateTitleSql">修改主副标题sql语句</param>
        /// <param name="selectDocSql">查询病人文书sql语句</param>
        /// <param name="headid">列头种类实例id</param>
        /// <param name="MainTitle">主标题</param>
        /// <param name="ScendTitle">副标题</param>
        /// <returns>1或者0</returns>
        public static int UpdateTitle(string updateTitleSql, string selectDocSql, string headid, string MainTitle, string ScendTitle)
        {
            string docpath = App.SysPath + @"\Integration.xml";
            SaveXmlDoc(selectDocSql, headid, MainTitle, ScendTitle);
            string strDoc = App.ReadXmlDoc(docpath);
            if (strDoc != string.Empty && strDoc != null)
            {
                string Sql_Update = "update T_ENTITY_Path_Doc tdoc set tdoc.patient_doc=" + ":doc1" + " where tdoc.head_id='" + headid + "'";
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "doc1";
                xmlPars[0].Value = strDoc;
                xmlPars[0].DBType =MySqlDbType.Text;


                int num = App.ExecuteSQL(Sql_Update, xmlPars);
                if (num > 0)
                {

                    int count = App.ExecuteSQL(updateTitleSql);
                    if (count > 0)
                    {

                        App.Msg("修改成功!");
                        return 1;
                    }
                }
            }
            return 0;
        }
        //没有带实例的
        public static int UpdateTitle(string[] updateTitleSql, string selectDocSql, string headid, string MainTitle, string ScendTitle, int type)
        {
            string docpath = App.SysPath + @"\Integration.xml";
            SaveXmlDoc(selectDocSql, headid, MainTitle, ScendTitle);
            string strDoc = App.ReadXmlDoc(docpath);
            if (strDoc != string.Empty && strDoc != null)
            {

                string Sql_Update = "update t_path_doc td set td.patient_doc=" + ":doc1" + " where td.head_id='" + headid + "'";
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "doc1";
                xmlPars[0].Value = strDoc;
                xmlPars[0].DBType = MySqlDbType.Text;
                int num = App.ExecuteSQL(Sql_Update, xmlPars);
                if (num > 0)
                {
                    int count = App.ExecuteBatch(updateTitleSql);
                    if (count > 0)
                    {
                        if (type != 0)
                        {
                            App.Msg("修改成功!");
                        }
                        return 1;
                    }
                }
            }
            return 0;
        }
        #endregion

        #region 输入验证
        /// <summary>
        /// 提取数字
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static double GetNumber(string code)
        {
            double number;
            Regex regex = new Regex(@"[^\d.]*");
            string str2 = regex.Replace(code, "");
            number = Convert.ToDouble(str2);
            return number;
        }

        /// <summary>
        /// 提取字符
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetChar(string code)
        {
            Regex regex = new Regex(@"[\d.]*");
            string str2 = regex.Replace(code, "");
            return str2;
        }

        /// <summary>
        /// 提取字符
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetChar2(string code)
        {
            Regex regex = new Regex(@"[^\d-]");
            string str2 = regex.Replace(code, "");
            return str2;
        }

        /// <summary>
        /// 提取数字
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetNumber2(string code)
        {
            Regex regex = new Regex(@"[\d-]");
            string str3 = regex.Replace(code, "");
            return str3;
        }
        #endregion

        /// <summary>
        /// 提取字符
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool GetZimu(string code)
        {
            bool flag = false;
            Regex regex = new Regex(@"[a-zA-z]");
            flag = regex.IsMatch(code);
            return flag;
        }

        /// <summary>
        /// 字符串按长度截断
        /// </summary>
        /// <param name="InputString"></param>
        /// <param name="nlenth"></param>
        /// <returns></returns>
        public static List<string> GetStringList(string InputString, int nlenth)
        {

            List<string> slist = new List<string>();
            int slenth = Encoding.Default.GetByteCount(InputString);
            if (slenth <= nlenth)
            {
                slist.Add(InputString);
            }
            else
            {
                while (InputString.Length > 0)
                {
                    int i = ((nlenth > InputString.Length) ? InputString.Length : nlenth);
                    while (Encoding.Default.GetByteCount(InputString.Substring(0, i)) > nlenth)
                    {
                        i--;
                    }
                    slist.Add(InputString.Substring(0, i));
                    InputString = InputString.Remove(0, i);
                }
            }
            return slist;
        }

        public static void On_Click_Zhuyuan(object sender, EventArgs e)
        {
            if (App.On_Zhuyuan != null)
            {
                App.On_Zhuyuan(sender, e);
            }
        }
        public static void On_Click_GetTemplete(object sender, EventArgs e)
        {
            if (On_GetTemplete != null)
            {
                On_GetTemplete(sender, e);
            }
        }
        public static void On_Click_SaveTemplete(object sender, EventArgs e)
        {
            if (On_SaveTemplete != null)
            {
                On_SaveTemplete(sender, e);
            }
        }
        #endregion

        #region FTP操作

        /// <summary>
        /// 将文件上传至Ftp
        /// </summary>
        /// <param name="filename">文件全路径</param>
        /// <param name="fileid">文件的主键</param>
        /// <returns></returns>
        public static bool SaveMediaFile(string fileName, string fileid)
        {
            RegeditRemotingChanel();

            FileInfo fileInfo = new FileInfo(fileName);

            string ExtraName = fileInfo.Name.Split('.')[1];

            //string uri = "ftp:// " + MediaFtpUrl + "/ " + fileInfo.Name;

           // string uri = @"ftp://" + Operater.MediaFtpUrl + @"/" + fileid + "." + ExtraName;

           // reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            //reqFTP.Credentials = new NetworkCredential(Operater.MediaFtpUser, Operater.MediaFtpPassword);

            reqFTP.KeepAlive = false;

            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            reqFTP.UseBinary = true;

            reqFTP.ContentLength = fileInfo.Length;

            int buffLength = 2048;

            byte[] buff = new byte[buffLength];

            int contentLen;

            FileStream fs = fileInfo.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();

                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);

                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 将文件上传至Ftp
        /// </summary>
        /// <param name="filename">文件全路径</param>
        /// <param name="fileid">文件的主键</param>
        /// <param name="Type">类型 L 检验检查 ， P 影像 ， D 电子病历</param>
        /// <param name="PatientId">病人主键</param>
        /// <returns></returns>
        public static bool UpLoadFtp(string fileName, string fileid, string Type, string PatientId)
        {
            string sql = "select * from T_SER_ADDRESS_LIST where type='" + Type + "'";
            DataSet ds = GetDataSet(sql);
            if (ds == null)
            {
                return false;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }

            string url = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
            string uname = ds.Tables[0].Rows[0]["USERNAME"].ToString();
            string password = ds.Tables[0].Rows[0]["PASSWORD"].ToString();

            RegeditRemotingChanel();

            FileInfo fileInfo = new FileInfo(fileName);

            //string ExtraName = fileInfo.Name.Split('.')[fileInfo.Name.Split('.').Length-1];

            //string uri = "ftp:// " + MediaFtpUrl + "/ " + fileInfo.Name;

            string uri = @"ftp://" + url + @"/" + PatientId;


            //if (!isHaveFtpDir(uri, uname, password))
            //{
            UpMakeDirectory(uri, uname, password);
            //}

            uri = @"ftp://" + url + @"/" + PatientId + @"/" + fileid;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            reqFTP.Credentials = new NetworkCredential(uname, password);

            reqFTP.KeepAlive = false;

            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            reqFTP.UseBinary = true;

            reqFTP.ContentLength = fileInfo.Length;

            int buffLength = 2048;

            byte[] buff = new byte[buffLength];

            int contentLen;

            FileStream fs = fileInfo.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();

                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);

                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }


        }


        /// <summary>
        /// 将缩写的文书上传至Ftp
        /// </summary>
        /// <param name="fileName">所写文书的</param>
        /// <param name="docname">文书名称</param>
        /// <param name="PatientId">病人主键</param>  
        /// <param name="isFileUpLoad">是否文件上传</param>
        /// <returns></returns>
        public static bool UpLoadFtpPatientDoc(string fileName, string docname, string PatientId, bool isFileUpLoad)
        {
            string sql = "select * from T_SER_ADDRESS_LIST where type='U'";
            DataSet ds = GetDataSet(sql);
            if (ds == null)
            {
                return false;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            string url = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
            string uname = ds.Tables[0].Rows[0]["USERNAME"].ToString();
            string password = ds.Tables[0].Rows[0]["PASSWORD"].ToString();
            //FileInfo fileInfo = new FileInfo(fileName);
            string uri = @"ftp://" + url + @"/" + PatientId;
            UpMakeDirectory(uri, uname, password);
            uri = @"ftp://" + url + @"/" + PatientId + @"/" + docname;
            //reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            //reqFTP.Credentials = new NetworkCredential(uname, password);
            //reqFTP.KeepAlive = false;
            //reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            //reqFTP.UseBinary = true;
            //reqFTP.Proxy = null;
            //reqFTP.ContentLength = fileInfo.Length;
            //int buffLength = 2048;
            //byte[] buff = new byte[buffLength];
            //int contentLen;
            //FileStream fs = fileInfo.OpenRead();
            //try
            //{
            //    Stream strm = reqFTP.GetRequestStream();
            //    contentLen = fs.Read(buff, 0, buffLength);
            //    while (contentLen != 0)
            //    {
            //        strm.Write(buff, 0, contentLen);
            //        contentLen = fs.Read(buff, 0, buffLength);
            //    }
            //    strm.Close();
            //    fs.Close();
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// 将缩写的文书上传至Ftp
        /// </summary>
        /// <param name=" XMLOut">所写文书的</param>
        /// <param name="docname"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public static bool UpLoadFtpPatientDoc(string XMLOut, string docname, string PatientId)
        {

            bool flaglocal = false;
            bool flagserver = false;
            try
            {
               // flagserver = WebService.UploadPatientDoc(XMLOut, docname, PatientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                if (!flagserver)
                {
                    //当保存服务器失败的情况下，就保存本地目录
                    flaglocal = SaveLocalDoc(XMLOut, docname, PatientId, false);
                }
                if (flagserver == true || flaglocal == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// 将所写的门诊文书上传至Ftp
        /// </summary>
        /// <param name=" XMLOut">所写文书的</param>
        /// <param name="docname"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        public static bool UpLoadFtpPatientMzDoc(string XMLOut, string docname, string PatientId)
        {
            try
            {
                //return WebService.UploadPatientMzDoc(XMLOut, docname, PatientId);

                bool flaglocal = false;
                bool flagserver = false;
                //flagserver = WebService.UploadPatientMzDoc(XMLOut, docname, PatientId);
                if (!flagserver)
                {
                    //当保存服务器失败的情况下，就保存本地目录
                    flaglocal = SaveLocalDoc(XMLOut, docname, PatientId, true);
                }
                if (flagserver == true || flaglocal == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 从Ftp上获取文书
        /// </summary>
        /// <param name="docname">文书名称（文书主键加'xml' 例如“123.xml”）</param>
        /// <param name="PatientId">病人主键</param>
        /// <returns></returns>
        public static string DownLoadFtpPatientDoc(string docname, string PatientId)
        {

            string Docxml = "";
            string url = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + "/WebSite1/Patient_doc/" + PatientId + "/" + docname;
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            try
            {
                Docxml = wb.DownloadString(url);
            }
            catch
            {
            }
            try
            {
                if (Docxml.Trim() == "")
                {
                    //表示从服务器端没有读取到文书信息,然后从客户端读取
                    Docxml = ReadLocalDoc(docname, PatientId, false);
                    UploadFilesUnFinsheddoc = new Thread(new ThreadStart(UpLoadUnfinshDocs));
                    UploadFilesUnFinsheddoc.IsBackground = true;
                    UploadFilesUnFinsheddoc.Start();
                }
                return Docxml;
            }
            catch
            {
                return Docxml;
            }
        }

        /// <summary>
        /// 从Ftp上获取门诊文书
        /// </summary>
        /// <param name="docname">文书名称（文书主键加'xml' 例如“123.xml”）</param>
        /// <param name="PatientId">病人主键</param>
        /// <returns></returns>
        public static string DownLoadFtpPatientMzDoc(string docname, string PatientId)
        {
            try
            {
                string url = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + "/WebSite1/Patient_Mz_doc/" + PatientId + "/" + docname;
                WebClient wb = new WebClient();
                wb.Encoding = Encoding.UTF8;
                return wb.DownloadString(url);

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将文书保存本地临时目录
        /// </summary>
        /// <param name="XMLOut"></param>
        /// <param name="docname"></param>
        /// <param name="PatientId"></param>
        /// <param name="ismzflag">是否是门诊 true 是</param>
        /// <returns></returns>
        public static bool SaveLocalDoc(string XMLOut, string docname, string PatientId, bool ismzflag)
        {
            try
            {
                string docpath = App.SysPath + "\\TempReadXml";
                if (ismzflag)
                {
                    docpath = App.SysPath + "\\TempReadXmlMz";
                }
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                doc.LoadXml(XMLOut);
                if (!Directory.Exists(docpath + "\\" + PatientId))
                {
                    Directory.CreateDirectory(docpath + "\\" + PatientId);
                }
                doc.Save(docpath + "\\" + PatientId + "\\" + docname);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 读取保存本地临时目录中的文书
        /// </summary>
        /// <param name="XMLOut"></param>
        /// <param name="docname"></param>
        /// <param name="PatientId"></param>
        /// <param name="ismzflag">是否是门诊 true 是</param>
        /// <returns></returns>
        public static string ReadLocalDoc(string docname, string PatientId, bool ismzflag)
        {
            try
            {
                string docpath = App.SysPath + "\\TempReadXml" + "\\" + PatientId + "\\" + docname;
                if (ismzflag)
                {
                    docpath = App.SysPath + "\\TempReadXmlMz" + "\\" + PatientId + "\\" + docname;
                }
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                doc.Load(docpath);
                return doc.OuterXml;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 上传没有上传完的文书
        /// </summary>
        public static void UpLoadUnfinshDocs()
        {
            try
            {
                string docpath = App.SysPath + "\\TempReadXml";
                string[] Patients = Directory.GetDirectories(docpath);
                if (Patients != null)
                {
                    for (int i = 0; i < Patients.Length; i++)
                    {
                        string dirname = Patients[i].Split('\\')[Patients[0].Split('\\').Length - 1];
                        string[] fileids = Directory.GetFiles(docpath + "\\" + dirname);
                        for (int j = 0; j < fileids.Length; j++)
                        {
                            string filsname = fileids[j].Split('\\')[fileids[j].Split('\\').Length - 1];
                            XmlDocument doc = new XmlDocument();
                            doc.Load(docpath + "\\" + dirname + "\\" + filsname);
                            bool flagsuccess =false;//WebService.UploadPatientDoc(doc.OuterXml, filsname, dirname);
                            if (flagsuccess)
                            {
                                //如果上传成功删除本地文件
                                File.Delete(docpath + "\\" + dirname + "\\" + filsname);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 上传文书生成的图片
        /// </summary>
        /// <param name="Patient_id">病人主键</param>
        /// <param name="fileName">图片名称（例如：test.jpg,2.jpg等）</param>
        /// <returns></returns>
        public static void UploadDocImage()
        {
            try
            {
                //if (WebService == null)
                //{
                //    WebService = new Bifrost.WebReference.Service();
                //}
                //string docpath = App.SysPath + "\\temp";
                //string[] Patients = Directory.GetDirectories(docpath);
                //if (Patients != null)
                //{
                //    for (int i = 0; i < Patients.Length; i++)
                //    {
                //        string dirname = Patients[i].Split('\\')[Patients[0].Split('\\').Length - 1];
                //        string[] fileids = Directory.GetFiles(docpath + "\\" + dirname);
                //        for (int j = 0; j < fileids.Length; j++)
                //        {
                //            string filsname = fileids[j].Split('\\')[fileids[j].Split('\\').Length - 1];
                //            FileInfo imgFile = new FileInfo(SysPath + "\\temp\\" + dirname + "\\" + filsname);
                //            byte[] imgByte = new byte[imgFile.Length];//1.初始化用于存放图片的字节数组   
                //            System.IO.FileStream imgStream = imgFile.OpenRead();//2.初始化读取图片内容的文件流   
                //            imgStream.Read(imgByte, 0, Convert.ToInt32(imgFile.Length));//3.将图片内容通过文件流读取到字节数组   

                //            if (WebService.UploadDocImageFile(imgByte, dirname, filsname) == "上传成功")
                //            {
                //                //如果成功删除本地对应的图片
                //                File.Delete(docpath + "\\" + dirname + "\\" + filsname);
                //            }
                //        }
                //    }
                //}
            }
            catch
            {

            }
        }

        /// <summary>
        /// 创建ftp路径
        /// </summary>
        /// <param name="uploadUrl">创建ftp路径</param>   
        public static bool UpMakeDirectory(string uploadUrl, string uname, string password)
        {
            try
            {
                FtpWebResponse uploadResponse = null;
                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(new Uri(uploadUrl));
                uploadRequest.Credentials = new NetworkCredential(uname, password);
                uploadRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                uploadRequest.Proxy = null;
                uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                uploadResponse.Close();
                return true;

            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 目录是否存在
        /// </summary>
        /// <param name="uploadUrl">路径</param>
        /// <param name="uname">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool isHaveFtpDir(string uploadUrl, string uname, string password)
        {

            try
            {
                FtpWebResponse uploadResponse = null;
                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(new Uri(uploadUrl));
                uploadRequest.Credentials = new NetworkCredential(uname, password);
                uploadRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                uploadRequest.Proxy = null;
                uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断字符串中是否有SQL攻击代码，by fangbo.yu 2008.07.18
        /// 传入用户提交数据
        /// true-安全；false-有注入攻击现有；
        public static bool ProcessSqlStr(string inputString)
        {
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    string str_Regex = @"\b(" + SqlStr + @")\b";
                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    if (true == Regex.IsMatch(inputString))
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        /// 恢复被 过滤SQL字符。 
        public static string ReplacePageChar(string str)
        {
            if (str == String.Empty)
                return String.Empty;
            str = str.Replace("‘", "'");
            str = str.Replace("；", ";");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("＜", "<");
            str = str.Replace("＞", ">");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("＠", "@");
            str = str.Replace("＝", "=");
            str = str.Replace("＋", "+");
            str = str.Replace("＊", "*");
            str = str.Replace("＆", "&");
            str = str.Replace("＃", "#");
            str = str.Replace("％", "%");
            str = str.Replace("￥", "$");
            return str;
        }
        #endregion

        #region 内部私有函数
        ///// <summary>
        ///// 查询控件中的子控件，并对C1表格控件和其他一些控件的样式进行设置
        ///// </summary>
        ///// <param name="c">当前控件</param>
        //private static void GetControl(System.Windows.Forms.Control c)
        //{
        //    try
        //    {
        //        if (c is ButtonX)
        //        {
        //            ButtonX c1 = c as ButtonX;
        //            c1.Style = eDotNetBarStyle.Office2007;
        //            c1.ColorTable = eButtonColor.OrangeWithBackground;
        //            c1.Cursor = System.Windows.Forms.Cursors.Hand;
        //            c1.ForeColor = SystemColors.Highlight;
        //        }                
        //        if (c is System.Windows.Forms.Button)
        //        {                    
        //            c.Cursor = System.Windows.Forms.Cursors.Hand;										
        //        }
        //        if (c is System.Windows.Forms.Label)
        //        {
        //            c.BackColor=Color.Transparent;
        //        }
        //        if (c is System.Windows.Forms.TextBox)
        //        {
        //            TextBox c1 = c as TextBox;               
        //            c1.BorderStyle = BorderStyle.FixedSingle;                    
        //        }
        //        if (c is System.Windows.Forms.DateTimePicker)
        //        {
        //            DateTimePicker temp = (DateTimePicker)c;
        //            temp.Value = App.GetSystemTime();
        //        }
        //        else if(c is C1.Win.C1FlexGrid.C1FlexGrid)
        //        {
        //            C1.Win.C1FlexGrid.C1FlexGrid c1 = c as C1.Win.C1FlexGrid.C1FlexGrid;
        //            c1.BackColor = Color.White;
        //            c1.ForeColor = Color.Black;
        //            c1.Styles.Fixed.BackColor = Color.AliceBlue;
        //            c1.Styles.Highlight.BackColor = SystemColors.InactiveCaption;
        //            c1.Styles.Focus.BackColor = SystemColors.GradientInactiveCaption;                    
        //            c1.Styles.EmptyArea.BackColor = Color.White;
        //            c1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;    
        //            c1.Styles.Fixed.ForeColor=SystemColors.Desktop;
        //            c1.AllowEditing = true;                                  			
        //        }
        //        else if (c is System.Windows.Forms.DateTimePicker)
        //        {
        //            System.Windows.Forms.DateTimePicker c2 = c as DateTimePicker;
        //            if (c2.CustomFormat == "MM" || c2.CustomFormat == "yyyy-MM")
        //            {
        //                c2.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() +"-"+ DateTime.Now.Month.ToString()+"-1");
        //            }
        //        }
        //        else if (c is System.Windows.Forms.UserControl)
        //        {
        //            //c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
        //            c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));                  
        //        }
        //        else if (c is System.Windows.Forms.Form)
        //        {
        //            //c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244))))); 
        //            c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));                  
        //        }
        //        else if (c is System.Windows.Forms.GroupBox)
        //        {                   
        //        }
        //        else if (c is DevComponents.DotNetBar.Controls.GroupPanel)
        //        {                   
        //            DevComponents.DotNetBar.Controls.GroupPanel c1 = c as DevComponents.DotNetBar.Controls.GroupPanel;
        //            c1.ColorSchemeStyle = eDotNetBarStyle.Office2003;
        //            c1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244))))); ;
        //            c1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247))))); ;
        //            c1.Style.TextAlignment = eStyleTextAlignment.Near;
        //            c1.DrawTitleBox = false;
        //            c1.Style.TextColor = Color.Black;                    
        //        }
        //        else if (c is DevComponents.DotNetBar.TabControl)
        //        {                   
        //            DevComponents.DotNetBar.TabControl c1 = c as DevComponents.DotNetBar.TabControl;
        //            c1.Style = eTabStripStyle.Office2007Document;                  
        //            c1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
        //        }               
        //        if (c.Controls.Count > 0)
        //        {
        //            foreach (System.Windows.Forms.Control ch in c.Controls)
        //                GetControl(ch);
        //        }

        //    }
        //    catch
        //    {

        //    }
        //}

        /// <summary>
        /// 查询控件中的子控件，并对C1表格控件和其他一些控件的样式进行设置
        /// </summary>
        /// <param name="c">当前控件</param>
        private static void GetControl(System.Windows.Forms.Control c)
        {
            try
            {
                //c.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                if (c is ButtonX)
                {
                    ButtonX c1 = c as ButtonX;
                    c1.Style = eDotNetBarStyle.StyleManagerControlled;
                    c1.ColorTable = eButtonColor.OrangeWithBackground;
                    c1.Cursor = System.Windows.Forms.Cursors.Hand;
                    //c1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //c1.ForeColor = Color.White;
                }
                if (c is Label)
                {
                    //c.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
                if (c is System.Windows.Forms.Button)
                {
                    c.Cursor = System.Windows.Forms.Cursors.Hand;
                }
                if (c is System.Windows.Forms.Label)
                {
                    c.BackColor = Color.Transparent;
                }
                if (c is System.Windows.Forms.TextBox)
                {
                    TextBox c1 = c as TextBox;
                    c1.BorderStyle = BorderStyle.FixedSingle;

                    //c1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                }
                if (c is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    DevComponents.DotNetBar.Controls.TextBoxX c1 = c as DevComponents.DotNetBar.Controls.TextBoxX;
                    c1.BorderStyle = BorderStyle.None;
                    //c1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                }
                if (c is System.Windows.Forms.DateTimePicker)
                {
                    DateTimePicker temp = (DateTimePicker)c;
                    temp.Value = App.GetSystemTime();
                }
                else if (c is System.Windows.Forms.DataGridView)
                {
                    DataGridView temp = (DataGridView)c;
                    temp.BackgroundColor = Color.White;
                    GridAction.SetGridStyle(c);
                    //temp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
                else if (c is DevComponents.DotNetBar.ExpandableSplitter)
                {
                    DevComponents.DotNetBar.ExpandableSplitter temp = (DevComponents.DotNetBar.ExpandableSplitter)c;
                    //temp.Style = eSplitterStyle.;
                }
                else if (c is C1.Win.C1FlexGrid.C1FlexGrid)
                {
                    C1.Win.C1FlexGrid.C1FlexGrid c1 = c as C1.Win.C1FlexGrid.C1FlexGrid;
                    c1.BackColor = Color.White;
                    c1.ForeColor = Color.Black;
                    //c1.Styles.Fixed.BackColor = Color.AliceBlue;
                    c1.Styles.Highlight.BackColor = SystemColors.InactiveCaption;
                    c1.Styles.Focus.BackColor = SystemColors.GradientInactiveCaption;
                    c1.Styles.EmptyArea.BackColor = Color.White;
                    c1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
                    c1.Styles.Fixed.ForeColor = SystemColors.Desktop;
                    c1.Styles.Fixed.BackColor = Color.White;
                    c1.AllowEditing = true;
                    //c1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    GridAction.SetGridStyle(c);
                }
                else if (c is System.Windows.Forms.DateTimePicker)
                {
                    System.Windows.Forms.DateTimePicker c2 = c as DateTimePicker;
                    if (c2.CustomFormat == "MM" || c2.CustomFormat == "yyyy-MM")
                    {
                        c2.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-1");
                    }
                }
                else if (c is System.Windows.Forms.UserControl)
                {
                    ////c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
                    //c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));                  
                }
                else if (c is System.Windows.Forms.Form)
                {
                    ////c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244))))); 
                    //c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));                  
                }
                else if (c is DevComponents.DotNetBar.Office2007Form)
                {
                    DevComponents.DotNetBar.Office2007Form fc =c as DevComponents.DotNetBar.Office2007Form;
                    fc.TopLeftCornerSize = 0;
                    fc.TopRightCornerSize = 0;
                }
                else if (c is System.Windows.Forms.GroupBox)
                {
                    System.Windows.Forms.GroupBox c1 = c as System.Windows.Forms.GroupBox;
                    c1.BackColor = Color.Transparent;

                }
                else if (c is DevComponents.DotNetBar.Controls.GroupPanel)
                {
                    DevComponents.DotNetBar.Controls.GroupPanel c1 = c as DevComponents.DotNetBar.Controls.GroupPanel;
                    //c1.ColorSchemeStyle = eDotNetBarStyle.Office2003;
                    //c1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244))))); ;
                    //c1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247))))); ;
                    c1.Style.TextAlignment = eStyleTextAlignment.Near;
                    c1.DrawTitleBox = false;
                    c1.Style.TextColor = Color.Black;
                }
                else if (c is DevComponents.DotNetBar.TabControl)
                {
                    DevComponents.DotNetBar.TabControl c1 = c as DevComponents.DotNetBar.TabControl;
                    c1.Style = eTabStripStyle.Flat;
                    //c1.Font = new Font("宋体", 9);
                    //c1.SelectedTabFont= new Font("宋体", 9);
                    //c1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
                }
                if (c.Controls.Count > 0)
                {
                    foreach (System.Windows.Forms.Control ch in c.Controls)
                        GetControl(ch);
                }

            }
            catch
            {

            }
        }


        /// <summary>
        /// 查询控件中的子控件，并对C1表格控件和其他一些控件的样式进行设置
        /// </summary>
        /// <param name="c">当前控件</param>
        private static void SetSqlsControl(System.Windows.Forms.Control c)
        {
            try
            {
                if (c is TextBox)
                {
                    TextBox c1 = c as TextBox;
                    c1.Text = ReplaceSQLChar(c1.Text);
                }
                else if (c is RichTextBox)
                {
                    RichTextBox c1 = c as RichTextBox;
                    c1.Text = ReplaceSQLChar(c1.Text);
                }
                else if (c is ComboBox)
                {
                    ComboBox c1 = c as ComboBox;
                    c1.Text = ReplaceSQLChar(c1.Text);
                }
                if (c.Controls.Count > 0)
                {
                    foreach (System.Windows.Forms.Control ch in c.Controls)
                        SetSqlsControl(ch);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 开启进度条服务
        /// </summary>
		private static void StartProgressServerice()
        {
            try
            {
                timedProgress = new Thread(new ThreadStart(App.MonoProc));
                //timedProgress.IsBackground = true;
                timedProgress.Priority = ThreadPriority.Highest;
                timedProgress.Start();
            }
            catch
            {

            }
        }


        /// <summary>
        /// 进度条
        /// </summary>
        private static void MonoProc()
        {
            FrmProgress objFrmProgress = new FrmProgress();
            objFrmProgress.label1.Text = progressmsg;
            objFrmProgress.ShowDialog();
        }

        /// <summary>
        /// 设置主界面信息栏中的信息
        /// </summary>
        /// <param name="val"></param>
        /// <param name="tools"></param>
        /// <returns></returns>
        private static bool SetMainFrmMsgToolText(string val, SubItemsCollection tools)
        {
            for (int i = 0; i < tools.Count; i++)
            {
                if (tools[i].GetType().ToString().Contains("LabelItem"))
                {
                    LabelItem temp = (LabelItem)tools[i];
                    if (temp.Name == "toolStripLabel")
                    {
                        temp.Text = val;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 将表转换成数据集
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static DataSet CreateDataSet(Type t)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            PropertyInfo[] pis = t.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                DataColumn dc;
                try
                {
                    if (pi.PropertyType.ToString().Contains("System.Nullable") == false)
                    {
                        dc = new DataColumn(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        dc = new DataColumn(pi.Name, typeof(string));
                    }
                    dt.Columns.Add(dc);
                }
                catch { }
            }
            return ds;
        }



        /// <summary>
        /// 将对象数组填充到数据集        
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="objArr">对象数组</param>
        /// <returns></returns>
        private static DataSet FillDataSet(DataSet ds, object[] objArr)
        {
            DataColumnCollection dcs = ds.Tables[0].Columns;
            Type t = objArr[0].GetType();
            foreach (object obj in objArr)
            {
                DataRow dr = ds.Tables[0].NewRow();
                for (int i = 0; i < dcs.Count; i++)
                {
                    dr[i] = t.InvokeMember(dcs[i].ColumnName, BindingFlags.GetProperty, null, obj, null);
                }
                ds.Tables[0].Rows.Add(dr);
            }
            return ds;
        }

        /// <summary>
        /// 属性转换 Bifrost.WebReference.OracleParameter类型和DBParameter之间的类型转换
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="pmet"></param>
        private static void getMySqlTypeProperty(MySqlDBParameter Parameter, ref MySqlSDBParameter pmet)
        {
            if (Parameter.DBType == MySqlDbType.Decimal)
            {
                pmet.DBType = MySqlDbType.Decimal;
            }
            else if (Parameter.DBType == MySqlDbType.VarChar)
            {
                pmet.DBType = MySqlDbType.VarChar;
            }
            else if (Parameter.DBType == MySqlDbType.Blob)
            {
                pmet.DBType = MySqlDbType.Blob;
            }
            else if (Parameter.DBType == MySqlDbType.Text)
            {
                pmet.DBType = MySqlDbType.Text;
            }         
            else if (Parameter.DBType == MySqlDbType.DateTime)
            {
                pmet.DBType = MySqlDbType.DateTime;
            }
            else if (Parameter.DBType == MySqlDbType.Timestamp)
            {
                pmet.DBType = MySqlDbType.Timestamp;
            }
        }


        /// <summary>
        /// 判断该类单例文书是否已经存在
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">病人id</param>
        /// <returns></returns>
        private static string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "'";
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
        }

        /// <summary>
        /// 更新模板库
        /// </summary>
        private static void UpdateTemplateDB()
        {
            string strCon = "provider=microsoft.jet.oledb.4.0;";
            strCon += @"data source=" + SysPath + "\\TemplatContent.db";  //e:\sjk.mdb
            OleDbConnection con = new OleDbConnection(strCon);
            con.Open();
            con.Close();
        }


        /// <summary>
        /// 获取当前所处的分院
        /// </summary>
        /// <param name="serverlist">分院列表</param>
        /// <returns>返回0 为失败</returns>
        private static int GetCurrentHospitalId(string[] serverlist)
        {
            try
            {
                if (serverlist != null)
                {
                    if (serverlist[0].Trim() != "")
                    {
                        return Convert.ToInt16(serverlist[0].Split(',')[1]);
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private static void page_Click(object sender, EventArgs e)
        {

            if (tabMain.Tabs.Count > 0)
            {
                tabMain.AutoCloseTabs = false;
                TabItem item = (TabItem)sender;
                //Point mp = Cursor.Position;
                MouseEventArgs mp = (MouseEventArgs)e;
                Point pTab = item.CloseButtonBounds.Location;
                if (mp.X >= pTab.X && mp.X <= pTab.X + item.CloseButtonBounds.Width && mp.Y >= pTab.Y &&
                    mp.Y <= pTab.Y + item.CloseButtonBounds.Height)
                {
                    if (Ask("确定要关闭'" + item.Text + "'"))
                        tabMain.Tabs.Remove(item);
                }
            }
        }


        /// <summary>
        /// 获取天数
        /// </summary>
        private static int GetDay(int month, int year)
        {
            int day = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    day = 31;
                    break;
                case 2:

                    //闰年天，平年天

                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    {
                        day = 29;
                    }
                    else
                    {
                        day = 28;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    day = 30;
                    break;
            }
            return day;
        }
        #endregion

        #region 内部公有函数
        /// <summary>
        /// 获取Excel文件中的表名
        /// </summary>
        /// <param name="ExcelFileName">Excel文件的路径</param>
        /// <param name="cmbTableName">Excel中的表名</param>
        internal static void GetExcelTableName(string ExcelFileName, ComboBox cmbTableName)
        {
            OleDbConnection oledbconn1 = new OleDbConnection();
            try
            {
                oledbconn1.ConnectionString = "provider=Microsoft.Jet.OLEDB.4.0;data source=" + ExcelFileName + ";Extended Properties=Excel 8.0;Persist Security Info=False";
                oledbconn1.Open();
                DataTable dt = oledbconn1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                foreach (DataRow dr in dt.Rows)
                {
                    string strTableName = (String)dr["TABLE_NAME"];
                    cmbTableName.Items.Add(strTableName.Remove(strTableName.Length - 1, 1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel文件不能被打开！", "错误:" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (oledbconn1.State == ConnectionState.Open)
                    oledbconn1.Close();
            }

        }
        #endregion
        /// <summary>
        /// 获取历史文书的HTML访问路径
        /// </summary>
        /// <param name="patient_Id">文书索引表mr_file_index中的patient_id</param>
        /// <param name="fileName">文书索引表mr_file_index中的file_name</param>
        /// <returns>html路径</returns>
        public static string GetHtmlUrl(string patient_Id, string fileName)
        {
            //string url = "";
            //try
            //{
            //    if (patient_Id != "" && fileName != "")
            //    {
            //        if (linkFormat == "0")
            //        {

            //            if (RegeditRemotingChanel())
            //            {
            //                url = Operater.GetHtmlUrl(patient_Id, fileName);
            //            }
            //            return url;
            //        }
            //    }
            //    else
            //    {
            return "";
            //    }
            //    return url;
            //}
            //catch (Exception ex)
            //{
            //    return url;
            //    throw ex;
            //}

        }

        /// <summary>
        /// 病人住院号
        /// </summary>
        /// <param name="Pid"></param>
        public static void GetListDatas(string Pid)
        {
            //WebReference_List.LISService LIS = new WebReference_List.LISService();           
            //string GetOrders = "";      //标本信息表(LIS_SampleInfo)-根据[住院号]获得信息-t_lis_sample
            //string GetReport = "";      //检验结果表(LIS_Result)-根据[标本流水号]获得信息-t_lis_result
            //string[] samples=null;
            //string[] reports=null;
            //List<string> sqls = new List<string>();
            //string isNull = null;            
            //try
            //{
            //    /*
            //     * 样本表
            //     */
            //    isNull = LIS.GetOrders(Pid);
            //    if (isNull != null)
            //    {
            //        samples = isNull.Split('@');
            //    }
            //    sqls.Add("delete from t_lis_result a where a.bblsh in (select t.bblsh from t_lis_sample t where t.mzh=" + Pid + ")");
            //    sqls.Add("delete from t_lis_sample t where t.mzh="+Pid+"");
            //    for (int n = 0; n < samples.Length; n++)
            //    {
            //        string[] sample = samples[n].Split('^');
            //        if (sample.Length > 11)
            //        {
            //            GetOrders = "insert into t_lis_sample(BBLSH,MZH,XM,NL,JYRQ,SFZH,BBDM,BBMC,JYRDM,JYRMC) " +
            //                                   "values('{0}','{1}','{2}','{3}',to_timestamp('{4}','yyyy-MM-dd hh24:mi:ss'),'{5}','{6}','{7}','{8}','{9}')";
            //            GetOrders = string.Format(GetOrders, sample[0], sample[11], sample[5], sample[8], sample[2]
            //                                   , sample[13], sample[17],sample[16] , sample[35], sample[35]);
            //            sqls.Add(GetOrders);
            //        }


            //        /*
            //         *检验结果表
            //         */
            //        isNull = LIS.GetReport(sample[0]);

            //        if (isNull != null)
            //        {
            //            reports = isNull.Split('@');
            //            for (int m = 0; m < reports.Length; m++)
            //            {
            //                string[] report = reports[m].Split('^');
            //                if (report.Length > 11)
            //                {
            //                    GetReport = "insert into t_lis_result(BBLSH,XMDM,XMMC,XMYWMC,XMJG,JGDW,CKZ,CSSJ,JGBZ,YZXMMC) " +
            //                                     " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
            //                    GetReport = string.Format(GetReport, sample[0], report[4],
            //                                            ReplaceSQLChar(report[5]),
            //                                            ReplaceSQLChar(report[6]),
            //                                            ReplaceSQLChar(report[7]),
            //                                            report[10], report[9], report[8], report[11], report[12]);
            //                    sqls.Add(GetReport);
            //                }
            //            }
            //        }
            //    }

            //    if (ExecuteBatch(sqls.ToArray()) == 0)
            //    {
            //        MsgErr("读取数据失败！");
            //    }                             

            //}
            //catch (Exception ex)
            //{               
            //    MsgErr("读取数据失败！"+ex.Message);
            //}

        }

        #region 语音识别

        private static string session_begin_params;
        private static WaveIn waveIn;
        private static AudioRecorder recorder;
        private static float lastPeak;//说话音量
        private static float secondsRecorded;
        private static float totalBufferLength;
        private static int Ends = 5;
        private const int BUFFER_SIZE = 4096;
        private static List<VoiceData> VoiceBuffer = new List<VoiceData>();
        public static List<string> TextBuffer = new List<string>();
        /// <summary>
        /// 指针转字符串
        /// </summary>
        /// <param name="p">指向非托管代码字符串的指针</param>
        /// <returns>返回指针指向的字符串</returns>
        private static string PtrToStr(IntPtr p)
        {
            List<byte> lb = new List<byte>();
            try
            {
                while (Marshal.ReadByte(p) != 0)
                {
                    lb.Add(Marshal.ReadByte(p));
                    p = new IntPtr(p.ToInt64() + 1);
                }
            }
            catch (AccessViolationException ex)
            {
                insertText(String.Format(ex.Message));
            }
            return Encoding.UTF8.GetString(lb.ToArray());
        }
        private static bool btext = false;
        public static string readText()
        {
            if (TextBuffer.Count > 0)
            {
                while (true)
                {
                    if (btext)
                        Thread.Sleep(100);
                    else
                    {
                        string str = string.Empty;
                        btext = true;
                        str = TextBuffer[TextBuffer.Count - 1];
                        TextBuffer.RemoveAt(TextBuffer.Count - 1);
                        btext = false;
                        return str;
                    }
                }
            }
            else
                return string.Empty;
        }
        public static void insertText(string text)
        {

            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            //if (this.textBox1.InvokeRequired)
            /*if (textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.AppendText(text + "\n");
                this.textBox1.Refresh();
            }*/
            //this.textBox1.AppendText(text + "\n");
            while (true)
            {
                if (btext)
                    Thread.Sleep(100);
                else
                {
                    btext = true;
                    if (TextBuffer.Count > 1000)
                        TextBuffer.Clear();
                    TextBuffer.Insert(0, text);
                    btext = false;
                    return;
                }
            }
        }


        private static void InitializationSpeech()
        {
            SpeechRecognition();
            totalBufferLength = 0;
            recorder = new AudioRecorder();
            recorder.BeginMonitoring(-1);
            recorder.SampleAggregator.MaximumCalculated += OnRecorderMaximumCalculated;

            waveIn = new WaveIn();
            //newWaveIn.WaveFormat = new WaveFormat(16000, 16, 1); // 16bit,16KHz,Mono的录音格式
            waveIn.WaveFormat = new WaveFormat(16000, 1);//16bit,1KHz 的录音格式
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;
           
            waveIn.WaveFormat = new WaveFormat(16000, 1);
        }

        //语音识别
        private static void RunIAT(List<VoiceData> VoiceBuffer, string session_begin_params)
        {
            IntPtr session_id = IntPtr.Zero;
            string rec_result = string.Empty;
            string hints = "正常结束";
            AudioStatus aud_stat = AudioStatus.ISR_AUDIO_SAMPLE_CONTINUE;
            EpStatus ep_stat = EpStatus.ISR_EP_LOOKING_FOR_SPEECH;
            RecogStatus rec_stat = RecogStatus.ISR_REC_STATUS_SUCCESS;
            int errcode = (int)ErrorCode.MSP_SUCCESS;

            session_id = MSCDLL.QISRSessionBegin(null, session_begin_params, ref errcode);
            if ((int)ErrorCode.MSP_SUCCESS != errcode)
            {
                insertText("\nQISRSessionBegin failed! error code:" + errcode);
                return;
            }

            for (int i = 0; i < VoiceBuffer.Count; i++)
            {
                aud_stat = AudioStatus.ISR_AUDIO_SAMPLE_CONTINUE;
                if (i == 0)
                    aud_stat = AudioStatus.ISR_AUDIO_SAMPLE_FIRST;
                errcode = MSCDLL.QISRAudioWrite(PtrToStr(session_id), VoiceBuffer[i].data, (uint)VoiceBuffer[i].data.Length, aud_stat, ref ep_stat, ref rec_stat);
                if ((int)ErrorCode.MSP_SUCCESS != errcode)
                {
                    MSCDLL.QISRSessionEnd(PtrToStr(session_id), null);
                }
            }

            errcode = MSCDLL.QISRAudioWrite(PtrToStr(session_id), null, 0, AudioStatus.ISR_AUDIO_SAMPLE_LAST, ref ep_stat, ref rec_stat);
            if ((int)ErrorCode.MSP_SUCCESS != errcode)
            {
                insertText("\nQISRAudioWrite failed! error code:" + errcode);
                return;
            }

            while (RecogStatus.ISR_REC_STATUS_SPEECH_COMPLETE != rec_stat)
            {
                IntPtr rslt = MSCDLL.QISRGetResult(PtrToStr(session_id), ref rec_stat, 0, ref errcode);
                if ((int)ErrorCode.MSP_SUCCESS != errcode)
                {
                    insertText("\nQISRGetResult failed, error code: " + errcode);
                    break;
                }
                if (IntPtr.Zero != rslt)
                {
                    string tempRes = PtrToStr(rslt);

                    rec_result = rec_result + tempRes;
                    if (rec_result.Length >= BUFFER_SIZE)
                    {
                        insertText("\nno enough buffer for rec_result !\n");
                        break;
                    }
                }

            }
            int errorcode = MSCDLL.QISRSessionEnd(PtrToStr(session_id), hints);

            //语音识别结果
            if (rec_result.Length != 0)
            {

                insertText(rec_result);


                //返回错误代码10111时，可调用SpeechRecognition()函数执行MSPLogin
            }
        }
        /// <summary>
        /// 开始录音回调函数       保存截获到的声音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            totalBufferLength += e.Buffer.Length;
            secondsRecorded = (float)(totalBufferLength / 32000);

            VoiceData data = new VoiceData();
            for (int i = 0; i < 3200; i++)
            {
                data.data[i] = e.Buffer[i];
            }
            VoiceBuffer.Add(data);

            if (lastPeak < 20)
                Ends = Ends - 1;
            else
                Ends = 5;

            if (Ends == 0)
            {
                if (VoiceBuffer.Count > 5)
                {
                    RunIAT(VoiceBuffer, session_begin_params);//调用语音识别
                }

                VoiceBuffer.Clear();
                Ends = 5;
            }

        }
        /// <summary>
        /// 录音结束回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnRecordingStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                /* MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                               e.Exception.Message));*/
                Console.WriteLine("A problem was encountered during recording {0}", e.Exception.Message);
            }
        }
        public static void SpeechRecognition()//初始化语音识别
        {
            int ret = (int)ErrorCode.MSP_SUCCESS;
            string login_params = string.Format("appid=5afa74fa,word_dir= . ");//appid和msc.dll要配套
            #region 参数
            /*
            *sub:本次识别请求的类型  iat 连续语音识别;   asr 语法、关键词识别,默认为iat
            *domain:领域      iat：连续语音识别  asr：语法、关键词识别    search：热词   video：视频    poi：地名  music：音乐    默认为iat。 注意：sub=asr时，domain只能为asr
            *language:语言    zh_cn：简体中文  zh_tw：繁体中文  en_us：英文    默认值：zh_cn
            *accent:语言区域    mandarin：普通话    cantonese：粤语    lmz：四川话 默认值：mandarin
            *sample_rate:音频采样率  可取值：16000，8000  默认值：16000   离线识别不支持8000采样率音频
            *result_type:结果格式   可取值：plain，json  默认值：plain
            *result_encoding:识别结果字符串所用编码格式  GB2312;UTF-8;UNICODE    不同的格式支持不同的编码：   plain:UTF-8,GB2312  json:UTF-8
            */
            #endregion
            session_begin_params = "sub=iat,domain=iat,language=zh_cn,accent=mandarin,sample_rate=16000,result_type=plain,result_encoding=utf8";

            string Username = "";
            string Password = "";
            ret = MSCDLL.MSPLogin(Username, Password, login_params);

            if ((int)ErrorCode.MSP_SUCCESS != ret)//不成功
            {
                //Console.WriteLine("失败了");
                Console.WriteLine("MSPLogin failed,error code:{0}", ret.ToString());
                MSCDLL.MSPLogout();
            }
        }
        private static WaveIn CreateWaveInDevice()//WaveIn实例化
        {
            WaveIn newWaveIn = new WaveIn();
            //newWaveIn.WaveFormat = new WaveFormat(16000, 16, 1); // 16bit,16KHz,Mono的录音格式
            newWaveIn.WaveFormat = new WaveFormat(16000, 1);//16bit,1KHz 的录音格式
            newWaveIn.DataAvailable += OnDataAvailable;
            newWaveIn.RecordingStopped += OnRecordingStopped;
            return newWaveIn;
        }
        private static void OnRecorderMaximumCalculated(object sender, MaxSampleEventArgs e)
        {
            lastPeak = Math.Max(e.MaxSample, Math.Abs(e.MinSample)) * 100;
        }
                
        public static void StartRecording()
        {
            try
            {
                if (waveIn == null)
                {
                    InitializationSpeech();
                    waveIn.StartRecording();
                }
                TextBuffer.Clear();
            }
            catch(Exception ee)
            { }
        }
        //public static void StopRecording()
        //{
        //    try
        //    {
        //        if (waveIn != null)
        //        {
        //            waveIn.StopRecording();//停止录音
        //        }
        //    }
        //    catch (Exception ee)
        //    { }
        //}

            #endregion

        }

    /// <summary>
    /// 记录列的信息
    /// </summary>
    public struct ColumnInfo
    {   
        /// <summary>
        /// 列的名称
        /// </summary>
        public string Name;
        
        /// <summary>
        ///字段名 
        /// </summary>
        public string Field;    
        
        /// <summary>
        /// 字段在网格中的位置
        /// </summary>
        public int Index;

        /// <summary>
        /// 列是否可见
        /// </summary>
        public bool visible;
    }

    //硬件Win32_Processor ,Win32_PhysicalMemory,Win32_DiskDrive,Win32_BaseBoard,Win32_BIOS,Win32_ParallelPort,Win32_SerialPort,Win32_SystemSlot, Win32_USBController,Win32_DesktopMonitor, Win32_DisplayConfiguration,Win32_DisplayControllerConfiguration
    #region WMIPath   
    public enum WMIPath
    {
        // 硬件  
        Win32_Processor, // CPU 处理器  
        Win32_PhysicalMemory, // 物理内存条  
        Win32_Keyboard, // 键盘  
        Win32_PointingDevice, // 点输入设备，包括鼠标。  
        Win32_FloppyDrive, // 软盘驱动器  
        Win32_DiskDrive, // 硬盘驱动器  
        Win32_CDROMDrive, // 光盘驱动器  
        Win32_BaseBoard, // 主板  
        Win32_BIOS, // BIOS 芯片  
        Win32_ParallelPort, // 并口  
        Win32_SerialPort, // 串口  
        Win32_SerialPortConfiguration, // 串口配置  
        Win32_SoundDevice, // 多媒体设置，一般指声卡。  
        Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)  
        Win32_USBController, // USB 控制器  
        Win32_NetworkAdapter, // 网络适配器  
        Win32_NetworkAdapterConfiguration, // 网络适配器设置  
        Win32_Printer, // 打印机  
        Win32_PrinterConfiguration, // 打印机设置  
        Win32_PrintJob, // 打印机任务  
        Win32_TCPIPPrinterPort, // 打印机端口  
        Win32_POTSModem, // MODEM  
        Win32_POTSModemToSerialPort, // MODEM 端口  
        Win32_DesktopMonitor, // 显示器  
        Win32_DisplayConfiguration, // 显卡  
        Win32_DisplayControllerConfiguration, // 显卡设置  
        Win32_VideoController, // 显卡细节。  
        Win32_VideoSettings, // 显卡支持的显示模式。  

        // 操作系统  
        Win32_TimeZone, // 时区  
        Win32_SystemDriver, // 驱动程序  
        Win32_DiskPartition, // 磁盘分区  
        Win32_LogicalDisk, // 逻辑磁盘  
        Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。  
        Win32_LogicalMemoryConfiguration, // 逻辑内存配置  
        Win32_PageFile, // 系统页文件信息  
        Win32_PageFileSetting, // 页文件设置  
        Win32_BootConfiguration, // 系统启动配置  
        Win32_ComputerSystem, // 计算机信息简要  
        Win32_OperatingSystem, // 操作系统信息  
        Win32_StartupCommand, // 系统自动启动程序  
        Win32_Service, // 系统安装的服务  
        Win32_Group, // 系统管理组  
        Win32_GroupUser, // 系统组帐号  
        Win32_UserAccount, // 用户帐号  
        Win32_Process, // 系统进程  
        Win32_Thread, // 系统线程  
        Win32_Share, // 共享  
        Win32_NetworkClient, // 已安装的网络客户端  
        Win32_NetworkProtocol, // 已安装的网络协议  
    }
    #endregion 

    public sealed class WMI
    {
        private ArrayList mocs;
        private StringDictionary names; // 用来存储属性名，便于忽略大小写查询正确名称。  

        /// <summary>  
        /// 信息集合数量  
        /// </summary>  
        public int Count
        {
            get { return mocs.Count; }
        }

        /// <summary>  
        /// 获取指定属性值，注意某些结果可能是数组。  
        /// </summary>  
        public object this[int index, string propertyName]
        {
            get
            {
                try
                {
                    string trueName = names[propertyName.Trim()]; // 以此可不区分大小写获得正确的属性名称。  
                    Hashtable h = (Hashtable)mocs[index];
                    return h[trueName];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>  
        /// 返回所有属性名称。  
        /// </summary>  
        /// <param name="index"></param>  
        /// <returns></returns>  
        public string[] PropertyNames(int index)
        {
            try
            {
                Hashtable h = (Hashtable)mocs[index];
                string[] result = new string[h.Keys.Count];

                h.Keys.CopyTo(result, 0);

                Array.Sort(result);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>  
        /// 返回测试信息。  
        /// </summary>  
        /// <returns></returns>  
        public string Test()
        {
            try
            {
                StringBuilder result = new StringBuilder(1000);

                for (int i = 0; i < Count; i++)
                {
                    int j = 0;
                    foreach (string s in PropertyNames(i))
                    {
                        result.Append(string.Format("{0}:{1}={2}\n", ++j, s, this[i, s]));

                        if (this[i, s] is Array)
                        {
                            Array v1 = this[i, s] as Array;
                            for (int x = 0; x < v1.Length; x++)
                            {
                                result.Append("\t" + v1.GetValue(x) + "\n");
                            }
                        }
                    }
                    result.Append("======WMI=======\n");
                }

                return result.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="path"></param>  
        public WMI(string path)
        {
            names = new StringDictionary();
            mocs = new ArrayList();

            try
            {
                ManagementClass cimobject = new ManagementClass(path);
                ManagementObjectCollection moc = cimobject.GetInstances();

                bool ok = false;
                foreach (ManagementObject mo in moc)
                {
                    Hashtable o = new Hashtable();
                    mocs.Add(o);

                    foreach (PropertyData p in mo.Properties)
                    {
                        o.Add(p.Name, p.Value);
                        if (!ok) names.Add(p.Name, p.Name);
                    }

                    ok = true;
                    mo.Dispose();
                }
                moc.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="path"></param>  
        public WMI(WMIPath path)
            : this(path.ToString())
        {
        }
    }

    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;// Size of receive buffer.
        public const int BufferSize = 256;// Receive buffer.
        public byte[] buffer = new byte[BufferSize];// Received data string.
        public StringBuilder sb = new StringBuilder();
    }
}
