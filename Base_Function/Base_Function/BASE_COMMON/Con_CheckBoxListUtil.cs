using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar.Controls;

namespace Base_Function.BASE_COMMON
{
    /// <summary>
    /// 操作多个复选框
    /// </summary>
    public class Con_CheckBoxListUtil
    {
        /// <summary>
        /// 如果列表中有的，根据内容勾选GroupBox里面的成员
        /// </summary>
        /// <param name="group">包含CheckBox控件组的GroupBox控件</param>
        /// <param name="valueList">逗号分隔的值列表</param>
        public static void SetCheck(GroupPanel group, string valueList)
        {
            string[] strtemp = valueList.Split(',');
            foreach (string str in strtemp)
            {
                foreach (Control control in group.Controls)
                {
                    CheckBox chk = control as CheckBox;
                    if (chk != null && chk.Text == str)
                    {
                        chk.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// 获取GroupBox控件成员勾选的值
        /// </summary>
        /// <param name="group">包含CheckBox控件组的GroupBox控件</param>
        /// <returns>返回逗号分隔的值列表</returns>
        public static string GetCheckedItems(GroupPanel group)
        {
            string resultList = "";
            foreach (Control control in group.Controls)
            {
                CheckBox chk = control as CheckBox;
                if (chk != null && chk.Checked)
                {
                    resultList += string.Format("{0},", chk.Text);
                }
            }
            return resultList.Trim(',');
        }

        /// <summary>
        /// 如果值列表中有的，根据内容勾选CheckedListBox的成员
        /// </summary>
        /// <param name="cblItems">CheckedListBox控件</param>
        /// <param name="valueList">逗号分隔的值列表</param>
        public static void SetCheck(CheckedListBox cblItems, string valueList)
        {
            string[] strtemp = valueList.Split(',');
            foreach (string str in strtemp)
            {
                for (int i = 0; i < cblItems.Items.Count; i++)
                {                    
                    if(cblItems.GetItemText(cblItems.Items[i])==str)
                    {
                        cblItems.SetItemChecked(i, true);                       
                        //CheckBox checkBox=cblItems.Items[i] as CheckBox;                       
                        //checkBox.ForeColor = System.Drawing.Color.Red;                        
                    }
                }               
            }
        }

        /// <summary>
        /// 获取CheckedListBox控件成员勾选的值
        /// </summary>
        /// <param name="cblItems">CheckedListBox控件</param>
        /// <returns>返回逗号分隔的值列表</returns>
        public static string GetCheckedItems(CheckedListBox cblItems)
        {
            string resultList = "";
            for (int i = 0; i < cblItems.CheckedItems.Count; i++)
            {
                //if (cblItems.GetItemChecked(i))
                //{
                //resultList += string.Format("{0},", cblItems.GetItemText(cblItems.CheckedItems[i]));
                //}
                resultList += string.Format("{0},", ((Class_Sections)cblItems.CheckedItems[i]).Sid);
            }
            return resultList.Trim(',');

         

        }

        /// <summary>
        /// 获得选中项的文本Text
        /// </summary>
        /// <param name="cblItems"></param>
        /// <returns></returns>
        public static string GetCheckedItemsValue(CheckedListBox cblItems)
        {
            string resultList = "";
            for (int i = 0; i < cblItems.CheckedItems.Count; i++)
            {              
                
                resultList += string.Format("{0},", cblItems.GetItemText(cblItems.CheckedItems[i]));
            }
            return resultList.Trim(',');

        }


        /// <summary>
        /// 移除被选中项
        /// </summary>
        /// <param name="cblItems"></param>
        public static void RemoveExitItems(CheckedListBox cblItems)
        {
            for (int i = 0; i < cblItems.CheckedItems.Count; i++)
            {
                cblItems.Items.Remove(cblItems.CheckedItems[i]);
            }
            
        }




    }
}
