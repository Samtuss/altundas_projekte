using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsTaschenrechner;

public class Rechner
{
    public int Addiere(int a, int b)
    {
        return a + b;
    }
    public int Subtrahiere(int a, int b)
    {
        return a - b;
    }
    public int Multipliziere(int a, int b)
    {
        return a * b;
    }
    public double Dividiere(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Division durch Null ist nicht erlaubt.");
        }
        return a / b;
    }
}
