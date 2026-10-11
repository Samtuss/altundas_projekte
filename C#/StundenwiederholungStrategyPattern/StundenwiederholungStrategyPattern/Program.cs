namespace StundenwiederholungStrategyPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            Kasse kasse = new Kasse(new HtmlFormatierer());

            Bestellung bestellung = new Bestellung("kunde1", "artikel1", 20.20m);
            kasse.Druck(bestellung);

            KasseA kasseA = new KasseA(new HtmlFormatiererA());
            kasseA.Druck(bestellung);


            // Ein interface verwende ich, wenn:
            // 
        }
    }
}
