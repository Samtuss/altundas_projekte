namespace EventsAmpel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event Ampel Bsp");

            Ampel ampel = new Ampel();

            ampel.FarbeGeaendert += ampel.OnFarbeGeaendert;


            ampel.SetFarbe("Rot");
            ampel.SetFarbe("Gelb");
            ampel.SetFarbe("Grün");
            ampel.SetFarbe("Gelb");
            ampel.SetFarbe("Rot");
        }
    }
}
