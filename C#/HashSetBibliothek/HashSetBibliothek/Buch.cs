using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetBibliothek;

public class Buch
{
    public string Titel { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; } // eindeutiger Identifier
    public Buch(string isbn, string titel, string autor)
    {
        Titel = titel;
        Autor = autor;
        ISBN = isbn;
    }
    public override bool Equals(object obj)
    {
        return obj is Buch other && ISBN == other.ISBN;
    }
    public override int GetHashCode()
    {
        return ISBN.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Titel} von {Autor}, ISBN: {ISBN}";
    }
}
