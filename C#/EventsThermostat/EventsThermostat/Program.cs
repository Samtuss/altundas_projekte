namespace EventsThermostat;

public class Program
{
    static void Main(string[] args)
    {
        Thermostat thermostat = new Thermostat();
        thermostat.Temperature = 22.0;
        thermostat.TempChanged += OnTemperatureChanged;

        thermostat.ChangeTemperature(23.5);


    }
    static void OnTargetTemperatureChanged(object sender, EventArgs e)
    {
        Console.WriteLine($"TargetTemperature was Changed");
    }
    static void OnTemperatureChanged(object sender, TempChangedEventArgs e)
    {
        Console.WriteLine($"Temperature was Changed. \nOld: {e.OldTemperature}\nNew: {e.NewTemperature}");
    }
    static void OnWindowOpened(object sender, EventArgs e)
    {
        Console.WriteLine($"Window was Opened");
    }
}
