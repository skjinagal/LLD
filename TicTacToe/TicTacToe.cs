namespace TicTacToe;
public class TicTacToe
{
    private Player player1;
    private Player player2;
    private Player currentPlayer;
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");
        // Game logic would go here
        TicTacToe game = new TicTacToe();
        game.StartGame();
    }

    public void StartGame()
    {
        player1 = new DefaultPlayer('X');
        player2 = new DefaultPlayer('O');
        currentPlayer = player1;
        char[,] board = new char[3, 3];
        // Game loop would go here
        while (true)
        {
            // Get move from current player (this would normally involve user input)
            Console.Write($" Player + {currentPlayer.Symbol} : + Enter your move (row and column, e.g., 1 2): " );
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            int row = int.Parse(parts[0]) - 1;
            int col = int.Parse(parts[1]) - 1;
            try
            {
                currentPlayer.MakeMove(board, row, col);
                if (IsGameOver(board, row, col))
                {
                    Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
                    break;
                }
                SwitchPlayer();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void SwitchPlayer()
    {
        currentPlayer = currentPlayer == player1 ? player2 : player1;
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver(char[,] board, int row, int col)
    {
        // Check rows, columns, and diagonals for a win
        char symbol = board[row, col];
        bool checkRow = true;
        bool checkCol = true;   

        for (int i = 0; i < 3; i++)
        {
            if(board[row, i] != symbol)
            {
                checkRow = false;
                break;
            }
        }
        if(checkRow) return true;
        for (int i = 0; i < 3; i++)
        {
            if(board[i, col] != symbol)
            {
                checkCol = false;
                break;
            }
        }
        if(checkCol) return true;
        if(row == col)
        {
            bool checkDiag1 = true;
            for (int i = 0; i < 3; i++)
            {
                if(board[i, i] != symbol)
                {
                    checkDiag1 = false;
                    break;
                }
            }
            if(checkDiag1) return true;
        }
        if(row + col == 2)
        {
            bool checkDiag2 = true;
            for (int i = 0; i < 3; i++)
            {
                if(board[i, 2 - i] != symbol)
                {
                    checkDiag2 = false;
                    break;
                }
            }
            if(checkDiag2) return true;
        }
        return false;
    }
        
}