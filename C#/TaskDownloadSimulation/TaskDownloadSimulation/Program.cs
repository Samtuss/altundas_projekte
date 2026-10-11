namespace TaskDownloadSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Downloads starten...\n");
            Task t1 = Task.Run(() => Download("foto.jpg", 5000));
            Task t2 = Task.Run(() => Download("video.mp4", 8000));
            Task t3 = Task.Run(() => Download("musik.mp3", 3000));
            Task.WaitAll(t1, t2, t3);
            Console.WriteLine("\nAlle Downloads abgeschlossen!");

        }
        static void Download(string dateiname, int gesamtZeitMs)
        {
            int pauseProSchritt = gesamtZeitMs / 10;
            for (int prozent = 10; prozent <= 100; prozent += 10)
            {
                Thread.Sleep(pauseProSchritt);
                Console.WriteLine($"{dateiname}: {prozent}%");
            }
            Console.WriteLine($"{dateiname}: Download abgeschlossen!");
        }
    }
}
