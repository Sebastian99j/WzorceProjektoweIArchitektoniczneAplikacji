using System;

namespace SingletonVault
{
    public sealed class Skarbiec
    {
        private static string kluczDostepu;
        private static Skarbiec instancja;
        private static readonly object blokada = new Object();

        private Skarbiec()
        {
            kluczDostepu = WygenerujKlucz();
        }

        public static Skarbiec Instancja
        {
            get
            {
                lock (blokada)
                {
                    if (instancja == null)
                    {
                        instancja = new Skarbiec();
                    }
                }

                return instancja;
            }
        }

        private static string WygenerujKlucz()
        {
            return $"Klucz-{DateTime.Now.Ticks}";
        }

        public void PokazKlucz()
        {
            Console.WriteLine($"Klucz dostępu do skarbca: {kluczDostepu}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var skarbiec1 = Skarbiec.Instancja;
            skarbiec1.PokazKlucz();

            var skarbiec2 = Skarbiec.Instancja;
            skarbiec2.PokazKlucz();

            Console.WriteLine(skarbiec1 == skarbiec2 ? "To ta sama instancja." : "To różne instancje.");
        }
    }
}
