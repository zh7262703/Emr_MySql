using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 菜单详细信息设置
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Permission_Info
    {
        private int id;

        private string perm_code; 

        private string dllname;

        private byte[] dll;

        private string function;

        private byte[] functionImage;

        private string version;

        private string ismainfrom;
       

        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 权限的代码
        /// </summary>
        public string Perm_code
        {
            get { return perm_code; }
            set { perm_code = value; }
        }

        /// <summary>
        /// 动态类库的名称
        /// </summary>
        public string DllName
        {
            get { return dllname; }
            set { dllname = value; }
        }

        /// <summary>
        /// 动态类库
        /// </summary>
        public byte[] Dll
        {
            get { return dll; }
            set { dll = value; }
        }

        /// <summary>
        /// 功能函数名称
        /// </summary>
        public string Function
        {
            set { function = value;}
            get { return function;}
        }

        /// <summary>
        /// 图标
        /// </summary>
        public byte[] FunctionImage
        {
            set { functionImage = value; }
            get { return functionImage; }
        }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version
        {
            set { version = value; }
            get { return version; }
        }

        /// <summary>
        /// 是否是主界面 0是 1否
        /// </summary>
        public string Ismainfrom
        {
            get { return ismainfrom; }
            set { ismainfrom = value; }
        }
    }
}
