using System.Diagnostics;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int maxLen = 0;
        var set = new HashSet<int>();
        int l=0, r=0, curLen;
        while (r < s.Length)
        {
            while(set.Contains(s[r]))
            {
                set.Remove(s[l]);
                l++;
            }
            set.Add(s[r]);
            curLen = r-l+1;
            maxLen=Math.Max(maxLen, curLen);            
            r++;
        }

        return maxLen;
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert("abcabcbb", 3);
        sol.Assert("bbbbb", 1);
        sol.Assert("pwwkew", 3);
        Console.WriteLine("Tests passed!");
    }

    void Assert(string s, int expected)
    {
        var actual = LengthOfLongestSubstring(s);
        Debug.Assert(actual == expected, $"actual {actual}, expected {expected}");
    }
}
