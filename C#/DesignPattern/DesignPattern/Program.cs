using DesignPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        string text1 = "Achtung";
        string text2 = "HTML";

        //Console.WriteLine(FormatText(text1, text2));
        //Console.WriteLine(FormatText(text1, "xml"));
        //Console.WriteLine(FormatText(text1, "plain"));
        //Console.WriteLine(FormatText(text1, "markdown"));


        var output = new TextOutput(new PlainFormatter());
        output.Write("Achtung");
        // Achtung
        output.SetFormatter(new HtmlFormatter());
        output.Write("Achtung");
        // <p>Achtung</p>
        output.SetFormatter(new MarkDownFormatter());
        output.Write("Achtung");
        // > Achtung
        output.SetFormatter(new XmlFormatter());
        output.Write("Achtung");


        Console.ReadKey();
    }

    public static string FormatText(string text, string format)
    {
        switch(format.ToLower())
        {
            case "plain":
                return text;
                break;

            case "html":
                return $"<p>{text}</p>";
                break;

            case "markdown":
                return $"> {text}";
                break;

            case "xml":
                return $"<xml>{text}</xml>";
                break;

            default:
                return text;
                
        }
    }
}