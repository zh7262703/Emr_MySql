using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// ���������Ȩ��
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Doc_OtherRights
    {
        private int id;
        private int texttype;
        private int textcontrol;
        private string other_name;

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
        /// ���������ť
        /// </summary>
        public int Textcontrol
        {
            get { return textcontrol; }
            set { textcontrol = value; }
        }
       
        /// <summary>
        /// ����Ȩ������
        /// </summary>
        public string Other_name
        {
            get { return other_name; }
            set { other_name = value; }
        }
    }
}
