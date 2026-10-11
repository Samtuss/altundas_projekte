using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public class KlartextForcmatiererA : BestellFormatiererPapa
    {
        public override string Formatiere(Bestellung bestellung)
        {
            return $"Kunde: {bestellung.Kunde}, Artikel: {bestellung.Artikel}, Gesamtbetrag: {bestellung.Gesamtbetrag}";
        }
    }
}
