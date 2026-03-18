using System.Collections.Concurrent;
namespace RateLimiter;
public class RateLimiter
{
    private ConcurrentDictionary<string, Bucket> requestLogs;
    private int maxRequests;
    private int refillRate = 3; // Number of tokens to add per second
    public RateLimiter(int maxRequests)
    {
        this.requestLogs = new ConcurrentDictionary<string, Bucket>();
        this.maxRequests = maxRequests;
    }

    public bool IsRequestAllowed(string userId)
    {
        if (!requestLogs.ContainsKey(userId))
        {
            requestLogs[userId] = new Bucket(maxRequests, refillRate);
        }

        var bucket = requestLogs[userId];
        return bucket.TryConsume();
    }
}