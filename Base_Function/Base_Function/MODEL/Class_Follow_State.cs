using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class Class_Follow_State
    {
        private string id;
        /// <summary>
        /// Id��
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string des;
        /// <summary>
        /// ״̬����
        /// </summary>
        public string Des
        {
            get { return des; }
            set { des = value; }
        }
        private string isfinished;
        /// <summary>
        /// �Ƿ��ʾ������
        /// </summary>
        public string Isfinished
        {
            get { return isfinished; }
            set { isfinished = value; }
        }
    }
}
