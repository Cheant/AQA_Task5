using System;
using System.Text;

namespace Task5Library
{
    class Constants
    {
        public static int hardComplexity = 4;
        public static int mediumComplexity = 2;
        public static int simpleComplexity = 1;
        public static int workingHoursPerDay = 8;

        public static string textNullEmpty = "Entered value is null or empty.";
        public static string textInvalidValue = "Entered value is invalid.";
        public static string textSelectPriority = "Please select number of priority for a new task: 1 - High    2 - Medium    3 - Low";
        public static string textSelectComplexity = "Please select number of complexity for a new task: 1 - Hard    2 - Medium    3 - Simple";
        public static string textEnterDescription = "Please enter description for a new task:";
        public static string textAnotherTask = "Do you want to enter another task: 1 - Yes    2 - No";
        public static string textTasksByPriority = "Please select number of priority to see all tasks with such priority: 1 - High    2 - Medium    3 - Low";
        public static string textAnotherPriority = "Do you want to see the tasks of another priority: 1 - Yes    2 - No";
        public static string textEnterDays = "Please enter number of days. You will see the tasks that can be completed in a given number of days (8 working hours per day).";
        public static string textAnotherDays = "Do you want to enter another number of days: 1 - Yes    2 - No";
    }
}
