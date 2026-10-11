using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public class Bestellung
    {
        public Bestellung(string kunde, string artikel, decimal gesamtbetrag)
        {
            Kunde = kunde;
            Artikel = artikel;
            Gesamtbetrag = gesamtbetrag;
        }

        public string Kunde { get; set; }
        public string Artikel { get; set; }
        public decimal Gesamtbetrag { get; set; }

    }
}
