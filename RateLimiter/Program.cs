// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var rateLimiter = new RateLimiter.RateLimiter(5);
Thread T1 = new Thread(GiveRequest);
Thread T2 = new Thread(GiveRequest);
Thread T3 = new Thread(GiveRequest);
T1.Start();
T2.Start();
T3.Start();
void GiveRequest()
{
    for (int i = 0; i < 100; i++)
    {
        if (rateLimiter.IsRequestAllowed("user1"))
        {
            Console.WriteLine("Request allowed");
        }
        else
        {
            Console.WriteLine("Request denied");
        }
    }
}