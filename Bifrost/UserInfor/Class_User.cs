using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Bifrost
{
    /// <summary>
    /// �û���Ϣ��USER
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_User
    {
        private string user_id;

        private string user_num;

        private string user_name;

        private string u_gender_code;

        private DateTime birth_date;

        private string u_tech_post;

        private string u_tech_post_name;

        private string u_seniority;

        private DateTime in_time;

        private string u_position;

        private string u_position_name;

        private string u_recipe_power;

        private string section_id;

        private string sickarea_id;

        private string phone;

        private string mobile_phone;

        private string email;

        private string enable_flag;

        private string profession_card;

        private string prof_card_name;

        private DateTime pass_time;

        private DateTime receive_time;

        private DateTime register_time;

        private Class_Sections section;

        private string accounttype;

        private string guid_doctor_id;

        private string guid_doctor_name;




        /// <summary>
        /// �û����
        /// </summary>
        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public string User_num
        {
            get { return user_num; }
            set { user_num = value; }
        }

        [Description("�û�����")]
        /// <summary>
        /// �û�����
        /// </summary>
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        /// <summary>
        ///�û��Ա�
        /// </summary>
        public string U_gender_code
        {
            get { return u_gender_code; }
            set { u_gender_code = value; }
        }
        /// <summary>
        /// �û���������
        /// </summary>
        public DateTime Birth_date
        {
            get { return birth_date; }
            set { birth_date = value; }
        }

        [Description("ְ��")]
        /// <summary>
        /// ְ��
        /// </summary>
        public string U_tech_post
        {
            get { return u_tech_post; }
            set { u_tech_post = value; }
        }

        [Description("ְ������")]
        /// <summary>
        /// ְ������
        /// </summary>
        public string U_tech_post_name
        {
            get { return u_tech_post_name; }
            set { u_tech_post_name = value; }
        }

        /// <summary>
        /// ���ʣ�1-�� 2-��
        /// </summary>
        public string U_seniority
        {
            get { return u_seniority; }
            set { u_seniority = value; }
        }
        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public DateTime In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }

        [Description("ְ��")]
        /// <summary>
        /// ְ��
        /// </summary>
        public string U_position
        {
            get { return u_position; }
            set { u_position = value; }
        }

        [Description("ְ������")]
        /// <summary>
        ///ְ������ 
        /// </summary>
        public string U_position_name
        {
            get { return u_position_name; }
            set { u_position_name = value; }
        }

        /// <summary>
        /// ����Ȩ��1-��ͨ����Ȩ  2-�鶾ҩ�ﴦ��Ȩ
        /// </summary>
        public string U_recipe_power
        {
            get { return u_recipe_power; }
            set { u_recipe_power = value; }
        }
        /// <summary>
        /// ��������ID
        /// </summary>
        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }
        /// <summary>
        /// ��������ID
        /// </summary>
        public string Sickarea_id
        {
            get { return sickarea_id; }
            set { sickarea_id = value; }
        }
        /// <summary>
        /// �绰
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string Mobile_phone
        {
            get { return mobile_phone; }
            set { mobile_phone = value; }
        }
        /// <summary>
        /// �ʼ���ַ
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        /// <summary>
        /// ��Ч��־��Y-��Ч  N-��Ч
        /// </summary>
        public string Enable_flag
        {
            get { return enable_flag; }
            set { enable_flag = value; }
        }
        /// <summary>
        /// ְҵ�ʸ�֤
        /// </summary>
        public string Profession_card
        {
            get { return profession_card; }
            set { profession_card = value; }
        }

        /// <summary>
        /// �ʸ�֤������
        /// </summary>
        public string Prof_card_name
        {
            get { return prof_card_name; }
            set { prof_card_name = value; }
        }
        /// <summary>
        /// ͨ��ʱ��
        /// </summary>
        public DateTime Pass_time
        {
            get { return pass_time; }
            set { pass_time = value; }
        }
        /// <summary>
        /// ��֤ʱ��
        /// </summary>
        public DateTime Receive_time
        {
            get { return receive_time; }
            set { receive_time = value; }
        }
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime Register_time
        {
            get { return register_time; }
            set { register_time = value; }
        }

        /// <summary>
        /// �û���������
        /// </summary>
        public Class_Sections Section
        {
            get { return section; }
            set { section = value; }
        }

        /// <summary>
        /// �ʺ�����
        /// </summary>
        public string Accounttype
        {
            get { return accounttype; }
            set { accounttype = value; }
        }


        /// <summary>
        /// ����ҽ��id
        /// </summary>
        public string Guid_doctor_id
        {
            get { return guid_doctor_id; }
            set { guid_doctor_id = value; }
        }

        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string Guid_doctor_name
        {
            get { return guid_doctor_name; }
            set { guid_doctor_name = value; }
        }
    }
}
