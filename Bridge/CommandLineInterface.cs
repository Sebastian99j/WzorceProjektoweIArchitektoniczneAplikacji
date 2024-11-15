namespace Bridge
{
    public class CommandLineInterface : UserInterface
    {
        public override void DisplayApplications()
        {
            Console.WriteLine("Command Line Interface - Applications:");
            Console.WriteLine("1. Vim\n2. GCC Compiler\n3. Git\n4. Curl");
        }
    }
}
