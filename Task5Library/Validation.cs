using System;

namespace Task5Library
{
    public class Validation
    {
        public static string GetValidDescription()
        {
            Console.WriteLine($"{Environment.NewLine}Enter Description:");

            var inputValue = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(inputValue))
            {
                Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Enter Description:");
                inputValue = Console.ReadLine();
            }
            return inputValue;
        }

        public static string GetValidDays()
        {
            string inputValue = GetValueNotNullOrEmpty();

            while (!int.TryParse(inputValue, out int validatedValue) || validatedValue <= 0)
            {
                Console.Clear();
                Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Please enter number of days. You will see the Tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                inputValue = GetValueNotNullOrEmpty();
            }
            return inputValue;
        }

        public static string GetValueNotNullOrEmpty()
        {
            var inputValue = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(inputValue))
            {
                Console.Clear();
                Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please enter number of days. You will see the Tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                inputValue = Console.ReadLine();
            }
            return inputValue;
        }
    }
}