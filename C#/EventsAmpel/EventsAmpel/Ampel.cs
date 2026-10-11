using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAmpel;

public class Ampel
{
    public string Farbe { get; set; }

    public event EventHandler<EventArgs> FarbeGeaendert;

    public void SetFarbe(string neueFarbe)
    {
        if (Farbe != neueFarbe)
        {
            Farbe = neueFarbe;
            FarbeGeaendert?.Invoke(this, EventArgs.Empty);
        }
    }
    public void OnFarbeGeaendert(object sender, EventArgs e)
    {
        Console.WriteLine($"Ampel ist jetzt {Farbe}");
    }
}
