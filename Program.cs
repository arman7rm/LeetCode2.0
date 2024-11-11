using System;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        var arr = new List<int[]>();
        arr.Add(new int[] { 1,4});
        arr.Add(new int[] { 4,6});
        solution.Merge(arr.ToArray());
    }
}
