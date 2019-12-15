using System;
using System.Collections.Generic;
using System.Text;

namespace Task5Library
{
    public class Calculation
    {
        List<Task> task = new List<Task>();

        Validation validation = new Validation();

        public void RecordInputTasksAndPrintExecutionTime()
        {
            int counter = 0;
            int proceed = 1;
            int executionTime = 0;
            string inputPriority;
            string inputPriorityName;
            string inputComplexity;
            string inputComplexityName;
            string inputDescription;
            string wantNewTask;

            while (proceed == 1)
            {
                Console.Clear();
                Console.WriteLine($"{Constants.textSelectPriority}");
                inputPriority = validation.GetValidValueThreeOptions(Constants.textSelectPriority);

                Console.WriteLine($"{Environment.NewLine}{Constants.textSelectComplexity}");
                inputComplexity = validation.GetValidValueThreeOptions(Constants.textSelectComplexity);

                Console.WriteLine($"{Environment.NewLine}{Constants.textEnterDescription}");
                inputDescription = validation.GetValueNotNullOrEmpty(Constants.textEnterDescription);

                Console.WriteLine($"{Environment.NewLine}{Constants.textAnotherTask}");
                wantNewTask = validation.GetValidValueTwoOptions(Constants.textAnotherTask);

                if (Convert.ToInt32(wantNewTask) == 2)
                {
                    proceed = 2;
                }

                counter++;

                if (inputPriority == "1")
                {
                    inputPriorityName = "High";
                }
                else if (inputPriority == "2")
                {
                    inputPriorityName = "Medium";
                }
                else
                {
                    inputPriorityName = "Low";
                }

                if (inputComplexity == "1")
                {
                    inputComplexityName = "Hard";
                    executionTime += Constants.hardComplexity;
                }
                else if (inputComplexity == "2")
                {
                    inputComplexityName = "Medium";
                    executionTime += Constants.mediumComplexity;
                }
                else
                {
                    inputComplexityName = "Simple";
                    executionTime += Constants.simpleComplexity;
                }

                task.Add(new Task() {TaskID = counter, PriorityID = Convert.ToInt32(inputPriority), PriorityName = inputPriorityName, ComplexityID = Convert.ToInt32(inputComplexity), ComplexityName = inputComplexityName, Description = inputDescription});
            }

            Console.Clear();
            Console.WriteLine($"{executionTime} hours are needed to complete all tasks.{Environment.NewLine}");
        }

        public void PrintTasksByPriority()
        {
            int proceed = 1;
            string inputPriority;
            string wantNewPriority;

            while (proceed == 1)
            {
                Console.Clear();
                Console.WriteLine($"{Constants.textTasksByPriority}");
                inputPriority = validation.GetValidValueThreeOptions(Constants.textTasksByPriority);

                foreach (Task tTask in task)
                {
                    if (tTask.PriorityID == Convert.ToInt32(inputPriority))
                    {
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.priorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
                    }
                }

                Console.WriteLine($"{Environment.NewLine}{Constants.textAnotherPriority}");
                wantNewPriority = validation.GetValidValueTwoOptions(Constants.textAnotherPriority);

                if (Convert.ToInt32(wantNewPriority) == 2)
                {
                    proceed = 2;
                }
            }
        }

        public void PrintTasksCompleteInEnteredDays()
        {
            int proceed = 1;
            int inputHours = 0;
            string inputDays;
            string wantNewDays;
            task.Sort((x, y) => x.PriorityID.CompareTo(y.PriorityID));

            while (proceed == 1)
            {
                Console.Clear();
                Console.WriteLine($"{Constants.textEnterDays}");
                inputDays = validation.GetValidValueThreeOptions(Constants.textEnterDays);
                inputHours = Convert.ToInt32(inputDays) * Constants.workingHoursPerDay;

                foreach (Task tTask in task)
                {
                    if (tTask.ComplexityID == 1 && inputHours >= Constants.hardComplexity)
                    {
                        inputHours -= Constants.hardComplexity;
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.priorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (tTask.ComplexityID == 2 && inputHours >= Constants.mediumComplexity)
                    {
                        inputHours -= Constants.mediumComplexity;
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.priorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (tTask.ComplexityID == 3 && inputHours >= Constants.simpleComplexity)
                    {
                        inputHours -= Constants.simpleComplexity;
                        Console.WriteLine($"{Environment.NewLine}Priority: {tTask.priorityName}{Environment.NewLine}Complexity: {tTask.ComplexityName}{Environment.NewLine}Description: {tTask.Description}");
                    }

                    if (inputHours == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"{Environment.NewLine}{Constants.textAnotherDays}");
                wantNewDays = validation.GetValidValueTwoOptions(Constants.textAnotherDays);

                if (Convert.ToInt32(wantNewDays) == 2)
                {
                    proceed = 2;
                }
            }
        }
    }
}
