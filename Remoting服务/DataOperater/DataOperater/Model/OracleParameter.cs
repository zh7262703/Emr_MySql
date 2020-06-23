using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace DataOperater.Model
{
    [Serializable]
    public class OrclParameter
    {
        private OracleType oracleType;//参数类型          
        private string parameterName;//参数名          
        private int size;//参数大小          
        private object parameterValue;//参数值
        private ParameterDirection direction;  //类型描述


        /// <summary>
        /// 
        /// </summary>  
        public OrclParameter()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public OrclParameter(string parameterName, OracleType dbType, int size)
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
        public OrclParameter(string parameterName, OracleType dbType, int size, object value)
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
            OrclParameter p = (OrclParameter)obj;
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
