using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Reflection;

namespace TempertureEditor.Util
{
    public class ObjectHelper
    {
        #region 获取设置对象值
        public static object Get(object obj)
        {
            object ret = obj;
            //if (obj is JToken)
            //{
            //    JToken vToken = obj as JToken;
            //    if (vToken == null)
            //    {
            //        ret = null;
            //    }
            //    else if (vToken is JValue)
            //    {
            //        ret = (vToken as JValue).Value;
            //    }
            //    else if (vToken is JProperty)
            //    {
            //        ret = Get((vToken as JProperty).Value);
            //    }
            //    else
            //    {
            //        ret = vToken;
            //    }
            //}
            return ret;
        }

        public static object Get(object obj, string vName)
        {
            object ret = null;
            if (obj == null)
            {
                return ret;
            }

            Type vType = obj.GetType();
            if (vType.IsValueType || vType.IsEnum)
            {
                ret = null;
            }
            else if (obj is IDictionary)
            {
                ret = DictionaryHelper.Get(obj as IDictionary, vName);
            }
            else if (obj is DataRow)
            {
                return RowHelper.Get(obj as DataRow, vName);
            }
            //else if (obj is JObject)
            //{
            //    return Get((obj as JObject)[vName]);
            //}
            else if (vType.IsClass)
            {
                PropertyInfo pro = vType.GetProperty(vName);
                if (pro != null)
                {
                    ret = pro.GetValue(obj, null);
                }
                else
                {
                    FieldInfo fie = vType.GetField(vName);
                    if (fie != null)
                    {
                        ret = fie.GetValue(obj);
                    }
                }
            }

            if (ret != null)
            {
                Type vAttrType = ret.GetType();
                Type vGenType = null;
                if (vAttrType.IsGenericType)
                {
                    vGenType = ret.GetType().GetGenericArguments()[0];
                }

                //if (ret is JArray ||
                //    ret is ArrayList ||
                //    (vGenType != null && (vGenType == typeof(JObject) || vGenType.FullName == "System.Object")))
                //{
                //    IList vInputList = ret as IList;
                //    IList vList = ConvertList(vInputList);
                //    if (!(obj is JObject))
                //    {
                //        Set(obj, vName, vList);
                //    }
                //    ret = vList;
                //}
                //else if (ret is JObject)
                //{
                //    ret = DictionaryHelper.ConvertDictionary(ret);
                //}
            }

            return ret;
        }

        public static void Set(object obj, string vName, object value)
        {
            if (obj == null)
            {
                return;
            }
            Type vType = obj.GetType();
            if (vType.IsValueType || vType.IsEnum)
            {
                return;
            }
            else if (obj is IDictionary)
            {
                (obj as IDictionary)[vName] = value;
            }
            else if (obj is DataRow)
            {
                RowHelper.Set(obj as DataRow, vName, value);
            }
            //else if (obj is JObject)
            //{
            //    (obj as JObject)[vName] = new JValue(value);
            //}
            else if (vType.IsClass)
            {
                SetTypeValue(vType, obj, vName, value);
            }
        }

        public static void SetTypeValue(Type vType, object obj, string vName, object value)
        {
            {
                PropertyInfo pro = vType.GetProperty(vName);
                if (pro != null)
                {
                    Type vProType = pro.PropertyType;
                    object vTypeValue = StringHelper.Get(vProType, value);
                    pro.SetValue(obj, vTypeValue, null);
                    return;
                }
            }
            {
                FieldInfo fie = vType.GetField(vName);
                if (fie != null)
                {
                    Type vProType = fie.FieldType;
                    object vTypeValue = StringHelper.Get(vProType, value);
                    fie.SetValue(obj, vTypeValue);
                }
            }
        }
        #endregion

        #region 获取对象的某个数据值
        public static int GetInt(object obj, string vName)
        {
            return Get<int>(obj, vName);
        }

        public static string GetString(object obj, string vName)
        {
            return Get<string>(obj, vName);
        }

        public static decimal GetDecimal(object obj, string vName)
        {
            return Get<decimal>(obj, vName);
        }

        public static T Get<T>(object obj, string vName)
        {
            object val = Get(obj, vName);
            return StringHelper.Get<T>(val);
        }
        #endregion

        #region 转换对象
        public static void AddList<T>(List<T> vTo, object vFrom, string vField)
            where T : class ,new()
        {
            IList vFroms = ObjectHelper.Get<IList>(vFrom, vField);
            if (vFroms == null || vTo == null)
            {
                return;
            }

            foreach (var vFromItem in vFroms)
            {
                T vToItem = ObjectHelper.Convert<T>(vFromItem);
                vTo.Add(vToItem);
            }
        }

        public static void AddListBase<T>(List<T> vTo, object vFrom, string vField)
        {
            IList vFroms = ObjectHelper.Get<IList>(vFrom, vField);
            if (vFroms == null || vTo == null)
            {
                return;
            }

            foreach (var vFromItem in vFroms)
            {
                T vToItem = StringHelper.Get<T>(vFromItem);
                vTo.Add(vToItem);
            }
        }

        public static T Convert<T>(T vTo, object vFrom)
            where T : class
        {
            if (vFrom is T)
            {
                return vFrom as T;
            }
            if (vTo == null)
            {
                return null;
            }
            WriteWithToClass(vTo, vFrom);
            return vTo;
        }

