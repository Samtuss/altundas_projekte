using EventsSmartphoneAkku;
namespace EventsSmartphoneAkku;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"SmartphoneAkku Bsp");
        Smartphone sp = new Smartphone();

        sp.Batterylow += sp.OnBatteryLow;


        for (int i = 9; i >= 0; i--)
        {
            sp.BatteryStatus -= 10;
            Console.WriteLine($"{sp.BatteryStatus} %");


        }
    }
}
