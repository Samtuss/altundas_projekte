using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class TextOutput
    {
        private ITextFormatter _formatter;
        public TextOutput(ITextFormatter formatter)
        {
            _formatter = formatter;
        }
        public void SetFormatter(ITextFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Write(string text)
        {
            // gibt das Ergebnis von _formatter.Format(text) auf der Konsole aus
            Console.WriteLine(_formatter.Format(text));
        }
    }
}
