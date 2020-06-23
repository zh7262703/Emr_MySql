using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    /// <summary>
    /// ��Ϣ�ظ�
    /// �����ߣ���Ρ��
    /// ����ʱ�䣺2013-04-28
    /// </summary>
    public partial class frmMsgReplay : DevComponents.DotNetBar.Office2007Form
    {
        string msgIds = "";
        /// <summary>
        /// ������־
        /// ���ͳɹ�Ϊtrue 
        /// ����ʧ�ܻ��ߵ�ȡ��Ϊfalse
        /// </summary>
        public bool flag = false;
        public frmMsgReplay()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��Ϣ�ظ�
        /// </summary>
        /// <param name="msgIds">ҽ��ѡ�е���Ϣ��Id�����Ÿ���</param>
        public frmMsgReplay(string msgIds)
        {
            InitializeComponent();
            this.msgIds = msgIds;
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMsgReplay_Load(object sender, EventArgs e)
        {
            txtReplyMsg.Focus();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtReplyMsg.Text == "")
            {
                App.Msg("�ظ����ݲ���Ϊ�գ�");
                return;
            }
            if (getStringLength(txtReplyMsg.Text) > 50)
            {
                App.Msg("�ظ����ݲ��ܳ���50���֣�");
                return;
            }
            string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate,reply_flag='�ѻظ�',reply_msg='" + txtReplyMsg.Text + "' where id in(" + msgIds + ")";
            int num = App.ExecuteSQL(update);
            if (num > 0)
            {
                App.Msg("���ͳɹ���");
                flag = true;
                this.Close();
            }
            else
            {
                App.Msg("����ʧ�ܣ�");
            }
        }

        /// <summary>
        /// ��ȡ��Ӣ�Ļ����ַ�����ʵ�ʳ���(�ֽ���)
        /// </summary>
        /// <param name="str">Ҫ��ȡ���ȵ��ַ���</param>
        /// <returns>�ַ�����ʵ�ʳ���ֵ���ֽ�����</returns>
        public int getStringLength(string str)
        {
            if (str.Equals(string.Empty))
                return 0;
            int strlen = 0;
            ASCIIEncoding strData = new ASCIIEncoding();
            //���ַ���ת��ΪASCII������ֽ�����
            byte[] strBytes = strData.GetBytes(str);
            for (int i = 0; i <= strBytes.Length - 1; i++)
            {
                if (strBytes[i] == 63)  //���Ķ�������ΪASCII����63,��"?"��
                    strlen++;
                strlen++;
            }
            return strlen;
        }
    }
}