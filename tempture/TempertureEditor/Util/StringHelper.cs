using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;

namespace TempertureEditor.Util
{
    public enum EnumCompare
    {
        Small = -1,
        Equals = 0,
        Big = 1,
        Null = 2
    }

    /// <summary>
    /// 字符串操作帮助类，传入很多字符串，获取第一个非空的字符串
    /// </summary>
    public class StringHelper
    {
        #region 获取值类型
        /// <summary>
        /// 将字符串转换为 bool ，当不能转换时，则默认为false
        /// </summary>
        /// <param name="vValue">需要转换的字符串</param>
        /// <param name="vDefault">默认值</param>
        /// <returns>转换成功后的值</returns>
        public static bool GetBoolean(object vValue, bool vDefault)
        {
            bool result = vDefault;
            try
            {
                if (!StringHelper.IsEmpty(vValue))
                {
                    result = (!StringHelper.SafeCompare(vValue, "0", true)
                        && !StringHelper.SafeCompare(vValue, "false", true)
                        && !StringHelper.SafeCompare(vValue, "f", true)
                        && !StringHelper.SafeCompare(vValue, "no", true)
                        && !StringHelper.IsEmpty(vValue)
                        && !StringHelper.SafeCompare(vValue, "n", true));
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }



        /// <summary>
        /// 将字符串转换为 bool ，当不能转换时，则默认为false
        /// </summary>
        /// <param name="vValue">需要转换的字符串</param>
        /// <returns>转换成功后的值</returns>
        public static bool GetBoolean(object vValue)
        {
            return GetBoolean(vValue, false);
        }

        /// <summary>
        /// 将字符串转换为 Int，当不能转换时，则默认为0
        /// </summary>
        /// <param name="obj">需要转换的字符串</param>
        /// <returns>转换成功后的值</returns>
        public static int GetInt(object vValue)
        {
            int result = 0;
            try
            {
                if (!StringHelper.IsEmpty(vValue))
                {
                    result = Convert.ToInt32(vValue);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex, StringHelper.GetString(vValue));
                //string vStr = "2625645988647";
                //if (StringHelper.SafeCompare(vStr, vValue, false))
                //{
                //    ThreadHelper.Sleep(10);
                //}
            }
            return result;
        }

        public static long GetLong(object vValue)
        {
            long result = 0;
            try
            {
                if (!StringHelper.IsEmpty(vValue))
                {
                    result = Convert.ToInt64(vValue);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex, StringHelper.GetString(vValue));
            }
            return result;
        }

        public static long GetLong(byte[] bytes)
        {
            if (bytes.Length > 0)
            {
                return BitConverter.ToInt64(bytes, 0);
            }
            return 0;
        }

        public static string GetPrice(object obj)
        {
            string str = "-";
            if (!IsEmpty(obj) && GetDouble(obj) != 0)
            {
                str = GetDouble(obj).ToString();
            }
            return str;
        }


        public static float GetFloat(object vValue)
        {
            float result = 0f;
            try
            {
                if (!StringHelper.IsEmpty(vValue))
                {
                    result = float.Parse(vValue.ToString());
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex, StringHelper.GetString(vValue));
            }
            return result;
        }

        public static short GetShort(object vValue)
        {
            short result = 0;
            try
            {
                if (!StringHelper.IsEmpty(vValue))
                {
                    result = Convert.ToInt16(vValue);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex, StringHelper.GetString(vValue));
            }
            return result;
        }

        /// <summary>
        /// 将字符串转换为 Double，当不能转换时，则默认为0
        /// </summary>
        /// <param name="obj">需要转换的字符串</param>
        /// <returns>转换成功后的值</returns>
        public static double GetDouble(object vValue)
        {
            double result = 0.0;
            try
            {
                if (!StringHelper.IsEmpty(vValue))
                {
                    result = Convert.ToDouble(vValue);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex, StringHelper.GetString(vValue));
            }
            return result;
        }

        /// <summary>
        /// 将字符串转换为Decimal，当不能转换时，则默认值为0
        /// </summary>
        /// <param name="vValue">需要转换的字符串</param>
        /// <returns>转换成功后的值</returns>
        public static decimal GetDecimal(object vValue)
        {
            decimal result = 0;
            try
            {
                if (!StringHelper.IsEmpty(vValue))
                {
                    result = Convert.ToDecimal(vValue);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex, StringHelper.GetString(vValue));
            }
            return result;
        }

        /// <summary>
        /// 将 object 转换为String
        /// </summary>
        /// <param name="obj">需要转换的object</param>
        /// <returns>转换成功的字符串</returns>
        public static string GetString(object obj)
        {
            obj = ObjectHelper.Get(obj);
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 将 object 转换为String
        /// </summary>
        /// <param name="obj">需要转换的object</param>
        /// <returns>转换成功的字符串</returns>
        public static string GetStringEmpty(object obj)
        {
            obj = ObjectHelper.Get(obj);
            return obj == null ? string.Empty : obj.ToString();
        }

        private static string[] m_formats = new string[] { "yyyy-MM-dd HH:mm:ss", "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-dd HH:mm", "yyyy-MM-dd" };
        public static DateTime? GetDateTime(object s)
        {
            if (s is DateTime)
            {
                return (DateTime)(s);
            }
            else if (s is DateTime?)
            {
                return s as DateTime?;
            }
            string strValue = StringHelper.GetString(s);
            DateTime? date = null;
            if (!string.IsNullOrEmpty(strValue))
            {
                // 第一次处理
                try
                {
                    date = DateTime.Parse(strValue);
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex, strValue);
                }

                //采用格式处理
                if (date == null)
                {
                    for (var i = 0; i < m_formats.Length; i++)
                    {
                        try
                        {
                            date = (DateTime?)DateTime.ParseExact(strValue, m_formats[i], null);
                        }
                        catch (Exception ex)
                        {
                            //LogHelper.WriteLog(ex, strValue);
                        }
                        if (date != null)
                        {
                            break;
                        }
                    }
                }
            }

            return date;
        }

        /// <summary>
        /// 根据类型来获取值
        /// </summary>
        /// <param name="vType">类型</param>
        /// <param name="fieldValue">对象</param>
        /// <returns>返回获取的值</returns>
        public static object Get(Type vType, object fieldValue)
        {
            if (vType.IsEnum)
            {
                string strValue = StringHelper.GetString(fieldValue);
                return EnumHelper.ConvertEnum(vType, strValue);
            }
            else if (IsType(vType, "System.String"))
            {
                return StringHelper.GetString(fieldValue);
            }
            else if (IsType(vType, "System.Boolean"))
            {
                string strValue = StringHelper.GetString(fieldValue);
                return StringHelper.GetBoolean(strValue);
            }
            else if (IsType(vType, "System.Int32"))
            {
                return StringHelper.GetInt(fieldValue);
            }
            else if (IsType(vType, "System.Double"))
            {
                return StringHelper.GetDouble(fieldValue);
            }
            else if (IsType(vType, "System.Decimal"))
            {
                return StringHelper.GetDecimal(fieldValue);
            }
            else if (IsType(vType, "System.Nullable`1[System.DateTime]"))
            {
                return StringHelper.GetDateTime(fieldValue);
            }
            else if (IsType(vType, "System.DateTime"))
            {
                DateTime? vValue = StringHelper.GetDateTime(fieldValue);
                return vValue == null ? DateTime.MinValue : vValue.Value;
            }
            //else if (vType.IsClass && fieldValue is JObject)
            //{
            //    return JSONHelper.DeserializeObject(JSONHelper.SerializeObject(fieldValue), vType);
            //}

            return fieldValue;
        }

        public static T Get<T>(object fieldValue)
        {
            return (T)Get(typeof(T), fieldValue);
        }

        #endregion

        #region 获取指定格式的字符串
        public static byte[] GetByte(string str)
        {
            byte[] bytes = new byte[str.Length / 2];
            for (int i = 0; i < str.Length / 2; i++)
            {
                int btvalue = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                bytes[i] = (byte)btvalue;
            }
            return bytes;
        }

        public static byte ToBCD(int p)
        {
            if (p >= 100)
            {
                throw new Exception("整形转换成字节的PCD码必须小于100");
            }
            byte bt = (byte)((p / 10 * 16) + p % 10);
            return bt;
        }

        public static int FromBCD(byte bt)
        {
            return (bt / 16) * 10 + bt % 16;
        }

        public static string GetStringByte(byte[] bytes)
        {
            return GetStringByte(bytes, 0, 0);
        }

        public static string GetStringByte(byte[] bytes, int start, int len)
        {
            if (len == 0)
            {
                len = bytes.Length;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < start + len; i++)
            {
                byte by = bytes[i];
                sb.AppendFormat("{0:X2}", by);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 使用Unicode转码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodingString(string str)
        {
            return EncodingString(Encoding.Unicode, str);
        }

        /// <summary>
        /// 字符串编码转换
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns></returns>
        public static string EncodingString(Encoding encoding, string str)
        {
            byte[] buff = encoding.GetBytes(str);
            str = Encoding.Default.GetString(buff, 0, buff.Length);//将字节流转换为字符串
            str = str.Replace("\0", String.Empty).Replace("\n", String.Empty);
            return str;
        }

        /// <summary>
        /// 传入很多字符串，获取第一个非空的字符串，至少需要两个参数
        /// </summary>
        /// <param name="obj0">第一个参数</param>
        /// <param name="obj1">第二个参数</param>
        /// <param name="obj2">参数列表</param>
        /// <returns>第一个非空字符串</returns>
        public static string GetLastString(string obj0, string obj1, params string[] obj2)
        {
            if (!string.IsNullOrEmpty(obj0))
            {
                return obj0;
            }
            if (!string.IsNullOrEmpty(obj1))
            {
                return obj1;
            }
            foreach (string str in obj2)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    return str;
                }
            }
            return string.Empty;
        }

        public static string GetTrim(string vCode)
        {
            if (vCode == null)
            {
                return null;
            }
            return vCode.Trim();
        }

        /// <summary>
        /// 获取名称，当第一个值为空时，则返回第二个值，否则返回第一个值
        /// </summary>
        /// <param name="vName">第一个值</param>
        /// <param name="vDefaultName">需要代替的值</param>
        /// <returns>返回不为空的值</returns>
        public static string GetDefaultName(string vName, string vDefaultName)
        {
            if (string.IsNullOrEmpty(vName))
            {
                return vDefaultName;
            }
            return vName;
        }

        public static string GetDateTimeString(string p, DateTime? vLastTime)
        {
            string vEmpty = string.Empty;
            if (vLastTime != null)
            {
                vEmpty = vLastTime.Value.ToString(p);
            }
            return vEmpty;
        }

        public static string GetStringLen(double data, int vLen)
        {
            return GetStringLen(data, vLen, "0");
        }

        public static string GetStringLen(double data, int vLen, string c)
        {
            string vIndex = data.ToString();
            for (var i = vIndex.Length; i < vLen; i++)
            {
                vIndex = c + vIndex;
            }
            return vIndex;
        }

        public static string GetStringLenLast(double data, int vLen, string c)
        {
            string vIndex = data.ToString();
            for (var i = vIndex.Length; i < vLen; i++)
            {
                vIndex = vIndex + c;
            }
            return vIndex;
        }
        #endregion

        #region 判断字符串类型以及对比
        /// <summary>
        /// 将数组转换为字符串
        /// </summary>
        /// <param name="vStrs">需要转换的数组</param>
        /// <returns>转换成功后的字符串</returns>
        public static string ArrayToString(string[] vStrs)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i;
            for (i = 0; i < vStrs.Length - 1; i++)
            {
                stringBuilder.Append(vStrs[i].Replace("@", "@@"));
                stringBuilder.Append("<@>");
            }
            stringBuilder.Append(vStrs[i].Replace("@", "@@"));
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 将字符串转换为数组
        /// </summary>
        /// <param name="vStr">需要转换的字符串</param>
        /// <returns>转换成功后的数组</returns>
        public static string[] StringToArray(string vStr)
        {
            string text = "<@>";
            List<string> list = new List<string>();
            int num = 0;
            int num2;
            while ((num2 = vStr.IndexOf(text, num)) != -1)
            {
                string item = vStr.Substring(num, num2 - num).Replace("@@", "@");
                list.Add(item);
                num = num2 + text.Length;
            }
            string item2 = vStr.Substring(num).Replace("@@", "@");
            list.Add(item2);
            return list.ToArray();
        }


        /// <summary>
        /// 比较两个字符串是否相等
        /// </summary>
        /// <param name="string1">字符串1</param>
        /// <param name="string2">字符串2</param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <returns>比较结果</returns>
        public static bool SafeCompare(string string1, string string2, bool ignoreCase)
        {
            return string1 != null
                && string2 != null
                && string1.Length == string2.Length
                && string.Compare(string1, string2, ignoreCase, CultureInfo.InvariantCulture) == 0;
        }


        /// <summary>
        /// 比较两个对象转换为字符串是否相等
        /// </summary>
        /// <param name="a">字符串1</param>
        /// <param name="b">字符串2</param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <returns>比较结果</returns>
        public static bool SafeCompare(object a, object b, bool ignoreCase)
        {
            string aStr = string.Empty;
            string bStr = string.Empty;

            if (a != null)
            {
                aStr = a.ToString();
            }

            if (b != null)
            {
                bStr = b.ToString();
            }

            return SafeCompare(aStr, bStr, ignoreCase);
        }

        /// <summary>
        /// 检测字符是否为空
        /// </summary>
        /// <param name="p">需要检测的字符</param>
        /// <returns>检测结果</returns>
        public static bool IsEmptyChar(char p)
        {

            return char.IsWhiteSpace(p);
#if other
            if (p == '\r' || p == '\n' || p == '\t' || p == ' ')
            {
                return true;
            }
            return false;
#endif
        }

        /// <summary>
        /// 类型匹配
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="typeName">类型的名称</param>
        /// <returns>读取的结果</returns>
        public static bool IsType(Type type, string typeName)
        {
            if (type == null)
            {
                return false;
            }
            else if (type.ToString() == typeName)
            {
                return true;
            }
            if (type.ToString() == "System.Object")
            {
                return false;
            }
            else
            {
                return IsType(type.BaseType, typeName);
            }
        }

        public static bool IsEmpty(object vValue)
        {
            return vValue == null || string.IsNullOrEmpty(vValue.ToString());
        }
        #endregion

        /// <summary>
        /// 比较时间
        /// </summary>
        /// <param name="nullable"></param>
        /// <param name="vNow"></param>
        /// <returns></returns>
        public static EnumCompare CompareDate(DateTime? vFrom, DateTime vTo)
        {
            if (vFrom == null || !vFrom.HasValue)
            {
                return EnumCompare.Null;
            }

            if (vFrom.Value > vTo)
            {
                return EnumCompare.Big;
            }
            else if (vFrom.Value < vTo)
            {
                return EnumCompare.Small;
            }
            else
            {
                return EnumCompare.Equals;
            }
        }

        public static EnumCompare CompareTime(DateTime? vFrom, DateTime vTo)
        {
            if (vFrom == null || !vFrom.HasValue)
            {
                return EnumCompare.Null;
            }

            int iFrom = GetTimeMillSeconds(vFrom.Value);
            int iTo = GetTimeMillSeconds(vTo);
            if (iFrom > iTo)
            {
                return EnumCompare.Big;
            }
            else if (iFrom < iTo)
            {
                return EnumCompare.Small;
            }
            else
            {
                return EnumCompare.Equals;
            }
        }

        public static int GetTimeMillSeconds(DateTime vTime)
        {
            return vTime.Hour * 60 * 60 * 1000 + vTime.Minute * 60 * 1000 + vTime.Second * 1000 + vTime.Millisecond;
        }

        public static int GetPage(int p1, int p2)
        {
            if (p2 == 0)
            {
                return 0;
            }
            return p1 / p2 + (p1 % p2 > 0 ? 1 : 0);
        }

        public static string GetGo(params string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string vStr in args)
            {
                if (string.IsNullOrEmpty(vStr))
                {
                    continue;
                }
                if (sb.Length > 0)
                {
                    sb.Append(" => ");
                }
                sb.Append(vStr);
            }
            return sb.ToString();
        }


        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="vKey">密匙</param>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(byte[] vKey, string encryptString, string encryptKey)
        {
            if (!string.IsNullOrEmpty(encryptString))
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = vKey;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }

            return string.Empty;
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(byte[] vKey, string decryptString, string decryptKey)
        {
            if (!string.IsNullOrEmpty(decryptString))
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = vKey;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                byte[] bytes = mStream.ToArray();
                return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            }

            return string.Empty;
        }

