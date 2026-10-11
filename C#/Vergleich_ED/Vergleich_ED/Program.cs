namespace Vergleich_ED;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Vergleich Bsp");
        Vergleich vergleich = new Vergleich();

        vergleich.Meindelegate = EventHandler;
        vergleich.Meindelegate += EventHandler2;

        vergleich.Meindelegate?.Invoke();

        //vergleich.MeinEvent = EventHandler; geht nicht!
        vergleich.MeinEvent += EventHandler;
        vergleich.MeinEvent += EventHandler2;

        //vergleich.MeinEvent?.Invoke(); geht nicht, da Event nur innerhalb der Klasse aufgerufen werden kann
        vergleich.InternTesten();

    }
    public static void EventHandler()
    {
        Console.WriteLine($"EventHandler1");
    }
    public static void EventHandler2()
    {
        Console.WriteLine($"EventHandler2");
        Console.WriteLine();
    }
}
