using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task5Library
{
    class Validation
    {
        private string _inputValue;

        public string GetValidValueThreeOptions(string parameter)
        {
            _inputValue = GetValueNotNullOrEmpty(parameter);

            while (!Regex.IsMatch(_inputValue, @"[1-3]") || !char.TryParse(_inputValue, out char result))
            {
                Console.Clear();

                if (parameter == Constants.textSelectPriority)
                {
                    Console.WriteLine($"{Constants.textInvalidValue}{Environment.NewLine}{Constants.textSelectPriority}");
                    _inputValue = GetValueNotNullOrEmpty(parameter);
                }

                if (parameter == Constants.textSelectComplexity)
                {
                    Console.WriteLine($"{Constants.textInvalidValue}{Environment.NewLine}{Constants.textSelectComplexity}");
                    _inputValue = GetValueNotNullOrEmpty(parameter);
                }

                if (parameter == Constants.textTasksByPriority)
                {
                    Console.WriteLine($"{Constants.textInvalidValue}{Environment.NewLine}{Constants.textTasksByPriority}");
                    _inputValue = GetValueNotNullOrEmpty(parameter);
                }
            }
            return _inputValue;
        }

        public string GetValidValueTwoOptions(string parameter)
        {
            _inputValue = GetValueNotNullOrEmpty(parameter);

            while (!Regex.IsMatch(_inputValue, @"[1-2]") || !char.TryParse(_inputValue, out char result))
            {
                Console.Clear();

                if (parameter == Constants.textAnotherTask)
                {
                    Console.WriteLine($"{Constants.textInvalidValue}{Environment.NewLine}{Constants.textAnotherTask}");
                    _inputValue = GetValueNotNullOrEmpty(parameter);
                }

                if (parameter == Constants.textAnotherPriority)
                {
                    Console.WriteLine($"{Constants.textInvalidValue}{Environment.NewLine}{Constants.textAnotherPriority}");
                    _inputValue = GetValueNotNullOrEmpty(parameter);
                }

                if (parameter == Constants.textAnotherDays)
                {
                    Console.WriteLine($"{Constants.textInvalidValue}{Environment.NewLine}{Constants.textAnotherDays}");
                    _inputValue = GetValueNotNullOrEmpty(parameter);
                }
            }
            return _inputValue;
        }

        public string GetValidDays(string parameter)
        {
            _inputValue = GetValueNotNullOrEmpty(parameter);

            while (!int.TryParse(_inputValue, out int validatedValue) || validatedValue <= 0)
            {
                Console.Clear();

                Console.WriteLine($"{Constants.textInvalidValue}{Environment.NewLine}{parameter}");
                _inputValue = GetValueNotNullOrEmpty(parameter);
            }
            return _inputValue;
        }

        public string GetValueNotNullOrEmpty(string parameter)
        {
            var inputValue = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(inputValue))
            {
                Console.Clear();

                if (parameter == Constants.textSelectPriority)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textSelectPriority}");
                    inputValue = Console.ReadLine();
                }

                if (parameter == Constants.textSelectComplexity)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textSelectComplexity}");
                    inputValue = Console.ReadLine();
                }

                if (parameter == Constants.textEnterDescription)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textEnterDescription}");
                    inputValue = Console.ReadLine();
                }

                if (parameter == Constants.textAnotherTask)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textAnotherTask}");
                    inputValue = Console.ReadLine();
                }

                if (parameter == Constants.textTasksByPriority)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textTasksByPriority}");
                    inputValue = Console.ReadLine();
                }

                if (parameter == Constants.textAnotherPriority)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textAnotherPriority}");
                    inputValue = Console.ReadLine();
                }

                if (parameter == Constants.textEnterDays)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textEnterDays}");
                    inputValue = Console.ReadLine();
                }

                if (parameter == Constants.textAnotherDays)
                {
                    Console.WriteLine($"{Constants.textNullEmpty}{Environment.NewLine}{Constants.textAnotherDays}");
                    inputValue = Console.ReadLine();
                }
            }
            return Convert.ToString(inputValue);
        }
    }
}
