public partial class Solution{
    public static int IndexEqualsValueSearch(int[] arr)
    {
        // your code goes here
        return BinarySearch(arr, 0, arr.Length - 1);
    }

    public static int BinarySearch(int[] arr, int l, int r)
    {
        if (r < l) return -1;
        int m = (r - l) / 2 + l;
        if (arr[m] == m) return m;
        if (arr[m] < m)
        {
            return BinarySearch(arr, m + 1, r);
        }
        return BinarySearch(arr, l, m - 1);
    }
}