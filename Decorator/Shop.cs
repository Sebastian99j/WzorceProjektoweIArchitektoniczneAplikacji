namespace Decorator
{
    public class Shop
    {
        public void ProcessPayment(string paymentType)
        {
            IPayment payment = new BasicPayment(paymentType);

            if (paymentType == "Karta")
            {
                payment = new SmsNotificationDecorator(payment);
                payment = new LoyaltyPointsDecorator(payment);
                payment = new RedirectToHomePageDecorator(payment);
            }

            payment.Pay();
        }
    }
}
