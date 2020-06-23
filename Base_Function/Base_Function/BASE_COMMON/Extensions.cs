using System.Collections.Generic;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR.Patient_Action_Manager;
using Bifrost;
using System.Linq;

namespace Base_Function
{
    internal static class Extensions
    {

        /// <summary>
        /// 将患者集合添加到Node的子节点中去
        /// </summary>
        /// <param name="patients"></param>
        /// <param name="parent"></param>
        //internal static void PatientsToNodes(this IEnumerable<InPatientInfo> patients, DevComponents.AdvTree.Node parent)
        //{
        //    if (patients != null)
        //    {
        //        DataInit.AddNodesFromPatients(parent, patients);
        //    }
        //}

        /// <summary>
        /// style是否包含style2
        /// </summary>
        /// <param name="style"></param>
        /// <param name="style2"></param>
        /// <returns></returns>
        //internal static bool Contains(this PatientViewStyle style, PatientViewStyle style2)
        //{
        //    bool res = false;
        //    if (style == PatientViewStyle.All)
        //    {
        //        res = true;
        //    }
        //    else
        //    {
        //        res = style == style2;
        //    }
        //    return res;
        //}

        /// <summary>
        /// 将字符串按指定字符数组分割
        /// 取第select个不为空的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="chars"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        internal static string SplitAndSelect(this string str, char[] chars, int select)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            else
            {
                var strs = str.Split(chars);
                if (strs != null)
                {
                    strs = strs.Where(o => !string.IsNullOrEmpty(o)).ToArray();
                    if (strs.Length >= select)
                    {
                        return strs[select - 1];
                    }
                    return "";
                }
                return "";
            }
        }

    }
}