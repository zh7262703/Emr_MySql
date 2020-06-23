using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BASE_COMMON
{
    /// <summary>
    /// 判断容器中控件的值
    /// </summary>
    public class Con_ClearCntrValue
    {
     
        /// <summary>
        /// 清空容器类某些控件的值
        /// </summary>
        /// <param name="parContainer">容器类控件</param>
        /// <param name="flag">用于判断是否可用</param>
        public static void ClearCntrValue(Control parContainer,bool flag)
        {
            for (int index = 0; index < parContainer.Controls.Count; index++)
            {
                //如果是容器类控件，递归调用自己
                if (parContainer.Controls[index].HasChildren)
                {
                    ClearCntrValue(parContainer.Controls[index],flag);

                    if (parContainer.Controls[index].Text == "执行时间点")
                    {
                        ClearCntrValue(parContainer.Controls[index], false);
                    } 
                }
                else
                {
                    switch(parContainer.Controls[index].GetType().Name)
                    {
                        case "TextBox":
                            parContainer.Controls[index].Text="";
                            break;

                        case "RadioButton":
                            ((RadioButton)(parContainer.Controls[index])).Checked=false;
                            
                            //if(flag)
                                ((RadioButton)(parContainer.Controls[index])).Enabled = flag;
                            break;

                        case "CheckBox":
                            ((CheckBox)(parContainer.Controls[index])).Checked=false;
                            //if (flag)
                            ((CheckBox)(parContainer.Controls[index])).Enabled = flag;
                            break;

                        case "ComboBox":
                            ((ComboBox)(parContainer.Controls[index])).SelectedIndex=0;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 容器类某些控件的值不能为空
        /// </summary>
        /// <param name="parContainer">容器类控件</param>
        /// <param name="flag">用于判断是否可用</param>
        public static bool IsNotNull(Control parContainer)
        {
            bool flag = false;
            for (int index = 0; index < parContainer.Controls.Count; index++)
            {
                //如果是容器类控件，递归调用自己
                if (parContainer.Controls[index].HasChildren)
                {
                    IsNotNull(parContainer.Controls[index]);
                }
                else
                {
                    switch (parContainer.Controls[index].GetType().Name)
                    {
                        case "TextBox":
                            if (parContainer.Controls[index].Text == "" || parContainer.Controls[index].Text == null)
                            {
                                flag = true;                           
                               
                            }
                            break;                        
                    }
                }
            }
            if (flag)
            {
                MessageBox.Show("文本框不能为空，请输入值，默认为0", "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            return flag;
        }
    }
}
