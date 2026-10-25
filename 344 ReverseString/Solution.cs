/*
	2 pointers
	O(n) complexity
	O(1) memory
*/
using System.Diagnostics;

public class Solution
{
    public void ReverseString(char[]? s) {
        if(s is null || s.Length < 2) return;

        int l = 0; int r = s.Length - 1;
        while (l < r)
        {
            (s[l], s[r]) = (s[r], s[l]);
            l++; r--;
        }
    }

    static void Main()
    {
        var sol = new Solution();
        sol.ReverseString(default);

        {
            var s = "";
            var arr = s.ToCharArray();
            sol.ReverseString(arr);
            Debug.Assert(arr.Length == 0);
        }

        {
            var s = "abba aboba";
            var arr = s.ToCharArray();
            sol.ReverseString(arr);
            var res = new string(arr);
            Debug.Assert(res == "aboba abba");
        }
    }
}