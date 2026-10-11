using TicTacToe;
const string TITLE = "TicTacToe, Samet Altundas";
Console.Title = TITLE + " " + Environment.UserName + " " + Environment.MachineName + ", started at " + DateTime.Now;
Console.WriteLine(TITLE);

TicTacToeClass tic = new TicTacToeClass();

Strategies strategy = new Strategies(new RandomStrategy());
IStrategy strategyChosen = strategy.StrategyChooser();

int ergebnis = 0;
int xCord;
int yCord;
bool validInput = true;

int[,] board = new int[3, 3];

do
{
    try
    {
        board = tic.MakeMove(board);

        Console.WriteLine("------------------------");
        Console.WriteLine($"Computers Turn:");
        // Pass the correct player to ComputerMove
        board = strategyChosen.ComputerMove(board, tic.currentPlayer);
        tic.currentPlayer *= -1; // Switch player after computer move
        ergebnis = tic.CheckWinner(board);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
        throw;
    }
} while (ergebnis == 0);

tic.PrintBoard(board);

Console.BackgroundColor = ConsoleColor.Magenta;

if (ergebnis == 1)
    Console.WriteLine("You Win!");
else if (ergebnis == -1)
    Console.WriteLine("Computer Wins!");
else
    Console.WriteLine("It's a draw!");
Console.BackgroundColor = default;






Console.WriteLine("\nHit Enter to Exit.");
Console.ReadLine();
