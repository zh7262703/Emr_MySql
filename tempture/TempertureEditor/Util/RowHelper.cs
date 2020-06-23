using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace TempertureEditor.Util
{
    public class RowHelper
    {
        #region 获取行中的值
        public static bool GetBoolean(DataRow vRow, string vField)
        {
            return Get<bool>(vRow, vField);
        }

        public static int GetInt(DataRow vRow, string vField)
        {
            return Get<int>(vRow, vField);
        }

        public static double GetDouble(DataRow vRow, string vField)
        {
            return Get<double>(vRow, vField);
        }

        public static decimal GetDecimal(DataRow vRow, string vField)
        {
            return Get<decimal>(vRow, vField);
        }

        public static string GetString(DataRow vRow, string vField)
        {
            return Get<string>(vRow, vField);
        }

        public static string GetPrice(DataRow vRow, string vField)
        {
            object obj = Get(vRow, vField);
            return StringHelper.GetPrice(obj);
        }

        public static T Get<T>(DataRow vRow, string vField)
        {
            object obj = Get(vRow, vField);
            return StringHelper.Get<T>(obj);
        }

        public static object Get(DataRow vRow, Type vType, string vField)
        {
            object obj = Get(vRow, vField);
            return StringHelper.Get(vType, obj);
        }

        public static DateTime? GetDateTime(DataRow vRow, string vField)
        {
            object obj = Get(vRow, vField);
            return StringHelper.GetDateTime(obj);
        }

        public static object Get(DataRow vRow, string vField)
        {
            if (vRow == null)
            {
                return null;
            }
            if (!vRow.Table.Columns.Contains(vField))
            {
                return null;
            }
            if (vRow.RowState == DataRowState.Detached)
            {
                return null;
            }
            return vRow[vField];
        }

        public static void Set(DataRow dataRow, string vName, object value)
        {
            if (!dataRow.Table.Columns.Contains(vName))
            {
                dataRow.Table.Columns.Add(vName);
            }
            dataRow[vName] = value;
        }
        #endregion

        #region 操作数据集
        /// <summary>
        /// 移除表格中的列
        /// </summary>
        /// <param name="vTable">表</param>
        /// <param name="vColumns">列集合</param>
        public static void RemoveColumn(DataTable vTable, params string[] vColumns)
        {
            if (vColumns != null)
            {
                foreach (string vColumn in vColumns)
                {
                    try
                    {
                        vTable.Columns.Remove(vColumn);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }

        public static void AddTable(DataSet dataSet, DataTable vTableData)
        {
            if (dataSet == null || vTableData == null)
            {
                return;
            }

            DataTable vCopyTable = vTableData.Copy();
            vCopyTable.TableName = string.Empty;
            dataSet.Tables.Add(vCopyTable);
        }

        public static void AddColumn(DataTable vTable, params string[] columns)
        {
            if (vTable == null)
            {
                return;
            }
            foreach (string vColumn in columns)
            {
                if (!vTable.Columns.Contains(vColumn))
                {
                    vTable.Columns.Add(vColumn);
                }
            }
        }

        public static void AddColumn(DataTable vTable, Type vType)
        {
            foreach (PropertyInfo vPro in vType.GetProperties())
            {
                if (vPro.CanRead && vPro.CanWrite)
                {
                    AddColumn(vTable, vPro.Name, vPro.PropertyType);
                }
            }

            foreach (FieldInfo vFie in vType.GetFields())
            {
                AddColumn(vTable, vFie.Name, vFie.FieldType);
            }
        }

        public static void AddColumn(DataTable vTable, string vName, Type vType)
        {
            if (vTable.Columns.Contains(vName))
            {
                return;
            }
            if (vType.FullName.IndexOf("System.Nullable`1") == 0)
            {
                vTable.Columns.Add(vName);
            }
            else
            {
                vTable.Columns.Add(vName, vType);
            }
        }

        public static DataTable CloneTable(DataTable vFrom)
        {
            DataTable vTo = vFrom.Copy();
            vTo.DefaultView.RowFilter = vFrom.DefaultView.RowFilter;
            return vTo;
            /*
            DataTable vTableClone = vTable.Clone();
            foreach (DataRow vRow in vTable.Rows)
            {
                DataRow vRowClone = vTableClone.NewRow();
                foreach (DataColumn column in vTable.Columns)
                {
                    vRowClone[column.ColumnName] = vRow[column.ColumnName];
                }
                vTableClone.Rows.Add(vRowClone);
            }
            return vTableClone;
             * */
        }

        public static void CopyRow(DataRow vFromRow, DataRow vToRow)
        {
            foreach (DataColumn vFromColumn in vFromRow.Table.Columns)
            {
                AddColumn(vToRow.Table, vFromColumn.ColumnName);
                DataColumn vToColumn = vToRow.Table.Columns[vFromColumn.ColumnName];
                vToRow[vToColumn] = RowHelper.Get(vFromRow, vToColumn.DataType, vFromColumn.ColumnName);
            }
        }
        #endregion

        #region 获取相等的值
        public static object GetTableText(DataTable vTable, string vValueField, string vTextField, object vValue)
        {
            if (vTable == null || vTable.Rows.Count == 0)
            {
                return null;
            }
            RowHelper.AddColumn(vTable, vValueField, vTextField);

            string vFilter = string.Format("{0}='{1}'", vValueField, vValue);
            DataRow[] vRows = vTable.Select(vFilter);
            if (vRows.Length == 0)
            {
                return null;
            }
            return vRows[0][vTextField];
        }
        #endregion

        /// <summary>
        /// 将表中的数据转换为相应的类型，放入到列表中
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="vList">列表</param>
        /// <param name="index">表的index</param>
        public static void AddList<T>(IList<T> vList, DataTable vTable)
            where T : class,new()
        {
            if (vList == null || vTable == null || vTable.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow vRow in vTable.Rows)
            {
                T t = ObjectHelper.Convert<T>(vRow);
                vList.Add(t);
            }
        }

        public static DataTable GetTable(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return new DataTable();
            }
            return dataTable;
        }
    }
}
