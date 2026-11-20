using System.Diagnostics;

public class Solution {
    public int NumJewelsInStones(string jewels, string stones) {
        var set = jewels.ToCharArray().ToHashSet();
        var map = new Dictionary<char, int>();
        foreach(char ch in stones)
        {
            if(map.TryGetValue(ch, out var count))  map[ch] = ++count;
            else map[ch] = 1;
        }
        int totalCount = 0;
        foreach(var pair in map)
        {
            if(set.Contains(pair.Key)) totalCount += pair.Value;
        }
        return totalCount;
    }

    static void Main() {
        var sol = new Solution();
        sol.Assert("aA", "aAAbbbb", 3);
        sol.Assert("z", "ZZ", 0);
        Console.WriteLine("Tests passed!");
    }

    void Assert(string jewels, string stones, int expected)
    {
        var actual = NumJewelsInStones(jewels, stones);
        Debug.Assert(actual == expected);
    }
}