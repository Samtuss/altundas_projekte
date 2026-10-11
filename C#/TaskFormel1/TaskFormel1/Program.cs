using System.Diagnostics;

namespace TaskFormel1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Rennen gestartet!\n");
            Task<RennErgebnis> t1 = Task.Run(() => FahreRennen("Verstappen", 5));
            Task<RennErgebnis> t2 = Task.Run(() => FahreRennen("Hamilton", 5));
            Task<RennErgebnis> t3 = Task.Run(() => FahreRennen("Norris", 5));
            Task.WaitAll(t1, t2, t3);
            // TODO: Ergebnisse sammeln
            // TODO: Nach Gesamtzeit sortieren (LINQ?)
            // TODO: Podium ausgeben
            // TODO: Nach schnellster Runde sortieren
            var ergebnisse = new List<RennErgebnis> { t1.Result, t2.Result, t3.Result };

            var schnellsteRunde = ergebnisse.OrderBy(e => e.SchnellsteRundeMs).ToList();//hier LINQ
            var schnellsteRundeFahrer = schnellsteRunde.First();
            schnellsteRundeFahrer.GesamtzeitMs -= 250; // Belohnung für schnellste Runde
            Console.WriteLine($"\nSchnellste Runde Fahrer:  " +  schnellsteRundeFahrer);

            var sortiert = ergebnisse.OrderBy(e => e.GesamtzeitMs).ToList();//hier LINQ
            var gewinner = sortiert.First();

            Console.WriteLine($"\nGewinner: {gewinner.Fahrer}");
            Console.ReadKey();
        }
        static RennErgebnis FahreRennen(string name, int rpiunden)
        {
            Random rnd = new Random();
            Stopwatch gesamt = new Stopwatch();
            Stopwatch rpiunde = new Stopwatch();
            long schnellste = long.MaxValue;
            gesamt.Start();
            for (int i = 1; i <= rpiunden; i++)
            {
                rpiunde.Restart();
                // TODO: Zufällige Rundenzeit (1000-1500ms) warten
                Thread.Sleep(rnd.Next(1000, 1501));

                // 20% Chance für eine "Boxenstopp"-Runde
                int rng = rnd.Next(1, 101);
                if (rng <= 20)
                {
                    // Boxenstopp: zusätzliche 500-1000ms warten
                    Thread.Sleep(rnd.Next(500));
                    Console.WriteLine($"Boxenstopp: {name}");
                }

                rpiunde.Stop();
                long zeit = rpiunde.ElapsedMilliseconds;
                Console.WriteLine($"{name} - Runde {i}: {zeit} ms");
                // TODO: Schnellste Runde merken
                if (zeit < schnellste)
                    schnellste = zeit;
            }
            gesamt.Stop();
            // TODO: RennErgebnis zurückgeben
            return new RennErgebnis(name, gesamt.ElapsedMilliseconds, schnellste);
        }
    }
}
