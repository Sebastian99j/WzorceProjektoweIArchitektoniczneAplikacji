namespace Adapter
{
    public class FakeAdult : Adult
    {
        private readonly Teenager _teenager;

        public FakeAdult(Teenager teenager)
        {
            _teenager = teenager;
        }

        public override bool IsAdult()
        {
            return true;
        }
    }
}
