namespace SnakeAndLadder;
public class GameBoard
{
    private int size;
    private List<Jumper> ladders;
    private List<Jumper> snakes;
    private Queue<Player> players;
    private Dice dice;
    public GameBoard(int size, List<Jumper> ladders, List<Jumper> snakes, Queue<Player> players, Dice dice)
    {
        this.size = size;
        this.ladders = ladders;
        this.snakes = snakes;
        this.players = players;
        this.dice = dice;
    }
    public void StartGame()
    {
        while(players.Count > 1)
        {
            var currrentPlayer = players.Dequeue();
            int diceRoll = dice.RollDice();
            var currentPosition = currrentPlayer.Position;
            int newPosition = currentPosition + diceRoll;
            if (newPosition > size)
            {
                newPosition = size;
            }
            currrentPlayer.Move(newPosition);
            foreach(var ladder in ladders)
            {
                if(ladder.GetStart() == newPosition)
                {
                    newPosition = ladder.GetEnd();
                    currrentPlayer.Move(newPosition);
                    Console.WriteLine($"Player {currrentPlayer.GetName()} climbed a ladder to position {newPosition}");
                    break;
                }
            }
            foreach(var snake in snakes)
            {
                if(snake.GetStart() == newPosition)
                {
                    newPosition = snake.GetEnd();
                    currrentPlayer.Move(newPosition);
                    Console.WriteLine($"Player {currrentPlayer.GetName()} got bitten by a snake and moved down to position {newPosition}");
                    break;
                }
            }
            if(newPosition == size)
            {
                Console.WriteLine($"Player {currrentPlayer.GetName()} wins!");
                continue;
            }
             
            players.Enqueue(currrentPlayer);
        }
    }
}