using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    class Class_Nurse_Record_NewBorn
    {
        private string dateTime;
        /// <summary>
        /// 日期时间
        /// </summary>
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private string boxT;
        /// <summary>
        /// 箱温
        /// </summary>
        public string BoxT
        {
            get { return boxT; }
            set { boxT = value; }
        }

        private string humidity;
        /// <summary>
        /// 湿度
        /// </summary>
        public string Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        #region 生命体征

        private string t;
        /// <summary>
        /// 体温
        /// </summary>
        public string T
        {
            get { return t; }
            set { t = value; }
        }

        private string hr;
        /// <summary>
        /// 心率
        /// </summary>
        public string HR
        {
            get { return hr; }
            set { hr = value; }
        }
        private string r;
        /// <summary>
        /// 呼吸
        /// </summary>
        public string R
        {
            get { return r; }
            set { r = value; }
        }

        private string bp;
        /// <summary>
        /// 血压
        /// </summary>
        public string Bp
        {
            get { return bp; }
            set { bp = value; }
        }

        //血氧饱和度
        private string oxygen_saturation;
        /// <summary>
        /// 血氧饱和度
        /// </summary>
        public string Oxygen_saturation
        {
            get { return oxygen_saturation; }
            set { oxygen_saturation = value; }
        }
        #endregion

        #region 入量
        private string medicineName;
        /// <summary>
        /// 药物名称
        /// </summary>
        public string MedicineName
        {
            get { return medicineName; }
            set { medicineName = value; }
        }
        private string medicineValue;
        /// <summary>
        /// 药物量
        /// </summary>
        public string MedicineValue
        {
            get { return medicineValue; }
            set { medicineValue = value; }
        }
        private string v;
        /// <summary>
        /// 速度
        /// </summary>
        public string V
        {
            get { return v; }
            set { v = value; }
        }

        private string breastMilk;
        /// <summary>
        /// 母乳
        /// </summary>
        public string BreastMilk
        {
            get { return breastMilk; }
            set { breastMilk = value; }
        }
        private string water;
        /// <summary>
        /// 水
        /// </summary>
        public string Water
        {
            get { return water; }
            set { water = value; }
        }
        private string formula;
        /// <summary>
        /// 配方奶
        /// </summary>
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }
        #endregion

        #region 出量
        private string urine;
        /// <summary>
        /// 小便
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }
        private string uColor;
        /// <summary>
        /// 小便颜色
        /// </summary>
        public string UColor
        {
            get { return uColor; }
            set { uColor = value; }
        }

        //大便
        private string shit;
        /// <summary>
        /// 大便
        /// </summary>
        public string Shit
        {
            get { return shit; }
            set { shit = value; }
        }

        private string characteristics;
        /// <summary>
        /// 性状
        /// </summary>
        public string Characteristics
        {
            get { return characteristics; }
            set { characteristics = value; }
        }
        private string puke;
        /// <summary>
        /// 呕吐物
        /// </summary>
        public string Puke
        {
            get { return puke; }
            set { puke = value; }
        }
        private string other;
        /// <summary>
        /// 其他
        /// </summary>
        public string Other
        {
            get { return other; }
            set { other = value; }
        }
        #endregion

        private string ductItem;
        /// <summary>
        /// 管道
        /// </summary>
        public string DuctItem
        {
            get { return ductItem; }
            set { ductItem = value; }
        }

        #region 护理
        private string eye;
        /// <summary>
        /// 眼
        /// </summary>
        public string Eye
        {
            get { return eye; }
            set { eye = value; }
        }
        private string mouth;
        /// <summary>
        /// 口
        /// </summary>
        public string Mouth
        {
            get { return mouth; }
            set { mouth = value; }
        }
        private string navel;
        /// <summary>
        /// 脐
        /// </summary>
        public string Navel
        {
            get { return navel; }
            set { navel = value; }
        }
        private string buttocks;
        /// <summary>
        /// 臀
        /// </summary>
        public string Buttocks
        {
            get { return buttocks; }
            set { buttocks = value; }
        }
        private string shower;
        /// <summary>
        /// 淋浴
        /// </summary>
        public string Shower
        {
            get { return shower; }
            set { shower = value; }
        }
        private string spongeBath;
        /// <summary>
        /// 擦浴
        /// </summary>
        public string SpongeBath
        {
            get { return spongeBath; }
            set { spongeBath = value; }
        }
        private string position;
        /// <summary>
        /// 体位
        /// </summary>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion
        #region 病情观察
        //皮肤
        private string skin;
        /// <summary>
        /// 皮肤
        /// </summary>
        public string Skin
        {
            get { return skin; }
            set { skin = value; }
        }
        private string cry;
        /// <summary>
        /// 哭声
        /// </summary>
        public string Cry
        {
            get { return cry; }
            set { cry = value; }
        }
        private string suck;
        /// <summary>
        /// 吸吮
        /// </summary>
        public string Suck
        {
            get { return suck; }
            set { suck = value; }
        }
        private string autoactive;
        /// <summary>
        /// 自主活动
        /// </summary>
        public string Autoactive
        {
            get { return autoactive; }
            set { autoactive = value; }
        }
        private string acra;
        /// <summary>
        /// 肢端
        /// </summary>
        public string Acra
        {
            get { return acra; }
            set { acra = value; }
        }
        #endregion

        private string nurseResult;
        /// <summary>
        /// 护理措施及效果
        /// </summary>
        public string NurseResult
        {
            get { return nurseResult; }
            set { nurseResult = value; }
        }

        private string signature;
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
