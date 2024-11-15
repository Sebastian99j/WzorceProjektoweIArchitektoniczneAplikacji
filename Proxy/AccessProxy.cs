namespace Proxy
{
    public class AccessProxy : IResource
    {
        private readonly IResource _resource;
        private readonly string _password;

        public AccessProxy(IResource resource, string password)
        {
            _resource = resource;
            _password = password;
        }

        public void Access()
        {
            Console.Write("Enter password to access resource: ");
            string userInput = Console.ReadLine();

            if (userInput == _password)
            {
                Console.WriteLine("Authentication successful.");
                _resource.Access();
            }
            else
            {
                Console.WriteLine("Authentication failed. Access denied.");
            }
        }
    }
}
