using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Base_Function.BASE_COMMON
{
    public class UserRights
    {
        /// <summary>
        /// �ж��Ƿ������ȫ��
        /// </summary>
        /// <param name="btnrole">��Ҫ�жϵ�Ȩ��</param>
        /// <param name="buttonRights">����Ȩ�޼���</param>
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
