using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Medical_Treatment
{
    public class DiagnoseInfo  
    {
        /// <summary>
        /// ��ϱ���
        /// </summary>
        private string diagnoseCode;

        public string DiagnoseCode
        {
            get { return diagnoseCode; }
            set { diagnoseCode = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        private string diagnoseName;

        public string DiagnoseName
        {
            get { return diagnoseName; }
            set { diagnoseName = value; }
        }
        /// <summary>
        /// �Ƿ�����ҽ���
        /// </summary>
        private string isChinese;

        public string IsChinese
        {
            get { return isChinese; }
            set { isChinese = value; }
        }
        private string patientDiagnoseInfo;
        /// <summary>
        /// ���������Ϣ
        /// </summary>
        public string PatientDiagnoseInfo
        {
            get { return patientDiagnoseInfo; }
            set { patientDiagnoseInfo = value; }
        }
    }
}
