using Microsoft.VisualBasic;

public partial class Solution{

    // TestCase:
    
    //     var root = new TreeNode(3);
    //     root.left = new TreeNode(5);
    //     root.right = new TreeNode(1);
    //     root.left.left = new TreeNode(6);
    //     root.left.right = new TreeNode(2);
    //     root.left.right.left = new TreeNode(7);
    //     root.left.right.right = new TreeNode(4);
    //     root.right.right = new TreeNode(8);
    //     root.right.left = new TreeNode(0);
    //     TreeNode p = root.left, q = root.right;
        

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var pSet = new HashSet<TreeNode>();
        var qSet = new HashSet<TreeNode>();
        var pStack = new Stack<TreeNode>();
        var qStack = new Stack<TreeNode>();
        bool found =false;
        preOrder(ref pStack, p, root, ref found);
        found = false;
        preOrder(ref qStack, q, root, ref found);

        while(qStack.Count>0 || pStack.Count>0){
            if(qStack.Count>0){
                if(pSet.Contains(qStack.Peek())) return qStack.Peek();
                qSet.Add(qStack.Pop());
            }
            if(pStack.Count>0){
                if(qSet.Contains(pStack.Peek())) return pStack.Peek();
                pSet.Add(pStack.Pop());
            }
        }
        return root;
    }

    public void preOrder(ref Stack<TreeNode> s, TreeNode target, TreeNode? n, ref bool found){
        if(n!=null && !found){
            s.Push(n);
            if(n==target){
                found = true;
                return;
            }
            preOrder(ref s, target, n.left, ref found);
            preOrder(ref s, target, n.right, ref found);
            if(!found)s.Pop();
        }
    }
}