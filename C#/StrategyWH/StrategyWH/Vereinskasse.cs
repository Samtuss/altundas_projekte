using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWH
{
    public class Vereinskasse
    {
        private IRabattStrategy _rabattStrategy;

        public Vereinskasse(IRabattStrategy rabattStrategy)
        {
            _rabattStrategy = rabattStrategy;
        }

        public decimal BerechneEndbetrag(decimal betrag)
        {
            var rabatt = _rabattStrategy.BerechneRabatt(betrag);
            return betrag - rabatt;
        }

        public void SetRabattStrategy(IRabattStrategy rabattStrategy)
        {
            _rabattStrategy = rabattStrategy;
        }

    }
}
