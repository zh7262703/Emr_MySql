using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// �����ְ��ְ��
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Doc_Job
    {
        private int id;
        private int texttype;
        private int textcontrol;
        private string flag;
        private int jobtitle;
        private int type;

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
        /// �������
        /// </summary>
        public int Textcontrol
        {
            get { return textcontrol; }
            set { textcontrol = value; }
        }       

        /// <summary>
        /// ��Ƿ���
        /// </summary>
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }        

        /// <summary>
        /// ����ְ���ְ������
        /// </summary>
        public int Jobtitle
        {
            get { return jobtitle; }
            set { jobtitle = value; }
        }       

        /// <summary>
        /// ְ���ְ������
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
 