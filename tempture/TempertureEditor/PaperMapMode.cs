using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor
{
    class PaperMapMode
    {

        private Control _con = null;
        private double _dScale = 1.0;        //缩放比例

        public double DScale
        {
            get
            {
                return _dScale;
            }

            set
            {
                _dScale = value;
            }
        }

        public PaperMapMode(Control con)
        {
            _con = con;
        }
        /*
        // 当前比例尺下,每丝米(DMM)多少个像素, 逻辑-->设备
        void CMapModePaper::GetScreenPixPerLogic(OUT double& cxLogPixPerDMM, OUT double& cyLogPixPerDMM) const
        {

    CClientDC dc(m_pWnd);

        int cxLogPixPerInch = dc.GetDeviceCaps(LOGPIXELSX);
        int cyLogPixPerInch = dc.GetDeviceCaps(LOGPIXELSY);

        // 每0.1毫米多少个像素
        cxLogPixPerDMM = cxLogPixPerInch / 254.0 * m_dScale;
	cyLogPixPerDMM = cyLogPixPerInch / 254.0 * m_dScale;
}
*/
    // 设备坐标 --> 逻辑坐标
    public Point? ScreenToLogic(Point pt)
        {
            if (_con == null)
                return null;

            Graphics g = _con.CreateGraphics();

            float dpiX = g.DpiX;        //水平dpi
            float dpiY = g.DpiY;        //垂直dpi(dpi:每英寸像素)

            // 每丝米多少个像素(1丝米＝0.1毫米)
            double cxLogPixPerDMM = dpiX / 254.0;
            double cyLogPixPerDMM = dpiY / 254.0;

            int x = (int)(pt.X / cxLogPixPerDMM / _dScale);
            int y = (int)(pt.Y / cyLogPixPerDMM / _dScale);

            return new Point(x, y);
        }

    }
}
