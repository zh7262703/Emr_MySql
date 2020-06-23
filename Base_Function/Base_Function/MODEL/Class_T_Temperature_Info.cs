using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 体温单其他信息
    /// </summary>
    public class Class_T_Temperature_Info
    {
        private string bed_no;
        /// <summary>
        /// 床号
        /// </summary>
        public string Bed_no
        {
            get { return bed_no; }
            set { bed_no = value; }
        }

        /// <summary>
        /// 住院病人ID
        /// </summary>
        private string pid;
        /// <summary>
        /// 住院病人ID
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private string shit;
        /// <summary>
        /// 大便
        /// </summary>
        public string Shit
        {
            get { return shit; }
            set { shit = value; }
        }

        private string stool_count;
        /// <summary>
        /// 大便次数
        /// </summary>
        public string Stool_count
        {
            get { return stool_count; }
            set { stool_count = value; }
        }
        private string stool_state;
        /// <summary>
        /// 大便状态
        /// </summary>
        public string Stool_state
        {
            get { return stool_state; }
            set { stool_state = value; }
        }
        private string shit_state;
        /// <summary>
        /// 大便失禁状态
        /// </summary>
        public string Shit_state
        {
            get { return shit_state; }
            set { shit_state = value; }
        }

        private string clysis_count;
        /// <summary>
        /// 灌肠次数
        /// </summary>
        public string Clysis_count
        {
            get { return clysis_count; }
            set { clysis_count = value; }
        }
        private string stool_count_e;
        /// <summary>
        /// 灌肠后大便次数
        /// </summary>
        public string Stool_count_e
        {
            get { return stool_count_e; }
            set { stool_count_e = value; }
        }

        private string stool_amount;
        /// <summary>
        /// 大便量
        /// </summary>
        public string Stool_amount
        {
            get { return stool_amount; }
            set { stool_amount = value; }
        }

        private string stool_amount_unit;
        /// <summary>
        /// 大便量单位
        /// </summary>
        public string Stool_amount_unit
        {
            get { return stool_amount_unit; }
            set { stool_amount_unit = value; }
        }
        private string stale_amount;
        /// <summary>
        /// 尿量
        /// </summary>
        public string Stale_amount
        {
            get { return stale_amount; }
            set { stale_amount = value; }
        }
        private string is_catheter;
        /// <summary>
        /// 是否导尿
        /// </summary>
        public string Is_catheter
        {
            get { return is_catheter; }
            set { is_catheter = value; }
        }
        private string weighttype;
        /// <summary>
        /// 体重不测原因
        /// </summary>
        public string Weighttype
        {
            get { return weighttype; }
            set { weighttype = value; }
        }
        private string weight;
        /// <summary>
        /// 体重测量值
        /// </summary>
        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string weight_unit;
        /// <summary>
        /// 体重单位
        /// </summary>
        public string Weight_unit
        {
            get { return weight_unit; }
            set { weight_unit = value; }
        }
        private string weight_special;
        /// <summary>
        /// 体重特殊情况
        /// </summary>
        public string Weight_special
        {
            get { return weight_special; }
            set { weight_special = value; }
        }
        private string length;
        /// <summary>
        /// 身高
        /// </summary>
        public string Length
        {
            get { return length; }
            set { length = value; }
        }

        private string sensi;
        /// <summary>
        /// 药物过敏
        /// </summary>
        public string Sensi
        {
            get { return sensi; }
            set { sensi = value; }
        }


        private string sensi_test_code;
        /// <summary>
        /// 药物过敏试验代码
        /// </summary>
        public string Sensi_test_code
        {
            get { return sensi_test_code; }
            set { sensi_test_code = value; }
        }

        private string sensi_test_result;
        /// <summary>
        /// 药物过敏试验结果
        /// </summary>
        public string Sensi_test_result
        {
            get { return sensi_test_result; }
            set { sensi_test_result = value; }
        }

        private string sensi_test_result_temp;
        /// <summary>
        /// 药物过敏试验结果其他
        /// </summary>
        public string Sensi_test_result_temp
        {
            get { return sensi_test_result_temp; }
            set { sensi_test_result_temp = value; }
        }
        private string record_id;
        /// <summary>
        /// 记录人ID
        /// </summary>
        public string Record_id
        {
            get { return record_id; }
            set { record_id = value; }
        }
        private string record_time;
        /// <summary>
        /// 记录时间
        /// </summary>
        public string Record_time
        {
            get { return record_time; }
            set { record_time = value; }
        }
        private string in_amount;
        /// <summary>
        /// 入量汇总
        /// </summary>
        public string In_amount
        {
            get { return in_amount; }
            set { in_amount = value; }
        }
        private string out_amount;
        /// <summary>
        /// 出量汇总
        /// </summary>
        public string Out_amount
        {
            get { return out_amount; }
            set { out_amount = value; }
        }
        private string out_amount1;
        /// <summary>
        /// 出量其他1
        /// </summary>
        public string Out_amount1
        {
            get { return out_amount1; }
            set { out_amount1 = value; }
        }
        private string out_amount2;
        /// <summary>
        /// 出量其他2
        /// </summary>
        public string Out_amount2
        {
            get { return out_amount2; }
            set { out_amount2 = value; }
        }
        private string out_amount3;
        /// <summary>
        /// 出量其他3
        /// </summary>
        public string Out_amount3
        {
            get { return out_amount3; }
            set { out_amount3 = value; }
        }
        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string bp_high;
        /// <summary>
        /// 血压收缩压测量值
        /// </summary>
        public string Bp_high
        {
            get { return bp_high; }
            set { bp_high = value; }
        }

        private string bp_low;
        /// <summary>
        /// 血压舒张压测量值
        /// </summary>
        public string Bp_low
        {
            get { return bp_low; }
            set { bp_low = value; }
        }

        private string bp_unit;
        /// <summary>
        /// 血压单位
        /// </summary>
        public string Bp_unit
        {
            get { return bp_unit; }
            set { bp_unit = value; }
        }

        private string out_other;
        /// <summary>
        /// 出量其他
        /// </summary>
        public string Out_other
        {
            get { return out_other; }
            set { out_other = value; }
        }

        private string bp_blood;
        /// <summary>
        /// 血压1
        /// </summary>
        public string Bp_blood
        {
            get { return bp_blood; }
            set { bp_blood = value; }
        }

        private string bp_blood2;
        /// <summary>
        /// 血压2
        /// </summary>
        public string Bp_blood2
        {
            get { return bp_blood2; }
            set { bp_blood2 = value; }
        }

        private string stool_count_f;
        /// <summary>
        /// 灌肠前大便
        /// </summary>
        public string Stool_count_f
        {
            get { return stool_count_f; }
            set { stool_count_f = value; }
        }

        private string patient_id;
        /// <summary>
        /// 病人的主键
        /// </summary>
        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        private string spo2;

        public string Spo2
        {
            get { return spo2; }
            set { spo2 = value; }
        }

        private string special;
        /// <summary>
        /// 特殊治疗
        /// </summary>
        public string Special
        {
            get { return special; }
            set { special = value; }
        }
        private string sputum_quantity;
        /// <summary>
        /// 出量-痰量
        /// </summary>
        public string Sputum_quantity
        {
            get { return sputum_quantity; }
            set { sputum_quantity = value; }
        }
        private string volume_of_drainage;
        /// <summary>
        /// 出量-引流量
        /// </summary>
        public string Volume_of_drainage
        {
            get { return volume_of_drainage; }
            set { volume_of_drainage = value; }
        }
        private string vomit;
        /// <summary>
        /// 出量-呕吐量
        /// </summary>
        public string Vomit
        {
            get { return vomit; }
            set { vomit = value; }
        }

        private string urine;
        /// <summary>
        /// 小便量
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }

        private string urine_count;
        /// <summary>
        /// 小便次数
        /// </summary>
        public string Urine_count
        {
            get { return urine_count; }
            set { urine_count = value; }
        }

        private string urine_state;
        /// <summary>
        /// 小便状态
        /// </summary>
        public string Urine_state
        {
            get { return urine_state; }
            set { urine_state = value; }
        }

        private string empty_name1;
        /// <summary>
        /// 空白行名称1
        /// </summary>
        public string Empty_name1
        {
            get { return empty_name1; }
            set { empty_name1 = value; }
        }

        private string empty_value1;
        /// <summary>
        /// 空白行值1
        /// </summary>
        public string Empty_value1
        {
            get { return empty_value1; }
            set { empty_value1 = value; }
        }

        private string empty_name2;
        /// <summary>
        /// 空白行名称2
        /// </summary>
        public string Empty_name2
        {
            get { return empty_name2; }
            set { empty_name2 = value; }
        }

        private string empty_value2;
        /// <summary>
        /// 空白行值2
        /// </summary>
        public string Empty_value2
        {
            get { return empty_value2; }
            set { empty_value2 = value; }
        }
        private string empty_name3;
        /// <summary>
        /// 空白行名称3
        /// </summary>
        public string Empty_name3
        {
            get { return empty_name3; }
            set { empty_name3 = value; }
        }

        private string empty_value3;
        /// <summary>
        /// 空白行值3
        /// </summary>
        public string Empty_value3
        {
            get { return empty_value3; }
            set { empty_value3 = value; }
        }

        private string empty_name4;
        /// <summary>
        /// 空白行名称4
        /// </summary>
        public string Empty_name4
        {
            get { return empty_name4; }
            set { empty_name4 = value; }
        }

        private string empty_value4;
        /// <summary>
        /// 空白行值4
        /// </summary>
        public string Empty_value4
        {
            get { return empty_value4; }
            set { empty_value4 = value; }
        }
        private string empty_name5;
        /// <summary>
        /// 空白行名称5
        /// </summary>
        public string Empty_name5
        {
            get { return empty_name5; }
            set { empty_name5 = value; }
        }

        private string empty_value5;
        /// <summary>
        /// 空白行值5
        /// </summary>
        public string Empty_value5
        {
            get { return empty_value5; }
            set { empty_value5 = value; }
        }

        private string water_amount;
        /// <summary>
        /// 饮水量
        /// </summary>
        public string Water_amount
        {
            get { return water_amount; }
            set { water_amount = value; }
        }

    }
}
