using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.Speech
{
    public partial class frmLearn : Form
    {
        private string CurrentStrVal = "";
        private SRecognition sr;
        public frmLearn()
        {
            InitializeComponent();
            Ini();
            if (!File.Exists(Application.StartupPath + "\\SpeechData.dt"))
            {
                File.CreateText(Application.StartupPath + "\\SpeechData.dt");                    
            }
            txtNew.Focus();

        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        private void Ini()
        {
            string[] SpeechDatas = { "1", "2" };
            CurrentStrVal = ReadSpeechData();
            if (CurrentStrVal.Trim() != "")
            {
                //获取已经学习的内容
                SpeechDatas = CurrentStrVal.Split(',');              
            }
            sr = new SRecognition(SpeechDatas);
            txtNew.Focus();
        }

        public string ReadSpeechData()
        {
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath+ "\\SpeechData.dt", Encoding.Default);
                string val = "";
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    val = val + line.ToString();
                }
                sr.Close();
                return val;

            }
            catch
            {
                return "";
            }
        }

        public void WriteSpeechData()
        {            
            FileStream fs = new FileStream(Application.StartupPath + "\\SpeechData.dt", FileMode.Open);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(CurrentStrVal);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        public void startSpeech()
        {
            txtOld.Text = "";
            txtNew.Text = "";
            sr.over();
            Ini();
            sr.BeginRec();
            txtOld.Text = App.SpeechStr;
            btnStart.Enabled = false;
            btnOver.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startSpeech();
        }



        private void btnReSet_Click(object sender, EventArgs e)
        {
            txtOld.Text = "";
            txtNew.Text = "";
            sr.over();
            Ini();

        }

        private void btnOver_Click(object sender, EventArgs e)
        {            
            sr.over();          
            btnStart.Enabled = true;
            btnOver.Enabled = false;
            txtNew.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNew.Text.Trim() != "")
            {
                if(CurrentStrVal!="")
                   CurrentStrVal = CurrentStrVal + "," + txtNew.Text.Trim();
                else                
                    CurrentStrVal = txtNew.Text.Trim();
                WriteSpeechData();
                MessageBox.Show("操作成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReSet_Click(sender, e);
            }
            else
                MessageBox.Show("请输入需要调整的文字内容!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtNew.Focus();
        }

        private void txtOld_TextChanged(object sender, EventArgs e)
        {
            txtNew.Text = txtOld.Text;
            txtNew.Focus();
        }

        private void txtNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (btnStart.Enabled)
                {
                    startSpeech();
                }
                else
                {
                    btnStart.Enabled = true;
                    btnOver.Enabled = false;
                    sr.over();                  
                }
            }
        }

        private void frmLearn_Load(object sender, EventArgs e)
        {
            txtNew.Focus();
        }

        private void frmLearn_Activated(object sender, EventArgs e)
        {
            txtNew.Focus();
        }
    }
}
