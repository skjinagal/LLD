namespace SnakeAndLadder;
public interface ISnakeLadderConfiguration
{
    List<Jumper> GetLadders();
    List<Jumper> GetSnakes();
    Queue<Player> GetPlayers();
}