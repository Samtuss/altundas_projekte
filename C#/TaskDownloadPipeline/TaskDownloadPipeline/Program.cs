namespace TaskDownloadPipeline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Installation gestartet...");
            Task.Run(() => {
                Console.WriteLine("[Download] Lade Datei herunter...");
                Thread.Sleep(2000);
                int groesse = 1500;
                Console.WriteLine($"[Download] Fertig! Größe: {groesse} KB");
                return groesse;
            })
            .ContinueWith(t => {
                Console.WriteLine($"[Entpacken] Entpacke 1500 KB...");
                Console.WriteLine($"Der vorherige Thread hat {t.Result} KB");
                Thread.Sleep(1000);
                Console.WriteLine($"[Entpacken] Fertig! Entpackt: 4500 KB");
            })
            .ContinueWith(t => {
                Console.WriteLine($"[Installieren] Installiere 4500 KB...\r\n");
                Thread.Sleep(1000);
                Console.WriteLine($"[Installieren] Installation abgeschlossen!\r\n");
            });
            Console.WriteLine("Hauptthread ist frei!\n");
            Thread.Sleep(6000); // Warten auf Pipeline

        }
    }
}
