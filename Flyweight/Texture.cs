namespace Flyweight
{
    public class Texture
    {
        private readonly string _fileName;

        public Texture(string fileName)
        {
            _fileName = fileName;
            Console.WriteLine($"Ładowanie tekstury z pliku: {_fileName}");
        }

        public void Display()
        {
            Console.WriteLine($"Tekstura: {_fileName}");
        }
    }
}
