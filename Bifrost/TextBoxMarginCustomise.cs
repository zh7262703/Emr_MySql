using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bifrost
{	
    /// <summary>
    /// 给TextBox加上图标
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>
	public class TextBoxMarginCustomise : NativeWindow
	{
		#region UnmanagedMethods
		[StructLayout(LayoutKind.Sequential)]
			private struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		
		[DllImport("user32", CharSet=CharSet.Auto)]
		private extern static int SendMessage(
			IntPtr hwnd, 
			int wMsg,
			int wParam, 
			int lParam);
		[DllImport("user32", CharSet=CharSet.Auto)]
		private extern static IntPtr FindWindowEx(
			IntPtr hwndParent, 
			IntPtr hwndChildAfter,
			[MarshalAs(UnmanagedType.LPTStr)]
			string lpszClass,
			[MarshalAs(UnmanagedType.LPTStr)]
			string lpszWindow);
		[DllImport("user32", CharSet=CharSet.Auto)]
		private extern static int GetWindowLong(
			IntPtr hWnd,
			int dwStyle);
		[DllImport("user32")]
		private extern static IntPtr GetDC(
			IntPtr hwnd);
		[DllImport("user32")]
		private extern static int ReleaseDC (
			IntPtr hwnd, 
			IntPtr hdc);
		[DllImport("user32")]
		private extern static int GetClientRect (
			IntPtr hwnd,
			ref RECT rc);
		[DllImport("user32")]
		private extern static int GetWindowRect (
			IntPtr hwnd,
			ref RECT rc);

		private const int EC_LEFTMARGIN = 0x1;
		private const int EC_RIGHTMARGIN = 0x2;
		private const int EC_USEFONTINFO = 0xFFFF;
		private const int EM_SETMARGINS = 0xD3;
		private const int EM_GETMARGINS = 0xD4;

		private const int WM_PAINT = 0xF;
		
		private const int WM_SETFOCUS = 0x7;
		private const int WM_KILLFOCUS = 0x8;

		private const int WM_SETFONT = 0x30;

		private const int WM_MOUSEMOVE = 0x200;
		private const int WM_LBUTTONDOWN = 0x201;
		private const int WM_RBUTTONDOWN = 0x204;
		private const int WM_MBUTTONDOWN = 0x207;
		private const int WM_LBUTTONUP = 0x202;
		private const int WM_RBUTTONUP = 0x205;
		private const int WM_MBUTTONUP = 0x208;
		private const int WM_LBUTTONDBLCLK = 0x203;
		private const int WM_RBUTTONDBLCLK = 0x206;
		private const int WM_MBUTTONDBLCLK = 0x209;

		private const int WM_KEYDOWN = 0x0100;
		private const int WM_KEYUP = 0x0101;
		private const int WM_CHAR = 0x0102;


		private const int GWL_EXSTYLE = (-20);
		private const int WS_EX_RIGHT             = 0x00001000;
		private const int WS_EX_LEFT              = 0x00000000;
		private const int WS_EX_RTLREADING        = 0x00002000;
		private const int WS_EX_LTRREADING        = 0x00000000;
		private const int WS_EX_LEFTSCROLLBAR     = 0x00004000;
		private const int WS_EX_RIGHTSCROLLBAR    = 0x00000000;

		#endregion

		#region Member Variables
		private System.Windows.Forms.ImageList imageList = null;
		private int icon = -1;
		private Control control = null;
		private ITextBoxMarginCustomisePainter customPainter = null;		
		private int customWidth = 0;
		#endregion 

		/// <summary>
		/// Gets whether a Window is <c>RightToLeft.Yes</c> from
		/// its <c>Handle</c>.
		/// </summary>
		/// <param name="handle">Handle of window to check.</param>
		/// <returns><c>True</c> if Window is RightToLeft, <c>False</c> otherwise.</returns>
		private static bool IsRightToLeft(IntPtr handle)
		{
			int style = GetWindowLong(handle, GWL_EXSTYLE);
			return (
				((style & WS_EX_RIGHT) == WS_EX_RIGHT) ||
				((style & WS_EX_RTLREADING) == WS_EX_RTLREADING) ||
				((style & WS_EX_LEFTSCROLLBAR) == WS_EX_LEFTSCROLLBAR));	
		}

		/// <summary>
		/// Gets the far margin of a TextBox control or the
		/// TextBox contained within a ComboBox.
		/// </summary>
		/// <param name="ctl">The Control to get the far margin
		/// for</param>
		/// <returns>Far margin, in pixels.</returns>
		public static int FarMargin(Control ctl)
		{
			IntPtr handle = ctl.Handle;
			if (typeof(System.Windows.Forms.ComboBox).IsAssignableFrom(ctl.GetType()))
			{
				handle = ComboEdithWnd(handle);
			}
			return FarMargin(handle);
		}
		
		private static int FarMargin(IntPtr handle)
		{
			int farMargin = SendMessage(handle, EM_GETMARGINS, 0, 0);			
			if (IsRightToLeft(handle))
			{
				farMargin = farMargin & 0xFFFF;
			}
			else
			{
				farMargin = (farMargin / 0x10000);
			}
			return farMargin;
		}


		/// <summary>
		/// Sets the far margin of a TextBox control or the
		/// TextBox contained within a ComboBox.
		/// </summary>
		/// <param name="ctl">The Control to set the far margin
		/// for</param>
		/// <param name="margin">New far margin in pixels, or -1
		/// to use the default far margin.</param>
		public static void FarMargin(Control ctl, int margin)
		{
			IntPtr handle = ctl.Handle;
			if (typeof(System.Windows.Forms.ComboBox).IsAssignableFrom(ctl.GetType()))
			{
				handle = ComboEdithWnd(handle);
			}
			FarMargin(handle, margin);
		}

		private static void FarMargin(IntPtr handle, int margin)
		{
			int message = IsRightToLeft(handle) ? EC_LEFTMARGIN : EC_RIGHTMARGIN;
			if (message == EC_LEFTMARGIN)
			{
				margin = margin & 0xFFFF;
			}
			else
			{
				margin = margin * 0x10000;
			}
			SendMessage(handle, EM_SETMARGINS, message, margin);
		}

		/// <summary>
		/// Gets the near margin of a TextBox control or the
		/// TextBox contained within a ComboBox.
		/// </summary>
		/// <param name="ctl">The Control to get the near margin
		/// for</param>
		/// <returns>Near margin, in pixels.</returns>
		public static int NearMargin(Control ctl)
		{
			IntPtr handle = ctl.Handle;
			if (typeof(System.Windows.Forms.ComboBox).IsAssignableFrom(ctl.GetType()))
			{
				handle = ComboEdithWnd(handle);
			}
			return NearMargin(handle);
		}

		private static int NearMargin(IntPtr handle)
		{
			int nearMargin = SendMessage(handle, EM_GETMARGINS, 0, 0);
			if (IsRightToLeft(handle))
			{
				nearMargin = nearMargin / 0x10000;
			}
			else
			{
				nearMargin = nearMargin & 0xFFFF;
			}		
			return nearMargin;
		}

		/// <summary>
		/// Sets the near margin of a TextBox control or the
		/// TextBox contained within a ComboBox.
		/// </summary>
		/// <param name="ctl">The Control to set the near margin
		/// for</param>
		/// <param name="margin">New near margin in pixels, or -1
		/// to use the default near margin.</param>
		public static void NearMargin(Control ctl, int margin)
		{			
			IntPtr handle = ctl.Handle;
			if (typeof(System.Windows.Forms.ComboBox).IsAssignableFrom(ctl.GetType()))
			{
				handle = ComboEdithWnd(handle);
			}
			NearMargin(handle, margin);
		}

		private static void NearMargin(IntPtr handle, int margin)
		{
			int message = IsRightToLeft(handle) ? EC_RIGHTMARGIN : EC_LEFTMARGIN;
			if (message == EC_LEFTMARGIN)
			{
				margin = margin & 0xFFFF;
			}
			else
			{
				margin = margin * 0x10000;
			}
			SendMessage(handle, EM_SETMARGINS, message, margin);
		}

		/// <summary>
		/// Gets the handle of the TextBox contained within a 
		/// ComboBox control.
		/// </summary>
		/// <param name="handle">The ComboBox window handle.</param>
		/// <returns>The handle of the contained text box.</returns>
		public static IntPtr ComboEdithWnd(IntPtr handle)
		{
			handle = FindWindowEx(handle, IntPtr.Zero, "EDIT", "\0");
			return handle;
		}

		/// <summary>
		/// Attaches an instance of this class to a ComboBox control.
		/// The control must have the "DropDown" style so it has a 
		/// TextBox.
		/// </summary>
		/// <param name="comboBox">ComboBox with DropDown style to
		/// attach to.</param>
		/// <remarks>Use the <see cref="System.Windows.Forms.NativeWindow.AssignHandle"/> method to attach 
		/// this class to an arbitrary TextBox control using its
		/// handle.</remarks>
		public void Attach(System.Windows.Forms.ComboBox comboBox)
		{
			if (!this.Handle.Equals(IntPtr.Zero))
			{
				this.ReleaseHandle();
			}
			IntPtr handle = ComboEdithWnd(comboBox.Handle);
			this.AssignHandle(handle);
			setMargin();
		}

		/// <summary>
		/// Attaches an instance of this class to a TextBox control.
		/// </summary>
		/// <param name="textBox">TextBox to attach to.</param>
		/// <remarks>Use the <see cref="System.Windows.Forms.NativeWindow.AssignHandle"/> method to attach 
		/// this class to an arbitrary TextBox control using its
		/// handle.</remarks>
		public void Attach(System.Windows.Forms.TextBox textBox)
		{
			if (!this.Handle.Equals(IntPtr.Zero))
			{
				this.ReleaseHandle();
			}
			this.AssignHandle(textBox.Handle);
			setMargin();
		}

		/// <summary>
		/// Gets/sets the ImageList used to draw icons in the control.
		/// </summary>
		public System.Windows.Forms.ImageList ImageList
		{
			get
			{
				return this.imageList;
			}
			set
			{
				this.imageList = value;
				setMargin();
			}
		}

		/// <summary>
		/// Gets/sets the 0-based icon index to draw in the control.
		/// Values &lt; 0 have special meanings. -1 erases the 
		/// icon, and &lt; -1 draws a colour sample box.
		/// </summary>
		public int Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				this.icon = value;
				setMargin();
			}
		}

		/// <summary>
		/// Gets/sets the control to be displayed in the near margin.
		/// The <see cref="ImageList"/> property must be <c>null</c> if you
		/// want to display a control.
		/// </summary>
		public System.Windows.Forms.Control Control
		{
			get
			{
				return this.control;
			}
			set
			{
				this.control = value;
				setMargin();
			}
		}
	

		/// <summary>
		/// Gets/sets a class which implements the <see cref="ITextBoxMarginCustomisePainter "/>
		/// interface to perform customised painting in the margin.
		/// The <see cref="ImageList"/> and <see cref="Control"/> properties must 
		/// be <c>null</c> if you want to use this technique.
		/// </summary>
		public ITextBoxMarginCustomisePainter CustomPainter
		{
			get
			{
				return this.customPainter;
			}
			set
			{
				this.customPainter = value;
				setMargin();
			}
		}
		

		/// <summary>
		/// Sets the near margin to accommodate the specified control.
		/// </summary>
		private void setMargin()
		{
			if (!this.Handle.Equals(IntPtr.Zero))
			{
				if (this.control != null)
				{
					NearMargin(this.Handle, this.control.Width + 4);
					moveControl();
				}
				else if (this.imageList != null)
				{
					NearMargin(this.Handle, this.imageList.ImageSize.Width + 4);
				}
				else if (this.customPainter != null)
				{
					this.customWidth = this.customPainter.GetMarginWidth();
					NearMargin(this.Handle, this.customWidth);
				}
			}
		}

		/// <summary>
		/// Moves the contained control to the appropriate 
		/// position
		/// </summary>
		private void moveControl()
		{
			if (this.control != null)
			{
				Point currentLocation = this.control.Location;
				RECT rcWindow = new RECT();
				GetWindowRect(this.Handle, ref rcWindow);
				Point moveTo = new Point(rcWindow.left + 2, 
					rcWindow.top + ((rcWindow.bottom - rcWindow.top) - this.control.Height) / 2);
				if (IsRightToLeft(this.Handle))
				{
					moveTo.X = rcWindow.right - this.control.Width - 2;
				}
				moveTo = this.control.Parent.PointToClient(moveTo);
				if (!currentLocation.Equals(moveTo))
				{
					this.control.Location = moveTo;
					this.control.BringToFront();
				}
			}
		}
			
		/// <summary>
		/// Calls the base WndProc and performs WM_PAINT
		/// processing to draw the icon if necessary.
		/// </summary>
		/// <param name="m">Windows Message</param>
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (this.control == null)
			{
				switch (m.Msg)
				{
					case WM_SETFONT:
						setMargin();
						break;
					case WM_PAINT:
						RePaint();
						break;
					case WM_SETFOCUS: 
					case WM_KILLFOCUS:
						RePaint();
						break;
					case WM_LBUTTONDOWN:
					case WM_RBUTTONDOWN:
					case WM_MBUTTONDOWN:
						RePaint();
						break;
					case WM_LBUTTONUP:
					case WM_RBUTTONUP:
					case WM_MBUTTONUP:
						RePaint();
						break;
					case WM_LBUTTONDBLCLK:
					case WM_RBUTTONDBLCLK:
					case WM_MBUTTONDBLCLK:
						RePaint();
						break;
					case WM_KEYDOWN:
					case WM_CHAR:
					case WM_KEYUP:
						RePaint();
						break;
					case WM_MOUSEMOVE:
						if (!m.WParam.Equals(IntPtr.Zero))
						{
							RePaint();
						}
						break;
				}
			}
			else
			{
				switch (m.Msg)
				{
					case WM_PAINT:
						moveControl();
						break;
				}
			}
		}

		/// <summary>
		/// Paints the control if necessary:
		/// </summary>
		private void RePaint()
		{
            try
            {
                if ((this.ImageList != null) ||
                    (this.customPainter != null))
                {
                    RECT rcClient = new RECT();
                    GetClientRect(this.Handle, ref rcClient);
                    bool rightToLeft = IsRightToLeft(this.Handle);

                    IntPtr handle = this.Handle;
                    IntPtr hdc = GetDC(handle);
                    Graphics gfx = Graphics.FromHdc(hdc);

                    if (this.customPainter == null)
                    {
                        int itemSize = this.imageList.ImageSize.Height;
                        Point pt = new Point(0, rcClient.top + (rcClient.bottom - rcClient.top - itemSize) / 2);
                        if (rightToLeft)
                        {
                            pt.X = rcClient.right - itemSize - 2;
                        }
                        else
                        {
                            pt.X = 2;
                        }
                        if (this.icon > -1)
                        {
                            gfx.SetClip(new Rectangle(pt.X, pt.Y, this.imageList.ImageSize.Width, this.imageList.ImageSize.Height - 4));
                            this.imageList.Draw(gfx, pt, icon);
                            gfx.ResetClip();
                        }
                        else
                        {
                            gfx.FillRectangle(SystemBrushes.Window, pt.X, pt.Y, this.imageList.ImageSize.Width, this.imageList.ImageSize.Height + 1);
                        }
                    }
                    else
                    {
                        Rectangle rcDraw = new Rectangle(
                            new Point(0, 0), new Size(this.customWidth, rcClient.bottom - rcClient.top));
                        this.customPainter.Draw(gfx, rcDraw, rightToLeft);
                    }

                    gfx.Dispose();
                    ReleaseDC(handle, hdc);
                }
            }
            catch
            { }
		}

		/// <summary>
		/// Constructs a new instance of this class
		/// </summary>
		public TextBoxMarginCustomise()
		{
			// intentionally blank
		}

	}

	/// <summary>
	/// An interface which users of the <see cref="TextBoxMarginCustomise"/>
	/// class can use to provide a customised painting routine for the
	/// margin area.  Create an instance of this class and install it
	/// using the <see cref="TextBoxMarginCustomise.CustomPainter"/>
	/// accessor.
	/// </summary>
	public interface ITextBoxMarginCustomisePainter
	{
		/// <summary>
		/// Called to obtain the width of the margin.
		/// </summary>
		/// <returns>Width of the margin</returns>
		int GetMarginWidth();

		/// <summary>
		/// Called whenever the margin area needs to
		/// be repainted.
		/// </summary>
		/// <param name="gfx">Graphics object to paint on.</param>
		/// <param name="rcDraw">Boundary of margin area.</param>
		/// <param name="rightToLeft">Whether the control is right 
		/// to left or not</param>
		void Draw(Graphics gfx, Rectangle rcDraw, bool rightToLeft);
	}
}
