using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbStrategy
{
    public class WarenkorbLogger
    {
        public void OnArtikelHinzugefügt(string name, decimal preis)
        {
            Console.WriteLine($"[LOG] Artikel hinzugefügt: {name} - {preis}€");
        }

        public void OnBestellungAbgeschlossen(decimal preis)
        {
            Console.WriteLine($"[PREIS] Zwischensumme: {preis}");
        }
    }
}
