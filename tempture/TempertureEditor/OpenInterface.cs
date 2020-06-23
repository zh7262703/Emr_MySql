using Bifrost;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor
{
    class OpenInterface
    {
        public static UserControl CreateFormUcTempertureCheckValSet(Form frm)
        {
            UcTempertureCheckValSet tp = new UcTempertureCheckValSet();
            tp.Dock = DockStyle.Fill;
            frm.Controls.Add(tp);
            frm.ShowDialog();
            App.UsControlStyle(tp);
            return tp;
        }

        public static void GetPaperSize(System.Drawing.Graphics g, double cx, double cy)
        {
            float dpiX = g.DpiX;        //水平dpi
            float dpiY = g.DpiY;        //垂直dpi(dpi:每英寸像素)
        }
    }
}
