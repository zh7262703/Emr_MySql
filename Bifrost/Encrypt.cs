using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.IO;
using System.Web.Security;

namespace Bifrost
{   
    /// <summary>
    /// 用于加密的类 
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// 自定义的密钥
        /// </summary>
        private const string strPublicKey = "ZHANGHUA7262703LEADRON";

        /// <summary>
        /// 构造函数        
        /// </summary>
        public Encrypt()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 使用MD5加密字符串
        /// </summary>
        /// <param name="_source">需要加密的字符串</param>
        /// <returns>返回加密好的串</returns>
        public static string StrToMD5(string _source)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(_source, "MD5"); ;
        }

        /// <summary>
        /// 加密函数，使用公共密钥
        /// </summary>
        /// <param name="_source">需要加密的字符串</param>
        /// <returns>返回加密好的串</returns>
        public static string EncryptStr(string _source)
        {
            return EncryptStr(_source, strPublicKey);
        }

        /// <summary>
        /// 加密函数，使用自定义密钥
        /// </summary>
        /// <param name="_source">需要加密的字符串</param>
        /// <param name="_key">密钥，16位字符串</param>
        /// <returns>返回加密好的串</returns>
        public static string EncryptStr(string _source, string _key)
        {
            string strSource, strKey;
            strKey = _key.Substring(0, 8);
            Byte[] byKey = ASCIIEncoding.ASCII.GetBytes(strKey);
            strKey = _key.Substring(8, 8);
            Byte[] byIV = ASCIIEncoding.ASCII.GetBytes(strKey);
            DES objDES = new DESCryptoServiceProvider();
            objDES.Key = byKey;
            objDES.IV = byIV;
            byte[] byInput = Encoding.Default.GetBytes(_source);
            MemoryStream objMemoryStream = new MemoryStream();
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(), CryptoStreamMode.Write);
            objCryptoStream.Write(byInput, 0, byInput.Length);
            objCryptoStream.FlushFinalBlock();
            StringBuilder objStringBuilder = new StringBuilder();
            foreach (byte b in objMemoryStream.ToArray())
            {
                objStringBuilder.AppendFormat("{0:X2}", b);
            }
            strSource = objStringBuilder.ToString();
            objCryptoStream.Close();
            objMemoryStream.Close();
            return strSource.ToString();
        }

        /// <summary>
        /// 解密函数，使用公共密钥
        /// </summary>
        /// <param name="_source">要解密的内容</param>
        /// <returns>返回解密后的字符串</returns>
        public static string DecryptStr(string _source)
        {
            return DecryptStr(_source, strPublicKey);
        }

        /// <summary>
        /// 解密函数，使用自定义密钥
        /// </summary>
        /// <param name="_source">要解密的内容</param>
        /// <param name="_key">密钥，16位字符串</param>
        /// <returns>返回解密后的字符串</returns>
        public static string DecryptStr(string _source, string _key)
        {
            string strSource, strKey;
            try
            {
                strKey = _key.Substring(0, 8);
                Byte[] bytKey = ASCIIEncoding.ASCII.GetBytes(strKey);
                strKey = _key.Substring(8, 8);
                Byte[] bytIV = ASCIIEncoding.ASCII.GetBytes(strKey);
                DES objDES = new DESCryptoServiceProvider();
                objDES.Key = bytKey;
                objDES.IV = bytIV;
                byte[] bytInputByteArray = new byte[_source.Length / 2];
                for (int x = 0; x < (_source.Length / 2); x++)
                {
                    int i = (Convert.ToInt32(_source.Substring(x * 2, 2), 16));
                    bytInputByteArray[x] = (byte)i;
                }
                MemoryStream objMemoryStream = new MemoryStream();
                CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateDecryptor(), CryptoStreamMode.Write);
                objCryptoStream.Write(bytInputByteArray, 0, bytInputByteArray.Length);
                objCryptoStream.FlushFinalBlock();
                strSource = Encoding.Default.GetString(objMemoryStream.ToArray());
                objMemoryStream.Close();
            }
            catch
            {
                strSource = "Key Error...";
            }
            return strSource;
        }
    }
}
