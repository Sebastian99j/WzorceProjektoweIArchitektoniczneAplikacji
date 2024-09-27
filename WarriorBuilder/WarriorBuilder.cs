namespace WarriorBuilder
{
    public abstract class WarriorBuilder
    {
        protected string _imie;
        protected int _sila;
        protected string _bron;

        public WarriorBuilder(string imie, int sila, string bron)
        {
            _imie = imie;
            _sila = sila;
            _bron = bron;
        }

        public abstract void ZapiszDoArmii();
        public abstract void PobierzBron();
        public abstract IWojownik TrenujWalki();
    }
}
