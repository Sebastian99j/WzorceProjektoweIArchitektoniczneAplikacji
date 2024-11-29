namespace Decorator
{
    public class RedirectToHomePageDecorator : PaymentDecorator
    {
        public RedirectToHomePageDecorator(IPayment payment) : base(payment) { }

        public override void Pay()
        {
            base.Pay();
            Console.WriteLine("Użytkownik został przekierowany na stronę główną sklepu.");
        }
    }
}
