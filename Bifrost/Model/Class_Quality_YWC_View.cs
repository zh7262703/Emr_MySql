using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class Class_Quality_YWC_View
    {
        private int id;

        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string document_Type;

        /// <summary>
        /// 文书类型
        /// </summary>
        public string Document_Type
        {
            get { return document_Type; }
            set { document_Type = value; }
        }
        private string inpatient_Type;

        /// <summary>
        /// 病人类型
        /// </summary>
        public string Inpatient_Type
        {
            get { return inpatient_Type; }
            set { inpatient_Type = value; }
        }
        private string base_Time;

        /// <summary>
        /// 参考时间
        /// </summary>
        public string Base_Time
        {
            get { return base_Time; }
            set { base_Time = value; }
        }
        private string true_time;

        /// <summary>
        /// 偏移时间
        /// </summary>
        public string True_time
        {
            get { return true_time; }
            set { true_time = value; }
        }
        private string runcycle;

        /// <summary>
        /// 执行周期
        /// </summary>
        public string Runcycle
        {
            get { return runcycle; }
            set { runcycle = value; }
        }
        private int excetimes;

        /// <summary>
        /// 执行总次数
        /// </summary>
        public int Excetimes
        {
            get { return excetimes; }
            set { excetimes = value; }
        }
        private string isprealert;

        /// <summary>
        /// 是否警告
        /// </summary>
        public string Isprealert
        {
            get { return isprealert; }
            set { isprealert = value; }
        }
        private string prealerttime;

        /// <summary>
        /// 警告时间
        /// </summary>
        public string Prealerttime
        {
            get { return prealerttime; }
            set { prealerttime = value; }
        }

        private string is_Take_grade;

        /// <summary>
        /// 是否扣分
        /// </summary>
        public string Is_Take_grade
        {
            get { return is_Take_grade; }
            set { is_Take_grade = value; }
        }

        private double take_Grade;

        /// <summary>
        /// 扣分值
        /// </summary>
        public double Take_Grade
        {
            get { return take_Grade; }
            set { take_Grade = value; }
        }

        private string is_Notice;

        /// <summary>
        /// 是否提醒
        /// </summary>
        public string Is_Notice
        {
            get { return is_Notice; }
            set { is_Notice = value; }
        }

        private string effect_section;

        /// <summary>
        /// 起效科室
        /// </summary>
        public string Effect_section
        {
            get { return effect_section; }
            set { effect_section = value; }
        }
        private string threadState;

        /// <summary>
        /// 线程状态
        /// </summary>
        public string ThreadState
        {
            get { return threadState; }
            set { threadState = value; }
        }
    }
}
