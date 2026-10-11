//using System.Diagnostics;

//namespace AsyncTaskZahlenschlossKnacken
//{
//    public class Program
//    {
//        static async Task Main(string[] args)
//        {
//            using var cts = new CancellationTokenSource();
//            // Geheimen Code generieren
//            Random rnd = new Random();
//            int geheimcode = rnd.Next(0, 10000);

//            Console.WriteLine(" Zahlenschloss-Challenge");
//            Console.WriteLine("   Geheimer Code wurde generiert...\n");

//            // TODO: Vier Knacker-Tasks starten (parallel!)
//            var taskAnna = KnackeAsync("Anna", 0, 2499, geheimcode, cts.Token);
//            var taskBert = KnackeAsync("Bert", 2500, 4999, geheimcode, cts.Token);
//            var taskClara = KnackeAsync("Clara", 5000, 7499, geheimcode, cts.Token);
//            var taskDavid = KnackeAsync("David", 7500, 9999, geheimcode, cts.Token);

//            Console.WriteLine("Anna  startet (0000-2499)");
//            Console.WriteLine("Bert  startet (2500-4999)");
//            Console.WriteLine("Clara startet (5000-7499)");
//            Console.WriteLine("David startet (7500-9999)\n");
//            Console.WriteLine($"Knacken...");
//            _ = Task.Run(() =>
//            {
//                Console.ReadLine();
//                cts.Cancel();
//            });
//            try
//            {
//                await Task.WhenAll(taskAnna, taskBert, taskClara, taskDavid);
//                Console.WriteLine($"{taskAnna.Result.Name}: Gefunden: {taskAnna.Result.Gefunden} - Versuche: {taskAnna.Result.Versuche} ({taskAnna.Result.ZeitMs}ms)");
//                Console.WriteLine($"{taskBert.Result.Name}: Gefunden: {taskBert.Result.Gefunden} - Versuche: {taskBert.Result.Versuche} ({taskBert.Result.ZeitMs}ms)");
//                Console.WriteLine($"{taskClara.Result.Name}: Gefunden: {taskClara.Result.Gefunden} - Versuche: {taskClara.Result.Versuche} ({taskClara.Result.ZeitMs}ms)");
//                Console.WriteLine($"{taskDavid.Result.Name}: Gefunden: {taskDavid.Result.Gefunden} - Versuche: {taskDavid.Result.Versuche} ({taskDavid.Result.ZeitMs}ms)");

//            }
//            catch (OperationCanceledException)
//            {
//                Console.WriteLine($"Arbeit wurde abgebrochen.");
//            }

//            // TODO: Auf alle warten mit await Task.WhenAll(...)
//            // TODO: Ergebnisse ausgeben
//            // TODO: Gewinner finden und ausgeben



//        }
//        static async Task<KnackErgebnis> KnackeAsync(string name, int von, int bis, int geheimcode, CancellationToken cancellationToken)
//        {
//            return await Task.Run(() =>
//            {
//                var sw = Stopwatch.StartNew();
//                int versuche = 0;

//                for (int versuch = von; versuch <= bis; versuch++)
//                {
//                    versuche++;
//                    Thread.Sleep(1);  // Simuliert Ausprobieren

//                    if (versuch == geheimcode)
//                    {
//                        sw.Stop();
//                        return new KnackErgebnis
//                        {
//                            Name = name,
//                            Gefunden = true,
//                            Code = versuch,
//                            Versuche = versuche,
//                            ZeitMs = sw.ElapsedMilliseconds
//                        };
//                    }

//                }

//                sw.Stop();
//                return new KnackErgebnis
//                {
//                    Name = name,
//                    Gefunden = false,
//                    Versuche = versuche,
//                    ZeitMs = sw.ElapsedMilliseconds
//                };
//            });
//        }
//    }
//    class KnackErgebnis
//    {
//        public string Name { get; set; }
//        public bool Gefunden { get; set; }
//        public int Code { get; set; }
//        public int Versuche { get; set; }
//        public long ZeitMs { get; set; }
//    }
//}


// CHATGPT

