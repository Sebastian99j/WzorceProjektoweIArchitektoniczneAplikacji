namespace Proxy
{
    public class ProtectedResource : IResource
    {
        public void Access()
        {
            Console.WriteLine("Access granted to Protected Resource.");
        }
    }
}
