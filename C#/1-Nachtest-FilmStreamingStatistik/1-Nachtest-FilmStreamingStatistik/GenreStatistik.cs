using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Nachtest_FilmStreamingStatistik;

public class GenreStatistik
{
    Dictionary<string, int> statistics = new Dictionary<string, int>();

    public void AddFilm(string title, string genre)
    {
        if (statistics.ContainsKey(genre))
        {
            statistics[genre]++;
        }
        else
        {
            statistics[genre] = 1;
        }
    }
    public int GetCount(string genre)
    {
        if (statistics.ContainsKey(genre))
        {
            return statistics[genre];
        }
        return 0;
    }

    public void CreateStatisticsCSV(string path)
    {
        if(!File.Exists(path))
        {
            throw new FileNotFoundException($"File not found {path}");
        }
        using (StreamReader reader = new StreamReader(path))
        {
            string inputline;
            string[] parts;
            reader.ReadLine();
            while(!reader.EndOfStream)
            {
                inputline = reader.ReadLine();
                parts = inputline.Split(',');
                AddFilm(parts[0], parts[1]);
            }
        }
    }
    public string GetMostPopularGenre()
    {
        string populargenre = string.Empty;
        int helper = 0;
        if (statistics.Count > 0)
        {
            foreach (var key in statistics.Keys)
            {
                if (helper < statistics[key])
                {
                    helper = statistics[key];
                    populargenre = key;
                }
            }
        }
        return populargenre;
    }

}
