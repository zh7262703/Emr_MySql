using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// ��Ժ��Ϣ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Sub_Hospital
    {
        private string id;       
        private string sub_code;       
        private string sub_name;

        /// <summary>
        /// ����
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Sub_code
        {
            get { return sub_code; }
            set { sub_code = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Sub_name
        {
            get { return sub_name; }
            set { sub_name = value; }
        }

        
    }
}
