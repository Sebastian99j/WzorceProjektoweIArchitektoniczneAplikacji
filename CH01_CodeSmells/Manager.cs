namespace CodeSmells
{
    internal class Manager : Employee
    {
        public void ManageTeam()
        {
            Console.WriteLine($"{Name} is managing the team.");
        }
    }
}
