public class LRUCache {
    public Dictionary<int, Node> map;
    public int cap;
    public int size;
    public Node head;
    public Node tail;

    public LRUCache(int capacity) {
        this.cap = capacity;
        this.map = new Dictionary<int, Node>();
    }
    
    public int Get(int key) {
        if(!map.ContainsKey(key)) return -1;
        Node node = map[key];
        if(node!=tail){
            removeNode(node);
            addToTail(node);
        }
        return node.val;
    }
   
    public void Put(int key, int value) {
        if(head==null){
            head = new Node(value, key);
            size++;
            map[key] = head;
            tail = head;
            return;
        }
        if(map.ContainsKey(key)){
            map[key].val = value;
            if(map[key]==tail)return;
            removeNode(map[key]);
            addToTail(map[key]);
        }
        else{
            size++;
            addToTail(new Node(value, key));
            map[key] = tail;
            if(size>cap){
                map.Remove(head.key);
                removeNode(head);
            }
        }
    }

    private void removeNode(Node n){
        if(n==head){
            head = head.next;
            head.prev = null;
        }else{
            n.prev.next = n.next;
            if (n.next != null) n.next.prev = n.prev;
            else tail = n.prev; // Update tail if necessary
        }
    }
    private void addToTail(Node n){
        tail.next = n;
        n.prev = tail;
        n.next = null;
        tail = tail.next;
    }
}
public class Node {
    public int val;
    public int key;
    public Node next;
    public Node prev;

    public Node(int x, int key){
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