using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernfächer_Verwaltung;

public class StudyTracker
{
    Dictionary<string, double> subjectHours = new Dictionary<string, double>();

    public void AddStudyHours(string subject, double hours)
    {
        if (!subjectHours.ContainsKey(subject))
        {
            subjectHours.Add(subject, hours);
        }
        else
        {
            subjectHours[subject] += hours;
        }
    }

    public double GetHours(string subject)
    {
        if (!subjectHours.ContainsKey(subject))
        {
            Console.WriteLine($"Das angegebene Fach existiert nicht.");
        }
        return subjectHours[subject];
    }

    public double GetTotalHours()
    {
        double helper = 0;
        foreach (var key in subjectHours.Keys)
        {
            helper += subjectHours[key];
        }
        return helper;
    }
    public string GetFavoriteSubject()
    {
        var helper = subjectHours.Keys.First();
        foreach (var key in subjectHours.Keys)
        {
            if (subjectHours[helper] < subjectHours[key])
            {
                helper = key;
            }
        }
        return helper;
    }

    public void PrintAllSubjects()
    {
        foreach (var key in subjectHours.Keys)
        {
            Console.WriteLine($"{key}: {subjectHours[key]} Stunden");
        }
    }

    public void GetSortedSubjects()
    {
        subjectHours.OrderByDescending(x => x);

        PrintAllSubjects();

    }

    public void GetSubjectsAbove(double minHours)
    {
        foreach (var key in subjectHours.Keys)
        {
            if (subjectHours[key] > minHours)
            {
                Console.WriteLine($"\n {key}");
            }
        }
    }

    public double GetAverageHours()
    {
        return subjectHours.Values.Average();
    }



}
