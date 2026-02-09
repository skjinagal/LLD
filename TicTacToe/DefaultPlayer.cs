namespace TicTacToe;
public class DefaultPlayer : Player
{
    public char Symbol { get; private set; }

    public DefaultPlayer(char symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(char[,] board, int row, int col)
    {
        if (board[row, col] == '\0')
        {
            board[row, col] = Symbol;
        }
        else
        {
            throw new InvalidOperationException("Cell is already occupied.");
        }
    }
}