using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net; 

namespace Bifrost.SYSTEMSET
{
    public partial class ucServerLinkShow : UserControl
    {
        public ucServerLinkShow()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {                
                this.richTextBox1.Text = App.ReceiveServerMsg;
                listView1.Items.Clear();
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    ListViewItem temp = new ListViewItem();
                    temp.ImageIndex = 0;
                    temp.Text = richTextBox1.Lines[i].ToString().Split('!')[0].ToString();
                    listView1.Items.Add(temp);
                }
                if (this.richTextBox1.Text == "")
                {
                    lblCount.Text = "当前登录系统的客户端和帐号数量为：0";
                }
                else
                {
                    lblCount.Text = "当前登录系统的客户端和帐号数量为：" + this.richTextBox1.Lines.Length.ToString();
                }
            }
            catch
            { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                listView1.View = View.List;
            }
            else
            {
                listView1.View = View.LargeIcon;
            }
        }
    }
}
