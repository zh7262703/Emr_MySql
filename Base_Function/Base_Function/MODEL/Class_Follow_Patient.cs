using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 随访记录
    /// </summary>
    public class Class_Follow_Patient
    {
        private string id;

        /// <summary>
        /// 随访记录ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string patient_id;

        /// <summary>
        /// 随访病人ID
        /// </summary>
        public string Patient_Id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        private string solution_id;

        /// <summary>
        /// 病区ID
        /// </summary>
        public string Solution_Id
        {
            get { return solution_id; }
            set { solution_id = value; }
        }
       
        private string creator_ID; //创建人ID

        /// <summary>
        /// 创建人ID
        /// </summary>
        public string Creator_ID
        {
            get { return creator_ID; }
            set { creator_ID = value; }
        }

        private string actual_time;
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public string Actual_time
        {
            get { return actual_time; }
            set { actual_time = value; }
        }
        private string requested_time;
        /// <summary>
        /// 理论完成时间
        /// </summary>
        public string Requested_time
        {
            get { return requested_time; }
            set { requested_time = value; }
        }
        private string isfinished;
        /// <summary>
        /// 是否完成1表示完成，0表示未完成
        /// </summary>
        public string Isfinished
        {
            get { return isfinished; }
            set { isfinished = value; }
        }
        private string state_id;
        /// <summary>
        /// 显示用户状态
        /// </summary>
        public string State_id
        {
            get { return state_id; }
            set { state_id = value; }
        }

        private string next_time;
        /// <summary>
        /// 下次随访时间
        /// </summary>
        public string Next_time
        {
            get { return next_time; }
            set { next_time = value; }
        }

        private string is_timeset;
        /// <summary>
        /// 指定Next_Time是计算下次随访的时间还是直接设定为下次随访时间，0代表为计算基准，1代表直接为下次随访时间
        /// </summary>
        public string Is_timeset
        {
            get { return is_timeset; }
            set { is_timeset = value; }
        }

    }
}
