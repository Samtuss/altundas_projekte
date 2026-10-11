using System.Diagnostics;

namespace AsyncServerPing
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Task<ServerErgebnis> serverA = Task.Run(() => PingServerAsync("Server A", "Wien", 1800, 4500, cts.Token, Fehler10()));
            Task<ServerErgebnis> serverB = Task.Run(() => PingServerAsync("Server B", "Frankfurt", 1600, 4200, cts.Token, Fehler10()));
            Task<ServerErgebnis> serverC = Task.Run(() => PingServerAsync("Server C", "London", 1000, 4000, cts.Token, Fehler10()));
            Task<ServerErgebnis> serverD = Task.Run(() => PingServerAsync("Server D", "New York", 2500, 3500, cts.Token, Fehler10()));
            Task<ServerErgebnis> serverE = Task.Run(() => PingServerAsync("Server E", "Tokyo", 2000, 4000, cts.Token, Fehler10()));
            Task<ServerErgebnis> dummyServer = Task.Run(() => PingServerAsync("Timeout Server", "Timeout", 3000, 3000, cts.Token, Fehler10()));
            var first = await Task.WhenAny(serverA, serverB, serverC, serverD, serverE, dummyServer);
            var ergebnis = await first;

            //while (ergebnis.Fehler)
            //{
                
            //}
            

            cts.Cancel();
            if (ergebnis.Name == "Timeout Server")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fehler: Timeout");
            }



                Console.WriteLine();
            Console.WriteLine($"--------------------------------------------------------------------------------------");
            //Console.WriteLine($"{serverA.Result.Name} ({serverA.Result.Standort}) Erfolgreich: {serverA.Result.Erfolgreich} - Zeit: {serverA.Result.AntwortZeitMs}ms");
            //Console.WriteLine($"{serverB.Result.Name} ({serverB.Result.Standort}) Erfolgreich: {serverB.Result.Erfolgreich} - Zeit: {serverB.Result.AntwortZeitMs}ms");
            //Console.WriteLine($"{serverC.Result.Name} ({serverC.Result.Standort}) Erfolgreich: {serverC.Result.Erfolgreich} - Zeit: {serverC.Result.AntwortZeitMs}ms");
            //Console.WriteLine($"{serverD.Result.Name} ({serverD.Result.Standort}) Erfolgreich: {serverD.Result.Erfolgreich} - Zeit: {serverD.Result.AntwortZeitMs}ms");
            //Console.WriteLine($"{serverE.Result.Name} ({serverE.Result.Standort}) Erfolgreich: {serverE.Result.Erfolgreich} - Zeit: {serverE.Result.AntwortZeitMs}ms");
            Console.WriteLine();
            Console.WriteLine($"{serverA.Result}");
            Console.WriteLine($"{serverB.Result}");
            Console.WriteLine($"{serverC.Result}");
            Console.WriteLine($"{serverD.Result}");
            Console.WriteLine($"{serverE.Result}");

            //var list = new List<ServerErgebnis>();
            //list.Add(serverA.Result);
            //list.Add(serverB.Result);
            //list.Add(serverC.Result);
            //list.Add(serverD.Result);
            //list.Add(serverE.Result);


            Console.ReadKey();
        }
        static public async Task<ServerErgebnis> PingServerAsync(string name, string standort, int von, int bis, CancellationToken token, bool fehler)
        {
            try
            {
                Console.WriteLine($"{name} ({standort}: Anfrage gestartet...)");
                var antwortzeit = Random.Shared.Next(von, bis + 1);

                await Task.Delay(antwortzeit, token);

                return new ServerErgebnis(name, standort, true, antwortzeit, fehler);
            }
            catch (OperationCanceledException e)
            {
                return new ServerErgebnis(name, standort, false, 0, fehler);

            }
        }
        static bool Fehler10()
        {
            return Random.Shared.Next(1, 11) == 1;
        }
    }

    public class ServerErgebnis
    {
        public ServerErgebnis(string name, string standort, bool erfolgreich, long antwortZeitMs, bool fehler)
        {
            Name = name;
            Standort = standort;
            Erfolgreich = erfolgreich;
            AntwortZeitMs = antwortZeitMs;
            Fehler = fehler;
        }

        public string Name { get; set; }
        public string Standort { get; set; }
        public bool Erfolgreich { get; set; }
        public long AntwortZeitMs { get; set; }
        public bool Fehler { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Standort}): {(Erfolgreich ? "Antwort erhalten!" : "Abgebrochen")} {(AntwortZeitMs == 0 ? "" : $"({AntwortZeitMs}ms)")}";
        }
    }
}
