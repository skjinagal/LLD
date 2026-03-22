namespace NotificationSystem;

public class PubSubSystem
{
    private readonly Dictionary<int, List<ISubscriber>> _subscribers = new Dictionary<int, List<ISubscriber>>();

    public void Subscribe(int key, ISubscriber subscriber)
    {
        if (!_subscribers.ContainsKey(key))
        {
            _subscribers[key] = new List<ISubscriber>();
        }
        if(!_subscribers[key].Contains(subscriber))
        {
            _subscribers[key].Add(subscriber);
        }
    }

    public void Unsubscribe(int key, ISubscriber subscriber)
    {
        if (_subscribers.ContainsKey(key))
        {
            _subscribers[key].Remove(subscriber);
            if (_subscribers[key].Count == 0)
            {
                _subscribers.Remove(key);
            }
        }
    }

    public void Publish(Message message)
    {
        if (_subscribers.ContainsKey(message.RoutingKey))
        {
            foreach (var subscriber in _subscribers[message.RoutingKey])
            {
                subscriber.Receive(message);
            }
        }
    }
}