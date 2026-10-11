using System.Runtime.ConstrainedExecution;

namespace AsyncTaskCancellationDemo;

public class Program
{
    static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource();
        // Beispiel: nach 5 Sekunden automatisch abbrechen
        cts.CancelAfter(TimeSpan.FromSeconds(5));
        Console.WriteLine("Starte Arbeit, drücke ENTER zum Abbrechen.");
        var workTask = DoWorkAsync(cts.Token);
        // Benutzerabbruch per ENTER
        _ = Task.Run(() => // Der Unterstrich _ vor dem = ist eine moderne C#-Syntax (ab C# 7.0), die als
                            //Discard(Wegwerfvariable) bezeichnet wird.Sie signalisiert dem Compiler,
                            //dass der Rückgabewert von Task.Run(...) absichtlich ignoriert wird.
        {
            Console.ReadLine();
            cts.Cancel();
        });
        try
        {
            await workTask;
            Console.WriteLine("Arbeit fertig.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Arbeit wurde abgebrochen.");
        }
    }
    static async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        // Beispiel: 10 Schritte, jeweils 1 s warten
        for (int i = 1; i <= 10; i++)
        {
            // Wir nutzen eine API, die den Token unterstützt
            await Task.Delay(1000, cancellationToken); // wirft OperationCanceledException bei Abbruch
                                                       // Zusätzlich explizit prüfen (z.B. nach rechenintensiven Blöcken)
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine($"Schritt {i} erledigt.");
        }
    }
}
