using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    /// <summary>
    /// 密码验证模块
    /// 作者：张华
    /// 日期:2012-6-5
    /// </summary>
    public partial class ucPasswordStrongCheck : UserControl
    {
        public ucPasswordStrongCheck()
        {
            InitializeComponent();
        }

        private int ClientSideStrongPassword(string value)
        {
            int num = 0;
            if (value.Trim().Length == 0)
            {
                return num;
            }
            if (value.Length > 0 && value.Length < 8)
            {
                num = 1;
            }

            if (value.Length >= 8 && value.Length <= 16)
            {
                num = 2;
            }

            if (value.Length > 16)
            {
                num = 4;
            }

            string chr = "";
            string valstr = @"!@#$%^&*()_+-='\" + @";:[{]}\|.>,</?`~";
            for (int i = 0; i < value.Length; i++)
            {
                chr = value.Substring(i, 1);

                if (valstr.IndexOf(chr) >= 0)
                {
                    ++num;
                    break;
                }
            }

            return num;
        }             

        /// <summary>
        /// 刷新密码状态
        /// </summary>
        /// <param name="Password"></param>
        public void RefleshState(string Password)
        {
            progressBarX1.Value = ClientSideStrongPassword(Password);
            if (progressBarX1.Value <= 1)
            {                
                lblPassWordLevel.Text = "弱";
                progressBarX1.ChunkColor = Color.Red;
                progressBarX1.ChunkColor2 = Color.Red;
            }
            else if (progressBarX1.Value == 2)
            {
                lblPassWordLevel.Text = "中";
                progressBarX1.ChunkColor = Color.Orange;
                progressBarX1.ChunkColor2 = Color.Orange;
            }
            else if (progressBarX1.Value >= 3)
            {
                lblPassWordLevel.Text = "强";
                progressBarX1.ChunkColor = Color.Green;
                progressBarX1.ChunkColor2 = Color.Green;
            }
        }
    }
}
