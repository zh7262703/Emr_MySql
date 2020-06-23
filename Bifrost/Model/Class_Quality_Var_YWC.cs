using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class Class_Quality_Var_YWC
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int document_type;

        /// <summary>
        /// 文书类型
        /// </summary>
        public int Document_type
        {
            get { return document_type; }
            set { document_type = value; }
        }
        private int inpatient_type;

        /// <summary>
        /// 患者类型
        /// </summary>
        public int Inpatient_type
        {
            get { return inpatient_type; }
            set { inpatient_type = value; }
        }
        private int base_time;

        /// <summary>
        /// 参考时间
        /// </summary>
        public int Base_time
        {
            get { return base_time; }
            set { base_time = value; }
        }
        private int true_time;

        /// <summary>
        /// 偏移时间
        /// </summary>
        public int True_time
        {
            get { return true_time; }
            set { true_time = value; }
        }
        private string truetime_unit;

        /// <summary>
        /// 偏移时间单位
        /// </summary>
        public string Truetime_unit
        {
            get { return truetime_unit; }
            set { truetime_unit = value; }
        }
        private int runcycle;

        /// <summary>
        /// 执行周期
        /// </summary>
        public int Runcycle
        {
            get { return runcycle; }
            set { runcycle = value; }
        }
        private string runcycleunit;

        /// <summary>
        /// 执行周期单位
        /// </summary>
        public string Runcycleunit
        {
            get { return runcycleunit; }
            set { runcycleunit = value; }
        }
        private char isprealert;

        /// <summary>
        /// 是否预警
        /// </summary>
        public char Isprealert
        {
            get { return isprealert; }
            set { isprealert = value; }
        }
        private int prealerttime;

        /// <summary>
        /// 报警时间
        /// </summary>
        public int Prealerttime
        {
            get { return prealerttime; }
            set { prealerttime = value; }
        }
        private string pretimeunit;

        /// <summary>
        /// 报警时间单位
        /// </summary>
        public string Pretimeunit
        {
            get { return pretimeunit; }
            set { pretimeunit = value; }
        }
        private char isoveralert;

        /// <summary>
        /// 是否警告
        /// </summary>
        public char Isoveralert
        {
            get { return isoveralert; }
            set { isoveralert = value; }
        }


        private int overalerttime;

        /// <summary>
        /// 报警提前时间（超过）
        /// </summary>
        public int Overalerttime
        {
            get { return overalerttime; }
            set { overalerttime = value; }
        }
        private string overtimeunit;

        /// <summary>
        /// 报警提前时间单位（超过）
        /// </summary>
        public string Overtimeunit
        {
            get { return overtimeunit; }
            set { overtimeunit = value; }
        }
        private char is_take_grade;

        /// <summary>
        /// 是否扣分
        /// </summary>
        public char Is_take_grade
        {
            get { return is_take_grade; }
            set { is_take_grade = value; }
        }
        private double take_grade;

        /// <summary>
        /// 扣分值
        /// </summary>
        public double Take_grade
        {
            get { return take_grade; }
            set { take_grade = value; }
        }
        private char is_notice;

        /// <summary>
        ///  是否提醒
        /// </summary>
        public char Is_notice
        {
            get { return is_notice; }
            set { is_notice = value; }
        }
        private int threadstate;

        /// <summary>
        /// 线程状态
        /// </summary>
        public int Threadstate
        {
            get { return threadstate; }
            set { threadstate = value; }
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


        private string effect_section;

        /// <summary>
        /// 作用科室
        /// </summary>
        public string Effect_section
        {
            get { return effect_section; }
            set { effect_section = value; }
        }
    }
}
