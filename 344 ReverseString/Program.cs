
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
        var s = new Solution();
        s.ReverseString(default);

        var s2 = "";
        var arr2 = s2.ToCharArray();
        s.ReverseString(arr2);
        Debug.Assert(arr2.Length == 0);

        var s3 = "abba aboba";
        var arr3 = s3.ToCharArray();
        s.ReverseString(arr3);
        var res = new string(arr3);
        Debug.Assert(res == "aboba abba");
    }
}