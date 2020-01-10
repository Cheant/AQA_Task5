using System;
using System.Collections.Generic;

namespace Task5Library
{
    public class Calculation
    {
        List<Task> tasks = new List<Task>();

        Validation validation = new Validation();

        public void RecordInputTasksAndPrintExecutionTime()
        {
            int counter = 0;
            int executionTime = 0;
            int inputPriorityID = 1;
            string inputPriority;
            string inputComplexity;
            string inputDescription;
            bool wantProceed = true;

            while (wantProceed)
            {
                Console.Clear();
                Console.WriteLine($"Please select priority for a new task:");
                validation.PrintAllPriorities();
                inputPriority = validation.GetValidPriority();

                Console.WriteLine($"{Environment.NewLine}Please select number of complexity for a new task:");
                validation.PrintAllComplexities();
                inputComplexity = validation.GetValidComplexity();

                Console.WriteLine($"{Environment.NewLine}Please enter description for a new task:");
                inputDescription = validation.GetValueNotNullOrEmpty("Description");

                Console.WriteLine($"{Environment.NewLine}Do you want to enter another task: Yes/No");
                wantProceed = validation.GetValidYesNo("Task");

                switch (inputPriority)
                {
                    case "High":
                        inputPriorityID = Convert.ToInt32(Priority.High);
                        break;
                    case "Medium":
                        inputPriorityID = Convert.ToInt32(Priority.Medium);
                        break;
                    case "Low":
                        inputPriorityID = Convert.ToInt32(Priority.Low);
                        break;
                }

                switch (inputComplexity)
                {
                    case "Hard":
                        executionTime += Convert.ToInt32(Complexity.Hard);
                        break;
                    case "Medium":
                        executionTime += Convert.ToInt32(Complexity.Medium);
                        break;
                    case "Simple":
                        executionTime += Convert.ToInt32(Complexity.Simple);
                        break;
                }

                counter++;

                tasks.Add(new Task() { TaskID = counter, PriorityID = inputPriorityID, PriorityName = inputPriority, ComplexityName = inputComplexity, Description = inputDescription });
            }

            Console.Clear();
            Console.WriteLine($"{executionTime} hours are needed to complete all tasks.{Environment.NewLine}");
        }

        public void PrintTasksByPriority()
        {
            string inputPriority;
            bool wantProceed = true;

            while (wantProceed)
            {
                Console.Clear();
                Console.WriteLine($"Please select number of priority to see all tasks with such priority:");
                validation.PrintAllPriorities();
                inputPriority = validation.GetValidPriority();

                foreach (Task tTask in tasks)
                {
                    if (tTask.PriorityName.ToLower() == inputPriority.ToLower())
                    {
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.PriorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Do you want to see the tasks of another priority: Yes/No");
                wantProceed = validation.GetValidYesNo("Priority");
            }
        }

        public void PrintTasksCompleteInEnteredDays()
        {
            int inputHours = 0;
            string inputDays;
            bool wantProceed = true;

            tasks.Sort((x, y) => x.PriorityID.CompareTo(y.PriorityID));

            while (wantProceed)
            {
                Console.Clear();
                Console.WriteLine($"Please enter number of days. You will see the tasks that can be completed in a given number of days ({Constants.WorkingHoursPerDay} working hours per day).");
                inputDays = validation.GetValidDays();
                inputHours = Convert.ToInt32(inputDays) * Constants.WorkingHoursPerDay;

                foreach (Task tTask in tasks)
                {
                    if (tTask.ComplexityName == Enum.GetName(typeof(Complexity), 4) && inputHours >= Convert.ToInt32(Complexity.Hard))
                    {
                        inputHours -= Convert.ToInt32(Complexity.Hard);
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.PriorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (tTask.ComplexityName == Enum.GetName(typeof(Complexity), 2) && inputHours >= Convert.ToInt32(Complexity.Medium))
                    {
                        inputHours -= Convert.ToInt32(Complexity.Medium);
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.PriorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (tTask.ComplexityName == Enum.GetName(typeof(Complexity), 1) && inputHours >= Convert.ToInt32(Complexity.Simple))
                    {
                        inputHours -= Convert.ToInt32(Complexity.Simple);
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.PriorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
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