        public static string[] Split(string vStr, string[] separator, StringSplitOptions options)
        {
            return vStr.Split(separator, options);
#if other
            return StringSplit.Split(vStr, separator, options);
#endif
        }

        public static string GetGUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static DateTime? GetDay(DateTime? vFrom)
        {
            DateTime? vTo = null;
            if (vFrom != null)
            {
                vTo = DateTime.Parse(GetDateTimeString("yyyy-MM-dd 00:00:00", vFrom));
            }
            return vTo;
        }

        public static DateTime? GetDayTo(DateTime? vFrom)
        {
            DateTime? vTo = null;
            if (vFrom != null)
            {
                vTo = DateTime.Parse(GetDateTimeString("yyyy-MM-dd 00:00:00", vFrom)).AddDays(1).AddMilliseconds(-1);
            }
            return vTo;
        }

        public static DateTime? GetTime(DateTime? vFrom)
        {
            DateTime? vTo = null;
            if (vFrom != null)
            {
                vTo = DateTime.Parse(GetDateTimeString("1987-11-04 HH:mm:ss", vFrom));
            }
            return vTo;
        }

        public static DateTime? GetTimeLast(string vFrom)
        {
            if (string.IsNullOrEmpty(vFrom) || StringHelper.SafeCompare(vFrom, "notime", true))
            {
                return null;
            }
            try
            {
                vFrom = "1987-11-04 " + vFrom;
                return DateTime.Parse(vFrom);
            }
            catch
            {
                return null;
            }
        }

