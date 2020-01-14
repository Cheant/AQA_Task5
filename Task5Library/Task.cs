namespace Task5Library
{
    public class Task
    {
        public static int ID = 1;
        public int TaskID { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public string Description { get; set; }

        public Task()
        {
            TaskID = ID++;
            Priority = EnumHelper.RequestForEnumValue<Priority>();
            Complexity = EnumHelper.RequestForEnumValue<Complexity>();
            Description = Validation.GetValidDescription();
        }
    }
}