using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 
    /// </summary>
    public class Class_Patients
    {
    
        private int tid; //模版ID

        /// <summary>
        /// 模版ID
        /// </summary>
        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }
        private string tName; //模版名称

        /// <summary>
        /// 模版名称
        /// </summary>
        public string TName
        {
            get { return tName; }
            set { tName = value; }
        }
        private string shortcut; //快捷码

        /// <summary>
        /// 快捷码
        /// </summary>
        public string Shortcut
        {
            get { return shortcut; }
            set { shortcut = value; }
        }
        private string textKind; //文书类型

        /// <summary>
        /// 文书类型
        /// </summary>
        public string TextKind
        {
            get { return textKind; }
            set { textKind = value; }
        }
        private char tempPlate_Level; //级别

        /// <summary>
        /// 级别(P-个人 S-科室 H-全院)
        /// </summary>
        public char TempPlate_Level
        {
            get { return tempPlate_Level; }
            set { tempPlate_Level = value; }
        }
        private char sex; //性别

        /// <summary>
        /// 性别(0-男，1女)
        /// </summary>
        public char Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private int ages; //年龄段
        
        /// <summary>
        /// 年龄段(婴儿、儿童、青年、成年、老年)
        /// </summary>
        public int Ages
        {
            get { return ages; }
            set { ages = value; }
        }
        private int section_ID; //科室ID

        /// <summary>
        /// 科室ID
        /// </summary>
        public int Section_ID
        {
            get { return section_ID; }
            set { section_ID = value; }
        }
        private int sickArea_ID; //病区ID

        /// <summary>
        /// 病区ID
        /// </summary>
        public int SickArea_ID
        {
            get { return sickArea_ID; }
            set { sickArea_ID = value; }
        }
        private int creator_ID; //创建人ID

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int Creator_ID
        {
            get { return creator_ID; }
            set { creator_ID = value; }
        }
        private string create_Time; //创建时间

        /// <summary>
        /// 创建时间
        /// </summary>
        public string Create_Time
        {
            get { return create_Time; }
            set { create_Time = value; }
        }
        private int updater_ID; //修改人ID

        /// <summary>
        /// 修改人ID
        /// </summary>
        public int Updater_ID
        {
            get { return updater_ID; }
            set { updater_ID = value; }
        }
        private string update_Time; //修改时间

        /// <summary>
        /// 修改时间
        /// </summary>
        public string Update_Time
        {
            get { return update_Time; }
            set { update_Time = value; }
        }
        private int verify_ID1; //科级审核人ID

        /// <summary>
        /// 科级审核人ID
        /// </summary>
        public int Verify_ID1
        {
            get { return verify_ID1; }
            set { verify_ID1 = value; }
        }
        private string verify_Time1; //科级审核时间

        /// <summary>
        /// 科级审核时间
        /// </summary>
        public string Verify_Time1
        {
            get { return verify_Time1; }
            set { verify_Time1 = value; }
        }
        private int verify_ID2; //院级审核人ID

        /// <summary>
        /// 院级审核人ID
        /// </summary>
        public int Verify_ID2
        {
            get { return verify_ID2; }
            set { verify_ID2 = value; }
        }
        private string verify_Time2; //院级审核时间

        /// <summary>
        /// 院级审核时间
        /// </summary>
        public string Verify_Time2
        {
            get { return verify_Time2; }
            set { verify_Time2 = value; }
        }
        private int verify_Sign; //审核标志

        /// <summary>
        /// 审核标志
        /// </summary>
        public int Verify_Sign
        {
            get { return verify_Sign; }
            set { verify_Sign = value; }
        }
        private char isDiag; //是否有诊断

        /// <summary>
        /// 是否有诊断
        /// </summary>
        public char IsDiag
        {
            get { return isDiag; }
            set { isDiag = value; }
        }
        private char enable_Flag; //有效标志

        /// <summary>
        /// 有效标志
        /// </summary>
        public char Enable_Flag
        {
            get { return enable_Flag; }
            set { enable_Flag = value; }
        }

        /// <summary>
        /// 默认标志
        /// </summary>
        private char isDefault;

        public char IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }
      
        /// <summary>
        /// 科室模板标志
        /// </summary>
        private string default_sec_id;

        public string Default_sec_id
        {
            get { return default_sec_id; }
            set { default_sec_id = value; }
        }

      

    }
}
