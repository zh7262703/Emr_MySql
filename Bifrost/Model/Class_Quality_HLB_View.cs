using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   public class Class_Quality_HLB_View
    {
        private int id;
        private string document_Type;
        private string sub_Item;
        private string inpatient_Type;
        private string base_Time;
        private int runcycle;
        private string runcycleunit;
        private string isprealert;
        private int prealerttime;
        private string pretimeunit;
        private string isoveralert;
        private int overalerttime;
        private string overtimeunit;
        private double take_Grade;
        private string is_Notice;
        private string is_Renew;
        private string fix_Time;
        private string istoday;
        private int exceTimes;
        private string threadState;
        private float item_Max;
        private float item_Min;

       /// <summary>
       /// 线程状态
       /// </summary>
       public string ThreadState
        {
            get { return threadState; }
            set { threadState = value; }
        }

       // private QualityThreadState qualityState;
       // private ArrayList threads;

        /// <summary>
        /// 线程数量
        /// </summary>
        //public ArrayList Threads
        //{
        //    get { return threads; }
        //    set { threads = value; }
        //}


        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 文档类型
        /// </summary>
        public string Document_Type
        {
            get { return document_Type; }
            set { document_Type = value; }
        }

        /// <summary>
        /// 监控子项
        /// </summary>
        public string Sub_Item
        {
            get { return sub_Item; }
            set { sub_Item = value; }
        }

        /// <summary>
        /// 病人类型(监控病人类型)
        /// </summary>
        public string Inpatient_Type
        {
            get { return inpatient_Type; }
            set { inpatient_Type = value; }
        }

        /// <summary>
        /// 参考时间
        /// </summary>
        public string Base_Time
        {
            get { return base_Time; }
            set { base_Time = value; }
        }

        /// <summary>
        /// 执行周期
        /// </summary>
        public int Runcycle
        {
            get { return runcycle; }
            set { runcycle = value; }
        }

        /// <summary>
        /// 执行周期单位
        /// </summary>
        public string Runcycleunit
        {
            get { return runcycleunit; }
            set { runcycleunit = value; }
        }



        /// <summary>
        /// 是否预警
        /// </summary>
        public string Isprealert
        {
            get { return isprealert; }
            set { isprealert = value; }
        }

        /// <summary>
        /// 报警提前时间
        /// </summary>
        public int Prealerttime
        {
            get { return prealerttime; }
            set { prealerttime = value; }
        }

        /// <summary>
        /// 报警提前时间单位
        /// </summary>
        public string Pretimeunit
        {
            get { return pretimeunit; }
            set { pretimeunit = value; }
        }

        /// <summary>
        /// 是否警告
        /// </summary>
        public string Isoveralert
        {
            get { return isoveralert; }
            set { isoveralert = value; }
        }

        /// <summary>
        /// 报警提前时间(超过)
        /// </summary>
        public int Overalerttime
        {
            get { return overalerttime; }
            set { overalerttime = value; }
        }

        /// <summary>
        /// 报警提前时间单位(超过)
        /// </summary>
        public string Overtimeunit
        {
            get { return overtimeunit; }
            set { overtimeunit = value; }
        }





        /// <summary>
        /// 扣分值
        /// </summary>
        public double Take_Grade
        {
            get { return take_Grade; }
            set { take_Grade = value; }
        }

        /// <summary>
        /// 是否提醒
        /// </summary>
        public string Is_Notice
        {
            get { return is_Notice; }
            set { is_Notice = value; }
        }

        /// <summary>
        /// 超时补上是否扣分
        /// </summary>
        public string Is_Renew
        {
            get { return is_Renew; }
            set { is_Renew = value; }
        }

        /// <summary>
        /// 固定执行时间点
        /// </summary>
        public string Fix_Time
        {
            get { return fix_Time; }
            set { fix_Time = value; }
        }


        /// <summary>
        /// 是否当天检查一次
        /// </summary>
        public string Istoday
        {
            get { return istoday; }
            set { istoday = value; }
        }




        /// <summary>
        /// 执行次数
        /// </summary>
        public int ExceTimes
        {
            get { return exceTimes; }
            set { exceTimes = value; }
        }


       
        /// <summary>
        /// 项目最大值
        /// </summary>
        public float Item_Max
        {
            get { return item_Max; }
            set { item_Max = value; }
        }


        

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
