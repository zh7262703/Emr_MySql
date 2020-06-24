using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using System.Xml;
using DataOperater;
using System.IO;
using System.Security.Cryptography;
using System.Management;
using System.Runtime.Remoting.Channels.Http;
using DataOperater.Model;

namespace Remoting服务端
{
    public partial class frmRemotingServer : Form
    {
        public static int Port =0;
        static string encryptKey = "Oyea";    //定义密钥

        public static string SetVal = "";
        public static string filename = "";
        public static string regiestCode = ""; //注册码
        //public static bool isOutTime = false;
        public static string showinfo = "";    //提示信息

        public static string RemotingType = "tcp";
              
        

        //string today = "";

        DbHelp Operater;
        public frmRemotingServer()
        {
            //this.Hide();
            InitializeComponent();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？","信息提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {               
                Application.Exit();
            }
        }

        private void 还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPortSet fc=new frmPortSet();
            fc.ShowDialog();
        }

        private void frmRemotingServer_Load(object sender, EventArgs e)
        {
            //获取配置信息
            string pstr = Environment.GetFolderPath(Environment.SpecialFolder.System);
            //string newStr = System.IO.Path.GetDirectoryName(str);
            //File.Exists();
            filename = pstr + "\\" + "r_emr_regist.txt";

            string link =Decrypt(File.ReadAllText("datalink.txt").Split(',')[0]);
            string mysqllink=Decrypt(File.ReadAllText("mysqldatalink.txt"));
            string orcl_connectionString = string.Format(@"Persist Security Info=False;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SID={2})));user id={3};password={4}", link.Split(',')[0], link.Split(',')[1], link.Split(',')[2], link.Split(',')[3], link.Split(',')[4]);

            Operater = new DbHelp();
            //Operater.orcl_connectionString = orcl_connectionString;
            Operater.mysql_connectionString = "data source=localhost;database=emrbzb;user id=root;password=111111;pooling=true;charset=utf8;Convert Zero Datetime=True;Allow Zero Datetime=True"; //mysqllink;
            
            bool yy = Operater.ConnectTest_MySql();

           // DataSet ds = Operater.GetDataSet_MySql("select a.id,a.patient_name as 姓名,a.pid as 住院号,a.section_name as 科室 from t_in_patient a where a.id in (select patient_id from  t_patients_doc where tid in (select tid from t_patient_doc_colb)) order by id desc");
            //DataSet ds = Operater.GetDataSet_MySql("select * from T_ACCOUNT where upper(ACCOUNT_NAME)='FK' and PASSWORD='BB31597A358EFF6E'");
            DataSet ds = Operater.GetDataSet_MySql("select n.ACCOUNT_ID,n.ENABLE_START_TIME from t_account n where n.ENABLE_START_TIME is not NULL LIMIT 1");
            if (File.Exists(filename))
            {
                regiestCode = File.ReadAllText(filename).Split(',')[1];

                if (regiestCode != "")
                {
                    if (frmRemotingServer.Encrypt(GetCpuID()) != regiestCode)
                    {
                        File.Delete(filename);
                        MessageBox.Show("注册码被恶意修改，请重新注册！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Restart();
                    }
                }
            }          

            if (Port == 0)
            {
                if (!File.Exists(filename))
                {
                    //首次使用
                    DateTime dte = Operater.GetSystemTime().AddDays(100);
                    string w = Encrypt(dte.ToString()) + ",";
                    File.WriteAllText(filename, w);

                    //regiestCode = File.ReadAllText(filename).Split(',')[1];

                }
                frmPortSet fc = new frmPortSet();
                fc.ShowDialog();
            }
            timer1.Enabled = true;
            TimeSpan ff = new TimeSpan(0);          

            if (RemotingType == "tcp")
            {
                #region TCP模式
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                RemotingConfiguration.CustomErrorsEnabled(false);
                System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseTime = ff;
                BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
                provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                IDictionary props = new Hashtable();
                props["port"] = Port;

                TcpChannel chan = new TcpChannel(props, null, provider);

                ChannelServices.RegisterChannel(chan, false);
              
                ObjRef obj = RemotingServices.Marshal(Operater, "Tcpservice");   //Tcpservice         
                RemotingServices.Unmarshal(obj);

                #endregion
            }
            else
            {
                #region Http模式
                HttpServerChannel serverChannel = new HttpServerChannel(Port);  //RemoteObject.soap
                ChannelServices.RegisterChannel(serverChannel, false);
                // Expose an object for remote calls.      
                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(DbHelp), "RemoteObject.soap",
                    WellKnownObjectMode.Singleton);
                #endregion
            }

            notifyIcon1.Text = "端口号：" + Port.ToString() + "remoting服务正在运行中,协议模式" + RemotingType;
            this.Visible = false;

            lbllimit.Text = "CPUID:" + GetCpuID();                     

        }


        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {              
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                if (!File.Exists(filename))
                {
                    //首次使用
                    DateTime dte = Operater.GetSystemTime().AddDays(100);
                    string w = Encrypt(dte.ToString()) + ",";
                    File.WriteAllText(filename, w);

                    //regiestCode = File.ReadAllText(filename).Split(',')[1];

                }
               

                if (regiestCode == null || regiestCode == "")
                {
                    #region 时效性验证
                    DateTime sysDate = DateTime.Now;
                    if (DateTime.Now.Hour == 8 ||
                        DateTime.Now.Hour == 10 ||
                        DateTime.Now.Hour == 12 ||
                        DateTime.Now.Hour == 14 ||
                        DateTime.Now.Hour == 18 ||
                        DateTime.Now.Hour == 23)
                    {
                        sysDate = Operater.GetSystemTime();
                    }

                    int days = getLimitsDays(sysDate);
                    string msg = "还剩试用天数：" + days + "天。\n为了确保系统使用不受影响请及时与软件厂商进行沟通！";
                    showinfo = "目前还剩" + days + "天";


                    /*
                     * 信息提示设置
                     */
                    FormCollection collection = Application.OpenForms;
                    if (DateTime.Now.Second == 8)
                    {

                        int fflag = 0;
                        for (int i = 0; i < collection.Count; i++)
                        {
                            if (collection[i].Name.Contains("frmMessageShow"))
                            {
                                frmMessageShow f1 = (frmMessageShow)collection[i];
                                f1.ini(msg);
                                fflag = 1;
                                break;
                            }
                        }
                        if (fflag == 0)
                        {
                            frmMessageShow f1 = new frmMessageShow();
                            f1.Show();
                            f1.ini(msg);
                        }
                    }

                    if (days <= 0)
                    {

                        for (int i = 0; i < collection.Count; i++)
                        {
                            if (collection[i].Name.Contains("frmMessageShow"))
                            {
                                frmMessageShow f1 = (frmMessageShow)collection[i];
                                f1.Close(); //关闭已有提示框
                                break;
                            }
                        }

                        RemotingServices.Disconnect(Operater);
                        timer1.Enabled = false;
                        showinfo = "目前已经过期！";
                        MessageBox.Show("试用期限已过，请与软件开发厂商联系！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    #endregion
                }
               
                this.Visible = false;

                Operater.RemoveOutLimited();              
                richTextBox1.Text = "";
                for (int i = 0; i < DbHelp.ArrCients.Count; i++)
                {
                    client_obj tb = (client_obj)DbHelp.ArrCients[i];
                    tb.LinkCount++;
                    string strval = tb.Ip + " " + tb.UserName + " " + tb.ZhiWu + " " + tb.ZhiCheng + " " + tb.Account_Name;
                    if (richTextBox1.Text.Trim() == "")
                    {
                        richTextBox1.Text = strval;
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "\n" + strval;
                    }
                }
                
                
            }
            catch
            { }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;                
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }

        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
           
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //notifyIcon1.ShowBalloonTip(5000, "remoting提示消息", "端口号：" + Port.ToString() + "remoting服务正在运行中", ToolTipIcon.Info);
        }

