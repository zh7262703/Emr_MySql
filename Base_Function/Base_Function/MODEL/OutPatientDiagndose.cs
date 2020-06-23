using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 出院病人诊断实体类
    /// </summary>
    public class OutPatientDiagndose
    {
        private string name;
        private string icd10;
        private string condition;
        private string number;
        private DiagnoseType dType;
        private string turnTo;

        private string _is_Chinese;
        /// <summary>
        /// 是否是中医诊断
        /// </summary>
        public string Is_Chinese
        {
            get { return _is_Chinese; }
            set { _is_Chinese = value; }
        }

        /// <summary>
        /// 转归情况
        /// </summary>
        public string TurnTo
        {
            get { return turnTo; }
            set { turnTo = value; }
        }
        
        /// <summary>
        /// 诊断名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ICD10 诊断码
        /// </summary>
        public string ICD10
        {
            get { return icd10; }
            set { icd10 = value; }
        }

        /// <summary>
        /// 入院病情
        /// </summary>
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        /// <summary>
        /// 病理号
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        /// <summary>
        /// 诊断类型
        /// </summary>
        public DiagnoseType DType
        {
            get { return dType; }
            set { dType = value; }
        }

        /// <summary>
        /// 诊断类型的枚举 
        /// </summary>
        public enum DiagnoseType 
        {
            /// <summary>
            /// 门急诊
            /// </summary>
            E = 0, 

            /// <summary>
            /// 病理诊断
            /// </summary>
            P = 1, 
            
            /// <summary>
            /// 损伤中毒
            /// </summary>
            S = 2, 
            
            /// <summary>
            /// 主要诊断
            /// </summary>
            M = 3, 
            
            /// <summary>
            /// 其他诊断
            /// </summary>
            O = 4,
             /// <summary>
            /// 中医门急诊
            /// </summary>
            C=5
        }
    }


}
