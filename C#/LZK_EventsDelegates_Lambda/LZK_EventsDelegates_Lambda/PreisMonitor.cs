using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZK_EventsDelegates_Lambda;

public class PreisMonitor
{
    public event EventHandler<PreisAlarmEventArgs>? PreisAlarm;

    public void CheckPreis(Produkt produkt, double wunschpreis)
    {
        if (produkt.Preis <= wunschpreis)
        {
            PreisAlarm?.Invoke(this, new PreisAlarmEventArgs(produkt, wunschpreis));
        }
    }
}
