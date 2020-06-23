using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    class GlobalSettings
    {        
        private static string connString = "";
        private static string scanPath = "";
        private static string browsePath = "";
        private static string tempPath = Environment.CurrentDirectory + @"\temp";

        /// <summary>
        /// 文件临时存放路径
        /// </summary>
        public static string TempPath
        {
            get { return GlobalSettings.tempPath;}            
        }


        /// <summary> 
        /// 查询病历的图片文件物理存放位置         
        /// </summary>
        public static string BrowsePath
        {
            get { return GlobalSettings.browsePath; }
        }

        /// <summary> 
        /// 扫描病历的图片文件物理存放位置
        /// 
        /// </summary>
        public static string ScanPath
        {
            get { return GlobalSettings.scanPath; }            
        }

        /// <summary> 
        /// 数据库连接信息
        /// 
        /// </summary>
        public static string ConnString
        {
            get { return GlobalSettings.connString; }
            
        }
        public static void GlobalInit()
        {
            connString = "Provider=MSDAORA.1;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST="
                +ReadSettings("DataBaseIP")
                +")(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)));user id="
                +ReadSettings("UserName")
                +";password="
                +ReadSettings("Pass");
                            
            
            scanPath = ReadSettings("ScanPath");
            browsePath = ReadSettings("BrowsePath"); 
        }
        private static string ReadSettings(string key)
        {
            string settingFile = Environment.CurrentDirectory + @"\appSettings.config";
            string value = "";
            try 
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(settingFile);
                value = xmlDoc.SelectSingleNode(@"//add[@key='" + key + "']").Attributes["value"].Value;

            }
            catch(Exception ex)
            {
                return "";
            }
            return value;
 
        }
    }
}
