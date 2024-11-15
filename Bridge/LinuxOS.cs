namespace Bridge
{
    public class LinuxOS : OperatingSystem
    {
        public LinuxOS(UserInterface userInterface) : base(userInterface) { }

        public override void LaunchApplications()
        {
            Console.WriteLine("Launching on Linux OS:");
            _userInterface.DisplayApplications();
        }
    }
}
