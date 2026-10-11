using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public class Kasse
    {
        private IBestellFormatierer _formatierer;

        public Kasse(IBestellFormatierer formatierer)
        {
            _formatierer = formatierer;
        }

        public void SetFormat(IBestellFormatierer f)
        {
            _formatierer = f;
        }
        public void Druck(Bestellung b)
        {
            Console.WriteLine(_formatierer.Formatiere(b));
        }
    }
}
