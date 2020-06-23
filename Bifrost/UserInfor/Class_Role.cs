using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Bifrost
{
    /// <summary>
    /// ��ɫ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Role
    {
        private string role_id;
        private string role_name;
        private string enable;
        private string sickarea_id;
        private string sickarea_name;
        private string section_id;
        private string section_name;
        private string role_type;
        private string sub_hospital;
        private Class_Permission[] permissions;
        private Class_Rnage[] rnages;
        private Class_Rnage canselectrange;
        private Class_Text[] texts;

        /// <summary>
        /// ��ɫID
        /// </summary>
        public string Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }

        [Description("��ɫ����")]
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string Role_name
        {
            get { return role_name; }
            set { role_name = value; }
        }

        /// <summary>
        /// ��Ч��־��Y-��Ч N-��Ч
        /// </summary>
        public string Enable
        {
            get { return enable; }
            set { enable = value; }
        }
        [Description("����Id")]
        /// <summary>
        /// ��������
        /// </summary>
        public string Sickarea_Id
        {
            get { return sickarea_id; }
            set { sickarea_id = value; }
        }

        [Description("��������")]
        /// <summary>
        /// ��������
        /// </summary>
        public string Sickarea_name
        {
            get { return sickarea_name; }
            set { sickarea_name = value; }
        }

        [Description("����Id")]
        /// <summary>
        /// ��������
        /// </summary>
        public string Section_Id
        {
            get { return section_id; }
            set { section_id = value; }
        }

        /// <summary>
        /// ��Ժ
        /// </summary>
        public string Sub_hospital
        {
            get { return sub_hospital; }
            set { sub_hospital = value; }
        }

        [Description("��������")]
        /// <summary>
        /// ��������
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }

        [Description("��ɫ����")]
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string Role_type
        {
            get { return role_type; }
            set { role_type = value; }
        }

        /// <summary>
        /// ��ɫ����Ӧ��Ȩ�޲˵���ť
        /// </summary>
        public Class_Permission[] Permissions
        {
            get { return permissions; }
            set { permissions = value; }
        }

        /// <summary>
        /// Ȩ��ʹ�÷�Χ����
        /// </summary>
        public Class_Rnage[] Rnages
        {
            get { return rnages; }
            set { rnages = value; }
        }

        /// <summary>
        /// ��ѡ��Χ��ֵ
        /// </summary>
        public Class_Rnage CanSelectRange
        {
            get { return canselectrange; }
            set { canselectrange = value; }
        }
        // private Class_Text texts;
        public Class_Text[] Texts
        {
            get { return texts; }
            set { texts = value; }
        }

    }
}
