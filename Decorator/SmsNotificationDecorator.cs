namespace Decorator
{
    public class SmsNotificationDecorator : PaymentDecorator
    {
        public SmsNotificationDecorator(IPayment payment) : base(payment) { }

        public override void Pay()
        {
            base.Pay();
            Console.WriteLine("Powiadomienie SMS zostało wysłane.");
        }
    }
}
