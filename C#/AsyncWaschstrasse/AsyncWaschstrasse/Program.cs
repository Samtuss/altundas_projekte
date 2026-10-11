using System.Diagnostics;

namespace AsyncWaschstrasse;

//public class Program
//{
//    static SemaphoreSlim sem = new SemaphoreSlim(2);
//    static async Task Main(string[] args)
//    {
//        Console.WriteLine("Hello, World!");

//        // Liste der Autos
//        var autos = new[] { "Auto 1", "Auto 2", "Auto 3", "Auto 4", "Auto 5", "Auto 6" };
//        var tasks = new List<Task<Ergebnis>>();

//        // Starte alle Wasch-Tasks
//        foreach (var auto in autos)
//        {
//            tasks.Add(Waschen(auto));
//        }

//        // Warte auf alle Ergebnisse und gebe sie aus
//        while (tasks.Count > 0)
//        {
//            var first = await Task.WhenAny(tasks);
//            tasks.Remove(first);
//            var ergebnis = await first;
//            Console.WriteLine($"{ergebnis.Name}: Fertig in {ergebnis.Delay}ms");
//        }
//    }

//    static async Task<Ergebnis> Waschen(string name)
//    {
//        Stopwatch sw = new Stopwatch();
//        sw.Start();
//        Console.WriteLine($"[{sw.ElapsedMilliseconds}ms] {name} wartet auf freien Platz");
//        await sem.WaitAsync();
//        try
//        {
//            Console.WriteLine($"[{sw.ElapsedMilliseconds}ms] {name} fährt in Waschplatz ein");
//            await Task.Delay(2000); // Simuliere Waschdauer
//            Console.WriteLine($"[{sw.ElapsedMilliseconds}ms] {name} wird gewaschen...");
//        }
//        finally
//        {
//            sem.Release();
//            sw.Stop();
//            Console.WriteLine($"[{sw.ElapsedMilliseconds}ms] {name} Fertig gewaschen! Platz wird frei.");
//        }
//        return new Ergebnis(name, sw.ElapsedMilliseconds);
//    }
using System;
using System.Threading;
using System.Threading.Tasks;

class Waschstrasse
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(2); // 2 Waschplätze
    static DateTime startTime = DateTime.Now;

    static string Timestamp()
    {
        double elapsed = (DateTime.Now - startTime).TotalSeconds;
        return $"[{elapsed:F1}s]";
    }

    static async Task AutoWaschen(int autoNummer)
    {
        Console.WriteLine($"{Timestamp()} Auto {autoNummer}: Wartet auf freien Platz...");

        await semaphore.WaitAsync(); // Warten bis Platz frei

        try
        {
            Console.WriteLine($"{Timestamp()} Auto {autoNummer}: Fährt in Waschplatz ein");

            // Zufällige Waschzeit zwischen 2 und 5 Sekunden
            int waschzeit = Random.Shared.Next(2000, 5001);
            await Task.Delay(waschzeit);

            Console.WriteLine($"{Timestamp()} Auto {autoNummer}: Fertig gewaschen! Platz wird frei.");
        }
        finally
        {
            semaphore.Release(); // Platz freigeben – auch bei Fehlern!
        }
    }

    static async Task Main(string[] args)
    {
        int anzahlAutos = 6;

        Console.WriteLine("WASCHSTRASSE (2 Plätze)");
        Console.WriteLine($"{anzahlAutos} Autos warten...");
        Console.WriteLine();

        // Alle Tasks parallel starten
        Task[] tasks = new Task[anzahlAutos];
        for (int i = 1; i <= anzahlAutos; i++)
        {
            int autoNummer = i;
            tasks[autoNummer - 1] = AutoWaschen(autoNummer);
        }

        // Auf alle Tasks warten
        await Task.WhenAll(tasks);

        double gesamtzeit = (DateTime.Now - startTime).TotalSeconds;

        Console.WriteLine();
        Console.WriteLine(new string('=', 40));
        Console.WriteLine($"    Alle {anzahlAutos} Autos gewaschen!");
        Console.WriteLine($"    Gesamtzeit: {gesamtzeit:F1}s");
        Console.WriteLine(new string('=', 40));
    }
}


