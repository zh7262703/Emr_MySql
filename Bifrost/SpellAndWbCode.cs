using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Bifrost
{
    public class SpellAndWbCode
    {
        #region ����

        /// <summary>
        /// XML�ļ���ȡʵ��
        /// </summary>
        private XmlReader reader = null;

        /// <summary>
        /// XML�ļ�������
        /// </summary>
        private string[] strXmlData = null;

        //��¼XML������뿪ʼλ�ã�
        private int wbCodeStation = 26;

        //��¼XML�н���λ�ã�
        private int outStation = 100;

        #endregion
        #region ���캯��
        /// <summary>
        /// ���캯������ʼ��XMLREADER
        /// </summary>
        public SpellAndWbCode()
        {
           
            try
            {
                reader = XmlReader.Create(App.SysPath + "\\CodeConfig.xml");
                this.strXmlData = getXmlData();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            //����հ��ļ�
            //reader.WhitespaceHandling = WhitespaceHandling.None;  
        }
        #endregion

        #region ˽�з���

        /// <summary>
        /// ��ȡXML�ļ�������
        /// </summary>
        /// <returns>����String[]</returns>
        private string[] getXmlData()
        {
            //���ﱾӦ�ÿ���52���ռ�͹��ˣ���ֹ�Ժ����XML�ڵ㣬�ʿ��ٶ�Щ�ռ�
            StringBuilder[] strValue = new StringBuilder[100];
            string[] result = new string[100];
            int i = 0;
            try
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name != "CodeConfig" && reader.Name != "SpellCode" && reader.Name != "WBCode")
                            {

                                strValue[i] = new StringBuilder();
                                strValue[i].Append(reader.Name);
                            }
                            if (reader.Name == "WBCode")
                            {
                                this.wbCodeStation = i;
                            }
                            break;
                        case XmlNodeType.Text:
                            strValue[i].Append(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name != "CodeConfig" && reader.Name != "SpellCode" && reader.Name != "WBCode")
                            {
                                result[i] = strValue[i].ToString();
                                i++;
                            }
                            if (reader.Name == "CodeConfig")
                            {
                                this.outStation = i;
                            }
                            break;
                    }
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return result;
        }

        /// <summary>
        /// ���Һ���
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="start">�����Ŀ�ʼλ��</param>
        /// <param name="end">�����Ľ���λ��</param>
        /// <returns>���ﷴ����ַ��������ַ���ֻ������д��Ӣ����ĸ</returns>
        private string searchWord(string strName, int start, int end)
        {
            strName = strName.Trim().Replace(" ", "");
            if (string.IsNullOrEmpty(strName))
            {
                return strName;
            }
            StringBuilder myStr = new StringBuilder();
            foreach (char vChar in strName)
            {
                // ������ĸ��������ֱ�����
                if ((vChar >= 'a' && vChar <= 'z') || (vChar >= 'A' && vChar <= 'Z') || (vChar >= '0' && vChar <= '9'))
                    myStr.Append(char.ToUpper(vChar));
                else
                {
                    // ���ַ�Unicode�����ڱ��뷶Χ�� �麺���б����ת�����
                    string strList = null;
                    int i;
                    for (i = start; i < end; i++)
                    {
                        strList = this.strXmlData[i];
                        if (strList.IndexOf(vChar) > 0)
                        {
                            myStr.Append(strList[0]);
                            break;
                        }
                    }
                }
            }
            return myStr.ToString();
        }

        #endregion
        #region ��������
        /// <summary>
        /// ��ú����ƴ����
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>����ƴ����,���ַ���ֻ������д��Ӣ����ĸ</returns>
        public string GetSpellCode(string strName)
        {
            return this.searchWord(strName, 0, this.wbCodeStation);
        }
        /// <summary>
        /// ��ú���������
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>���������,���ַ���ֻ������д��Ӣ����ĸ</returns>
        public string GetWBCode(string strName)
        {
            return this.searchWord(strName, this.wbCodeStation, this.outStation);
        }

        #endregion
    }
}
