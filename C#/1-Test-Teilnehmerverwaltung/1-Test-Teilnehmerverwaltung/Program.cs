
using _1_Test_Teilnehmerverwaltung;

const string PATH = $"..\\..\\..\\..\\..\\..\\..\\Aufgaben\\teilnehmer.csv";

Verwaltung verwaltung = new Verwaltung();
verwaltung.CSVEinlesen(PATH);

if (verwaltung.CountList() == 0)
    throw new Exception("Die Teilnehmerliste ist leer.");
    Console.WriteLine();

Console.WriteLine($"Datei wurde erfolgreich eingelesen.");


verwaltung.FirstFive();

verwaltung.VIPInsert(new Teilnehmer("VIP", "vipmail@gmail.com", DateTime.Now));

Console.WriteLine();
verwaltung.FirstFive();

Console.WriteLine();
verwaltung.ListAusgeben();

verwaltung.DeleteMiddle();

Console.WriteLine();
verwaltung.ListAusgeben();