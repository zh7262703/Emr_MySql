using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   /// <summary>
   /// ������Ϣ
   /// </summary>
   public class Class_SickRoomInfo
    {
        private int srid;
     
        private int said;
   
        private int sick_room_code;
     
        private int bedlevel;
    
        private string org_prop;
    
        private string sex_ctrl;
     
        private string sex_flag;
    
        private string enableflag;

        /// <summary>
        /// ����ID
        /// </summary>
        public int Srid
        {
            get { return srid; }
            set { srid = value; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int Said
        {
            get { return said; }
            set { said = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int Sick_room_code
        {
            get { return sick_room_code; }
            set { sick_room_code = value; }
        }
        /// <summary>
        /// �ȼ�
        /// </summary>
        public int Bedlevel
        {
            get { return bedlevel; }
            set { bedlevel = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Org_prop
        {
            get { return org_prop; }
            set { org_prop = value; }
        }
        /// <summary>
        /// �Ա���Ʊ�־
        /// </summary>
        public string Sex_ctrl
        {
            get { return sex_ctrl; }
            set { sex_ctrl = value; }
        }
        /// <summary>
        /// �Ա�(��ǰ)
        /// </summary>
        public string Sex_flag
        {
            get { return sex_flag; }
            set { sex_flag = value; }
        }
        /// <summary>
        /// ��Ч��־
        /// </summary>
        public string Enableflag
        {
            get { return enableflag; }
            set { enableflag = value; }
        }
    }
}
