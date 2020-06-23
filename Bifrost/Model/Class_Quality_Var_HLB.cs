using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 护理部参数设置实体类
    /// </summary>
    public class Class_Quality_Var_HLB
    {
        private int id;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int document_Type;

        /// <summary>
        /// 文档类型
        /// </summary>
        public int Document_Type
        {
            get { return document_Type; }
            set { document_Type = value; }
        }
        private int sub_Item;

        /// <summary>
        /// 监控子项
        /// </summary>
        public int Sub_Item
        {
            get { return sub_Item; }
            set { sub_Item = value; }
        }
        private int inpatient_Type;

        /// <summary>
        /// 病人类型(监控病人类型)
        /// </summary>
        public int Inpatient_Type
        {
            get { return inpatient_Type; }
            set { inpatient_Type = value; }
        }
        private int base_Time;

        /// <summary>
        /// 参考时间
        /// </summary>
        public int Base_Time
        {
            get { return base_Time; }
            set { base_Time = value; }
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
        /// 报警提前时间
        /// </summary>
        public int Prealerttime
        {
            get { return prealerttime; }
            set { prealerttime = value; }
        }
        private string pretimeunit;

        /// <summary>
        /// 报警提前时间单位
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
        /// 报警提前时间(超过)
        /// </summary>
        public int Overalerttime
        {
            get { return overalerttime; }
            set { overalerttime = value; }
        }
        private string overtimeunit;

        /// <summary>
        /// 报警提前时间单位(超过)
        /// </summary>
        public string Overtimeunit
        {
            get { return overtimeunit; }
            set { overtimeunit = value; }
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
        private char is_Notice;

        /// <summary>
        /// 是否提醒
        /// </summary>
        public char Is_Notice
        {
            get { return is_Notice; }
            set { is_Notice = value; }
        }
        private char is_Renew;

        /// <summary>
        /// 超时补上是否扣分
        /// </summary>
        public char Is_Renew
        {
            get { return is_Renew; }
            set { is_Renew = value; }
        }
        private string fix_Time;

        /// <summary>
        /// 固定执行时间点
        /// </summary>
        public string Fix_Time
        {
            get { return fix_Time; }
            set { fix_Time = value; }
        }

        private char istoday;

        /// <summary>
        /// 是否当天检查一次
        /// </summary>
        public char Istoday
        {
            get { return istoday; }
            set { istoday = value; }
        }

        
        private int exceTimes;

        /// <summary>
        /// 执行次数
        /// </summary>
        public int ExceTimes
        {
            get { return exceTimes; }
            set { exceTimes = value; }
        }

        private int threadState;

        /// <summary>
        /// 线程状态
        /// </summary>
        public int ThreadState
        {
            get { return threadState; }
            set { threadState = value; }
        }

        private float item_Max;

        /// <summary>
        /// 项目最大值
        /// </summary>
        public float Item_Max
        {
            get { return item_Max; }
            set { item_Max = value; }
        }


        private float item_Min;

        /// <summary>
        /// 项目最小值
        /// </summary>
        public float Item_Min
        {
            get { return item_Min; }
            set { item_Min = value; }
        }

     }
}
