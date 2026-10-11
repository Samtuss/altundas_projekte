using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vergleich_ED;

public class Vergleich
{
    public delegate void MeineMethode();
    public MeineMethode Meindelegate;
    public event MeineMethode MeinEvent;

    public void InternTesten()
    {
        MeinEvent?.Invoke();
        Meindelegate?.Invoke();
    }

}
