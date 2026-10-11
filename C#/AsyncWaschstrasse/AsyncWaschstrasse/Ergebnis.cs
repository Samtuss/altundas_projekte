using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWaschstrasse
{
    public class Ergebnis
    {
        public Ergebnis(string name, long delay)
        {
            Name = name;
            Delay = delay;
        }

        public string Name { get; }
        public long Delay { get; }
    }
}
