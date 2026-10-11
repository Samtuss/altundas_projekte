using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWH
{
    public class MitarbeiterRabatt : IRabattStrategy
    {
        public decimal BerechneRabatt(decimal betrag)
        {
            return betrag * 0.30m; // 30% Rabatt für Mitarbeiter
        }
    }
}
