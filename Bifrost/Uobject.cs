using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 通用对象类型
    /// </summary>
    public class Uobject
    {
        /// <summary>
        ///主键
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
    }
}
