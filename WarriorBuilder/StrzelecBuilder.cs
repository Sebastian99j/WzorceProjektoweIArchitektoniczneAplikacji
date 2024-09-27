namespace WarriorBuilder
{
    public class StrzelecBuilder : WarriorBuilder
    {
        public StrzelecBuilder(string imie, int sila, string bron) : base(imie, sila, bron)
        {
        }

        public override void ZapiszDoArmii()
        {
            Console.WriteLine($"{_imie} zapisuje się do armii jako Strzelec.");
        }

        public override void PobierzBron()
        {
            Console.WriteLine($"{_imie} pobiera broń: {_bron}");
        }

        public override IWojownik TrenujWalki()
        {
            Console.WriteLine($"{_imie} trenuje walki z {_bron}");
            return new Strzelec(_imie, _sila, _bron);
        }
    }
}
