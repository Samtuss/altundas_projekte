using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFormel1;

public class RennErgebnis
{
    public string Fahrer { get; set; }
    public long GesamtzeitMs { get; set; }
    public long SchnellsteRundeMs { get; set; }

    public RennErgebnis(string fahrer, long gesamtzeitms, long schnellsterunde)
    {
        Fahrer = fahrer;
        GesamtzeitMs = gesamtzeitms;
        SchnellsteRundeMs = schnellsterunde;
    }

    public override string ToString()
    {
        return $"{Fahrer}: Gesamtzeit = {GesamtzeitMs} ms, Schnellste Runde = {SchnellsteRundeMs} ms";
    }

}
