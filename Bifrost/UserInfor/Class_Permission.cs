using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// �˵���ťȨ��
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Permission
    {
        /// <summary>
        /// Ȩ�ޱ�PERMISSION
        /// </summary>
        private string id;
     
        private string perm_code;
  
        private string perm_name;
    
        private string perm_kind;

        private string num;

        private Class_Permission_Info permission_info; 
    
        /// <summary>
        /// Ȩ��ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Ȩ����
        /// </summary>
        public string Perm_code
        {
            get { return perm_code; }
            set { perm_code = value; }
        }
        /// <summary>
        /// Ȩ������
        /// </summary>
        public string Perm_name
        {
            get { return perm_name; }
            set { perm_name = value; }
        }
        /// <summary>
        /// Ȩ�����ࣺ1-�˵� 2-��ť
        /// </summary>
        public string Perm_kind
        {
            get { return perm_kind; }
            set { perm_kind = value; }
        }

        /// <summary>
        /// �˵������õ����
        /// </summary>
        public string Num
        {
            get { return num; }
            set { num = value; }
        }

        /// <summary>
        /// Ȩ�޵���ϸ��Ϣ
        /// </summary>
        public Class_Permission_Info Permission_Info
        {
            set { permission_info = value; }
            get { return permission_info; }
        }
    }
}
