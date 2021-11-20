using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Structure
{
    public static class Helper
    {
        public static DateTime Time0 = DateTime.Parse("01.01.1900 00:00:00");
        public static DateTime Time = DateTime.Parse("01.01.1900 00:00:00");
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] mem_info = type.GetMember(en.ToString());

            if (mem_info != null && mem_info.Length > 0)
            {
                object[] attrs = mem_info[0].GetCustomAttributes(
                                              typeof(DescriptionAttribute),
                                              false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
        public static string GetTime()
        {
            return $"Time is {Time.ToString("HH:mm")}";
        }
    }
}
