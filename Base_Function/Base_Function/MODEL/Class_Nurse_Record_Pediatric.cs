using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// ���ƻ����¼��
    /// </summary>
    class Class_Nurse_Record_Pediatric
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

        private string sick_level;
        /// <summary>
        /// ����̶�
        /// </summary>
        public string Sick_level
        {
            get { return sick_level; }
            set { sick_level = value; }
        }

        private string nurse_level;
        /// <summary>
        /// ������
        /// </summary>
        public string Nurse_level
        {
            get { return nurse_level; }
            set { nurse_level = value; }
        }

        private string consciousness;
        /// <summary>
        /// ��ʶ
        /// </summary>
        public string Consciousness
        {
            get { return consciousness; }
            set { consciousness = value; }
        }

        #region ͫ��
        private string left;
        /// <summary>
        /// ��
        /// </summary>
        public string Left
        {
            get { return left; }
            set { left = value; }
        }
        private string right;
        /// <summary>
        /// ��
        /// </summary>
        public string Right
        {
            get { return right; }
            set { right = value; }
        }
        #endregion

        #region ��������

        private string t;
        /// <summary>
        /// Tֵ
        /// </summary>
        public string T
        {
            get { return t; }
            set { t = value; }
        }

        private string p;
        /// <summary>
        /// Pֵ
        /// </summary>
        public string P
        {
            get { return p; }
            set { p = value; }
        }
        private string hr;
        /// <summary>
        /// HRֵ
        /// </summary>
        public string HR
        {
            get { return hr; }
            set { hr = value; }
        }
        private string r;
        /// <summary>
        /// R
        /// </summary>
        public string R
        {
            get { return r; }
            set { r = value; }
        }

        private string bp;
        /// <summary>
        /// BP
        /// </summary>
        public string Bp
        {
            get { return bp; }
            set { bp = value; }
        }
        #endregion


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

        #region ����
        private string inputname;
        /// <summary>
        /// ��������
        /// </summary>
        public string Inputname
        {
            get { return inputname; }
            set { inputname = value; }
        }
        private string inputvalue;
        /// <summary>
        /// ������
        /// </summary>
        public string Inputvalue
        {
            get { return inputvalue; }
            set { inputvalue = value; }
        }
        private string inputother;
        /// <summary>
        /// �����Զ�����
        /// </summary>
        public string Inputother
        {
            get { return inputother; }
            set { inputother = value; }
        }

        #endregion

        #region ����
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

        //С��
        private string urine;
        /// <summary>
        /// С��
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }

        private string outother;
        /// <summary>
        /// ��������
        /// </summary>
        public string Outother
        {
            get { return outother; }
            set { outother = value; }
        }

        //����
        private string out_item_name;
        /// <summary>
        /// �����Զ���ֵ
        /// </summary>
        public string Out_item_name
        {
            get { return out_item_name; }
            set { out_item_name = value; }
        }
        #endregion

        //�ܵ�
        private string duct_item_name;
        /// <summary>
        /// �ܵ�����
        /// </summary>
        public string Duct_item_name
        {
            get { return duct_item_name; }
            set { duct_item_name = value; }
        }
        //�ܵ����
        private string duct_item_values;
        /// <summary>
        /// ���ֹܵ����
        /// </summary>
        public string Duct_item_values
        {
            get { return duct_item_values; }
            set { duct_item_values = value; }
        }

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

        private string oxygen;
        /// <summary>
        /// ����
        /// </summary>
        public string Oxygen
        {
            get { return oxygen; }
            set { oxygen = value; }
        }
        private string oxygen_value;
        /// <summary>
        /// ����
        /// </summary>
        public string Oxygen_value
        {
            get { return oxygen_value; }
            set { oxygen_value = value; }
        }

        private string safenurse;
        /// <summary>
        /// ��ȫ����
        /// </summary>
        public string Safenurse
        {
            get { return safenurse; }
            set { safenurse = value; }
        }

        //��ע
        private string nurse_result;
        /// <summary>
        /// ��ע
        /// </summary>
        public string Nurse_result
        {
            get { return nurse_result; }
            set { nurse_result = value; }
        }

        //ǩ��
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
