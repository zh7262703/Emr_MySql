using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Web.Configuration;
using System.Configuration;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DataOperater
{
    /// <summary>
    /// 服务器端的数据库操作库    
    /// 创建者：张华
    /// 创建时间：2010-3-14
    /// </summary>
    public partial class Oral : MarshalByRefObject
    {
        private string connectionString;//连接数据库字符串  
        private string mediaftpurl;     //媒体文件存放用的ftp
        private string mediaftpuser;    //媒体文件存放用的ftp的用户名
        private string mediaftppassword;//媒体文件存放用的ftp的密码      

        /// <summary>
        /// 服务器端的消息集合
        /// </summary>
        public static ArrayList ArrCients = new ArrayList();
        
        /// 
        /// 获得连接字符串
        ///    
        public string ConnectionString
        {
            
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }

        }

        /// 
        /// 媒体文件存放用的ftp
        ///    
        public string MediaFtpUrl
        {
            get
            {
                return mediaftpurl;
            }
            set
            {
                mediaftpurl = value;
            }

        }

        /// 
        /// 媒体文件存放用的ftp的用户名
        ///    
        public string MediaFtpUser
        {
            get
            {
                return mediaftpuser;
            }
            set
            {
                mediaftpuser = value;
            }

        }

        /// 
        /// 媒体文件存放用的ftp的密码
        ///    
        public string MediaFtpPassword
        {
            get
            {
                return mediaftppassword;
            }
            set
            {
                mediaftppassword = value;
            }

        }


        public Oral()
        {                   
            ConnectionString = File.ReadAllText("datalink.txt").Split(',')[0];
            MediaFtpUrl = File.ReadAllText("datalink.txt").Split(',')[1];
            MediaFtpUser = File.ReadAllText("datalink.txt").Split(',')[2];
            MediaFtpPassword = File.ReadAllText("datalink.txt").Split(',')[3];
        }        

        #region ORCAL操作    

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name=CmdString></param>
        /// <param name=TableName></param>
        /// <returns></returns> 
        public DataSet GetDataSet(string CmdString)
        {
            OracleConnection cnn = new OracleConnection(ConnectionString);
            try
            {
              
                cnn.Open();
                OracleDataAdapter myDa = new OracleDataAdapter();                
                myDa.SelectCommand = new OracleCommand(CmdString, cnn);                
                DataSet myDs = new DataSet();
                myDa.Fill(myDs, "table");                
                return myDs;
            }
            catch
            {
                return null;
            }
            finally
            {
                cnn.Close();
            }
        }

        /// <summary>
        /// 返回DataSet 多张表
        /// </summary>
        /// <param name=CmdString></param>
        /// <param name=TableName></param>
        /// <returns></returns>       
        public DataSet GetDataSets(Class_Table[] tabsqls)
        {
            OracleConnection cnn = new OracleConnection(ConnectionString);           
            OracleDataAdapter myDa = new OracleDataAdapter();
            DataSet myDs = new DataSet();
            try
            { 
                cnn.Open();
                for (int i = 0; i < tabsqls.Length; i++)
                {                    
                    myDa.SelectCommand = new OracleCommand(tabsqls[i].Sql, cnn);
                    myDa.Fill(myDs, tabsqls[i].Tablename);
                }
                return myDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }

        /// <summary>
        /// 根据行号和列名返回值
        /// </summary>
        /// <param name="CmdString">SQl语句</param>
        /// <param name="rowindex">行号</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        public string ReadSqlVal(string CmdString, int rowindex, string colName)
        {
           OracleConnection cnn = new OracleConnection(ConnectionString);
            try
            {
                
                cnn.Open();
                OracleDataAdapter myDa = new OracleDataAdapter();
                myDa.SelectCommand = new OracleCommand(CmdString, cnn);
                DataSet myDs = new DataSet();
                myDa.Fill(myDs, "table");
                return myDs.Tables[0].Rows[rowindex][colName].ToString();
            }
            catch
            {
                return null;
            }
            finally
            {
                cnn.Close();
            }
        }      

        /// <summary>
        /// 返回影响数据库的行数
        /// </summary>
        /// <param name=CmdString></param>
        /// <returns></returns>
        public int ExecuteSQL(string CmdString)
        {
            OracleConnection cnn = new OracleConnection(ConnectionString);
            try
            {
               
                cnn.Open();
                OracleCommand myCmd = new OracleCommand(CmdString, cnn);
                int Cmd = myCmd.ExecuteNonQuery();
                return Cmd;
            }
            catch
            {
                return 0;
            }
            finally
            {
                cnn.Close();
            }
        }
        

        /// <summary>
        /// 以带参数的形式执行操作
        /// </summary>
        /// <param name="CmdString">SQL语句</param>
        /// <param name="Parameters">参数集合</param>       
        /// <returns></returns>
        public int ExecuteSQLWithParams(string CmdString, DBParameter[] paremts)
        {            
            OracleConnection cnn = new OracleConnection(ConnectionString);
            try
            {
              
                cnn.Open();
                OracleCommand myCmd = new OracleCommand(CmdString, cnn);
                for (int i = 0; i < paremts.Length; i++)
                {
                    System.Data.OracleClient.OracleParameter Parameter = new OracleParameter();
                    Parameter.Value = paremts[i].Value;
                    Parameter.ParameterName = paremts[i].ParameterName;
                    Parameter.OracleType = paremts[i].DBType;
                    Parameter.Size = paremts[i].Size;
                    myCmd.Parameters.Add(Parameter);
                }
                int Cmd = myCmd.ExecuteNonQuery();

                return Cmd;
            }
            catch
            {
                return 0;
            }
            finally
            {
                cnn.Close();
            }
        }
      


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>     
        public void RunProcedure(string storedProcName, DBParameter[] parameters)
        {     
            OracleConnection cnn = new OracleConnection(ConnectionString);      
            try
            {
                
                cnn.Open();
                OracleCommand myCmd = new OracleCommand();
                myCmd.Connection = cnn;
                myCmd.CommandText = storedProcName;//声明存储过程名
                myCmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    //foreach (OracleParameter parameter in parameters)
                    //{
                    //    myCmd.Parameters.Add(parameter);
                    //}
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        System.Data.OracleClient.OracleParameter Parameter = new OracleParameter();
                        Parameter.Value = parameters[i].Value;
                        Parameter.ParameterName = parameters[i].ParameterName;
                        Parameter.OracleType = parameters[i].DBType;
                        myCmd.Parameters.Add(Parameter);
                    }
                }
                myCmd.ExecuteNonQuery();//执行存储过程

            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>        
        public DataSet RunProcedureGetData(string storedProcName, System.Data.OracleClient.OracleParameter[] parameters)
        {         
            OracleConnection cnn = new OracleConnection(ConnectionString);  
            try
            {
                
                cnn.Open();
                DataSet ds = new DataSet();
                OracleDataAdapter sqlDA = new OracleDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(cnn, storedProcName, parameters);
                sqlDA.Fill(ds, "table");                
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;                
            }
            finally
            {
                cnn.Close();
            }
        }

        /// <summary>
        /// 构建 OracleCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand</returns>
        private static OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OracleParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        ///   <summary> 
        ///   批量执行Sql语句 
        ///   </summary> 
        ///   <param name= "BatchSql "> Sql语句数组 </param> 
        public int ExecuteBatch(string[] BatchSql)
        {
           
            //打开连接 
            OracleConnection cnn = new OracleConnection(ConnectionString);
            cnn.Open();

            //创建事务 
            OracleCommand cmd = cnn.CreateCommand();
            //OracleTransaction transaction = cnn.BeginTransaction(IsolationLevel.ReadCommitted);
            OracleTransaction transaction = cnn.BeginTransaction();

            cmd.Transaction = transaction;
            int y = 0;
            try
            {       //执行两个保存数据集的操作 
                for (int i = 0; i < BatchSql.Length; i++)
                {
                    if (BatchSql[i].Trim() != "")
                    {
                        cmd.CommandText = BatchSql[i];
                        cmd.ExecuteNonQuery();
                    }
                }
                y = y + 1;
                //执行完成后提交事务 
                transaction.Commit();
                return y;
            }
            catch(Exception ex)
            {
                //回滚事务 
                transaction.Rollback();
                throw ex;

            }
            finally
            {
                //关闭连接 
                cnn.Close();
            }
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <returns></returns>
        public bool ConnectTest()
        {
            try
            {
                OracleConnection cnn = new OracleConnection(ConnectionString);
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 其他操作
        /// <summary>
        /// 获取FTP更新目录的信息
        /// </summary>
        /// <returns></returns>       
        public string[] GetFtpMessage()
        {
            string[] ftps = new string[6];
            XmlDocument doc = new XmlDocument();
            doc.Load(File.ReadAllText("datalink.txt").Split(',')[1]);
            XmlDocument docDir = new XmlDocument();
            docDir.Load(File.ReadAllText("datalink.txt").Split(',')[2]);

            XmlNode root = doc.SelectSingleNode("Ftp");
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                if (root.ChildNodes[i].Name == "user")
                {
                    ftps[0] = root.ChildNodes[i].InnerText;
                }
                else if (root.ChildNodes[i].Name == "password")
                {
                    ftps[1] = root.ChildNodes[i].InnerText;
                }
                else if (root.ChildNodes[i].Name == "ftpip")
                {
                    ftps[2] = root.ChildNodes[i].InnerText;
                }
                else if (root.ChildNodes[i].Name == "vsersion")
                {
                    ftps[3] = root.ChildNodes[i].InnerText;
                }
                else if (root.ChildNodes[i].Name == "programs")
                {
                    ftps[4] = root.ChildNodes[i].InnerText;
                }
            }
            ftps[5] = docDir.OuterXml;
            return ftps;
        }

        /// <summary>
        /// 插入文书模板(t_patients_doc-文书;t_model_lable-标签模块;t_struct-结构化)
        /// </summary>
        /// <param name="PID">病人主ID(HIS)</param>
        /// <param name="textKind">文书类型</param>
        /// <param name="xmlDoc">文书模板</param>
        /// <returns></returns>       
        public string InsertModel(string PID, int textKind_ID, string xmlDoc, int belongToSys_ID, int sickKind_ID, string textName)
        {
            //XmlElement xmlElement = xmlDoc.DocumentElement;
            string strinsert = "";
            OracleConnection cnn = new OracleConnection(ConnectionString);
            cnn.Open();
            OracleCommand command = cnn.CreateCommand();
            OracleTransaction transaction = null;

            try
            {
                transaction = cnn.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = transaction;

                int tid = GenId("T_Patients_Doc", "TID");

                strinsert = "insert into T_Patients_Doc values(" + tid.ToString() + ",'" + PID + "'," + textKind_ID + ",:Patients_Doc," + belongToSys_ID + "," + sickKind_ID + ",'" + textName + "')";

                //OracleParameter[] xmlPars = new OracleParameter[1];
                //xmlPars[0] = new OracleParameter();
                //xmlPars[0].ParameterName = "Patients_Doc";
                //xmlPars[0].Value = xmlDoc.OuterXml;
                //xmlPars[0].OracleType = OracleType.Clob;
                //xmlPars[0].Direction = ParameterDirection.Input;

                OracleParameter xmlParDoc = new OracleParameter();
                xmlParDoc.ParameterName = "Patients_Doc";
                xmlParDoc.Value = xmlDoc;
                xmlParDoc.OracleType = OracleType.Clob;

                command.Parameters.Add(xmlParDoc);

                command.CommandText = strinsert;

                command.ExecuteNonQuery();

                string msg = InsertLableModel(tid, xmlDoc); //===========插入标签模板与结构化

                //message = ExecuteSQLWithParams(strinsert, xmlPars);//------------插入文书模板


                if (msg == null)
                {
                    transaction.Rollback();                   
                    return null;
                }
                transaction.Commit();

                //NClose();

                return "成功";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return "数据库异常！----------------" + ex.ToString();
            }
            finally
            {
                cnn.Close();
            }

        }

        /// <summary>
        /// 插入标签模板
        /// </summary>
        /// <param name="doc">文书代码</param>
        /// <param name="xmlDoc">标签模板</param>
        /// <returns></returns>       
        public string InsertLableModel(int tid, string xmlDoc)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(xmlDoc);
            XmlElement xmlElement = Doc.DocumentElement;
            string insertLable = "";
            int message = 0;
            try
            {
                foreach (XmlNode bodyNode in xmlElement.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        if (bodyNode.HasChildNodes)
                        {   //int i = 1;                        
                            foreach (XmlNode divNode in bodyNode.ChildNodes)
                            {
                                if (divNode.Name == "div")
                                {
                                    //i++;
                                    //string divModel = divNode.InnerText;
                                    string divTitle = "";
                                    for (int i = 0; i < divNode.Attributes.Count; i++)
                                    {
                                        if (divNode.Attributes[i].ToString().Trim() == "title")
                                            divTitle = divNode.Attributes["title"].Value;
                                    }

                                    if (divTitle.Trim() == "")
                                        divTitle = "文本域";
                                    int id = GenId("t_model_lable", "LID");
                                    //插入标签模块
                                    insertLable = "insert into t_model_lable(LID,TID,LABLEKIND,LABLE_MODEL)values(" + id + "," + tid + ",'" + divTitle + "',:divModel)";

                                    DBParameter[] xmlPars = new DBParameter[1];
                                    xmlPars[0] = new DBParameter();
                                    xmlPars[0].ParameterName = "divModel";
                                    xmlPars[0].Value = divNode.OuterXml;
                                    xmlPars[0].DBType = OracleType.Clob;
                                    //xmlPars[0].Direction = ParameterDirection.Input;
                                    message = ExecuteSQLWithParams(insertLable, xmlPars);

                                    foreach (XmlNode selectNode in divNode.ChildNodes)
                                    {
                                        if (selectNode.Name == "select")
                                        {
                                            string selName = selectNode.Attributes["name"].Value;
                                            string selValue = selectNode.Attributes["value"].Value;
                                            string sid = GenId("t_struct", "sid").ToString();
                                            ////插入结构化
                                            string insertStruct = "insert into t_struct values(" + sid + "," + id + ",'" + selName + "','" + selValue + "'," + tid + ")";
                                            message = ExecuteSQL(insertStruct);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (message != 0)
                {
                    return "成功！";
                }
                else
                {
                    return "失败！";
                }
            }
            catch (Exception ex)
            {
                return "数据库异常！----------------" + ex.ToString();
            }
            finally
            {
                //NClose();
            }
        }


        /// <summary>
        /// 插入标签模板
        /// </summary>
        /// <param name="doc">文书代码</param>
        /// <param name="xmlDoc">标签模板</param>
        /// <returns></returns>       
        public string InsertLableContent(int tid, string xmlDoc)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDoc);
            XmlElement xmlElement = doc.DocumentElement;
            string insertLable = "";
            int message = 0;
            try
            {
                foreach (XmlNode bodyNode in xmlElement.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        if (bodyNode.HasChildNodes)
                        {   
                            //string divModel = divNode.InnerText;
                            string divTitle = "test";
                            //if (divNode.Name == "div")
                            //  divTitle = divNode.Attributes["title"].Value;
                            int id = GenId("T_TempPlate_Cont", "ID");
                            //插入标签模块
                            insertLable = "insert into T_TempPlate_Cont(ID,TID,LableName,Content)values(" + id + "," + tid + ",'" + divTitle + "',:divContent)";
                            DBParameter[] xmlPars = new DBParameter[1];
                            xmlPars[0] = new DBParameter();
                            xmlPars[0].ParameterName = "divContent";
                            //xmlPars[0].Value = divNode.OuterXml;
                            xmlPars[0].Value = bodyNode.InnerXml;
                            xmlPars[0].DBType = OracleType.Clob;
                            //xmlPars[0].Direction = ParameterDirection.Input;
                            message = ExecuteSQLWithParams(insertLable, xmlPars);
                        }
                    }
                }

                if (message != 0)
                {
                    return "成功！";
                }
                else
                {
                    return "失败！";
                }
            }
            catch (Exception ex)
            {
                return "数据库异常！----------------" + ex.ToString();
            }
            finally
            {
                //NClose();
            }
        }

        /// <summary>
        /// 自动生成ID
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="Idname">id字段名</param>
        /// <returns></returns>
        private int GenId(string tablename, string Idname)
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
            }
            catch
            {
                return 1;
            }
        }



        /// <summary>
        /// 获取所有局域网地址
        /// </summary>
        /// <returns></returns>    
        public ArrayList GetAllLocalMachines()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("arp -a");
            p.StandardInput.WriteLine("exit");
            ArrayList list = new ArrayList();
            StreamReader reader = p.StandardOutput;
            string IPHead = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString().Substring(0, 3);
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                line = line.Trim();
                if (line.StartsWith(IPHead) && (line.IndexOf("dynamic") != -1))
                {

                    string IP = line.Substring(0, 15).Trim();                 
                    list.Add(IP);

                }
            }
            return list;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">要传送的消息</param>
        /// <param name="currentip">发消息的Ip</param>     
        public void sendmymsg(string message, string currentip)
        {
            ArrayList templist = GetAllLocalMachines();
            for (int i = 0; i < templist.Count; i++)
            {
                try
                {
                    if (currentip != templist[i].ToString())// && templist[i].ToString()
                    {


                        TcpClient client = new TcpClient();//"192.168.1.103"  templist[i].ToString(), 5567
                        IAsyncResult MyResult = client.BeginConnect(templist[i].ToString(), 5567, null, null);

                        MyResult.AsyncWaitHandle.WaitOne(1, true);   //指定等候時間  
                        if (!MyResult.IsCompleted)
                        {
                            client.Close();
                        }
                        else
                        {
                            NetworkStream sendStream = client.GetStream();
                            String msg = message;
                            Byte[] sendBytes = Encoding.Default.GetBytes(msg);
                            sendStream.Write(sendBytes, 0, sendBytes.Length);
                            sendStream.Close();
                            client.Close();
                        }
                    }
                }
                catch
                { }
            }
        }


        /// <summary>
        /// 获取所有的当前的在线用户的资料
        /// </summary>
        /// <returns></returns>
        public string GetAllCurrentOpersXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + @"\Operator\Users.xml");
                return doc.OuterXml;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="SenderIp"></param>
        /// <param name="target"></param>
        /// <param name="patintname"></param>
        public void SenderCurrentOpersXml(string SenderIp, string TargetSectionId, string patintname)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + @"\Operator\Users.xml");
            XmlElement xe1 = doc.CreateElement("User");
            xe1.SetAttribute("content", patintname);
            xe1.SetAttribute("SendIp", SenderIp);
            xe1.SetAttribute("TargetSectionId", TargetSectionId);
            xe1.SetAttribute("opflag", "0");
            doc.SelectSingleNode("Users").AppendChild(xe1);
            doc.Save(Application.StartupPath + @"\Operator\Users.xml");
        }

        /// <summary>
        /// 删除所有的flag为1的记录
        /// </summary>
        public void DeleteAllOpersXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + @"\Operator\Users.xml");
                bool flag;
                do
                {
                    flag = false;
                    for (int i = 0; i < doc.SelectSingleNode("Users").ChildNodes.Count; i++)
                    {
                        if (doc.SelectSingleNode("Users").ChildNodes[i].Attributes["opflag"].Value == "1")
                        {
                            doc.SelectSingleNode("Users").RemoveChild(doc.SelectSingleNode("Users").ChildNodes[i]);
                            flag = true;
                            break;
                        }
                    }
                }
                while (!flag);
                doc.Save(Application.StartupPath + @"\Operator\Users.xml");
            }
            catch
            {
 
            }
        }

        /// <summary>
        /// 设置flag标志位
        /// </summary>
        public void SetOpersXml(string SenderIp)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + @"\Operator\Users.xml");
                for (int i = 0; i < doc.SelectSingleNode("Users").ChildNodes.Count; i++)
                {
                    if (doc.SelectSingleNode("Users").ChildNodes[i].Attributes["opflag"].Value == "0")
                    {
                        if (doc.SelectSingleNode("Users").ChildNodes[i].Attributes["SendIp"].Value == SenderIp)
                        {
                            doc.SelectSingleNode("Users").ChildNodes[i].Attributes["opflag"].Value = "1";
                            doc.Save(Application.StartupPath + @"\Operator\Users.xml");
                            return;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 返回服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetSystemTime()
        {
            return DateTime.Now;
        }

      
       
        #endregion

        #region 监测操作
        /// <summary>
        /// 获取服务器端的消息
        /// </summary>
        public string GetSeverMessages()
        {
            string tempstr = "";
            for (int i = 0; i < ArrCients.Count; i++)
            {
                client_obj tb = (client_obj)ArrCients[i];              
                string strval = tb.Ip + " " + tb.UserName + " " + tb.ZhiWu + " " + tb.ZhiCheng + " " + tb.Account_Name;
                if (tempstr.Trim() == "")
                {
                    tempstr = strval;
                }
                else
                {
                    tempstr = tempstr + "\n" + strval;
                }
            }
            return tempstr;
        }

        /// <summary>
        /// 设置服务器端的消息
        /// </summary>
        public void SetSeverMessages(string recvStr)
        {
            client_obj clobj = new client_obj();
            clobj.Ip = recvStr.Split(';')[0].ToString();
            clobj.UserName = recvStr.Split(';')[1].ToString();
            clobj.ZhiWu = recvStr.Split(';')[2].ToString();
            clobj.ZhiCheng = recvStr.Split(';')[3].ToString();
            clobj.Account_Name = recvStr.Split(';')[4].ToString();
            clobj.LinkCount = 0;
            if (!IsHaveSame(clobj))
            {
                ArrCients.Add(clobj);
            }
        }

        /// <summary>
        /// 移除超时的节点
        /// </summary>
        public static void RemoveOutLimited()
        {
            for (int i = 0; i < ArrCients.Count; i++)
            {
                client_obj temp = (client_obj)ArrCients[i];
                if (temp.LinkCount > 8)
                {
                    ArrCients.Remove(temp);
                    RemoveOutLimited();
                }
            }
        }

        /// <summary>
        /// 相同匹配操作
        /// </summary>
        /// <param name="clobj"></param>
        /// <returns></returns>
        public static bool IsHaveSame(client_obj clobj)
        {
            bool flag = false;
            for (int i = 0; i < ArrCients.Count; i++)
            {
                client_obj temp = (client_obj)ArrCients[i];
                if (clobj.Ip == temp.Ip &&
                        clobj.UserName == temp.UserName &&
                        clobj.ZhiWu == temp.ZhiWu &&
                        clobj.ZhiCheng == temp.ZhiCheng &&
                        clobj.Account_Name == temp.Account_Name)
                {
                    temp.LinkCount = 0;
                    ArrCients[i] = temp;
                    flag = true;
                }
            }
            return flag;
        }

        #endregion

    }

    [Serializable]
    public class DBParameter
    {
        
        private OracleType oracleType;//参数类型          
        private string parameterName;//参数名          
        private int size;//参数大小          
        private object parameterValue;//参数值
        /// <summary>
        /// 
        /// </summary>  
        public DBParameter()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public DBParameter(string parameterName, OracleType dbType, int size)
        {
            if (parameterName != null)
            {
                this.parameterName = parameterName.Trim();
            }
            this.oracleType = dbType;
            this.size = size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        public DBParameter(string parameterName, OracleType dbType, int size, object value)
        {
            if (parameterName != null)
            {
                this.parameterName = parameterName.Trim();
            }
            this.oracleType = dbType;
            this.size = size;
            this.parameterValue = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public OracleType DBType
        {
            get
            {
                return oracleType;
            }
            set
            {
                this.oracleType = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ParameterName
        {
            get
            {
                return this.parameterName;
            }
            set
            {
                if (value != null)
                {
                    this.parameterName = value;
                }
                else
                {
                    this.parameterName = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Value
        {
            get
            {
                return parameterValue;
            }
            set
            {
                this.parameterValue = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            DBParameter p = (DBParameter)obj;
            return ((this.oracleType == p.oracleType) && (string.Compare(this.parameterName, p.parameterName, true, System.Globalization.CultureInfo.CurrentCulture) == 0) && (this.parameterValue.GetHashCode() == p.parameterValue.GetHashCode()) && (this.size == p.size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.oracleType.GetHashCode() ^ this.parameterName.GetHashCode() ^ this.size.GetHashCode() ^ this.parameterValue.GetHashCode();
        }       
       
    } 
}