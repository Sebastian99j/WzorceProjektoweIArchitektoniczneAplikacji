namespace Factory
{
    public class Strzelec : IWojownik
    {
        public Strzelec(string imie, int sila, string bron)
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
                return 150;
            }
        }
        public string Bron { get; set; }
    }
}
