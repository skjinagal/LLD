namespace SnakeAndLadder;
public class SnakeLadderConfiguration : ISnakeLadderConfiguration
{

    public List<Jumper> GetLadders()
    {
        var ladderData = ReadLadderFile();
        var ladders = new List<Jumper>();
        var ladderLines = ladderData.Split(Environment.NewLine);
        foreach (var line in ladderLines)
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                int start = int.Parse(parts[0]);
                int end = int.Parse(parts[1]);
                ladders.Add(new Jumper(start, end));
            }
        }
        return ladders;
    }

    public List<Jumper> GetSnakes()
    {
        var snakeData = ReadSnakeFile();
        var snakes = new List<Jumper>();
        var snakeLines = snakeData.Split(Environment.NewLine);
        foreach (var line in snakeLines)
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                int start = int.Parse(parts[0]);
                int end = int.Parse(parts[1]);
                snakes.Add(new Jumper(start, end));
            }
        }
        return snakes;
    }
    
    public Queue<Player> GetPlayers()
    {
        var playerData = ReadPlayerFile();
        var players = new List<Player>();
        var playerLines = playerData.Split(Environment.NewLine);
        foreach (var line in playerLines)
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                string id = parts[0];
                string name = parts[1];
                players.Add(new Player(name, int.Parse(id)));
            }
        }
        return new Queue<Player>(players);
    }

    private string ReadSnakeFile()
    {
        return File.ReadAllText("snakes.txt");
    }

    private string ReadLadderFile()
    {
        return File.ReadAllText("ladders.txt");
    }

    private string ReadPlayerFile()
    {
        return File.ReadAllText("players.txt");
    }
}