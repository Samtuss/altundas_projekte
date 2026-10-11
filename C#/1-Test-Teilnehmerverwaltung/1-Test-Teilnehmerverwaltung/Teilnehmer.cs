using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Test_Teilnehmerverwaltung;

public class Teilnehmer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Anmeldezeit { get; set; }

    public Teilnehmer(string name, string email, DateTime anmeldezeitpunkt)
    {
        Name = name;
        Email = email;
        Anmeldezeit = anmeldezeitpunkt;
    }
}

