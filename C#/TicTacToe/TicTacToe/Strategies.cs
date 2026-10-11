using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Strategies
    {
        private IStrategy _strategy;

        public Strategies(IStrategy strategy)
        {
            _strategy = strategy;
        }
        public IStrategy StrategyChooser()
        {
            Console.WriteLine("Choose a strategy for the computer:");
            Console.WriteLine("1. Random Move");
            Console.WriteLine("2. Defensive Move");
            Console.WriteLine("3. Offensive Move");
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();
            IStrategy strategy;
            switch (choice)
            {
                case "1":
                    strategy = new RandomStrategy();
                    break;
                case "2":
                    strategy = new DefensiveStrategy();
                    break;
                case "3":
                    strategy = new OffensiveStrategy();
                    break;
                default:
                    Console.WriteLine("Invalid choice, defaulting to Random Move.");
                    strategy = new RandomStrategy();
                    break;
            }

            return strategy;
            // Here you would integrate the chosen strategy into your game logic
            // For example, pass it to the TicTacToeClass or use it directly
        }
    }
}
