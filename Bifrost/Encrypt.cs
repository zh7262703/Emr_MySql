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
    /// ���ڼ��ܵ��� 
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2009-9-10
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// �Զ������Կ
        /// </summary>
        private const string strPublicKey = "ZHANGHUA7262703LEADRON";

        /// <summary>
        /// ���캯��        
        /// </summary>
        public Encrypt()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// ʹ��MD5�����ַ���
        /// </summary>
        /// <param name="_source">��Ҫ���ܵ��ַ���</param>
        /// <returns>���ؼ��ܺõĴ�</returns>
        public static string StrToMD5(string _source)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(_source, "MD5"); ;
        }

        /// <summary>
        /// ���ܺ�����ʹ�ù�����Կ
        /// </summary>
        /// <param name="_source">��Ҫ���ܵ��ַ���</param>
        /// <returns>���ؼ��ܺõĴ�</returns>
        public static string EncryptStr(string _source)
        {
            return EncryptStr(_source, strPublicKey);
        }

        /// <summary>
        /// ���ܺ�����ʹ���Զ�����Կ
        /// </summary>
        /// <param name="_source">��Ҫ���ܵ��ַ���</param>
        /// <param name="_key">��Կ��16λ�ַ���</param>
        /// <returns>���ؼ��ܺõĴ�</returns>
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
        /// ���ܺ�����ʹ�ù�����Կ
        /// </summary>
        /// <param name="_source">Ҫ���ܵ�����</param>
        /// <returns>���ؽ��ܺ���ַ���</returns>
        public static string DecryptStr(string _source)
        {
            return DecryptStr(_source, strPublicKey);
        }

        /// <summary>
        /// ���ܺ�����ʹ���Զ�����Կ
        /// </summary>
        /// <param name="_source">Ҫ���ܵ�����</param>
        /// <param name="_key">��Կ��16λ�ַ���</param>
        /// <returns>���ؽ��ܺ���ַ���</returns>
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
