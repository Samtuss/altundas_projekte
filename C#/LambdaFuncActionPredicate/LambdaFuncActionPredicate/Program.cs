namespace LambdaFuncActionPredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Lambda - Aufgabe 2 - Func, Action, Predicate");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Func: Quadriert eine Zahl");
            Func<int, int> quadriere = x => x * x;
            Console.WriteLine(quadriere(5));
            Console.WriteLine();

            Console.WriteLine("Func: Prüft ob ein String länger ist als 5 Zeichen");
            Func<string,bool> istLaengerAls5 = s => s.Length > 5;
            Console.WriteLine(istLaengerAls5("Hallo Welt"));
            Console.WriteLine(istLaengerAls5("hey"));
            Console.WriteLine();

            Console.WriteLine($"Func: Dividiert 2 Zahlen");
            Func<double, double, double> dividiere = (a, b) => a / b;
            Console.WriteLine(dividiere(10, 2));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Action: Gibt einen Text in Großbuchstaben aus");
            Action<string> gibInGrossbuchstabenAus = s => Console.WriteLine(s.ToUpper());
            gibInGrossbuchstabenAus("Hallo Welt");
            Console.WriteLine();

            Console.WriteLine($"Action: Multipliziert 2 Zahlen");
            Action<int, int> multipliziereUndGibAus = (a, b) => Console.WriteLine(a * b);
            multipliziereUndGibAus(6, 7);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"Predicate: Schaut ob Zahl negativ ist");
            Predicate<int> istNegativ = x => x < 0;
            Console.WriteLine(istNegativ(-5));
            Console.WriteLine(istNegativ(3));
            Console.WriteLine();

            Console.WriteLine($"Schaut ob ein string mit 'A' beginnt");
            Predicate<string> beginntMitA = s => s.StartsWith("A");
            Console.WriteLine(beginntMitA("Apfel"));
            Console.WriteLine(beginntMitA("Banane"));
            Console.WriteLine();



        }
    }
}