        public static decimal GetMod(decimal vFrom, decimal vTemp)
        {
            return vTemp == 0 ? 0 : vFrom / vTemp;
        }

        public static string GetMd5(string vInput)
        {
            string text = "";
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(vInput);
                byte[] array = MD5.Create().ComputeHash(bytes);
                for (int i = 0; i < array.Length; i++)
                {
                    text += array[i].ToString("x2");
                }
            }
            catch (Exception ex)
            {
                
            }
            return text;
        }


        public static DateTime? GetDayStart(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            return DateTime.Parse(dateTime.Value.ToString("yyyy-MM-dd 00:00:00"));
        }

        public static DateTime? GetDayEnd(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            return GetDayStart(dateTime).Value.AddDays(1).AddSeconds(-1); ;
        }

        public static int GetHourMinutes(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return 0;
            }
            return dateTime.Value.Hour * 60 + dateTime.Value.Minute;
        }

        public static string GetHourMinutesFormat(DateTime? dateTime)
        {
            return GetDateTimeString("HH:mm", dateTime);
        }

        public static bool StringIsIn(string vFrom, params string[] vTos)
        {
            foreach (string vTo in vTos)
            {
                if (SafeCompare(vFrom, vTo, true))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否是IP地址
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string ipAddress)
        {
            string regexStr = @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$";
            Match regex = Regex.Match(ipAddress, regexStr);
            if (regex.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
