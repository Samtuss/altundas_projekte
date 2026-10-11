using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public class CsvFormatierer : IBestellFormatierer
    {
        public string Formatiere(Bestellung bestellung)
        {
            return $"{bestellung.Kunde},{bestellung.Artikel},{bestellung.Gesamtbetrag}";
        }
    }
}
