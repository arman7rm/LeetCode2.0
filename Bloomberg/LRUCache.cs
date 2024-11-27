public class LRUCache
{
    public Dictionary<int, Node> map;
    public int cap;
    public int size;
    public Node head;
    public Node tail;

    public LRUCache(int capacity)
    {
        this.cap = capacity;
        this.size = 0;
        this.map = new Dictionary<int, Node>();
    }

    public int Get(int key)
    {
        if (!map.ContainsKey(key)) return -1;
        Node node = map[key];
        if (node != tail) moveToTail(node);
        return node.val;
    }

    public void Put(int key, int value)
    {
        if (head == null)
        {
            head = new Node(value, key);
            size++;
            map[key] = head;
            tail = head;
        }
        else if (map.ContainsKey(key))
        {
            Node node = map[key];
            node.val = value;
            if (node != tail) moveToTail(node);
        }
        else
        {
            size++;
            addToTail(new Node(value, key));
            map[key] = tail;
            if (size > cap)
            {
                map.Remove(head.key);
                head = head.next;
                head.prev = null;
            }
        }
    }

    private void moveToTail(Node n)
    {
        if (n == head)
        {
            head = head.next;
            head.prev = null;
        }
        else
        {
            n.prev.next = n.next;
            n.next.prev = n.prev;
        }
        addToTail(n);
    }

    private void addToTail(Node n)
    {
        tail.next = n;
        n.prev = tail;
        n.next = null;
        tail = tail.next;
    }
}
public class Node
{
    public int val;
    public int key;
    public Node next;
    public Node prev;

    public Node(int x, int key)
    {
        this.val = x;
        this.key = key;
    }
}
/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */