using System.Reflection.Metadata;
using System.Runtime;

public partial class Solution{
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var res = new List<IList<int>>();
        findCombos(ref res, candidates,new List<int>(), target, 0,0);
        return res;
    }
    public void findCombos(ref List<IList<int>>res,int[] candidates,List<int> list, int target, int sum, int start){
        if(sum==target){
            res.Add(new List<int>(list));
            return;
        }
        for(int i=start; i<candidates.Length; i++){
            sum += candidates[i];
            list.Add(candidates[i]);
            if(sum<=target)findCombos(ref res, candidates,list, target, sum,i);
            list.RemoveAt(list.Count-1);
            sum -= candidates[i];
        }
    }
}