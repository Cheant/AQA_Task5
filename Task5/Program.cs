using System;
using Task5Library;

namespace Task5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calculation calculation = new Calculation();

            calculation.RecordInputTasksAndPrintExecutionTime();
            Console.ReadKey();
            calculation.PrintTasksByPriority();
            calculation.PrintTasksCompleteInEnteredDays();
        }
    }
}