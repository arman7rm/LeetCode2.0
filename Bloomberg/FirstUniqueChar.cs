public partial class Solution {
    public int FirstUniqChar(string s) {
        var map = new Dictionary<char, int>();
        foreach(var c in s){
            if(!map.ContainsKey(c)) map[c] = 0;
            map[c]++;
        }
        for(int i=0; i<s.Length; i++){
            if(map[s[i]]==1) return i;
        }
        return -1;
    }
}