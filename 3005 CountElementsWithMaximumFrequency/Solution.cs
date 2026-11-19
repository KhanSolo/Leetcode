
using System.Diagnostics;

public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        var map = new Dictionary<int, int>();
        foreach(var num in nums)
        {
            if(map.TryGetValue(num, out var count))            
                map[num] = ++count;
             else            
                map[num] = 1;            
        }
        int maxCount = map.Max(pair => pair.Value);
        int pairCount = map.Count(pair => pair.Value == maxCount);

        return maxCount * pairCount;
    }

    static void Main(){
        var sol = new Solution();
        sol.Assert([1,2,2,3,1,4], 4);
        sol.Assert([1,2,3,4,5], 5);
        Console.WriteLine("Tests passed!");
    }

    void Assert(int[] nums, int expected)
    {
        var actual = MaxFrequencyElements(nums);
        Debug.Assert(actual == expected);        
    }
}