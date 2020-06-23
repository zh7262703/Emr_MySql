using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class Class_Follow_State
    {
        private string id;
        /// <summary>
        /// Id号
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string des;
        /// <summary>
        /// 状态描述
        /// </summary>
        public string Des
        {
            get { return des; }
            set { des = value; }
        }
        private string isfinished;
        /// <summary>
        /// 是否表示随访完成
        /// </summary>
        public string Isfinished
        {
            get { return isfinished; }
            set { isfinished = value; }
        }
    }
}
