using System.ComponentModel;

namespace TaskCountdownDuell
{
    internal class Program
    {
        public static bool gewonnen = false; // DÖRTY CODING!!!!!!!!!!!!!!!!!
        static void Main(string[] args)
        {
            Task taskA = Task.Run(() => Countdown("A", 10, 300));
            Task taskB = Task.Run(() => Countdown("B", 15, 300));
            Task.WaitAll(taskA, taskB);
            Console.WriteLine("Beide Countdowns beendet.");

            Console.ReadKey();
        }
        static void Countdown(string name, int start, int delayMs)
        {
            // TODO: Von start runterzählen bis 0
            // TODO: Bei jedem Schritt den Wert ausgeben
            // TODO: delayMs Millisekunden warten
            // TODO: Bei 0 den Gewinner ausgeben

            while (start > 0)
            {
                Console.WriteLine($"{name} : {start}");
                Thread.Sleep(delayMs);
                start--;
            }
            if (!gewonnen)
            {
                gewonnen = true; // DÖRTY CODING!!!!!!!!!!!!!!!!!
                Console.WriteLine($"{name} hat gewonnen!"); 
            }
        }

    }
}
