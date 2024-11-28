/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public partial class Solution {
    public bool IsValidBST(TreeNode root) {
        Double max= Int64.MaxValue;
        Double min = Int64.MinValue;
        return inOrderTraversal(root, max, min);
    }

    public bool inOrderTraversal(TreeNode n, Double max, Double min){
        if(n!=null){
            if(n.val>=max || n.val<=min) return false;
            return inOrderTraversal(n.left, n.val, min)&&inOrderTraversal(n.right, max, n.val);
        }
        return true;
    }
}