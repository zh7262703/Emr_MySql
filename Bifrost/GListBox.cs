using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Bifrost
{
    public class GListBox : ListBox
    {
        private ImageList _myImageList;
        public ImageList ImageList
        { get { return _myImageList; } 
            set { _myImageList = value; } 
        }
        public GListBox() 
        { this.DrawMode = DrawMode.OwnerDrawFixed; }
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            GListBoxItem item;
            Rectangle bounds = e.Bounds;
            try
            {
              
                Size imageSize = _myImageList.ImageSize;
                item = (GListBoxItem)Items[e.Index];
                if (item.ImageIndex != -1)
                {
                    ImageList.Draw(e.Graphics, bounds.Left, bounds.Top-2, item.ImageIndex);
                    e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor), bounds.Left + imageSize.Width, bounds.Top+2);
                }
                else
                { e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor), bounds.Left, bounds.Top + 2); }
            }
            catch
            {
                if (Items.Count > 0)
                {
                    if (e.Index != -1)
                    {
                        e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), bounds.Left, bounds.Top + 2);
                    }
                    else
                    {
                        e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), bounds.Left, bounds.Top + 2);
                    }
                }
            }
            base.OnDrawItem(e);
        }
    }
    
}
