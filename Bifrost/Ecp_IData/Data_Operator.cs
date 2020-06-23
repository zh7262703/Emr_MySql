using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost.Ecp_IData
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    public class Data_Operator
    {
        public static IDataSource idatasource = null;
        private static Data_Operator data_Operator = null;
        public static void CreateData(IDataSource idatas)
        {
            idatasource = idatas;
        }
        private Data_Operator()
        { 
        
        }
        public static Data_Operator GetInstance()
        {
            if(data_Operator==null)
            {
                data_Operator =new Data_Operator();
            }
            return data_Operator;
        }
    }
}