        public static T Convert<T>(object vFrom)
            where T : class ,new()
        {
            if (vFrom is T)
            {
                return vFrom as T;
            }
            T vTo = new T();
            return Convert<T>(vTo, vFrom);
        }

        public static object WriteWithToClass(object vTo, object vFrom)
        {
            if (vTo == null)
            {
                return null;
            }
            Type vToType = vTo.GetType();
            PropertyInfo[] vProps = vToType.GetProperties();
            foreach (PropertyInfo vItem in vProps)
            {
                if (!vItem.CanWrite)
                {
                    continue;
                }
                object vValue = ObjectHelper.Get(vFrom, vItem.Name);
                if (vValue == null || vValue.GetType() == typeof(System.DBNull))
                {
                    vValue = null;
                }
                try
                {
                    if (IsWriteType(vItem.PropertyType, vValue))
                    {
                        vItem.SetValue(vTo, StringHelper.Get(vItem.PropertyType, vValue), null);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }

            FieldInfo[] vFields = vToType.GetFields();
            foreach (FieldInfo vItem in vFields)
            {
                object vValue = ObjectHelper.Get(vFrom, vItem.Name);
                try
                {
                    if (IsWriteType(vItem.FieldType, vValue))
                    {
                        vItem.SetValue(vTo, StringHelper.Get(vItem.FieldType, vValue));
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }

            return vTo;
        }

        public static object WriteWithFromClass(object vTo, object vFrom)
        {
            if (vFrom == null)
            {
                return vTo;
            }
            Type vFromType = vFrom.GetType();
            PropertyInfo[] vProps = vFromType.GetProperties();
            foreach (PropertyInfo vItem in vProps)
            {
                if (!vItem.CanWrite)
                {
                    continue;
                }
                object vValue = ObjectHelper.Get(vFrom, vItem.Name);
                if (vValue == null || vValue.GetType() == typeof(System.DBNull))
                {
                    vValue = null;
                }
                try
                {
                    if (IsWriteType(vItem.PropertyType, vValue))
                    {
                        ObjectHelper.Set(vTo, vItem.Name, vValue);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }

            FieldInfo[] vFields = vFromType.GetFields();
            foreach (FieldInfo vItem in vFields)
            {
                object vValue = ObjectHelper.Get(vFrom, vItem.Name);
                try
                {
                    if (IsWriteType(vItem.FieldType, vValue))
                    {
                        ObjectHelper.Set(vTo, vItem.Name, vValue);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }

            return vTo;
        }

        public static IList ConvertList(IList obj)
        {
            IList vList = new List<object>();
            foreach (object item in obj)
            {
                vList.Add(item);
                //if (item is JObject)
                //{
                //    vList.Add(DictionaryHelper.ConvertDictionary(item));
                //}
                //else
                //{
                //    vList.Add(item);
                //}
            }
            return vList;
        }

        public static List<T> GetList<T>(object obj)
        {
            List<T> vTo = new List<T>();

            #region 获取辅助码数组
            if (obj is IList)
            {
                IList vCodeFrom = obj as IList;
                foreach (object vItem in vCodeFrom)
                {
                    if (StringHelper.IsEmpty(vItem))
                    {
                        continue;
                    }
                    vTo.Add(StringHelper.Get<T>(vItem));
                }
            }
            else
            {
                if (!StringHelper.IsEmpty(obj))
                {
                    vTo.Add(StringHelper.Get<T>(obj));
                }
            }
            #endregion

            return vTo;
        }

        public static bool IsWriteType(Type a, object b)
        {
            if (!a.IsClass)
            {
                return true;
            }
            if (a == typeof(string))
            {
                return true;
            }
            bool isEmpty = StringHelper.IsEmpty(b);
            if (isEmpty)
            {
                return true;
            }

            //if (b is JObject && a.IsClass)
            //{
            //    return true;
            //}

            return a.IsAssignableFrom(b.GetType());
        }

        public static bool IsAutoConvert(Type vToType, Type vFromType)
        {
            return vFromType != vToType && (vToType.IsValueType || vToType.IsEnum || vToType == typeof(string));
        }
        #endregion


        public static DataTable ToTable(object vInfo)
        {
            return AddTable(null, vInfo, 0);
        }

        public static DataTable AddTable(DataTable vTable, object vInfo)
        {
            return AddTable(vTable, vInfo, 0);
        }

        public static DataTable AddTable(DataTable vTable, object vInfo, int offset)
        {
            return AddTable(vTable, new List<object> { vInfo }, offset);
        }
        public static DataTable AddTable(DataTable vTable, IList vList)
        {
            return AddTable(vTable, vList, 0);
        }

        public static DataTable AddTable(DataTable vTable, IList vList, int offset)
        {
            if (vTable == null)
            {
                vTable = new DataTable();
            }
            foreach (object item in vList)
            {
                offset++;
                DataRow vRow = null;
                if (vTable.Rows.Count < offset)
                {
                    vRow = vTable.NewRow();
                    vTable.Rows.Add(vRow);
                }
                else
                {
                    vRow = vTable.Rows[offset];
                }
                WriteWithFromClass(vRow, item);
            }
            return vTable;
        }

        public static T GetItem<T>(List<T> list, int iTo)
        {
            if (list == null || list.Count == 0)
            {
                return default(T);
            }
            else if (iTo >= list.Count || iTo < 0)
            {
                return default(T);
            }
            else
            {
                return list[iTo];
            }
        }
    }
}
