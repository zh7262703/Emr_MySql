using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// �����ٴ�·��ʵ����
    /// </summary>
    public class T_Entity_Path
    {
        private int id;
        private string path_code;
        private string path_name;
        private string entity_name;
        private string normal_inpatient_days;

        /// <summary>
        /// ��ţ�������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        /// <summary>
        /// ·������
        /// </summary>
        public string Path_code
        {
            get { return path_code; }
            set { path_code = value; }
        }
        
        /// <summary>
        /// ·������
        /// </summary>
        public string Path_name
        {
            get { return path_name; }
            set { path_name = value; }
        }
        
        /// <summary>
        /// ��������
        /// </summary>
        public string Entity_name
        {
            get { return entity_name; }
            set { entity_name = value; }
        }
       
        /// <summary>
        /// ��׼סԺ����
        /// </summary>
        public string Normal_inpatient_days
        {
            get { return normal_inpatient_days; }
            set { normal_inpatient_days = value; }
        }
    }
}
