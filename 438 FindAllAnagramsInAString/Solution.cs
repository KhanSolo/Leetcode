using System.Diagnostics;

public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        if(p.Length > s.Length) return [];

        var pmap = new Dictionary<char, int>();
        for(int i=0; i<p.Length; i++) // populating pmap
            pmap[p[i]] = pmap.GetValueOrDefault(p[i]) + 1;

        var result = new List<int>();
        for(int i=0; i<p.Length; i++) //first window - subtracting first p.Length chars from pmap
            pmap[s[i]] = pmap.GetValueOrDefault(s[i]) - 1;

        var nonZero = 0; // number of non zero elements in pmap
        foreach(var pair in pmap) nonZero += pair.Value is not 0 ? 1 : 0;

        if(nonZero is 0) result.Add(0); // if it's zero - anagram

        int l=1, r=p.Length;
        while (r < s.Length)
        {
            Update(s[l-1], 1); // handle a left side (previous char that went out of a window)
            Update(s[r], -1); // handle a right side (next char that went into the window)

            if(nonZero is 0) result.Add(l);

            l++; r++;
        }
        return result;

        void Update(char c, int delta)
        {
            var oldVal = pmap.GetValueOrDefault(c);
            var newVal = oldVal + delta;
            pmap[c] = newVal;

            if(oldVal != 0 && newVal == 0) nonZero -= 1; // -1 or 1 => 0
            if(oldVal == 0 && newVal != 0) nonZero += 1; // 0 => -1 or 1
        }
    }

    static void Main()
    {
        var sol = new Solution();

        sol.Assert("baa", "aa", [1]);
        sol.Assert("aa", "bb", []);
        sol.Assert("cbaebabacd", "abc", [0,6]);
        sol.Assert("abab","ab", [0,1,2]);

        Console.WriteLine("Tests passed!");
    }

    private void Assert(string s, string p, int[] expected)
    {
        var actual = FindAnagrams(s,p);
        Debug.Assert(actual.Count == expected.Length,
             $"actual {actual.Count}, expected {expected.Length}");
        for(int i=0; i<actual.Count; i++)
        {
            Debug.Assert(actual[i]==expected[i],
             $"actual[{i}]: {actual[i]}, expected[{i}]: {expected[i]}");
        }
    }
}
