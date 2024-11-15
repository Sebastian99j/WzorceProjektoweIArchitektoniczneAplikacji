namespace Bridge
{
    public abstract class OperatingSystem
    {
        protected UserInterface _userInterface;

        protected OperatingSystem(UserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public abstract void LaunchApplications();
    }
}
