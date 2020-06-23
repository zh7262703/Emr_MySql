using System;
using System.Drawing;
using System.Collections.Specialized;

namespace Base_Function.BASE_COMMON
{
    /// <summary>
    /// �����¼��ǩ������
    /// </summary>
    public class NurseRecordSign
    {
        #region Variables
        public const double ROW_WIDTH = 159.6D;
        public const string SPLIT_MARK = "@";
        public const string SPACE_MARK = " ";

        private static SizeF signatureSize = new SizeF();
        private static SizeF totalSize = new SizeF();
        private static SizeF spaceSize = new SizeF();
        private static SizeF splitMarkSize = new SizeF();
        private string conditionContent;
        private string signature;
        private Graphics graphics;
        private double lastLineWidth;
        private string spaces = string.Empty;
        private static StringCollection splitConditions = new StringCollection();
        #endregion

        #region Propertys
        /// <summary>
        /// �����¼����
        /// </summary>
        public string ConditionContent
        {
            get { return conditionContent; }
            set { conditionContent = value; }
        }
        /// <summary>
        /// ǩ��
        /// </summary>
        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }
        /// <summary>
        /// �����ַ���ȶ���
        /// </summary>
        public Graphics Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// ��ʼ�������¼��ǩ������
        /// </summary>
        /// <param name="conditionText">�����¼</param>
        /// <param name="sign">ǩ��</param>
        /// <param name="g">�����ַ���ȶ���</param>
        public NurseRecordSign(string conditionText, string sign, Graphics g)
        {
            this.conditionContent = FormatConditionContent(conditionText);
            this.signature = sign;
            this.graphics = g;
            InitialCharSize(conditionContent, signature, graphics);
            lastLineWidth = CalcRemainder(totalSize.Width, ROW_WIDTH);
        }
        #endregion
        /// <summary>
        /// ��ʽ������ǩ��
        /// </summary>
        /// <returns></returns>
        public string FormatConditionSign()
        {
            return FormatConditionSign(conditionContent, signature, graphics);
        }
        /// <summary>
        /// ��ʽ������ǩ��
        /// </summary>
        /// <returns></returns>
        public static string FormatConditionSign(string conditions, string sign, Graphics g)
        {
            string result = string.Empty;
            string spaces = string.Empty;
            SplitConditionContent(conditions, g);
            string lastCondition = string.Empty;
            if (splitConditions.Count != 0)
            {
                lastCondition = splitConditions[splitConditions.Count - 1];
            }
            double interval = CalcAppendBlankWidth(lastCondition, g);
            for (double i = 0; i < interval; i += spaceSize.Width)
            {
                spaces += SPACE_MARK;
            }
            result = MakeConditionSign(conditions, spaces, SPLIT_MARK, sign);
            return result;
        }

        #region Privates

        /// <summary>
        /// ������ӿո�Ŀ��
        /// </summary>
        /// <param name="content">��������</param>
        /// <param name="g">��ȡ�ַ���ȵĶ���</param>
        /// <returns></returns>
        private static double CalcAppendBlankWidth(string content, Graphics g)
        {
            double interval = 0.0D;
            double lastWidth = GetCharsWidth(content, g);
            if (lastWidth > ROW_WIDTH / 2)
            {
                interval = lastWidth;
            }
            else
            {
                if (lastWidth + signatureSize.Width > ROW_WIDTH)
                {
                    interval = ROW_WIDTH;
                }
            }
            return interval;
        }
        /// <summary>
        /// ��ȡ�ַ��Ŀ��
        /// </summary>
        /// <param name="chars">�ַ�</param>
        /// <returns></returns>
        private static double GetCharsWidth(string chars, Graphics graphics)
        {
            chars = chars.EndsWith(SPACE_MARK) ? chars + SPLIT_MARK : chars;
            double charsWidth = CalcCharsSize(chars, graphics).Width;
            charsWidth = chars.EndsWith(SPLIT_MARK) ? charsWidth - splitMarkSize.Width : charsWidth;
            return charsWidth;
        }
        /// <summary>
        /// ��ʽ�������¼�е����ݡ�
        /// </summary>
        /// <param name="conditionContent">�����¼</param>
        private static string FormatConditionContent(string conditionContent)
        {
            if (string.IsNullOrEmpty(conditionContent))
            {
                return string.Empty;
            }
            bool checkResult = conditionContent.Contains("\n");
            while (checkResult)
            {
                conditionContent = conditionContent.Remove(conditionContent.IndexOf("\n"), 1);
                checkResult = conditionContent.Contains("\n");
            }
            return conditionContent;
        }

        private static void SplitConditionContent(string conditions, Graphics graphics)
        {
            string perval = string.Empty;
            for (int i = 0; i < conditions.Length; i++)
            {
                string temp = string.Empty;
                temp = perval + conditions[i].ToString();
                SizeF tempSize = CalcCharsSize(temp, graphics);
                if (tempSize.Width <= ROW_WIDTH)
                {
                    perval = temp;
                    if (i == conditions.Length - 1)
                    {
                        if (!string.IsNullOrEmpty(perval))
                        {
                            splitConditions.Add(perval);
                            perval = string.Empty;
                        }
                    }
                }
                else
                {
                    splitConditions.Add(perval);
                    perval = string.Empty;
                    i -= 1;
                }
            }
        }
        /// <summary>
        /// ���첡��ǩ��
        /// </summary>
        /// <param name="condition">�����¼</param>
        /// <param name="spaces">�ո�</param>
        /// <param name="splitMark">�ָ���-�����ǩ��֮��</param>
        /// <param name="sign">ǩ��</param>
        private static string MakeConditionSign(string condition, string spaces, string splitMark, string sign)
        {
            return string.Format("{0}{1}{2}{3}", condition, spaces, splitMark, sign);
        }
        private static double CalcRemainder(double divisor, double dividend)
        {
            if (dividend == 0)
            {
                return 0.0;
            }
            return divisor % dividend;
        }
        private static double CalcQuotient(double divisor, double dividend)
        {
            if (dividend == 0)
            {
                return 0.0;
            }
            return divisor / dividend;
        }
        private static void InitialCharSize(string conditionContent, string signature, Graphics graphics)
        {
            signatureSize = CalcCharsSize(signature, graphics);
            totalSize = CalcCharsSize(conditionContent, graphics);
            spaceSize = CalcCharsSize(SPACE_MARK, graphics);
            splitMarkSize = CalcCharsSize(SPLIT_MARK, graphics);
        }
        public static SizeF CalcCharsSize(string strContent, Graphics graphics)
        {
            return graphics.MeasureString(strContent, new Font("����", 7));
        }
        #endregion
    }
}
