using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public abstract class BestellFormatiererPapa
    {
        public abstract string Formatiere(Bestellung bestellung);

        public string ErstelleKopfzeile()
        {
            return $"=== Bestellung von {DateTime.Now} ===";
        }
    }
}
