using System.Diagnostics;
using System.Text;

public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs is null || strs.Length is 0) return "";
        if (strs.Length is 1) return strs[0];

        int limit = int.MaxValue;
        foreach(var str in strs) limit = Math.Min(limit, str.Length);        

        var sb = new StringBuilder();
        int chIdx = 0;
        var firstStr = strs[0];
        while (chIdx < limit)
        {
            bool match = true;

            char currentChar = firstStr[chIdx];
            for(int w = 1; w < strs.Length; w++)
            {
                var nextStr = strs[w];
                var nextChar = nextStr[chIdx];
                if(currentChar != nextChar)
                {
                    match = false;
                    break;
                }
            }

            if(match) sb.Append(currentChar);
            else break;
            chIdx++;
        }
        return sb.ToString();
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert(["flower", "flow", "flight"], "fl");
        sol.Assert(["dog", "racecar", "car"], "");
        sol.Assert(["abc", "ab","abcd"], "ab");
        sol.Assert([],"");
        Console.WriteLine("Tests passed!");
    }

    private void Assert(string[] strs, string expected)
    {
        var actual = LongestCommonPrefix(strs);
        Debug.Assert(actual.Length == expected.Length);
        Debug.Assert(actual == expected, $"actual {actual}, expexted {expected}");
    }
}
