namespace LRU;
public class LRU
{
    private int capacity;
    private Dictionary<int, Node> cache;
    private Node head;
    private Node tail;

    public LRU(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, Node>();
        head = new Node(0, 0, TimeSpan.Zero);
        tail = new Node(0, 0, TimeSpan.Zero);
        head.SetNext(tail);
        tail.SetPrev(head);
    }

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            Node node = cache[key];
            if (node.IsExpired())
            {
                RemoveNode(node);
                cache.Remove(key);
                return -1;
            }
            MoveToHead(node);
            return node.GetValue();
        }
        return -1;
    }

    public void Put(int key, int value, TimeSpan timeToLive)
    {
        RemoveExpiredNodes();
        if (cache.ContainsKey(key))
        {
            Node node = cache[key];
            node.SetValue(value);
            MoveToHead(node);
        }
        else
        {
            if (cache.Count == capacity)
            {
                RemoveTail();
            }
            Node newNode = new Node(key, value, timeToLive);
            cache[key] = newNode;
            AddToHead(newNode);
        }
    }

    private void MoveToHead(Node node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    private void AddToHead(Node node)
    {
        node.SetNext(head.GetNext());
        node.SetPrev(head);
        head.GetNext().SetPrev(node);
        head.SetNext(node);
    }

    private void RemoveNode(Node node)
    {
        node.GetPrev().SetNext(node.GetNext());
        node.GetNext().SetPrev(node.GetPrev());
    }

    private void RemoveTail()
    {
        Node tailNode = tail.GetPrev();
        RemoveNode(tailNode);
        cache.Remove(tailNode.GetKey());
    }

    public void DisplayCache()
    {
        Node current = head.GetNext();
        while (current != tail)
        {
            Console.Write($"({current.GetKey()}, {current.GetValue()}) ");
            current = current.GetNext();
        }
        Console.WriteLine();
    }

    private void RemoveExpiredNodes()
    {
        Node current = head.GetNext();
        while (current != tail)
        {
            if (current.IsExpired())
            {
                Node nextNode = current.GetNext();
                RemoveNode(current);
                cache.Remove(current.GetKey());
                current = nextNode;
            }
            else
            {
                current = current.GetNext();
            }
        }
    }
}