namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var nightClub = new NightClub();

            var krzys = new Teenager(17);
            var fakeAdult = new FakeAdult(krzys);

            Console.WriteLine("Krzyś próbuje wejść do klubu...");
            bool canEnter = nightClub.AllowEntry(fakeAdult);

            if (canEnter)
            {
                Console.WriteLine("Krzyś oszukał bramkarza i wszedł do klubu!");
            }
            else
            {
                Console.WriteLine("Krzyś został złapany i nie wszedł do klubu.");
            }
        }
    }
}
