using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   public class Class_TngAccount
    {
        /// <summary>
        /// 诊疗护理组与帐户的关系
        /// </summary>
        private int id;
      
        private int tng_id;
      
        private int account_id;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 诊疗护理组编号
        /// </summary>
        public int Tng_id
        {
            get { return tng_id; }
            set { tng_id = value; }
        }
        /// <summary>
        /// 帐户编号
        /// </summary>
        public int Account_id
        {
            get { return account_id; }
            set { account_id = value; }
        }
    }
}
