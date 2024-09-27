namespace Factory
{
    public interface IWojownik
    {
        public string Imie { get; set; }
        public int Sila { get; set; }
        public int Zywotnosc { get; }
        public string Bron { get; set; }
    }
}
