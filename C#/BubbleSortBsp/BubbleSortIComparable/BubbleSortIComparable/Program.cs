using BubbleSortIComparable;
const string TITLE = "BubbleSortIComparable, Asir Samet Altundas";
Console.Title = TITLE + " " + Environment.UserName + " " + Environment.MachineName + ", started at " + DateTime.Now;
Console.WriteLine(TITLE);


Person p1 = new Person(64);
Person p2 = new Person(34);
Person p3 = new Person(25);
Person p4 = new Person(12);
Person p5 = new Person(22);
Person p6 = new Person(11);
Person p7 = new Person(90);

List<Person> people = new List<Person>() { p1, p2, p3, p4, p5, p6, p7 };

for (int i = 0; i < people.Count; i++)
{
    for (int j = 0; j < people.Count - i - 1; j++)
    {
        if (people[j].CompareTo(people[j + 1]) > 0)
        {
            // Swap
            Person temp = people[j];
            people[j] = people[j + 1];
            people[j + 1] = temp;
        }
    }
}

foreach (var person in people)
{
    Console.WriteLine($"Person Age: {person.Age}");
}





Console.WriteLine("\nHit Enter to Exit.");
Console.ReadLine();