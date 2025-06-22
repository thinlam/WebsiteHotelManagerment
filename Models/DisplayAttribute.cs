using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteHotelManagerment.Models
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(Enum enumValue)
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DisplayAttribute)attrs[0]).Name;
            }
            return enumValue.ToString();
        }
    }
}
