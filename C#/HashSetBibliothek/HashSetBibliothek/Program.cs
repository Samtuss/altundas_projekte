// C# Menu Skeleton
using HashSetBibliothek;
using System.Xml;

string title = "HashSetBibliothek, Altundas Asir Samet";
Console.Title = title;
Console.WindowHeight = 40;
Console.WindowWidth = 85;

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(title + "\r\n");
Console.ResetColor();

//display menu:
int mItem;
bool mExiting = false;

Bibliothek bibliothek = new Bibliothek();

bibliothek.AddBook(new Buch("978-3-16-148410-0", "Clean Code", "Robert C. Martin"));
bibliothek.AddBook(new Buch("978-0-13-468599-1", "Design Patterns", "Gang of Four"));
bibliothek.AddBook(new Buch("978-1-23-456789-7", "C# in Depth", "Jon Skeet"));
bibliothek.AddBook(new Buch("978-3-16-148410-0", "Clean Code", "Robert C. Martin"));

bibliothek.AvailableBooks();

bibliothek.AddBook2(new Buch("978-3-16-148410-0", "Clean Code", "Gang of Four"));
bibliothek.AddBook2(new Buch("978-3-16-148410-0", "Clean Code", "Robert C. Martin"));

bibliothek.AvailableBooks2();



while (!mExiting)
{
    Console.WriteLine("\r\n" + "Please choose an option:");
    Console.WriteLine("\t" + "0 ... Borrow book");
    Console.WriteLine("\t" + "1 ... Return book");
    Console.WriteLine("\t" + "2 ... Check status");
    Console.WriteLine("\t" + "3 ... View Overwiew");
    Console.WriteLine("\t" + "4 ... Intersect with oder was auch immer das sein soll.");
    Console.WriteLine("\t" + "5 ... ");
    Console.WriteLine("\t" + "6 ... ");
    Console.WriteLine("\t" + "9 ... Exit");
    Console.Write("Your selection: ");

    //Parse menu selection and dispatch
    if (int.TryParse(Console.ReadLine(), out mItem))
    {
        switch (mItem)
        {
            case 0:
                Console.WriteLine($"Gib ein: ISBN");
                string isbn = Console.ReadLine();
                bibliothek.BorrowBook(isbn);
                bibliothek.AvailableBooks();
                break;
            case 1:
                Console.WriteLine($"Gib ein: ISBN");
                string isbn2 = Console.ReadLine();
                bibliothek.ReturnBook(isbn2);
                bibliothek.AvailableBooks();
                break;
            case 2:
                Console.WriteLine($"Gib ein: ISBN");
                string isbn3 = Console.ReadLine();
                bibliothek.CheckStatus(isbn3);
                break;
            case 3:
                bibliothek.ViewOverwiew();
                break;
            case 4:
                bibliothek.IntersectWith();
                bibliothek.AvailableBooks();
                break;
            case 9:
                mExiting = true;
                break;

            default: //invalid number entered
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number 0 .. 9..");
                Console.ResetColor();
                break;
        }
    }
    else //invalid character entered
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Please enter a number 0 .. 9.");
        Console.ResetColor();
    }
}
Console.WriteLine("\r\n" + "Thank you!");

Console.ReadLine();
