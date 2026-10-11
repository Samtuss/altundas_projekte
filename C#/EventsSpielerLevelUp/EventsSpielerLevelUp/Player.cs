using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventsSpielerLevelUp;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Hp { get; set; }
    private int Xp { get; set; }


    public int NeuesLevel { get; set; }
    public Player(string name, int hp, int xp, int level)
    {
        Name = name;
        Hp = hp;
        Xp = xp;
        Level = level;
    }

    public event EventHandler<EventArgs> LevelUp;
    public event EventHandler<EventArgs> Dead;

    public void GetXP(int xp)
    {
        Xp += xp;
        if (Xp >= 100)
        {
            NeuesLevel = Level + 1;
            Level = NeuesLevel;
            Xp = Xp - 100;
            LevelUp?.Invoke(this, EventArgs.Empty);
        }
    }
    public void GetDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 100;
            Dead?.Invoke(this, EventArgs.Empty);
        }
    }
    public void OnDamage(object sender, EventArgs e)
    {
        Console.WriteLine($"Player is dead.");
    }
    public void OnLevelUp(object sender, EventArgs e) => Console.WriteLine($"Player leveled up to level {NeuesLevel}.");
}