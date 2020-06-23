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
    /// �������˵����ݿ������    
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-3-14
    /// </summary>
    public partial class Oral : MarshalByRefObject
    {
        private string connectionString;//�������ݿ��ַ���  
        private string connectionString_others;//�������ݿ��ַ������������ݣ�  
        private string mediaftpurl;     //ý���ļ�����õ�ftp
        private string mediaftpuser;    //ý���ļ�����õ�ftp���û���
        private string mediaftppassword;//ý���ļ�����õ�ftp������ 
        private bool isright=false;     //�Ƿ�����ʹ��ϵͳ
             

        /// <summary>
        /// �������˵���Ϣ����
        /// </summary>
        public static ArrayList ArrCients = new ArrayList();
        
        /// 
        /// ��������ַ���
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
        /// ��������ַ���
        ///    
        public string ConnectionString_Others
        {

            get
            {
                return connectionString_others;
            }
            set
            {
                connectionString_others = value;
            }

        }

        /// 
        /// ý���ļ�����õ�ftp
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
        /// ý���ļ�����õ�ftp���û���
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
        /// ý���ļ�����õ�ftp������
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

        /// <summary>
        /// �Ƿ�����ʹ��ϵͳ
        /// </summary>
        public bool Isright
        {
            get
            {
                return isright;
            }

            set
            {
                isright = value;
            }
        }

        public Oral()
        {
           
            ConnectionString = File.ReadAllText("datalink.txt").Split(',')[0];
            MediaFtpUrl = File.ReadAllText("datalink.txt").Split(',')[1];
            MediaFtpUser = File.ReadAllText("datalink.txt").Split(',')[2];
            MediaFtpPassword = File.ReadAllText("datalink.txt").Split(',')[3];

            ConnectionString_Others = File.ReadAllText("datalink_others.txt");
        }        

        #region ORCAL����    
        /// <summary>
        /// ����DataSet�������ݿ�
        /// </summary>
        /// <param name=CmdString></param>
        /// <param name=TableName></param>
        /// <returns></returns> 
        public DataSet GetDataSet_Others(string CmdString)
        {
            OracleConnection cnn = new OracleConnection(ConnectionString_Others);
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
        /// ����DataSet
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
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                cnn.Close();
            }
        }

        /// <summary>
        /// ����DataSet ���ű�
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
        /// �����кź���������ֵ
        /// </summary>
        /// <param name="CmdString">SQl���</param>
        /// <param name="rowindex">�к�</param>
        /// <param name="colName">����</param>
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
        /// ����Ӱ�����ݿ������
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
        /// �Դ���������ʽִ�в���
        /// </summary>
        /// <param name="CmdString">SQL���</param>
        /// <param name="Parameters">��������</param>       
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
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>     
        public void RunProcedure(string storedProcName, DBParameter[] parameters)
        {     
            OracleConnection cnn = new OracleConnection(ConnectionString);      
            try
            {
                
                cnn.Open();
                OracleCommand myCmd = new OracleCommand();
                myCmd.Connection = cnn;
                myCmd.CommandText = storedProcName;//�����洢������
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
                myCmd.ExecuteNonQuery();//ִ�д洢����

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
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>        
        public DataSet RunProcedureGetData(string storedProcName, DBParameter[] parameters)
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
        /// ���� OracleCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OracleCommand</returns>
        private static OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, DBParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {                
                for (int i = 0; i < parameters.Length; i++)
                {
                    System.Data.OracleClient.OracleParameter Parameter = new OracleParameter();
                    Parameter.Value = parameters[i].Value;
                    Parameter.ParameterName = parameters[i].ParameterName;
                    Parameter.OracleType = parameters[i].DBType;
                    Parameter.Direction = parameters[i].Direction;
                    command.Parameters.Add(Parameter);
                }
            }          
            return command;
        }

        ///   <summary> 
        ///   ����ִ��Sql��� 
        ///   </summary> 
        ///   <param name= "BatchSql "> Sql������� </param> 
        public int ExecuteBatch(string[] BatchSql)
        {
           
            //������ 
            OracleConnection cnn = new OracleConnection(ConnectionString);
            cnn.Open();

            //�������� 
            OracleCommand cmd = cnn.CreateCommand();
            //OracleTransaction transaction = cnn.BeginTransaction(IsolationLevel.ReadCommitted);
            OracleTransaction transaction = cnn.BeginTransaction();

            cmd.Transaction = transaction;
            int y = 0;
            try
            {       //ִ�������������ݼ��Ĳ��� 
                for (int i = 0; i < BatchSql.Length; i++)
                {
                    if (BatchSql[i].Trim() != "")
                    {
                        cmd.CommandText = BatchSql[i];
                        cmd.ExecuteNonQuery();
                    }
                }
                y = y + 1;
                //ִ����ɺ��ύ���� 
                transaction.Commit();
                return y;
            }
            catch(Exception ex)
            {
                //�ع����� 
                transaction.Rollback();
                throw ex;

            }
            finally
            {
                //�ر����� 
                cnn.Close();
            }
        }

        /// <summary>
        /// ���Ӳ���
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
            catch(Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��ȡFTP����Ŀ¼����Ϣ
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
        /// ��������ģ��(t_patients_doc-����;t_model_lable-��ǩģ��;t_struct-�ṹ��)
        /// </summary>
        /// <param name="PID">������ID(HIS)</param>
        /// <param name="textKind">��������</param>
        /// <param name="xmlDoc">����ģ��</param>
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

                string msg = InsertLableModel(tid, xmlDoc); //===========�����ǩģ����ṹ��

                //message = ExecuteSQLWithParams(strinsert, xmlPars);//------------��������ģ��


                if (msg == null)
                {
                    transaction.Rollback();                   
                    return null;
                }
                transaction.Commit();

                //NClose();

                return "�ɹ�";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return "���ݿ��쳣��----------------" + ex.ToString();
            }
            finally
            {
                cnn.Close();
            }

        }

        /// <summary>
        /// �����ǩģ��
        /// </summary>
        /// <param name="doc">�������</param>
        /// <param name="xmlDoc">��ǩģ��</param>
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
                                        divTitle = "�ı���";
                                    int id = GenId("t_model_lable", "LID");
                                    //�����ǩģ��
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
                                            ////����ṹ��
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
                    return "�ɹ���";
                }
                else
                {
                    return "ʧ�ܣ�";
                }
            }
            catch (Exception ex)
            {
                return "���ݿ��쳣��----------------" + ex.ToString();
            }
            finally
            {
                //NClose();
            }
        }


        /// <summary>
        /// �����ǩģ��
        /// </summary>
        /// <param name="doc">�������</param>
        /// <param name="xmlDoc">��ǩģ��</param>
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
                            //�����ǩģ��
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
                    return "�ɹ���";
                }
                else
                {
                    return "ʧ�ܣ�";
                }
            }
            catch (Exception ex)
            {
                return "���ݿ��쳣��----------------" + ex.ToString();
            }
            finally
            {
                //NClose();
            }
        }

        /// <summary>
        /// �Զ�����ID
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="Idname">id�ֶ���</param>
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
        /// ��ȡ���о�������ַ
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
        /// ������Ϣ
        /// </summary>
        /// <param name="message">Ҫ���͵���Ϣ</param>
        /// <param name="currentip">����Ϣ��Ip</param>     
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

                        MyResult.AsyncWaitHandle.WaitOne(1, true);   //ָ���Ⱥ�r�g  
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
        /// ��ȡ���еĵ�ǰ�������û�������
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
        /// ������Ϣ
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
        /// ɾ�����е�flagΪ1�ļ�¼
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
        /// ����flag��־λ
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
        /// ���ط�����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime GetSystemTime()
        {
            return DateTime.Now;
        }

      
       
        #endregion

        #region ������
        /// <summary>
        /// ��ȡ�������˵���Ϣ
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
        /// ���÷������˵���Ϣ
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
        /// �Ƴ���ʱ�Ľڵ�
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
        /// ��ͬƥ�����
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


        /// <summary>
        /// �������
        /// </summary>
        /// <param name="textid"></param>
        /// <param name="patientid"></param>
        /// <returns></returns>
        public string GetDocXML(string nodeid,string textid,string patientid,string Doctype,string NewDocXml)
        {
            try
            {
                XmlDocument NewDoc = new XmlDocument();
                NewDoc.LoadXml(NewDocXml);

                #region �������ݲ�ѯ
                InPatient_Doc[] patient_Docs = null;
                patient_Docs = GetSelectNodes(patientid, textid, Doctype);
                #endregion



                #region ��������ƴ��
                XmlDocument TempXml = new XmlDocument();
                TempXml.PreserveWhitespace = true;
                StringBuilder strBuilder = new StringBuilder();

                string sickarea = "";
                string section = "";
                string bed = "";
                for (int i = 0; i < patient_Docs.Length; i++)
                {
                    if (patient_Docs[i] == null)
                        continue;

                    XmlDocument ChildXml = new XmlDocument();
                    ChildXml.PreserveWhitespace = true;
                    ChildXml.LoadXml(patient_Docs[i].Patients_doc);
                    if (patient_Docs[i].Isnewpage == "Y")
                    {
                        //��ʾ��������Ҫ���з�ҳ
                        //strBuilder.Append(@"<Skip operatercreater='0' /><p operatercreater='0' />");
                        //���鿪ͷ����
                        strBuilder.Append(@"<Skip operatercreater='0' />");
                    }

                    sickarea = ReadSqlVal("select sick_area_name from T_PATIENTS_DOC where TID=" + patient_Docs[i].Id + "", 0, "sick_area_name");

                    strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//��������
                    strBuilder.Append(@"<split textId='" + patient_Docs[i].Id + "' section_name = '" + patient_Docs[i].Section_name +
                        "' bed_no='" + patient_Docs[i].Bed + "' sick_area='" + sickarea + "'/>");


                }

                XmlNode xmlNode = NewDoc.SelectSingleNode("emrtextdoc");//����<body>
                string ss = strBuilder.ToString();
                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        bodyNode.InnerXml = strBuilder.ToString();
                    }
                }
                #endregion
                return NewDoc.OuterXml;
            }
            catch
            {
                return "";
            }

        }

        #region ���������ز���

        /// <summary>
        /// ��õ�ǰ�ڵ㲡������
        /// </summary>
        /// <param name="nodes">��ǰ�ڵ��µ���������</param>
        /// <returns>����Patient_Doc</returns>
        private InPatient_Doc[] GetSelectNodes(string patient_id, string textid,string DocType)
        {
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());
            //string sql = "select a.tid,a.patients_doc,a.textname,a.textkind_id from t_patients_doc a" +
            //             " left join t_quality_text b on a.tid=b.tid where a.patient_id='" + this.currentPatient.Id + "' "+
            //             " and a.tid=" + text.Id + " order by a.tid";
            string sql = "";
            if (!DocType.Contains("Class_Text"))
            {
                sql = "select a.tid,a.textname,a.textkind_id,a.createid,a.submitted,a.doc_name,a.section_name,b.ISNEWPAGE,Bed_no from t_patients_doc a inner join t_text b on a.textkind_id = b.id " +
                           "where a.patient_id='" + patient_id + "' and a.tid=" + textid + " order by doc_name";
            }
            else
            {
                sql = "select a.tid,a.textname,a.textkind_id,a.createid,a.submitted,a.doc_name,c.issimpleinstance,a.section_name,c.ISNEWPAGE,Bed_no from t_patients_doc a" +
                                          " inner join t_text c on a.textkind_id = c.id" +
                                          " where patient_id='" + patient_id + "'  and  textkind_id!=134" +    //textkind_id=134��ǰ����
                                          " and parentid=" + textid + "  and submitted='Y' order by doc_name";
            }
            DataSet ds = GetDataSet(sql);
            InPatient_Doc[] patient_Docs = null;
            //string[,] arrs = null;
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    //ȥ����ͬ������
                    int tid = 0;
                    //arrs = new string[dt.Rows.Count,2];
                    patient_Docs = new InPatient_Doc[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //arrs[i,0] = dt.Rows[i]["patients_doc"].ToString();
                        //arrs[i, 1] = dt.Rows[i]["tid"].ToString();
                        if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                        {
                            patient_Docs[i] = new InPatient_Doc();
                            patient_Docs[i].Patients_doc = ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");                            
                            patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            patient_Docs[i].Createid = dt.Rows[i]["createid"].ToString();
                            patient_Docs[i].Submitted = dt.Rows[i]["submitted"].ToString();
                            patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                            patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                            patient_Docs[i].Bed = dt.Rows[i]["Bed_no"].ToString();
                            tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());

                            if (dt.Rows[i]["ISNEWPAGE"].ToString() == "Y")
                            {
                                patient_Docs[i].Isnewpage = "Y";
                            }
                            else
                            {
                                patient_Docs[i].Isnewpage = "N";
                            }
                        }
                    }
                }
            }
            return patient_Docs;

        }
        #endregion

    }

    [Serializable]
    public class DBParameter
    {
        
        private OracleType oracleType;//��������          
        private string parameterName;//������          
        private int size;//������С          
        private object parameterValue;//����ֵ
        private ParameterDirection direction;  //��������

      
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
        public ParameterDirection Direction
        {
            get { return direction; }
            set { direction = value; }
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
