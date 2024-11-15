namespace Proxy
{
    public class PublicResource : IResource
    {
        public void Access()
        {
            Console.WriteLine("Access granted to Public Resource.");
        }
    }
}