        private void frmRemotingServer_MinimumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void frmRemotingServer_Resize(object sender, EventArgs e)
        {          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Oral ff = new Oral();
            ////DBParameter[] tt = new DBParameter[1];
            ////tt[0] = new DBParameter();
            ////tt[0].DBType =System.Data.OracleClient.OracleType.VarChar ;
            ////tt[0].ParameterName = "ttt";
            ////tt[0].Value = "3";
            ////ff.RunProcedure("TEST", tt);

            //DBParameter[] tt = new DBParameter[2];
            //tt[0] = new DBParameter();
            //tt[0].DBType = System.Data.OracleClient.OracleType.Number;
            //tt[0].ParameterName = "us_id";
            //tt[0].Value = "3";


            //tt[1] = new DBParameter();
            //tt[1].DBType = System.Data.OracleClient.OracleType.Cursor;
            //tt[1].ParameterName = "cur_name";
            //tt[1].Direction = ParameterDirection.Output;
            //DataSet ds = ff.RunProcedureGetData("PKG_select_text.Getusername", tt);
           


        }

        private void frmRemotingServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        /// <summary>
        /// 获取试用天数
        /// </summary>
        /// <param name="sysDate"></param>
        /// <returns></returns>
        public int getLimitsDays(DateTime sysDate)
        {
            string dtestr = Decrypt(File.ReadAllText(filename).Split(',')[0]);
            DateTime limitDate = Convert.ToDateTime(dtestr);
            TimeSpan d3 = limitDate.Subtract(sysDate);
            return d3.Days;
        }
        

        #region 加密字符串
        /// <summary> /// 加密字符串   
        /// </summary>  
        /// <param name="str">要加密的字符串</param>  
        /// <returns>加密后的字符串</returns>  
        public static string Encrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化加密流对象   
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);  //向加密流中写入数据      

            CStream.FlushFinalBlock();              //释放加密流      

            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
        }
        #endregion

        #region 解密字符串
        /// <summary>  
        /// 解密字符串   
        /// </summary>  
        /// <param name="str">要解密的字符串</param>  
        /// <returns>解密后的字符串</returns>  
        public static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化解密流对象       
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);      //向解密流中写入数据     

            CStream.FlushFinalBlock();               //释放解密流      

            return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
        }
        #endregion 

        public static string GetCpuID()
        {
            try
            {
                //获取CPU序列号代码
                string cpuInfo = "";//cpu序列号
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }

    }
}