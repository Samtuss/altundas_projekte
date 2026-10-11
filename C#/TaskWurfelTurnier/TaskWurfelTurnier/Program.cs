using System;
using System.Linq;
using System.Threading.Tasks;

namespace TaskWurfelTurnier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use Task<int> to get results from each player
            Task<int>[] tasks = new Task<int>[4];
            Console.WriteLine($"Würfel-Turnier beginnt!");
            for (int i = 0; i < tasks.Length; i++)
            {
                int bla = i;
                tasks[i] = Task.Run(() => Wurfeln(bla));
            }

            // Wait for all tasks to complete
            Task.WaitAll(tasks);

            // Collect results and determine the winner
            int maxSum = int.MinValue;
            int winner = -1;
            for (int i = 0; i < tasks.Length; i++)
            {
                int result = tasks[i].Result;
                Console.WriteLine($"Spieler {i} hat insgesamt {result} Punkte.");
                if (result > maxSum)
                {
                    maxSum = result;
                    winner = i;
                }
            }
            Console.WriteLine($"Spieler {winner} hat mit {maxSum} Punkten gewonnen!");
        }
        static int Wurfeln(int id)
        {
            int summe = 0, helper = 0;

            for (int i = 0; i < 1000; i++) 
            {
                helper = Random.Shared.Next(1, 7);
                summe += helper;
                //Thread.Sleep(1);
            }
            Console.WriteLine($"Spieler {id} ist fertig.");
            return summe;
        }
    }
}
