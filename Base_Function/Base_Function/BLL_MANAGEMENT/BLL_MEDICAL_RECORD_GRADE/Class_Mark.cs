using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 评分
    /// </summary>
    public class Class_Mark
    {
        private string id;

        private string code;

        private string typeId;

        private string name;

        private string checkReq;

        private string deductStand;

        private string deductScore;

        private string isSingVeto;

        private string singVetoLev;

        private string isModifyManual;

        private string validState;

        private string spellCode;

        private string type;

        private string vetoProjects;

        /// <summary>
        /// 项目评分ID
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 项目评分编码
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// 项目评分类型ID
        /// </summary>
        public string TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        /// <summary>
        /// 项目评分名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 检查要求
        /// </summary>
        public string CheckReq
        {
            get { return checkReq; }
            set { checkReq = value; }
        }

        /// <summary>
        /// 评分标准
        /// </summary>
        public string DeductStand
        {
            get { return deductStand; }
            set { deductStand = value; }
        }

        /// <summary>
        /// 单项扣分值
        /// </summary>
        public string DeductScore
        {
            get { return deductScore; }
            set { deductScore = value; }
        }

        /// <summary>
        /// 是否单项否决
        /// </summary>
        public string IsSingVeto
        {
            get { return isSingVeto; }
            set { isSingVeto = value; }
        }

        /// <summary>
        /// 单项否决级别
        /// </summary>
        public string SingVetoLev
        {
            get { return singVetoLev; }
            set { singVetoLev = value; }
        }

        /// <summary>
        /// 是否手动修改分值
        /// </summary>
        public string IsModifyManual
        {
            get { return isModifyManual; }
            set { isModifyManual = value; }
        }

        /// <summary>
        /// 有效标志
        /// </summary>
        public string ValidState
        {
            get { return validState; }
            set { validState = value; }
        }

        /// <summary>
        /// 拼音查询码
        /// </summary>
        public string SpellCode
        {
            get { return spellCode; }
            set { spellCode = value; }
        }

        /// <summary>
        /// 主观客观标志
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 否决其他评分项目 逗号分隔
        /// </summary>
        public string VetoProjects
        {
            get { return vetoProjects; }
            set { vetoProjects = value; }
        }
    }
}
