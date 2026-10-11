using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbStrategy
{
    delegate void ArtikelEventHandler(string artikelName, decimal preis);
    delegate void BestellungEventHandler(decimal gesamtpreis);
    internal class Warenkorb
    {
        private List<(string Name, decimal Preis)> _artikel = new();
        public event ArtikelEventHandler? ArtikelHinzugefügt;
        public event BestellungEventHandler? BestellungAbgeschlossen;

        public void ArtikelHinzufügen(string name, decimal preis)
        {
            _artikel.Add((name, preis));
            ArtikelHinzugefügt?.Invoke(name, preis);
        }
        public void Bestellen()
        {
            decimal gesamt = 0;
            foreach (var a in _artikel)
                gesamt += a.Preis;
            BestellungAbgeschlossen?.Invoke(gesamt);
            _artikel.Clear();
        }

    }
}
