using System.Diagnostics;

namespace AsyncTaskSuchWettrennen
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            const int MAXSIZE = 1000;

            Random rnd = new Random();
            int gesucht = rnd.Next(1, MAXSIZE);
            Console.WriteLine($"Gesucht : {gesucht}");

            int[] array = new int[MAXSIZE];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, MAXSIZE);
            }

            Task<SuchErgebnis> TaskA = Suche(array, gesucht, 0, MAXSIZE / 3, "TaskA");
            Task<SuchErgebnis> TaskB = Suche(array, gesucht, MAXSIZE / 3 + 1, (MAXSIZE / 3) * 2, "TaskB");
            Task<SuchErgebnis> TaskC = Suche(array, gesucht, (MAXSIZE / 3) * 2 + 1, MAXSIZE - 1, "TaskC");

            await Task.WhenAll(TaskA, TaskB, TaskC);


            List<SuchErgebnis> results = new List<SuchErgebnis> { TaskA.Result, TaskB.Result, TaskC.Result };
            foreach (SuchErgebnis item in results)
            {
                Console.WriteLine($"{item.Sucher} - {item.Gefunden} - Index: {item.Index} ({item.SuchzeitMs}ms)");
            }
        }

        static async Task<SuchErgebnis> Suche(int[] array, int wert, int start, int end, string name)
        {
            int index = 0;
            bool gefunden = false;
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Run(() => {
                for (int i = start; i < end; i++)
                {
                    Thread.Sleep(1);
                    if (wert == array[i])
                    {
                        gefunden = true;
                        index = i;
                        Console.WriteLine($"Wert gefunden - Index: {i}");
                        sw.Stop();
                        break;
                    }
                }
                if (sw.IsRunning)
                {
                    sw.Stop();
                }
            });
            return new SuchErgebnis
            {
                Sucher = name,
                Gefunden = gefunden,
                Index = index,
                SuchzeitMs = sw.ElapsedMilliseconds,
            };
        }
    }
    class SuchErgebnis
    {

        public string Sucher { get; set; }
        public bool Gefunden { get; set; }
        public int Index { get; set; }
        public long SuchzeitMs { get; set; }
    }
}
