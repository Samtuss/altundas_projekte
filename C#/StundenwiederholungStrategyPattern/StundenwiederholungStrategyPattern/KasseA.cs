using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public class KasseA
    {
        private BestellFormatiererPapa _formatierer;

        public KasseA(BestellFormatiererPapa formatierer)
        {
            _formatierer = formatierer;
        }

        public void SetFormat(BestellFormatiererPapa f)
        {
            _formatierer = f;
        }
        public void Druck(Bestellung b)
        {
            Console.WriteLine(_formatierer.Formatiere(b));
        }
    }
}
