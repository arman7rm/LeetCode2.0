using System;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        int[] candidates = new int[] {3,5,8};
        var res = (solution.CombinationSum(candidates, 11));
        foreach(var row in res){
            foreach(var num in row){
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
