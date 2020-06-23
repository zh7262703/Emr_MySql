using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{

    class Info_MedicalRecords
    {
        #region //相关变量定义

        private string patientID;
        private int visitID;
        private string textType;
        private string patientName;
        private int fileOrder;
        private string textTypeCode;
        private string fileName;       

        #endregion

        /// <summary>
        /// 获取或设置病历文件的文件名。
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// 获取或设置病历文件的类型编码。
        /// </summary>
        public string TextTypeCode
        {
            get { return textTypeCode; }
            set { textTypeCode = value; }
        }

        /// <summary>
        /// 获取或设置病历文件的显示顺序。
        /// </summary>
        public int FileOrder
        {
            get { return fileOrder; }
            set { fileOrder = value; }
        }

        /// <summary>
        /// 获取或设置病历文件的病人姓名。
        /// </summary>
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }

        /// <summary>
        /// 获取或设置病历文件的类型名称。
        /// </summary>
        public string TextType
        {
            get { return textType; }
            set { textType = value; }
        }

        /// <summary>
        /// 获取或设置病人的住院次数。
        /// </summary>
        public int VisitID
        {
            get { return visitID; }
            set { visitID = value; }
        }

        /// <summary>
        /// 获取或设置病人的ID。
        /// </summary>
        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

    }
}
