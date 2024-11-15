namespace Bridge
{
    public class GraphicalUserInterface : UserInterface
    {
        public override void DisplayApplications()
        {
            Console.WriteLine("Graphical User Interface - Applications:");
            Console.WriteLine("1. Microsoft Edge\n2. Visual Studio\n3. Photoshop\n4. Spotify");
        }
    }
}
