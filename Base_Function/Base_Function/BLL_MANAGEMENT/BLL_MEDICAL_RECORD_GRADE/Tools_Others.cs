using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
// System.Data.OleDb;
//using System.Data.OracleClient;
using System.Diagnostics;
using DevComponents.AdvTree;
using Bifrost;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public class Tools_Others
    {

        #region 调用参数pb
        public static bool StartProcess(string fName,string args)
        {            
            try
            {
                Process myprocess = new Process();                
                myprocess.StartInfo = new ProcessStartInfo(fName, args); 
                myprocess.StartInfo.UseShellExecute = false; 
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
                Tools_Others.WriteErrorLog("调用外部程序失败：" + ex.Message);
                return false;
            }
            
        }

        #endregion

        #region 递归查询节点下文件
        public static void GetNodesFiles(ArrayList filesName,Node node)
        {
            if (node.Nodes.Count < 1)
            {
                filesName.Add(node.Tag);
                return;

            }
            else
            {
                foreach (Node temp in node.Nodes)
                {
                    Tools_Others.GetNodesFiles(filesName, temp);
                }
                
            }
            
        }

        #endregion

        #region 读写INI文件
        //public static bool WriteIniFiles(string section, string key, string val, string fileName)
        //{
        //    string filePath = Environment.CurrentDirectory +@"\"+ fileName;
        //    try
        //    {
        //        bool b = MessageFilesOperation.WritePrivateProfileString(section, key, val, filePath);
        //        return b;
        //    }
        //    catch (Exception ex)
        //    {
        //        MyTools.WriteErrorLog(ex.Message);
        //        return false;
        //    }
        //}

        //public static string ReadIniFiles(string section, string key, string fileName)
        //{
        //    string filePath = Environment.CurrentDirectory + @"\" + fileName;
        //    StringBuilder strValue = new StringBuilder(255);

        //    try
        //    {
        //        MessageFilesOperation.GetPrivateProfileString(section, key, "error", strValue, 255, filePath);
        //        return strValue.ToString().Trim();
        //    }
        //    catch (Exception ex)
        //    {
        //        MyTools.WriteErrorLog(ex.Message);
        //        return "";
        //    }
        //}
        #endregion

        #region 记录错误信息
        public static bool WriteErrorLog(string errorMessage)
        {
            string filePath = Environment.CurrentDirectory + @"\" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            //if (File.Exists(filePath))
            //{
            //    //如果存在文件，则向文件添加日志
            //    StreamWriter sw = new StreamWriter(filePath, true);

            //    sw.WriteLine("============================================================================");
            //    sw.WriteLine(App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss") + ":");
            //    sw.WriteLine(errorMessage);
            //    sw.Close();
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);

                sw.WriteLine("============================================================================");
                sw.WriteLine(App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss") + ":");
                sw.WriteLine(errorMessage);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出现错误，写入错误日志文件失败，请联系相关人员");
                return false;
            }
        }
        #endregion 

        #region 查询病历文件 +1重载
        public static ArrayList SearchFiles(string pid,string vid,string pname)
        {
            ArrayList temp = new ArrayList();

            string sql = "select * from T_ELECTRONIC_ARCHIVE t where t.patient_id = '"+pid+"'";

            if (vid != "")
            {
                sql += " and t.visit_id = " + vid; 
            }
            if (pname != "")
            {
                sql += " and t.visit_id = " + vid+"'";
            }
            return temp;
        }

        public static ArrayList SearchFiles(string bah)
        {
            ArrayList temp = new ArrayList();



            return temp;
        }

        #endregion 

        

    }
}
