namespace Decorator
{
    public abstract class PaymentDecorator : IPayment
    {
        protected IPayment _payment;

        public PaymentDecorator(IPayment payment)
        {
            _payment = payment;
        }

        public virtual void Pay()
        {
            _payment.Pay();
        }
    }
}
