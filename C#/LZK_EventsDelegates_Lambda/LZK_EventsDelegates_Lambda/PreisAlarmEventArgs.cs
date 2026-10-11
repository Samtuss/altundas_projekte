using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZK_EventsDelegates_Lambda
{
    public class PreisAlarmEventArgs : EventArgs
    {
        public Produkt Produkt { get; set; }
        public double Wunschpreis { get; set; }

        public PreisAlarmEventArgs(Produkt produkt, double wunschpreis)
        {
            Produkt = produkt;
            Wunschpreis = wunschpreis;
        }
    }
}
