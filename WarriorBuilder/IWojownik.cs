using System;

namespace WarriorBuilder
{
    public interface IWojownik
    {
        string Imie { get; }
        int Sila { get; }
        string Bron { get; }

        void PobierzBron();
        void TrenujWalki();
    }
}
