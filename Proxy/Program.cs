namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var publicResource = ResourceFactory.CreateResource("public");
            var protectedResource = ResourceFactory.CreateResource("protected", "secure123");

            while (true)
            {
                Console.WriteLine("\nSelect Resource:");
                Console.WriteLine("1. Public Resource");
                Console.WriteLine("2. Protected Resource");
                Console.WriteLine("0. Exit");

                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        publicResource.Access();
                        break;
                    case "2":
                        protectedResource.Access();
                        break;
                    case "0":
                        Console.WriteLine("Exiting program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
