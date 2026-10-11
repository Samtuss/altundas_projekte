namespace TasksSchneckenrennen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => Schnecke("Turbo"));
            Task t2 = Task.Run(() => Schnecke("Blitz"));
            Task t3 = Task.Run(() => Schnecke("Speedi"));

            Task.WaitAll(t1, t2, t3);
            Console.WriteLine("Das Rennen ist beendet!");
        }
        static void Schnecke(string name)
        {
            Random rnd = new Random();

            int position = 0;
            while(position < 20)
            {
                position += rnd.Next(1, 4); // Schnecke bewegt sich um 1 bis 3 Positionen vorwärts

                Thread.Sleep(rnd.Next(200, 501)); // Kurze Pause, um das Rennen zu verlangsamen
                Console.WriteLine($"{name}, Position: {position}");
            }
            Console.WriteLine($"{name} ist im Ziel");

        }
    }
}
