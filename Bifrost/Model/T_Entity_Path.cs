using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 病种临床路径实体类
    /// </summary>
    public class T_Entity_Path
    {
        private int id;
        private string path_code;
        private string path_name;
        private string entity_name;
        private string normal_inpatient_days;

        /// <summary>
        /// 编号，自增列
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        /// <summary>
        /// 路径代码
        /// </summary>
        public string Path_code
        {
            get { return path_code; }
            set { path_code = value; }
        }
        
        /// <summary>
        /// 路径名称
        /// </summary>
        public string Path_name
        {
            get { return path_name; }
            set { path_name = value; }
        }
        
        /// <summary>
        /// 病种名称
        /// </summary>
        public string Entity_name
        {
            get { return entity_name; }
            set { entity_name = value; }
        }
       
        /// <summary>
        /// 标准住院天数
        /// </summary>
        public string Normal_inpatient_days
        {
            get { return normal_inpatient_days; }
            set { normal_inpatient_days = value; }
        }
    }
}
