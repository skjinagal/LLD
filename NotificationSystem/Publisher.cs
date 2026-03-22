namespace NotificationSystem
{
    public class Publisher
    {
        private readonly PubSubSystem _pubSubSystem;

        public Publisher(PubSubSystem pubSubSystem)
        {
            _pubSubSystem = pubSubSystem;
        }

        public void Publish(Message message)
        {
            _pubSubSystem.Publish(message);
        }
    }
}