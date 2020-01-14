using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5Library
{
    public class Calculation
    {
        List<Task> tasks = new List<Task>();

        public void RecordInputTasks()
        {
            string wantProceed = nameof(YesNo.Yes);

            while (wantProceed == nameof(YesNo.Yes))
            {
                Console.Clear();
                Console.WriteLine($"Creation of a new Task.");

                tasks.Add(new Task());

                Console.WriteLine($"{Environment.NewLine}Do you want to create another Task?");
                wantProceed = EnumHelper.RequestForEnumValue<YesNo>().ToString();
            }
        }

        public void PrintExecutionTimeForAllTasks()
        {
            int executionTime = 0;

            foreach (Task task in tasks)
            {
                executionTime += EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity);
            }

            Console.Clear();
            Console.WriteLine($"{executionTime} hours are needed to complete all Tasks.{Environment.NewLine}");
            Console.ReadKey();
        }

        public void PrintTasksByPriority()
        {
            Priority inputPriority;
            string wantProceed = nameof(YesNo.Yes);

            while (wantProceed == nameof(YesNo.Yes))
            {
                Console.Clear();
                Console.WriteLine($"Displaying Tasks by selected Priority.{Environment.NewLine}");
                inputPriority = EnumHelper.RequestForEnumValue<Priority>();

                foreach (Task task in tasks)
                {
                    if (task.Priority == inputPriority)
                    {
                        Console.WriteLine($"{Environment.NewLine}Priority: {task.Priority}{Environment.NewLine}Complexity: {task.Complexity}{Environment.NewLine}Description: {task.Description}");
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Do you want to see the Tasks of another Priority?");
                wantProceed = EnumHelper.RequestForEnumValue<YesNo>().ToString();
            }
        }

        public void PrintTasksCompleteInEnteredDays()
        {
            int inputHours = 0;
            string wantProceed = nameof(YesNo.Yes);

            tasks = tasks.OrderBy(x => x.Priority).ToList();

            while (wantProceed == nameof(YesNo.Yes))
            {
                Console.Clear();
                Console.WriteLine($"Please enter number of days. You will see the Tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                inputHours = Convert.ToInt32(Validation.GetValidDays()) * Constants.WorkingHoursPerDay;

                foreach (Task task in tasks)
                {
                    if (inputHours >= EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity))
                    {
                        inputHours -= EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity);
                        Console.WriteLine($"{Environment.NewLine}Priority: {task.Priority}{Environment.NewLine}Complexity: {task.Complexity}{Environment.NewLine}Description: {task.Description}");
                    }

                    if (inputHours == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Do you want to enter another number of days?");
                wantProceed = EnumHelper.RequestForEnumValue<YesNo>().ToString();
            }
        }
    }
}