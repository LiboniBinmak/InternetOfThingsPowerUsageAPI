using System;
using System.Linq;
using System.Reflection;

namespace InternetOfThingsPowerUsageAPI.Enums
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            if (value == null) throw new ArgumentNullException("value");
            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) description = attributes[0].Description;
            return description;
        }
        public static int GetValueOf(string enumName, string enumConst)
        {
            Type enumType = Type.GetType(enumName);
            if (enumType == null)
            {
                throw new ArgumentException("Specified enum type could not be found", "enumName");
            }
            object value = Enum.Parse(enumType, enumConst);
            return Convert.ToInt32(value);
        }

        public static T GetValueFromDescription<T>(this string description)
        {
            Type type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (FieldInfo field in type.GetFields())
            {
                EnumDescriptionAttribute[] attribute = field.GetCustomAttributes(
                                                           typeof(EnumDescriptionAttribute)) as EnumDescriptionAttribute[];
                if (attribute != null && attribute.Any())
                {
                    if (attribute[0].Description.Equals(description))
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name.Equals(description))
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
        }
    }
}
