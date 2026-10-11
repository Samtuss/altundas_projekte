using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbStrategy
{
    public class RabattRechner
    {
        public void OnBestellungAbgeschlossen(decimal gesamt)
        {
            decimal rabatt = 0;

            if(gesamt > 500)
            {
                rabatt = 0.1m;
            }
            else if (gesamt >= 100)
            {
                rabatt = 0.05m;
            }

            decimal rabatte = gesamt * rabatt;
            decimal endpreis = gesamt - rabatte;

            Console.WriteLine($"[RABATT] {rabatt * 100}% Rabatt: {rabatte} Sie zahlen: {gesamt}");
        }
    }
}
