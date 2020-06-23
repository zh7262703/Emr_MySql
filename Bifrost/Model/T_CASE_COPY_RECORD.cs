using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class T_CASE_COPY_RECORD
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        private string iD;

        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        /// <summary>
        /// 复印日期
        /// </summary>
        private string cOPY_TIME;

        public string COPY_TIME
        {
            get { return cOPY_TIME; }
            set { cOPY_TIME = value; }
        }
        /// <summary>
        /// 复印单位
        /// </summary>
        private string aPPLY_UNIT;

        public string APPLY_UNIT
        {
            get { return aPPLY_UNIT; }
            set { aPPLY_UNIT = value; }
        }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        private string aPPLY_PERSON;

        public string APPLY_PERSON
        {
            get { return aPPLY_PERSON; }
            set { aPPLY_PERSON = value; }
        }
        /// <summary>
        /// 病历号
        /// </summary>
        private string cASE_ID;

        public string CASE_ID
        {
            get { return cASE_ID; }
            set { cASE_ID = value; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        private string dEGREE_NUMBER;

        public string DEGREE_NUMBER
        {
            get { return dEGREE_NUMBER; }
            set { dEGREE_NUMBER = value; }
        }
        /// <summary>
        /// 工作证
        /// </summary>
        private string jOB_NUMBER;

        public string JOB_NUMBER
        {
            get { return jOB_NUMBER; }
            set { jOB_NUMBER = value; }
        }
        /// <summary>
        /// 委托书
        /// </summary>
        private string tRUST_DEED;

        public string TRUST_DEED
        {
            get { return tRUST_DEED; }
            set { tRUST_DEED = value; }
        }
        /// <summary>
        /// 死亡证明
        /// </summary>
        private string dEAD_ARGUE;

        public string DEAD_ARGUE
        {
            get { return dEAD_ARGUE; }
            set { dEAD_ARGUE = value; }
        }
        /// <summary>
        /// 近亲家属关系
        /// </summary>
        private string nEAR_RELATIVE_ARGUE;

        public string NEAR_RELATIVE_ARGUE
        {
            get { return nEAR_RELATIVE_ARGUE; }
            set { nEAR_RELATIVE_ARGUE = value; }
        }
        /// <summary>
        /// 复印内容
        /// </summary>
        private string cOPY_VALUE;

        public string COPY_VALUE
        {
            get { return cOPY_VALUE; }
            set { cOPY_VALUE = value; }
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        private string rECORD_TIME;

        public string RECORD_TIME
        {
            get { return rECORD_TIME; }
            set { rECORD_TIME = value; }
        }
    }
}
