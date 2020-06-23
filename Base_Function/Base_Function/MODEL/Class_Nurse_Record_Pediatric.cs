using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 儿科护理记录单
    /// </summary>
    class Class_Nurse_Record_Pediatric
    {
        private string dateTime;
        /// <summary>
        /// 日期时间
        /// </summary>
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private string sick_level;
        /// <summary>
        /// 病情程度
        /// </summary>
        public string Sick_level
        {
            get { return sick_level; }
            set { sick_level = value; }
        }

        private string nurse_level;
        /// <summary>
        /// 护理级别
        /// </summary>
        public string Nurse_level
        {
            get { return nurse_level; }
            set { nurse_level = value; }
        }

        private string consciousness;
        /// <summary>
        /// 意识
        /// </summary>
        public string Consciousness
        {
            get { return consciousness; }
            set { consciousness = value; }
        }

        #region 瞳孔
        private string left;
        /// <summary>
        /// 左
        /// </summary>
        public string Left
        {
            get { return left; }
            set { left = value; }
        }
        private string right;
        /// <summary>
        /// 右
        /// </summary>
        public string Right
        {
            get { return right; }
            set { right = value; }
        }
        #endregion

        #region 生命体征

        private string t;
        /// <summary>
        /// T值
        /// </summary>
        public string T
        {
            get { return t; }
            set { t = value; }
        }

        private string p;
        /// <summary>
        /// P值
        /// </summary>
        public string P
        {
            get { return p; }
            set { p = value; }
        }
        private string hr;
        /// <summary>
        /// HR值
        /// </summary>
        public string HR
        {
            get { return hr; }
            set { hr = value; }
        }
        private string r;
        /// <summary>
        /// R
        /// </summary>
        public string R
        {
            get { return r; }
            set { r = value; }
        }

        private string bp;
        /// <summary>
        /// BP
        /// </summary>
        public string Bp
        {
            get { return bp; }
            set { bp = value; }
        }
        #endregion


        //血氧饱和度
        private string oxygen_saturation;
        /// <summary>
        /// 血氧饱和度
        /// </summary>
        public string Oxygen_saturation
        {
            get { return oxygen_saturation; }
            set { oxygen_saturation = value; }
        }

        #region 入量
        private string inputname;
        /// <summary>
        /// 入量名称
        /// </summary>
        public string Inputname
        {
            get { return inputname; }
            set { inputname = value; }
        }
        private string inputvalue;
        /// <summary>
        /// 入量量
        /// </summary>
        public string Inputvalue
        {
            get { return inputvalue; }
            set { inputvalue = value; }
        }
        private string inputother;
        /// <summary>
        /// 入量自定义项
        /// </summary>
        public string Inputother
        {
            get { return inputother; }
            set { inputother = value; }
        }

        #endregion

        #region 出量
        //大便
        private string shit;
        /// <summary>
        /// 大便
        /// </summary>
        public string Shit
        {
            get { return shit; }
            set { shit = value; }
        }

        //小便
        private string urine;
        /// <summary>
        /// 小便
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }

        private string outother;
        /// <summary>
        /// 出量其它
        /// </summary>
        public string Outother
        {
            get { return outother; }
            set { outother = value; }
        }

        //出量
        private string out_item_name;
        /// <summary>
        /// 出量自定义值
        /// </summary>
        public string Out_item_name
        {
            get { return out_item_name; }
            set { out_item_name = value; }
        }
        #endregion

        //管道
        private string duct_item_name;
        /// <summary>
        /// 管道名称
        /// </summary>
        public string Duct_item_name
        {
            get { return duct_item_name; }
            set { duct_item_name = value; }
        }
        //管道情况
        private string duct_item_values;
        /// <summary>
        /// 各种管道情况
        /// </summary>
        public string Duct_item_values
        {
            get { return duct_item_values; }
            set { duct_item_values = value; }
        }

        //皮肤
        private string skin;
        /// <summary>
        /// 皮肤
        /// </summary>
        public string Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        private string oxygen;
        /// <summary>
        /// 吸氧
        /// </summary>
        public string Oxygen
        {
            get { return oxygen; }
            set { oxygen = value; }
        }
        private string oxygen_value;
        /// <summary>
        /// 流量
        /// </summary>
        public string Oxygen_value
        {
            get { return oxygen_value; }
            set { oxygen_value = value; }
        }

        private string safenurse;
        /// <summary>
        /// 安全护理
        /// </summary>
        public string Safenurse
        {
            get { return safenurse; }
            set { safenurse = value; }
        }

        //备注
        private string nurse_result;
        /// <summary>
        /// 备注
        /// </summary>
        public string Nurse_result
        {
            get { return nurse_result; }
            set { nurse_result = value; }
        }

        //签名
        private string signature;
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

    }
}
