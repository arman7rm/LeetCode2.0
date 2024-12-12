using System.Text;
public partial class Solution{

public static int DecodeVariations(string s){
        int count = 0;
        var list = new List<string>();
        DecodeVariations(s, 0, ref count, ref list, new StringBuilder());
        foreach(var st in list){
            Console.WriteLine(st);
        }
        return count;
    }
    public static void DecodeVariations(string s, int start, ref int count, ref List<string> list, StringBuilder curr)
    {
        if (start == s.Length - 1)
        {
            
            curr.Append(s[start]);
            curr.Append(",");
            list.Add(curr.ToString());
            curr.Remove(curr.Length-2, 2);
            count++;
            return;
        }
        
        if (s[start] == 0) return;
        if (start < s.Length - 1)
        {
            if (int.Parse($"{s[start]}{s[start + 1]}") < 27)
            {
                curr.Append(s[start]);
                curr.Append(s[start+1]);
                curr.Append(",");
                DecodeVariations(s, start + 2, ref count, ref list, curr);
                curr.Remove(curr.Length-3, 3);
            }
        }
        curr.Append(s[start]);
        curr.Append(",");
        DecodeVariations(s, start + 1, ref count, ref list, curr);
        curr.Remove(curr.Length-2, 2);
    }
}