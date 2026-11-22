
using System.Diagnostics;
using System.Linq;

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var map = new Dictionary<string, IList<string>>();
        for(int i=0; i<strs.Length; i++)
        {
            var arr = strs[i].ToCharArray();
            Array.Sort(arr);
            var key = new string(arr);

            if(map.TryGetValue(key, out var collection))            
                collection.Add(strs[i]);            
            else            
                map[key] = [strs[i]];
        }

        return [.. map.Select(pair => pair.Value)];
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert([""],[[""]]);
        sol.Assert(["a"],[["a"]]);
        sol.Assert(["eat","tea","tan","ate","nat","bat"],
                  [["eat","tea","ate"],["tan","nat"],["bat"]]);
        Console.Write("Tests passed!");
    }

    private void Assert(string[] strs, IList<IList<string>> expected)
    {
        var actual = GroupAnagrams(strs);
        Debug.Assert(actual.Count == expected.Count);
        for(int i = 0; i<actual.Count; i++)
        {
            var act = actual[i];
            var exp = expected[i];
            Debug.Assert(act.Count == exp.Count);
            for(int j=0; j<act.Count; j++)
            {
                Debug.Assert(act[j]==exp[j], $"act[{j}]: {act[j]}; exp[{j}]: {exp[j]}");
            }
        }
    }
}