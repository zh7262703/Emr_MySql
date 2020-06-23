using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 死亡病人疾病情况实体类
    /// 创建者:LWM
    /// 创建时间:2014-05-15
    /// </summary>
    public class Class_SWBRJBQK
    {
        private string no;

        /// <summary>
        /// 顺序
        /// </summary>
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        private string icd10;
        /// <summary>
        /// ICD10
        /// </summary>
        public string Icd10
        {
            get { return icd10; }
            set { icd10 = value; }
        }

        private string jb_name;
        /// <summary>
        /// 疾病名称
        /// </summary>
        public string Jb_name
        {
            get { return jb_name; }
            set { jb_name = value; }
        }

        private string zls;
        /// <summary>
        /// 总例数
        /// </summary>
        public string Zls
        {
            get { return zls; }
            set { zls = value; }
        }

        private string zzrs;
        /// <summary>
        /// 占总人数%
        /// </summary>
        public string Zzrs
        {
            get { return zzrs; }
            set { zzrs = value; }
        }

        private string zy_days;
        /// <summary>
        /// 住院总天数-计
        /// </summary>
        public string Zy_days
        {
            get { return zy_days; }
            set { zy_days = value; }
        }

        private string zy_days_avg;
        /// <summary>
        /// 住院总天数-平均
        /// </summary>
        public string Zy_days_avg
        {
            get { return zy_days_avg; }
            set { zy_days_avg = value; }
        }

        private string zy_cost;
        /// <summary>
        /// 住院总费用-计
        /// </summary>
        public string Zy_cost
        {
            get { return zy_cost; }
            set { zy_cost = value; }
        }
        private string zy_cost_avg;
        /// <summary>
        /// 住院总费用_平均
        /// </summary>
        public string Zy_cost_avg
        {
            get { return zy_cost_avg; }
            set { zy_cost_avg = value; }
        }

        private string yp_cost;
        /// <summary>
        /// 药品总费用-计
        /// </summary>
        public string Yp_cost
        {
            get { return yp_cost; }
            set { yp_cost = value; }
        }

        private string yp_cost_avg;
        /// <summary>
        /// 药品总费用-平均
        /// </summary>
        public string Yp_cost_avg
        {
            get { return yp_cost_avg; }
            set { yp_cost_avg = value; }
        }

        private string zl_cost;
        /// <summary>
        /// 治疗总-计
        /// </summary>
        public string Zl_cost
        {
            get { return zl_cost; }
            set { zl_cost = value; }
        }

        private string zl_cost_avg;
        /// <summary>
        /// 治疗总-平均
        /// </summary>
        public string Zl_cost_avg
        {
            get { return zl_cost_avg; }
            set { zl_cost_avg = value; }
        }

        private string jc_cost;
        /// <summary>
        /// 检查总-计
        /// </summary>
        public string Jc_cost
        {
            get { return jc_cost; }
            set { jc_cost = value; }
        }

        private string jc_cost_avg;
        /// <summary>
        /// 检查总-平均
        /// </summary>
        public string Jc_cost_avg
        {
            get { return jc_cost_avg; }
            set { jc_cost_avg = value; }
        }

        private string cw_cost;
        /// <summary>
        /// 床位总-计
        /// </summary>
        public string Cw_cost
        {
            get { return cw_cost; }
            set { cw_cost = value; }
        }

        private string cw_cost_avg;
        /// <summary>
        /// 床位总-平均
        /// </summary>
        public string Cw_cost_avg
        {
            get { return cw_cost_avg; }
            set { cw_cost_avg = value; }
        }

        private string ss_cost;
        /// <summary>
        /// 手术总-计
        /// </summary>
        public string Ss_cost
        {
            get { return ss_cost; }
            set { ss_cost = value; }
        }

        private string ss_cost_avg;
        /// <summary>
        /// 手术总-平均
        /// </summary>
        public string Ss_cost_avg
        {
            get { return ss_cost_avg; }
            set { ss_cost_avg = value; }
        }

    }
}
