namespace NotificationSystem
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public int RoutingKey { get; set; }

        public Message(string content, int routingKey)
        {
            Content = content;
            Timestamp = DateTime.Now;
            RoutingKey = routingKey;
        }
    }
}