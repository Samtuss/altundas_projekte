using _1_Nachtest_FilmStreamingStatistik;
public class Program
{
    static void Main(string[] args)
    {
        const string PATH = @"films.csv";
        Console.WriteLine($"Using path: {Path.GetFullPath(PATH)}");

        var statistic = new GenreStatistik();

        statistic.CreateStatisticsCSV(PATH);

        Console.WriteLine(statistic.GetCount("Sci-Fi")); 

















    }
}
