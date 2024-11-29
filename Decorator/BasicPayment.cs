namespace Decorator
{
    public class BasicPayment : IPayment
    {
        private readonly string _paymentType;

        public BasicPayment(string paymentType)
        {
            _paymentType = paymentType;
        }

        public void Pay()
        {
            Console.WriteLine($"Płatność za pomocą: {_paymentType} została przetworzona.");
        }
    }
}
