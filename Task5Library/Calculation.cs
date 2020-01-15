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
            do
            {
                Console.Clear();
                Console.WriteLine($"Creation of a new Task.");

                tasks.Add(new Task());

                Console.WriteLine($"{Environment.NewLine}Do you want to create another Task?");
            } while (EnumHelper.RequestForEnumValue<YesNo>() == YesNo.Yes);
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

            do
            {
                Console.Clear();
                Console.WriteLine($"Displaying Tasks by selected Priority.{Environment.NewLine}");
                inputPriority = EnumHelper.RequestForEnumValue<Priority>();

                List<Task> selectedTasks = tasks.Where(x => x.Priority == inputPriority).ToList();

                foreach (Task task in selectedTasks)
                {
                    if (task.Priority == inputPriority)
                    {
                        Console.WriteLine($"{Environment.NewLine}Priority: {task.Priority}");
                        Console.WriteLine($"Complexity: {task.Complexity}");
                        Console.WriteLine($"Description: {task.Description}");
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Do you want to see the Tasks of another Priority?");
            } while (EnumHelper.RequestForEnumValue<YesNo>() == YesNo.Yes);
        }

        public void PrintTasksCompleteInEnteredDays()
        {
            int inputHours = 0;

            tasks = tasks.OrderBy(x => x.Priority).ToList();

            do
            {
                Console.Clear();
                Console.WriteLine($"Please enter number of days. You will see the Tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                inputHours = Convert.ToInt32(Validation.GetValidDays()) * Constants.WorkingHoursPerDay;

                foreach (Task task in tasks)
                {
                    if (inputHours >= EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity))
                    {
                        inputHours -= EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity);
                        Console.WriteLine($"{Environment.NewLine}Priority: {task.Priority}");
                        Console.WriteLine($"Complexity: {task.Complexity}");
                        Console.WriteLine($"Description: {task.Description}");
                    }

                    if (inputHours == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Do you want to enter another number of days?");
            } while (EnumHelper.RequestForEnumValue<YesNo>() == YesNo.Yes);
        }
    }
}