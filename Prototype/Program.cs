using Newtonsoft.Json;
using Prototype;

class Program
{
    static void Main(string[] args)
    {
        Ork originalOrk = new Ork("Gorbag", 100);

        List<Ork> orki = new List<Ork>();

        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            string serializedOrk = JsonConvert.SerializeObject(originalOrk);

            Ork clonedOrk = JsonConvert.DeserializeObject<Ork>(serializedOrk);

            clonedOrk.Sila = random.Next(80, 120);

            orki.Add(clonedOrk);
        }

        foreach (Ork ork in orki)
        {
            Console.WriteLine(ork);
        }
    }
}