public partial class Solution{
    public int TriangleNumber(int[] nums) {
        var arr = nums;
        Array.Sort(arr); 
        int count = 0;
        var firstIndexSmaller = new Dictionary<int, int>();
        for(int i=0; i<arr.Length-2; i++){
            for(int j=i+1; j<arr.Length-1; j++){
                int sum = arr[i]+arr[j];
                if(!firstIndexSmaller.ContainsKey(sum)) firstIndexSmaller[sum] = findFirstIndexSmaller(arr, sum, 0 , arr.Length-1);
                for(int k=j+1; k<=firstIndexSmaller[sum]; k++){
                    if(k==i || k==j)continue;
                    count++;
                }
            }
        } 
        
        return count;
    }
    public int findFirstIndexSmaller(int[] arr, int target, int l, int r){
        int m = (r-l+1)/2 +l;
        if(r-l==1){
            if(arr[r]<target)return r;
            if(arr[l]<target)return l;
            return -1;
        }
        if(r-l==0){
            if(arr[r]>=target) return -1;
            return r;
        }
        if(target>arr[m] && m<arr.Length-1 && target<=arr[m+1]) return m;
        if(target<=arr[m]){
            return findFirstIndexSmaller(arr, target, l, m);
        }
        return findFirstIndexSmaller(arr, target, m, r);
    }
}