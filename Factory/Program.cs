using Factory;

class Program
{
    static void Main(string[] args)
    {
        var garnizon = new Garnizon();
        List<IWojownik> wojownicy = new List<IWojownik>();

        var tablica = new[]
        {
                new { Imie = "Jan", Wiek = 20, Bron = "Miecz", Typ = TypWojownika.PIECHUR },
                new { Imie = "Michal", Wiek = 21, Bron = "Pika", Typ = TypWojownika.PIECHUR },
                new { Imie = "Karol", Wiek = 27, Bron = "Topor", Typ = TypWojownika.PIECHUR },
                new { Imie = "Marek", Wiek = 19, Bron = "Luk", Typ = TypWojownika.STRZELEC },
                new { Imie = "Bartlomiej", Wiek = 41, Bron = "Luk", Typ = TypWojownika.STRZELEC },
                new { Imie = "Marek", Wiek = 27, Bron = "Kusza", Typ = TypWojownika.STRZELEC },
                new { Imie = "Jan", Wiek = 18, Bron = "Halabarda", Typ = TypWojownika.KONNY },
                new { Imie = "Michal", Wiek = 42, Bron = "Kopia", Typ = TypWojownika.KONNY },
                new { Imie = "Miroslaw", Wiek = 39, Bron = "Pika", Typ = TypWojownika.KONNY },
                new { Imie = "Kamil", Wiek = 44, Bron = "Wlocznia", Typ = TypWojownika.KONNY }
            };

        wojownicy.AddRange(tablica.Select(z => garnizon.stworzWojownika(z.Imie, z.Wiek, z.Bron, z.Typ)));

        wojownicy.ForEach(wojownik =>
            Console.WriteLine($"Cześć mam na imię {wojownik.Imie} i moja specjalność to {wojownik.GetType().Name}"));

        IWojownik[] tablicaWojownikow = wojownicy.Where(w =>
            w is Piechur || w is Konny || w is Strzelec).Take(10).ToArray();
    }
}