namespace RateLimiter;
public class Bucket
{
    public int Capacity { get; private set; }
    public int CurrentTokens { get; private set; }
    public int RefillRate { get; private set; }
    private object lockObj = new object();
    public Bucket(int capacity, int refillRate)
    {
        Capacity = capacity;
        RefillRate = refillRate;
        CurrentTokens = capacity; // Start with a full bucket
    }

    private DateTime lastRefillTime = DateTime.UtcNow;

    private void Refill()
    {
        double tokensToAdd = (DateTime.UtcNow - lastRefillTime).TotalSeconds * RefillRate;
        CurrentTokens = Math.Min(Capacity, CurrentTokens + (int)tokensToAdd);
        lastRefillTime = DateTime.UtcNow;
    }

    public bool TryConsume()
    {
        
        lock (lockObj)
        {
            Refill();
            if (CurrentTokens > 0)
            {
                CurrentTokens--;
                return true;
            }
            return false;
        }
        
    }
}