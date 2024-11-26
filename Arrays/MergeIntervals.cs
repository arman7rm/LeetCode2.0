using System.Reflection.Metadata;
using System.Runtime;

public partial class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1) return intervals;

        var arr = new List<int[]>(intervals);
        arr.Sort((a, b) => a[0].CompareTo(b[0]));
        int first = 0, second = 1;
        
        while (second < arr.Count)
        {
            if (arr[first][1] >= arr[second][0] || arr[first][1] >= arr[second][1])
            {
                arr[first][0] = Math.Min(arr[first][0], arr[second][0]);
                arr[first][1] = Math.Max(arr[second][1], arr[first][1]);
                arr.RemoveAt(second);
            }
            else
            {
                first++;
                second++;
                if (second == arr.Count) arr.Add(arr[second - 1]);
            }
        }
        return arr.ToArray();
    }
}