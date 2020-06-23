using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Bifrost
{
    /// <summary>
    /// 角色
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Role
    {
        private string role_id;
        private string role_name;
        private string enable;
        private string sickarea_id;
        private string sickarea_name;
        private string section_id;
        private string section_name;
        private string role_type;
        private string sub_hospital;
        private Class_Permission[] permissions;
        private Class_Rnage[] rnages;
        private Class_Rnage canselectrange;
        private Class_Text[] texts;

        /// <summary>
        /// 角色ID
        /// </summary>
        public string Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }

        [Description("角色名称")]
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Role_name
        {
            get { return role_name; }
            set { role_name = value; }
        }

        /// <summary>
        /// 有效标志：Y-有效 N-无效
        /// </summary>
        public string Enable
        {
            get { return enable; }
            set { enable = value; }
        }
        [Description("病区Id")]
        /// <summary>
        /// 所属病区
        /// </summary>
        public string Sickarea_Id
        {
            get { return sickarea_id; }
            set { sickarea_id = value; }
        }

        [Description("病区名称")]
        /// <summary>
        /// 病区名称
        /// </summary>
        public string Sickarea_name
        {
            get { return sickarea_name; }
            set { sickarea_name = value; }
        }

        [Description("科室Id")]
        /// <summary>
        /// 所属科室
        /// </summary>
        public string Section_Id
        {
            get { return section_id; }
            set { section_id = value; }
        }

        /// <summary>
        /// 分院
        /// </summary>
        public string Sub_hospital
        {
            get { return sub_hospital; }
            set { sub_hospital = value; }
        }

        [Description("科室名称")]
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }

        [Description("角色类型")]
        /// <summary>
        /// 角色类型
        /// </summary>
        public string Role_type
        {
            get { return role_type; }
            set { role_type = value; }
        }

        /// <summary>
        /// 角色所对应的权限菜单按钮
        /// </summary>
        public Class_Permission[] Permissions
        {
            get { return permissions; }
            set { permissions = value; }
        }

        /// <summary>
        /// 权限使用范围集合
        /// </summary>
        public Class_Rnage[] Rnages
        {
            get { return rnages; }
            set { rnages = value; }
        }

        /// <summary>
        /// 能选择范围的值
        /// </summary>
        public Class_Rnage CanSelectRange
        {
            get { return canselectrange; }
            set { canselectrange = value; }
        }
        // private Class_Text texts;
        public Class_Text[] Texts
        {
            get { return texts; }
            set { texts = value; }
        }

    }
}
