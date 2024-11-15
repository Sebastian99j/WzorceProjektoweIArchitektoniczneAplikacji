namespace Bridge
{
    public class WindowsOS : OperatingSystem
    {
        public WindowsOS(UserInterface userInterface) : base(userInterface) { }

        public override void LaunchApplications()
        {
            Console.WriteLine("Launching on Windows OS:");
            _userInterface.DisplayApplications();
        }
    }
}
