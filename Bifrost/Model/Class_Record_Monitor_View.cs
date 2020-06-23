using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class Class_Record_Monitor_View
    {
        private string sickArea_Name;

        /// <summary>
        /// 病区名称
        /// </summary>
        public string SickArea_Name
        {
            get { return sickArea_Name; }
            set { sickArea_Name = value; }
        }
        private string docType;

        /// <summary>
        /// 文书类型
        /// </summary>
        public string DocType
        {
            get { return docType; }
            set { docType = value; }
        }

        private string docTypeID;
        /// <summary>
        /// 文书类型id,针对护理质控记录id情况增设
        /// </summary>
        public string DocTypeID
        {
            get { return docTypeID; }
            set { docTypeID = value; }
        }

        private int num;

        /// <summary>
        /// 数量
        /// </summary>
        public int Num
        {
            get { return num; }
            set { num = value; }
        }


        private int pV;

        /// <summary>
        /// 红黄灯
        /// </summary>
        public int PV
        {
            get { return pV; }
            set { pV = value; }
        }

        private string sickArea_ID;

        /// <summary>
        /// 病区ID
        /// </summary>
        public string SickArea_ID
        {
            get { return sickArea_ID; }
            set { sickArea_ID = value; }
        }

    }
}
