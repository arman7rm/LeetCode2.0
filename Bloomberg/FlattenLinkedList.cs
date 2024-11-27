public partial class Solution {
    public class Node{
        public Node next;
        public Node prev;
        public Node child;
        public Node() {

        }
    }
    public Node Flatten(Node head) {
        if (head == null) return null;

        var stack = new Stack<Node>();
        var runner = head;

        while (runner != null) {
            if (runner.child != null) {
                // If there's a next node, push it onto the stack
                if (runner.next != null) {
                    stack.Push(runner.next);
                }

                // Flatten the child list
                runner.next = runner.child;
                runner.next.prev = runner;
                runner.child = null; // Clear the child pointer
            }

            // If we reach the end of the current list and there are nodes on the stack
            if (runner.next == null && stack.Count > 0) {
                var nextNode = stack.Pop();
                runner.next = nextNode;
                nextNode.prev = runner;
            }

            runner = runner.next;
        }

        return head;
    }
}
