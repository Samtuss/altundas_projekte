namespace WarenkorbStrategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warenkorb wk = new();
            WarenkorbLogger logger = new WarenkorbLogger();
            PreisAnzeige preisanzeige = new PreisAnzeige();
            RabattRechner rechner = new RabattRechner();


            wk.BestellungAbgeschlossen += rechner.OnBestellungAbgeschlossen;
            wk.ArtikelHinzugefügt += preisanzeige.OnArtikelHinzugefügt;
            wk.ArtikelHinzugefügt += logger.OnArtikelHinzugefügt;
            wk.BestellungAbgeschlossen += logger.OnBestellungAbgeschlossen;
            wk.BestellungAbgeschlossen += preisanzeige.OnBestellungAbgeschlossen;

            wk.ArtikelHinzufügen("Laptop", 999m);
            wk.ArtikelHinzufügen("Maus", 29m);
            wk.ArtikelHinzufügen("Tastatur", 79m);
            wk.Bestellen();

        }
    }
}
