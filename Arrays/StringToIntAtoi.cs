public partial class Solution {
    public int MyAtoi(string s) {
        if(s.Length==0) return 0;
        int start = 0;
        while(start<s.Length && s[start]==' '){
            start++;
        }
        int sign = 1;
        if(start<s.Length){
            if(s[start]=='-'){
                sign = -1;
                start++;
            }else if(s[start]=='+'){
                start++;
            }
        }
        while(start<s.Length && s[start]=='0'){
            start++;
        }
        if(start==s.Length || !char.IsNumber(s[start])) return 0;
        int end = start;
        while(end<s.Length && char.IsNumber(s[end])){
            end++;
        }
        if(Int32.TryParse(s.Substring(start, end-start), out int num)) return num*sign;
        return sign==1? Int32.MaxValue : Int32.MinValue;
    }
}