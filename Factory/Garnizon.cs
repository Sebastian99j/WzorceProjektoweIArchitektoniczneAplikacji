namespace Factory
{
    enum TypWojownika
    {
        KONNY, STRZELEC, PIECHUR
    }

    internal class Garnizon
    {
        public IWojownik stworzWojownika(string imie, int sila, string bron, TypWojownika typWojownika)
        {
            switch (typWojownika)
            {
                case TypWojownika.KONNY:
                    {
                        return new Konny(imie, sila, bron);
                    }
                case TypWojownika.STRZELEC:
                    {
                        return new Strzelec(imie, sila, bron);
                    }
                case TypWojownika.PIECHUR:
                    {
                        return new Piechur(imie, sila, bron);
                    }
                default:
                    {
                        return new Piechur(imie, sila, bron);
                    }
            }
        }
    }
}
