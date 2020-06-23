using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 用于存储字典数据
    /// </summary>
    public class EntityData
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        //public string Key { get; set; }

        //public string Data { get; set; }
        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
