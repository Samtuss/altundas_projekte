using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryZeiterfassungssystem;

public class TimeEntry
{
    public DateTime Timestamp { get; set; }
    public string EmployeeId { get; set; }
    public string Project { get; set; }
    public double Hours { get; set; }
    public string Descriptio{ get; set; }
}
