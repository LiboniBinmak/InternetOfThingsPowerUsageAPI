using System;

namespace InternetOfThingsPowerUsageAPI.Enums
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class EnumDescriptionAttribute : Attribute
    {
        public EnumDescriptionAttribute(string description) : base() => Description = description;

        public string Description { get; }
    }
}
