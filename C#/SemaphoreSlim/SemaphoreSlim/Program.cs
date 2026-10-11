using System.Diagnostics;

namespace SemaphoreSlimShow
{
    internal class Program
    {
        static SemaphoreSlim kassen = new SemaphoreSlim(5);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Task[] tasks = new Task[15];
            for (int i = 0; i < 15; i++)
            {
                string kunde = $"Kunde{i + 1}";
                tasks[i] = Task.Run(() => Einkaufen(kunde));
            }
            Task.WaitAll(tasks);

        }
        static void Einkaufen(string kunde)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine($"{kunde} betritt den Laden...");
            // TODO: Warten ausgeben
            // TODO: Wait() aufrufen
            Console.WriteLine($"{kunde} wartet auf Zugang...");
            kassen.Wait();
            Console.WriteLine($"{kunde} hat Zugang...");
            try
            {
                Console.WriteLine($"{kunde} ist an der Kasse!");
                Thread.Sleep(Random.Shared.Next(1000, 3000));
                Console.WriteLine($"{kunde} hat bezahlt und geht.");
            }
            finally
            {
                // TODO: Release() aufrufen
                kassen.Release();
                sw.Stop();
                Console.WriteLine($"\t {kunde} - Wartezeit: {sw.ElapsedMilliseconds} ms");
            }

        }
        

    }
}
