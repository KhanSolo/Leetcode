using System;
using System.Diagnostics;

public class Solution {
    public int FirstUniqChar(string s) {
        var map = new Dictionary<char,int>();
        for(int i=0; i < s.Length; i++)
        {
            var ch = s[i];
            if(map.TryGetValue(ch, out var count))
            {
                count++;
                map[ch]=count;
            } else
            {
                map[ch]=1;
            }            
        }
        for(int i=0; i < s.Length; i++)
        {
            var ch=s[i];
            if(map.TryGetValue(ch, out var count))
            {
                if(count is 1)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert("leetcode", 0);
        sol.Assert("loveleetcode", 2);
        sol.Assert("aabb", -1);
        Console.WriteLine("Tests passed!");
    }

    void Assert(string s, int expected)
    {
        var actual = FirstUniqChar(s);
        Debug.Assert(actual == expected, $"actual:{actual}, expected:{expected}");
    }
}
