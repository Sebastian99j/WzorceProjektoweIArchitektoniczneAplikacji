namespace Prototype
{
    public class Ork
    {
        public string Imie { get; set; }
        public int Sila { get; set; }

        public Ork(string imie, int sila)
        {
            Imie = imie;
            Sila = sila;
        }

        public override string ToString()
        {
            return $"Ork: {Imie}, Siła: {Sila}";
        }
    }
}
