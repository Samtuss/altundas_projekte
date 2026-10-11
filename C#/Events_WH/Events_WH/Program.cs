namespace Events_WH;

internal class Program
{
    static void Main(string[] args)
    {
        Alarm alarm = new Alarm();

        alarm.Alarmiert += AlarmHandler;
        alarm.Alarmiert += AlarmLogger;

        alarm.Klingeln();

        alarm.Alarmiert -= AlarmHandler;

        alarm.Klingeln();
    }
    static public void AlarmHandler(object sender, EventArgs args)
    {
        Console.WriteLine($"Alarm/Handler wurde aktiviert.");
    }
    public static void AlarmLogger(object sender, EventArgs args)
    {
        Console.WriteLine($"AlarmLogger aufgerufen");
    }
}
