/*
    2 pointers
*/

using System.Diagnostics;

public class Solution {
    public bool BackspaceCompare(string s, string t)
    {
        int l = s.Length - 1;
        int r = t.Length - 1;

        while (true)
        {
            l = NextValidIndex(s, l);
            r = NextValidIndex(t, r);

            if(l<0 || r<0) return l==r;
            if(s[l]!=t[r]) return false;
            l--; r--;
        }
    }

    private int NextValidIndex(string str, int i)
    {
        var skip = 0;
        while (i >= 0)
        {
            if(str[i] == '#')   skip++; // if # - increase skip
            else if(skip > 0)   skip--; // if not # - reduce skip
            else                break;  // if skip == 0 - return valid index

            i--;
        }
        return i;
    }

    public static void Main()
    {
        var sol = new Solution();

        // s = "y#fo##f"
        // t = "y#f#o##f"
        sol.Assert("y#fo##f", "y#f#o##f");

        // s = "bxj##tw"
        // t = "bxo#j##tw"
        sol.Assert("bxj##tw", "bxo#j##tw");

        // s = "a##c"
        // t = "#a#c"
        sol.Assert("a##c", "#a#c");

        // Input: s = "ab#c", t = "ad#c"
        // Output: true
        // Explanation: Both s and t become "ac".
        sol.Assert("ab#c", "ad#c");

        // Input: s = "ab##", t = "c#d#"
        // Output: true
        // Explanation: Both s and t become "".
        sol.Assert("ab##", "c#d#");
    
        // Input: s = "a#c", t = "b"
        // Output: false
        // Explanation: s becomes "c" while t becomes "b".
        sol.AssertNot("a#c", "b");

        Console.WriteLine("Tests passed!");
    }

    private void Assert(string s, string t)
    {
        var res = BackspaceCompare(s, t);
        Debug.Assert(res);
    }
    private void AssertNot(string s, string t)
    {
        var res = BackspaceCompare(s, t);
        Debug.Assert(!res);
    }
}