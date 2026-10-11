using System.Threading.Tasks;

namespace TaskParalleleBerechnungen
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Parallele Berechnung Startet");
            Task<long> t1 = Task.Run(() => Summiere("A", 1, 1000000));
            Task<long> t2 = Task.Run(() => Summiere("B", 1000001, 2000000));

            Task.WhenAll(t1, t2).ContinueWith(t =>
            {
                long summe = t1.Result + t2.Result;
                Console.WriteLine($"Summe: {summe}");
            });
            Console.WriteLine($"Beide fertig!");
            Thread.Sleep(1000);
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
