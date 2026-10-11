namespace AsyncTaskPrimzahlPrüfer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            long zahl1 = 1_000_000_007;
            long zahl2 = 1_000_000_008;
            Console.WriteLine($"Prüfe {zahl1}...");
            Console.WriteLine($"Prüfe {zahl2}...");
            // TODO: Beide Tasks starten (parallel!)
            Task<bool> task1 = IstPrimzahlAsync(zahl1);
            Console.WriteLine($"Test");
            Task<bool> task2 = IstPrimzahlAsync(zahl2);

            // TODO: Mit WhenAll auf beide warten
            Task.WhenAll(task1, task2);

            // TODO: Ergebnisse ausgeben
            Console.WriteLine($"Zahl1:{zahl1}, {task1.Result} - Zahl2: {zahl2}, {task2.Result}");
        }
        static async Task<bool> IstPrimzahlAsync(long zahl)
        {
            return await Task.Run(() => {
                Console.WriteLine($"{zahl}");
                if (zahl < 2) return false;
                if (zahl == 2) return true;
                if (zahl % 2 == 0) return false;
                for (long i = 3; i < zahl; i += 2)
                {
                    if (zahl % i == 0)
                        return false;
                }
                return true;
            });
        }

    }
}
