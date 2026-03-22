    namespace NotificationSystem
    {
        public class Subscriber : ISubscriber
        {
            public string Name { get; set; }
            public void Receive(Message message)
            {
                Console.WriteLine($"Subscriber {Name} received message: {message.Content} at {message.Timestamp}");
                
            }
        }
    }