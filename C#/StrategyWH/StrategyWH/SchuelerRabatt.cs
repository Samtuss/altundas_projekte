using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWH
{
    public class SchuelerRabatt : IRabattStrategy
    {
        public decimal BerechneRabatt(decimal betrag)
        {
            return betrag * 0.20m; // 20% Rabatt für Schüler
        }
    }
}
