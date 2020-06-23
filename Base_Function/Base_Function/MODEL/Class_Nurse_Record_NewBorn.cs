using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    class Class_Nurse_Record_NewBorn
    {
        private string dateTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private string boxT;
        /// <summary>
        /// ����
        /// </summary>
        public string BoxT
        {
            get { return boxT; }
            set { boxT = value; }
        }

        private string humidity;
        /// <summary>
        /// ʪ��
        /// </summary>
        public string Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        #region ��������

        private string t;
        /// <summary>
        /// ����
        /// </summary>
        public string T
        {
            get { return t; }
            set { t = value; }
        }

        private string hr;
        /// <summary>
        /// ����
        /// </summary>
        public string HR
        {
            get { return hr; }
            set { hr = value; }
        }
        private string r;
        /// <summary>
        /// ����
        /// </summary>
        public string R
        {
            get { return r; }
            set { r = value; }
        }

        private string bp;
        /// <summary>
        /// Ѫѹ
        /// </summary>
        public string Bp
        {
            get { return bp; }
            set { bp = value; }
        }

        //Ѫ�����Ͷ�
        private string oxygen_saturation;
        /// <summary>
        /// Ѫ�����Ͷ�
        /// </summary>
        public string Oxygen_saturation
        {
            get { return oxygen_saturation; }
            set { oxygen_saturation = value; }
        }
        #endregion

        #region ����
        private string medicineName;
        /// <summary>
        /// ҩ������
        /// </summary>
        public string MedicineName
        {
            get { return medicineName; }
            set { medicineName = value; }
        }
        private string medicineValue;
        /// <summary>
        /// ҩ����
        /// </summary>
        public string MedicineValue
        {
            get { return medicineValue; }
            set { medicineValue = value; }
        }
        private string v;
        /// <summary>
        /// �ٶ�
        /// </summary>
        public string V
        {
            get { return v; }
            set { v = value; }
        }

        private string breastMilk;
        /// <summary>
        /// ĸ��
        /// </summary>
        public string BreastMilk
        {
            get { return breastMilk; }
            set { breastMilk = value; }
        }
        private string water;
        /// <summary>
        /// ˮ
        /// </summary>
        public string Water
        {
            get { return water; }
            set { water = value; }
        }
        private string formula;
        /// <summary>
        /// �䷽��
        /// </summary>
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }
        #endregion

        #region ����
        private string urine;
        /// <summary>
        /// С��
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }
        private string uColor;
        /// <summary>
        /// С����ɫ
        /// </summary>
        public string UColor
        {
            get { return uColor; }
            set { uColor = value; }
        }

        //���
        private string shit;
        /// <summary>
        /// ���
        /// </summary>
        public string Shit
        {
            get { return shit; }
            set { shit = value; }
        }

        private string characteristics;
        /// <summary>
        /// ��״
        /// </summary>
        public string Characteristics
        {
            get { return characteristics; }
            set { characteristics = value; }
        }
        private string puke;
        /// <summary>
        /// Ż����
        /// </summary>
        public string Puke
        {
            get { return puke; }
            set { puke = value; }
        }
        private string other;
        /// <summary>
        /// ����
        /// </summary>
        public string Other
        {
            get { return other; }
            set { other = value; }
        }
        #endregion

        private string ductItem;
        /// <summary>
        /// �ܵ�
        /// </summary>
        public string DuctItem
        {
            get { return ductItem; }
            set { ductItem = value; }
        }

        #region ����
        private string eye;
        /// <summary>
        /// ��
        /// </summary>
        public string Eye
        {
            get { return eye; }
            set { eye = value; }
        }
        private string mouth;
        /// <summary>
        /// ��
        /// </summary>
        public string Mouth
        {
            get { return mouth; }
            set { mouth = value; }
        }
        private string navel;
        /// <summary>
        /// ��
        /// </summary>
        public string Navel
        {
            get { return navel; }
            set { navel = value; }
        }
        private string buttocks;
        /// <summary>
        /// ��
        /// </summary>
        public string Buttocks
        {
            get { return buttocks; }
            set { buttocks = value; }
        }
        private string shower;
        /// <summary>
        /// ��ԡ
        /// </summary>
        public string Shower
        {
            get { return shower; }
            set { shower = value; }
        }
        private string spongeBath;
        /// <summary>
        /// ��ԡ
        /// </summary>
        public string SpongeBath
        {
            get { return spongeBath; }
            set { spongeBath = value; }
        }
        private string position;
        /// <summary>
        /// ��λ
        /// </summary>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion
        #region ����۲�
        //Ƥ��
        private string skin;
        /// <summary>
        /// Ƥ��
        /// </summary>
        public string Skin
        {
            get { return skin; }
            set { skin = value; }
        }
        private string cry;
        /// <summary>
        /// ����
        /// </summary>
        public string Cry
        {
            get { return cry; }
            set { cry = value; }
        }
        private string suck;
        /// <summary>
        /// ��˱
        /// </summary>
        public string Suck
        {
            get { return suck; }
            set { suck = value; }
        }
        private string autoactive;
        /// <summary>
        /// �����
        /// </summary>
        public string Autoactive
        {
            get { return autoactive; }
            set { autoactive = value; }
        }
        private string acra;
        /// <summary>
        /// ֫��
        /// </summary>
        public string Acra
        {
            get { return acra; }
            set { acra = value; }
        }
        #endregion

        private string nurseResult;
        /// <summary>
        /// �����ʩ��Ч��
        /// </summary>
        public string NurseResult
        {
            get { return nurseResult; }
            set { nurseResult = value; }
        }

        private string signature;
        /// <summary>
        /// ǩ��
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
