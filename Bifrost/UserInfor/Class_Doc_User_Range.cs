using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// �����ʹ�÷�Χ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Doc_User_Range
    {
        private int id;
        private int texttype; 
        private int belonghospital;
        private int section;
        private int workgroup;

        /// <summary>
        /// ����
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        /// <summary>
        /// ��������
        /// </summary>
        public int Texttype
        {
            get { return texttype; }
            set { texttype = value; }
        }
       
        /// <summary>
        /// ��Ժ
        /// </summary>
        public int Belonghospital
        {
            get { return belonghospital; }
            set { belonghospital = value; }
        }
        
        /// <summary>
        /// ����
        /// </summary>
        public int Section
        {
            get { return section; }
            set { section = value; }
        }
       
        /// <summary>
        /// ����
        /// </summary>
        public int Workgroup
        {
            get { return workgroup; }
            set { workgroup = value; }
        }
    }
}
