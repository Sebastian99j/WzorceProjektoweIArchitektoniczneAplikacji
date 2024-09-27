namespace Factory
{
    public class Piechur : IWojownik
    {
        public Piechur(string imie, int sila, string bron)
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
                return 125;
            }
        }
        public string Bron { get; set; }
    }
}
