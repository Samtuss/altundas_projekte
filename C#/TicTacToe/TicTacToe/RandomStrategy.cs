using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class RandomStrategy : IStrategy
    {
        public int[,] ComputerMove(int[,] board, int player)
        {
            List<(int, int)> availableMoves = new List<(int, int)>();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == 0)
                    {
                        availableMoves.Add((row, col));
                    }
                }
            }
            if (availableMoves.Count == 0) return board; // No moves left
            Random rand = new Random();
            var move = availableMoves[rand.Next(availableMoves.Count)];
            board[move.Item1, move.Item2] = player;
            return board;
        }
    }
}
