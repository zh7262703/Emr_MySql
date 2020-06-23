using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class T_MACROS_ELEMENTS
    {
        public int Id { get; set; }

        /// <summary>
        /// 宏元素名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 类型 1：当前患者信息 2：当前用户信息 3：当前角色信息 4：当前时间 5：当前患者诊断信息 6:当前患者体征信息 7：当前患者其他体征信息
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string Default_Value { get; set; }

        /// <summary>
        /// 对应对象的列名 用于患者基本信息与宏的对应关系
        /// </summary>
        public string ColName { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 1 可用 0 不可用
        /// </summary>
        public string Enable { get; set; }

        /// <summary>
        /// 是否只在元素值为空时执行 0：否 1：是
        /// </summary>
        public string OnlyOnNull { get; set; }

        /// <summary>
        /// 取分割后的不为空的第几个
        /// </summary>
        public int Select_Index { get; set; }

        /// <summary>
        /// 将取到的值按字符串分割
        /// </summary>
        public string Split { get; set; }

        /// <summary>
        /// 名称与元素之前的连接字符串
        /// </summary>
        public string Join { get; set; }
    }
}
