using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ChatChannel : ISubject
    {
        private List<IObserver> _users = new List<IObserver>();
        public ChatChannel(List<IObserver> users) { _users = users; }
        public ChatChannel()
        {
                
        }

        public void Send(string message)
        {
            foreach (var user in _users)
            {
                user.Update(message);
            }
        }

        public void Register(IObserver observer)
        {
            _users.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _users.Remove(observer);
        }

        public void Notify(string message)
        {
            Send(message);
        }
    }
}
