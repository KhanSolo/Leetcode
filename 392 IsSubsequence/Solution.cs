/*
    2 pointers
    O(n) complexity
    O(1) memory
*/

using System.Diagnostics;

public class Solution {
    public bool IsSubsequence(string s, string t)
    {
        int j=0;
        for(int i=0; i<t.Length; ++i)
        {
            if (s[j] == t[i])
            {
                j++;
                if(IsFound()) break;
            }
        }
        return IsFound();
        bool IsFound() => j == s.Length;
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert("abc", "ahbgdc", true);
        sol.Assert("axc", "ahbgdc", false);
        sol.Assert("","",true);
        Console.WriteLine("Tests passed!");
    }

    private void Assert(string sub, string str, bool expected)
        =>
            Debug.Assert(IsSubsequence(sub, str) == expected, $"Should be {expected}");
}