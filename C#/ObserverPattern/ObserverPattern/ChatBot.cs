using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ChatBot : ISubject
    {
        List<string> messages = new List<string>();
        List<IObserver> _user = new List<IObserver>();
        public ChatBot()
        {
            messages.Add("Ich bin ein Bot1");
            messages.Add("Ich bin ein Bot2");
            messages.Add("Ich bin ein Bot3");
            messages.Add("Ich bin ein Bot4");
            messages.Add("Ich bin ein Bot5");
        }
        public void Notify(string message)
        {
            foreach (var listMessage in messages)
            {
                foreach(IObserver singleObserver in _user)
                {
                    singleObserver.Update(listMessage);
                }
                Thread.Sleep(1000);
            }
        }

        public void Register(IObserver observer)
        {
            _user.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _user.Remove(observer);
        }
    }
}
