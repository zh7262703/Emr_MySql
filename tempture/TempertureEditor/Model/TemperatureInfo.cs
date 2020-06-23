using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Model
{
    /// <summary>
    /// 体温单信息
    /// </summary>
    public class TemperatureInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int TD {get;set;}

        /// <summary>
        /// 床号
        /// </summary>
        public string Sick_Bed_No {get;set;}

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Patient_Name {get;set;}

        /// <summary>
        /// 时段1的体温
        /// </summary>
        public string T1 {get;set;}

        /// <summary>
        /// 时段1的脉搏
        /// </summary>
        public string P1 {get;set;}

        /// <summary>
        /// 时段1的呼吸
        /// </summary>
        public string R1 {get;set;}
        
        public string T2 {get;set;}
        public string P2 {get;set;}
        public string R2 {get;set;}
        public string T3 {get;set;}
        public string P3 {get;set;}
        public string R3 {get;set;}
        public string T4 {get;set;}
        public string P4 {get;set;}
        public string R4 {get;set;}

        /// <summary>
        /// 大便次数
        /// </summary>
        public string DBCS {get;set;}

        /// <summary>
        /// 体重
        /// </summary>
        public string TZ {get;set;}

        /// <summary>
        /// 小便次数
        /// </summary>
        public string XBCS {get;set;}

        /// <summary>
        /// 
        /// </summary>
        public string DY {get;set;}
        public string ZYTS {get;set;}
    }
}
