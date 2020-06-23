using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 帐号权限使用范围
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Rnage
    {
        
        private string id;
        private string rnagename;
        private string acc_role_id;
        private string section_id;
        private string sickarea_id;
        private string shid;     
        private string isbelonge;

        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

       
       
        /// <summary>
        /// 范围名称
        /// </summary>
        public string Rnagename
        {
            get { return rnagename; }
            set { rnagename = value; }
        }


        
        
        /// <summary>
        /// 帐号权限关系ID
        /// </summary>
        public string Acc_role_id
        {
            get { return acc_role_id; }
            set { acc_role_id = value; }
        }

        /// <summary>
        /// 科室ID
        /// </summary>        
        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }

        /// <summary>
        /// 病区ID
        /// </summary>       
        public string Sickarea_id
        {
            get { return sickarea_id; }
            set { sickarea_id = value; }
        }

        /// <summary>
        /// 分院ID
        /// </summary>
        public string Shid
        {
            get { return shid; }
            set { shid = value; }
        }

        /// <summary>
        /// 科室或病区 0科室 1病区
        /// </summary>        
        public string Isbelonge
        {
            get { return isbelonge; }
            set { isbelonge = value; }
        }
    }
}
