using System;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        var root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.right = new TreeNode(1);
        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);
        root.left.right.left = new TreeNode(7);
        root.left.right.right = new TreeNode(4);
        root.right.right = new TreeNode(8);
        root.right.left = new TreeNode(0);

        Console.WriteLine(solution.LowestCommonAncestor(root, root.left, root.right).val);
    }
}
