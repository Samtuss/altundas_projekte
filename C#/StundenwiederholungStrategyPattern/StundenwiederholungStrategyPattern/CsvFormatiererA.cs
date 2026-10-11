using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public class CsvFormatiererA : BestellFormatiererPapa
    {
        public override string Formatiere(Bestellung bestellung)
        {
            return $"{bestellung.Kunde},{bestellung.Artikel},{bestellung.Gesamtbetrag}";
        }
    }
}
