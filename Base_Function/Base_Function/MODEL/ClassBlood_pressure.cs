using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// ѪѹȺ¼ʵ����
    /// �����ߣ�����
    /// ����ʱ�� 2011-03-06
    /// </summary>
    public class ClassBlood_pressure
    {
        private string bed;
      
        private string pidname;
        
        private string blood_pressure08;
     
        private string blood_pressure14;
    
        private string pid;
        private string pidids;

   
        /// <summary>
        /// ����
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Pidname
        {
            get { return pidname; }
            set { pidname = value; }
        }
        /// <summary>
        /// Ѫѹ8:00
        /// </summary>
        public string Blood_pressure08
        {
            get { return blood_pressure08; }
            set { blood_pressure08 = value; }
        }
        /// <summary>
        /// Ѫѹ14:00
        /// </summary>
        public string Blood_pressure14
        {
            get { return blood_pressure14; }
            set { blood_pressure14 = value; }
        }
        /// <summary>
        /// ����סԺ��
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// ���˱��
        /// </summary>
        public string Pidids
        {
            get { return pidids; }
            set { pidids = value; }
        }

    }
}
