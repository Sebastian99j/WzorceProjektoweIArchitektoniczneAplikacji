using System;

namespace SingletonVault
{
    public sealed class Vault
    {
        private static string kluczDostepu;
        private static Vault instancja;
        private static readonly object blokada = new Object();

        private Vault()
        {
            kluczDostepu = WygenerujKlucz();
        }

        public static Vault Instancja
        {
            get
            {
                lock (blokada)
                {
                    if (instancja == null)
                    {
                        instancja = new Vault();
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
            var skarbiec1 = Vault.Instancja;
            skarbiec1.PokazKlucz();

            var skarbiec2 = Vault.Instancja;
            skarbiec2.PokazKlucz();

            Console.WriteLine(skarbiec1 == skarbiec2 ? "To ta sama instancja." : "To różne instancje.");
        }
    }
}
