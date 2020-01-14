using System;
using System.Text;
using System.Reflection;

namespace Task5Library
{
    public class EnumHelper
    {
        public string PrintEnumDefinition<TEnum>() where TEnum : struct
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Environment.NewLine}Select {typeof(TEnum).Name}:");
            for (int index = 1; index < Enum.GetValues(typeof(TEnum)).Length + 1; index++)
            {
                sb.AppendLine($"{index}. {Enum.GetName(typeof(TEnum), index)}");
            }
            return sb.ToString();
        }

        public TEnum RequestForEnumValue<TEnum>() where TEnum : struct
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

        public int GetEnumValueAttribute<TEnum>(Enum value) where TEnum : struct
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            EnumValueAttribute attribute = (EnumValueAttribute)fi.GetCustomAttribute(typeof(EnumValueAttribute), false);
            return attribute.EnumValue;
        }
    }
}