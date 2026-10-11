using BubbleSort;
const string TITLE = "BubbleSortWiederholung, Altundas Samet";
Console.Title = TITLE + " " + Environment.UserName + " " + Environment.MachineName + ", started at " + DateTime.Now;
Console.WriteLine(TITLE);

BubbleSortClass1 bs = new BubbleSortClass1(new int[] { 64, 34, 25, 12, 22, 11, 90 });

int[] arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };


int[] array = bs.Sort();

foreach (var item in array) 
{
    Console.Write($"{item} ");
}



Console.WriteLine("\nHit Enter to Exit.");
Console.ReadLine();
