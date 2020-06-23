using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 菜单或按钮权限
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Permission
    {
        /// <summary>
        /// 权限表PERMISSION
        /// </summary>
        private string id;
     
        private string perm_code;
  
        private string perm_name;
    
        private string perm_kind;

        private string num;

        private Class_Permission_Info permission_info; 
    
        /// <summary>
        /// 权限ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 权限码
        /// </summary>
        public string Perm_code
        {
            get { return perm_code; }
            set { perm_code = value; }
        }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Perm_name
        {
            get { return perm_name; }
            set { perm_name = value; }
        }
        /// <summary>
        /// 权限种类：1-菜单 2-按钮
        /// </summary>
        public string Perm_kind
        {
            get { return perm_kind; }
            set { perm_kind = value; }
        }

        /// <summary>
        /// 菜单排序用的序号
        /// </summary>
        public string Num
        {
            get { return num; }
            set { num = value; }
        }

        /// <summary>
        /// 权限的详细信息
        /// </summary>
        public Class_Permission_Info Permission_Info
        {
            set { permission_info = value; }
            get { return permission_info; }
        }
    }
}
