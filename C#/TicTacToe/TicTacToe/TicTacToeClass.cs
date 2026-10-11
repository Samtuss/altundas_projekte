using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeClass
    {
        public int currentPlayer = 1; // 1 for player 1 (X), -1 for player 2 (O)
        public void PrintBoard(int[,] board)
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    char mark = board[i, j] == 1 ? 'X' : board[i, j] == -1 ? 'O' : ' ';
                    Console.Write($" {mark} ");
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("---+---+---");
            }
        }
        public int[,] MakeMove(int[,] board)
        {
            while (true)
            {
                int xCord, yCord;
                PrintBoard(board);
                Console.WriteLine($"Your turn:");
                Console.WriteLine($"Input: x-coordinate");
                if (!int.TryParse(Console.ReadLine(), out xCord)) continue;
                Console.WriteLine($"Input: y-coordinate");
                if (!int.TryParse(Console.ReadLine(), out yCord)) continue;

                // Swap indices: first is row (y), second is column (x)
                if (yCord < 0 || yCord > 2 || xCord < 0 || xCord > 2 || board[yCord, xCord] != 0)
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue; // Invalid move
                }
                board[yCord, xCord] = currentPlayer;
                currentPlayer *= -1; // Switch player 
                return board; // Return after a valid move
            }
        }
        public int CheckWinner(int[,] board)
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(board[i, 0] + board[i, 1] + board[i, 2]) == 3)
                    return board[i, 0];
                if (Math.Abs(board[0, i] + board[1, i] + board[2, i]) == 3)
                    return board[0, i];
            }
            // Check diagonals
            if (Math.Abs(board[0, 0] + board[1, 1] + board[2, 2]) == 3)
                return board[0, 0];
            if (Math.Abs(board[0, 2] + board[1, 1] + board[2, 0]) == 3)
                return board[0, 2];
            // Check for draw or ongoing game
            foreach (var cell in board)
            {
                if (cell == 0) return 0; // Game is still ongoing
            }
            return 2; // Draw
        }

    }
}
