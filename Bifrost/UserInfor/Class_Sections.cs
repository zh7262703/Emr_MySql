using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{  
    /// <summary>
    /// ������Ϣ��SECTION
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Sections
    {

        private string section_code;
        private string section_name;
        private string belongto_section_id;
        private string ischecksection;
        private string belongto_section_name;
        private string belongto_bigsection_id;
        private string isbelongtobigsection;
        private string type;
        private string inout_flag;
        private string manage_type;
        private string state;
        private string belongto_hospital;
        private int sid;

        /// <summary>
        /// ����ID
        /// </summary>
        public int Sid
        {
            get { return sid; }
            set { sid = value; }
        }


        /// <summary>
        /// ���Ҵ���
        /// </summary>
        public string Section_Code
        {
            get { return section_code; }
            set { section_code = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Section_Name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// ��������Ƶ�ID
        /// </summary>
        public string Belongto_Section_Id
        {
            get { return belongto_section_id; }
            set { belongto_section_id = value; }
        }
        /// <summary>
        /// �Ƿ���ƣ�Y��
        /// </summary>
        public string isCheckSection
        {
            get { return ischecksection; }
            set { ischecksection = value; }
        }
        /// <summary>
        /// ��������Ƶ�����
        /// </summary>
        public string Belongto_Section_Name
        {
            get { return belongto_section_name; }
            set { belongto_section_name = value; }
        }
        /// <summary>
        /// �������ID
        /// </summary>
        public string Belongto_BigSection_ID
        {
            get { return belongto_bigsection_id; }
            set { belongto_bigsection_id = value; }
        }
        /// <summary>
        /// �Ƿ��Ǵ�ƣ�Y��
        /// </summary>
        public string isBelongToBigSection
        {
            get { return isbelongtobigsection; }
            set { isbelongtobigsection = value; }
        }
        /// <summary>
        /// ���1-���� 2-��� 3-��ͨ
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// סԺ�������־��I-סԺ O-����
        /// </summary>
        public string Inout_flag
        {
            get { return inout_flag; }
            set { inout_flag = value; }
        }
        /// <summary>
        /// ���ҹ������ԣ�1-�ٴ� 2-ҩ�� 3-���� 4-���� 5-ҽ�� 6-���� 7-��ѧ
        /// </summary>
        public string Manage_type
        {
            get { return manage_type; }
            set { manage_type = value; }
        }
        /// <summary>
        /// ��Ч��־��Y-��Ч  N-��Ч 
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// ������Ժ
        /// </summary>
        public string Belongto_hospital
        {
            get { return belongto_hospital; }
            set { belongto_hospital = value; }
        }
    }
}
