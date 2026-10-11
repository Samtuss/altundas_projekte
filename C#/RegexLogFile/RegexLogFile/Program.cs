using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace RegexLogFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input = "[2025-11-03 08:42:11] ERROR   ServiceA:" +
                " Connection timeout after 3000ms\r\n[2025-11-03 08:42:15]" +
                " INFO    \r\nServiceB: Health check OK\r\n[2025-11-03 " +
                "08:43:02] WARNING ServiceA: Retry attempt 2/5\r\n" +
                "[2025-11-03 08:43:45] ERROR   ServiceC: Disk usage 94%" +
                "\r\n[2025-11-03 08:44:10] INFO    \r\nServiceA: " +
                "Reconnected successfully\r\n[2025-11-03 08:44:58] ERROR   " +
                "ServiceB: Null reference in payment module\r\n[2025-11-03 " +
                "08:45:30] WARNING ServiceC: Memory usage above 80%\r\n" +
                "[2025-11-03 08:46:01] ERROR   ServiceA: Database connection " +
                "refused";
            var split = input.Split("\r\n");
            Console.WriteLine(split.Length);

            foreach (string line in split)
            {
                if (line.Contains($"ERROR"))
                {
                    Console.WriteLine($"Zeit: {line.Substring(1, 19)}" +
                        $"Service: {line.Substring(30, 9)}" +
                        $"Fehler: {line.Substring(40)}");
                }
            }

            Console.WriteLine($"......................................");

            string input2 = "2025-11-03 08:42:11] ERROR   ServiceA: Connection timeout after 3000ms\r\n[2025-11-03 08:42:15] INFO    ServiceB: Health check OK\r\n[2025-11-03 08:43:02] WARNING ServiceA: Retry attempt 2/5\r\n[2025-11-03 08:43:45] ERROR   ServiceC: Disk usage 94%\r\n[2025-11-03 08:44:10] INFO    ServiceA: Reconnected successfully\r\n[2025-11-03 08:44:58] ERROR   ServiceB: Null reference in payment module\r\n[2025-11-03 08:45:30] WARNING ServiceC: Memory usage above 80%\r\n[2025-11-03 08:46:01] ERROR   ServiceA: Database connection refused";
            var split2 = input.Split("\r\n");
            Dictionary<string, int> dict = new Dictionary<string, int>();

            var pattern = @"\[(?<timestamp>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\]\s+(?<level>\w+)\s+(?<service>\w+):\s+(?<message>.+)";

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string service = match.Groups["service"].Value;
                if (match.Groups["level"].Value == "ERROR")
                {                    
                    if (!dict.ContainsKey(service))
                    {
                        dict[service] = 0;
                    }
                    dict[service]++;
                }
                
                Console.WriteLine($"Zeit: {match.Groups["timestamp"].Value}");

                Console.WriteLine($"Level: {match.Groups["level"].Value}");

                Console.WriteLine($"Service: {match.Groups["service"].Value}");

                Console.WriteLine($"Fehler: {match.Groups["message"].Value}");
                Console.WriteLine();
            }

            foreach(var dic in dict)
            {
                Console.WriteLine($".........");
                Console.WriteLine($"{dic.Key}: {dic.Value}");
            }

            var labba = FilterByTimeRange(input, new TimeOnly(08, 43, 00), new TimeOnly(08,45,00));

            Console.WriteLine($"--------------");
            Console.WriteLine($"{labba}");

            Console.ReadKey();
        }
        public static int FilterByTimeRange(string log, TimeOnly from, TimeOnly to)
        {
            var split = log.Split("\r\n");
            var pattern = @"\[(?<timestamp>\d{4}-\d{2}-\d{2}) (?<time>\d{2}:\d{2}:\d{2})\]\s+(?<level>\w+)\s+(?<service>\w+):\s+(?<message>.+)";

            var matches = Regex.Matches(log, pattern);


            var einträge = 0;
            foreach (Match match in matches)
            {
                var time = match.Groups["time"].Value;

                var time2 = TimeOnly.Parse(time);


                if (time2 >= from && time2 <= to)
                {
                    einträge++;
                }

            }
            return einträge;
        }
    }
}
