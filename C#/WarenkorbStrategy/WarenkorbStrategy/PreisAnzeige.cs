using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbStrategy
{
    public class PreisAnzeige
    {
        private decimal hilfe = 0;

        public void OnArtikelHinzugefügt(string name, decimal preis)
        {
            hilfe += preis;
            Console.WriteLine($"[PREIS] Zwischensumme: {hilfe}");
        }


        public void OnBestellungAbgeschlossen(decimal preis)
        {
            Console.WriteLine($"[PREIS] Bestellung abgeschlossen. Anzeige zurückgesetzt.");
            hilfe = 0;
        }
    }
}
