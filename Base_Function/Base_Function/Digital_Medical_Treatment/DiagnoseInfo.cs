using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Medical_Treatment
{
    public class DiagnoseInfo  
    {
        /// <summary>
        /// 诊断编码
        /// </summary>
        private string diagnoseCode;

        public string DiagnoseCode
        {
            get { return diagnoseCode; }
            set { diagnoseCode = value; }
        }
        /// <summary>
        /// 诊断名称
        /// </summary>
        private string diagnoseName;

        public string DiagnoseName
        {
            get { return diagnoseName; }
            set { diagnoseName = value; }
        }
        /// <summary>
        /// 是否是中医诊断
        /// </summary>
        private string isChinese;

        public string IsChinese
        {
            get { return isChinese; }
            set { isChinese = value; }
        }
        private string patientDiagnoseInfo;
        /// <summary>
        /// 患者诊断信息
        /// </summary>
        public string PatientDiagnoseInfo
        {
            get { return patientDiagnoseInfo; }
            set { patientDiagnoseInfo = value; }
        }
    }
}
