namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            Console.WriteLine("Wybierz metodę płatności (Karta, Gotówka, Blik):");
            string paymentType = Console.ReadLine();

            shop.ProcessPayment(paymentType);

            Console.WriteLine("Dziękujemy za zakupy!");
        }
    }
}
