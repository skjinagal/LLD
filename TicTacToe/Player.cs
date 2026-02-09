namespace TicTacToe;
public interface Player
{
    char Symbol { get; }
    void MakeMove(char[,] board, int row, int col);
}