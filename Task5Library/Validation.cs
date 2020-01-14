using System;

namespace Task5Library
{
    public class Validation
    {
        private string _inputValue;

        public bool GetValidYesNo(string parameter)
        {
            do
            {
                _inputValue = GetValueNotNullOrEmpty("Another" + parameter);
                Console.Clear();

                if (parameter == "Task")
                {
                    Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Do you want to create another Task: Yes/No");
                }

                else if (parameter == "Priority")
                {
                    Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Do you want to see the Tasks of another Priority: Yes/No");
                }

                else
                {
                    Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Do you want to enter another number of days: Yes/No");
                }
            } while (_inputValue.ToLower() != "yes" && _inputValue.ToLower() != "no");

            if (_inputValue.ToLower() == "yes")
            {
                return true;
            }
            return false;
        }

        public string GetValidDays()
        {
            do
            {
                _inputValue = GetValueNotNullOrEmpty("Days");
                Console.Clear();

                Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Please enter number of days. You will see the Tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
            } while (!int.TryParse(_inputValue, out int validatedValue) || validatedValue <= 0);

            return _inputValue;
        }

        public string GetValueNotNullOrEmpty(string parameter)
        {
            var inputValue = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(inputValue))
            {
                Console.Clear();

                if (parameter == "Description")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Enter Description:");
                }

                else if (parameter == "AnotherTask")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Do you want to create another Task: Yes/No");
                }

                else if (parameter == "AnotherPriority")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Do you want to see the Tasks of another Priority: Yes/No");
                }

                else if (parameter == "Days")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please enter number of days. You will see the Tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                }

                else
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Do you want to enter another number of days: Yes/No");
                }

                inputValue = Console.ReadLine();
            }
            return inputValue;
        }
    }
}