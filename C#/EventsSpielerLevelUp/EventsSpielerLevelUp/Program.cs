namespace EventsSpielerLevelUp;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Player Xp Level Bsp");
        Player player = new Player("Max", 100, 0, 1);

        player.LevelUp += player.OnLevelUp;
        player.Dead += player.OnDamage;

        player.GetXP(50);
        player.GetXP(60); // Should trigger level up event

        player.GetXP(1000);

        player.GetDamage(30);
        player.GetDamage(80); // Should trigger dead event
    }
}
