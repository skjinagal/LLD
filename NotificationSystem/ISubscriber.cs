namespace NotificationSystem
{
    public interface ISubscriber
    {
        string Name { get; }
        void Receive(Message message);
    }
}