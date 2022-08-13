using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

#nullable disable

namespace PhoneBook.Core.Extensions
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
           where TAttribute : Attribute
        {
            var attribute = enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
            return attribute;
        }

        public static string GetDisplayName(this Enum constant)
        {
            var dispName = constant.ToString();
            var dn = constant.GetAttribute<DisplayAttribute>();
            if (dn != null)
                dispName = dn.Name;

            return dispName;
        }

        public static int ToInt32(this Enum constant)
        {
            return Convert.ToInt32(constant);
        }
    }

}
