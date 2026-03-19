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
        head = new Node(0, 0);
        tail = new Node(0, 0);
        head.SetNext(tail);
        tail.SetPrev(head);
    }

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            Node node = cache[key];
            MoveToHead(node);
            return node.GetValue();
        }
        return -1;
    }

    public void Put(int key, int value)
    {
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
            Node newNode = new Node(key, value);
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
}