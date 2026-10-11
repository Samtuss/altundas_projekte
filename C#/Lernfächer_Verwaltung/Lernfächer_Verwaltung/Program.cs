using Lernfächer_Verwaltung;
using System.Net.WebSockets;

StudyTracker tracker = new StudyTracker();
tracker.AddStudyHours("Mathematik", 3.5);
tracker.AddStudyHours("Deutsch", 2.0);
tracker.AddStudyHours("Englisch", 4.0);
tracker.AddStudyHours("Mathematik", 2.5); // Wird addiert!
Console.WriteLine(tracker.GetHours("Mathematik")); // Output: 6.0
Console.WriteLine(tracker.GetTotalHours()); // Output: 12.0
Console.WriteLine(tracker.GetFavoriteSubject()); // Output: Mathematik
Console.WriteLine();
tracker.PrintAllSubjects();

// Theoriefragen
//      Warum ist ein Dictionary hier besser als eine List?
//          - 
//      Was passiert, wenn man GetHours() für ein nicht existierendes Fach aufruft?
//          - 
//      Wie würdest du ContainsKey() vs. TryGetValue() einsetzten?
//          - 

tracker.GetSortedSubjects();


Console.WriteLine();