using System.Diagnostics;

namespace AsyncTaskZahlenschlossKnacken
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using var cts = new CancellationTokenSource();

            // Geheimen Code generieren
            Random rnd = new Random();
            int geheimcode = rnd.Next(0, 10000);

            Console.WriteLine(" Zahlenschloss-Challenge");
            Console.WriteLine($"\tGeheimer Code wurde generiert...\n");

            // 🔧 ÄNDERUNG:
            // Statt nur den CancellationToken zu übergeben,
            // übergeben wir bewusst die CancellationTokenSource,
            // damit ein Task alle anderen abbrechen kann.
            var taskAnna = KnackeAsync("Anna", 0, 2499, geheimcode, cts);
            var taskBert = KnackeAsync("Bert", 2500, 4999, geheimcode, cts);
            var taskClara = KnackeAsync("Clara", 5000, 7499, geheimcode, cts);
            var taskDavid = KnackeAsync("David", 7500, 9999, geheimcode, cts);

            Console.WriteLine("Anna  startet (0000-2499)");
            Console.WriteLine("Bert  startet (2500-4999)");
            Console.WriteLine("Clara startet (5000-7499)");
            Console.WriteLine("David startet (7500-9999)\n");

            Console.WriteLine("Knacken... (Enter = Abbruch)");

            // 🔧 ÄNDERUNG:
            // Benutzer kann jederzeit per Enter abbrechen
            _ = Task.Run(() =>
            {
                Console.ReadLine();
                cts.Cancel();
            });

            try
            {
                // 🔧 ÄNDERUNG:
                // Wenn ein Task cancelt, wirft WhenAll eine OperationCanceledException
                await Task.WhenAll(taskAnna, taskBert, taskClara, taskDavid);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nKnacken wurde abgebrochen.\n");
            }

            // Ergebnisse ausgeben (nur abgeschlossene Tasks)
            PrintResult(taskAnna);
            PrintResult(taskBert);
            PrintResult(taskClara);
            PrintResult(taskDavid);
        }

        static void PrintResult(Task<KnackErgebnis> task)
        {
            var r = task.Result;
            Console.WriteLine($"{r.Name}: Gefunden: {r.Gefunden} - Versuche: {r.Versuche} ({r.ZeitMs} ms)");
        }

        static async Task<KnackErgebnis> KnackeAsync(string name, int von, int bis, int geheimcode, CancellationTokenSource cts)
        {
            var token = cts.Token;

            var sw = Stopwatch.StartNew();
            int versuche = 0;

            for (int versuch = von; versuch <= bis; versuch++)
            {
                // 🔧 ÄNDERUNG:
                // Jeder Durchlauf prüft, ob ein anderer Task bereits gewonnen hat
                // token.ThrowIfCancellationRequested();
                if (token.IsCancellationRequested)
                {
                    sw.Stop();
                    return new KnackErgebnis
                    {
                        Name = name,
                        Gefunden = false,
                        Versuche = versuche,
                        ZeitMs = sw.ElapsedMilliseconds
                    };
                }


                versuche++;

                // 🔧 ÄNDERUNG:
                // Thread.Sleep blockiert Threads → Task.Delay ist async & cancelbar
                await Task.Delay(1);

                if (versuch == geheimcode)
                {
                    // 🔧 ÄNDERUNG:
                    // Gewinner stoppt alle anderen Tasks
                    cts.Cancel();

                    sw.Stop();
                    return new KnackErgebnis
                    {
                        Name = name,
                        Gefunden = true,
                        Code = versuch,
                        Versuche = versuche,
                        ZeitMs = sw.ElapsedMilliseconds
                    };
                }
            }

            sw.Stop();
            return new KnackErgebnis
            {
                Name = name,
                Gefunden = false,
                Versuche = versuche,
                ZeitMs = sw.ElapsedMilliseconds
            };
        }
    }

    class KnackErgebnis
    {
        public string Name { get; set; }
        public bool Gefunden { get; set; }
        public int Code { get; set; }
        public int Versuche { get; set; }
        public long ZeitMs { get; set; }
    }
}
