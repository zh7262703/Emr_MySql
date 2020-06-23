using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Base_Function.BASE_COMMON
{
    public class UserRights
    {
        /// <summary>
        /// 判断是否有相关全限
        /// </summary>
        /// <param name="btnrole">需要判断的权限</param>
        /// <param name="buttonRights">操作权限集合</param>
        /// <returns></returns>
        public bool isExistRole(string btnrole, ArrayList buttonRights)
        {
            for (int i = 0; i < buttonRights.Count; i++)
            {
                if (buttonRights[i].ToString().Trim() == btnrole)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
