using WarriorBuilder;

class Program
{
    static void Main(string[] args)
    {
        var garnizon = new Garnizon();

        var piechur1 = new PiechurBuilder("Jan", 80, "Miecz");
        var piechur2 = new PiechurBuilder("Piotr", 85, "Topór");
        garnizon.Szkolenie(piechur1);
        garnizon.Szkolenie(piechur2);

        var konny1 = new KonnyBuilder("Michał", 90, "Lanca");
        var konny2 = new KonnyBuilder("Paweł", 88, "Kopia");
        garnizon.Szkolenie(konny1);
        garnizon.Szkolenie(konny2);

        var strzelec1 = new StrzelecBuilder("Marek", 75, "Łuk");
        var strzelec2 = new StrzelecBuilder("Krzysztof", 78, "Kusza");
        garnizon.Szkolenie(strzelec1);
        garnizon.Szkolenie(strzelec2);

        garnizon.WyswietlWojownikow();
    }
}
