using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   public class Class_TngAccount
    {
        /// <summary>
        /// ���ƻ��������ʻ��Ĺ�ϵ
        /// </summary>
        private int id;
      
        private int tng_id;
      
        private int account_id;
        /// <summary>
        /// ���
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// ���ƻ�������
        /// </summary>
        public int Tng_id
        {
            get { return tng_id; }
            set { tng_id = value; }
        }
        /// <summary>
        /// �ʻ����
        /// </summary>
        public int Account_id
        {
            get { return account_id; }
            set { account_id = value; }
        }
    }
}
