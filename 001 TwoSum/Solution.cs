/*
	Hash tables
	O(n) complexity
	O(n) memory
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Solution
 {
    public static int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int,int>();
        for(var i = 0; i<nums.Length; ++i)
        {
            var cur = nums[i];
            var rest = target - cur;
            if(map.TryGetValue(rest, out var idx))
            {
                return [i, idx];
            }
            else
            {
                map[cur] = i;
            }
        }
        return [];
    }

    static bool Eq(int[] actual, int[] expected)
    {
        if(actual is null || expected is null) return false;
        if(actual.Length != expected.Length) return false;
        Array.Sort(actual); Array.Sort(expected);
        for(int i = 0; i<actual.Length; ++i)
        {
            if(actual[i] != expected[i]) return false;    
        }        
        return true;
    }

    static void EqWrite(int[] actual, int[] expexted)
        =>
            Console.WriteLine(Eq(actual, expexted) ? "Success" : "Failed");    

    static void Main()
    {
        // Example 1:
        // Input: nums = [2,7,11,15], target = 9
        // Output: [0,1]
        // Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].        
        {
            var result = TwoSum([2,7,11,15], 9);
            EqWrite(result, [0,1]);
        }       

        // Example 2:
        // Input: nums = [3,2,4], target = 6
        // Output: [1,2]
        {
            var result = TwoSum([3,2,4], 6);
            EqWrite(result, [1,2]);
        }

        // Example 3:
        // Input: nums = [3,3], target = 6
        // Output: [0,1]
        {
            var result = TwoSum([3,3], 6);
            EqWrite(result, [0,1]);
        }
    }
}