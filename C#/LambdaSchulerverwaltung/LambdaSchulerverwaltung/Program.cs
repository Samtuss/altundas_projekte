namespace LambdaSchulerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Schueler> klasse = new List<Schueler>
            {
            new Schueler { Name = "Anna", Note = 2, Alter = 16 },
            new Schueler { Name = "Bob", Note = 4, Alter = 15 },
            new Schueler { Name = "Clara", Note = 1, Alter = 16 },
            new Schueler { Name = "David", Note = 3, Alter = 17 },
            new Schueler { Name = "Emma", Note = 2, Alter = 15 }
            };

            // Beispiel 1: Alle Schüler mit Note 1 oder 2 finden
            Console.WriteLine($"Alle Schüler mit 1 oder 2 als Note:");
            List<Schueler> finde1und2 = klasse.FindAll(s => s.Note == 1 || s.Note == 2);
            foreach (var schueler in finde1und2)
            {
                Console.WriteLine($"Name: {schueler.Name}, Note: {schueler.Note}, Alter: {schueler.Alter}");
            }
            Console.WriteLine();


            Console.WriteLine($"Erster Schueler mit 5 als Note:");
            Schueler erste5 = klasse.Find(s => s.Note == 5);
            Console.WriteLine(erste5?.Name);
            Console.WriteLine();

            Console.WriteLine($"Sind alle Schüler älter oder gleich 15?");
            var alleAelter15 = klasse.FindAll(s => s.Alter >= 15);
            if (alleAelter15.Count == klasse.Count) Console.WriteLine(true);
            else Console.WriteLine(false);
            Console.WriteLine();
            Console.WriteLine($"Sind alle Schüler älter oder gleich 15? - ist dasselbe - anderer Lösungsweg");
            bool alleAelter15B = klasse.FindAll(s => s.Alter >= 15).Count == klasse.Count;
            Console.WriteLine(alleAelter15B);
            Console.WriteLine();

            Console.WriteLine("Sind alle Schüler älter oder gleich 15? ist auch dasselbe - anderer Lösungsweg");
            Predicate<List<Schueler>> alleAelter15C = x => x.All(y => y.Alter >= 15);
            Console.WriteLine(alleAelter15C(klasse));
            Console.WriteLine();

            Console.WriteLine($"Alle Schüler nach Noten sortiert:");
            klasse.Sort((x,y) => x.Note.CompareTo(y.Note));
            // klasse.Reverse(); // damit absteigen sortiert ist
            foreach(Schueler x in klasse)
            {
                Console.WriteLine($"\tName: {x.Name}, Note: {x.Note}, Alter: {x.Alter}");
            }

            Console.WriteLine($"Alle Schüler nach Namen sortiert");
            klasse.Sort((x, y) => x.Name.CompareTo(y.Name));
            // klasse.Reverse(); // damit absteigen sortiert ist
            foreach (Schueler x in klasse)
            {
                Console.WriteLine($"\tName: {x.Name}, Note: {x.Note}, Alter: {x.Alter}");
            }

            Action<Schueler> nameToUpper = s => s.Name = s.Name.ToUpper();

            foreach (Schueler x in klasse)
            {
                nameToUpper(x);
            }
            Console.WriteLine($"Schüler Großbuchstaben:");
            foreach (Schueler x in klasse)
            {
                Console.WriteLine($"\tName: {x.Name}, Note: {x.Note}, Alter: {x.Alter}");
            }



            Console.WriteLine();
        }
    }
}
