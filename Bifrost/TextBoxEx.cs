using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    public class TextBoxEx : TextBox
    {
        private const int WM_PAINT = 0x000F;

        private string backGroundText = "";
        private Image _icon;

        [Description("BackGround Text")]
        public string BackGroundText
        {
            get { return backGroundText; }
            set { backGroundText = value; }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                using (Graphics g = CreateGraphics())
                {
                    if (string.IsNullOrEmpty(Text) && !Focused)
                    {
                        SizeF size = g.MeasureString(backGroundText, Font);
                        //draw background text
                        g.DrawString(backGroundText, Font, Brushes.LightGray, new PointF(0, (Height - size.Height) / 2));
                    }
                }
            }
        }
    }
}
