using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Remoting服务端
{
    public partial class frmPortSet : Form
    {
        private string Regeditstr = "";  //当前注册码

        public frmPortSet()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {            

            try
            {
                frmRemotingServer.Port = Convert.ToInt32(textBox1.Text);
                this.Close();
            }
            catch
            {
                MessageBox.Show("信息提示", "请输入数值类型！");
                this.textBox1.Text = "9999";
            }
        }

        private void frmPortSet_Load(object sender, EventArgs e)
        {
            txtCpuId.Text=frmRemotingServer.GetCpuID();
            Regeditstr = frmRemotingServer.regiestCode;
            if (Regeditstr != "" && Regeditstr != null)
            {
                this.txtRegsit.Text = Regeditstr;
                this.txtRegsit.ReadOnly = true;
                this.btnRegist.Visible = false;
                this.lblRegist.Text = "已注册！";
                label5.Visible = false;
            }
            else
            {
                this.txtRegsit.Text = "";
                this.txtRegsit.ReadOnly = false;
                this.btnRegist.Visible = true;
                this.lblRegist.Text = "未注册！";
                label5.Visible = true;
                label5.Text ="未注册版的试用天数为100天！" +frmRemotingServer.showinfo;
            }

            frmRemotingServer.RemotingType = "tcp";
        }

        private void frmPortSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmRemotingServer.Port == 0)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegist_Click(object sender, EventArgs e)
        {
            string nowkey=frmRemotingServer.Encrypt(txtCpuId.Text);
            if (txtRegsit.Text != nowkey)
            {
                MessageBox.Show("注册码不正确！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

               
                string str1= File.ReadAllText(frmRemotingServer.filename);
                File.WriteAllText(frmRemotingServer.filename, str1+txtRegsit.Text);
                frmRemotingServer.regiestCode = txtRegsit.Text;
                //MessageBox.Show("注册成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblRegist.Text = "已注册！";
                btnRegist.Visible = false;
                label5.Visible = false;
                txtRegsit.ReadOnly = true;

                if (frmRemotingServer.showinfo.Contains("过期"))
                {
                    MessageBox.Show("软件已经过期，注册之后需要重新开启！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Restart();
                }
            }

        }

        private void chkHttp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHttp.Checked)
            {
                frmRemotingServer.RemotingType = "http";
            }
            else
            {
                frmRemotingServer.RemotingType = "tcp";
            }
        }
    }
}