using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Digital_Medical_Treatment
{
    public class pnlCustom : Panel
    {
        public int CheckCount()
        {
            int count = 0;
            if (this.Enabled)
            {
                foreach (CheckBox item in this.Controls)
                {
                    if (item.Checked)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
