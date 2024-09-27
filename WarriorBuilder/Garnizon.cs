namespace WarriorBuilder
{
    public class Garnizon
    {
        private List<IWojownik> wojownicy = new List<IWojownik>();

        public void Szkolenie(WarriorBuilder builder)
        {
            builder.ZapiszDoArmii();
            builder.PobierzBron();
            var wojownik = builder.TrenujWalki();
            wojownicy.Add(wojownik);
            Console.WriteLine($"{wojownik.Imie} został wyszkolony i dodany do garnizonu.\n");
        }

        public void WyswietlWojownikow()
        {
            Console.WriteLine("W garnizonie znajdują się następujący wojownicy:");
            foreach (var wojownik in wojownicy)
            {
                Console.WriteLine($"{wojownik.Imie} - {wojownik.GetType().Name}");
            }
        }
    }
}
