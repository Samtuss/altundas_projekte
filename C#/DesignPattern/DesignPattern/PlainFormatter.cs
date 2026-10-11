using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class PlainFormatter : ITextFormatter
    {
        public string Format(string text)
        {
            return text;
        }
    }
}
