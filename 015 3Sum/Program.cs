using System.Collections.Generic;
using System.Diagnostics;

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        if(nums.Length < 3 || nums.Length > 3000) return [];
        // 3 <= nums.length <= 3000
        // -10^5 <= nums[i] <= 10^5
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for(var i = 0; i<nums.Length-2; ++i)
        {
            // No possible triplet can sum to zero
            // if the smallest remaining number is positive.
            if (nums[i] > 0)
                break;

            if (i>0 && nums[i] == nums[i-1]) continue; // avoiding duplicates since nums is sorted

            var a = nums[i];
            var l = i+1;
            var r = nums.Length - 1;
            while (l < r)
            {
                (var b, var c) = (nums[l], nums[r]);
                if(a + b + c == 0) // a+b+c=0
                {
                    var three = new List<int>(){a, b, c};
                    result.Add(three);
                    
                    l++;
                    r--;

                    // removing duplicates for repeating numbers after moving 2 pointers
                    while (l<r && nums[l] == nums[l-1]) l++;
                    while (l<r && nums[r] == nums[r+1]) r--;

                } else
                // should be: -a = b+c
                if(-a > b + c) // -a > b + c
                {
                    l++;
                } else {        // -a < b + c
                    r--;
                }
            }
        }

        return result;
    }

    public static void Main()
    {
        var sol = new Solution();

        {
            var res = sol.ThreeSum([-1,0,1,2,-1,-4]);
            AssertResult(res, 2, "Example 1");

            // Input: nums = [-1,0,1,2,-1,-4]
            // Output: [[-1,-1,2],[-1,0,1]]
            // Explanation: 
            // nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
            // nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
            // nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
            // The distinct triplets are [-1,0,1] and [-1,-1,2].
            // Notice that the order of the output and the order of the triplets does not matter.
        }
        {
            var res = sol.ThreeSum([0,1,1]);
            AssertResult(res, 0, "Example 2");
            // Input: nums = [0,1,1]
            // Output: []
            // Explanation: The only possible triplet does not sum up to 0.
        }
        {  
            var res = sol.ThreeSum([0,0,0]);
            AssertResult(res, 1, "Example 3");

            // Input: nums = [0,0,0]
            // Output: [[0,0,0]]
            // Explanation: The only possible triplet sums up to 0.
        }
        {
            var res = sol.ThreeSum([0,0,0,0]);
            AssertResult(res, 1, "Example 4");
            // Notice that the solution set must not contain duplicate triplets.
        }
        {
            var res = sol.ThreeSum([-2,0,1,1,2]);
            AssertResult(res, 2, "Example 5");
        }

        Console.WriteLine("Tests passed");
    }

    static void AssertResult(IList<IList<int>> result, int expextedSubarrays, string? msg = null)
    {
        if (msg is not null) Console.WriteLine(msg);
        Debug.Assert(result.Count == expextedSubarrays);
        for(var i = 0; i<result.Count; ++i) {
            Debug.Assert(result[i].Count == 3);
            Debug.Assert(result[i].IsZero());
        }
    }
}

public static class IEnumerableExtensions
{
    public static bool IsZero(this IEnumerable<int> list)
    {
        var sum = 0;
        foreach(var i in list) sum+=i;
        return sum == 0;
    }
}