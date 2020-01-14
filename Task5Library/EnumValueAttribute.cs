using System;
using System.Reflection;


namespace Task5Library
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(int value)
        {
            EnumValue = value;
        }

        public int EnumValue { get; }

        public int GetEnumValueAttribute<TEnum>(Enum value) where TEnum : struct
        {
            // Get the EnumValue attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            EnumValueAttribute attribute = (EnumValueAttribute)fi.GetCustomAttribute(typeof(EnumValueAttribute), false);
            return attribute.EnumValue;
        }
    }
}