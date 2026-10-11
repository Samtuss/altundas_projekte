namespace LZK_EventsDelegates_Lambda;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<Produkt> produkte = ReaderCSV();
    }
    static public List<Produkt> ReaderCSV()
    {
        const string PATH = @"produkte.txt";
        if(!File.Exists(PATH))
        {
            throw new FileNotFoundException("Die Datei wurde nicht gefunden.", PATH);
        }
        List<Produkt> produkte = new List<Produkt>();

        using (StreamReader reader = new StreamReader(PATH))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                string name = parts[0];
                double preis = double.Parse(parts[1]);
                string kategorie = parts[2];
                Produkt produkt = new Produkt(name, preis, kategorie);
                produkte.Add(produkt);
            }
        }
        return produkte;
    }
}