using System;
using System.Text;
using System.Reflection;

namespace Task5Library
{
    public class EnumHelper
    {
        public static string PrintEnumDefinition<TEnum>() where TEnum : struct
        {
            StringBuilder sb = new StringBuilder();

            if (typeof(TEnum).Name == typeof(YesNo).Name)
            {
                sb.AppendLine($"Please select:");
            }
            else
            {
                sb.AppendLine($"{Environment.NewLine}Please select {typeof(TEnum).Name}:");
            }

            for (int index = 1; index < Enum.GetValues(typeof(TEnum)).Length + 1; index++)
            {
                sb.AppendLine($"{index}. {Enum.GetName(typeof(TEnum), index)}");
            }
            return sb.ToString();
        }

        public static TEnum RequestForEnumValue<TEnum>() where TEnum : struct
        {
            TEnum result;
            bool parseResult;
            do
            {
                Console.WriteLine(PrintEnumDefinition<TEnum>());

                string _pr = Console.ReadLine();
                parseResult = Enum.TryParse(_pr, ignoreCase: true, result: out result)
                    & Enum.IsDefined(typeof(TEnum), result);

                if (!parseResult)
                {
                    Console.WriteLine($"{Environment.NewLine}Entered value is invalid.");
                }
            } while (!parseResult);
            return result;
        }

        public static int GetEnumValueAttribute<TEnum>(Enum value) where TEnum : struct
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            EnumValueAttribute attribute = (EnumValueAttribute)fi.GetCustomAttribute(typeof(EnumValueAttribute), false);
            return attribute.EnumValue;
        }
    }
}