using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// ��Ժ�������ʵ����
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
        /// �Ƿ�����ҽ���
        /// </summary>
        public string Is_Chinese
        {
            get { return _is_Chinese; }
            set { _is_Chinese = value; }
        }

        /// <summary>
        /// ת�����
        /// </summary>
        public string TurnTo
        {
            get { return turnTo; }
            set { turnTo = value; }
        }
        
        /// <summary>
        /// �����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ICD10 �����
        /// </summary>
        public string ICD10
        {
            get { return icd10; }
            set { icd10 = value; }
        }

        /// <summary>
        /// ��Ժ����
        /// </summary>
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public DiagnoseType DType
        {
            get { return dType; }
            set { dType = value; }
        }

        /// <summary>
        /// ������͵�ö�� 
        /// </summary>
        public enum DiagnoseType 
        {
            /// <summary>
            /// �ż���
            /// </summary>
            E = 0, 

            /// <summary>
            /// �������
            /// </summary>
            P = 1, 
            
            /// <summary>
            /// �����ж�
            /// </summary>
            S = 2, 
            
            /// <summary>
            /// ��Ҫ���
            /// </summary>
            M = 3, 
            
            /// <summary>
            /// �������
            /// </summary>
            O = 4,
             /// <summary>
            /// ��ҽ�ż���
            /// </summary>
            C=5
        }
    }


}
