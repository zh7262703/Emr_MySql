using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// ��ü�¼
    /// </summary>
    public class Class_Follow_Patient
    {
        private string id;

        /// <summary>
        /// ��ü�¼ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string patient_id;

        /// <summary>
        /// ��ò���ID
        /// </summary>
        public string Patient_Id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        private string solution_id;

        /// <summary>
        /// ����ID
        /// </summary>
        public string Solution_Id
        {
            get { return solution_id; }
            set { solution_id = value; }
        }
       
        private string creator_ID; //������ID

        /// <summary>
        /// ������ID
        /// </summary>
        public string Creator_ID
        {
            get { return creator_ID; }
            set { creator_ID = value; }
        }

        private string actual_time;
        /// <summary>
        /// ʵ�����ʱ��
        /// </summary>
        public string Actual_time
        {
            get { return actual_time; }
            set { actual_time = value; }
        }
        private string requested_time;
        /// <summary>
        /// �������ʱ��
        /// </summary>
        public string Requested_time
        {
            get { return requested_time; }
            set { requested_time = value; }
        }
        private string isfinished;
        /// <summary>
        /// �Ƿ����1��ʾ��ɣ�0��ʾδ���
        /// </summary>
        public string Isfinished
        {
            get { return isfinished; }
            set { isfinished = value; }
        }
        private string state_id;
        /// <summary>
        /// ��ʾ�û�״̬
        /// </summary>
        public string State_id
        {
            get { return state_id; }
            set { state_id = value; }
        }

        private string next_time;
        /// <summary>
        /// �´����ʱ��
        /// </summary>
        public string Next_time
        {
            get { return next_time; }
            set { next_time = value; }
        }

        private string is_timeset;
        /// <summary>
        /// ָ��Next_Time�Ǽ����´���õ�ʱ�仹��ֱ���趨Ϊ�´����ʱ�䣬0����Ϊ�����׼��1����ֱ��Ϊ�´����ʱ��
        /// </summary>
        public string Is_timeset
        {
            get { return is_timeset; }
            set { is_timeset = value; }
        }

    }
}
