namespace Decorator
{
    public class LoyaltyPointsDecorator : PaymentDecorator
    {
        public LoyaltyPointsDecorator(IPayment payment) : base(payment) { }

        public override void Pay()
        {
            base.Pay();
            Console.WriteLine("Punkty lojalnościowe zostały dodane.");
        }
    }
}
