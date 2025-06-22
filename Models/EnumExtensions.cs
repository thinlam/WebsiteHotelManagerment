using System;
using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var attr = enumValue.GetType()
            .GetField(enumValue.ToString())
            .GetCustomAttribute<DescriptionAttribute>();

        return attr == null ? enumValue.ToString() : attr.Description;
    }
}
