using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Util
{
    public class EnumHelper
    {
        public static T ConvertEnum<T>(string vStr) where T : struct
        {
            return EnumHelper.ConvertEnum<T>(vStr, default(T));
        }

        public static T ConvertEnum<T>(string vStr, T vDefault) where T : struct
        {
            T result = vDefault;
            try
            {
                if (!StringHelper.IsEmpty(vStr))
                {
                    result = (T)(Enum.Parse(typeof(T), vStr, false));
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        public static object ConvertEnum(Type vType, string vStr)
        {
            return ConvertEnum(vType, vStr, 0);
        }

        public static object ConvertEnum(Type vType, string vStr, object vDefault)
        {
            object result = vDefault;
            try
            {
                if (!StringHelper.IsEmpty(vStr))
                {
                    result = Enum.Parse(vType, vStr, false);
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
