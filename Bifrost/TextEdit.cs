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
    /// 简单文本编辑器
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>
    public partial class TextEdit : UserControl
    {    
        /// <summary>
        /// 文本内容
        /// </summary>
        public string ValText
        {
            get { return rtxtEdit.Text; }
            set { rtxtEdit.Text = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TextEdit()
        {
            InitializeComponent();

            foreach (FontFamily family in FontFamily.Families)
            {
                toolStripComboBoxName.Items.Add(family.Name);
            }

            toolStripComboBoxSize.Items.AddRange(FontSize.All.ToArray());
        }

        private void TextEdit_Load(object sender, EventArgs e)
        {
            //工具栏
            foreach (FontFamily family in FontFamily.Families)
            {
                toolStripComboBoxName.Items.Add(family.Name);
            }

            toolStripComboBoxSize.Items.AddRange(FontSize.All.ToArray());
        }

        /// <summary>
        /// 设置字体颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();            
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {                         
                rtxtEdit.SelectionColor = dialog.Color;
                rtxtEdit.Focus();
            }
        }

        /// <summary>
        /// 粗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            if (rtxtEdit.SelectionFont != null)
            {
                Font oldFont, newFont;
                oldFont = rtxtEdit.SelectionFont;
                if (oldFont.Bold)
                {
                    newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Bold);
                }
                else
                {
                    newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
                }
                rtxtEdit.SelectionFont = newFont;
                rtxtEdit.Focus();
            }
        }

        /// <summary>
        /// 斜体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            if (rtxtEdit.SelectionFont != null)
            {
                Font oldFont, newFont;
                oldFont = rtxtEdit.SelectionFont;
                if (oldFont.Italic)
                {
                    newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Italic);
                }
                else
                {
                    newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
                }
                rtxtEdit.SelectionFont = newFont;
                rtxtEdit.Focus();
            }
        }

        /// <summary>
        /// 下划线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {            
            if (rtxtEdit.SelectionFont != null)
            {
                Font oldFont, newFont;
                oldFont = rtxtEdit.SelectionFont;
                if (oldFont.Underline)
                {
                    newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Underline);
                }
                else
                {
                    newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
                }
                rtxtEdit.SelectionFont = newFont;
                rtxtEdit.Focus();
            }
        }

        private void toolStripComboBoxName_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripComboBoxSize_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtxtEdit.SelectionFont != null && toolStripComboBoxSize.Text.Trim() != "")
            {
                Font oldFont = rtxtEdit.SelectionFont;
                rtxtEdit.SelectionFont = new Font(oldFont.FontFamily.Name, Convert.ToSingle(toolStripComboBoxSize.Text), Font.Style);
                rtxtEdit.Focus();
            }
        }

        private void toolStripComboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtxtEdit.SelectionFont != null && toolStripComboBoxName.Text.Trim() != "")
            {
                Font oldFont = rtxtEdit.SelectionFont;
                rtxtEdit.SelectionFont = new Font(toolStripComboBoxName.Text, oldFont.Size, Font.Style);
                rtxtEdit.Focus();
            }
        }

        private void toolStripButtonLeft_Click(object sender, EventArgs e)
        {         
            rtxtEdit.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButtonCenter_Click(object sender, EventArgs e)
        {
            rtxtEdit.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButtonRight_Click(object sender, EventArgs e)
        {
            rtxtEdit.SelectionAlignment = HorizontalAlignment.Right;
        }
    }

    /// <summary>
    /// 字体大小
    /// </summary>
    public class FontSize
    {
        private static List<FontSize> allFontSize = null;
        public static List<FontSize> All
        {
            get
            {
                if (allFontSize == null)
                {
                    allFontSize = new List<FontSize>();
                    allFontSize.Add(new FontSize(8, 1));
                    allFontSize.Add(new FontSize(10, 2));
                    allFontSize.Add(new FontSize(12, 3));
                    allFontSize.Add(new FontSize(14, 4));
                    allFontSize.Add(new FontSize(18, 5));
                    allFontSize.Add(new FontSize(24, 6));
                    allFontSize.Add(new FontSize(36, 7));
                }
                return allFontSize;
            }
        }

        public static FontSize Find(int value)
        {
            if (value < 1)
            {
                return All[0];
            }

            if (value > 7)
            {
                return All[6];
            }
            return All[value - 1];
        }

        private FontSize(int display, int value)
        {
            displaySize = display;
            valueSize = value;
        }
        private int valueSize;
        public int Value
        {
            get
            {
                return valueSize;
            }
        }
        private int displaySize;
        public int Display
        {
            get
            {
                return displaySize;
            }
        }
        public override string ToString()
        {
            return displaySize.ToString();
        }
    }
}
