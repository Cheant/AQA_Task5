namespace Task5Library
{
    public class Task
    {
        public int TaskID { get; set; }
        public int PriorityID { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
    }
}