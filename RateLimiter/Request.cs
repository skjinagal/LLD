namespace RateLimiter;
public class Request
{
    private string userId;
    private DateTime timestamp;

    public Request(string userId, DateTime timestamp)
    {
        this.userId = userId;
        this.timestamp = timestamp;
    }

    public string GetUserId()
    {
        return userId;
    }

    public DateTime GetTimestamp()
    {
        return timestamp;
    }
}