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
    /// ��ܹ���������  
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2009-9-10
    /// </summary>    
	public class App
    {

        /*
         *˵����
         *    ��ƹ������������ҪĿ����Ϊ���������Ŀ���Ч�ʣ��Լ��������ģ��֮���ͳһ�ԡ�
         * ��һЩ���õķ����Լ����ݿ⡢�����������ӵȽ���ͳһ�ķ�װ�͹�������ϵͳ����֮���ż���ԣ�
         * Ϊ����ά�������ṩ���㣬����ά���ɱ���111111    
         */


        //����INI�ļ���д��������WritePrivateProfileString()
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //����INI�ļ��Ķ���������GetPrivateProfileString()
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        private static Thread timedProgress;
        private static string progressmsg;

        public static Thread SendtoServerMes;
        public static string ReceiveServerMsg;

        /// <summary>
        /// �ϴ�δ��ɵ�����
        /// </summary>
        public static Thread UploadFilesUnFinsheddoc;


        /// <summary>
        /// ����ǰ·��
        /// </summary>
        public static string SysPath = Directory.GetCurrentDirectory();

        private static string stat;

        //��ǰӦ�ó����·��             
        private static string apppath;
       
        //�ж��Ƿ��Ѿ����й��˳�ʼ������
        private static bool startflag = false;

        // ��ǰ��ѷ�����       
        private static string IpPort = "";


        // ��ѷ������ĵ�ַ        
        private static string BestIp = "";
        private static string lujin = "";

        // ���з�������IP�Ͷ˿ں��б�         
        public static string[] ServerList;

        //��������ҽԺ������ֵ��ȡ�ķ�������IP�Ͷ˿ں��б�
        public static string[] ServerList2;

        //��ǰϵͳ�İ汾��
        public static string ProgrameVersion = "";

        // ���ӷ�ʽ              
        public static string linkFormat = "0";

        // ������ѯ�б�         
        private static frmCodeSelect uccodeselect = new frmCodeSelect();

        // ���ڴ�ſ�����ѯ���       
        public static Class_SelectObj SelectObj = null;

        // �����ѯ�Ƿ���� true���� falseδ����        
        public static bool FastCodeFlag = false;

        // ��¼�򿪴���Ĳ��裨dll��+������+�������ͣ�       
        public static ArrayList Openforms;

        /// <summary>
        /// �������˵�һЩ������Ϣ��������
        /// </summary>
        public static string ServiceOpersXml = "";

        // Excel�ļ���·��      
        public static string ExcelFileName = "";

        // Excel�еı���       
        public static string tableName = "";

        /// <summary>
        /// ·���û�
        /// </summary>
        public static string EcpUser = "newecp.";
        /// <summary>
        /// BI�û�
        /// </summary>
        public static string BIUser = "bisj.";

        /// <summary>
        /// �����¼��ģ��ѡ������
        /// </summary>
        public static string NurseResault = "";

        // ǩ�������һЩ��Ϣ       
        internal static Class_DocSign DocSign;

        // ��ȡ��ǰ��¼�û����ʺ�        
        public static Class_Account UserAccount;

        // ��ǰ������ı���      
        public static string MdiFormTittle = "";

        // ��ǰ�����������        
        public static Form ParentForm = null;

        /// <summary>
        /// Remotingӳ���࣬������Ҫ������
        /// ��ʹ�ɻ�����������˽���ӳ���ϵ���Ӷ��������ݿ�Ĳ�����
        /// </summary>
        public static DbHelp Operater = null;
        public static DbHelp Operater2 = null;

        // ҽԺ����      
        public static string HospitalTittle = "";

        // ������Ľ��      
        public static string LisResault = "";

        //ҽ�����
        public static string His_Yz_Resault = "";

        //Pasc�Ľ��
        public static string PascResault = "";

        // ��Ϣ��ʾ��       
        private static AlertCustom m_AlertOnLoad = null;

        private static FtpWebRequest reqFTP;

        /// <summary>
        /// ��������������
        /// </summary>
        public static DevComponents.DotNetBar.TabControl tabMain;

        /// <summary>
        /// �������Ĺ�����
        /// </summary>
        public static DevComponents.DotNetBar.RibbonBar MainToolBar;

        /// <summary>
        /// �ܴ�ҽ������б�
        /// </summary>
        public static Control ucRecord;

        // RoleFlag   0--Ĭ������Ȩ�޶���ʹ��  1--Ĭ������Ȩ�޶�����ʹ��       
        private static string Roleflag;

        // Refreshflag 0--�༭���еĸ���ճ������  1--���Ʋ�������  
        public static string Refreshflag;

        //�ϼ�ҽʦ�鷿ʱ��
        public static string CurrentUpdateTime = "";

        //�ϼ�ҽʦ�鷿����
        public static string CurrentUpdateContent = "";

        //�ϼ�ҽʦ�鷿ID
        public static string CurrentHightDoctorId = "";

        /// <summary>
        /// ��ǰ�򿪵���������
        /// </summary>
        public static ArrayList OperaterDocIdS = new ArrayList();

        /// <summary>
        /// ��ǰ�����ķ�Ժ
        /// </summary>
        public static int CurrentHospitalId = 0;

        /// <summary>
        /// ��ǰѡ�е�Remoting��ַ
        /// </summary>
        public static string remotingIp = "";

        /// <summary>
        /// ��Ժʹ�������б�
        /// </summary>
        public static string[] HosptalIds;

        /// <summary>
        /// ����ϵͳ���ñ�־  true ��  false ��
        /// </summary>
        public static bool isOtherSystemRefrenceflag = false;
        public static string OtherSystemAccount = "";
        public static string OtherSystemHisId = "";
        public static string OtherSystemDept = "";             //����ϵͳ�ı�־ D ���� N ����  + ����

        //Pasc�Ľ��(Ӱ��ѧ���)
        public static string PascResault_YJ = "";

        public static string[] ServerListUrl;
        
        /// <summary>
        /// ��ǰѡ�е�WebServie��ַ
        /// </summary>
        public static string webserviceIp = "";


        #region �ٴ�·��ȫ�ֱ���
        public const string ITEM_CODEDoctor = "938"; //ҽ��
        public const string ITEM_CODENurse = "959";//��ʿ
        public const string ITEM_CODEVariation = "940";//����
        /// <summary>
        /// ���ݿ��û���
        /// </summary>
        public static readonly string tablespace = "ecp.";

        public static string Second_HospitalTitle = "��  ��  ʡ  ��  ��  ҽ  Ժ";

        /// <summary>
        /// סԺ���̲鿴
        /// </summary>
        public static event EventHandler On_Zhuyuan = null;
        /// <summary>
        /// ��ǰģ��
        /// </summary>
        public static event EventHandler On_GetTemplete = null;
        /// <summary>
        /// ����ģ��
        /// </summary>
        public static event EventHandler On_SaveTemplete = null;
        #endregion



        /// <summary>
        /// ��ʼ������
        /// </summary>
		public App()
        { 
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //			            
        }

        #region ����
        #endregion

        #region ����ע��
        /// <summary>
        /// ���̹���
        /// </summary>
        static KeyBordHook kh;
        /// <summary>
        /// ��깳��
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
                    if (App.UserAccount.TimeOut_Unit == "��")
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
                    if (App.UserAccount.TimeOut_Unit == "��")
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
        /// ע������
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
        /// ��ȡ��ǰ����·��
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
        /// ��ʼ��Web����
        /// </summary>
        public static void iniwebservice()
        {
            //WebService = new Bifrost.WebReference.Service();
            //string webip = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebService_EMR/Service.asmx";
            //WebService.Url = webip;

        }

        /// <summary>
        /// �ͷ�����������
        /// �ر�ϵͳ�����л���ɫ �ͷ�֮ǰ���������������� 
        /// </summary>
        public static void ReleaseLockedDoc()
        {
            int CurrentProcessID = System.Diagnostics.Process.GetCurrentProcess().Id;
            string sql = "delete from t_patient_doc_locked where processid=" + CurrentProcessID;
            App.ExecuteSQL(sql);
        }

        /// <summary>
        /// �رջ��߲�������ʱ �ͷ�֮ǰ�����û���������������
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
        /// ��ȡԴͼƬ���Ƽ���
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
        /// �ر������������ʱ �ͷ�֮ǰ�û�����������ʱ����������
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
        /// ���ߵ�ĳ�������Ƿ�����
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
        /// ��ס���ߵĲ���������
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

        #region ���ݿ����


        /*
         *˵����
         *��ǰ�����ݿ�ʹ�õ�Oracle�����ݿ������ʽ��Ҫ�����֣�
         * 1.WebService��ʽ�����ַ�ʽͨ��HttpЭ�飬�ȶ���ȫ��������������һ�㡣
         * 2.Remoting��ʽ�����ַ�ʽ��Ҫͨ��TCP/IPЭ�飬ִ��Ч�ʽϸߣ�����ȫ��û��ǰ�ߺá�
         * Ŀǰ��Ҫ���õ��ǵڶ��ַ�ʽ��
         *
         * ��ÿ�ζ����ݿ���в�����ʱ�򣬶���ͨ��RegeditRemotingChanel���������з������ļ�⣬
         * ��֤ϵͳ���������У�һ�����ַ������쳣���ͻ��Զ����з��������л���
         */

        /// <summary>
        /// �������ݿ��Ƿ��������
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
        /// ����DataSet
        /// </summary>
        /// <param name="CmdString">��ѯ���</param>        
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
        /// �鵵���˻����¼������ת��
        /// </summary>
        /// <param name="Sqls">ִ����伯��</param>
        /// <param name="patient_Id">��������ID</param>
        /// <param name="IsFile">�Ƿ�鵵</param>
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
                    //�鵵����
                    //SqlActions_Delete = "";//�����λᵼ�����ݶ�ʧdelete from T_NURSE_RECORD_HISTORY where patient_id='" + patient_Id + "' ";
                    SqlActions_Insert = "insert into T_NURSE_RECORD_HISTORY select ID,BED_NO,PID,MEASURE_TIME,ITEM_CODE,ITEM_VALUE,LIE_POS,STATUS_MEASURE,STATE,CREAT_ID,CREATE_TIME,UPDATE_ID,UPDATE_TIME,C_STATE,OTHER_NAME,PATIENT_ID,DIAGNOSE_NAME,ITEM_SHOW_NAME,RECORD_TYPE from T_NURSE_RECORD where patient_id='" + patient_Id + "' order by id";
                    SqlActions_Del = "delete from T_NURSE_RECORD where patient_id='" + patient_Id + "'";
                }
                else
                {
                    //�鵵�˻ز���
                    //SqlActions_Delete = "";//�������˵�ͬһ���˻ᵼ�����ݶ�ʧdelete from T_NURSE_RECORD where patient_id='" + patient_Id + "' ";
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
        /// PACS�鿴
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
        /// �����¼��ģ�����
        /// </summary>
        /// <param name="template_content">ģ�������</param>
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
        /// LIS�鿴
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
        /// �����¼��ģ�����
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
        /// ҽ�����鿴
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
        /// ����������
        /// </summary>
        /// <param name="inPatient">�û�ʵ��</param>
        public static void frmShowSSMZ(InPatientInfo inPatient)
        {
            try
            {
                if (inPatient != null)
                {
                    //����	    ʾ��	    ˵��	            ��ע
                    //IP	    175.16.8.68	����ָ��	
                    //Type	    Patient_id	����ID��	        ����HIS
                    //Visit_id	Visit_id	סԺ������סԺ��ʶ	����HIS
                    //Mr_class	1001	    1001:����
                    //His_no		        ����his������ˮ�� His������ˮ��
                    //                      ����Ϊ�գ�	        ����Ϊ�գ�
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
                //App.MsgErr("����ѡ����!");
            }
        }

        /// <summary>  
        /// ����where��ȡҽ��
        /// </summary>  
        /// <param name="where">��and��ʼд</param>  
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
        /// ����DataSet
        /// </summary>
        /// <param name="TabSqls">��ѯ��伯��</param>        
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
        /// �����кź���������ֵ
        /// </summary>
        /// <param name="CmdString">SQl���</param>
        /// <param name="rowindex">�к�</param>
        /// <param name="colName">����</param>
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
        /// �Զ�����ID
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="Idname">id�ֶ���</param>
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
        /// �����ʺ�����
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="Idname">������</param>
        /// <param name="hospitalid">��Ժ</param>
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
        /// ����Ӱ�����ݿ������
        /// </summary>
        /// <param name="CmdString">��ѯ���</param>
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
        /// ������SQl����Ӱ�����ݿ������
        /// </summary>
        /// <param name="CmdStrings">��ѯ��伯��</param>       
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
        /// �Դ���������ʽִ�в���
        /// </summary>
        /// <param name="CmdString">SQL���</param>
        /// <param name="Parameters">��������</param>       
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
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
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
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
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
        /// ��ҳ����
        /// </summary>
        /// <param name="p_SqlSelect">��ѯ���</param>
        /// <param name="p_KeyColumn">����</param>
        /// <param name="p_Order">����ʽ true:ASC false DESC</param>
        /// <param name="p_PageSize">ÿҳ����</param>
        /// <param name="p_PageIndex">��ǰҳ��</param>
        /// <param name="p_RowCount">��������</param>
        /// <param name="p_PageCount">����ҳ��</param>
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
        /// SQL�ؼ��ֹ���
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSQLChar(string str)
        {
            if (str == String.Empty)
                return String.Empty; str = str.Replace("'", "��");
            str = str.Replace(";", "��");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("<", "��");
            str = str.Replace(">", "��");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("@", "��");
            str = str.Replace("=", "��");
            str = str.Replace("+", "��");
            str = str.Replace("*", "��");
            str = str.Replace("&", "��");
            str = str.Replace("#", "��");
            str = str.Replace("%", "��");
            str = str.Replace("$", "��");

            return str;
        }

        /// <summary>
        /// ת�������ַ�
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
        /// ����Ժ֮������ͬ��
        /// </summary>
        /// <param name="curhospitalid">��ǰ��ʼ��Ժ</param>
        /// <param name="Sqls">SQLS����</param>
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
                        App.MsgErr("����Ժ����Ժ�ʺ�ͬ������ʧ�ܣ�");
                    }
                    App.CurrentHospitalId = Convert.ToInt16(curhospitalid);
                }
            }
        }

        /// <summary>
        /// ����Ժ֮������ͬ��
        /// </summary>
        /// <param name="curhospitalid">��ǰ��ʼ��Ժ</param>
        /// <param name="Sqls">SQLS����</param>
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
                        App.MsgErr("����Ժ����Ժ�ʺ�ͬ������ʧ�ܣ�");
                    }

                    App.CurrentHospitalId = Convert.ToInt16(curhospitalid);
                }
            }
        }

        /// <summary>
        /// ����Ժ֮������ͬ��  ���˺ź��û���Ϣ�Ĺ�ϵ
        /// </summary>
        /// <param name="curhospitalid">��ǰ��ʼ��Ժ</param>
        /// <param name="Sqls">SQLS����</param>
        /// <param name="Account_id">�˺�����</param>
        /// <param name="User_id">�û�����</param>
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
                        App.MsgErr("����Ժ����Ժ�ʺ�ͬ������ʧ�ܣ�");
                    }

                    App.CurrentHospitalId = Convert.ToInt16(curhospitalid);
                }
            }
        }
        #endregion            

        /// <summary>
        /// ��ȡϵͳʱ��
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
        /// ���ò˵���ť��״̬
        /// </summary>
        /// <param name="toolButtonName">��ť��</param>
        /// <param name="flag">״̬</param>
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
        /// ��������Ƿ���ͨ ������Ӧʱ��
        /// </summary>
        /// <param name="ip">�����ַ���硰192.168.1.10����www.163.com��</param>
        /// <returns>-1��Ӧʧ��</returns>
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
        ///  ��ȡ��ѷ�����
        /// </summary>
        /// <param name="ServerList">�������б�</param>
        /// <returns>��ѷ�����</returns>
        public static string GetBestServerUri(string[] ServerList)
        {
            if (ServerList != null)
            {
                long[] Reslect = new long[ServerList.Length];
                /*
                 * ��ȡ��Ӧ�ĺ�����
                 */
                for (int i = 0; i < ServerList.Length; i++)
                {
                    Reslect[i] = PingResult(ServerList[i].Split(':')[0]);
                }

                /*
                 * ��ȡ��ѷ�����
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
        /// �ض�������������ӳ�����Զ�Ѱ�Һ��ʵķ�����
        /// </summary>
        /// <returns></returns>
        public static bool RegeditRemotingChanel()
        {
            try
            {
                int restindex = 0;
                /*
                 *��ȡ��Ժ������remoting����
                 */
                //ReSetSLink:
                ArrayList CurrentRemotings = new ArrayList();

                /*
                 * ˵���з�Ժ����
                 */
                for (int i = 0; i < ServerList.Length; i++)
                {
                    if (ServerList[i].Split(',')[1].ToString().Trim() == CurrentHospitalId.ToString().Trim())
                    {
                        CurrentRemotings.Add(ServerList[i]);
                    }
                }

                /*
                 * �����Щremoting�����õ�
                 */
                ArrayList CurrentUseFullRemotings = new ArrayList(); //Ŀǰ����ʹ�õ�remoting����
                for (int i = 0; i < CurrentRemotings.Count; i++)
                {
                    try
                    {
                        string remotingIp = CurrentRemotings[i].ToString();
                        string uri = "tcp://" + remotingIp.Split(',')[0].ToString() + "/TcpService";
                        object o = Activator.GetObject(typeof(DbHelp), uri);
                        Operater = (DbHelp)o;
                        Operater.ConnectTest_MySql();//remoting�����Ƿ���ȷ
                        CurrentUseFullRemotings.Add(CurrentRemotings[i].ToString());
                    }
                    catch
                    {

                    }
                }


                /*
                 * ��remoting
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
        /// �ض�������������ӳ�����Զ�Ѱ�Һ��ʵķ�����
        /// </summary>
        /// <returns></returns>
        public static bool RegeditWebServiceChanel()
        {
            try
            {

                ///*
                //* �����ЩWebService�����õ�
                //*/
                //ArrayList CurrentUseFullRemotings = new ArrayList(); //Ŀǰ����ʹ�õ�WebService����
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
                // * ��WebService
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
        /// ��ȡ���õ�url��ַ�б�
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
        /// ϵͳ��ʼ��
        /// </summary>
        public static void Ini()
        {

            /*
             * ˵����
             * 1.�ǻ�ȡһЩϵͳ��������ı�Ҫ���������磺��ǰ�ĳ����ִ��·�����Լ����������б�ȡ�
             * 2.��������˽�������ѡ����ѵķ�������
             * 
             */
            try
            {

                //WebService = new Bifrost.WebReference.Service();
                //string webip1 = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite1/Service.asmx";
                //WebService.Url = webip1;
                //App.Progress("ϵͳ��ʼ�������Ժ�...");                             

                //Write_ConfigInfo("Editor", "Hospitalname", "�׶�ҽ�ƴ�ѧ��������ͬ��ҽԺ", SysPath + "\\Config.ini");
                SysPath = Application.StartupPath;
                //һЩ������Ϣ
                HospitalTittle = Read_ConfigInfo("Editor", "Hospitalname", SysPath + "\\Config.ini");


                Openforms = new ArrayList();
                string AllService = Read_ConfigInfo("WebServerPath", "ServiceList", SysPath + "\\Config.ini");

                //��ȡ����Ȩ�޵�Ĭ�Ϸ�ʽ
                //RoleFlag   0--Ĭ������Ȩ�޶���ʹ��  1--Ĭ������Ȩ�޶�����ʹ��
                Roleflag = App.Read_ConfigInfo("WebServerPath", "RoleFlag", SysPath + "\\Config.ini").Trim();
                if (Roleflag == "")
                {
                    App.Write_ConfigInfo("WebServerPath", "RoleFlag", "0", SysPath + "\\Config.ini");
                    Roleflag = "0";
                }

                //���ת����ʽ
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
                         * remoting��ʽ
                         */
                        //BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
                        //provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Low;
                        //Hashtable props = new Hashtable();
                        //props["name"] = "tcp_rem";
                        ////props["timeout"] = 10000;//���ó�ʱʱ�� 
                        //TcpChannel _tcpChannel = new TcpChannel(props, null, null);
                        //ChannelServices.RegisterChannel(_tcpChannel, false);
                        ReSetServerLink();

                        ServerList2 = ServerList;

                        //��ȡ��ѵķ�����
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
                         * webservice��ʽ
                         */
                        //if (WebService == null)
                        //{
                        //    WebService = new WebReference.Service();
                        //}
                        //string webip = @"http://" + Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebService_EMR/Service.asmx";
                        //WebService.Url = webip;

                        //if (WebService.ConnectTest() == false)
                        //{
                        //    MsgErr("���ݿ�δ��������");
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
                MsgErr("ϵͳ��ʼ��ʧ��,���������������Ӳ�����,������δ������������ò���ȷ����ϸԭ��:" + ex.ToString());
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
        /// ������Ϣ��ʾ����2
        /// </summary>
        /// <param name="title">����</param>
        /// <param name="content">����</param>
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
        /// ������Ϣ��ʾ����2
        /// </summary>
        /// <param name="title">����</param>
        /// <param name="content">����</param>
        /// <param name="url">����</param>
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
        /// дINI�ļ�
        /// </summary>
        /// <param name="section">�½�</param>
        /// <param name="key">�ؼ���</param>
        /// <param name="keyvalue">Ҫд���ֵ</param>
        /// <param name="path">INI�ļ�·��</param>
        public static void Write_ConfigInfo(string section, string key, string keyvalue, string path)
        {
            WritePrivateProfileString(section, key, keyvalue, path);
        }


        /// <summary>
        /// ��ȡINI�ļ���Ϣ
        /// </summary>
        /// <param name="section">�½�</param>
        /// <param name="key">�ؼ���</param>
        /// <param name="path">·��</param>
        /// <returns></returns>
        public static string Read_ConfigInfo(string section, string key, string path)
        {
            try
            {
                //��ȡ������Ϣ
                StringBuilder temp1 = new StringBuilder(2550);
                int i1 = GetPrivateProfileString(section, key, "", temp1, 2550, path);
                return temp1.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("������Ϣ��" + ex, "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// ������������Button�ؼ����ı䰴ť��ʽ
        /// </summary>
        /// <param name="frm">����</param>
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
        /// �ؼ���ʽ����
        /// </summary>
        /// <param name="Ctl">�ؼ�</param>
        public static void UsControlStyle(System.Windows.Forms.Control Ctl)
        {
            GetControl(Ctl);
        }

        /// <summary>
        /// ������������Button�ؼ����ı䰴ť��ʽ
        /// </summary>
        /// <param name="frm">����</param>
        /// <param name="isMaxSize">�Ƿ�ȫ����ʾ</param>
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
        /// ������ʽ���趨
        /// </summary>
        /// <param name="f">����</param>
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
        /// ������ʽ���趨
        /// </summary>
        /// <param name="f">����</param>
        /// <param name="flag">�Ƿ�ı䴰��ߴ������һЩ����</param>
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
        /// ���ȿ�ʼ
        /// </summary>
        /// <param name="Message">��Ϣ</param>
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
        /// ���Ƚ���
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
        /// ���ֽ�������ʽ��ȡ�ļ�
        /// </summary>
        /// <param name="PathFile">�ļ�·��</param>
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
        /// Bitmap��ʽ��ת��
        /// </summary>
        /// <param name="ImageByte">�ֽ���</param>
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
        /// �ж��Ƿ�����ֵ����
        /// </summary>
        /// <param name="str">��Ҫ�жϵĲ���</param>
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
        /// ��Ϣ��ʾ��
        /// </summary>
        /// <param name="text">��Ϣ</param>
        public static void Msg(string text)
        {
            //MessageBoxEx.UseSystemLocalizedString = true;
            //MessageBoxEx.Show(text, "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);	
            MessageBox.Show(text, "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// ��Ϣ��ʾ��
        /// </summary>
        /// <param name="text">��Ϣ</param>
        /// <param name="parentfrm">������</param>
        public static void Msg(string text, Form parentfrm)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            MessageBoxEx.Show(parentfrm, text, "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// ������Ϣ��ʾ
        /// </summary>
        /// <param name="text">������Ϣ</param>
        public static void MsgErr(string text)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            MessageBoxEx.Show(text, "������Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// ������Ϣ��ʾ
        /// </summary>
        /// <param name="text">������Ϣ</param>
        public static void MsgWaring(string text)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            MessageBoxEx.Show(text, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// ��Ϣѯ����ʾ��
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        /// <returns></returns>
        public static bool Ask(string msg)
        {
            MessageBoxEx.UseSystemLocalizedString = true;
            return (MessageBoxEx.Show(msg, "��Ϣ��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        /// <summary>
        /// ��ȡExcel����
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
                //���ݿ������ַ��� 
                string myConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                //��ѯ�ַ��� 
                string mySQLstr = "SELECT * FROM [" + tableName + "$]";
                //�������ݿ���� 
                OleDbConnection myConnection = new OleDbConnection(myConn);
                try
                {
                    //ִ��SQL������ 
                    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(mySQLstr, myConnection);
                    //��Excel
                    myConnection.Open();
                    //��DataSet�������
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
        /// ���������
        /// </summary>
        /// <param name="inputstring">�ַ���</param>
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
        /// ��ȡƴ����
        /// </summary>
        /// <param name="cn">�ַ���</param>
        /// <returns></returns>
        public static string getSpell(string cn)
        {
            return Class_Font_Spell_First.GetChineseSpell(cn);
        }

        /// <summary> 
        /// תȫ�ǵĺ���(SBC case) 
        /// </summary> 
        /// <param name="input">�����ַ���</param> 
        /// <returns>ȫ���ַ���</returns> 
        public static string ToSBC(string input)
        {
            return Strings.StrConv(input, VbStrConv.Wide, 0);
        }

        /// <summary>
        /// ����Code��ѯT_HOSPITAL_CONFIG�е�Valueֵ
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetHospitalConfig(string code)
        {
            return App.ReadSqlVal("select t.value from T_HOSPITAL_CONFIG t where t.code='" + code + "'", 0, "value");
        }

        /// <summary> 
        /// ת��ǵĺ���(DBC case) 
        /// </summary> 
        /// <param name="input">�����ַ���</param> 
        /// <returns>����ַ���</returns>    
        public static string ToDBC(string input)
        {
            return Strings.StrConv(input, VbStrConv.Narrow, 0);
        }

        /// <summary>
        /// �жϵ�ǰֵ�Ƿ�����ֵ
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
        /// �Ƿ�������
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
        /// �ڵ������
        /// </summary>
        /// <param name="ObjNode">ѡ�нڵ�</param>
        /// <param name="trvTypedCategory">���ؼ�</param>
        public static void TrvNodeMovUp(TreeNode ObjNode, TreeView trvTypedCategory)
        {
            //----�ڵ�������ƶ�   
            if (ObjNode != null)
            {
                TreeNode newnode = new TreeNode();
                //--------���ѡ�нڵ�Ϊ��ڵ�   
                if (ObjNode.Index == 0)
                {
                    //-------------   
                }
                else if (ObjNode.Index != 0)
                {
                    newnode = (TreeNode)ObjNode.Clone();
                    //-------------��ѡ�нڵ�Ϊ���ڵ�   
                    if (ObjNode.Level == 0)
                    {
                        trvTypedCategory.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
                    }
                    //-------------��ѡ�нڵ㲢�Ǹ��ڵ�   
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
        /// �ڵ������
        /// </summary>
        /// <param name="ObjNode">���ڵ�</param>
        /// <param name="trvTypedCategory">���ؼ�</param>
        public static void TrvNodeMovDown(TreeNode ObjNode, TreeView trvTypedCategory)
        {
            //----�ڵ�������ƶ�   
            if (ObjNode != null)
            {
                TreeNode newnode = new TreeNode();
                //-------------���ѡ�е��Ǹ��ڵ�   
                if (ObjNode.Level == 0)
                {
                    //---------���ѡ�нڵ�Ϊ��׽ڵ�   
                    if (ObjNode.Index == trvTypedCategory.Nodes.Count - 1)
                    {
                        //---------------   
                    }
                    //---------���ѡ�еĲ�����׵Ľڵ�   
                    else
                    {
                        newnode = (TreeNode)ObjNode.Clone();
                        trvTypedCategory.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
                        ObjNode.Remove();
                        ObjNode = newnode;

                    }
                }
                //-------------���ѡ�нڵ㲻�Ǹ��ڵ�   
                else if (ObjNode.Level != 0)
                {
                    //---------���ѡ����׵Ľڵ�   
                    if (ObjNode.Index == ObjNode.Parent.Nodes.Count - 1)
                    {
                        //-----------   
                    }
                    //---------���ѡ�еĲ�����͵Ľڵ�   
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
        ///// �ڵ������
        ///// </summary>
        ///// <param name="ObjNode">ѡ�нڵ�</param>
        ///// <param name="trvTypedCategory">���ؼ�</param>
        //public static void TrvNodeMovUp(Node ObjNode, DevComponents.AdvTree.AdvTree trvTypedCategory)
        //{
        //    //----�ڵ�������ƶ�   
        //    if (ObjNode != null)
        //    {
        //        Node newnode = new Node();
        //        //--------���ѡ�нڵ�Ϊ��ڵ�   
        //        if (ObjNode.Index == 0)
        //        {
        //            //-------------   
        //        }
        //        else if (ObjNode. != 0)
        //        {
        //            newnode = (Node)ObjNode.Clone();
        //            //-------------��ѡ�нڵ�Ϊ���ڵ�   
        //            if (ObjNode.Level == 0)
        //            {
        //                trvTypedCategory.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
        //            }
        //            //-------------��ѡ�нڵ㲢�Ǹ��ڵ�   
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
        ///// �ڵ������
        ///// </summary>
        ///// <param name="ObjNode">���ڵ�</param>
        ///// <param name="trvTypedCategory">���ؼ�</param>
        //public static void TrvNodeMovDown(TreeNode ObjNode, DevComponents.AdvTree.AdvTree trvTypedCategory)
        //{
        //    //----�ڵ�������ƶ�   
        //    if (ObjNode != null)
        //    {
        //        TreeNode newnode = new TreeNode();
        //        //-------------���ѡ�е��Ǹ��ڵ�   
        //        if (ObjNode.Level == 0)
        //        {
        //            //---------���ѡ�нڵ�Ϊ��׽ڵ�   
        //            if (ObjNode.Index == trvTypedCategory.Nodes.Count - 1)
        //            {
        //                //---------------   
        //            }
        //            //---------���ѡ�еĲ�����׵Ľڵ�   
        //            else
        //            {
        //                newnode = (TreeNode)ObjNode.Clone();
        //                trvTypedCategory.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
        //                ObjNode.Remove();
        //                ObjNode = newnode;

        //            }
        //        }
        //        //-------------���ѡ�нڵ㲻�Ǹ��ڵ�   
        //        else if (ObjNode.Level != 0)
        //        {
        //            //---------���ѡ����׵Ľڵ�   
        //            if (ObjNode.Index == ObjNode.Parent.Nodes.Count - 1)
        //            {
        //                //-----------   
        //            }
        //            //---------���ѡ�еĲ�����͵Ľڵ�   
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
        /// �Ƴ�ListView����ѡ�еĽڵ�
        /// </summary>
        /// <param name="trv">���ؼ�</param>
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
        /// �Ƴ�������ѡ�еĽڵ�
        /// </summary>
        /// <param name="trv">���ؼ�</param>
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
        /// ��ȡ����IP
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
        /// �������������Ϣ
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        /// <param name="Currentip">����Ip</param>
        public static void SendMessage(string msg, string Currentip)
        {           
                Operater.sendmymsg(msg, Currentip);
           
        }

        /// <summary>
        /// ��ȡ�������˴�����Ϣ
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
        /// �������������Ϣ
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
        /// ��ȡת�ƵȲ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public static string getMesContent(string[] SectionIds)
        {
            try
            {
                XmlNodeList nodeslist;       //��Ҽ�����Ϣ
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
        /// ��Ժ�Ǽǲ�����Ϣ
        /// </summary>
        /// <param name="said">������Ϣ</param>
        /// <returns></returns>
        public static string getMesSarContent(string said)
        {
            try
            {
                XmlNodeList nodeslist;       //��Ҽ�����Ϣ
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
        /// ������ʱ��Ϣ
        /// </summary>
        /// <param name="Content"></param>
        public static void AddTempUserMsg(string Content)
        {
            try
            {
                XmlNodeList nodeslist;       //��Ҽ�����Ϣ
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
        /// �ж��Ƿ��Ѿ������������
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static bool IsReceiceMsg(string Content)
        {
            try
            {
                XmlNodeList nodeslist;       //��Ҽ�����Ϣ
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
        /// ��������Ϣ���е���Ϣ
        /// </summary>
        /// <param name="val">����</param>
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
        /// ����Ȩ���жϰ�ť�Ƿ�����жϰ�ť
        /// </summary>
        /// <param name="btnPermission">��ťȨ�޼���</param>
        /// <param name="Control">���������ؼ�</param>
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
        /// �ж��Ƿ�����Ч��Ip��ַ true��Ч false��Ч
        /// </summary>
        /// <param name="addressString">IP��ַ</param>
        /// <returns></returns>
        public static bool IPAddressCheck(string addressString)
        {
            try
            {
                string webServerAddress;
                Regex r = new Regex(@"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");//IP��ַ��������ʽ
                Match m;
                webServerAddress = addressString;
                webServerAddress = webServerAddress.Trim();
                m = r.Match(webServerAddress);
                if (m.Success)   //��һ���ж�IP��ַ�ĺϷ���
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
                        return true;// ����IP��ַ��ʽ��Ҫ��
                    else
                        return false;//�Ƿ���ַ
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
        /// �����ѯ
        /// </summary>
        /// <param name="Sql">��ѯ���</param>
        /// <param name="trlTepm">��ǰ�ؼ�</param>
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
        /// �����ѯ
        /// ������Ŀ
        /// ���������б��༭����
        /// </summary>
        /// <param name="Sql">��ѯ���</param>
        /// <param name="trlTepm">��ǰ�ؼ�</param>
        /// <param name="Sel_Name"></param>
        /// <param name="Sel_Val"></param>     
        public static void FastCodeCheck(string Sql, Control trlTepm, string Sel_Name, string Sel_Val, string BABM)
        {
            uccodeselect.IniucCodeSelect(Sql, trlTepm, Sel_Name, Sel_Val, BABM);
            trlTepm.Focus();
        }


        /// <summary>
        /// �۽������ѯ����
        /// </summary>
        public static void SelectFastCodeCheck()
        {
            if (uccodeselect != null)
            {
                uccodeselect.Fg_Focus();
            }
        }

        /// <summary>
        /// �رտ����ѯ����
        /// </summary>
        public static void HideFastCodeCheck()
        {
            if (uccodeselect != null)
            {
                uccodeselect.Hide();
            }
        }

        /// <summary>
        /// ��ȡʱ�䴮
        /// </summary>
        /// <param name="strval">�ַ���</param>
        /// <returns></returns>
        public static string GetTimeString(string strval)
        {
            int right = 0;
            string timestr = "";

            string val = ToDBC(strval);

            //2011-2-16 8:23 ����
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
                //2011-2-16 ����
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
        /// ��ȡ����ʱ�� 
        /// </summary>
        /// <param name="birthday">��������</param>
        /// <param name="In_Time">��Ժʱ��</param>
        /// <param name="unitflag">�Ƿ���ʾ��λ true��ʾ false ����ʾ</param>
        /// <returns></returns>
        public static string GetTheAgeTime(DateTime birthday, DateTime In_Time, bool unitflag)
        {
            try
            {
                int year = 0;
                int month = 0;
                int day = 0;
                //int day, month, year;
                //���յ��꣬�£���
                int birthdayYear = birthday.Year;
                int birthdayMonth = birthday.Month;
                int birthdayDay = birthday.Day;
                //��ǰʱ�����,��,��
                int nowYear = In_Time.Year;
                int nowMonth = In_Time.Month;
                int nowDay = In_Time.Day;

                //�õ���
                if (nowDay >= birthdayDay)
                {
                    day = nowDay - birthdayDay;
                }
                else
                {
                    nowMonth -= 1;
                    day = GetDay(nowMonth, nowYear) + nowDay - birthdayDay;
                }

                //�õ���
                if (nowMonth >= birthdayMonth)
                {
                    month = nowMonth - birthdayMonth;
                }
                else
                {
                    nowYear -= 1;
                    month = 12 + nowMonth - birthdayMonth;
                }
                //�õ���
                year = nowYear - birthdayYear;
                if (year == 0)
                {
                    if (month == 0)
                    {
                        if (day > 0)
                        {
                            if (unitflag)
                                return day.ToString() + @"/30��";
                            else
                                return day.ToString() + @"/30";
                        }
                    }
                    else
                    {
                        if (day > 0)
                        {
                            if (unitflag)
                                return month.ToString() + " " + day.ToString() + @"/30��";
                            else
                                return month.ToString() + " " + day.ToString() + @"/30";
                        }
                        else
                        {
                            if (unitflag)
                                return month.ToString() + "��";
                            else
                                return month.ToString();
                        }
                    }
                }
                else
                {
                    if (unitflag)
                        return year.ToString() + "��";
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
        /// ����ˢ��Grid������һ�α�ˢ�£�
        /// </summary>
        /// <param name="flgView">���ؼ�</param>
        /// <param name="items">��������</param>
        /// <param name="colInfos">��ʾ������</param>
        /// <param name="rowflexnum">��ͷ��ռ������</param>
        public static void ArrayToGrid(C1.Win.C1FlexGrid.C1FlexGrid flgView, object[] items, ColumnInfo[] colInfos, int rowflexnum)
        {
            try
            {
                flgView.Cols.Count = colInfos.Length;
                flgView.Rows.Count = items.Length + rowflexnum;

                DataTable tb = new DataTable();
                //tb=ArrayToTable.Convert(items);

                tb = ObjectArrayToDataSet(items).Tables[0]; ;

                //�ﶨ����
                for (int i = 0; i < colInfos.Length; i++)
                {
                    if (colInfos[i].Name != null)
                        flgView[0, i] = colInfos[i].Name;
                }
                //������ݰ�
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

                //������
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
                MsgErr("���ˢ��ʧ�ܣ�����ԭ��:" + ex.ToString());
            }

        }

        /// <summary>
        /// ����������ת��Ϊ���ݼ�
        /// </summary>
        /// <param name="objArr">���󼯺�</param>
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
        /// �����û����������û��ĵ���ϸ��Ϣ
        /// </summary>
        /// <param name="id">����</param>
        /// <returns></returns>
        public static Class_User GetUserInfoById(string id)
        {
            DataSet ds = GetDataSet("select t.*,a.name as ְ��,b.name as ְ�� from t_userinfo t inner join t_data_code a on a.id=t.u_tech_post inner join t_data_code b on b.id=t.u_position where t.user_id=" + id + "");
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
                    userinfo.U_tech_post_name = ds.Tables[0].Rows[0]["ְ��"].ToString();
                    userinfo.U_position_name = ds.Tables[0].Rows[0]["ְ��"].ToString();
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
        /// �����������û��ؼ�
        /// </summary>
        /// <param name="User_Control">�û��Զ���ؼ�</param>
        /// <param name="Tab_Text">����</param>
        public static void AddNewBusUcControl(Control User_Control, string Tab_Text)
        {
            TabControlPanel p_temp = new TabControlPanel();
            TabItem t_temp = new TabItem();
            t_temp.AttachedControl = p_temp;
            if (!Tab_Text.Equals("ҽ��վ") && !Tab_Text.Equals("��ʿվ"))
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
        /// ���������
        /// </summary>
        public static void ClearBusUcControl()
        {
            tabMain.Tabs.Clear();
        }


        #region ϵͳ���˵�����ʾ
        /// <summary>
        /// �������ò˵�
        /// </summary>
        public void frmPerssionShow()
        {
            frmPermissionSet fm = new frmPermissionSet();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "�������ò˵�");
        }

        /// <summary>
        /// ��ɫȨ������
        /// </summary>
        public void frmRoleSetShow()
        {
            frmRoleSet fm = new frmRoleSet();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "��ɫȨ������");
        }

        /// <summary>
        /// �û��ʺ�����
        /// </summary>
        public void frmAccountShow()
        {
            frmAccount fm = new frmAccount();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "�û��ʺ�����");
        }

        /// <summary>
        /// �û�������־��ѯ
        /// </summary>
        public void frmOperaterLogShow()
        {

            Bifrost.SYSTEMSET.frmOperaterShow fm = new Bifrost.SYSTEMSET.frmOperaterShow();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "�û�������־��ѯ");
        }


        /// <summary>
        /// �����ʺ�
        /// </summary>
        /// <param name="User">�û�ʵ��</param>
        public static void frmAccountSetByUser(Class_User User)
        {
            frmAccountSimpleSet fm = new frmAccountSimpleSet(User);
            App.FormStytleSet(fm, false);
            fm.ShowDialog();
        }

        /// <summary>
        /// �������ò˵�
        /// </summary>
        public void frmDocRoleSetShow()
        {
            frmDocRoleSet fm = new frmDocRoleSet();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "�������ò˵�");
        }

        /// <summary>
        /// ��ʾ��ǰ��¼�ͻ����б�
        /// </summary>
        public void frmShowServerLinkList()
        {
            SYSTEMSET.frmShowServerLinks fr = new Bifrost.SYSTEMSET.frmShowServerLinks();
            App.UsControlStyle(fr);
            App.AddNewBusUcControl(fr, "��ʾ��ǰ��¼�ͻ����б�");
        }

        /// <summary>
        /// ��ʾ��ɫ��Чʱ���趨
        /// </summary>
        public void frmShowRoleTimeSpan()
        {
            SYSTEMSET.frmDutyTimeSpanSet fr = new Bifrost.SYSTEMSET.frmDutyTimeSpanSet();
            App.UsControlStyle(fr);
            App.AddNewBusUcControl(fr, "��ʾ��ɫ��Чʱ���趨");
        }

        /// <summary>
        /// Σ�ػ�����Ŀ��ά��
        /// </summary>
        public void frmShowNurseMask()
        {
            SYSTEMSET.ucNurseMask fr = new Bifrost.SYSTEMSET.ucNurseMask();
            App.UsControlStyle(fr);
            App.AddNewBusUcControl(fr, "Σ�ػ�����Ŀ��ά��");
        }


        /// <summary>
        /// ����ϵͳ�ӿڵ���
        /// </summary>
        public void frmBaInsert()
        {
            HisInStance.frmBa_Insert fm = new HisInStance.frmBa_Insert();
            App.UsControlStyle(fm);
            App.AddNewBusUcControl(fm, "���²���ϵͳ�ӿ�");
        }

        #endregion


        #region �������
        /// <summary>
        /// ����ģ���ǩ
        /// </summary>
        /// <param name="TID">ģ��ID</param>
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
        /// ����ģ��
        /// </summary>
        /// <param name="PID">������ID(HIS)</param>
        /// <param name="xmlDoc">����(xml����)</param>
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
        /// �����ǩ--------������
        /// </summary>
        /// <param name="TID">סԺ�����������</param>
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
        /// ����ṹ��--------������
        /// </summary>
        /// <param name="LID">ģ�漯�ϱ�ǩ����</param>
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
        /// ��ѯ��ǩģ����ı����ݣ�span�ڵ㣩�����ڹؼ��ʹ���
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
        /// ��ȡ����Ȩ��
        /// </summary>
        /// <param name="Text_id">��������</param>       
        /// <param name="patient_group_id">��ǰ���˵����ƻ�����</param>
        /// <param name="Sick_Doctor_Id">��ǰ���˵����ƻ�����</param>
        /// <returns></returns>
        public static ArrayList Get_Text_Button_Rights(int Text_id, int patient_group_id, int Sick_Doctor_Id)
        {
            try
            {
                #region ��ʼ����ťEnable����
                for (int i = 0; i < ParentForm.Controls.Count; i++)
                {
                    if (ParentForm.Controls[i].Name == "toolbar")
                    {
                        Bar temptool = (Bar)ParentForm.Controls[i];
                        for (int k = 0; k < temptool.Items.Count; k++)
                        {
                            ButtonItem temp = (ButtonItem)temptool.Items[k];
                            /*
                             * �������ť�� ע�� ��ɫѡ�� һ��EnableΪtrue tsbtnDutySet tsbtnHelp
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
                             * �������ť�� ע�� ��ɫѡ�� һ��EnableΪtrue tsbtnHelp
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

                #region ����Ȩ���趨
                //���е��������
                DataSet ds_Text_Operater = App.GetDataSet("select * from t_permission where perm_kind=2");

                //ְ���ְ��
                DataSet ds_job = App.GetDataSet("select flag,jobtitle,types,levels,textcontrol from t_text_jobtitle_relation a inner join T_IN_DOC_JOBTITLE b on a.jobtitle=b.jobtitle_id where texttype=" + Text_id + "");

                //����Ȩ��
                DataSet ds_OtherRight = App.GetDataSet("select * from t_text_other_set where texttype=" + Text_id + "");

                //ְ��ְ�Ƽ����
                DataSet ds_Levels = App.GetDataSet("select * from T_IN_DOC_JOBTITLE");

                //��ǰ�ʺ���ӵ�е���������Ϣ
                DataSet ds_Group = App.GetDataSet("select * from T_TREATORNURSE_GROUP a inner join t_tng_account b on a.tng_id=b.tng_id where b.account_id=" + App.UserAccount.Account_id + "");

                //ְ�� ����
                ArrayList JobRights = new ArrayList();

                //��ť����Ȩ��һ ����
                ArrayList buttonRights1 = new ArrayList();

                //��ť����Ȩ�޶� ����00
                ArrayList buttonRights2 = new ArrayList();

                //��Ȩ�޵Ĳ���
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
                             * ְ��ְ��
                             */
                            DataRow[] jobs = ds_job.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < jobs.Length; j++)
                            {
                                JobRights.Add(jobs[j]);
                            }

                            /*
                             *��ȡ���е�����Ȩ�� 
                             */

                            DataRow[] OtherRights = ds_OtherRight.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < OtherRights.Length; j++)
                            {
                                if (OtherRights[j]["other_name"].ToString().Trim() == "���ܴ�" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "��ִҵ֤��" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "����������")
                                {
                                    buttonRights1.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                                else
                                {
                                    buttonRights2.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                            }

                            /*
                             * Ȩ��Ч��
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
                                    string jobtitle = temprow["jobtitle"].ToString().Trim(); //ְ���ְ��ID
                                    string types = temprow["types"].ToString().Trim();       //����
                                    int levels = Convert.ToInt16(temprow["levels"].ToString().Trim());     //����

                                    //ְ��
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
                                            else if (Sign.Contains("��"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("��"))
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

                                    //ְ��
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
                                            else if (Sign.Contains("��"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("��"))
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
                                    //���ְҵ֤��                                   
                                    if (buttonRights1[j].ToString() == "���ܴ�")
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

                                    if (buttonRights1[j].ToString() == "��ִҵ֤��")
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

                                    //if (buttonRights1[j].ToString() == "����������")
                                    //{
                                    //    //���������� tng_id
                                    //    flagbutton1 = false;
                                    //    if (ds_Group.Tables[0].Rows.Count > 0)
                                    //    {
                                    //        if (patient_group_id != 0)  //�˲������ڹ����С���
                                    //        {
                                    //            for (int k = 0; k < ds_Group.Tables[0].Rows.Count; k++)
                                    //            {
                                    //                if (ds_Group.Tables[0].Rows[k]["tng_id"].ToString() == patient_group_id.ToString())
                                    //                {
                                    //                    flagbutton1 = true;
                                    //                }
                                    //            }
                                    //        }
                                    //        //else   //patient_group_id = 0,��ʱ����û�������������
                                    //        //{
                                    //        //    flagbutton1 = true;
                                    //        //}
                                    //    }
                                    //    //else  //��¼�˺�û�����ƻ���������
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
                                        //�ʻ����� 53��ʵϰ 54�ɽ���
                                        if (buttonRights2[j].ToString().Trim() == "��ʵϰ")
                                        {
                                            flagbutton2_shixi = true;
                                        }
                                        //if (buttonRights2[j].ToString().Trim() == "�ɽ���")
                                        //{
                                        //    flagbutton2_jinxiu = true;
                                        //}
                                    }
                                }
                            }
                            //if (Roleflag == "0")   //�������Roleflag=0,Ĭ��Ȩ����Ч
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

                #region ����б�             
                if (Text_id != 151 && Text_id != 389) //�Ƿ�Ϊ������¼ 235
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
                            //ͬһְ��Ļ���Ҫ�ж�ְ��
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
                            //ͬһְ��Ļ���Ҫ�ж�ְ��
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


                //ˢ�������尴ť
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
        ///Ȩ�޹������� 
        /// </summary>
        /// <param name="Text_id"></param>
        /// <param name="patient_group_id"></param>
        /// <param name="Sick_Doctor_Id"></param>
        /// <param name="obj"></param>
        /// <param name="OperateType">0�޸Ļ򴴽� 1���</param>
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
                    #region treenode�������޸�
                    bool flag = false;  //��ǰ�ʺŶԸ÷������Ƿ�����д��Ȩ��
                    TreeNode Temp = obj as TreeNode;
                    if (Temp.Name != "" && currentPatient != null)
                    {
                        string account_Type = App.UserAccount.CurrentSelectRole.Role_type;
                        if (account_Type == "D")   //��ǰ�û���ҽ��
                        {
                            //������Ĳ���Ȩ�޿���
                            int textId = 0; //����ID
                            if (Temp != null)
                            {
                                //��������
                                if (Temp.Tag.GetType().ToString() == "Bifrost.Patient_Doc")
                                {
                                    Patient_Doc doc = Temp.Tag as Patient_Doc;
                                    textId = doc.Textkind_id;
                                }
                                //��������
                                if (Temp.Tag.GetType().ToString() == "Bifrost.Class_Text")
                                {
                                    Class_Text text = Temp.Tag as Class_Text;
                                    textId = text.Id;
                                }
                            }
                            ArrayList list = App.Get_Text_Button_Rights(textId, currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id));
                            if (list.Count == 0)
                            {
                                return "����Ȩ�޲��㣡";
                            }
                            for (int i = 0; i < list.Count; i++)
                            {
                                string Button_Write = list[i] as string;
                                if (Temp.Tag.GetType().ToString().Contains("Class_Text"))
                                {
                                    Class_Text temtxt = (Class_Text)Temp.Tag;
                                    if (temtxt.Issimpleinstance == "1")
                                    {
                                        //��������
                                        if (Button_Write == "tsbtnWrite")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                        {
                                            flag = true;
                                            break;
                                        }
                                        if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                        {
                                            if (temtxt.Id == 138 || temtxt.Id == 158)
                                            {
                                                return "";//"1����סԺ���̼�¼���µġ���Ժ/����ǰ���һ�β��̡�δ��д������²�������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;\n2������Ժ/����ǰ���һ�β��̡�����д����δ�����ܴ�ҽʦ���ϼ�ҽʦǩ��������£�Ҳ������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //��������
                                        string temptid = isExitRecord(temtxt.Id, currentPatient.Id);
                                        if (temptid != null && temptid != "")
                                        {
                                            if (Button_Write == "tsbtnModify")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (Button_Write == "tsbtnWrite")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                            {
                                                flag = true;
                                                break;
                                            }
                                            if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                            {
                                                if (temtxt.Id == 138 || temtxt.Id == 158)
                                                {
                                                    return "";//"1����סԺ���̼�¼���µġ���Ժ/����ǰ���һ�β��̡�δ��д������²�������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;\n2������Ժ/����ǰ���һ�β��̡�����д����δ�����ܴ�ҽʦ���ϼ�ҽʦǩ��������£�Ҳ������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;";
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (Temp.Tag.GetType().ToString().Contains("Patient_Doc"))
                                {
                                    if (Button_Write == "tsbtnModify")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            if (!flag)
                            {
                                return "����û�жԸ÷�������д��Ȩ�ޣ�";
                            }
                        }
                    }
                    #endregion
                }
                else if (OperateType == 1)
                {
                    #region ���
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
                    #region treenode�������޸�
                    bool flag = false;  //��ǰ�ʺŶԸ÷������Ƿ�����д��Ȩ��
                    DevComponents.AdvTree.Node Temp = obj as DevComponents.AdvTree.Node;
                    if (Temp.Name != "" && currentPatient != null)
                    {
                        string account_Type = App.UserAccount.CurrentSelectRole.Role_type;
                        if (account_Type == "D")   //��ǰ�û���ҽ��
                        {
                            //������Ĳ���Ȩ�޿���
                            int textId = 0; //����ID
                            if (Temp != null)
                            {
                                //��������
                                if (Temp.Tag.GetType().ToString() == "Bifrost.Patient_Doc")
                                {
                                    Patient_Doc doc = Temp.Tag as Patient_Doc;
                                    textId = doc.Textkind_id;
                                }
                                //��������
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
                                return "����Ȩ�޲��㣡";
                            }
                            for (int i = 0; i < list.Count; i++)
                            {
                                string Button_Write = list[i] as string;
                                if (Temp.Tag.GetType().ToString().Contains("Class_Text"))
                                {
                                    Class_Text temtxt = (Class_Text)Temp.Tag;
                                    if (temtxt.Issimpleinstance == "1")
                                    {
                                        //��������
                                        if (Button_Write == "tsbtnWrite")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                        {
                                            flag = true;
                                            break;
                                        }
                                        if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                        {
                                            if (temtxt.Id == 138 || temtxt.Id == 158)
                                            {
                                                return "";//"1����סԺ���̼�¼���µġ���Ժ/����ǰ���һ�β��̡�δ��д������²�������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;\n2������Ժ/����ǰ���һ�β��̡�����д����δ�����ܴ�ҽʦ���ϼ�ҽʦǩ��������£�Ҳ������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //��������
                                        string temptid = isExitRecord(temtxt.Id, currentPatient.Id);
                                        if (temptid != null && temptid != "")
                                        {
                                            if (Button_Write == "tsbtnModify")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (Button_Write == "tsbtnWrite")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                            {
                                                flag = true;
                                                break;
                                            }
                                            if (!App.DocIsCanWrite(temtxt.Id.ToString(), currentPatient.Id.ToString()))
                                            {
                                                if (temtxt.Id == 138 || temtxt.Id == 158)
                                                {
                                                    return "";//"1����סԺ���̼�¼���µġ���Ժ/����ǰ���һ�β��̡�δ��д������²�������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;\n2������Ժ/����ǰ���һ�β��̡�����д����δ�����ܴ�ҽʦ���ϼ�ҽʦǩ��������£�Ҳ������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼��;";
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (Temp.Tag.GetType().ToString().Contains("Patient_Doc"))
                                {
                                    if (Button_Write == "tsbtnModify")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            if (!flag)
                            {
                                return "����û�жԸ÷�������д��Ȩ�ޣ�";
                            }
                        }
                    }
                    #endregion
                }
                else if (OperateType == 1)
                {
                    #region ���
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
                //�л�TABҳ
                string sql = "";
                DevComponents.DotNetBar.TabItem temptab = obj as DevComponents.DotNetBar.TabItem;
                InPatientInfo inpatient = temptab.Tag as InPatientInfo;
                if (temptab.Text.Contains("���"))
                {
                    App.SetToolButtonByUser("tsbtnTemplate", false);
                    App.SetToolButtonByUser("tsbtnTemplateSave", false);
                    App.SetToolButtonByUser("ttsbtnPrint", true);
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    App.SetToolButtonByUser("tsbtnCommit", false);
                }
                else
                {
                    string textId = "0";     //����ID         
                    string tabtype = "";  //��������

                    if (temptab.Name.Split(';').Length == 2)//�޸�����
                    {
                        textId = temptab.Name.Split(';')[0].ToString();
                        tabtype = temptab.Name.Split(';')[1].ToString();
                    }
                    if (temptab.Name.Split(';').Length >= 3)//�½�����
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
        /// �Ƿ���Ҫ��ǩ  true ��Ҫ��ǩ false ����Ҫ��ǩ
        /// </summary>
        /// <param name="user_id">���鴴��</param>
        /// <returns></returns>
        public static bool IsNeedCheck(string user_id)
        {
            try
            {
                string KindId = App.ReadSqlVal("select a.kind as KindId from t_account a inner join t_account_user b on a.account_id=b.account_id where b.user_id=" + user_id + " and rownum=1", 0, "KindId");
                if (KindId == "53" || KindId == "54" || KindId == "7921")
                {
                    //ʵϰ�����ޣ��о���
                    return true;
                }
                else if (KindId == "70")
                {
                    //��תҽ��
                    //select count(t.user_id) as num from t_userinfo t where t.profession_card='true' and t.user_id=                  59808581
                    string num = App.ReadSqlVal("select count(t.user_id) as num from t_userinfo t where t.profession_card='true' and t.user_id=" + user_id + "", 0, "num");
                    if (num != "")
                    {
                        if (num == "0")
                        {
                            //��֤
                            return true;
                        }
                        else
                        {
                            //��֤
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
        /// �����Ƿ���Դ���  true ���Դ��� false ���ɴ���
        /// </summary>
        /// <param name="Text_id">��������</param>
        /// <returns></returns>
        public static bool DocIsCanWrite(string Text_id, string patient_id)
        {
            /*
             * 1����סԺ���̼�¼���µġ���Ժ/����ǰ���һ�β��̡�δ��д������²�������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼����
               2������Ժ/����ǰ���һ�β��̡�����д����δ�����ܴ�ҽʦ���ϼ�ҽʦǩ��������£�Ҳ������д����Ժ��¼���µġ�������¼���򡾳�Ժ��¼����

             */

            //844   138������¼  158��Ժ��¼
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
        /// �ж��Ƿ���ڵ�������ҽʦ
        /// </summary>
        /// <param name="User_id">�û�ʵ��</param>
        /// <returns></returns>
        public static bool IsHigherMasterDoctor(string User_id)
        {
            try
            {
                //����ҽʦ ��IDΪ  leves=2
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
        /// �жϵ�ǰ�˻��Ƿ��ǻ�ʿ�� true �� false ��
        /// </summary> 
        /// <returns></returns>
        public static bool IsMasterNurser()
        {
            try
            {
                if (App.UserAccount.CurrentSelectRole.Role_name.Contains("��ʿ��"))
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
        /// ����Ȩ������
        /// </summary>
        /// <param name="Text_id">��������</param>
        /// <param name="Patient_Doctor_id">��ǰ����ܴ�ҽ��</param>
        /// <param name="patient_group_id">���������ID</param>
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

                //���е��������
                DataSet ds_Text_Operater = App.GetDataSet("select * from t_permission where perm_kind=2");

                //ְ���ְ��
                DataSet ds_job = App.GetDataSet("select flag,jobtitle,types,levels,textcontrol from t_text_jobtitle_relation a inner join T_IN_DOC_JOBTITLE b on a.jobtitle=b.jobtitle_id where texttype=" + Text_id + "");

                //����Ȩ��
                DataSet ds_OtherRight = App.GetDataSet("select * from t_text_other_set where texttype=" + Text_id + "");

                //ְ��ְ�Ƽ����
                DataSet ds_Levels = App.GetDataSet("select * from T_IN_DOC_JOBTITLE");

                //��ǰ�ʺ���ӵ�е���������Ϣ
                DataSet ds_Group = App.GetDataSet("select * from T_TREATORNURSE_GROUP a inner join t_tng_account b on a.tng_id=b.tng_id where b.account_id=" + App.UserAccount.Account_id + "");

                //bool IsZhiWuZhiCheng = false;
                //bool IsOtherRights = false;


                //ְ�� ����
                ArrayList JobRights = new ArrayList();

                //��ť����Ȩ��һ ����
                ArrayList buttonRights1 = new ArrayList();

                //��ť����Ȩ�޶� ����
                ArrayList buttonRights2 = new ArrayList();

                //��Ȩ�޵Ĳ���
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
                             * ְ��ְ��
                             */
                            DataRow[] jobs = ds_job.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < jobs.Length; j++)
                            {
                                //allrights.add(ds_otherright.tables[0].rows[i]["other_name"].tostring().trim());
                                JobRights.Add(jobs[j]);
                            }

                            /*
                             *��ȡ���е�����Ȩ�� 
                             */

                            DataRow[] OtherRights = ds_OtherRight.Tables[0].Select("textcontrol=" + buttonid.ToString() + "");
                            for (int j = 0; j < OtherRights.Length; j++)
                            {
                                if (OtherRights[j]["other_name"].ToString().Trim() == "���ܴ�" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "��ִҵ֤��" ||
                                    OtherRights[j]["other_name"].ToString().Trim() == "����������")
                                {
                                    buttonRights1.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                                else
                                {
                                    buttonRights2.Add(OtherRights[j]["other_name"].ToString().Trim());
                                }
                            }

                            /*
                             * Ȩ��Ч�� �ж��Ƿ�����Ӧ�Ĳ���Ȩ��
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
                                    string jobtitle = temprow["jobtitle"].ToString().Trim(); //ְ���ְ��ID
                                    string types = temprow["types"].ToString().Trim();       //����
                                    int levels = Convert.ToInt16(temprow["levels"].ToString().Trim());     //����

                                    //ְ��
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
                                            else if (Sign.Contains("��"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("��"))
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

                                    //ְ��
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
                                            else if (Sign.Contains("��"))
                                            {
                                                if (alevel >= levels)
                                                {
                                                    flagJob = true;
                                                }
                                            }
                                            else if (Sign.Contains("��"))
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
                                    //���ְҵ֤��                                   
                                    if (buttonRights1[j].ToString() == "���ܴ�")
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

                                    if (buttonRights1[j].ToString() == "��ִҵ֤��")
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

                                    if (buttonRights1[j].ToString() == "����������")
                                    {
                                        //���������� tng_id
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
                                            //else   //patient_group_id = 0,��ʱ����û�������������
                                            //{
                                            //    flagbutton1 = true;
                                            //}
                                        }
                                        //else   //��¼�˺�û�����ƻ���������
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
                                    //�ʻ����� 53��ʵϰ 54�ɽ���
                                    if (buttonRights2[j].ToString().Trim() == "��ʵϰ")
                                    {
                                        flagbutton2_shixi = true;
                                    }

                                    //if (buttonRights2[j].ToString().Trim() == "�ɽ���")
                                    //{
                                    //    flagbutton2_jinxiu = true;
                                    //}
                                }
                            }

                            if (Roleflag == "0")      //�������Roleflag=0,Ĭ��Ȩ����Ч
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

                //ˢ�������尴ť
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
        /// �������
        /// </summary>
        public static void Text_Preview()
        {
            //ˢ�������尴ť
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
                         * �������ť�� ע�� ��ɫѡ�� һ��EnableΪtrue
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
                         * �������ť�� ע�� ��ɫѡ�� һ��EnableΪtrue
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
        /// ��ȡ��׼24Сʱ�Ƶ�ʱ��
        /// </summary>
        /// <param name="Time">ʱ�����</param>
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
        /// ��ȡ�̶�ʱ���
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
        /// �ж��Ƿ��������ַ�
        /// </summary>
        /// <param name="srcString">�ַ�������</param>
        /// <returns></returns>
        public static bool CheckChineseEncode(string srcString)
        {
            int strLen = srcString.Length;
            //�ַ����ĳ��ȣ�һ����ĸ�ͺ��ֶ���һ��
            int bytLeng = System.Text.Encoding.UTF8.GetBytes(srcString).Length;
            //�ַ������ֽ�������ĸռ1λ������ռ2λ,ע�⣬һ��ҪUTF8
            bool chkResult = false;
            if (strLen < bytLeng)
            //����ַ����ĳ��ȱ��ַ������ֽ���С����Ȼ���������к�����^-^
            {
                chkResult = true;
            }
            return chkResult;
        }


        /// <summary>
        /// ��������ϼ�ҽʦǩ��
        /// </summary>
        public static Class_DocSign InSerterHighLevelDigSign()
        {
            frmHightLevelDigSign fr = new frmHightLevelDigSign("", "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }


        /// <summary>
        /// �����ϼ�ҽʦǩ��
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign()
        {
            frmHightLevelSign fr = new frmHightLevelSign("", "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// ����ܴ�ҽʦǩ��
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign(string Type)
        {
            frmHightLevelSign fr = new frmHightLevelSign(Type, "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// ����ܻ�ʿ/ʦǩ��
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign_Nurse(string Type)
        {
            frmHightLevelSign_Nurse fr = new frmHightLevelSign_Nurse(Type, "");
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// �޸�ҽʦǩ��
        /// </summary>
        /// <param name="Type">����S</param>
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
        /// �޸Ļ�ʿ/ʦǩ��
        /// </summary>
        public static Class_DocSign InSerterHighLevelSign_Nurse(string Type, string userid)
        {
            frmHightLevelSign_Nurse fr = new frmHightLevelSign_Nurse(Type, userid);
            App.FormStytleSet(fr, false);
            fr.ShowDialog();
            return App.DocSign;
        }

        /// <summary>
        /// ����ְ��ְ�Ʒ��ؼ���ߵ��� 0�б�ʧ�� ��Ϊ0�ɹ�
        /// </summary>
        /// <param name="User_A_Id">Ա��A</param>
        /// <param name="User_B_Id">Ա��B</param>
        /// <returns>0�б�ʧ�� ����Ļ����ظ߼����userid</returns>
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
                    //��ȡְ��ְ�ƹ�ϵ��
                    DataSet ds = App.GetDataSet("select * from t_in_doc_jobtitle");

                    /*
                     * ��ȡAԱ����ʵ��
                     */
                    Class_User tinfo_A = new Class_User();
                    DataSet ds_infoA = App.GetDataSet("select * from T_USERINFO where user_id=" + User_A_Id + "");
                    tinfo_A.User_id = User_A_Id;
                    tinfo_A.User_name = ds_infoA.Tables[0].Rows[0]["USER_NAME"].ToString();
                    tinfo_A.U_tech_post = ds_infoA.Tables[0].Rows[0]["U_TECH_POST"].ToString(); //ְ��

                    if (UserAccount.UserInfo.User_id == tinfo_A.User_id)
                    {
                        tinfo_A.U_position = UserAccount.CurrentSelectRole.Role_id;  //ְ��
                    }
                    else
                    {
                        string sql_u = "select a.role_id from t_acc_role a inner join t_account_user b on a.account_id=b.account_id where b.user_id=" + User_A_Id + "";
                        DataSet ds_a_u = GetDataSet(sql_u);
                        tinfo_A.U_position = ds_a_u.Tables[0].Rows[0]["role_id"].ToString();

                    }

                    /*
                     * ��ȡBԱ����ʵ��
                     */
                    Class_User tinfo_B = new Class_User();
                    DataSet ds_infoB = App.GetDataSet("select * from T_USERINFO where user_id=" + User_B_Id + "");
                    tinfo_B.User_id = User_B_Id;
                    tinfo_B.User_name = ds_infoB.Tables[0].Rows[0]["USER_NAME"].ToString();
                    tinfo_B.U_tech_post = ds_infoB.Tables[0].Rows[0]["U_TECH_POST"].ToString(); //ְ��


                    if (UserAccount.UserInfo.User_id == tinfo_B.User_id)
                    {
                        tinfo_B.U_position = UserAccount.CurrentSelectRole.Role_id;  //ְ��
                    }
                    else
                    {
                        string sql_u = "select a.role_id from t_acc_role a inner join t_account_user b on a.account_id=b.account_id where b.user_id=" + User_B_Id + "";
                        DataSet ds_b_u = GetDataSet(sql_u);
                        tinfo_B.U_position = ds_b_u.Tables[0].Rows[0]["role_id"].ToString();
                    }

                    // tinfo_B.U_position = ds_infoB.Tables[0].Rows[0]["U_POSITION"].ToString();  //ְ��

                    string leave_a = "0";
                    string leave_b = "0";
                    string userid = "0";
                    DataRow[] rowas;
                    DataRow[] rowbs;

                    /*
                     * ְ����ж�
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
                         * ְ�Ƶ��ж�
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
        /// ��ȡ������Ľ��
        /// </summary>
        /// <param name="pid">����סԺ��</param>
        public static void ShowLisResault(string pid)
        {
            LisResault = "";
            Bifrost.HisInstance.FrmLis fm = new Bifrost.HisInstance.FrmLis(pid);
            fm.Show();

        }

        /// <summary>
        /// ��ӵ�ǰ����������Ϣ
        /// </summary>
        /// <param name="?"></param>
        public static void AddCurrentDocMsg(string DocName)
        {
            OperaterDocIdS.Add(DocName);
        }

        /// <summary>
        /// ɾ����ǰ����������Ϣ
        /// </summary>
        /// <param name="?"></param>
        public static void DelCurrentDocMsg(string DocName)
        {
            OperaterDocIdS.Remove(DocName);
        }

        /// <summary>
        /// �жϵ�ǰ�����Ƿ��Ѿ����˴�
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
        /// ��յ�ǰ������������Ϣ
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
                            #region ��Դ����
                            string host = Encrypt.DecryptStr(Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini"));
                            IPAddress ServerIp = IPAddress.Parse(host);
                            string uri = "tcp://" + ServerIp + ":2000/TcpService";
                            object o = Activator.GetObject(typeof(DbHelp), uri);

                            Operater2 = (DbHelp)o;
                            string sendStr = App.GetHostIp() + ";" + App.UserAccount.UserInfo.User_name + ";" + App.UserAccount.UserInfo.U_position_name + ";" + App.UserAccount.UserInfo.U_tech_post_name + ";" + App.UserAccount.Account_name + @"!";
                            /*
                            * ��ǰ���ڲ���������Ͳ���ID����
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
                // ��state�����ȡsocket.  
                Socket client = (Socket)ar.AsyncState;
                // �������.  
                client.EndConnect(ar);
                // ��������ɣ����̼߳���.  
                connectDone.Set();
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }

        private static string Receive(Socket client)
        {
            try
            {   // ��������state.  
                StateObject state = new StateObject();
                state.workSocket = client;
                // ��Զ��Ŀ���������.  
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
                // ����������첽state�����л�ȡstate��socket����  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                //��Զ���豸��ȡ����  
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {  // �����ݣ��洢.  
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                    // ������ȡ.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {  // �������ݶ�ȡ���.  
                    if (state.sb.Length > 1)
                    { response = state.sb.ToString(); }  // �������ݶ�ȡ��ϵ�ָʾ�ź�.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }

        private static void Send(Socket client, String data)
        {  // ��ʽת��.  
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            // ��ʼ�������ݵ�Զ���豸.  
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // ��state�����л�ȡsocket  
                Socket client = (Socket)ar.AsyncState;
                // ������ݷ���.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                // ָʾ�����Ѿ�������ɣ����̼߳���.  
                sendDone.Set();
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }



        /// <summary>
        /// ת���������ڼ��ĺ���
        /// </summary>
        /// <param name="date">����ʱ��</param>
        /// <returns></returns>
        public static string dateToChsWeek(System.DateTime date)
        {
            string week = date.DayOfWeek.ToString();
            switch (week)
            {
                case "Monday": return "����һ";
                case "Tuesday": return "���ڶ�";
                case "Wednesday": return "������";
                case "Thursday": return "������";
                case "Friday": return "������";
                case "Saturday": return "������";
                default: return "������";
            }
        }

        /// <summary>
        /// ���˽����е�SQL�ؼ��� 
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
        /// ������ǰ�ʿ�ʱ��
        /// </summary>
        /// <param name="patient_Id">����ID</param>
        /// <param name="textType_Id">��������</param>
        /// <param name="xmldocument">xml����</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument)
        {
            return "";
        }

        /// <summary>
        /// ������ǰ�ʿ�ʱ��
        /// </summary>
        /// <param name="patient_Id">����ID</param>
        /// <param name="textType_Id">��������</param>
        /// <param name="xmldocument">xml����</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument, out bool isOkDiagnose)
        {
            isOkDiagnose = false;
            return "";
        }


        /// <summary>
        /// ������ǰ�ʿ�ʱ��
        /// </summary>
        /// <param name="patient_Id">����ID</param>
        /// <param name="textType_Id">��������</param>
        /// <param name="xmldocument">xml����</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument, out bool isOkDiagnose, out string referDiagnoseTime, bool isNew)
        {
            isOkDiagnose = false;
            referDiagnoseTime = "";
            return "";
        }

        /// <summary>
        /// ������ǰ�ʿ�ʱ��
        /// </summary>
        /// <param name="patient_Id">����ID</param>
        /// <param name="textType_Id">��������</param>
        /// <param name="xmldocument">xml����</param>
        /// <returns></returns>
        public static string checkDocRule(string patient_Id, string textType_Id, System.Xml.XmlDocument xmldocument, out bool isOkDiagnose, out string referDiagnoseTime, int replaceHigher, bool isNew)
        {
            string patient_id = patient_Id;//����ID
            string document_id = textType_Id;//����ID
            DateTime in_time = new DateTime();//��Ժʱ��
            DateTime record_time = new DateTime();//��¼ʱ��
            DateTime sign_time = new DateTime();//ǩ��ʱ��
            DateTime inital_time = new DateTime();//�������ʱ��
            DateTime confirm_time = new DateTime();//ȷ�����ʱ��            
            DateTime out_time = new DateTime();//��Ժʱ��
            DateTime reference_time = new DateTime();//�ο�ʱ��,��ʱ�䣬���ڱȽ�ʱ���Ƿ��ǿ�
            DateTime tittle_time = new DateTime();//����ʱ��
            string doc_tittle = "";
            isOkDiagnose = false;
            referDiagnoseTime = "";
            /*
             * ��ȡ������ص�ƥ������,��Ժʱ�䣨�ο�ʱ�䣩����Ժʱ���
             * ҽ�񴦹����,�������ͣ�ƫ��ʱ�䣬Ԥ��ֵ��ִ������
             */
            string SqlInfo = "select a.in_time,b.happen_time,b.action_type from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id where a.id=" + patient_Id + " and b.next_id=0";
            DataSet PatientInfods = App.GetDataSet(SqlInfo);
            if (PatientInfods != null)
            {
                if (PatientInfods.Tables[0].Rows.Count > 0)
                {
                    in_time = Convert.ToDateTime(PatientInfods.Tables[0].Rows[0]["in_time"].ToString());
                    if (PatientInfods.Tables[0].Rows[0]["action_type"].ToString() == "����")
                    {
                        out_time = Convert.ToDateTime(PatientInfods.Tables[0].Rows[0]["happen_time"].ToString());
                    }

                }
            }
            DataSet ruleds = App.GetDataSet("select aa.*,bb.code from t_quality_var_ywc aa inner join t_data_code bb on aa.document_type=bb.id");

            /*
             * ����XML�ĵ���ȡ���ֵ����¼ʱ�䣬ǩ��ʱ��,ȷ�����ʱ�䣬�������ʱ��,����ʱ�䣩
             */

            XmlNode bodynode = xmldocument.ChildNodes[0].SelectSingleNode("body");
            #region �������
            if (bodynode.ChildNodes[0].Attributes["title"] != null)
                doc_tittle = bodynode.ChildNodes[0].Attributes["title"].Value;
            #endregion
            if (bodynode != null)
            {
                #region ��ȡ��¼ʱ��
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
                            //��¼ʱ��
                            jlrq = jlrq.Replace("��", ":");
                            record_time = Convert.ToDateTime(jlrq.Replace("��", " "));
                        }
                    }
                }
            }
            #endregion
            #region ��ȡ����ǩ��ʱ��
            XmlNode signnode = bodynode.SelectSingleNode("input[@name='����ʱ��']");
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
                //ǩ��ʱ��
                qmsj = qmsj.Replace("��", ":");
                sign_time = Convert.ToDateTime(qmsj.Replace("��", " "));
            }
            #endregion
            #region ��ȡ������� �� ȷ����� ʱ��
            string cbzdTime = "";
            string sjTime = "";
            XmlNode footnode = bodynode.SelectSingleNode("div[@id='divFoot']");
            XmlNodeList footnodeList = xmldocument.GetElementsByTagName("input");
            for (int i = 0; i < footnodeList.Count; i++)
            {
                if (footnodeList[i].Attributes["name"].Value == "��ͨҽʦ����")
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
                if (footnodeList[i].Attributes["name"].Value == "�ϼ�ҽʦ����")
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
                //�������ʱ��
                cbzdTime = cbzdTime.Replace("��", ":");
                inital_time = Convert.ToDateTime(cbzdTime.Replace("��", " "));
            }
            if (sjTime != "")
            {
                //ȷ�����ʱ��
                sjTime = sjTime.Replace("��", ":");
                confirm_time = Convert.ToDateTime(sjTime.Replace("��", " "));
            }

            #endregion
            /*
             * ����ı���ͬʱ���ؽ��
             * �ο�ʱ��+ƫ��ʱ�� Ԥ��ʱ��͵�ǰʱ��Ƚ�
             * ��ǰʱ��>�ο�ʱ��&&��ǰʱ��<�ο�ʱ��+ƫ��ʱ��-Ԥ��ʱ���ʾʱ������
             * ��ǰʱ��>�ο�ʱ��+ƫ��ʱ��-Ԥ��ʱ��&&�ο�ʱ��+ƫ��ʱ���ʾ��ǰ������Ԥ��ʱ���ڣ�Ҫ�ٶ����
             * ��ǰʱ��>�ο�ʱ��+ƫ��ʱ���ʾ�����Ѿ���ʱ
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
                    if (textType_Id == "119")//�Ѳ���
                    {
                        // 1.��Ժ��¼
                        return Class_Doc_Rule.In_Area_Rule(in_time, record_time, inital_time, confirm_time, reference_time, turntime, unit, ref isOkDiagnose, ref referDiagnoseTime);
                    }
                    else if (textType_Id == "120")
                    {
                        // 2. 24Сʱ�����Ժ��¼                       
                        return Class_Doc_Rule.In_Out_Area_Rule(turntime, unit, in_time, sign_time, xmldocument);
                    }
                    else if (textType_Id == "121")
                    {
                        // 3. 24Сʱ����Ժ������¼                       
                        return Class_Doc_Rule.In_Die_Area_Rule(turntime, unit, in_time, sign_time, xmldocument);
                    }
                    else if (textType_Id == "1162" || textType_Id == "1201")
                    {
                        #region 4.�ƻ���������/סԺ����
                        //�����мƻ���������/סԺ����
                        return Class_Doc_Rule.Beijing_Birth_Control_Record_Rule(in_time, sign_time, xmldocument, out_time, doc_tittle);
                        #endregion
                    }
                    //else if (textType_Id == "1161")//סԺ�����У�����ǩ��ʱ�䣨����ǩ�������ʱ�䣩û��
                    //{
                    //    //һ�ղ���סԺ��������Σ�
                    //    return Class_Doc_Rule.Day_Medical_Record_Curattage_Rule(in_time, sign_time, xmldocument, out_time);
                    //}
                    else if (textType_Id == "125")//�Ѳ���
                    {
                        // 6.�״β��̼�¼                       
                        return Class_Doc_Rule.First_Medical_Record_Rule(turntime, unit, tittle_time, doc_tittle, in_time);
                    }
                    //else if (textType_Id == "126")
                    //{
                    //    // 7.���̼�¼.һ�㲡�̼�¼                        
                    //    return Class_Doc_Rule.Day_Medical_Record_Rule(patient_id, in_time, turntime, unit, tittle_time, doc_tittle, replaceHigher);
                    //}
                    //else if (textType_Id == "127")//�Ѳ���
                    //{
                    //    //8.9.�ϼ��鷿��¼                      
                    //    return Class_Doc_Rule.Higher_Docter_Check_Rule(doc_tittle, patient_id, in_time, tittle_time);
                    //}

                    else if (textType_Id == "130")//�Ѳ���
                    {
                        //10.���̼�¼--ת����¼                       
                        return Class_Doc_Rule.Turn_Out_Rule(tittle_time, doc_tittle, patient_Id, reference_time, out_time, in_time);
                    }
                    else if (textType_Id == "301")//�Ѳ���
                    {
                        //11.���̼�¼--ת���¼                      
                        return Class_Doc_Rule.Turn_In_Rule(in_time, reference_time, out_time, patient_id, turntime, unit, tittle_time, doc_tittle, isNew);
                    }
                    else if (textType_Id == "890")//ͬ891û��
                    {
                        //12.�����¼                                              
                        return Class_Doc_Rule.JiaoBan_Record_Rule(tittle_time, doc_tittle, reference_time, in_time);
                    }
                    else if (textType_Id == "891")//�Ѳ���û��
                    {
                        // 13.�Ӱ��¼                       
                        return Class_Doc_Rule.JieBan_Record_Rule(tittle_time, doc_tittle, in_time, patient_Id);
                    }
                    //else if (textType_Id == "136")//û���ϻ�ʿվû��
                    //{
                    //    #region 14.�����״β��̼�¼
                    //    //��������ʱ��ȡ�Ի�ʿվ�����µ�,��ʿվû����
                    //    return "�����״β��̼�¼����ʱ��ȡ�Ի�ʿվ����ʿվû����";
                    //    #endregion
                    //}
                    else if (textType_Id == "131")//�׶�С���������Եģ�true_time��truetime_unitӦ����runcycle,runcycleunit
                    {

                        //DateTime temptime = new DateTime();
                        tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
                        turntime = Convert.ToInt16(ruleds.Tables[0].Rows[i]["runcycle"]);
                        unit = ruleds.Tables[0].Rows[i]["runcycleunit"].ToString();
                        //15.�׶�С��                       
                        return Class_Doc_Rule.Stage_Summary_Rule(tittle_time, doc_tittle, turntime, unit, in_time, patient_Id);
                    }
                    //else if (textType_Id == "133")//�����ʱ�������ʱ��
                    //{
                    //    // 16.�����¼           
                    //    return Class_Doc_Rule.Consultaion_Record_Rule(patient_id, turntime, unit, tittle_time, doc_tittle);
                    //}
                    //else if (textType_Id == "151")
                    //{
                    //    //������¼
                    //    return Class_Doc_Rule.Operation_Record_Rule(patient_Id, xmldocument, in_time, isNew);
                    //}
                    else if (textType_Id == "158")//�Ѳ��ԣ���Ժǰ���һ�β���ʱ��
                    {
                        //17.1��Ժ��¼                       
                        return Class_Doc_Rule.Out_Record_Rule(patient_id, in_time, tittle_time, doc_tittle, xmldocument);
                    }
                    else if (textType_Id == "138")//ͬ17.1 û�н��в���
                    {
                        //17.2������¼                     
                        return Class_Doc_Rule.Die_Record_Rule(patient_id, in_time, tittle_time, doc_tittle, xmldocument);
                    }
                    else if (textType_Id == "844")
                    {
                        // 17.3  ���һ�β��̼�¼                      
                        return Class_Doc_Rule.Last_Medical_Record_Rule(tittle_time, doc_tittle, in_time);
                    }
                    else if (textType_Id == "139")//û�в���
                    {
                        //18.�����������ۼ�¼                       
                        return Class_Doc_Rule.Die_Discussion_Record(patient_Id, turntime, unit, out_time, tittle_time, doc_tittle);
                    }

                }
            }
            return "";
        }

        /// <summary>
        /// ����̬����ת��Ϊ�ַ�������
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
        /// ���ݷ�Ժֵ��ȡ���������б�
        /// </summary>
        /// <param name="ServerList">���������б�</param>
        /// <param name="type">����ֵ</param>
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
        /// ��ȡ����ֵ����
        /// </summary>
        /// <param name="serverlist">�������б�</param>
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
        /// ��ȡ��Ȩ�������Ȩ��
        /// </summary>
        /// <param name="patient_id">��������</param>
        /// <param name="textid">��������</param>
        /// <param name="operater">������ʽ 0 ���� 1��� 2�޸�</param>
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
                                //����
                                if (relation.Split(',')[i] == App.UserAccount.CurrentSelectRole.Section_Id)
                                {
                                    for (int j = 0; j < function.Split(',').Length; j++)
                                    {
                                        if (function.Split(',')[j] == "����" && operater == 0)
                                        {
                                            SetToolButtonByUser("tsbtnCommit", true);
                                            SetToolButtonByUser("ttsbtnPrint", true);
                                            SetToolButtonByUser("tsbtnTemplate", true);
                                            SetToolButtonByUser("tsbtnTemplateSave", true);
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "�鿴" && operater == 1)
                                        {
                                            //SetToolButtonByUser("tsbtnCommit", true);
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "�޸�" && operater == 2)
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
                                //����
                                //����
                                if (relation.Split(',')[i] == App.UserAccount.UserInfo.User_id)
                                {
                                    for (int j = 0; j < function.Split(',').Length; j++)
                                    {
                                        if (function.Split(',')[j] == "����" && operater == 0)
                                        {
                                            SetToolButtonByUser("tsbtnCommit", true);
                                            SetToolButtonByUser("ttsbtnPrint", true);
                                            SetToolButtonByUser("tsbtnTemplate", true);
                                            SetToolButtonByUser("tsbtnTemplateSave", true);
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "�鿴" && operater == 1)
                                        {
                                            return "";
                                        }
                                        else if (function.Split(',')[j] == "�޸�" && operater == 2)
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
                        return "��Ȩ�Ѿ�����ʱЧ";
                    }
                    return "�ò���û�еõ���Ȩ";
                }
                else
                {
                    return "�ò���û�еõ���Ȩ";
                }
            }
            else
            {
                return "�ò���û�еõ���Ȩ";
            }
        }

        #endregion

        #region ��������ť�¼�����
        /// <summary>
        /// ��д
        /// </summary>
        public static EventHandler A_Write;

        /// <summary>
        /// ǩ��
        /// </summary>
        public static EventHandler A_Sign;

        /// <summary>
        /// ���
        /// </summary>
        public static EventHandler A_Check;

        /// <summary>
        /// �޸�
        /// </summary>
        public static EventHandler A_Modify;

        /// <summary>
        /// ɾ��
        /// </summary>
        public static EventHandler A_Delete;

        /// <summary>
        /// �鿴
        /// </summary>
        public static EventHandler A_Look;

        /// <summary>
        /// ����
        /// </summary>
        public static EventHandler A_Import;

        /// <summary>
        /// ����
        /// </summary>
        public static EventHandler A_OutPut;

        /// <summary>
        /// ��ȡģ��
        /// </summary>
        public static EventHandler A_Template;

        /// <summary>
        /// ����Ϊģ��
        /// </summary>
        public static EventHandler A_TemplateSave;

        /// <summary>
        /// ��ȡ·��ģ��
        /// </summary>
        public static EventHandler A_Path_Template;

        /// <summary>
        /// ����Ϊ·��ģ��
        /// </summary>
        public static EventHandler A_Path_TemplateSave;

        /// <summary>
        /// ֪��ͬ��������ӡ�¼�
        /// </summary>
        public static EventHandler A_BachePrint;

        /// <summary>
        /// ����ΪСģ��
        /// </summary>
        public static EventHandler A_SmallTemplateSave;

        /// <summary>
        /// ��ӡ�¼�
        /// </summary>
        public static EventHandler A_Print;

        /// <summary>
        /// ����ӡ�¼�
        /// </summary>
        public static EventHandler A_PrintContinue;

        /// <summary>
        /// �ݴ�
        /// </summary>
        public static EventHandler A_TempSave;

        /// <summary>
        /// �ύ
        /// </summary>
        public static EventHandler A_Commit;

        /// <summary>
        /// ˢ�����ؼ�
        /// </summary>
        public static EventHandler A_RefleshTreeBook;

        /// <summary>
        /// ��Ⱦ�������ϱ�
        /// </summary>
        public static EventHandler A_BKSB;

        /// <summary>
        /// ��������
        /// </summary>
        public static EventHandler A_HZTX;

        /// <summary>
        /// �鿴����
        /// </summary>
        public static EventHandler A_CheckSick;

        /// <summary>
        /// �鿴���µ�
        /// </summary>
        public static EventHandler A_CheckTemprature;

        /// <summary>
        /// �鿴�����¼��
        /// </summary>
        public static EventHandler A_tsbtnCheckNurseRecord;

        /// <summary>
        /// �鿴��������
        /// </summary>
        public static EventHandler A_CheckLis;

        /// <summary>
        /// �鿴Ӱ�񱨸�
        /// </summary>
        public static EventHandler A_CheckPacs;

        /// <summary>
        /// ��������
        /// </summary>
        public static EventHandler A_CheckOperator;

        /// <summary>
        /// ������������
        /// </summary>
        public static EventHandler A_PatientSickInfoApply;

        /// <summary>
        /// �鵵�˻�����
        /// </summary>
        public static EventHandler A_BackSickInfoApply;

        /// <summary>
        /// ���в�������
        /// </summary>
        public static EventHandler A_UsedSickInfoCheck;

        /// <summary>
        /// ����Ȩ�������
        /// </summary>
        public static EventHandler A_DocRights;

        /// <summary>
        /// ��������
        /// </summary>
        public static EventHandler A_MedicalRecordFinishing;

        /// <summary>
        /// �����鵵
        /// </summary>
        public static EventHandler A_MedicalRecords;

        /// <summary>
        /// δ��ɹ���
        /// </summary>
        public static EventHandler A_UnfinishedWork;

        ///// <summary>
        ///// ��ϱ༭
        ///// </summary>
        public static EventHandler A_btnInsertDiosgin;

        ///// <summary>
        ///// ˢ�����
        ///// </summary>
        public static EventHandler A_btnRefreshDiosgin;
        #endregion

        #region FlexGrid����


        /// <summary>
        ///  �����ﶨ���ݼ�
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

        #region DataGridViewX����
        /// <summary>
        ///  �����ﶨ���ݼ�
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

        #region �ٴ�·��       

        #region ���л�����
        /// <summary>
        /// Function:soap���л�����
        /// CreateTime:2011-12-2
        /// Author:Kenneth
        /// </summary>
        /// <param name="obj">����Object</param>
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
        /// Function:soap�����л�����
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

        #region ��ȡ����xml
        /// <summary>
        /// ��ȡ����xml
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

        #region �����޸ĺ��xml����
        /// <summary>
        /// �����޸ĺ��xml����
        /// </summary>
        /// <param name="selectDocSql">��ѯ��ǰ�������鷵��xml</param>
        /// <param name="path">xml�ļ�����·��</param>
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
                if (File.Exists(docpath)) //���xml���ڣ���ɾ��xml
                {
                    File.Delete(docpath);
                }
                xmldoc.Save(docpath);
            }
        }
        #endregion

        #region �޸���������
        /// <summary>
        /// �޸���������(������ʵ��)
        /// </summary>
        /// <param name="updateTitleSql">�޸���������sql���</param>
        /// <param name="selectDocSql">��ѯ��������sql���</param>
        /// <param name="headid">��ͷ����ʵ��id</param>
        /// <param name="MainTitle">������</param>
        /// <param name="ScendTitle">������</param>
        /// <returns>1����0</returns>
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

                        App.Msg("�޸ĳɹ�!");
                        return 1;
                    }
                }
            }
            return 0;
        }
        //û�д�ʵ����
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
                            App.Msg("�޸ĳɹ�!");
                        }
                        return 1;
                    }
                }
            }
            return 0;
        }
        #endregion

        #region ������֤
        /// <summary>
        /// ��ȡ����
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
        /// ��ȡ�ַ�
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
        /// ��ȡ�ַ�
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
        /// ��ȡ����
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
        /// ��ȡ�ַ�
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
        /// �ַ��������Ƚض�
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

        #region FTP����

        /// <summary>
        /// ���ļ��ϴ���Ftp
        /// </summary>
        /// <param name="filename">�ļ�ȫ·��</param>
        /// <param name="fileid">�ļ�������</param>
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
        /// ���ļ��ϴ���Ftp
        /// </summary>
        /// <param name="filename">�ļ�ȫ·��</param>
        /// <param name="fileid">�ļ�������</param>
        /// <param name="Type">���� L ������ �� P Ӱ�� �� D ���Ӳ���</param>
        /// <param name="PatientId">��������</param>
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
        /// ����д�������ϴ���Ftp
        /// </summary>
        /// <param name="fileName">��д�����</param>
        /// <param name="docname">��������</param>
        /// <param name="PatientId">��������</param>  
        /// <param name="isFileUpLoad">�Ƿ��ļ��ϴ�</param>
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
        /// ����д�������ϴ���Ftp
        /// </summary>
        /// <param name=" XMLOut">��д�����</param>
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
                    //�����������ʧ�ܵ�����£��ͱ��汾��Ŀ¼
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
        /// ����д�����������ϴ���Ftp
        /// </summary>
        /// <param name=" XMLOut">��д�����</param>
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
                    //�����������ʧ�ܵ�����£��ͱ��汾��Ŀ¼
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
        /// ��Ftp�ϻ�ȡ����
        /// </summary>
        /// <param name="docname">�������ƣ�����������'xml' ���硰123.xml����</param>
        /// <param name="PatientId">��������</param>
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
                    //��ʾ�ӷ�������û�ж�ȡ��������Ϣ,Ȼ��ӿͻ��˶�ȡ
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
        /// ��Ftp�ϻ�ȡ��������
        /// </summary>
        /// <param name="docname">�������ƣ�����������'xml' ���硰123.xml����</param>
        /// <param name="PatientId">��������</param>
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
        /// �����鱣�汾����ʱĿ¼
        /// </summary>
        /// <param name="XMLOut"></param>
        /// <param name="docname"></param>
        /// <param name="PatientId"></param>
        /// <param name="ismzflag">�Ƿ������� true ��</param>
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
        /// ��ȡ���汾����ʱĿ¼�е�����
        /// </summary>
        /// <param name="XMLOut"></param>
        /// <param name="docname"></param>
        /// <param name="PatientId"></param>
        /// <param name="ismzflag">�Ƿ������� true ��</param>
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
        /// �ϴ�û���ϴ��������
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
                                //����ϴ��ɹ�ɾ�������ļ�
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
        /// �ϴ��������ɵ�ͼƬ
        /// </summary>
        /// <param name="Patient_id">��������</param>
        /// <param name="fileName">ͼƬ���ƣ����磺test.jpg,2.jpg�ȣ�</param>
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
                //            byte[] imgByte = new byte[imgFile.Length];//1.��ʼ�����ڴ��ͼƬ���ֽ�����   
                //            System.IO.FileStream imgStream = imgFile.OpenRead();//2.��ʼ����ȡͼƬ���ݵ��ļ���   
                //            imgStream.Read(imgByte, 0, Convert.ToInt32(imgFile.Length));//3.��ͼƬ����ͨ���ļ�����ȡ���ֽ�����   

                //            if (WebService.UploadDocImageFile(imgByte, dirname, filsname) == "�ϴ��ɹ�")
                //            {
                //                //����ɹ�ɾ�����ض�Ӧ��ͼƬ
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
        /// ����ftp·��
        /// </summary>
        /// <param name="uploadUrl">����ftp·��</param>   
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
        /// Ŀ¼�Ƿ����
        /// </summary>
        /// <param name="uploadUrl">·��</param>
        /// <param name="uname">�û���</param>
        /// <param name="password">����</param>
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

        /// �ж��ַ������Ƿ���SQL�������룬by fangbo.yu 2008.07.18
        /// �����û��ύ����
        /// true-��ȫ��false-��ע�빥�����У�
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


        /// �ָ��� ����SQL�ַ��� 
        public static string ReplacePageChar(string str)
        {
            if (str == String.Empty)
                return String.Empty;
            str = str.Replace("��", "'");
            str = str.Replace("��", ";");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("��", "<");
            str = str.Replace("��", ">");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("��", "@");
            str = str.Replace("��", "=");
            str = str.Replace("��", "+");
            str = str.Replace("��", "*");
            str = str.Replace("��", "&");
            str = str.Replace("��", "#");
            str = str.Replace("��", "%");
            str = str.Replace("��", "$");
            return str;
        }
        #endregion

        #region �ڲ�˽�к���
        ///// <summary>
        ///// ��ѯ�ؼ��е��ӿؼ�������C1���ؼ�������һЩ�ؼ�����ʽ��������
        ///// </summary>
        ///// <param name="c">��ǰ�ؼ�</param>
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
        /// ��ѯ�ؼ��е��ӿؼ�������C1���ؼ�������һЩ�ؼ�����ʽ��������
        /// </summary>
        /// <param name="c">��ǰ�ؼ�</param>
        private static void GetControl(System.Windows.Forms.Control c)
        {
            try
            {
                //c.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                if (c is ButtonX)
                {
                    ButtonX c1 = c as ButtonX;
                    c1.Style = eDotNetBarStyle.StyleManagerControlled;
                    c1.ColorTable = eButtonColor.OrangeWithBackground;
                    c1.Cursor = System.Windows.Forms.Cursors.Hand;
                    //c1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //c1.ForeColor = Color.White;
                }
                if (c is Label)
                {
                    //c.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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

                    //c1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                }
                if (c is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    DevComponents.DotNetBar.Controls.TextBoxX c1 = c as DevComponents.DotNetBar.Controls.TextBoxX;
                    c1.BorderStyle = BorderStyle.None;
                    //c1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

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
                    //temp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
                    //c1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
                    //c1.Font = new Font("����", 9);
                    //c1.SelectedTabFont= new Font("����", 9);
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
        /// ��ѯ�ؼ��е��ӿؼ�������C1���ؼ�������һЩ�ؼ�����ʽ��������
        /// </summary>
        /// <param name="c">��ǰ�ؼ�</param>
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
        /// ��������������
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
        /// ������
        /// </summary>
        private static void MonoProc()
        {
            FrmProgress objFrmProgress = new FrmProgress();
            objFrmProgress.label1.Text = progressmsg;
            objFrmProgress.ShowDialog();
        }

        /// <summary>
        /// ������������Ϣ���е���Ϣ
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
        /// ����ת�������ݼ�
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
        /// ������������䵽���ݼ�        
        /// </summary>
        /// <param name="ds">���ݼ�</param>
        /// <param name="objArr">��������</param>
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
        /// ����ת�� Bifrost.WebReference.OracleParameter���ͺ�DBParameter֮�������ת��
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
        /// �жϸ��൥�������Ƿ��Ѿ�����
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">����id</param>
        /// <returns></returns>
        private static string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "'";
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
        }

        /// <summary>
        /// ����ģ���
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
        /// ��ȡ��ǰ�����ķ�Ժ
        /// </summary>
        /// <param name="serverlist">��Ժ�б�</param>
        /// <returns>����0 Ϊʧ��</returns>
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
                    if (Ask("ȷ��Ҫ�ر�'" + item.Text + "'"))
                        tabMain.Tabs.Remove(item);
                }
            }
        }


        /// <summary>
        /// ��ȡ����
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

                    //�����죬ƽ����

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

        #region �ڲ����к���
        /// <summary>
        /// ��ȡExcel�ļ��еı���
        /// </summary>
        /// <param name="ExcelFileName">Excel�ļ���·��</param>
        /// <param name="cmbTableName">Excel�еı���</param>
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
                MessageBox.Show("Excel�ļ����ܱ��򿪣�", "����:" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (oledbconn1.State == ConnectionState.Open)
                    oledbconn1.Close();
            }

        }
        #endregion
        /// <summary>
        /// ��ȡ��ʷ�����HTML����·��
        /// </summary>
        /// <param name="patient_Id">����������mr_file_index�е�patient_id</param>
        /// <param name="fileName">����������mr_file_index�е�file_name</param>
        /// <returns>html·��</returns>
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
        /// ����סԺ��
        /// </summary>
        /// <param name="Pid"></param>
        public static void GetListDatas(string Pid)
        {
            //WebReference_List.LISService LIS = new WebReference_List.LISService();           
            //string GetOrders = "";      //�걾��Ϣ��(LIS_SampleInfo)-����[סԺ��]�����Ϣ-t_lis_sample
            //string GetReport = "";      //��������(LIS_Result)-����[�걾��ˮ��]�����Ϣ-t_lis_result
            //string[] samples=null;
            //string[] reports=null;
            //List<string> sqls = new List<string>();
            //string isNull = null;            
            //try
            //{
            //    /*
            //     * ������
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
            //         *��������
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
            //        MsgErr("��ȡ����ʧ�ܣ�");
            //    }                             

            //}
            //catch (Exception ex)
            //{               
            //    MsgErr("��ȡ����ʧ�ܣ�"+ex.Message);
            //}

        }

        #region ����ʶ��

        private static string session_begin_params;
        private static WaveIn waveIn;
        private static AudioRecorder recorder;
        private static float lastPeak;//˵������
        private static float secondsRecorded;
        private static float totalBufferLength;
        private static int Ends = 5;
        private const int BUFFER_SIZE = 4096;
        private static List<VoiceData> VoiceBuffer = new List<VoiceData>();
        public static List<string> TextBuffer = new List<string>();
        /// <summary>
        /// ָ��ת�ַ���
        /// </summary>
        /// <param name="p">ָ����йܴ����ַ�����ָ��</param>
        /// <returns>����ָ��ָ����ַ���</returns>
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
            //newWaveIn.WaveFormat = new WaveFormat(16000, 16, 1); // 16bit,16KHz,Mono��¼����ʽ
            waveIn.WaveFormat = new WaveFormat(16000, 1);//16bit,1KHz ��¼����ʽ
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;
           
            waveIn.WaveFormat = new WaveFormat(16000, 1);
        }

        //����ʶ��
        private static void RunIAT(List<VoiceData> VoiceBuffer, string session_begin_params)
        {
            IntPtr session_id = IntPtr.Zero;
            string rec_result = string.Empty;
            string hints = "��������";
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

            //����ʶ����
            if (rec_result.Length != 0)
            {

                insertText(rec_result);


                //���ش������10111ʱ���ɵ���SpeechRecognition()����ִ��MSPLogin
            }
        }
        /// <summary>
        /// ��ʼ¼���ص�����       ����ػ񵽵�����
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
                    RunIAT(VoiceBuffer, session_begin_params);//��������ʶ��
                }

                VoiceBuffer.Clear();
                Ends = 5;
            }

        }
        /// <summary>
        /// ¼�������ص�����
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
        public static void SpeechRecognition()//��ʼ������ʶ��
        {
            int ret = (int)ErrorCode.MSP_SUCCESS;
            string login_params = string.Format("appid=5afa74fa,word_dir= . ");//appid��msc.dllҪ����
            #region ����
            /*
            *sub:����ʶ�����������  iat ��������ʶ��;   asr �﷨���ؼ���ʶ��,Ĭ��Ϊiat
            *domain:����      iat����������ʶ��  asr���﷨���ؼ���ʶ��    search���ȴ�   video����Ƶ    poi������  music������    Ĭ��Ϊiat�� ע�⣺sub=asrʱ��domainֻ��Ϊasr
            *language:����    zh_cn����������  zh_tw����������  en_us��Ӣ��    Ĭ��ֵ��zh_cn
            *accent:��������    mandarin����ͨ��    cantonese������    lmz���Ĵ��� Ĭ��ֵ��mandarin
            *sample_rate:��Ƶ������  ��ȡֵ��16000��8000  Ĭ��ֵ��16000   ����ʶ��֧��8000��������Ƶ
            *result_type:�����ʽ   ��ȡֵ��plain��json  Ĭ��ֵ��plain
            *result_encoding:ʶ�����ַ������ñ����ʽ  GB2312;UTF-8;UNICODE    ��ͬ�ĸ�ʽ֧�ֲ�ͬ�ı��룺   plain:UTF-8,GB2312  json:UTF-8
            */
            #endregion
            session_begin_params = "sub=iat,domain=iat,language=zh_cn,accent=mandarin,sample_rate=16000,result_type=plain,result_encoding=utf8";

            string Username = "";
            string Password = "";
            ret = MSCDLL.MSPLogin(Username, Password, login_params);

            if ((int)ErrorCode.MSP_SUCCESS != ret)//���ɹ�
            {
                //Console.WriteLine("ʧ����");
                Console.WriteLine("MSPLogin failed,error code:{0}", ret.ToString());
                MSCDLL.MSPLogout();
            }
        }
        private static WaveIn CreateWaveInDevice()//WaveInʵ����
        {
            WaveIn newWaveIn = new WaveIn();
            //newWaveIn.WaveFormat = new WaveFormat(16000, 16, 1); // 16bit,16KHz,Mono��¼����ʽ
            newWaveIn.WaveFormat = new WaveFormat(16000, 1);//16bit,1KHz ��¼����ʽ
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
        //            waveIn.StopRecording();//ֹͣ¼��
        //        }
        //    }
        //    catch (Exception ee)
        //    { }
        //}

            #endregion

        }

    /// <summary>
    /// ��¼�е���Ϣ
    /// </summary>
    public struct ColumnInfo
    {   
        /// <summary>
        /// �е�����
        /// </summary>
        public string Name;
        
        /// <summary>
        ///�ֶ��� 
        /// </summary>
        public string Field;    
        
        /// <summary>
        /// �ֶ��������е�λ��
        /// </summary>
        public int Index;

        /// <summary>
        /// ���Ƿ�ɼ�
        /// </summary>
        public bool visible;
    }

    //Ӳ��Win32_Processor ,Win32_PhysicalMemory,Win32_DiskDrive,Win32_BaseBoard,Win32_BIOS,Win32_ParallelPort,Win32_SerialPort,Win32_SystemSlot, Win32_USBController,Win32_DesktopMonitor, Win32_DisplayConfiguration,Win32_DisplayControllerConfiguration
    #region WMIPath   
    public enum WMIPath
    {
        // Ӳ��  
        Win32_Processor, // CPU ������  
        Win32_PhysicalMemory, // �����ڴ���  
        Win32_Keyboard, // ����  
        Win32_PointingDevice, // �������豸��������ꡣ  
        Win32_FloppyDrive, // ����������  
        Win32_DiskDrive, // Ӳ��������  
        Win32_CDROMDrive, // ����������  
        Win32_BaseBoard, // ����  
        Win32_BIOS, // BIOS оƬ  
        Win32_ParallelPort, // ����  
        Win32_SerialPort, // ����  
        Win32_SerialPortConfiguration, // ��������  
        Win32_SoundDevice, // ��ý�����ã�һ��ָ������  
        Win32_SystemSlot, // ������ (ISA & PCI & AGP)  
        Win32_USBController, // USB ������  
        Win32_NetworkAdapter, // ����������  
        Win32_NetworkAdapterConfiguration, // ��������������  
        Win32_Printer, // ��ӡ��  
        Win32_PrinterConfiguration, // ��ӡ������  
        Win32_PrintJob, // ��ӡ������  
        Win32_TCPIPPrinterPort, // ��ӡ���˿�  
        Win32_POTSModem, // MODEM  
        Win32_POTSModemToSerialPort, // MODEM �˿�  
        Win32_DesktopMonitor, // ��ʾ��  
        Win32_DisplayConfiguration, // �Կ�  
        Win32_DisplayControllerConfiguration, // �Կ�����  
        Win32_VideoController, // �Կ�ϸ�ڡ�  
        Win32_VideoSettings, // �Կ�֧�ֵ���ʾģʽ��  

        // ����ϵͳ  
        Win32_TimeZone, // ʱ��  
        Win32_SystemDriver, // ��������  
        Win32_DiskPartition, // ���̷���  
        Win32_LogicalDisk, // �߼�����  
        Win32_LogicalDiskToPartition, // �߼��������ڷ�����ʼĩλ�á�  
        Win32_LogicalMemoryConfiguration, // �߼��ڴ�����  
        Win32_PageFile, // ϵͳҳ�ļ���Ϣ  
        Win32_PageFileSetting, // ҳ�ļ�����  
        Win32_BootConfiguration, // ϵͳ��������  
        Win32_ComputerSystem, // �������Ϣ��Ҫ  
        Win32_OperatingSystem, // ����ϵͳ��Ϣ  
        Win32_StartupCommand, // ϵͳ�Զ���������  
        Win32_Service, // ϵͳ��װ�ķ���  
        Win32_Group, // ϵͳ������  
        Win32_GroupUser, // ϵͳ���ʺ�  
        Win32_UserAccount, // �û��ʺ�  
        Win32_Process, // ϵͳ����  
        Win32_Thread, // ϵͳ�߳�  
        Win32_Share, // ����  
        Win32_NetworkClient, // �Ѱ�װ������ͻ���  
        Win32_NetworkProtocol, // �Ѱ�װ������Э��  
    }
    #endregion 

    public sealed class WMI
    {
        private ArrayList mocs;
        private StringDictionary names; // �����洢�����������ں��Դ�Сд��ѯ��ȷ���ơ�  

        /// <summary>  
        /// ��Ϣ��������  
        /// </summary>  
        public int Count
        {
            get { return mocs.Count; }
        }

        /// <summary>  
        /// ��ȡָ������ֵ��ע��ĳЩ������������顣  
        /// </summary>  
        public object this[int index, string propertyName]
        {
            get
            {
                try
                {
                    string trueName = names[propertyName.Trim()]; // �Դ˿ɲ����ִ�Сд�����ȷ���������ơ�  
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
        /// ���������������ơ�  
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
        /// ���ز�����Ϣ��  
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
        /// ���캯��  
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
        /// ���캯��  
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
