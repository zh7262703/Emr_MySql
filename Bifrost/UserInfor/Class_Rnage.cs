using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// �ʺ�Ȩ��ʹ�÷�Χ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Rnage
    {
        
        private string id;
        private string rnagename;
        private string acc_role_id;
        private string section_id;
        private string sickarea_id;
        private string shid;     
        private string isbelonge;

        /// <summary>
        /// ����
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

       
       
        /// <summary>
        /// ��Χ����
        /// </summary>
        public string Rnagename
        {
            get { return rnagename; }
            set { rnagename = value; }
        }


        
        
        /// <summary>
        /// �ʺ�Ȩ�޹�ϵID
        /// </summary>
        public string Acc_role_id
        {
            get { return acc_role_id; }
            set { acc_role_id = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>        
        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>       
        public string Sickarea_id
        {
            get { return sickarea_id; }
            set { sickarea_id = value; }
        }

        /// <summary>
        /// ��ԺID
        /// </summary>
        public string Shid
        {
            get { return shid; }
            set { shid = value; }
        }

        /// <summary>
        /// ���һ��� 0���� 1����
        /// </summary>        
        public string Isbelonge
        {
            get { return isbelonge; }
            set { isbelonge = value; }
        }
    }
}
