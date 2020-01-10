using System;

namespace Task5Library
{
    public class Validation
    {
        private string _inputValue;

        public string GetValidPriority()
        {
            bool validValue = false;
            _inputValue = GetValueNotNullOrEmpty("Priority");

            while (!validValue)
            {
                foreach (string s in Enum.GetNames(typeof(Priority)))
                {
                    if (_inputValue.ToLower() == s.ToLower())
                    {
                        return s;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Please select priority:");
                PrintAllPriorities();

                _inputValue = GetValueNotNullOrEmpty("Priority");
            }
            return _inputValue;
        }

        public string GetValidComplexity()
        {
            bool validValue = false;
            _inputValue = GetValueNotNullOrEmpty("Complexity");

            while (!validValue)
            {
                foreach (string s in Enum.GetNames(typeof(Complexity)))
                {
                    if (_inputValue.ToLower() == s.ToLower())
                    {
                        return s;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Please select complexity for a new task:");
                PrintAllComplexities();

                _inputValue = GetValueNotNullOrEmpty("Complexity");
            }
            return _inputValue;
        }

        public bool GetValidYesNo(string parameter)
        {
            _inputValue = GetValueNotNullOrEmpty("Another" + parameter);

            while (_inputValue.ToLower() != "yes" && _inputValue.ToLower() != "no")
            {
                Console.Clear();

                if (parameter == "Task")
                {
                    Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Do you want to enter another task: Yes/No");
                }

                if (parameter == "Priority")
                {
                    Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Do you want to see the tasks of another priority: Yes/No");
                }

                if (parameter == "Days")
                {
                    Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Do you want to enter another number of days: Yes/No");
                }

                _inputValue = GetValueNotNullOrEmpty("Another" + parameter);
            }

            if (_inputValue.ToLower() == "yes")
            {
                return true;
            }

            return false;
        }

        public string GetValidDays()
        {
            _inputValue = GetValueNotNullOrEmpty("Days");

            while (!int.TryParse(_inputValue, out int validatedValue) || validatedValue <= 0)
            {
                Console.Clear();

                Console.WriteLine($"Entered value is invalid.{Environment.NewLine}Please enter number of days. You will see the tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                _inputValue = GetValueNotNullOrEmpty("Days");
            }
            return _inputValue;
        }

        public string GetValueNotNullOrEmpty(string parameter)
        {
            var inputValue = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(inputValue))
            {
                Console.Clear();

                if (parameter == "Priority")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please select priority:");
                    PrintAllPriorities();
                }

                if (parameter == "Complexity")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please select complexity for a new task:");
                    PrintAllComplexities();
                }

                if (parameter == "Description")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please enter description for a new task:");
                }

                if (parameter == "AnotherTask")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Do you want to enter another task: Yes/No");
                }

                if (parameter == "AnotherPriority")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Do you want to see the tasks of another priority: Yes/No");
                }

                if (parameter == "Days")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Please enter number of days. You will see the tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                }

                if (parameter == "AnotherDays")
                {
                    Console.WriteLine($"Entered value is null or empty.{Environment.NewLine}Do you want to enter another number of days: Yes/No");
                }

                inputValue = Console.ReadLine();
            }
            return inputValue;
        }

        public void PrintAllPriorities()
        {
            foreach (string s in Enum.GetNames(typeof(Priority)))
            {
                Console.Write("{0}   ", s);
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public void PrintAllComplexities()
        {
            foreach (string s in Enum.GetNames(typeof(Complexity)))
            {
                Console.Write("{0}   ", s);
            }
            Console.WriteLine($"{Environment.NewLine}");
        }
    }
}