using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ChatUser : IObserver
    {
        public string Name { get; }
        public ChatUser(string name) { Name = name; }
        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"[{Name}] empfängt: {message}");
        }

        public void Update(string message)
        {
            ReceiveMessage(message);
        }
    }
}
