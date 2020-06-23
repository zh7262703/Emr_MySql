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
    /// 消息回复
    /// 创建者：吕巍林
    /// 创建时间：2013-04-28
    /// </summary>
    public partial class frmMsgReplay : DevComponents.DotNetBar.Office2007Form
    {
        string msgIds = "";
        /// <summary>
        /// 操作标志
        /// 发送成功为true 
        /// 发送失败或者点取消为false
        /// </summary>
        public bool flag = false;
        public frmMsgReplay()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 消息回复
        /// </summary>
        /// <param name="msgIds">医生选中的消息的Id，逗号隔开</param>
        public frmMsgReplay(string msgIds)
        {
            InitializeComponent();
            this.msgIds = msgIds;
        }

        /// <summary>
        /// 取消
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
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtReplyMsg.Text == "")
            {
                App.Msg("回复内容不能为空！");
                return;
            }
            if (getStringLength(txtReplyMsg.Text) > 50)
            {
                App.Msg("回复内容不能超过50个字！");
                return;
            }
            string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate,reply_flag='已回复',reply_msg='" + txtReplyMsg.Text + "' where id in(" + msgIds + ")";
            int num = App.ExecuteSQL(update);
            if (num > 0)
            {
                App.Msg("发送成功！");
                flag = true;
                this.Close();
            }
            else
            {
                App.Msg("发送失败！");
            }
        }

        /// <summary>
        /// 获取中英文混排字符串的实际长度(字节数)
        /// </summary>
        /// <param name="str">要获取长度的字符串</param>
        /// <returns>字符串的实际长度值（字节数）</returns>
        public int getStringLength(string str)
        {
            if (str.Equals(string.Empty))
                return 0;
            int strlen = 0;
            ASCIIEncoding strData = new ASCIIEncoding();
            //将字符串转换为ASCII编码的字节数字
            byte[] strBytes = strData.GetBytes(str);
            for (int i = 0; i <= strBytes.Length - 1; i++)
            {
                if (strBytes[i] == 63)  //中文都将编码为ASCII编码63,即"?"号
                    strlen++;
                strlen++;
            }
            return strlen;
        }
    }
}