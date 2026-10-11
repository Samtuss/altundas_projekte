using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class XmlFormatter : ITextFormatter
    {
        public string Format(string text)
        {
            return $"<xml>{text}</xml>";
        }
    }
}
