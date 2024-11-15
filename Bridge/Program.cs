namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface graphicalInterface = new GraphicalUserInterface();
            UserInterface commandLineInterface = new CommandLineInterface();

            OperatingSystem windowsWithGUI = new WindowsOS(graphicalInterface);
            OperatingSystem linuxWithCLI = new LinuxOS(commandLineInterface);
            OperatingSystem linuxWithGUI = new LinuxOS(graphicalInterface);

            Console.WriteLine("Windows with GUI:");
            windowsWithGUI.LaunchApplications();

            Console.WriteLine("\nLinux with CLI:");
            linuxWithCLI.LaunchApplications();

            Console.WriteLine("\nLinux with GUI:");
            linuxWithGUI.LaunchApplications();
        }
    }
}
