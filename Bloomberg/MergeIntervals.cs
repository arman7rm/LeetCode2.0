public partial class Solution {
    public int[][] MergeIntervals(int[][] intervals) {
        if(intervals.Length==1) return intervals;
        var arr = intervals.ToList();
        arr.Sort((a,b) => a[0].CompareTo(b[0]));
        var res = new List<int[]>();
        var curr = arr[0];
        for(int i=1; i<arr.Count; i++){
            if(arr[i][0]<=curr[1] || arr[i][1] <=curr[1]){
                curr[0] = Math.Min(curr[0], arr[i][0]);
                curr[1] = Math.Max(arr[i][1], curr[1]);
            }else{
                res.Add(new int[] {curr[0], curr[1]});
                curr[0] = arr[i][0];
                curr[1] = arr[i][1];
            }
            if(i==arr.Count-1){
                res.Add(curr);
            }
        }
        return res.ToArray();
    }
}