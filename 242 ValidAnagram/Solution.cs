
using System.Diagnostics;

public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;

        var map = new Dictionary<char, int>();
        foreach(var c in s)
        {
            if(map.TryGetValue(c, out var count))
            {
                count++;
                map[c] = count;
            } else
            {
                map[c] = 1;
            }
        }

        foreach(var c in t)
        {
            if(map.TryGetValue(c, out var count))
            {
                count--;
                if(count is 0) map.Remove(c);                
                else           map[c]=count;
            } else
            {
                map[c] = -1;
            }
        }

        return map.Count == 0;
    }

    static void Main()
    {
        var sol = new Solution();
        sol.Assert("anagram", "nagaram", true);
        sol.Assert("rat", "car", false);
        Console.WriteLine("Tests passed!");
    }

    private void Assert(string s, string t, bool expected)
    {
        var actual = IsAnagram(s, t);
        Debug.Assert(actual == expected);
    }
}
