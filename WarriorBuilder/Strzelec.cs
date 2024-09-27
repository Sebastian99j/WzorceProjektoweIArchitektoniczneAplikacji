namespace WarriorBuilder
{
    public class Strzelec : IWojownik
    {
        public string Imie { get; }
        public int Sila { get; }
        public string Bron { get; private set; }

        public Strzelec(string imie, int sila, string bron)
        {
            Imie = imie;
            Sila = sila;
            Bron = bron;
        }

        public void PobierzBron()
        {
            Console.WriteLine($"{Imie} (Strzelec) pobiera broń: {Bron}");
        }

        public void TrenujWalki()
        {
            Console.WriteLine($"{Imie} (Strzelec) trenuje walki z {Bron}");
        }
    }
}
