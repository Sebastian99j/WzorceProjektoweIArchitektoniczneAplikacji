using CodeSmells;

namespace CodeSmells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Długa lista parametrów
            var productInfo = new ProductInfo
            {
                ProductName = "Laptop",
                Category = "Electronics",
                Price = 1610.99M,
                Stock = 12,
                SupplierName = "TechSupplier Inc.",
                SupplierContact = "123-456-789"
            };

            RegisterProduct(productInfo);

            // Message Chains (Łańcuchy wiadomości)
            Car car = new Car();

            string cylinderSize = car.GetCylinderSize();
            Console.WriteLine($"Cylinder Size: {cylinderSize}");

            //Refused Bequest (Odrzucony spadek)

            Employee employee = new Employee { Name = "John", Position = "Developer" };
            Manager manager = new Manager { Name = "Jane", Position = "Team Lead" };

            employee.Work();
            employee.AttendMeeting();

            manager.Work();
            manager.AttendMeeting();
            manager.ManageTeam();

            //Temporary Field (Tymczasowe pole)
            InvoiceGenerator generator = new InvoiceGenerator();
            generator.GenerateInvoice();

            //Data Clumps (Grupy danych)
            EventDetails eventDetails = new EventDetails("Developer Conference", new DateTime(2024, 11, 25), "New York");

            EventManager eventManager = new EventManager();
            eventManager.RegisterEvent(eventDetails);

            Console.ReadKey();
        }

        public static void RegisterProduct(ProductInfo productInfo)
        {
            Console.WriteLine($"Product: {productInfo.ProductName}, Category: {productInfo.Category}, Price: {productInfo.Price:C}, Stock: {productInfo.Stock}, Supplier: {productInfo.SupplierName}, Contact: {productInfo.SupplierContact}");
        }
    }
}

