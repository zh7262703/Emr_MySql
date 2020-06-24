using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Bifrost
{
    [Serializable]
    public class MySqlDBParameter
    {
        private MySqlDbType mysqlType;//参数类型          
        private string parameterName;//参数名          
        private int size;//参数大小          
        private object parameterValue;//参数值
        private ParameterDirection direction;  //类型描述


        /// <summary>
        /// 
        /// </summary>  
        public MySqlDBParameter()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public MySqlDBParameter(string parameterName, MySqlDbType dbType, int size)
        {
            if (parameterName != null)
            {
                this.parameterName = parameterName.Trim();
            }
            this.mysqlType = dbType;
            this.size = size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        public MySqlDBParameter(string parameterName, MySqlDbType dbType, int size, object value)
        {
            if (parameterName != null)
            {
                this.parameterName = parameterName.Trim();
            }
            this.mysqlType = dbType;
            this.size = size;
            this.parameterValue = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public MySqlDbType DBType
        {
            get
            {
                return mysqlType;
            }
            set
            {
                this.mysqlType = value;
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
            MySqlDBParameter p = (MySqlDBParameter)obj;
            return ((this.mysqlType == p.mysqlType) && (string.Compare(this.parameterName, p.parameterName, true, System.Globalization.CultureInfo.CurrentCulture) == 0) && (this.parameterValue.GetHashCode() == p.parameterValue.GetHashCode()) && (this.size == p.size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.mysqlType.GetHashCode() ^ this.parameterName.GetHashCode() ^ this.size.GetHashCode() ^ this.parameterValue.GetHashCode();
        }
    }
}
