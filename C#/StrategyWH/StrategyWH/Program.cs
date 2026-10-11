using StrategyWH;

const string TITLE = "StrategyWH, Altundas Samet, 26.9.2025";
Console.Title = TITLE + " " + Environment.UserName + " " + Environment.MachineName + ", started at " + DateTime.Now;
Console.WriteLine(TITLE);


Vereinskasse vereinskasse = new Vereinskasse(new SchuelerRabatt());

Console.WriteLine($"\nRabatt: {vereinskasse.BerechneEndbetrag(100)}");


Console.WriteLine("\nHit Enter to Exit.");
Console.ReadLine();
