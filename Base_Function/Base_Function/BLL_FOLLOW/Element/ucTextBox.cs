using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class ucTextBox : UserControl
    {
        private int width;


        public ucTextBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 插入ucElement控件
        /// </summary>
        /// <param name="user"></param>
        public void createUser(ucElement user)
        {
            for (int i = 0; i < panel_content.Controls.Count; i++)
            {
                ucElement temp = (ucElement)panel_content.Controls[i];
                if (user.Flagid == temp.Flagid)
                {
                    App.Msg("控件已存在");
                    return;
                }

            }
            if (panel_content.Controls.Count > 0)
            {
                user.Left = panel_content.Controls[panel_content.Controls.Count - 1].Left + panel_content.Controls[panel_content.Controls.Count - 1].Width;
            }
            else
                user.Left = panel_content.Location.X;

            user.Top = panel_content.Location.Y;
            user.Height = panel_content.Height;
            panel_content.Controls.Add(user);


        }
        public void reArrangment()
        {
            for (int i = 0; i < panel_content.Controls.Count; i++)
            {
                ucElement temp = (ucElement)panel_content.Controls[i];
                if (i == 0)
                    temp.Left = panel_content.Location.X;
                else
                    temp.Left = panel_content.Controls[i- 1].Left + panel_content.Controls[i - 1].Width;
            }
        }
        /// <summary>
        /// 释放ucElement控件
        /// </summary>
        public void disposeElement()
        {
            for (int i = 0; i < panel_content.Controls.Count; i++)
            {
                ucElement temp = (ucElement)panel_content.Controls[i];
                temp.Dispose();

            }            
        }
        /// <summary>
        /// 获取控件实际宽度
        /// </summary>
        /// <param name="w"></param>
        public void setWidth(int w)
        {
            width = w;
        }


        /// <summary>
        /// 返回所有插入实例的ID
        /// </summary>
        /// <returns></returns>
        public string GetIds()
        {
            try
            {
                //List<string> ids = new List<string>();
                string ids="";
                for (int i = 0; i < panel_content.Controls.Count; i++)
                {
                    if (i != 0)
                    {
                        ucElement temp = (ucElement)panel_content.Controls[i];
                        ids = ids + "," + temp.Flagid;
                    }
                    else
                    {
                        ucElement temp = (ucElement)panel_content.Controls[i];
                        ids = temp.Flagid;
                    }

                }
                return ids;
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 左移按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            int count = panel_content.Controls.Count;
            if (count != 0)
            {
                if (panel_content.Controls[count - 1].Left + panel_content.Controls[count - 1].Width > panel_content.Location.X + this.width)
                {
                    for (int i = 0; i < count; i++)
                    {
                        panel_content.Controls[i].Left -= 5;
                    }
                }
            }
        }
        /// <summary>
        /// 右移按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            int count = panel_content.Controls.Count;
            if (count != 0)
            {
                if (panel_content.Controls[0].Left < panel_content.Location.X)
                {
                    for (int i = 0; i < count; i++)
                    {
                        panel_content.Controls[i].Left += 5;
                    }
                }
            }
        }

        private void panel_content_ControlRemoved(object sender, ControlEventArgs e)
        {
            reArrangment();
        }
    }
}
