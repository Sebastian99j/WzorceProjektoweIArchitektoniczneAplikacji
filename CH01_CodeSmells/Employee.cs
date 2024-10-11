namespace CodeSmells
{
    internal class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public void Work()
        {
            Console.WriteLine($"{Name} is working.");
        }

        public void AttendMeeting()
        {
            Console.WriteLine($"{Name} is attending a meeting.");
        }
    }
}
