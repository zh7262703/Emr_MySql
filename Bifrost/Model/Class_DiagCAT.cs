using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// ���Ŀ¼������Ϣ��
    /// </summary>
    public class Class_DiagCAT
    {
        private int id;
     
        private string name;
      
        private int parent_id;
    
        private string is_sign;
        /// <summary>
        /// ���ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// �ϼ�Ŀ¼ID
        /// </summary>
        public int Parent_id
        {
            get { return parent_id; }
            set { parent_id = value; }
        }
        /// <summary>
        /// �Ƿ��ӽڵ�
        /// </summary>
        public string Is_sign
        {
            get { return is_sign; }
            set { is_sign = value; }
        }
    }
}
