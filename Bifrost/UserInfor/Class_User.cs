using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Bifrost
{
    /// <summary>
    /// 用户信息表USER
    /// 创建者：张华
    /// 创建时间：2010-6-15
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
        /// 用户编号
        /// </summary>
        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        /// <summary>
        /// 用户工号
        /// </summary>
        public string User_num
        {
            get { return user_num; }
            set { user_num = value; }
        }

        [Description("用户姓名")]
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        /// <summary>
        ///用户性别
        /// </summary>
        public string U_gender_code
        {
            get { return u_gender_code; }
            set { u_gender_code = value; }
        }
        /// <summary>
        /// 用户出生年月
        /// </summary>
        public DateTime Birth_date
        {
            get { return birth_date; }
            set { birth_date = value; }
        }

        [Description("职称")]
        /// <summary>
        /// 职称
        /// </summary>
        public string U_tech_post
        {
            get { return u_tech_post; }
            set { u_tech_post = value; }
        }

        [Description("职称名称")]
        /// <summary>
        /// 职称名称
        /// </summary>
        public string U_tech_post_name
        {
            get { return u_tech_post_name; }
            set { u_tech_post_name = value; }
        }

        /// <summary>
        /// 年资：1-高 2-低
        /// </summary>
        public string U_seniority
        {
            get { return u_seniority; }
            set { u_seniority = value; }
        }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }

        [Description("职务")]
        /// <summary>
        /// 职务
        /// </summary>
        public string U_position
        {
            get { return u_position; }
            set { u_position = value; }
        }

        [Description("职务名称")]
        /// <summary>
        ///职务名称 
        /// </summary>
        public string U_position_name
        {
            get { return u_position_name; }
            set { u_position_name = value; }
        }

        /// <summary>
        /// 处方权：1-普通处方权  2-麻毒药物处方权
        /// </summary>
        public string U_recipe_power
        {
            get { return u_recipe_power; }
            set { u_recipe_power = value; }
        }
        /// <summary>
        /// 所属科室ID
        /// </summary>
        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }
        /// <summary>
        /// 所属病区ID
        /// </summary>
        public string Sickarea_id
        {
            get { return sickarea_id; }
            set { sickarea_id = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile_phone
        {
            get { return mobile_phone; }
            set { mobile_phone = value; }
        }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        /// <summary>
        /// 有效标志：Y-有效  N-无效
        /// </summary>
        public string Enable_flag
        {
            get { return enable_flag; }
            set { enable_flag = value; }
        }
        /// <summary>
        /// 职业资格证
        /// </summary>
        public string Profession_card
        {
            get { return profession_card; }
            set { profession_card = value; }
        }

        /// <summary>
        /// 资格证书名称
        /// </summary>
        public string Prof_card_name
        {
            get { return prof_card_name; }
            set { prof_card_name = value; }
        }
        /// <summary>
        /// 通过时间
        /// </summary>
        public DateTime Pass_time
        {
            get { return pass_time; }
            set { pass_time = value; }
        }
        /// <summary>
        /// 领证时间
        /// </summary>
        public DateTime Receive_time
        {
            get { return receive_time; }
            set { receive_time = value; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime Register_time
        {
            get { return register_time; }
            set { register_time = value; }
        }

        /// <summary>
        /// 用户所属科室
        /// </summary>
        public Class_Sections Section
        {
            get { return section; }
            set { section = value; }
        }

        /// <summary>
        /// 帐号性质
        /// </summary>
        public string Accounttype
        {
            get { return accounttype; }
            set { accounttype = value; }
        }


        /// <summary>
        /// 带教医生id
        /// </summary>
        public string Guid_doctor_id
        {
            get { return guid_doctor_id; }
            set { guid_doctor_id = value; }
        }

        /// <summary>
        /// 带教医生名字
        /// </summary>
        public string Guid_doctor_name
        {
            get { return guid_doctor_name; }
            set { guid_doctor_name = value; }
        }
    }
}
