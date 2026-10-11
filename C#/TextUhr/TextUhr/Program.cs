using TextUhr;
const string TITLE = "TextUhr, Asir Samet Altundas 3BHIF, V1.0";
Console.Title = TITLE + " " + Environment.UserName + " " + Environment.MachineName + ", started at " + DateTime.Now;
Console.WriteLine(TITLE);

GetTimeAsText uhr = new GetTimeAsText();

while (true)
{
    Console.Clear();
    Console.WriteLine("Aktuelle Uhrzeit:");
    Console.WriteLine();
    Console.WriteLine(uhr.GetCurrentTimeAsText());

    Thread.Sleep(1000); // 1 sekunde
}






Console.WriteLine("\nHit Enter to Exit.");
Console.ReadLine();
