namespace LRU;
public class Node
{
    private int key;
    private int value;
    private Node prev;
    private Node next;

    public Node(int key, int value)
    {
        this.key = key;
        this.value = value;
        this.prev = null;
        this.next = null;
    }

    public int GetKey()
    {
        return key;
    }

    public int GetValue()
    {
        return value;
    }

    public Node GetPrev()
    {
        return prev;
    }

    public void SetPrev(Node prev)
    {
        this.prev = prev;
    }

    public Node GetNext()
    {
        return next;
    }

    public void SetNext(Node next)
    {
        this.next = next;
    }
    public void SetValue(int value)
    {
        this.value = value; 
    }
}