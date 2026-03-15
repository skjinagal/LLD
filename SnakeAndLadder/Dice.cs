namespace SnakeAndLadder;
public class Dice
{
    private int numberOfDice;
    public Dice(int numberOfDice)
    {
        this.numberOfDice = numberOfDice;
    }
    public int RollDice()
    {
        Random random = new Random();
        int total = 0;
        for (int i = 0; i < numberOfDice; i++)
        {
            total += random.Next(1, 7); // Generates a number between 1 and 6
        }
        return total;
    }
}