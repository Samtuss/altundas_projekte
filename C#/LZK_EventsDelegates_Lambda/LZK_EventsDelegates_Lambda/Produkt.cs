using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZK_EventsDelegates_Lambda;

public class Produkt
{
    public string Name { get; }
    public double Preis { get; }
    public string Kategorie { get; }

    public Produkt(string name, double preis, string kategorie)
    {
        Name = name;
        Preis = preis;
        Kategorie = kategorie;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Name: {Name} - Preis: {Preis} - Kategorie: {Kategorie}");
        return sb.ToString();
    }


}
