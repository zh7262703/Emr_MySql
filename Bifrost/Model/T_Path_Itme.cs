using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class T_Path_Itme
    {
        private int id;
        private string item_code;
        private string item_name;
        private string item_state;

        /// <summary>
        /// ������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
       
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }
       
        /// <summary>
        /// ��Ŀ״̬
        /// </summary>
        public string Item_state
        {
            get { return item_state; }
            set { item_state = value; }
        }
    }
}
