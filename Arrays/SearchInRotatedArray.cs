public partial class Solution
{
    public int SearchInRotatedArray(int[] nums, int target) {
        if(nums.Length==0)return -1;
        if(nums.Length==1)return nums[0]==target?0:-1;
        int start = findStart(nums, 0, nums.Length-1);
        if(target<=nums[nums.Length-1]){
            return binarySearch(nums, target, start, nums.Length-1);
        }
        return binarySearch(nums, target, 0, start>0?start-1:nums.Length-1);
    }

    public int findStart(int[] nums, int l, int r){
        if(nums[l]<nums[r])return l;
        if(r-l<=1)return r;
        int m = (r-l)/2+l;
        if(nums[l]>nums[m]){
            return findStart(nums, l, m);
        }
        return findStart(nums, m, r);
        
    }
    public int binarySearch(int[] nums, int t, int l, int r){
        int m = (r-l+1)/2+l;
        if(nums[m]==t)return m;
        if(r-l==0)return -1;
        if(t<nums[m]){
            return binarySearch(nums, t, l, m-1);
        }
        return binarySearch(nums, t, m, r);
    }
}

