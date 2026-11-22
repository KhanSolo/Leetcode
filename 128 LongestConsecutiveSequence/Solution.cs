using System.Diagnostics;

public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = nums.ToHashSet();
        var maxLen = 0;
        foreach(var num in set)
        {
            var prev = num-1;
            var contains = set.Contains(prev);
            if (contains) continue;
            
            var next = num + 1;
            var curLen = 1;
            while(set.Contains(next++)) // this is O(n), not a O(n^2) 
               curLen++;                // because every number is checked just one time!
            
            maxLen = Math.Max(maxLen, curLen);
        }
        return maxLen;
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert([], 0);
        sol.Assert([100, 4, 200, 1, 3, 2], 4);
        sol.Assert([0, 3, 7, 2, 5, 8, 4, 6, 0, 1], 9);
        sol.Assert([1, 0, 1, 2], 3);
        Console.WriteLine("Tests passed!");
    }

    private void Assert(int[] nums, int expected)
    {
        var actual = LongestConsecutive(nums);
        Debug.Assert(actual == expected);
    }
}