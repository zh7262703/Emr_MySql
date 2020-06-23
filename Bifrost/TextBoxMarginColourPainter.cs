using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bifrost
{
    /// <summary>
    /// IP地址专用输入框
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>
	public class TextBoxMarginColourPainter : ITextBoxMarginCustomisePainter
	{

		private Color color = Color.FromKnownColor(KnownColor.Control);

        /// <summary>
        /// 颜色
        /// </summary>
		public System.Drawing.Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
			}
		}

		/// <summary>
		/// Called to obtain the width of the margin.
		/// </summary>
		/// <returns>Width of the margin</returns>
		public int GetMarginWidth()
		{
			return 18;
		}

		/// <summary>
		/// Called whenever the margin area needs to
		/// be repainted.
		/// </summary>
		/// <param name="gfx">Graphics object to paint on.</param>
		/// <param name="rcDraw">Boundary of margin area.</param>
		/// <param name="rightToLeft">Whether the control is right to left 
		/// or not</param>
		public void Draw(Graphics gfx, Rectangle rcDraw, bool rightToLeft)
		{
			Rectangle rcColor = new Rectangle(
				rcDraw.Location, rcDraw.Size);
			rcColor.X += 2;
			rcColor.Y += (rcColor.Height - 14) / 2;
			rcColor.Width = 14;
			rcColor.Height = 14;

			Brush br = new SolidBrush(this.color);
			gfx.FillRectangle(br, rcColor);
			br.Dispose();
			gfx.DrawRectangle(SystemPens.Highlight, rcColor);

		}

		/// <summary>
		/// Constructs a new instance of this class with the specified
		/// colour.
		/// </summary>
		/// <param name="color">Colour to draw</param>
		public TextBoxMarginColourPainter(Color color)
		{
			this.color = color;
		}
	}
}
