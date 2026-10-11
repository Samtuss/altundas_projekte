using System.Diagnostics.Metrics;

namespace TaskCount
{
    internal class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        {
            Task[] task = new Task[100];
            for (int i = 0; i < task.Length; i++)
            {
                task[i] = Task.Run(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        counter++;
                    }

                });
            }
            Task.WaitAll(task);
            Console.WriteLine(counter);

            Task<int> s1 = Task.Run(() => { int sum = 0; for (int i = 0; i < 1000; i++) sum++; return sum; });
            Task<int> s2 = Task.Run(() => { int sum = 0; for (int i = 0; i < 1000; i++) sum++; return sum; });
            Task<int> s3 = Task.Run(() => { int sum = 0; for (int i = 0; i < 1000; i++) sum++; return sum; });
            Task<int> s4 = Task.Run(() => { int sum = 0; for (int i = 0; i < 1000; i++) sum++; return sum; });

            int summe = s1.Result + s2.Result + s3.Result + s4.Result;

            Console.WriteLine("Summe: " + summe);

            Console.WriteLine($"Anna: {s1.Result}");
            Console.WriteLine($"Ben: {s2.Result}");
            Console.WriteLine($"Clara: {s3.Result}");
            Console.WriteLine($"David: {s4.Result}");

            Console.ReadKey();

        }
    }
}
