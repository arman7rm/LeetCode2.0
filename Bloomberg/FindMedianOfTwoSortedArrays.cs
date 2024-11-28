public partial class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if(nums1.Length>nums2.Length) return FindMedianSortedArrays(nums2,nums1);
        int m = nums1.Length, n = nums2.Length;
        int l = 0, r=m;
        while(l<=r){
            int p1 = l+ (r-l)/2;
            int p2 = (m+n+1)/2 - p1;

            int maxLeft1 = p1 == 0 ? int.MinValue : nums1[p1-1];
            int minRight1 = p1 == m ? int.MaxValue : nums1[p1];

            int maxLeft2 = p2 == 0 ? int.MinValue : nums2[p2-1];
            int minRight2 = p2 == n ? int.MaxValue : nums2[p2];

            if(maxLeft1 <= minRight2 && maxLeft2 <= minRight1){
                if((m+n)%2==0){
                    return (Math.Max(maxLeft1, maxLeft2)+Math.Min(minRight1, minRight2))/2.0;
                }
                return Math.Max(maxLeft1, maxLeft2);
            }
            else if(maxLeft2 > minRight1){
                l = p1+1;
            }else{
                r = p1-1;
            }
        }
        throw new ArgumentException("Arrays are not sorted");
    }
}