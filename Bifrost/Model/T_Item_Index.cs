using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class T_Item_Index
    {
        private int id;

        /// <summary>
        /// ָ��ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string index_code;

        /// <summary>
        /// ָ�����
        /// </summary>
        public string Index_code
        {
            get { return index_code; }
            set { index_code = value; }
        }
        private string index_name;

        /// <summary>
        /// ָ������
        /// </summary>
        public string Index_name
        {
            get { return index_name; }
            set { index_name = value; }
        }
        private string index_state;

        /// <summary>
        /// ָ��״̬
        /// </summary>
        public string Index_state
        {
            get { return index_state; }
            set { index_state = value; }
        }
    }
}
