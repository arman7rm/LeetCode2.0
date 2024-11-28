public partial class Solution {
    public class Node{
        public Node next;
        public Node prev;
        public Node child;
        public Node() {

        }
    }
    public Node Flatten(Node head) {
        var runner = head;
        var stack = new Stack<Node>();
        while(runner!=null){
            if(runner.child!=null){
                if (runner.next != null)stack.Push(runner.next);
                runner.next = runner.child;
                runner.next.prev = runner;
                runner.child = null;
            }
            if(runner.next==null && stack.Count>0){
                runner.next = stack.Pop();
                runner.next.prev = runner;
            }
            runner = runner.next;
        }
        return head;
    }
}
