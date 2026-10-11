using System.Diagnostics;

namespace Rechenduell
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Rechenduell startet!");

            Stopwatch sw = Stopwatch.StartNew();

            Task<long> rechnerA = Task.Run(() => Summiere("Rechner A", 1, 1000000));
            Task<long> rechnerB = Task.Run(() => Summiere("Rechner B", 1000001, 2000000));
            Task<long> rechnerC = Task.Run(() => Summiere("Rechner C", 2000001, 3000000));

            Task.WaitAll(rechnerA, rechnerB, rechnerC);

            long gesamtSumme = rechnerA.Result + rechnerB.Result + rechnerC.Result;

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"Gesamtsumme: {gesamtSumme}");
            Console.WriteLine($"Berechnungszeit: {sw.ElapsedMilliseconds} ms");
            
        }

        static long Summiere(string name, int von, int bis)
        {
            Console.WriteLine($"{name}: Starte ({von} bis {bis})");

            long summe = 0;
            for (int i = von; i <= bis; i++)
            {
                summe += i;
            }

            Console.WriteLine($"{name}: Fertig! Summe = {summe}");
            return summe;
        }
    }
}
