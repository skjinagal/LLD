namespace SnakeAndLadder;
public class Jumper
{
    private int start;
    private int end;

    public Jumper(int start, int end)
    {
        this.start = start;
        this.end = end;
    }

    public int GetStart()
    {
        return start;
    }

    public int GetEnd()
    {
        return end;
    }
}