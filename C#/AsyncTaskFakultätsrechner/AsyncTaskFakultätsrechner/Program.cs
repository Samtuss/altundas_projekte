using System.Numerics;
using System.Threading.Channels;

namespace AsyncTaskFakultätsrechner
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Berechne Fakultäten...\n");
            // TODO: Drei Tasks parallel starten
            var task20 = BerechneAsync(20);
            var task25 = BerechneAsync(25);
            var task30 = BerechneAsync(30);
            // TODO: Auf alle warten
            Console.WriteLine($"Warten...");
            await Task.WhenAll(task20, task25, task30);
            // TODO: Ergebnisse ausgeben

            Console.WriteLine($"20! - {task20.Result}");
            Console.WriteLine($"25! - {task25.Result}");
            Console.WriteLine($"30! - {task30.Result}");

        }
        static async Task<BigInteger> BerechneAsync(int n)
        {
            return await Task.Run(() => {
                // TODO: Fakultät berechnen
                BigInteger result = 1;
                for (int i = 2; i <= n; i++)
                    result *= i;
                return result;
            });
        }
    }
}
