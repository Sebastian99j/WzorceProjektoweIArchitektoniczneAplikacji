namespace Factory
{
    public class Konny : IWojownik
    {
        public Konny(string imie, int sila, string bron)
        {
            Imie = imie;
            Sila = sila;
            Bron = bron;
        }

        public string Imie { get; set; }
        public int Sila { get; set; }
        public int Zywotnosc 
        { 
            get
            {
                return 100;
            }
        }
        public string Bron { get; set; }
    }
}
