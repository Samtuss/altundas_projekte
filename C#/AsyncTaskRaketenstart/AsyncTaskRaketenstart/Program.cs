namespace AsyncTaskRaketenstart
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Drücke eine Taste für Abbruch: W=Wetter, T=Technik, Esc= Manuell");

            var cts = new CancellationTokenSource();

            var token = cts.Token;

            string abortReason = "Unbekannt";

            int currentSecond = -1;

            Task<Status> CountdownTask = Task.Run(async () =>
            {
                int count = 10;

                for (int i = 10; i >= 0; i--)
                {
                    currentSecond = i;

                    if (token.IsCancellationRequested)
                        return new Status(false, "Countdown");

                    Console.WriteLine($"Countdown: {i}");
                    await Task.Delay(1000);
                }
                return new Status(true, "Countdown");
            }, token);


            Task<Status> keyTask = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    Thread.Sleep(10);
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.W)
                        {
                            abortReason = "Wetter";
                            return new Status(true, "Key");
                        }
                        else if (key == ConsoleKey.T)
                        {
                            abortReason = "Technik";
                            return new Status(true, "Key"); ;
                        }
                        else if (key == ConsoleKey.Escape)
                        {
                            abortReason = "Manuell";
                            return new Status(true, "Key"); ;
                        }
                    }
                }
                return new Status(false, "Key"); ;
            }, token);




            var first = await Task.WhenAny(CountdownTask, keyTask);

            if (first.Result.Name == "Key" && first.Result.Result == true)
            {
                cts.Cancel();
                Console.WriteLine($"ABORT! Start wurde bei T-{currentSecond} abgebrochen");
                Console.WriteLine($"Grund: {abortReason}");
            }
            else
            {
                Console.WriteLine("LIFTOFF! Rakete erfolgreich gestartet");
                cts.Cancel();
            }
            Console.ReadKey();
        }
    }
}
