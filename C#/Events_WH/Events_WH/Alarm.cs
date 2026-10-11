namespace Events_WH;

internal class Alarm
{
    public event EventHandler Alarmiert;
    public void Klingeln()
    {
        Console.Beep();
        Console.Beep();
        Console.Beep();
        Console.WriteLine($"Alarm läuft");

        Alarmiert.Invoke(this, EventArgs.Empty);
    }
}