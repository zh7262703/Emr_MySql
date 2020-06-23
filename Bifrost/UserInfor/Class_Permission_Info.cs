using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// �˵���ϸ��Ϣ����
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Permission_Info
    {
        private int id;

        private string perm_code; 

        private string dllname;

        private byte[] dll;

        private string function;

        private byte[] functionImage;

        private string version;

        private string ismainfrom;
       

        /// <summary>
        /// ����
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Ȩ�޵Ĵ���
        /// </summary>
        public string Perm_code
        {
            get { return perm_code; }
            set { perm_code = value; }
        }

        /// <summary>
        /// ��̬��������
        /// </summary>
        public string DllName
        {
            get { return dllname; }
            set { dllname = value; }
        }

        /// <summary>
        /// ��̬���
        /// </summary>
        public byte[] Dll
        {
            get { return dll; }
            set { dll = value; }
        }

        /// <summary>
        /// ���ܺ�������
        /// </summary>
        public string Function
        {
            set { function = value;}
            get { return function;}
        }

        /// <summary>
        /// ͼ��
        /// </summary>
        public byte[] FunctionImage
        {
            set { functionImage = value; }
            get { return functionImage; }
        }

        /// <summary>
        /// �汾��
        /// </summary>
        public string Version
        {
            set { version = value; }
            get { return version; }
        }

        /// <summary>
        /// �Ƿ��������� 0�� 1��
        /// </summary>
        public string Ismainfrom
        {
            get { return ismainfrom; }
            set { ismainfrom = value; }
        }
    }
}
