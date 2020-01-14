using System;
using System.Collections.Generic;

namespace Task5Library
{
    public class Calculation
    {
        List<Task> tasks = new List<Task>();

        Validation validation = new Validation();

        EnumHelper enumHelper = new EnumHelper();

        //EnumValueAttribute enumValueAttribute = new EnumValueAttribute(_enumValue);

        public void RecordInputTasksAndPrintExecutionTime()
        {
            int counter = 0;
            int executionTime = 0;
            Priority inputPriority;
            Complexity inputComplexity;
            string inputDescription;
            bool wantProceed = true;

            while (wantProceed)
            {
                Console.Clear();
                Console.WriteLine($"Creation of a new Task.{Environment.NewLine}");
                inputPriority = enumHelper.RequestForEnumValue<Priority>();

                inputComplexity = enumHelper.RequestForEnumValue<Complexity>();

                Console.WriteLine($"{Environment.NewLine}Enter Description:");
                inputDescription = validation.GetValueNotNullOrEmpty("Description");

                Console.WriteLine($"{Environment.NewLine}Do you want to create another Task: Yes/No");
                wantProceed = validation.GetValidYesNo("Task");

                EnumValueAttribute enumValueAttribute = new EnumValueAttribute(Convert.ToInt32(inputComplexity));

                executionTime += EnumValueAttribute.GetEnumValueAttribute<Complexity>(inputComplexity);

                counter++;

                tasks.Add(new Task() { TaskID = counter, PriorityID = Convert.ToInt32(inputPriority), Priority = inputPriority, Complexity = inputComplexity, Description = inputDescription });
            }

            Console.Clear();
            Console.WriteLine($"{executionTime} hours are needed to complete all Tasks.{Environment.NewLine}");
        }

        public void PrintTasksByPriority()
        {
            Priority inputPriority;
            bool wantProceed = true;

            while (wantProceed)
            {
                Console.Clear();
                Console.WriteLine($"Displaying Tasks by selected Priority.{Environment.NewLine}");
                inputPriority = enumHelper.RequestForEnumValue<Priority>();

                foreach (Task tTask in tasks)
                {
                    if (tTask.Priority == inputPriority)
                    {
                        Console.WriteLine($"{Environment.NewLine}{tTask.PriorityID}Priority: {tTask.Priority}{Environment.NewLine}Complexity: {tTask.Complexity}{Environment.NewLine}Description: {tTask.Description}");
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Do you want to see the Tasks of another Priority: Yes/No");
                wantProceed = validation.GetValidYesNo("Priority");
            }
        }

        public void PrintTasksCompleteInEnteredDays()
        {
            int inputHours = 0;
            bool wantProceed = true;

            tasks.Sort((x, y) => x.PriorityID.CompareTo(y.PriorityID));

            while (wantProceed)
            {
                Console.Clear();
                Console.WriteLine($"Please enter number of days. You will see the Tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                inputHours = Convert.ToInt32(validation.GetValidDays()) * Constants.WorkingHoursPerDay;

                foreach (Task tTask in tasks)
                {
                    if (tTask.Complexity == Enum.GetName(typeof(Complexity), 4) && inputHours >= Convert.ToInt32(Complexity.Hard))
                    {
                        inputHours -= Convert.ToInt32(Complexity.Hard);
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.Priority}{Environment.NewLine}Complexity: {tTask.Complexity}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (tTask.Complexity == Enum.GetName(typeof(Complexity), 2) && inputHours >= Convert.ToInt32(Complexity.Medium))
                    {
                        inputHours -= Convert.ToInt32(Complexity.Medium);
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.Priority}{Environment.NewLine}Complexity: {tTask.Complexity}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (tTask.Complexity == Enum.GetName(typeof(Complexity), 1) && inputHours >= Convert.ToInt32(Complexity.Simple))
                    {
                        inputHours -= Convert.ToInt32(Complexity.Simple);
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.Priority}{Environment.NewLine}Complexity: {tTask.Complexity}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (inputHours == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Do you want to enter another number of days: Yes/No");
                wantProceed = validation.GetValidYesNo("Days");
            }
        }
    }
}