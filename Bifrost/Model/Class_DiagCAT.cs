using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 诊断目录定义信息表
    /// </summary>
    public class Class_DiagCAT
    {
        private int id;
     
        private string name;
      
        private int parent_id;
    
        private string is_sign;
        /// <summary>
        /// 诊断ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 上级目录ID
        /// </summary>
        public int Parent_id
        {
            get { return parent_id; }
            set { parent_id = value; }
        }
        /// <summary>
        /// 是否子节点
        /// </summary>
        public string Is_sign
        {
            get { return is_sign; }
            set { is_sign = value; }
        }
    }
}
