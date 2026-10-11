using System.Threading.Channels;

namespace EventsThermostat;

public class Thermostat
{
    public event EventHandler<TempChangedEventArgs> TempChanged;
    public event EventHandler<EventArgs> TargetTempChanged;
    public event EventHandler<EventArgs> WindowOpened;

    private double _temperature;
    public double Temperature 
    { 
        get => _temperature;
        set
        {
            if(_temperature != value)
            {
                TempChanged?.Invoke(this, new TempChangedEventArgs(_temperature, value));
                _temperature = value;
            }
        }
    }

    public void ChangeTemperature(double newTemperature)
    {
        Temperature = newTemperature;
    }

}
public class TempChangedEventArgs : EventArgs
{
    public double OldTemperature { get; }
    public double NewTemperature { get; }
    public TempChangedEventArgs(double oldTemp, double newTemp)
    {
        OldTemperature = oldTemp;
        NewTemperature = newTemp;
    }
}