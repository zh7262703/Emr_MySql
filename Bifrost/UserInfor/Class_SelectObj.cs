using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bifrost
{   
    /// <summary>
    /// ���ڻ�ȡ�����ѯ��ֵ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_SelectObj
    {
        private string select_name;
        private string select_val;
        private DataRow select_row;

        /// <summary>
        /// ����
        /// </summary>
        public string Select_Name
        {
            get { return select_name; }
            set { select_name = value; }
        }

        /// <summary>
        /// ֵ
        /// </summary>
        public string Select_Val
        {
            get { return select_val; }
            set { select_val = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DataRow Select_Row
        {
            get { return select_row; }
            set { select_row = value; }
        }
    }
}
