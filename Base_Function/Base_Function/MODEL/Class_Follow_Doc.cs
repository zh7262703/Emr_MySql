using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    class Class_Follow_Doc
    {
        private string id;
        /// <summary>
        /// ����
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string record_id;
        /// <summary>
        /// ��¼��
        /// </summary>
        public string Record_id
        {
            get { return record_id; }
            set { record_id = value; }
        }
        private string doc_name;
        /// <summary>
        /// ������
        /// </summary>
        public string Doc_name
        {
            get { return doc_name; }
            set { doc_name = value; }
        }
        private string text_type;
        /// <summary>
        /// �������ͺ�
        /// </summary>
        public string Text_type
        {
            get { return text_type; }
            set { text_type = value; }
        }
        private string doc_content;
        /// <summary>
        /// ��������
        /// </summary>
        public string Doc_content
        {
            get { return doc_content; }
            set { doc_content = value; }
        }
        private string issimpleinstance;
        /// <summary>
        /// �Ƿ�Ϊ��������0Ϊ������1Ϊ����
        /// </summary>
        public string Issimpleinstance
        {
            get { return issimpleinstance; }
            set { issimpleinstance = value; }
        }
        private string text_name;
        /// <summary>
        /// ����������
        /// </summary>
        public string Text_name
        {
            get { return text_name; }
            set { text_name = value; }
        }
        private string creator_id;

        public string Creator_id
        {
            get { return creator_id; }
            set { creator_id = value; }
        }

    }
}
