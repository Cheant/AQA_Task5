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
    }
}