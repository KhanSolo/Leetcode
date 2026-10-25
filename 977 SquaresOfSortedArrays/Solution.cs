/*
    2 pointers
    O(n) complexity
    O(n) memory
*/
using System.Diagnostics;

public class Solution {
    public int[] SortedSquares(int[] nums) {
        var result = new int[nums.Length];

        var l = 0;
        var r = nums.Length-1;
        for (int i=nums.Length-1; i>=0; --i) // filling backward order
        {
            var sql = nums[l] * nums[l];
            var sqr = nums[r] * nums[r];
            if(sql > sqr)
            {
                result[i] = sql;
                l++;                
            }
            else
            {
                result[i] = sqr;
                r--;
            }
        }
        
        return result;
    }

    public static void Main()
    {
        var sol = new Solution();

        {
            var result = sol.SortedSquares([-4,-1,0,3,10]);
            AssertArray(result, [0,1,9,16,100], "Example 1");
            // Input: nums = [-4,-1,0,3,10]
            // Output: [0,1,9,16,100]
            // Explanation: After squaring, the array becomes [16,1,0,9,100].
            // After sorting, it becomes [0,1,9,16,100].
        }

        {
            var result = sol.SortedSquares([-7,-3,2,3,11]);
            AssertArray(result, [4,9,9,49,121], "Example 2");
            // Input: nums = [-7,-3,2,3,11]
            // Output: [4,9,9,49,121]
        }

        Console.WriteLine("Tests passed!");
    }

    private static void AssertArray(int[] actual, int[] expected, string msg)
    {
        Console.WriteLine(msg);
        Debug.Assert(actual.Length == expected.Length, $"{msg}: lenghts differ");
        for(int i=0; i<actual.Length; ++i)
        {
            Debug.Assert(actual[i]==expected[i], 
                $"{msg}: actual {actual[i]}; expected {expected[i]}; i = {i}");
        }
    }
}