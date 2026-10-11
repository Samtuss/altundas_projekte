using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSmartphoneAkku;

public class Smartphone
{
    private int _batteryStatus; // Backing field for BatteryStatus

    public int BatteryStatus
    {
        get => _batteryStatus;
        set 
        {
            int oldValue = _batteryStatus;
            _batteryStatus = value; // Update the backing field
            if (_batteryStatus <= 20 && _batteryStatus != oldValue)
                Batterylow?.Invoke(this, EventArgs.Empty);
        }
    }

    public Smartphone()
    {
        BatteryStatus = 100;
    }

    public event EventHandler<EventArgs> Batterylow;

    public void OnBatteryLow(object sender, EventArgs e) // Updated method signature
    {
        Console.WriteLine("Achtung: Akku fast leer!");
    }
}
