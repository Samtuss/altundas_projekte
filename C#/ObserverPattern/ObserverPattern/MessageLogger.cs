using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class MessageLogger : IObserver
    {
        List<string> messages = new List<string>();
        public void Update(string message)
        {
            messages.Add($"[{DateTime.Now}] : {message}");
        }

        public void SendLog()
        {
            foreach(string message in messages)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine($"\n" + messages.Count);
        }
    }
}
