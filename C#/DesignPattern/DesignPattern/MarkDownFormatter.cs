using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class MarkDownFormatter : ITextFormatter
    {
        public string Format(string text)
        {
            return $"> {text}";
        }
    }
}
