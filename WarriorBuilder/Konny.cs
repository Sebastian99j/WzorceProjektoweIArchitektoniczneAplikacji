namespace WarriorBuilder
{
    public class Konny : IWojownik
    {
        public string Imie { get; }
        public int Sila { get; }
        public string Bron { get; private set; }

        public Konny(string imie, int sila, string bron)
        {
            Imie = imie;
            Sila = sila;
            Bron = bron;
        }

        public void PobierzBron()
        {
            Console.WriteLine($"{Imie} (Konny) pobiera broń: {Bron}");
        }

        public void TrenujWalki()
        {
            Console.WriteLine($"{Imie} (Konny) trenuje walki z {Bron}");
        }
    }
}
