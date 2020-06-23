using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace TempertureEditor.Util
{
    public class DictionaryHelper
    {
        public static M GetCreate<T, M>(Dictionary<T, M> vDic, T vKey) where M : new()
        {
            if (vDic == null)
            {
                return default(M);
            }
            if (!vDic.ContainsKey(vKey))
            {
                vDic[vKey] = ((default(M) == null) ? Activator.CreateInstance<M>() : default(M));
            }
            return vDic[vKey];
        }

        public static object Get(IDictionary vDic, string vKey)
        {
            if (vDic == null || !vDic.Contains(vKey))
            {
                return null;
            }
            return vDic[vKey];
        }

        public static T Get<T>(Dictionary<string, T> vDic, string vKey)
        {
            return Get<string, T>(vDic, vKey);
        }

        public static M Get<T, M>(Dictionary<T, M> vDic, T vKey)
        {
            if (vDic == null || !vDic.ContainsKey(vKey))
            {
                return default(M);
            }
            return vDic[vKey];
        }

        public static T Get<T>(IDictionary vDic, string vKey)
        {
            object obj = null;
            if (vDic == null || !vDic.Contains(vKey))
            {
                return default(T);
            }
            obj = vDic[vKey];
            obj = StringHelper.Get(typeof(T), obj);
            return (T)obj;
        }

        /// <summary>
        /// 处理传入的参数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetDictionary(object data)
        {
            try
            {
                return data as Dictionary<string, object>;

                //if (data is Dictionary<string, object>)
                //{
                //    return data as Dictionary<string, object>;
                //}
                //else
                //{
                //    string json = JSONHelper.SerializeObject(data);
                //    return JSONHelper.DeserializeObject<Dictionary<string, object>>(json);
                //}
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public static IDictionary ConvertDictionary(object dataItem)
        {
            IDictionary data = dataItem as IDictionary;
            //if (data == null && dataItem is JObject)
            //{
            //    data = new Dictionary<string, object>();

            //    JObject jObject = dataItem as JObject;
            //    foreach (KeyValuePair<string, JToken> kvp in jObject)
            //    {
            //        string vKey = kvp.Key;
            //        JValue jValue = kvp.Value as JValue;
            //        if (jValue != null)
            //        {
            //            data[vKey] = jValue.Value;
            //        }
            //        else
            //        {
            //            data[vKey] = null;
            //        }
            //    }
            //}
            //else if (data == null)
            //{
            //    data = new Dictionary<string, object>();
            //}
            return data;
        }


        #region 数据集操作
        public static void CopyColumn(DataTable vSelectTable, string vFromName, string vToName)
        {
            if (!vSelectTable.Columns.Contains(vFromName))
            {
                vSelectTable.Columns.Add(vFromName);
            }
            if (!vSelectTable.Columns.Contains(vToName))
            {
                vSelectTable.Columns.Add(vToName);
            }
            for (var i = 0; i < vSelectTable.Rows.Count; i++)
            {
                DataRow vSourceRow = vSelectTable.Rows[i];
                string vID = string.Empty;
                try
                {
                    vID = vSourceRow[vFromName].ToString();
                }
                catch (Exception ex)
                {
                    
                }
                vSourceRow[vToName] = vID;
            }
        }

        /// <summary>
        /// 获取一行的数据
        /// </summary>
        /// <param name="vRow">需要获取的行</param>
        /// <returns>返回获取的值</returns>
        public static Dictionary<string, object> GetRowDictionary(DataRow vRow)
        {
            Dictionary<string, object> vDic = new Dictionary<string, object>();
            if (vRow != null)
            {
                foreach (DataColumn col in vRow.Table.Columns)
                {
                    vDic[col.ColumnName] = vRow[col];
                }
            }
            return vDic;
        }

        /// <summary>
        /// 获取转换的结果
        /// </summary>
        /// <param name="vTable">需要获取的表格</param>
        /// <returns>返回结果</returns>
        public static List<Dictionary<string, object>> GetListDictionarys(DataTable vTable)
        {
            if (vTable == null)
            {
                return null;
            }
            DataRow[] vRows = new DataRow[vTable.Rows.Count];
            vTable.Rows.CopyTo(vRows, 0);
            return GetListDictionarys(vRows);
        }

        /// <summary>
        /// 获取转换的结果
        /// </summary>
        /// <param name="vRows">获取选择的行数</param>
        /// <returns>返回结果</returns>
        public static List<Dictionary<string, object>> GetListDictionarys(DataRow[] vRows)
        {
            List<Dictionary<string, object>> vList = new List<Dictionary<string, object>>();

            foreach (DataRow vRow in vRows)
            {
                vList.Add(GetRowDictionary(vRow));
            }

            return vList;
        }
        #endregion
    }
}
