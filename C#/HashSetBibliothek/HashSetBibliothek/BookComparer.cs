using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetBibliothek
{
    public class BookComparer : IEqualityComparer<Buch>
    {
        public bool Equals(Buch x, Buch y)
        {
            if (x == null || y == null) return false;
            if (x == null && y == null) return true;
            return x.Autor == y.Autor && x.Titel == y.Titel;
        }
        public int GetHashCode(Buch obj)
        {
            return obj.Autor.GetHashCode() + obj.Titel.GetHashCode();
        }
    }
}
