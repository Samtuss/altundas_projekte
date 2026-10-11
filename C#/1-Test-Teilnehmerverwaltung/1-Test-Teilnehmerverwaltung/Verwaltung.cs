using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Test_Teilnehmerverwaltung;

public class Verwaltung
{
    LinkedList<Teilnehmer> TeilnehmerListe = new LinkedList<Teilnehmer>();

    

    public void CSVEinlesen (string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Die angegebene Datei wurde nicht gefunden.", path);
        }
        //string[] lines = File.ReadAllLines(path);

        //for(int i = 1; i < lines.Length; i++)
        //{
        //    string line = lines[i];
        //    string[] parts = line.Split(',');
        //    if (parts.Length != 3)
        //    {
        //        throw new FormatException($"Ungültiges Format in Zeile {i + 1}: {line}");
        //    }
        //    string name = parts[0];
        //    string email = parts[1];
        //    string zeit = parts[2];
        //    DateTime anmeldezeit = DateTime.Parse(zeit);
        //    Teilnehmer teilnehmer = new Teilnehmer(name, email, anmeldezeit);
        //    TeilnehmerListe.AddLast(teilnehmer);
        //}

        using (StreamReader reader = new StreamReader(path))
        {
            // Skip header line
            reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length != 3)
                {
                    throw new FormatException($"Ungültiges Format in Zeile: {line}");
                }
                string name = parts[0];
                string email = parts[1];
                string zeit = parts[2];
                DateTime anmeldezeit = DateTime.Parse(zeit);
                Teilnehmer teilnehmer = new Teilnehmer(name, email, anmeldezeit);
                TeilnehmerListe.AddLast(teilnehmer);
            }
        }


    }

    public int CountList()
    {
        return TeilnehmerListe.Count;
    }

    public void FirstFive()
    {
        var current = TeilnehmerListe.First;
        int length = 5;
        if (CountList() < 5)
            length = CountList();

        for (int i = 0; i < length; i++)
        {
            Console.WriteLine($"Name: {current.Value.Name}, Email: {current.Value.Email}, Anmeldezeit: {current.Value.Anmeldezeit}");
            current = current.Next;
        }
    }


    public void DeleteMiddle()
    {
        int count = CountList();
        if (count == 0)
            return;
        int middleIndex = count / 2;
        var current = TeilnehmerListe.First;
        for (int i = 0; i < middleIndex - 1; i++)
        {
            current = current.Next;
        }
        TeilnehmerListe.Remove(current);
    }

    public void ListAusgeben()
    {
        int i = 0;
        foreach (var current in TeilnehmerListe)
        {
            i++;
            Console.WriteLine($"Nr.d{i} - Name: {current.Name}, Email: {current.Email}, Anmeldezeit: {current.Anmeldezeit}");
        }
    }

    public void VIPInsert (Teilnehmer teilnehmer)
    {
        TeilnehmerListe.AddFirst(teilnehmer);
    }

}
