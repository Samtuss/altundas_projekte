using ObserverPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        ChatUser newUser = new ChatUser("David");
        ChatUser secondUser = new ChatUser("Alan");

        MessageLogger logger = new MessageLogger();

        ChatChannel channel = new ChatChannel();


        channel.Register(secondUser);
        channel.Register(newUser);


        channel.Notify("Hibr8n");
        channel.Notify("Hallo David");

        channel.Unregister(secondUser);

        channel.Notify("Ende");

        ChatBot bot = new ChatBot();

        bot.Register(secondUser);
        bot.Register(newUser);

        bot.Notify("labbaaa nicht"); // labba nicht geht nicht weil wir
        // in der chatbot klasse andere strings schon adden und den
        // parameter so lassen

        bot.Unregister(secondUser);
        bot.Notify("labbbbaaaaaa");

        logger.Update("labbbbaaaaaa");
        logger.Update("labbbbaaaaaa");
        logger.Update("labbbbaaaaaa");
        logger.Update("labbbbaaaaaa");
        logger.Update("labbbbaaaaaa");

        logger.SendLog();

    }
}