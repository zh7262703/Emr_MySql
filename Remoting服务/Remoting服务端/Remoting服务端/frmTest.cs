using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataOperater;
using System.IO;
using System.Security.Cryptography;

namespace Remoting服务端
{
    public partial class frmTest : Form
    {
        static string encryptKey = "Oyea";    //定义密钥

        public frmTest()
        {
            InitializeComponent();
        }

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

        private void frmTest_Load(object sender, EventArgs e)
        {
            DbHelp db = new DbHelp();
            string mysqllink = Decrypt(File.ReadAllText("mysqldatalink.txt"));
            db.mysql_connectionString = mysqllink;
            dataGridView1.DataSource= db.GetDataSet_MySql("select * from t_text").Tables[0].DefaultView;
        }
    }
}
