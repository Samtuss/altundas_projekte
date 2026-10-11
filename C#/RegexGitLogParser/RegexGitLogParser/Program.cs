using System;
using System.Text.RegularExpressions;

class Program
{
    static readonly Regex commitPattern = new Regex(
        @"(?<hash>[0-9a-f]{7})\s*\|\s*" +
        @"(?<timestamp>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\s*\|\s*" +
        @"(?<author>[^\s|]+)\s*\|\s*" +
        @"(?<message>.+)",
        RegexOptions.Compiled
    );
    static void Main()
    {
        //string[] logLines =
        //{
        //    "a3f9b2c | 2025-11-03 09:15:00 | max.mustermann     | Fix: login button not responding",
        //    "d4e5f6a | 2025-11-03 11:58:44 | thomas.müller | Merge branch 'feature/dark-mode' into main",
        //    "a3b4c5d | 2025-11-04 08:10:44 | franziska.öhlinger | Feature: notification badges"
        //};

        //var regex = new Regex(
        //    @"^(?<hash>.*?)\s+\|\s+(?<time>.*?)\s+\|\s+(?<author>.*?)\s+\|\s+(?<message>.*)$",
        //    RegexOptions.Compiled
        //);

        //foreach (var line in logLines)
        //{
        //    var match = regex.Match(line);

        //    if (!match.Success)
        //    {
        //        Console.WriteLine("❌ Kein Match:");
        //        Console.WriteLine(line);
        //        continue;
        //    }

        //    Console.WriteLine("✅ Commit gefunden:");
        //    Console.WriteLine($"  Hash    : {match.Groups["hash"].Value}");
        //    Console.WriteLine($"  Zeit    : {match.Groups["time"].Value}");
        //    Console.WriteLine($"  Autor   : {match.Groups["author"].Value.Trim()}");
        //    Console.WriteLine($"  Message : {match.Groups["message"].Value}");
        //    Console.WriteLine(new string('-', 50));
        //}

        string[] lines = File.ReadAllLines("gitlog.txt");

        // --- Aufgabe 1 ---
        Console.WriteLine("=== Aufgabe 1: Alle Commits ===\n");
        PrintAllCommits(lines);

        // --- Aufgabe 2 ---
        Console.WriteLine("\n=== Aufgabe 2: Fix-Commits ===\n");
        Console.WriteLine("[Fix-Commits]");
        foreach (var entry in GetFixCommits(lines))
            Console.WriteLine(entry);

        // --- Aufgabe 3 ---
        Console.WriteLine("\n=== Aufgabe 3: Commits pro Autor ===\n");
        CountByAuthor(lines);

        // --- Aufgabe 4 (Bonus) ---
        Console.WriteLine("\n=== Aufgabe 4: Zeitraum-Filter (09:00 – 13:59) ===\n");
        var gefiltert = FilterByTimeRange(lines,
                            TimeOnly.Parse("09:00:00"),
                            TimeOnly.Parse("13:59:59"));
        Console.WriteLine($"Anzahl Commits im Zeitraum: {gefiltert.Count}\n");
        foreach (var entry in gefiltert)
            Console.WriteLine("  " + entry);

        // --- Zusatzfrage ---
        Console.WriteLine("\n=== Zusatzfrage: Commits ohne gültigen Präfix ===\n");
        PrintCommitsWithoutPrefix(lines);

        Console.ReadKey();
    }
    // ================================================================
    // AUFGABE 1 – Alle Commits strukturiert ausgeben
    // ================================================================
    static void PrintAllCommits(string[] lines)
    {
        foreach (var line in lines)
        {
            var match = commitPattern.Match(line);
            if (!match.Success) continue; // Zeile überspringen wenn kein Match

            Console.WriteLine($"Hash:    {match.Groups["hash"].Value}");
            Console.WriteLine($"Datum:   {match.Groups["timestamp"].Value}");
            Console.WriteLine($"Autor:   {match.Groups["author"].Value}");
            Console.WriteLine($"Message: {match.Groups["message"].Value}");
            Console.WriteLine("---");
        }
    }

