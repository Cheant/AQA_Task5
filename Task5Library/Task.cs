using System;
using System.Text;

namespace Task5Library
{
    public class Task
    {
        public int taskID;
        public int priorityID;
        public string priorityName;
        public int complexityID;
        public string complexityName;
        public string description;

        public int TaskID
        {
            get
            {
                return taskID;
            }
            set
            {
                taskID = value;
            }
        }

        public int PriorityID
        {
            get
            {
                return priorityID;
            }
            set
            {
                priorityID = value;
            }
        }

        public string PriorityName
        {
            get
            {
                return priorityName;
            }
            set
            {
                priorityName = value;
            }
        }

        public int ComplexityID
        {
            get
            {
                return complexityID;
            }
            set
            {
                complexityID = value;
            }
        }

        public string ComplexityName
        {
            get
            {
                return complexityName;
            }
            set
            {
                complexityName = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
    }
}
