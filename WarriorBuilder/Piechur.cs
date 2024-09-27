namespace WarriorBuilder
{
    public class Piechur : IWojownik
    {
        public string Imie { get; }
        public int Sila { get; }
        public string Bron { get; private set; }

        public Piechur(string imie, int sila, string bron)
        {
            Imie = imie;
            Sila = sila;
            Bron = bron;
        }

        public void PobierzBron()
        {
            Console.WriteLine($"{Imie} (Piechur) pobiera broń: {Bron}");
        }

        public void TrenujWalki()
        {
            Console.WriteLine($"{Imie} (Piechur) trenuje walki z {Bron}");
        }
    }
}
