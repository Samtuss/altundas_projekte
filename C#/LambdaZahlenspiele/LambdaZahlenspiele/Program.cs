namespace LambdaZahlenspiele
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> zahlen = new List<int> { 12, 7, 23, 4, 19, 8, 31, 15, 2, 28 };
            Console.WriteLine($"List: ");
            foreach (var zahl in zahlen)
            {
                Console.Write(" " + zahl);
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");


            Console.WriteLine("Alle Zahlen größer als 10:");
            zahlen.FindAll(x => x > 10).ForEach(x => Console.Write(" " + x));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Erste Zahl die durch 5 teilbar ist.");
            Console.WriteLine(" " + zahlen.Find(n => n % 5 == 0));
            Console.WriteLine();

            Console.WriteLine($"Existiert eine Zahl über 50?");
            Console.WriteLine(zahlen.Exists(x => x > 50));
            Console.WriteLine();

            Console.WriteLine("Alle Zahlen verdoppelt:");
            zahlen.ForEach(x => Console.Write(" " + x * 2));
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");


            Console.ReadKey();
        }
    }
}