    // ================================================================
    // AUFGABE 2 – Nur Fix-Commits zurückgeben
    //
    // Warum StartsWith("Fix:") und nicht Contains("Fix:")?
    //   → "Hotfix: ..." enthält zwar "fix", aber BEGINNT nicht mit "Fix:"
    //   → StartsWith ist hier die sicherste Methode
    //
    // Alternative mit Regex direkt auf der Message:
    //   new Regex(@"^Fix:").IsMatch(message)
    //   → ^ = Anfang des Strings (hier: Anfang der message-Gruppe)
    // ================================================================
    static List<string> GetFixCommits(string[] lines)
    {
        var result = new List<string>();

        foreach (var line in lines)
        {
            var match = commitPattern.Match(line);
            if (!match.Success) continue;

            string message = match.Groups["message"].Value;

            if (message.StartsWith("Fix:"))
            {
                result.Add(
                    $"{match.Groups["timestamp"].Value} | " +
                    $"{match.Groups["author"].Value} | " +
                    $"{message}"
                );
            }
        }

        return result;
    }

    // ================================================================
    // AUFGABE 3 – Commits pro Autor zählen, absteigend sortiert
    // ================================================================
    static void CountByAuthor(string[] lines)
    {
        var dict = new Dictionary<string, int>();

        foreach (var line in lines)
        {
            var match = commitPattern.Match(line);
            if (!match.Success) continue;

            string author = match.Groups["author"].Value;

            if (!dict.ContainsKey(author))
                dict[author] = 0;

            dict[author]++;
        }

        Console.WriteLine("[Commits pro Autor]");

        // OrderByDescending → nach Anzahl absteigend
        // ThenBy            → bei Gleichstand alphabetisch
        foreach (var entry in dict.OrderByDescending(e => e.Value).ThenBy(e => e.Key))
        {
            Console.WriteLine($"  {entry.Key,-25}: {entry.Value}");
        }
    }

    // ================================================================
    // AUFGABE 4 (BONUS) – Zeitraum-Filter
    //
    // Ablauf:
    //   1. Commit-Zeile matchen → timestamp-Gruppe holen
    //   2. Uhrzeit (HH:mm:ss) mit separatem Pattern extrahieren
    //   3. TimeOnly.Parse() → vergleichbares Objekt
    //   4. from <= zeit <= to → inklusiver Bereichscheck
    // ================================================================
    static List<string> FilterByTimeRange(string[] lines, TimeOnly from, TimeOnly to)
    {
        // Hilfs-Pattern: holt nur "HH:mm:ss" aus dem Timestamp
        var timePattern = new Regex(@"\d{2}:\d{2}:\d{2}");
        var result = new List<string>();

        foreach (var line in lines)
        {
            var match = commitPattern.Match(line);
            if (!match.Success) continue;

            // Uhrzeit aus dem Timestamp-Feld extrahieren
            var zeitMatch = timePattern.Match(match.Groups["timestamp"].Value);
            if (!zeitMatch.Success) continue;

            var zeit = TimeOnly.Parse(zeitMatch.Value);

            if (zeit >= from && zeit <= to)
                result.Add(line.Trim());
        }

        return result;
    }

    // ================================================================
    // ZUSATZFRAGE – Commits ohne gültigen Präfix finden
    //
    // Gültige Präfixe: Fix | Feature | Hotfix | Refactor | Chore
    //
    // Pattern: ^(Fix|Feature|Hotfix|Refactor|Chore):
    //   → ^ = Anfang des message-Strings
    //   → (...|...) = Alternativen-Gruppe
    //   → : = Doppelpunkt muss direkt danach folgen
    //
    // Commits OHNE Präfix → !prefixPattern.IsMatch(message)
    // ================================================================
    static void PrintCommitsWithoutPrefix(string[] lines)
    {
        var prefixPattern = new Regex(@"^(Fix|Feature|Hotfix|Refactor|Chore):");
        int count = 0;

        foreach (var line in lines)
        {
            var match = commitPattern.Match(line);
            if (!match.Success) continue;

            string message = match.Groups["message"].Value;

            if (!prefixPattern.IsMatch(message))
            {
                Console.WriteLine($"  Kein Präfix: {match.Groups["hash"].Value} | {message}");
                count++;
            }
        }

        Console.WriteLine($"\nGesamt ohne gültigen Präfix: {count}");
    }
}