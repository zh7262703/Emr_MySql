using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 
    /// </summary>
    public class Class_Follow_Patients
    {
        private int id; 

        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    
        private int tid; //ģ��ID

        /// <summary>
        /// ģ��ID
        /// </summary>
        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }
        private string tName; //ģ������

        /// <summary>
        /// ģ������
        /// </summary>
        public string TName
        {
            get { return tName; }
            set { tName = value; }
        }
        private string shortcut; //�����

        /// <summary>
        /// �����
        /// </summary>
        public string Shortcut
        {
            get { return shortcut; }
            set { shortcut = value; }
        }
        private string textKind; //��������

        /// <summary>
        /// ��������
        /// </summary>
        public string TextKind
        {
            get { return textKind; }
            set { textKind = value; }
        }
        private char tempPlate_Level; //����

        /// <summary>
        /// ����(P-���� S-���� H-ȫԺ)
        /// </summary>
        public char TempPlate_Level
        {
            get { return tempPlate_Level; }
            set { tempPlate_Level = value; }
        }
        private char sex; //�Ա�

        /// <summary>
        /// �Ա�(0-�У�1Ů)
        /// </summary>
        public char Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private int ages; //�����
        
        /// <summary>
        /// �����(Ӥ������ͯ�����ꡢ���ꡢ����)
        /// </summary>
        public int Ages
        {
            get { return ages; }
            set { ages = value; }
        }
        private string section_ID; //����ID

        /// <summary>
        /// ����ID
        /// </summary>
        public string Section_ID
        {
            get { return section_ID; }
            set { section_ID = value; }
        }
        private int sickArea_ID; //����ID

        /// <summary>
        /// ����ID
        /// </summary>
        public int SickArea_ID
        {
            get { return sickArea_ID; }
            set { sickArea_ID = value; }
        }
        private int creator_ID; //������ID

        /// <summary>
        /// ������ID
        /// </summary>
        public int Creator_ID
        {
            get { return creator_ID; }
            set { creator_ID = value; }
        }
        private string create_Time; //����ʱ��

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string Create_Time
        {
            get { return create_Time; }
            set { create_Time = value; }
        }
        private int updater_ID; //�޸���ID

        /// <summary>
        /// �޸���ID
        /// </summary>
        public int Updater_ID
        {
            get { return updater_ID; }
            set { updater_ID = value; }
        }
        private string update_Time; //�޸�ʱ��

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public string Update_Time
        {
            get { return update_Time; }
            set { update_Time = value; }
        }
        private int verify_ID1; //�Ƽ������ID

        /// <summary>
        /// �Ƽ������ID
        /// </summary>
        public int Verify_ID1
        {
            get { return verify_ID1; }
            set { verify_ID1 = value; }
        }
        private string verify_Time1; //�Ƽ����ʱ��

        /// <summary>
        /// �Ƽ����ʱ��
        /// </summary>
        public string Verify_Time1
        {
            get { return verify_Time1; }
            set { verify_Time1 = value; }
        }
        private int verify_ID2; //Ժ�������ID

        /// <summary>
        /// Ժ�������ID
        /// </summary>
        public int Verify_ID2
        {
            get { return verify_ID2; }
            set { verify_ID2 = value; }
        }
        private string verify_Time2; //Ժ�����ʱ��

        /// <summary>
        /// Ժ�����ʱ��
        /// </summary>
        public string Verify_Time2
        {
            get { return verify_Time2; }
            set { verify_Time2 = value; }
        }
        private int verify_Sign; //��˱�־

        /// <summary>
        /// ��˱�־
        /// </summary>
        public int Verify_Sign
        {
            get { return verify_Sign; }
            set { verify_Sign = value; }
        }
        private char isDiag; //�Ƿ������

        /// <summary>
        /// �Ƿ������
        /// </summary>
        public char IsDiag
        {
            get { return isDiag; }
            set { isDiag = value; }
        }
        private char enable_Flag; //��Ч��־

        /// <summary>
        /// ��Ч��־
        /// </summary>
        public char Enable_Flag
        {
            get { return enable_Flag; }
            set { enable_Flag = value; }
        }

        /// <summary>
        /// Ĭ�ϱ�־
        /// </summary>
        private char isDefault;

        public char IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }
      
        /// <summary>
        /// ����ģ���־
        /// </summary>
        private string default_sec_id;

        public string Default_sec_id
        {
            get { return default_sec_id; }
            set { default_sec_id = value; }
        }
        /// <summary>
        /// �����ߵ����
        /// </summary>
        private string creator_Role;

        public string Creator_Role
        {
            get { return creator_Role; }
            set { creator_Role = value; }
        }      

    }
}
