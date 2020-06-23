using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Text.RegularExpressions;

namespace Base_Function.BASE_COMMON
{
    /// <summary>
    /// 判断
    /// </summary>
    public class Con_Regex
    {
        static string _Float = "^[0-9]+(.[0-9][1])]?$";


        public static void IsNumberForKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8&&e.KeyChar!='.')
            {
                App.MsgErr("只能输入数字！");
                e.Handled = true;
                return;
            }

        }

        public static void IsFloatNumberForKeyPress(string mathString)
        {
            if (!Regex.IsMatch(mathString, _Float)) //文本内容是不是数字
            {
                App.MsgErr("只能输入数字！");
                return;
            }
        }
    }
}
