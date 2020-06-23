using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace Base_Function.BASE_COMMON
{
    public class TemperPrintView : IDisposable
    {
        private ArrayList gdiObject = new ArrayList();
        private Graphics _graph;
        StringFormat format = StringFormat.GenericTypographic;
        public Graphics Graph
        {
            get { return _graph; }
            set { _graph = value; }
        }

        #region IDisposable ≥…‘±
        public void Dispose()
        {

        }
        #endregion

        public void drawText(string text, string fontName, float fontSize,bool isBold,Color brushColor, int x, int y)
        {
            this.Graph.DrawString(text, GetFont(fontName, fontSize, isBold), GetSolidBrush(brushColor), x, y, format);
        }

        public void drawText(string text, Font font, Brush brush, int x, int y)
        {
            this.Graph.DrawString(text, font, brush, x, y, format);
        }

        public void drawText(string text, Font font, Brush brush, int maxWidth,int x ,int y)
        {
            SizeF size = this.Graph.MeasureString(text, font, 1000, format);
            int newX = Convert.ToInt32((maxWidth - size.Width) / 2) + x;
            this.Graph.DrawString(text, font, brush, newX, y, format);
        }

        public void drawLine(Pen pen,int startX,int startY,int endX,int endY)
        {
        //    this.Graph.DrawLine();
        }

        public Pen GetPen(Color color, float penWidth)
        {
            foreach (object var in this.gdiObject)
            {
                if (var is Pen)
                {
                    Pen pen = (Pen)var;
                    if (pen.Color == color && pen.Width == penWidth)
                    {
                        return pen;
                    }
                }
            }
            Pen newPen = new Pen(color, penWidth);
            this.gdiObject.Add(newPen);
            return newPen;
        }

        public Font GetFont(string fontName, float fontSize, bool isBold)
        {
            foreach (object _font in this.gdiObject)
            {
                if (_font is Font)
                {
                    Font font = (Font)_font;
                    if (font.Name == fontName && font.Size == fontSize && font.Bold == isBold)
                    {
                        return font;
                    }
                }
            }
            Font newFont = new Font(fontName, fontSize, isBold ? FontStyle.Bold : FontStyle.Regular);
            this.gdiObject.Add(newFont);
            return newFont;
        }

        private Brush GetSolidBrush(Color color)
        {
            foreach (object var in gdiObject)
            {
                if (var is SolidBrush)
                {
                    SolidBrush brush = (SolidBrush)var;
                    if (brush.Color == color)
                    {
                        return brush;
                    }
                }
            }
            SolidBrush newBrush = new SolidBrush(color);
            this.gdiObject.Add(newBrush);
            return newBrush;
        }
    }
}