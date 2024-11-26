using System.Text;

public partial class Solution {
    public string DecodeString(string s) {
        var res = new StringBuilder();
        int i = 0;

        while (i < s.Length) {
            if (Char.IsLetter(s[i])) {
                // Append the letter directly
                res.Append(s[i]);
                i++;
            } else if (Char.IsDigit(s[i])) {
                // Read the number (repeat count)
                int repeat = 0;
                while (i < s.Length && Char.IsDigit(s[i])) {
                    repeat = repeat * 10 + (s[i] - '0');
                    i++;
                }

                // Skip the opening bracket '['
                i++;  // Move past '['
                int start = i;
                int bracketCount = 1;

                // Find the corresponding closing bracket ']'
                while (bracketCount > 0) {
                    if (s[i] == '[') bracketCount++;
                    if (s[i] == ']') bracketCount--;
                    i++;
                }

                // Recursively decode the substring within the brackets
                string decoded = DecodeString(s.Substring(start, i - start - 1));

                // Append the decoded substring 'repeat' times
                for (int j = 0; j < repeat; j++) {
                    res.Append(decoded);
                }
            }
        }
        return res.ToString();
    }
}