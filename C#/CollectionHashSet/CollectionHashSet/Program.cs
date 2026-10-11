// C# Menu Skeleton
string title = "CollectionHashSet";
Console.Title = title;
Console.WindowHeight = 40;
Console.WindowWidth = 85;

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(title + "\r\n");
Console.ResetColor();

//display menu:
int mItem;
bool mExiting = false;

HashSet<string> members = new HashSet<string>();

while (!mExiting)
{
    Console.WriteLine("\r\n" + "Please choose an option:");
    Console.WriteLine("\t" + "0 ... Add member");
    Console.WriteLine("\t" + "1 ... Remove member");
    Console.WriteLine("\t" + "2 ... Find member");
    Console.WriteLine("\t" + "3 ... Show all members");
    Console.WriteLine("\t" + "4 ... Show member count");
    Console.WriteLine("\t" + "5 ... Exit");
    Console.Write("Your selection: ");

    //Parse menu selection and dispatch
    if (int.TryParse(Console.ReadLine(), out mItem))
    {
        switch (mItem)
        {
            case 0:
                Console.WriteLine($"Enter name:");
                string nameToAdd = Console.ReadLine() ?? string.Empty; // ?? bedeutet: falls der benuter nichts eingibt, wird ein leerer String verwendet ("")
                if (members.Add(nameToAdd.Trim().ToLower())) // Add returns true if the item was added, false if it was already present
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Member '{nameToAdd}' added.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Member '{nameToAdd}' already exists.");
                    Console.ResetColor();
                }
                break;
            case 1:
                Console.WriteLine($"Enter name: ");
                string nameToRemove = Console.ReadLine() ?? string.Empty;
                if (members.Remove(nameToRemove.Trim().ToLower())) // Remove returns true if the item was removed, false if it was not found
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Member '{nameToRemove}' removed.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Member '{nameToRemove}' not found.");
                    Console.ResetColor();
                }
                break;
            case 2:
                Console.WriteLine($"Enter name: ");
                string nameToFind = Console.ReadLine() ?? string.Empty;
                if (members.Contains(nameToFind.Trim().ToLower())) // Contains returns true if the item is found, false otherwise
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Member '{nameToFind}' found.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Member '{nameToFind}' not found.");
                    Console.ResetColor();
                }
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Members:");
                Console.ResetColor();
                int count = 0;
                foreach (var member in members)
                {
                    count++;
                    Console.WriteLine($"   {count}. {member}");
                }
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Member count: {members.Count}");
                Console.ResetColor();
                break;
            case 5:
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
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\r\n" + "Thank you!");
Console.ResetColor();

Console.ReadLine();